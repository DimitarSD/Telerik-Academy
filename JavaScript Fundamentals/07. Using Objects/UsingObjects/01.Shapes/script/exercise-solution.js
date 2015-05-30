// 01. Write functions for working with shapes in  standard Planar coordinate system
// Points are represented by coordinates P(X, Y)
// Lines are represented by two points, marking their beginning and ending
// L(P1(X1,Y1), P2(X2,Y2))
// Calculate the distance between two points
// Check if three segment lines can form a triangle
var jsConsole;

function point(x, y) {
    this.coodinatesX = x;
    this.coodinatesY = y;
    this.toString = function () {
        return '(' + this.coodinatesX + ', ' + this.coodinatesY + ')';
    }
}

function line(firstPoint, secondPoint) {
    this.start = firstPoint;
    this.end = secondPoint
    this.toString = function () {
        return '((' + this.start.coodinatesX + ', ' + this.start.coodinatesY + '), (' + this.end.coodinatesX + ', ' + this.end.coodinatesY + '))';
    }

    this.length = calculateDistance(firstPoint, secondPoint);
}

function calculateDistance(startPoint, endPoint) {
    return Math.sqrt(Math.pow(startPoint.coodinatesX - endPoint.coodinatesX, 2) + Math.pow(startPoint.coodinatesY - endPoint.coodinatesY, 2));
}

function canFormTriangle(firstLine, secondLine, thirdLine) {
    return firstLine.length < secondLine.length + thirdLine.length &&
           secondLine.length < firstLine.length + thirdLine.length &&
           thirdLine.length < firstLine.length + secondLine.length;
}

var pointOne = new point(3, 4);
var pointTwo = new point(1, 1);
var pointThree = new point(9, 7);
var pointFour = new point(4, 6);
var pointFive = new point(8, 1);

jsConsole.writeLine('First point: ' + pointOne.toString());
jsConsole.writeLine('Second point: ' + pointTwo.toString());
jsConsole.writeLine('Third point: ' + pointThree.toString());
jsConsole.writeLine('Forth point: ' + pointFour.toString());
jsConsole.writeLine('Fifth point: ' + pointFive.toString());

var lineOne = new line(pointFive, pointOne);
var lineTwo = new line(pointThree, pointFour);
var lineThree = new line(pointOne, pointTwo);

jsConsole.writeLine();
jsConsole.writeLine('First line: ' + lineOne);
jsConsole.writeLine('Second line: ' + lineTwo);
jsConsole.writeLine('Third line: ' + lineThree);

jsConsole.writeLine('The lines can form a triangle: ' + canFormTriangle(lineOne, lineTwo, lineThree));