import * as alt from 'alt-client';
import * as native from 'natives';
import { Sound } from '../Hud/time.js';
import * as math from '../utility.js';
//import * as inventory from './js/javascript.js';
import * as friends from '../PlayerFriends/Friends.js';
import * as InteractionMenu from '../InteractionMenu/main.js';
const url = `http://resource/client/inventory/index.html`;
let view = null;
let otherInfType = 0;
let vehicleFromTrunk = null;
let cameraControlsInterval;
let checkTrunkInterval = null;
let checkTargetPlayerInterval = null;
let checkHandschufachInterval = null;
let otherBackPack = null;
let blockKeyI = false;
export function RemoveHudItem(id) {
    removeHudItem(id);
    if (otherBackPack == id) deleteOtherBackpack();
}
export function AddHudItem(id) {
    console.log('Test');
    alt.emitServer('AddGroundHudItem', id);
}
alt.onServer('closeInventory', closeView);
alt.onServer('ShowInventory', showInv);
alt.onServer('openInventory', openInv);
alt.onServer('showOtherHud', openOther);
alt.onServer('addGround', addGround);
alt.onServer('addInv', addInv);
alt.onServer('addCloth', addCloth);
alt.onServer('addProp', addProp);
alt.onServer('addBack', addBack);
alt.onServer('addOther', addOther);
alt.onServer('addOtherHud', addOtherHud);
alt.onServer('addBackHud', addBackHud);
alt.onServer('RemoveHudItem', removeHudItem);
alt.onServer('setWeight', setWeight);
alt.onServer('AddWeightBackpackAndPlayer', updateWeigth);
alt.onServer('AddWeightOtherAndPlayer', updateWeigthOtherP);
alt.onServer('AddWeightOtherAndBack', updateWeigthOtherB);
alt.onServer('UpdateSplitItemAmount', updateSplitItemAmount);
alt.onServer('UpdateItemAmount', UpdateItemAmount);
export function ShowVehicleTrunk(vehicle) {
    const allowOpenInv = alt.getMeta('noInv');
    if (blockKeyI || allowOpenInv == 1) return;
    if (view == null) {
        if (vehicle == null) return;
        if (native.getEntitySpeed(vehicle) >= 2) return;
        alt.emitServer('VehicleTrunk', vehicle);
        vehicleFromTrunk = vehicle;
    }
}
function getNearPlayer(action) {
    //utility.getPlayersInRange(alt.Player.local.pos,3,alt.Player.local.dimension);
    if (view != null) {
        view.emit('ClearMenuItems');
    }
    const players = alt.Player.all;
    for(let i = 0; i < players.length; i++){
        const player = players[i];
        if (!player || !player.valid) {
            continue;
        }
        if (alt.Player.local == player) continue;
        const scid = player.getStreamSyncedMeta('SocialClubId');
        if (!scid) {
            continue;
        }
        const id = player.getStreamSyncedMeta('PlayerId');
        if (!id) {
            continue;
        }
        let name = 'Unbekannter';
        if (!friends.IsSocialClubIdFriend(scid) || native.getPedDrawableVariation(player, 1) > 0) {
            name = 'Unbekannter (' + id + ')';
        } else name = '' + player.getStreamSyncedMeta('FullName');
        if (alt.Player.local.pos.distanceTo(player.pos) > 3) continue;
        if (view == null) continue;
        view.emit('createMenuPlayer', action, name, id);
    }
}
function updateSplitItemAmount(amount, mass) {
    if (view != null) view.emit('updateSplitItemAmount', amount, mass);
}
function UpdateItemAmount(id, amount, mass) {
    if (view != null) view.emit('UpdateItemAmount', id, amount, mass);
}
function removeHudItem(id) {
    if (view != null) view.emit('removeHudItem', id);
}
function addBackHud(size, weight) {
    if (view != null) view.emit('addBackHud', size, weight);
}
function addBack(id, des, type, slot, src, size, ammo, mass, maxamount) {
    if (view != null) view.emit('addBack', id, des, type, slot, src, size, ammo, mass, maxamount);
}
function addOtherHud(size, weight) {
    if (view != null) view.emit('addOtherHud', size, weight);
}
function addOther(id, des, type, slot, src, ammo, mass, maxamount) {
    if (view != null) view.emit('addOther', id, des, type, slot, src, ammo, mass, maxamount);
}
function addProp(id, des, type, slot, src, ammo, mass, maxamount) {
    if (view != null) view.emit('addProp', id, des, type, slot, src, ammo, mass, maxamount);
}
function addCloth(id, des, type, slot, src, ammo, mass, maxamount) {
    if (view != null) view.emit('addCloth', id, des, type, slot, src, ammo, mass, maxamount);
}
function addInv(id, des, type, slot, src, ammo, mass, maxamount) {
    if (view != null) view.emit('addInv', id, des, type, slot, src, ammo, mass, maxamount);
}
function addGround(id, des, type, src, ammo, mass, maxamount) {
    if (view != null) view.emit('addGround', id, des, type, src, ammo, mass, maxamount);
}
function setWeight(weight, max) {
    if (view != null) view.emit('setWeight', weight, max);
}
function updateWeigth(playerweight, backpackweight) {
    if (view != null) view.emit('updateWeigth', playerweight, backpackweight);
}
function updateWeigthOtherP(otherWeight, playerweight) {
    if (view != null) view.emit('updateWeigthOP', otherWeight, playerweight);
}
function updateWeigthOtherB(otherWeight, backpackweight) {
    if (view != null) view.emit('updateWeigthOB', otherWeight, backpackweight);
}
function checkTargetPlayer() {
    const targetId = InteractionMenu.targetPlayerInv;
    if (targetId == null) closeView();
    const players = alt.Player.all;
    for(let i = 0; i < players.length; i++){
        const player = players[i];
        if (!player || !player.valid) {
            continue;
        }
        //if (alt.Player.local == player) continue;
        const id = player.getStreamSyncedMeta('PlayerId');
        if (!id) {
            continue;
        }
        if (targetId == id) {
            if (player.pos.distanceTo(alt.Player.local.pos) > 3) closeView();
            else return;
        }
    }
    closeView();
}
function checkTrunkUsable() {
    if (vehicleFromTrunk == null) return;
    if (native.getEntitySpeed(vehicleFromTrunk) >= 2) {
        closeView();
        return;
    }
    if (vehicleFromTrunk.lockState != 1) {
        closeView();
        return;
    }
    const player = alt.Player.local;
    if (vehicleFromTrunk.wheelsCount > 0) {
        const pos = math.getEntityRearPosition(vehicleFromTrunk.scriptID);
        if (math.distance(player.pos, pos) > 2) {
            closeView();
            return;
        }
    } else {
        if (math.distance(player.pos, vehicleFromTrunk.pos) > 3) {
            closeView();
            return;
        }
    }
}
alt.on('keydown', (key)=>{
    const allowOpenInv = alt.getMeta('noInv');
    if (blockKeyI || allowOpenInv == 1) return;
    if (key == 73 && view == null && alt.gameControlsEnabled()) {
        openInv(0, 0);
        return;
    }
    if (key == 73 && view != null) {
        closeView();
        return;
    }
});
function takeItem(id, slot, backpack) {
    alt.emitServer('RemoveGroundItem', id, slot, backpack);
}
function layItemDown(id, slot, backpack) {
    alt.emitServer('AddGroundItem', id, slot, backpack);
}
function itemmove(id, start, end, backpack) {
    alt.emitServer('itemmoveinv', id, start, end, backpack);
}
function setCloth(id, start, comp) {
    alt.emitServer('setCloth', id, start, comp);
}
function backpackItems(id) {
    alt.emitServer('getBackpackitems', id);
}
function showPerso(id) {
    alt.emitServer('showPerso', id);
}
function showPlayerPerso(player, dbid) {
    alt.emitServer('showPlayerPerso', player, dbid);
}
function showDrive(id) {
    alt.emitServer('showDrive', id);
}
function showPlayerDrive(player, dbid) {
    alt.emitServer('showPlayerDrive', player, dbid);
}
function deleteOtherBackpack() {
    if (otherBackPack == null) return;
    if (view == null) return;
    view.emit('deleteOtherInv');
    alt.emitServer('CloseOtherBackpack');
    otherBackPack = null;
}
function showOtherBackpack(dbid) {
    if (otherBackPack != null) view.emit('deleteOtherInv');
    otherBackPack = dbid;
    alt.emitServer('getOtherBackPackItems', dbid);
}
function equipItem(dbid) {
    alt.emitServer('equipPlayerItem', dbid);
}
function useitem(dbid) {
    alt.emitServer('usePlayerItem', dbid);
}
function stackInvItem(itemid, amount, stackitem, ground, endslot, startslot) {
    alt.emitServer('stackInvItem', itemid, amount, stackitem, ground, endslot, startslot);
}
function splitItem(itemid, amount, slot) {
    alt.emitServer('splitItem', itemid, amount, slot);
}
function renameItem(itemid, newName) {
    alt.emitServer('renameItem', itemid, newName);
}
function openOther(type, slolts) {
    if (view == null) return;
    view.emit('createOtherInv', slolts);
    otherInfType = type;
    view.emit('setOtherText', 'Rucksack');
}
function showInv(state) {
    if (state) {
        if (view != null) view.emit('showView');
        return;
    }
    closeView();
}
function openInv(otherType, other) {
    if (view == null) {
        view = new alt.WebView(url);
        view.on('closeView', closeView);
        view.on('takeGroundItem', takeItem);
        view.on('itemonground', layItemDown);
        view.on('itemmoveinv', itemmove);
        view.on('backpackItems', backpackItems);
        view.on('setCloth', setCloth);
        view.on('showPerso', showPerso);
        view.on('getNearPlayer', getNearPlayer);
        view.on('showPlayerPerso', showPlayerPerso);
        view.on('showDrive', showDrive);
        view.on('showPlayerDrive', showPlayerDrive);
        view.on('stackInvItem', stackInvItem);
        view.on('splitItem', splitItem);
        view.on('equipItem', equipItem);
        view.on('useitem', useitem);
        view.on('showOtherBackpack', showOtherBackpack);
        view.on('deleteOtherBackpack', deleteOtherBackpack);
        view.on('renameItem', renameItem);
        view.on('blockInv', blockInv);
        blockKeyI = false;
        Sound('Zipper');
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        alt.emitServer('calculateMuni');
        alt.emitServer('getGroundItems');
        alt.emitServer('getInvItems');
        alt.emitServer('getCloth');
        if (other >= 1) {
            view.emit('createOtherInv', other);
            otherInfType = otherType;
            if (otherType == 1) {
                view.emit('setOtherText', 'Schrank');
                alt.emitServer('getWardrobeItems');
            }
            if (otherType == 2) {
                view.emit('setOtherText', 'Kofferraum');
                alt.emitServer('getTrunkItems');
                checkTrunkInterval = alt.setInterval(checkTrunkUsable, 500);
            }
            if (otherType == 4) {
                view.emit('setOtherText', 'Spieler');
                alt.emitServer('getTargetPlayerItems');
                checkTargetPlayerInterval = alt.setInterval(checkTargetPlayer, 500);
            }
            if (otherType == 5) {
                view.emit('setOtherText', 'Handschuhfach');
                alt.emitServer('getHandschufachItems');
                checkHandschufachInterval = alt.setInterval(checkHandschufachUse, 500);
            }
        }
    }
    showCursor(true);
    view.focus();
}
function checkHandschufachUse() {
    if (alt.Player.local.vehicle == null) closeView();
    if (alt.Player.local.seat != 1 && alt.Player.local.seat != 2) closeView();
}
function blockInv(state) {
    blockKeyI = state;
}
function handleControls() {
    const allowOpenInv = alt.getMeta('noInv');
    if (allowOpenInv == 1) closeView();
    native.hideHudAndRadarThisFrame();
    native.disableAllControlActions(0);
    //native.disableAllControlActions(1);
    native.disableControlAction(0, 0, true);
    native.disableControlAction(0, 1, true);
    native.disableControlAction(0, 2, true);
    native.disableControlAction(0, 24, true);
    native.disableControlAction(0, 25, true);
}
function closeView() {
    if (checkTrunkInterval != null) {
        alt.clearInterval(checkTrunkInterval);
        checkTrunkInterval = null;
    }
    if (checkHandschufachInterval != null) {
        alt.clearInterval(checkHandschufachInterval);
        checkHandschufachInterval = null;
    }
    if (checkTargetPlayerInterval != null) {
        alt.clearInterval(checkTargetPlayerInterval);
        checkTargetPlayerInterval = null;
    }
    if (cameraControlsInterval !== undefined || cameraControlsInterval !== null) {
        alt.clearInterval(cameraControlsInterval);
        cameraControlsInterval = null;
    }
    if (view && view.destroy) {
        view.destroy();
    }
    view = null;
    showCursor(false);
    switch(otherInfType){
        case 1:
            alt.emitServer('closeOtherInfWardrobe');
            break;
        case 2:
            alt.emitServer('closeOtherInfVehicle');
            break;
        case 4:
            alt.emitServer('closeTargetPlayerInv');
            break;
        case 5:
            alt.emitServer('closeOtherFrontInfVehicle');
            break;
    }
    otherInfType = 0;
    vehicleFromTrunk = null;
    if (otherBackPack != null) {
        alt.emitServer('CloseOtherBackpack');
    }
    otherBackPack = null;
    blockInv(false);
}
function showCursor(state) {
    try {
        alt.showCursor(state);
    } catch (err) {
        return;
    }
}
