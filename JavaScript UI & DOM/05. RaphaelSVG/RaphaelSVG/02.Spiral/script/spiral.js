var paper = Raphael(15, 15, 1000, 600);

function drawSpiral(cx, cy, a, b) {
    var center = 'M' + cx + ' ' + cy;
    var spiral = [center];

    for (var i = 0; i < 730; i++) {
        var angle = -0.1 * i;
        var x = cx + (a + b * angle) * Math.cos(angle);
        var y = cy + (a + b * angle) * Math.sin(angle);

        spiral.push('L' + x + ' ' + y);
    }

    paper.path(spiral.join(''));
};

drawSpiral(300, 300, 0, 4);