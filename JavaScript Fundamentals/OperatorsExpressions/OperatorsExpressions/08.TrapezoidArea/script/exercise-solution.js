// 08. Write an expression that calculates trapezoid's area by given sides a and b and height h.
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = calculateArea;

function calculateArea() {
    var sideA = jsConsole.readFloat('#side-a');
    var sideB = jsConsole.readFloat('#side-b');
    var height = jsConsole.readFloat('#height');

    var area = ((sideA + sideB) / 2) * height;

    jsConsole.writeLine('Trapezoid area is: ' + area);
}