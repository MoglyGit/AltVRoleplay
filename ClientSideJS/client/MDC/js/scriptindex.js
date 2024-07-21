function setPlayer(sc) {
    localStorage.setItem("playersc", sc);
    getPlayerInfos();
}
alt.on("mdcUser", (name)=>{
    document.getElementById("policeName").innerHTML = "Name: " + name;
});
function getPlayerInfos() {
    if (localStorage.getItem("playersc") == null) return;
    alt.emit("getPlayerInfos", parseInt(localStorage.getItem("playersc")));
}
function getPlayerInfos2() {
    if (localStorage.getItem("playersc") == null) return;
    document.getElementById("addCrime").style.display = "block";
    alt.emit("getPlayerInfos", parseInt(localStorage.getItem("playersc")));
}
function getPlayerOpenWanteds() {
    if (localStorage.getItem("playersc") == null) return;
    document.getElementById("addCrime").style.display = "none";
    alt.emit("getPlayerOpenWanteds", parseInt(localStorage.getItem("playersc")));
}
function getPlayerOpenTickets() {
    if (localStorage.getItem("playersc") == null) return;
    document.getElementById("addCrime").style.display = "none";
    alt.emit("getPlayerOpenTickets", parseInt(localStorage.getItem("playersc")));
}
function getPlayerAnschriften() {
    if (localStorage.getItem("playersc") == null) return;
    document.getElementById("addCrime").style.display = "none";
    alt.emit("getPlayerAnschriften", parseInt(localStorage.getItem("playersc")));
}
function createCrime() {
    if (localStorage.getItem("playersc") == null) return;
    const reason = document.getElementById("crimereason").innerHTML;
    console.log("test: " + parseInt(localStorage.getItem("playersc")));
    //if(!/^[A-Za-z1-9.,():!? ]*$/.test(reason))return;
    let e = document.getElementById("crime");
    console.log("test: " + e.value);
    if (e.value == "anmerkung") {
        alt.emit("createCrime", 0, 0, reason, 0, 0, parseInt(localStorage.getItem("playersc")));
    } else if (e.value == "verwarnung") {
        const price = document.getElementById("price").value;
        alt.emit("createCrime", 1, parseInt(price), reason, 1, 0, parseInt(localStorage.getItem("playersc")));
    } else if (e.value == "verbrechen") {
        let price = 0, time = 0;
        if (document.getElementById("grad").value == "1") {
            price = 150;
            time = 60 * 3;
        }
        if (document.getElementById("grad").value == "2") {
            price = 300;
            time = 60 * 5;
        }
        if (document.getElementById("grad").value == "3") {
            price = 1000;
            time = 60 * 10;
        }
        if (document.getElementById("grad").value == "4") {
            price = 3000;
            time = 60 * 30;
        }
        if (document.getElementById("grad").value == "5") {
            price = 5000;
            time = 60 * 60;
        }
        alt.emit("createCrime", 2, price, reason, 1, time, parseInt(localStorage.getItem("playersc")));
    }
}
