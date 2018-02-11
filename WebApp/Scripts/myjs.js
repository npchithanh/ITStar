
$(document).ready(function(){
    $(window).scroll(function(){
        if($(this).scrollTop() > 30) {
        	$('#header').addClass('fix-top');
        	$('.top-bar').slideUp();
        	$('.main-menu').slideUp();
        	$('.header-logo').hide();
        	$('.btn-menu').show();
        }
        else {
        	$('#header').removeClass('fix-top');
        	$('.top-bar').slideDown();
        	$('.main-menu').slideDown();
        	$('.header-logo').show();
        	$('.btn-menu').hide();
        }
    });

    $('.btn-menu').click(function(){
    	$('.main-menu').slideToggle();
    });

    $(".c-location-widget__link-change").click(function () {
        $(".c-location-widget__form").fadeToggle();

    })

    $(".open-pr-info").click(function(){
    	$(".product-description-box-info").css('height','auto');
    	$(".close-pr-info").show();
    	
    });

    $(".close-pr-info").click(function(){
    	$(".product-description-box-info").css('height','800px');
    	$(".open-pr-info").show();
    	$(this).hide();
    });


});



