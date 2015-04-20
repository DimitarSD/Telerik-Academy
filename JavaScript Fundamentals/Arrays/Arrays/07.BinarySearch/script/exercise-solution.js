// 07. Write a program that finds the index of given element in a sorted array of integers 
// by using the binary search algorithm (find it in Wikipedia).
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = getIndex;
var sequenceOfNumbers = [9, 12, 13, 25, 29, 78, 99, 197, 299, 4155, 7899];

jsConsole.writeLine('Please choose a number.');
jsConsole.writeLine('The sequence: ');
jsConsole.writeLine(sequenceOfNumbers.join(', '));

function getIndex() {
    var element = jsConsole.readInteger('#input-element');
    var min = 0;
    var max = sequenceOfNumbers.length - 1;

    var index = binarySearch(sequenceOfNumbers, element, min, max);

    if (index === -1) {
        jsConsole.writeLine('Your element doesn\'t exist in the sequence');
    } else {
        jsConsole.writeLine('The index of your element is: ' + index);
    }
}

function binarySearch(sequenceOfNumbers, element, min, max) {
    while (max >= min) {
        var middle = (min + max) / 2 | 0;

        if (sequenceOfNumbers[middle] * 1 === element) {
            return middle;
        } else if (sequenceOfNumbers[middle] * 1 < element) {
            min = middle + 1;
        } else {
            max = middle - 1;
        }
    }

    var defaultValue = -1;
    return defaultValue;
}
