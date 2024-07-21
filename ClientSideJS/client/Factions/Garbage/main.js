import * as alt from 'alt-client';
import * as native from 'natives';
import * as math from '../../utility.js';
const url = `http://resource/client/Factions/Garbage/Garbage.html`;
let view = null;
let cameraControlsInterval = null;
let factionId = 0;
alt.onServer('ShowGarbageSide', ShowGarbage);
alt.on('keydown', (key)=>{
    if (key == 69 && alt.gameControlsEnabled()) {
        let player = alt.Player.local;
        if (player.vehicle != null) return;
        const vehicle = math.getClosestVehicle(player);
        if (vehicle == null) return;
        if (vehicle.model != alt.hash('trash') && vehicle.model != alt.hash('trash2')) return;
        const pos = math.getEntityRearPosition(vehicle.scriptID);
        if (math.distance(player.pos, pos) > 2) return;
        alt.emitServer('behindTrash', vehicle, pos.x, pos.y, pos.z);
    }
});
function ShowGarbage(duty, faction) {
    if (view == null) {
        factionId = faction;
        view = new alt.WebView(url);
        view.emit('isDuty', duty);
        view.on('closeGarbage', closeView);
        view.on('setGarbageDuty', setGarbageDuty);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        showCursor(true);
    }
}
function setGarbageDuty() {
    alt.emitServer('factionDuty', factionId);
    factionId = 0;
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
