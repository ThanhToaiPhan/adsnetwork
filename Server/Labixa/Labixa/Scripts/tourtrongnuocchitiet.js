$(document).ready(function () {
    $("#up-button-tour").click(function () {
        var listItem = document.getElementsByClassName("item");
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
        var listItem = document.getElementsByClassName("item");
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

    $("div.xxx").hover(
    function () {
        $(this).find("div.content-hide-1").slideToggle("slow");
    },
    function () {
        $(this).find("div.content-hide-1").slideToggle("slow");
    }
  );
});