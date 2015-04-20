// 08. Write a script that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
// 0 -> 'Zero'
// 273 -> 'Two hundred seventy three' ?
// 400 -> 'Four hundred'
// 501 -> 'Five hundred and one'
// 711 -> 'Seven hundred and eleven'
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = displayNumberAsWord;

function displayNumberAsWord(){
    var numberAsString = jsConsole.readInteger('#input-number');
    var number = parseInt(numberAsString, 10);
    var numberAsWord = '';

    if (number > 99) {
        var hundred = (number / 100) | 0;
        numberAsWord += getHundred(hundred) + ' hundred ';
        number = number % 100;

        if (number < 20 && number !== 0) {
            numberAsWord += ' and ';
            numberAsWord += getTenths(number);
        }

        if (number >= 20 && number <= 99) {
            var tenths = (number / 10) | 0;
            numberAsWord += getTenthsSecond(tenths);

            number = number % 10;
            if (number > 0 && number <= 9) {
                numberAsWord += getTenths(number);
            }
        }

        jsConsole.writeLine(numberAsWord);

    } else if (number <= 99) {
        if (number < 20 && number > 0) {
            numberAsWord += getTenths(number);
        }

        if (number >= 20) {
            var tenths = (number / 10) | 0;
            numberAsWord += getTenthsSecond(tenths) + ' ';

            number = number % 10;
            if (number > 0 && number <= 9) {
                numberAsWord += getTenths(number);
            }
        }

        jsConsole.writeLine(numberAsWord);

    } else {
        numberAsWord += getTenths(number);
        jsConsole.writeLine(numberAsWord);
    }
}

function getHundred(number) {
    switch (number) {
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
    }
}

function getTenths(number) {
    switch (number) {
        case 1:
        case 2:
        case 3:
        case 4:
        case 5:
        case 6:
        case 7:
        case 8:
        case 9:
            return getHundred(number);
        case 10:
            return 'Ten';
        case 11:
            return 'Eleven';
        case 12:
            return 'Twelve';
        case 13:
            return 'Thirteen';
        case 14:
            return 'Fourteen';
        case 15:
            return 'Fifteen';
        case 16:
            return 'Sixteen';
        case 17:
            return 'Seventeen';
        case 18:
            return 'Eighteen';
        case 19:
            return 'Nineteen';
    }
}

function getTenthsSecond(number) {
    switch (number) {
        case 2:
            return 'Twenty ';
        case 3:
            return 'Thirty ';
        case 4:
            return 'Forty ';
        case 5:
            return 'Fifty ';
        case 6:
            return 'Sixty ';
        case 7:
            return 'Seventy ';
        case 8:
            return 'Eighty ';
        case 9:
            return 'Ninety ';
    }
}