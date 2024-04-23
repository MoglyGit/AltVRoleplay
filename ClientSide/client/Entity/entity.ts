import * as alt from 'alt-client';
import * as native from 'natives';
import * as inventory from '../inventory/typescript';
import * as math from '../utility.js';
let entityData = [];
let objects = [];
let peds = [];
export let textLabels = [];

async function requestModelSync(model, entityId, currentEntityData, position) {
    await alt.Utils.requestModel(model);
    const r = currentEntityData['r'];
    peds[entityId] = native.createPed(4, model, position.x, position.y, position.z - 1, r, false, false);
    native.setEntityHeading(peds[entityId], r);
    native.setBlockingOfNonTemporaryEvents(peds[entityId], true);
    native.setPedConfigFlag(peds[entityId], 32, false); // ped cannot fly thru windscreen
    native.setPedConfigFlag(peds[entityId], 281, true);
    native.freezeEntityPosition(peds[entityId], true);
    native.setEntityCanBeDamaged(peds[entityId], false);
}

alt.onServer('entitySync:create', (entityId, entityType, position, newEntityData) => {
    if (newEntityData) {
        if (!entityData[entityType]) {
            entityData[entityType] = {};
        }
        if (!entityData[entityType][entityId]) {
            entityData[entityType][entityId] = {};
        }
        for (const key in newEntityData) {
            entityData[entityType][entityId][key] = newEntityData[key];
        }
    }
    let currentEntityData;
    if (entityData[entityType] && entityData[entityType][entityId]) {
        currentEntityData = entityData[entityType][entityId];
    } else {
        currentEntityData = null;
    }
    if (entityType == 0) {
        groundItems(entityId, currentEntityData, position);
    } else if (entityType == 1) {
        if (Array.isArray(textLabels[entityId])) {
            textLabels[entityId][0] = currentEntityData['text'];
            textLabels[entityId][1] = position.x;
            textLabels[entityId][2] = position.y;
            textLabels[entityId][3] = position.z;
            textLabels[entityId][4] = parseInt(currentEntityData['eventType']);
            textLabels[entityId][5] = parseInt(currentEntityData['keyrange']);
        } else {
            textLabels[entityId] = [
                currentEntityData['text'],
                position.x,
                position.y,
                position.z,
                parseInt(currentEntityData['eventType']),
                parseInt(currentEntityData['keyrange']),
            ];
        }
    } else if (entityType == 2) {
        const model = alt.hash(currentEntityData['model']);
        requestModelSync(model, entityId, currentEntityData, position);
    }
    if (entityType == 3) {
        createObject(entityId, currentEntityData, position);
    }
});

alt.onServer('entitySync:remove', (entityId, entityType) => {
    let currentEntityData;
    if (entityData[entityType]) {
        currentEntityData = entityData[entityType][entityId];
    } else {
        currentEntityData = null;
    }
    if (entityType == 0) {
        native.deleteObject(objects[entityId]);
        if (currentEntityData['invhudid'] != null) inventory.RemoveHudItem(parseInt(currentEntityData['invhudid']));
    } else if (entityType == 1) {
        textLabels[entityId][0] = '';
        textLabels[entityId][4] = 0;
    } else if (entityType == 2) {
        native.deletePed(peds[entityId]);
    } else if (entityType == 3) {
        native.deleteObject(objects[entityId]);
    }
});

alt.onServer('entitySync:updatePosition', (entityId, entityType, position) => {
    let currentEntityData;
    if (entityData[entityType]) {
        currentEntityData = entityData[entityType][entityId];
    } else {
        currentEntityData = null;
    }
    if (entityType == 1) {
        native.deleteObject(objects[entityId]);
        createObject(entityId, currentEntityData, position);
    } else if (entityType == 3) {
        native.deleteObject(objects[entityId]);
        createObject(entityId, currentEntityData, position);
    }
});

alt.onServer('entitySync:updateData', (entityId, entityType, newEntityData) => {
    alt.log(newEntityData);
    if (!entityData[entityType]) {
        entityData[entityType] = {};
    }
    if (!entityData[entityType][entityId]) {
        entityData[entityType][entityId] = {};
    }
    if (newEntityData) {
        for (const key in newEntityData) {
            entityData[entityType][entityId][key] = newEntityData[key];
        }
    }
    let currentEntityData = entityData[entityType][entityId];
    if (entityType == 1) {
        if (Array.isArray(textLabels[entityId])) {
            textLabels[entityId][0] = currentEntityData['text'];
            textLabels[entityId][4] = parseInt(currentEntityData['eventType']);
            textLabels[entityId][5] = parseInt(currentEntityData['keyrange']);
        }
    } else if (entityType == 3) {
        native.setEntityRotation(
            objects[entityId],
            parseFloat(currentEntityData['roll']),
            parseFloat(currentEntityData['pitch']),
            parseFloat(currentEntityData['yaw']),
            1,
            true
        );
    }
});

alt.onServer('entitySync:clearCache', (entityId, entityType) => {
    if (!entityData[entityType]) {
        return;
    }
    delete entityData[entityType][entityId];
});

//Functions
async function groundItems(entityId, currentEntityData, position) {
    await alt.Utils.requestModel(currentEntityData['obj']);
    const groundZ = native.getGroundZFor3dCoord(
        position.x,
        position.y,
        position.z + 5,
        undefined,
        undefined,
        undefined
    );
    if (groundZ[1] != null && groundZ[1] - position.z < 5)
        objects[entityId] = native.createObject(
            currentEntityData['obj'],
            position.x,
            position.y,
            groundZ[1] + 0.1,
            false,
            false,
            false
        );
    else
        objects[entityId] = native.createObject(
            currentEntityData['obj'],
            position.x,
            position.y,
            position.z - 1,
            false,
            false,
            false
        );
    native.freezeEntityPosition(objects[entityId], true);
    inventory.AddHudItem(parseInt(entityData['invhudid']));
}

async function createObject(entityId, currentEntityData, position) {
    await alt.Utils.requestModel(currentEntityData['obj']);
    const groundZ = native.getGroundZFor3dCoord(
        position.x,
        position.y,
        position.z + 100,
        undefined,
        undefined,
        undefined
    );
    if (groundZ[1] != null && currentEntityData['onground']) {
        objects[entityId] = native.createObject(
            currentEntityData['obj'],
            position.x,
            position.y,
            groundZ[1] + 0.1,
            false,
            false,
            false
        );
        alt.log('Test1');
    } else {
        objects[entityId] = native.createObject(
            currentEntityData['obj'],
            position.x,
            position.y,
            position.z,
            false,
            false,
            false
        );
        alt.log('Test2');
    }
    native.setEntityRotation(
        objects[entityId],
        currentEntityData['pitch'],
        currentEntityData['roll'],
        currentEntityData['yaw'],
        1,
        true
    );
    native.freezeEntityPosition(objects[entityId], true);
}

//damage check
alt.everyTick(() => {
    let player = alt.Player.local;
    if (!player) return;
    for (let i = 0; i < objects.length; i++) {
        if (!objects[i]) continue;
        if (native.hasEntityBeenDamagedByEntity(objects[i], player, true)) {
            native.clearEntityLastDamageEntity(objects[i]);
            native.setEntityHealth(objects[i], 1000, 0, 0);
            alt.emitServer('ObjectDamaged', i);
            console.log('player dmg');
        }
        if (player.vehicle == null) continue;
        const entityHitObj = native.getLastEntityHitByEntity(objects[i]);
        if (entityHitObj != player.vehicle.scriptID) continue;
        const fwd = math.getEntityForwardPosition(alt.Player.local, 4);
        const object = native.getEntityCoords(objects[i], false);
        const dist = Math.sqrt(Math.pow(fwd.x - object.x, 2) + Math.pow(fwd.y - object.y, 2));
        console.log(object);
        if (dist > 2) continue;
        native.setEntityHealth(objects[i], 1000, 0, 0);
        alt.emitServer('ObjectDamagedWithVehicle', i);
        console.log('Vehicle dmg');
    }
});
