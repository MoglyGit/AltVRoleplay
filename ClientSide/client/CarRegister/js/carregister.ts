alt.on("createCar",(name, price,dbid,playermoney) => {
	const newLi = document.createElement("li");
	newLi.setAttribute("class","center button2");
	newLi.setAttribute("onclick","registerCar(this)");
	const value = price.toLocaleString().replaceAll(',','.')+"$";
	if(playermoney<price)
	{
		newLi.setAttribute("style","background-color: rgb(185, 0, 0)");
	}
	newLi.innerHTML = 'Fahrzeug: '+name+'<br> Kosten: '+price+'$';
	newLi.dataset.cardbid = ""+dbid;
	newLi.dataset.price = ""+price;
	document.getElementById("carList").appendChild(newLi);
});


document.body.addEventListener("keydown", (event) => {
	if (event.keyCode == 27 || event.keyCode == 66) {
	  alt.emit("closeView");
	  return;
	}
});

function registerCar(car)
{
	alt.emit("registerPlayerCar",parseInt(car.dataset.price),parseInt(car.dataset.cardbid));
}

function closeCarRegister()
{
	alt.emit("closeView");
}