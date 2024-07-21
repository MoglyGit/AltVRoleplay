function selectOnlyThis(id, number) {
    for(var i = 1; i <= 3; i++){
        document.getElementById(number + 'Check' + i).checked = false;
    }
    document.getElementById(id).checked = true;
}
alt.on('setText', (text, money, eat, product)=>{
    document.getElementById('info').innerHTML = text + ' Menü<br>Nahrungs Produkte: ' + eat + '<br>Sonstige Produkte: ' + product + '<br>Business Konto: <font color="#00ff00">' + money + '$';
});
function changeSellItem(ev, number) {
    ev.preventDefault();
    const price = parseInt(document.getElementById(number + 'SellPrice').value);
    if (price < 0 || price > 10000) {
        document.getElementById(number + 'SellInfoitem').innerHTML = "<font color='red'>[Warnung]</font> Preis nicht akzeptiert";
        return;
    }
    let item = null;
    for(var i = 1; i <= 4; i++){
        if (!document.getElementById(number + 'Check' + i)) continue;
        if (document.getElementById(number + 'Check' + i).checked) {
            item = document.getElementById(number + 'Check' + i).value;
        }
    }
    if (item == null) {
        document.getElementById(number + 'SellInfoitem').innerHTML = "<font color='red'>[Warnung]</font> Kein Produkt ausgewählt";
        return;
    }
    alt.emit('changeProduct', number, price, item);
    if (number == 5) {
        closeViewStore();
        return;
    }
    document.getElementById('products' + number).style.display = 'none';
    document.getElementById('products' + (number + 1)).style.display = 'block';
}
function showChangePro() {
    document.getElementById('Menu').style.display = 'none';
    document.getElementById('products0').style.display = 'block';
}
function showChange() {
    document.getElementById('Menu').style.display = 'none';
    document.getElementById('namemenu').style.display = 'block';
}
function changeName(ev) {
    ev.preventDefault();
    const name = document.getElementById('name').value;
    if (!/^[A-Za-z0-9/ ]*$/.test(name) || name.length > 10 || name.trim().length <= 2) {
        document.getElementById('infoinput').innerHTML = "<font color='red'>[Warnung]</font> Name nicht akzeptiert";
        return;
    }
    alt.emit('changeShopName', name);
}
function closeViewStore() {
    alt.emit('closeView');
}
document.body.addEventListener('keydown', (event)=>{
    if (event.keyCode == 27) {
        alt.emit('closeView');
        return;
    }
});
