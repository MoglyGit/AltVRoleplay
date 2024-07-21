import * as alt from 'alt-client';
import * as Textlabel from './TextLabel/3DText.js';
import * as Friends from './PlayerFriends/Friends.js';
alt.onServer('LoginComplete', ()=>{
    Textlabel.SetAllowDraw(true);
    Friends.SetFriendList();
    console.log('conComplete');
});
