import * as alt from 'alt-client';
import * as native from 'natives';
const url = `http://resource/client/Store247/Store247BuyItems.html`;
let view = null;
let cameraControlsInterval = null;
let dbid = 0;
alt.onServer('ShowStoreItems', ShowStoreItems);
alt.onServer('AddShowShop', AddShowShop);
alt.onServer('CloseShop247Hud', closeView);
function ShowStoreItems(id) {
    if (view == null) {
        view = new alt.WebView(url);
        view.on('closeView', closeView);
        view.on('buyItem', buyItem);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        showCursor(true);
        dbid = id;
    }
}
function AddShowShop(i, item, price) {
    if (view != null) view.emit('addShopItem', i, item, price);
}
function buyItem(i) {
    if (dbid != 0) alt.emitServer('BuyShopItem', i, dbid);
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
    showCursor(false);
}
