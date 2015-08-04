/* globals $ */

/* 

Create a function that takes an id or DOM element and:

* If an id is provided, select the element
* Finds all elements with class button or content within the provided element
  * Change the content of all .button elements with "hide"
* When a .button is clicked:
  * Find the topmost .content element, that is before another .button and:
    * If the .content is visible:
        * Hide the .content
        * Change the content of the .button to "show"
    * If the .content is hidden:
        * Show the .content
        * Change the content of the .button to "hide"
    * If there isn't a .content element after the clicked .button and before other .button, do nothing
* Throws if:
  * The provided DOM element is non-existant
  * The id is either not a string or does not select any DOM element
  

*/

function solve(){
  return function (selector) {
    var selectedElement,
      elementsWithClassButton,
      elementsWithClassContent;

    if (typeof (selector) === 'string') {
      selectedElement = document.getElementById(selector);

      if (selectedElement === null) {
        throw new Error('Element with the provided ID does not exist');
      }
    } else if (selector instanceof HTMLElement){
      selectedElement = selector;
    } else {
      throw new Error('Invalid selector');
    }
    
    elementsWithClassButton = document.getElementsByClassName('button');
    elementsWithClassContent = document.getElementsByClassName('content');
    
    for (var i = 0, len = elementsWithClassButton.length; i < len; i += 1) {
      elementsWithClassButton[i].innerHTML = 'hide';
    }
    
    for (var i = 0, len = elementsWithClassButton.length; i < len; i += 1) {
      var currentButton = elementsWithClassButton[i];
      
      currentButton.addEventListener('click', function (ev) {
        var clickedButton = ev.target;
        var nextContent = clickedButton.nextElementSibling;
        
        while (nextContent && nextContent.className.indexOf('content') < 0) {
          nextContent = nextContent.nextElementSibling;
        }
        
        var isContentVisible = nextContent.style.display === '';
        
        if (isContentVisible) {
          nextContent.style.display = 'none';
          clickedButton.innerHTML = 'show';
        } else {
          nextContent.style.display = ''; 
          clickedButton.innerHTML = 'hide';
        }
      });
    }
  };
};

module.exports = solve;