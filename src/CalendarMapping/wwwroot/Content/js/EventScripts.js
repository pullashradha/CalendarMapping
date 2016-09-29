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
    $(".delete-event-details").submit(function (event) {
        event.preventDefault();
        if (confirm("Are you sure you want to delete this event?")) {
            $.ajax({
                type: "POST",
                dataType: "html",
                data: $(this).serialize(),
                url: $("#DeleteCurrentEventUrl").val(),
                success: function (result) {
                    location.replace("Index");
                }
            });
        }
    });
//Google Map
    $("#map-events").submit(function (event) {
        event.preventDefault();
        var address = $("#address").val();

        var showMapDiv = document.getElementById("show-events-map");

        var defaultMapOptions = {
            center: { lat: 45.5207049, lng: -122.6795911 },
            zoom: 16
        }
        var map = new google.maps.Map(showMapDiv, defaultMapOptions);

        var geocoder = new google.maps.Geocoder();
        geocoder.geocode({ "address": address }, function (results, status) {
            if (status === "OK") {
                map.setCenter(results[0].geometry.location);
                var marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location
                });
            } else {
                alert("Geocode was not successful for the following reason: " + status);
            }
        });
    });
});