$(document).ready(function () {
//Index
    $("#remove-favorite-calendar").hide();
    $("#profiled-events-list").submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: "GET",
            dataType: "html",
            data: $(this).serialize(),
            url: $("#EventsListUrl").val(),
            success: function (result) {
                $("#show-events").html(result);
            }
        });
        $("#events-list").hide();
    });
});