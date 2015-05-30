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

var sixthImage = document.getElementById("ImageSix");
var sixthImageDisplay = document.getElementById("ImageSixDisplay");

var seventhImage = document.getElementById("ImageSeven");
var seventhImageDisplay = document.getElementById("ImageSevenDisplay");

var eightImage = document.getElementById("ImageEight");
var eightImageDisplay = document.getElementById("ImageEightDisplay");

var ninethImage = document.getElementById("ImageNine");
var ninethImageDisplay = document.getElementById("ImageNineDisplay");

var tenImage = document.getElementById("ImageTen");
var tenImageDisplay = document.getElementById("ImageTenDisplay");

firstImage.onclick = function () {
    firstImageDisplay.style.visibility = 'visible';
    secondImageDisplay.style.visibility = 'hidden';
    thirdImageDisplay.style.visibility = 'hidden';
    fourthImageDisplay.style.visibility = 'hidden';
    fifthImageDisplay.style.visibility = 'hidden';
    sixthImageDisplay.style.visibility = 'hidden';
    seventhImageDisplay.style.visibility = 'hidden';
    eightImageDisplay.style.visibility = 'hidden';
    ninethImageDisplay.style.visibility = 'hidden';
    tenImageDisplay.style.visibility = 'hidden';
}

secondImage.onclick = function () {
    firstImageDisplay.style.visibility = 'hidden';
    secondImageDisplay.style.visibility = 'visible';
    thirdImageDisplay.style.visibility = 'hidden';
    fourthImageDisplay.style.visibility = 'hidden';
    fifthImageDisplay.style.visibility = 'hidden';
    sixthImageDisplay.style.visibility = 'hidden';
    seventhImageDisplay.style.visibility = 'hidden';
    eightImageDisplay.style.visibility = 'hidden';
    ninethImageDisplay.style.visibility = 'hidden';
    tenImageDisplay.style.visibility = 'hidden';
}

thirdImage.onclick = function () {
    firstImageDisplay.style.visibility = 'hidden';
    secondImageDisplay.style.visibility = 'hidden';
    thirdImageDisplay.style.visibility = 'visible';
    fourthImageDisplay.style.visibility = 'hidden';
    fifthImageDisplay.style.visibility = 'hidden';
    sixthImageDisplay.style.visibility = 'hidden';
    seventhImageDisplay.style.visibility = 'hidden';
    eightImageDisplay.style.visibility = 'hidden';
    ninethImageDisplay.style.visibility = 'hidden';
    tenImageDisplay.style.visibility = 'hidden';
}

fourthImage.onclick = function () {
    firstImageDisplay.style.visibility = 'hidden';
    secondImageDisplay.style.visibility = 'hidden';
    thirdImageDisplay.style.visibility = 'hidden';
    fourthImageDisplay.style.visibility = 'visible';
    fifthImageDisplay.style.visibility = 'hidden';
    sixthImageDisplay.style.visibility = 'hidden';
    seventhImageDisplay.style.visibility = 'hidden';
    eightImageDisplay.style.visibility = 'hidden';
    ninethImageDisplay.style.visibility = 'hidden';
    tenImageDisplay.style.visibility = 'hidden';
}

fifthImage.onclick = function () {
    firstImageDisplay.style.visibility = 'hidden';
    secondImageDisplay.style.visibility = 'hidden';
    thirdImageDisplay.style.visibility = 'hidden';
    fourthImageDisplay.style.visibility = 'hidden';
    fifthImageDisplay.style.visibility = 'visible';
    sixthImageDisplay.style.visibility = 'hidden';
    seventhImageDisplay.style.visibility = 'hidden';
    eightImageDisplay.style.visibility = 'hidden';
    ninethImageDisplay.style.visibility = 'hidden';
    tenImageDisplay.style.visibility = 'hidden';
}

sixthImage.onclick = function () {
    firstImageDisplay.style.visibility = 'hidden';
    secondImageDisplay.style.visibility = 'hidden';
    thirdImageDisplay.style.visibility = 'hidden';
    fourthImageDisplay.style.visibility = 'hidden';
    fifthImageDisplay.style.visibility = 'hidden';
    sixthImageDisplay.style.visibility = 'visible';
    seventhImageDisplay.style.visibility = 'hidden';
    eightImageDisplay.style.visibility = 'hidden';
    ninethImageDisplay.style.visibility = 'hidden';
    tenImageDisplay.style.visibility = 'hidden';
}

seventhImage.onclick = function () {
    firstImageDisplay.style.visibility = 'hidden';
    secondImageDisplay.style.visibility = 'hidden';
    thirdImageDisplay.style.visibility = 'hidden';
    fourthImageDisplay.style.visibility = 'hidden';
    fifthImageDisplay.style.visibility = 'hidden';
    sixthImageDisplay.style.visibility = 'hidden';
    seventhImageDisplay.style.visibility = 'visible';
    eightImageDisplay.style.visibility = 'hidden';
    ninethImageDisplay.style.visibility = 'hidden';
    tenImageDisplay.style.visibility = 'hidden';
}

eightImage.onclick = function () {
    firstImageDisplay.style.visibility = 'hidden';
    secondImageDisplay.style.visibility = 'hidden';
    thirdImageDisplay.style.visibility = 'hidden';
    fourthImageDisplay.style.visibility = 'hidden';
    fifthImageDisplay.style.visibility = 'hidden';
    sixthImageDisplay.style.visibility = 'hidden';
    seventhImageDisplay.style.visibility = 'hidden';
    eightImageDisplay.style.visibility = 'visible';
    ninethImageDisplay.style.visibility = 'hidden';
    tenImageDisplay.style.visibility = 'hidden';
}

ninethImage.onclick = function () {
    firstImageDisplay.style.visibility = 'hidden';
    secondImageDisplay.style.visibility = 'hidden';
    thirdImageDisplay.style.visibility = 'hidden';
    fourthImageDisplay.style.visibility = 'hidden';
    fifthImageDisplay.style.visibility = 'hidden';
    sixthImageDisplay.style.visibility = 'hidden';
    seventhImageDisplay.style.visibility = 'hidden';
    eightImageDisplay.style.visibility = 'hidden';
    ninethImageDisplay.style.visibility = 'visible';
    tenImageDisplay.style.visibility = 'hidden';
}

tenImage.onclick = function () {
    firstImageDisplay.style.visibility = 'hidden';
    secondImageDisplay.style.visibility = 'hidden';
    thirdImageDisplay.style.visibility = 'hidden';
    fourthImageDisplay.style.visibility = 'hidden';
    fifthImageDisplay.style.visibility = 'hidden';
    sixthImageDisplay.style.visibility = 'hidden';
    seventhImageDisplay.style.visibility = 'hidden';
    eightImageDisplay.style.visibility = 'hidden';
    ninethImageDisplay.style.visibility = 'hidden';
    tenImageDisplay.style.visibility = 'visible';
}