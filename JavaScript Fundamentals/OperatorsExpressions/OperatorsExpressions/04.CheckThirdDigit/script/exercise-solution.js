// 4. Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = checkForDigit;

function checkForDigit() {
    var number = jsConsole.readInteger('#input-number');
    var digit = parseInt(number / 100) % 10;

    if (digit === 7) {
        jsConsole.writeLine('Third digit of your number is 7: ' + number);
    } else {
        jsConsole.writeLine('Third digit of your number is not 7 it is ' + digit);
    }
}

