// 06. Write a function that checks if the element at given position in given array of integers is bigger than 
// its two neighbors (when such exist).
var jsConsole;

function checkIsBigger(array, position) {
    var isLarger;

    if (position === 0)
    {
        isLarger = false;
    }
    else if (position === array.Length - 1)
    {
        isLarger = false;
    }
    else
    {
        isLarger = (array[position] > array[position - 1] && array[position] > array[position + 1]);
    }

    return isLarger;
}

var array = [25, 91, 56, 56, 100, 50, 80, 53, 48, 24, 21, 84, 76, 3, 84, 25, 71, 26, 34];
var position = 13;

jsConsole.writeLine('Array of numbers: ');
jsConsole.writeLine(array.join(', '));

jsConsole.writeLine('Position: ' + position);

jsConsole.writeLine('The element at position ' + position + ' in the array is bigger than its two neighbors: ' + checkIsBigger(array, position));