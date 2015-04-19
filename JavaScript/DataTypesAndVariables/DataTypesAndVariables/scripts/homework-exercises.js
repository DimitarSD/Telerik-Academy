// 1. Assign all the possible JavaScript literals to different variables.
var integer = 15;
var float = 3.1555;
var str = 'JavaScript';
var boolean = true;
var array = ['JS', 15.19, 7, { Name: 'C#', Lectures: 15 }];
var obj = {
    Name: 'JavaScript',
    NumberOfLecures: 25,
    Lector: 'Penka'
};

var nullVariable = null;
var undefinedVariable;

// 2. Create a string variable with quoted text in it. For example: 'How you doin'?', Joey said.
var quotedText = 'How you doin "Peet", Joey said.';
console.log(quotedText);

// 3. Try typeof on all variables you created.
console.log(typeof (integer));
console.log(typeof (float));
console.log(typeof (str));
console.log(typeof (boolean));
console.log(typeof (array));
console.log(typeof (obj));
console.log(typeof (nullVariable));
console.log(typeof (undefinedVariable));

// 4. Create null, undefined variables and try typeof on them.
console.log('Null is of type: ' + typeof (nullVariable));
console.log('Undefined is of type: ' + typeof (undefinedVariable));