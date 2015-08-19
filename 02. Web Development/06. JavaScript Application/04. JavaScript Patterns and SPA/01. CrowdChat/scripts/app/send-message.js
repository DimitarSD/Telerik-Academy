define(['jquery', 'update'], function ($, update) {
	var send = (function () {
		'use strict';
		
		function sendMessage(url, data) {
			var deferred = $.Deferred(),
				stringifiedData = '';

			if (data) {
				stringifiedData = JSON.stringify(data);
			}

			$.ajax({
				url: url,
				type: 'POST',
				data: stringifiedData,
				contentType: 'application/json',
				timeout: 5000,
				success: function (data) {
					update.makeUpdate(url, getCookie('username'));
				},
				error: function (error) {
					deferred.reject(error);
				}
			});

			return deferred.promise();
		};

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

		return {
			sendMessage: sendMessage
		};
	} ());
	
	return send;
});