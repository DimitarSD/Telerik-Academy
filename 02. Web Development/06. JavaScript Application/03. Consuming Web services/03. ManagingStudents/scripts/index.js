(function () {
	require(['../scripts/http-request'], function (httpRequester) {
		'use strict';

		var resourceUrl = 'http://localhost:3000/students',
			request = httpRequester;

		$('#id-container').hide();

		$('#add-student-button').on('click', function () {
			var student = {
				name: $('#name-input').val(),
				grade: $('#grade-input').val(),
			};

			addStudent(student);
		});

		function addStudent(data) {
			request.postJSON(resourceUrl, data, addStudentSuccess);
		}

		function addStudentSuccess(data) {
			alert('Student with name: "' + data.name + '" added');
		}

		$('#remove-student-button').on('click', function () {
			$('#id-container').show();

			$('#remove').on('click', function () {
				var id = $('#id-input').val();
				$('#id-container').hide();

				removeStudent(id);
			});
		});

		function removeStudent(id) {
			request.deleteJSON(resourceUrl + '/' + id, removeStudentSuccess);
		}

		function removeStudentSuccess() {
			alert('Student removed');
		}

		$('#show-students-button').on('click', function () {
			$('#student-container').html('');

			showStudents();
		});

		function showStudents() {
			request.getJSON(resourceUrl, null, showStudentsSuccess);
		}

		function showStudentsSuccess(data) {
			if (data.students.length === 0) {
				alert('There is not any students to show');
			}

			var $ul = $('<ul/>'),
				template = $('#student-template').html();

			for (var i = 0; i < data.students.length; i += 1) {
				var student = data.students[i],
					studentData = {
						id: student.id,
						name: student.name,
						grade: student.grade
					},
					compiledTemplate = Handlebars.compile(template);

				$ul.append(compiledTemplate(studentData));
			}

			$('#student-container').append($ul);
		}
	});
} ());