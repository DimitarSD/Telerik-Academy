var formidable = require('formidable'),
    http = require('http'),
    fs = require('fs'),
    uuid = require('node-uuid'),
    path = require('path'),
    imageExt = '.jpg',
    port = 9999;

http.createServer(function(request, response) {
    response.writeHead(200, {
        'content-type': 'text/html'
    });

    if (request.url === '/' && request.method.toLowerCase() === 'get') {
        response.end(generateFormHtml());
    }

    if (request.url === '/upload' && request.method.toLowerCase() === 'post') {
        parseFormData(request, response);
        return;
    }

    if (request.url.indexOf('/image') === 0) {
        var imageId = path.join(__dirname, request.url);

        response.writeHead(200, {
            'Content-Type': 'text/html'
        });

        fs.readFile(imageId, function(error, data) {
            if (error) {
                console.log('Cannot read image...');
                return;
            }

            response.write('<html><body><img src="data:image/jpeg;base64,');
            response.write(new Buffer(data).toString('base64'));
            response.end('"/></body></html>');
        });

        return;
    }

    function parseFormData(request, response) {
        var form = new formidable.IncomingForm();
        form.parse(request, function(error, fields, files) {
            var filePath = files.upload.path;
            saveFile(filePath, response);
        });
    }

    function saveFile(filePath, response) {
        fs.readFile(filePath, function(error, original_data) {
            var id = uuid.v1();
            var base64Image = original_data.toString('base64');
            var decodedImage = new Buffer(base64Image, 'base64');
            fs.writeFile('Images/' + id + imageExt, decodedImage, function(error) {});

            response.write('You can access image at: localhost:' + port + '/images/' + id + imageExt);
            response.end();
        });
    }

    response.end();
}).listen(port);

function generateFormHtml() {
    return '<form action="/upload" enctype="multipart/form-data" method="post">' +
        '<input type="file" name="upload" accept="image/*"><br>' +
        '<input type="submit" value="Upload">' +
        '</form>';
}

console.log('Server is running on port: ' + port);