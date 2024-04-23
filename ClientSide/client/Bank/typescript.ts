import * as alt from 'alt-client';
import * as native from 'natives';

const url = `http://resource/client/Bank/bank.html`;
let view = null;
let cameraControlsInterval = null;
alt.onServer('ShowFleecaBankNew', ShowFleecaBankNew);
alt.onServer('ShowFleecaBank', ShowFleecaBank);
alt.onServer('closeFleecaBank', closeView);
alt.onServer('createBankTransfer', createBankTransfer);
alt.onServer('bankError', bankError);
alt.onServer('updateBank', updateBank);
alt.onServer('updateBank2', updateBank2);
function updateBank2(money: number) {
    if (view != null) view.emit('updateBank2', money);
}
function updateBank(money: number) {
    if (view != null) view.emit('updateBank', money);
}

function bankError(str) {
    if (view != null) view.emit('bankError', str);
}

function createBankTransfer(money: number, name, reason, date) {
    if (view != null) view.emit('createBankTransfer', money, name, reason, date);
}

function createBank() {
    alt.emitServer('createBank', 500, 1);
    if (view != null) closeView();
}
function BankAccountInfoFleeca() {
    alt.emitServer('BankAccountInfoFleeca');
}
function einzahlen(money: number) {
    alt.emitServer('einzahlen', money);
}
function auszahlen(money: number, noAtm) {
    alt.emitServer('auszahlen', money, noAtm);
}
function ueberweisung(e: string, m: number, r: string) {
    alt.emitServer('ueberweisung', e, m, r);
}
function ShowFleecaBank(money: number, r: string, atm: number) {
    if (view == null) {
        console.log('i: ' + r);
        view = new alt.WebView(url);
        view.emit('hasKonto', alt.Player.local.getStreamSyncedMeta('FullName'), money, r, atm);
        view.on('closeView', closeView);
        view.on('einzahlen', einzahlen);
        view.on('auszahlen', auszahlen);
        view.on('ueberweisung', ueberweisung);
        view.on('BankAccountInfoFleeca', BankAccountInfoFleeca);
        view.on('giveKredit', giveKredit);
        alt.setMeta('noInv', '1');
        alt.setMeta('noChat', '1');
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        showCursor(true);
    }
}

function giveKredit(money: number) {
    alt.emitServer('giveKredit', money);
}

function ShowFleecaBankNew() {
    if (view == null) {
        view = new alt.WebView(url);
        view.emit('new');
        view.on('closeView', closeView);
        view.on('createBank', createBank);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        showCursor(true);
    }
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
    alt.deleteMeta('noInv');
    alt.deleteMeta('noChat');
    view = null;
    showCursor(false);
}
