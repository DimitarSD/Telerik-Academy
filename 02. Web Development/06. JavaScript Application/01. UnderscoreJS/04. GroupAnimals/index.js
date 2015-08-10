/// <reference path="../typings/tsd.d.ts" />

// 04. Write a function that by a given array of animals, 
// groups them by species and sorts them by number of legs

(function () {
	var animals = [
		{ species: 'mammals', family: 'bear', numberOfLegs: 4 },
		{ species: 'mammals', family: 'cat', numberOfLegs: 4 },
		{ species: 'birds', family: 'parrot', numberOfLegs: 2 },
		{ species: 'reptiles', family: 'snake', numberOfLegs: 0 },
		{ species: 'insects', family: 'bee', numberOfLegs: 6 },
		{ species: 'insects', family: 'ant', numberOfLegs: 6 },
		{ species: 'fish', family: 'shark', numberOfLegs: 0 },
		{ species: 'amphibians', family: 'frog', numberOfLegs: 4 }];

	_.chain(animals)
		.groupBy('species')
		.sortBy(function (animal) {
			return animal[0].numberOfLegs;
		}).each(function (group) {
			console.log('Species: ' + group[0].species);
			group.forEach(function (animal) {
				console.log('Family: ' + animal.family + ' -> Number of legs: ' + animal.numberOfLegs);
			});
			console.log('------------------------');
		});

} ());