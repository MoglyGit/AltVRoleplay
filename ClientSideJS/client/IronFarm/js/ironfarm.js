let actualHit = null;
let speed = 0.1;
let side = -1;
let hit = 0;
let hits = 0;
let maxhits = 20;
let loose = 2;
let hitTry = 0;
function addElement() {
    // create a new div element
    const newDiv = document.createElement('div');
    // and give it some content
    const newContent = document.createTextNode('X');
    // add the text node to the newly created div
    newDiv.appendChild(newContent);
    // add the newly created element and its content into the DOM
    const currentDiv = document.getElementById('way');
    currentDiv.appendChild(newDiv);
    newDiv.style.marginLeft = '94%';
    newDiv.style.marginTop = '-6%';
    actualHit = newDiv;
}
setInterval(myTimer, 5);
function myTimer() {
    if (actualHit == null) return;
    const pos = parseFloat(actualHit.style.marginLeft);
    if (pos <= 0.5) {
        side = 1;
        hitTry = 0;
    }
    if (pos >= 95) {
        side = -1;
        hitTry = 0;
    }
    const new_pos = pos + speed * side;
    actualHit.style.marginLeft = new_pos + '%';
}
function getRandomInt(max) {
    return Math.floor(Math.random() * max);
}
document.body.addEventListener('keydown', (event)=>{
    if (event.keyCode == 73 || event.keyCode == 27 || event.keyCode == 88) {
        alt.emit('closeView');
        return;
    }
    if (event.keyCode == 32) {
        if (hit != 1 && hitTry != 1) {
            hitTry = 1;
            alt.emit('playPickAxeSound');
            const hitpos = parseFloat(actualHit.style.marginLeft);
            if (document.getElementById('hit').offsetLeft < actualHit.offsetLeft && document.getElementById('hit').offsetLeft + document.getElementById('hit').offsetWidth > actualHit.offsetLeft + 14) {
                document.getElementById('hit').style.backgroundColor = '#00FF009F';
                hits += 1;
                loose = 2;
                if (hits >= maxhits) {
                    alt.emit('doneIron');
                }
                speed = parseFloat('0.' + (1 + 5 * (hits / maxhits)));
            } else {
                /*if (hits > 0 && loose == 0) {
                    hits -= 1;
                    loose = 2;
                    speed = parseFloat('0.' + (1 + 5 * (hits / maxhits)));
                }
                loose -= 1;*/ document.getElementById('hit').style.backgroundColor = '#FF00009F';
            }
            document.getElementById('info').innerHTML = '(' + hits + '/' + maxhits + ')';
        }
        hit = 1;
    }
// do something
});
document.body.addEventListener('keyup', (event)=>{
    if (event.keyCode == 32) {
        document.getElementById('hit').style.backgroundColor = '#00FF0000';
        hit = 0;
    }
// do something
});
alt.on('setStrong', (strong)=>{
    const w = 3 + 77 * (strong / 10);
    maxhits = 20 - strong;
    document.getElementById('info').innerHTML = '(' + hits + '/' + maxhits + ')';
    document.getElementById('hit').style.width = w + 'px';
    addElement();
});
