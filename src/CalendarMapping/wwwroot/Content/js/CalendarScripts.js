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
//Detail
    $("#close-event-view").hide();
    $("#create-event-view").click(function () {
        $.ajax({
            type: "GET",
            dataType: "html",
            url: $("#CreateEventUrl").val(),
            success: function (result) {
                $("#create-event-view").hide();
                $("#close-event-view").show();
                $("#show-new-event-form").show();
                $("#show-new-event-form").html(result);
            }
        });
    });
    $("#close-event-view").click(function () {
        $("#show-new-event-form").hide();
        $("#close-event-view").hide();
        $("#create-event-view").show();
    });
});