import * as alt from 'alt-server';

alt.log(`alt:V Server - Typescript started`);
alt.on('charCreate', cam);

alt.on('playerConnect', OnPlayerConnect);

function OnPlayerConnect(player: alt.Player) {
    player.setStreamSyncedMeta('name', player.name);
    player.emit('playerConnect');
}

function cam(player: alt.Player, zoom: number, x: number, y: number, z: number, r: number) {
    alt.Utils.wait(1000);
    alt.emitClient(player, 'charCreate', zoom, x, y, z, r);
}
