import * as alt from 'alt-client';
import * as native from 'natives';

const url = `http://resource/client/Firmen/Tuner/TunerMenu.html`;
let view = null;
let cameraControlsInterval = null;
let cloneVehicle: alt.Vehicle = null;
let tuningParts = [];
let primCol = [];
let secCol = [];
let selectedModifikation = -1;
let lastModifikaitonList = [];
let lastModifikaiton = -1;
let freeCamTuner = false;
let nos = false;
let chip = false;
let startMods = [];
let usedsynced = false;

alt.on('ShowTuner', ShowTunerMenu);

function ShowTunerMenu(veh: alt.Vehicle) {
    if (view == null && veh != null) {
        selectedModifikation = -1;
        view = new alt.WebView(url);
        view.on('closeView', closeView);
        view.on('setVehColor', setVehColor);
        view.on('changeTuning', changeTuning);
        view.on('selectedMod', selectedMod);
        view.on('setModValue', setMod);
        view.on('freeCam', freeCam);
        view.on('setMod', setMod);
        view.on('setNeon', setNeon);
        view.on('addMod', addMod);
        view.on('setTiresType', setTiresType);
        view.on('setTires', setTires);
        view.on('setTireColor', setTireColor);
        view.on('addNos', addNos);
        view.on('addChip', addChip);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        cloneVehicle = veh;
        const tireColor = native.getVehicleExtraColours(cloneVehicle);
        view.emit(
            'updateTire',
            native.getVehicleWheelType(cloneVehicle),
            native.getVehicleMod(cloneVehicle, 23),
            tireColor[2]
        );
        if (cloneVehicle.hasSyncedMeta('SpeedBoost')) view.emit('setExtrasLoad', 100, 1);
        for (let i = 0; i < 50; i++) {
            tuningParts[i] = native.getVehicleMod(cloneVehicle, i);
            if (i == 22 || i == 18) {
                if (native.isToggleModOn(cloneVehicle, i)) {
                    view.emit('setExtrasLoad', i, 0);
                    tuningParts[i] = 0;
                }
            }
            if (i == 11 || i == 12 || i == 13) {
                if (tuningParts[i] != -1) view.emit('setExtrasLoad', i, tuningParts[i]);
            }
        }
        startMods = [...tuningParts];

        const col1 = native.getVehicleCustomSecondaryColour(cloneVehicle);
        secCol[0] = col1[1];
        secCol[1] = col1[2];
        secCol[2] = col1[3];
        const col2 = native.getVehicleCustomPrimaryColour(cloneVehicle);
        primCol[0] = col2[1];
        primCol[1] = col2[2];
        primCol[2] = col2[3];
        view.focus();
        showCursor(true);
    }
}

function freeCam() {
    showCursor(freeCamTuner);
    freeCamTuner = !freeCamTuner;
}

function selectedMod(mod) {
    if (cloneVehicle == null) return;
    if (selectedModifikation != -1) {
        lastModifikaitonList[selectedModifikation] = lastModifikaiton;
    }
    selectedModifikation = mod;
    lastModifikaiton = lastModifikaitonList[mod] == undefined ? -1 : lastModifikaitonList[mod];
    const currentMod = native.getVehicleMod(cloneVehicle, selectedModifikation);
    for (let x = 0; x < 255; x++) {
        const name = native.getModTextLabel(cloneVehicle, selectedModifikation, x);
        if (name == '' || name == null || name == undefined) continue;
        //alt.log(native.getFilenameForAudioConversation(name));
        view.emit('addButton', native.getFilenameForAudioConversation(name), x, currentMod == x);
    }
    view.emit('ShowMods');
}

function addChip(state) {
    if (cloneVehicle == null) return;
    chip = state;
    calculateProd(nos, chip);
}

function addNos(state) {
    if (cloneVehicle == null) return;
    nos = state;
    calculateProd(nos, chip);
}

function setTireColor(col) {
    if (cloneVehicle == null) return;
    native.setVehicleExtraColours(cloneVehicle, 0, col);
}

function setNeon(active, r, g, b) {
    if (cloneVehicle == null) return;
    if (active) native.setVehicleNeonColour(cloneVehicle, r, g, b);
    native.setVehicleNeonEnabled(cloneVehicle, 0, active);
    native.setVehicleNeonEnabled(cloneVehicle, 1, active);
    native.setVehicleNeonEnabled(cloneVehicle, 2, active);
    native.setVehicleNeonEnabled(cloneVehicle, 3, active);
}

function setTiresType(type) {
    if (cloneVehicle == null) return;
    native.setVehicleWheelType(cloneVehicle, type);
    view.emit('setMaxTires', native.getNumVehicleMods(cloneVehicle, 23));
    native.setVehicleMod(cloneVehicle, 23, 0, false);
    tuningParts[23] = 0;
    calculateProd(nos, chip);
}

function setTires(tires) {
    if (cloneVehicle == null) return;
    native.setVehicleMod(cloneVehicle, 23, tires, false);
    tuningParts[23] = tires;
    calculateProd(nos, chip);
}

function addMod(type, val) {
    if (cloneVehicle == null) return;
    lastModifikaiton = val;
    native.setVehicleMod(cloneVehicle, type, lastModifikaiton, false);
    tuningParts[type] = lastModifikaiton;
    alt.log('modifyer:' + native.getVehicleModModifierValue(cloneVehicle, type, lastModifikaiton));
    alt.log('Type: ' + type + ' | ' + val);
    if (type == 22) {
        native.toggleVehicleMod(cloneVehicle, 22, val > -1);
    }
    calculateProd(nos, chip);
}

function setMod(x) {
    if (cloneVehicle == null) return;
    lastModifikaiton = x;
    native.setVehicleMod(cloneVehicle, selectedModifikation, lastModifikaiton, true);
    tuningParts[selectedModifikation] = lastModifikaiton;
    alt.log('modifyer:' + native.getVehicleModModifierValue(cloneVehicle, selectedModifikation, lastModifikaiton));
    calculateProd(nos, chip);
}

function calculateProd(installnos, installchip) {
    let prod = 0;
    for (let x = 0; x < startMods.length; x++) {
        if (startMods[x] == tuningParts[x]) continue;
        if (x == 23 || 14) {
            prod += getProductsNeedForType(x);
            continue;
        }
        const modifyer = getProductsNeedForType(x) + getProductsNeedForType(x) * (tuningParts[x] + 1);
        prod += modifyer;
    }
    if (installnos) prod += 100;
    if (installchip) prod += 80;
    if (view != null) view.emit('setNeededProds', prod);
}

function getProductsNeedForType(type) {
    switch (type) {
        case 0:
            return 10;
        case 1:
            return 7;
        case 2:
            return 7;
        case 3:
            return 5;
        case 4:
            return 6;
        case 5:
            return 2;
        case 6:
            return 4;
        case 7:
            return 2;
        case 8:
            return 2;
        case 9:
            return 2;
        case 10:
            return 4;
        case 11:
            return 10;
        case 12:
            return 10;
        case 13:
            return 4;
        case 14:
            return 20;
        case 15:
            return 3;
        case 16:
            return 30;
        case 18:
            return 20;
        case 22:
            return 10;
        case 23:
            return 25;
        case 25:
            return 2;
        case 26:
            return 2;
        case 27:
            return 2;
        case 28:
            return 2;
        case 30:
            return 2;
        case 31:
            return 4;
        case 32:
            return 2;
        case 33:
            return 3;
        case 34:
            return 2;
        case 35:
            return 2;
        case 36:
            return 2;
        case 37:
            return 2;
        case 38:
            return 2;
        case 39:
            return 3;
        case 40:
            return 3;
        case 41:
            return 4;
        case 42:
            return 2;
        case 43:
            return 1;
        case 44:
            return 2;
        case 45:
            return 2;
        case 46:
            return 5;
        case 48:
            return 7;
    }
    return 10;
}

function changeTuning() {
    const col1 = native.getVehicleCustomSecondaryColour(cloneVehicle);
    secCol[0] = col1[1];
    secCol[1] = col1[2];
    secCol[2] = col1[3];
    const col2 = native.getVehicleCustomPrimaryColour(cloneVehicle);
    primCol[0] = col2[1];
    primCol[1] = col2[2];
    primCol[2] = col2[3];
    const getneonCol = native.getVehicleNeonColour(cloneVehicle);
    const neoncolor = [getneonCol[1], getneonCol[2], getneonCol[3]];
    const tireColor = native.getVehicleExtraColours(cloneVehicle);
    alt.emitServer(
        'SyncTuning',
        cloneVehicle,
        JSON.stringify(tuningParts),
        JSON.stringify(primCol),
        JSON.stringify(secCol),
        native.getVehicleNeonEnabled(cloneVehicle, 0),
        JSON.stringify(neoncolor),
        native.getVehicleWheelType(cloneVehicle),
        tireColor[2],
        nos,
        chip
    );
    alt.log(tuningParts);
    usedsynced = true;
}

function setVehColor(primary, r, g, b) {
    if (cloneVehicle != null) {
        if (primary == 1) native.setVehicleCustomPrimaryColour(cloneVehicle, r, g, b);
        else native.setVehicleCustomSecondaryColour(cloneVehicle, r, g, b);
    }
}

function handleControls() {
    //native.disableAllControlActions(1);
    if (!freeCamTuner) {
        native.disableAllControlActions(0);
        native.disableControlAction(0, 0, true);
        native.disableControlAction(0, 1, true);
        native.disableControlAction(0, 2, true);
        native.disableControlAction(0, 24, true);
        native.disableControlAction(0, 25, true);
    }
}

function showCursor(state) {
    try {
        alt.showCursor(state);
    } catch (err) {
        return;
    }
}

function closeView() {
    if (cameraControlsInterval !== undefined || cameraControlsInterval !== null) {
        alt.clearInterval(cameraControlsInterval);
        cameraControlsInterval = null;
    }
    if (view && view.destroy) {
        view.destroy();
    }
    view = null;
    alt.deleteMeta('noInv');
    showCursor(false);
    alt.emitServer('ResetTuningVehicle', cloneVehicle);
    if (!usedsynced) {
        for (let i = 0; i < 50; i++) {
            native.setVehicleMod(cloneVehicle, i, startMods[i], false);
        }
    }
    native.setVehicleCustomPrimaryColour(cloneVehicle, primCol[0], primCol[1], primCol[2]);
    native.setVehicleCustomSecondaryColour(cloneVehicle, secCol[0], secCol[1], secCol[2]);
    cloneVehicle = null;
    nos = false;
    chip = false;
    usedsynced = false;
}
