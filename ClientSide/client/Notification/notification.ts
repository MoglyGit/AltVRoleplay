import * as alt from 'alt-client';
import * as native from 'natives';

const url = `http://resource/client/Notification/index.html`;
let view = null;
let tickid = 0;
let tick = 0;
let removetickid = 0;
let timer = null;
alt.onServer('Notify', ShowNotification);

export function ShowNotification(type, string) {
    tick++;
    tickid++;
    if (view == null) {
        view = new alt.WebView(url);
        view.emit('createNotify', type, string, tickid);
        if (timer == null) {
            timer = setInterval(myTimer, 2500);
        }
    } else {
        view.emit('createNotify', type, string, tickid);
    }
}

function myTimer() {
    tick--;
    if (tick <= 0) {
        if (timer != null) clearInterval(timer);
        timer = null;
        removetickid = 0;
        tickid = 0;
    }
    if (view != null && tick <= 0) {
        view.destroy();
        view = null;
        return;
    }
    removetickid++;
    view.emit('removeNotify', removetickid);
}
