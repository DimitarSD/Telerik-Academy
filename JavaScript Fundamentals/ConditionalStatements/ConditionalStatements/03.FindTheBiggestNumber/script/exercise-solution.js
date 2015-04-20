// 03. Write a script that finds the biggest of three integers using nested if statements.
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = findBiggestNumber;

function findBiggestNumber() {
    var firstNumber = jsConsole.readInteger('#first-number');
    var secondNumber = jsConsole.readInteger('#second-number');
    var thirdNumber = jsConsole.readInteger('#third-number');

    if (firstNumber === secondNumber && firstNumber === thirdNumber) {
        jsConsole.writeLine('The biggest number is: ' + firstNumber);
    }
    else if (firstNumber < secondNumber && secondNumber > thirdNumber) {
        jsConsole.writeLine('The biggest number is: ' + secondNumber);
    }
    else if (firstNumber < thirdNumber && thirdNumber > secondNumber) {
        jsConsole.writeLine('The biggest number is: ' + thirdNumber);
    }
    else if (firstNumber > secondNumber && firstNumber > thirdNumber) {
        jsConsole.writeLine('The biggest number is: ' + firstNumber);
    } else {
        jsConsole.writeLine('You have equal numbers. I can\'t give you an answer.');
    }
}