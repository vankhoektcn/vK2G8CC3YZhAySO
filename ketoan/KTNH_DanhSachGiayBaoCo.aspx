<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTNH_DanhSachGiayBaoCo.aspx.cs" Inherits="KTNH_DanhSachGiayBaoCo" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_NganHang.ascx" TagName="menu_ketoannganhang" TagPrefix="uc1" %>

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
function ResetTableDSGiayBaoCo()
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
      //var txtTenKH=document.getElementById('txtTenKH');
      txtMaKH.value=MaKH;
      //txtTenKH.value = TenKH;
      
    document.getElementById('txtTenKH').focus();
}
function TestMaNCC(obj)
{
    if(obj.value=="")
    {
        document.getElementById('txtMaNCC').value = "";
    }
}
 function LoadDanhSachGiayBaoCo()
 {    
    ResetTableDSGiayBaoCo();
     var TuNgay  = document.getElementById('txtTuNgay').value;
     var DenNgay  = document.getElementById('txtDenNgay').value;
     var SoPhieu  = document.getElementById('txtSoPhieu').value;
     var MaKH = document.getElementById('txtMaKH').value;
     var tknh=document.getElementById('drl_tknh').value;         
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
                       //unc_id(0),so_unc(1),ngay_lap(2),ma_ncc(3),ncc.TenNhaCungCap(4),Dien_Giai(5),TK_Co(6),SoTaiKhoanNCC(7),TenNganHangNCC(8),Tien(9)
                        ShowDanhSachGiayBaoCo(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7],Column[8],Column[9]);                        
                    }                    
                  }
                  else
                  {
                    alert("Không có danh sách giấy báo có!");
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=LoadDanhSachGiayBaoCo&TuNgay="+TuNgay+"&DenNgay="+DenNgay+"&MaKH="+MaKH+"&SoPhieu="+SoPhieu+"&tknh="+tknh+"&times="+Math.random(),true);
        xmlHttp.send(null);
 }
 function ShowDanhSachGiayBaoCo(UNT_ID,SoUNT,NgayLap,MaKH,TenKH,DienGiai,TKCo,TKNganHang,TenNganHang,Tien)
 {//phieu_chi_id(0),so_phieu_chi(1),ngay_chi(2),ma_ncc(3),tennnc(4),dien_giai(5),tk_co(6),tien(7)              
   var link = "KTNH_UyNhiemThu.aspx";
   var TableDanhSach = document.getElementById('TableDanhSach');
    var lastRow = TableDanhSach.rows.length; 
    var shtml = "<tr class=\"RowGidView\">";
        shtml += "		<td style=\"width:50px;text-align:center\">"+(lastRow-1)+"</td>	";
        if("<%=StaticData.HavePermision(this.Page, "KeToanNH_DanhMucTKNH_Xoa") %>" == "False")
            shtml += "		<td style=\"width:50px;text-align:center\"><label id=\"Xoa_"+(lastRow-1)+"\" style=\"cursor:pointer;font-style:italic;color:Blue\" onclick=\"getFunctionXoaGiayBaoCo('"+SoUNT+"','"+NgayLap+"')\"></label></td>	";        
        else
            shtml += "		<td style=\"width:50px;text-align:center\"><label id=\"Xoa_"+(lastRow-1)+"\" style=\"cursor:pointer;font-style:italic;color:Blue\" onclick=\"getFunctionXoaGiayBaoCo('"+SoUNT+"','"+NgayLap+"')\">Xóa</label></td>	";        
        shtml += "		<td style=\"width:200px;text-align:center\"  id=\"txtSoUNT_"+(lastRow-1)+"\"><a href=\""+link+"?idUNT="+UNT_ID+"&SoUNT="+SoUNT+"&MaKH="+MaKH+"\"><input type=\"hidden\" id=\"hdSoUNT_"+(lastRow-1)+"\" value=\""+SoUNT+"\"/>"+SoUNT+"</a></td>	";
        shtml +="       <td style=\"width:200px;text-align:center\"  id=\"txtNgayLap_"+(lastRow-1)+"\"><input type=\"hidden\" id=\"hdNgayLap_"+(lastRow-1)+"\" value=\""+NgayLap+"\"/>"+NgayLap+"</td>";      
        shtml += "		<td style=\"width:200px;text-align:center\"  id=\"txtMaKH_"+(lastRow-1)+"\"><input type=\"hidden\" id=\"hdMaKH_"+(lastRow-1)+"\" value=\""+MaKH+"\"/>"+MaKH+"</td>	";
        shtml += "		<td style=\"width:200px;text-align:center\"  id=\"txtTenKH_"+(lastRow-1)+"\">"+TenKH+"</td>	";
        shtml += "		<td style=\"width:300px;text-align:left\"  id=\"txtDienGiai_"+(lastRow-1)+"\"> "+DienGiai+"</td>	"; 
        shtml += "      <td style=\"width:200px;text-align:center\"  id=\"txtTKCo_"+(lastRow-1)+"\"> "+TKCo+"</td>	"; 
        shtml += "      <td style=\"width:200px;text-align:center\"  id=\"txtTKNganHang_"+(lastRow-1)+"\"> "+TKNganHang+"</td>	"; 
        shtml += "     <td style=\"width:300px;text-align:center\"  id=\"txtTenNganHang_"+(lastRow-1)+"\"> "+TenNganHang+"</td>	";         
        shtml += "		<td style=\"width:300px;text-align:right\" id=\"txtTien_"+(lastRow-1)+"\">"+FormatSoTien(Tien)+"</td>	";  
//        
     shtml += "	</tr>";
  $("#TableDanhSach:last").append(shtml);           
 }
 function XoaUyNhiemChi(SoUNT,NgayLapUNT)
 {       
    kiemtrangaykhoaso(NgayLapUNT,SoUNT);    
 }
 function kiemtrangaykhoaso(ngaylap_ct,soUNT)
{              
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {
            var value = xmlHttp.responseText;                   
            if(value==1)
                alert('Không được xóa phiếu sau ngày khóa sổ!');
            else 
            {                              
              var rs = confirm("Bạn muốn xóa giấy báo có  "+soUNT+" này?");                                    
              if(rs==true)              
              {               
                getFunctionXoaGiayBaoCo(soUNT,ngaylap_ct);
              }
            }             
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrangaykhoaso&ngaylap_ct="+ngaylap_ct+"&times="+Math.random(),true)    
    xmlHttp.send(null);      
}
function getFunctionXoaGiayBaoCo(SoUNT,NgayLapUNT)
{   
   xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if(value="1")
                    alert("Xóa giấy báo có thành công!");
                else
                    alert("Xóa giấy báo có thất bại!");
                 LoadDanhSachGiayBaoCo();
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=XoaUyNhiemThu&SoUNT="+SoUNT+"&ngay_lap_unt="+NgayLapUNT+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
 </script>
<form id="form1" runat="server">
<div width = "100%" align = "left" style="height:  34px;background-color:#007138"> 
<uc1:menu_ketoannganhang ID="menu_ketoannganhang" runat="server" /></div>
<div>
    <table>
        <tr>
            <td>Từ ngày : </td>
            <td><input type="text" id="txtTuNgay" onclick="dp_cal.toggle()" /></td>
            <td>Đến ngày :</td>
            <td><input type="text" id="txtDenNgay" onclick="dp_cal2.toggle()" /></td>
            <td>Số phiếu :</td>
            <td><input type="text" id="txtSoPhieu" /></td>
            <td>Khách hàng :</td>
            <td><input type="text" id="txtMaKH" runat="Server" onfocus="ShowKhachHang('txtMaKH')" /></td>
            <td><asp:dropdownlist id="drl_tknh" runat="server"> </asp:dropdownlist> </td>
            <td><input type="button" id="bt_TimKiem"  onclick="LoadDanhSachGiayBaoCo()" value="Tìm kiếm" /></td>
        </tr>
    </table>
</div>
<div>

<table class="TableGidview" id="TableDanhSach">
         <tr>
              <td class ="tdHeader" colspan="11" >DANH SÁCH GIẤY BÁO CÓ</td>
         </tr>
		<tr class="HeaderGidView">
		    
		    <td style="width:50px">
		       STT		       
		     </td>
		     
		     <td style="width:50px"></td>
		     <td style="width:200px">
		       Số phiếu
		       
		     </td>
		     <td style="width:200px">
		       Ngày lập
		       
		    </td>
		    <td style="width:200px">
		        Mã khách
		    </td>
		     <td style="width:300px">
		        Tên khách
		    </td>
		      <td style="width:300px">
		        Diễn giải		      
		      </td>
		      <td style="width:100px">
		        TK đối ứng
		      </td>
		       <td style="width:200px">
		        TK ngân hàng
		      </td>
		       <td style="width:300px">
		        Tên ngân hàng
		      </td>
		      <td style="width:200px">
		         Tổng tiền		         
		      </td>		        
		</tr>					 
					  
	</table> 
</div>
</form>
