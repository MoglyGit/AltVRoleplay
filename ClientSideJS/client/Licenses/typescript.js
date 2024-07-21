import * as alt from 'alt-client';
import { Vector3 } from 'alt-shared';
import * as native from 'natives';
alt.everyTick(inCheckpoint);
alt.onServer('showDrivingInfo', ShowInfo);
alt.onServer('ExamOne', ExamOneState);
alt.onServer('Examreset', Examreset);
const url = `http://resource/client/Licenses/index.html`;
let view = null;
let cameraControlsInterval = null;
let failPos = null;
let failCheck = null;
let nexChecpointPos = null;
let checkpoint = null;
let nextState = 0;
export function ShowInfo() {
    if (view == null) {
        view = new alt.WebView(url);
        view.on('closeView', closeView);
        view.on('carTest', carTest);
        view.focus();
        alt.showCursor(true);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
    }
}
function carTest() {
    alt.emitServer('DrivingLicense', 500);
    closeView();
}
function Examreset() {
    if (failCheck != null) native.deleteCheckpoint(checkpoint);
    if (checkpoint != null) native.deleteCheckpoint(checkpoint);
    failCheck = null;
    failPos = null;
    nextState = 0;
    nexChecpointPos = null;
    checkpoint = null;
}
function inCheckpoint() {
    const player = alt.Player.local;
    if (player.vehicle == null) return;
    if (nexChecpointPos == null && failCheck == null) {
        return;
    }
    if (failPos != null) {
        const distfail = player.pos.distanceTo(failPos);
        if (distfail > 300) {
            if (failCheck != null) native.deleteCheckpoint(failCheck);
            if (checkpoint != null) native.deleteCheckpoint(checkpoint);
            nexChecpointPos = null;
            alt.emitServer('FailedDrivingAway');
            nextState = 0;
            failCheck = null;
            failPos = null;
            return;
        }
        if (distfail <= 3) {
            if (failCheck != null) native.deleteCheckpoint(failCheck);
            if (checkpoint != null) native.deleteCheckpoint(checkpoint);
            nexChecpointPos = null;
            if (nextState == -7) {
                alt.emitServer('FailedDriving');
                nextState = 0;
                failCheck = null;
                failPos = null;
                return;
            }
            FailWayOne(nextState);
        }
    }
    if (nexChecpointPos == null) return;
    const dist = player.pos.distanceTo(nexChecpointPos);
    if (dist > 300) {
        if (failCheck != null) native.deleteCheckpoint(failCheck);
        if (checkpoint != null) native.deleteCheckpoint(checkpoint);
        nexChecpointPos = null;
        alt.emitServer('FailedDrivingAway');
        nextState = 0;
        failCheck = null;
        failPos = null;
        return;
    }
    if (dist > 3 && nextState != 20) {
        return;
    } else if (dist > 2) {
        return;
    }
    if (nextState == 20) {
        if (player.vehicle.rot.z <= 2.8 && player.vehicle.rot.z >= 2.7) {
            nextState = 0;
            failPos = null;
            nexChecpointPos = null;
            if (checkpoint != null) native.deleteCheckpoint(checkpoint);
            if (failCheck != null) native.deleteCheckpoint(failCheck);
            alt.emitServer('CheckCar');
        }
        return;
    }
    if (checkpoint != null) native.deleteCheckpoint(checkpoint);
    if (failCheck != null) native.deleteCheckpoint(failCheck);
    failPos = null;
    nexChecpointPos = null;
    ExamOneState(nextState);
}
function FailWayOne(check) {
    if (check == 4) {
        failPos = new Vector3(-41.44615, 15.059341, 71.52234);
        nextState = -1;
        failCheck = setCheckpoint(failPos.x, failPos.y, failPos.z);
        return;
    }
    if (check == -1) {
        failPos = new Vector3(-25.081318, 22.562637, 71.38757);
    }
    if (check == -2) {
        failPos = new Vector3(117.05934, -40.747253, 67.107666);
    }
    if (check == -3) {
        failPos = new Vector3(61.85934, -186.03955, 54.369263);
    }
    if (check == -4) {
        failPos = new Vector3(17.09011, -267.91647, 46.989014);
    }
    if (check == -5) {
        failPos = new Vector3(-49.714287, -235.06813, 45.05127);
    }
    if (check == -6) {
        failPos = new Vector3(-45.48132, -221.77582, 44.950195);
    }
    if (check == 7) {
        failPos = new Vector3(-205.27911, 251.93407, 91.52307);
        nextState = -8;
        failCheck = setCheckpoint(failPos.x, failPos.y, failPos.z);
        return;
    }
    if (check == -8) {
        failPos = new Vector3(-69.61319, 249.36264, 101.80151);
    }
    if (check == -9) {
        failPos = new Vector3(52.087914, 239.70988, 109.08057);
    }
    if (check == -10) {
        failPos = new Vector3(192.75165, 178.6022, 105.019775);
    }
    if (check == -11) {
        failPos = new Vector3(124.52308, -9.072525, 67.17505);
    }
    if (check == -12) {
        failPos = new Vector3(117.05934, -40.747253, 67.107666);
        failCheck = setCheckpoint(failPos.x, failPos.y, failPos.z);
        nextState = -3;
        return;
    }
    failCheck = setCheckpoint(failPos.x, failPos.y, failPos.z);
    nextState--;
}
function ExamOneState(check) {
    let pos = null;
    if (check == 0) {
        if (failCheck != null) native.deleteCheckpoint(checkpoint);
        if (checkpoint != null) native.deleteCheckpoint(checkpoint);
        failCheck = null;
        failPos = null;
        nextState = 0;
        nexChecpointPos = null;
        checkpoint = null;
        pos = new Vector3(-81.534065, -229.46373, 44.09082);
    } else if (check == 1) {
        pos = new Vector3(-89.23517, -211.74066, 44.41101); //2
        alt.emitServer('SendMessage', 'Fahrlehrer: Rechtsabbiegen');
    } else if (check == 2) {
        pos = new Vector3(-83.47253, -133.75385, 57.01465); //2
    } else if (check == 3) {
        pos = new Vector3(-228.8044, -45.032967, 48.825684); //2
        failPos = new Vector3(-66.14505, -84.34286, 57.065186);
        failCheck = setCheckpoint(failPos.x, failPos.y, failPos.z);
    } else if (check == 4) {
        pos = new Vector3(-239.4989, -26.756042, 48.791992); //2
        alt.emitServer('SendMessage', 'Fahrlehrer: Rechtsabbiegen');
    } else if (check == 5) {
        pos = new Vector3(-218.09671, 105.00659, 68.92749); //2
    } else if (check == 6) {
        pos = new Vector3(-61.094505, 38.149452, 71.52234); //2
        failPos = new Vector3(-222.94945, 142.98462, 69.19702);
        failCheck = setCheckpoint(failPos.x, failPos.y, failPos.z);
    } else if (check == 7) {
        pos = new Vector3(-35.525276, 51.125275, 71.539185); //2
        alt.emitServer('SendMessage', 'Fahrlehrer: Linksabbiegen');
    } else if (check == 8) {
        pos = new Vector3(29.41978, 231.32307, 108.87842); //2
    } else if (check == 9) {
        pos = new Vector3(76.641754, 227.6967, 108.0022); //2
        alt.emitServer('SendMessage', 'Fahrlehrer: Rechtsabbiegen');
    } else if (check == 10) {
        pos = new Vector3(181.7011, 193.25275, 104.901855); //2
        alt.emitServer('SendMessage', 'Fahrlehrer: kurz halten');
    } else if (check == 11) {
        pos = new Vector3(189.6, 172.16704, 104.783936); //2
        alt.emitServer('SendMessage', 'Fahrlehrer: Rechtsabbiegen');
    } else if (check == 12) {
        pos = new Vector3(123.42857, -9.441757, 66.9729); //2
    } else if (check == 13) {
        pos = new Vector3(115.06813, -48.026375, 66.9729); //2
    } else if (check == 14) {
        pos = new Vector3(76.8923, -137.48572, 54.38611); //2
    } else if (check == 15) {
        pos = new Vector3(61.81978, -186.27692, 54.183838); //2
    } else if (check == 16) {
        pos = new Vector3(33.600002, -258.05273, 46.989014); //2
    } else if (check == 17) {
        pos = new Vector3(17.406593, -268.57584, 46.820557); //2
        alt.emitServer('SendMessage', 'Fahrlehrer: Rechtsabbiegen');
    } else if (check == 18) {
        pos = new Vector3(-49.503296, -234.46153, 44.865967); //2
        alt.emitServer('SendMessage', 'Fahrlehrer: Zurück zur Fahrschule');
    } else if (check == 19) {
        alt.emitServer('SendMessage', 'Fahrlehrer: Rückwärts einparken');
        pos = new Vector3(-56.017582, -217.27911, 44.764893); //2
        checkpoint = native.createCheckpoint(49, pos.x, pos.y, pos.z - 2, 0, 0, 0, 3, 255, 0, 0, 80, 0);
        nexChecpointPos = pos;
        nextState++;
        return;
    }
    checkpoint = setCheckpoint(pos.x, pos.y, pos.z);
    nexChecpointPos = pos;
    nextState++;
}
function setCheckpoint(x, y, z) {
    return native.createCheckpoint(49, x, y, z - 2, 0, 0, 0, 5, 255, 0, 0, 80, 0);
}
function handleControls() {
    native.hideHudAndRadarThisFrame();
    native.disableAllControlActions(0);
    //native.disableAllControlActions(1);
    native.disableControlAction(0, 0, true);
    native.disableControlAction(0, 1, true);
    native.disableControlAction(0, 2, true);
    native.disableControlAction(0, 24, true);
    native.disableControlAction(0, 25, true);
}
function closeView() {
    if (cameraControlsInterval !== undefined || cameraControlsInterval !== null) {
        alt.clearInterval(cameraControlsInterval);
        cameraControlsInterval = null;
    }
    if (view != null) {
        view.destroy();
    }
    view = null;
    alt.showCursor(false);
}
