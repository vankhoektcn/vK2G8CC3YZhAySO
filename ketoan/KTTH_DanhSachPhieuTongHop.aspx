<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTH_DanhSachPhieuTongHop.aspx.cs" Inherits="ketoan_KTTM_DanhSachPhieuTongHop" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_TongHop.ascx" TagName="uscmenuKT_TongHopTH" TagPrefix="uc1" %>
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
function ResetTableDSPhieuChi()
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
function ShowNhaCungCap(obj)
{
        var objsrc = document.getElementById(obj);      
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachDoiTuong&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:300,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    setChonNCC(data[2],data[3]);
                                                                    //document.getElementById(obj).blur();
                                                                }
                                                            );     
}
function setChonNCC(MaDT,TenDT)
{
      
      var txtMaDT=document.getElementById('txtMaDT');
      var txtTenDT=document.getElementById('txtTenDT');
     
      txtMaDT.value=MaDT;
      txtTenDT.value = TenDT;
      
      //alert(hd_IDBN.value);
      document.getElementById('txtMaDT').focus();
}
function TestMaNCC(obj)
{
    if(obj.value=="")
    {
        document.getElementById('txtMaDT').value = "";
    }
}
 function LoadDanhSachPhieuTongHop()
 {
    ResetTableDSPhieuChi();
     var TuNgay  = document.getElementById('txtTuNgay').value;
     var DenNgay  = document.getElementById('txtDenNgay').value;
     var SoPhieuTH  = document.getElementById('txtSoPhieuTH').value;
     var MaDT = document.getElementById('txtMaDT').value;
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
                       //phieu_chi_id(0),so_phieu_chi(1),ngay_chi(2),ma_ncc(3),tennnc(4),dien_giai(5),tk_co(6),tien(7)
                        ShowDanhSachPhieuChi(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7],Column[8]);                        
                    }                    
                  }
                  else
                  {
                    alert("Không có danh sách phiếu tổng hợp!");
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=DanhSachPhieuTongHop&TuNgay="+TuNgay+"&DenNgay="+DenNgay+"&MaDT="+MaDT+"&SoPhieuTH="+SoPhieuTH+"&times="+Math.random(),true);
        xmlHttp.send(null);
 }
 function ShowDanhSachPhieuChi(PhieuTHID,SoPhieu,NgayLap,MaDT,TenDT,DienGiai,LoaiTK,TaiKhoan,TongTien)
 {                          
    var TableDanhSach = document.getElementById('TableDanhSach');
    var lastRow = TableDanhSach.rows.length; 
    var link="KTTH_PhieuTongHop.aspx";
    var shtml = "<tr class=\"RowGidView\">";
         shtml += "		<td style=\"width:50px;text-align:center\">"+(lastRow-1)+"</td>	";
         if('<%=StaticData.HavePermision(this.Page, "KeToanTM_KTTM_DanhSachPhieuTongHop_Xoa")%>' != 'False')
            shtml += "		<td style=\"width:50px;text-align:center\"><label id=\"Xoa_"+(lastRow-1)+"\" style=\"cursor:pointer;font-style:italic;color:Blue\" onclick=\"XoaPhieuChi('"+SoPhieu+"')\">Xóa</label></td>	";
         else
            shtml += "		<td style=\"width:50px;text-align:center\"><label id=\"Xoa_"+(lastRow-1)+"\" style=\"cursor:pointer;font-style:italic;color:Blue\" onclick=\"XoaPhieuChi('"+SoPhieu+"')\"></label></td>	";        
        shtml += "		<td style=\"width:200px;text-align:center\"  id=\"txtSoPC_"+(lastRow-1)+"\"><a href=\""+link+"?idPhieuTH="+PhieuTHID+"&SoPhieu="+SoPhieu+"\"><input type=\"hidden\" id=\"hdSoPC_"+(lastRow-1)+"\" value=\""+SoPhieu+"\"/>"+SoPhieu+"</a></td>	";
        shtml +="       <td style=\"width:200px;text-align:center\"  id=\"txtNgayThu_"+(lastRow-1)+"\"><input type=\"hidden\" id=\"hdNgayChi_"+(lastRow-1)+"\" value=\""+NgayLap+"\"/>"+NgayLap+"</td>";      
        shtml += "		<td style=\"width:200px;text-align:center\"  id=\"txtMaDT_"+(lastRow-1)+"\"><input type=\"hidden\" id=\"hdMaNCC_"+(lastRow-1)+"\" value=\""+MaDT+"\"/>"+MaDT+"</td>	";
        shtml += "		<td style=\"width:200px;text-align:center\"  id=\"txtTenDT_"+(lastRow-1)+"\">"+TenDT+"</td>	";
        shtml += "		<td style=\"width:300px;text-align:left\"  id=\"txtDienGiai_"+(lastRow-1)+"\"> "+DienGiai+"</td>	"; 
        shtml += "		<td style=\"width:300px;text-align:left\"  id=\"txtLoaiTK_"+(lastRow-1)+"\"> "+LoaiTK+"</td>	"; 
        shtml += "      <td style=\"width:200px;text-align:center\"  id=\"txtTKCo_"+(lastRow-1)+"\"> "+TaiKhoan+"</td>	"; 
        shtml += "		<td style=\"width:300px;text-align:right\" id=\"txtTien_"+(lastRow-1)+"\">"+FormatSoTien(TongTien)+"</td>	";       
     shtml += "	</tr>";     
  $("#TableDanhSach:last").append(shtml);           
}
function XoaPhieuChi(SoPhieuChi)
{
     var rs = confirm("Bạn muốn xóa phiếu  "+SoPhieuChi +" này?");
     if(rs==true)
     {
        getFunctionXoaPhieuChi(SoPhieuChi);
        LoadDanhSachPhieuTongHop();
     }     
}
function getFunctionXoaPhieuChi(sophieu)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {  
                       alert("Xóa phiếu thành công!");
                      }
                      else
                        alert("Xóa phiếu thất bại!");                      
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=xoaphieuketoan&sophieu="+sophieu+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
 </script>
<form id="form1" runat="server">
<div width = "100%" align = "left" style="height:  34px;background-color:#007138"> <uc1:uscmenuKT_TongHopTH ID="uscmenuKT_TongHopTH1" runat="server" /></div>
<div>
    <table>
        <tr>
            <td>Từ ngày : </td>
            <td><input type="text" id="txtTuNgay" onclick="dp_cal.toggle()" /></td>
            <td>Đến ngày :</td>
            <td><input type="text" id="txtDenNgay" onclick="dp_cal2.toggle()" /></td>
            <td>Số phiếu :</td>
            <td><input type="text" id="txtSoPhieuTH" /></td>
            <td>Nhà cung cấp :</td>
            <td><input type="text" id="txtMaDT" onchange="TestMaNCC(this)" onfocus="ShowNhaCungCap('txtMaDT')" /><input type="hidden" id="txtMaDTa" /></td>
            <td><input type="button" id="bt_TimKiem"  onclick="LoadDanhSachPhieuTongHop()" value="Tìm kiếm" /></td>
        </tr>
    </table>
</div>
<div>

<table class="TableGidview" id="TableDanhSach">
         <tr>
              <td class ="tdHeader" colspan="10" >DANH SÁCH PHIẾU TỔNG HỢP</td>
         </tr>
		<tr class="HeaderGidView">
		    
		      <td style="width:50px">
                STT
		       
		     </td>
		     <td style="width:50px">
                		       
		     </td>
		     <td style="width:200px">
		       Số phiếu 
		       
		     </td>
		     <td style="width:200px">
		       Ngày lập
		       
		    </td>
		    <td style="width:200px">
		        Mã đối tượng
		    </td>
		     <td style="width:300px">
		        Tên đối tượng
		    </td>
		      <td style="width:300px">
		        Diễn giải
		      
		      </td>
		       <td style="width:100px">
		        Loại TK
		      </td>
		      <td style="width:100px">
		        Tài khoản
		      </td>
		      <td style="width:200px">
		         Tổng phát sinh
		         
		      </td>		    
		</tr>					 
					  
	</table> 
</div>
</form>
