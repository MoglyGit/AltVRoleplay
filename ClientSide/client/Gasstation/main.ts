import * as alt from 'alt-client';
import * as native from 'natives';

const url = `http://resource/client/Gasstation/gasstation.html`;
let view = null;
let cameraControlsInterval = null;
let ltdStore = -1;
let ltdPay = -1;
alt.onServer('ShowgasPaying', ShowgasPaying);

function ShowgasPaying(money: number, storeId) {
    if (view == null) {
        view = new alt.WebView(url);
        view.emit('toPay', money);
        view.on('closeView', closeView);
        view.on('payGas', payGas);
        ltdStore = storeId;
        ltdPay = money;
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        showCursor(true);
    }
}

function payGas() {
    alt.emitServer('PayGas', ltdStore, ltdPay);
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
    showCursor(false);
}
