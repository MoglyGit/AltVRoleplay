function closeCarDealerMenu() {
    alt.emit('closeView');
}
function getContracts() {
    alt.emit('getServerContracts');
}
function ShowMenuCarDealer(state) {
    if (state == 0) {
        document.getElementById('menu').style.visibility = 'visible';
        document.getElementById('menu').style.display = 'block';
        document.getElementById('contractsMenu').style.visibility = 'hidden';
        document.getElementById('contractsMenu').style.display = 'none';
        document.getElementById('showAuszug').style.display = 'none';
    }
    if (state == 1) {
        document.getElementById('menu').style.visibility = 'hidden';
        document.getElementById('menu').style.display = 'none';
        document.getElementById('contractsMenu').style.visibility = 'visible';
        document.getElementById('contractsMenu').style.display = 'block';
        document.getElementById('showAuszug').style.display = 'none';
    }
}
function showWorker() {
    alt.emit('showWorker');
}
function showNameChange() {
    alt.emit('showNameChange');
}
function showKasse() {
    alt.emit('showKasse');
}
function getCarDealer() {
    alt.emit('getCarDealer');
}
alt.on('showRank', (rank)=>{
    if (rank >= 3) {
        document.getElementById('nameChange').style.display = 'block';
        document.getElementById('workerList').style.display = 'block';
    }
    if (rank >= 2) {
        document.getElementById('finance').style.display = 'block';
    }
    if (rank >= 1) {
        document.getElementById('contractCreate').style.display = 'block';
    }
});
alt.on('setName', (name)=>{
    document.getElementById('info').innerHTML = 'Firma: ' + name;
});
alt.on('ShowMenu', (state)=>{
    ShowMenuCarDealer(state);
});
alt.on('createCarContract', (model, delivery, rdy, orderby)=>{
    const newLi = document.createElement('li');
    newLi.setAttribute('class', 'center button2');
    newLi.innerHTML = 'Fahrzeug: ' + model + '<br> Ankunft: ' + delivery + '<br>Besteller: ' + orderby;
    if (!rdy) {
        newLi.setAttribute('style', 'background-color: rgb(185, 0, 0)');
    }
    document.getElementById('contracts').appendChild(newLi);
});
document.body.addEventListener('keydown', (event)=>{
    if (event.keyCode == 27) {
        alt.emit('closeView');
        return;
    }
});
