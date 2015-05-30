// 02. Write a script that compares two char arrays lexicographically (letter by letter).
var jsConsole;

var firstCharArray = ['H', 'e', 'l', 'l', 'o', 'r'];
var secondCharArray = ['a', 'c', 'l', 'd', 'o', 'n', 'y'];

for (var i = 0; i < firstCharArray.length; i++) {
    for (var j = 0; j < secondCharArray.length; j++) {
        if (firstCharArray[i] === secondCharArray[j]) {
            jsConsole.writeLine(firstCharArray[i] + ' === ' + secondCharArray[j]);
        } else {
            jsConsole.writeLine(firstCharArray[i] + ' !== ' + secondCharArray[j]);
        }
    }
}