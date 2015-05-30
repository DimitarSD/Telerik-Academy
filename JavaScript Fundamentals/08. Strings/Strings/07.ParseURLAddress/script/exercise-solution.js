// 07. Write a script that parses an URL address given in the format: [protocol]://[server]/[resource]
// and extracts from it the [protocol], [server] and [resource] elements. Return the elements in a JSON object.
var jsConsole;
var extractButton = document.getElementById('extract-content');

extractButton.onclick = displayResult;

function extract() {
    var input = jsConsole.read('#input-text');
    var url = document.createElement('a');
    url.href = input;

    var protocol = url.protocol;
    var server = url.hostname;
    var resource = url.pathname;

    return getJSONObject(protocol, server, resource);
}

function displayResult() {
    jsConsole.writeLine(extract())
}

function getJSONObject(protocol, server, resource) {
    var obj = {
        protocol: protocol,
        server: server,
        resource: resource
    }

    return JSON.stringify(obj);
}