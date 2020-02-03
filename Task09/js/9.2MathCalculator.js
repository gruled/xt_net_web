function MathCalculator(text) {
    var numRE = /\d+(\.\d+)?/g;
    var opRE = /[\+\-*/]/g;
    var numArr = text.match(numRE);
    var opArr = text.match(opRE);
    var result = numArr[0];
    for (let i = 0; i < opArr.length; i++) {
        switch (opArr[i]) {
            case '*':
                result *= numArr[i + 1];
                break;
            case '/':
                result /= numArr[i + 1];
                break;
            case '+':
                result = parseFloat(result) + parseFloat(numArr[i + 1]);
                break;
            case '-':
                result -= numArr[i + 1];
                break;
        }
    }
    return parseFloat(result);
}

var input = prompt("Введите выражение","3.5 +4*10-5.3 /5 =");
alert(MathCalculator(input).toFixed(2));