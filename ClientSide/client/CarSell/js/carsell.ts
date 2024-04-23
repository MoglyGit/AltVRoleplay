alt.on('MoneyForCar', (money) => {
    document.getElementById('info').innerHTML =
        'Vertrauenswürdige Person:\nFür das Fahrzeug gebe ich dir: <font color="#00ff00">' + money + '$';
});

function sellCar() {
    alt.emit('sellCar');
}

function closeCarSell() {
    alt.emit('closeCarSell');
}
document.body.addEventListener('keydown', (event) => {
    if (event.keyCode == 27) {
        closeCarSell();
        return;
    }
});
