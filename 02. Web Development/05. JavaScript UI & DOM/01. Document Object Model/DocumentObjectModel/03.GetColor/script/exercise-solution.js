// 03. Crеate a function that gets the value of <input type="color"> and sets the background of the body to this value
var setColorButton = document.getElementById('set-color');

setColorButton.onclick = function () {
    var color = document.getElementById('input-text').value;

    document.body.style.backgroundColor = '#' + color;
};