/* global OAuth */
(function () {
	var applicationApiKey = 'DdW8JWhQugAsv47lpQwswLHWxtg';

	function getAuthorisationPromise() {
		OAuth.initialize(applicationApiKey);
		var authorisationPromise = OAuth.popup('twitter', {
			cache: true
		});

		return authorisationPromise;
	}

	function renderTweets(data) {
		var ul = $('<ul/>'),
			template = $('#tweet-template').html(),
			localeTimeStringOptions = {
				weekday: 'long',
				year: 'numeric',
				month: 'short',
				day: 'numeric',
				hour: '2-digit',
				minute: '2-digit'
			};

		for (var i = 0, len = data.length; i < len; i += 1) {
			var user = data[i].user,
				tweet = {
					username: user.screen_name,
					screen_name: '@' + user.screen_name,
					name: user.name,
					img_src: user.profile_image_url,
					tweet_message: data[i].text,
					time_posted: new Date(data[i].created_at).toLocaleTimeString('en-US', localeTimeStringOptions)
				},
				compiledTemplate = Handlebars.compile(template);

			ul.append(compiledTemplate(tweet));
		}
		
		$('#tweets-container').append(ul);
	}

	$('#show-tweets').on('click', function () {
		var username = $('#twitter-username-input').val(),
			tweets = $('#number-messages-input').val(),
			numberOfTweets = parseInt(tweets),
			url = 'https://api.twitter.com/1.1/statuses/user_timeline.json?count=' +
				numberOfTweets + '&screen_name=' + username;

		$('#tweets-container').html('');

		getAuthorisationPromise()
			.done(function (response) {
				response
					.get(url)
					.done(function (data) {
						renderTweets(data);
					})
					.fail(function (error) {
						alert(error);
					});
			});
	});
} ());