import * as alt from 'alt-client';
import * as native from 'natives';

const url = `http://resource/client/Firmen/Konto/FirmenKonto.html`;
let view = null;
let cameraControlsInterval = null;
alt.onServer('createFirmenBankTransfer', addFirmenKontoAuszug);
alt.onServer('firmenKontoNr', showKontoInfo);
alt.onServer('bankFirmenError', bankFirmenError);
alt.onServer('closeFirmenKonto', closeView);

export function ShowFirmaKonto() {
    alt.emitServer('getFirmenKontoTransfer');
}

function bankFirmenError(str) {
    if (view != null) view.emit('bankError', str);
}

function showKontoInfo(nr: string, konto: number) {
    if (view == null) {
        view = new alt.WebView(url);
        view.emit('setText', nr, konto);
        view.on('closeView', closeView);
        view.on('ueberweisung', ueberweisung);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        alt.setMeta('noInv', '1');
        showCursor(true);
    }
}

function ueberweisung(e: string, m: number, r: string) {
    alt.emitServer('ueberweisungFirma', e, m, r);
}

function addFirmenKontoAuszug(money, name, reason, date) {
    if (view != null) view.emit('addFirmenTransfer', money, name, reason, date);
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
