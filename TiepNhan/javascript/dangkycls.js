$(document).ready(function(){
  
    $("#idkhoadangky").DropList({ajax:"ajax/dangkyCLS_Ajax.aspx?do=idkhoadangkysearch",defaultVal:"- Chọn khoa - "});
    $("#idbacsi").DropList({ajax:"ajax/dangkyCLS_Ajax.aspx?do=LoadDanhSachBacSiCD",defaultVal:"- Chọn bác sĩ - " });
    $("#idnguoidung").DropList({ajax:"ajax/dangkyCLS_Ajax.aspx?do=LoadDSNguoiTiepNhan",defaultVal:"- Người đăng ký - "});
    setControlFind($.mkv.queryString("idbenhnhan"));
    loadTableAjaxkhambenhcanlamsan($.mkv.queryString("idkhoachinh"));
    $("#dangky").click(function(){
        SaveThuPhi();
    });
    $("#moi").click(function(){
        window.close();
    });
});
function setControlFind(idkhoatimkiem){
   if (idkhoatimkiem != "" && idkhoatimkiem != null) {
            $.BindFind({ ajax: "ajax/dangkyCLS_Ajax.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem + "&idkhoa=" + $.mkv.queryString("IdKhoa") },null,function(){
                     $.mkv.ExtendtionLuu(true, { Frame: "#thongtindangky"});
                        $("#idbacsi").attr("disabled",false);
                $("#gridTablecls input").attr("disabled",false);
        });
    }
}
function loadTableAjaxkhambenhcanlamsan(idkhoa, page) {
if (idkhoa == null) idkhoa = "";
if (page == null) page = "1";
$("#tableAjax_khambenhcanlamsan").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>');
$.ajax({
    type: "GET",
    cache: false,
    url: "ajax/dangkyCLS_Ajax.aspx?do=loadTablekhambenhcanlamsan&idkhambenh=" + idkhoa + "&page=" + page,
    success: function(value) {
        $("#tableAjax_khambenhcanlamsan").html(value);
         
        tongtiencls();
    }
});
}
 function thanhtiencls(obj) {
    var tientruocck = eval($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val()) * eval($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val());
    var tienck = (eval(tientruocck) * eval($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#chietkhau").val())) / 100;
    $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(tientruocck - tienck);
}   
function tongtiencls()
{
    var tablegrid="gridTablecls";   
    var tongtien=0;
    for(var i=1;i<document.getElementById(tablegrid).rows.length-1;i++)
    {
    try{
        if(typeof eval(document.getElementById(tablegrid).rows[i].cells[8].getElementsByTagName("input")[0].value.replace(/\$|\,/g,''))!='undefined')
             tongtien += eval(document.getElementById(tablegrid).rows[i].cells[8].getElementsByTagName("input")[0].value.replace(/\$|\,/g,''));
        }catch(ex){}
    }
    document.getElementById(tablegrid).rows[document.getElementById(tablegrid).rows.length-1].cells[2].innerText = formatCurrency(tongtien).split(".")[0];
}
function idcanlamsansearch(obj) {
  
    $(obj).unautocomplete().autocomplete("ajax/dangkyCLS_Ajax.aspx?do=idcanlamsansearch&idbenhnhan=" + $("#idbenhnhan").val() + "&loaibenhnhan=" + $("#loaibenhnhan").val()+ "&tennhom=" +  encodeURIComponent($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#mkv_tennhom").val()) + "&idphongkhambenh=" + $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#idkhoa").val(), {
        minChars: 0,
        width: 550,
        scroll: true,
        addRow: true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {

        if ($(obj).parents("#gridTablecls").attr("id") != null) {
            $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
            $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val("1");
            $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val(data[2]);
            $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#isbh").val(data[3]);
            $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#chietkhau").val("0");
            $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
            thanhtiencls(obj);
            tongtiencls();
        }
        setTimeout(function() {
            $("#gridTablecls").find("tr").next().eq($(obj).parent().parent().index()).find("#mkv_idcanlamsan").focus();
        }, 100);
    });
}
$.mkv.afterThemDong = function(tablename, dongso) {
    if (tablename == "gridTablecls") {
        //xac dinh select row below
        $("#"+tablename).find("tr").eq(dongso+1).find("#idkhoa").val($("#"+tablename).find("tr").eq(dongso).find("#idkhoa").val());
        $("#"+tablename).find("tr").eq(dongso+1).find("#mkv_idkhoa").val($("#"+tablename).find("tr").eq(dongso).find("#mkv_idkhoa").val());
        $("#"+tablename).find("tr").eq(dongso+1).find("#mkv_tennhom").val($("#"+tablename).find("tr").eq(dongso).find("#mkv_tennhom").val());
        //end xac dinh 
    }
}
function idkhoachange(obj)
{
  $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#mkv_tennhom").val('');
  $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idcanlamsan").val('');
    
}
function idkhoasearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/dangkyCLS_Ajax.aspx?do=idkhoasearch", {
        minChars: 0,
        width: 150,
        scroll: true,
        catche: false,
        addRow: false,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        
        $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
          $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#mkv_tennhom").focus();
        }, 100);
    });
}
 function idkhoadangkysearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/dangkyCLS_Ajax.aspx?do=idkhoadangkysearch", {
        minChars: 0,
        width: 200,
        scroll: true,
        catche: false,
        addRow: true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
         $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}
function idphongsearch(obj) {

    $(obj).unautocomplete().autocomplete("ajax/dangkyCLS_Ajax.aspx?do=idphongsearch&idpkb=" + $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#idkhoa").val(), {
        minChars: 0,
        width: 200,
        scroll: true,
        catche: false,
        addRow: false,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
    
        $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
          $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idcanlamsan").focus();
        }, 100);
    });
}
//--------------------------can lam sang---------------------------------------------------------
var listCLS = "";
function ChonCLS(obj, idnhom, idpkb,loai) {
    if (idpkb == null)
        listCLS = "";
    for (var i = 1; i < $("#gridTablecls").find("tr").length; i++) {
        if ($.trim($("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val()).length > 0)
            listCLS += $("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val() + ",";
    }
    if (idpkb == null)
        idpkb = 0;
    $(obj).TimKiem({
        ajax: "ajax/dangkyCLS_Ajax.aspx?do=ChonCLS&listID=" + listCLS + "&idpkb=" + idpkb 
        + "&IdBenhNhan=" + $.mkv.queryString("idbenhnhan") 
        + "&loaibenhnhan="+$.mkv.queryString("LoaiBN"), 
        readMKV: false,
        onlyPopup:false,
        width:"1000",
        heigth:"800",aysnc:true
    });
}
    function checkAllCLS(obj) {
    var tableCLS = $(obj).parents("table").find("tr");
    for (var i = 0; i < tableCLS.length; i++) {
        CheckXoaCLS(tableCLS.eq(i).find("input[type=checkbox]").val());
        if ($(obj).is(":checked")) {
            tableCLS.eq(i).find("input[type=checkbox]").attr("checked", true);
            listCLS += tableCLS.eq(i).find("input[type=checkbox]").val() + ",";
        } else {
            tableCLS.eq(i).find("input[type=checkbox]").attr("checked", false);
        }
    }
}
function setChonDichVuCLS(obj) {
    CheckXoaCLS($(obj).val());
    if ($(obj).is(":checked")) {
        listCLS += $(obj).val() + ",";
    }
    tongtiencls();
}

function CheckXoaCLS(vals) {
    if (listCLS.indexOf(",") != -1) {
        var arrIDDV = listCLS.split(',');
        for (var j = 0; j < arrIDDV.length; j++) {
            if (arrIDDV[j] == vals) {
                var stemp = new RegExp(arrIDDV[j] + ",", 'g');
                listCLS = listCLS.replace(stemp, '');
                break;
            }

        }
    }
}
$.mkv.runCloseTimKiem = function(obj) {
   var loai = "";
   if($(obj).attr("onclick").indexOf("cls") != -1){
        loai = "cls";
   }
    if(loai=="cls"){
        var slvack = "";
        for (var i = 0; i < $("#gridTablecls").find("tr").length; i++) {
            var idcls = $("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val();
            var sl = $("#gridTablecls").find("tr").eq(i).find("#soluong").val();
            var ck = $("#gridTablecls").find("tr").eq(i).find("#chietkhau").val();
            var idkhoachinh = $("#gridTablecls").find("tr").eq(i).find("#idkhoachinh").val();
            if ((sl > 1 || ck > 0) || (idkhoachinh != null && idkhoachinh != ""))
                slvack += "@" + idcls + "^" + sl + "^" + ck+"^"+idkhoachinh;

        }
        var idkhambenh = "";
        if ($.mkv.queryString("idkhoachinh") != "")
            idkhambenh = $.mkv.queryString("idkhoachinh");
        else
            idkhambenh = $.mkv.queryString("idkhoachinh");

        $("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
        $.ajax({
            type: "GET",
            dataType: "text",
            url: "ajax/dangkyCLS_Ajax.aspx?do=GetDSCLS&listID=" + listCLS + "&IdBenhNhan=" + $("#idbenhnhan").val() + "&IdKhambenh=" + idkhambenh + "&slvack=" + slvack +"&loaibenhnhan="+$("#loaibenhnhan").val(),
            success: function(data) {
                if(data!=null && data!="" && data!="error")
                {
                   $("#tableAjax_khambenhcanlamsan").html(data);
                   tongtiencls();
                }
                $("#loadingAjax").remove();
            }
        });
    }
}
//------------------------------------------------------------------------------------------------------
function xoaontablecls(control) {
    var sttmoi=$(control).parent().parent().index();
    var valueCLS = $(control).parents("table").find("tr").eq($(control).parent().parent().index()).find("#idcanlamsan").val();
    $(control).XoaRow({
        ajax: "ajax/dangkyCLS_Ajax.aspx?do=xoakhambenhcanlamsan"
    });

    (($(control).parent().parent().index() == -1) ? CheckXoaCLS(valueCLS) : "");
    var row=document.getElementById("gridTablecls").getElementsByTagName("tr");
    for(var i=sttmoi;i<row.length-1;i++){
        row[i].childNodes[0].innerHTML=i;
    }
    tongtiencls();
}
function CreatenewCLS()
{
  $.ajax({
    type: "GET",
    async:false,
    cache: true,
    url: "ajax/dangkyCLS_Ajax.aspx?do=create&idbenhnhan="+ $("#idbenhnhan").val() + "&ngaydk=" + $("#ngaythu").val() + "&nguoidk=" + $("#idnguoidung").val() +"&IdKhoa="+$("#idkhoadangky").val(),
    success: function(data) {
         var values=data.split('|');
        $("#maphieucls").val(values[0]);
        $("#iddangkycls").val(values[1]);
        $("#IsDKK").val(values[2]);
      }
   });
}    
function SaveThuPhi()
{   
    var tablegridcls="gridTablecls";
    var dichvutrung="";
    for(var k=1;k<document.getElementById(tablegridcls).rows.length-1;k++)
    {
        for(var l=k+1;l<document.getElementById(tablegridcls).rows.length-1;l++){
            if(document.getElementById(tablegridcls).rows[k].cells[4].getElementsByTagName("input")[0].value==document.getElementById(tablegridcls).rows[l].cells[4].getElementsByTagName("input")[0].value){
                    dichvutrung+=document.getElementById(tablegridcls).rows[l].cells[4].getElementsByTagName("input")[1].value + ",";
            }
        }
    }
    if(dichvutrung.split(',')[0].length-1>0){
         $.mkv.myerror("Dịch vụ : " + dichvutrung + " trùng nhau");
            return false;        
    }
   if($("#maphieucls").val()==""){
       CreatenewCLS();
   }
   var ngaythu=$("#ngaythu").val();
    $.LuuTable({
        ajax:"ajax/dangkyCLS_Ajax.aspx?do=luuTablekhambenhcanlamsan&ngaythu=" + ngaythu 
                                                            + "&idbenhnhan=" + $("#idbenhnhan").val()  
                                                            + "&idbacsi=" + $("#idbacsi").val() 
                                                            + "&bscd=" + encodeURIComponent($("#idbacsi option:selected").text()) 
                                                             + "&idnguoidung=" + $("#idnguoidung").val()
                                                             +"&MaPhieuCLS="+ $("#maphieucls").val()  
                                                             + "&iddangkycls=" + $("#iddangkycls").val() 
                                                             + "&idkhoadangky=" + $("#idkhoadangky").val()
                                                             +"&IsDKK="+ $("#IsDKK").val()
                                                             +"&gio="+$.mkv.queryString("gio")+"&phut="+$.mkv.queryString("phut")
                                                             ,
        tablename:"gridTablecls"
      
    },function(){
      
          if ($("#txtngayphieu").val() == "") {
            $.mkv.myerror("Bạn chưa chọn ngày đăng ký phí dịch vụ. Vui lòng kiểm tra lại.");
         
            return false;
        }
        else if ($("#ddlNguoiTiepNhan").val() == "" || $("#ddlNguoiTiepNhan").val()=="0") {
            $.mkv.myerror("Bạn chưa chọn người tiếp nhận. Vui lòng kiểm tra lại.");
            return false;
        }
        else if ($("#txtidbenhnhan").val() == "" || $("#txtidbenhnhan").val()=="0") {
            $.mkv.myerror("Bạn chưa chọn Bệnh nhân. Vui lòng kiểm tra lại.");
            return false;
        }
       return true;
    },function(){
             $.mkv.myalert('Đăng ký CLS thành công !',1000,"success");
             $("#moi").focus();
    });
}
function idbacsisearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/dangkyCLS_Ajax.aspx?do=LoadDanhSachBacSiCD", {
        minChars: 0,
        width: 300,
        scroll: true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
           $("#trieuchung").focus();
        }, 100);
    });
}

 //------------------------------can lam sang thuong quy ----------------------------------
 $.fn.rowCount = function() {
    return $('tr', $(this).find('tbody')).length;
 };
 function ChoncanlamsangThuongquy(obj)
 {
   
    $(obj).TimKiem({
        ajax:"ajax/dangkyCLS_Ajax.aspx?do=ChonclsThuongquy"
            ,title:"Cận lâm sàng thường quy"
            ,readMKV:false
            ,onlyPopup:false
    },function(){
       /* var rowsCount=$("#gridTablecls").rowCount()-2;
        if(rowsCount >1){
            $.mkv.myerror("Đã có chỉ định cận lâm sàng rồi.");
            return false;
        }*/
        return true;
    },null);
 }
function setCSLThuongQuy(idkhoa,page)
 {
         listCLS="";
         var slvack = "";
         for (var i = 1; i < $("#gridTablecls").find("tr").length; i++) {
            if ($.trim($("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val()).length > 0)
                listCLS += $("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val() + ",";
            var idcls = $("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val();
            var sl = $("#gridTablecls").find("tr").eq(i).find("#soluong").val();
            var ck = $("#gridTablecls").find("tr").eq(i).find("#chietkhau").val();
            var idkhoachinh = $("#gridTablecls").find("tr").eq(i).find("#idkhoachinh").val();
            if ((sl > 1 || ck > 0) || (idkhoachinh != null && idkhoachinh != ""))
                slvack += "@" + idcls + "^" + sl + "^" + ck+"^"+idkhoachinh;
         }
         if(idkhoa == null) idkhoa = "";
         if(page == null) page = "1";
            $.mkv.dongtimkiem('default');
         $("#tableAjax_khambenhcanlamsan").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
         $.ajax({
            async:false,
             type:"GET",
             cache:false,
             url:"ajax/dangkyCLS_Ajax.aspx?do=setCSLThuongQuy&NhomId="+idkhoa+"&page="+page + "&loaibenhnhan=" + $.mkv.queryString("LoaiBN") + "&listID="  + listCLS + "&slvack=" + slvack,
              success: function (value){
                     document.getElementById("tableAjax_khambenhcanlamsan").innerHTML=value;
                     $("table.jtable tr:nth-child(odd)").addClass("odd");
                     $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                     $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                      tongtiencls();
                }
         });
 }
 