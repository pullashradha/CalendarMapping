$(document).ready(function () {
//Index View
    $("#log-out").click(function () {
        $.ajax({
            type: "POST",
            dataType: "html",
            data: $(this).serialize(),
            url: $("#LogoutUrl").val(),
            success: function (result) {
                location.reload();
            }
        });
    });
//List View
    $(".delete-user").submit(function (event) {
        event.preventDefault();
        if (confirm("Are you sure you want to delete this user?")) {
            $.ajax({
                type: "POST",
                dataType: "html",
                data: $(this).serialize(),
                url: $("#DeleteUserUrl").val(),
                success: function (result) {
                    location.reload();
                }
            });
        }
    });
//Profile View
    $(".edit-user").hide();
    $("#edit-user-btn").click(function () {
        $(".edit-user").toggle();
    });
    $("#edit-user-form").submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: "POST",
            dataType: "html",
            data: $(this).serialize(),
            url: $("#EditUrl").val(),
            success: function (result) {
                location.reload();
            }
        });
    });
    $("#edit-username").submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: "POST",
            dataType: "html",
            data: $(this).serialize(),
            url: $("#EditUsernameUrl").val(),
            success: function (result) {
                location.reload();
            }
        });
    });
    $("#reset-password-form").submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: "POST",
            dataType: "html",
            data: $(this).serialize(),
            url: $("#ResetPasswordUrl").val(),
            success: function (result) {
                location.reload();
            }
        });
    });
    $("#delete-user").submit(function (event) {
        event.preventDefault();
        if (confirm("Are you sure you want to delete your account?")) {
            $.ajax({
                type: "POST",
                dataType: "html",
                data: $(this).serialize(),
                url: $("#DeleteCurrentUserUrl").val(),
                success: function (result) {
                    location.reload();
                }
            });
        }
    });
});