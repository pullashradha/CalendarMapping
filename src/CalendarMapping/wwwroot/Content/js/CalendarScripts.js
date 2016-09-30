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
            url: $("#CreateCalendarUrl").val(),
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
            url: $("#EditCalendarUrl").val(),
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
                url: $("#DeleteCalendarUrl").val(),
                success: function (result) {
                    location.reload();
                }
            });
        }
    });
//Detail
    $("#new-event-form").hide();
    $("#new-event-btn").click(function () {
        $("#new-event-form").toggle();
    });
    $("#new-event-form").submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: "POST",
            dataType: "html",
            data: $(this).serialize(),
            url: $("#CreateEventUrl").val(),
            success: function (result) {
                location.reload();
            }
        });
    });
    $("#events-list").submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: "GET",
            dataType: "json",
            data: $(this).serialize(),
            url: $("#EventsListUrl").val(),
            success: function (result) {
                for (var i = 0; i < result.length; i++)
                {
                    $("#individual-event").append("<h5>" + result[i].description + "</h5>");
                }
            }
        });
        $("#events-list").hide();
    });
    $(".delete-calendar-details").submit(function (event) {
        event.preventDefault();
        if (confirm("Are you sure you want to delete this calendar?")) {
            $.ajax({
                type: "POST",
                dataType: "html",
                data: $(this).serialize(),
                url: $("#DeleteCurrentCalendarUrl").val(),
                success: function (result) {
                    location.replace("Index");
                }
            });
        }
    });
//Calendar Events Map
    $("#map-calendar-events").submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: "POST",
            dataType: "json",
            data: $(this).serialize(),
            url: $("#CalendarEventsMapUrl").val(),
            success: function (eventsList) {
                var userLocationImg = "http://maps.google.com/mapfiles/ms/icons/purple-dot.png";
                var showMapDiv = document.getElementById("show-calendar-events-map");

                var geoSuccess = function (position) {
                    var userLat = position.coords.latitude;
                    var userLng = position.coords.longitude;

                    var defaultMapOptions = {
                        center: { lat: userLat, lng: userLng },
                        zoom: 16
                    }
                    var map = new google.maps.Map(showMapDiv, defaultMapOptions);

                    var userLocationMarker = new google.maps.Marker({
                        map: map,
                        position: { lat: userLat, lng: userLng },
                        icon: userLocationImg
                    });
                    var userInfoWindow = new google.maps.InfoWindow({
                        content: "Your Location"
                    });
                    userLocationMarker.addListener("click", function () {
                        userInfoWindow.open(map, userLocationMarker);
                    });

                    for (var i = 0; i < eventsList.length; i++) {
                        mapEvent(map, eventsList[i]);
                    }
                };

                var mapEvent = function (map, event) {
                    var geocoder = new google.maps.Geocoder();

                    var infoWindowContent = "<a href='/Event/Detail?eventId=" + event.id + "'>" + event.description + "</a>";

                    geocoder.geocode({ "address": event.address }, function (results, status) {
                        if (status == "OK") {
                            var eventMarker = new google.maps.Marker({
                                map: map,
                                position: results[0].geometry.location
                            });
                            var eventInfoWindow = new google.maps.InfoWindow({
                                content: infoWindowContent
                            });
                            eventMarker.addListener("click", function () {
                                eventInfoWindow.open(map, eventMarker);
                            });
                        } else {
                            alert("Geocode was not successful for the following reason: " + status);
                        }
                    });
                }

                var geoError = function (error) {
                    console.log("Error occurred. Error code: " + error.code);
                }

                var geoOptions = {
                    enableHighAccuracy: true
                }

                navigator.geolocation.getCurrentPosition(geoSuccess, geoError, geoOptions);
            }
        });
    });
});