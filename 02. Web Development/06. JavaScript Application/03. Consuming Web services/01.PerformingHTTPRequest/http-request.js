/// <reference path="../typings/jquery/jquery.d.ts" />

var httpRequest = (function () {
	'use strict';
	
	function makeHttpRequest(url, type, data, headers) {
		var deferred = $.Deferred();
		
		var stringifiedData = '';
		if (data) {
			stringifiedData = JSON.stringify(data);
		}
		
		$.ajax({
			url: url,
			type: type,
			data: stringifiedData,
			headers: headers,
			contentType: 'application/json',
			timeout: 5000,
			success: function (data) {
				deferred.resolve(data);
			},
			error: function (error) {
				deferred.reject(error);
			}
		});
		
		return deferred.promise();
	}
	
	function getJSON(url) {
		return makeHttpRequest(url, 'GET');
	}
	
	function postJSON(url, data) {
		return makeHttpRequest(url, 'POST', data);
	}
	
	return {
		getJSON: getJSON,
		postJSON: postJSON
	};
} ());