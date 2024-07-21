import * as alt from "alt-client";
import * as native from "natives";
let loginHud;
alt.onServer('freezeMe', (freeze)=>{
    const player = alt.Player.local.scriptID;
    native.freezeEntityPosition(player, freeze);
});
alt.onServer('CloseLoginHud', ()=>{
    alt.showCursor(false);
    alt.toggleGameControls(true);
    alt.toggleVoiceControls(true);
    if (loginHud) {
        loginHud.destroy();
    }
});
alt.onServer('SendErrorMessage', (text)=>{
    loginHud.emit('ErrorMessage', text);
});
alt.onServer('RegisterHud', ()=>{
    loginHud = new alt.WebView("http://resource/client/login/register.html");
    loginHud.focus();
    alt.showCursor(true);
    alt.toggleGameControls(false);
    alt.toggleVoiceControls(false);
    loginHud.on('Auth.Register', (password)=>{
        alt.emitServer('Event.Register', password);
    });
});
alt.onServer('LoginHud', ()=>{
    loginHud = new alt.WebView("http://resource/client/login/login.html");
    loginHud.focus();
    alt.showCursor(true);
    alt.toggleGameControls(false);
    alt.toggleVoiceControls(false);
    loginHud.on('Auth.Login', (password)=>{
        alt.emitServer('Event.Login', password);
    });
});
