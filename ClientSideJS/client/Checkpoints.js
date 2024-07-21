import * as alt from 'alt-client';
import * as native from 'natives';
import { Vector3 } from 'alt-shared';
export let checkpointPos = null;
export let checkpointId = null;
export let checkpointYaw = null;
export let checkpointYawRange = null;
export function resetcheckpointpos() {
    checkpointPos = null;
    checkpointId = null;
    checkpointYaw = null;
    checkpointYawRange = null;
}
alt.onServer('SetRoute', SetRoute);
function SetRoute(color, x, y, z) {
    native.clearGpsMultiRoute();
    native.setGpsMultiRouteRender(false);
    native.startGpsMultiRoute(color, true, true);
    native.setGpsMultiRouteRender(true);
    native.addPointToGpsMultiRoute(x, y, z);
}
alt.onServer('ResetRoute', ResetRoute);
function ResetRoute() {
    native.clearGpsMultiRoute();
    if (checkpointId != null) native.deleteCheckpoint(checkpointId);
    resetcheckpointpos();
}
alt.onServer('SetCheckpoint', SetCheckpoint);
function SetCheckpoint(x, y, z, yaw, yawRange) {
    checkpointPos = new Vector3(x, y, z);
    checkpointId = native.createCheckpoint(49, x, y, z - 2, 0, 0, 0, 5, 255, 0, 0, 80, 0);
    if (checkpointYawRange != 0 && checkpointYaw != 0) {
        checkpointYawRange = yawRange;
        checkpointYaw = yaw;
    }
}
alt.everyTick(inCheckpoint);
function inCheckpoint() {
    const player = alt.Player.local;
    if (player.vehicle == null) return;
    if (checkpointPos != null) {
        if (player.vehicle.pos.distanceTo(checkpointPos) < 2) {
            if (checkpointYawRange != 0 && checkpointYaw != 0) {
                const a = checkpointYaw - checkpointYawRange;
                const b = checkpointYaw + checkpointYawRange;
                if (player.vehicle.rot.z < a || player.vehicle.rot.z > b) return;
            }
            alt.emitServer('EnterRouteCheckpoint');
            native.deleteCheckpoint(checkpointId);
            native.clearGpsMultiRoute();
            resetcheckpointpos();
        }
    }
}
