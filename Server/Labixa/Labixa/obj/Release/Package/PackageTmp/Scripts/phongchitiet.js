$(document).ready(function () {
    $("#up-button-tour").click(function () {
        var listItem = document.getElementsByClassName("item item-z");
        for (var i = 0; i < listItem.length; i++) {
            if ($(listItem[i]).hasClass("active")) {
                $(listItem[i]).toggleClass("active");
                if (i - 1 < 0) {
                    $(listItem[listItem.length - 1]).toggleClass("active");
                }
                else {
                    $(listItem[i - 1]).toggleClass("active");
                }
                break;
            }
        }
        event.preventDefault();
    });
    $("#up-button-room").click(function () {
        var listItem = document.getElementsByClassName("item item-1");
        for (var i = 0; i < listItem.length; i++) {
            if ($(listItem[i]).hasClass("active")) {
                $(listItem[i]).toggleClass("active");
                if (i - 1 < 0) {
                    $(listItem[listItem.length - 1]).toggleClass("active");
                }
                else {
                    $(listItem[i - 1]).toggleClass("active");
                }
                break;
            }
        }
        event.preventDefault();
    });
    $("#down-button-tour").click(function () {
        var listItem = document.getElementsByClassName("item item-z");
        for (var i = 0; i < listItem.length; i++) {
            if ($(listItem[i]).hasClass("active")) {
                $(listItem[i]).toggleClass("active");
                if (i + 1 == listItem.length) {
                    $(listItem[0]).toggleClass("active");
                }
                else {
                    $(listItem[i + 1]).toggleClass("active");
                }
                break;
            }
        }
        event.preventDefault();
    });
    $("#down-button-room").click(function () {
        var listItem = document.getElementsByClassName("item item-1");
        for (var i = 0; i < listItem.length; i++) {
            if ($(listItem[i]).hasClass("active")) {
                $(listItem[i]).toggleClass("active");
                if (i + 1 == listItem.length) {
                    $(listItem[0]).toggleClass("active");
                }
                else {
                    $(listItem[i + 1]).toggleClass("active");
                }
                break;
            }
        }
        event.preventDefault();
    });

    $("#service-body").niceScroll({ cursorcolor: "white", cursorborder: "1px solid #969696" });
    $("#about").niceScroll({ cursorcolor: "white", cursorborder: "1px solid #969696" });
    $("#about-event").niceScroll({ cursorcolor: "white", cursorborder: "1px solid #969696" });

    $("div.xxx").hover(
    function () {
        $(this).find("div.content-hide-1").slideToggle("slow");
    },
    function () {
        $(this).find("div.content-hide-1").slideToggle("slow");
    }
  );
});