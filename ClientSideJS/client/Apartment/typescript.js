import * as alt from 'alt-client';
import * as native from 'natives';
const url = `http://resource/client/Apartment/Apartment.html`;
let view = null;
let cameraControlsInterval = null;
alt.onServer('ShowApartment', ShowApartment);
alt.onServer('clsoeApartmentView', closeView);
alt.onServer('ApartmentInfo', ApartmentInfo);
alt.onServer('ShowGarbage', AddGarbageButton);
function AddGarbageButton() {
    if (view != null) view.emit('addGarbage');
}
function ShowApartment(state, haskey, id, rent = 0) {
    if (view == null) {
        view = new alt.WebView(url);
        view.emit('ShowApartmentHud', state, haskey, id, rent);
        view.on('closeApartmentView', closeView);
        view.on('tryRentApartment', tryRentApartment);
        view.on('tryEnterApartment', tryEnterApartment);
        view.on('tryLeaveApartment', tryLeaveApartment);
        view.on('ringByApartment', ringByApartment);
        view.on('unrentApartment', unrentApartment);
        view.on('tryLockingApartment', tryLockingApartment);
        view.on('takeGarbage', takeGarbage);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        showCursor(true);
    }
}
function takeGarbage(id) {
    alt.emitServer('tryTakeGarbage', id);
}
function tryLockingApartment(id) {
    alt.emitServer('tryLockingApartment', id);
}
function unrentApartment(id) {
    alt.emitServer('unrentApartment', id);
}
function ringByApartment(id) {
    alt.emitServer('ringByApartment', id);
}
function ApartmentInfo(string) {
    if (view != null) view.emit('ApartmentInfo', string);
}
function tryLeaveApartment(id) {
    alt.emitServer('tryLeaveApartment', id);
}
function tryEnterApartment(id) {
    alt.emitServer('tryEnterApartment', id);
}
function tryRentApartment(id) {
    alt.emitServer('tryRentApartment', id);
}
function handleControls() {
    native.disableAllControlActions(0);
    //native.disableAllControlActions(1);
    native.disableControlAction(0, 0, true);
    native.disableControlAction(0, 1, true);
    native.disableControlAction(0, 2, true);
    native.disableControlAction(0, 24, true);
    native.disableControlAction(0, 25, true);
}
function showCursor(state) {
    try {
        alt.showCursor(state);
    } catch (err) {
        return;
    }
}
function closeView() {
    if (cameraControlsInterval !== undefined || cameraControlsInterval !== null) {
        alt.clearInterval(cameraControlsInterval);
        cameraControlsInterval = null;
    }
    if (view && view.destroy) {
        view.destroy();
    }
    view = null;
    showCursor(false);
}
