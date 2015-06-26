// 08. Write a JavaScript function that replaces in a HTML document given as string all the tags <a href="…">…</a> 
// with corresponding tags [URL=…]…/URL].
var jsConsole;
var replaceButton = document.getElementById('replace-content');

replaceButton.onclick = replaceTags;

function replaceTags() {
    var text = jsConsole.read('#input-text');
    var result = '';

    for (var i = 0; i < text.length; i += 1) {
        if (text.substr(i, 1) === '<' && text.substr(i + 1, 1) === 'a') {
            result += '[URL=';
            i += 8;
        } else if (text.substr(i, 1) === '"' && text.substr(i + 1, 1) === '>') {
            result += ']';
            i += 1;
        } else if (text.substr(i, 1) === '<' && text.substr(i + 1, 1) === '/' && text.substr(i + 2, 1 ) == 'a') {
            result += '[/URL]';
            i += 3;
        } else {
            result += text.substr(i, 1);
        }
    }

    jsConsole.writeLine(result.htmlEscape());
}
