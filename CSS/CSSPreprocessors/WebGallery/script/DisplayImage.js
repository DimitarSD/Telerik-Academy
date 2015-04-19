var firstImage = document.getElementById("ImageOne");
var firstImageDisplay = document.getElementById("ImageOneDisplay");

var secondImage = document.getElementById("ImageTwo");
var secondImageDisplay = document.getElementById("ImageTwoDisplay");

var thirdImage = document.getElementById("ImageThree");
var thirdImageDisplay = document.getElementById("ImageThreeDisplay");

var fourthImage = document.getElementById("ImageFour");
var fourthImageDisplay = document.getElementById("ImageFourDisplay");

var fifthImage = document.getElementById("ImageFive");
var fifthImageDisplay = document.getElementById("ImageFiveDisplay");

firstImage.onclick = function () {
    firstImageDisplay.style.visibility = 'visible';
    secondImageDisplay.style.visibility = 'hidden';
    thirdImageDisplay.style.visibility = 'hidden';
    fourthImageDisplay.style.visibility = 'hidden';
    fifthImageDisplay.style.visibility = 'hidden';
}

secondImage.onclick = function () {
    firstImageDisplay.style.visibility = 'hidden';
    secondImageDisplay.style.visibility = 'visible';
    thirdImageDisplay.style.visibility = 'hidden';
    fourthImageDisplay.style.visibility = 'hidden';
    fifthImageDisplay.style.visibility = 'hidden';
}

thirdImage.onclick = function () {
    firstImageDisplay.style.visibility = 'hidden';
    secondImageDisplay.style.visibility = 'hidden';
    thirdImageDisplay.style.visibility = 'visible';
    fourthImageDisplay.style.visibility = 'hidden';
    fifthImageDisplay.style.visibility = 'hidden';
}

fourthImage.onclick = function () {
    firstImageDisplay.style.visibility = 'hidden';
    secondImageDisplay.style.visibility = 'hidden';
    thirdImageDisplay.style.visibility = 'hidden';
    fourthImageDisplay.style.visibility = 'visible';
    fifthImageDisplay.style.visibility = 'hidden';
}

fifthImage.onclick = function () {
    firstImageDisplay.style.visibility = 'hidden';
    secondImageDisplay.style.visibility = 'hidden';
    thirdImageDisplay.style.visibility = 'hidden';
    fourthImageDisplay.style.visibility = 'hidden';
    fifthImageDisplay.style.visibility = 'visible';
}