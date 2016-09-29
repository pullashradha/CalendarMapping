$(document).ready(function () {
//Index
    $(".delete-event").submit(function (event) {
        event.preventDefault();
        if (confirm("Are you sure you want to delete this event?")) {
            $.ajax({
                type: "POST",
                dataType: "html",
                data: $(this).serialize(),
                url: $("#DeleteEventUrl").val(),
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
            url: $("#EditEventUrl").val(),
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