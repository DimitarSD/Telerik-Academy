
var myVideo = document.getElementById("BTV");

var playButton = document.getElementById("PlayButton");
playButton.onclick = play;

myVideo.onclick = pause;

var image = document.getElementById("NewsBTV");

myVideo.onended = function () {
    playButton.style.visibility = 'visible';
    myVideo.style.visibility = 'hidden';
}

function play() {
    myVideo.play();
    myVideo.style.visibility = 'visible';
    playButton.style.visibility = 'hidden'
}

function pause() {
    myVideo.pause();
    playButton.style.visibility = 'visible';
}
