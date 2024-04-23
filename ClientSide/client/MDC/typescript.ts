import * as alt from "alt-client";
import * as native from "natives";

alt.onServer('showMDC', ShowMDC);
const url = `http://resource/client/MDC/index.html`;
let view = null;
let cameraControlsInterval=null;
alt.onServer("dbPlayer", createdbPlayer);
alt.onServer("setMdcPlayerInfo",setMdcPlayerInfo);
alt.onServer("createCrimeInfo",createCrimeInfo);
alt.onServer("clearCrimeDiv",clearDiv);
function clearDiv()
{
    if(view!=null)view.emit("clearDiv");
}
function createCrimeInfo(date, type,reason, officer, cost)
{
    if(view!=null)view.emit("createCrimeInfo",date, type,reason, officer, cost);
}
function setMdcPlayerInfo(name, age, job, addr)
{
    if(view!=null)view.emit("createPersonInfo",name, job,addr, age);
}

function createdbPlayer(fn, ln, sc, pid)
{
    if(view!=null)view.emit("createdbPlayer",fn,ln,sc,pid);
}

function mdcPersonSearch(person)
{
    alt.emitServer("mdcPersonSearch", person);
}

function getPlayerInfos(sc:number)
{
    alt.emitServer("getPlayerInfos", sc);
}
function createCrime(type, cost, crime, want,time,sc)
{
    alt.emitServer("createMdcCrime",type,cost,crime,want, time,sc);
}
function getPlayerOpenWanteds(sc)
{
    alt.emitServer("getPlayerOpenWanteds",sc);
}
function getPlayerOpenTickets(sc)
{
    alt.emitServer("getPlayerOpenTickets",sc);
}
function getPlayerAnschriften(sc)
{
    alt.emitServer("getPlayerAnschriften",sc)
}

function ShowMDC(name)
{
    if(view==null)
    {
        view = new alt.WebView(url);
        view.on('closeView',closeView);
        view.on('getPlayerInfos', getPlayerInfos);
        view.on('mdcPersonSearch', mdcPersonSearch);
        view.on('createCrime', createCrime);
        view.on('getPlayerOpenWanteds',getPlayerOpenWanteds)
        view.on('getPlayerOpenTickets',getPlayerOpenTickets);
        view.on('getPlayerAnschriften',getPlayerAnschriften)
        view.emit("mdcUser",name);
        alt.setMeta("noInv","1");
        alt.setMeta("noChat","1");
        showCursor(true);
        view.focus();
        cameraControlsInterval = alt.setInterval(handleControls, 0);
    }
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
        showCursor(false);
        alt.deleteMeta("noInv");
        alt.deleteMeta("noChat");
    }
    view = null;
}
function showCursor(state) {
    try {
        alt.showCursor(state);
    } catch (err) {
        return;
    }
}