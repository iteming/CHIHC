
var Modal = {
    //导航父级模块对象的 Target
    Target: "SystemManage",
    ChooseUser: function () {
        var nodes = zTreeHelper.zTree().getSelectedNodes();
        var treeNode = nodes[0];
        if (nodes.length == 0) {
            //toastrShow(MSG.TOAST_WARNING, MSG.CHOOSE_NODES);
            MsgBox.Alert(MSG.CHOOSE_NODES);
            return;
        }

        var scope = Modal.GetAgCtrl('list2Ctrl');
        scope.Pager.ChooseUserModal(treeNode.ID);
    },
    GetAgCtrl: function (control) {
        //通过controller来获取Angular应用
        var appElement = document.querySelector('[ng-controller=' + control + ']');
        var $scope = angular.element(appElement).scope();
        confirm
        return $scope;
    },
    GetDictionary: function (dicName,callback) {
        ///<summary>根据字典名称获取字典</summary>

        $.ajax({
            url: "/System/Dictionary/GetDictionary",//?dicName=" + dicName,
            type: "Post",
            dataType: "json",
            data: {dicName:dicName},
            success: function (data) {
                if (data.status > 0) {
                    if (callback) {
                        callback(dicName,data.data);
                    }
                } 
            }
        });
    },
    //
    NodeLevel: {
        //操作对象
        Type: { Organ: 'Organ' },
        //      nodeID:被移动节点ID
        //targetNodeID:目标节点ID
        //    moveType:操作类型  inner:node成为targetNode的子节点
        //                        prev:node与targetNode平级，node在targetNode之前
        //                        next:node与targetNode平级，node在targetNode之后
        //    operType:操作对象，如操作组织结构则使用  Modal.NodeLevel.Type.Organ
        //    callback:回调处理结果  function(isSuc,msg)
        Change:function(nodeID, targetNodeID, moveType, operType, callback){
            $.ajax({
                url: "/Nodes/NodeLevelChange",
                type: "post",
                dataType: "json",
                data: {
                    nodeID: nodeID,
                    targetID: targetNodeID,
                    moveType:moveType,
                    operType: operType
                },
                success: function (data) {
                    var ret = data.status > 0;
                    if ('function' == typeof callback) {
                        callback(ret, data.msg);
                    }
                }
            });
        }
    },
    NewGuid: function () {
        ///<summary>服务器</summary>
        var ret = "";
        $.ajax({
            url: "/Services/Guid",//?dicName=" + dicName,
            type: "Get",
            dataType: "text",
            async: false,
            data: {},
            success: function (data) {
                ret= data;
            }
        });
        return ret;
    },
    GetTimeStamp: function () { return new Date().getTime() },
}


var MSG = {
    TOAST_ERROR: 0,
    TOAST_SUCCESS: 1,
    TOAST_WARNING: 3,
    TOAST_INFO: 4,
    SUBMIT_CHECKED: "请选择行!",
    SUBMIT_NO_CHANGE: "未发生改变!",
    DELETE_CHECKED: "请选择要删除的记录!",
    DELETE_CONFIRM: "是否删除该记录?",
    DELETE_CONFIRM_NODES: "是否删除该节点?",
    DELETE_CONFIRM_NODES_CHILD: "是否删除该节点及其子节点?",
    CHOOSE_NODES: "请先选择一个节点!",
    CHOOSE_NODES_PARENT: "请先选择一个父节点!",
    CHOOSE_NODES_CANNOT: "该节点不可被选中!",
}


//Tianyf 20170825 
//改进Jquery的Ajax方法,url增加随机数
; (function ($) {
    //备份ajax
    var _ajax = $.ajax;

    $.ajax = function (opt) {
        if (opt.url.indexOf('?') > 0)
            opt.url += "&rnd=" + Modal.GetTimeStamp();
        else
            opt.url += "?rnd=" + Modal.GetTimeStamp();

        var fn = {
            error: function (XMLHttpRequest, textStatus, errorThrown) { },
            success: function (data, textStatus) { },
            beforeSend: function () { },
            complete: function (event, xhr, settings) { }
        };

        if (opt.error)
            fn.error = opt.error;
        if (opt.success)
            fn.success = opt.success;
        if (opt.beforeSend)
            fn.beforeSend = opt.beforeSend;
        if (opt.complete)
            fn.complete = opt.complete;

        var _opt = $.extend(opt, {
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //超时处理
                if (408 == XMLHttpRequest.status) {
                    top.window.location = "/Account/LogOut";
                    return;
                }
                fn.error(XMLHttpRequest, textStatus, errorThrown);
            },
            success: function (data, textStatus) {
                fn.success(data, textStatus);
            },
            beforeSend: function () {
                var height = $(document).height();
                $("#loading").height(height);
                $("#loading").show();
                fn.beforeSend();
            },
            complete: function (event, xhr, settings) {
                $("#loading").hide();
                fn.complete(event, xhr, settings);
            }
        });

        return _ajax(_opt);
    };
})(jQuery);