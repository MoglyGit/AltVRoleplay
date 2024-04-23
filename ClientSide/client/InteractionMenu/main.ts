import * as alt from 'alt-client';
import * as native from 'natives';
import * as friends from '../PlayerFriends/Friends.js';

const url = `http://resource/client/InteractionMenu/Menu.html`;
let view = null;
let cameraControlsInterval = null;
let allowKeys = true;
export let targetPlayerInv = null;
let animDic = null;
let animName = null;
let animBlockInv = false;

alt.onServer('ShowInteractMenu', ShowInteractMenu);
alt.onServer('PlayerBodyInfos', PlayerBodyInfos);
alt.onServer('SetPlayerMenu', ShowInteractMenu);

alt.on('keydown', (key) => {
    if (key == 113) {
        if (view == null) GetPlayerMenuInfos();
        else closeView();
        return;
    }
});

function GetPlayerMenuInfos() {
    alt.emitServer('GetPlayerMenuInfos');
}

function ShowInteractMenu(faction, faction_rank, firma, firma_rank) {
    if (view == null) {
        view = new alt.WebView(url);
        view.on('closeView', closeView);
        view.on('getNearPlayersForInteraction', getNearPlayersForInteraction);
        view.on('getBodyInfo', getBodyInfo);
        view.on('invadePlayerInFirma', invadePlayerInFirma);
        view.on('addFriend', addFriend);
        view.on('givePlayerMoney', givePlayerMoney);
        view.on('setInText', setInText);
        view.on('searchPlayer', searchPlayer);
        view.on('playAnim', playAnim);
        view.on('stopAnim', stopAnim);
        view.emit('showMenuPoints', faction, faction_rank, firma, firma_rank);
        view.on('showFirmenHud', showFirmenHud);
        view.focus();
        showCursor(true);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        allowKeys = true;
        return;
    }
    view.on('ShowMainHud');
}

function showFirmenHud() {
    closeView();
    alt.emitServer('openFirmenHud');
}

function showCursor(state) {
    try {
        alt.showCursor(state);
    } catch (err) {
        return;
    }
}

function handleControls() {
    if (!allowKeys) {
        native.disableAllControlActions(0);
    }
    native.disableControlAction(0, 1, true);
    native.disableControlAction(0, 2, true);
    native.disableControlAction(0, 24, true);
    native.disableControlAction(0, 25, true);
}

function closeView() {
    if (cameraControlsInterval !== undefined || cameraControlsInterval !== null) {
        alt.clearInterval(cameraControlsInterval);
        cameraControlsInterval = null;
    }
    if (view && view.destroy) {
        view.destroy();
    }
    view = null;
    showCursor(false);
}

function setInText(state: number) {
    if (state == 1) {
        allowKeys = false;
    } else {
        allowKeys = true;
    }
}

function playAnim(dic: string, name: string, inb: number, out: number, flag: number, lock: boolean, invBlock: boolean) {
    if (view != null) {
        alt.emitServer('PlayAnimation', dic, name, inb, out, flag, lock, invBlock);
        animDic = dic;
        animName = name;
        animBlockInv = invBlock;
    }
}

function stopAnim() {
    if (view != null) {
        if (animName == null || animDic == null) return;
        alt.emitServer('StoppPlayAnimation', animDic, animName, animBlockInv);
        animDic = null;
        animName = null;
    }
}

function searchPlayer(playerid: number) {
    if (view != null) {
        alt.emitServer('GetPlayerSearch', playerid);
        targetPlayerInv = playerid;
    }
}

function givePlayerMoney(playerid: number, money: number) {
    if (view != null) alt.emitServer('GivePlayerMoneyFromPlayer', playerid, money);
}

function PlayerBodyInfos(height: number, eyeCol: string) {
    if (view != null) view.emit('bodyInfo', height, eyeCol);
}

function getBodyInfo(playerid: number) {
    if (view != null) alt.emitServer('GetPlayerBodyInfos', playerid);
}

function invadePlayerInFirma(playerid: number) {
    if (view != null) alt.emitServer('InvadePlayerInFirma', playerid);
}

function addFriend(playerid: number, add: boolean) {
    if (view != null) alt.emitServer('AddPlayerFriend', playerid, add);
}

function getNearPlayersForInteraction() {
    if (view == null) return;
    const players = alt.Player.all;
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
        let name = 'Unbekannter';
        if (!friends.IsSocialClubIdFriend(scid) || native.getPedDrawableVariation(player, 1) > 0) {
            name = 'Unbekannter (' + id + ')';
        } else name = '' + player.getStreamSyncedMeta('FullName');
        if (alt.Player.local.pos.distanceTo(player.pos) > 2) continue;
        if (view == null) continue;
        view.emit('createPlayerForInteractionMenu', name, id);
    }
}
