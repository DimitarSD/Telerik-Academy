// 03. Write a script that finds the max and min number from a sequence of numbers
var jsConsole;
var buttonMax = document.getElementById('find-max');
var buttonMin = document.getElementById('find-min');

buttonMax.onclick = findMaxNumber;
buttonMin.onclick = findMinNumber;

function getNumbers() {
    var sequence = jsConsole.read('#input-sequence');
    var numbers = sequence.split(',');
    return numbers;
}

function findMaxNumber() {
    var max = Number.MIN_VALUE;
    var sequenceOfNumbers = getNumbers();

    for (var i = 0; i < sequenceOfNumbers.length; i++) {
        if (max < sequenceOfNumbers[i] * 1) {
            max = sequenceOfNumbers[i] * 1;
        }
    }

    jsConsole.writeLine('The max number is: ' + max);
}

function findMinNumber() {
    var min = Number.MAX_VALUE;
    var sequenceOfNumbers = getNumbers();

    for (var i = 0; i < sequenceOfNumbers.length; i++) {
        if (min > sequenceOfNumbers[i] * 1) {
            min = sequenceOfNumbers[i] * 1;
        }
    }

    jsConsole.writeLine('The min number is: ' + min);
}