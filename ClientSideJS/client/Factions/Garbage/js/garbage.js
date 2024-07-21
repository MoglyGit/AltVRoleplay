alt.on('isDuty', (duty)=>{
    let text = '';
    if (duty == 0) text = 'Einstemplen';
    else text = 'Ausstemplen';
    document.getElementById('buttoninfo').value = text;
});
function garbageDuty() {
    alt.emit('setGarbageDuty');
}
function closeGarbage() {
    alt.emit('closeGarbage');
}
document.body.addEventListener('keydown', (event)=>{
    if (event.keyCode == 27) {
        closeCarSell();
        return;
    }
});
