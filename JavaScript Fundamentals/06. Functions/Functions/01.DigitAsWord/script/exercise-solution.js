﻿// 01. Write a function that returns the last digit of given integer as an English word. Examples: 512 -> "two", 1024  "four", 12309 -> "nine"
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = displayDigitAsWord;

function getDigit() {
    var number = jsConsole.readInteger('#input-number');
    return number % 10;
}

function getDigitAsWord() {
    var number = getDigit();

    switch (number) {
        case 0:
            return 'Zero';
        case 1:
            return 'One';
        case 2:
            return 'Two';
        case 3:
            return 'Three';
        case 4:
            return 'Four';
        case 5:
            return 'Five';
        case 6:
            return 'Six';
        case 7:
            return 'Seven';
        case 8:
            return 'Eight';
        case 9:
            return 'Nine';
        default:
            return 'Not a digit';
    }
}

function displayDigitAsWord() {
    jsConsole.writeLine(getDigitAsWord());
}

var clearButton = document.getElementById('clear');

clearButton.onclick = function clear() {
    jsConsole.clearConsole();
}