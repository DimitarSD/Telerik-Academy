var env = process.env.NODE_ENV || 'development',
    config = require('./server/config/config')[env],
    chat = require('./server/controllers/chatController');

chat.init(config);
chat.registerUser({ username: 'DonchoMinkov', password: '123456q' });
chat.registerUser({ username: 'NikolayKostov', password: '123456q' });

chat.sendMessage({
    from: 'DonchoMinkov',
    to: 'NikolayKostov',
    text: 'Hey, Niki!'
});

chat.sendMessage({
    from: 'NikolayKostov',
    to: 'DonchoMinkov',
    text: 'Hey, Doncho!'
});

chat.sendMessage({
    from: 'NikolayKostov',
    to: 'DonchoMinkov',
    text: 'How are you today?'
});

chat.sendMessage({
    from: 'DonchoMinkov',
    to: 'NikolayKostov',
    text: 'I\'m fine! You?'
});

chat.sendMessage({
    from: 'NikolayKostov',
    to: 'DonchoMinkov',
    text: 'Same here.'
});

// Wait unit all messages where saved
setTimeout(function () {
    chat.getMessages({
        with: 'DonchoMinkov',
        and: 'NikolayKostov'
    });
}, 1000);