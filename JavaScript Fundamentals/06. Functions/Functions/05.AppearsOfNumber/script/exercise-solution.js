// 05. Write a function that counts how many times given number appears in given array. 
// Write a test function to check if the function is working correctly.
var jsConsole;

function countAppereance(array, number) {
    var counter = 0;

    for (var i = 0; i < array.length; i++) {
        if (array[i] * 1 === number) {
            counter += 1;
        }
    }

    return counter;
}

function testFunction() {
    var array = [1, 7, 19, 8, 1, 1, 2, 9, 1, 7, 5, 1, 6, 8, 10, 7, 7, 10, 9, 9, 2, 4, 1, 3];
    var number = 1;

    jsConsole.writeLine(countAppereance(array, number));
}

testFunction();