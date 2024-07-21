import * as alt from 'alt-client';
import * as native from 'natives';
import { Sound } from '../Hud/time.js';
const url = `http://resource/client/IronFarm/index.html`;
let view = null;
let cameraControlsInterval = null;
alt.onServer('IronFarming', IronFarming);
function IronFarming(strong) {
    if (view == null) {
        view = new alt.WebView(url);
        view.emit('setStrong', strong);
        view.on('closeView', closeView);
        view.on('doneIron', doneIron);
        view.on('playPickAxeSound', PlaySoundPickAxeHit);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        showCursor(false);
    }
}
function PlaySoundPickAxeHit() {
    Sound('PickAxeHit');
    alt.emitServer('PickAxeAnimation');
}
function doneIron() {
    alt.emitServer('GivePlayerIron');
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
