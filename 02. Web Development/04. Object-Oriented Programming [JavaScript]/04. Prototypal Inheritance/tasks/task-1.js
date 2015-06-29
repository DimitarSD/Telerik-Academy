/* Task Description */
/*
* Create an object domElement, that has the following properties and methods:
  * use prototypal inheritance, without function constructors
  * method init() that gets the domElement type
    * i.e. `Object.create(domElement).init('div')`
  * property type that is the type of the domElement
    * a valid type is any non-empty string that contains only Latin letters and digits
  * property innerHTML of type string
    * gets the domElement, parsed as valid HTML
      * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
    * attributes must be sorted in ascending alphabetical order by their name, not in the order they were added
  * property content of type string
    * sets the content of the element
    * works only if there are no children
  * property attributes
    * each attribute has name and value
    * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
  * property children
    * each child is a domElement or a string
  * property parent
    * parent is a domElement
  * method appendChild(domElement / string)
    * appends to the end of children list
  * method addAttribute(name, value)
    * throw Error if type is not valid
  * method removeAttribute(attribute)
    * throw Error if attribute does not exist in the domElement
*/


/* Example

var meta = Object.create(domElement)
	.init('meta')
	.addAttribute('charset', 'utf-8');

var head = Object.create(domElement)
	.init('head')
	.appendChild(meta)

var div = Object.create(domElement)
	.init('div')
	.addAttribute('style', 'font-size: 42px');

div.content = 'Hello, world!';

var body = Object.create(domElement)
	.init('body')
	.appendChild(div)
	.addAttribute('id', 'cuki')
	.addAttribute('bgcolor', '#012345');

var root = Object.create(domElement)
	.init('html')
	.appendChild(head)
	.appendChild(body);

console.log(root.innerHTML);
Outputs:
<html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
*/


function solve() {
  var domElement = (function () {
    
    // -------- Validation --------
    function typeValidation(type) {
      if (typeof (type) !== 'string' || type === '' || !/^[A-Za-z0-9]*$/.test(type)) {
        throw new Error('Type must be a non-empty string that contain only latin letters and digits.');
      }
    }

    function attributeValidation(attributeName) {
      if (typeof (attributeName) !== 'string' || attributeName === '' || !/^[A-Za-z0-9\-]*$/.test(attributeName)) {
        throw new Error('Attribute name must be a non-empty string that contain only latin letters, digits and/or dashes.');
      }
    }

    function childValidation(child) {
      if (typeof (child) !== 'string' && Object.getPrototypeOf(child) !== domElement) {
        throw new Error('Child must be either string or DOM element.');
      }
    }

    function parentValidation(parent) {
      if (Object.getPrototypeOf(parent) !== domElement) {
        throw new Error('Parent must be a DOM element.');
      }
    }

    function contentValidation(content) {
      if (typeof (content) !== 'string') {
        throw new Error('Content must be of type string.');
      }
    }

    function getSortedAttributes(attributes) {
      var attributesAsArray = [];

      for (var prop in attributes) {
        if (attributes.hasOwnProperty(prop)) {
          attributesAsArray.push(prop);
        }
      }

      attributesAsArray = attributesAsArray.sort();

      return attributesAsArray;
    }

    var domElement = {
      // Initialize all propeties that we need. We use 'init' as a constructor.
      init: function (type) {
        this.type = type;
        this._attributes = {};
        this._children = [];
        this._content = '';
        this._parent = null;
        return this;
      },
      appendChild: function (child) {
        childValidation(child);
        
        child.parent = this;
        this._children.push(child);
        
        return this;
      },
      addAttribute: function (name, value) {
        attributeValidation(name);
        
        this._attributes[name] = value;
        
        return this;
      },
      removeAttribute: function (attributeName) {
        if (!this.attributes[attributeName]) {
          throw new Error('You cannot remove a non-existing attribute.');
        }

        delete this.attributes[attributeName];
        return this;
      },
      get innerHTML() {
        var output = '<' + this.type;

        if (this.attributes) {
          var sortedAttributes = getSortedAttributes(this.attributes);
          
          for (var i = 0, len = sortedAttributes.length; i < len; i += 1) {
            var attributeName = sortedAttributes[i];
            var attributeValue = this.attributes[attributeName];
            
            output += ' ' + attributeName + '="' + attributeValue + '"';
          }
        }

        output += '>';

        if (this.children.length > 0) {
          for (var i = 0; i < this.children.length; i += 1) {
            var currentChildren = this.children[i];
            if (typeof (currentChildren) === 'string') {
              output += currentChildren;
            } else {
              output += currentChildren.innerHTML;
            }
          }
        } else {
          output += this.content;
        }

        output += '</' + this.type + '>';
        return output;
      },
    };
    
    Object.defineProperties(domElement, {
      type: {
        get: function () {
          return this._type;
        },
        set: function (value) {
          typeValidation(value);
          this._type = value;
        }
      },
      children: {
        get: function () {
          return this._children;
        }
      },
      parent: {
        get: function () {
          return this._parent;
        },
        set: function (value) {
          parentValidation(value);
          this._parent = value;
        }
      },
      attributes: {
        get: function () {
          return this._attributes;
        }
      },
      content: {
        get: function () {
          return this._content;
        },
        set: function (value) {
          contentValidation(value);
          this._content = value;
        }
      }
    });
    
    return domElement;
  } ());
  return domElement;
}

module.exports = solve;
