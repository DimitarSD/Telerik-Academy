define([], function () {
	var cookie = (function () {
		'use strict';

		// Get the value of cookie by its name
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
			getCookie: getCookie
		};	
	} ());

	return cookie;
});