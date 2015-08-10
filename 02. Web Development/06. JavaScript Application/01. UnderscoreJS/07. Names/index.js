/// <reference path="../typings/tsd.d.ts" />

// 07. By an array of people find the most common first and last name. 
// Use underscore.

(function () {
	var people = [
		{ firstName: 'Doncho', lastName: 'Minkov', sex: 'male' },
		{ firstName: 'Evlogi', lastName: 'Minkov', sex: 'male' },
		{ firstName: 'Georgi', lastName: 'Hristov', sex: 'male' },
		{ firstName: 'Evlogi', lastName: 'Georgiev', sex: 'male' },
		{ firstName: 'Nikolay', lastName: 'Kostov', sex: 'male' },
		{ firstName: 'Doncho', lastName: 'Kostov', sex: 'male' },
		{ firstName: 'Penka', lastName: 'Minkova', sex: 'female' },
		{ firstName: 'Albena', lastName: 'Minkova', sex: 'female' },
		{ firstName: 'Albena', lastName: 'Georgieva', sex: 'female' },
		{ firstName: 'Evlogi', lastName: 'Kostov', sex: 'male' }];

	console.log('Male first name:');
	findMostCommon(people, 'male', 'firstName');
	console.log('------------------');

	console.log('Male last name:');
	findMostCommon(people, 'male', 'lastName');
	console.log('------------------');

	console.log('Female first name:');
	findMostCommon(people, 'female', 'firstName');
	console.log('------------------');

	console.log('Female last name:');
	findMostCommon(people, 'female', 'lastName');

	function findMostCommon(collectionOfPeople, sex, groupBy) {
		_.chain(people)
		// Filter all people by sex
			.where({ sex: sex })
		// Group them by firstName or by lastName
			.groupBy(groupBy)
		// Find the most common name
			.max(function (group) {
				return group.length;
			}).value().forEach(function (person) {
				console.log(person[groupBy]);
			});
	}
} ());