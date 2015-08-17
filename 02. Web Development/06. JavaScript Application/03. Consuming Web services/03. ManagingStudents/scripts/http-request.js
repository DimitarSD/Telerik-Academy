define(function () {
	'use strict';

	// Make a function 'makeHttpRequest' which we will use to
	// make different HTTP Request
	function makeHttpRequest(url, type, data, onSuccess) {
		var deferred = $.Deferred(),
			stringifiedData = '';
			
		if (data) {
			stringifiedData = JSON.stringify(data);
		}

		$.ajax({
			url: url,
			type: type,
			data: stringifiedData,
			contentType: 'application/json',
			timeout: 5000,
			success: function (data) {
				onSuccess(data);
			},
			error: function (error) {
				deferred.reject(error);
			}
		});

		return deferred.promise();
	}

	function getJSON(url, data, onSuccess) {
		return makeHttpRequest(url, 'GET', null, onSuccess);
	}

	function postJSON(url, data, onSuccess) {
		return makeHttpRequest(url, 'POST', data, onSuccess);
	}

	function deleteJSON(url, onSuccess) {
		return makeHttpRequest(url, 'DELETE', null, onSuccess);
	}

	return {
		getJSON: getJSON,
		postJSON: postJSON,
		deleteJSON: deleteJSON
	};

});