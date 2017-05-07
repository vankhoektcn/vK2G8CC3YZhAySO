<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HDDV_DanhSachHoaDon.aspx.cs" Inherits="ketoan_HDDV_DanhSachHoaDon" %>

<!--#include file = "header.htm" -->

<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_HoadonDV.ascx" TagName="menu_ketoanhoadonDV" TagPrefix="uc1" %>

<link type="text/css" rel="stylesheet" href="../ketoan/css_KeToan/sheet_index.css" />
<link href="../ketoan/css_KeToan/epoch_styles.css" type="text/css" rel="stylesheet" />
<link href="../ketoan/css_KeToan/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/default.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/style.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/table.css" />
<script type="text/javascript" src="../ketoan/js_KeToan/libary.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/script.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jscript.js"></script>
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
    TTien=0;
    document.getElementById('TongThanhTien').value = 0;
}
function TestMaKH(obj)
{
    if(obj.value=="")
    {
        document.getElementById('txtMaKH').value = "";
    }
}
function ShowKhachHang(obj)
{
    var objsrc = document.getElementById(obj);
      
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachKhachHang&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:500,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    setChonKhachHang(data[2],data[3]);
                                                                    //document.getElementById(obj).blur();
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
      //alert(hd_IDBN.value);
}
 function LoadDanhSachHoaDon()
 {
    TTien=0;
    ResetTableDSPhieuThu();
    GetDanhSachHoaDon();
   
 }
 function GetDanhSachHoaDon()
 {
    ResetTableDSPhieuThu();
     var TuNgay  = document.getElementById('txtTuNgay').value;
     var DenNgay  = document.getElementById('txtDenNgay').value;
     var SoHD  = document.getElementById('txtSoHD').value;
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
                        ShowDanhSachPhieuThu(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7],Column[8],Column[9],Column[10],Column[11],Column[12]);
                        //hoa_donid,so_hd,convert(varchar,ngay_lap_hd,103)ngay_lap_hd, ma_kh,dien_giai,tk_no,tk_co,tk_thue,thue_suat,tien,tien_thue,tong_tien
                    }                    
                  }
                  else
                  {
                    alert("Không có danh sách hóa đơn!");
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=DanhSachHoaDon&TuNgay="+TuNgay+"&DenNgay="+DenNgay+"&MaKH="+MaKH+"&SoHD="+SoHD+"&times="+Math.random(),true);
        xmlHttp.send(null);
 }

 function ShowDanhSachPhieuThu(HD_id,SoHD,NgayLapHD,MaKH,DienGiai,TKNo,TKCo,TK_Thue,ThueSuat,Tien,TienThue,TongTien,loai_hd)
 {//hoa_donid,so_hd,convert(varchar,ngay_lap_hd,103)ngay_lap_hd, ma_kh,dien_giai,tk_no,tk_co,tk_thue,thue_suat,tien,tien_thue,tong_tien                
    var TableDanhSach = document.getElementById('TableDanhSach');
    var lastRow = TableDanhSach.rows.length; 
    var shtml = "<tr class=\"RowGidView\">";        
        shtml += "		<td style=\"width:50px;text-align:center\">"+(lastRow-1)+"</td>	";
        shtml += "		<td style=\"width:50px;text-align:center\"><label id=\"Xoa_"+(lastRow-1)+"\" style=\"cursor:pointer;font-style:italic;color:Blue\" onclick=\"XoaHoaDon('"+SoHD+"','"+NgayLapHD+"')\">Xóa</label></td>	";
        shtml += "		<td style=\"width:100px;text-align:center\"><a href=\"HDDV_XuatHoaDon.aspx?idHoaDon="+HD_id+"&SoHD="+SoHD+"&loai_hd="+loai_hd+"&MaKH="+MaKH+"\"><input type=\"hidden\" id=\"hdSoHD_"+(lastRow-1)+"\" value=\""+SoHD+"\"/>"+SoHD+"</a></td>	";
        shtml +="       <td style=\"width:100px;text-align:center\"><input type=\"hidden\" id=\"hdNgayLap_"+(lastRow-1)+"\" value=\""+NgayLapHD+"\"/>"+NgayLapHD+"</td>";      
        shtml += "		<td style=\"width:300px;text-align:center\"><input type=\"hidden\" id=\"hdMaKH_"+(lastRow-1)+"\" value=\""+MaKH+"\"/>"+MaKH+"</td>	";
        shtml += "		<td style=\"width:300px;text-align:left\"> "+DienGiai+"</td>	"; 
        shtml += "      <td style=\"width:100px;text-align:center\"> "+TKNo+"</td>	"; 
        shtml += "      <td style=\"width:100px;text-align:center\"> "+TKCo+"</td>	"; 
        shtml += "      <td style=\"width:100px;text-align:center\"> "+TK_Thue+"</td>	"; 
        shtml += "      <td style=\"width:100px;text-align:center\"> "+ThueSuat+"</td>	"; 
        shtml += "		<td style=\"width:200px;text-align:right\" >"+FormatSoTien(Tien)+"</td>	";  
        shtml += "      <td style=\"width:200px;text-align:center\"> "+FormatSoTien(TienThue)+"</td>	"; 
        shtml += "      <td style=\"width:100px;text-align:center\"><input id=\"ThanhTien_"+(lastRow-1)+ "\" style=\"width:100px;text-align:right\" readonly=\"readonly\" value=\""+FormatSoTien(TongTien)+"\" /> </td>	"; 
//        
  shtml += "	</tr>";
  $("#TableDanhSach:last").append(shtml);           
  CongTongTien(TongTien);
 }
 var TTien=0;
 function CongTongTien(ThanhTien)
 {
 
  // var TongTien = 0;
    var x;
   
    var count = TTien;
  
    TTien =  eval(count) + (eval(ThanhTien));           
    document.getElementById('TongThanhTien').value = FormatSoTien(TTien);
 }
 function XoaHoaDon(SoHD,NgayLapHD)
 {    
    kiemtrangaykhoaso(NgayLapHD,SoHD);
 }
 function kiemtrangaykhoaso(ngaylap_ct,SoHD)
{           
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {
            var value=xmlHttp.responseText;             
            if(value==1)
                alert('Không được xóa phiếu sau ngày khóa sổ!');
            else 
            {
                var rs = confirm("Bạn muốn xóa hóa đơn "+SoHD+" này?");
                if(rs==true)
                {
                    TestTrangThaiHoaDon(SoHD,ngaylap_ct);        
                }
            }             
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrangaykhoaso&ngaylap_ct="+ngaylap_ct+"&times="+Math.random(),true)    
    xmlHttp.send(null);      
}
 function TestTrangThaiHoaDon(SoHD,NgayLapHD)
{
      
      var xmlHttp = GetMSXmlHttp();

        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if(value=="1")
                {
                    alert('Hóa đơn này đã được xuất phiếu thu không thể xóa!');
                }
                else
                {
                    getFunctionXoaHoaDon(SoHD,NgayLapHD);
                }
                GetDanhSachHoaDon();
            }
        }
         
          xmlHttp.open("GET","ajax.aspx?do=TestTrangThaiHoaDon&SoHD="+SoHD+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function getFunctionXoaHoaDon(SoHD,NgayLapHD)
{
      
      var xmlHttp = GetMSXmlHttp();

        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if(value=="1")
                {
                    alert('Xóa hóa đơn thành công!');
                }
                else
                {
                    alert('Xóa hóa đơn thất bại!');
                }
                GetDanhSachHoaDon();
            }
        }
         
          xmlHttp.open("GET","ajax.aspx?do=XoaHoaDonDichVu&SoHD="+SoHD+"&NgayLapHD="+NgayLapHD+"&times="+Math.random(),true);
        xmlHttp.send(null);
}

</script>
<form id="form1" runat="server">ju
<div width = "100%" align = "left" style="height:  34px;background-color:#007138"> 
    <uc1:menu_ketoanhoadonDV ID="menu_ketoanhoadonDV1" runat="server" /></div>
<div>
    <table>
        <tr>
            <td>Từ ngày : </td>
            <td><input type="text" id="txtTuNgay" onclick="dp_cal.toggle()" /></td>
            <td>Đến ngày :</td>
            <td><input type="text" id="txtDenNgay" onclick="dp_cal2.toggle()" /></td>
            <td>Số hóa đơn :</td>
            <td><input type="text" id="txtSoHD" /></td>
            <td>Khách hàng :</td>
            <td><input type="text" id="txtTenKH" onchange="TestMaKH(this)" onfocus="ShowKhachHang('txtTenKH')" /><input type="hidden" id="txtMaKH" /></td>
            <td><input type="button" id="bt_TimKiem"  onclick="LoadDanhSachHoaDon()" value="Tìm kiếm" /></td>
        </tr>
    </table>
</div>
<div>

<table class="TableGidview" id="TableDanhSach">
         <tr>
              <td class ="tdHeader" colspan="13" >DANH SÁCH HÓA ĐƠN</td>
         </tr>
		<tr class="HeaderGidView">
		    
		     <td style="width:50px">
		       STT
		       
		     </td>
		      <td style="width:50px">
		       
		     </td>
		     <td style="width:100px">
		       Số hóa đơn
		       
		     </td>
		     <td style="width:100px">
		       Ngày lập
		       
		    </td>
		    <td style="width:300px">
		        Mã khách hàng
		    </td>
		     
		    
		      <td style="width:300px">
		        Diễn giải
		      </td>
		      <td style="width:100px">
		         TK nợ
		      </td>
		      <td style="width:100px">
		         TK có
		      </td>
		       <td style="width:100px">
		         TK Thuế
		      </td>
		      <td style="width:100px">
		         Thuế suất
		      </td>
		      <td style="width:200px">
		         Số tiền
		      </td>
		      <td style="width:200px">
		         Tiền thuế
		      </td>
		      <td style="width:100px">
		         Thành tiền
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
	<div style="text-align:right">Tổng tiền:<input id="TongThanhTien" readonly="readonly" style="width:100px;text-align:right" /></div> 
</div>
</form>
