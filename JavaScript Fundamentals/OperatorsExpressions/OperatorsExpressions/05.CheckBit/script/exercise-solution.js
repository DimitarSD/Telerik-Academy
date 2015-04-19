// 05. Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = checkBit;

function checkBit() {
    var number = jsConsole.readInteger('#input-number');
    var binary = number.toString(2);

    var mask = 1 << 3;
    var result = number & mask;
    var bit = result >> 3;

    jsConsole.writeLine('Your number is binary: ' + binary);
    jsConsole.writeLine('The bit at position 3 is: ' + bit);
}