import * as alt from 'alt-client';
import * as native from 'natives';

alt.onServer('vehlock', VehLock);
function VehLock(veh) {
    native.startVehicleHorn(veh, 100, alt.hash('HELDDOWN'), false);
}

alt.on('keydown', (key) => {
    if (key == 37) {
        if (!alt.Player.local.vehicle) return;
        if (!alt.Player.local.vehicle.hasSyncedMeta('blinker')) return;
        if (alt.Player.local.vehicle.getSyncedMeta('blinker') == '1') alt.emitServer('BlinkerOut');
        else alt.emitServer('BlinkerLeft');
    }
    if (key == 38) {
        if (!alt.Player.local.vehicle) return;
        if (!alt.Player.local.vehicle.hasSyncedMeta('blinker')) return;
        if (alt.Player.local.vehicle.getSyncedMeta('blinker') == '64') alt.emitServer('BlinkerOut');
        else alt.emitServer('Interrior');
    }
    if (key == 39) {
        if (!alt.Player.local.vehicle) return;
        if (!alt.Player.local.vehicle.hasSyncedMeta('blinker')) return;
        if (alt.Player.local.vehicle.getSyncedMeta('blinker') == '2') alt.emitServer('BlinkerOut');
        else alt.emitServer('BlinkerRight');
    }
    if (key == 40) {
        if (!alt.Player.local.vehicle) return;
        if (!alt.Player.local.vehicle.hasSyncedMeta('blinker')) return;
        if (alt.Player.local.vehicle.getSyncedMeta('blinker') == '4') alt.emitServer('BlinkerOut');
        else alt.emitServer('BlinkerBoth');
    }
});
