let calculations = 0;

function fibonacciRecursive(n) {
    calculations++;
    if (n < 2) return n;
    return fibonacciRecursive(n - 1) + fibonacciRecursive(n - 2);
}

function fibonacciMemoizedTopDown() {
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

function fibonacciMemoizedBottomUp(n)
{
    let answers = [0, 1];
    if (n < 2) return n;
    for (let i = 2; i <= n; ++i)
    {
        calculations++;
        answers.push(answers[i - 2] + answers[i - 1]);        
    }
    return answers.pop();
}

calculations = 0;
console.log("Recursive", fibonacciRecursive(10));
console.log("Recursive calcuations", calculations);

calculations = 0;
const memoizedFib = fibonacciMemoizedTopDown();
console.log('Memoized Top Down', memoizedFib(10));
console.log('Memoized Calculations', calculations);

calculations = 0;
console.log('Memoized Bottom Up', fibonacciMemoizedBottomUp(10));
console.log('Memoized Calculations', calculations);