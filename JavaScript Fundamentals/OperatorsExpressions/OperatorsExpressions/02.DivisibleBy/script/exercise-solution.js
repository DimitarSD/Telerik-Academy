// 2. Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = isDivisible;

function isDivisible() {
    var number = jsConsole.readInteger('#input-number');

    if (number % 3 === 0 && number % 7 === 0) {
        jsConsole.writeLine('Your number is divisible by 7 and 3 at the same time')
    } else {
        jsConsole.writeLine('Your number is not disivible by 7 and 3 at the same time');
    }
}