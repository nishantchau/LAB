var page_actions = function(){
    
    /* PROGGRESS START 
    $.mpb("show",{value: [0,50],speed: 5});        
     END PROGGRESS START */

    var html_click_avail = true;

    $("html").on("click", function(){
        if(html_click_avail)
            $(".x-navigation-horizontal li,.x-navigation-minimized li,.x-features .x-features-search,.x-features .x-features-profile").removeClass('active');        
        
    });        
    
    $(".x-features-nav-open").on("click",function(e){
        $(".x-hnavigation").toggleClass("active");
    });
    
    $(".x-hnavigation .xn-openable > a").on("click",function(e){
        if($(this).parent("li").hasClass("active")){
           $(this).parent("li").removeClass("active");
        }else{
            $(".x-hnavigation .xn-openable").removeClass("active");
            $(this).parents("li").addClass("active");        
        }
    });
    
    $(".x-features .x-features-profile").on("click",function(e){
        e.stopPropagation();
        $(this).toggleClass("active");
    });
    
    $(".x-features .x-features-search").on("click",function(e){
        e.stopPropagation();
        $(this).addClass("active");
        $(this).find("input[type=text]").focus();
    });
    
    $(".x-navigation-horizontal .panel").on("click",function(e){
        e.stopPropagation();
    });    

 

    /* SIDEBAR */
    $(".sidebar-toggle").on("click",function(){
        $("body").toggleClass("sidebar-opened");
        return false;
    });
    $(".sidebar .sidebar-tab").on("click",function(){
        $(".sidebar .sidebar-tab").removeClass("active");
        $(".sidebar .sidebar-tab-content").removeClass("active");

        $($(this).attr("href")).addClass("active");
        $(this).addClass("active");

        return false;
    });
    $(".page-container").on("click",function(){
       $("body").removeClass("sidebar-opened");
    });
    /* END SIDEBAR */

    /* PAGE TABBED */
    $(".page-tabs a").on("click",function(){
        $(".page-tabs a").removeClass("active");
        $(this).addClass("active");
        $(".page-tabs-item").removeClass("active");        
        $($(this).attr("href")).addClass("active");
        return false;
    });
    /* END PAGE TABBED */

    /* PAGE MODE TOGGLE */
    $(".page-mode-toggle").on("click",function(){
        page_mode_boxed();
        return false;
    });
    /* END PAGE MODE TOGGLE */

    x_navigation();
    
    /* PROGGRESS COMPLETE 
    $.mpb("update",{value: 100, speed: 5, complete: function(){            
        $(".mpb").fadeOut(200,function(){
            $(this).remove();
        });
    }});
     END PROGGRESS COMPLETE */
}

$(document).ready(function(){        
    page_actions();    
});

$(function(){                
    onload();
    
    $(window).resize(function(){
        x_navigation_onresize();
        page_content_onresize();    
    });
});

function onload(){
    x_navigation_onresize();    
    page_content_onresize();    
}

function page_mode_boxed(){
    $("body").toggleClass("page-container-boxed");
    onresize(400);
}

function page_content_onresize(){
    var vpW = Math.max(document.documentElement.clientWidth, window.innerWidth || 0)
    var vpH = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);
    
    $(".page-content,.content-frame-body,.content-frame-right,.content-frame-left").css("width","").css("height","");
    
    $(".sidebar .sidebar-wrapper").height(vpH);
    
    var content_minus = 0;
    content_minus = ($(".page-container-boxed").length > 0) ? 40 : content_minus;
    content_minus += ($(".page-navigation-top-fixed").length > 0) ? 50 : 0;
    
    var content = $(".page-content");
    var sidebar = $(".page-sidebar");
    
    if(content.height() < vpH - content_minus){        
        content.height(vpH - content_minus);
    }        
    
    if(sidebar.height() > content.height()){        
        content.height(sidebar.height());
    }
    
    if($(".page-content-adaptive").length > 0)
        $(".page-content-adaptive").css("min-height",vpH-80);
    
    if(vpW > 1024){
        
        if($(".page-sidebar").hasClass("scroll")){
            if($("body").hasClass("page-container-boxed")){
                var doc_height = vpH - 40;
            }else{
                var doc_height = vpH;
            }
           $(".page-sidebar").height(doc_height);
           
       }
       
       var fbm = $("body").hasClass("page-container-boxed") ? 200 : 162;       
       
       var cfH = $(".content-frame").height();       
       if($(".content-frame-body").height() < vpH-162){           
           
           var cfM = vpH-fbm < cfH-80 ? cfH-80 : vpH-fbm;
                   
           $(".content-frame-body,.content-frame-right,.content-frame-left").height(cfM);
           
       }else{
           $(".content-frame-right,.content-frame-left").height($(".content-frame-body").height());
       }
        
        $(".content-frame-left").show();
        $(".content-frame-right").show();
    }else{
        $(".content-frame-body").height($(".content-frame").height()-80);
        
        if($(".page-sidebar").hasClass("scroll"))
           $(".page-sidebar").css("height","");
    }
    
    if(vpW < 1200){
        if($("body").hasClass("page-container-boxed")){
            $("body").removeClass("page-container-boxed").data("boxed","1");
        }
    }else{
        if($("body").data("boxed") === "1"){
            $("body").addClass("page-container-boxed").data("boxed","");
        }
    }
    //$(window).trigger("resize");
}

/* EOF PANEL FUNCTIONS */

/* X-NAVIGATION CONTROL FUNCTIONS */
function x_navigation_onresize(){
    
    var inner_port = window.innerWidth || $(document).width();
    
    if(inner_port < 1025){               
        $(".page-sidebar .x-navigation").removeClass("x-navigation-minimized");
        $(".page-container").removeClass("page-container-wide");
        $(".page-sidebar .x-navigation li.active").removeClass("active");
        
                
        $(".x-navigation-horizontal").each(function(){            
            if(!$(this).hasClass("x-navigation-panel")){                
                $(".x-navigation-horizontal").addClass("x-navigation-h-holder").removeClass("x-navigation-horizontal");
            }
        });
        
        
    }else{        
        if($(".page-navigation-toggled").length > 0){
            x_navigation_minimize("close");
        }       
        
        $(".x-navigation-h-holder").addClass("x-navigation-horizontal").removeClass("x-navigation-h-holder");                
    }
    
}

function x_navigation_minimize(action){
    
    if(action == 'open'){
        $(".page-container").removeClass("page-container-wide");
        $(".page-sidebar .x-navigation").removeClass("x-navigation-minimized");
		$(".page-sidebar").removeClass("x-adeptClose");
		$(".page-sidebar").css("overflow","hidden");
		$("#main-content").removeClass("x-adeptMainClose");
        $(".x-navigation-minimize").find(".fa").removeClass("fa-indent").addClass("fa-dedent");
        $(".page-sidebar.scroll").mCustomScrollbar("update");
    }
    
    if(action == 'close'){
        $(".page-container").addClass("page-container-wide");
        $(".page-sidebar .x-navigation").addClass("x-navigation-minimized");
		$(".page-sidebar").addClass("x-adeptClose");
		$(".page-sidebar").css("overflow","visible");
		$("#main-content").addClass("x-adeptMainClose");
        $(".x-navigation-minimize").find(".fa").removeClass("fa-dedent").addClass("fa-indent");
        $(".page-sidebar.scroll").mCustomScrollbar("disable",true);
    }
    
    $(".x-navigation li.active").removeClass("active");
    
}

function x_navigation(){
    
    $(".x-navigation-control").click(function(){
        $(this).parents(".x-navigation").toggleClass("x-navigation-open");
        
        onresize();        
        return false;
    });

    if($(".page-navigation-toggled").length > 0){
        x_navigation_minimize("close");
    }    
    
    if($(".page-navigation-toggled-hover").length > 0){
        $(".page-sidebar").hover(function(){
            $(".x-navigation-minimize").trigger("click");
        },function(){
            $(".x-navigation-minimize").trigger("click");
        });        
    }
    
    $(".x-navigation-minimize").click(function(){
                
        if($(".page-sidebar .x-navigation").hasClass("x-navigation-minimized")){
            $(".page-container").removeClass("page-navigation-toggled");
            x_navigation_minimize("open");
        }else{            
            $(".page-container").addClass("page-navigation-toggled");
            x_navigation_minimize("close");            
        }
        
        onresize();
        
        return false;        
    });
       
    $(".x-navigation  li > a").click(function(){
        
        var li = $(this).parent('li');        
        var ul = li.parent("ul");
        
        ul.find(" > li").not(li).removeClass("active");    
        
    });
       
    $(".x-navigation li").click(function(event){
        event.stopPropagation();
        
        var li = $(this);
                
        if(li.children("ul").length > 0 || li.children(".panel").length > 0 || $(this).hasClass("xn-profile") > 0){
            if(li.hasClass("active")){
                li.removeClass("active");
                li.find("li.active").removeClass("active");
            }else
                li.addClass("active");

            onresize();

            if($(this).hasClass("xn-profile") > 0)
                return true;
            else
                return false;
        }                                     
    });
    
    /* XN-SEARCH */
    $(".xn-search").on("click",function(){
        $(this).find("input").focus();
    })
    /* END XN-SEARCH */
    
}
/* EOF X-NAVIGATION CONTROL FUNCTIONS */

/* PAGE ON RESIZE WITH TIMEOUT */
function onresize(timeout){    
    timeout = timeout ? timeout : 200;
    
    setTimeout(function(){
        page_content_onresize();                
    },timeout);
}
/* EOF PAGE ON RESIZE WITH TIMEOUT */

/* PLAY SOUND FUNCTION */
function playAudio(file){
    if(file === 'alert')
        document.getElementById('audio-alert').play();

    if(file === 'fail')
        document.getElementById('audio-fail').play();    
}
/* END PLAY SOUND FUNCTION */

/* PAGE LOADING FRAME */
function pageLoadingFrame(action,ver){    
    
    ver = ver ? ver : 'v2';
    
    var pl_frame = $("<div></div>").addClass("page-loading-frame");
    
    if(ver === 'v2')
        pl_frame.addClass("v2");
    
    var loader = new Array();
    loader['v1'] = '<div class="page-loading-loader"><img src="img/loaders/page-loader.gif"/></div>';
    loader['v2'] = '<div class="page-loading-loader"><div class="dot1"></div><div class="dot2"></div></div>';
    
    if(action == "show" || !action){
        $("body").append(pl_frame.html(loader[ver]));
    }
    
    if(action == "hide"){
        
        if($(".page-loading-frame").length > 0){
            $(".page-loading-frame").addClass("removed");

            setTimeout(function(){
                $(".page-loading-frame").remove();
            },800);        
        }
        
    }
}
/* END PAGE LOADING FRAME */

/* NEW OBJECT(GET SIZE OF ARRAY) */
Object.size = function(obj) {
    var size = 0, key;
    for (key in obj) {
        if (obj.hasOwnProperty(key)) size++;
    }
    return size;
};
/* EOF NEW OBJECT(GET SIZE OF ARRAY) */


/* MATERIAL CHECKBOX */
var wskCheckbox = function() {
  var wskCheckboxes = [];
  var SPACE_KEY = 32;

  function addEventHandler(elem, eventType, handler) {
    if (elem.addEventListener) {
      elem.addEventListener (eventType, handler, false);
    }
    else if (elem.attachEvent) {
      elem.attachEvent ('on' + eventType, handler);
    }
  }

  function clickHandler(e) {
    e.stopPropagation();
    if (this.className.indexOf('checked') < 0) {
      this.className += ' checked';
    } else {
      this.className = 'chk-span';
    }
  }

  function keyHandler(e) {
    e.stopPropagation();
    if (e.keyCode === SPACE_KEY) {
      clickHandler.call(this, e);
      // Also update the checkbox state.

      var cbox = document.getElementById(this.parentNode.getAttribute('for'));
      cbox.checked = !cbox.checked;
    }
  }

  function clickHandlerLabel(e) {
    var id = this.getAttribute('for');
    var i = wskCheckboxes.length;
    while (i--) {
      if (wskCheckboxes[i].id === id) {
        if (wskCheckboxes[i].checkbox.className.indexOf('checked') < 0) {
          wskCheckboxes[i].checkbox.className += ' checked';
        } else {
          wskCheckboxes[i].checkbox.className = 'chk-span';
        }
        break;
      }
    }
  }

  function findCheckBoxes() {
    var labels =  document.getElementsByTagName('label');
    var i = labels.length;
    while (i--) {
      var posCheckbox = document.getElementById(labels[i].getAttribute('for'));
      if (posCheckbox !== null && posCheckbox.type === 'checkbox') {
        var text = labels[i].innerText;
        var span = document.createElement('span');
        span.className = 'chk-span';
        span.tabIndex = i;
        labels[i].insertBefore(span, labels[i].firstChild);
        addEventHandler(span, 'click', clickHandler);
        addEventHandler(span, 'keyup', keyHandler);
        addEventHandler(labels[i], 'click', clickHandlerLabel);
        wskCheckboxes.push({'checkbox': span,
            'id': labels[i].getAttribute('for')});
      }
    }
  }

  return {
    init: findCheckBoxes
  };
}();
wskCheckbox.init();
/* ./MATERIAL CHECKBOX */