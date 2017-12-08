/*
* author:张晓飞
* date：2015-11-12
* des：保存和获取用户信息
*/
(function (window, $) {
    var validResult = {};

    var checkObjs = {
        /**
         * 检查输入的一串字符是否全部是数字
         * 输入:str  String
         * 返回:true 或 flase; true表示为数字
         */
        checkNum: function (str) {
            return /\D/.test(str);
        },


        /**
         * 检查输入的一串字符是否为小数
         * 输入:str  String
         * 返回:true 或 flase; true表示为小数
         */
        checkDecimal: function (str) {
            return /^-?\d+(\.\d+)?$/g.test(str);
        },

        /**
         * 检查输入的一串字符是否为整型数据
         * 输入:str  字符串
         * 返回:true 或 flase; true表示为小数
         */
        checkInteger: function (str) {
            return /^[-+]?\d*$/.test(str);
        },

        /**************************************************************************************/
        /*************************************字符的验证*****************************************/
        /**************************************************************************************/


        /**
         * 检查输入的一串字符是否是字符
         * 输入:str  String
         * 返回:true 或 flase; true表示为全部为字符 不包含汉字
         */
        checkStr: function (str) {
            return /[^\x00-\xff]/g.test(str);
        },


        /**
         * 检查输入的一串字符是否包含汉字
         * 输入:str  String
         * 返回:true 或 flase; true表示包含汉字
         */
        checkChinese: function (str) {
            return escape(str).indexOf("%u") != -1;
        },


        /**
         * 检查输入的邮箱格式是否正确
         * 输入:str  String
         * 返回:true 或 flase; true表示格式正确
         */
        checkEmail: function (str) {
            return (/^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/.test(str) && str.length <= 25);
            //return /[A-Za-z0-9_-]+[@](\S*)(net|com|cn|org|cc|tv|[0-9]{1,3})(\S*)/g.test(str);
        },


        /**
         * 检查输入的手机号码格式是否正确
         * 输入:str  String
         * 返回:true 或 flase; true表示格式正确
         */
        checkMobilePhone: function (str) {
            return /^0{0,1}(13[0-9]|145|147|15[0-3]|15[5-9]|180|18[5-9])[0-9]{8}$/.test(str);
            //return /^\d{11}$/.test(str);
        },


        /**
         * 检查输入的固定电话号码是否正确
         * 输入:str  String
         * 返回:true 或 flase; true表示格式正确
         */
        checkTelephone: function (str) {
            return /^(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$/.test(str);
        },
        /**
         * 检查支付密码格式是否正确
         * 输入:str  String
         * 返回:true 或 flase; true表示格式正确
         */
        checkNick: function (str) {
            return /^[\u4e00-\u9fa5a-zA-Z0-9_-]{4,25}$/.test(str.replace(/[\u4e00-\u9fa5]{1}/g, 'xx'));
            //return /^(?!\d)[\u4e00-\u9fa5a-zA-Z0-9_-]{4,25}$/.test(str);
        },
        /**
         * 检查QQ的格式是否正确
         * 输入:str  String
         *  返回:true 或 flase; true表示格式正确
         */
        checkQQ: function (str) {
            return /^\d{5,10}$/.test(str);
        },

        /**
         * 检查邮政编码格式是否正确
         * 输入:str  String
         *  返回:true 或 flase; true表示格式正确
         */
        checkPostCode: function (str) {
            return /^\d{6}$/.test(str);
        },

        /**
         * 检查输入的身份证号是否正确
         * 输入:str  字符串
         *  返回:true 或 flase; true表示格式正确
         */
        checkCard: function (str) {
            //15位数身份证正则表达式
            var arg1 = /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/;
            //18位数身份证正则表达式
            var arg2 = /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[A-Z])$/;
            return arg1.test(str) || arg2.test(str);
        },

        /**
         * 检查输入的IP地址是否正确
         * 输入:str  String
         *  返回:true 或 flase; true表示格式正确
         */
        checkIP: function (str) {
            var arg = /^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$/;
            return arg.test(str);
        },

        /**
         * 检查输入的URL地址是否正确
         * 输入:str  String
         *  返回:true 或 flase; true表示格式正确
         */
        checkURL: function (str) {
            return /(http[s]?|ftp):\/\/[^\/\.]+?\..+\w$/i.test(str);
        },

        /**
         * 检查输入的字符是否具有特殊字符
         * 输入:str  String
         * 返回:true 或 flase; true表示包含特殊字符
         * 主要用于注册信息的时候验证
         */
        checkQuote: function (str) {
            var items = new Array("~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "{", "}", "[", "]", "(", ")");
            items.push(":", ";", "'", "|", "\\", "<", ">", "?", "/", "<<", ">>", "||", "//");
            items.push("admin", "administrators", "administrator", "管理员", "系统管理员");
            items.push("select", "delete", "update", "insert", "create", "drop", "alter", "trancate");
            str = str.toLowerCase();
            for (var i = 0; i < items.length; i++) {
                if (str.indexOf(items[i]) >= 0) {
                    return true;
                }
            }
            return false;
        },

        /**
         * 检查输入的用户名是否具有特殊字符
         * 输入:str  String
         * 返回:true 或 flase; true表示包含特殊字符
         * 主要用户注册和信息修改
         */
        checkUserName: function (str) {
            return /^[a-zA-Z\u4e00-\u9fa5]{6,25}/.test(str.replace(/[\u4e00-\u9fa5]{1}/g, 'xx'));   ///^[0-9a-zA-Z\u4e00-\u9fa5_]{4,16}$/;
        },

        /**************************************************************************************/
        /*************************************时间的验证*****************************************/
        /**************************************************************************************/

        /**
         * 检查日期格式是否正确
         * 输入:str  String
         * 返回:true 或 flase; true表示格式正确
         * 注意：此处不能验证中文日期格式
         * 验证短日期（2015-12-15）
         */
        checkDate: function (str) {
            //var value=str.match(/((^((1[8-9]\d{2})|([2-9]\d{3}))(-)(10|12|0?[13578])(-)(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))(-)(11|0?[469])(-)(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))(-)(0?2)(-)(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)(-)(0?2)(-)(29)$)|(^([3579][26]00)(-)(0?2)(-)(29)$)|(^([1][89][0][48])(-)(0?2)(-)(29)$)|(^([2-9][0-9][0][48])(-)(0?2)(-)(29)$)|(^([1][89][2468][048])(-)(0?2)(-)(29)$)|(^([2-9][0-9][2468][048])(-)(0?2)(-)(29)$)|(^([1][89][13579][26])(-)(0?2)(-)(29)$)|(^([2-9][0-9][13579][26])(-)(0?2)(-)(29)$))/);
            var value = str.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
            if (value) {
                var date = new Date(value[1], value[3] - 1, value[4]);
                return (date.getFullYear() == value[1] && (date.getMonth() + 1) == value[3] && date.getDate() == value[4]);
            }
            return false;
        },

        /**
         * 检查时间格式是否正确
         * 输入:str  String
         * 返回:true 或 flase; true表示格式正确
         * 验证时间(10:57:10)
         */
        checkTime: function (str) {
            var value = str.match(/^(\d{1,2})(:)?(\d{1,2})\2(\d{1,2})$/)
            if (value) {
                if (!(value[1] > 24 || value[3] > 60 || value[4] > 60)) {
                    return true;
                }
            }
            return false;
        },

        /**
         * 检查验证码长度是否正确
         * 输入:str  String
         * 返回:true 或 flase; true表示格式正确
         */
        checkCaptcha: function (str) {
            return str.length === 4;
        },

        /**
         * 检查密码长度是否正确
         * 输入:str  String
         * 返回:true 或 flase; true表示格式正确
         */
        checkPassword: function (str) {
            return str.length >= 6 && str.length <= 20;
        },

        /**
         * 检查动态验证码长度是否正确
         * 输入:str  String
         * 返回:true 或 flase; true表示格式正确
         */
        checkVerCode: function (str) {
            return str.length === 6;
        },

        /**
         * 检查两次输入是否相等
         * 输入:pwd  String,pwd2 String
         * 返回:true 或 flase; true表示格式正确
         */
        checkEqual: function (str, str2) {
            return "" !== str && str === str2;
        },

        /**
        * ajax验证用户名是否已使用
        * state：1未注册，-1已注册
        */
        ajaxCheckUserName: function () {
            $.ajax({
                url: "/home/validusername?username=" + obj.node.val(),
                dataType: "json",
                timeout: 3000,
                type: "post",
                success: function (ret) {
                    if (ret.State > 0) validResult["ajaxUserName"] = true;
                }
            });
        },

        /**
        * ajax验证邮箱是否已使用
        * state：1未注册，-1已注册
        */
        ajaxCheckEmail: function (val) {
            $.ajax({
                url: "/home/validemail?email=" + val,
                dataType: "json",
                timeout: 3000,
                type: "post",
                success: function (ret) {
                    if (ret.State > 0) validResult["ajaxEmail"] = true;
                }
            });
        },
        ajaxCheckMobile: function (val) {
            $.ajax({
                url: "/home/validenmobile?mobile=" + val,
                dataType: "json",
                timeout: 3000,
                type: "post",
                success: function (ret) {
                    if (ret.State > 0) validResult["ajaxMobile"] = true;
                }
            });
        },
        /**
        * 发送动态码
        */
        ajaxSendCode: function (val) {
            var _this = this;
            if ($(_this).hasClass("btn-disabled")) return false;
            $.ajax({
                url: "/home/sendencode",
                type: "post",
                data: "mobile=" + val,
                timeout: 5000,
                dataType: "json",
                beforeSend: function (xhr) {
                    $(_this).addClass("btn-disabled").text("正在发送...");
                },
                error: function () {
                    $(_this).text("发送验证码").removeClass("btn-disabled");
                },
                success: function (ret) {
                    console.log(ret);
                    if (ret.State > 0) {
                        var i = 60;
                        var timer = setInterval(function () {
                            $(_this).text(--i + "秒后可重试");
                            if (i === 0) {
                                clearInterval(timer);
                                $(_this).text("重新获取").removeClass("btn-disabled");
                            }
                        }, 1000);
                        validResult["ajaxSendCode"] = true;
                    } else {
                        $(_this).text("发送验证码").removeClass("btn-disabled");
                    }
                }
            })
        },

    }

    var com = {
        getBaseInfo: function (callback) {
            $.post("/enterprise/getbaseinfo", null, function (ret) {
                if (ret.State > 0 && callback) callback(ret.Data);
            }, "json");
        },
        getRegion: function (code, callback) {
            $.post("/home/region/" + code, null, function (ret) {
                if (ret.State > 0 && callback) callback(ret.Data);
            }, "json");
        },
        getProperty: function (callback) {
            $.post("/home/property", null, function (ret) {
                if (ret.State > 0 && callback) callback(ret.Data);
            }, "json");
        },
        getIndustry: function (callback) {
            $.post("/home/industry", null, function (ret) {
                if (ret.State > 0 && callback) callback(ret.Data);
            }, "json");
        },
        getScale: function (callback) {
            $.post("/home/scale", null, function (ret) {
                if (ret.State > 0 && callback) callback(ret.Data);
            }, "json");
        },
        updateProperty: function (id) {
            $.post("/enterprise/updateproperty/" + id);
        },
        updateIndustry: function (id) {
            $.post("/enterprise/updateindustry/" + id);
        },
        updateScale: function (id) {
            $.post("/enterprise/updatescale/" + id);
        },
        getReceiveAdds: function (index, callback) {
            $.post("/enterprise/receiveadds/" + index, null, function (ret) {
                if (callback && ret.State > 0) callback(ret.Data);
            }, "json");
        },
        getSendAdds: function (index, callback) {
            $.post("/enterprise/sendadds/" + index, null, function (ret) {
                if (callback && ret.State > 0) callback(ret.Data);
            }, "json");
        },
        getEmployees: function (callback) {
            $.post("/enterprise/getemployees", null, function (ret) {
                if (callback && ret.State > 0) callback(ret.Data);
            }, "json");
        }
    };

    var tempModal, modalDialog, modalWrap;

    var modal = function () {
        var modal = $('<div class="modal fade" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static"> <div class="modal-dialog"> <div class="modal-header"> <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button> <h3 class="modal-title"></h3> </div> <div class="panel-body"> <div class="modal-msg"></div> </div> <div class="modal-footer"> <button type="button" class="right-button btn btn-block btn-primary" data-dismiss="modal"> <span>关闭</span> </button> </div> </div> </div> <div class="modal-wrap"></div>');

        function show(title, msg) {
            if (title)
                modalDialog.find(".modal-title").text(title);
            if (msg)
                modalDialog.find(".modal-msg").text(msg);
            modalDialog.show();
            modalWrap.addClass("in");
            modalDialog.addClass("in");
        }
        return {
            createModal: modal,
            modalEvent: function () {
                modalDialog.on("click", function () {
                    modalWrap.removeClass("in");
                    modalDialog.removeClass("in");
                    modalDialog.hide();
                });
            },
            show: show
        }
    }

    window.validate = checkObjs;
    window.validResult = validResult;
    window.com = com;
    window.modal = {
        initModal: function () {
            tempModal = modal();
            $("body").append(tempModal.createModal);
            modalDialog = $(".modal"), modalWrap = $(".modal-wrap");
            tempModal.modalEvent();
        },
        show: function (title, msg, callback) {
            if (tempModal)
                tempModal.show(title, msg);
        }
    };

})(window, jQuery);