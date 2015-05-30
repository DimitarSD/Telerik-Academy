// 07. Write a function that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.
// Use the function from the previous exercise.
var jsConsole;

function checkIsBigger(array, position) {
    var isLarger;

    if (position === 0) {
        isLarger = false;
    }
    else if (position === array.Length - 1) {
        isLarger = false;
    }
    else {
        isLarger = (array[position] > array[position - 1] && array[position] > array[position + 1]);
    }

    return isLarger;
}

var counter = 0;
var array = [25, 91, 56, 56, 100, 50, 80, 53, 48, 24, 21, 84, 76, 3, 84, 25, 71, 26, 34];

jsConsole.writeLine('Array: ' + array.join(', '));

for (var i = 0; i < array.length; i++) {
    if (array, i) {
        jsConsole.writeLine('The index of the first element in the array that is larger than its neighbours is ' + i);
        counter += 1;
        break;
    }
}

if (counter === 0) {
    jsConsole.writeLine(-1);
}