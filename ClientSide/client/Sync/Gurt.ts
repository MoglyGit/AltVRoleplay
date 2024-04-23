import * as alt from 'alt-client';
import * as native from 'natives';
import * as notify from '../Notification/notification';

const gurt = 'GurtUsed';

alt.everyTick(() => {
    const player = alt.Player.local;
    native.setPedConfigFlag(alt.Player.local.scriptID, 113, true);
    if (player.vehicle == null) {
        native.setPedConfigFlag(alt.Player.local.scriptID, 32, true);
        if (alt.hasMeta(gurt)) {
            alt.deleteMeta(gurt);
            notify.ShowNotification(0, 'Abgeschnallt');
        }
        return;
    }
    if (!alt.hasMeta(gurt)) {
        native.setPedConfigFlag(alt.Player.local.scriptID, 32, true);
    } else native.setPedConfigFlag(alt.Player.local.scriptID, 32, alt.getMeta(gurt) == true);
});
