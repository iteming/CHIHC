(function ($) {

    var imageBaseUrl = "/Theme/Ico/";
    var icon = {
        warning: imageBaseUrl + "warning.png",//警告
        success: imageBaseUrl + "successIcon.png",//成功
        sorry: imageBaseUrl + "sorry.png",//抱歉
        cartempty: imageBaseUrl + "cartempty.png",//购物车为空
        housekeeping: imageBaseUrl + "houseKeeping.png"//管家
    }

    var html = '<div class="tiplayer">'
          + '<div class="tipbox">'
              //+ '<a href="javascript:;" class="tipclose ">×</a>'
             + ' <dl>'
                 //+ ' <dt>'
                 //    + '<img src="">'
                 // + '</dt>'
                  + '<dd class="text"></dd>'
                  + '<dd class="btn">'
                      + '<a href="javascript:;" class="tipbtn  tipOk"></a>'
                      + '<a href="javascript:;" class="tipbtn  tipCancel"></a>'
                  + '</dd>'
              + '</dl>'
         + ' </div>'
         + '</div>';

    function Show(param) {
        $(".wrap").append(html);
        var popbox = $(".tiplayer");
        if (param.icon) {
            popbox.find("img").attr("src", icon[param.icon]);
        }
        else {
            popbox.find("img").remove();
        }
        popbox.find(".text").html(param.text);
        if (param.okValue) {
            popbox.find(".tipOk").text(param.okValue).click(closeTip).click(param.okEvent);
        }
        else {
            popbox.find(".tipOk").remove();
        }
        if (param.cancelValue) {
            popbox.find(".tipCancel").text(param.cancelValue).click(closeTip).click(param.cancelEvent);
        }
        else {
            popbox.find(".tipCancel").remove();
        }
        popbox.find(".tipclose").click(closeTip).click(param.cancelEvent);
        popbox.show();
        if (!param.okValue && !param.cancelValue) {
            setTimeout(function () {
                $(".tiplayer").hide().remove();
                param.okEvent();
            }, 1000);
        }
    }

    function closeTip() {
        $(".tiplayer").hide().remove();
    }

    var defaults = {
        icon: "warning",
        text: "",
        okValue: null,
        okEvent: null,
        cancelValue: null,
        cancelEvent: null
    }

    window.alert = function (options, iconOptions) {
        Show(
            (typeof options == "string" || typeof options == "number") && typeof iconOptions == "string" ?
            $.extend({}, defaults, { text: options, icon: iconOptions }) : (typeof options == "string" || typeof options == "number") ? $.extend({}, defaults, { text: options }) : $.extend({}, defaults, options)
            );
    }
})(jQuery)