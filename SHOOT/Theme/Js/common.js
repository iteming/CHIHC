function selectMenus(index) {
    var imgsbg = new Array("../Images/menu1bg.png", "../Images/menu2bg.png", "../Images/menu3bg.png", "../Images/menu4bg.png", "../Images/menu5bg.png");
    var menus = $(".bottom>li>a");
    $(menus).each(function (i, item) {
        if (i + 1 == index) {
            $(item).addClass("on");
            $(item).css("backgroundImage", "url('" + imgsbg[i] + "')");
        }
    });
}

var sStorage = window.sessionStorage;
var tempHistry = sStorage.tempHistry;
$(function () {
    $("#searchkey").keydown(function (e) {
        if (e.keyCode == 13) {
            var keys = $("#searchkey").val();
            if (/[^\w\u4e00-\u9fa5]/g.test(keys)) {
                alert("只能输入数字、字母、中文搜索");
                return;
            }
            jumpUrl("/Product/Products?name=" + keys);
        }
    });
    $(".backbtn").click(function () {
        var url = location.href;
        if (tempHistry != undefined && tempHistry.length != 0) {
            var histry = JSON.parse(tempHistry);
            var histyUrl = histry[histry.length - 1];
            var temurl = url;
            if (temurl.indexOf("?") >= 0) {
                temurl = temurl.substring(0, temurl.indexOf("?"));
            }
            var controller = "";
            var action = temurl.substring(temurl.lastIndexOf("/"));
            temurl = temurl.substring(0, temurl.lastIndexOf("/"));
            if (temurl.indexOf("/") >= 0) {
                controller = temurl.substring(temurl.lastIndexOf("/"));
            } else {
                controller = "/";
                action = "";
            }
            if (histyUrl.indexOf(controller + action) >= 0) {
                histry.pop();
            }
            sStorage.tempHistry = JSON.stringify(histry);
            location.href = histry[histry.length - 1];
        } 
        else {
            history.go(-1);
        }
    });

    $("a").click(function () {
        if ($(this).attr("href") == undefined) {
            return true;
        } else {
            jumpUrl($(this).attr("href"));
            return false;
        }
    })

})

function jumpUrl(jumpUrl) {
    var url = location.href;
    if (tempHistry == undefined || tempHistry.length == 0 || tempHistry.length == 2) {
        var histry = new Array();
        histry.push(url);
        sStorage.tempHistry = JSON.stringify(histry);
    } else {
        var histry = JSON.parse(tempHistry);
        var histyUrl = histry[histry.length - 1];
        var temurl = url;
        if (temurl.indexOf("ConfirmOrder") < 0) {
            if (temurl.indexOf("?") >= 0) {
                temurl = temurl.substring(0, temurl.indexOf("?"));
            }
            var controller = "";
            var action = temurl.substring(temurl.lastIndexOf("/"));
            temurl = temurl.substring(0, temurl.lastIndexOf("/"));
            if (temurl.indexOf("/") >= 0) {
                controller = temurl.substring(temurl.lastIndexOf("/"));
            } else {
                controller = "/";
                action = "";
            }
            if (histyUrl.indexOf(controller + action) < 0) {
                histry.push(url);
                sStorage.tempHistry = JSON.stringify(histry);
            }
        }
    }
    location.href = jumpUrl;
}
function getUrl(url, succesMethod, errorMethod) {
    var result = {};
    $.ajax({
        url: url,
        cache: false,
        async: false,
        type: "get",
        success: function (rets) {
            if (rets.Status == 1) {
                if (rets.Msg != "") {
                    alert({
                        text: rets.Msg,
                        okEvent: function () {
                            succesMethod == undefined ? function () {; } : succesMethod();
                        }
                    });
                } else {
                    succesMethod == undefined ? function () {; } : succesMethod()
                }
            } else {
                alert({
                    text: rets.Msg,
                    okEvent: function () {
                        errorMethod == undefined ? function () {; } : errorMethod();
                    }
                });
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            result = null;
            alert("请求异常");
            //alert(XMLHttpRequest.status);
            //alert(XMLHttpRequest.readyState);
            //alert(textStatus);
        },
    });
    return result;
}
function postUrl(url, data, succesMethod, errorMethod) {
    var result = {};
    $.ajax({
        url: url,
        data: data,
        cache: false,
        async: false,
        type: "POST",
        contentType: "application/json",
        success: function (rets) {
            if (rets.Status == 1) {
                if (rets.Msg != "") {
                    alert({
                        text: rets.Msg,
                        okEvent: function () {
                            succesMethod == undefined ? function () {; } : succesMethod();
                        }
                    });
                } else {
                    succesMethod == undefined ? function () {; } : succesMethod();
                }
            } else {
                alert({
                    text: rets.Msg,
                    okEvent: function () {
                        errorMethod == undefined ? function () {; } : errorMethod();
                    }
                });
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            result = null;
            alert("请求异常");
            //alert(XMLHttpRequest.status);
            //alert(XMLHttpRequest.readyState);
            //alert(textStatus);
        },
    });
}
