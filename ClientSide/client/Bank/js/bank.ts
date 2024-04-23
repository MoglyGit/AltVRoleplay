let na = null;
let mon: number = 0;
let iban = '';
let noAtm = 0;
const audio = new Audio('sound/money-counter.mp3');
const audioerror = new Audio('sound/error.mp3');
const audiobutton = new Audio('sound/button.mp3');
alt.on('hasKonto', (name, money: number, iba: string, atm: number) => {
    document.getElementById('KontoEvents').style.display = 'block';
    document.getElementById('kontocreate').style.display = 'none';
    document.getElementById('backHome').style.display = 'none';
    document.getElementById('einaus').style.display = 'none';
    na = name;
    mon = money;
    iban = iba;
    noAtm = atm;
    if (atm == 0) document.getElementById('kredit').style.display = 'block';
    document.getElementById('info').setAttribute('class', 'center');
    konto();
});

alt.on('new', () => {
    document.getElementById('info').innerHTML =
        'Guten Tag, wie ich sehe haben Sie noch kein Konto bei uns. Möchten Sie ein Konto bei uns eröffnen?<br> Unser <b>Angebot</b>:<br>Zinsen: 1.5%(Jeden Payday gratis Geschenkt)<br>Willkommends Bonus: 500$<br>Kredit bis: 5000$<br>Kredit Zinssatz: 20%<br>ATM Extrakosten: 10%(Anfallende Kosten bei ATM nutzung)<br>';
});

alt.on('createBankTransfer', (money, name, reason, date) => {
    const newLi = document.createElement('li');
    const value = money.toLocaleString().replaceAll(',', '.') + '$';
    let n = 'Von ' + name;
    if (money < 0) {
        newLi.style.backgroundColor = 'rgb(185, 0, 0)';
        n = 'An ' + name;
    }
    newLi.innerHTML = '' + value + '<br>' + n + '<br>Datum: ' + date + '<br>Grund: ' + reason;
    document.getElementById('auszug').appendChild(newLi);
});

alt.on('bankError', (err) => {
    if (noAtm == 1) audioerror.play();
    document.getElementById('info').innerHTML = "<font color='red'>[Warnung]</font> " + err;
});
alt.on('updateBank', (money) => {
    mon = money;
    audio.play();
});
alt.on('updateBank2', (money) => {
    mon = money;
    showHome();
});
alt.on('ButtonSoundWrong', () => {
    audio.play();
});

function ueberweisung(ev) {
    ev.preventDefault();
    const m = parseInt((<HTMLInputElement>document.getElementById('ueberbetrag')).value);
    const e = (<HTMLInputElement>document.getElementById('ueberid')).value;
    const r = (<HTMLInputElement>document.getElementById('ueberrs')).value;
    if (!/^[A-Za-z][A-Za-z ]-[0-9][0-9]*$/.test(e)) {
        audioerror.play();
        document.getElementById('info').innerHTML = "<font color='red'>[Warnung]</font> Falsche IBAN eingabe";
        return;
    }
    if (!/^[A-Za-z!,.? ]*$/.test(r)) {
        audioerror.play();
        document.getElementById('info').innerHTML = "<font color='red'>[Warnung]</font> Nicht erlaube zeichen im Grund";
        return;
    }
    alt.emit('ueberweisung', e, m, r);
}

function giveKredit(money) {
    console.log(money);
    alt.emit('giveKredit', money);
}

function showKredit() {
    document.getElementById('KontoEvents').style.display = 'none';
    document.getElementById('kontocreate').style.display = 'none';
    document.getElementById('backHome').style.display = 'block';
    document.getElementById('auszug').style.display = 'none';
    document.getElementById('einaus').style.display = 'none';
    document.getElementById('ueberHud').style.display = 'none';
    document.getElementById('kreditHud').style.display = 'block';
    document.getElementById('info').innerHTML = 'Am Payday werden 10% vom kredit zurückgezahlt';
    if (noAtm == 1) audiobutton.play();
}

function showUeber() {
    document.getElementById('KontoEvents').style.display = 'none';
    document.getElementById('kontocreate').style.display = 'none';
    document.getElementById('backHome').style.display = 'block';
    document.getElementById('auszug').style.display = 'none';
    document.getElementById('einaus').style.display = 'none';
    document.getElementById('ueberHud').style.display = 'block';
    document.getElementById('kreditHud').style.display = 'none';
    document.getElementById('info').innerHTML = 'Empfänger IBAN:';
    if (noAtm == 1) audiobutton.play();
}

function konto() {
    const value = mon.toLocaleString().replaceAll(',', '.') + '$';
    if (mon > 0) {
        document.getElementById('info').innerHTML =
            'Willkommen ' +
            na +
            '<br>IBAN: ' +
            iban +
            "<br>Kontostand: <font color='#00ff00'><b>" +
            value +
            '</b></font>';
    } else {
        document.getElementById('info').innerHTML =
            'Willkommen ' + na + '<br>IBAN: ' + iban + "<br>Kontostand: <font color='red'><b>" + value + '</b></font>';
    }
}

function einzahlen() {
    const money = parseInt((<HTMLInputElement>document.getElementById('betrag')).value);
    if (money > 0) {
        alt.emit('einzahlen', money);
    }
    if (noAtm == 1) audiobutton.play();
}
function auszahlen() {
    const money = parseInt((<HTMLInputElement>document.getElementById('betrag')).value);
    if (money > 0) {
        alt.emit('auszahlen', money, noAtm);
    }
    if (noAtm == 1) audiobutton.play();
}

function showinOut() {
    document.getElementById('KontoEvents').style.display = 'none';
    document.getElementById('kontocreate').style.display = 'none';
    document.getElementById('backHome').style.display = 'block';
    document.getElementById('auszug').style.display = 'none';
    document.getElementById('einaus').style.display = 'block';
    document.getElementById('kreditHud').style.display = 'none';
    document.getElementById('info').innerHTML = '';
    if (noAtm == 1) audiobutton.play();
}

function showHome() {
    document.getElementById('KontoEvents').style.display = 'block';
    document.getElementById('kontocreate').style.display = 'none';
    document.getElementById('backHome').style.display = 'none';
    document.getElementById('auszug').style.display = 'none';
    document.getElementById('einaus').style.display = 'none';
    document.getElementById('kreditHud').style.display = 'none';
    document.getElementById('ueberHud').style.display = 'none';
    konto();
    if (noAtm == 1) audiobutton.play();
}

function showAuszug() {
    document.getElementById('auszug').innerHTML = '';
    document.getElementById('kontocreate').style.display = 'none';
    document.getElementById('KontoEvents').style.display = 'none';
    document.getElementById('auszug').style.display = 'block';
    document.getElementById('info').innerHTML = '<b>Kontoauszüge</b>';
    document.getElementById('backHome').style.display = 'block';
    alt.emit('BankAccountInfoFleeca');
    if (noAtm == 1) audiobutton.play();
}

function closeView() {
    if (noAtm == 1) audiobutton.play();
    alt.emit('closeView');
}
function createBank() {
    alt.emit('createBank');
}

document.body.addEventListener('keydown', (event) => {
    if (event.keyCode == 27) {
        alt.emit('closeView');
        return;
    }
});
