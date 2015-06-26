var canvas = document.getElementById('the-canvas');
var ctx = canvas.getContext('2d');

function reset() {
    ctx.rect(0, 0, ctx.canvas.width, ctx.canvas.height);
    var grd = ctx.createLinearGradient(500, 250, 500, 0);
    grd.addColorStop(0, '#8ED6FF');
    grd.addColorStop(1, '#004CB3');
    ctx.fillStyle = grd;
    ctx.fill();

    ctx.beginPath();
    ctx.arc(0, 0, 120, 0, 2 * Math.PI);
    ctx.fillStyle = '#FFD800';
    ctx.fill();
    ctx.strokeStyle = '#FFD800';
    ctx.stroke();
};

function drawSuperMarioOne() {
    var image = new Image();
    image.src = 'images/SuperMario1.png';
    ctx.drawImage(image, 400, 395);
};

function drawSuperMarioTwo() {
    var image = new Image();
    image.src = 'images/SuperMario2.png';
    ctx.drawImage(image, 400, 390);
};

function drawCloud() {
    var image = new Image();
    image.src = 'images/cloud.png';
    return image;
};

function drawTube() {
    var image = new Image();
    image.src = 'images/Pipe.gif';
    image.style.zIndex = '-1';
    return image;
};

function drawCoin() {
    var image = new Image();
    image.src = 'images/Coin.gif';
    return image;
};

var i = 0;
var z = 0;

function drawSuper() {
    setTimeout(function(){
        requestAnimationFrame(drawSuper)

        reset();
        
        ctx.drawImage(drawCloud(), 950 - i * 30, 100);
        ctx.drawImage(drawCloud(), 1200 - i * 30, 150);
        ctx.drawImage(drawCloud(), 1600 - z * 30, 30);
        ctx.drawImage(drawTube(), 950 - i * 30, 400);
        ctx.drawImage(drawCoin(), 1100 - i * 30, 320);
        ctx.drawImage(drawCoin(), 1120 - i * 30, 320);
        ctx.drawImage(drawCoin(), 1140 - i * 30, 320);
        ctx.drawImage(drawCoin(), 1160 - i * 30, 320);
        ctx.drawImage(drawCoin(), 1190 - i * 30, 300);
        ctx.drawImage(drawCoin(), 1210 - i * 30, 300);
        ctx.drawImage(drawCoin(), 1230 - i * 30, 300);

        if (i % 2 === 0) {
            drawSuperMarioOne();
        } else {
            drawSuperMarioTwo();
        }

        if (z > 60) {
            z = 0;
        }

        if (i > 45) {
            i = 0;
        }

        i++;
        z++;

    }, 1000/7)
};

reset();

requestAnimationFrame(drawSuper);