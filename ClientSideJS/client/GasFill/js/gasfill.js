let inFill = false;
let fuel = 0;
let actprice = 0;
let fillType = -1;
let fillPrice = [];
let maxAddingFuel = 0;
alt.on('setInfos', (maxAdd, price)=>{
    document.getElementById('f0').value = 'Benzin (' + price[0] + '$)';
    document.getElementById('f1').value = 'Diesel (' + price[1] + '$)';
    document.getElementById('f2').value = 'Petrol (' + price[2] + '$)';
    document.getElementById('f3').value = 'Elektro (' + price[3] + '$)';
    fillPrice = price;
    maxAddingFuel = maxAdd;
});
function useFillType(type) {
    alt.emit('useGasType', type);
    document.getElementById('hud').style.display = 'none';
    document.getElementById('fill').style.display = 'block';
    fillType = type;
    inFill = true;
}
function setFillPrice(price, fill) {
    document.getElementById('fillinfo').innerHTML = 'Liter: ' + fill.toFixed(2) + '<br>Preis: ' + price;
}
function endFillGas() {
    alt.emit('endFill', actprice, fuel);
}
function closeFillGas() {
    alt.emit('closeView');
}
document.body.addEventListener('keydown', (event)=>{
    if (event.keyCode == 13 && inFill) {
        if (maxAddingFuel <= fuel) return;
        fuel += 0.1;
        if (fillPrice[fillType] >= 10) {
            actprice += parseFloat((fillPrice[fillType] / 10).toFixed(2));
        } else {
            if (parseFloat((fuel * 100).toFixed(2)) % 100 == 0) actprice += fillPrice[fillType];
        }
        setFillPrice(actprice, fuel);
        return;
    }
});
