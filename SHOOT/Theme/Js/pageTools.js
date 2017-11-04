
//公用分页加载
//url访问地址，controlId追加控件ID
function PagingLoad(url, controlId) {
    //记录分页
    var pageNum;
    if ($("#Num").val() === "") {
        pageNum = 1;
    } else {
        pageNum = parseInt($("#Num").val()) + 1;
    }
    $("#Num").val(pageNum);
    if (url.indexOf('?') >= 0) {
        url += "&pageNum=" + pageNum;
    } else {
        url += "?pageNum=" + pageNum;
    }
    $.ajax({
        dataType: "html",
        type: "Post",
        url: url,
        async: false,
        success: function (data) {
            if (controlId === "") {
                //仅供产品列表类似有tab切换的使用
                controlId = "ProductContent";
                $("#" + controlId).append(data);
                if (pageNum > 1 && data.length <= 0 && $("#" + controlId).has(".publicProductItem").length) {
                    $(".LoadedTip").show();
                }
            } else {
                $("#" + controlId).append(data);
                if (pageNum > 1 && data.length <= 0) {
                    $(".LoadedTip").show();
                }
            }
            if (pageNum === 1 && data.trim().length <= 0) {
                $(".emptyPacket").show();
            }
        },
        error: function (request) {
        }
    });
}

//上划加载
function ScrollLoading(methodName) {
    $(window).scroll(function () {
        var scrollTop = $(this).scrollTop();
        var scrollHeight = $(document).height();
        var windowHeight = $(this).height();
        if (scrollTop + windowHeight === scrollHeight) {
            methodName();
        }
    });
}

$(function () {
    //首次加载
    GetFirstLevelList();
    //上划加载
    ScrollLoading(GetProductList);
    $("#jumpLabel").val("/index/index");
});