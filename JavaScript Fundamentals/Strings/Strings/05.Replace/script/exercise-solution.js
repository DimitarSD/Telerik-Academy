// 06. Write a function that replaces non breaking white-spaces in a text with &nbsp;
var jsConsole;
var replaceButton = document.getElementById('replace-spaces');

replaceButton.onclick = displayResult;

function replace() {
    var text = jsConsole.read('#input-text');
    var result = '';

    for (var i = 0; i < text.length; i+=1) {
        if (text.substr(i, 1) === ' ') {
            result += '&nbsp;';
        } else {
            result += text.substr(i, 1);
        }
    }

    return result;
}

function displayResult() {
    var s = replace();
    jsConsole.writeLine(s.htmlEscape());
}