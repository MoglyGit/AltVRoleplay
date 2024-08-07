function LockVehicle() {
    if (document.getElementById('lock').value.includes('Ab')) document.getElementById('lock').value = 'Aufschließen';
    else document.getElementById('lock').value = 'Abschließen';
    alt.emit('lockVehicle');
}
function ChangeSingalLight() {
    alt.emit('ChangeSireneMuted');
    if (document.getElementById('sirenlight').value.includes('deaktivieren')) document.getElementById('sirenlight').value = 'Sirene aktivieren';
    else document.getElementById('sirenlight').value = 'Sirene deaktivieren';
}
function Home() {
    document.getElementById('vehicleInfoBox').style.display = 'none';
    document.getElementById('menu').style.display = 'block';
}
function ShowNumberPlate() {
    alt.emit('ShowNumberPlate');
}
function ShowTrunk() {
    alt.emit('ShowTrunk');
}
function ExitVehicleMenu() {
    alt.emit('closeView');
}
function ToggleFront() {
    alt.emit('toggleFront');
}
function ToggleTrunk() {
    alt.emit('toggleTrunk');
}
function Tunen() {
    alt.emit('tuneVehicle');
}
function ToggleAnker() {
    alt.emit('toggleAnker');
}
function Repair() {
    alt.emit('repairVehicle');
}
function Tuev() {
    alt.emit('tuevVehicle');
}
function ChangeLock() {
    alt.emit('changeLockVehicle');
}
function ToggleGurt() {
    alt.emit('ToggleGurt');
    if (document.getElementById('useGurt').value.includes('An')) document.getElementById('useGurt').value = 'Abschnallen';
    else document.getElementById('useGurt').value = 'Angeschnallt';
}
function ToggleEngine() {
    if (document.getElementById('engine').value.includes('aus')) document.getElementById('engine').value = 'Motor an';
    else document.getElementById('engine').value = 'Motor aus';
    alt.emit('ToggleEngine');
}
function ShowinVehicleMenuDriver(canUse) {
    if (canUse) {
        document.getElementById('opentrunk').style.display = 'block';
        document.getElementById('openfront').style.display = 'block';
        document.getElementById('handschuh').style.display = 'block';
    }
}
function ShowinVehicleMenuCoDriver(canUse) {
    if (canUse) document.getElementById('handschuh').style.display = 'block';
}
function OpenHandschuh() {
    alt.emit('OpenHandschuh');
}
function DoShortSiren() {
    alt.emit('DoShortSiren');
    if (document.getElementById('shortSiren').value.includes('deaktivieren')) document.getElementById('shortSiren').value = 'Kurze Sirene aktivieren';
    else document.getElementById('shortSiren').value = 'Kurze Sirene deaktivieren';
}
alt.on('ShowSirenToggle', (has, hasShort)=>{
    document.getElementById('sirenlight').style.display = 'block';
    document.getElementById('shortSiren').style.display = 'block';
    if (has) document.getElementById('sirenlight').value = 'Sirene aktivieren';
    else document.getElementById('sirenlight').value = 'Sirene deaktivieren';
    if (hasShort) document.getElementById('shortSiren').value = 'Kurze Sirene deaktivieren';
    else document.getElementById('shortSiren').value = 'Kurze Sirene aktivieren';
});
alt.on('setNumberplateInfo', (tuev, numberPlate, name)=>{
    document.getElementById('vehNumberInfo').innerHTML = 'Kennzeichen: ' + numberPlate;
    document.getElementById('vehModelname').innerHTML = 'Fahrzeug: ' + name;
    document.getElementById('vehTuev').innerHTML = 'Tuev: ' + tuev;
    document.getElementById('menu').style.display = 'none';
    document.getElementById('vehicleInfoBox').style.display = 'block';
});
alt.on('ShowinVehicleMenuDriver', (canUse)=>{
    ShowinVehicleMenuDriver(canUse);
});
alt.on('ShowinVehicleMenuCoDriver', (canUse)=>{
    ShowinVehicleMenuCoDriver(canUse);
});
alt.on('showGurt', (state)=>{
    document.getElementById('useGurt').style.display = 'block';
    if (state == true || state == null) document.getElementById('useGurt').value = 'Anschnallen';
    else document.getElementById('useGurt').value = 'Abschnallen';
});
alt.on('ShowLockMenu', (locked)=>{
    document.getElementById('lock').style.display = 'block';
    if (locked) document.getElementById('lock').value = 'Aufschließen';
    else document.getElementById('lock').value = 'Abschließen';
});
alt.on('ShowUseTrunk', ()=>{
    document.getElementById('trunk').style.display = 'block';
    document.getElementById('numberplate').style.display = 'block';
});
alt.on('ShowEngine', (engineOn)=>{
    document.getElementById('engine').style.display = 'block';
    if (engineOn) document.getElementById('engine').value = 'Motor aus';
    else document.getElementById('engine').value = 'Motor an';
});
alt.on('showMechanic', ()=>{
    document.getElementById('mechanic0').style.display = 'block';
    document.getElementById('mechanic1').style.display = 'block';
    document.getElementById('mechanic2').style.display = 'block';
});
alt.on('showTuner', ()=>{
    document.getElementById('tuning0').style.display = 'block';
});
alt.on('showAnker', ()=>{
    document.getElementById('useAnker').style.display = 'block';
});
