
$(function () {
    $(".bottom_left>a").click(function () {
        var iscoller = 0;
        if ($(this).hasClass("coller")) {
            iscoller = 1;
        }

        var url = "/Product/AddColler?id=" + $(".hidid").val() + "&type=" + $(".hidtype").val() + "&isColler=" + iscoller;
        getUrl(url, function () {
            iscoller == 0 ? $(".bottom_left>a").addClass("coller") : $(".bottom_left>a").removeClass("coller");
        });
    });

});