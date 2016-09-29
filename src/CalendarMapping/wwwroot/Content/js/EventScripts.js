$(document).ready(function () {
//Create
    $("#new-event-form").submit(function (event) {
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
//Index
    $(".delete-event").submit(function (event) {
        event.preventDefault();
        if (confirm("Are you sure you want to delete this event?")) {
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
//Detail
    $("#edit-event").hide();
    $("#edit-form-btn").click(function () {
        $("#edit-event").toggle();
    });
    $("#edit-event").submit(function (event) {
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
    $(".delete-event").submit(function (event) {
        event.preventDefault();
        if (confirm("Are you sure you want to delete this event?")) {
            $.ajax({
                type: "POST",
                dataType: "html",
                data: $(this).serialize(),
                url: $("#DeleteCurrentEventUrl").val(),
                success: function (result) {
                    location.reload();
                }
            });
        }
    });
});