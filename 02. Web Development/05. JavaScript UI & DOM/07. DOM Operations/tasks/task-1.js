/* globals $ */

/* 

Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed   
*/

module.exports = function () {
  return function (element, contents) {
    var selectedElement,
      divElement,
      documentFragment,
      currentDiv;

    if (arguments.length < 2) {
      throw new Error('Function must take atleast 2 parameters');
    }

    if (typeof (element) !== 'string' && !(element instanceof HTMLElement)) {
      throw new Error('The passed parameter must be either id of type string or DOM element');
    }

    if (typeof (element) === 'string') {
      selectedElement = document.getElementById(element);

      if (selectedElement === null) {
        throw new Error('DOM element with provided ID does not exist');
      }
    } else if (element instanceof HTMLElement) {
      selectedElement = element;
    }

    for (var i = 0, len = contents.length; i < len; i += 1) {
      if (typeof (contents[i]) !== 'string' && typeof (contents[i]) !== 'number') {
        throw new Error('Elements in the contents array must be either of type string or type number');
      }
    }

    var firstChild = selectedElement.firstChild;

    while (firstChild) {
      selectedElement.removeChild(firstChild);
      firstChild = selectedElement.firstChild;
    }

    divElement = document.createElement('div');
    documentFragment = document.createDocumentFragment();

    for (var i = 0, len = contents.length; i < len; i += 1) {
      currentDiv = divElement.cloneNode(true); // Performs a deep copy
      currentDiv.innerHTML = contents[i];
      documentFragment.appendChild(currentDiv);
    }

    selectedElement.appendChild(documentFragment);
  };
};