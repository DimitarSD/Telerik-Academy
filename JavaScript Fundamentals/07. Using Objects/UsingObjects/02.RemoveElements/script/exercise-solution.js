// 02. Write a function that removes all elements with a given value
// Attach it to the array type
// Read about prototype and how to attach methods
var jsConsole;
var removeButton = document.getElementById('remove');

removeButton.onclick = function () {
    var arr = getNumbers();
    var element = getElementToRemove();
    jsConsole.writeLine('Your sequence of elements: ' + arr);
    arr.remove(element);
    jsConsole.writeLine('Your sequence after removing the element: ' + arr);
}

function getNumbers() {
    var sequence = jsConsole.read('#input-sequence');
    var numbers = sequence.split(',');
    return numbers;
}

function getElementToRemove() {
    var elementToRemove = jsConsole.readInteger('#element-to-remove');
    return elementToRemove;
}

Array.prototype.remove = function(elementToRemove) {
    for (var i = this.length - 1; i >= 0; i-=1) {
        if (elementToRemove === this[i] * 1) {
            this.splice(i, 1);
        }
    }
}