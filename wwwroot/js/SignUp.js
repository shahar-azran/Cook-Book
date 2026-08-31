function validateSignUp(e) {
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

    var userId = document.getElementById("userid").value.trim();
    var userName = document.getElementById("userName").value.trim();
    var userTel = document.getElementById("userTel").value.trim();
    var userEmail = document.getElementById("userEmail").value.trim();
    var userPassword = document.getElementById("userPassword").value.trim();

    if (userId === "") {
        showError("userid", "userIdError", "אנא הזן תעודת זהות.");
    } else if (isNaN(userId) || userId.length !== 9) {
        showError("userid", "userIdError", "תעודת זהות חייבת להכיל 9 ספרות בדיוק.");
    } else {
        showError("userid", "userIdError", "");
    }

    var namePattern = /^[a-zA-Z\u0590-\u05FF\s]+$/;
    if (userName === "") {
        showError("userName", "userNameError", "אנא הזן שם משתמש.");
    } else if (userName.length < 2) {
        showError("userName", "userNameError", "שם משתמש חייב להכיל לפחות 2 אותיות.");
    } else if (!namePattern.test(userName)) {
        showError("userName", "userNameError", "שם משתמש יכול להכיל אותיות בלבד.");
    } else {
        showError("userName", "userNameError", "");
    }

    var phonePattern = /^05\d{8}$/;
    if (!phonePattern.test(userTel)) {
        showError("userTel", "userTelError", "הזן מספר טלפון נייד תקין (10 ספרות).");
    } else {
        showError("userTel", "userTelError", "");
    }

    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailPattern.test(userEmail)) {
        showError("userEmail", "userEmailError", "הזן כתובת אימייל תקינה (כולל '@').");
    } else {
        showError("userEmail", "userEmailError", "");
    }

    if (userPassword.length < 6) {
        showError("userPassword", "userPasswordError", "הסיסמה חייבת להכיל לפחות 6 תווים.");
    } else {
        showError("userPassword", "userPasswordError", "");
    }

    if (!isValid && e) {
        e.preventDefault();
    }

    return isValid;
}