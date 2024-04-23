alt.on('toPay', (money) => {
    document.getElementById('info').innerHTML = 'Mitarbeiter:\nDas macht dann: <font color="#00ff00">' + money + '$';
});

function payGas() {
    alt.emit('payGas');
}

function closeGas() {
    alt.emit('closeView');
}
document.body.addEventListener('keydown', (event) => {
    if (event.keyCode == 27) {
        closeGas();
        return;
    }
});
