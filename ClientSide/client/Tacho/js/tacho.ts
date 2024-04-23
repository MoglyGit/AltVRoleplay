alt.on('Speed', (speed, engineOn, rpm, gear) => {
    if (gear == 0 && speed > 0) gear = 'R';
    if (gear == 0) gear = 'N';
    document.getElementById('gear').innerHTML = '[' + gear + ']';
    const speedbar = document.getElementById('speedbar');
    let color = '#21a3009d';
    if (!engineOn) {
        rpm = 0;
        color = '#21a30000';
    }
    if (rpm >= 0.75) {
        color = '#a398009d';
    }
    if (rpm >= 0.85) {
        color = '#a300009d';
    }
    speedbar.style.backgroundColor = color;
    speedbar.style.width = 333 * rpm + 'px';
    if (speed < 10) {
        document.getElementById('speed').innerHTML = '00' + speed + ' KM/H';
        return;
    }
    if (speed < 100) {
        document.getElementById('speed').innerHTML = '0' + speed + ' KM/H';
        return;
    }
    document.getElementById('speed').innerHTML = '' + speed + ' KM/H';
});

alt.on('setNosCharges', (value) => {
    if (value == 0) {
        document.getElementById('nos').style.display = 'none';
        return;
    }
    document.getElementById('nos').style.display = 'block';
    document.getElementById('noscharges').innerHTML = '' + value + 'x';
});

alt.on('LockState', (lockstate) => {
    if (lockstate == 2) {
        document.getElementById('lock').style.display = 'block';
        return;
    }
    document.getElementById('lock').style.display = 'none';
});

alt.on('MotorState', (motor) => {
    if (motor == 1) {
        document.getElementById('motor').style.display = 'block';
        return;
    }
    document.getElementById('motor').style.display = 'none';
});

alt.on('Fill', (fill, max_tank) => {
    document.getElementById('tank').innerHTML = '' + fill + '/' + max_tank + 'L';
    const percent = (140 * (fill / max_tank)).toFixed();
    const p = parseInt(percent);
    let color = '#00b618';
    let warning = 'none';
    if (p > 20 && p < 50) {
        color = '#b69500';
    }
    if (p <= 20) {
        color = '#b60600';
        warning = 'blocK';
    }
    if (p <= 0) {
        warning = 'blocK';
        color = '#000000be';
    }
    document.getElementById('fillwarning').style.display = warning;
    const bar = document.getElementById('fillbar');
    bar.style.backgroundColor = color;
    bar.style.width = percent + 'px';
});

alt.on('Range', (range) => {
    const showrange = '' + Math.floor(range / 1000);
    const fill = 6 - showrange.toString().length;
    if (fill < 0) {
        //kaput
        return;
    }
    let nullString = '';
    for (let i = 0; i < fill; i++) {
        nullString += '0';
    }
    document.getElementById('range').innerHTML = nullString + showrange + 'km';
});
