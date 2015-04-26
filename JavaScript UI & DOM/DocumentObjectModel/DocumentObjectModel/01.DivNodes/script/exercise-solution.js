// 01. Write a script that selects all the div nodes that are directly inside other div elements
// Create a function using querySelectorAll()
// Create a function using getElementsByTagName()
var jsConsole;

var buttonQuerySelector = document.getElementById('query-selector');
var buttonGetByTagName = document.getElementById('tag-name');

buttonQuerySelector.onclick = function () {
    var nestedDivs = document.querySelectorAll('div > div');

    for (var i = 0, len = nestedDivs.length; i < len; i+=1) {
        nestedDivs[i].style.color = '#0094FF';
    }
};

buttonGetByTagName.onclick = function () {
    var divs = document.getElementsByTagName('div');

    for (var i = 0, len = divs.length; i < len; i+=1) {
        if (divs[i].parentNode instanceof HTMLDivElement){
            divs[i].style.color = '#00ff21';
        }
    }
};