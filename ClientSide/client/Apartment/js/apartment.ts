let apartment_id = -1;
alt.on('addGarbage', () => {
    document.getElementById('garbage').style.display = 'block';
});

alt.on('ShowApartmentHud', (state, haskey, id, rent) => {
    apartment_id = id;
    if (state == 0) {
        document.getElementById('ApartmentRent').style.display = 'block';
        document.getElementById('img1').style.display = 'block';
        document.getElementById('info').innerHTML = "Mindest Vertragslaufzeit: 3 Payday's\nMiete: " + rent;
    } else if (state == 1) {
        document.getElementById('ApartmentOwned').style.display = 'block';
        if (haskey) {
            document.getElementById('lock').style.display = 'block';
        }
    } else if (state == 2) {
        document.getElementById('ApartmentOwner').style.display = 'block';
        if (haskey) {
            document.getElementById('lock2').style.display = 'block';
        }
    } else if (state == 3) {
        document.getElementById('ApartmentOut').style.display = 'block';
        if (haskey) {
            document.getElementById('lock3').style.display = 'block';
        }
    }
});

alt.on('ApartmentInfo', (string) => {
    document.getElementById('info').innerHTML = '' + string;
});
function getGarbage() {
    alt.emit('takeGarbage', apartment_id);
}

function tryLockingApartment() {
    alt.emit('tryLockingApartment', apartment_id);
}
function unrentApartment() {
    alt.emit('unrentApartment', apartment_id);
}

function ringByApartment() {
    alt.emit('ringByApartment', apartment_id);
}

function tryLeaveApartment() {
    alt.emit('tryLeaveApartment', apartment_id);
}

function tryEnterApartment() {
    alt.emit('tryEnterApartment', apartment_id);
}

function tryRentApartment() {
    alt.emit('tryRentApartment', apartment_id);
}

function closeApartmentView() {
    alt.emit('closeApartmentView');
}
document.body.addEventListener('keydown', (event) => {
    if (event.keyCode == 27) {
        alt.emit('closeApartmentView');
        return;
    }
});
