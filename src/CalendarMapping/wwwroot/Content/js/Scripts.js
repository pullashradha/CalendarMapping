$(document).ready(function () {
//Index
    $("#remove-favorite-calendar").hide();
    $("#add-favorite-calendar").submit(function (event) {
        event.preventDefault();
        $("#add-favorite-calendar").hide();
        $("#remove-favorite-calendar").show();
        $.ajax({
            type: "POST",
            dataType: "html",
            data: $(this).serialize(),
            url: $("#AddFavoriteCalendarUrl").val(),
            success: function (result) {
                location.reload();
            }
        });
    });
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