$(document).ready(function () {
    //Index
    $("#new-calendar-form").hide();
    $("#new-calendar-btn").click(function () {
        $("#new-calendar-form").toggle();
    });
    $("#new-calendar-form").submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: "POST",
            dataType: "html",
            data: $(this).serialize(),
            url: $("#CreateUrl").val(),
            success: function (result) {
                location.reload();
            }
        });
    });
    $(".edit-calendar").submit(function (event) {
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
    $(".delete-calendar").submit(function (event) {
        event.preventDefault();
        if (confirm("Are you sure you want to delete this calendar?")) {
            $.ajax({
                type: "POST",
                dataType: "html",
                data: $(this).serialize(),
                url: $("#DeleteUrl").val(),
                success: function (result) {
                    location.reload();
                }
            });
        }
    });
});