var domain = window.location.href;
$.ajax({
    url: '//172.16.10.115:9006/check-domain',
    type: 'POST',
    crossDomain: true,
    dataType: 'json',
    data: { domain: domain, code: '518c775a-2b16-4cad-933c-cbdcc4de7eaa' },
    success: function (response) {
        if (response.message == "success") {
            $('#' + response.code).parent().append("<script>var code='" + response.code + "';var link_1='" + response.link_1 + "';var image_1='" + response.image_1 + "';var title_1='" + response.title_1 + "';var url_1='" + response.url_1 + "';var content_1='" + response.content_1 + "';var price_1='" + response.price_1 + "';var price_type_1='" + response.price_type_1 + "';var link_2='" + response.link_2 + "';var image_2='" + response.image_2 + "';var title_2='" + response.title_2 + "';var url_2='" + response.url_2 + "';var content_2='" + response.content_2 + "';var price_2='" + response.price_2 + "';var price_type_2='" + response.price_type_2 + "';var link_3='" + response.link_3 + "';var image_3='" + response.image_3 + "';var title_3='" + response.title_3 + "';var url_3='" + response.url_3 + "';var content_3='" + response.content_3 + "';var price_3='" + response.price_3 + "';var price_type_3='" + response.price_type_3 + "';<\/script>");
            $('#' + response.code).parent().append(response.script);
            $('#' + response.code).parent().append(response.func);
        }
        else {
            console.log(response.message);
        }
    }
});