var jsConsole;
var people = [];

function Person(firstName, lastName, age, gender) {
    this.FirstName = firstName;
    this.LastName = lastName;
    this.Age = age;
    this.Gender = gender;
    this.toString = '{ Name: ' + this.FirstName + ' ' + this.LastName + ', age: ' + this.Age + ', sex: ' + this.Gender + ' }';
}

var buttonProblemOne = document.getElementById('problem-one');
buttonProblemOne.onclick = function () {
    jsConsole.clearConsole();
    jsConsole.writeLine('Problem 1. Make person');
    jsConsole.writeLine('Write a function for creating persons.');
    jsConsole.writeLine('Each person must have firstname, lastname, age and gender (true is female, false is male)');
    jsConsole.writeLine('Generate an array with ten person with different names, ages and genders');
    jsConsole.writeLine();
    jsConsole.writeLine('Solution: ');
    jsConsole.writeLine();

    function generatePersons() {
        var firstNameMale = ['Ivan', 'Georgi', 'Ivaylo', 'Anton', 'Petar', 'Simeon', 'Nikolay'];
        var firstNameFemale = ['Albena', 'Elena', 'Aleks', 'Sofia', 'Elitsa', 'Victoria', 'Aleksandra'];

        var lastNameMale = ['Ivanov', 'Georgiev', 'Simeonov', 'Apostolov'];
        var lastNameFemale = ['Ivanova', 'Georgieva', 'Simeonova', 'Apostolova'];

        var age = ((Math.random() * 29) | 0) + 1;
        var sex = generateGender();
        var indexFirstName = (Math.random() * 7) | 0;
        var indexLastName = (Math.random() * 4) | 0;

        if (sex) {
            var person = new Person(firstNameFemale[indexFirstName], lastNameFemale[indexLastName], age, 'female');
            people.push(person);
        } else {
            var person = new Person(firstNameMale[indexFirstName], lastNameMale[indexLastName], age, 'male');
            people.push(person);
        }
    }

    function generateGender() {
        var sex = (Math.random() * 2) | 0;

        if (sex === 0) {
            return true;
        } else {
            return false;
        }
    }

    for (var i = 0; i < 10; i += 1) {
        generatePersons();
    }

    for (var i = 0; i < people.length; i += 1) {
        jsConsole.writeLine(people[i].toString);
    }
}

var buttonProblemTwo = document.getElementById('problem-two');
buttonProblemTwo.onclick = function () {
    jsConsole.clearConsole();
    jsConsole.writeLine('Problem 2. People of age');
    jsConsole.writeLine('Write a function that checks if an array of person contains only people of age (with age 18 or greater)');
    jsConsole.writeLine('Use only array methods and no regular loops (for, while)');
    jsConsole.writeLine();
    jsConsole.writeLine('Solution:');
    jsConsole.writeLine();
    for (var i = 0; i < people.length; i += 1) {
        jsConsole.writeLine(people[i].toString);
    }
    function isOfAge(person) {
        return person.age >= 18;
    }

    var ofAge = people.every(isOfAge);

    jsConsole.writeLine();
    jsConsole.writeLine('Contains only people with age 18 or greater: ' + ofAge)
}

var buttonProblemThree = document.getElementById('problem-three');
buttonProblemThree.onclick = function () {
    jsConsole.clearConsole();
    jsConsole.writeLine('Problem 3. Underage people');
    jsConsole.writeLine('Write a function that prints all underaged persons of an array of person');
    jsConsole.writeLine('Use Array#filter and Array#forEach');
    jsConsole.writeLine('Use only array methods and no regular loops (for, while)');
    jsConsole.writeLine();
    jsConsole.writeLine('Solution:');
    jsConsole.writeLine();

    for (var i = 0; i < people.length; i += 1) {
        jsConsole.writeLine(people[i].toString);
    }

    function isUnderage(person) {
        return person.Age < 18;
    }

    var underagePeople = people.filter(isUnderage);

    jsConsole.writeLine();
    underagePeople.forEach(function (person) {
        jsConsole.writeLine('Name: ' + person.FirstName + ' ' + person.LastName + ', Age: ' + person.Age);
    });
}

var buttonProblemFour = document.getElementById('problem-four');
buttonProblemFour.onclick = function () {
    jsConsole.clearConsole();
    jsConsole.writeLine('Problem 4. Average age of females');
    jsConsole.writeLine('Write a function that calculates the average age of all females, extracted from an array of persons');
    jsConsole.writeLine('Use Array#filter');
    jsConsole.writeLine('Use only array methods and no regular loops (for, while)');
    jsConsole.writeLine();
    jsConsole.writeLine('Solution:');
    jsConsole.writeLine();

    for (var i = 0; i < people.length; i += 1) {
        jsConsole.writeLine(people[i].toString);
    }

    function isFemale(person) {
        return person.Gender;
    }

    var females = people.filter(isFemale);

    var agesSum = females.reduce(function (sum, person) {
        return sum + person.Age;
    }, 0);

    var averageAge = Math.round(agesSum / females.length);

    jsConsole.writeLine();
    jsConsole.writeLine('The average age of all females: ' + averageAge);

}

var buttonProblemFive = document.getElementById('problem-five');
buttonProblemFive.onclick = function () {
    jsConsole.clearConsole();
    jsConsole.writeLine('Problem 5. Youngest person');
    jsConsole.writeLine('Write a function that finds the youngest male person in a given array of people and prints his full name');
    jsConsole.writeLine('Use only array methods and no regular loops (for, while)');
    jsConsole.writeLine('Use Array#find');
    jsConsole.writeLine();
    jsConsole.writeLine('Solution:');
    jsConsole.writeLine();

    for (var i = 0; i < people.length; i += 1) {
        jsConsole.writeLine(people[i].toString);
    }

    if (!Array.prototype.find) {
        Array.prototype.find = function (callback) {
            var i, len = this.length;
            for (i = 0; i < len; i += 1) {
                if (callback(this[i], i, this)) {
                    return this[i];
                }
            }
        }
    }

    function isMale(person) {
        return person.Gender;
    }

    var youngest = people.sort(function (firstPerson, secondPerson) {
        return firstPerson.Age > secondPerson.Age;
    }).find(isMale);

    jsConsole.writeLine();
    jsConsole.writeLine('The youngest: ' + youngest.FirstName + ' ' + youngest.LastName);
}

var buttonProblemSix = document.getElementById('problem-six');
buttonProblemSix.onclick = function () {
    jsConsole.clearConsole();
    jsConsole.writeLine('Problem 6. Group people');
    jsConsole.writeLine('Write a function that groups an array of persons by first letter of first name and returns the groups as a JavaScript Object');
    jsConsole.writeLine('Use Array#reduce');
    jsConsole.writeLine('Use only array methods and no regular loops (for, while)');
    jsConsole.writeLine();
    jsConsole.writeLine('Solution:');
    jsConsole.writeLine();

    for (var i = 0; i < people.length; i += 1) {
        jsConsole.writeLine(people[i].toString);
    }

    var result = people.reduce(function (groups, person) {
        if (groups[person.FirstName[0]]) {
            groups[person.FirstName[0]].push(person);
        } else {
            groups[person.FirstName[0]] = [person]
        }

        return groups;
    }, {});

    console.log(result);

    jsConsole.writeLine();
    jsConsole.writeLine('Open the browser console to see the final result.');
}