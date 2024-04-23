import * as alt from 'alt-client';
import * as native from 'natives';
import * as firmenKonto from '../Konto/main';
import * as firmenName from '../Name/main';
import * as firmenWorker from '../WorkerList/main';

const url = `http://resource/client/Firmen/CarDealer/CarDealerMenu.html`;
let view = null;
let cameraControlsInterval = null;

alt.onServer('ShowCarDealerMenuOwner', ShowCarDealerMenuOwner);
alt.onServer('createCarContract', createCarContract);

function ShowCarDealerMenuOwner(name: string, rank: number) {
    if (view == null) {
        view = new alt.WebView(url);
        view.emit('showRank', rank);
        view.emit('setName', name);
        view.on('closeView', closeView);
        view.on('getServerContracts', getServerContracts);
        view.on('getCarDealer', getCarDealer);
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

function createCarContract(model: number, date: string, rdy: boolean, orderby: string) {
    if (view == null) return;
    const vehname = native.getDisplayNameFromVehicleModel(model);
    view.emit('createCarContract', vehname, date, rdy, orderby);
}

function getCarDealer() {
    closeView();
    alt.emit('ShowCarDealerMenu');
}

function getServerContracts() {
    if (view == null) return;
    alt.emitServer('getAllCarDealerContracts');
    view.emit('ShowMenu', 1);
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
