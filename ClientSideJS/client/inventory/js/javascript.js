let maxWeight = 0;
let actuallWeight = 0;
let backpackMaxWeight = 0;
let backpackactuallWeight = 0;
let otherinfMaxWeight = 0;
let otherinfactualWeight = 0;
let otherinfName = '';
let timeOut = null;
//Div create Inv
const toAdd = document.createDocumentFragment();
const toAddBack = document.createDocumentFragment();
for(let i = 0; i < 24; i++){
    let newDiv = document.createElement('div');
    newDiv.setAttribute('class', 'invplace');
    newDiv.setAttribute('id', 'inv' + i);
    newDiv.setAttribute('onmouseenter', 'mouseenter(this)');
    newDiv.setAttribute('data-place', '1');
    toAdd.appendChild(newDiv);
    let newDivBack = document.createElement('div');
    newDivBack.setAttribute('class', 'invplace');
    newDivBack.setAttribute('id', 'backl' + i);
    newDivBack.setAttribute('onmouseenter', 'backpackenter(this)');
    newDivBack.setAttribute('data-place', '2');
    toAddBack.appendChild(newDivBack);
}
document.getElementById('inventar').appendChild(toAdd);
document.getElementById('backpack3').appendChild(toAddBack);
let stackItem = null;
let itemSelected = null;
let itemStardInv = null;
let itemStartParent = null;
let itemStartPositionStyle = null;
let hasbackpack = 0;
let rightClickItem = null;
let splitItem = null;
let reNameItem = null;
let acceptedSlot = null;
let otherBackPack = null;
function CloseMenu() {
    ClearMenuList();
    document.getElementById('contextMenu').style.display = 'none';
}
function ClearMenuList() {
    var node = document.getElementById('menu');
    node.innerHTML = '';
    rightClickItem = null;
}
function backPackShow(e, item) {
    if (itemSelected != null) stopItemMove();
    if (item.dataset.dbid == hasbackpack) return;
    rightClickItem = item;
    var menu = document.getElementById('contextMenu');
    menu.style.display = 'block';
    menu.style.left = e.pageX + 'px';
    menu.style.top = e.pageY + 'px';
    var menuList = document.getElementById('menu');
    var x = document.createElement('li');
    var t;
    if (otherBackPack == rightClickItem.dataset.dbid) {
        x.setAttribute('onclick', 'OtherBackPackClose()');
        t = document.createTextNode('Schliessen');
    } else if (otherBackPack == null && otherinfMaxWeight == 0) {
        x.setAttribute('onclick', 'BackPackShow()');
        t = document.createTextNode('Öffnen');
    }
    x.appendChild(t);
    menuList.appendChild(x);
}
function useAble(e, item) {
    if (itemSelected != null) stopItemMove();
    if (item.dataset.place == '0') return;
    if (item.dataset.place == '4') return;
    rightClickItem = item;
    var menu = document.getElementById('contextMenu');
    menu.style.display = 'block';
    menu.style.left = e.pageX + 'px';
    menu.style.top = e.pageY + 'px';
    var menuList = document.getElementById('menu');
    var x = document.createElement('li');
    x.setAttribute('onclick', 'UseItem()');
    var t = document.createTextNode('Benutzen');
    x.appendChild(t);
    menuList.appendChild(x);
}
function reName(e, item) {
    if (itemSelected != null) stopItemMove();
    //if (item.dataset.place == '0') return;
    rightClickItem = item;
    var menu = document.getElementById('contextMenu');
    menu.style.display = 'block';
    menu.style.left = e.pageX + 'px';
    menu.style.top = e.pageY + 'px';
    var menuList = document.getElementById('menu');
    var x = document.createElement('li');
    x.setAttribute('onclick', 'RenameItem(' + e.pageX + ',' + e.pageY + ')');
    var t = document.createTextNode('Umbenennen');
    x.appendChild(t);
    menuList.appendChild(x);
}
function equip(e, item) {
    if (itemSelected != null) stopItemMove();
    if (item.dataset.place == '0') return;
    if (item.dataset.place == '4') return;
    rightClickItem = item;
    var menu = document.getElementById('contextMenu');
    menu.style.display = 'block';
    menu.style.left = e.pageX + 'px';
    menu.style.top = e.pageY + 'px';
    var menuList = document.getElementById('menu');
    var x = document.createElement('li');
    x.setAttribute('onclick', 'EquipItem()');
    var t = document.createTextNode('An-/Ablegen');
    x.appendChild(t);
    menuList.appendChild(x);
}
function split(e, item) {
    if (itemSelected != null) stopItemMove();
    //if (item.dataset.place == '0') return;
    rightClickItem = item;
    var menu = document.getElementById('contextMenu');
    menu.style.display = 'block';
    menu.style.left = e.pageX + 'px';
    menu.style.top = e.pageY + 'px';
    var menuList = document.getElementById('menu');
    var x = document.createElement('li');
    x.setAttribute('onclick', 'SplitItem(' + e.pageX + ',' + e.pageY + ')');
    var t = document.createTextNode('Teilen');
    x.appendChild(t);
    menuList.appendChild(x);
}
function drivlic(e, item) {
    if (itemSelected != null) stopItemMove();
    rightClickItem = item;
    var menu = document.getElementById('contextMenu');
    menu.style.display = 'block';
    menu.style.left = e.pageX + 'px';
    menu.style.top = e.pageY + 'px';
    var menuList = document.getElementById('menu');
    var x = document.createElement('li');
    x.setAttribute('onclick', 'ShowDrive()');
    var t = document.createTextNode('Anschauen');
    x.appendChild(t);
    menuList.appendChild(x);
    var x = document.createElement('li');
    x.setAttribute('onclick', 'GetNearPlayers(this)');
    x.dataset.action = '1';
    var t = document.createTextNode('Zeigen');
    x.appendChild(t);
    menuList.appendChild(x);
}
function perso(e, item) {
    if (itemSelected != null) stopItemMove();
    rightClickItem = item;
    var menu = document.getElementById('contextMenu');
    menu.style.display = 'block';
    menu.style.left = e.pageX + 'px';
    menu.style.top = e.pageY + 'px';
    var menuList = document.getElementById('menu');
    var x = document.createElement('li');
    x.setAttribute('onclick', 'ShowPerso()');
    var t = document.createTextNode('Anschauen');
    x.appendChild(t);
    menuList.appendChild(x);
    var x = document.createElement('li');
    x.setAttribute('onclick', 'GetNearPlayers(this)');
    x.dataset.action = '0';
    var t = document.createTextNode('Zeigen');
    x.appendChild(t);
    menuList.appendChild(x);
}
function SplitItem(x, y) {
    if (rightClickItem == null) return;
    splitItem = rightClickItem;
    var menu = document.getElementById('split');
    var maxinput = document.getElementById('splitamount');
    maxinput.setAttribute('max', rightClickItem.dataset.ammount);
    menu.style.left = x + 'px';
    menu.style.top = y + 'px';
    menu.style.display = 'block';
}
function splitItemAmount() {
    if (splitItem == null) return;
    var amount = parseInt(document.getElementById('splitamount').value);
    alt.emit('splitItem', parseInt(splitItem.dataset.dbid), amount, splitItem.parentNode.id);
    var menu = document.getElementById('split');
    menu.style.display = 'none';
}
function RenameItem(x, y) {
    if (rightClickItem == null) return;
    reNameItem = rightClickItem;
    var menu = document.getElementById('rename');
    menu.style.left = x + 'px';
    menu.style.top = y + 'px';
    menu.style.display = 'block';
    alt.emit('blockInv', true);
}
function renameItemServer(ev) {
    ev.preventDefault();
    if (reNameItem == null) return;
    var newItemName = document.getElementById('renameItem').value;
    if (newItemName.trim().length < 3) return;
    alt.emit('renameItem', parseInt(reNameItem.dataset.dbid), newItemName);
    var menu = document.getElementById('rename');
    menu.style.display = 'none';
    reNameItem.dataset.description = newItemName;
    showItemInfo(reNameItem);
    reNameItem = null;
    alt.emit('blockInv', false);
}
function BackPackShow() {
    if (rightClickItem == null) return;
    if (rightClickItem.dataset.dbid == hasbackpack) return;
    alt.emit('showOtherBackpack', parseInt(rightClickItem.dataset.dbid));
    otherBackPack = rightClickItem.dataset.dbid;
}
function OtherBackPackClose() {
    if (rightClickItem == null) return;
    alt.emit('deleteOtherBackpack');
    otherBackPack = null;
    otherinfMaxWeight = 0;
}
function ShowDrive() {
    if (rightClickItem == null) return;
    alt.emit('showDrive', parseInt(rightClickItem.dataset.dbid));
}
function ShowDrivePlayer(item) {
    if (rightClickItem == null) return;
    alt.emit('showPlayerDrive', parseInt(item.dataset.player), parseInt(rightClickItem.dataset.dbid));
}
function ShowPerso() {
    if (rightClickItem == null) return;
    alt.emit('showPerso', parseInt(rightClickItem.dataset.dbid));
}
function EquipItem() {
    if (rightClickItem == null) return;
    alt.emit('equipItem', parseInt(rightClickItem.dataset.dbid));
}
function UseItem() {
    if (rightClickItem == null) return;
    alt.emit('useitem', parseInt(rightClickItem.dataset.dbid));
}
function ShowPersoPlayer(item) {
    if (rightClickItem == null) return;
    alt.emit('showPlayerPerso', parseInt(item.dataset.player), parseInt(rightClickItem.dataset.dbid));
}
alt.on('ClearMenuItems', ()=>{
    var node = document.getElementById('menu');
    node.innerHTML = '';
});
alt.on('createMenuPlayer', (action, name, player)=>{
    if (rightClickItem == null) return;
    var menu = document.getElementById('contextMenu');
    menu.style.display = 'block';
    var menuList = document.getElementById('menu');
    var x = document.createElement('li');
    if (action == 0) {
        x.setAttribute('onclick', 'ShowPersoPlayer(this)');
        x.dataset.player = player;
    }
    if (action == 1) {
        x.setAttribute('onclick', 'ShowDrivePlayer(this)');
        x.dataset.player = player;
    }
    var t = document.createTextNode('' + name);
    x.appendChild(t);
    menuList.appendChild(x);
});
function GetNearPlayers(item) {
    if (rightClickItem == null) return;
    alt.emit('getNearPlayer', parseInt(item.dataset.action));
}
function mouseenterBoden() {
    if (itemSelected == null) return;
    //document.getElementById('boden').appendChild(itemSelected);
    acceptedSlot = document.getElementById('boden');
}
function itemOnGround() {
    itemSelected.style.backgroundColor = '#00000000';
    alt.emit('itemonground', parseInt(itemSelected.dataset.dbid), itemStardInv, hasbackpack);
    itemSelected.dataset.ground = '1';
    if (itemSelected.dataset.type == 1 && hasbackpack != 0 && itemSelected.dataset.place == 1) {
        removebackpack();
    }
    itemSelected.dataset.place = '0';
    itemSelected = null;
    itemStardInv = null;
    updateWeightInfo();
}
function bodenclick() {
    if (itemSelected != null) {
        itemOnGround();
        return;
    }
}
function updateAmount(item) {
    item.innerHTML = item.dataset.ammount + 'x';
}
function addStack(slotItem) {
    if (itemSelected.dataset.type == 1) return;
    if (itemSelected == slotItem) return;
    document.body.appendChild(itemSelected);
    itemSelected.style.visibility = 'hidden';
    itemSelected.dataset.place = slotItem.dataset.place;
    stackItem = slotItem;
    stackItem.style.backgroundColor = '#e38400';
    stackItem.dataset.ammount = parseInt(itemSelected.dataset.ammount) + parseInt(stackItem.dataset.ammount);
    stackItem.dataset.mass = (parseFloat(itemSelected.dataset.mass) + parseFloat(stackItem.dataset.mass)).toFixed(2);
    updateAmount(stackItem);
}
function mouseenter(slot) {
    if (itemSelected == null) return;
    if (slot.hasChildNodes()) {
        if (itemSelected.dataset.type == 0) return;
        if (itemSelected.dataset.type != slot.lastChild.dataset.type) return;
        if (parseInt(itemSelected.dataset.ammount) + parseInt(slot.lastChild.dataset.ammount) > parseInt(itemSelected.dataset.maxamount)) return;
        if (!itemStardInv.includes('inv') && actuallWeight + parseFloat(itemSelected.dataset.mass) > maxWeight) return;
        if (stackItem == null) addStack(slot.lastChild);
        return;
    }
    if (itemSelected.dataset.type == 1 && hasbackpack != 0 && itemSelected.dataset.place != '1') return;
    if (!itemStardInv.includes('inv') && itemSelected.dataset.place != '1' && actuallWeight + parseFloat(itemSelected.dataset.mass) > maxWeight) return;
    //slot.appendChild(itemSelected);
    acceptedSlot = slot;
    itemSelected.dataset.place = '1';
    if (itemSelected.style.visibility == 'hidden') itemSelected.style.visibility = 'visible';
    if (stackItem != null) {
        stackItem.style.backgroundColor = '#00000000';
        itemSelected.style.backgroundColor = '#2bff00a1';
        stackItem.dataset.ammount = parseInt(stackItem.dataset.ammount) - parseInt(itemSelected.dataset.ammount);
        stackItem.dataset.mass = (parseFloat(stackItem.dataset.mass) - parseFloat(itemSelected.dataset.mass)).toFixed(2);
        updateAmount(stackItem);
        stackItem = null;
    }
}
function removebackpack() {
    hasbackpack = 0;
    document.getElementById('backpack3').style.display = 'none';
    for(let i = 0; i < 24; i++){
        let element = document.getElementById('backl' + i);
        if (element.hasChildNodes()) {
            element.removeChild(element.firstChild);
        }
    }
}
function backpackenter(slot) {
    if (itemSelected == null) return;
    if (slot.hasChildNodes()) {
        if (itemSelected.dataset.type == 0) return;
        if (itemSelected.dataset.type != slot.lastChild.dataset.type) return;
        if (parseInt(itemSelected.dataset.ammount) + parseInt(slot.lastChild.dataset.ammount) > parseInt(itemSelected.dataset.maxamount)) return;
        if (!itemStardInv.includes('back') && backpackactuallWeight + parseFloat(itemSelected.dataset.mass) > backpackMaxWeight) return;
        if (stackItem == null) addStack(slot.lastChild);
        return;
    }
    if (itemSelected.dataset.type == 1) return;
    if (hasbackpack == 0) {
        removebackpack();
        return;
    }
    if (!itemStardInv.includes('back') && itemSelected.dataset.place != '2' && backpackactuallWeight + parseFloat(itemSelected.dataset.mass) > backpackMaxWeight) return;
    //slot.appendChild(itemSelected);
    acceptedSlot = slot;
    itemSelected.dataset.place = '2';
    if (itemSelected.style.visibility == 'hidden') itemSelected.style.visibility = 'visible';
    if (stackItem != null) {
        stackItem.style.backgroundColor = '#00000000';
        itemSelected.style.backgroundColor = '#2bff00a1';
        stackItem.dataset.ammount = parseInt(stackItem.dataset.ammount) - parseInt(itemSelected.dataset.ammount);
        stackItem.dataset.mass = (parseFloat(stackItem.dataset.mass) - parseFloat(itemSelected.dataset.mass)).toFixed(2);
        updateAmount(stackItem);
        stackItem = null;
    }
}
function otherenter(slot) {
    if (itemSelected == null) return;
    if (otherBackPack != null && itemSelected.dataset.type == 1) return;
    if (otherBackPack == itemSelected.dataset.dbid) return;
    if (slot.hasChildNodes()) {
        if (itemSelected.dataset.type == 0) return;
        if (itemSelected.dataset.type != slot.lastChild.dataset.type) return;
        if (parseInt(itemSelected.dataset.ammount) + parseInt(slot.lastChild.dataset.ammount) > parseInt(itemSelected.dataset.maxamount)) return;
        if (!itemStardInv.includes('other') && otherinfactualWeight + parseFloat(itemSelected.dataset.mass) > otherinfMaxWeight) return;
        if (stackItem == null) addStack(slot.lastChild);
        return;
    }
    if (!itemStardInv.includes('other') && itemSelected.dataset.place != '4' && otherinfactualWeight + parseFloat(itemSelected.dataset.mass) > otherinfMaxWeight) return;
    //slot.appendChild(itemSelected);
    acceptedSlot = slot;
    itemSelected.dataset.place = '4';
    if (itemSelected.style.visibility == 'hidden') itemSelected.style.visibility = 'visible';
    if (stackItem != null) {
        stackItem.style.backgroundColor = '#00000000';
        itemSelected.style.backgroundColor = '#2bff00a1';
        stackItem.dataset.ammount = parseInt(stackItem.dataset.ammount) - parseInt(itemSelected.dataset.ammount);
        stackItem.dataset.mass = (parseFloat(stackItem.dataset.mass) - parseFloat(itemSelected.dataset.mass)).toFixed(2);
        updateAmount(stackItem);
        stackItem = null;
    }
}
function schuhe(slot) {
    if (itemSelected == null) return;
    if (slot.hasChildNodes()) return;
    if (itemSelected.dataset.type != 7) return;
    //slot.appendChild(itemSelected);
    acceptedSlot = slot;
    itemSelected.dataset.place = '3';
}
function hose(slot) {
    if (itemSelected == null) return;
    if (slot.hasChildNodes()) return;
    if (itemSelected.dataset.type != 6) return;
    //slot.appendChild(itemSelected);
    acceptedSlot = slot;
    itemSelected.dataset.place = '3';
}
function under(slot) {
    if (itemSelected == null) return;
    if (slot.hasChildNodes()) return;
    if (itemSelected.dataset.type != 8) return;
    //slot.appendChild(itemSelected);
    acceptedSlot = slot;
    itemSelected.dataset.place = '3';
}
function tops(slot) {
    if (itemSelected == null) return;
    if (slot.hasChildNodes()) return;
    if (itemSelected.dataset.type != 9) return;
    //slot.appendChild(itemSelected);
    acceptedSlot = slot;
    itemSelected.dataset.place = '3';
}
function mask(slot) {
    if (itemSelected == null) return;
    if (slot.hasChildNodes()) return;
    if (itemSelected.dataset.type != 5) return;
    //slot.appendChild(itemSelected);
    acceptedSlot = slot;
    itemSelected.dataset.place = '3';
}
function acces(slot) {
    if (itemSelected == null) return;
    if (slot.hasChildNodes()) return;
    if (itemSelected.dataset.type != 19) return;
    //slot.appendChild(itemSelected);
    acceptedSlot = slot;
    itemSelected.dataset.place = '3';
}
function hut(slot) {
    if (itemSelected == null) return;
    if (slot.hasChildNodes()) return;
    if (itemSelected.dataset.type != 10) return;
    //slot.appendChild(itemSelected);
    acceptedSlot = slot;
    itemSelected.dataset.place = '3';
}
function brille(slot) {
    if (itemSelected == null) return;
    if (slot.hasChildNodes()) return;
    if (itemSelected.dataset.type != 11) return;
    //slot.appendChild(itemSelected);
    acceptedSlot = slot;
    itemSelected.dataset.place = '3';
}
function ohrring(slot) {
    if (itemSelected == null) return;
    if (slot.hasChildNodes()) return;
    if (itemSelected.dataset.type != 12) return;
    // slot.appendChild(itemSelected);
    acceptedSlot = slot;
    itemSelected.dataset.place = '3';
}
function uhr(slot) {
    if (itemSelected == null) return;
    if (slot.hasChildNodes()) return;
    if (itemSelected.dataset.type != 13) return;
    //slot.appendChild(itemSelected);
    acceptedSlot = slot;
    itemSelected.dataset.place = '3';
}
function armband(slot) {
    if (itemSelected == null) return;
    if (slot.hasChildNodes()) return;
    if (itemSelected.dataset.type != 14) return;
    //slot.appendChild(itemSelected);
    acceptedSlot = slot;
    itemSelected.dataset.place = '3';
}
function getCursor(event) {
    if (itemSelected == null) return;
    const x = event.clientX;
    const y = event.clientY;
    const infoElement = itemSelected;
    const posx = x - 50;
    const posy = y - 50;
    infoElement.style.top = posy + 'px';
    infoElement.style.left = posx + 'px';
}
function itemclick(event, item) {
    if (event.button != 0) return;
    CloseMenu();
    if (itemSelected != null) return;
    var menu = document.getElementById('split');
    menu.style.display = 'none';
    splitItem = null;
    reNameItem = null;
    itemSelected = item;
    itemStardInv = itemSelected.parentNode.id;
    itemStartParent = itemSelected.parentNode;
    itemStartPositionStyle = itemSelected.style.position;
    itemSelected.style.position = 'absolute';
    document.body.appendChild(itemSelected);
    itemSelected.style.backgroundColor = '#2bff00a1';
    showItemInfo(itemSelected);
}
function stopItemMove() {
    if (itemSelected != null) {
        if (itemStartPositionStyle != null) itemSelected.style.position = itemStartPositionStyle;
        if (acceptedSlot == null) {
            itemSelected.style.backgroundColor = '#00000000';
            itemStartParent.appendChild(itemSelected);
            itemStartParent = null;
            itemStartPositionStyle = null;
            itemSelected = null;
            itemStardInv = null;
            return;
        }
        acceptedSlot.appendChild(itemSelected);
        if (acceptedSlot.id == 'boden') {
            itemOnGround();
            return;
        }
        acceptedSlot = null;
        itemSelected.style.backgroundColor = '#00000000';
        if (itemSelected.dataset.type == 1) {
            if (itemSelected.dataset.place == 4) {
                if (hasbackpack == itemSelected.dataset.dbid) {
                    hasbackpack = 0;
                    removebackpack();
                }
            }
            if (itemSelected.dataset.place == 1 && !('ground' in itemSelected.dataset)) {
                if (hasbackpack == 0) {
                    hasbackpack = parseInt(itemSelected.dataset.dbid);
                    if (otherBackPack == itemSelected.dataset.dbid) {
                        //testdas
                        otherBackPack = null;
                        otherinfMaxWeight = 0;
                        console.log('remove Backpack');
                    }
                    alt.emit('backpackItems', hasbackpack);
                }
            }
        }
        if ('ground' in itemSelected.dataset && itemSelected.dataset.place != 0) {
            if (stackItem != null) {
                alt.emit('stackInvItem', parseInt(stackItem.dataset.dbid), parseInt(stackItem.dataset.ammount), parseInt(itemSelected.dataset.dbid), true, stackItem.parentNode.id, itemStardInv);
                stackItem.style.backgroundColor = '#00000000';
                stackItem = null;
            } else alt.emit('takeGroundItem', parseInt(itemSelected.dataset.dbid), itemSelected.parentNode.id, hasbackpack);
            if (itemSelected.dataset.type == 1 && itemSelected.dataset.place == 1) {
                if (hasbackpack == 0) {
                    hasbackpack = parseInt(itemSelected.dataset.dbid);
                    if (otherBackPack == itemSelected.dataset.dbid) {
                        //testdas
                        otherBackPack = null;
                        otherinfMaxWeight = 0;
                        console.log('remove Backpack');
                    }
                    alt.emit('backpackItems', hasbackpack);
                }
            }
            delete itemSelected.dataset.ground;
            updateWeightInfo();
            itemStartParent = null;
            itemStartPositionStyle = null;
            itemSelected = null;
            itemStardInv = null;
            return;
        }
        if (itemStardInv != itemSelected.parentNode.id && itemSelected.dataset.place != 0) alt.emit('itemmoveinv', parseInt(itemSelected.dataset.dbid), itemStardInv, itemSelected.parentNode.id, hasbackpack);
        if (stackItem != null) {
            alt.emit('stackInvItem', parseInt(stackItem.dataset.dbid), parseInt(stackItem.dataset.ammount), parseInt(itemSelected.dataset.dbid), false, stackItem.parentNode.id, itemStardInv);
            stackItem.style.backgroundColor = '#00000000';
            stackItem = null;
        }
        itemStartParent = null;
        itemStartPositionStyle = null;
        itemSelected = null;
        itemStardInv = null;
        return;
    }
}
function updateOtherInfMass() {
    document.getElementById('interactionInvInfo').innerHTML = otherinfName + ' (' + otherinfactualWeight.toFixed(2) + '/' + otherinfMaxWeight + 'kg)';
}
function updateBackWeightInfo() {
    if (hasbackpack == 0) {
        removebackpack();
        return;
    }
    document.getElementById('backinf3').innerHTML = 'Rucksack (' + backpackactuallWeight.toFixed(2) + '/' + backpackMaxWeight + 'kg)';
    document.getElementById('' + hasbackpack).innerHTML = backpackactuallWeight.toFixed(2) + 'kg';
}
function updateWeightInfo() {
    if (hasbackpack == 0) {
        removebackpack();
    }
    document.getElementById('inf').innerHTML = 'Inventar (' + actuallWeight.toFixed(2) + '/' + maxWeight + 'kg)';
}
function createitem(id, des, type, ammount, mass, maxamount) {
    const newDiv = document.createElement('div');
    newDiv.setAttribute('class', 'item');
    newDiv.setAttribute('id', '' + id);
    newDiv.setAttribute('onmousedown', 'itemclick(event,this)');
    newDiv.setAttribute('onmouseup', 'stopItemMove()');
    //newDiv.setAttribute('onmousemove', 'getCursor(event)');
    newDiv.style.zIndex = '-1';
    newDiv.innerHTML = ammount + 'x';
    newDiv.dataset.dbid = '' + id;
    newDiv.dataset.description = des;
    newDiv.dataset.type = '' + type;
    newDiv.dataset.ammount = '' + ammount;
    const itemmass = mass * ammount;
    newDiv.dataset.mass = '' + itemmass.toFixed(2);
    newDiv.dataset.maxamount = '' + maxamount;
    newDiv.addEventListener('contextmenu', ()=>{
        ClearMenuList();
        showItemInfo(newDiv);
    });
    if (type == 1) {
        newDiv.dataset.ammount = ammount.toFixed(2);
        newDiv.innerHTML = newDiv.dataset.ammount + 'kg';
        newDiv.dataset.mass = '' + 0;
        newDiv.addEventListener('contextmenu', (e)=>{
            backPackShow(e, newDiv);
        });
    }
    if (type == 16) {
        newDiv.addEventListener('contextmenu', (e)=>{
            perso(e, newDiv);
        });
    }
    if (type == 17) {
        newDiv.addEventListener('contextmenu', (e)=>{
            drivlic(e, newDiv);
        });
    }
    if (type == 33 || type == 34 || type == 35 || type == 40 || type == 50 || type == 51 || type == 52) {
        newDiv.addEventListener('contextmenu', (e)=>{
            equip(e, newDiv);
        });
    }
    if (type == 36 || type == 37 || type == 38 || type == 39 || type >= 41 && type <= 49 || type == 53) {
        newDiv.addEventListener('contextmenu', (e)=>{
            useAble(e, newDiv);
        });
    }
    if (maxamount > 1) {
        newDiv.addEventListener('contextmenu', (e)=>{
            split(e, newDiv);
        });
    }
    newDiv.addEventListener('contextmenu', (e)=>{
        reName(e, newDiv);
    });
    return newDiv;
}
function addGround(id, des, type, src, ammount, mass, maxamount) {
    const item = createitem(id, des, type, ammount, mass, maxamount);
    item.style.backgroundImage = 'url("' + src + '")';
    item.dataset.ground = '1';
    item.dataset.place = '0';
    document.getElementById('boden').appendChild(item);
}
alt.on('addGround', (id, des, type, src, ammo, mass, maxamount)=>{
    addGround(id, des, type, src, ammo, mass, maxamount);
});
alt.on('addInv', (id, des, type, slot, src, ammo, mass, maxamount)=>{
    const item = createitem(id, des, type, ammo, mass, maxamount);
    item.style.backgroundImage = 'url("' + src + '")';
    if (type == 1 && hasbackpack == 0) {
        hasbackpack = id;
        alt.emit('backpackItems', id);
    }
    item.dataset.place = '1';
    document.getElementById('inv' + slot).appendChild(item);
});
alt.on('addBackHud', (size, weight)=>{
    if (hasbackpack == 0) {
        removebackpack();
        return;
    }
    document.getElementById('backpack3').style.display = 'block';
    backpackMaxWeight = 5 * size;
    backpackactuallWeight = parseFloat(weight.replace(',', '.'));
    updateBackWeightInfo();
});
alt.on('addBack', (id, des, type, slot, src, size, ammo, mass, maxamount)=>{
    if (hasbackpack == 0) {
        removebackpack();
        return;
    }
    const item = createitem(id, des, type, ammo, mass, maxamount);
    item.style.backgroundImage = 'url("' + src + '")';
    item.dataset.place = '2';
    document.getElementById('backl' + slot).appendChild(item);
});
alt.on('addOtherHud', (size, weight)=>{
    document.getElementById('interactionInv').style.display = 'block';
    otherinfMaxWeight = parseFloat(size.replace(',', '.'));
    otherinfactualWeight = parseFloat(weight.replace(',', '.'));
    updateOtherInfMass();
});
alt.on('addOther', (id, des, type, slot, src, ammo, mass, maxamount)=>{
    const item = createitem(id, des, type, ammo, mass, maxamount);
    item.style.backgroundImage = 'url("' + src + '")';
    item.dataset.place = '4';
    document.getElementById('other' + slot).appendChild(item);
});
alt.on('addCloth', (id, des, type, slot, src, ammo, mass, maxamount)=>{
    const item = createitem(id, des, type, ammo, mass, maxamount);
    item.style.backgroundImage = 'url("' + src + '")';
    item.dataset.place = '3';
    document.getElementById('cloth' + slot).appendChild(item);
});
alt.on('addProp', (id, des, type, slot, src, ammo, mass, maxamount)=>{
    const item = createitem(id, des, type, ammo, mass, maxamount);
    item.style.backgroundImage = 'url("' + src + '")';
    item.dataset.place = '3';
    document.getElementById('pop' + slot).appendChild(item);
});
alt.on('removeHudItem', (id)=>{
    const remItem = document.getElementById('' + id);
    if (remItem.dataset.place == '0' || remItem == itemSelected) {
        if (parseInt(document.getElementById('' + id).dataset.dbid) == hasbackpack) {
            removebackpack();
        }
        document.getElementById('' + id).remove();
        return;
    }
});
alt.on('setWeight', (weight, max)=>{
    maxWeight = max;
    actuallWeight = parseFloat(weight.replace(',', '.'));
    updateWeightInfo();
});
alt.on('showView', ()=>{
    timeOut = setTimeout(showPageRemoveLaoding, 200);
});
function showPageRemoveLaoding() {
    if (timeOut != null) {
        clearTimeout(timeOut);
        timeOut = null;
    }
    document.getElementById('loading').style.visibility = 'hidden';
    document.getElementById('page').style.visibility = 'visible';
}
function showItemInfo(item) {
    let itemString = '';
    if (item.dataset.type == 1) {
        itemString = item.dataset.description;
    } else {
        itemString = item.dataset.description + ' | Gewicht: ' + item.dataset.mass + ' (' + item.dataset.ammount + '/' + item.dataset.maxamount + ')';
    }
    document.getElementById('itemName').innerHTML = itemString;
}
alt.on('updateWeigth', (w, b)=>{
    const mass = parseFloat(w.replace(',', '.'));
    const backmass = parseFloat(b.replace(',', '.'));
    actuallWeight += mass;
    backpackactuallWeight += backmass;
    updateBackWeightInfo();
    updateWeightInfo();
});
alt.on('updateWeigthOP', (w, b)=>{
    const mass = parseFloat(w.replace(',', '.'));
    const backmass = parseFloat(b.replace(',', '.'));
    otherinfactualWeight += mass;
    actuallWeight += backmass;
    if (otherinfactualWeight < 0) otherinfactualWeight = 0;
    updateOtherInfMass();
    updateWeightInfo();
});
alt.on('updateWeigthOB', (w, b)=>{
    const mass = parseFloat(w.replace(',', '.'));
    const backmass = parseFloat(b.replace(',', '.'));
    otherinfactualWeight += mass;
    backpackactuallWeight += backmass;
    updateOtherInfMass();
    updateBackWeightInfo();
});
alt.on('updateSplitItemAmount', (amount, mass)=>{
    if (splitItem == null) return;
    splitItem.dataset.ammount = '' + amount;
    const itemmass = mass * amount;
    splitItem.dataset.mass = '' + itemmass.toFixed(2);
    updateAmount(splitItem);
});
alt.on('UpdateItemAmount', (id, amount, mass)=>{
    const item = document.getElementById('' + id);
    if (!item) return;
    item.dataset.ammount = '' + amount;
    const itemmass = mass * amount;
    item.dataset.mass = '' + itemmass.toFixed(2);
    updateAmount(item);
});
alt.on('setOtherText', (text)=>{
    document.getElementById('interactionInvInfo').innerHTML = text;
    otherinfName = text;
});
alt.on('createOtherInv', (slots)=>{
    const tootherinf = document.createDocumentFragment();
    for(let i = 0; i < slots; i++){
        let newDivOther = document.createElement('div');
        newDivOther.setAttribute('class', 'invplace');
        newDivOther.setAttribute('id', 'other' + i);
        newDivOther.setAttribute('onmouseenter', 'otherenter(this)');
        newDivOther.setAttribute('data-place', '4');
        tootherinf.appendChild(newDivOther);
    }
    document.getElementById('interactionInv').appendChild(tootherinf);
});
alt.on('deleteOtherInv', ()=>{
    const otherHud = document.getElementById('interactionInv');
    while(otherHud.lastChild){
        if (otherHud.lastChild == document.getElementById('interactionInvInfo')) break;
        otherHud.removeChild(otherHud.lastChild);
    }
    document.getElementById('interactionInv').style.display = 'none';
});
document.body.addEventListener('keydown', (event)=>{
    if (event.keyCode == 27) {
        alt.emit('closeView');
        return;
    }
// do something
});
