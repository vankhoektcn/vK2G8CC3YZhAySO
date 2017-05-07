<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTNH_UyNhiemChi.aspx.cs" Inherits="ketoan_KTNH_UyNhiemChi" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_NganHang.ascx" TagName="menu_ketoannganhang1" TagPrefix="uc1" %>
 <!--#include file ="header.htm"-->
 
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/table_TCHD.css" />
<link href="../ketoan/css_KeToan/epoch_styles.css" type="text/css" rel="stylesheet" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/default.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/epoch_styles.css" />
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

<%--<%@ Register Src="menu_ketoannganhang.ascx" TagName="menu_ketoantienmat" TagPrefix="uc1" %>--%>
 <script language="javascript" type="text/javascript">
 var dp_cal;  
	window.onload = function () 
	{	  	    	   
	   //document.getElementById('txtMaUNC').disable=true;	 
	   document.getElementById('txtNgayLapUNC').focus();
	   phanquyen();
	   var queryString = "";
	    queryString =  window.location.search.substring(1).split('&');
	    if(queryString!='' && queryString!='dkmenu=ktnganhang' )
	    {	        
	        if(queryString.length==3)
	        {	            
	            var idUNC = queryString[0].split('=');
	            var SoUNC = queryString[1].split('=');
	            var MaNCC = queryString[2].split('=');	            
	            //var soUNCkq=SoUNC[1].substring(0,(SoUNC[1].length-3));	            
	            LoadUyNhiemChi(SoUNC[1]);
	            if(document.getElementById('bt_Luu').value =="Lưu")
                {
                    document.getElementById('bt_Luu').value = "Sửa";        
                }
            }
            else
            {                                              
                document.getElementById('ddlLoaiUNC').value=1;                
                var mapn=queryString[0].split('=');   
                LoadChiTietThanhToanCongNo(mapn[1]);             
            }
	    }	    
	};
	function phanquyen() 
	{
	    var quyenthem = '<%=StaticData.HavePermision(this.Page, "KeToanNH_KTNH_UyNhiemChi_Them")%>';
        var quyensua = '<%=StaticData.HavePermision(this.Page, "KeToanNH_KTNH_UyNhiemChi_Sua")%>';
        var quyenxoa = '<%=StaticData.HavePermision(this.Page, "KeToanNH_KTNH_UyNhiemChi_Xoa")%>';
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
    var sophieu=document.getElementById('txtMaUNC').value;
    if(document.getElementById('bt_Luu').value =="Sửa")
    {
         document.getElementById('bt_Luu').value = "Lưu";        
    }
    else
        if(document.getElementById('bt_Luu').value =="Lưu")
        {
//          if(sophieu=="")
//            TaoMaSoUyNhiemChi();  
          themnhacungcap();
          LuuUyNhiemChi(Ctr);       
        }       
}	
function TaoMaSoUyNhiemChi()
{
      var Table = "Uy_Nhiem_Chi";
      var manghiepvu = "GIAY_BAO_NO";
      var Column = "So_UNC";
      var ngaylap=document.getElementById('txtNgayLapUNC').value;
      xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="")
                      {  
                        document.getElementById('txtMaUNC').value = value;  
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
        if((key>=65 && key<=90))
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
    var btnluu=document.getElementById('bt_Luu').value;            
    if(btnluu=="Sửa")
    {
       document.getElementById('bt_Luu').value = "Lưu";
    }
    
    document.getElementById('txtMaNCC').value="";
    document.getElementById('txtTenNCC').value="";
    document.getElementById('txtTaiKhoanNganHang').value="";
    document.getElementById('txtNganHang').value="";
    document.getElementById('txtMaUNC').value="";
    document.getElementById('hdUNC_ID').value="";
    
    document.getElementById('txtTaiKhoanCo').value="";
    document.getElementById('txtDienGiai').value="";
    document.getElementById('txtNgayLapUNC').value="";
    document.getElementById('txtNguoiNhanTien').value="";
    ResetTableDSUyNhiemChi();                            
    //TaoMaSoUyNhiemChi();
}
function ResetTableDSUyNhiemChi()
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
  document.getElementById('txtTaiKhoanCo').value = TaiKhoanKT;
//  document.getElementById('txtTaiKhoanNganHang').value = SoHieuTKNH;
//  document.getElementById('txtNganHang').value = TenTKNH;
     document.getElementById('txtTaiKhoanCo').focus();     
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
function ShowNhaCungCap(Ctr)
{    
         var obj = Ctr.id;
        var objsrc = document.getElementById(obj);
      
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachNhaCungCap2&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:300,scroll:true,formatItem:function(data)
                                                            { if(data!="") return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    setChonNCC(data[2],data[3],data[4],data[5],data[6]);
                                                                    document.getElementById(obj).blur();
                                                                }
                                                            ); 
    
}
function setChonNCC(idNCC,MaNCC,TenNCC,TKNganHang,NganHang)
{      
      var txtMaNCC=document.getElementById('txtMaNCC');
      var txtTenNCC=document.getElementById('txtTenNCC');
      var txtTaiKhoanNganHang=document.getElementById('txtTaiKhoanNganHang');
      var txtNganHang=document.getElementById('txtNganHang');
      txtMaNCC.value=MaNCC;
      txtTenNCC.value = TenNCC;
      txtNganHang.value = NganHang;
      txtTaiKhoanNganHang.value = TKNganHang;      
      //alert(hd_IDBN.value);
      document.getElementById('txtTenNCC').focus();
}
function ShowNhaCungCap2(Ctr)
{
        var obj = Ctr.id;
        var objsrc = document.getElementById(obj);
      
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachNhaCungCap2&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj.substring(0,obj.length-2),
                                                        {width:300,scroll:true,formatItem:function(data)
                                                            { if(data!="") return data[1];}
                                                        }
                                                    ).result(
                                                                 function(event,data)
                                                                {
                                                                    setChonNCC2(data[2],data[3],data[4],obj);
                                                                    document.getElementById(obj).blur();
                                                                }
                                                            ); 
    
}
function setChonNCC2(idNCC,MaNCC,TenNCC,obj)
{                   
      var dong=obj.substring(obj.length-1);     
      //alert(dong);
     document.getElementById('TableDanhSach').rows[dong].cells[2].getElementsByTagName("input")[0].value=MaNCC;
     document.getElementById('TableDanhSach').rows[dong].cells[3].getElementsByTagName("input")[0].value=TenNCC; 
     document.getElementById('TableDanhSach').rows[dong].cells[4].getElementsByTagName("input")[0].focus();
}
function ThemDong()
{ 
    var MaNCC = document.getElementById('txtMaNCC').value;
    var TenNCC= document.getElementById('txtTenNCC').value;    
    var TableDanhSach = document.getElementById('TableDanhSach');
    var lastRow = TableDanhSach.rows.length; 
    var shtml = "<tr class=\"RowGidView\">";
             shtml += "		<td class=\"Column0\" style=\"width:50px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\" style=\"width:50px\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/></td>";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"txtMaNCC_"+(lastRow)+"\"  onfocus=\"ShowNhaCungCap2(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"txtTenNCC_"+(lastRow)+"\"   onfocus=\"ShowNhaCungCap2(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"TaiKhoanNo_"+(lastRow)+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoHD_"+(lastRow)+"\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoSeri_"+(lastRow)+"\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"NgayLapHD_"+(lastRow)+"\" onchange=\"TestDate(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml +="       <td class=\"Column3_CK\"><input type=\"text\" id =\"DienGiai_"+(lastRow)+"\" style=\"width:99%;text-align:left\" /></td>";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"PhatSinhNo_"+(lastRow)+"\" onchange=\"getFormatSoTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" /></td>	"; 
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"ThanhTien_"+(lastRow)+"\" readonly=\"readonly\"  onclick=\"TinhThanhTien('"+(lastRow)+"')\" style=\"width:99%;text-align:right\"/></td>	";                                           
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
    document.getElementById('TableDanhSach').rows[lastRow].cells[2].getElementsByTagName("input")[0].value=MaNCC;
    document.getElementById('TableDanhSach').rows[lastRow].cells[3].getElementsByTagName("input")[0].value=TenNCC; 
    document.getElementById('TableDanhSach').rows[lastRow].cells[4].getElementsByTagName("input")[0].focus();
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
             TableDanhSach.rows[i].cells[2].getElementsByTagName("input")[0].id = "MaNCC_"+i;
             TableDanhSach.rows[i].cells[3].getElementsByTagName("input")[0].id = "TenNCC_"+i;
             TableDanhSach.rows[i].cells[4].getElementsByTagName("input")[0].id = "TaiKhoanNo_"+i;
             TableDanhSach.rows[i].cells[5].getElementsByTagName("input")[0].id = "SoHD_"+i;
             TableDanhSach.rows[i].cells[6].getElementsByTagName("input")[0].id = "SoSeri_"+i;
             TableDanhSach.rows[i].cells[7].getElementsByTagName("input")[0].id = "NgayLapHD_"+i;
             TableDanhSach.rows[i].cells[8].getElementsByTagName("input")[0].id = "DienGiai_"+i;
             TableDanhSach.rows[i].cells[9].getElementsByTagName("input")[0].id = "PhatSinhNo_"+i;
             TableDanhSach.rows[i].cells[10].getElementsByTagName("input")[0].id = "ThueSuat_"+i;             
             TableDanhSach.rows[i].cells[11].getElementsByTagName("input")[0].id = "TienThue_"+i;
             TableDanhSach.rows[i].cells[12].getElementsByTagName("input")[0].id = "TaiKhoanThue_"+i;
             TableDanhSach.rows[i].cells[13].getElementsByTagName("input")[0].id = "ThanhTien_"+i;             
        }
      }
        TinhTongTien();
}

function LoadUyNhiemChi(SoUNC)
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
          xmlHttp.open("GET","ajax.aspx?do=LoadUyNhiemChiBySoUNC&SoUNC="+SoUNC+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function ShowUyNhiemChi(UNC_ID,So_UNC,NgayLap,MaNCC,TenNCC,DienGiai,TKCo,SoTaiKhoanNCC,TenNganHangNCC,Tien,NguoiNhan)
{
    document.getElementById('hdUNC_ID').value = UNC_ID;
    document.getElementById('txtMaUNC').value = So_UNC;
    document.getElementById('txtNgayLapUNC').value = NgayLap;
    document.getElementById('txtMaNCC').value = MaNCC;
    document.getElementById('txtTenNCC').value = TenNCC;
    document.getElementById('txtNguoiNhanTien').value = NguoiNhan;
    document.getElementById('txtDienGiai').value = DienGiai;
    document.getElementById('txtTaiKhoanCo').value = TKCo;
    document.getElementById('TongTien').value = Tien;
    document.getElementById('txtTaiKhoanNganHang').value = SoTaiKhoanNCC;
    document.getElementById('txtNganHang').value = TenNganHangNCC;
    ResetTableDSUyNhiemChi();
    LoadChiTietUyNhiemChiBySoUNC(So_UNC);
}
function LoadChiTietThanhToanCongNo(MaPN)
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
                        ShowChiTietUyNhiemChi(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7],Column[8],Column[9],Column[10],Column[11],'','','');                                                                                              
                        j++;
                    }                    
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=LoadChiTietThanhToanCongNo&MaPN="+MaPN+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function LoadChiTietUyNhiemChiBySoUNC(SoUNC)
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
                        ShowChiTietUyNhiemChi(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7],Column[8],Column[9],Column[10],Column[11],Column[12],Column[13]);
                        j++;
                    }                    
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=LoadChiTietUyNhiemChiBySoUNC&SoUNC="+SoUNC+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function ShowChiTietUyNhiemChi(MaNCC,TenNCC,TKNo,SoHD,SoSeri,NgayLapHD,DienGiai,PSNo,ThueSuat,TKThue,TienThue,mapn,IdNhapVT,IdPhieuNhap)
{        
    if(NgayLapHD=="01/01/1900")
        NgayLapHD = "";
       var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td class=\"Column0\" style=\"width:50px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            
            shtml += "		<td class=\"Column0\" style=\"width:50px\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/>"
                   +"<input type=\"hidden\" id=\"IdNhapVT_"+(lastRow)+"\" value=\""+IdNhapVT+"\"/>"
                +"<input type=\"hidden\" id=\"IdPhieuNhap_"+(lastRow)+"\" value=\""+IdPhieuNhap+"\"/>"
                 +"<input type=\"hidden\" id=\"mapn_"+(lastRow)+"\" value=\""+mapn+"\"/>"
                +"</td>";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"MaNCC_"+(lastRow)+"\"  onfocus=\"ShowNhaCungCap(this)\" style=\"width:99%;text-align:center\" value=\""+MaNCC+"\"/></td>	";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"TenNCC_"+(lastRow)+"\"  onfocus=\"ShowNhaCungCap(this)\" style=\"width:99%;text-align:center\" value=\""+TenNCC+"\"/></td>	";  
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"TaiKhoanNo_"+(lastRow)+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\" value=\""+TKNo+"\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoHD_"+(lastRow)+"\" style=\"width:99%;text-align:center\" value=\""+SoHD+"\" /></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoSeri_"+(lastRow)+"\" style=\"width:99%;text-align:center\" value=\""+SoSeri+"\"  /></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"NgayLapHD_"+(lastRow)+"\" onchange=\"TestDate(this)\" style=\"width:99%;text-align:center\" value=\""+NgayLapHD+"\" /></td>	";
            shtml +="       <td class=\"Column3_CK\"><input type=\"text\" id =\"DienGiai_"+(lastRow)+"\" style=\"width:99%;text-align:left\" value=\""+DienGiai+"\" /></td>";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"PhatSinhNo_"+(lastRow)+"\" onchange=\"getFormatSoTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" value=\""+FormatSoTien(PSNo)+"\" /></td>	"; 
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"ThanhTien_"+(lastRow)+"\" readonly=\"readonly\"  onclick=\"TinhThanhTien(this)\" style=\"width:99%;text-align:right\"/></td>	";                                         
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
      TinhThanhTien_IDRow(lastRow);      
}
function TinhThanhTien_IDRow(RowID)
{    
    var idPhatSinhNo = "PhatSinhNo_"+RowID;
    var valuePhatSinhNo = document.getElementById(idPhatSinhNo).value;    
    var idThanhTien = "ThanhTien_"+RowID;
    valueThanhTien = eval(ChangeFormatCurrency(valuePhatSinhNo));
    document.getElementById(idThanhTien).value = FormatSoTien(valueThanhTien);  
   TinhTongTien();
}
function TinhThanhTien(Ctr)
{
    var idPhatSinhNo = "PhatSinhNo_"+Ctr;
    var valuePhatSinhNo = document.getElementById(idPhatSinhNo).value;
    var idThanhTien = "ThanhTien_"+Ctr;
    valueThanhTien = eval(ChangeFormatCurrency(valuePhatSinhNo)) ;
    document.getElementById(idThanhTien).value = FormatSoTien(valueThanhTien);   
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
function LuuUyNhiemChi(Ctr)
{       
    Ctr.disabled = true;
    document.getElementById('message').style.visibility = "visible";        
    var UNC_ID = document.getElementById('hdUNC_ID').value;    
    var SoUNC = document.getElementById('txtMaUNC').value;    
    var NgayLap = document.getElementById('txtNgayLapUNC').value;    
    var MaNCC = document.getElementById('txtMaNCC').value;
    
    var NguoiNhan = document.getElementById('txtNguoiNhanTien').value;    
    var DienGiai = document.getElementById('txtDienGiai').value;
    var TKCo = document.getElementById('txtTaiKhoanCo').value;
    var TongTien = document.getElementById('TongTien').value;
    var TKNganHangNCC = document.getElementById('txtTaiKhoanNganHang').value;
    var TenNganHangCC = document.getElementById('txtNganHang').value;    
    if(SoUNC=="")
    {
        alert("Chưa có số ủy nhiệm chi. Vui lòng kiểm tra lại. Cảm ơn!");
        Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
    }
    else
    if(NgayLap=="")
    {
        alert("Chưa chọn ngày lập ủy nhiệm chi. Vui lòng kiểm tra lại. Cảm ơn!");
        Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
    }
    else
    if(MaNCC=="")
    {
        alert("Chưa chọn nhà cung cấp. Vui lòng kiểm tra lại. Cảm ơn!");
        Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
    }
    else
    if(TKCo=="")
    {
        alert("Chưa chọn tài khoản có. Vui lòng kiểm tra lại. Cảm ơn!");
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
        getFunctionLuuUyNhiemChi(Ctr,UNC_ID,SoUNC,NgayLap,MaNCC,NguoiNhan,DienGiai,TKCo,ChangeFormatCurrency(TongTien),TKNganHangNCC,TenNganHangCC);
}
function getFunctionLuuUyNhiemChi(Ctr,UyNhiemChiID,So_UNC,NgayLap,MaNCC,NguoiNhan,DienGiai,TKCo,TongTien,TKNganHangNCC,TenNganHangCC)
{

   xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                  if (value=="1")
                  {  
                      XoaChiTietUyNhiemChi(Ctr,So_UNC)    
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=Luu_UyNhiemChi&UyNhiemChiID="+UyNhiemChiID+"&So_UNC="+So_UNC+"&NgayLap="+NgayLap+"&MaNCC="+MaNCC+"&NguoiNhan="+encodeURIComponent(NguoiNhan)+"&DienGiai="+encodeURIComponent(DienGiai)+"&TKCo="+TKCo+"&TongTien="+TongTien+"&TKNganHangNCC="+TKNganHangNCC+"&TenNganHangCC="+encodeURIComponent(TenNganHangCC)+"&times="+Math.random(),true);
        xmlHttp.send(null);
}

function XoaChiTietUyNhiemChi(Ctr,SoUNC)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                    XoaSoCai_UyNhiemChi(Ctr,SoUNC);                   
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=XoaChiTietUyNhiemChi&SoUNC="+SoUNC+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function XoaSoCai_UyNhiemChi(Ctr,SoUNC)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                    LuuChiTietUyNhiemChi(Ctr);                  
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=XoaSoCai&SoCT="+SoUNC+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function LuuChiTietUyNhiemChi(Ctr)
{     
    var SoUNC = document.getElementById('txtMaUNC').value;
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var x;
    var rs = 1;
    var valueMaNCC="";
    var valueTenNCC="";
    var valueTkNo ="";
    var valuePhatSinhNo="";    
    var valueSoHD="";
    var valueSoSeri="";
    var valueNgayLapHD="";
    var valueNgayLapHD="";
    var valueDienGiai ="";
    var valueIdNhapVT="";
    var valueIdPhieuNhap="";
    var valuemapn="";
    var flag = false;   
    var loaiunc=document.getElementById('ddlLoaiUNC').value;    
    if(Row>2)
    {
       for(var i=2;i<Row;i++)
        {
              var MaNCC="txtMaNCC_"+i;
              var TenNCC="txtTenNCC_"+i;  
              var TKNo = "TaiKhoanNo_"+i;
              var PhatSinhNo = "PhatSinhNo_"+i;              
              var SoHD = "SoHD_"+i;
              var SoSeri = "SoSeri_"+i;
              var NgayLapHD = "NgayLapHD_"+i;
              var DienGiai = "DienGiai_"+i;
              var oIdNhapVT = "IdNhapVT_"+i;
              var oIdPhieuNhap = "IdPhieuNhap_"+i;
              var mapn="mapn_"+i;
              
             if(document.getElementById(TKNo).value=="")
             {
                alert("Chưa nhập tài khoản nợ. Vui lòng kiểm tra lại. Nếu không dùng dòng này vui lòng xóa đi cảm ơn!");
                Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
             }
             else
             
             if(document.getElementById(PhatSinhNo).value=="")
             {
                alert("Chưa có phát sinh nợ. Vui lòng kiểm tra lại, cảm ơn!");
                Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
                    flag = false;
             }
             else
             {
                flag = true;
                 valueMaNCC +=";"+ document.getElementById('TableDanhSach').rows[i].cells[2].getElementsByTagName("input")[0].value
                 valueTenNCC +=";"+document.getElementById('TableDanhSach').rows[i].cells[3].getElementsByTagName("input")[0].value
                 valueTkNo +=";"+ document.getElementById(TKNo).value;
                 
                 var PSNo = document.getElementById(PhatSinhNo).value;
                 valuePhatSinhNo +=";"+ ChangeFormatCurrency(PSNo);                                 
                 
                 valueSoHD +=";"+ document.getElementById(SoHD).value;
                 valueSoSeri +=";"+ document.getElementById(SoSeri).value;
                 valueNgayLapHD +=";"+ document.getElementById(NgayLapHD).value;
                 valueDienGiai +=";"+ document.getElementById(DienGiai).value;                 
                 var Status = 0;            
                 if(loaiunc==1)
                 {
                    valueIdNhapVT +=";"+ document.getElementById(oIdNhapVT).value;                
                    valueIdPhieuNhap +=";"+ document.getElementById(oIdPhieuNhap).value;
                    valuemapn+=";"+document.getElementById(mapn).value;                   
                 }                                       
              }           
        }
        if(flag)
        {
            getFunctionLuuChiTietUyNhiemChi(Ctr,SoUNC,valueMaNCC,valueTenNCC,valueTkNo,valuePhatSinhNo,valueSoHD,valueSoSeri,valueNgayLapHD,valueDienGiai,Status,valueIdPhieuNhap,valueIdNhapVT,valuemapn,loaiunc);            
        }
//        else
//        {
//            XoaUyNhiemChi(SoUNC);
//        }
     }
    else
    {
        alert("Chưa nhập chi tiết ủy nhiệm chi. Vui lòng kiểm tra lại. Cảm ơn!");
        Ctr.disabled = false;
        document.getElementById('message').style.visibility = "hidden";
        ///gọi ham xoa phieu uy nhiem chi
        XoaUyNhiemChi(SoUNC);
    }        
}
function getFunctionLuuChiTietUyNhiemChi(Ctr,SoUNC,MaNCC,TenNCC,TKNo,PhatSinhNo,SoHD,SoSeri,NgayLapHD,DienGiai,Status,valueIdPhieuNhap,valueIdNhapVT,mapn,loaiunc)
{    
   xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                 if(value=="1")
                 {
                    LuuSoCai_UyNhiemChi(Ctr,MaNCC,TKNo,PhatSinhNo,DienGiai,SoHD,SoSeri,NgayLapHD);       
                 }
                 else
                 {
                    // alert("Chưa nhập chi tiết ủy nhiệm chi. Vui lòng kiểm tra lại. Cảm ơn!");
                    Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
                    ///gọi ham xoa phieu uy nhiem chi
                    XoaUyNhiemChi(SoUNC);
                 }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=Luu_ChiTietUyNhiemChi&SoUNC="+SoUNC+"&MaNCC="+MaNCC+"&TenNCC="+encodeURIComponent(TenNCC)+"&TKNo="+TKNo+"&PhatSinhNo="+PhatSinhNo+"&SoHD="+SoHD+"&SoSeri="+SoSeri+"&NgayLapHD="+NgayLapHD+"&DienGiai="+encodeURIComponent(DienGiai)+"&Status="+Status+"&valueIdNhapVT="+valueIdNhapVT+"&valueIdPhieuNhap="+valueIdPhieuNhap+"&mapn="+mapn+"&loaiunc="+loaiunc+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function LuuSoCai_UyNhiemChi(Ctr,MaNCC,TKNo,PhatSinhNo,DienGiai,SoHD,SoSeri,NgayLapHD)
{    
    var SoUNC = document.getElementById('txtMaUNC').value;
    var NgayLap = document.getElementById('txtNgayLapUNC').value;
    //var MaNCC = document.getElementById('txtMaNCC').value;
    var TKCo = document.getElementById('txtTaiKhoanCo').value;
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
                        alert("Lưu phiếu ủy nhiệm chi thành công!");
                         document.getElementById('bt_Luu').value = "Sửa";
                         ResetTableDSUyNhiemChi();
                        LoadChiTietUyNhiemChiBySoUNC(SoUNC);  
                    }
                    else
                    {
                         alert("Lưu phiếu ủy nhiệm thất bại. Vui lòng kiểm tra lại. Cảm ơn!");
                         XoaUyNhiemChi(SoUNC);
                    }
                    Ctr.disabled = false;
                     document.getElementById('message').style.visibility = "hidden";                                                
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=LuuSoCaiUyNhiemChi&SoUNC="+SoUNC+"&NgayLap="+NgayLap+"&MaNCC="+MaNCC+"&TKCo="+TKCo+"&TKNo="+TKNo+"&PhatSinhNo="+PhatSinhNo+"&DienGiai="+encodeURIComponent(DienGiai)+"&SoHD="+SoHD+"&SoSeri="+SoSeri+"&NgayLapHD="+NgayLapHD+"&UserDau="+UserDau+"&UserCuoi"+UserCuoi+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function XoaUyNhiemChi(SoUNC)
{
   xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;                 
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=XoaUyNhiemChi_fault&SoUNC="+SoUNC+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function InUyNhiemChi()
{       
    var so_unc=document.getElementById('txtMaUNC').value;
    var tk_co=document.getElementById('txtTaiKhoanCo').value;
    var tabledanhsach=document.getElementById('TableDanhSach');
    var row=tabledanhsach.rows.length;    
    var idmancc="";
    var mancc="";
    var i=row-2;
    while(row>=2)
    {        
        idmancc="MaNCC_"+(row-1);        
        mancc=document.getElementById(idmancc).value;               
        window.open("KTNH_rptUyNhiemChi.aspx?so_unc=" + so_unc + "&tk_co=" + tk_co+"&mancc="+mancc+"&giatri="+i);    
        row--;
        i--;
    }
    
}
function ngayunc()
{
    dinhdangngay(document.getElementById('txtNgayLapUNC'));
}

function kiemtrasounc(tenbang,tenfield,dieukien)
{   
    var tenbang="uy_nhiem_chi";
    var tenfield="so_unc";
    var dieukien=document.getElementById('txtMaUNC').value;      
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {               
            var value=xmlHttp.responseText;
            xacnhan(value);                                  
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
        document.getElementById('txtMaUNC').focus();
    }               
}

function kiemtramancc()
{
    var tenbang="nhacungcap";
    var tenfield="manhacungcap";    
    var dieukien=document.getElementById('txtMaNCC').value;      
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {               
            var value=xmlHttp.responseText;            
            if (value==0)
            {
                if (confirm('Mã nhà cung cấp này chưa có!Bạn muốn thêm mới không?'))
                {                    
                 document.getElementById('txtTenNCC').focus();                               
                }           
                else
                    {
                        alert('Xin vui lòng nhập mã nhà cung cấp!')   
                        document.getElementById('txtMaNCC').focus();            
                    }
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrathongtinTable&tenbang="+tenbang+"&tenfield="+tenfield+"&dieukien="+dieukien+"&times="+Math.random(),false);
    xmlHttp.send(null);
}
function themnhacungcap()
{
    var mancc=document.getElementById('txtMaNCC').value;    ;
    var tenncc=document.getElementById('txtTenNCC').value;
    var nguoilienhe=document.getElementById('txtNguoiNhanTien').value;
    var nganhang=document.getElementById('txtNganHang').value;
    var tknganhang=document.getElementById('txtTaiKhoanNganHang').value;    
    var diachi="";        
    xmlHttp=GetMSXmlHttp();
    xmlHttp.open("GET","ajax.aspx?do=themnhacungcap&mancc="+mancc+"&tenncc="+encodeURIComponent(tenncc)+"&diachi="+encodeURIComponent(diachi)+"&nguoilienhe="+encodeURIComponent(nguoilienhe)+"&nganhang="+encodeURIComponent(nganhang)+"&tknganhang="+tknganhang+"&times="+Math.random(),true);
    xmlHttp.send(null);    
}
function LoadDanhSachHoaDon()
{
    var MaNCC = document.getElementById('txtMaNCC').value;
    var NgayLap = document.getElementById('txtNgayLapUNC').value;
    var TableDanhSach = document.getElementById('TableDanhSach');
    var lastRow = TableDanhSach.rows.length;
    if(lastRow>2)
        ResetTableDSUyNhiemChi();
    
    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                  if (value!="")
                  {  
                    var row = value.split('|');
                    for(var i = 1;i<row.length;i++)
                    {
                        var Column = row[i];
                        var data = Column.split('&');
                        //ShowDanhSachHoaDon(data[0],data[1],data[2],data[3],data[4],data[5],data[6],data[7],0);
                        ShowChiTietUyNhiemChi(data[0],data[1],data[2],data[3],data[4],data[5],data[6],data[7],data[8],data[9],data[10],data[11],data[12],data[13]);
                    }
                  }
            }
        }
          xmlHttp.open("GET","KTTM_PhieuChiHoaDon_Ajax.aspx?do=LoadDanhSachHoaDonPhieuUyNhiemChi&MaNCC="+MaNCC+"&NgayLap="+NgayLap+"&times="+Math.random(),true);
        xmlHttp.send(null);   
}
function ShowDanhSachHoaDon(SoHD,TKNo,NgayLapHD,ThanhTien,NguyenTe,DienGiai,IdNhapVT,IdPhieuNhap,IDPhieuChiCT)
{
    var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
             shtml += "		<td class=\"Column0\" style=\"width:50px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\" style=\"width:50px\" id=\"td_checkbox\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/>"
                 +"<input type=\"hidden\" id=\"IdNhapVT_"+(lastRow-1)+"\" value=\""+IdNhapVT+"\"/>"
                +"<input type=\"hidden\" id=\"IdPhieuNhap_"+(lastRow-1)+"\" value=\""+IdPhieuNhap+"\"/>"
                +"</td>";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"TaiKhoanNo_"+(lastRow)+"\"  onchange=\"TestMaTaiKhoan(this)\" value=\""+TKNo+"\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoHD_"+(lastRow)+"\" style=\"width:99%;text-align:center\" value=\""+SoHD+"\" /></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoSeri_"+(lastRow)+"\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"NgayLapHD_"+(lastRow)+"\" onchange=\"TestDate(this)\" value=\""+NgayLapHD+"\" style=\"width:99%;text-align:center\"/></td>	";
            shtml +="       <td class=\"Column3_CK\"><input type=\"text\" id =\"DienGiai_"+(lastRow)+"\" style=\"width:99%;text-align:left\" value=\""+DienGiai+"\" /></td>";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"PhatSinhNo_"+(lastRow)+"\" onchange=\"getFormatSoTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" /></td>	"; 
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"ThanhTien_"+(lastRow)+"\" readonly=\"readonly\" value=\""+ThanhTien+"\"  onclick=\"TinhThanhTien('"+(lastRow)+"')\" style=\"width:99%;text-align:right\"/></td>	";                                           
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
  CongTongTien(ThanhTien);
}
function kiemtrasounc(tenbang,tenfield,dieukien)
{   
    var tenbang="uy_nhiem_chi";
    var tenfield="so_unc";
    var dieukien=document.getElementById('txtMaUNC').value;      
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {               
            var value=xmlHttp.responseText;
            xacnhan(value);                                  
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrathongtinTable&tenbang="+tenbang+"&tenfield="+tenfield+"&dieukien="+dieukien+"&times="+Math.random(),false);
    xmlHttp.send(null);
}
function copynoidung()
{
    var ngaylapphieu=document.getElementById('txtNgayLapUNC').value;
    var maunc=document.getElementById('txtMaUNC').value;
    var mancc=document.getElementById('txtMaNCC').value;
    var tenncc=document.getElementById('txtTenNCC').value;    
    var nguoinhantien=document.getElementById('txtNguoiNhanTien').value;    
    var tkno=document.getElementById('txtTaiKhoanCo').value;    
    var tknganhang=document.getElementById('txtTaiKhoanNganHang').value;
    var nganhang=document.getElementById('txtNganHang').value;
    var diengiai=document.getElementById('txtDienGiai').value;           
    ResetDataOnTable();
    //document.getElementById('txtMaUNC').value=maunc
    document.getElementById('txtNgayLapUNC').value=ngaylapphieu;    
    document.getElementById('txtMaNCC').value=mancc;    
    document.getElementById('txtTenNCC').value=tenncc;    
    document.getElementById('txtNguoiNhanTien').value=nguoinhantien;    
    document.getElementById('txtTaiKhoanCo').value=tkno;    
    document.getElementById('txtTaiKhoanNganHang').value=nganhang;  
    document.getElementById('txtNganHang').value=nganhang;  
    document.getElementById('txtMaUNC').focus();
    document.getElementById('txtDienGiai').value = diengiai;
    document.getElementById('TongTien').value = "";
    
    alert('Copy nội dung thành công');
}
//=======================================================================================================
 </script>
 <form id="form1" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">   
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:menu_ketoannganhang1 ID="Menu_ketoannganhang2" runat="server" />
        </td>
    </tr>      
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr style="height:10px">
                    <td><div  class = "tdHeader">PHIẾU ỦY NHIỆM CHI</div></td>
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
                                                            <td class="tdLabel">Số ủy nhiệm chi : </td>
                                                            <td class="tdText"><input  id="txtMaUNC" type="text" runat="server" onblur="kiemtrasounc();" class="InputText" /><input type="hidden" id="hdUNC_ID" /></td>
                                                            
                                                            <td class="tdLabel" >Ngày lập :</td>
                                                            <td  class="tdText" ><input id="txtNgayLapUNC" onblur="ngayunc();"  runat="server" style="width:100px;"   type="text"/>&nbsp(dd/mm/yyyy)</td>
                                
                                                            <td class="tdLabel" >Chọn loại UNC :</td>
                                                            <td>  
                                                                <asp:dropdownlist id="ddlLoaiUNC" runat="server" >
                                                                    <asp:ListItem Selected="True" Value="0">UNC kh&#225;c</asp:ListItem>
                                                                    <asp:ListItem Value="1">UNC Theo HĐ</asp:ListItem>
                                                                </asp:dropdownlist>
                                                            </td>                                                                                                                                                                                  
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">Mã nhà cung cấp : </td>
                                                            <td class="tdText"><input id="txtMaNCC"  type="text" onfocus="ShowNhaCungCap(this)" onblur="kiemtramancc();" class="InputText" /><input type="hidden" id="hd_idBenhNhan" /></td>
                                                            
                                                            <td class="tdLabel">Tên nhà cung cấp: </td>
                                                            <td  class="tdText"><input id="txtTenNCC" type="text"  onfocus="ShowNhaCungCap(this)" class="InputText" /></td>
                                                            
                                                             <td class="tdLabel"> Người nhận tiền : </td>
                                                            <td  class="tdText"><input id="txtNguoiNhanTien" type="text" class="InputText" /></td>
                                                           
                                                        </tr>
                                                                                                       
                                                        <tr>
                                                            <td class="tdLabel">Tài khoản có: </td>
                                                            <td  class="tdText"><input id="txtTaiKhoanCo" type="text" class="InputText" onchange="TestMaTaiKhoan(this)" onfocus="ShowTaiKhoanNganHang(this)" /></td>
                                                            
                                                             <td class="tdLabel">TK ngân hàng: </td>
                                                            <td  class="tdText"><input id="txtTaiKhoanNganHang" type="text" class="InputText" /></td>
                                                            
                                                             <td class="tdLabel">Ngân hàng: </td>
                                                            <td  class="tdText"><input id="txtNganHang" type="text" class="InputText" /></td>
                                                            
                                                        </tr>
                                                        
                                                        
                                                        <tr>
                                                            <td class="tdLabel" style="height: 40px">Diễn giải : </td>
                                                            <td colspan="6"  class="tdText" style="height: 40px">
                                                                <textarea id="txtDienGiai" style="width:570px" cols="20"  rows="2"></textarea></td>
                                                            
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td colspan="6" style="text-align:center">                                                                
                                                                <input type="button" value="Lưu" id="bt_Luu" onclick="bt_Click(this)" style="width:100px" />
                                                                <input type="button" value="Làm mới" id="bt_LamLai" onclick="ResetDataOnTable()" style="width:100px" />
                                                                <input type="button" value="IN"  style="width:100px" id="bt_in" onclick="InUyNhiemChi()" />                                                                
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
              <td class ="tdHeader" colspan="14" >Chi tiết ủy nhiệm chi</td>
         </tr>
		<tr class="HeaderGidView">
		     <td class="HeaderColumn0_CK">STT</td>
		    <td class="HeaderColumn0_CK">Xóa</td>
		     <td class="HeaderColumn1_CK">
		    Mã NCC
		     </td>
		     <td class="HeaderColumn1_CK">
		    Tên nhà cung cấp
		     </td>
		     <td class="HeaderColumn1_CK">
		    TK nợ
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
		        Phát sinh nợ
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