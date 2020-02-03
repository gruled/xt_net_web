//alert("hello");
function hhe() {
    var objSel = document.firstForm.firstSelect;
    var objSelSec = document.secondForm.secondSelect;
    var optionSel = objSel.options;
    for (let i = 0; i < optionSel.length; i++) {
        if(optionSel[i].selected){
            objSelSec.options[objSelSec.options.length] = optionSel[i];
        }
    }
}