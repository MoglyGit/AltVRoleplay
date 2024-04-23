import * as alt from 'alt-client';
import { Vector3 } from 'alt-shared';
import * as native from 'natives';

export function isPlayerLookingAtPos(epos, distance = 0.5) {
    // Spieler-Objekt des lokalen Spielers erhalten
    const player = alt.Player.local;

    // Prüfen, ob das Spieler-Objekt gültig ist
    if (!player || !player.valid) {
        return false;
    }
    const fwd = getEntityForwardPosition(alt.Player.local, 0.5);
    console.log('distance:' + distance2d(fwd, epos));
    if (distance2d(fwd, epos) <= distance || distance2d(player.pos, epos) <= 0.1) return true;
    return false;
}
/**
 * Get all players in a certain range of a position.
 * @param  {} pos
 * @param  {} range
 * @param  {} dimension=0
 * @returns {Array<alt.Player>}
 */
export function getPlayersInRange(pos, range, dimension = 0) {
    if (pos === undefined || range === undefined) {
        throw new Error('GetPlayersInRange => pos or range is undefined');
    }

    return alt.Player.all.filter((player) => {
        return player.dimension == dimension && distance(pos, player.pos) <= range;
    });
}

export function getEntityForwardPosition(entity: alt.Entity, scale) {
    const fwd = getForwardVectorServer(entity.rot.z);
    return {
        x: entity.pos.x + fwd.x * scale,
        y: entity.pos.y + fwd.y * scale,
        z: entity.pos.z,
    };
}

export function showHelpText(text, sound, milliseconds) {
    native.beginTextCommandDisplayHelp('STRING');
    native.addTextComponentSubstringPlayerName(text);
    native.endTextCommandDisplayHelp(0, false, sound, milliseconds);
}

/**
 * Get the forward vector of a player.
 * @param  {} rot
 * @returns {{x,y,z}}
 */
export function getForwardVectorServer(deg) {
    deg = deg + 0.8;
    return {
        x: 1 * Math.cos(deg) - 1 * Math.sin(deg),
        y: 1 * Math.sin(deg) + 1 * Math.cos(deg),
        z: 0,
    };
}

/**
 * Get the distance from one vector to another.
 * Does take Z-Axis into consideration.
 * @param  {} vector1
 * @param  {} vector2
 * @returns {number}
 */
export function distance(vector1, vector2) {
    if (vector1 === undefined || vector2 === undefined) {
        throw new Error('AddVector => vector1 or vector2 is undefined');
    }

    return Math.sqrt(
        Math.pow(vector1.x - vector2.x, 2) + Math.pow(vector1.y - vector2.y, 2) + Math.pow(vector1.z - vector2.z, 2)
    );
}

/**
 * Get the distance from one vector to another.
 * Does not take Z-Axis into consideration.
 * @param  {} vector1
 * @param  {} vector2
 * @returns {{x,y,z}}
 */
export function distance2d(vector1, vector2) {
    if (vector1 === undefined || vector2 === undefined) {
        throw new Error('AddVector => vector1 or vector2 is undefined');
    }

    return Math.sqrt(Math.pow(vector1.x - vector2.x, 2) + Math.pow(vector1.y - vector2.y, 2));
}

/**
 * Check if a position is between two vectors.
 * @param  {} pos
 * @param  {} vector1
 * @param  {} vector2
 * @returns {boolean}
 */
export function isBetween(pos, vector1, vector2) {
    const validX = pos.x > vector1.x && pos.x < vector2.x;
    const validY = pos.y > vector1.y && pos.y < vector2.y;
    return validX && validY ? true : false;
}

/**
 * Get a random position around a position.
 * @param  {} position
 * @param  {} range
 * @returns {{x,y,z}}
 */
export function randomPositionAround(position, range) {
    return {
        x: position.x + Math.random() * (range * 2) - range,
        y: position.y + Math.random() * (range * 2) - range,
        z: position.z,
    };
}

/**
 * Get the closest vector from a group of vectors.
 * @param  {alt.Vector3} pos
 * @param  {Array<{x,y,z}> | Array<{pos:alt.Vector3}} arrayOfPositions
 * @returns {Array<any>}
 */
export function getClosestVectorFromGroup(pos, arrayOfPositions) {
    arrayOfPositions.sort((a, b) => {
        if (a.pos && b.pos) {
            return distance(pos, a.pos) - distance(pos, b.pos);
        }

        return distance(pos, a.pos) - distance(pos, b.pos);
    });

    return arrayOfPositions[0];
}

/**
 * Get the closest player to a player.
 * @param  {} player
 * @returns {Array<alt.Player>}
 */
export function getClosestPlayer(player) {
    return getClosestVectorFromGroup(player.pos, [...alt.Player.all]);
}

/**
 * Get the closest vehicle to a player.
 * @param  {alt.Vector3} player
 * @returns {Array<alt.Vehicle>}
 */
export function getClosestVehicle(player) {
    const vehicles = [...alt.Vehicle.all];
    let closest = -1;
    let v: alt.Vehicle = null;
    for (let i = 0; i < vehicles.length; i++) {
        const vehicle = vehicles[i];
        if (!vehicle || !vehicle.valid) {
            continue;
        }
        const dist = distance(vehicle.pos, player.pos);
        if (dist > 20) continue;
        if (closest == -1 || dist < closest) {
            closest = dist;
            v = vehicle;
        }
    }
    return v;
}

//
export function rotationToDirection(rotation: alt.Vector3): alt.Vector3 {
    const z = this.degToRad(rotation.z);
    const x = this.degToRad(rotation.x);
    const num = Math.abs(Math.cos(x));

    return new alt.Vector3(-Math.sin(z) * num, Math.cos(z) * num, Math.sin(x));
}

// Get the distance between to vectors.

export function getEntityFrontPosition(entityHandle: number): alt.Vector3 {
    let modelDimensions = native.getModelDimensions(native.getEntityModel(entityHandle), undefined, undefined);
    return this.getOffsetPositionInWorldCoords(entityHandle, new alt.Vector3(0, modelDimensions[2].y, 0));
}

export function getEntityRearPosition(entityHandle: number): alt.Vector3 {
    let modelDimensions = native.getModelDimensions(native.getEntityModel(entityHandle), undefined, undefined);
    return this.getOffsetPositionInWorldCoords(entityHandle, new alt.Vector3(0, modelDimensions[1].y, 0));
}

export function getOffsetPositionInWorldCoords(entityHandle: number, offset: alt.Vector3): alt.Vector3 {
    return native.getOffsetFromEntityInWorldCoords(entityHandle, offset.x, offset.y, offset.z);
}

export function degToRad(deg: number): number {
    return (deg * Math.PI) / 180.0;
}

export function dot(vector1: alt.Vector3, vector2: alt.Vector3) {
    return vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
}

export function getDirectionFromRotation(rotation: alt.Vector3): alt.Vector3 {
    var z = rotation.z * (Math.PI / 180.0);
    var x = rotation.x * (Math.PI / 180.0);
    var num = Math.abs(Math.cos(x));

    return new alt.Vector3(-Math.sin(z) * num, Math.cos(z) * num, Math.sin(x));
}
