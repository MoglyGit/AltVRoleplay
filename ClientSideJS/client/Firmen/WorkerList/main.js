import * as alt from 'alt-client';
import * as native from 'natives';
const url = `http://resource/client/Firmen/WorkerList/WorkerList.html`;
let view = null;
let cameraControlsInterval = null;
alt.onServer('ShowWorkerList', showWorkerListHud);
alt.onServer('addWorker', addWorker);
alt.onServer('firmenSucces', firmenSucces);
alt.onServer('closeWorkerHud', closeView);
export function ShowWorkerList() {
    showWorkerListHud();
    alt.emitServer('getFirmenWorker');
}
function firmenSucces() {
    if (view != null) view.emit('showWorkerInfo');
}
function addWorker(scid, name, gehalt, rank) {
    if (view != null) view.emit('addHudWorker', scid, name, gehalt, rank);
}
function showWorkerListHud() {
    if (view == null) {
        view = new alt.WebView(url);
        view.on('closeView', closeView);
        view.on('changegehalt', changegehalt);
        view.on('changeRank', changeRank);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        alt.setMeta('noInv', '1');
        showCursor(true);
    }
}
function changeRank(scid, rank) {
    if (view != null) alt.emitServer('ChangePlayerFirmenRank', scid, rank);
}
function changegehalt(scid, gehalt) {
    if (view != null) alt.emitServer('ChangePlayerFirmenGehalt', scid, gehalt);
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
    alt.deleteMeta('noInv');
}
