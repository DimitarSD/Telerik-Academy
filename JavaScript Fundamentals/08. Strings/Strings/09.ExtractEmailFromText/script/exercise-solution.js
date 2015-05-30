// 09. Write a function for extracting all email addresses from given text. 
// All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails. Return the emails as array of strings.
var jsConsole;
var extractButton = document.getElementById('extract-emails');

extractButton.onclick = displayAllExtractedEmails;

function extractEmails() {
    var text = jsConsole.read('#input-text');
    return text.match(/([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9._-]+)/gi);
}

function displayAllExtractedEmails() {
    var emails = extractEmails();

    jsConsole.writeLine(emails.join(', '));
}