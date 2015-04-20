// 02. Write a function that reverses the digits of given decimal number. Example: 256 -> 652
var jsConsole;
var reverseButton = document.getElementById('reverse');

reverseButton.onclick = reverseNumber;

function reverseNumber() {
    var number = jsConsole.read('#input-number');
    var reversedNumber = number.split('').reverse().join('');
    
    jsConsole.writeLine(reversedNumber);
}