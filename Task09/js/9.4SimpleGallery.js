var count = 10;
function counter() {
    document.getElementById("hello").textContent = "До перехода осталось: " + count + " секунд";
    if (count > 0) count--;
    if (count == 0) window.location.href = redir;
}
function timeReset() {
    count = 10;
}
function goBack() {
    window.history.back();
}
function check() {
    if (final == true) {
        var result = confirm("Конец последовательности \nOK- начать заново\nCANSEL- выход");
        if (result) {
            window.location.href = redir;
        }
        else {
            alert("Здесь должно было быть закрытие окна, но на это условие разрешили не обращать внимания, т.к. закрытие нынче корректно не работает");
        }
    }
}
check();
let timerId = setInterval(() => { counter(); }, 1000);