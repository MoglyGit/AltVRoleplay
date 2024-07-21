let interactPlayer = null;
let interactPlayer_Name = null;
function ShowMenu(state) {
    interactPlayer = null;
    interactPlayer_Name = null;
    document.getElementById('playerInfoBox').style.visibility = 'hidden';
    document.getElementById('playerInfoBox').style.display = 'none';
    document.getElementById('playerAnimation').style.visibility = 'hidden';
    document.getElementById('playerAnimation').style.display = 'none';
    document.getElementById('playerAnimation_Surrender').style.visibility = 'hidden';
    document.getElementById('playerAnimation_Surrender').style.display = 'none';
    if (state == 0) {
        document.getElementById('menu').style.visibility = 'visible';
        document.getElementById('menu').style.display = 'block';
        document.getElementById('playerList').style.visibility = 'hidden';
        document.getElementById('playerList').style.display = 'none';
        document.getElementById('playerInteraction').style.visibility = 'hidden';
        document.getElementById('playerInteraction').style.display = 'none';
    } else if (state == 1) {
        document.getElementById('playerList').style.visibility = 'visible';
        document.getElementById('playerList').style.display = 'block';
        document.getElementById('menu').style.visibility = 'hidden';
        document.getElementById('menu').style.display = 'none';
        document.getElementById('playerInteraction').style.visibility = 'hidden';
        document.getElementById('playerInteraction').style.display = 'none';
    } else if (state == 2) {
        document.getElementById('playerInteraction').style.visibility = 'visible';
        document.getElementById('playerInteraction').style.display = 'block';
        document.getElementById('menu').style.visibility = 'hidden';
        document.getElementById('menu').style.display = 'none';
        document.getElementById('playerList').style.visibility = 'hidden';
        document.getElementById('playerList').style.display = 'none';
    } else if (state == 3) {
        document.getElementById('playerAnimation').style.visibility = 'visible';
        document.getElementById('playerAnimation').style.display = 'block';
        document.getElementById('menu').style.visibility = 'hidden';
        document.getElementById('menu').style.display = 'none';
        document.getElementById('playerList').style.visibility = 'hidden';
        document.getElementById('playerList').style.display = 'none';
    }
}
function ShowAnimList(state) {
    document.getElementById('playerAnimation').style.visibility = 'hidden';
    document.getElementById('playerAnimation').style.display = 'none';
    if (state == 1) {
        document.getElementById('playerAnimation_Surrender').style.visibility = 'visible';
        document.getElementById('playerAnimation_Surrender').style.display = 'block';
    }
}
function ShowPlayer() {
    var node = document.getElementById('dynamicPlayerList');
    node.innerHTML = '';
    ShowMenu(1);
    alt.emit('getNearPlayersForInteraction');
}
function PlayerInteraction(item) {
    ShowMenu(2); // interactPlayer = null in Methode !!! nicht zeile vertauschen
    interactPlayer = item.dataset.player;
    interactPlayer_Name = item.dataset.pName;
    if (interactPlayer_Name.includes('Unbekannt')) document.getElementById('friendButton').value = 'Freund hinzufügen';
    else document.getElementById('friendButton').value = 'Freund entfernen';
}
function AddFriend() {
    if (interactPlayer == null) {
        ShowMenu(0);
        return;
    }
    const add = interactPlayer_Name.includes('Unbekannt');
    alt.emit('addFriend', parseInt(interactPlayer), add);
    if (add) {
        document.getElementById('friendButton').value = 'Freund entfernen';
        interactPlayer_Name = 'other';
    } else {
        document.getElementById('friendButton').value = 'Freund hinzufügen';
        interactPlayer_Name = 'Unbekannt';
    }
}
function GetBodyInfo() {
    if (interactPlayer == null) {
        ShowMenu(0);
        return;
    }
    alt.emit('getBodyInfo', parseInt(interactPlayer));
}
function InvitePlayerFirma() {
    if (interactPlayer == null) {
        ShowMenu(0);
        return;
    }
    alt.emit('invadePlayerInFirma', parseInt(interactPlayer));
}
function SearchPlayer() {
    if (interactPlayer == null) {
        ShowMenu(0);
        return;
    }
    alt.emit('searchPlayer', parseInt(interactPlayer));
    alt.emit('closeView');
}
function Anim(dic, name, inb, out, flag, lock, invBlock = false) {
    alt.emit('playAnim', dic, name, inb, out, flag, lock, invBlock);
}
function stopAnim() {
    alt.emit('stopAnim');
}
function setInPText(state) {
    alt.emit('setInText', state);
}
function BackToPlayerInteraction() {
    if (interactPlayer == null) {
        ShowMenu(0);
        return;
    }
    document.getElementById('playerInteraction').style.visibility = 'visible';
    document.getElementById('playerInteraction').style.display = 'block';
    document.getElementById('playerGiveMoney').style.visibility = 'hidden';
    document.getElementById('playerGiveMoney').style.display = 'none';
    document.getElementById('playerInfoBox').style.visibility = 'hidden';
    document.getElementById('playerInfoBox').style.display = 'none';
}
function givePlayerMoney(ev) {
    ev.preventDefault();
    if (interactPlayer == null) {
        ShowMenu(0);
        return;
    }
    document.getElementById('playerInteraction').style.visibility = 'visible';
    document.getElementById('playerInteraction').style.display = 'block';
    document.getElementById('playerGiveMoney').style.visibility = 'hidden';
    document.getElementById('playerGiveMoney').style.display = 'none';
    const money = document.getElementById('moneyTransfer').value;
    alt.emit('givePlayerMoney', parseInt(interactPlayer), parseInt(money));
}
function ShowFirma() {
    alt.emit('showFirmenHud');
}
function ShowMoneyBox() {
    if (interactPlayer == null) {
        ShowMenu(0);
        return;
    }
    document.getElementById('playerGiveMoney').style.visibility = 'visible';
    document.getElementById('playerGiveMoney').style.display = 'block';
    document.getElementById('playerInteraction').style.visibility = 'hidden';
    document.getElementById('playerInteraction').style.display = 'none';
}
alt.on('bodyInfo', (height, eyeCo)=>{
    document.getElementById('playerInfoBox').style.visibility = 'visible';
    document.getElementById('playerInfoBox').style.display = 'block';
    document.getElementById('playerInteraction').style.visibility = 'hidden';
    document.getElementById('playerInteraction').style.display = 'none';
    document.getElementById('pName').innerHTML = 'Name: ' + interactPlayer_Name;
    if (Math.random() <= 0.5) height += Math.floor(Math.random() * 20);
    else height -= Math.floor(Math.random() * 20);
    document.getElementById('pHeight').innerHTML = 'Größe ca.: ' + height + ' cm';
    document.getElementById('pEyes').innerHTML = 'Augenfarbe: ' + eyeCo;
});
alt.on('ShowMainHud', ()=>{
    ShowMenu(0);
});
alt.on('showMenuPoints', (faction, faction_rank, firma, firma_rank)=>{
    if (faction > 0) document.getElementById('FrakMenu').style.display = 'block';
    if (firma > 0) document.getElementById('FirmenMenu').style.display = 'block';
    if (firma_rank >= 2 && firma > 0) document.getElementById('invateFirma').style.display = 'block';
});
alt.on('createPlayerForInteractionMenu', (name, player)=>{
    var menuList = document.getElementById('dynamicPlayerList');
    var x = document.createElement('li');
    x.setAttribute('class', 'center button2');
    x.setAttribute('onclick', 'PlayerInteraction(this)');
    x.style.backgroundColor = 'rgba(0, 80, 185, 0.712)';
    x.dataset.player = player;
    x.dataset.pName = name;
    var t = document.createTextNode('' + name);
    x.appendChild(t);
    menuList.appendChild(x);
});
