<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTH_SoNhatKiChung.aspx.cs" Inherits="ketoan_KTTH_SoNhatKiChung" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_TongHop.ascx" TagName="uscmenuKT_TongHopNKC" TagPrefix="uc1" %>
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
<script type="text/javascript" src="../ketoan/js_KeToan/scriptoflong.js"></script>
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
 var dp_cal,dp_cal2;
// window.window.onload = function () 
//{  
////   document.getElementById('txtTuNgay').value=ngayhienhanh();
////   document.getElementById('txtDenNgay').value=ngayhienhanh();
//}
 function FormatSoTien(obj)
{
	    return formatCurrency(obj);
}
function ResetTableSoNhatKyChung()
{
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var lastRow = Row;
    while(lastRow>2)
    {
        TableDanhSach.deleteRow(lastRow-1);
        lastRow--;
    }
    //alert('troi oi da reset lai loi ben duoi roi  ne ong truc oi '); 
}
function LoadSoNhatKyChung()
{       
    ResetTableSoNhatKyChung();
    var tungay=document.getElementById('txtTuNgay').value;
    var denngay=document.getElementById('txtDenNgay').value;
    
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {
            value=xmlHttp.responseText;           
            if (value!=null)
            {               
                var row=value.split('|');                                              
                for(i=1;i<row.length;i++)
                {                                            
                    var column=row[i].split('$');                                       
                    showsonhatkychung(column[0],column[1],column[2],column[3],column[4],column[5],column[6],column[7]);
                }
             }
             else
                alert('Không có chứng từ nào phát sinh trong thời gian bạn chọn!');                         
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=loadSoNhatKyChung&tungay="+tungay+"&denngay="+denngay+"&times="+Math.random(),true);
    xmlHttp.send("null");
}
function showsonhatkychung(ma_ct,ngay_lap_ct,ma_kh,ten_kh,dien_giai,tai_khoan,ps_no,ps_co)
 {   
    var TableDanhSach = document.getElementById('TableDanhSach');
    var lastRow = TableDanhSach.rows.length; 
    var shtml = "<tr class=\"RowGidView\">";
         shtml += "		<td style=\"width:50px;text-align:center\">"+(lastRow-1)+"</td>	";
        shtml += "		<td style=\"width:100px;text-align:center\"   id=\"txtma_ct_"+(lastRow-1)+"\">"+ma_ct+"</td>";
        shtml += "		<td style=\"width:150px;text-align:center\"  id=\"txtngaylapct_"+(lastRow-1)+"\">"+ngay_lap_ct+"</td>	";
        shtml +="       <td style=\"width:150px;text-align:center\"  id=\"txtmakh_"+(lastRow-1)+"\">"+ma_kh+"</td>";      
        shtml += "		<td style=\"width:300px;text-align:center\"  id=\"txttenkh_"+(lastRow-1)+"\">"+ten_kh+"</td>	";
        shtml += "		<td style=\"width:400px;text-align:center\"  id=\"txtdiengiai_"+(lastRow-1)+"\">"+dien_giai+"</td>	";
        shtml += "		<td style=\"width:100px;text-align:center\"  id=\"txttaikhoan_"+(lastRow-1)+"\"> "+tai_khoan+"</td>	"; 
        shtml += "      <td style=\"width:200px;text-align:right\"  id=\"txtpsno_"+(lastRow-1)+"\"> "+FormatSoTien(ps_no)+"</td>	";             
        shtml += "      <td style=\"width:200px;text-align:right\" id=\"txtpsco_"+(lastRow-1)+"\">"+FormatSoTien(ps_co)+"</td>";  
     shtml += "	</tr>";
  $("#TableDanhSach:last").append(shtml);          
 } 
 function dinhdangtungay()
 {       
    dinhdangngay(document.getElementById('txtTuNgay'));// con thieu ham dinhdangngay(document.getElementById('txtTuNgay'));
 }
 function dinhdangdenngay()
 {
    dinhdangngay(document.getElementById('txtDenNgay'));//dinhdangngay(document.getElementById('txtTuNgay'));
 }
 function insonhatkichung()
 {  
    var tungay=document.getElementById('txtTuNgay').value;
    var denngay=document.getElementById('txtDenNgay').value;    
    window.open("KTTH_rptInSoNhatKyChung.aspx?tungay="+tungay+"&denngay="+denngay);
 }
 </script>
 
<form id="form1" runat="server">
<div>
    <table>
    <tr>
        <td width = "100%" align = "left" class="bg_menu" colspan="6">
            <uc1:uscmenuKT_TongHopNKC ID="uscmenuKT_TongHopNKC1" runat="server" />
        </td>
    </tr>
        <tr>
            <td>Từ ngày : </td>
            <td><input type="text" id="txtTuNgay" onclick="dp_cal.toggle()" /></td>
            <td> Đến ngày :  </td>
            <td><input type="text" id="txtDenNgay" onclick="dp_cal2.toggle()" /></td>           
            <td><input type="button" id="bt_TimKiem" onclick="LoadSoNhatKyChung()" value="Tìm kiếm" /></td>
        <td><input style ="width:70px;" type="button" id="bt_in" onclick="insonhatkichung()" value="In" /> </td>
        </tr>
    </table>
</div>
<div>

<table class="TableGidview" id="TableDanhSach">
         <tr>
              <td class ="tdHeader" colspan="10" >Sổ Nhật Ký Chung</td>
         </tr>
		<tr class="HeaderGidView">
		    
		      <td style="width:50px">
                STT		       
		     </td>		     
		     <td style="width:100px">
		       Số phiếu
		       
		     </td>
		     <td style="width:150px">
		       Ngày lập
		       
		    </td>
		    <td style="width:150px">
		        Mã khách hàng
		    </td>
		     <td style="width:300px">
		        Tên khách hàng
		    </td>
		      <td style="width:400px">
		        Diễn giải
		      
		      </td>
		      <td style="width:100px">
		        Tài khoản 
		      </td>
		      
		      <td style="width:200px">
		         PS Nợ		         
		      </td>
		      
		      <td style="width:200px">
		         PS Có		         
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
