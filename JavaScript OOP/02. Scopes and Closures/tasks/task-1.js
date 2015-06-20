/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
					*	They are provided by an options object {category: ...} or {author: ...}
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/category has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/
function solve() {
	var library = (function () {
		var books = [],
			categories = [];
		
		function listBooks() {
			var optionalParameter = arguments[0]; 
			
            if (optionalParameter && optionalParameter.author) { 
                books = books.filter(function (book) {
                    return book.author === optionalParameter.author;
                });
            } else if (optionalParameter && optionalParameter.category) {
                books = books.filter(function (book) {
                    return book.category === optionalParameter.category;
                });
            } 

            books = books.sort(function (firstBook, secondBook) {
                return firstBook.ID - secondBook.ID;
            });

            return books;
		}

		function addBook(book) {
			var i,
				booksArrayLength = books.length;
			
			// Book title validation
			if (book.title.length < 2 || book.title.length > 100) {
				throw new Error('Book title must contain between 2 and 100 characters.');
			}
			
			// Book category validation
			if (book.category.length < 2 || book.title.length > 100) {
				throw new Error('Book category must contain between 2 and 100 characters.');
			}
			
			// Book author validation
			if (book.author.length === 0) {
				throw new Error('Author cannot be empty string.');
			}
			
			// Book ISBN validation
			if (book.isbn.length < 10 || book.isbn.length > 13) {
				throw new Error('Book ISBN must contain 10 or 13 digits.');
			}
			
			for (i = 0; i < booksArrayLength; i += 1) {
				if (book.title === books[i].title){
					throw new Error('Book with this title already exist.');
				}
				
				if (book.isbn === books[i].isbn) {
					throw new Error('Book with this ISBN already exist.');
				}
			}
			
			book.ID = books.length + 1;
			books.push(book);
			
			// Adding new category if doesn't exist 
			if (categories.indexOf(book.category) === -1) {
                categories.push(book.category);
            }
			
			return book;
		}

		function listCategories() {
			// Sort all categories
			categories = categories.sort(function (firstCategory, secondCategory) {
                return firstCategory - secondCategory;
            });
			
			return categories;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());
	return library;
}
module.exports = solve;
