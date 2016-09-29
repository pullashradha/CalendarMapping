$(document).ready(function () {
//Index
    $("#new-role-form").hide();
    $("#new-role-btn").click(function () {
        $("#new-role-form").toggle();
    });
    $("#new-role-form").submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: "POST",
            dataType: "html",
            data: $(this).serialize(),
            url: $("#CreateRoleUrl").val(),
            success: function (result) {
                location.reload();
            }
        });
    });
    $(".edit-role").submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: "POST",
            dataType: "html",
            data: $(this).serialize(),
            url: $("#EditRoleUrl").val(),
            success: function (result) {
                location.reload();
            }
        });
    });
    $(".delete-role").submit(function (event) {
        event.preventDefault();
        if (confirm("Are you sure you want to delete this role?")) {
            $.ajax({
                type: "POST",
                dataType: "html",
                data: $(this).serialize(),
                url: $("#DeleteRoleUrl").val(),
                success: function (result) {
                    location.reload();
                }
            });
        }
    });
    $("#add-user-form").submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: "POST",
            dataType: "html",
            data: $(this).serialize(),
            url: $("#AddUserUrl").val(),
            success: function (result) {
                location.reload();
            }
        });
    });
    $("#remove-user-form").submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: "POST",
            dataType: "html",
            data: $(this).serialize(),
            url: $("#RemoveUserUrl").val(),
            success: function (result) {
                location.reload();
            }
        });
    });
});