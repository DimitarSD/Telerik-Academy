// 03. Write a function that finds all the occurrences of word in a text
// The search can case sensitive or case insensitive
// Use function overloading
var jsConsole;
var checkButton = document.getElementById('check');

checkButton.onclick = getNumberOfOccurrences;

function getWords() {
    var text = jsConsole.read('#input-text');
    var words = text.split(/\W+/);
    return words;
}

function getNumberOfOccurrences() {
    var searchedWord = jsConsole.read('#input-word');
    var arrayOfWords = getWords();

    var counter = 0;

    for (var i = 0; i < arrayOfWords.length; i+=1) {
        if (searchedWord === arrayOfWords[i]) {
            counter += 1;
        }
    }

    jsConsole.writeLine(counter);
}