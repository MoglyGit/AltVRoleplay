function Warning(text) {
	if(text.length > 0)
	{
		document.getElementById("warning").innerHTML = text;
	}
}
alt.on('ErrorMessage', (txt) => Warning(txt));
function Login() {
	var password = (<HTMLInputElement>document.getElementById("pwd")).value;

	if(password.length < 6)
	{
		Warning("Password ist zu kurz.");
	}
	else
	{
		alt.emit('Auth.Login', password);
	}
}

function Register() {
	var password = (<HTMLInputElement>document.getElementById("pwd")).value;
	var password2 = (<HTMLInputElement>document.getElementById("pwd2")).value;
	if(password.length < 6)
	{
		Warning("Password ist zu kurz.");
	}
	else
	{
		if(password != password2)
		{
			Warning("Die Passwörter stimmen nicht überein");
		}
		else{
			alt.emit('Auth.Register', password);
		}
	}
}
function music() {
	let audio = <HTMLAudioElement>document.getElementById("mu");
	audio.play();
}
function stopmusic(){
	let audio = (<HTMLAudioElement>document.getElementById("mu"));
	audio.pause();
}