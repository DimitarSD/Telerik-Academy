/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
  function studentValidation(name) {
    var names = name.split(' '),
      firstName = names[0],
      lastName = names[1];

    if (typeof (name) === 'undefined' || name === ' ') {
      throw new Error('Invalid name. Cannot be undefined or empty string.');
    }

    if (names.length < 1 || names.length > 2) {
      throw new Error('Student can have only first and last name.');
    }

    if (firstName.charCodeAt(0) < 65 || firstName.charCodeAt(0) > 90) {
      throw new Error('The first name must start with upper case letter');
    }

    if (lastName.charCodeAt(0) < 65 || lastName.charCodeAt(0) > 90) {
      throw new Error('The last name must start with upper case letter');
    }
  }

  function sortScore(array) {
    return array.sort(function (first, second) {
      if (first[1] < second[1]) {
        return -1;
      }
      if (first[1] > second[1]) {
        return 1;
      }
      return 0;
    });
  }

  var Course = {
    init: function (title, presentations) {
      // Initialize all propeties that we need. We use 'init' as a constructor.
      this.title = title;
      this.presentations = presentations;
      this.students = [];
      this.homework = [];
      this.examResults = {};
      return this;
    },
    addStudent: function (name) {
      var names = name.split(' '),
        studentFirstName = names[0],
        studentLastName = names[1];

      studentValidation(name);

      var student = {
        firstname: studentFirstName,
        lastname: studentLastName,
        id: this.students.length + 1
      };

      this.students.push(student);
      return this.students.length;
    },
    getAllStudents: function () {
      // Using .slice() to return a copy of this.students
      return this.students.slice();
    },
    submitHomework: function (studentID, homeworkID) {
      if (homeworkID < 1 || homeworkID > this.presentations.length) {
        throw new Error('Invalid homework ID.');
      }

      if (studentID < 1 || studentID > this.students.length) {
        throw new Error('Invalid student ID.' + this.students.length);
      }

      var homework = {
        student: studentID,
        homework: homeworkID
      };

      this.homework.push(homework);
    },
    pushExamResults: function (results) {
      if (!arguments[0] || arguments[0] === 'undefined' || !Array.isArray(results)) {
        throw new Error('No arguments have been passed.');
      }

      results = results.sort(function (first, second) {
          if (first[1] < second[1]) {
            return -1;
          }
          if (first[1] > second[1]) {
            return 1;
          }
          return 0;
        });

      for (var i = 0; i < results.length; i += 1) {
        var currentStudent = results[i];

        if (!currentStudent.score || !currentStudent.StudentID) {
          throw new Error('Either score or StudentID is missing.');
        }

        var isValidID = this.students.every(function (student) {
          return student.id === currentStudent.StudentID;
        });

        if (isValidID) {
          throw new Error('There can\'t be same student twice.');
        }

        if (currentStudent.StudentID <= 0 || currentStudent.StudenID > this.students.length) {
          throw new Error('Invalid student ID.');
        }

        if (currentStudent.score === 0) {
          throw new Error('Each student must have score.');
        }

        if (typeof (currentStudent.score) !== 'number') {
          throw new Error('Score must be of type number.');
        }

        for (var k = 0; k < results.length - 1; k += 1) {
          if (results[k].StudentID === results[k + 1].StudentID) {
            throw new Error();
          }
        }

        this.examResults[results[i].StudentID] = results[i].score;
      }

      return this;
    },
    getTopStudents: function () {
      var finalScores = [];

      for (var i = 0; i < this.students.length; i += 1) {
        var finalExamScore = this.examResults[this.students[i].id]['examResults'],
          finalHomeworkScore = this.examResults[this.students[i].id]['homework'].length / this.presentations.length,
          finalScore = finalExamScore / 100 * 75 + finalHomeworkScore / 100 * 25;

        finalScores.push([this.students[i].id, finalScore]);
      }

      var topScores = sortScore(finalScores)
        .reverse()
        .slice(0, 10);

      for (var i = 0; i < topScores.length; i += 1) {
        for (var j = 0; j < this.students.length; j += 1) {
          if (topScores[i][0] === this.students[j].id) {
            this.examResults.push(this.students[j]);
          }
        }
      }

      return this.examResults;
    }
  };

  Object.defineProperties(Course, {
    title: {
      get: function () {
        return this._title;
      },
      set: function (value) {
        if (typeof (value) !== 'string' || value === '' || /^\s|\s{2}|^.{0}$|\s$/.test(value)) {
          throw new Error('Invalid course title.');
        }

        this._title = value;
      }
    },
    presentations: {
      get: function () {
        return this._presentations;
      },
      set: function (value) {
        if (value.length === 0) {
          throw new Error('There must be atleast one presentation.');
        }

        for (var i = 0; i < value.length; i += 1) {
          if (typeof (value[i]) !== 'string' || value[i] === '' || /^\s|\s{2}|^.{0}$|\s$/.test(value[i])) {
            throw new Error('Invalid presentation title.');
          }
        }

        this._presentations = value;
      }
    }
  });

  return Course;
}

module.exports = solve;