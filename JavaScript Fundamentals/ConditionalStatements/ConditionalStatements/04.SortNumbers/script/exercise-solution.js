// 04. Sort 3 real values in descending order using nested if statements.
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = sortNumbers;

function sortNumbers() {
    var firstNumber = jsConsole.readFloat('#first-number');
    var secondNumber = jsConsole.readFloat('#second-number');
    var thirdNumber = jsConsole.readFloat('#third-number');

    if (firstNumber <= secondNumber && firstNumber <= thirdNumber && secondNumber <= thirdNumber) {
        jsConsole.writeLine('Your numbers sorted in descending order: ' + thirdNumber + ' ' + secondNumber + ' ' + firstNumber);
    } else if (firstNumber <= secondNumber && firstNumber <= thirdNumber && secondNumber >= thirdNumber) {
        jsConsole.writeLine('Your numbers sorted in descending order: ' + secondNumber + ' ' + thirdNumber + ' ' + firstNumber);
    } else if (firstNumber >= secondNumber && firstNumber <= thirdNumber && secondNumber <= thirdNumber) {
        jsConsole.writeLine('Your numbers sorted in descending order: ' + thirdNumber + ' ' + firstNumber + ' ' + secondNumber);
    } else if (firstNumber <= secondNumber && firstNumber >= thirdNumber && secondNumber >= thirdNumber) {
        jsConsole.writeLine('Your numbers sorted in descending order: ' + secondNumber + ' ' + firstNumber + ' ' + thirdNumber);
    } else if (firstNumber >= secondNumber && firstNumber >= thirdNumber && secondNumber <= thirdNumber) {
        jsConsole.writeLine('Your numbers sorted in descending order: ' + firstNumber + ' ' + thirdNumber + ' ' + secondNumber);
    } else {
        jsConsole.writeLine('Your numbers sorted in descending order: ' + firstNumber + ' ' + secondNumber + ' ' + thirdNumber);
    }
}