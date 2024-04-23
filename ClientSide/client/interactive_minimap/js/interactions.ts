let item = null;
let start = null;
let startstyle = null;

function say(node) {
    if (node == item) return;
    console.log(node.innerHTML);
}

function moveItem(img) {
    if (item != null) return;
    startstyle = img.style.position;
    img.style.position = 'absolute';
    start = img.parentNode;
    document.body.appendChild(img);
    item = img;
}

function stopItemMoveX() {
    console.log('out');
    if (item == null) return;
    item.style.position = startstyle;
    start.appendChild(item);
    startstyle = null;
    start = null;
    item = null;
}
