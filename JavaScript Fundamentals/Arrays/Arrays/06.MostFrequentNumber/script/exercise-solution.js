// 06. Write a program that finds the most frequent number in an array. Example:
// {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = findNumber;

function getNumbers() {
    var sequence = jsConsole.read('#input-sequence');
    var numbers = sequence.split(',');
    return numbers;
}

function findNumber() {
    var sequenceOfNumbers = getNumbers();

    var counter = 1;
    var maxCounter = Number.MIN_VALUE;
    var number;

    for (var i = 0; i < sequenceOfNumbers.length; i++) {
        for (var j = i + 1; j < sequenceOfNumbers.length; j++) {
            if (sequenceOfNumbers[i] * 1 === sequenceOfNumbers[j] * 1) {
                counter++;
            }

            if (counter > maxCounter) {
                maxCounter = counter;
                number = sequenceOfNumbers[i] * 1;
            }
        }

        counter = 0;
    }

    jsConsole.writeLine('The most frequent number is ' + number + ' (' + maxCounter + ' times)');
}