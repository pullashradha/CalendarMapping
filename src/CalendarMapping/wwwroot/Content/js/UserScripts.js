$(document).ready(function () {
//List
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
//Profile
    $(".edit-user").hide();
    $("#edit-user-btn").click(function () {
        $(".edit-user").toggle();
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