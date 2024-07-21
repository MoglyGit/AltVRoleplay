import * as alt from 'alt-client';
import * as native from 'natives';
import * as firmenKonto from '../Konto/main.js';
import * as firmenName from '../Name/main.js';
import * as firmenWorker from '../WorkerList/main.js';
const url = `http://resource/client/Firmen/Mechanic/MechanicMenu.html`;
let view = null;
let cameraControlsInterval = null;
alt.onServer('ShowMechanicMenuOwner', ShowMechanicMenuOwner);
function ShowMechanicMenuOwner(name, rank) {
    if (view == null) {
        view = new alt.WebView(url);
        view.emit('showRank', rank);
        view.emit('setName', name);
        view.on('closeView', closeView);
        view.on('showKasse', showKasse);
        view.on('showNameChange', showNameChange);
        view.on('showWorker', showWorker);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        showCursor(true);
    }
}
function showWorker() {
    closeView();
    firmenWorker.ShowWorkerList();
}
function showNameChange() {
    closeView();
    firmenName.showChangeNameHud();
}
function showKasse() {
    closeView();
    firmenKonto.ShowFirmaKonto();
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
