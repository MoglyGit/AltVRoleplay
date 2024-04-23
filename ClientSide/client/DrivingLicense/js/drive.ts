alt.on("createDrive",(owner,id,car,bike) => {
	document.getElementById("p2").innerHTML ="Name: "+owner;
	document.getElementById("p3").innerHTML ="Auto: "+ (car==1 ? "im besitz":"nicht im besitz");
	document.getElementById("p4").innerHTML ="Motrrad: "+ (bike==1 ? "im besitz":"nicht im besitz");
	document.getElementById("p5").innerHTML ="";
	document.getElementById("p6").innerHTML ="";
	document.getElementById("p7").innerHTML = id;
	document.getElementById("persovor").style.display ="block";
});

document.body.addEventListener("keydown", (event) => {
	if (event.keyCode==73 ||event.keyCode==66 || event.keyCode == 27) {
	  alt.emit("closeView");
	  return;
	}
	// do something
  });