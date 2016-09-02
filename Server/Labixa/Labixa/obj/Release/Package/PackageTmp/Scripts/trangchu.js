$(document).ready(function () {
    $("#button-slide-down").click(function () {
        $("html, body").animate({
            scrollTop: $("#slide-to").offset().top
        }, 1000);
    });
    $("#search-dropdown li").click(function () {
        $("#button-dropdown").html($(this).text() + "<i class='fa fa-chevron-down c-right'></i>");
        $("#tour").val($(this).text());
        event.preventDefault();
    });
    $("#button-search").click(function () {
        var term = $("#search").val();
        var link = "tim-kiem/tour-nuoc-ngoai";
        if ($("#button-dropdown").text() == "Tour trong nước")
        {
            link = "tim-kiem/tour-trong-nuoc";
        }
        $.ajax({
            url: link,
            data: { term: term },
            success: function () {
            }
        });
    });
    $("#tour-in-button-1").click(function () {
        var listItem;
        if ($("#tour-in-hot-carousel").css("display") != "none") {
            listItem = document.getElementsByClassName("item-in-hot");
        }
        else {
            listItem = document.getElementsByClassName("item-in-new");
        }
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
    $("#tour-in-button-2").click(function () {
        var listItem;
        if ($("#tour-in-hot-carousel").css("display") != "none") {
            listItem = document.getElementsByClassName("item-in-hot");
        }
        else {
            listItem = document.getElementsByClassName("item-in-new");
        }
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
    $("#tour-out-button-1").click(function () {
        var listItem;
        if ($("#tour-out-hot-carousel").css("display") != "none") {
            listItem = document.getElementsByClassName("item-out-hot");
        }
        else {
            listItem = document.getElementsByClassName("item-out-new");
        }
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
    $("#tour-out-button-2").click(function () {
        var listItem;
        if ($("#tour-out-hot-carousel").css("display") != "none") {
            listItem = document.getElementsByClassName("item-out-hot");
        }
        else {
            listItem = document.getElementsByClassName("item-out-new");
        }
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
    $("#tour-in-hot").click(function () {
        if (!$(this).hasClass("btn-active")) {
            $(this).toggleClass("btn-active");
            $(this).toggleClass("btn-not-active");
            $("#tour-in-new").toggleClass("btn-not-active");
            $("#tour-in-new").toggleClass("btn-active");
            $("#tour-in-hot-carousel").show();
            $("#tour-in-new-carousel").hide();
        }
    });
    $("#tour-in-new").click(function () {
        if (!$(this).hasClass("btn-active")) {
            $(this).toggleClass("btn-active");
            $(this).toggleClass("btn-not-active");
            $("#tour-in-hot").toggleClass("btn-not-active");
            $("#tour-in-hot").toggleClass("btn-active");
            $("#tour-in-hot-carousel").hide();
            $("#tour-in-new-carousel").show();
        }
    });
    $("#tour-out-hot").click(function () {
        if (!$(this).hasClass("btn-active")) {
            $(this).toggleClass("btn-active");
            $(this).toggleClass("btn-not-active");
            $("#tour-out-new").toggleClass("btn-not-active");
            $("#tour-out-new").toggleClass("btn-active");
            $("#tour-out-hot-carousel").show();
            $("#tour-out-new-carousel").hide();
        }
    });
    $("#tour-out-new").click(function () {
        if (!$(this).hasClass("btn-active")) {
            $(this).toggleClass("btn-active");
            $(this).toggleClass("btn-not-active");
            $("#tour-out-hot").toggleClass("btn-not-active");
            $("#tour-out-hot").toggleClass("btn-active");
            $("#tour-out-hot-carousel").hide();
            $("#tour-out-new-carousel").show();
        }
    });
    $("#about").click(function () {
        if (!$(this).hasClass("active")) {
            $(this).addClass("active");
            $("#about-event").removeClass("active");
        }
    });
    $("#about-event").click(function () {
        if (!$(this).hasClass("active")) {
            $(this).addClass("active");
            $("#about").removeClass("active");
        }
    });
    $("#tour-promo-scroll > .row").niceScroll();
    $(".carousel").carousel({
        interval: 3000
    })
});