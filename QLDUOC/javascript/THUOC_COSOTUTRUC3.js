$(document).ready(function () {
    $.mkv.moveUpandDown("#tablefind");
    setControlFind($.mkv.queryString("idkhoachinh"));
    $("#luu").click(function () {
        $(this).Luu({
            ajax: "../ajax/THUOC_COSOTUTRUC_ajax3.aspx?do=Luu"
        }, null, function () {
            $.LuuTable({
                ajax: "../ajax/THUOC_COSOTUTRUC_ajax3.aspx?do=luuTableTHUOC_COSOTUTRUC_CHITIET&IdCoSoTuTruc=" + $.mkv.queryString("idkhoachinh"),
                tablename: "gridTable"
            });
        });
    });
    $("#moi").click(function () {
        $(this).Moi();
        loadTableAjaxTHUOC_COSOTUTRUC_CHITIET('');
    });
    $("#xoa").click(function () {
        $(this).Xoa({
            ajax: "../ajax/THUOC_COSOTUTRUC_ajax3.aspx?do=xoa"
        }, null, function () {
            loadTableAjaxTHUOC_COSOTUTRUC_CHITIET('');
        });
    });
    $("#timKiem").click(function () {
        Find($(this));
    });
    $("#IdKho").DropList({
        ajax:"../ajax/THUOC_COSOTUTRUC_ajax3.aspx?do=IdKhoSearch"
        ,defaultVal:"- Chọn kho -"
        ,async:false
    },null,function(){
        if($.isNullOrEmpty($.mkv.queryString("idkhoachinh")))
            $("#IdKho")[0].selectedIndex=1;                        
    });
    $("#LoaiThuocID").DropList({
        ajax:"../ajax/THUOC_COSOTUTRUC_ajax3.aspx?do=LoaiThuocIDSearch"
        ,defaultVal:"- Chọn đối tượng -"
        ,async:false
    },null,function(){
        if($.isNullOrEmpty($.mkv.queryString("idkhoachinh")))
            $("#LoaiThuocID")[0].selectedIndex=1;                        
    });
    setIdKho();
});
function setIdKho() {
    $.BindFind({
        ajax: "../ajax/THUOC_COSOTUTRUC_ajax3.aspx?do=setIdKho",useEnabled:false
    });
}
function setControlFind(idkhoatimkiem) {
    if (idkhoatimkiem != "" && idkhoatimkiem != null) {
        $.BindFind({ ajax: "../ajax/THUOC_COSOTUTRUC_ajax3.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem }, null, function () {
            loadTableAjaxTHUOC_COSOTUTRUC_CHITIET($.mkv.queryString("idkhoachinh"));
        });
    } else { loadTableAjaxTHUOC_COSOTUTRUC_CHITIET(); }
}
function Find(control, page) {
    if ($("#IdKho").val() == null || $("#IdKho").val() == "") {
        $.mkv.myerror("Vui lòng chọn kho.");
        return false;
    }
    if (page == null) page = "1";
    $(control).TimKiem({
        ajax: "../ajax/THUOC_COSOTUTRUC_ajax3.aspx?do=TimKiem&page=" + page
    });
}
function xoaontable(control, bool) {
    if (bool || bool == null)
        $(control).XoaRow({
            ajax: "../ajax/THUOC_COSOTUTRUC_ajax3.aspx?do=xoaTHUOC_COSOTUTRUC_CHITIET"
        });
}
function loadTableAjaxTHUOC_COSOTUTRUC_CHITIET(idkhoa, page) {
    if (idkhoa == null) idkhoa = "";
    if (page == null) page = "1";
    $("#tableAjax_THUOC_COSOTUTRUC_CHITIET").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>');
    $.ajax({
        type: "GET",
        cache: false,
        url: "../ajax/THUOC_COSOTUTRUC_ajax3.aspx?do=loadTableTHUOC_COSOTUTRUC_CHITIET&IdCoSoTuTruc=" + idkhoa + "&page=" + page,
        success: function (value) {
            $("#tableAjax_THUOC_COSOTUTRUC_CHITIET").html(value);
        }
    });
}
function IdThuocSearch(obj) {
    $(obj).unautocomplete().autocomplete("../ajax/THUOC_COSOTUTRUC_ajax3.aspx?do=IdThuocSearch&LoaiThuocID=" + $("#LoaiThuocID").val(), {
        minChars: 0,
        width: 350,
        scroll: true,
        addRow: true,
        formatItem: function (data) {
            return data[0];
        } 
    }).result(function (event, data) {
        if ($(obj).parents("#gridTable").attr("id") != null) {
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + obj.id.replace("mkv_", "")).val(data[1]);
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#tendvt").val(data[2]);
            if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                $.mkv.themDongTable("gridTable");
        }
        setTimeout(function () {
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#CoSo").focus();
        }, 100);
    });
}
$.mkv.afterThemDong = function (tablename, dongso) {
    if (tablename == "gridTable") {
        $("#" + tablename).find("tr").eq(dongso + 1).find("#tendvt").attr("disabled", true);
    }
}
function IdKhoSearch(obj) {
    $(obj).unautocomplete().autocomplete("../../KhoaPhauThuat/ajax/khambenh_ajax3.aspx?do=idkhoxuatsearch&IdKhoa=" + $.mkv.queryString("IdKhoa"), {
        minChars: 0,
        width: 350,
        scroll: true,
        addRow: false,
        header: "<div style =\"width:100%;height:30px\">"
                          + "<div algin='left' style=\"width:15%;color:white;font-weight:bold;float:left; font-size:14px;\" >Mã kho</div>"
                          + "<div style=\"width:65%;color:white;font-weight:bold;float:left; font-size:14px; \" >Tên kho</div>"
               + "</div>",
        formatItem: function (data) {
            return data[0];
        }
    }).result(function (event, data) {
        $(obj).val(data[3]);
        $("#" + obj.id.replace("mkv_", "")).val(data[1]);
        setTimeout(function () {
            $("#mkv_LoaiThuocID").focus();
        }, 100);
    });
}
function LoaiThuocIDSearch(obj) {
    $(obj).unautocomplete().autocomplete("../ajax/THUOC_COSOTUTRUC_ajax3.aspx?do=LoaiThuocIDSearch", {
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