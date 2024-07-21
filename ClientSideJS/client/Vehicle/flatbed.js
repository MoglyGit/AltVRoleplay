import * as alt from 'alt-client';
import * as native from 'natives';
import * as math from '../utility.js';
import * as textlabel from '../TextLabel/3DText.js';
let flatBed = null;
alt.onServer('getFlatBedDropPos', getFlatBedDropPos);
alt.onServer('getFrontDistance', getFrontDistance);
alt.everyTick(()=>{
    if (alt.Player.local.vehicle != null) return;
    const vehicles = [
        ...alt.Vehicle.streamedIn
    ];
    for(let i = 0; i < vehicles.length; i++){
        const vehicle = vehicles[i];
        if (!vehicle || !vehicle.valid) {
            continue;
        }
        if (vehicle.model != alt.hash('flatbed')) {
            continue;
        }
        if (native.getEntitySpeed(vehicle) >= 1) continue;
        let fwd = math.getEntityForwardPosition(vehicle, 0.5);
        fwd.z += 0.8;
        if (alt.Player.local.pos.distanceTo(fwd) < 1) {
            if (vehicle.lockState != 1 || vehicle.engineOn) continue;
            flatBed = vehicle;
            textlabel.drawText3d('Auf/Abladen\nNutze E', fwd.x, fwd.y, fwd.z, 0.4, 4, 255, 255, 255, 255);
            return;
        }
        flatBed = null;
    }
});
alt.on('keydown', (key)=>{
    if (alt.Player.local.vehicle != null) return;
    if (key == 69 && flatBed != null) tryLoadVehicle();
});
function tryLoadVehicle() {
    if (flatBed == null) return;
    const pos = math.getEntityForwardPosition(flatBed, -6.0);
    alt.emitServer('loadOnFlatBed', flatBed, pos.x, pos.y);
}
function getFlatBedDropPos(flat) {
    const fwd = math.getEntityForwardPosition(flat, -7.0);
    alt.emitServer('UnLoadFlatBed', fwd.x, fwd.y, flat.pos.z);
}
function getFrontDistance(veh) {
    const front = math.getEntityFrontPosition(veh.scriptID);
    const dist = math.distance2d(front, veh.pos);
    const groundZ = native.getGroundZFor3dCoord(veh.pos.x, veh.pos.y, veh.pos.z, undefined, undefined, undefined);
    const height = veh.pos.z - groundZ[1];
    alt.emitServer('SetFlatBedLoadedvehiclePlace', dist, height);
}
