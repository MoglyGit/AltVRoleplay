function closeFirmenNameChangeHud() {
    alt.emit('closeView');
}
function changeFirmenName(ev) {
    ev.preventDefault();
    const name = document.getElementById('firmenName').value;
    if (!/^[A-Za-z!,./|? 0-9]*$/.test(name)) {
        document.getElementById('info').innerHTML = "<font color='red'>[Warnung]</font> Nicht erlaubte zeichen im Namen";
        return;
    }
    alt.emit('changeName', name);
}
