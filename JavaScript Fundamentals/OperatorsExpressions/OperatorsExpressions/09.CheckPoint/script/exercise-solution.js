// 09. Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) and out of the rectangle 
// R(top=1, left=-1, width=6, height=2).
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = checkPoint;

function checkPoint() {
    var pointX = jsConsole.readFloat('#point-x');
    var pointY = jsConsole.readFloat('#point-y');

    var checkCircle = ((pointX - 1) * (pointX - 1)) + ((pointY - 1) * (pointX - 1)) <= 9;
    var checkRectangle = pointX < -1 || pointX > 5 || pointY < -1 || pointY > 1;

    var isInside = checkCircle && checkRectangle;

    jsConsole.writeLine('Your point is inside the circle and out of the rectangle: ' + isInside);
}