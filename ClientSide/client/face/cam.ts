import * as alt from 'alt-client';
import * as native from 'natives';
import * as editor from './editor';

let cameraControlsInterval;
let camera;
let gzoom = 0.1;
let gzoomy = 0;
let zpos = 0;
let fov = 90;
let startPosition;
let startCamPosition;
let timeBetweenAnimChecks = Date.now() + 100;
let freezekey = false;

export function setKeyFreeze(a:boolean)
{
    freezekey = a;
}

export function createPedEditCamera(cloneId:number, zoom: number, x1:number, y1:number, z1:number) {
    startPosition = { x: x1, y: y1, z: z1 };
    if (!camera) {
        const forwardVector = native.getEntityForwardVector(cloneId);
        const forwardCameraPosition = {
            x: startPosition.x + forwardVector.x * zoom,
            y: startPosition.y + forwardVector.y * zoom,
            z: startPosition.z + zpos
        };

        fov = 90;
        startCamPosition = forwardCameraPosition;

        camera = native.createCamWithParams(
            'DEFAULT_SCRIPTED_CAMERA',
            forwardCameraPosition.x,
            forwardCameraPosition.y,
            forwardCameraPosition.z,
            0,
            0,
            0,
            fov,
            true,
            0
        );
        native.pointCamAtCoord(camera, startPosition.x, startPosition.y, startPosition.z);
        native.setCamActive(camera, true);
        native.renderScriptCams(true, false, 0, true, false, 1);
    }

    cameraControlsInterval = alt.setInterval(handleControls, 0);
}

export function destroyPedEditCamera() {
    if (cameraControlsInterval !== undefined || cameraControlsInterval !== null) {
        alt.clearInterval(cameraControlsInterval);
        cameraControlsInterval = null;
    }

    if (camera) {
        camera = null;
    }

    native.destroyAllCams(true);
    native.renderScriptCams(false, false, 0, false, false, 1);

    zpos = 0;
    fov = 90;
    startPosition = null;
    startCamPosition = null;
}

function handleControls() {
    native.hideHudAndRadarThisFrame();
    native.disableAllControlActions(0);
    native.disableAllControlActions(1);
    native.disableControlAction(0, 0, true);
    native.disableControlAction(0, 1, true);
    native.disableControlAction(0, 2, true);
    native.disableControlAction(0, 24, true);
    native.disableControlAction(0, 25, true);
    native.disableControlAction(0, 32, true); // w
    native.disableControlAction(0, 33, true); // s
    native.disableControlAction(0, 34, true); // a
    native.disableControlAction(0, 35, true); // d
    native.disableControlAction(0, 38, true); // e
    native.disableControlAction(0, 44, true); // q

    const [_, width] = native.getScreenResolution(0, 0);
    const cursor = alt.getCursorPos();
    const _x = cursor.x;
    let oldHeading = native.getEntityHeading(editor.cloneId);

    if(freezekey)return;

    // e
    if (native.isDisabledControlPressed(0, 38)) {
        if(gzoomy < -0.7)return;
        gzoomy -= 0.01;

        setcam();
    }

    // q
    if (native.isDisabledControlPressed(0, 44)) {
        if(gzoomy > 0.65)return;
        gzoomy += 0.01;
        setcam();
    }

    if (native.isDisabledControlPressed(0, 32)) { // w
        zpos += 0.01;

        if (zpos > 0.8) {
            zpos = 0.8;
        }

        setcam();
    }

    if (native.isDisabledControlPressed(0, 33)) { //s
        zpos -= 0.01;

        if (zpos < -0.6) {
            zpos = -0.6;
        }

        setcam();
    }

    // d
    if (native.isDisabledControlPressed(0, 35)) {
        const newHeading = (oldHeading += 2);
        native.setEntityHeading(editor.cloneId, newHeading);
    }

    // a
    if (native.isDisabledControlPressed(0, 34)) {
        const newHeading = (oldHeading -= 2);
        native.setEntityHeading(editor.cloneId, newHeading);
    }

    if (Date.now() > timeBetweenAnimChecks) {
        timeBetweenAnimChecks = Date.now() + 1500;
        if (!native.isEntityPlayingAnim(editor.cloneId, 'nm@hands', 'hands_up', 3)) {
            alt.emit('animation:Play', {
                dict: 'nm@hands',
                name: 'hands_up',
                duration: -1,
                flag: 2
            });
        }
    }
}

function setcam(){
    let x = startCamPosition.x+gzoom;
    let y = startCamPosition.y+gzoomy;
    let z = startCamPosition.z+zpos;
    native.setCamCoord(camera, x, y, z);
    native.pointCamAtCoord(camera, x, y, z);
    native.setCamActive(camera, true);
    native.renderScriptCams(true, false, 0, true, false, 1); 
}

export function setFov(value) {
    fov = value;

    native.setCamFov(camera, fov);
    native.setCamActive(camera, true);
    native.renderScriptCams(true, false, 0, true, false, 1);
}

export function setZPos(value) {
    zpos = value;

    native.setCamCoord(camera, startCamPosition.x, startCamPosition.y, startCamPosition.z + zpos);
    native.pointCamAtCoord(camera, startPosition.x, startPosition.y, startPosition.z + zpos);
    native.setCamActive(camera, true);
    native.renderScriptCams(true, false, 0, true, false, 1);
}
