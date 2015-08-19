(function () {
	'use strict';

	require.config({
		paths: {
			'jquery': '../scripts/libs/jquery',
			'jqueryCookie': '../scripts/libs/jquery.cookie',
			'sammy': '../scripts/libs/sammy',
			'controller': '../scripts/app/controller',
			'httpRequester': '../scripts/app/http-requester',
			'update': '../scripts/app/update-chat',
			'send': '../scripts/app/send-message',
			'messageParser':'../scripts/app/message-parser'
		}
	});

	require(['jquery', 'controller'], function ($, controller) {
		var url = 'http://crowd-chat.herokuapp.com/posts';

		var chatApp = controller('#main-container', url);
		chatApp.run('#/home');
	});
} ());
