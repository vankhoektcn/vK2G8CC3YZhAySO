<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTM_DanhSachPhieuTTTamUng.aspx.cs" Inherits="ketoan_KTTM_DanhSachPhieuThanhToanTamUng" %>

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
    

<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_TienMat.ascx" TagName="menu_ketoantienmat" TagPrefix="uc1" %>
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
      
      var txtMaNCC=document.getElementById('txtMaNCC');
      var txtTenNCC=document.getElementById('txtTenNCC');
     
      txtMaNCC.value=MaNCC;
      txtTenNCC.value = TenNCC;
      
      //alert(hd_IDBN.value);
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
                       //phieu_chi_id(0),so_phieu_chi(1),ngay_chi(2),ma_ncc(3),tennnc(4),dien_giai(5),tk_co(6),tien(7)
                        ShowDanhSachPhieuChi(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7]);                        
                    }                    
                  }
                  else
                  {
                    alert("Không có danh sách phiếu thanh toán tạm ứng!");
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=DanhSachPhieu_TT_Tam_Ung&TuNgay="+TuNgay+"&DenNgay="+DenNgay+"&MaNCC="+MaNCC+"&SoPhieuChi="+SoPhieuChi+"&times="+Math.random(),true);
        xmlHttp.send(null);
 }
 function ShowDanhSachPhieuChi(PhieuChiID,SoPhieuChi,NgayChi,MaNCC,TenNCC,DienGiai,TKNo,Tien)
 {//phieu_chi_id(0),so_phieu_chi(1),ngay_chi(2),ma_ncc(3),tennnc(4),dien_giai(5),tk_co(6),tien(7)                 
    var TableDanhSach = document.getElementById('TableDanhSach');
    var lastRow = TableDanhSach.rows.length; 
    var shtml = "<tr class=\"RowGidView\">";
         shtml += "		<td style=\"width:50px;text-align:center\">"+(lastRow-1)+"</td>	";
         if('<%=StaticData.HavePermision(this.Page, "KeToanTM_KTTM_DanhSachPhieuThanhTTUng_Xoa")%>' != 'False')
            shtml += "		<td style=\"width:50px;text-align:center\"><label id=\"Xoa_"+(lastRow-1)+"\" style=\"cursor:pointer;font-style:italic;color:Blue\" onclick=\"XoaPhieuChi('"+SoPhieuChi+"','"+NgayChi+"')\">Xóa</label></td>	";
         else   
            shtml += "		<td style=\"width:50px;text-align:center\"><label id=\"Xoa_"+(lastRow-1)+"\" style=\"cursor:pointer;font-style:italic;color:Blue\" onclick=\"XoaPhieuChi('"+SoPhieuChi+"','"+NgayChi+"')\"></label></td>	";
        shtml += "		<td style=\"width:200px;text-align:center\"  id=\"txtSoPC_"+(lastRow-1)+"\"><a href=\"KTTM_PhieuThanhToanTamUng.aspx?idPhieuChi="+PhieuChiID+"&SoPC="+SoPhieuChi+"\"><input type=\"hidden\" id=\"hdSoPC_"+(lastRow-1)+"\" value=\""+SoPhieuChi+"\"/>"+SoPhieuChi+"</a></td>	";
        shtml +="       <td style=\"width:200px;text-align:center\"  id=\"txtNgayThu_"+(lastRow-1)+"\"><input type=\"hidden\" id=\"hdNgayChi_"+(lastRow-1)+"\" value=\""+NgayChi+"\"/>"+NgayChi+"</td>";
      
        shtml += "		<td style=\"width:200px;text-align:center\"  id=\"txtMaNCC_"+(lastRow-1)+"\"><input type=\"hidden\" id=\"hdMaNCC_"+(lastRow-1)+"\" value=\""+MaNCC+"\"/>"+MaNCC+"</td>	";
        shtml += "		<td style=\"width:200px;text-align:center\"  id=\"txtMaNCC_"+(lastRow-1)+"\">"+TenNCC+"</td>	";
        shtml += "		<td style=\"width:300px;text-align:left\"  id=\"txtDienGiai_"+(lastRow-1)+"\"> "+DienGiai+"</td>	"; 
        shtml += "      <td style=\"width:200px;text-align:center\"  id=\"txtTKNo_"+(lastRow-1)+"\"> "+TKNo+"</td>	"; 
        shtml += "		<td style=\"width:300px;text-align:right\" id=\"txtTien_"+(lastRow-1)+"\">"+FormatSoTien(Tien)+"</td>	";  
//        
     shtml += "	</tr>";
  $("#TableDanhSach:last").append(shtml);           
 }
function XoaPhieuChi(SoPhieuChi,NgayChi)
{
     kiemtrangaykhoaso(NgayChi,SoPhieuChi);     
}
 function kiemtrangaykhoaso(ngaylap_ct,SoPhieuChi)
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
              var rs = confirm("Bạn muốn xóa phiếu chi "+SoPhieuChi +" này?");
              if(rs==true)
                {
                 getFunctionXoaPhieuChi(SoPhieuChi);
                 LoadDanhSachPhieuChi();
                }     
            }             
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrangaykhoaso&ngaylap_ct="+ngaylap_ct+"&times="+Math.random(),true)    
    xmlHttp.send(null);      
}
function getFunctionXoaPhieuChi(SoPhieuChi)
{   
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {  
                       alert("Xóa phiếu TT tạm ứng thành công!");
                      }
                      else
                        alert("Xóa phiếu TT tạm ứng thất bại!");                      
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=XoaPhieu_TT_Tam_Ung&SoPhieuChi="+SoPhieuChi+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
 </script>
<form id="form1" runat="server">
<div width = "100%" align = "left" style="height:  34px;background-color:#007138"> <uc1:menu_ketoantienmat ID="menu_ketoantienmat1" runat="server" /></div>
<div>
    <table>
        <tr>
            <td>Từ ngày : </td>
            <td><input type="text" id="txtTuNgay" onclick="dp_cal.toggle()" /></td>
            <td>Đến ngày :</td>
            <td><input type="text" id="txtDenNgay" onclick="dp_cal2.toggle()" /></td>
            <td>Số phiếu :</td>
            <td><input type="text" id="txtSoPhieuChi" /></td>
            <td>Nhà cung cấp :</td>
            <td><input type="text" id="txtTenNCC" onchange="TestMaNCC(this)" onfocus="ShowNhaCungCap('txtTenNCC')" /><input type="hidden" id="txtMaNCC" /></td>
            <td><input type="button" id="bt_TimKiem"  onclick="LoadDanhSachPhieuChi()" value="Tìm kiếm" /></td>
        </tr>
    </table>
</div>
<div>

<table class="TableGidview" id="TableDanhSach">
         <tr>
              <td class ="tdHeader" colspan="10" >DANH SÁCH PHIẾU THANH TOÁN TẠM ỨNG</td>
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
		        Mã nhân viên
		    </td>
		     <td style="width:300px">
		        Tên nhân viên
		    </td>
		      <td style="width:300px">
		        Diễn giải
		      
		      </td>
		      <td style="width:100px">
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
