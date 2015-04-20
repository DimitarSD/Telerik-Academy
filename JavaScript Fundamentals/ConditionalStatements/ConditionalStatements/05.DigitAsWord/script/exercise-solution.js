// 05. Write script that asks for a digit and depending on the input shows the name of that digit (in English) using a switch statement.
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = displayDigitAsWord;

function displayDigitAsWord() {
    var number = jsConsole.readInteger('#input-number');

    switch (number) {
        case 0:
            jsConsole.writeLine('Zero');
            break;
        case 1:
            jsConsole.writeLine('One');
            break;
        case 2:
            jsConsole.writeLine('Two');
            break;
        case 3:
            jsConsole.writeLine('Three');
            break;
        case 4:
            jsConsole.writeLine('Four');
            break;
        case 5:
            jsConsole.writeLine('Five');
            break;
        case 6:
            jsConsole.writeLine('Six');
            break;
        case 7:
            jsConsole.writeLine('Seven');
            break;
        case 8:
            jsConsole.writeLine('Eight');
            break;
        case 9:
            jsConsole.writeLine('Nine');
            break;
        default:
            jsConsole.writeLine('Not a digit');
    }
}