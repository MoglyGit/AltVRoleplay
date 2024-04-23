function showWorker() {
    alt.emit('showWorker');
}

function showNameChange() {
    alt.emit('showNameChange');
}

function showKasse() {
    alt.emit('showKasse');
}

function closeMechanic() {
    alt.emit('closeView');
}

alt.on('showRank', (rank: number) => {
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

alt.on('setName', (name) => {
    document.getElementById('info').innerHTML = 'Firma: ' + name;
});
