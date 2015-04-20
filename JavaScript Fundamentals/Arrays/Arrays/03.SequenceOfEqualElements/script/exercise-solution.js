// 03. Write a script that finds the maximal sequence of equal elements in an array.
// Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = findSequence;

function getNumbers() {
    var sequence = jsConsole.read('#input-sequence');
    var numbers = sequence.split(',');
    return numbers;
}

function findSequence() {
    var sequenceOfNumbers = getNumbers();

    var counter = 1;
    var currentElement;
    var currentMax = Number.MIN_VALUE;

    for (var i = 0; i < sequenceOfNumbers.length - 1; i++) {

        if ((sequenceOfNumbers[i] * 1) === (sequenceOfNumbers[i + 1] * 1)) {

            counter += 1;
            if (counter > currentMax) {
                currentMax = counter;
                currentElement = sequenceOfNumbers[i] * 1
            }
        } else {
            counter = 1;
        }
    }

    printSequence(currentElement, currentMax);
}

function printSequence(currentElement, currentMax) {
    jsConsole.writeLine('Maximal sequence of equal elements: ');

    for (var i = 0; i < currentMax; i++) {
        jsConsole.write(currentElement);

        if (i !== currentMax - 1) {
            jsConsole.write(', ');
        }
    }

    jsConsole.writeLine();
}