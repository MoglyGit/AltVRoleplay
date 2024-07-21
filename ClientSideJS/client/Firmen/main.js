import * as alt from 'alt-client';
import * as native from 'natives';
const url = `http://resource/client/Firmen/FirmenBuy.html`;
let view = null;
let cameraControlsInterval = null;
let price = 0;
let dbid = 0;
alt.onServer('ShowFirmenBuy', ShowFirmenBuy);
function ShowFirmenBuy(name, m, id) {
    if (view == null) {
        view = new alt.WebView(url);
        view.emit('setText', name, m);
        view.on('closeView', closeView);
        view.on('buyfirma', buyfirma);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        showCursor(true);
        price = m;
        dbid = id;
    }
}
function buyfirma() {
    if (dbid != 0) alt.emitServer('BuyFirma', price, dbid);
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
    dbid = 0;
    price = 0;
    showCursor(false);
}
