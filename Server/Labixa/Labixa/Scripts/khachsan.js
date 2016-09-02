$(document).ready(function () { 
    $("#tour-control-left").click(function () {
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
    $("#tour-control-right").click(function () {
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
    $("#tour-hot").click(function () {
        if (!$(this).hasClass("tour-head-text-active")) {
            $(this).toggleClass("tour-head-text-active");
            $("#tour-new").toggleClass("tour-head-text-active");
            $("#tour-in-hot-carousel").show();
            $("#tour-in-new-carousel").hide();
        }
        event.preventDefault();
    });
    $("#tour-new").click(function () {
        if (!$(this).hasClass("tour-head-text-active")) {
            $(this).toggleClass("tour-head-text-active");
            $("#tour-hot").toggleClass("tour-head-text-active");
            $("#tour-in-hot-carousel").hide();
            $("#tour-in-new-carousel").show();
        }
        event.preventDefault();
    });
    $("#view-list").click(function () {
        if (!$(this).hasClass("view-active")) {
            $(this).toggleClass("view-active");
            $("#view-grid").toggleClass("view-active");
            $("#viewType").val("list");
            $("#display-list").show();
            $("#display-grid").hide();
        }
    });
    $("#view-grid").click(function () {
        if (!$(this).hasClass("view-active")) {
            $(this).toggleClass("view-active");
            $("#view-list").toggleClass("view-active");
            $("#viewType").val("grid");
            $("#display-grid").show();
            $("#display-list").hide();
        }
    });
    $("div.xxx").hover(
    function () {
        $(this).find("div.content-hide-1").slideToggle("slow");
    },
    function () {
        $(this).find("div.content-hide-1").slideToggle("slow");
    })
    $(".page-li").click(function () {
        var number_page = ($(this).data("number"));
        if (!$(this).hasClass("li-active")) {
            if (number_page > 5) {
                if ($(this).hasClass("li-1")) {
                    if ($(this).text() != "...") {
                        $(".page-li").removeClass("li-active");
                        $(this).toggleClass("li-active");
                    }
                }
                else if ($(this).hasClass("li-2")) {
                    if ($(".li-1").text() == "1") {
                        $(".page-li").removeClass("li-active");
                        $(this).toggleClass("li-active");
                    }
                    else {
                        if ($(this).text() == "2") {
                            $(".page-li").removeClass("li-active");
                            $(this).toggleClass("li-active");
                            $(".li-1").html("<a href='#'>1</a>");
                            $(".li-4").html("<a href='#'>...</a>");
                            $(".li-5").html("<a href='#'></a>");
                        }
                        else {
                            $(".li-4").html($(".li-3").html());
                            $(".li-3").html($(this).html());
                            $(this).html("<a href='#'>" + (parseInt($(this).text()) - 1) + "</a>");
                            if (parseInt($(this).text()) < number_page - 1) {
                                $(".li-5").html("<a href='#'>...</a>");
                            }
                        }
                    }
                }
                else if ($(this).hasClass("li-3")) {
                    if (parseInt($(this).text()) < number_page - 1) {
                        $(".li-1").html("<a href='#'>...</a>");
                        $(".li-4").html("<a href='#'>4</a>");
                        $(".li-5").html("<a href='#'>...</a>");
                    }
                    $(".page-li").removeClass("li-active");
                    $(this).toggleClass("li-active");

                }
                else if ($(this).hasClass("li-4")) {
                    if (parseInt($(this).text()) < number_page - 1) {
                        $(".li-2").html($(".li-3").html());
                        $(".li-3").html($(this).html());
                        $(this).html("<a href='#'>" + (parseInt($(this).text()) + 1) + "</a>");
                    }
                    else if (parseInt($(this).text()) == number_page - 1) {
                        $(".li-2").html($(".li-3").html());
                        $(".li-3").html($(this).html());
                        $(this).html("<a href='#'>" + number_page + "</a>");
                        $(".li-5").html("<a href='#'></a>");
                    }
                    else if (parseInt($(this).text()) == number_page) {
                        $(".page-li").removeClass("li-active");
                        $(this).toggleClass("li-active");
                    }
                }
            }
            else {
                $(".page-li").removeClass("li-active");
                $(this).toggleClass("li-active");
            }
            var link;
            if ($("#tourType").val() == "in") {
                link = "tour-trong-nuoc";
            }
            else {
                link = "tour-nuoc-ngoai"
            }
            $.ajax({
                url: link,
                
                data: { page: parseInt($(this).text()), viewType: $("#viewType").val(), totalPage: parseInt($("#totalPage").val()) },
                success: function (htmlResponse) {
                    $("#display-" + $("#viewType").val()).html(htmlResponse);
                }
            });
        }
        event.preventDefault();
    });
});