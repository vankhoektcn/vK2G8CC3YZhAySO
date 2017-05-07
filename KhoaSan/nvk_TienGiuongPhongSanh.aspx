<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nvk_TienGiuongPhongSanh.aspx.cs"
    Inherits="nvk_TienGiuongPhongSanh" %>

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
 border:3px ;
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
        
        
        
        
</style>
<script type="text/javascript" src="../noitru/js/nvk_GiuongBenh.js"></script>

<script language="javascript" type="text/javascript">
     
    var dp_cal1; 
      var dp_cal; 
	window.onload = function () 
	{
	    btnMoi_click();
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
    <div id="divFather" style="width: 99%;">
        <div id="divHeader" class="divHeader_">
            Tiền Giường Phòng Sanh</div>
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
                        <legend class="legend_ND">Danh Sách Bệnh Nhân - Tiền Giường</legend>
                        <div id="divDanhSachBN" runat="server" style="width:100%"></div>
                </fieldset>
            </div>
        </fieldset>
    </div>
    <%--dkkd--%>
    <div style="display:none;position:fixed;top:15%;bottom:10%;left:10%;width:80%;height:430px;background-color:White;z-index:1000;padding:10px 10px 10px 10px;border:10px solid #4D67A2;overflow-y:visible;" id="nvkDivGFather" >
        <div style="width:100%;height:25px;background: url(../images/bgmenu.gif) repeat;">
            <span align="left" style="float:left;padding-top:2px;padding-left:10px;cursor:pointer;font-weight:bold;" onmousedown="mouseDown('nvkDivGFather')" onmouseup="mouseRelease()">Thông Tin Giường Bệnh</span>
            <span style="float:right"><img src="../images/close.gif" align="right" style="width:25px;height:25px;" title="click vào để đóng danh sách" onclick="hideDivG_BN('nvkDivGFather')" style="cursor:pointer;"></span>
        </div>
        <div id="nvk_divChua" style="width:100%;height:400px !inportant;overflow-y:scroll;float:right">
        
        </div>
    </div>
    
    <%--fgfjkfk--%>
</form>
<script type="text/javascript">
function hideDivG_BN(divname)
{
    document.getElementById(divname).style.display="none";
    $.mkv.removeQueryString('idctdkk');
}
</script>
<!--#include file ="footer.htm"-->
