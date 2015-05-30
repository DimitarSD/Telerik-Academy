// 03. Write a JavaScript function that finds how many times a substring is contained in a given text (perform case insensitive search).
var jsConsole;
var searchButton = document.getElementById('search');

searchButton.onclick = displayResult;

function substringCounter() {
    var text = jsConsole.read('#input-text');
    var searchedSubstring = jsConsole.read('#searched-word');
    var counter = 0;

    for (var i = 0; i <= text.length - searchedSubstring.length; i+=1) {
        var substring = text.substr(i, searchedSubstring.length);
        if (searchedSubstring.toLowerCase() === substring.toLowerCase()) {
            counter += 1;
        }
    }

    return counter;
}

function displayResult() {
    var result = substringCounter();
    jsConsole.writeLine(result);
}