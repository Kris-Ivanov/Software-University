function findNthDigit(arr) {
    var n = arr[0];
    var num = arr[1].toString().replace('.', '').replace('-', '');
    if (num.length < n) {
        console.log('The number doesn’t have ' + n + ' digits');
    } else {
        for (var i = 1; i < n; i++) {
            num = Math.floor(num / 10);
        }
        console.log(num % 10);
    }
}
findNthDigit([1, 6]);
findNthDigit([2, -55]);
findNthDigit([6, 923456]);
findNthDigit([3, 1451.78]);
findNthDigit([6, 888.88]);