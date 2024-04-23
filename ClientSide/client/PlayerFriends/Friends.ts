import * as alt from 'alt-client';
import * as native from 'natives';

let friends = [];
export function SetFriendList() {
    const player = alt.Player.local;
    console.log(player.hasSyncedMeta('FriendList'));
    if (!player.hasSyncedMeta('FriendList')) return;
    friends = <[]>player.getSyncedMeta('FriendList');
    console.log(friends);
    console.log(IsSocialClubIdFriend(2));
}
export function IsSocialClubIdFriend(scid: number) {
    return friends.includes(scid);
}

alt.onServer('AddFriend', (targetscid) => {
    friends.push(targetscid);
});

alt.onServer('RemoveFriend', (targetscid) => {
    friends = friends.filter(function (ids) {
        return ids != targetscid;
    });
});
