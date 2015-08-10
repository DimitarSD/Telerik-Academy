/// <reference path="../typings/tsd.d.ts" />

// 05. By a given array of animals, find the total number of legs
// Each animal can have 2, 4, 6, 8 or 100 legs

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

	var totalNumberOfLegs = _.chain(animals)
		.reduce(function (totalNumberOfLegs, animal) {
			return totalNumberOfLegs + animal.numberOfLegs;
		}, 0);

	console.log('Total number of legs: ' + totalNumberOfLegs);

} ());