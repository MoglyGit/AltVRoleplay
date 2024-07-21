import * as alt from 'alt-client';
import * as native from 'natives';
alt.onServer('setTime', SetTime);
alt.onServer('setProgressBar', SetProgressBar);
const url = `http://resource/client/Hud/index.html`;
let view = null;
let h = -1;
let m = -1;
let s = -1;
let lastmoney;
let moneytick = 0;
let view2 = null;
let eventType = 0;
alt.onServer('Sound', Sound);
export function Sound(string) {
    if (view != null) view.emit('Sound', string);
}
let cameraControlsInterval = null;
export function SetProgressBar(time, event, info) {
    if (view2 == null) {
        view2 = new alt.WebView('http://resource/client/Hud/progress.html');
        view2.emit('createProg', time, info);
        alt.setMeta('noInv', '1');
        alt.setMeta('noChat', '1');
        view2.on('closeView', closeView2);
        eventType = event;
        cameraControlsInterval = alt.setInterval(handleControls, 0);
    }
}
function closeView2(allow) {
    if (view2 == null) return;
    if (cameraControlsInterval !== undefined || cameraControlsInterval !== null) {
        alt.clearInterval(cameraControlsInterval);
        cameraControlsInterval = null;
    }
    if (view2 && view2.destroy) {
        view2.destroy();
    }
    view2 = null;
    alt.deleteMeta('noInv');
    alt.deleteMeta('noChat');
    if (allow == 1) alt.emitServer('PlayerProgDone', eventType);
}
alt.on('keydown', (key)=>{
    if (key == 88 && view2 != null) {
        alt.emitServer('StopPlayerProg');
        closeView2(0);
    }
});
function handleControls() {
    native.disableAllControlActions(0);
    //native.disableAllControlActions(1);
    native.disableControlAction(0, 0, true);
    native.disableControlAction(0, 1, true);
    native.disableControlAction(0, 2, true);
    native.disableControlAction(0, 24, true);
    native.disableControlAction(0, 25, true);
}
function SetTime(hour, min, sec) {
    h = hour, m = min, s = sec;
    native.setClockTime(hour, min, sec);
    if (alt.getMsPerGameMinute() != 30000) alt.setMsPerGameMinute(30000);
    if (view == null) {
        view = new alt.WebView(url);
        view.emit('setTime', h, m, s);
    }
}
alt.setInterval(()=>{
    if (h == -1) return;
    if (alt.getMsPerGameMinute() != 30000) alt.setMsPerGameMinute(30000);
    s++;
    if (s >= 60) {
        m++;
        s = 0;
    }
    if (m >= 60) {
        h++;
        m = 0;
    }
    if (h >= 24) {
        h = 0;
    }
    native.setClockTime(h, m, s);
    if (view == null) view = new alt.WebView(url);
    view.emit('setTime', h, m, s, alt.Player.local.hasSyncedMeta('WearingWatch'));
    view.emit('syncMoney', alt.Player.local.getSyncedMeta('PMoney'), lastmoney);
    view.emit('syncPayday', alt.Player.local.getSyncedMeta('PayDay'));
    view.emit('syncThirst', alt.Player.local.getSyncedMeta('Thirst'));
    view.emit('syncHunger', alt.Player.local.getSyncedMeta('Hunger'));
    view.emit('syncHarn', alt.Player.local.getSyncedMeta('Harn'));
    view.emit('syncHappy', alt.Player.local.getSyncedMeta('Happy'));
    moneytick--;
    if (moneytick < 0) {
        lastmoney = alt.Player.local.getSyncedMeta('PMoney');
        moneytick = 3;
    }
}, 1000);
