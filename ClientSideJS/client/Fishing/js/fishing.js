let fishtry = 0;
let fishtimer = null;
let fishes = [];
let fishspeed = [];
let fishType = [];
let fishDespawn = [];
let blocked = 1;
let fishMaxTrys = 3;
let waitInterval = null;
let a = 0;
let t = 0;
let tc = 0;
alt.on('addFish', (amoun, type, typeChance)=>{
    waitInterval = setInterval(startFishing, 5000 + 1000 * getRandomFishInt(10));
    a = amoun;
    t = type;
    tc = typeChance;
});
function startFishing() {
    clearInterval(waitInterval);
    addFish(a, t, tc);
    document.body.style.visibility = 'visible';
    blocked = 0;
    alt.emit('removeKoeder');
}
document.body.addEventListener('keydown', (event)=>{
    if (event.keyCode == 73 || event.keyCode == 27 || event.keyCode == 88) {
        alt.emit('closeView');
        return;
    }
    if (blocked != 0) return;
    if (event.keyCode == 68) {
        if (fishtry != 0) return;
        let player = document.getElementById('player');
        let water = document.getElementById('water');
        if (player.offsetLeft + player.offsetWidth + 5 < water.offsetLeft + water.offsetWidth) {
            let x = parseFloat(player.style.marginLeft);
            x += 1;
            player.style.marginLeft = x + '%';
        }
    }
    if (event.keyCode == 65) {
        if (fishtry != 0) return;
        const player = document.getElementById('player');
        const water = document.getElementById('water');
        if (player.offsetLeft - 5 > water.offsetLeft) {
            let x = parseFloat(player.style.marginLeft);
            x -= 1;
            player.style.marginLeft = x + '%';
        }
    }
    if (event.keyCode == 32) {
        if (fishtry != 0) {
            clearFishTry();
            return;
        }
        fishMaxTrys -= 1;
        const rope = document.getElementById('rope');
        rope.style.height = '1vh';
        rope.style.visibility = 'visible';
        fishtry = 1;
        if (fishtimer != null) {
            clearInterval(fishtimer);
            fishtimer = null;
        }
        fishtimer = setInterval(moveRope, 200);
    }
// do something
});
function clearFishTry() {
    const rope = document.getElementById('rope');
    if (fishtimer != null) {
        clearInterval(fishtimer);
        fishtimer = null;
    }
    rope.style.height = '1vh';
    rope.style.visibility = 'hidden';
    rope.style.marginTop = -5 + 'vh';
    fishtry = 0;
    if (fishMaxTrys <= 0) {
        alt.emit('closeView');
    }
}
function moveRope() {
    const rope = document.getElementById('rope');
    const water = document.getElementById('water');
    let y = parseFloat(rope.style.height);
    y += 1;
    rope.style.height = y + 'vh';
    let top = parseFloat(rope.style.marginTop);
    top -= 1;
    rope.style.marginTop = top + 'vh';
    HittetFish();
    if (rope.offsetHeight - parseFloat(rope.style.marginTop) >= water.offsetHeight - 15) {
        clearFishTry();
    }
}
function HittetFish() {
    const rope = document.getElementById('rope');
    for(let i = 0; i < fishes.length; i++){
        if (fishDespawn[i] > 5 - fishType[i]) continue;
        if (getOffset(fishes[i]).top + 30 > getOffset(rope).top && getOffset(rope).top > getOffset(fishes[i]).top) {
            if (getOffset(fishes[i]).left + 30 > getOffset(rope).left && getOffset(rope).left > getOffset(fishes[i]).left) {
                alt.emit('hitFish', fishType[i], i);
            }
        }
    }
}
//addFish(4, 5, 50);
function addFish(amount, type, typeChance) {
    let constY = 10;
    if (amount > 4) amount = 4;
    for(let i = 0; i < amount; i++){
        const newDiv = document.createElement('div');
        // and give it some content
        // add the text node to the newly created div
        fishType[i] = 0;
        fishDespawn[i] = 0;
        if (typeChance >= getRandomFishInt(100) && (type < 4 && i > 1 || type >= 4 && i > 2)) {
            newDiv.innerHTML = getFishType(type);
            fishType[i] = type;
        } else newDiv.innerHTML = getFishType(0);
        newDiv.style.marginTop = '0%';
        newDiv.style.marginLeft = '0%';
        // add the newly created element and its content into the DOM
        const currentDiv = document.getElementById('water');
        currentDiv.appendChild(newDiv);
        const y = 1;
        newDiv.style.marginTop = parseFloat(newDiv.style.marginTop) - (constY + y) + 'vh';
        constY = parseFloat(newDiv.style.marginTop) * -1;
        const x = getRandomFishInt(80);
        const pos = parseFloat(newDiv.style.marginLeft) + x;
        newDiv.style.marginLeft = pos + '%';
        fishes[i] = newDiv;
        fishspeed[i] = 1 + getRandomFishInt(10);
        console.log(i + ': Fish height: ' + getOffset(fishes[i]).top);
    }
    setInterval(moveFishes, 100);
}
function getOffset(el) {
    const rect = el.getBoundingClientRect();
    return {
        left: rect.left + window.scrollX,
        top: rect.top + window.scrollY
    };
}
function moveFishes() {
    for(let i = 0; i < fishes.length; i++){
        if (fishDespawn[i] > 5 - fishType[i]) continue;
        fishspeed[i] -= 1;
        if (fishspeed[i] > 0) continue;
        fishspeed[i] = 1 + getRandomFishInt(10);
        let speed = 2;
        if (fishType[i] >= 3) speed = 3;
        const pos = parseFloat(fishes[i].style.marginLeft) - 1 - getRandomFishInt(speed);
        fishes[i].style.marginLeft = pos + '%';
        const water = document.getElementById('water');
        if (fishes[i].offsetLeft < water.offsetLeft - 4) {
            fishDespawn[i] += 1;
            if (fishDespawn[i] > 5 - fishType[i]) {
                fishes[i].style.visibility = 'hidden';
                fishes[i].style.marginLeft = '200%';
                return;
            }
            fishes[i].style.marginLeft = '100%';
        }
    }
}
function getFishType(type) {
    if (type == 0) return '&#128031;'; //normal
    if (type == 1) return '&#128033;'; //kugel
    if (type == 2) return '&#128032;'; //tropical
    if (type == 3) return '&#128025;'; //krake
    if (type == 4) return '&#128044;'; //dolphin
    if (type == 5) return '&#129416;'; //shark
    return '&#128031;';
}
function getRandomFishInt(max) {
    return Math.floor(Math.random() * max);
}
