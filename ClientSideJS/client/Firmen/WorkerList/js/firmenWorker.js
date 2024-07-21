let actuallWorker = null;
function changeGehalt(ev) {
    ev.preventDefault();
    if (actuallWorker == null) return;
    const gehalt = parseInt(document.getElementById('newgehalt').value);
    if (gehalt <= 0) return;
    alt.emit('changegehalt', parseInt(actuallWorker.dataset.scid), gehalt);
    actuallWorker.innerHTML = 'Name: ' + actuallWorker.dataset.name + '<br>Rang: ' + getFrimenRankNames(actuallWorker.dataset.rank) + '<br>Gehalt: ' + gehalt;
}
function showChangegehalt() {
    if (actuallWorker == null) return;
    document.getElementById('workerInfo').style.display = 'none';
    document.getElementById('workerGehalt').style.display = 'block';
}
function changeRank(rank) {
    if (actuallWorker == null) return;
    alt.emit('changeRank', parseInt(actuallWorker.dataset.scid), rank);
    actuallWorker.innerHTML = 'Name: ' + actuallWorker.dataset.name + '<br>Rang: ' + getFrimenRankNames(rank) + '<br>Gehalt: ' + actuallWorker.dataset.gehalt;
}
function showChangerank() {
    if (actuallWorker == null) return;
    document.getElementById('workerInfo').style.display = 'none';
    document.getElementById('workerRank').style.display = 'block';
}
function showWorkerInfo() {
    if (actuallWorker == null) {
        HomeWorkerHud();
        return;
    }
    document.getElementById('workerInfo').style.display = 'block';
    document.getElementById('workerGehalt').style.display = 'none';
    document.getElementById('workerRank').style.display = 'none';
}
function closeWorkerHud() {
    alt.emit('closeView');
}
function HomeWorkerHud() {
    document.getElementById('mainmenu').style.display = 'block';
    document.getElementById('workerGehalt').style.display = 'none';
    document.getElementById('workerRank').style.display = 'none';
    document.getElementById('workerInfo').style.display = 'none';
}
function showWorkerInteract(worker) {
    actuallWorker = worker;
    document.getElementById('infoWorker').innerHTML = 'Mitarbeiter: ' + worker.dataset.name;
    document.getElementById('mainmenu').style.display = 'none';
    document.getElementById('workerInfo').style.display = 'block';
}
function getFrimenRankNames(rank) {
    if (rank == 1) return 'Arbeiter';
    if (rank == 2) return 'Manager';
    if (rank == 3) return 'Besitzer';
    return 'Praktikant';
}
alt.on('showWorkerInfo', ()=>{
    showWorkerInfo();
});
alt.on('addHudWorker', (scid, name, gehalt, rank)=>{
    const newLi = document.createElement('li');
    newLi.innerHTML = 'Name: ' + name + '<br>Rang: ' + getFrimenRankNames(rank) + '<br>Gehalt: ' + gehalt;
    newLi.dataset.scid = '' + scid;
    newLi.dataset.name = '' + name;
    newLi.dataset.rank = '' + rank;
    newLi.dataset.gehalt = '' + gehalt;
    newLi.setAttribute('onclick', 'showWorkerInteract(this)');
    newLi.setAttribute('class', 'button2');
    newLi.style.backgroundColor = 'rgb(0, 113, 148)';
    document.getElementById('worker').appendChild(newLi);
});
