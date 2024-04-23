import * as alt from 'alt-client';
import * as native from 'natives';
import * as cam from './cam';

const fModel = alt.hash('mp_f_freemode_01');
const mModel = alt.hash(`mp_m_freemode_01`);
const url = `http://resource/client/face/html/index.html`;
let view;

export let cloneId = null;
let lasti = 0;
let posx = 0;
let posy = 0;
let posz = 0;
let posr = 0;

native.requestModel(fModel);
native.requestModel(mModel);

alt.onServer('charCreate', charCreate);
alt.onServer('allowedToSpawn', finalSpawn);

function charCreate(zoom: number, x: number, y: number, z: number, r: number) {
    showCursor(true);
    alt.setMeta('noInv', '1');
    native.freezeEntityPosition(alt.Player.local.scriptID, true);
    posx = x;
    posy = y;
    posz = z;
    posr = r;
    cloneId = native.createPed(0, mModel, x, y, z, r, false, false);
    native.setEntityHeading(cloneId, r);
    cam.createPedEditCamera(cloneId, zoom, x, y, z);
    cam.setFov(50);
    cam.setZPos(0.6);
    native.setPedHeadBlendData(cloneId, 22, 22, 0, 22, 22, 0, 0, 0, 0, false);

    if (!view) {
        view = new alt.WebView(url);
        view.on('clientSync', handleClientSync);
        view.on('clientSpawnSync', handleSpawn);
        view.on('keysFreeze', handleKeyFreeze);
        alt.setMeta('noChat', '1');
    }
    view.focus();
}

function handleKeyFreeze(a: boolean) {
    cam.setKeyFreeze(a);
}

function finalSpawn() {
    if (cloneId != null) {
        native.deletePed(cloneId);
    }
    closeView();
    alt.deleteMeta('noInv');
    alt.deleteMeta('noChat');
}

function handleSpawn(data) {
    alt.emitServer('spawnPlayerAfterCreation', JSON.stringify(data));
}

function handleClientSync(data) {
    if (lasti != data.sex) {
        lasti = data.sex;
        let model = mModel;
        if (data.sex == 1) {
            model = fModel;
        }
        if (cloneId != null) {
            native.deletePed(cloneId);
        }
        cloneId = native.createPed(0, model, posx, posy, posz, posr, false, false);
        native.setEntityHeading(cloneId, posr);
        alt.Utils.wait(1000);
    }

    for (let i = 0; i <= 19; i++) {
        native.setPedMicroMorph(cloneId, i, parseFloat(data.micro[i]));
    }

    for (let i = 0; i <= 12; i++) {
        native.setPedHeadOverlay(cloneId, i, parseInt(data.head[i]), parseFloat(data.opa[i]));
    }

    native.setPedHairTint(cloneId, data.haircolor, data.hairtint);

    native.setPedHeadOverlayTint(cloneId, 1, 1, parseInt(data.overlaytint[0]), 0);
    native.setPedHeadOverlayTint(cloneId, 2, 1, parseInt(data.overlaytint[1]), 0);
    native.setPedHeadOverlayTint(cloneId, 10, 1, parseInt(data.overlaytint[2]), 0);
    native.setPedHeadOverlayTint(cloneId, 8, 2, parseInt(data.overlaytint[3]), 0);
    native.setPedHeadOverlayTint(cloneId, 5, 2, parseInt(data.overlaytint[4]), 0);

    for (let i = 0; i <= 11; i++) {
        native.setPedComponentVariation(cloneId, i, parseInt(data.clothes[i]), parseInt(data.clothestext[i]), 0);
    }

    native.setHeadBlendEyeColor(cloneId, data.eyecolor);

    native.setPedHeadBlendData(
        cloneId,
        data.shapeFirstID,
        data.shapeSecondID,
        data.shapeThirdID,
        data.skinFirstID,
        data.skinSecondID,
        data.skinThirdID,
        data.shapeMix,
        data.skinMix,
        data.thirdMix,
        data.isParent
    );
}

function closeView() {
    if (view && view.destroy) {
        view.destroy();
    }

    view = null;
    showCursor(false);
    native.freezeEntityPosition(alt.Player.local.scriptID, false);
    cam.destroyPedEditCamera();
}

function showCursor(state) {
    try {
        alt.showCursor(state);
    } catch (err) {
        return;
    }
}
