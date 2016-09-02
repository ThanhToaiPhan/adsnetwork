var domain = window.location.href;
$.ajax({
    url: '//172.16.10.115:9006/check-domain',
    type: 'POST',
    crossDomain: true,
    dataType: 'json',
    data: { domain: domain, code: 'd966b2fb-382d-4746-a7e4-a41171a0dddc' },
    success: function (response) {
        if (response.message == "success") {
            $('#' + response.code).parent().append("<script>var code='" + response.code + "';var link_1='" + response.link_1 + "';var image_1='" + response.image_1 + "';var title_1='" + response.title_1 + "';var url_1='" + response.url_1 + "';var content_1='" + response.content_1 + "';var price_1='" + response.price_1 + "';var price_type_1='" + response.price_type_1 + "';var link_2='" + response.link_2 + "';var image_2='" + response.image_2 + "';var title_2='" + response.title_2 + "';var url_2='" + response.url_2 + "';var content_2='" + response.content_2 + "';var price_2='" + response.price_2 + "';var price_type_2='" + response.price_type_2 + "';var link_3='" + response.link_3 + "';var image_3='" + response.image_3 + "';var title_3='" + response.title_3 + "';var url_3='" + response.url_3 + "';var content_3='" + response.content_3 + "';var price_3='" + response.price_3 + "';var price_type_3='" + response.price_type_3 + "';var link_4='" + response.link_4 + "';var image_4='" + response.image_4 + "';var title_4='" + response.title_4 + "';var url_4='" + response.url_4 + "';var content_4='" + response.content_4 + "';var price_4='" + response.price_4 + "';var price_type_4='" + response.price_type_4 + "';<\/script>");
            $('#' + response.code).parent().append(response.script);
            $('#' + response.code).parent().append(response.func);
        }
        else {
            console.log(response.message);
        }
    }
});