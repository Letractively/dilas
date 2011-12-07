$(function(){
$('.leftmenu_right').click(
function(){
	
	if ($(".leftmenu_dragbox").css("left") == "-170px") {
        $(".leftmenu_dragbox").animate({left:"0px"});
 //$(".leftmenu").hide();

$(".jquery_img").attr('src','/Dilas/images/dot_light.png');

        }	
		else{
	//$(".leftmenu").hide();
		 $(".leftmenu_dragbox").animate({left:"-170px"});
$(".jquery_img").attr('src','/Dilas/images/dot.gif');
			}
	}
)



	

})
	


	
 




