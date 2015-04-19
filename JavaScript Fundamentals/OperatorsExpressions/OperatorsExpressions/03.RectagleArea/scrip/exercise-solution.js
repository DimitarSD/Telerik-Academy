// 3. Write an expression that calculates rectangle’s area by given width and height.
var jsConsole;
var testButton = document.getElementById('start');

testButton.onclick = calculateArea;

function calculateArea() {
    var width = jsConsole.readFloat('#width');
    var height = jsConsole.readFloat('#height');

    var area = width * height;
    jsConsole.writeLine('The area is: ' + area);
}