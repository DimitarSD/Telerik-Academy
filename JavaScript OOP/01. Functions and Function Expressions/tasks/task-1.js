/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

function sum(arrayOfNumbers) {
		var i,
	 		len = arrayOfNumbers.length,
	 		currentSum = 0;
	
	if (len === 0){
		return null;
	}
	
	if (typeof arrayOfNumbers === 'undefined'){
			throw new Error();
		}
	
	for	(i = 0; i < len; i += 1){
		if (isNaN(arrayOfNumbers[i])){
			throw new Error();
		}
		
		currentSum += +arrayOfNumbers[i];
	}
	
	return currentSum;
}

module.exports = sum;