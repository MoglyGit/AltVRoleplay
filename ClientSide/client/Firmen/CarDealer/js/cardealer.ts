let colorPicker;
let colorPickerSecondary;
const defaultColor = '#ffffff';

window.addEventListener('load', startup, false);

function startup() {
    colorPicker = document.getElementById('primary');
    colorPicker.value = defaultColor;
    colorPicker.addEventListener('input', updatePrimary, false);
    colorPicker.addEventListener('change', updatePrimary, false);

    colorPickerSecondary = document.getElementById('secondary');
    colorPickerSecondary.value = defaultColor;
    colorPickerSecondary.addEventListener('input', updateSecondary, false);
    colorPickerSecondary.addEventListener('change', updateSecondary, false);
}

function updatePrimary(event) {
    const string = event.target.value;
    const r = string[1] + string[2];
    const g = string[3] + string[4];
    const b = string[5] + string[6];

    alt.emit('setVehColor', 1, parseInt(r, 16), parseInt(g, 16), parseInt(b, 16));
}

function updateSecondary(event) {
    const string = event.target.value;
    const r = string[1] + string[2];
    const g = string[3] + string[4];
    const b = string[5] + string[6];

    alt.emit('setVehColor', 0, parseInt(r, 16), parseInt(g, 16), parseInt(b, 16));
}

function SelectCar(element) {
    alt.emit('changeVehicle', element.value);
}

function setInText(state: number) {
    alt.emit('setInText', state);
}

function SearchCar() {
    let model = (<HTMLInputElement>document.getElementById('vehSearchValue')).value;
    model = model.trim();
    if (!/^[A-Za-z0-9]*$/.test(model)) {
        showError('Nur buchstaben');
        return;
    }
    alt.emit('changeVehicle', model);
}

function CloseCarDealer() {
    alt.emit('closeView');
}

function showError(msg) {
    const errorElem = document.getElementById('error');
    errorElem.innerHTML = 'Fehler: ' + msg;
}

function BuyCarDealerVehicle() {
    alt.emit('buyVehicle');
}

alt.on('setVehicleInfos', (modelname, price, tanktype, tank, koff, speed) => {
    document.getElementById('vehcilename').innerHTML = 'Fahrzeug: ' + modelname;
    document.getElementById('tanktype').innerHTML = 'Tankart: ' + tanktype;
    document.getElementById('kofferraum').innerHTML = 'Kofferraum: ' + koff + ' kg';
    document.getElementById('maxtank').innerHTML = 'Tankvolume: ' + tank + ' Liter';
    document.getElementById('maxspeed').innerHTML = 'Geschw.: ' + speed + 'km/h';
    const priceString = new Intl.NumberFormat('de-DE').format(price);
    document.getElementById('carPRice').innerHTML = priceString + '$';
});

alt.on('error', (msg) => {
    showError(msg);
});

alt.on('resetColor', () => {
    colorPickerSecondary.value = defaultColor;
    colorPicker.value = defaultColor;
});

/*document.body.addEventListener('keydown', (event) => {
    if (event.keyCode == 27) {
        alt.emit('closeView');
        return;
    }
});*/
