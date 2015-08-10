/// <reference path="../typings/tsd.d.ts" />

// 02. Write function that finds the first name and last name 
// of all students with age between 18 and 24. 
// Use Underscore.js

(function () {
	var students = [
		{ firstName: 'Doncho', lastName: 'Minkov', age: 53 },
		{ firstName: 'Maria', lastName: 'Minkova', age: 17 },
		{ firstName: 'Ivan', lastName: 'Georgiev', age: 22 },
		{ firstName: 'Penka', lastName: 'Kenova', age: 24 },
		{ firstName: 'Nikolay', lastName: 'Draganov', age: 20 }];

	_.chain(students)
		.filter(function (student) {
			return student.age >= 18 && student.age <= 24;
		})
		.each(function (student) {
			console.log(student.firstName + ' ' + student.lastName + ' -> Age: ' + student.age);
		});
} ());