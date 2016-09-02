$(document).ready(function () {
    var captcha = (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    $("#captcha-content").text(captcha);

    $("#captcha-change").click(function () {
        var captcha = (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
        $("#captcha-content").text(captcha);
        event.preventDefault();
    });
    $("#order-button").click(function () {
        var checked = true;
        // kiem tra ho va ten
        var temp = jQuery.trim($("#customerName").val());
        if (temp.length <= 0) {
            checked = false;
            $("#customerName").css('border', '1px solid red');
        }
        else {
            $("#customerName").css('border', '1px solid #b2b2b2');
        }
        // kiem tra dia chi
        temp = jQuery.trim($("#customerAddress").val());
        if (temp.length <= 0) {
            checked = false;
            $("#customerAddress").css('border', '1px solid red');
        }
        else {
            $("#customerAddress").css('border', '1px solid #b2b2b2');
        }
        // kiem tra so dien thoai
        temp = jQuery.trim($("#customerPhone").val());
        if (temp.length <= 9 || isNaN(temp)) {
            checked = false;
            $("#customerPhone").css('border', '1px solid red');
        }
        else {
            $("#customerPhone").css('border', '1px solid #b2b2b2');
        }
        // kiem tra email
        temp = jQuery.trim($("#customerEmail").val());
        if (temp.length <= 0 || temp.indexOf('@') <= 0) {
            checked = false;
            $("#customerEmail").css('border', '1px solid red');
        }
        else {
            $("#customerEmail").css('border', '1px solid #b2b2b2');
        }
        // kiem tra so luong dat tour
        var temp1 = jQuery.trim($("#quantityAdult").val());
        var temp2 = jQuery.trim($("#quantityChildren").val());
        var temp3 = jQuery.trim($("#quantityBaby").val());
        if (temp1.length <= 0 && temp2.length <= 0 && temp3.length <= 0) {
            checked = false;
            $("#quantityAdult").parent().css('border', '1px solid red');
            $("#quantityChildren").parent().css('border', '1px solid red');
            $("#quantityBaby").parent().css('border', '1px solid red');
        }
        else {
            if (temp1.length > 0 && isNaN(temp1)) {
                checked = false;
                $("#quantityAdult").parent().css('border', '1px solid red');
            }
            else {
                $("#quantityAdult").parent().css('border', '1px solid #b2b2b2');
                $("#quantityChildren").parent().css('border', '1px solid #b2b2b2');
                $("#quantityBaby").parent().css('border', '1px solid #b2b2b2');
            }
            if (temp2.length > 0 && isNaN(temp2)) {
                checked = false;
                $("#quantityChildren").parent().css('border', '1px solid red');
            }
            else {
                $("#quantityAdult").parent().css('border', '1px solid #b2b2b2');
                $("#quantityChildren").parent().css('border', '1px solid #b2b2b2');
                $("#quantityBaby").parent().css('border', '1px solid #b2b2b2');
            }
            if (temp3.length > 0 && isNaN(temp3)) {
                checked = false;
                $("#quantityBaby").parent().css('border', '1px solid red');
            }
            else {
                $("#quantityAdult").parent().css('border', '1px solid #b2b2b2');
                $("#quantityChildren").parent().css('border', '1px solid #b2b2b2');
                $("#quantityBaby").parent().css('border', '1px solid #b2b2b2');
            }
        }
        // hoan thanh cac buoc kiem tra
        if (checked)
        {
            $(this).closest('form').submit();
        }
        event.preventDefault();
        return false;
    });
});