    
    
    $(document).ready(function() {
        $.mkv.moveUpandDown("#gridTable");
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();
        if (dd < 10) { dd = '0' + dd }
        if (mm < 10) { mm = '0' + mm }
        $("#ngaydangky").val(dd + "/" + mm + "/" + yyyy);
        $("#ngaytiepnhan").val(dd + "/" + mm + "/" + yyyy);
        $("#tenbenhnhan").focus();
        
        // Bind DropDownList
        $("#idloaiuutien").DropList({ ajax: "../ajax/benhnhan_ajax.aspx?do=idloaiuutienSearch", defaultVal: "" });
        $("#loai").DropList({ ajax: "../ajax/benhnhan_ajax.aspx?do=loaiSearch", defaultVal: "" });
        $("#idphongkhambenh").DropList({ ajax: "../ajax/benhnhan_ajax.aspx?do=idphongkhambenhSearch&loaibn=" + $("#loai").val()});
        //////////
        macdinhbaohiem();
        setControlFind($.mkv.queryString("idkhoachinh"));
        $("#luu").click(function() {
            $(this).Luu({
                ajax: "../ajax/benhnhan_ajax.aspx?do=Luu"
            }, function() {
                if ($("#ngaytiepnhan").val() == "") {
                    $.mkv.myerror("Ngày tiếp nhận không bỏ trống.");
                    return false;
                }
                else if ($("#tenbenhnhan").val() == "") {
                    $.mkv.myerror("Tên bệnh nhân không bỏ trống.");
                    return false;
                }
                else if ($("#diachi").val() == "") {
                    $.mkv.myerror("Địa chỉ không bỏ trống.");
                    return false;
                }
                else if ($("#ngaysinh").val() == "") {
                    $.mkv.myerror("Ngày sinh không được bỏ trống.");
                    return false;
                }
                else if ($("#idloaiuutien").val() == "") {
                    $.mkv.myerror("Chưa chọn loại ưu tiên.");
                    return false;
                }
                else if ($("#loai").val() == "") {
                    $.mkv.myerror("Chưa chọn loại khám.");
                    return false;
                }
                else if ($("#loai").val() != "2") {
                    if ($("#ngaybatdau").val() != "" && $("#ngayketthuc").val() != "") {
                        var nbd = new Date($("#ngaybatdau").val().substring(6, 10), $("#ngaybatdau").val().substring(3, 5), $("#ngaybatdau").val().substring(0, 2));
                        var nkt = new Date($("#ngayhethan").val().substring(6, 10), $("#ngayhethan").val().substring(3, 5), $("#ngayhethan").val().substring(0, 2));
                        if (nbd > new Date(yyyy, mm, dd)) {
                            $.mkv.myerror("Ngày bắt đầu không lớn hơn ngày hiện tại.");
                            $("#ngaybatdau").focus();
                            return false;
                        } else if (nkt < nbd) {
                            $.mkv.myerror("Ngày kết thúc không nhỏ hơn ngày bắt đầu.");
                            $("#ngayhethan").focus();
                            return false;
                        }
                    } else {
                        $.mkv.myerror("Ngày bắt đầu và ngày kết thúc không bỏ trống.");
                        $("#ngaybatdau").focus();
                        return false;
                    }
                }
                return true;
            }, function(data) {
                if (data.indexOf("@") != -1) {
                    var val = data.split('@');
                    $.mkv.queryString("idkhoachinh", val[0]);
                    $("#mabenhnhan").val(val[1]);
                }
                 $.mkv.ExtendtionLuu(false, { Frame: "#thontindangkykham"});
                setTimeout(function() { $("#dangKy").focus() }, 100);
            });
            $("#tenbenhnhan").focus();
            if ($("#loai").val() == "2")
                $.mkv.ExtendtionLuu(true, { Frame: "#thongtinbh" });
               
        });
        $("#moi").click(function() {
            $(this).Moi();
            $("#ngaytiepnhan").val(dd + "/" + mm + "/" + yyyy);
            $("#ngaydangky").val(dd + "/" + mm + "/" + yyyy);
            macdinhbaohiem();
            $("#tenbenhnhan").focus();
            $("#dangKy").css("display", "");
        });
        $("#xoa").click(function() {
            $(this).Xoa({ ajax: "../ajax/benhnhan_ajax.aspx?do=xoa" });
        });
        $("#timKiem").click(function() {
            Find(this);
        });
        
          $("#DKCLS").click(function() {
            window.open("dangkyCLS.aspx?idbenhnhan="+$.mkv.queryString("idkhoachinh"),'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');  
        });
        
        $("#dangKy").click(function() {
            $(this).TimKiem({
                ajax: "../ajax/benhnhan_ajax.aspx?do=dangkykhambenh&idbenhnhan=" + $.mkv.queryString("idkhoachinh")
                         + "&loai=" + $("#loai").val()
                         + "&sobh1=" + $("#sobh1").val()
                         + "&sobh2=" + $("#sobh2").val()
                         + "&sobh3=" + $("#sobh3").val()
                         + "&sobh4=" + $("#sobh4").val()
                         + "&sobh5=" + $("#sobh5").val()
                         + "&sobh6=" + $("#sobh6").val()

                         , Frame: "#thontindangkykham"
            }, function(value) {
                $("#dangKy").css("display", "none");
                $("#moi").focus();
                $.mkv.myalert(value, 1000, "success");

            }, function() {
                if ($("#ngaydangky").val() == "") {
                    $.mkv.myerror("Chưa chọn ngày đăng ký.");
                    return false;
                }
                return true;
            });
        });


    });

    function setControlFind(idkhoatimkiem) {
        if (idkhoatimkiem != "" && idkhoatimkiem != null) {
            $.BindFind({ ajax: "../ajax/benhnhan_ajax.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem });
        }
    }
    function Find(control, page) {
        if (page == null) page = "1";
        $(control).TimKiem({
            ajax: "../ajax/benhnhan_ajax.aspx?do=TimKiem&page=" + page
        });
    }
//    function idloaiuutienSearch(obj) {
//        $(obj).unautocomplete().autocomplete("../ajax/benhnhan_ajax.aspx?do=idloaiuutienSearch", {
//            minChars: 0,
//            width: 350,
//            scroll: true,
//            formatItem: function(data) {
//                return data[0];
//            } 
//        }).result(function(event, data) {
//            $("#" + obj.id.replace("mkv_", "")).val(data[1]);
//            setTimeout(function() {
//                obj.focus();
//            }, 100);
//        });
//    }
//    function loaiSearch(obj) {
//        $(obj).unautocomplete().autocomplete("../ajax/benhnhan_ajax.aspx?do=loaiSearch", {
//            minChars: 0,
//            width: 350,
//            scroll: true,
//            formatItem: function(data) {
//                return data[0];
//            } 
//        }).result(function(event, data) {
//            if (data[1] == "2") {
//                $.mkv.XoaTrangData({ Frame: "#thongtinbh" });
//                $.mkv.ExtendtionLuu(true, { Frame: "#thongtinbh" });
//            } else {
//                $.mkv.ExtendtionLuu(false, { Frame: "#thongtinbh" });
//            }
//            $("#" + obj.id.replace("mkv_", "")).val(data[1]);
//            setTimeout(function() {
//                obj.focus();
//            }, 100);
//        });
//    }
//    function idphongkhambenhSearch(obj) {
//        $(obj).unautocomplete().autocomplete("../ajax/benhnhan_ajax.aspx?do=idphongkhambenhSearch&loaibn=" + $("#loai").val(), {
//            minChars: 0,
//            width: 350,
//            scroll: true,
//            formatItem: function(data) {
//                return data[0];
//            } 
//        }).result(function(event, data) {

//            $("#" + obj.id.replace("mkv_", "")).val(data[1]);
//            $.ajax({
//                cache: false,
//                url: "../ajax/benhnhan_ajax.aspx?do=loadSTT&idphongkhambenh=" + $("#idphongkhambenh").val(),
//                success: function(data) {
//                    $("#STT").val(data);
//                }
//            });
//            setTimeout(function() {
//                obj.focus();
//            }, 100);
//        });
//    }
    function madangkybhSearch(obj) {
        //    $(obj).unautocomplete().autocomplete("../ajax/benhnhan_ajax.aspx?do=madangkybhSearch", {
        //    minChars: 0,
        //    width: 350,
        //    scroll: true,
        //    header: "",
        //    formatItem: function(data) {
        //        return data[0];
        //    } 
        //}).result(function(event, data) {

        //    if (data[2].indexOf("79 - 029") == -1)
        //        $("#IsDungTuyen").attr("checked", true);
        //    else
        //        $("#IsDungTuyen").attr("checked", false);

        //    $(obj).val(data[2]);
        //    $("#noidangkykcb").val(data[3]);

        //    setTimeout(function() {
        //        obj.focus();
        //    }, 100);
        //});
    }
    function ktramabh(obj) {
        $.ajax({ cache: false,
            url: "../ajax/benhnhan_ajax.aspx?do=ktramabh&mabh=" + obj.value,
            success: function(data) {
                if (data.split('|')[2].indexOf("79 - 029") == -1)
                    $("#IsDungTuyen").attr("checked", true);
                else
                    $("#IsDungTuyen").attr("checked", false);
                $("#noidangkykcb").val(data.split('|')[3]);
            }
        });
    }
    function loaichuyen(obj) {
        if (obj.value == "2" || obj.value == "3") {
            $.mkv.XoaTrangData({ Frame: "#thongtinbh" });
            $.mkv.ExtendtionLuu(true, { Frame: "#thongtinbh" });
        } else {
            $.mkv.ExtendtionLuu(false, { Frame: "#thongtinbh" });
            macdinhbaohiem();
        }
        $("#idphongkhambenh").DropList({ ajax: "../ajax/benhnhan_ajax.aspx?do=idphongkhambenhSearch&loaibn=" + $("#loai").val() });
        obj.focus();
    }
    function idphongkhambenhchuyen(obj) {
        $.ajax({
            cache: false,
            url: "../ajax/benhnhan_ajax.aspx?do=loadSTT&idphongkhambenh=" + obj.value,
            success: function(data) {
                $("#STT").val(data);
            }
        });
    }
    function macdinhbaohiem() {
        $("#noidangkykcb").val("SỞ Y TẾ TP. HỒ CHÍ MINH-BỆNH VIỆN QUẬN 12");
        $("#MaDangKy_KCB_bandau").val("79 - 029");
    }
// xu ly chuoi bao hiem
(function($) {
    $.fn.extend({
        chuyenBH: function(sokitu, kieudulieu) {
			
            $(this).keyup(function(event) {
                if (event.keyCode == 37 || event.keyCode == 39) return;
                if (event.keyCode != 46 && event.keyCode != 8) {
                    if ($(this).attr("id") != "sobh6") {
                        if ($(this).val().length == sokitu) {
                            var nextIdx = $('input[type=text]');
                            nextIdx = nextIdx.eq(nextIdx.index(this) + 1).select();
                        }
                    }
                }
            }).keydown(function(event) {
                if (event.keyCode == 37 || event.keyCode == 39) return;
                if (event.keyCode != 46 && event.keyCode != 8 && event.keyCode != 9) {
                    if ((kieudulieu != null && kieudulieu == "char") && ((event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode >= 48 && event.keyCode <= 57))) {
                        return false;
                    } else if ((kieudulieu != null && kieudulieu == "num") && ((event.keyCode < 96 || event.keyCode > 105) && (event.keyCode < 48 || event.keyCode > 57))) {
                        return false;
                    }
                    if ($(this).val().length >= sokitu) {
                        return false;
                    }
                } else if (event.keyCode == 8) {
                    if ($(this).attr("id") != "sobh1") {
                        if ($(this).val().length <= 0) {
                            var nextIdx = $('input[type=text]');
                            nextIdx = nextIdx.eq(nextIdx.index(this) - 1).focus();
                        }
                    }
                }
            }).focus(function(){
				$.setFocusCharacter(this,this.value.length);
			}).blur(function() {
                var flagbh = true;
                $("[id^=sobh]").each(function () {
                    if(this.id == "sobh1" && this.value.length != 2)
                        flagbh = false;
                    else if(this.id == "sobh2" && this.value.length != 1)
                        flagbh = false;
                    else if(this.id == "sobh3" && this.value.length != 2)
                        flagbh = false;
                    else if(this.id == "sobh4" && this.value.length != 2)
                        flagbh = false;
                    else if(this.id == "sobh5" && this.value.length != 3)
                        flagbh = false;
                    else if(this.id == "sobh6" && this.value.length != 5)
                        flagbh = false;
                });
                if(flagbh == true){
                    $.ajax({
                        cache:false,
                        url:"../ajax/benhnhan_ajax.aspx?do=kiemtrabhdangky"
                         + "&sobh1=" + $("#sobh1").val()
                         + "&sobh2=" + $("#sobh2").val()
                         + "&sobh3=" + $("#sobh3").val()
                         + "&sobh4=" + $("#sobh4").val()
                         + "&sobh5=" + $("#sobh5").val()
                         + "&sobh6=" + $("#sobh6").val(),
                        error:function (value) {
                            $.mkv.myerror(value.responseText);
                        }
                    });
                }
                $(this).unbind("keydown");
                $(this).unbind("blur");
            });
        },
        validMaDK: function() {
            $(this).keydown(function(event) {
                if (event.keyCode == 9 || (event.keyCode == 37 || event.keyCode == 39)) return;
                if (((event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode >= 48 && event.keyCode <= 57)) || (event.keyCode == 8 || event.keyCode == 46)) {
                    if (event.keyCode != 8 && event.keyCode != 46) {
                        if ($(this).val().substring(0, $.getCharacter(this)).length == 2) {
                            if ($(this).val().indexOf("-") != -1) {
                                $.setFocusCharacter(this, $(this).val().indexOf("-") + 2);
                            } else {
                                $(this).val($(this).val() + " - ");
                            }
                        } else {
                            if ($(this).val().indexOf("-") != -1) {
                                if ($(this).val().substring(4, $(this).val().length).length > 3) {
                                    return false;
                                }
                            }
                        }
                    } else {
                        var nobackspace1 = [' ', '-'];
                        var pos = $.getCharacter(this);
                        if (event.keyCode == 8)
                            if (pos > 0) pos--;
                        if (!$.inArray($(this).val().charAt(pos), nobackspace1)) {
                            $.setFocusCharacter(this, $(this).val().indexOf("-") - 1);
                            return false;
                        }
                    }
                } else {
                    return false;
                }
            }).keyup(function(event) {
                if (event.keyCode == 9 || (event.keyCode == 37 || event.keyCode == 39)) return;
                if ($(this).val().substring(0, $.getCharacter(this)).length == 2) {
                    if ($(this).val().indexOf("-") != -1) {
                        $.setFocusCharacter(this, $(this).val().indexOf("-") + 2);
                    } else {
                        $(this).val($(this).val() + " - ");
                    }
                }
            }).blur(function() {
                $(this).unbind("keydown");
                $(this).unbind("blur");
            });
        }
    });
})(jQuery);


