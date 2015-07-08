function solve() {
	var module = (function () {
		var player,
			playlist,
			playable,
			audio,
			video,
			validator,
			CONSTANTS = {
				TextMinLength: 3,
				TextMaxLength: 25,
				AudioMinLength: 0,
				ImdbRatingMinValue: 1,
				ImdbRatingMaxValue: 5
			};

		function indexOfElementWithIdInCollection(collection, id) {
			for (var i = 0; i < collection.length; i += 1) {
				if (collection[i].id === id) {
					return i;
				}
			}

			return -1;
		}

		function getSortingFunction(firstParameter, secondParameter) {
            return function (first, second) {
                if (first[firstParameter] < second[firstParameter]) {
                    return -1;
                }
                else if (first[firstParameter] > second[firstParameter]) {
                    return 1;
                }

                if (first[secondParameter] < second[secondParameter]) {
                    return -1;
                }
                else if (first[secondParameter] > second[secondParameter]) {
                    return 1;
                }
                else {
                    return 0;
                }
            };
        }

		validator = {
			validateIfUndefined: function (value, message) {
				if (typeof (value) === 'undefined') {
					throw new Error(message + ' cannot be undefined');
				}
			},
			validateIfString: function (value, message) {
				if (typeof (value) !== 'string') {
					throw new Error(message + ' must be of type string');
				}
			},
			validateIfEmptyString: function (value, message) {
				if (value === '') {
					throw new Error(message + ' cannot be an empty string');
				}
			},
			validateIfNumber: function (value, message) {
				if (typeof (value) !== 'number') {
					throw new Error(message + ' must be of type number');
				}
			},
			validateIfObject: function (value, message) {
				if (typeof (value) !== 'object') {
					throw new Error(message + ' must be an object');
				}
			},
			validateIfPositiveNumber: function (value, message) {
				if (value <= 0) {
					throw new Error(message + ' must be greater than 0');
				}
			},
			validateString: function (value, message) {
				this.validateIfUndefined(value, message);
				this.validateIfString(value, message);
				this.validateIfEmptyString(value, message);

				if (value.length < CONSTANTS.TextMinLength || value.length > CONSTANTS.TextMaxLength) {
					throw new Error(message + ' must be between ' +
						CONSTANTS.TextMinLength + ' and ' +
						CONSTANTS.TextMaxLength + ' characters');
				}
			},
			validateAudioLength: function (value, message) {
				this.validateIfUndefined(value, message);
				this.validateIfNumber(value, message);

				if (value <= CONSTANTS.AudioMinLength) {
					throw new Error(message + ' must be greater than ' + CONSTANTS.AudioMinLength);
				}
			},
			validateImdbRating: function (value, message) {
				this.validateIfUndefined(value, message);
				this.validateIfNumber(value, message);

				if (value < CONSTANTS.ImdbRatingMinValue || value > CONSTANTS.ImdbRatingMaxValue) {
					throw new Error(message + ' must be between ' +
						CONSTANTS.ImdbRatingMinValue + ' and ' +
						CONSTANTS.ImdbRatingMaxValue);
				}
			},
			validatePlayableId: function (value) {
				this.validateIfUndefined(value, 'Playable ID');

				if (typeof (value) !== 'number') {
					value = value.id;
				}

				this.validateIfUndefined(value);
				return value;
			},
			validatePageAndSize: function (page, size, length) {
				this.validateIfUndefined(page);
                this.validateIfUndefined(size);
                this.validateIfNumber(page);
                this.validateIfNumber(size);

                if (page < 0) {
                    throw new Error('Page must be a positive number');
                }

                this.validateIfPositiveNumber(size);

				if (page * size > length) {
                    throw new Error('Invalid page or size');
                }
			}
		};

		player = (function () {
			var currentPlayerID = 0,
				player = Object.create({});

			Object.defineProperty(player, 'init', {
				value: function (name) {
					this.name = name;
					this._id = ++currentPlayerID;
					this._playlists = [];
					return this;
				}
			});

			Object.defineProperty(player, 'name', {
				get: function () {
					return this._name;
				},
				set: function (value) {
					validator.validateString(value, 'Player name');
					this._name = value;
				}
			});

			Object.defineProperty(player, 'id', {
				get: function () {
					return this._id;
				}
			});

			Object.defineProperty(player, 'addPlaylist', {
				value: function (playlistToAdd) {
					validator.validateIfUndefined(playlistToAdd, 'Playlist');
					validator.validateIfUndefined(playlistToAdd.id, 'Playlist ID');

					this._playlists.push(playlistToAdd);
					return this;
				}
			});

			Object.defineProperty(player, 'getPlaylistById', {
				value: function (id) {
                    validator.validateIfUndefined(id);
                    validator.validateIfNumber(id);
                    validator.validateIfPositiveNumber(id);

                    for (var i = 0; i < this._playlists.length; i += 1) {
                        var currentPlaylist = this._playlists[i];
                        if (currentPlaylist.id === id) {
                            return currentPlaylist;
                        }
                    }

                    return null;
                }
			});

			Object.defineProperty(player, 'removePlaylist', {
				value: function (id) {
                    id = validator.validatePlayableId(id);

                    var foundIndex = indexOfElementWithIdInCollection(this._playlists, id);
                    if (foundIndex < 0) {
                        throw new Error('Playlist with id ' + id + ' was not found in player');
                    }

                    this._playlists.splice(foundIndex, 1);
                    return this;
                }
			});

			Object.defineProperty(player, 'listPlaylists', {
				value: function (page, size) {
                    validator.validatePageAndSize(page, size, this._playlists.length);

                    return this._playlists
                        .slice()
                        .sort(getSortingFunction('name', 'id'))
                        .splice(page * size, size);
                }
			});

			Object.defineProperty(player, 'contains', {
				value: function (playable, playlist) {
                    for (var i = 0; i < playlist.length; i += 1) {
                        var currentPlayble = playlist[i];
                        if (currentPlayble.id === playable.id) {
                            return true;
                        }
                    }

                    return false;
                }
			});

			Object.defineProperty(player, 'search', {
				value: function (pattern) {
                    var result = [],
                        isFound = false;
                    pattern = pattern.toLowerCase();

                    for (var i = 0; i < this._playlists.length; i += 1) {
                        var currentPlaylist = this._playlists[i];

                        for (var j = 0; j < currentPlaylist.length; i += 1) {
                            var currentPlayable = currentPlaylist[i];
                            if (currentPlayable.title.indexOf(pattern) !== -1) {
                                var newPlaylist = {
                                    name: currentPlaylist.name,
                                    id: currentPlaylist.id
                                };
                                isFound = true;
                                result.push(newPlaylist);
                                break;
                            }
                        }
                    }

                    if (!isFound) {
                        return [];
                    }

                    return result;
                }
			});

			return player;
		} ());

		playlist = (function () {
			var currentPlaylistID = 0;
			playlist = Object.create({});
			
			// Create constructor
			Object.defineProperty(playlist, 'init', {
				value: function (name) {
					this.name = name;
					this._id = ++currentPlaylistID;
					this._playables = [];
					return this;
				}
			});
			
			// Create properties
			Object.defineProperty(playlist, 'name', {
				get: function () {
					return this._name;
				},
				set: function (value) {
					validator.validateString(value, 'Playlist name');
					this._name = value;
				}
			});

			Object.defineProperty(playlist, 'id', {
				get: function () {
					return this._id;
				}
			});
			
			// Create methods
			Object.defineProperty(playlist, 'addPlayable', {
				value: function (playable) {
					validator.validateIfUndefined(playable, 'Playable');
					validator.validateIfObject(playable, 'Playable');

					this._playables.push(playable);
					return this;
				}
			});

			Object.defineProperty(playlist, 'getPlayableById', {
				value: function (id) {
					validator.validateIfUndefined(id, 'Playable ID');
					validator.validateIfNumber(id, 'Playable ID');
					validator.validateIfPositiveNumber(id, 'Playable ID');

					for (var i = 0; i < this._playables.length; i += 1) {
						var currentPlayable = this._playables[i];
						if (currentPlayable.id === id) {
							return currentPlayable;
						}
					}

					return null;
				}
			});

			Object.defineProperty(playlist, 'removePlayable', {
				value: function (id) {
					id = validator.validatePlayableId(id);

					var foundIndex = indexOfElementWithIdInCollection(this._playables, id);
					if (foundIndex < 0) {
						throw new Error('Playlist with the given id is not existing');
					}

					this._playables.splice(foundIndex, 1);
					return this;
				}
			});

			Object.defineProperty(playlist, 'listPlayables', {
				value: function (page, size) {
                    page = page || 0;
                    size = size || 9007199254740992;
                    validator.validatePageAndSize(page, size, this._playables.length);

                    return this
                        ._playables
                        .slice()
                        .sort(getSortingFunction('title', 'id'))
                        .splice(page * size, size);
                }
			});

			return playlist;
		} ());

		playable = (function () {
			var currentPlayableID = 0,
				playable = Object.create({});
				
			// Create constructor
			Object.defineProperty(playable, 'init', {
				value: function (title, author) {
					this.title = title;
					this.author = author;
					this._id = ++currentPlayableID;
					return this;
				}
			});
			
			// Create properties
			Object.defineProperty(playable, 'title', {
				get: function () {
					return this._title;
				},
				set: function (value) {
					validator.validateString(value, 'Playable title');
					this._title = value;
				}
			});

			Object.defineProperty(playable, 'author', {
				get: function () {
					return this._author;
				},
				set: function (value) {
					validator.validateString(value, 'Playable title');
					this._author = value;
				}
			});

			Object.defineProperty(playable, 'id', {
				get: function () {
					return this._id;
				}
			});

			// Create methods
			Object.defineProperty(playable, 'play', {
				value: function () {
					var playFormat = this.id + '. ' + this.title + ' - ' + this.author;
					return playFormat;
				}
			});

			return playable;
		} ());

		audio = (function (parent) {
			var audio = Object.create(parent);
			
			// Create constructor
			Object.defineProperty(audio, 'init', {
				value: function (title, author, length) {
					parent.init.call(this, title, author);
					this.length = length;
					return this;
				}
			});
			
			// Create constructor
			Object.defineProperty(audio, 'length', {
				get: function () {
					return this._length;
				},
				set: function (value) {
					validator.validateAudioLength(value, 'Audio length');
					this._length = value;
				}
			});
			
			// Create methods
			Object.defineProperty(audio, 'play', {
				value: function () {
					var baseString = parent.play.call(this);
					return baseString + ' - ' + this.length;
				}
			});

			return audio;
		} (playable));

		video = (function (parent) {
			var video = Object.create(parent);
			
			// Create constructor
			Object.defineProperty(video, 'init', {
				value: function (title, author, imdbRating) {
					parent.init.call(this, title, author);
					this.imdbRating = imdbRating;
					return this;
				}
			});
			
			// Create properties
			Object.defineProperty(video, 'imdbRating', {
				get: function () {
					return this._imdbRating;
				},
				set: function (value) {
					validator.validateImdbRating(value, 'IMDB rating');
					this.__imdbRating = value;
				}
			});

			Object.defineProperty(video, 'play', {
				value: function () {
					var baseString = parent.play.call(this);
					return baseString + ' - ' + this.imdbRating;
				}
			});

			return video;
		} (playable));

		return {
            getPlayer: function (name) {
                return Object.create(player).init(name);
            },
            getPlaylist: function (name) {
                return Object.create(playlist).init(name);
            },
            getAudio: function (title, author, length) {
                return Object.create(audio).init(title, author, length);
            },
            getVideo: function (title, author, imdbRating) {
                return Object.create(video).init(title, author, imdbRating);
            }
        };

	} ());

	return module;
}

module.exports = solve;