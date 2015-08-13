(function () {
	'use strict';

	var randomNumbersCollection = [1234, 2015, 7488, 1045, 1111, 9789, 1903, 7489, 2415, 2514],
		generatedNumber = generateRandomNumber(),
		playerPoints = 100,
		countPlayerTurns = 0,
		maxTurns = 5,
		guessingButton = document.getElementById('guessing-button'),
		highscoreButton = document.getElementById('hightscore'),
		body = document.getElementsByTagName('body')[0];

	guessingButton.addEventListener('click', function () {
		var userInput = document.getElementById('input-number').value | 0;
		countPlayerTurns += 1;

		if (userInput === generatedNumber) {
			showMessage('Congratilations! You guessed the number!');
			saveResult(playerPoints);
			return;
		}

		// Take points for wrong answer
		playerPoints -= countPlayerTurns * maxTurns;

		if (countPlayerTurns === maxTurns) {
			showMessage('Sorry, but you lose!');
			saveResult(0);
		}

		// Update player turns
		document.getElementById('turns').textContent = maxTurns - countPlayerTurns + ' lives';
		
		// Clear the input field
		document.getElementById('input-number').value = '';
	});

	highscoreButton.addEventListener('click', function () {
		var hightscoreContainer,
			table;
		if (localStorage.length === 0) {
			alert('Empty hightscore list!');
			return;
		}

		hightscoreContainer = document.createElement('div');
		hightscoreContainer.id = 'highscore-container';

		table =
		'<table>' +
			'<thead>' +
				'<tr>' +
					'<td>Nickname</td>' +
					'<td>Points</td>' +
				'</tr>' +
			'</thead>' +
		'<tbody>';

		for (var i = 0, len = localStorage.length; i < len; i += 1) {
			table += '<tr><td>' + localStorage.key(i) + '</td>' + '<td>' + localStorage.getItem(localStorage.key(i)) + '</td>';
		}

		table += '</tbody></table>';

		hightscoreContainer.innerHTML = table;
		body.appendChild(hightscoreContainer);
	});

	function generateRandomNumber() {
		var randomIndex = Math.floor(Math.random() * 10);
		return randomNumbersCollection[randomIndex];
	}

	function showMessage(message) {
		var messageContainer = document.createElement('div'),
			messageHeader,
			label,
			input,
			saveGame;

		messageContainer.id = 'message-container';

		messageHeader = document.createElement('h1');
		messageHeader.textContent = message;

		label = document.createElement('label');
		label.textContent = 'Enter your nickname: ';
		label.id = 'nickname-label';
		label.setAttribute('for', 'nickname-input');

		input = document.createElement('input');
		input.id = 'nickname-input';

		saveGame = document.createElement('button');
		saveGame.id = 'save-game';
		saveGame.textContent = 'Save';

		messageContainer.appendChild(messageHeader);
		messageContainer.appendChild(label);
		messageContainer.appendChild(input);
		messageContainer.appendChild(saveGame);

		body.appendChild(messageContainer);
	}

	function saveResult(playerPoints) {
		var saveButton = document.getElementById('save-game'),
			points = playerPoints.toString();

		saveButton.addEventListener('click', function () {
			var nickname = document.getElementById('nickname-input').value;
			localStorage.setItem(nickname, points);
		});
	}
} ());