import * as alt from 'alt-client';
import * as native from 'natives';
let view = null;
const url = `http://resource/client/Tacho/index.html`;
alt.onServer('ShowTacho', ShowTacho);
alt.onServer('HideTacho', HideTacho);
let last_pos = null;
let pos_ticks = 50;
let max_tank = 40;

function ShowTacho(maxfill: number) {
    let player = alt.Player.local;
    if (!player) return;
    if (!player.vehicle || !player.vehicle.hasSyncedMeta('Fill')) {
        setTimeout(() => {
            ShowTacho(maxfill);
        }, 300);
    } else {
        let veh = player.vehicle;
        if (
            veh.model == alt.hash('bmx') ||
            veh.model == alt.hash('cruiser') ||
            veh.model == alt.hash('fixter') ||
            veh.model == alt.hash('scorcher') ||
            veh.model == alt.hash('tribike') ||
            veh.model == alt.hash('tribike2') ||
            veh.model == alt.hash('tribike3')
        )
            return;
        if (view == null) view = new alt.WebView(url);
        last_pos = null;
        pos_ticks = 50;
        max_tank = maxfill;
    }
}
function HideTacho() {
    if (view != null) view.destroy();
    view = null;
    last_pos = null;
}
alt.setInterval(() => {
    if (view == null) return;
    let player = alt.Player.local;
    if (!player) return;
    if (!player.vehicle) return;
    if (player.seat != 1) return;
    let veh = player.vehicle;
    let speed = (native.getEntitySpeed(veh) * 3.6).toFixed();
    view.emit('Speed', speed, veh.engineOn, veh.rpm, veh.gear);
    SetFill(veh);
    SetLockState(veh);
    SetRange(veh);
    SetMotorcontroll(veh);
    SetNosCharges(veh);
}, 100);

function SetNosCharges(veh) {
    if (view == null) return;
    if (veh.hasSyncedMeta('NosCharges')) {
        const value = veh.getSyncedMeta('NosCharges');
        view.emit('setNosCharges', value);
    } else view.emit('setNosCharges', 0);
}

function SetMotorcontroll(veh) {
    if (view == null) return;
    const health = native.getVehicleEngineHealth(veh);
    if (health <= 500) {
        view.emit('MotorState', 1);
        return;
    }
    view.emit('MotorState', 0);
}

function SetFill(veh: alt.Vehicle) {
    if (view == null) return;
    let fillCheck = veh.hasSyncedMeta('Fill');
    if (!fillCheck) return;
    let fill = <number>veh.getSyncedMeta('Fill');
    view.emit('Fill', fill.toFixed(2), max_tank);
    veh.fuelLevel = (parseFloat(fill.toFixed(2)) / max_tank) * 65;
}

function SetRange(veh: alt.Vehicle) {
    if (view == null) return;
    if (!veh.engineOn) return;
    let rangecheck = veh.hasSyncedMeta('Range');
    if (!rangecheck) return;
    let range = <number>veh.getSyncedMeta('Range');
    view.emit('Range', range);

    pos_ticks--;
    if (pos_ticks <= 0) {
        pos_ticks = 50;
        if (last_pos == null) {
            last_pos = veh.pos;
            return;
        }
        const dis = parseInt(veh.pos.distanceTo(last_pos).toFixed());
        alt.emitServer('VehicleRange', veh, dis, parseInt(veh.speed.toFixed()), veh.rpm, veh.gear);
        last_pos = veh.pos;
    }
}

function SetLockState(veh: alt.Vehicle) {
    if (view == null) return;
    view.emit('LockState', veh.lockState);
}
