// 01. Write a script that prints all the numbers from 1 to N
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = printNumbers;

function printNumbers() {
    var number = jsConsole.readInteger('#input-number');

    for (var i = 1; i <= number; i++) {
        jsConsole.writeLine(i);
    }
}
