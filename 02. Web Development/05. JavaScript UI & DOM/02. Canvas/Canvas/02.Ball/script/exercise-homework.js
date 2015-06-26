// 02. Draw a circle that flies inside a box
// When it reaches an edge, it should bounce that edge

var canvas = document.getElementById('the-canvas');
var ctx = canvas.getContext('2d');
var radius = 65;
var xPos = 5 + radius
var yPos = 5 + radius;
var directionDown = true;
var directionRight = true;
var counter = 0;

function moveBall() {
    ctx.clearRect(0, 0, canvas.width, canvas.height)
    if ((xPos + radius === canvas.width) || (xPos - radius === 0)) {
        directionRight = !directionRight;
    }

    if ((yPos + radius === canvas.height) || (yPos - radius === 0)) {
        directionDown = !directionDown;
    }

    if (directionDown) {
        yPos++;
    } else {
        yPos--;
    }

    if (directionRight) {
        xPos++;
    } else {
        xPos--;
    }

    ctx.beginPath();
    ctx.arc(xPos, yPos, radius, 0, 2 * Math.PI);
    ctx.fillStyle = '#76A731';
    ctx.strokeStyle = 'black';
    ctx.lineWidth = 2;
    ctx.fill();
    ctx.stroke();

    requestAnimationFrame(moveBall);
}

moveBall();