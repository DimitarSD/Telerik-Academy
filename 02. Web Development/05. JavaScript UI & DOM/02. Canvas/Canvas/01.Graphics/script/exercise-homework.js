// 01. Draw the following graphics using canvas.

var canvas = document.getElementById('the-canvas');
var ctx = canvas.getContext('2d');

// Person
ctx.save();
ctx.beginPath();
ctx.scale(1.1, 1);
ctx.arc(200, 150, 60, 0, 2 * Math.PI);
ctx.fillStyle = '#90CAD7';
ctx.strokeStyle = '#396693';
ctx.lineWidth = 2;
ctx.fill();
ctx.stroke();

ctx.beginPath();
ctx.scale(5, 1);
ctx.arc(40, 100, 13, 0, 360 * Math.PI / 180);
ctx.fillStyle = '#396693';
ctx.strokeStyle = 'black';
ctx.lineWidth = 1;
ctx.fill();
ctx.stroke();

ctx.beginPath();
ctx.restore();
ctx.fillStyle = '#396693';
ctx.lineWidth = 2;
ctx.fillRect(185, 10, 70, 80);
ctx.strokeRect(185, 10, 70, 80);

ctx.beginPath();
ctx.save();
ctx.scale(5, 1);
ctx.lineWidth = 1;
ctx.arc(44, 89, 7, 0, Math.PI);
ctx.fill();
ctx.stroke();

ctx.beginPath();
ctx.arc(44, 10, 7, 0, 2 * Math.PI);
ctx.stroke();
ctx.fill();
ctx.restore();

ctx.beginPath();
ctx.save();
ctx.scale(1.5, 1);
ctx.arc(120, 135, 8, 0, 2 * Math.PI);
ctx.strokeStyle = '#396693';
ctx.stroke();

ctx.beginPath();
ctx.arc(155, 135, 8, 0, 2 * Math.PI);
ctx.strokeStyle = '#396693';
ctx.stroke();

ctx.beginPath();
ctx.scale(1, 2.1);
ctx.arc(117, 64, 3, 0, 2 * Math.PI);
ctx.fill();

ctx.beginPath();
ctx.arc(152, 64, 3, 0, 2 * Math.PI);
ctx.fill();

ctx.beginPath();
ctx.restore();
ctx.save();
ctx.rotate(10 * Math.PI / 180);
ctx.scale(3, 1);
ctx.lineWidth = 1;
ctx.arc(77, 145, 8, 0, 2 * Math.PI);
ctx.strokeStyle = '#396693';
ctx.stroke();
ctx.restore();

ctx.beginPath();
ctx.strokeStyle = '#396693';
ctx.moveTo(205, 137);
ctx.lineTo(192, 163);
ctx.lineTo(205, 163);
ctx.stroke();
ctx.closePath();

// House
var fillColor = '#975b5b';
ctx.strokeStyle = 'black';
ctx.fillStyle = fillColor;
ctx.fillRect(600, 200, 280, 220);
ctx.strokeRect(600, 200, 280, 220);

// roof
ctx.beginPath();
ctx.moveTo(600, 199);
ctx.lineTo(740, 40);
ctx.lineTo(880, 199);
ctx.fill();
ctx.stroke();
ctx.closePath();

// windows
ctx.fillStyle = 'black';
ctx.fillRect(620, 230, 50, 30);
ctx.fillRect(675, 230, 50, 30);
ctx.fillRect(755, 230, 50, 30);
ctx.fillRect(810, 230, 50, 30);
ctx.fillRect(620, 265, 50, 30);
ctx.fillRect(675, 265, 50, 30);
ctx.fillRect(755, 265, 50, 30);
ctx.fillRect(810, 265, 50, 30);
ctx.fillRect(755, 330, 50, 30);
ctx.fillRect(810, 330, 50, 30);
ctx.fillRect(755, 365, 50, 30);
ctx.fillRect(810, 365, 50, 30);

// door
ctx.beginPath();
ctx.moveTo(670, 330);
ctx.lineTo(670, 420);
ctx.stroke();
ctx.closePath();

ctx.beginPath();
ctx.arc(660, 395, 4, 0, 2 * Math.PI);
ctx.stroke();

ctx.beginPath();
ctx.arc(680, 395, 4, 0, 2 * Math.PI);
ctx.stroke();
ctx.closePath();
ctx.save();

ctx.beginPath();
ctx.scale(2, 1);
ctx.lineWidth = 1;
ctx.arc(335, 350, 20, 0, Math.PI, true);
ctx.stroke();
ctx.restore();

ctx.beginPath();
ctx.moveTo(630, 350);
ctx.lineTo(630, 420);
ctx.stroke();

ctx.beginPath();
ctx.moveTo(710, 350);
ctx.lineTo(710, 420);
ctx.stroke();
ctx.closePath();

//chimney
ctx.beginPath();
ctx.moveTo(800, 160);
ctx.lineTo(800, 80);
ctx.lineTo(830, 80);
ctx.lineTo(830, 160);
ctx.fillStyle = fillColor;
ctx.fill();
ctx.stroke();

ctx.beginPath();
ctx.save();
ctx.scale(2.9, 1);
ctx.arc(281, 80, 5, 0, 2 * Math.PI);
ctx.lineWidth = 1;
ctx.fill();
ctx.stroke();
ctx.restore();

// Bike
ctx.fillStyle = 'lightblue';
ctx.strokeStyle = '#37889C';
ctx.beginPath();
ctx.arc(150, 500, 60, 0, 2 * Math.PI);
ctx.fill();
ctx.stroke();

ctx.beginPath();
ctx.arc(380, 500, 60, 0, 2 * Math.PI);
ctx.fill();
ctx.stroke();

ctx.beginPath();
ctx.moveTo(150, 500);
ctx.lineTo(250, 495);
ctx.lineTo(360, 425);
ctx.lineTo(380, 500);
ctx.lineTo(349, 385);
ctx.lineTo(379, 345);
ctx.lineTo(349, 385);
ctx.lineTo(300, 405);
ctx.lineTo(349, 385);
ctx.lineTo(360, 425);
ctx.lineTo(220, 425);
ctx.closePath();
ctx.stroke();

ctx.beginPath();
ctx.moveTo(250, 495);
ctx.lineTo(200, 395);
ctx.lineTo(230, 395);
ctx.lineTo(170, 395);
ctx.stroke();

ctx.beginPath();
ctx.arc(250, 495, 17, 0, 2 * Math.PI);
ctx.stroke();

ctx.beginPath();
ctx.moveTo(260, 510);
ctx.lineTo(270, 520);
ctx.stroke();

ctx.beginPath();
ctx.moveTo(238, 482);
ctx.lineTo(228, 470);
ctx.stroke();