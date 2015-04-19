// 07. Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = isPrime;

function isPrime() {
    var number = jsConsole.readInteger('#input-number');

    var prime = true;

    if (number === 1 || number === 0) {
        prime = false;
    }

    for (var i = 2; i < number; i+=1) {

        if ((number % i) === 0) {
            prime = false;
        }
    }

    jsConsole.writeLine('Your number is prime: ' + prime);
}