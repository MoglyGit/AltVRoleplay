alt.on('setText', (text, money) => {
    document.getElementById('info').innerHTML = text + ' zu verkaufen<br>Preis: <font color="#00ff00">' + money + '$';
});

function closeFirma() {
    alt.emit('closeView');
}

function buyFirma() {
    alt.emit('buyfirma');
}

document.body.addEventListener('keydown', (event) => {
    if (event.keyCode == 73 || event.keyCode == 27 || event.keyCode == 88) {
        alt.emit('closeView');
        return;
    }
});
