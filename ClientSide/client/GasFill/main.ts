import * as alt from 'alt-client';
import * as native from 'natives';

const url = `http://resource/client/GasFill/gasfill.html`;
let view = null;
let cameraControlsInterval = null;
let ltdStore = -1;
let fillPrice = [];
let fillType = -1;
alt.onServer('ShowGasFill', ShowGasFill);

function ShowGasFill(maxAdd, storeId, price1, price2, price3, price4) {
    if (view == null) {
        view = new alt.WebView(url);
        fillPrice[0] = price1;
        fillPrice[1] = price2;
        fillPrice[2] = price3;
        fillPrice[3] = price4;
        view.emit('setInfos', maxAdd, fillPrice);
        view.on('closeView', closeView);
        view.on('useGasType', useGasType);
        view.on('endFill', endFill);
        ltdStore = storeId;
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        showCursor(true);
    }
}

function endFill(price, fuel) {
    alt.emitServer('setLTDStats', ltdStore, price, fuel);
    closeView();
}

function useGasType(type) {
    fillType = type;
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
