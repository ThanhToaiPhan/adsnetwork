$(document).ready(function () {
    var captcha = (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    $("#captcha-content").text(captcha);

    var listDate = $(".hasDatepicker");
    var date1 = new Date($(listDate[0]).val());
    var date2 = new Date($(listDate[1]).val());
    if (date2 < date1) {
        $("#night").val("NaN");
    }
    else {
        var timeDiff = Math.abs(date2.getTime() - date1.getTime());
        var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
        $("#night").val(diffDays);
    }
    
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
        temp = jQuery.trim($("#soluong").val());
        if (temp.length <= 0 || isNaN(temp)) {
            checked = false;
            $("#soluong").css('border', '1px solid red');
        }
        else {
            $("#soluong").css('border', '1px solid #b2b2b2');
        }
        temp = jQuery.trim($("#sophong").val());
        if (temp.length <= 0 || isNaN(temp)) {
            checked = false;
            $("#sophong").css('border', '1px solid red');
        }
        else {
            $("#sophong").css('border', '1px solid #b2b2b2');
        }
        //kiem tra so dem
        temp = jQuery.trim($("#night").val());
        if (temp === "NaN") {
            checked = false;
            $("#night").css('border', '1px solid red');
        }
        else {
            $("#night").css('border', '1px solid #b2b2b2');
        }
        // kiem tra da doc va dong y cac dieu khoan su dung
        if (!$("#condition")[0].checked) {
            checked = false;
            $("#condition").parent().css('border', '1px solid red');
        }
        else {
            $("#condition").parent().css('border', 'none');
        }
        // kiem tra ma xac nhan
        temp = jQuery.trim($("#captcha").val());
        if (temp.length <= 0 || temp.localeCompare($("#captcha-content").text().toUpperCase()) != 0) {
            checked = false;
            console.log($("#captcha-content").text());
            $("#captcha").css('border', '1px solid red');
            var captcha = (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
            $("#captcha-content").text(captcha);
        }
        else {
            $("#captcha").css('border', '1px solid #b2b2b2');
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