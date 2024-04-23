alt.on('addShopItem', (i, product, price) => {
    (<HTMLInputElement>document.getElementById('' + i)).value = product + ' (' + price + '$)';
    document.getElementById('' + i).style.visibility = 'visible';
});

function buy(i: number) {
    alt.emit('buyItem', i);
}

function closeViewShopItemsPlayer() {
    alt.emit('closeView');
}

document.body.addEventListener('keydown', (event) => {
    if (event.keyCode == 73 || event.keyCode == 27 || event.keyCode == 88) {
        alt.emit('closeView');
        return;
    }
});
