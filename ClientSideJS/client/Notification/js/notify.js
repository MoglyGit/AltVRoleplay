alt.on("createNotify", (type, string, tick)=>{
    const newDiv = document.createElement("div");
    switch(type){
        case 0:
            newDiv.setAttribute("class", "check");
            newDiv.innerHTML = "<i class='far fa-check-circle color'></i> &nbsp; &nbsp;<span>" + string + "</span>";
            break;
        case 1:
            newDiv.setAttribute("class", "info");
            newDiv.innerHTML = "<i class='fa fa-info-circle spin'></i> &nbsp; &nbsp;<span>" + string + "</span>";
            break;
        case 2:
            newDiv.setAttribute("class", "warning");
            newDiv.innerHTML = "<i class='fa fa-exclamation-triangle rotate'></i> &nbsp; &nbsp;<span>" + string + "</span>";
            break;
        case 3:
            newDiv.setAttribute("class", "danger");
            newDiv.innerHTML = "<i class='far fa-times-circle shine'></i> &nbsp; &nbsp;<span>" + string + "</span>";
            break;
    }
    newDiv.setAttribute("id", "t" + tick);
    document.getElementById("notifys").appendChild(newDiv);
});
alt.on("removeNotify", (tick)=>{
    document.getElementById("t" + tick).remove();
});
