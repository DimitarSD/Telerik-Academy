// 02. Write a JavaScript function to check if in a given expression the brackets are put correctly.
// Example of correct expression: ((a+b)/5-d).
// Example of incorrect expression: )(a+b)).
var jsConsole;
var checkButton = document.getElementById('check');

checkButton.onclick = displayResult;

function splitInput() {
    var expression = jsConsole.read('#input-text');
    var array = expression.split('');
    return array;
}

function checkExpression() {
    var expression = splitInput();
    var bracketsCounter = 0;

    for (var i = 0; i < expression.length; i++) {
        if (expression[i] === '(') {
            bracketsCounter += 1;
        } else if (expression[i] === ')') {
            bracketsCounter -= 1;
        }

        if (bracketsCounter < 0) {
            return false;
        }
    }

    return true;
}

function displayResult() {
    var result = checkExpression();

    if (result) {
        jsConsole.writeLine('The expression is correct.')
    } else {
        jsConsole.writeLine('The expression is incorrect');
    }
}