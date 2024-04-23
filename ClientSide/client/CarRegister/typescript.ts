import * as alt from "alt-client";
import * as native from "natives";

const url = `http://resource/client/CarRegister/CarRegister.html`;
let view = null;
let cameraControlsInterval = null;

alt.onServer("CreateRegisterCar", CreateRegisterCar);
alt.onServer("CloseRegisterCar", closeView);


function CreateRegisterCar(name:string,price:number,dbid:number)
{
    if(!alt.Player.local.hasSyncedMeta("PMoney"))return;
    if(view==null)
    {
        view = new alt.WebView(url);
        alt.setMeta("noInv","1");
        alt.setMeta("noChat","1");
        view.on("registerPlayerCar",registerPlayerCar);
        view.on("closeView",closeView);
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        view.focus();
        showCursor(true);
    }
    view.emit("createCar",name,price,dbid,alt.Player.local.getSyncedMeta("PMoney"));
}

function registerPlayerCar(price:number,dbid:number)
{
    alt.emitServer("RegisterPlayerCar",price,dbid);
    closeView();
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
    if (view) {
        view.destroy();
    }
    alt.deleteMeta("noInv");
    alt.deleteMeta("noChat");
    view = null;
    showCursor(false);
}