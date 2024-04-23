function closeFirmaKonto() {
    alt.emit('closeView');
}

function HomeFB() {
    document.getElementById('mainmenu').style.display = 'block';
    document.getElementById('ueberHud').style.display = 'none';
}

function Showueberweisung() {
    document.getElementById('mainmenu').style.display = 'none';
    document.getElementById('ueberHud').style.display = 'block';
}

function ueberweisungFB(ev) {
    ev.preventDefault();
    const m = parseInt((<HTMLInputElement>document.getElementById('ueberbetrag')).value);
    const e = (<HTMLInputElement>document.getElementById('ueberid')).value;
    const r = (<HTMLInputElement>document.getElementById('ueberrs')).value;
    if (!/^[A-Za-z][A-Za-z ]-[0-9][0-9]*$/.test(e)) {
        document.getElementById('info2').innerHTML = "<font color='red'>[Warnung]</font> Falsche IBAN eingabe";
        return;
    }
    if (!/^[A-Za-z!,.? ]*$/.test(r)) {
        document.getElementById('info2').innerHTML =
            "<font color='red'>[Warnung]</font> Nicht erlaube zeichen im Grund";
        return;
    }
    alt.emit('ueberweisung', e, m, r);
}

alt.on('bankError', (err) => {
    document.getElementById('info2').innerHTML = "<font color='red'>[Warnung]</font> " + err;
});

alt.on('setText', (text, konto) => {
    const value = konto.toLocaleString().replaceAll(',', '.') + '$';
    if (konto > 0) {
        document.getElementById('info').innerHTML =
            '<b>IBAN: ' + text + "<br>Kontostand: <font color='#00ff00'><b>" + value + '</b></font>';
    } else {
        document.getElementById('info').innerHTML =
            '<b>IBAN: ' + text + "<br>Kontostand: <font color='red'><b>" + value + '</b></font>';
    }
});

alt.on('addFirmenTransfer', (money, name, reason, date) => {
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
