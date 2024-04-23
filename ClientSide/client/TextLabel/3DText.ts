import * as alt from 'alt-client';
import * as native from 'natives';
import * as entity from '../Entity/entity';
import * as math from '../utility.js';
import * as friends from '../PlayerFriends/Friends.js';

let allowDraw = false;
const atms = ['prop_fleeca_atm', 'prop_atm_01', 'prop_atm_02', 'prop_atm_03'];

const muell = [218085040, 4236481708, 666561306];

const muellcane = [1437508529, 1329570871, 3107680657];

export function SetAllowDraw(state: boolean) {
    allowDraw = state;
}

alt.everyTick(() => {
    if (allowDraw) load3DText();
    const player = alt.Player.local;
});

alt.on('keydown', (key) => {
    if (key == 69 && alt.gameControlsEnabled()) {
        const playerPos = alt.Player.local.pos;
        for (let i = 0; i < entity.textLabels.length; i++) {
            if (!Array.isArray(entity.textLabels)) continue;
            if (!Array.isArray(entity.textLabels[i])) continue;
            if (!entity.textLabels[i][0] || entity.textLabels[i][0] == '') continue;
            const dist = Math.sqrt(
                Math.pow(playerPos.x - entity.textLabels[i][1], 2) + Math.pow(playerPos.y - entity.textLabels[i][2], 2)
            );
            console.log('distance text:' + dist);
            if (dist > entity.textLabels[i][5]) continue;
            const pos: alt.Vector3 = new alt.Vector3(
                entity.textLabels[i][1],
                entity.textLabels[i][2],
                entity.textLabels[i][3]
            );
            if (!math.isPlayerLookingAtPos(pos, entity.textLabels[i][5])) continue;
            const TextLabelEvent = entity.textLabels[i][4];
            alt.emitServer('TextLabelAction', TextLabelEvent, entity.textLabels[i][1]);
            return;
        }
        checkmuell();
        checkAtm();
        checkGaststation();
    }
});
function checkGaststation() {
    const pos = alt.Player.local.pos;
    var e = native.getClosestObjectOfType(pos.x, pos.y, pos.z, 1, 1933174915, false, true, true);
    if (!e) e = native.getClosestObjectOfType(pos.x, pos.y, pos.z, 1, 4130089803, false, true, true);
    if (e) {
        const en = native.getEntityCoords(e, false);
        if (!math.isPlayerLookingAtPos(en)) return;
        alt.emitServer('tryFillVehicle');
        return;
    }
}
function checkAtm() {
    const pos = alt.Player.local.pos;
    for (let i in atms) {
        var e = native.getClosestObjectOfType(pos.x, pos.y, pos.z, 1, alt.hash(atms[i]), false, true, true);
        if (e) {
            const en = native.getEntityCoords(e, false);
            if (!math.isPlayerLookingAtPos(en)) return;
            alt.emitServer('openATM');
            return;
        }
    }
}
function checkmuell() {
    const pos = alt.Player.local.pos;
    for (let i in muell) {
        var e = native.getClosestObjectOfType(pos.x, pos.y, pos.z, 0.5, muell[i], false, true, true);
        if (e) {
            const en = native.getEntityCoords(e, false);
            native.freezeEntityPosition(e, true);
            if (!math.isPlayerLookingAtPos(en)) return;
            alt.emitServer('MuellOpen', en, 2);
            const player = alt.Player.local;
            native.requestAnimDict('anim@gangops@facility@servers@bodysearch@');
            native.taskPlayAnim(
                player,
                'anim@gangops@facility@servers@bodysearch@',
                'player_search',
                1,
                1,
                1000,
                0,
                0,
                false,
                false,
                false
            );
            return;
        }
    }
    for (let i in muellcane) {
        var e = native.getClosestObjectOfType(pos.x, pos.y, pos.z, 0.5, muellcane[i], false, true, true);
        if (e) {
            const en = native.getEntityCoords(e, false);
            if (!math.isPlayerLookingAtPos(en)) return;
            alt.emitServer('MuellOpen', en, 1);
            return;
        }
    }
}

function checkObjHash(hash) {
    const pos = alt.Player.local.pos;
    var e = native.getClosestObjectOfType(pos.x, pos.y, pos.z, 1, alt.hash(hash), false, true, true);
    return e;
}

function load3DText() {
    const test = alt.LocalObject.allWorld.filter((x) => alt.Player.local.pos.distanceTo(x.pos) < 3);
    //const test =alt.Entity.all.filter(x=> math.distance(x.pos,alt.Player.local.pos) < 5);
    for (let i = 0; i < test.length; i++) {
        if (test[i].model == 3552768664) {
            drawText3d('Wasserspender', test[i].pos.x, test[i].pos.y, test[i].pos.z + 1, 0.4, 4, 255, 255, 255, 255);
            continue;
        }
        if (test[i].model == 1933174915 || test[i].model == 4130089803) {
            drawText3d('Zapfsäule', test[i].pos.x, test[i].pos.y, test[i].pos.z + 1, 0.4, 4, 255, 255, 255, 255);
            continue;
        }
        for (let x in muell) {
            if (test[i].model != muell[x]) continue;
            drawText3d(
                'Mülltonne durchsuchen',
                test[i].pos.x,
                test[i].pos.y,
                test[i].pos.z + 1,
                0.4,
                4,
                255,
                255,
                255,
                255
            );
            break;
        }
        for (let x in muellcane) {
            if (test[i].model != muellcane[x]) continue;
            drawText3d(
                'Mülleimer durchsuchen',
                test[i].pos.x,
                test[i].pos.y,
                test[i].pos.z + 1,
                0.4,
                4,
                255,
                255,
                255,
                255
            );
            continue;
        }
        if (
            test[i].model == alt.hash('prop_atm_03') ||
            test[i].model == alt.hash('prop_atm_02') ||
            test[i].model == alt.hash('prop_atm_01') ||
            test[i].model == alt.hash('prop_fleeca_atm')
        ) {
            drawText3d('ATM', test[i].pos.x, test[i].pos.y, test[i].pos.z + 1, 0.4, 4, 255, 255, 255, 255);
            continue;
        }
    }
    if (alt.Player.local.hasSyncedMeta('Aduty')) {
        const fwd = math.getEntityForwardPosition(alt.Player.local, 2.0);
        const groundZ = native.getGroundZFor3dCoord(fwd.x, fwd.y, fwd.z, undefined, undefined, undefined);
        drawText3d('hier: ' + groundZ[0], fwd.x, fwd.y, groundZ[1], 0.4, 4, 255, 255, 255, 255);
        const obj = alt.LocalObject.allWorld.filter((x) => alt.Player.local.pos.distanceTo(x.pos) < 20);
        obj.forEach((element) => {
            alt.log(element.model);
            drawText3d(
                'Objecthash: ' + element.model,
                element.pos.x,
                element.pos.y,
                element.pos.z,
                0.4,
                4,
                255,
                255,
                255,
                255
            );
        });
    }
    for (let i = 0; i < entity.textLabels.length; i++) {
        if (!Array.isArray(entity.textLabels)) continue;
        if (!Array.isArray(entity.textLabels[i])) continue;
        if (!entity.textLabels[i][0] || entity.textLabels[i][0] == '') continue;
        drawText3d(
            entity.textLabels[i][0],
            entity.textLabels[i][1],
            entity.textLabels[i][2],
            entity.textLabels[i][3],
            0.4,
            4,
            255,
            255,
            255,
            255
        );
    }
    const players = [...alt.Player.all];
    for (let i = 0; i < players.length; i++) {
        const player = players[i];
        if (!player || !player.valid) {
            continue;
        }
        //if (alt.Player.local == player) continue;
        const scid: number = <number>player.getStreamSyncedMeta('SocialClubId');
        if (!scid) {
            continue;
        }
        const id = player.getStreamSyncedMeta('PlayerId');
        if (!id) {
            continue;
        }
        if (!friends.IsSocialClubIdFriend(scid) || native.getPedDrawableVariation(player, 1) > 0) {
            if (alt.Player.local.pos.distanceTo(player.pos) > 3) continue;
            drawText3d(
                'Unbekannter (' + id + ')',
                player.pos.x,
                player.pos.y,
                player.pos.z + 1,
                0.4,
                4,
                255,
                255,
                255,
                255
            );
            continue;
        }
        const name = player.getStreamSyncedMeta('FullName');
        if (!name) {
            continue;
        }
        if (alt.Player.local.pos.distanceTo(player.pos) > 3) continue;
        drawText3d(name + ' (' + id + ')', player.pos.x, player.pos.y, player.pos.z + 1, 0.4, 4, 255, 255, 255, 255);
    }
}

export function drawText3d(
    msg,
    x,
    y,
    z,
    scale,
    fontType,
    r,
    g,
    b,
    a,
    useOutline = true,
    useDropShadow = true,
    layer = 0
) {
    const playerPos = { ...alt.Player.local.pos };
    //if(Math.sqrt(Math.pow((playerPos.x-x),2)+Math.pow(playerPos.y -y,2)) > 10)return;
    let hex = msg.match('{.*}');
    if (hex) {
        const rgb = hexToRgb(hex[0].replace('{', '').replace('}', ''));
        r = rgb[0];
        g = rgb[1];
        b = rgb[2];
        msg = msg.replace(hex[0], '');
    }

    native.setDrawOrigin(x, y, z, false);
    native.beginTextCommandDisplayText('STRING');
    native.addTextComponentSubstringPlayerName(msg);
    native.setTextFont(fontType);
    native.setTextScale(1, scale);
    native.setTextWrap(0.0, 1.0);
    native.setTextCentre(true);
    native.setTextColour(r, g, b, a);

    if (useOutline) {
        native.setTextOutline();
    }

    if (useDropShadow) {
        native.setTextDropShadow();
    }

    native.endTextCommandDisplayText(0, 0, 0);
    native.clearDrawOrigin();
}

export function drawText2d(
    msg,
    x,
    y,
    scale,
    fontType,
    r,
    g,
    b,
    a,
    useOutline = true,
    useDropShadow = true,
    layer = 0,
    align = 0
) {
    let hex = msg.match('{.*}');
    if (hex) {
        const rgb = hexToRgb(hex[0].replace('{', '').replace('}', ''));
        r = rgb[0];
        g = rgb[1];
        b = rgb[2];
        msg = msg.replace(hex[0], '');
    }

    native.beginTextCommandDisplayText('STRING');
    native.addTextComponentSubstringPlayerName(msg);
    native.setTextFont(fontType);
    native.setTextScale(1, scale);
    native.setTextWrap(0.0, 1.0);
    native.setTextCentre(true);
    native.setTextColour(r, g, b, a);
    native.setTextJustification(align);

    if (useOutline) {
        native.setTextOutline();
    }

    if (useDropShadow) {
        native.setTextDropShadow();
    }

    native.endTextCommandDisplayText(x, y, 0);
}

function hexToRgb(hex) {
    var result = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(hex);
    return result
        ? {
              r: parseInt(result[1], 16),
              g: parseInt(result[2], 16),
              b: parseInt(result[3], 16),
          }
        : null;
}
