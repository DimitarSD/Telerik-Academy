define(['jquery', 'sammy', 'update', 'send', 'get-cookie'], function ($, sammy, updater, sender, cookie) {
	var chatApp = function (containerID, url) {
		return sammy(containerID, function () {
			
			this.get('#/home', function () {
				$(containerID).html('');
				$(containerID).load('scripts/views/home-template.html');
			});

			this.get('#/login', function () {
				$(containerID).html('');
				$(containerID).load('scripts/views/login-template.html', function () {
					$('#login-button').on('click', function () {
						var username = $('#nickname-input').val();

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
				var url = 'http://crowd-chat.herokuapp.com/posts',
					username = cookie.getCookie('username');
				
				$(containerID).html('');

				if (typeof (username) === 'undefined') {
					alert('Please login'); // Need to change
					window.location.hash = '#/login';
				} else {
					$(containerID).load('scripts/views/chat-template.html', function () {
						$('#send-button').on('click', function () {
							var textMessage = $('#message-input').val();
							
							if (textMessage === '') {
								textMessage = '=== Gagnam style ===';
							}
							
							var message = {
								user: username,
								text: textMessage
							};

							$('#message-input').val('');
							sender.sendMessage(url, message);
						});

						$('#message-input').keypress(function (event) {
							if (event.which === 13) {
								$('#send-button').click();
							}
						});
					});
				}

				setInterval(function () {
					updater.makeUpdate(url, username);
				}, 3000);
			});
		});
	};

	return chatApp;
});
