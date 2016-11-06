$(document).ready(function () {
//Index
    $("#new-role-form").hide();
    $("#new-role-btn").click(function () {
        $("#new-role-form").toggle();
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
});