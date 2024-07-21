import * as alt from "alt-client";
alt.onServer('showDrive', ShowDriveLicense);
const url = `http://resource/client/DrivingLicense/drivelicense.html`;
let view = null;
function ShowDriveLicense(owner, sc, id, car, bike) {
    if (view == null) {
        view = new alt.WebView(url);
        view.on('closeView', closeView);
        view.emit("createDrive", owner, 'S' + id + 'S' + sc, car, bike);
        view.focus();
    }
}
function closeView() {
    if (view != null) {
        view.destroy();
    }
    view = null;
}
