// 05. Write a function that finds the youngest person in a given array of persons and prints his/hers full name
// Each person have properties firstname, lastname and age.
var jsConsole;

var persons = [
    { firstName: 'Albena', lastName: 'Georgieva', age: 24 },
    { firstName: 'Georgi', lastName: 'Kovachev', age: 25 },
    { firstName: 'Ilaylo', lastName: 'Kendov', age: 2 },
    { firstName: 'Penka', lastName: 'Pencheva', age: 99 }
]

function findYoungestPerson(persons) {
    var firstName;
    var lastName;
    var minAge = Number.MAX_VALUE;

    for (var i = 0; i < persons.length; i++) {
        if (minAge > persons[i].age) {
            minAge = persons[i].age
            firstName = persons[i].firstName;
            lastName = persons[i].lastName;
        }
    }

    return firstName + ' ' + lastName;
}

var youngestPerson = findYoungestPerson(persons);

jsConsole.writeLine('The youngest person is: ' + youngestPerson);