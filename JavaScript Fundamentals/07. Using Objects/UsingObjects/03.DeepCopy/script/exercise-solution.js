// 03. Write a function that makes a deep copy of an object
// The function should work for both primitive and reference types
var jsConsole;

function copyJSON(obj) {
    var clone = JSON.parse(JSON.stringify(obj));
    return clone;
}

function copy(obj) {
    if (obj === null || typeof (obj) !== 'object') {
        return obj;
    }

    var temp = obj.constructor();

    for (var key in obj) {
        if (Object.prototype.hasOwnProperty.call(obj, key)) {
            temp[key] = copy(obj[key]);
        }
    }
    return temp;
}

var originalObject = {
    firstName: 'Pesho',
    age: 2,
    address: {
        country: 'Bulgaria',
        city: 'Sofia'
    }
};

var copiedObject = copy(originalObject);
jsConsole.writeLine('original === copy : ' + (originalObject === copiedObject));
jsConsole.writeLine('-----------------------------')
var copiedObjectJSON = copyJSON(originalObject);
jsConsole.writeLine('Using JSON')
jsConsole.writeLine('original === copyJSON : ' + (originalObject === copiedObjectJSON));
