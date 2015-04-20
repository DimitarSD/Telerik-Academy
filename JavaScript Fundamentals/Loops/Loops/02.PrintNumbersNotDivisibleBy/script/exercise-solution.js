// 02. Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = printNumbers;

function printNumbers() {
    var number = jsConsole.readInteger('#input-number');

    jsConsole.writeLine('All numbers from 1 to ' + number + ' that are not divisible by 3 and 7 at the same time');

    for (var i = 1; i <= number; i++) {
        if (i % 3 !== 0 && i % 7 !== 0) {
            jsConsole.writeLine(i);
        }
    }
}