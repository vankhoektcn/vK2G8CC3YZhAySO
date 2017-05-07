<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nvk_baoCaoSuDung15Ngay_new.aspx.cs"
    Inherits="nvk_baoCaoSuDung15Ngay_new" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!--#include file ="../khoasan/header.htm"-->
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
    background: #4d67a2 url(../images/bottom_nav_bg1.jpg) no-repeat top center;
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
 border:1px solid black ;
 padding-bottom:3px;
 padding-top:3px;
 }
.fieldset_TTNK
{
 border:2px solid Pink ;
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
        font: normal 12px "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif;
        border-right: 1px solid #C1DAD7;
        border-bottom: 1px solid #C1DAD7;
        padding: 6px 12px 6px 12px;
        color: #4f6b72;
        text-align:left;
        }
  table.table15Ngay tr:hover
        {
			background:#f6ebcd;	
		}      
        
        
        
</style>

<script type="text/javascript" src="../noitru/js/nvk_GiuongBenh.js"></script>

<script language="javascript" type="text/javascript">
     
    var dp_cal1; 
      var dp_cal; 
	window.onload = function () 
	{
	    //btnMoi_click();
	};
function btnMoi_click()
{
    $("#txtTuNgay").val(dayNew());
    $("#txtDenNgay").val(dayNew());
	    $("#txtmabenhnhan").val("");
	    $("#txttenbenhnhan").val("");
	    btnTimKiem_click();    
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

function btnTimKiem_click()
{
        $("#divDanhSachBN").html("<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang load bệnh nhân chờ nhập khoa.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_TienGiuongPhongSanh_ajax.aspx?do=btnTimKiem_click&idkhoa="+queryString("IdKhoa")+"&mabenhnhan="+$("#txtmabenhnhan").val()+"&tenbenhnhan="+encodeURIComponent($("#txttenbenhnhan").val())+"&tungay="+$("#txtTuNgay").val()+"&denngay="+$("#txtDenNgay").val()+"";	            
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
function DongTienGiuong_Click(idchitietdangkykham)
{
//    $(obj).TimKiem({
//        ajax:"../ajax/nvk_TienGiuongPhongSanh_ajax.aspx?do=TienGiuong_Click&idkhoa="+queryString("IdKhoa")+"&idctdkk="+idchitietdangkykham+"&idbenhnhan="+idbenhnhan+"&ngaynhap="+ngaynhap+"&tenphong="+tenphong+""
//        ,title:"Bệnh Nhân - Tiền Giường"
//    },null,null,function(){});
        var PathUrl="../ajax/nvk_TienGiuongPhongSanh_ajax.aspx?do=TienGiuong_Click&idkhoa="+queryString("IdKhoa")+"&idctdkk="+idchitietdangkykham+""
    $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            var divG=document.getElementById("nvkDivGFather");
                            divG.style.display="block";                            
                            document.getElementById("nvk_divChua").innerHTML=value;
                            $.mkv.queryString("idctdkk",idchitietdangkykham);
                        }
                });
    
}
function btnDongNhapKhoa_Click()
{
    $("#divTimKiem").remove();
}

</script>

<form id="Form1" method="post" runat="server">
    <div id="divMenu" style="width: 99%; height: 20px;">
        <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
    </div>
    <div id="divFather" style="width: 99%;border: solid 1px Blue">
        <div id="divHeader" class="divHeader_">
            BÁO CÁO SỬ DỤNG THUỐC</div>
        <fieldset class="fieldset_Father">
            <div id="divTK1" class="divControl">
                <fieldset class="fieldset_CT">
                    <legend class="legend_CT">Lọc báo cáo</legend><span class="spanText">Kho:</span>
                    <%--<input mkv="true" id="txtmabenhnhan" type="text" style="width: 110px" />--%>
                    <asp:dropdownlist id="ddlKho" runat="server" width="150px"></asp:dropdownlist>
                    <span class="spanText">Đối tượng:</span>
                    <asp:dropdownlist id="ddlLoaiThuoc" runat="server" width="130px"></asp:dropdownlist>
                    <%--<input mkv="true" id="txttenbenhnhan" type="text" style="width: 150px" />--%>
                    <span class="spanText">Từ ngày:</span>
                    <input id="txtTuNgay" type="text" runat="server" onfocus="$(this).datepick();" onblur="nvk_testDate_this(this);"
                        style="width: 80px;" />
                    <input id="txtTuGio" type="text" runat="server" style="width:50px;" value="00:00:00"/>
                    <span class="spanText">Đến ngày :</span><input id="txtDenNgay" type="text" runat="server"
                        onfocus="$(this).datepick();" onblur="nvk_testDate_this(this);" style="width: 80px;" />
                    <input id="txtDenGio" type="text" runat="server" style="width:50px;" value="23:59:59"/>&nbsp;
                                                
                                                <input type="radio" id="rd_OdABC" value="" runat="server" name="rdOrder"/>
                                                <span style="padding-right: 10px;color:Blue">S.X ABC</span>  
                                                <input type="radio" id="rd_OdLoai" value=""  checked="true" runat="server" name="rdOrder"/>
                                                <span style="padding-right: 10px;color:Blue">S.X phân loại</span>  
                    <br />
                    <span class="spanText">Sử dụng theo: </span>
                    <select id="ddLoaiNgaySuDung" runat="server" >
                        <option value="ngayxuat">Ngày xuất</option>
                        <option value="ngaychidinh">Ngày chỉ định</option>
                    </select>
                    <span class="spanText">Đã xuất? </span>
                    <input type="checkbox" runat="server" id="cbIsDaXuat" checked="checked" />
                    <input type="button" runat="server" id="btnLayBaoCao" value="Lấy báo cáo" style="width: 100px"
                        onserverclick="btnLayBaoCao_ServerClick" onclick="LayBaoCao_Click();" />
                    <input type="button" runat="server" id="btnXuatExcell" value="Xuất Excell" style="width: 80px"
                        onserverclick="btnXuatExcell_ServerClick" />
                    <%--<asp:button runat="server" text="Lấy báo cáo" id="btnLayBaoCao"  style="width: 80px" />
                    <asp:button runat="server" text="Xuất Excell" id="btnXuatExcell"  style="width: 80px" />--%>
                </fieldset>
            </div>
            <div class="divContent">
                <fieldset class="fieldset_ND">
                    <legend class="legend_ND">Nội dung kết quả báo cáo</legend>
                    <div id="divNoiDungBaoCao" runat="server" style="width: 100%;">
                        <%--<table style="width: 100%" rules="all">
                            <tr>
                                <td align="left">
                                    <span class="sp_Blue_Bold">BỆNH VIỆN ĐA KHOA MINH ĐƯC </span>
                                </td>
                            </tr>
                            <tr>
                            <tr>
                                <td align="left">
                                    <span class="sp_Blue_Bold">Khoa :Khoa ngoại </span>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <span class="sp_Blue_Bold" style="font-size: 22px;">BÁO CÁO SỬ DỤNG THUỐC 15 NGÀY (TỪ
                                        01/10/2012 - 15/10/2012)</span></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                        <table rules="all"  style="border:solid 1px Black;width:100%;">
                        <tr>
                        <td><span class="sp_Red_Bold" style="color:Green">Thuốc - Hàm lượng</span></td>
                        <td><span class="sp_Red_Bold" >Đvt</span></td>
                        <td><span class="sp_Red_Bold" >01/10</span></td>
                        <td><span class="sp_Red_Bold" >02/10</span></td>
                        <td><span class="sp_Red_Bold" >03/10</span></td>
                        <td><span class="sp_Red_Bold" >04/10</span></td>
                        <td colspan="3"><span class="sp_Red_Bold" >05/10</span></td>
                        <td><span class="sp_Red_Bold" >06/10</span></td>
                        <td><span class="sp_Red_Bold" >07/10</span></td>
                        <td><span class="sp_Red_Bold" >08/10</span></td>
                        </tr>
                        </table>--%>
                        <span style="text-align:left"></span>
                        
                        <%--nvk end comment--%>
                    </div>
                </fieldset>
            </div>
        </fieldset>
    </div>
    <%--dkkd--%>
    <%--fgfjkfk--%>
</form>

<script type="text/javascript">
function hideDivG_BN(divname)
{
    document.getElementById(divname).style.display="none";
    $.mkv.removeQueryString('idctdkk');
}
function LayBaoCao_Click()
{
    $("#divNoiDungBaoCao").html("<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang lấy báo cáo.....<img id='imgLoading' src='../images/processing.gif' /></span>");
}
</script>

<style type="text/css">
.sp_Blue_Bold
{
    color:Blue;font-weight:bold;
}
.sp_Red_Bold
{
    color:Red;font-weight:bold;
}
</style>
<!--#include file ="../khoasan/footer.htm"-->
