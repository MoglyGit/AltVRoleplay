function sellItems(i) {
    alt.emit('sellDealerItems', i);
}
function closeViewDealer() {
    alt.emit('closeView');
}
document.body.addEventListener('keydown', (event)=>{
    if (event.keyCode == 73 || event.keyCode == 27 || event.keyCode == 88) {
        alt.emit('closeView');
        return;
    }
});
