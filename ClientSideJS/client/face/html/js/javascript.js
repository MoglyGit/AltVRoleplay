const data = {
    name: "Max",
    firstname: "Muster",
    age: 21,
    height: 170,
    crime: "",
    shapeFirstID: 28,
    shapeSecondID: 22,
    shapeThirdID: 0,
    skinFirstID: 22,
    skinSecondID: 22,
    skinThirdID: 0,
    shapeMix: 0,
    skinMix: 0,
    thirdMix: 0,
    isParent: false,
    sex: 0,
    haircolor: 0,
    hairtint: 0,
    rpszenario: 1,
    clothes: [
        0,
        0,
        0,
        15,
        0,
        0,
        1,
        0,
        15,
        0,
        0,
        15,
        0
    ],
    clothestext: [
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0
    ],
    eyecolor: 1,
    overlaytint: [
        0,
        0,
        0,
        0,
        0
    ],
    micro: [
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0
    ],
    head: [
        255,
        255,
        255,
        255,
        255,
        255,
        255,
        255,
        255,
        255,
        255,
        255,
        255
    ],
    opa: [
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1
    ]
};
//Seite anpassen
function show(id) {
    switch(id){
        case 0:
            document.getElementById("face").style.display = "block";
            document.getElementById("face1").style.display = "block";
            document.getElementById("hair").style.display = "none";
            document.getElementById("hair1").style.display = "none";
            document.getElementById("rp").style.display = "none";
            document.getElementById("rpcrime").style.display = "none";
            document.getElementById("done").style.display = "none";
            break;
        case 1:
            document.getElementById("face").style.display = "none";
            document.getElementById("face1").style.display = "none";
            document.getElementById("hair").style.display = "block";
            document.getElementById("hair1").style.display = "block";
            document.getElementById("rp").style.display = "none";
            document.getElementById("rpcrime").style.display = "none";
            document.getElementById("done").style.display = "none";
            if (data.sex == 0) {
                document.getElementById("hair").max = "76";
            }
            if (data.sex == 1) {
                document.getElementById("hair").max = "80";
            }
            break;
        case 2:
            document.getElementById("face").style.display = "none";
            document.getElementById("face1").style.display = "none";
            document.getElementById("hair").style.display = "none";
            document.getElementById("hair1").style.display = "none";
            document.getElementById("rp").style.display = "block";
            document.getElementById("rpcrime").style.display = "none";
            document.getElementById("done").style.display = "none";
            break;
        case 3:
            document.getElementById("face").style.display = "none";
            document.getElementById("face1").style.display = "none";
            document.getElementById("hair").style.display = "none";
            document.getElementById("hair1").style.display = "none";
            document.getElementById("rp").style.display = "none";
            document.getElementById("rpcrime").style.display = "none";
            document.getElementById("done").style.display = "block";
            break;
    }
    clientSync();
}
function keysFreeze(a) {
    alt.emit('keysFreeze', a);
}
function clientSync() {
    alt.emit('clientSync', data);
}
function cloth(index, id, text) {
    data.clothes[index] = id;
    data.clothestext[index] = text;
}
function spawn(ev) {
    ev.preventDefault();
    data.crime = document.getElementById("crime").value;
    data.name = document.getElementById("fname").value;
    data.firstname = document.getElementById("lname").value;
    data.age = parseInt(document.getElementById("age").value);
    data.height = parseInt(document.getElementById("high").value);
    alt.emit('clientSpawnSync', data);
}
function rpSzenario(id) {
    document.getElementById("rpcrime").style.display = "none";
    if (id == 0) {
        document.getElementById("info").value = "Kriminell";
        document.getElementById("rpcrime").style.display = "block";
    }
    if (id == 1) document.getElementById("info").value = "Neutral";
    if (id == 2) document.getElementById("info").value = "Beamter";
    data.rpszenario = id;
    startClothes(-1);
}
function startClothes(id) {
    switch(id){
        case -1:
            cloth(3, 15, 0);
            cloth(4, 0, 0);
            cloth(6, 1, 0);
            cloth(8, 15, 0);
            cloth(11, 15, 0);
            break;
        case 0:
            if (data.rpszenario == 0) {
                if (data.sex == 0) {
                    cloth(3, 0, 0);
                    cloth(11, 0, 0);
                } else {
                    cloth(3, 0, 0);
                    cloth(11, 0, 0);
                }
            }
            if (data.rpszenario == 1) {
                if (data.sex == 0) {
                    cloth(3, 11, 0);
                    cloth(8, 15, 0);
                    cloth(11, 26, 0);
                } else {
                    cloth(3, 2, 0);
                    cloth(11, 2, 0);
                }
            }
            if (data.rpszenario == 2) {
                if (data.sex == 0) {
                    cloth(3, 0, 0);
                    cloth(8, 15, 0);
                    cloth(11, 234, 0);
                } else {
                    cloth(3, 5, 0);
                    cloth(8, 0, 0);
                    cloth(11, 8, 0);
                }
            }
            break;
        case 1:
            if (data.rpszenario == 0) {
                if (data.sex == 0) {
                    cloth(3, 5, 0);
                    cloth(11, 5, 0);
                } else {
                    cloth(3, 4, 0);
                    cloth(11, 247, 0);
                }
            }
            if (data.rpszenario == 1) {
                if (data.sex == 0) {
                    cloth(3, 0, 0);
                    cloth(8, 1, 0);
                    cloth(11, 346, 0);
                } else {
                    cloth(3, 9, 0);
                    cloth(11, 9, 0);
                }
            }
            if (data.rpszenario == 2) {
                if (data.sex == 0) {
                    cloth(3, 1, 0);
                    cloth(8, 1, 0);
                    cloth(11, 35, 0);
                } else {
                    cloth(3, 14, 0);
                    cloth(8, 15, 0);
                    cloth(11, 56, 0);
                }
            }
            break;
        case 2:
            if (data.rpszenario == 0) {
                if (data.sex == 0) {
                    cloth(4, 5, 0);
                } else {
                    cloth(4, 66, 0);
                }
            }
            if (data.rpszenario == 1) {
                if (data.sex == 0) {
                    cloth(4, 0, 0);
                } else {
                    cloth(4, 1, 0);
                }
            }
            if (data.rpszenario == 2) {
                if (data.sex == 0) {
                    cloth(4, 9, 0);
                } else {
                    cloth(4, 34, 0);
                }
            }
            break;
        case 3:
            if (data.rpszenario == 0) {
                if (data.sex == 0) {
                    cloth(4, 6, 0);
                } else {
                    cloth(4, 2, 0);
                }
            }
            if (data.rpszenario == 1) {
                if (data.sex == 0) {
                    cloth(4, 103, 0);
                } else {
                    cloth(4, 110, 0);
                }
            }
            if (data.rpszenario == 2) {
                if (data.sex == 0) {
                    cloth(4, 103, 0);
                } else {
                    cloth(4, 7, 0);
                }
            }
            break;
        case 4:
            if (data.sex == 0) {
                cloth(6, 1, 0);
            } else {
                cloth(6, 1, 0);
            }
            break;
        case 5:
            if (data.sex == 0) {
                cloth(6, 7, 0);
            } else {
                cloth(6, 49, 0);
            }
            break;
    }
    clientSync();
}
//clientSync#
function changeEyeColor(id) {
    data.eyecolor = parseInt(id);
    clientSync();
}
function changePedHairCut(i) {
    if (data.sex == 0 && parseInt(i) == 23) return;
    if (data.sex == 1 && parseInt(i) == 24) return;
    data.clothes[2] = parseInt(i);
    clientSync();
}
function changePedHairColour(i, a) {
    if (i != null) {
        data.haircolor = parseInt(i);
    }
    if (a != null) {
        data.hairtint = parseInt(a);
    }
    clientSync();
}
function changePedHeadOverlayTint(i, col1) {
    data.overlaytint[i] = parseInt(col1);
    clientSync();
}
function loadPed(i) {
    data.sex = i;
    cloth(3, 15, 0);
    cloth(4, 0, 0);
    cloth(6, 1, 0);
    cloth(8, 15, 0);
    cloth(11, 15, 0);
    clientSync();
}
function changeMicroMorph(i, id) {
    data.micro[i] = parseFloat(id);
    clientSync();
}
function changePedHeadOverlay(i, id, opacity) {
    if (opacity != null) {
        data.opa[i] = parseFloat(opacity);
    }
    if (id != null) {
        if (parseInt(id) == -1) {
            id = "255";
        }
        data.head[i] = parseInt(id);
    }
    clientSync();
}
function change(i, id) {
    let value = 0;
    let floatvalue = 0.0;
    if (i < 4) {
        value = parseInt(id);
        if (isNaN(value)) return;
    } else {
        floatvalue = parseFloat(id);
        if (isNaN(value)) return;
    }
    switch(i){
        case 0:
            data.shapeFirstID = value;
            break;
        case 1:
            data.shapeSecondID = value;
            break;
        case 2:
            data.skinFirstID = value;
            break;
        case 3:
            data.skinSecondID = value;
            break;
        case 4:
            data.shapeMix = floatvalue;
            break;
        case 5:
            data.skinMix = floatvalue;
            break;
    }
    clientSync();
}
