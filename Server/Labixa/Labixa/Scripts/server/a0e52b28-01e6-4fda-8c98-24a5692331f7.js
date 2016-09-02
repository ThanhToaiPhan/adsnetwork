var domain = window.location.href;
$.ajax({
    url: '//172.16.10.115:9006/check-domain',
    type: 'POST',
    crossDomain: true,
    dataType: 'json',
    data: { domain: domain, code: 'a0e52b28-01e6-4fda-8c98-24a5692331f7' },
    success: function (response) {
        if (response.message == "success") {
            $('#' + response.code).parent().append("<script>var code='" + response.code + "';var link_1='" + response.link_1 + "';var image_1='" + response.image_1 + "';<\/script>");
            $('#' + response.code).parent().append(response.script);
            $('#' + response.code).parent().append(response.func);
        }
        else {
            console.log(response.message);
        }
    }
});