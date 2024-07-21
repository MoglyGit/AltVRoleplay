import * as alt from 'alt-client';
import * as native from 'natives';
import * as math from '../utility.js';
import * as inv from '../inventory/typescript.js';
import * as notify from '../Notification/notification.js';
const url = `http://resource/client/InteractionMenuVehicle/Menu.html`;
let view = null;
let cameraControlsInterval = null;
let interactionVehicle = null;
let isInVehicleCheck = false;
alt.onServer('ShowVehicleMenu', ShowInteractMenu);
alt.onServer('CloseVehicleInteraction', closeView);
alt.onServer('ShowVehicleNumberPlate', ShowVehicleNumberPlate);
alt.on('keydown', (key)=>{
    if (key == 114) {
        if (view == null) GetVehicleMenuInfos();
        else closeView();
        return;
    }
});
function ShowVehicleNumberPlate(tuev, numberplate, name) {
    if (view != null) view.emit('setNumberplateInfo', tuev, numberplate, name);
}
function GetVehicleMenuInfos() {
    const player = alt.Player.local;
    if (player.vehicle != null) {
        alt.emitServer('GetVehicleMenuInfo', player.vehicle);
    } else {
        const veh = math.getClosestVehicle(player);
        if (veh.pos.distanceTo(player.pos) <= 3) alt.emitServer('GetVehicleMenuInfo', veh);
    }
}
function ShowInteractMenu(haskey, veh, isMechanic = false, isTuner = false) {
    if (view == null) {
        interactionVehicle = veh;
        view = new alt.WebView(url);
        const player = alt.Player.local;
        const canUseTrunkHoodHandschufach = !(native.isThisModelABike(interactionVehicle.model) || native.isThisModelABicycle(interactionVehicle.model));
        if (player.vehicle != null && player.seat == 1) {
            view.emit('ShowinVehicleMenuDriver', canUseTrunkHoodHandschufach);
            if (haskey) view.emit('ShowEngine', interactionVehicle.engineOn);
        } else if (player.vehicle != null && player.seat == 2) view.emit('ShowinVehicleMenuCoDriver', canUseTrunkHoodHandschufach);
        if (haskey) view.emit('ShowLockMenu', interactionVehicle.lockState == 2);
        if (player.vehicle == null) {
            if (interactionVehicle.wheelsCount > 0) {
                const pos = math.getEntityRearPosition(interactionVehicle.scriptID);
                if (math.distance(player.pos, pos) <= 2) view.emit('ShowUseTrunk');
            } else {
                if (math.distance(player.pos, interactionVehicle.pos) <= 3) view.emit('ShowUseTrunk');
            }
        }
        if (player.vehicle != null && (player.seat == 1 || player.seat == 2) && native.getVehicleClass(interactionVehicle) == 18) view.emit('ShowSirenToggle', veh.hasSyncedMeta('siren'), veh.hasSyncedMeta('shortsiren'));
        if (player.vehicle != null) {
            view.emit('showGurt', alt.getMeta('GurtUsed'));
            if (native.getVehicleClass(player.vehicle) == 14) view.emit('showAnker');
        }
        if (isMechanic) view.emit('showMechanic');
        if (isTuner) view.emit('showTuner');
        view.on('closeView', closeView);
        view.on('lockVehicle', lockVehicle);
        view.on('ShowTrunk', ShowTrunk);
        view.on('ToggleEngine', ToggleEngine);
        view.on('toggleTrunk', toggleTrunk);
        view.on('toggleFront', toggleFront);
        view.on('OpenHandschuh', OpenHandschuh);
        view.on('ShowNumberPlate', ShowNumberPlate);
        view.on('ChangeSireneMuted', ChangeSireneMuted);
        view.on('DoShortSiren', DoShortSiren);
        view.on('ToggleGurt', ToggleGurt);
        view.on('repairVehicle', repairVehicle);
        view.on('tuevVehicle', tuevVehicle);
        view.on('changeLockVehicle', changeLockVehicle);
        view.on('tuneVehicle', tuneVehicle);
        view.on('toggleAnker', toggleAnker);
        view.focus();
        showCursor(true);
        isInVehicleCheck = player.vehicle != null;
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        return;
    }
}
function toggleAnker() {
    if (interactionVehicle != null) {
        alt.emitServer('ToggleAnker', interactionVehicle);
    }
}
function tuneVehicle() {
    if (interactionVehicle != null) {
        alt.emit('ShowTuner', interactionVehicle);
        closeView();
    }
}
function changeLockVehicle() {
    if (interactionVehicle != null) alt.emitServer('ChangeLockVehicle', interactionVehicle);
}
function tuevVehicle() {
    if (interactionVehicle != null) alt.emitServer('TuevVehicleMechanic', interactionVehicle);
}
function repairVehicle() {
    if (interactionVehicle != null) alt.emitServer('RepairVehicleMechanic', interactionVehicle);
}
function ToggleGurt() {
    if (!alt.hasMeta('GurtUsed')) {
        alt.setMeta('GurtUsed', false);
        notify.ShowNotification(0, 'Angeschnallt');
    } else {
        alt.setMeta('GurtUsed', alt.getMeta('GurtUsed') != true);
        let text = alt.getMeta('GurtUsed') == false ? 'Angeschnallt' : 'Abgeschnallt';
        notify.ShowNotification(0, text);
    }
}
function DoShortSiren() {
    if (interactionVehicle != null) alt.emitServer('DoShortSiren', interactionVehicle);
}
function ChangeSireneMuted() {
    if (interactionVehicle != null) alt.emitServer('ChangeVehicleSirenMute', interactionVehicle);
}
function ShowNumberPlate() {
    if (interactionVehicle != null) alt.emitServer('ShowNumberPlateFromVehicle', interactionVehicle);
}
function OpenHandschuh() {
    if (interactionVehicle != null) {
        alt.emitServer('OpenHandschuhfach', interactionVehicle);
        closeView();
    }
}
function toggleFront() {
    if (interactionVehicle != null) alt.emitServer('TryToggleHood', interactionVehicle, interactionVehicle.seatCount <= 2);
}
function toggleTrunk() {
    if (interactionVehicle != null) alt.emitServer('TryToggleTrunk', interactionVehicle, interactionVehicle.seatCount <= 2);
}
function ToggleEngine() {
    if (interactionVehicle != null) alt.emitServer('TryEngineVehicle');
}
function ShowTrunk() {
    if (interactionVehicle != null) {
        inv.ShowVehicleTrunk(interactionVehicle);
        closeView();
    }
}
function lockVehicle() {
    if (interactionVehicle != null) alt.emitServer('TryLockingVehicle', interactionVehicle);
}
function showCursor(state) {
    try {
        alt.showCursor(state);
    } catch (err) {
        return;
    }
}
function handleControls() {
    if (isInVehicleCheck && alt.Player.local.vehicle == null) closeView();
    if (interactionVehicle != null && !isInVehicleCheck && alt.Player.local.pos.distanceTo(interactionVehicle.pos) > 4) closeView();
    native.disableControlAction(0, 1, true);
    native.disableControlAction(0, 2, true);
    native.disableControlAction(0, 24, true);
    native.disableControlAction(0, 25, true);
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
    interactionVehicle = null;
}
