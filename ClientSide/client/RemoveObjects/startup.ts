import * as alt from 'alt-client';
import * as native from 'natives';

alt.everyTick(() => {
    const pos = alt.Player.local.pos;
    const e = native.getClosestObjectOfType(
        pos.x,
        pos.y,
        pos.z,
        70,
        alt.hash('prop_mineshaft_door'),
        false,
        true,
        true
    );
    if (e) {
        if (native.isEntityVisible(e)) {
            //alt.LocalObject.allWorld.
            native.setEntityCollision(e, false, false);
            native.setEntityVisible(e, false, false);
            native.setEntityCanBeDamaged(e, false);
        }
    }
});
