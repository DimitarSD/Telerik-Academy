/// <reference path="../typings/tsd.d.ts" />

// 06. By a given collection of books, find the most popular 
// author (the author with the highest number of books)

(function () {
	var books = [
		{ bookName: 'The Hunger Games', author: 'Suzanne Collins', year: 2008 },
		{ bookName: 'Catching Fire', author: 'Suzanne Collins', year: 2009 },
		{ bookName: 'Mockingjay', author: 'Suzanne Collins', year: 2010 },
		{ bookName: 'The Maze Runner', author: 'James Dashner', year: 2009 },
		{ bookName: 'The Scorch Trials', author: 'James Dashner', year: 2010 },
		{ bookName: 'The Keeper', author: 'David Baldacci', year: 2015 }];

	_.chain(books)
		.groupBy('author')
		.max(function (authorBooks) {
			return authorBooks.length;
		})
		.value()
		.forEach(function (book) {
			console.log('Book name: ' + book.bookName + ' ----- Author: ' + book.author);
		});

} ());