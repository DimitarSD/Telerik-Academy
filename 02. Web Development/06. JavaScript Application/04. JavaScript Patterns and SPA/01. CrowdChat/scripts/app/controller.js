define(['jquery', 'sammy', 'update', 'send'], function ($, sammy, update, send) {
	var chatApp = function (containerID, url) {
		return sammy(containerID, function () {
			var username;

			this.get('#/home', function () {
				$(containerID).html('');
				$(containerID).load('scripts/views/home-template.html');
			});

			this.get('#/login', function () {
				$(containerID).html('');
				$(containerID).load('scripts/views/login-template.html', function () {
					$('#login-button').on('click', function () {
						username = $('#nickname-input').val();

						if (username.length < 3) {
							$('#nickname-input').val('');
							alert('Your username must contain atleast 3 characters');
						} else {
							document.cookie = 'username=' + username + '; expires=Thu, 22 Dec 2016 12:00:00 UTC; path=/';
							window.location.hash = '#/chat';
						}
					});
				});
			});

			this.get('#/chat', function () {
				var url = 'http://crowd-chat.herokuapp.com/posts';
				$(containerID).html('');

				if (typeof (username) === 'undefined') {
					alert('Please login');
					window.location.hash = '#/login';
				} else {
					$(containerID).load('scripts/views/chat-template.html', function () {
						$('#send-button').on('click', function () {
							var message = {
								user: getCookie('username'),
								text: $('#message-input').val()
							};

							$('#message-input').val('');
							send.sendMessage(url, message);
						});

						$('#message-input').keypress(function (event) {
							if (event.which === 13) {
								$('#send-button').click();
							}
						});
					});
				}

				update.makeUpdate(url, getCookie('username'));
			});

			function getCookie(name) {
				var start = document.cookie.indexOf(name + '='),
					end;

				if (start !== -1) {
					start = start + name.length + 1;
					end = document.cookie.indexOf(';', start);

					if (end === -1) {
						end = document.cookie.length;
					}

					return document.cookie.substring(start, end);
				}
			}
		});
	};

	return chatApp;
});
