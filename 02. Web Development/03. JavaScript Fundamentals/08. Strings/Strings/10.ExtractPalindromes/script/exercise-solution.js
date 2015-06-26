// 10. Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
var jsConsole;
var extractButton = document.getElementById('extract-palindromes');

extractButton.onclick = displayAllPalindromes;

function extractPalindromes() {
    var text = jsConsole.read('#input-text');
    var words = text.split(/\W+/);
    var palindromes = [];

    for (var i = 0; i < words.length; i+=1) {
        if (words[i] === words[i].split('').reverse().join('') && words[i].length > 2) {
            palindromes.push(words[i])
        }
    }

    return palindromes;
}

function displayAllPalindromes() {
    var palindromes = extractPalindromes();
    jsConsole.writeLine(palindromes.join(', '))
}