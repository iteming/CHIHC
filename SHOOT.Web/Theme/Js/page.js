var pageNum = 0;
function pageLoad(div,pageindex) {
    //记录分页
    pageNum = pageNum + 1;
    if (div = undefined || div == null || div == "") {
        div = "page_content";
    }
    var temurl = location.href;
    var urlparam = "";
    if (temurl.indexOf("?") >= 0) {
        urlparam = temurl.substring(temurl.indexOf("?"));
        temurl = temurl.substring(0, temurl.indexOf("?"));
    }
    temurl += "_Page" + urlparam;

    if (temurl.indexOf('?') >= 0) {
        temurl += "&pageNum=" + pageNum;
    } else {
        temurl += "?pageNum=" + pageNum;
    }
    $.ajax({
        dataType: "html",
        type: "get",
        url: temurl,
        cache: false,
        async: false,
        success: function (data) {
            data = $.trim(data);
            if (data == "") {
                if (pageNum == 1) {
                    data = "<h2 class='noshow'><img src='/Images/none.png' /></h2>";
                } else {
                    data = "<span class='noshow'>戳到底啦!</span>";
                }
            }
            if ($("#" + div).find(".noshow").length < 1) {
                $("#" + div).append(data);
            }
        },
        error: function (request) {
            alert("数据请求异常");
        }
    });
}

//上划加载
function scrollLoading(i) {
    pageLoad(i);
    $(window).scroll(function () {
        var scrollTop = $(this).scrollTop();
        var scrollHeight = $(document).height();
        var windowHeight = $(this).height();
        if (scrollTop + windowHeight === scrollHeight) {
            pageLoad(i);
        }
    });
}


$(function () {
    //上划加载
    scrollLoading(0);
})