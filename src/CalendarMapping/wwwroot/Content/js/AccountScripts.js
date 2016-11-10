$(document).ready(function () {
//Login
    $(".login-form").submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: "POST",
            dataType: "html",
            data: $(this).serialize(),
            url: $("#LoginUrl").val(),
            success: function (result) {
                location.href = "/User";
            }
        });
    });
//Register
    $(".register-form").submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: "POST",
            dataType: "json",
            data: $(this).serialize(),
            url: $("#RegisterUrl").val(),
            success: function (result) {
                if (result === "succeeded") {
                    location.href = "/User";
                } else {
                    location.href = "/Account/Register";
                }
            }
        });
    });
});