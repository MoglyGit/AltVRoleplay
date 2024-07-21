import * as alt from 'alt-client';
import * as native from 'natives';
const url = `http://resource/client/CarSell/Carsell.html`;
let view = null;
let cameraControlsInterval = null;
let sellVehicle = null;
alt.onServer('ShowCarSell', ShowCarSell);
alt.onServer('CloseCarSell', closeView);
function ShowCarSell(money, veh) {
    if (view == null) {
        view = new alt.WebView(url);
        sellVehicle = veh;
        view.emit('MoneyForCar', money);
        view.on('closeCarSell', closeView);
        view.on('sellCar', sellCar);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        showCursor(true);
    }
}
function sellCar() {
    alt.emitServer('SellVehicle', sellVehicle);
    closeView();
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
    sellVehicle = null;
    showCursor(false);
}
