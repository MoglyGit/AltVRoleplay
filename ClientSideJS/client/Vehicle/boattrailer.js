import * as alt from 'alt-client';
import * as native from 'natives';
import * as math from '../utility.js';
import * as textlabel from '../TextLabel/3DText.js';
let boatTrailer = null;
alt.onServer('isTrailerInWater', isInWater);
alt.everyTick(()=>{
    const vehicles = [
        ...alt.Vehicle.streamedIn
    ];
    for(let i = 0; i < vehicles.length; i++){
        const vehicle = vehicles[i];
        if (!vehicle || !vehicle.valid) {
            continue;
        }
        if (vehicle.model != alt.hash('boattrailer')) {
            continue;
        }
        if (native.getEntitySpeed(vehicle) >= 1) continue;
        const fwd = math.getEntityForwardPosition(vehicle, 2.0);
        if (alt.Player.local.pos.distanceTo(fwd) < 2) {
            boatTrailer = vehicle;
            textlabel.drawText3d('Auf/Abladen\nNutze E', fwd.x, fwd.y, fwd.z, 0.4, 4, 255, 255, 255, 255);
            return;
        }
        boatTrailer = null;
    }
});
alt.on('keydown', (key)=>{
    if (key == 69 && boatTrailer != null) tryLoadBoat();
});
function tryLoadBoat() {
    const pos = math.getEntityForwardPosition(boatTrailer, -5.0);
    alt.emitServer('slipBoat', boatTrailer, pos.x, pos.y);
}
function isInWater(trailer, unload) {
    const fwd = math.getEntityForwardPosition(trailer, -5.0);
    const groundZ = native.getGroundZFor3dCoord(fwd.x, fwd.y, fwd.z, undefined, undefined, undefined);
    const waterZ = native.getWaterHeight(fwd.x, fwd.y, groundZ[1]);
    if (waterZ[0] && groundZ[1] <= waterZ[1]) {
        if (unload) alt.emitServer('UnloadBoat', fwd.x, fwd.y, waterZ[1]);
        else alt.emitServer('LoadBoat');
        return;
    }
    alt.emitServer('BoatLoadFailed');
}
