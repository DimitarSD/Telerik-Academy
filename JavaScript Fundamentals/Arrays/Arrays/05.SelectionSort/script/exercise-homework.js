// 05. Sorting an array means to arrange its elements in increasing order. Write a script to sort an array.
// Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, 
// move it at the second position, etc.Hint: Use a second array
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = sortNumbers;

function getNumbers() {
    var sequence = jsConsole.read('#input-sequence');
    var numbers = sequence.split(',');
    return numbers;
}

function sortNumbers() {
    var sequenceOfNumbers = getNumbers();

    jsConsole.writeLine('Your sequense before the sort:');
    jsConsole.writeLine(sequenceOfNumbers.join(', '));

    for (var i = 0; i < sequenceOfNumbers.length - 1; i++) {
        for (var j = i + 1; j < sequenceOfNumbers.length; j++) {
            if (sequenceOfNumbers[i] > sequenceOfNumbers[j]) {
                var temp = sequenceOfNumbers[i];
                sequenceOfNumbers[i] = sequenceOfNumbers[j];
                sequenceOfNumbers[j] = temp;
            }
        }
    }

    jsConsole.writeLine('Your sequense after the sort:');
    jsConsole.writeLine(sequenceOfNumbers.join(', '));
}
