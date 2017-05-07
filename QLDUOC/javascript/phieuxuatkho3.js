var IdKho_Prev = null;
var NgayThang_Prev = null;
var IdKho2_Prev = null;
var MaPhieuXuat_Prev = null;
var Gio_Prev = null;
var Phut_Prev = null;
$(document).ready(function () {
    //───────────────────────────────────────────────────────────────────────────────────────
    setIdKho();
    $.mkv.moveUpandDown("#tablefind");
    setControlFind($.mkv.queryString("idkhoachinh"));
    var ishongvo = "";
    if ($.mkv.queryString("IdKho2") != null && $.mkv.queryString("IdKho2") != "")
        ishongvo = "1";
    $("#luu").click(function () {
        $(this).Luu({
            ajax: "../ajax/phieuxuatkho_ajax3.aspx?do=Luu" + "&ishongvo=" + ishongvo
                        + "&IdKho_Prev=" + IdKho_Prev
                         + "&NgayThang_Prev=" + NgayThang_Prev
                         + "&IdKho2_Prev=" + IdKho2_Prev
                         + "&MaPhieuXuat_Prev=" + MaPhieuXuat_Prev
                         + "&Gio_Prev=" + Gio_Prev
                         + "&Phut_Prev=" + Phut_Prev
        }, function () {
            var thuoctrung = "";
            if ($("#idkho2").val() == null || $("#idkho2").val() == "") {
                $.mkv.myerror("Vui lòng chọn kho nhập");
                $("#mkv_idkho2").focus();
                return false;
            }
            for (var i = 1; i < $('#gridTable >tbody >tr').length - 1; i++) {
                for (var j = i + 1; j < $('#gridTable >tbody >tr').length - 1; j++) {
                    if ($("#gridTable").find("tr").eq(i).find("#IdThuoc").val() == $("#gridTable").find("tr").eq(j).find("#IdThuoc").val()) {
                        thuoctrung += $("#gridTable").find("tr").eq(j).find("#mkv_IdThuoc").val() + ",";
                    }
                }
            }
            if (thuoctrung.split(',')[0].length - 1 > 0) {
                $.mkv.myerror(thuoctrung + " trùng nhau");
                return false;
            }
            if (!checkSLTon_Grid()) return false;

            //------------------------------------------------
            return true;
        }, function () {
            $.LuuTable({
                ajax: "../ajax/phieuxuatkho_ajax3.aspx?do=luuTableHS_OutPutDetail&IdPhieuXuat=" + $.mkv.queryString("idkhoachinh")
                         + "&IdKho_Prev=" + IdKho_Prev
                         + "&NgayThang_Prev=" + NgayThang_Prev
                         + "&IdKho2_Prev=" + IdKho2_Prev
                         + "&IdKho=" + $("#idkho").val()
                         + "&NgayThang=" + $("#ngaythang").val()
                         + "&IdKho2=" + $("#idkho2").val()

                         + "&Gio=" + $("#gio").val()
                         + "&Gio_Prev=" + Gio_Prev
                         + "&Phut=" + $("#phut").val()
                         + "&Phut_Prev=" + Phut_Prev
                         ,
                tablename: "gridTable"
            }, null, function () {
                $.ajax({
                    async: false,
                    cache: false,
                    url: "../ajax/phieuxuatkho_ajax3.aspx?do=GetMaPhieuXuat&IdPhieuXuat=" + $.mkv.queryString("idkhoachinh"),
                    success: function (data) {
                        $("#maphieuxuat").val(data.split("|")[0]);

                        IdKho_Prev =  $("#idkho").val();
                        NgayThang_Prev = $("#ngaythang").val();
                        IdKho2_Prev = $("#idkho2").val();
                        MaPhieuXuat_Prev = data.split("|")[0];
                        Gio_Prev = $("#gio").val();
                        Phut_Prev = $("#phut").val();
                        if (data.split("|")[6] != "")
                            alert(data.split("|")[6]);
                    }
                });
            });
        });
    });
    //───────────────────────────────────────────────────────────────────────────────────────
    $("#TimMoi").click(function () {
        $(this).Moi();
        setIdKho();
        loadTableAjaxHS_OutPutDetail('');

    });
    //───────────────────────────────────────────────────────────────────────────────────────
    $("#moi").click(function () {
        $(this).Moi();
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();
        if (dd < 10) { dd = '0' + dd }
        if (mm < 10) { mm = '0' + mm }
        $("#ngaythang").val(dd + "/" + mm + "/" + yyyy);
        setIdKho();
        loadTableAjaxHS_OutPutDetail('');
        $("#luu").css("display", "");
       $("#xoa").css("display", "");
    });
    $("#xoa").click(function () {
        $(this).Xoa({
            ajax: "../ajax/phieuxuatkho_ajax3.aspx?do=xoa"
        }, null, function () {
            loadTableAjaxHS_OutPutDetail('');
        });
    });
    $("#timKiem").click(function () {
        Find($(this));
    });


    $("#ViewDetail").click(function () {
        var idkhoachinh = $.mkv.queryString("idkhoachinh");
        if (idkhoachinh == null || idkhoachinh == "") return;
        window.open("HS_ChiTietPhieuXuat.aspx?idkhoachinh=" + idkhoachinh);
    });
    $("#PrintBienBan").click(function () {
        var idphieuxuat = $.mkv.queryString("idkhoachinh");
        if (idphieuxuat == null || idphieuxuat == "") return false;
        $.ajax({
            type: "POST",
            url: "../ajax/phieuxuatkho_ajax3.aspx?do=PrintBienBan"
                             + "&idphieuxuat=" + idphieuxuat,
            dataType: "text",
            success: function (data) {
                window.open(data, "_blank");
            }
        });
    });
});
function setControlFind(idkhoatimkiem) {
          
    if (idkhoatimkiem != "" && idkhoatimkiem != null) {
        $.BindFind({ ajax: "../ajax/phieuxuatkho_ajax3.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem }, null, function () {
            loadTableAjaxHS_OutPutDetail($.mkv.queryString("idkhoachinh"));
            
            $("#_luu").click(function () {
                var myTable = document.getElementById("gridTable");
                var controls = myTable.getElementsByTagName("input");
                for (i = 0; i < controls.length; i++) {
                    controls[i].disabled = !controls[i].disabled;
                }
                for (var j = 0; j < $("#gridTable >tbody >tr").length; j++) {
                    $("#gridTable").find("tr").eq(j).find("td").eq(1).find("a").attr("disabled", false);
                    $("#gridTable").find("tr").eq(j).find("td").eq(1).find("a").attr("onclick", "xoaontable(this,true);");
                }
            });
        });
    } else { loadTableAjaxHS_OutPutDetail(); }
    
    
}
function Find(control, page) {
    if (page == null) page = "1";
    $(control).TimKiem({
        ajax: "../ajax/phieuxuatkho_ajax3.aspx?do=TimKiem&page=" + page, width: "1000"
    }, null, function (data) {
        if (data == null || data == "") {
            $.mkv.closeDivTimKiem();
        }
    });
}
function xoaontable(control, bool) {
    if (bool || bool == null)
        $(control).XoaRow({
            ajax: "../ajax/phieuxuatkho_ajax3.aspx?do=xoaHS_OutPutDetail"
        });
}

function setIdKho() {
    if ($.mkv.queryString("idkhoachinh") != null && $.mkv.queryString("idkhoachinh") != "") return false;
    if ($.mkv.queryString("IdKho2") != null && $.mkv.queryString("IdKho2") != "") {
        $("#mkv_idkho2").attr("disabled", true);
        $("#PrintBienBan").css("display", "");
        $(".header-div").html("Phiếu xuất hỏng vỡ");
        // $("#SOPHIEUYC").attr("disabled",true);
    }
    else {
        //$("#xuathongvo").css("display", "none");
    }

    $.BindFind({
        ajax: "../ajax/phieuxuatkho_ajax3.aspx?do=setIdKho"
                + "&idkhoa=" + $.mkv.queryString("idkhoa")
                + "&IdKho=" + $.mkv.queryString("IdKho")
                + "&IdKho2=" + $.mkv.queryString("IdKho2")
                + "&LoaiThuocID=" + $.mkv.queryString("LoaiThuocID"), useEnabled: false
    }, null, function () {
        $("#SOTT").attr("disabled", true);

        if ($.mkv.queryString("IdKho2") != null && $.mkv.queryString("IdKho2") != "") {
            TaoSoPhieuYC();
        }
    });

}
function loadTableAjaxHS_OutPutDetail(idkhoa, page) {
    var hongvo;
    if ($.mkv.queryString("IdKho2") != null && $.mkv.queryString("IdKho2") != "")
        hongvo = "1";
    if (idkhoa == null) idkhoa = "";
    if (page == null) page = "1";
       
    $("#tableAjax_HS_OutPutDetail").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>');
    $.ajax({
        type: "GET",
        cache: false,
        url: "../ajax/phieuxuatkho_ajax3.aspx?do=loadTableHS_OutPutDetail&idphieuxuat=" + idkhoa + "&page=" + page + "&ishongvo=" + hongvo
        + "&IDPHIEUYC=" + $("#IDPHIEUYC").val()
        + "&IDPHIEUYCTRA=" + $("#IDPHIEUYCTRA").val()
        ,
        success: function (value) {
            document.getElementById("tableAjax_HS_OutPutDetail").innerHTML = value;
            $("table.jtable tr:nth-child(odd)").addClass("odd");
            $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
            $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
            if (idkhoa != null && idkhoa != "") {
                var myTable = document.getElementById("gridTable");
                var controls = myTable.getElementsByTagName("input");
                for (i = 0; i < controls.length; i++) {
                    controls[i].disabled = "disabled";
                }
                for (var j = 0; j < $("#gridTable >tbody >tr").length; j++) {
                    $("#gridTable").find("tr").eq(j).find("td").eq(1).find("a").attr("disabled", true);
                    $("#gridTable").find("tr").eq(j).find("td").eq(1).find("a").attr("onclick", "xoaontable(this,false);");
                }
            }
        }
    });
    
            IdKho_Prev = $("#idkho").val();
            NgayThang_Prev = $("#ngaythang").val();
            IdKho2_Prev = $("#idkho2").val();
            MaPhieuXuat_Prev = $("#maphieuxuat").val();
            Gio_Prev = $("#gio").val();
            Phut_Prev = $("#phut").val();
    
     if($("#IDPHIEUYC").val()!=null &&$("#IDPHIEUYC").val()!="")
     {
          $("#_luu").css("display", "none");
          $("#xoa").css("display", "none");
          return false;
     }
      if($("#IDPHIEUYCTRA").val()!=null &&$("#IDPHIEUYCTRA").val()!="")
     {
          $("#_luu").css("display", "none");
          $("#xoa").css("display", "none");
          return false;
     }
     
      
                   
                    
}
function IdThuocSearch(obj, type) {
    var idkho2 = $("#idkho2").val();

    $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax3.aspx?do=IdThuocSearch"
            +"&idkho2=" + idkho2 
            + "&loaithuoc=" + $("#IdLoaiThuoc").val() 
            + "&idkho=" + $("#idkho").val()
            + "&NgayCT=" + $("#ngaythang").val() 
            + "&type=" + type
            + "&Gio=" + $("#gio").val()
            + "&Phut=" + $("#phut").val()
            + "&CurrentSL=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#Quantity").val()
            + "&CurrentIdThuoc=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IdThuoc").val()
     , {
         minChars: 0,
         width: 850,
         scroll: true,
         addRow: true,
         header: "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
                + "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
                 + "<div style=\"width:15%;height:30px;color:#000;font-weight:bold;float:left\" >TT HC</div>"
                + "<div style=\"width:25%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;padding-left:5px;\" >Biệt dược</div>"
                + "<div style=\"width:29%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;\" >Hoạt chất</div>"
                + "<div style=\"width:7%;height:30px;color:#000;font-weight:bold;float:left;\" >ĐVT</div>"
                + "<div style=\"width:8%;height:30px;color:#000;font-weight:bold;float:left\" >SLTon </div>"
                + "<div style=\"width:7%;height:30px;color:#000;font-weight:bold;float:left;\" >Dự trù</div>"
                + "</div>",
         formatItem: function (data) {
             $(".ac_results").css("padding-top", "30px");
             return data[0];
         }
     }).result(function (event, data) {
      
         if ($(obj).parents("#gridTable").attr("id") != null) {
             if (type == "2") {
                 $(obj).val(data[11]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IdThuoc").val(data[1]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_IdThuoc").val(data[4]);
             } else if (type == "1") {
                 $(obj).val(data[4]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#tthoatchat").val(data[11]);
             }
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#UnitID").val(data[3]);
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_UnitID").val(data[7]);
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SLTON").val(data[6]);
             if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                 $.mkv.themDongTable("gridTable");
         }
         setTimeout(function () {
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#Quantity").focus();
         }, 100);
     });
}
function UnitIDSearch(obj) {
    $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax3.aspx?do=UnitIDSearch", {
        minChars: 0,
        width: 350,
        scroll: true,
        formatItem: function (data) {
            return data[0];
        }
    }).result(function (event, data) {
        if ($(obj).parents("#gridTable").attr("id") != null) {
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + obj.id.replace("mkv_", "")).val(data[1]);
            if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                $.mkv.themDongTable("gridTable");
        }
        setTimeout(function () {
            obj.focus();
        }, 100);
    });
}
function idkhoSearch(obj) {
    $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax3.aspx?do=idkhoSearch"
                + "&idkhoa=" + $.mkv.queryString("idkhoa")
                + "&IdKho=" + $.mkv.queryString("IdKho")
                , {
                    minChars: 0,
                    width: 250,
                    scroll: true,
                    header: false,
                    formatItem: function (data) {
                        return data[0];
                    }
                }).result(function (event, data) {
                    $("#" + obj.id.replace("mkv_", "")).val(data[1]);
                    setTimeout(function () {
                        obj.focus();
                    }, 100);
                });
}

function idkho2Search(obj) {
    $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax3.aspx?do=idkho2Search"
                + "&idkhoa=" + $.mkv.queryString("idkhoa")
                + "&IdKho=" + $.mkv.queryString("IdKho")
                , {
                    minChars: 0,
                    width: 250,
                    scroll: true,
                    header: false,
                    formatItem: function (data) {
                        return data[0];
                    }
                }).result(function (event, data) {
                    $("#" + obj.id.replace("mkv_", "")).val(data[1]);
                    setTimeout(function () {
                        obj.focus();
                    }, 100);
                });
}
$.mkv.afterThemDong = function (tablename, dongso) {
    if (tablename == "gridTable") {
        $("#" + tablename).find("tr").eq(dongso + 1).find("#SLTON").attr("disabled", true);
    }
}

function IdLoaiThuocSearch(obj) {
    $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax3.aspx?do=IdLoaiThuocSearch", {
        minChars: 0,
        width: 350,
        scroll: true,
        formatItem: function (data) {
            return data[0];
        }
    }).result(function (event, data) {
        $("#" + obj.id.replace("mkv_", "")).val(data[1]);
        setTimeout(function () {
            obj.focus();
        }, 100);
    });
}
function CheckSLTon(obj) {
    var slton = $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SLTON");
    if (eval($(obj).val()) > eval(slton.val())) {
        $.mkv.myerror("Số lượng không vượt quá : " + slton.val());
        $(obj).focus();
        $("#luu").attr("disabled", true);
        $("#_luu").attr("disabled", true);
        return false;
    }
    else {
        $("#luu").attr("disabled", false);
        $("#_luu").attr("disabled", false);
        $("#gridTable").find("tr").next().eq($(obj).parent().parent().index()).find("#tthoatchat").focus();
        return true;
    }
}
function TaoSoPhieuYC() {
    var idkhoa = $("#idkho").val();
    if (idkhoa != null && idkhoa != "") {
        $.ajax({
            async: false,
            url: "../ajax/phieuxuatkho_ajax3.aspx",
            data: {
                "do": "TaoSoPhieuYC",
                idkhoa: idkhoa,
                ngaythang: $("#ngaythang").val()
            },
            success: function (data) {
                $("#SOPHIEUYC").val(data);
            }
        });
    }
}
function InPhieuXuat() {
    if ($.mkv.queryString("idkhoachinh") != "" && $.mkv.queryString("idkhoachinh") != null && $.mkv.queryString("idkhoachinh") != "0") {
        window.open('../Web/frm_PhieuXuatKho_Crpt.aspx?idphieuxuat=' + $.mkv.queryString("idkhoachinh") + "#isPrint=0", '_blank');
    }
    else
        $.mkv.myerror("Chưa lưu phiếu xuất !");

}
function checkSLTon_Grid() {
    var msg = true;
    for (var j = 1; j < $('#gridTable >tbody >tr').length; j++) {
        var tenthuoc = $("#gridTable").find("tr").eq(j).find("#mkv_IdThuoc").val();
        var sl = eval($("#gridTable").find("tr").eq(j).find("#Quantity").val());
        var slton = eval($("#gridTable").find("tr").eq(j).find("#SLTON").val());
        if (sl <= 0) {
            $.mkv.myerror("Số lượng kê " + tenthuoc + " không phù hợp");
            $("#gridTable").find("tr").eq(j).css("background-color", "#f09090");
            return false;
        }
        if (sl > slton) {
            $.mkv.myerror(tenthuoc + ": không đủ tồn.");
            $("#gridTable").find("tr").eq(j).css("background-color", "#f09090");
            msg = false;
        }
    }
    return msg;
}

function ghichuSearch(obj) {
    $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax3.aspx?do=ghichuSearch"
                , {
                    minChars: 0,
                    width: 250,
                    scroll: true,
                    header: false,
                    formatItem: function (data) {
                        return data[0];
                    }
                }).result(function (event, data) {
                    $("#" + obj.id.replace("mkv_", "")).val(data[1]);
                    setTimeout(function () {
                        obj.focus();
                    }, 100);
                });
}