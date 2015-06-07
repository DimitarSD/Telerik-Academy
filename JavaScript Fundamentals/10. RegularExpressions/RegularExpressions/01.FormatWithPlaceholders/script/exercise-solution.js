// 01. Write a function that formats a string. The function should have placeholders, as shown in the example
// Add the function to the String.prototype

var jsConsole;

String.prototype.format = function (options) {
    return this.replace(/(?:#{(\w+)})/g, function ($0, $1) {
        return options[$1];
    });
};

var exampleOne = { name: 'John' };
jsConsole.writeLine('Hello, there! Are you #{name}?'.format(exampleOne));

var exampleTwo = { name: 'John', age: 13 };
jsConsole.writeLine('My name is #{name} and I am #{age}-years-old'.format(exampleTwo));