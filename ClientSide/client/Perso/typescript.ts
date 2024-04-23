import * as alt from "alt-client";
import * as native from "natives";

alt.onServer('showPerso', ShowPerso);
const url = `http://resource/client/Perso/perso.html`;
let view = null;


function ShowPerso(fname, lname, age, height, eye, street, id)
{
    if(view==null)
    {
        view = new alt.WebView(url);
        view.on('closeView',closeView);
        view.emit("createPerso",fname, lname, age, height, eye, street, id);
        view.focus();
    }
}

function closeView() {
    if (view != null) {
        view.destroy();
    }
    view = null;
}