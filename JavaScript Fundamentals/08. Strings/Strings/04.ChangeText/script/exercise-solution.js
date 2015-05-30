// 04. You are given a text. Write a function that changes the text in all regions:
// <upcase>text</upcase> to uppercase.
// <lowcase>text</lowcase> to lowercase
// <mixcase>text</mixcase> to mix casing(random)
var jsConsole;
var changeButton = document.getElementById('change-text');

changeButton.onclick = displayResult;

function changeTextInTags() {
    var text = jsConsole.read('#input-text');
    var result = '';

    var isOutState = true;
    var isInState = false;
    var isLowerCase = false;
    var isUpperCase = false;
    var isMixCase = false;
    var inTag = 0;

    for (var i = 0; i < text.length; i+=1) {
        if (isOutState) {
            if (text.substr(i, 1) === '<') {
                isOutState = false;
                isInState = true;
                inTag += 1;
            } else {
                result += text.substr(i, 1);
            }
        }

        if (isInState) {
            if (text.substr(i - 1, 1) === '<' && text.substr(i, 1) === 'l') {
                isLowerCase = true;
            }

            if (text.substr(i - 1, 1) === '<' && text.substr(i, 1) === 'u') {
                isUpperCase = true;
            }

            if (text.substr(i - 1, 1) === '<' && text.substr(i, 1) === 'm') {
                isMixCase = true;
            }
        }

        if (isLowerCase) {
            if (text.substr(i, 1) === '>') {
                continue;
            } else if (text.substr(i - 1, 1) === '>') {
                for (var j = 0; isLowerCase; j++) {
                    result += text.substr(i + j, 1).toLowerCase();
                    if (text.substr(i + j + 1, 1) === '<') {
                        isLowerCase = false;
                    }
                }
            }
        }

        if (isUpperCase) {
            if (text.substr(i, 1) === '>') {
                continue;
            } else if (text.substr(i - 1, 1) === '>') {
                for (var j = 0; isUpperCase; j++) {
                    result += text.substr(i + j, 1).toUpperCase();
                    if (text.substr(i + j + 1, 1) === '<') {
                        isUpperCase = false;
                    }
                }
            }
        }

        if (isMixCase) {
            if (text.substr(i, 1) === '>') {
                continue;
            } else if (text.substr(i - 1, 1) === '>') {
                for (var j = 0; isMixCase; j++) {
                    if (Math.random() < 0.5) {
                        result += text.substr(i + j, 1).toUpperCase();
                    } else {
                        result += text.substr(i + j, 1).toLowerCase();
                    }
                    if (text.substr(i + j + 1, 1) === '<') {
                        isMixCase = false;
                    }
                }
            }
        }

        if (text.substr(i, 1) === '>' && (text.substr(i + 1, 1) === ' ' ||
            text.substr(i + 1, 1) === ',' || 
            text.substr(i + 1, 1) === '.' || 
            text.substr(i + 1, 1) === '!' ||
            text.substr(i + 1, 1) === '?')) {
            isInState = false;
            isOutState = true;
        }
    }
    return result;
}

function displayResult() {
   jsConsole.writeLine(changeTextInTags());
}