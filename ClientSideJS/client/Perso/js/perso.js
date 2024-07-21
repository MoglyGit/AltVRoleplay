alt.on("createPerso", (fname, lname, age, height, eye, street, id)=>{
    document.getElementById("p2").innerHTML = "Name: " + fname + " " + lname;
    document.getElementById("p3").innerHTML = "Alter: " + age;
    document.getElementById("p4").innerHTML = "Groesse: " + height;
    document.getElementById("p5").innerHTML = "Augenfarbe: " + eye;
    document.getElementById("p6").innerHTML = "Anschrift: " + street;
    document.getElementById("p7").innerHTML = "" + id;
    document.getElementById("persovor").style.display = "block";
});
document.body.addEventListener("keydown", (event)=>{
    if (event.keyCode == 73 || event.keyCode == 66 || event.keyCode == 27) {
        alt.emit("closeView");
        return;
    }
// do something
});
