import * as alt from 'alt-client';
import * as native from 'natives';

const url = `http://resource/client/Store247/Store247Owner.html`;
let view = null;
let cameraControlsInterval = null;
let dbid = 0;
alt.onServer('ShowStore247Owner', ShowStore247Owner);

function ShowStore247Owner(name: string, money: number, id: number, eat: number, product: number) {
    if (view == null) {
        view = new alt.WebView(url);
        view.emit('setText', name, money, eat, product);
        view.on('closeView', closeView);
        view.on('changeShopName', changeShopName);
        view.on('changeProduct', changeProduct);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        showCursor(true);
        dbid = id;
    }
}
function changeProduct(number: number, price: number, item: string) {
    if (dbid != 0) {
        alt.emitServer('ChangeProduktSell', dbid, number, price, item);
    }
}
function changeShopName(name: string) {
    if (dbid != 0) {
        console.log(name + '|' + dbid);
        alt.emitServer('changeShopName', name, dbid);
    }
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
    dbid = 0;
    view = null;
    showCursor(false);
}
