// 1. Write an if statement that examines two integer variables and exchanges their values 
// if the first one is greater than the second one.
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = exchangeValues;

function exchangeValues() {
    var firstNumber = jsConsole.readInteger('#first-number');
    var secondNumber = jsConsole.readInteger('#second-number');

    jsConsole.writeLine('Your numbers are ' + firstNumber + ' and ' + secondNumber);

    if (firstNumber > secondNumber) {
        var temp = firstNumber;
        firstNumber = secondNumber;
        secondNumber = temp;
    }

    jsConsole.writeLine('First number: ' + firstNumber);
    jsConsole.writeLine('Second number: ' + secondNumber);
}