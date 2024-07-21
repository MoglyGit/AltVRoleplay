import * as alt from 'alt-client';
import * as native from 'natives';
const anchor = 'BoatAnchor';
alt.on('gameEntityCreate', (entity)=>{
    console.log('type:' + entity.type + ' | mdoel: ' + entity.model);
    //alt.BaseObjectType.Vehicle.valueOf()
    if (1 != entity.type) return;
    if (entity.hasSyncedMeta(anchor)) {
        const state = entity.getSyncedMeta(anchor);
        Anchor(entity, state);
    }
});
alt.on('gameEntityDestroy', (entity)=>{
// Remove meta changes for example
});
alt.on('syncedMetaChange', (entity, key, newValue, oldValue)=>{
    if (1 != entity.type) return;
    if (key === anchor) Anchor(entity, newValue);
});
function Anchor(entity, state) {
    const boat = alt.Vehicle.getByID(entity.id);
    if (state == 1) {
        native.setBoatAnchor(boat, true);
        native.setBoatRemainsAnchoredWhilePlayerIsDriver(boat, true);
        console.log('Anker Synced');
    } else {
        native.setBoatAnchor(boat, false);
        native.setBoatRemainsAnchoredWhilePlayerIsDriver(boat, false);
        console.log('Ankergelöst Synced');
    }
}
