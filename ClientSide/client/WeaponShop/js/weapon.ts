alt.on('weaponError', (err) => {
    document.getElementById('info').innerHTML = '' + err;
});

function giveWeapon(weaponid, price) {
    alt.emit('giveWeapon', weaponid, price);
}

function giveMuni(muniid, price) {
    alt.emit('giveMuni', muniid, price);
}

function closeViewW() {
    alt.emit('closeView');
}

document.body.addEventListener('keydown', (event) => {
    if (event.keyCode == 27) {
        alt.emit('closeView');
        return;
    }
});
