let TunercolorPicker;
let TunercolorPickerSecondary;
let TunerNeonColor;
const defColor = '#ffffff';
let modItems = [];
let modItemCount = 0;
let greeButton = null;
let back = 0;
let extras = [];

window.addEventListener('load', startup, false);

function startup() {
    TunercolorPicker = document.getElementById('primary');
    TunercolorPicker.value = defColor;
    TunercolorPicker.addEventListener('input', updatePrimary, false);
    TunercolorPicker.addEventListener('change', updatePrimary, false);

    TunercolorPickerSecondary = document.getElementById('secondary');
    TunercolorPickerSecondary.value = defColor;
    TunercolorPickerSecondary.addEventListener('input', updateSecondary, false);
    TunercolorPickerSecondary.addEventListener('change', updateSecondary, false);

    TunerNeonColor = document.getElementById('neoncolor');
    TunerNeonColor.value = defColor;
    TunerNeonColor.addEventListener('input', updateNeon, false);
    TunerNeonColor.addEventListener('change', updateNeon, false);
}

function updatePrimary(event) {
    const string = event.target.value;
    const r = string[1] + string[2];
    const g = string[3] + string[4];
    const b = string[5] + string[6];

    alt.emit('setVehColor', 1, parseInt(r, 16), parseInt(g, 16), parseInt(b, 16));
}

function changeHorn(horn) {
    alt.emit('addMod', 14, parseInt(horn));
}

function changeTireCol(col) {
    alt.emit('setTireColor', parseInt(col));
}

function updateNeon(event) {
    const string = event.target.value;
    const r = string[1] + string[2];
    const g = string[3] + string[4];
    const b = string[5] + string[6];

    alt.emit('setNeon', true, parseInt(r, 16), parseInt(g, 16), parseInt(b, 16));
}

function updateSecondary(event) {
    const string = event.target.value;
    const r = string[1] + string[2];
    const g = string[3] + string[4];
    const b = string[5] + string[6];

    alt.emit('setVehColor', 0, parseInt(r, 16), parseInt(g, 16), parseInt(b, 16));
}

function SelectMod(mod) {
    alt.emit('selectedMod', mod);
}

function CloseTuner() {
    alt.emit('closeView');
}

function showError(msg) {
    const errorElem = document.getElementById('error');
    errorElem.innerHTML = 'Fehler: ' + msg;
}

function changeTireType(type) {
    alt.emit('setTiresType', parseInt(type));
    let tireName = getTireTypeName(type);
    document.getElementById('tireinfo').innerHTML = 'Reifen Type: ' + tireName;
    (<HTMLInputElement>document.getElementById('tirevalue')).value = '0';
}

function getTireTypeName(type) {
    let tireName = '';
    switch (parseInt(type)) {
        case 0:
            tireName = 'Sport';
            break;
        case 1:
            tireName = 'Muscle';
            break;
        case 2:
            tireName = 'Lowrider';
            break;
        case 3:
            tireName = 'SUV';
            break;
        case 4:
            tireName = 'Offroad';
            break;
        case 5:
            tireName = 'Tuner';
            break;
        case 6:
            tireName = 'Bike Wheels';
            break;
        case 7:
            tireName = 'High End';
            break;
        case 8:
            tireName = 'Bennys Originals';
            break;
        case 9:
            tireName = 'Bennys Bespoke';
            break;
        case 10:
            tireName = 'Racing';
            break;
        case 11:
            tireName = 'Street';
            break;
        case 12:
            tireName = 'Track';
            break;
    }
    return tireName;
}

function changeTire(tires) {
    alt.emit('setTires', parseInt(tires));
}

function ResetNeon() {
    alt.emit('setNeon', false, 0, 0, 0);
}

function BuyTuning() {
    alt.emit('changeTuning');
}

function Show(state) {
    clear();
    switch (state) {
        case 1:
            document.getElementById('tunerMainMenu').style.display = 'block';
            back = 1;
            break;
        case 2:
            document.getElementById('interior').style.display = 'block';
            back = 2;
            break;
        case 3:
            document.getElementById('engineBlock').style.display = 'block';
            back = 3;
            break;
        case 4:
            document.getElementById('tuningNeon').style.display = 'block';
            back = 4;
            break;
        case 5:
            document.getElementById('verbesserung').style.display = 'block';
            back = 5;
            break;
        case 6:
            document.getElementById('tires').style.display = 'block';
            back = 6;
            break;
        case 7:
            document.getElementById('horn').style.display = 'block';
            back = 7;
            break;
    }
}

function Backaus() {
    clear();
    switch (back) {
        case 1:
            document.getElementById('tunerMainMenu').style.display = 'block';
            break;
        case 2:
            document.getElementById('interior').style.display = 'block';
            break;
        case 3:
            document.getElementById('engineBlock').style.display = 'block';
            break;
        case 4:
            document.getElementById('tunerMainMenu2').style.display = 'block';
            break;
        case 5:
            document.getElementById('verbesserung').style.display = 'block';
            break;
    }
    for (let x = 0; x < modItemCount; x++) {
        modItems[x].remove();
    }
    modItemCount = 0;
}

function clear() {
    document.getElementById('tunerMainMenu2').style.display = 'none';
    document.getElementById('tunerMainMenu').style.display = 'none';
    document.getElementById('tunerMenu').style.display = 'none';
    document.getElementById('interior').style.display = 'none';
    document.getElementById('engineBlock').style.display = 'none';
    document.getElementById('tuningNeon').style.display = 'none';
    document.getElementById('verbesserung').style.display = 'none';
    document.getElementById('tires').style.display = 'none';
    document.getElementById('horn').style.display = 'none';
}

function Main() {
    clear();
    document.getElementById('tunerMainMenu2').style.display = 'block';
    for (let x = 0; x < modItemCount; x++) {
        modItems[x].remove();
    }
    modItemCount = 0;
}

function SelectNeutral() {
    alt.emit('setModValue', -1);
    if (greeButton != null) greeButton.setAttribute('style', 'background-color: rgb(0, 113, 148);');
}

function resetAddMods() {
    alt.emit('addMod', 11, -1);
    alt.emit('addMod', 12, -1);
    alt.emit('addMod', 18, -1);
    alt.emit('addMod', 22, -1);
    alt.emit('addMod', 13, -1);
    alt.emit('addMod', 11, -1);
}

function addChip() {
    const type = 100;
    if (extras[type] == null || extras[type] == undefined || extras[type] == -1) {
        alt.emit('addChip', true);
        addExtra(100, 'Chip Tuning');
        extras[type] = 1;
    } else {
        removeExtra(100);
        extras[type] = -1;
        alt.emit('addChip', false);
    }
}

function addNos() {
    const type = 99;
    if (extras[type] == null || extras[type] == undefined || extras[type] == -1) {
        alt.emit('addNos', true);
        addExtra(99, 'Nitro 5x');
        extras[type] = 1;
    } else {
        removeExtra(99);
        extras[type] = -1;
        alt.emit('addNos', false);
    }
}

function addMod(type, val, button) {
    if (extras[type] == null || extras[type] == undefined || extras[type] == -1) {
        addExtra(type, '' + (<HTMLInputElement>button).value);
        extras[type] = val;
        alt.emit('addMod', type, val);
    } else if (extras[type] != val) {
        removeExtra(type);
        addExtra(type, '' + (<HTMLInputElement>button).value);
        extras[type] = val;
        alt.emit('addMod', type, val);
    } else {
        removeExtra(type);
        extras[type] = -1;
        alt.emit('addMod', type, -1);
    }
}

function SetMod(button, mod) {
    alt.emit('setModValue', mod);
    if (greeButton != null) greeButton.setAttribute('style', 'background-color: rgb(0, 113, 148);');
    button.setAttribute('style', 'background-color: rgb(0, 113, 0);');
    greeButton = button;
}

function removeExtra(type) {
    const el = document.getElementById('Extras:' + type);
    if (el != null) el.remove();
}

function addExtra(type, name) {
    const newLi = document.createElement('p');
    newLi.innerHTML = name;
    newLi.setAttribute('id', 'Extras:' + type);
    document.getElementById('extras').appendChild(newLi);
}

alt.on('ShowMods', () => {
    clear();
    document.getElementById('tunerMenu').style.display = 'block';
});

alt.on('addButton', (name, mod, ismod) => {
    const newDiv = document.createElement('input');
    newDiv.setAttribute('class', 'center buttonTuner');
    newDiv.setAttribute('onclick', 'SetMod(this,' + mod + ')');
    newDiv.setAttribute('type', 'submit');
    newDiv.setAttribute('value', name);
    if (ismod) {
        newDiv.setAttribute('style', 'background-color: rgb(0, 113, 0);');
        greeButton = newDiv;
    } else newDiv.setAttribute('style', 'background-color: rgb(0, 113, 148);');
    document.getElementById('tunerMenu').appendChild(newDiv);
    modItems[modItemCount] = newDiv;
    modItemCount += 1;
});

alt.on('setNeededProds', (prod) => {
    document.getElementById('carPRice').innerHTML = '' + prod;
});

alt.on('setExtrasLoad', (type, value) => {
    if (type != 13) addExtra(type, '' + (<HTMLInputElement>document.getElementById('ex' + type)).value);
    else {
        if (value == 0) addExtra(type, 'Transmission 25');
        else if (value == 1) addExtra(type, 'Transmission 50');
        else if (value == 2) addExtra(type, 'Transmission 100');
    }
    extras[type] = value;
});

alt.on('error', (msg) => {
    showError(msg);
});

alt.on('updateTire', (type, val, col) => {
    let tireName = getTireTypeName(type);
    document.getElementById('tireinfo').innerHTML = 'Reifen Type: ' + tireName;
    (<HTMLInputElement>document.getElementById('tireType')).value = type;
    (<HTMLInputElement>document.getElementById('tirevalue')).value = val;
    (<HTMLInputElement>document.getElementById('tirecol')).value = col;
});

alt.on('setMaxTires', (max) => {
    (<HTMLInputElement>document.getElementById('tirevalue')).max = max;
});

document.body.addEventListener('keydown', (event) => {
    if (event.keyCode == 73 || event.keyCode == 27 || event.keyCode == 88) {
        alt.emit('closeView');
        return;
    }
    if (event.keyCode == 82) {
        alt.emit('freeCam');
    }
    // do something
});
