// 02. Write a script that shows the sign (+ or -) of the product of 
// three real numbers without calculating it. Use a sequence of if statements.
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = showProductSign;

function showProductSign() {
    var firstNumber = jsConsole.readFloat('#first-number');
    var secondNumber = jsConsole.readFloat('#second-number');
    var thirdNumber = jsConsole.readFloat('#third-number');

    if (firstNumber === 0 || secondNumber === 0 || thirdNumber === 0) {
        jsConsole.writeLine('The product is 0.');
    }
    else if ((firstNumber > 0 && secondNumber > 0 && thirdNumber < 0) || (firstNumber > 0 && secondNumber < 0 && thirdNumber > 0) || (firstNumber < 0 && secondNumber > 0 && thirdNumber > 0)) {
        jsConsole.writeLine('The product is negative (Minus -).');
    }
    else if ((firstNumber > 0 && secondNumber < 0 && thirdNumber < 0) || (firstNumber < 0 && secondNumber < 0 && thirdNumber > 0) || (firstNumber < 0 && secondNumber > 0 && thirdNumber < 0)) {
        jsConsole.writeLine('The product is positive (Plus +)');
    }
    else if (firstNumber < 0 && secondNumber < 0 && thirdNumber < 0) {
        jsConsole.writeLine('The product is negative (Minus -)');
    }
    else if (firstNumber > 0 && secondNumber > 0 && thirdNumber > 0) {
        jsConsole.writeLine('The product is positive (Plus +)');
    }
}