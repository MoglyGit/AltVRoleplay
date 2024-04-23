import * as alt from 'alt-client';
import * as native from 'natives';
import * as math from '../utility.js';

const url = `http://resource/client/Fishing/index.html`;
let view = null;
let showPointInterval = null;
let c = null;
let canFish = false;
alt.onServer('ShowFishingIndicator', Main);
alt.onServer('StopFishingIndicator', StopMain);
alt.onServer('StartFishing', StartFishing);

alt.on('keydown', (key) => {
    if (key == 69 && view == null) tryFishing();
});

function Main() {
    showPointInterval = alt.setInterval(showPoint, 0);
}
function StopMain() {
    if (showPointInterval != null) {
        alt.clearInterval(showPointInterval);
        showPointInterval = null;
        canFish = false;
        if (c != null) native.deleteCheckpoint(c);
    }
}

function tryFishing() {
    if (!canFish) return;
    alt.emitServer('TryFishing');
}

function StartFishing(amount: number, type: number, typeChance: number) {
    if (view == null) {
        view = new alt.WebView(url);
        view.on('closeView', closeView);
        view.on('hitFish', hitFish);
        view.on('removeKoeder', removeKoeder);
        view.emit('addFish', amount, type, typeChance);
        view.focus();
        showCursor(false);
        alt.emitServer('PlayFishingAnimation', true);
        alt.Player.local.setMeta('allowInv', false);
    }
}

function removeKoeder() {
    alt.emitServer('RemoveKoeder');
}

function showPoint() {
    const fwd = math.getEntityForwardPosition(alt.Player.local, 5.0);
    const groundZ = native.getGroundZFor3dCoord(fwd.x, fwd.y, fwd.z, undefined, undefined, undefined);
    const waterZ = native.getWaterHeight(fwd.x, fwd.y, groundZ[1]);
    if (c != null) native.deleteCheckpoint(c);
    if (alt.Player.local.vehicle != null) return;
    if (waterZ[0] && (groundZ[1] <= waterZ[1] || !groundZ[0])) {
        c = native.createCheckpoint(49, fwd.x, fwd.y, waterZ[1], 0, 0, 0, 0.1, 0, 133, 15, 150, 0);
        canFish = true;
        return;
    }
    c = native.createCheckpoint(49, fwd.x, fwd.y, groundZ[1], 0, 0, 0, 0.1, 133, 0, 15, 150, 0);
    canFish = false;
}

function hitFish(type: number, height: number) {
    closeView();
    alt.emitServer('FishHitter', type, height);
}

function showCursor(state) {
    try {
        alt.showCursor(state);
    } catch (err) {
        return;
    }
}

function closeView() {
    if (view && view.destroy) {
        view.destroy();
    }
    view = null;
    showCursor(false);
    alt.Player.local.setMeta('allowInv', true);
    alt.emitServer('PlayFishingAnimation', false);
}
