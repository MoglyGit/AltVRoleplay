document.body.addEventListener("keydown", (event) => {
	if (event.keyCode==73 ||event.keyCode==66 || event.keyCode == 27) {
	  alt.emit("closeView");
	  return;
	}
	// do something
});

function car()
{
    alt.emit("carTest");
}

function bike()
{

}