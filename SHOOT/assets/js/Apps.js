var handleDatepicker = function () {
    $("#datepicker-default").datepicker({
        todayHighlight: true
    });
    $("#datepicker-inline").datepicker({
        todayHighlight: true
    });
    $(".input-daterange").datepicker({
        todayHighlight: true
    });
    $("#datepicker-disabled-past").datepicker({
        todayHighlight: true
    });
    $("#datepicker-autoClose").datepicker({
        todayHighlight: true,
        autoclose: true
    });
    $("#datepicker-start").datepicker({
        todayHighlight: true,
        autoclose: true
    });
    $("#datepicker-end").datepicker({
        todayHighlight: true,
        autoclose: true
    })
    $("#datepicker-start1").datepicker({
        todayHighlight: true,
        autoclose: true
    });
    $("#datepicker-end2").datepicker({
        todayHighlight: true,
        autoclose: true
    })
};

var onEnterKeydown = function (event) {
    var e = event || window.event || arguments.callee.caller.arguments[0];
    if (e && e.keyCode == 27) { // 按 Esc 
        //要做的事情
        //toastrShow(MSG.TOAST_WARNING,"Esc");
    }
    if (e && e.keyCode == 113) { // 按 F2 
        //要做的事情
        //toastrShow(MSG.TOAST_WARNING,"F2");
    }
    if (e && e.keyCode == 13) { // enter 键
        //要做的事情
        //toastrShow(MSG.TOAST_WARNING,"Enter");
        return true;
    }
    return false;
}

var tooltip = function () {
    $("[data-toggle='tooltip']").tooltip();
}

var belowIE8Detection = function () {
    var browser = navigator.appName;
    if (browser == "Microsoft Internet Explorer") {
        var appversion = navigator.appVersion;
        var version = appversion.split(";");
        var trim_Version = version[1].replace(/[ ]/g, "");

        if (trim_Version == "MSIE9.0" || trim_Version == "MSIE8.0") {
            $('input, textarea').placeholder();
        }
        if (trim_Version == "MSIE5.0" || trim_Version == "MSIE6.0" || trim_Version == "MSIE7.0") {
            MsgBox.Alert("建议在IE8以上或者谷歌、火狐等浏览器浏览，当前IE内核为：" + trim_Version)
        }
    }
}

var windowScrollDetection = function () {
    $(window).scroll(function () {
        if ($(document).scrollTop() <= 0) {
            MsgBox.Alert("滚动条已经到达顶部为0");
        }

        if ($(document).scrollTop() >= $(document).height() - $(window).height()) {
            MsgBox.Alert("滚动条已经到达底部为" + $(document).scrollTop());
        }
    });
}

var menuFocusDetection = function () {
    // 菜单定位
    var lis = $(".ulnavmain").find("a");
    var href = location.href;
    var flag = false;

    lis.each(function () {
        //if (this.href.indexOf(href) > -1) {
        if (href.indexOf(this.href) > -1) {
            $(this).parent().addClass("active");
            $(this).parent().parent().parent().addClass("active");
            flag = true;
            return false;
        }
    });

    if (!flag) {
        lis.first().parent().addClass("active");
    }
}

var hideAlter = function () {
    // 点击 alert 框，自动隐藏
    $("[data-dismiss=alter]").on("click", function () {
        $(this).parent().hide();
    });
}


var hidden_toast = function () {
    $('#toast-container').css('display', 'none');
};

var toastr = function () {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "positionClass": "toast-bottom-right",
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
};
var toastrAutoClose = function () {
    if ($("#toast-container").length > 0) {
        if ($('#toast-container').css('display') == 'block') {
            setTimeout(function () {
                $('#toast-container').css('display', 'none');
            }, '3000')
        }
    }
};
var toastrShow = function (status, msg) {
    if ($("#toast-container").length > 0 && msg != '') {
        if ($('#toast-container').css('display') == 'none') {
            $('#toast-container').css('display', 'block');
            var msgclass = status == 1 ? 'toast-success' : (status == 0 ? 'toast-error' : (status == 3 ? 'toast-warning' : 'toast-info'));
            var html = '<div class="toast ' + msgclass + '"><div class="toast-message">' + msg + '</div></div>';
            $('#toast-container').html(html);

            setTimeout(function () {
                $('#toast-container').css('display', 'none');
            }, '3000')
        }
    }
};
//可视化内容自适应高度方法
function autoHeight() {
    var h_fixed = 130;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $("#content").css('height', h_look);
    }
    else {
        return false;
    }
}

//档案信息左边树内容自适应高度方法
function poleTreeautoHeight() {
    var h_fixed = 175;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".poletree").css('height', h_look);
    }
    else {
        return false;
    }
}

//数据字典右边表单内容自适应高度方法
function dictionaryautoHeight() {
    var h_fixed = 175;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".dictiform").css('height', h_look);
    }
    else {
        return false;
    }
}

//电线杆维护左边树内容自适应高度方法
function teleTreeautoHeight() {
    var h_fixed = 227;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".poleteletree").css('height', h_look);
    }
    else {
        return false;
    }
}

//物资使用左边树内容自适应高度方法
function MaterialUsetreeutoHeight() {
    var h_fixed = 250;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".MaterialUsetree").css('height', h_look);
    }
    else {
        return false;
    }
}

//档案信息右边表格内容自适应高度方法
function poleTableautoHeight() {
    var h_fixed = 230;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".poletable").css('height', h_look);
    }
    else {
        return false;
    }
}

//档案信息右边菜单内容自适应高度方法
function PolemanuautoHeight() {
    var h_fixed = 275;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".Polemanu").css('height', h_look);
    }
    else {
        return false;
    }
}

//图号维护右边表格自适应高度方法
function picHelpautoHeight() {
    var h_fixed = 305;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".pichelp").css('height', h_look);
    }
    else {
        return false;
    }
}
//发料单管理左边自适应高度方法
function faliaodanautoHeight() {
    var h_fixed = 335;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".faliaodan").css('height', h_look);
    }
    else {
        return false;
    }
}

//入库维护单表格自适应高度方法
function EnterHelpautoHeight() {
    var h_fixed = 290;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".enterhelp").css('height', h_look);
    }
    else {
        return false;
    }
}

//入库单维护表格内容自适应高度方法
function receiptAutoHeight() {
    var h_fixed = 360;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".receipt").css('height', h_look);
    }
    else {
        return false;
    }
}
//物资签收右边内容自适应高度方法
function goodsrightAutoHeight() {
    var h_fixed = 210;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".goodsRight").css('height', h_look);
    }
    else {
        return false;
    }
}



//物资目录左边树内容自适应高度方法
function goodsTreeAutoHeight() {
    var h_fixed = 227;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".goodsTree").css('height', h_look);
    }
    else {
        return false;
    }
}

//物资签收左边表格内容自适应高度方法
function goodsreceiveAutoHeight() {
    var h_fixed = 255
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".goodsreceive").css('height', h_look);
    }
    else {
        return false;
    }
}

//模块定义左边树内容自适应高度方法
function RightModuleAutoHeight() {
    var h_fixed = 280;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".moduletree").css('height', h_look);
    }
    else {
        return false;
    }
}

//物资目录右边表格内容自适应高度方法
function goodsTableAutoHeight() {
    var h_fixed = 330;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".goodsTable").css('height', h_look);
    }
    else {
        return false;
    }
}


//物资发放左边表格自适应高度方法
function leftsendAutoHeight() {
    var h_fixed = 358;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".leftsending").css('height', h_look);
    }
    else {
        return false;
    }
}


//档案查询右边表格自适应高度方法
function quirepleoAutoHeight() {
    var h_fixed = 355;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".quirepleo").css('height', h_look);
    }
    else {
        return false;
    }
}

//物资发放右边表格自适应高度方法
function rightsendAutoHeight() {
    var h_fixed = 260;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".rightsending").css('height', h_look);
    }
    else {
        return false;
    }
}

//物资使用查询右边表格自适应高度方法
function quireuseAutoHeight() {
    var h_fixed = 375;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".quireuse").css('height', h_look);
    }
    else {
        return false;
    }
}
//入库单维护左边表格自适应高度方法
function rukuandanAutoHeight() {
    var h_fixed = 365;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".rukudan").css('height', h_look);
    }
    else {
        return false;
    }
}

//线杆使用物资查询使用查询右边表格自适应高度方法
function MaterialPoleAutoHeight() {
    var h_fixed = 420;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".MaterialPole").css('height', h_look);
    }
    else {
        return false;
    }
}

//物资使用动态生成自适应高度方法
function MateriaUseAutoHeight() {
    var h_fixed = 485;
    var h = $(window).height();
    var h_old = 80;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".Materialuse").css('height', h_look);
    }
    else {
        return false;
    }
}

//物资使用左边表格动态生成自适应高度方法
function MateriaUseleftAutoHeight() {
    var h_fixed = 315;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".Materialuseleft").css('height', h_look);
    }
    else {
        return false;
    }
}

//入库维护单右边表格动态生成自适应高度方法
function rukrightAutoHeight() {
    var h_fixed = 320;
    var h = $(window).height();
    var h_old = 300;
    var h_look = h - h_fixed;
    if (h_look > h_old) {
        $(".rukright").css('height', h_look);
    }
    else {
        return false;
    }
}


var Plugins = function () {
    "use strict";
    return {
        init: function () {
            handleDatepicker();
            tooltip();
            belowIE8Detection();
            //menuFocusDetection();
            hideAlter();
            toastr();
            toastrAutoClose();
            //调用可视化内容自适应高度方法
            autoHeight();
            $(window).resize(autoHeight);
            //windowScrollDetection();
            //入库维护单表格内容自适应高度方法
            receiptAutoHeight();
            $(window).resize(receiptAutoHeight);
            //入库维护单表格内容自适应高度方法
            rukrightAutoHeight();
            $(window).resize(rukrightAutoHeight);
            //物资目录左边树内容自适应高度方法
            goodsTreeAutoHeight();
            $(window).resize(goodsTreeAutoHeight);
            //物资目录右边表格内容自适应高度方法
            goodsTableAutoHeight();
            $(window).resize(goodsTableAutoHeight);
            //物资发放左边表格内容自适应高度方法
            leftsendAutoHeight();
            $(window).resize(leftsendAutoHeight);
            //物资发放右边表格内容自适应高度方法
            rightsendAutoHeight();
            $(window).resize(rightsendAutoHeight);
            //档案信息左边树内容自适应高度方法
            poleTreeautoHeight();
            $(window).resize(poleTreeautoHeight);
            //电线杆维护左边树内容自适应高度方法
            teleTreeautoHeight();
            $(window).resize(teleTreeautoHeight);
            //档案信息右边表格内容自适应高度方法
            poleTableautoHeight();
            $(window).resize(poleTableautoHeight);
            //档案信息右边菜单内容自适应高度方法
            PolemanuautoHeight();
            $(window).resize(PolemanuautoHeight);
            //图号维护右边表格内容自适应高度方法
            picHelpautoHeight();
            $(window).resize(picHelpautoHeight);
            //档案查询右边表格内容自适应高度方法
            quirepleoAutoHeight();
            $(window).resize(quirepleoAutoHeight);
            //数据字典右边表单内容自适应高度方法
            dictionaryautoHeight();
            $(window).resize(dictionaryautoHeight);
            //模块定义左边树内容自适应高度方法
            RightModuleAutoHeight();
            $(window).resize(RightModuleAutoHeight);
            //物资使用左边树内容自适应高度方法
            MaterialUsetreeutoHeight();
            $(window).resize(MaterialUsetreeutoHeight);
            //档案查询右边表格内容自适应高度方法
            quireuseAutoHeight();
            $(window).resize(quireuseAutoHeight);
            //线杆使用物资查询右边表格内容自适应高度方法
            MaterialPoleAutoHeight();
            $(window).resize(MaterialPoleAutoHeight);
            //入库维护单表格内容自适应高度方法
            EnterHelpautoHeight();
            $(window).resize(EnterHelpautoHeight);
            //物资签收表格内容自适应高度方法
            goodsrightAutoHeight();
            $(window).resize(goodsrightAutoHeight);
            //物资使用动态生成自适应高度方法
            MateriaUseAutoHeight();
            $(window).resize(MateriaUseAutoHeight);
            //物资使用左边表格自适应高度方法
            MateriaUseleftAutoHeight();
            $(window).resize(MateriaUseleftAutoHeight);
            //物资签收左边表格自适应高度方法
            goodsreceiveAutoHeight();
            $(window).resize(goodsreceiveAutoHeight);
            //物资签收左边表格自适应高度方法
            faliaodanautoHeight();
            $(window).resize(faliaodanautoHeight);
            //入库单维护左边表格自适应高度方法
            rukuandanAutoHeight();
            $(window).resize(rukuandanAutoHeight);
        }
    }
}()