define(['jquery', 'messageParser'], function ($, parser) {
	var update = (function () {
		'use strict';
		
		function makeUpdate(url, username) {
			var deferred = $.Deferred();

			$.ajax({
				url: url,
				type: 'GET',
				contentType: 'application/json',
				timeout: 5000,
				success: function (data) {
					$('#chat-messages-container').html('');

					var $messagesField = $('#chat-messages-container'),
						$ul = $('<ul/>');

					for (var i = 0; i < data.length; i += 1) {
						var $message = $('<li/>');

						if (data[i].by === username) {
							$message.attr('id', 'local-user');
						} else {
							$message.attr('id', 'server-user');
						}

						$message
							.append($('<p/>').addClass('send-by').html(data[i].by + ':'))
							.append($('<p/>').addClass('text-message').html(parser.parseMessage(data[i].text)));
						
						$ul.append($message);
					}
					
					$messagesField.append($ul);
					$('#chat-messages-container').scrollTop($('#chat-messages-container')[0].scrollHeight);
				},
				error: function (error) {
					deferred.reject(error);
				}
			});

			return deferred.promise();
		};

		return {
			makeUpdate: makeUpdate
		};
	} ());

	return update;
});