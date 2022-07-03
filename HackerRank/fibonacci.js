let calculations = 0;

function fibonacciRecursive(n) {
    calculations++;
    if (n < 2) return n;
    return fibonacciRecursive(n - 1) + fibonacciRecursive(n - 2);
}

function fibonacciMemoized() {
    let cache = {};
    return function fib(n) {
        calculations++;
        if (n in cache) {
            return cache[n];
        }
        if (n < 2) return n;
        else {
            let result = fib(n - 1) + fib(n - 2);
            cache[n] = result;
            return result;
        }
    }
}

calculations = 0;
console.log("Recursive", fibonacciRecursive(10));
console.log("Recursive calcuations", calculations);

calculations = 0;
const memoizedFib = fibonacciMemoized();
console.log('Memoized', memoizedFib(10));
console.log('Memoized Calculations', calculations);