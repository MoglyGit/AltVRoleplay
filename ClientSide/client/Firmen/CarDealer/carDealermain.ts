import * as alt from 'alt-client';
import * as native from 'natives';
import * as cam from './carDealerCam';

const url = `http://resource/client/Firmen/CarDealer/CarDealer.html`;
let view = null;
let cameraControlsInterval = null;
export let cloneVehicle = null;
let cloneId = null;
const fModel = alt.hash('mp_f_freemode_01');
export let allowKeys = true;

alt.on('ShowCarDealerMenu', ShowCarDealerMenu);
alt.onServer('ShowCarDealerMenu', ShowCarDealerMenu);
alt.onServer('AllowCar', changeVehicleFroMServerSide);

function ShowCarDealerMenu() {
    if (view == null) {
        view = new alt.WebView(url);
        view.on('closeView', closeView);
        view.on('changeVehicle', changeVehicle);
        view.on('setVehColor', setVehColor);
        view.on('setInText', setInText);
        view.on('buyVehicle', buyVehicle);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        showCursor(true);
        alt.emitServer('teleportCarDealer');
        alt.setMeta('noInv', '1');
        native.freezeEntityPosition(alt.Player.local.scriptID, true);

        cloneId = native.createPed(0, fModel, 204.73846, -996.23737, -99.01465, 0, false, false);
        native.setEntityHeading(cloneId, 90);

        cam.createPedEditCamera(cloneId, 0.3, 194.74286, -1002.15826, -99.01465);
        cam.setFov(50);
        cam.setZPos(1);
        if (cloneId != null) {
            native.deletePed(cloneId);
            cloneId = null;
        }
    }
}

function buyVehicle() {
    if (cloneVehicle == null) {
        if (view != null) view.emit('error', 'Fahrzeug nicht gefunden');
        return;
    }
    let colorP = native.getVehicleCustomPrimaryColour(cloneVehicle);
    let colorS = native.getVehicleCustomSecondaryColour(cloneVehicle);
    alt.emitServer(
        'CarDealerBuyVehicle',
        native.getEntityModel(cloneVehicle),
        colorP[1],
        colorP[2],
        colorP[3],
        colorS[1],
        colorS[2],
        colorS[3]
    );
    closeView();
}

function setInText(state: number) {
    if (state == 1) {
        allowKeys = false;
    } else {
        allowKeys = true;
    }
}

function changeVehicle(name: string) {
    const modelhash = alt.hash(name);
    if (!native.isModelValid(modelhash) || !native.isModelAVehicle(modelhash)) {
        if (view != null) view.emit('error', 'Fahrzeug nicht gefunden');
        return;
    }
    alt.emitServer('isCarallowedToSell', name);
}

async function changeVehicleFroMServerSide(
    allow: boolean = false,
    modelname: string = '',
    price: number = 0,
    tanktype: number = 0,
    tank: number = 0,
    koff: number = 0
) {
    if (!allow) {
        if (view != null) view.emit('error', 'Das verkaufen wir nicht');
        return;
    }
    if (cloneVehicle != null) {
        native.deleteVehicle(cloneVehicle);
        cloneVehicle = null;
    }
    const modelhash = alt.hash(modelname);
    await alt.Utils.requestModel(modelhash);
    cloneVehicle = native.createVehicle(modelhash, 201.30989, -1002.5011, -99.6886, 0, false, false, false);
    native.setVehicleDirtLevel(cloneVehicle, 0);
    setVehColor(0, 255, 255, 255);
    setVehColor(1, 255, 255, 255);
    if (view != null) {
        view.emit('resetColor');
        view.emit(
            'setVehicleInfos',
            modelname,
            price,
            tanktype,
            tank,
            koff,
            native.getVehicleModelEstimatedMaxSpeed(modelhash) * 3.6
        );
    }
}

function setVehColor(primary, r, g, b) {
    if (cloneVehicle != null) {
        if (primary == 1) native.setVehicleCustomPrimaryColour(cloneVehicle, r, g, b);
        else native.setVehicleCustomSecondaryColour(cloneVehicle, r, g, b);
    }
}

function handleControls() {
    native.disableAllControlActions(0);
    //native.disableAllControlActions(1);
    native.disableControlAction(0, 0, true);
    native.disableControlAction(0, 1, true);
    native.disableControlAction(0, 2, true);
    native.disableControlAction(0, 24, true);
    native.disableControlAction(0, 25, true);
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
    cam.destroyPedEditCamera();
    native.freezeEntityPosition(alt.Player.local.scriptID, false);
    alt.emitServer('teleportCarDealer');
    if (cloneId != null) {
        native.deletePed(cloneId);
        cloneId = null;
    }
    if (cloneVehicle != null) {
        native.deleteVehicle(cloneVehicle);
        cloneVehicle = null;
    }
}
