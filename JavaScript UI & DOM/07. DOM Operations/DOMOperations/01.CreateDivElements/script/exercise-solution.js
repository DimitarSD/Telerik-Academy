// 01. Write a script that creates a number of div elements. Each div element must have the following
// Random width and height between 20px and 100px
// Random background color
// Random font color
// Random position on the screen (position:absolute)
// A strong element with text "div" inside the div
// Random border radius
// Random border color
// Random border width between 1px and 20px

;(function () {

    var createDivButton = document.getElementById('create-div');
    createDivButton.onclick = createDivElements;

    function randomWidth() {
        var width = Math.random() * 100 | 0;
        while (width < 20 || width > 100) {
            width = Math.random() * 100 | 0;
        }

        return width.toString() + 'px';
    }

    function randomHeight() {
        var height = Math.random() * 100 | 0;
        while (height < 20 || height > 100) {
            height = Math.random() * 100 | 0;
        }

        return height.toString() + 'px';
    }

    function randomColor() {
        var red = Math.random() * 256 | 0;
        var blue = Math.random() * 256 | 0;
        var green = Math.random() * 256 | 0;

        return 'rgb(' + red + ', ' + blue + ', ' + green + ')';
    }

    function randomPositionX() {
        var positionX = Math.random() * screen.width | 0;
        return positionX.toString() + 'px';
    }

    function randomPositionY() {
        var positionY = Math.random() * screen.height | 0;
        return positionY.toString() + 'px';
    }

    function createDivElements() {
        var input = document.getElementById('input-number').value;
        var count = parseInt(input);
                
        for (var i = 0; i < count; i++) {
            var div = document.createElement('div');
            var strong = document.createElement('strong');
            strong.innerHTML = 'div';
            div.appendChild(strong);
            div.style.width = randomWidth();
            div.style.height = randomHeight();
            div.style.backgroundColor = randomColor();
            div.style.color = randomColor();

            var positionX = 1 + Math.random() * 2 | 0;
            var positionY = 3 + Math.random() * 2 | 0;

            if (positionX === 1) {
                div.style.posLeft = randomPositionX();
            } else if (positionX === 2) {
                div.style.posRight = randomPositionX();
            }

            if (positionY === 3) {
                div.style.posTop = randomPositionY();
            } else if (positionY === 4) {
                div.style.posBottom = randomPositionY();
            }

            var borderWidth = Math.random() * 20 | 0;

            while (borderWidth < 1 || borderWidth > 20) {
                borderWidth = Math.random() * 20 | 0;
            }

            div.style.borderWidth = borderWidth.toString() + 'px';

            var borderRadius = Math.random() * 360 | 0;
            div.style.borderRadius = borderRadius.toString() + 'px';

            div.style.borderColor = randomColor();
            document.body.appendChild(div);
        }
    }
}())