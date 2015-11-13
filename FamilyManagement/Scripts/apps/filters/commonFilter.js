'use strict';
angular.module('CommonFilter', [])
        .filter('elseValue', function () {
            //当值为null或者不存在时显示另一个值
            return function (value, elseValue) {
                if (value) return value;
                else return elseValue;
            };
        })
        .filter('limit', function () {
            var strReg = /[^\x21-\x7e]/g;
            //截取字符串
            //超过长度的情况，取小于指定长度的最多字符串，再加...
            return function (str, num) {
                if (!num)
                    return str;

                if (!angular.isString(str))
                    return str;

                var replacedStr = str.replace(strReg, "**");
                if (replacedStr.length > num) {
                    var strLen = str.length;
                    var tmpI = Math.floor(num / 2) - 1;
                    var tmpLength = str.substr(0, tmpI).replace(strReg, "**").length;
                    for (; tmpI < strLen; tmpI++) {
                        tmpLength += str.substr(tmpI, 1).replace(strReg, "**").length;
                        if (tmpLength >= num)
                            return str.substr(0, tmpI) + "...";
                    }
                } else {
                    return str;
                }
            };
        })
        .filter('parseJsonDate', function () {
            //解析服务端返回的json格式的日期到date类型的对象
            return function (dateStr) {
                var reISO = /^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2}(?:\.\d*))(?:Z|(\+|-)([\d|:]*))?$/;
                var reMsAjax = /^\/Date\((d|-|.*)\)[\/|\\]$/;
                var date;
                if (typeof dateStr === 'string') {
                    var a = reISO.exec(dateStr);
                    if (a)
                        date = new Date(dateStr);
                    a = reMsAjax.exec(dateStr);
                    if (a) {
                        var b = a[1].split(/[-+,.]/);
                        date = new Date(b[0] ? +b[0] : 0 - +b[1]);
                    }
                }
                return date;
            };
        })
        .filter('formatJsonDate', ['$filter', function ($filter) {
            // 将服务端返回的json格式的日期格式化成日期字符串
            // formatStr使用ng的格式化字符串标准
            return function (dateStr, formatStr) {
                var date = $filter('parseJsonDate')(dateStr);
                return $filter('date')(date, formatStr);
            };
        }])
        .filter('ifTrue', function () {
            //当condition为true时返回值
            return function (value, condition) {
                if (condition) return value;
                else return "";
            };
        })
        .filter('secondToTime', function () {
            //当condition为true时返回值
            return function (input) {
                if (input == -1) {
                    return "";
                }
                var hh, mm, ss;
                //得到小时
                hh = input / 3600 | 0;
                input = parseInt(input) - hh * 3600;
                if (parseInt(hh) < 10) {
                    hh = "0" + hh;
                }
                //得到分
                mm = input / 60 | 0;
                //得到秒
                ss = parseInt(input) - mm * 60;
                if (parseInt(mm) < 10) {
                    mm = "0" + mm;
                }
                if (ss < 10) {
                    ss = "0" + ss;
                }
                return hh + ":" + mm + ":" + ss;
            };
        })
        .filter('mapValue', function () {
            return function (key, dict) {
                if (!dict || !dict.hasOwnProperty(key))
                    return "";
                else
                    return dict[key];
            };
        })
        //类型
        .filter("targetType", function () {
            return function (type) {
                if (type == models.core.targetType.Exam) {
                    return "测试";
                }
                if (type == models.core.targetType.Assignment) {
                    return "作业";
                }
                if (type == models.core.targetType.Course) {
                    return "课程";
                }

            };
        })
        //node状态
        .filter("nodeState", function () {
            return function (state) {
                if (state == models.core.userState.NotStarted) {
                    return "未完成";
                }
                if (state == models.core.userState.Underway) {
                    return "进行中";
                }
                if (state == models.core.userState.WaitForChecked) {
                    return "未批改";
                }
                if (state == models.core.userState.Finished) {
                    return "已完成";
                }
            };
        })
        .filter('top', function () {
            return function (list, num) {
                var res = [];
                for (var i = 0, length = list.length; i < length && i < num; i++) {
                    res.push(list[i]);
                };
                return res;
            };
        });