define([update', 'get-cookie'], function ($, update, cookie) {
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
					update.makeUpdate(url, cookie.getCookie('username'));
				},
				error: function (error) {
					deferred.reject(error);
				}
			});

			return deferred.promise();
		};

		return {
			sendMessage: sendMessage
		};
	} ());

	return send;
});