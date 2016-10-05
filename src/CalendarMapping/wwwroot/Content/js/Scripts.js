$(document).ready(function () {
    //Index
    $(".glyphicon-heart").hide();
    $(".glyphicon-heart-empty").click(function () {
        $(".glyphicon-heart-empty").hide();
        $(".glyphicon-heart").show();
        $.ajax({
            type: "POST",
            dataType: "html",
            data: $(this).serialize(),
            url: $("#FavoriteCalendarsUrl").val(),
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