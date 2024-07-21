import * as alt from 'alt-client';
import * as native from 'natives';
import { Sound } from '../Hud/time.js';
const speed = 'SpeedBoost';
const nosSpeed = 'NosBoost';
alt.on('keydown', (key)=>{
    const player = alt.Player.local;
    if (player.vehicle == null || player.vehicle.hasSyncedMeta(nosSpeed)) return;
    if (key == 16 && alt.gameControlsEnabled()) {
        alt.emitServer('UseNos', player.vehicle);
        return;
    }
});
alt.on('gameEntityCreate', (entity)=>{
    console.log('type:' + entity.type + ' | mdoel: ' + entity.model);
    //alt.BaseObjectType.Vehicle.valueOf()
    if (1 != entity.type) return;
    if (entity.hasSyncedMeta(speed)) {
        const boost = entity.getSyncedMeta(speed);
        SetSpeed(entity, boost);
    }
    if (entity.hasSyncedMeta(nosSpeed)) {
        const boost = entity.getSyncedMeta(nosSpeed);
        SetNos(entity, boost);
    }
});
alt.on('gameEntityDestroy', (entity)=>{
// Remove meta changes for example
});
alt.on('syncedMetaChange', (entity, key, newValue, oldValue)=>{
    alt.log('key: ' + key + ' value: ' + newValue);
    if (1 != entity.type) return;
    if (key === speed) SetSpeed(entity, newValue);
    if (key === nosSpeed) SetNos(entity, newValue);
});
function SetSpeed(entity, boost) {
    const veh = alt.Vehicle.getByID(entity.id);
    native.modifyVehicleTopSpeed(veh, boost);
}
function SetNos(entity, boost) {
    const veh = alt.Vehicle.getByID(entity.id);
    if (boost == undefined || boost == null) {
        if (veh.hasSyncedMeta(speed)) {
            const syncboost = veh.getSyncedMeta(speed);
            SetSpeed(entity, syncboost);
        } else native.modifyVehicleTopSpeed(veh, 0);
    } else {
        native.modifyVehicleTopSpeed(veh, boost);
        Sound('Nos');
        native.enableVehicleExhaustPops(veh, true);
    }
}
