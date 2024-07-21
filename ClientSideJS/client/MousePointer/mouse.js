import * as alt from 'alt-client';
import * as native from 'natives';
let cameraControlsInterval = null;
alt.on("keydown", (key)=>{
    if (key == 121 && alt.gameControlsEnabled()) {
        if (alt.isCursorVisible()) {
            if (cameraControlsInterval !== undefined || cameraControlsInterval !== null) {
                alt.clearInterval(cameraControlsInterval);
                cameraControlsInterval = null;
            }
            showCursor(false);
            return;
        }
        cameraControlsInterval = alt.setInterval(handleControls, 0);
        showCursor(true);
        const pos = alt.Player.local.pos;
        var e = native.getClosestObjectOfType(pos.x, pos.y, pos.z, 20, 3552768664, false, true, true);
        const pos2 = native.getEntityCoords(e, false);
    }
});
function handleControls() {
    native.disableControlAction(0, 25, true);
    const x = alt.getCursorPos().x;
    const y = alt.getCursorPos().y;
    if (native.isDisabledControlJustPressed(0, 25)) {
        const pos = alt.screenToWorld(x, y);
    }
}
function showCursor(state) {
    try {
        alt.showCursor(state);
    } catch (err) {
        return;
    }
}
