<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTM_DanhSachPhieuThuHoaDon.aspx.cs" Inherits="ketoan_KTTM_DanhSachPhieuThuHoaDon" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_TienMat.ascx" TagName="menu_ketoantienmat" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

 <!--#include file ="header.htm"-->
<link type="text/css" rel="stylesheet" href="../ketoan/css_KeToan/sheet_index.css" />
<link href="../ketoan/css_KeToan/epoch_styles.css" type="text/css" rel="stylesheet" />
<link href="../ketoan/css_KeToan/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/default.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/style.css" />
<script type="text/javascript" src="../ketoan/js_KeToan/libary.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/script.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jscript.js"></script>
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/table_TCHD.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/epoch_styles.css" />
<link href="../ketoan/css_ketoan/dropdown/dropdown.css" media="screen" rel="stylesheet" type="text/css" />
<link href="../ketoan/css_ketoan/dropdown/themes/default/default.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../ketoan/js_KeToan/epoch_classes.js"></script>
<script type="text/javascript" src="../ketoan/editor/editor.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jquery-1.4.2.js"></script>
<script src="../js/jquery.autocomplete.js" type="text/javascript"></script>
    

 <script language="javascript" type="text/javascript">
 var dp_cal,dp_cal2;
 window.window.onload = function () 
{
     dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));	
	 dp_cal2 = new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
}
 function FormatSoTien(obj)
{
	    return formatCurrency(obj);
}
function ResetTableDSPhieuThu()
{
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var lastRow = Row;
    while(lastRow>2)
    {
        TableDanhSach.deleteRow(lastRow-1);
        lastRow--;
    }

}
function ShowKhachHang(obj)
{
            var objsrc = document.getElementById(obj);
      
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachKhachHang&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:700,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    setChonKhachHang(data[2],data[3]);
                                                                   // document.getElementById(obj).blur();
                                                                }
                                                            ); 
   
}


function setChonKhachHang(MaKH,TenKH)
{
      
      var txtMaKH=document.getElementById('txtMaKH');
      var txtTenKH=document.getElementById('txtTenKH');
      txtMaKH.value=MaKH;
      txtTenKH.value = TenKH;
      
    document.getElementById('txtTenKH').focus();
}
function TestMaKH(obj)
{
    if(obj.value=="")
    {
        document.getElementById('txtMaKH').value = "";
    }
}
 function LoadDanhSachPhieuThuHoaDon()
 {
    ResetTableDSPhieuThu();
     var TuNgay  = document.getElementById('txtTuNgay').value;
     var DenNgay  = document.getElementById('txtDenNgay').value;
     var SoPhieuThu  = document.getElementById('txtSoPhieuThu').value;
     var MaKH  = document.getElementById('txtMaKH').value;
     xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                  if (value!="")
                  {  
                    //alert(value);
                    var Row = value.split('|');
                    for(i=1;i<Row.length;i++)
                    {
                       var Column = Row[i].split('&');
                       ShowDanhSachPhieuThu(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7]);
                    }                    
                  }
                  else
                  {
                    alert("Không có danh sách phiếu thu!");
                  }
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=DanhSachPhieuThu&TuNgay="+TuNgay+"&DenNgay="+DenNgay+"&MaKH="+MaKH+"&SoPhieuThu="+SoPhieuThu+"&times="+Math.random(),true);
        xmlHttp.send(null);
 }
 function ShowDanhSachPhieuThu(PhieuThuID,SoPhieuThu,NgayThu,MaKH,DienGiai,TKNo,Tien,Status)
 {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
              // ResetTableDSPhieuThu();
    var link = "";
    //var typePhieuThu = SoPhieuThu.substring(0,4);         
    if(Status=="True")
    {
        link = "KTTM_PhieuThuHoaDon.aspx";
    }
    else
        link = "KTTM_ThuKhac.aspx";
    var TableDanhSach = document.getElementById('TableDanhSach');
    var lastRow = TableDanhSach.rows.length; 
    var shtml = "<tr class=\"RowGidView\">";
        shtml += "		<td style=\"width:50px;text-align:center\">"+(lastRow-1)+"</td>	";
        if('<%=StaticData.HavePermision(this.Page, "KeToanTM_KTTM_DanhSachPhieuThu_Xoa")%>' != 'False')
            shtml += "		<td style=\"width:50px;text-align:center\"><label id=\"Xoa_"+(lastRow-1)+"\" style=\"cursor:pointer;font-style:italic;color:Blue\" onclick=\"XoaPhieuThu('"+SoPhieuThu+"')\">Xóa</label></td>	";
        else
            shtml += "		<td style=\"width:50px;text-align:center\"><label id=\"Xoa_"+(lastRow-1)+"\" style=\"cursor:pointer;font-style:italic;color:Blue\" onclick=\"XoaPhieuThu('"+SoPhieuThu+"')\"></label></td>	";    
        shtml += "		<td style=\"width:200px;text-align:center\"  id=\"txtSoPT_"+(lastRow-1)+"\"><a href=\""+link+"?idPhieuThu="+PhieuThuID+"&SoPT="+SoPhieuThu+"&MaKh="+MaKH+"&dkmenu=kttienmat\"><input type=\"hidden\" id=\"hdSoPT_"+(lastRow-1)+"\" value=\""+SoPhieuThu+"\"/>"+SoPhieuThu+"</a></td>	";
        shtml +="       <td style=\"width:200px;text-align:center\"  id=\"txtNgayThu_"+(lastRow-1)+"\"><input type=\"hidden\" id=\"hdNgayThu_"+(lastRow-1)+"\" value=\""+NgayThu+"\"/>"+NgayThu+"</td>";
      
        shtml += "		<td style=\"width:200px;text-align:center\"  id=\"txtMaKH_"+(lastRow-1)+"\"><input type=\"hidden\" id=\"hdMaKH_"+(lastRow-1)+"\" value=\""+MaKH+"\"/>"+MaKH+"</td>	";
        shtml += "		<td style=\"width:300px;text-align:left\"  id=\"txtDienGiai_"+(lastRow-1)+"\"> "+DienGiai+"</td>	"; 
        shtml += "      <td style=\"width:200px;text-align:center\"  id=\"txtTKNo_"+(lastRow-1)+"\"> "+TKNo+"</td>	"; 
        shtml += "		<td style=\"width:300px;text-align:right\" id=\"txtTien_"+(lastRow-1)+"\">"+FormatSoTien(Tien)+"</td>	";  
//        
     shtml += "	</tr>";
  $("#TableDanhSach:last").append(shtml);           
 }
 function XoaPhieuThu(SoPhieuThu)
 {
    var rs = confirm("Bạn muốn xóa phiếu thu  "+SoPhieuThu+" này?");
    if(rs==true)
    {
        getFunctionXoaPhieuThu(SoPhieuThu);
    }
    
 }
function getFunctionXoaPhieuThu(SoPhieuThu)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {  
                        alert("Xóa phiếu thu thành công");
                      }
                      else
                      {
                          alert("Xóa phiếu thu thất bại");
                      }
                    LoadDanhSachPhieuThuHoaDon();     
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=XoaPhieuThu&SoPhieuThu="+SoPhieuThu+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
 </script>
<form id="form1" runat="server">
<div width = "100%" align = "left" style="height:  34px;background-color:#007138"> <uc1:menu_ketoantienmat ID="menu_ketoantienmat1" runat="server" /></div>
<div>
    <table>
        <tr>
            <td>Từ ngày : </td>
            <td><input type="text" id="txtTuNgay" runat="server" onclick="dp_cal.toggle()" /></td>
            <td>Đến ngày :</td>
            <td><input type="text" id="txtDenNgay" runat="server" onclick="dp_cal2.toggle()" /></td>
            <td>Số phiếu thu :</td>
            <td><input type="text" id="txtSoPhieuThu" /></td>
            <td>Khách hàng :</td>
            <td><input type="text" id="txtTenKH" onchange="TestMaKH(this)" onfocus="ShowKhachHang('txtTenKH')" /><input type="hidden" id="txtMaKH" /></td>
            <td><input type="button" id="bt_TimKiem"  onclick="LoadDanhSachPhieuThuHoaDon()" value="Tìm kiếm" /></td>
        </tr>
    </table>
</div>
<div>

<table class="TableGidview" id="TableDanhSach">
         <tr>
              <td class ="tdHeader" colspan="10" >DANH SÁCH PHIẾU THU</td>
         </tr>
		<tr class="HeaderGidView">
		    
		      <td style="width:50px">
		       STT
		       
		     </td>
		     <td style="width:50px">
		       		       
		     </td>
		     <td style="width:200px">
		       Số phiếu thu
		       
		     </td>
		     <td style="width:200px">
		       Ngày thu
		       
		    </td>
		    <td style="width:300px">
		        Mã khách hàng
		    </td>
		     
		      <td style="width:300px">
		        Diễn giải
		      
		      </td>
		      <td style="width:200px">
		        Tài khoản nợ
		      </td>
		      <td style="width:200px">
		         Tổng tiền
		         
		      </td>
		        <%-- phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien--%>
		    <%--<td class="HeaderColumn3">
		        Tiền đã thanh toán
		       
		    </td>
		   <td class="HeaderColumn3">
		        Tiền còn lại
		       
		    </td>
		   <td class="HeaderColumn3">
		        Tiền thanh toán
		       
		    </td>
		    <td class="HeaderColumn1">
		       Cập nhật
		       
		    </td>--%>
		</tr>					 
					  
	</table> 
</div>
</form>
