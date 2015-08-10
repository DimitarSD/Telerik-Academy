/// <reference path="../typings/tsd.d.ts" />

// 03. Write a function that by a given array of students 
// finds the student with highest marks

(function () {
	var students = [
		{ firstName: 'Doncho', lastName: 'Minkov', marks: [2, 6, 4, 4, 6] },
		{ firstName: 'Albena', lastName: 'Georgieva', marks: [6, 6, 6, 6, 5, 6] },
		{ firstName: 'Petar', lastName: 'Stoichev', marks: [2, 3, 3, 2] },
		{ firstName: 'Svetoslav', lastName: 'Ivanov', marks: [2, 2, 3, 2, 2, 3] },
		{ firstName: 'Aleksandra', lastName: 'Zlatanova', marks: [3, 6, 3, 4, 5, 6] },
		{ firstName: 'Nikolay', lastName: 'Minkov', marks: [2, 3] },

	];

	var studentWithHighestMarks =_.chain(students)
		.map(function (student) {
			return {
				firstName: student.firstName,
				lastName: student.lastName,
				mark: (student.marks.reduce(function (sumOfAllMarks, mark) {
					return sumOfAllMarks + mark;
				}, 0) / student.marks.length).toFixed(2)
			};
		})
		.max(function (student) {
			return student.mark;
		}).value();
	
	console.log(studentWithHighestMarks.firstName + ' ' + studentWithHighestMarks.lastName + ' -> Mark: ' + studentWithHighestMarks.mark);

} ());