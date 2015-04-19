// 06. Write an expression that checks if given point (x,  y) is within a circle K(O, 5).
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = checkPoint;

function checkPoint() {
    var pointX = jsConsole.readFloat('#point-x');
    var pointY = jsConsole.readFloat('#point-y');

    var isInside = ((pointX * pointX) + (pointY * pointY)) <= 25;

    jsConsole.writeLine('The point is inside the circle: ' + isInside);
}