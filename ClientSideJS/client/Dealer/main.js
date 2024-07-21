import * as alt from 'alt-client';
import * as native from 'natives';
const url = `http://resource/client/Dealer/DealerMenu.html`;
let view = null;
let cameraControlsInterval = null;
alt.onServer('ShowDealerMenu', ShowDealerMenu);
function ShowDealerMenu() {
    if (view == null) {
        view = new alt.WebView(url);
        view.on('closeView', closeView);
        view.on('sellDealerItems', sellDealerItems);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        showCursor(true);
    }
}
function sellDealerItems(i) {
    alt.emitServer('sellDealerItems', i);
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
