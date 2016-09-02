var domain = window.location.href;
$.ajax({
    url: '//172.16.10.115:9006/check-domain',
    type: 'POST',
    crossDomain: true,
    dataType: 'json',
    data: { domain: domain, code: '6ddb131e-7839-4993-999a-d66756be1f97' },
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