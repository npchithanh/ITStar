// JavaScript Document

    	$(document).ready(function(e) {
            $("#c1").click(function(){
				$("body").animate({
					scrollTop: $(".why").offset().top -50
				},1000);
			});
			
			$("#c3").click(function(){
				$("body").animate({
					scrollTop: $(".btn-dky").offset().top -50
				},1000);
			});
			
			$("#c2").click(function(){
				$("body").animate({
					scrollTop: $(".noidungkh").offset().top -50
				},1000);
			});
        });
