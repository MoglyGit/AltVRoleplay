const doorLockAuido = new Audio('sound/doorlock.mp3');
const doorUnLockAuido = new Audio('sound/doorunlock.mp3');
const doorBell = new Audio('sound/doorbell.mp3');
const zipper = new Audio('sound/zipper.mp3');
const pickaxe = new Audio('sound/pickaxe.mp3');
const nos = new Audio('sound/nos.mp3');

alt.on('Sound', (sound) => {
    switch (sound) {
        case 'DoorLockSound':
            doorLockAuido.volume = 0.4;
            doorLockAuido.play();
            break;
        case 'DoorUnLockSound':
            doorUnLockAuido.volume = 0.4;
            doorUnLockAuido.play();
            break;
        case 'DoorBell':
            doorBell.volume = 0.4;
            doorBell.play();
            break;
        case 'Zipper':
            zipper.volume = 0.4;
            zipper.play();
            break;
        case 'PickAxeHit':
            pickaxe.volume = 0.4;
            pickaxe.play();
            break;
        case 'Nos':
            nos.volume = 0.2;
            nos.play();
            break;
    }
});

alt.on('setTime', (h, m, s, w) => {
    if (!w) {
        document.getElementById('time').style.display = 'none';
        return;
    }
    document.getElementById('time').style.display = 'block';
    if (s < 10) s = '0' + s;
    if (m < 10) m = '0' + m;
    if (h < 10) h = '0' + h;
    document.getElementById('time').innerHTML = '' + h + ':' + m + ':' + s;
});

alt.on('syncMoney', (money, lastmoney) => {
    let hud = document.getElementById('mset');
    if (money >= 0) hud.style.color = '#00cc00';
    else hud.style.color = '#ff0000';
    let abzug = 0;
    abzug = money - lastmoney;
    document.getElementById('abzug').innerHTML = '';
    document.getElementById('mset').innerHTML = money.toLocaleString().replaceAll(',', '.') + '$';
    if (abzug < 0) {
        document.getElementById('abzug').style.color = '#ff0000';
        document.getElementById('abzug').innerHTML = ' ' + abzug + '$';
    } else if (abzug > 0) {
        document.getElementById('abzug').style.color = '#00cc00';
        document.getElementById('abzug').innerHTML = ' +' + abzug + '$';
    }
});

alt.on('syncPayday', (payday) => {
    const paydaytimer = document.getElementById('paydaytimer');
    paydaytimer.style.display = document.getElementById('time').style.display;
    paydaytimer.innerHTML = 'PayDay: ' + payday + '/60';
});

alt.on('syncThirst', (thirstpercent) => {
    const thirst = document.getElementById('durst');
    thirst.innerHTML = thirstpercent + '%';
});

alt.on('syncHunger', (thirstpercent) => {
    const thirst = document.getElementById('hunger');
    thirst.innerHTML = thirstpercent + '%';
});
alt.on('syncHarn', (thirstpercent) => {
    const thirst = document.getElementById('harn');
    thirst.innerHTML = thirstpercent + '%';
});
alt.on('syncHappy', (thirstpercent) => {
    const thirst = document.getElementById('happy');
    thirst.innerHTML = thirstpercent + '%';
});
