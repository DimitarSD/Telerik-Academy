var User = require('mongoose').model('User');

module.exports = {
  registerUser: function(request, response) {
      var user = {
          username: request.username,
          password: request.password
      };

      User.create(user, function(error, user) {
          if (error) {
              console.log('Failed to register user: ' + error);
              return;
          }
      });
  }
};