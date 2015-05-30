// 04. Write a function that checks if a given object contains a given property
var jsConsole;

function getAllProperties(obj) {
    var properties = [];

    for (var key in obj) {
        properties.push(key);
    }

    return properties;
}

function hasProperty(obj, propertyName) {
    var allObjProperties = getAllProperties(obj);

    for (var i = 0; i < allObjProperties.length; i++) {
        if (allObjProperties[i] === propertyName) {
            return true;
        }
    }

    return false;
}

var person = {
    name: 'Ivan',
    age: 25,
    city: 'Sofia',
    isStudent: true,
    languages: ['C#', 'JS', 'CSS', 'HTML']
};

var hasProp = hasProperty(person, 'city')

if (hasProp) {
    jsConsole.writeLine('The object contains the property')
} else {
    jsConsole.writeLine('The object does not contains the property')
}