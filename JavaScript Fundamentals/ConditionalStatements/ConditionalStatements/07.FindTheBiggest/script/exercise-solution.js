// 07. Write a script that finds the greatest of given 5 variables.
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = findTheBiggest;

function findTheBiggest() {
    var firstNumber = jsConsole.readFloat('#first-number');
    var secondNumber = jsConsole.readFloat('#second-number');
    var thirdNumber = jsConsole.readFloat('#third-number');
    var fourthNumber = jsConsole.readFloat('#fourth-number');
    var fifthNumber = jsConsole.readFloat('#fifth-number');

    var numbers = [firstNumber, secondNumber, thirdNumber, fourthNumber, fifthNumber];

    var max = numbers[0];
    for (var i = 0; i < numbers.length; i++) {
        if (max < numbers[i]) {
            max = numbers[i];
        }
    }

    jsConsole.writeLine('The biggest number is: ' + max);
}