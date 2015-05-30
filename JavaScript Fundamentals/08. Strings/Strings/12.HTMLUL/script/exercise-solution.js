// 12. Write a function that creates a HTML UL using a template for every HTML LI. 
// The source of the list should an array of elements. Replace all placeholders marked with –{…}–   
// with the value of the corresponding property of the object.
var jsConsole;

var people = [
    { name: 'Kalina', age: 25 },
    { name: 'Petko', age: 19 },
    { name: 'Ivaylo', age: 23 },
    { name: 'Anton', age: 25 }
]

var template = document.getElementById('list-item').innerHTML;
var peopleList = generateList(people, template);
jsConsole.writeLine(peopleList);

function generateList(people, template) {
    var result = '<ul>'

    for (var item in people) {
        result += '<li>' +
            template.replace('-{name}-', people[item].name).replace('-{age}-', people[item].age) +
            '</li>';
    }

    result += '</ul>';

    return result;
}