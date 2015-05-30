// 04. Write a script that finds the lexicographically smallest and largest property in document, window and navigator objects
var jsConsole;

function smallestProperty(obj) {
    var firstProperty = true;

    for (var property in obj) {
        if (firstProperty) {
            var smallestProperty = property;
            firstProperty = false;
        }

        if (smallestProperty < property) {
            smallestProperty = property;
        }
    }

    jsConsole.writeLine(smallestProperty);
}

function largestProperty(obj) {
    var firstProperty = true;

    for (var property in obj) {
        if (firstProperty) {
            var largestProperty = property;
            firstProperty = false;
        }

        if (largestProperty > property) {
            largestProperty = property;
        }
    }

    jsConsole.writeLine(largestProperty);
}

var doc = document;
var win = window;
var nav = navigator

jsConsole.write('Document: largest -> ');
smallestProperty(doc);
jsConsole.write('Document: smallest -> ');
largestProperty(doc);

jsConsole.write('Window: largest -> ');
smallestProperty(win);
jsConsole.write('Window: smallest -> ');
largestProperty(win);

jsConsole.write('Navigator: largest -> ');
smallestProperty(nav);
jsConsole.write('Navigator: smallest -> ');
largestProperty(nav);