function hhe(inSelect, outSelect) {
    var objSel = document.getElementById(outSelect);
    var objSelSec = document.getElementById(inSelect);
    var optionSel = objSel.options;
    var arr = getSelectedIndexes(objSel);
    if(arr.length>0){
        for (let i = 0; i < arr.length; i++) {
            var s = getSelectedIndexes(objSel);
            optionSel[s[0]].selected=false;
            objSelSec.options[objSelSec.options.length] = optionSel[s[0]];
        }
    }
    else{
        alert("empty output");
    }
}
function getSelectedIndexes(oListbox) {
    var arrIndexes = new Array;
    for (var i = 0; i < oListbox.options.length; i++) {
        if (oListbox.options[i].selected) arrIndexes.push(i);
    }
    return arrIndexes;
}
function hhq(inSelect, outSelect) {
    var objSel = document.getElementById(outSelect);
    var objSelSec = document.getElementById(inSelect);
    var objSelLength = objSel.options.length;
    for (let i = 0; i < objSelLength; i++) {
        objSelSec.options[objSelSec.options.length] = objSel.options[0];
    }
}
