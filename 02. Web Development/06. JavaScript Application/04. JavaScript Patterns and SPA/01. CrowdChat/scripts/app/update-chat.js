define(['jquery', 'message-parser'], function ($, parser) {
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
						$ul = $('<ul/>'),
						maxNumberOfMessages = 0;

					if (data.length >= 40) {
						maxNumberOfMessages = data.length - 40;
					}

					for (var i = maxNumberOfMessages; i < data.length; i += 1) {
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