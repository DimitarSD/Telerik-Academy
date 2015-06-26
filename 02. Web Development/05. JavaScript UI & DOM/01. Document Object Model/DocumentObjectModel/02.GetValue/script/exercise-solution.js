// 02. Create a function that gets the value of <input type="text"> ands prints its value to the console
var jsConsole;
var extractButton = document.getElementById('extract-value');

extractButton.onclick = function () {
    var input = document.getElementById('input-text');
    var text = input.value;
    jsConsole.writeLine(text);
}
