<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTM_DanhSachCongNo.aspx.cs" Inherits="ketoan_KTTM_DanhSachCongNo" %>
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
      
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachNhaCungCap&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:300,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(       
                                                                function(event,data)
                                                                {                                                                        
                                                                    setChonNCC(data[2],data[3],data[4]);
                                                                    //document.getElementById(obj).blur();
                                                                }
                                                            );     
}
function setChonNCC(idNCC,MaNCC,TenNCC)
{           
      var txtTenNCC=document.getElementById('txtTenNCC');         
      txtTenNCC.value = TenNCC;            
      document.getElementById('txtTenNCC').focus();
}
function TestMaNCC(obj)
{
    if(obj.value=="")
    {
        document.getElementById('txtMaNCC').value = "";
    }
}
 function LoadDanhSachPhieuChi()
 { 
    ResetTableDSPhieuChi();
     var TuNgay  = document.getElementById('txtTuNgay').value;
     var DenNgay  = document.getElementById('txtDenNgay').value;
     var SoPhieuChi  = document.getElementById('txtSoPhieuChi').value;
     var MaNCC = document.getElementById('txtMaNCC').value;     
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
                        ShowDanhSachPhieuChi(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7],Column[8],Column[9],Column[10],Column[11]);                        
                    }                    
                  }
                  else
                  {
                    alert("Không có danh sách phiếu chi!");
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=DanhSachHoaDonDauVao&TuNgay="+TuNgay+"&DenNgay="+DenNgay+"&MaNCC="+MaNCC+"&SoPhieuChi="+SoPhieuChi+"&times="+Math.random(),true);
        xmlHttp.send(null);
 }
 function ShowDanhSachPhieuChi(MaNCC,TenNCC,TK,MaPN,NgayNhap,DienGiai,SoHD,NgayLapHD,HanTT,TienTT,TienDaTT,TienChuaTT)
 {   
    var TableDanhSach = document.getElementById('TableDanhSach');
    var lastRow = TableDanhSach.rows.length; 
    var shtml = "<tr class=\"RowGidView\">";
        shtml += "		<td style=\"width:50px;text-align:center\">"+(lastRow-1)+"</td>	";
        shtml += "		<td style=\"width:20px;text-align:center\"  id=\"chk_"+(lastRow-1)+"\"><input type=\"checkbox\" id=\"checkbox_"+(lastRow-1)+"\"><input type=\"hidden\" id=\"mancc_"+(lastRow-1)+"\" value=\""+MaNCC+"\" \></td>"
        shtml += "		<td style=\"width:300px;text-align:center\"  id=\"txtTenNCC_"+(lastRow-1)+"\">"+TenNCC+"</td>";        
        shtml += "		<td style=\"width:80px;text-align:center\"  id=\"txtTK_"+(lastRow-1)+"\">"+TK+"</td>";
        shtml += "		<td style=\"width:100px;text-align:center\"  id=\"txtMaPN_"+(lastRow-1)+"\"><input type=\"hidden\" id=\"mapn_"+(lastRow-1)+"\" value=\""+MaPN+"\"\>"+MaPN+"</td>	";
        shtml += "		<td style=\"width:100px;text-align:center\"  id=\"txtNgayNhap_"+(lastRow-1)+"\"><input type=\"hidden\" id=\"ngaynhap_"+(lastRow-1)+"\" value=\""+NgayNhap+"\"\>"+NgayNhap+"</td>	";
        shtml += "		<td style=\"width:300px;text-align:left\"  id=\"txtDienGiai_"+(lastRow-1)+"\"> "+DienGiai+"</td>	"; 
        shtml += "      <td style=\"width:100px;text-align:center\"  id=\"txtSoHD_"+(lastRow-1)+"\"> "+SoHD+"</td>	"; 
        shtml += "		<td style=\"width:100px;text-align:center\"  id=\"txtNgayLapHD_"+(lastRow-1)+"\">"+NgayLapHD+"</td>	";
        shtml += "		<td style=\"width:100px;text-align:center\"  id=\"txtHanTT_"+(lastRow-1)+"\">"+HanTT+"</td>	";
        shtml += "		<td style=\"width:120px;text-align:center\"  id=\"txtTienTT_"+(lastRow-1)+"\">"+FormatSoTien(TienTT)+"</td>	";
        shtml += "		<td style=\"width:120px;text-align:center\"  id=\"txtTienDaTT_"+(lastRow-1)+"\">"+FormatSoTien(TienDaTT)+"</td>	";
        shtml += "		<td style=\"width:120px;text-align:right\" id=\"txtTienChuaTT_"+(lastRow-1)+"\">"+FormatSoTien(TienChuaTT)+"</td>	";       
     shtml += "	</tr>";     
  $("#TableDanhSach:last").append(shtml);    
}
function danhsachcongnochon()
{
    var tableds=document.getElementById('TableDanhSach');
    var row=tableds.rows.length;    
    var valueSoPN="";
    var flag=false;
    if(row>2)
    {
        while(row>2)
        {
            var idcheckbox="checkbox_"+(row-2);            
            var vlcheckbox=document.getElementById(idcheckbox);
            if(vlcheckbox.checked==true)
            {                
                flag=true;
                var idSoPN="mapn_"+(row-2);
                valueSoPN+=";"+document.getElementById(idSoPN).value;                
            }
            row--;
        }        
        if(flag)
            window.open("KTNH_UyNhiemChi.aspx?mapn="+valueSoPN);
        else
            alert('Bạn chưa chọn hóa đơn nào');
    }
}
function thanhtoan()
  {  
    //var httt=document.getElementById('ddlhinhthucthanhtoan').value;   
    danhsachcongnochon();
  }         
 </script>
<form id="form1" runat="server">
<div width = "100%" align = "left" style="height:  34px;background-color:#007138"> <uc1:menu_ketoantienmat ID="menu_ketoantienmat1" runat="server" /></div>
<div>
    <table>
        <tr>
            <td>Từ ngày : </td>
            <td><input type="text" id="txtTuNgay" onclick="dp_cal.toggle()" style="width:100px;" /></td>
            <td>Đến ngày :</td>
            <td><input type="text" id="txtDenNgay" onclick="dp_cal2.toggle()" style="width:100px;" /></td>
            <td>Số hóa đơn :</td>
            <td><input type="text" id="txtSoPhieuChi" style="width:70px;" /></td>
            <td>Nhà cung cấp :</td>
            <td><input type="text" id="txtTenNCC" onchange="TestMaNCC(this)" onfocus="ShowNhaCungCap('txtTenNCC')" /><input type="hidden" id="txtMaNCC" /></td>
            <td><input type="button" id="bt_TimKiem"  onclick="LoadDanhSachPhieuChi()" value="Tìm kiếm" /></td>
            <td>
                <asp:dropdownlist id="ddlhinhthucthanhtoan" runat="server">
                    <asp:ListItem Value="0">--Hình thức thanh toán--</asp:ListItem>
                    <asp:ListItem Value="1">Tiền mặt</asp:ListItem>
                    <asp:ListItem Value="2">Tiền gởi ngân hàng</asp:ListItem>
                </asp:dropdownlist>
            </td>
            <td><input type ="button" id="btnthanhtoan" onclick="thanhtoan()" value ="Thanh toán" /></td>
        </tr>
    </table>
</div>
<div>

<table class="TableGidview" id="TableDanhSach">
         <tr>
              <td class ="tdHeader" colspan="14" >DANH SÁCH CÔNG NỢ</td>
         </tr>
		<tr class="HeaderGidView">
		    
		      <td style="width:50px">
                STT		       
		     </td>
		     <td style="width:50px">                		       
		     </td>			       
		     <td style="width:300px">
		       Tên NCC	       
		    </td>
		     <td style="width:80px">
		       Tài khoản       
		    </td>
		    <td style="width:100px">
		        Mã PN
		    </td>
		     <td style="width:100px">
		       Ngày nhập
		    </td>
		      <td style="width:200px">
		        Diễn giải		      
		      </td>
		      <td style="width:100px">
		       Số HĐ
		      </td>
		      <td style="width:100px">
		         Ngày lập HĐ		         
		      </td>
		      <td style="width:100px">
		         Hạn TT		         
		      </td>
		      <td style="width:120px">
		        Tiền TT		         
		      </td>
		      <td style="width:120px">
		        Tiền đã TT		         
		      </td>
		      <td style="width:120px">
		        Tiền chưa TT		         
		      </td>		    
		</tr>					 
					  
	</table> 
</div>
</form>
