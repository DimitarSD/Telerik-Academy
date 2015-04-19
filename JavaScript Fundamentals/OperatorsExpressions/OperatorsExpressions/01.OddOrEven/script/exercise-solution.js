// 1. Write an expression that checks if given integer is odd or even.
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = checkNumber;

function checkNumber() {
    var number = jsConsole.readInteger('#input-number');

    if (number % 2 === 0) {
        jsConsole.writeLine('Your number is even. -> ' + number);
    } else {
        jsConsole.writeLine('Your number is odd. -> ' + number);
    }
}