$(document).ready(function () {

  $("#navigation li").click(function(){
    $("#navigation li").removeClass();
    $(this).addClass("link-active");
  });


  $(window).scroll(function () {
    var scrolling = 38 - $(window).scrollTop();
    if (scrolling > 0)
    {
      $('#main-header').css('marginTop', "" + scrolling + "px");
    }
    else
    {
      $('#main-header').css('marginTop', '0px');
    }
  });

  $("div.blog-post").hover(
    function() {
        $(this).find("div.content-hide").slideToggle("slow");
    },
    function() {
        $(this).find("div.content-hide").slideToggle("slow");
    }
  );

  $('.flexslider').flexslider({
		prevText: '',
		nextText: '',
		slideshowSpeed: 2000
	});

  $('.testimonails-slider').flexslider({
    animation: 'slide',
    slideshowSpeed: 2000,
    prevText: '',
    nextText: '',
    controlNav: false
  });

  $(function(){

  // Instantiate MixItUp:

  $('#Container').mixItUp();

  

  $(document).ready(function() {
      $(".fancybox").fancybox();

      $("#li-about").click(function () {
          var link = $("#about-to");
          var offset = link.offset();
          var top = offset.top;
          $("html, body").animate({
              scrollTop: top}, 2000);
      });
      $("#li-contact").click(function () {
          $("html, body").animate({ scrollTop: $(document).height() }, 2000);
      });

    });
  });


});

