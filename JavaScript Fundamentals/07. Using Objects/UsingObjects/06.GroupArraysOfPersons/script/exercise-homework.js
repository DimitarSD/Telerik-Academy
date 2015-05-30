// 06. Write a function that groups an array of persons by age, first or last name. 
// The function must return an associative array, with keys - the groups, and values -arrays with persons in this groups
// Use function overloading (i.e. just one function)
var jsConsole;

var persons = [
    { firstName: 'Albena', lastName: 'Georgieva', age: 24 },
    { firstName: 'Georgi', lastName: 'Kovachev', age: 25 },
    { firstName: 'Ilaylo', lastName: 'Kendov', age: 2 },
    { firstName: 'Penka', lastName: 'Pencheva', age: 99 },
]

function group(persons, groupType) {
    var groupedPersons = [];
    
    // Using function overloading
    switch (arguments.length) {
        case 1: {
            var ageGroup = [];
            var firstNameGroup = [];
            var lastNameGroup = [];

            for (var i = 0; i < persons.length; i++) {
                ageGroup[i] = persons[i].age;
                firstNameGroup[i] = persons[i].firstName;
                lastNameGroup[i] = persons[i].lastName;
            }

            groupedPersons['firstName'] = firstNameGroup;
            groupedPersons['lastName'] = lastNameGroup;
            groupedPersons['age'] = ageGroup;
        }
        case 2: {
            var arrGroupType = [];
            for (var i = 0; i < persons.length; i++) {

                switch (groupType) {
                    case 'age':
                        arrGroupType[i] = persons[i].age;
                        break;
                    case 'firstName':
                        arrGroupType[i] = persons[i].firstName;
                        break;
                    case 'lastName':
                        arrGroupType[i] = persons[i].lastName;
                        break;
                }
            }

            groupedPersons[groupType] = arrGroupType;
        }
    }

    return groupedPersons;
}

// Call the function with just one argument (only the array). 
// In this case the fuction return array with keys - the groups (age, firstName, lastName) and values - 
// array with persons first name, last name or age;
jsConsole.writeLine('Call the function with one argument, then print each group:')
jsConsole.writeLine();
var groupedPersons = group(persons);
jsConsole.writeLine('groupedPersons[\'firstName\'] = ' + groupedPersons.firstName);
jsConsole.writeLine('groupedPersons[\'lastName\'] = ' + groupedPersons.lastName);
jsConsole.writeLine('groupedPersons[\'age\'] = ' + groupedPersons.age);
jsConsole.writeLine();

// Call the function with two arguments - the array and the group type (i.e 'firstName', 'lastName' or 'age')
// In this case the function return array with key - the group type and value - array;
jsConsole.writeLine('Call the function with two arguments:')
var groupByAge = group(persons, 'age');
jsConsole.writeLine('groupByAge[\'age\'] = ' + groupByAge.age);
