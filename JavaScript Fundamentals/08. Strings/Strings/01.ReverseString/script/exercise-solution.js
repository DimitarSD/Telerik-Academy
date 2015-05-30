// 01. Write a JavaScript function reverses string and returns itExample: "sample" -> "elpmas".
var jsConsole;
var reverseButton = document.getElementById('reverse');

reverseButton.onclick = reverse;

function reverse() {
    var input = jsConsole.read('#input-text');
    var reversedInput = input.split('').reverse().join('');

    jsConsole.writeLine(reversedInput);
}