// 04. Write a script that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.
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
    var maxCounter = Number.MIN_VALUE;
    var bestStart = 0;

    for (var i = 0; i < sequenceOfNumbers.length - 1; i++) {
        if (sequenceOfNumbers[i] * 1 < sequenceOfNumbers[i + 1] * 1) {
            counter++;
        } else if (sequenceOfNumbers[i] * 1 > sequenceOfNumbers[i + 1] * 1) {
            if (counter > maxCounter) {
                maxCounter = counter;
                counter = 1;
                bestStart = i - maxCounter + 1;
            }

            counter = 1;
        }
    }

    if (counter > maxCounter) {
        maxCounter = counter;
        bestStart = i - maxCounter + 1;
    }

    printSequence(bestStart, maxCounter, sequenceOfNumbers);
}

function printSequence(bestStart, maxCounter, sequenceOfNumbers) {
    for (var i = bestStart; i < bestStart + maxCounter; i++) {
        jsConsole.write(sequenceOfNumbers[i]);

        if (i !== (bestStart + maxCounter - 1)) {
            jsConsole.write(', ');
        }
    }

    jsConsole.writeLine();
}