/// <reference path="../typings/tsd.d.ts" />

// 01. Write a method that from a given array of students finds 
// all students whose first name is before its last name 
// alphabetically.Print the students in descending order by full name.
// Use Underscore.js


(function () {
	var students = [
		{ firstName: 'Doncho', lastName: 'Minkov' },
		{ firstName: 'Albena', lastName: 'Georgieva' },
		{ firstName: 'Nikolay', lastName: 'Kostov' },
		{ firstName: 'Petar', lastName: 'Ivanov' },
		{ firstName: 'Ivaylo', lastName: 'Kenov' },
		{ firstName: 'Svetoslav', lastName: 'Georgiev' }];

	_.chain(students)
		.reject(function (student) {
			return student.firstName > student.lastName;
		})
		.sortBy(function (student) {
			return student.firstName;
		}).each(function (student) {
			console.log(student.firstName + ' ' + student.lastName);
		});
} ());