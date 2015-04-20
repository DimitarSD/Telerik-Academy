// 06. Write a script that enters the coefficients a, b and c of a quadratic equation
// a*x2 + b*x + c = 0
// and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = calculate;

function calculate() {
    var a = jsConsole.readFloat('#coefficient-a');
    var b = jsConsole.readFloat('#coefficient-b');
    var c = jsConsole.readFloat('#coefficient-c');

    var discriminant = (b * b) - (4 * a * c);

    if (discriminant === 0) {
        var rootOne = (-b - Math.sqrt(discriminant)) / (2 * a);
        var rootTwo = (-b + Math.sqrt(discriminant)) / (2 * a);

        jsConsole.writeLine('You have two real equal roots: ' + rootOne + ' and ' + rootTwo);
    } else if (discriminant > 0) {
        var rootOne = (-b - Math.sqrt(discriminant)) / (2 * a);
        var rootTwo = (-b + Math.sqrt(discriminant)) / (2 * a);

        jsConsole.writeLine('You have two real differents roots: ' + rootOne + ' and ' + rootTwo);
    } else {
        jsConsole.writeLine('There isn\'t roots in real numbers.');
    }

}