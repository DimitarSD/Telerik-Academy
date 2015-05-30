// 11. Write a function that formats a string using placeholders.
// The function should work with up to 30 placeholders and all types
var jsConsole;

function stringFormat(string) {
    var args = [];
    for (var arg in arguments) {
        args.push(arguments[arg])
    }

    args.shift();
    var result = '';
    for (var i = 0; i < args.length; i++) {
        string = string.replace(new RegExp('\\{' + i + '\\}', "g"), args[i])
    }

    return string;
}

var firstString = stringFormat('Hello {0}!', 'Peter');
jsConsole.writeLine(firstString);

var frmt = '{0}, {1}, {0} text {2}';
var secondString = stringFormat(frmt, 1, 'Pesho', 'Gosho');
jsConsole.writeLine(secondString);
