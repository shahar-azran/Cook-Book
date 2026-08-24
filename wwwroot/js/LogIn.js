function validateLogIn(e) {
    var isValid = true;

    function showError(inputId, errorId, message) {
        var inputGroup = document.getElementById(inputId).parentElement;
        var errorBox = document.getElementById(errorId);
        var textSpan = errorBox.querySelector(".tooltip-text");

        if (message) {
            textSpan.innerText = message;
            inputGroup.classList.add("show-error");
            isValid = false;
        } else {
            textSpan.innerText = "";
            inputGroup.classList.remove("show-error");
        }
    }

    var username = document.getElementById("username").value.trim();
    var password = document.getElementById("password").value.trim();

    if (username === "") {
        showError("username", "usernameError", "אנא הזן שם משתמש.");
    } else {
        showError("username", "usernameError", "");
    }

    if (password === "") {
        showError("password", "passwordError", "אנא הזן סיסמה.");
    } else {
        showError("password", "passwordError", "");
    }

    if (!isValid && e) {
        e.preventDefault();
    }

    return isValid;
}