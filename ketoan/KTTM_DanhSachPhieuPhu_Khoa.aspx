<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTM_DanhSachPhieuPhu_Khoa.aspx.cs" Inherits="KTTM_DanhSachPhieuPhu_Khoa" %>

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
 var dp_cal;
 window.window.onload = function () 
{
     dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtngaythu'));	
//	 dp_cal2 = new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
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
      txtMaNCC.value=MaNCC;      
      document.getElementById('txtMaNCC').focus();
}
function TestMaNCC(obj)
{
    if(obj.value=="")
    {
        document.getElementById('txtMaNCC').value = "";
    }
}
 function LoadDanhSachPhieuThu()
 {
     ResetTableDSPhieuChi();
     var ngaythu  = document.getElementById('txtngaythu').value;    
     var sophieuthu  = document.getElementById('txtsophieuthu').value;
     //var mabn = document.getElementById('txtMaBN').value;
     var nguoidung=document.getElementById('drl_nguoidung').value;
     var isthu=document.getElementById('chktt').checked;     
     if(isthu)
        isthu=1;
     else
        isthu=0;    
     xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;               
                  if (value!="")
                  {  
                    //alert(value);
                    var strresult=value.split('$');    
                    var tongtien=strresult[1];     
                    document.getElementById('txttongtien').value=FormatSoTien(tongtien);                                       
                    var Row = strresult[0].split('|');
                    for(i=1;i<Row.length;i++)
                    {
                        var Column = Row[i].split('&');                       
                       //phieu_chi_id(0),so_phieu_chi(1),ngay_chi(2),ma_ncc(3),tennnc(4),dien_giai(5),tk_co(6),tien(7)
                        ShowDanhSachPhieuChi(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6]);                        
                    }                    
                  }
                  else
                  {
                    alert("Không có phiếu thu nào!");
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=DanhSachPhieuThu_Khoa&ngaythu="+ngaythu+"&sophieuthu="+sophieuthu+"&nguoidung="+encodeURIComponent(nguoidung)+"&isthu="+isthu+"&times="+Math.random(),true);
        xmlHttp.send(null);
 }
 function ShowDanhSachPhieuChi(maphieu,ngaylap,mabenhnhan,tenbenhnhan,noidungthu,khoa,tongtien)
 {
//    var link = "";
//    var typePhieuChi = SoPhieuChi.substring(0,4);
//    if(typePhieuChi=="PCHD")
//       link = "KTTM_PhieuChiHoaDon.aspx";
//    else
//       link = "KTTM_PhieuChiKhac.aspx";
    var TableDanhSach = document.getElementById('TableDanhSach');
    var lastRow = TableDanhSach.rows.length; 
    var shtml = "<tr class=\"RowGidView\">";
        shtml += "		<td style=\"width:50px;text-align:center\">"+(lastRow-1)+"</td>	";        
        shtml += "		<td style=\"width:150px;text-align:center\"  id=\"txtsophieuthu_"+(lastRow-1)+"\">"+maphieu+"</td>	";
        shtml +="       <td style=\"width:200px;text-align:center\"  id=\"txtngaythu_"+(lastRow-1)+"\">"+ngaylap+"</td>";      
        shtml += "		<td style=\"width:200px;text-align:center\"  id=\"txtmabn_"+(lastRow-1)+"\">"+mabenhnhan+"</td>	";
        shtml += "		<td style=\"width:250px;text-align:center\"  id=\"txttenbn_"+(lastRow-1)+"\">"+tenbenhnhan+"</td>	";        
        shtml += "      <td style=\"width:200px;text-align:center\"  id=\"txtnoidungthu_"+(lastRow-1)+"\"> "+noidungthu+"</td>	"; 
        shtml += "      <td style=\"width:200px;text-align:center\"  id=\"txtnguoithu"+(lastRow-1)+"\"> "+khoa+"</td>	"; 
        shtml += "		<td style=\"width:150px;text-align:right\" id=\"txtTien_"+(lastRow-1)+"\">"+FormatSoTien(tongtien)+"</td>	";  
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
                       alert("Xóa phiếu chi thành công!");
                      }
                      else
                        alert("Xóa phiếu chi thất bại!");                      
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=XoaPhieuChi&SoPhieuChi="+SoPhieuChi+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function lapphieuthu()
{
     var ngaythu  = document.getElementById('txtngaythu').value;    
     var sophieuthu  = document.getElementById('txtsophieuthu').value;
     //var mabn = document.getElementById('txtMaBN').value;
     var nguoidung=document.getElementById('drl_nguoidung').value;
     xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="")
                      {  
                        doanhthukhoa(value);
                      }
                      else
                        alert("không có phiếu thu hoặc phiếu này đã thu rồi!");                      
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=doanhthukhoa&ngaythu="+ngaythu+"&sophieuthu="+sophieuthu+"&nguoidung="+encodeURIComponent(nguoidung)+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function doanhthukhoa(value)
  {      
    var ngaythu=document.getElementById('txtngaythu').value;
    var tongtien=document.getElementById('txttongtien').value;
    var nguoidung=document.getElementById('drl_nguoidung').value;
    var diengiai='Doanh thu của '+nguoidung+' ngày '+ ngaythu;    
    window.open("KTTM_ThuKhac.aspx?tongtien="+tongtien+"&diengiai="+diengiai+"&doanhthu="+value+"&ngaythu="+ngaythu+"&nguoidung="+nguoidung);
  } 
function inbangke()
{
    var ngaythu=document.getElementById('txtngaythu').value;
    var nguoithu=document.getElementById('drl_nguoidung').value;   
    window.open("KTTM_rptBangKePhieuThu_nguoidung.aspx?ngaythu="+ngaythu+"&nguoithu="+nguoithu);
}         
 </script>
<form id="form1" runat="server">
<div width = "100%" align = "left" style="height:  34px;background-color:#007138"> <uc1:menu_ketoantienmat ID="menu_ketoantienmat1" runat="server" /></div>
<div>
    <table>
        <tr>           
            <td>Ngày thu :</td>
            <td><input type="text" id="txtngaythu" style="width:100px" runat="server" onclick="dp_cal.toggle()" /></td>
            <td>Số phiếu thu :</td>
            <td><input type="text" style="width:80px" id="txtsophieuthu" /></td>            
            <td>Người dùng</td>
            <td><asp:dropdownlist id="drl_nguoidung" runat="server"> </asp:dropdownlist> </td>
            <td>Đã thu:</td>
            <td><input type="checkbox" id="chktt" /> </td>
            <td><input type="button" id="bt_TimKiem"  onclick="LoadDanhSachPhieuThu()" value="Load doanh thu" /></td>            
            <td>Tổng tiền:</td>
            <td><input type="text" id="txttongtien" style="font-weight:bolder" disabled="disabled" /> </td>
            <td><input type="button" id="btntttu"  onclick="lapphieuthu()" value="Lập phiếu thu" /></td>
            <td><input type="button" id="btninbangke"  onclick="inbangke()" value="In bảng kê" /></td>
        </tr>
    </table>
</div>
<div>

<table class="TableGidview" id="TableDanhSach">
         <tr>
              <td class ="tdHeader" colspan="10" >DANH SÁCH PHIẾU THU CHI TIẾT THEO NGƯỜI DÙNG</td>
         </tr>
		<tr class="HeaderGidView">		    
		      <td style="width:50px">
                STT		       
		     </td>		    
		     <td style="width:200px">
		       Số phiếu thu		       
		     </td>
		     <td style="width:100px">
		       Ngày thu		       
		    </td>
		    <td style="width:200px">
		        Mã bệnh nhân
		    </td>
		     <td style="width:300px">
		        Tên bệnh nhân
		    </td>		     
		      <td style="width:300px">
		        Nội dung thu
		      </td>
		      <td style="width:200px">
		        Khoa
		      </td>
		      <td style="width:150px">
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
