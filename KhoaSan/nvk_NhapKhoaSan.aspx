<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nvk_NhapKhoaSan.aspx.cs"
    Inherits="nvk_NhapKhoaSan" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!--#include file ="header.htm"-->
<style>
.divHeader_
{
    width: 100%;
    padding:5px 0px 0px 0px;
    height:30px;
    margin: 0px 0px 0px 0px;
    background-color: DarkBlue;
    text-align:center;
    font-weight:bold;
    font-size: 18px;
    color: White;
}
.divControl
{
    width: 98%;
    padding:0px 5px 5px 5px;
    height:auto;
    margin: 0px 5px 5px 5px;
    text-align:center;
    
}
.spanText
{
    padding:5px 5px 5px 5px;
    font-family:Arial;
}
.spanText_Blue
{
    padding:5px 5px 5px 5px;
    font-family:Arial;
    color:Blue;
    font-weight:bold;
}
.divContent
{
    width: 98%;
    padding:0px 5px 5px 5px;
    height:auto;
    margin: 0px 5px 5px 5px;
    text-align:center;
    
}
.fieldset_Father 
{
 border:2px #CAE3FF ;
 padding-bottom:3px;
 padding-top:3px;
 }
.fieldset_CT 
{
 border:3px solid white ;
 padding-bottom:3px;
 padding-top:3px;
 }

.legend_CT {
 color:Blue;
    padding:2px;
    margin-left: 14px;
    font-weight:bold;
    font-size: 14px;
  }
.fieldset_ND 
{
 border:1px solid Blue ;
 padding-bottom:3px;
 padding-top:3px;
 }
.fieldset_TTNK
{
 border:2px solid Blue ;
 padding-bottom:3px;
 padding-top:3px;
}
.legend_ND {
 color:Green;
    padding:2px;
    margin-left: 14px;
    font-weight:bold;
    font-size: 14px;
    font-style:italic;
  }
.button_1
{
    font-weight:bold;
    font-size: 16px;
    color:Red;
}
.legend_TTNK
{
    color:Green;
    padding:2px;
    margin-left: 14px;
    font-weight:bold;
    font-size: 18px;
    font-style:italic;
  }
  table.jtable td
        {
        font: normal 11px  Verdana, Arial, Helvetica, sans-serif;
        border-right: 1px solid #C1DAD7;
        border-bottom: 1px solid #C1DAD7;
        padding: 6px 12px 6px 12px;
        color: #4f6b72;
        text-align:left;
        }
</style>

<script language="javascript" type="text/javascript">
     
    var dp_cal1; 
      var dp_cal; 
	window.onload = function () 
	{
	    btnMoi_click();
	};
function btnMoi_click()
{
	    var curentDay= CurentDate();
//	    $("#txtTuNgay").val(curentDay);
//	    $("#txtDenNgay").val(curentDay);
    $("#txtTuNgay").val(dayNew());
    $("#txtDenNgay").val(dayNew());
	    $("#txtmabenhnhan").val("");
	    $("#txttenbenhnhan").val("");
	    btnTimKiem_click();    
}
function CurentDate()
{
  var d, s = "";
  d = new Date();
  var nvk_day= d.getDate().toString();
  var nvk_month= (d.getMonth() + 1).toString();
  s += FormatMonth_Day(nvk_day) + "/";
  s += FormatMonth_Day(nvk_month) + "/";
  s += d.getYear();
  return(s);
}
function dayNew()
{
    var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();
        if (dd < 10) { dd = '0' + dd }
        if (mm < 10) { mm = '0' + mm }
        var aa= dd + "/" + mm + "/" + yyyy;
        return aa;
}
function FormatMonth_Day(GiaTri)
{
    if(GiaTri.length<2)
        GiaTri= "0"+GiaTri;
    return GiaTri;
}
    function TestDatePhieu(t)
	{
		if (t.value != "")
		{
			t.value=AddString(t.value);
			if (isDate(t.value)==false)
			{
				t.value="";
				alert("Bạn nhập ngày tháng không hợp lệ ! ");
				t.focus();
			}
		}
		return;
	}
function btnTimKiem_click()
{
        $("#divDanhSachBN").html("<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang load bệnh nhân chờ nhập khoa.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_NhapKhoaSan_ajax.aspx?do=btnTimKiem_click&idkhoa="+queryString("IdKhoa")+"&mabenhnhan="+$("#txtmabenhnhan").val()+"&tenbenhnhan="+encodeURIComponent($("#txttenbenhnhan").val())+"&tungay="+$("#txtTuNgay").val()+"&denngay="+$("#txtDenNgay").val()+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            document.getElementById('divDanhSachBN').innerHTML=value;
                        }
                });
}
function DongNhapHauSan_Click(idnoitru,idKB_NhapHS,obj)
{
    $(obj).TimKiem({
        ajax:"../ajax/nvk_NhapKhoaSan_ajax.aspx?do=NhapHauSan_Click&idkhoa="+queryString("IdKhoa")+"&idnoitru="+idnoitru+"&idkhambenh="+idKB_NhapHS+""
        ,title:"Bệnh Nhân - Nhập Khoa",width:"1000px", height:"420px"
    },null,null,function(){});
}
function DongVaoChoSanh_Click(idnoitru,idKB_ChoSanh,obj)
{
    $(obj).TimKiem({
        ajax:"../ajax/nvk_NhapKhoaSan_ajax.aspx?do=VaoChoSanh_Click&idkhoa="+queryString("IdKhoa")+"&idnoitru="+idnoitru+"&idkhambenh="+idKB_ChoSanh+""
        ,title:"Nhập Bệnh Chờ Sanh",width:"1000px", height:"420px"
    },null,null,function(){});
}
function btnLuuNhapKhoa_Click(idkhoa,idkhambenh,IsLuuCho,IsHauSanh)
{
    $("#spDangLuuNhap").html("<span style='height: auto; width: 100%;text-align:center; color: Blue; font-weight: bold;font-style:italic' class='Tieude'> Đang lưu nhập khoa.....<img id='imgLoading' src='../images/processing.gif' /></span>");
    var txtNgayNhap=$("#txtNgayNhap").val();
        if(txtNgayNhap==""){alert("Chưa chọn ngày nhập khoa !");document.getElementById('spDangLuuNhap').innerHTML="";return; }
    var txtGioNhap=$("#txtGioNhap").val();
    var selPhongNhap="0";//$("#selPhongNhap").val();
    if(IsLuuCho==0)
        selPhongNhap=document.getElementById("selPhongNhap").value;//$("#selPhongNhap").val();
    var selGiuongNhap=document.getElementById("selGiuongNhap").value;//$("#selGiuongNhap").val();
    var txtGiaGiuong=$("#txtGiaGiuong").val();
    var idbacsi=$("#idbacsi").val();
        if(idbacsi=="" || idbacsi=="0"){alert("Chưa chọn Bác Sĩ !");document.getElementById('spDangLuuNhap').innerHTML="";return; }
    var iddieuduong=$("#iddieuduong").val();
    var cbTinhTienTrongNgay=document.getElementById("cbTinhTienTrongNgay").checked;//$("#cbTinhTienTrongNgay").checked;
    var idnoitru= $("#idCdNhapKhoa").val();
    // kiểm tra không lưu giường
    if(document.getElementById("cbTinhGiuongCho") != null)
        {
        if(document.getElementById("cbTinhGiuongCho").checked== false)
            selGiuongNhap="0";
            
        }
    // return;
    var listQuer="&txtNgayNhap="+txtNgayNhap+"&txtGioNhap="+txtGioNhap+"&selPhongNhap="+selPhongNhap+"&selGiuongNhap="+selGiuongNhap+"&txtGiaGiuong="+txtGiaGiuong+"&idbacsi="+idbacsi+"&iddieuduong="+iddieuduong+"&cbTinhTienTrongNgay="+cbTinhTienTrongNgay+"&IsHauSanh="+IsHauSanh+"";
        var PathUrl="../ajax/nvk_NhapKhoaSan_ajax.aspx?do=btnLuuNhapKhoa_Click&IsLuuCho="+IsLuuCho+"&idkhoa="+queryString("IdKhoa")+"&idkhambenh="+idkhambenh+"&idnoitru="+idnoitru+""+listQuer;	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            if(value !="")
                            {
                                document.getElementById('spDangLuuNhap').innerHTML="";
                                $("#idCdNhapKhoa").val(value);
                                nvk_luutableChanDoanNhapKhoa(value);
                            }
                            else
                            {
                                document.getElementById('spDangLuuNhap').innerHTML="";
                                alert("Lưu THẤT BẠI !");                                
                            }
                        }
                });
}
function btnDongNhapKhoa_Click()
{
    $("#divTimKiem").remove();
}
function nvk_luutableChanDoanNhapKhoa(idnoitru)
{
   $.LuuTable({
         ajax:"../ajax/nvk_NhapKhoaSan_ajax.aspx?do=nvk_luutableChanDoanNhapKhoa&idkhoa="+queryString("IdKhoa")+"&idnoitru="+idnoitru+"",
         tablename:"gridTableCDPH"
        },null,function () 
            {
                alert("Đã lưu THÀNH CÔNG !");
                btnTimKiem_click();
            }
         );//end LuuTable
}
</script>

<form id="Form1" method="post" runat="server">
    <div id="divMenu" style="width: 99%; height: 20px;">
        <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
    </div>
    <div id="divFather" style="width: 99%;border: solid 1px Black;">
        <div id="divHeader" class="divHeader_">
            Nhập Khoa</div>
        <fieldset class="fieldset_Father">
            <div id="divTK1" class="divControl">
                <fieldset class="fieldset_CT">
                    <legend class="legend_CT">Tìm kiếm bệnh nhân</legend><span class="spanText">Mã bệnh
                        nhân:</span><input mkv="true" id="txtmabenhnhan" type="text" style="width: 110px" />
                    <span class="spanText">Tên bệnh nhân:</span>
                    <input mkv="true" id="txttenbenhnhan" type="text" style="width: 150px" />
                    <%--<span class="spanText">Giới tính:</span> <input mkv="true" id="Text2" type="text" style="width: 50px" />
<span class="spanText">Năm sinh:</span> <input type="text" id="namsinh" style="width: 80px;" />--%>
                    <span class="spanText">Từ ngày:</span>
                    <input id="txtTuNgay" type="text" runat="server"  onfocus="$(this).datepick();" onblur="nvk_testDate_this(this);" 
                        style="width: 80px;" />
                    <span class="spanText">Đến ngày :</span><input id="txtDenNgay" type="text" runat="server"
                         onfocus="$(this).datepick();" onblur="nvk_testDate_this(this);"  style="width: 80px;" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnTimKiem" onclick="btnTimKiem_click()" value="Tìm Kiếm" style="width: 80px" />
                    <input type="button" id="btnMoi" onclick="btnMoi_click()" value="Mới" style="width: 80px" />
                </fieldset>
            </div>
            <div class="divContent">
                <fieldset class="fieldset_ND">
                        <legend class="legend_ND">Danh sách bệnh nhân chờ nhập khoa</legend>
                        <div id="divDanhSachBN" runat="server" style="width:100%"></div>
                </fieldset>
            </div>
        </fieldset>
    </div>
</form>
<script language="javascript" type="text/javascript">

	function nvk_LoadGiuongNhapTheoPhong(obj,idkhoa)
	{
	var idphong= $("#selPhongNhap").val();
	    $("#spGiuongNhap").html("<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang load Giường.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_NhapKhoaSan_ajax.aspx?do=nvk_LoadGiuongNhapTheoPhong&idkhoa="+queryString("IdKhoa")+"&idphong="+idphong+"";
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            $("#spGiuongNhap").html(value);
                        }
                });
	}
	function nvk_LoadGiaTheoGiuong(obj,idkhoa)
	{
	var idgiuong= $("#selGiuongNhap").val();
        var PathUrl="../ajax/nvk_NhapKhoaSan_ajax.aspx?do=nvk_LoadGiaTheoGiuong&idkhoa="+queryString("IdKhoa")+"&idgiuong="+idgiuong+"";
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            $("#txtGiaGiuong").val(value);
                        }
                });
	}
	function idbacsisearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/nvk_commonFuntion_ajax.aspx?do=idbacsisearch",{
             minChars:0,
             width:550,
             scroll:true,
             header:"Danh sách bác sĩ",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                    $("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
  function iddieuduongsearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=iddieuduongNhapKhoasearch",{
             minChars:0,
             width:550,
             scroll:true,
             header:"Danh sách điều dưỡng",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                    $("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
function ChanDoansearch(obj,IsMa)
         {
             $(obj).unautocomplete().autocomplete("../ajax/nvk_NhapKhoaSan_ajax.aspx?do=ChanDoansearch&IsMaICD="+IsMa+"",{
             minChars:0,
             width:550,
             scroll:true,
             addRow:false,
             header:"Chẩn đoán ICD10...",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                //$(obj).val(data[4]);
                $("#gridTableCDPH").find("tr").eq($(obj).parent().parent().index()).find("#idicd").val(data[1]);
                $("#gridTableCDPH").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idicd").val(data[2]);
                $("#gridTableCDPH").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idicdMoTa").val(data[3]);
//                 if($(obj).parents("#gridTableCDPH").attr("id") != null){
//                     $("#gridTableCDPH").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
//                 }
                 nvk_themdongtableCDPH(obj);
                 setTimeout(function () {
                     obj.focus();
                 },100);
                 
             });
             
         }
         function xoaontableCDPH(control){
            if($(control).parents("table").find("tr").length < 4){
                //$.mkv.themDongTable($(control).parents("table").attr('id'));
                nvk_themdongtableCDPH(control);
            }
                  var valueCLS = $(control).parents("table").find("tr").eq($(control).parent().parent().index()).find("#idicd").val();
                  $(control).XoaRow({
                     ajax:"../ajax/nvk_NhapKhoaSan_ajax.aspx?do=xoanvk_chanDoanNhapKhoa",
                     valueErXoa:"Không có quyền xóa !"
                  });               
         }
         var tablegrid="gridTableCDPH";
function chuyendongPH(control,isAuTo){
    try{
        if(event.keyCode == 40 || (isAuTo != null && isAuTo==true)){
                  //if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[1].getElementsByTagName("a")[0] == null && document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[control.parentNode.cellIndex].getElementsByTagName("select")[0] == null){
                    //themDongTable(tablegrid); 
                    nvk_themdongtableCDPH(control)
                //}
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0] != null)
                     document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0].focus();
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0] != null)
                    document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0].focus();
        }
        if(event.keyCode == 38){
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0] != null )
                     document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0].focus();
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0] != null)
                    document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0].focus();  
                
                    var flagrow = false;
                    for(var i = 0;i<document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells.length ;i++)
                    {
                        if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[i].getElementsByTagName('input')[0] != null){
                        if( document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[i].getElementsByTagName('input')[0].type == "text"){
                            if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[i].getElementsByTagName('input')[0].value.length > 0 && document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[i].getElementsByTagName('input')[0].value != '0'){
                            flagrow = true;
                            return;
                          }
                         }
                       }
                    }
                if(flagrow == false && document.getElementById(tablegrid).rows.length > 3 && (document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells.length - 1].getElementsByTagName('input')[0].value.length < 1 ))
                    document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);
        }
        if(event.keyCode == 27){
            if(control.type == 'text' || document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[control.parentNode.cellIndex].getElementsByTagName("select")[0] != null)
                chuyenformout(control);
        }
        if(event.keyCode == 13){
            if(control.type == 'text' || document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[control.parentNode.cellIndex].getElementsByTagName("select")[0] != null)
            {
                if(control.style.position=='')
                    chuyenform(control);
                else
                    chuyenformout(control);
            }
       }
    }catch(ex){}
}
function nvk_themdongtableCDPH(obj)
    {
    //alert("thêm dòng");
        if(document.getElementById("gridTableCDPH").rows[obj.parentNode.parentNode.rowIndex + 1] == null){
        
        var htmlPH="<tr>"
        +"<td>" + (obj.parentNode.parentNode.rowIndex + 1) + "</td>"
        +"<td><a onclick='xoaontableCDPH(this)'><%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %></a></td>"
        +"<td><input mkv='true' id='idicd' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idicd' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,1)' value='' class='down_select' style='width:80px'/></td>"
        +"<td><input mkv='true' id='mkv_idicdMoTa' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,0)' value='' class='down_select' style='width:320px'/></td>"
        //+"<td><input id='mkvDown' type='text'  value='' style='width:10px'  onkeydown=\"chuyendongPH(this);\" /></td>"
        +"<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>"
        +"</tr>";
        $("#gridTableCDPH").append(htmlPH);
        
           }
    }
</script>

<script type="text/javascript" language="javascript">
function OnCheck_TinhGiuongCho(idCheck)
{
    if(idCheck.checked == true)
	{
        document.getElementById("selGiuongNhap").disabled=false;
        document.getElementById("txtGiaGiuong").disabled=false;
        document.getElementById("cbTinhTienTrongNgay").disabled=false;
    }
    else
    {
        document.getElementById("selGiuongNhap").disabled=true;
        document.getElementById("txtGiaGiuong").disabled=true;
        document.getElementById("txtGiaGiuong").value="0";
        document.getElementById("cbTinhTienTrongNgay").disabled=true;
        document.getElementById("cbTinhTienTrongNgay").checked= false;
        //alert(document.getElementById("txtGiaGiuong").value);
        //alert($("#txtGiaGiuong").val());
    }
    
}
</script>
<!--#include file ="footer.htm"-->
