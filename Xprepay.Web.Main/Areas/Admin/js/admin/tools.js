(function(){
  $(document).on("click",".nav-item>a",function(e){
        e.preventDefault();
        e.stopPropagation();
        $(".index").hide();
        if($(this).hasClass('active')){
                $(this).removeClass('active');
                $(this).next().slideUp(300);
        }else{
                $(this).addClass('active');
                $(this).next().slideDown(300);
        }
        $(this).parent().siblings().children('a').removeClass('active').next().slideUp(300);
        if($(this).hasClass('drop-toggle')){
              $(this).addClass('toggle');
        }
  });
  var h = $(window).height();
  $(".page-content").height(h - 50 - 61 - 20);
  // $(".table-content").height( $(".page-content").height() - 63 - 47);
  //  $(".table-content").css('overflow-y', 'scroll');
  $('#seldate').datepicker({
    beforeShowDay: function (date){
      if (date.getMonth() === (new Date()).getMonth())
        switch (date.getDate()){
          case 4:
            return {
              tooltip: 'Example tooltip',
              classes: 'active'
            };
          case 8:
            return false;
          case 12:
            return "green";
        }
    }
});
})();
