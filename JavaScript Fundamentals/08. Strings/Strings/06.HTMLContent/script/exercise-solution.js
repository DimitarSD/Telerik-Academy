// 06. Write a function that extracts the content of a html page given as text. 
// function should return anything that is in a tag, without the tags:
var jsConsole;
var extractButton = document.getElementById('extract-content');

extractButton.onclick = displayResult;

function extractContent() {
    var text = jsConsole.read('#input-text');
    var result = '';

    var isOutState = true;
    var inTagCounter = 0;

    for (var i = 0; i < text.length; i+=1) {
        if (text.substr(i, 1) === '<') {
            isOutState = false;
        }

        if (text.substr(i, 1) === '>' && text.substr(i + 1, 1) !== '<') {
            isOutState = true;
            i += 1
        }

        if (isOutState) {
            result += text.substr(i, 1);
        }
    }

    return result;
}

function displayResult() {
    jsConsole.writeLine(extractContent());
}