/* Task description */
/*
	Write a function a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `number`
		3) it must throw an Error if any of the range params is missing
*/

function findPrimes(from, to) {
	var divisor,
		maxDivisor,
		i,
		isPrime,
		primeNumbers = [];
	
	from = +from;
	to = +to;
	
		if (typeof(from) === 'undefined' || typeof(to) === 'undefined'){
			throw new Error();
		}
		
		if (isNaN(from) || isNaN(to)){
			throw new Error();
		}
		
		for (i = from; i <= to; i += 1){
			maxDivisor = Math.sqrt(i);
			isPrime = true;
			for (divisor = 2; divisor <= maxDivisor; divisor += 1){
				if (i % divisor === 0){
					isPrime = false;
					break;
				}
			}
			
			if (isPrime && i > 1){
				primeNumbers.push(i);
			}
		}
		
		return primeNumbers;
}

module.exports = findPrimes;