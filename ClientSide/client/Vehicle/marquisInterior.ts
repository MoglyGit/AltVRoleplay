/*import * as alt from 'alt-client';
import * as native from 'natives';
import * as math from '../utility.js';

alt.on('keydown', (key) => {
    if (key == 69) {
        let player = alt.Player.local;
        if (player.vehicle != null) return;
        const vehicle: alt.Vehicle = math.getClosestVehicle(player);
        if (vehicle == null) return;
        if (vehicle.model != alt.hash('marquis')) return;
        const fwd = math.getEntityForwardPosition(vehicle, -3);
        if (math.distance(player.pos, fwd) > 2) return;
        alt.emitServer('TryEnterMarquis', vehicle);
    }
});*/
