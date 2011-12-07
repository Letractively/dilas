$(document).ready(function () {
    $('.keyWord').val('請輸入關鍵字');
    $('.keyWord').click(function () {
        if ($('.keyWord').val() == '請輸入關鍵字') {
            $(this).val('');
        }
    });

    $('.keyWord').blur(function () {
        if ($('.keyWord').val() == '') {
            $(this).val('請輸入關鍵字');
        }

    });

});

$(function(){
$('.homebook_list tbody tr:odd').addClass('homebook_list_odd'); 
$('.homebook_list tbody tr:even').addClass('homebook_list_even'); 
$('.top_click').toggle(function(){
	$(this).attr('class' ,'top_click qqqq');
	
	//$('.top_box').show()
	$('.top_box').show();
	}
	,function(){
		$(this).attr('class' ,'top_click');
	$('.top_box').hide();
		}
	);
	
	$('.topmenu').click(function(){
	$('.topmenu_box:hidden').fadeIn();
	setTimeout(function(){
		
        $('.topmenu_box').hide();
    }, 4000);
	}
	);
		
}
);