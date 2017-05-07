<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTNH_UyNhiemThu.aspx.cs" Inherits="ketoan_KTNH_UyNhiemThu" %>
 <%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_NganHang.ascx" TagName="menu_ketoannganhang" TagPrefix="uc1" %>

 <!--#include file ="header.htm"-->
<link type="text/css" rel="stylesheet" href="../ketoan/css_KeToan/sheet_index.css" />
<link href="../ketoan/css_KeToan/epoch_styles.css" type="text/css" rel="stylesheet" />
<link href="../ketoan/css_KeToan/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/default.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/style.css" />

<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/epoch_styles.css" />
<link href="../ketoan/css_ketoan/dropdown/dropdown.css" media="screen" rel="stylesheet" type="text/css" />
<link href="../ketoan/css_ketoan/dropdown/themes/default/default.css" media="screen" rel="stylesheet" type="text/css" />

<script type="text/javascript" src="../ketoan/js_KeToan/libary.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/script.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/scriptoflong.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jscript.js"></script>

<script type="text/javascript" src="../ketoan/js_KeToan/epoch_classes.js"></script>
<script type="text/javascript" src="../ketoan/editor/editor.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jquery-1.4.2.js"></script>
<script src="../js/jquery.autocomplete.js" type="text/javascript"></script>
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/table_TCHD.css" />

<%--<%@ Register Src="menu_ketoannganhang.ascx" TagName="menu_ketoantienmat" TagPrefix="uc1" %>
--%> <script language="javascript" type="text/javascript">         
	window.onload = function () 
	{	       	    
	    //document.getElementById('txtMaUNT').disable=true;	
	    document.getElementById('txtMaUNT').focus();		        	    	        
	    var queryString = "";
	    queryString =  window.location.search.substring(1).split('&');
	    if(queryString!="" && queryString!='dkmenu=ktnganhang')
	    {
	        var idUNT = queryString[0].split('=');
	        var SoUNT = queryString[1].split('=');
	        var MaKH = queryString[2].split('=');
	        LoadUyNhiemThu(SoUNT[1]);
	       if(document.getElementById('bt_Luu').value =="Lưu")
            {
                document.getElementById('bt_Luu').value = "Sửa";        
            }
	    }
	};
	function phanquyen() 
	{
	    var quyenthem = '<%=StaticData.HavePermision(this.Page, "KeToanNH_KTNH_UyNhiemThu_Them")%>';
        var quyensua = '<%=StaticData.HavePermision(this.Page, "KeToanNH_KTNH_UyNhiemThu_Sua")%>';
        var quyenxoa = '<%=StaticData.HavePermision(this.Page, "KeToanNH_KTNH_UyNhiemThu_Xoa")%>';
        if(document.getElementById('bt_Luu').value == "Lưu")
        {
            if(quyenthem == 'False')
                document.getElementById('bt_Luu').disabled = true;
            else
                document.getElementById('bt_Luu').disabled = false;
        }
        if(document.getElementById('bt_Luu').value == "Sửa")
        {
            if(quyensua == 'False')
                document.getElementById('bt_Luu').disabled = true;
            else
                document.getElementById('bt_Luu').disabled = false;
        }
	}
function bt_Click(Ctr)
{       
    var ngaylap_ct=document.getElementById('txtNgayLapUNT').value;       
    kiemtrangaykhoaso(ngaylap_ct,Ctr);
}	
function kiemtrangaykhoaso(ngaylap_ct,Ctr)
{       
    var sophieu=document.getElementById('txtMaUNT').value;
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {
            var value=xmlHttp.responseText; 
            if(value==1)
                alert('Ngày lập Ủy nhiệm chi phải lớn hơn ngày khóa sổ!');
            else 
            {
                if(document.getElementById('bt_Luu').value =="Sửa")
                {
                    document.getElementById('bt_Luu').value = "Lưu";        
                }
                else
                if(document.getElementById('bt_Luu').value =="Lưu")
                {
//                    if(sophieu=="")
//                        TaoMaSoUyNhiemChi();
                    //themkhachhang();
                    LuuUyNhiemThu(Ctr);       
                }       
            }             
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrangaykhoaso&ngaylap_ct="+ngaylap_ct+"&times="+Math.random(),true)    
    xmlHttp.send(null); 
    }
function TaoMaSoUyNhiemChi()
{
       var Table = "Uy_Nhiem_Thu";
       var manghiepvu = "GIAY_BAO_CO";
       var Column = "So_unt";
       var ngaylap=document.getElementById('txtNgayLapUNT').value;
      xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="")
                      {  
                        document.getElementById('txtMaUNT').value = value;  
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TaoMaSoTuDong&Table="+Table+"&manghiepvu="+manghiepvu+"&Column="+Column+"&ngaylap="+ngaylap+"&times="+Math.random(),false);
            xmlHttp.send(null);
}
 function TestDate(t)
	{
		if (t.value != "")
		{
			t.value=AddString(t.value);
			if (isDate(t.value)==false)
			{
				t.value="";
				alert("Bạn nhập ngày tháng không hợp lệ. Vui lòng nhập lại với định dạng \"dd/MM/yyyy\" ! ");
				t.focus();
			}
		}
		return;
	}
function getFormatSoTien(Ctr)
{
    var idText = Ctr.id;
    var txtPhatSinh = document.getElementById(idText);
    txtPhatSinh.value = FormatSoTien(txtPhatSinh.value);
    var RowID = idText.split('_')[1];
    TinhThanhTien_IDRow(RowID);
    TinhTongTien();
    
}
function FormatSoTien(obj)
{
	    return formatCurrency(obj);
}

function TestNumberofInput(Ctr)
{
        var obj = Ctr.id;
        var key;
        if(window.event)
        {
          key = window.event.keyCode; 
        }
        //alert(key);
        var txtObj = document.getElementById(obj);
        //if((key<48||key>57)&&key!=190&&key!=8&&key!=9&&key!=37&&key!=38&&key!=39&&key!=40)
        if((key>=65&&key<=90))
        {
            alert("Chỉ được nhập số!");
            
            txtObj.value ="";
        }
        else
        {
            var number = txtObj.value;
             if(number=="")
                number="0";
             if(!isFinite(parseFloat(number))||parseFloat(number)>999999999999)
             {   alert("Nhập sai định dạng.Chỉ được nhập số!Vui lòng kiểm tra lại cảm ơn!"); 
                 txtObj.value ="";
                 document.getElementById(obj).focus();
             }
         }     
}
//==================Các hàm xử lý==============================

function ResetDataOnTable()
{     
    var btnluu=document.getElementById('bt_luu').value;            
    if(btnluu=="Sửa")
    {
       document.getElementById('bt_luu').value = "Lưu";
    }    
    document.getElementById('txtMaKH').value="";
    document.getElementById('txtTenKH').value="";
    document.getElementById('txtTaiKhoanNganHang').value="";
    document.getElementById('txtNganHang').value="";
    document.getElementById('txtMaUNT').value="";
    document.getElementById('hdUNT_ID').value="";
    
    document.getElementById('txtTaiKhoanNo').value="";
    document.getElementById('txtDienGiai').value="";
    document.getElementById('txtNgayLapUNT').value="";
    document.getElementById('txtNguoiNopTien').value="";
    ResetTableDSUyNhiemThu();                            
    //TaoMaSoUyNhiemChi();
}
function ResetTableDSUyNhiemThu()
{
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var lastRow = Row;
    while(lastRow>2)
    {
        TableDanhSach.deleteRow(lastRow-1);
        lastRow--;
    }
TongTien = 0;
}
function ShowTaiKhoanNganHang(Ctr)
{
    var obj = Ctr.id;
    var objsrc = document.getElementById(obj);
  
        $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=DanhSachTaiKhoanNganHang&Key="+objsrc.value+"&obj="+obj,
                                                    {width:550,scroll:true,formatItem:function(data)
                                                        {return data[1];}
                                                    }
                                                ).result(
                                                            function(event,data)
                                                            {
                                                          
                                                                setChonTaiKhoanNganHang(data[2],data[3],data[4]);
                                                              //  document.getElementById(obj).blur();
                                                            }
                                                        );           
}

function setChonTaiKhoanNganHang(TaiKhoanKT,SoHieuTKNH,TenTKNH)
{
  document.getElementById('txtTaiKhoanNo').value = TaiKhoanKT;
//  document.getElementById('txtTaiKhoanNganHang').value = SoHieuTKNH;
//  document.getElementById('txtNganHang').value = TenTKNH;
     document.getElementById('txtTaiKhoanNo').focus();
     
}
function ShowTaiKhoan(Ctr)
{
    var obj = Ctr.id;   
    var objsrc = document.getElementById(obj);
  
        $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=DanhSachTaiKhoan_Jquery&Key="+objsrc.value+"&obj="+obj,
                                                    {width:350,scroll:true,formatItem:function(data)
                                                        {return data[1];}
                                                    }
                                                ).result(
                                                            function(event,data)
                                                            {
                                                                setChonTaiKhoan(data[2],obj);
                                                              //  document.getElementById(obj).blur();
                                                            }
                                                        );           
}

function setChonTaiKhoan(MaTaiKhoan,idText)
{
    if(idText!="")
    {
      var txtTaiKhoan=document.getElementById(idText);
      txtTaiKhoan.value=MaTaiKhoan;
      txtTaiKhoan.focus();
    } 
}

function TestMaTaiKhoan(Ctr)
{
    var txtTaiKhoan = Ctr.id;
    var MaTaiKhoan = document.getElementById(txtTaiKhoan);
    if(MaTaiKhoan.value!="")
    {
        xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="1")
                      {  
                         alert("Tài khoản bạn chọn chưa có trong danh mục tài khoản. Vui lòng kiểm tra lại. Cảm ơn!");
                         MaTaiKhoan.value ="";
                         document.getElementById(txtTaiKhoan).focus();
                      }
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=TestMaTaiKhoan&Key="+MaTaiKhoan.value+"&times="+Math.random(),true);
            xmlHttp.send(null);
    }
}
function ShowKhachHang(Ctr)
{ 
         var obj=Ctr.id;         
         var objsrc = document.getElementById(obj);                               
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachKhachHang_UNT&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:700,scroll:true,formatItem:function(data)
                                                            {if(data!="") return data[1]; }
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    
                                                                    setChonKhachHang(data[2],data[3],data[4],data[5],data[6]);
                                                                    document.getElementById(obj).blur();
                                                                   // document.getElementById('txtTenKH').focus();
                                                                }
                                                            ); 
   
}
function setChonKhachHang(MaKH,TenKH,TKNganHang,NganHang,nguoilienhe)
{      
      var txtMaKH=document.getElementById('txtMaKH');
      var txtTenKH=document.getElementById('txtTenKH');      
      txtMaKH.value=MaKH;
      txtTenKH.value = TenKH;                
      document.getElementById('txtnguoinoptien').value=nguoilienhe;
      document.getElementById('txtTaiKhoanNganHang').value=TKNganHang;
      document.getElementById('txtNganHang').value=NganHang;
      document.getElementById('txtTenKH').focus();
      //setTimeout(kiemtramakhach(),10);
}

function ThemDong()
{ 
    var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
             shtml += "		<td class=\"Column0\" style=\"width:50px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\" style=\"width:50px\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/></td>";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"TaiKhoanCo_"+(lastRow)+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoHD_"+(lastRow)+"\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoSeri_"+(lastRow)+"\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"NgayLapHD_"+(lastRow)+"\" onchange=\"TestDate(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml +="       <td class=\"Column3_CK\"><input type=\"text\" id =\"DienGiai_"+(lastRow)+"\" style=\"width:99%;text-align:left\" /></td>";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"PhatSinhCo_"+(lastRow)+"\" onchange=\"getFormatSoTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" /></td>	"; 
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"ThueSuat_"+(lastRow)+"\" onkeyup=\"TestNumberofInput(this)\" onchange=\"TinhThanhTien('"+(lastRow)+"')\"  style=\"width:99%;text-align:right\" /></td>	"; 
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"TienThue_"+(lastRow)+"\" onchange=\"getFormatSoTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" /></td>	"; 
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"TaiKhoanThue_"+(lastRow)+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"ThanhTien_"+(lastRow)+"\" readonly=\"readonly\"  onclick=\"TinhThanhTien('"+(lastRow)+"')\" style=\"width:99%;text-align:right\"/></td>	";                                           
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
}
function XoaDong()
{
     var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
      
        if(lastRow>2)
        {
                for(var i=2;i<lastRow;i++)
                {
                     var idCheckBox = "checkbox_"+i;
                     var checkbox = document.getElementById(idCheckBox);
                    if(checkbox.checked)
                    {
                       
                        TableDanhSach.deleteRow(i);
                        UpdateRowOfTable();
                        XoaDong();
                          break;
                    }
                  
                }
             
        }
       
}
function UpdateRowOfTable()
{
      var TableDanhSach = document.getElementById('TableDanhSach');
      var lastRow = TableDanhSach.rows.length; 
      if(lastRow>2)
      {
        for(var i=2;i<lastRow;i++)
        {
          
        
             TableDanhSach.rows[i].cells[0].getElementsByTagName("input")[0].id = "STT_"+i;
             TableDanhSach.rows[i].cells[0].getElementsByTagName("input")[0].value = i-1;
             TableDanhSach.rows[i].cells[1].getElementsByTagName("input")[0].id = "checkbox_"+i;
             TableDanhSach.rows[i].cells[2].getElementsByTagName("input")[0].id = "TaiKhoanCo_"+i;
             TableDanhSach.rows[i].cells[3].getElementsByTagName("input")[0].id = "SoHD_"+i;
             TableDanhSach.rows[i].cells[4].getElementsByTagName("input")[0].id = "SoSeri_"+i;
             TableDanhSach.rows[i].cells[5].getElementsByTagName("input")[0].id = "NgayLapHD_"+i;
             TableDanhSach.rows[i].cells[6].getElementsByTagName("input")[0].id = "DienGiai_"+i;
             TableDanhSach.rows[i].cells[7].getElementsByTagName("input")[0].id = "PhatSinhCo_"+i;
             TableDanhSach.rows[i].cells[8].getElementsByTagName("input")[0].id = "ThueSuat_"+i;
             
             TableDanhSach.rows[i].cells[9].getElementsByTagName("input")[0].id = "TienThue_"+i;
             TableDanhSach.rows[i].cells[10].getElementsByTagName("input")[0].id = "TaiKhoanThue_"+i;
             TableDanhSach.rows[i].cells[11].getElementsByTagName("input")[0].id = "ThanhTien_"+i;
             
        }
      }
        TinhTongTien();
}
function LoadUyNhiemThu(SoUNT)
{
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
                    var j=1;
                    while(j<Row.length)
                    {
                        var Column = Row[j].split('&');
                       //unc_id,so_unc,ngay_lap,ma_ncc,ncc.TenNhaCungCap,Dien_Giai,TK_Co,SoTaiKhoanNCC,TenNganHangNCC,Tien,Nguoi_Nhan
                        ShowUyNhiemChi(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7],Column[8],Column[9],Column[10]);
                        j++;
                    }                    
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=LoadUyNhiemThuBySoUNT&SoUNT="+SoUNT+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function ShowUyNhiemChi(UNT_ID,So_UNT,NgayLap,MaKh,TenKH,DienGiai,TKNo,SoTaiKhoanKH,TenNganHangKH,Tien,NguoiNopTien)
{
    document.getElementById('hdUNT_ID').value = UNT_ID;
    document.getElementById('txtMaUNT').value = So_UNT;
    document.getElementById('txtNgayLapUNT').value = NgayLap;
    document.getElementById('txtMaKH').value = MaKh;
    document.getElementById('txtTenKH').value = TenKH;
    document.getElementById('txtNguoiNopTien').value = NguoiNopTien;
    document.getElementById('txtDienGiai').value = DienGiai;
    document.getElementById('txtTaiKhoanNo').value = TKNo;
    document.getElementById('TongTien').value = Tien;
    document.getElementById('txtTaiKhoanNganHang').value = SoTaiKhoanKH;
    document.getElementById('txtNganHang').value = TenNganHangKH;
    ResetTableDSUyNhiemThu();
    LoadChiTietUyNhiemThuBySoUNT(So_UNT);
}
function LoadChiTietUyNhiemThuBySoUNT(SoUNT)
{
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
                    var j=1;
                    while(j<Row.length)
                    {
                        var Column = Row[j].split('&');
                       //tk_no(1),ps_no(2),tk_thue(3),tien_thue(4),so_hd(5),so_seri(6),ngay_lap_hd(7),dien_giai(8),ThueSuat(9)
                        ShowChiTietUyNhiemThu(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7],Column[8]);
                        j++;
                    }                    
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=LoadChiTietUyNhiemThuBySoUNT&SoUNT="+SoUNT+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function ShowChiTietUyNhiemThu(TKCo,PSCo,TKThue,TienThue,SoHD,SoSeri,NgayLapHD,DienGiai,ThueSuat)
{
    if(NgayLapHD=="01/01/1900")
        NgayLapHD = "";
       var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td class=\"Column0\" style=\"width:50px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\" style=\"width:50px\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/></td>";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"TaiKhoanCo_"+(lastRow)+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\" value=\""+TKCo+"\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoHD_"+(lastRow)+"\" style=\"width:99%;text-align:center\" value=\""+SoHD+"\" /></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoSeri_"+(lastRow)+"\" style=\"width:99%;text-align:center\" value=\""+SoSeri+"\"  /></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"NgayLapHD_"+(lastRow)+"\" onchange=\"TestDate(this)\" style=\"width:99%;text-align:center\" value=\""+NgayLapHD+"\" /></td>	";
            shtml +="       <td class=\"Column3_CK\"><input type=\"text\" id =\"DienGiai_"+(lastRow)+"\" style=\"width:99%;text-align:left\" value=\""+DienGiai+"\" /></td>";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"PhatSinhCo_"+(lastRow)+"\" onchange=\"getFormatSoTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" value=\""+FormatSoTien(PSCo)+"\" /></td>	"; 
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"ThueSuat_"+(lastRow)+"\" onkeyup=\"TestNumberofInput(this)\" onchange=\"TinhThanhTien(this)\"  style=\"width:99%;text-align:right\" value=\""+ThueSuat+"\" /></td>	"; 
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"TienThue_"+(lastRow)+"\" onchange=\"getFormatSoTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" value=\""+FormatSoTien(TienThue)+"\" /></td>	"; 
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"TaiKhoanThue_"+(lastRow)+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\" value=\""+TKThue+"\" /></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"ThanhTien_"+(lastRow)+"\" readonly=\"readonly\"  onclick=\"TinhThanhTien(this)\" style=\"width:99%;text-align:right\"/></td>	";                                         
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
      TinhThanhTien_IDRow(lastRow);      
}
function TinhThanhTien_IDRow(RowID)
{
    
   var idPhatSinhCo = "PhatSinhCo_"+RowID;
    var valuePhatSinhCo = document.getElementById(idPhatSinhCo).value;
    
    var idThue = "ThueSuat_"+RowID;
    var valueThue = document.getElementById(idThue).value;
    
    var idTienThue = "TienThue_"+RowID;
    var TienThue = document.getElementById(idTienThue);
    TienThue.value = FormatSoTien(eval(ChangeFormatCurrency(valuePhatSinhCo)) * eval(ChangeFormatCurrency(valueThue))/100);
    
    var idThanhTien = "ThanhTien_"+RowID;
    valueThanhTien = eval(ChangeFormatCurrency(valuePhatSinhCo)) + eval(ChangeFormatCurrency(TienThue.value));
    document.getElementById(idThanhTien).value = FormatSoTien(valueThanhTien);
   // CongTongTien(valueThanhTien);
   TinhTongTien();
}

function TinhThanhTien(Ctr)
{
//    var IDCtr = Ctr.id;    
//    var RowID = IDCtr.split('_')[1];
    var idPhatSinhCo = "PhatSinhCo_"+Ctr;
    var valuePhatSinhCo = document.getElementById(idPhatSinhCo).value;
    var idThue = "ThueSuat_"+Ctr;
    var valueThue = document.getElementById(idThue).value;    
    var idTienThue = "TienThue_"+Ctr;
    var TienThue = document.getElementById(idTienThue);
    TienThue.value = FormatSoTien(Math.round((eval(ChangeFormatCurrency(valuePhatSinhCo)) * eval(ChangeFormatCurrency(valueThue)))/100));   
    var idThanhTien = "ThanhTien_"+Ctr;
    valueThanhTien = eval(ChangeFormatCurrency(valuePhatSinhCo)) + eval(ChangeFormatCurrency(TienThue.value));
    document.getElementById(idThanhTien).value = FormatSoTien(valueThanhTien);
   // CongTongTien(valueThanhTien);
   TinhTongTien();
}
 var TongTien = 0;
function CongTongTien(ThanhTien)
{
    var txtTongTien = document.getElementById('TongTien');
    txtTongTien.value = FormatSoTien(TongTien);
     
}
function TinhTongTien()
{
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
   var Tien = 0;
    var x;
    //var lastRow= Row-2;
    if(Row>2)
    {
       for(var i=2;i<Row;i++)
       {
            
            var count = Tien;
            var txtSoTien = "ThanhTien_"+i;
            var sotien =  document.getElementById(txtSoTien);
            if(sotien.value!="")
            {
                Tien =  eval(count) + (eval(ChangeFormatCurrency(sotien.value)));
            }    
            
       }
     }
     
    var txtTongTien = document.getElementById('TongTien');
    txtTongTien.value = FormatSoTien(Tien);
     
}

//================================Lưu ủy nhiệm chi=======================================================
function LuuUyNhiemThu(Ctr)
{
    Ctr.disabled = true;
    document.getElementById('message').style.visibility = "visible";
    var UNT_ID = document.getElementById('hdUNT_ID').value;
    var SoUNT = document.getElementById('txtMaUNT').value;
    var NgayLap = document.getElementById('txtNgayLapUNT').value;
    var MaKH = document.getElementById('txtMaKH').value;
    var NguoiNopTien = document.getElementById('txtNguoiNopTien').value;
    var DienGiai = document.getElementById('txtDienGiai').value;
    var TKNo = document.getElementById('txtTaiKhoanNo').value;
    var TongTien = document.getElementById('TongTien').value;
    var TKNganHangKH = document.getElementById('txtTaiKhoanNganHang').value;
    var TenNganHangKH = document.getElementById('txtNganHang').value;
    if(SoUNT=="")
    {
        alert("Chưa có số phiếu. Vui lòng kiểm tra lại. Cảm ơn!");
        Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
    }
    else
    if(NgayLap=="")
    {
        alert("Chưa chọn ngày lập phiếu. Vui lòng kiểm tra lại. Cảm ơn!");
        Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
    }
    else
    if(MaKH=="")
    {
        alert("Chưa chọn khách hàng. Vui lòng kiểm tra lại. Cảm ơn!");
        Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
    }
    else
    if(TKNo=="")
    {
        alert("Chưa chọn tài khoản nợ. Vui lòng kiểm tra lại. Cảm ơn!");
        Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
    }
    else
    if(TongTien=="")
    {
        alert("Chưa có tổng tiền. Vui lòng kiểm tra lại. Cảm ơn!");
        Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
    }
    else
        getFunctionLuuUyNhiemThu(Ctr,UNT_ID,SoUNT,NgayLap,MaKH,NguoiNopTien,DienGiai,TKNo,ChangeFormatCurrency(TongTien),TKNganHangKH,TenNganHangKH);
}
function getFunctionLuuUyNhiemThu(Ctr,UyNhiemThuID,So_UNT,NgayLap,MaKH,NguoiNopTien,DienGiai,TKNo,TongTien,TKNganHangKH,TenNganHangKH)
{
   xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                  if (value=="1")
                  {  
                      XoaChiTietUyNhiemThu(Ctr,So_UNT)    
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=Luu_UyNhiemThu&UyNhiemThuID="+UyNhiemThuID+"&So_UNT="+So_UNT+"&NgayLap="+NgayLap+"&MaKH="+MaKH+"&NguoiNhan="+encodeURIComponent(NguoiNopTien)+"&DienGiai="+encodeURIComponent(DienGiai)+"&TKNo="+TKNo+"&TongTien="+TongTien+"&TKNganHangKH="+TKNganHangKH+"&TenNganHangKH="+encodeURIComponent(TenNganHangKH)+"&times="+Math.random(),true);
        xmlHttp.send(null);
}

function XoaChiTietUyNhiemThu(Ctr,SoUNT)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                    XoaSoCai_UyNhiemThu(Ctr,SoUNT);                   
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=XoaChiTietUyNhiemThu&SoUNT="+SoUNT+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function XoaSoCai_UyNhiemThu(Ctr,SoUNT)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                    LuuChiTietUyNhiemThu(Ctr);
                  
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=XoaSoCai&SoCT="+SoUNT+"&times="+Math.random(),true);
            xmlHttp.send(null);
}

function LuuChiTietUyNhiemThu(Ctr)
{     
     var SoUNT = document.getElementById('txtMaUNT').value;
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var x;
    var rs = 1;
    var valueTkCo ="";
    var valuePhatSinhCo="";
    var valueThueSuat ="";
    var valueTKThue="";
    var valueTienThue="";
    var valueSoHD="";
    var valueSoSeri="";
    var valueNgayLapHD="";
    var valueNgayLapHD="";
    var valueDienGiai ="";
    var flag = false;
    if(Row>2)
    {
       for(var i=2;i<Row;i++)
        {
              var TKCo = "TaiKhoanCo_"+i;
              var PhatSinhCo = "PhatSinhCo_"+i;
              var ThueSuat = "ThueSuat_"+i;
              var TKThue = "TaiKhoanThue_"+i;
              var TienThue = "TienThue_"+i;
              var SoHD = "SoHD_"+i;
              var SoSeri = "SoSeri_"+i;
              var NgayLapHD = "NgayLapHD_"+i;
              var DienGiai = "DienGiai_"+i;
             if(document.getElementById(TKCo).value=="")
             {
                alert("Chưa nhập tài khoản nợ. Vui lòng kiểm tra lại. Nếu không dùng dòng này vui lòng xóa đi cảm ơn!");
                Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
             }
             else
             
             if(document.getElementById(PhatSinhCo).value=="")
             {
                alert("Chưa có phát sinh nợ. Vui lòng kiểm tra lại, cảm ơn!");
                Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
                    flag = false;
             }
             else
             {
                flag = true;
                 valueTkCo +=";"+ document.getElementById(TKCo).value;
                 
                 var PSCo = document.getElementById(PhatSinhCo).value;
                 valuePhatSinhCo +=";"+ ChangeFormatCurrency(PSCo);
                 
                 valueThueSuat +=";"+ document.getElementById(ThueSuat).value;
                 valueTKThue +=";"+ document.getElementById(TKThue).value;
                 
                 var tien_thue = document.getElementById(TienThue).value;
                 valueTienThue +=";"+ ChangeFormatCurrency(tien_thue);
                 
                 valueSoHD +=";"+ document.getElementById(SoHD).value;
                 valueSoSeri +=";"+ document.getElementById(SoSeri).value;
                 valueNgayLapHD +=";"+ document.getElementById(NgayLapHD).value;
                 valueDienGiai +=";"+ document.getElementById(DienGiai).value;
                 var Status = 0;
              }           
        }
        if(flag)
        {
            getFunctionLuuChiTietUyNhiemThu(Ctr,SoUNT,valueTkCo,valuePhatSinhCo,valueThueSuat,valueTKThue,valueTienThue,valueSoHD,valueSoSeri,valueNgayLapHD,valueDienGiai,Status);
            
        }
//        else
//        {
//            XoaUyNhiemThu(SoUNT);
//        }
     }
    else
    {
        alert("Chưa nhập chi tiết giấy báo có. Vui lòng kiểm tra lại. Cảm ơn!");
        Ctr.disabled = false;
        document.getElementById('message').style.visibility = "hidden";
        ///gọi ham xoa phieu uy nhiem chi
        XoaUyNhiemThu(SoUNT);
    }
        
}
function getFunctionLuuChiTietUyNhiemThu(Ctr,SoUNT,TKCo,PhatSinhCo,ThueSuat,TKThue,TienThue,SoHD,SoSeri,NgayLapHD,DienGiai,Status)
{
   xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                 if(value=="1")
                 {
                    LuuSoCai_UyNhiemThu(Ctr,TKCo,TKThue,PhatSinhCo,DienGiai,TienThue,SoHD,SoSeri,NgayLapHD);       
                 }
                 else
                 {
                    // alert("Chưa nhập chi tiết ủy nhiệm chi. Vui lòng kiểm tra lại. Cảm ơn!");
                    Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
                    ///gọi ham xoa phieu uy nhiem chi
                    XoaUyNhiemThu(SoUNT);
                 }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=Luu_ChiTietUyNhiemThu&SoUNT="+SoUNT+"&TKCo="+TKCo+"&PhatSinhCo="+PhatSinhCo+"&ThueSuat="+ThueSuat+"&TKThue="+TKThue+"&TienThue="+TienThue+"&SoHD="+SoHD+"&SoSeri="+SoSeri+"&NgayLapHD="+NgayLapHD+"&DienGiai="+encodeURIComponent(DienGiai)+"&Status="+Status+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function LuuSoCai_UyNhiemThu(Ctr,TKCo,TKThue,PhatSinhCo,DienGiai,TienThue,SoHD,SoSeri,NgayLapHD)
{
    
    var SoUNT = document.getElementById('txtMaUNT').value;
    var NgayLap = document.getElementById('txtNgayLapUNT').value;
    var MaKH = document.getElementById('txtMaKH').value;
    var TKNo = document.getElementById('txtTaiKhoanNo').value;
    var Dien_Giai = document.getElementById('txtDienGiai').value;
    var UserDau = "Tăng Thúy Ngọc";
    var UserCuoi = "CyberTang";
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                    if(value=="1")
                    {
                        alert("Lưu giấy báo có thành công!");
                         document.getElementById('bt_Luu').value = "Sửa";
                         ResetTableDSUyNhiemThu();
                        LoadChiTietUyNhiemThuBySoUNT(SoUNT);  
                    }
                    else
                    {
                         alert("Lưu giấy báo có thất bại. Vui lòng kiểm tra lại. Cảm ơn!");
                         XoaUyNhiemThu(SoUNT);
                    }
                    Ctr.disabled = false;
                     document.getElementById('message').style.visibility = "hidden";                                                
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=LuuSoCaiUyNhiemThu&SoUNT="+SoUNT+"&NgayLap="+NgayLap+"&MaKH="+MaKH+"&dien_giai="+encodeURIComponent(Dien_Giai)+"&TKNo="+TKNo+"&TKCo="+TKCo+"&PhatSinhCo="+PhatSinhCo+"&TKThue="+TKThue+"&TienThue="+TienThue+"&DienGiai="+encodeURIComponent(DienGiai)+"&SoHD="+SoHD+"&SoSeri="+SoSeri+"&NgayLapHD="+NgayLapHD+"&UserDau="+UserDau+"&UserCuoi"+UserCuoi+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function XoaUyNhiemThu(SoUNT)
{
   xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;                 
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=XoaUyNhiemThu&SoUNT="+SoUNT+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function InUyNhiemChi()
{
      var so_unc=document.getElementById('txtMaUNT').value;
    var tk_co=document.getElementById('txtTaiKhoanNo').value;
    window.open("KTNH_rptUyNhiemChi.aspx?so_unc=" + so_unc + "&tk_co=" + tk_co);
}
function ngayunt()
{    
    dinhdangngay(document.getElementById('txtNgayLapUNT'));
}
function kiemtraSoUNT(tenbang,tenfield,dieukien)
{   
    var tenbang="uy_nhiem_thu";
    var tenfield="so_unt";
    var dieukien=document.getElementById('txtMaUNT').value;      
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {               
            var value=xmlHttp.responseText;
            if(value==1)
            {
                alert('Số ủy nhiệm chi này đã có, vui lòng nhập lại');
                document.getElementById('txtMaUNT').focus();
            }                                  
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrathongtinTable&tenbang="+tenbang+"&tenfield="+tenfield+"&dieukien="+dieukien+"&times="+Math.random(),false);
    xmlHttp.send(null);
}
function xacnhan(kq)
{
    if(kq==1)
    {
        alert('Số ủy nhiệm chi này đã có, vui lòng nhập lại');
        document.getElementById('txtMaUNT').focus();
    }               
}

function kiemtramakh()
{
    var tenbang="khachhang";
    var tenfield="makhachhang";    
    var dieukien=document.getElementById('txtMaKH').value;      
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {               
            var value=xmlHttp.responseText;            
            if (value==0)
            {
                if (confirm('Mã khách hàng này chưa có!Bạn muốn thêm mới không?'))
                {                    
                 document.getElementById('txtTenKH').focus();                               
                }           
                else
                    {
                        alert('Xin vui lòng nhập mã khách hàng!')   
                        document.getElementById('txtMaKH').focus();            
                    }
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrathongtinTable&tenbang="+tenbang+"&tenfield="+tenfield+"&dieukien="+dieukien+"&times="+Math.random(),false);
    xmlHttp.send(null);
}
function themkhachhang()
{
    var makhach=document.getElementById('txtMaKH').value;
    var tenkh=document.getElementById('txtTenKH').value;  
    var nguoinoptien=document.getElementById('txtNguoiNopTien').value;
    var tknganhang=document.getElementById('txtTaiKhoanNganHang').value;
    var nganhang=document.getElementById('txtnganhang').value;
    xmlHttp=GetMSXmlHttp();
    xmlHttp.open("GET","ajax.aspx?do=themkhachhang2&makh="+makhach+"&tenkh="+encodeURIComponent(tenkh)+"&nguoinoptien="+nguoinoptien+"&tknganhang="+encodeURIComponent(tknganhang)+"&nganhang="+encodeURIComponent(nganhang)+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//ham kiem tra ma khach hang da co hay chua
function kiemtramakhach()
{
    var tenbang="khachhang";
    var tenfield="makhachhang";    
    var dieukien=document.getElementById('txtMaKH').value;  
    var kq;  
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {               
            var value=xmlHttp.responseText;            
            //document.getElementById('txtTenKH').focus(); 
            xacnhan(value);
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrathongtinTable&tenbang="+tenbang+"&tenfield="+tenfield+"&dieukien="+dieukien+"&times="+Math.random(),false);
    xmlHttp.send(null);
}
function xacnhan(kq)
{
    if (kq==0)
    {
        if (confirm('Mã khách hàng này chưa có!Bạn muốn thêm mới không?'))
            {                    
              document.getElementById('txtTenKH').focus();                               
            }           
        else
            document.getElementById('txtNguoiNopTien').focus();            
     }
}
function copynoidung()
{
    var ngaylapphieu=document.getElementById('txtNgayLapUNT').value;
    var maunc=document.getElementById('txtMaUNT').value;
    var mancc=document.getElementById('txtMaKH').value;
    var tenncc=document.getElementById('txtTenKH').value;    
    var nguoinhantien=document.getElementById('txtNguoiNopTien').value;    
    var tkno=document.getElementById('txtTaiKhoanNo').value;    
    var tknganhang=document.getElementById('txtTaiKhoanNganHang').value;
    var nganhang=document.getElementById('txtNganHang').value;
    var diengiai=document.getElementById('txtDienGiai').value;           
    ResetDataOnTable();
    //document.getElementById('txtMaUNT').value=maunc
    document.getElementById('txtNgayLapUNT').value=ngaylapphieu;    
    document.getElementById('txtMaKH').value=mancc;    
    document.getElementById('txtTenKH').value=tenncc;    
    document.getElementById('txtNguoiNopTien').value=nguoinhantien;    
    document.getElementById('txtTaiKhoanNo').value=tkno;    
    document.getElementById('txtTaiKhoanNganHang').value=nganhang;  
    document.getElementById('txtNganHang').value=nganhang;  
    document.getElementById('txtMaUNT').focus();
    document.getElementById('txtDienGiai').value = diengiai;
    alert('Copy nội dung thành công');
}
//=======================================================================================================
 </script>
 <form id="form1" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:menu_ketoannganhang ID="menu_ketoantienmat1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr style="height:10px">
                    <td><div  class = "tdHeader">GIẤY BÁO CÓ CỦA NGÂN HÀNG</div></td>
                </tr>
                <tr>
					    <td width="100%" valign = "top">
						    <table cellPadding="0" width="100%" border="0">
							    <tr>
								    <td vAlign="top" align="center" width="100%">
									    <table cellSpacing="0" cellPadding="0" width="98%" border="0">
										    
										    <tr style="padding-bottom: 5px; padding-top: 10px">
											    <td align="left"  style="height: 20px;width:100%;padding-left:200px">
												    <table class="Table" >
												      
												        <tr>
                                                            <td class="tdLabel">Số phiếu : </td>
                                                            <td class="tdText"><input  id="txtMaUNT" type="text"  runat="server"  class="InputText" /><input type="hidden" id="hdUNT_ID" /></td>                                                            
                                                            <td class="tdLabel" >Ngày lập :</td>
                                                            <td  class="tdText" ><input id="txtNgayLapUNT" onblur="ngayunt();"  style="width:100px;" runat="server"   type="text"/>&nbsp(dd/mm/yyyy)</td>                                                                                                                      
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">Mã khách hàng : </td>
                                                            <td class="tdText"><input id="txtMaKH"  type="text"  onfocus="ShowKhachHang(this)" onblur="kiemtramakhach();"  class="InputText" /><input type="hidden" id="hd_idBenhNhan" /></td>
                                                            
                                                            <td class="tdLabel">Tên khách hàng: </td>
                                                            <td  class="tdText"><input id="txtTenKH" type="text"  onfocus="ShowKhachHang(this)" class="InputText" /></td>
                                                            
                                                             <td class="tdLabel"> Người nộp tiền : </td>
                                                            <td  class="tdText"><input id="txtNguoiNopTien" type="text" class="InputText" /></td>                                                           
                                                        </tr>
                                                                                                       
                                                        <tr>
                                                            <td class="tdLabel">Tài khoản nợ: </td>
                                                            <td  class="tdText"><input id="txtTaiKhoanNo" type="text" class="InputText" onchange="TestMaTaiKhoan(this)" onfocus="ShowTaiKhoanNganHang(this)" /></td>
                                                            
                                                             <td class="tdLabel">TK ngân hàng: </td>
                                                            <td  class="tdText"><input id="txtTaiKhoanNganHang" type="text" class="InputText" /></td>
                                                            
                                                             <td class="tdLabel">Ngân hàng: </td>
                                                            <td  class="tdText"><input id="txtNganHang" type="text" class="InputText" /></td>
                                                            
                                                        </tr>
                                                        
                                                        
                                                        <tr>
                                                            <td class="tdLabel">Diễn giải : </td>
                                                            <td colspan="6"  class="tdText">
                                                                <textarea id="txtDienGiai" style="width:570px" cols="20"  rows="2"></textarea></td>
                                                            
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td colspan="6" style="text-align:center">
                                                                                                                               
                                                                <input type="button" value="Lưu" id="bt_Luu" onclick="bt_Click(this)" style="width:100px" />
                                                                <input type="button" value="Làm mới" id="bt_LamLai" onclick="ResetDataOnTable()" style="width:100px" />
                                                                <%--<input type="button" value="IN"  style="width:100px" id="bt_in" onclick="InUyNhiemChi()" />--%>
                                                                <input type="button" value="Copy"  style="width:100px" id="copy" onclick="copynoidung();" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="9" style="text-align:center">
                                                                <label id="message"  style="visibility:hidden" > Đang xử lý vui lòng chờ trong giây lát....</label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                  </td>
										    </tr>
									    </table>
								    </td>
							    </tr>
							    
							    
							   
						    </table>
						    
						    				   
					    </td>
				</tr>
            </table>
         </td>
       </tr>       
	    
     </table>
    <table class="TableGidview" id="TableDanhSach">
         <tr>
              <td class ="tdHeader" colspan="12" >Chi tiết giấy báo có</td>
         </tr>
		<tr class="HeaderGidView">
		     <td class="HeaderColumn0_CK">STT</td>
		    <td class="HeaderColumn0_CK">Xóa</td>
		     <td class="HeaderColumn1_CK">
		    TK Có
		     </td>
		    <td class="HeaderColumn2_CK">
		        Số hóa đơn
		    </td>
		    <td class="HeaderColumn2_CK">
		        Số seri
		    </td>
		    <td class="HeaderColumn2_CK">
		        Ngày lập HD
		    </td>
		     <td class="HeaderColumn3_CK">
		       Diễn giải
		       
		    </td>
		    <td class="HeaderColumn2_CK">
		        Phát sinh có
		    </td>
		    <td class="HeaderColumn1_CK">
		        Thuế 
		    </td>
		     <td class="HeaderColumn2_CK">
		        Tiền thuế
		    </td>
		    <td class="HeaderColumn1_CK">
		        TK thuế
		    </td>
              <td class="HeaderColumn2_CK">
		        Thành tiền
		     </td>		    	    
		</tr>					 
	  						 
	</table>         
    <div class ="tdHeader" style="font-size:14px;padding-left:910px">Tổng tiền : <input type="text" style="width:200px;text-align:right" readonly="readonly" id="TongTien" onclick="TinhTongTien()"/></div>      
    <div><input type="button" id="bt_ThemDong" value="Thêm dòng" onclick="ThemDong()"/><input type="button" id="bt_XoaDong" value="Xóa dòng" onclick="XoaDong()" /></div>
</form>
<!--#include file ="footer.htm"-->