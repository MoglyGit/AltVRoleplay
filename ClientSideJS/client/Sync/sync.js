import * as alt from 'alt-client';
import * as native from 'natives';
alt.everyTick(()=>{
    native.setPedConfigFlag(alt.Player.local.scriptID, 241, true);
    native.setPedConfigFlag(alt.Player.local.scriptID, 429, true);
    native.setPedConfigFlag(alt.Player.local.scriptID, 184, true);
});
alt.setInterval(()=>{
    const vehicles = [
        ...alt.Vehicle.streamedIn
    ];
    for(let i = 0; i < vehicles.length; i++){
        const veh = vehicles[i];
        if (!veh || !veh.valid) continue;
        //blinker
        const light = veh.getSyncedMeta('blinker');
        if (light) veh.indicatorLights = parseInt('' + light);
        const siren = veh.getSyncedMeta('siren');
        if (siren) {
            native.setVehicleHasMutedSirens(veh, true);
        } else {
            native.setVehicleHasMutedSirens(veh, false);
        }
        const shortsiren = veh.getSyncedMeta('shortsiren');
        if (shortsiren) native.blipSiren(veh);
    }
}, 1000);
