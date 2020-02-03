function remover(text, devideSym) {
    var txt = text;
    for (let i = 0; i < devideSym.length; i++) {
        txt = replacer(txt, devideSym[i]);
    }
    var arr = txt.split("_");
    var arrMain = [];
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] != "") {
            arrMain.push(arr[i]);
        }
    }
    var cutSym = [];
    for (let i = 0; i < arrMain.length; i++) {
        for (let j = 0; j < arrMain[i].length; j++) {
            if (counter(arrMain[i], arrMain[i][j]) > 1) {
                if (!cutSym.includes(arrMain[i][j])) {
                    cutSym.push(arrMain[i][j]);
                }
            }
        }
    }
    var finalTxt = text;
    for (let i = 0; i < cutSym.length; i++) {
        while (finalTxt.includes(cutSym[i])) {
            finalTxt = finalTxt.replace(cutSym[i], "");
        }
    }
    return finalTxt;
}
function replacer(arrText, sym) {
    var t = "" + arrText;
    while (t.includes(sym)) {
        t = t.replace(sym, "_");
    }
    return t;
}
function counter(text, sym) {
    var count = 0;
    for (let i = 0; i < text.length; i++) {
        if (text[i] == sym) {
            count++;
        }
    }
    return count;
}
var input = prompt("Введите предложение","У попа была собака");
alert(remover(input, " \t&!:;,."));