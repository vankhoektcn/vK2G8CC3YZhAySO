<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTM_PhieuChiKhac.aspx.cs" Inherits="ketoan_KTTM_PhieuChiKhac" %>

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

<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_TienMat.ascx" TagName="menu_ketoantienmat" TagPrefix="uc1" %>
 <script language="javascript" type="text/javascript">    
    
 //========================Các hàm kiểm tra===================   
     var dp_cal;
  
	window.onload = function () 
	{
	    //dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtNgayLapPhieuChi'));
	    	
	   //  ShowTableChiTietPhieuThu();
	   //TaoMaSoHoaDon();	   
	     var queryString = "";
	    queryString =  window.location.search.substring(1).split('&');	    	    
	    if(queryString!="" && queryString!='dkmenu=kttienmat')
	    {
	        var idPhieuChi = queryString[0].split('=');
	        var SoPC = queryString[1].split('=');
	        //var MaNCC = queryString[2].split('=');
	        
	        if(document.getElementById('bt_Luu').value =="Lưu")
            {
                document.getElementById('bt_Luu').value = "Sửa";        
            }
	        LoadPhieuChi(idPhieuChi[1]);
	      
	    }
	    //document.getElementById('txtMaPC').focus();
	};
function bt_Click(Ctr)
{
    var ngaylap_ct=document.getElementById('txtNgayLapPhieuChi').value;
    kiemtrangaykhoaso(ngaylap_ct,Ctr.id);      
}	
function kiemtrangaykhoaso(ngaylap_ct,Ctr)
{     
    var sophieu=document.getElementById('txtMaPC').value;    
    var tDay=new Date();
    var tYear=tDay.getFullYear();      
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {
            var value=xmlHttp.responseText; 
            if(value==1)
                alert('Ngày lập phiếu chi phải lớn hơn ngày khóa sổ!');
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
//                    {       
//                        if(tYear <= 2012 )               
//                            TaoMaSoHoaDon2012(); 
//                        else
//                            TaoMaSoHoaDon();                
//                    }                                            
                    LuuPhieuChi(Ctr);
                    themnhacungcap();       
                }    
           }                                
         }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrangaykhoaso&ngaylap_ct="+ngaylap_ct+"&times="+Math.random(),true)    
    xmlHttp.send(null);      
}
function TaoMaSoHoaDon()
{       
       var Table = "Phieu_Chi";
       var manghiepvu = "PHIEU_CHI";
       var Column = "so_phieu_chi";
       var ngaylap=document.getElementById('txtNgayLapPhieuChi').value;
       xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;                    
                      if (value!="")
                      {                         
                        document.getElementById('txtMaPC').value = value;  
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TaoMaSoTuDong&Table="+Table+"&manghiepvu="+manghiepvu+"&Column="+Column+"&ngaylap="+ngaylap+"&times="+Math.random(),false);
            xmlHttp.send(null);
}

function TaoMaSoHoaDon2012()
{       
       var Table = "Phieu_Chi";
       var manghiepvu = "PHIEU_CHI";
       var Column = "so_phieu_chi";
       var ngaylap=document.getElementById('txtNgayLapPhieuChi').value;
       xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;                    
                      if (value!="")
                      {                         
                        document.getElementById('txtMaPC').value = value;  
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TaoMaSoTuDong_minhduc&Table="+Table+"&manghiepvu="+manghiepvu+"&Column="+Column+"&ngaylap="+ngaylap+"&times="+Math.random(),false);
            xmlHttp.send(null);
}
function LoadPhieuChi(idPhieuChi)
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
                    for(i=1;i<Row.length;i++)
                    {
                        var Column = Row[i].split('&');
                       //phieu_chi_id(0),so_phieu_chi(1),ngay_chi(2),ma_ncc(3),tennnc(4),dien_giai(5),tk_co(6),tien(7),nguoigiao(8)
                        ShowPhieuChi(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7],Column[8],Column[9],Column[10],Column[11]);                        
                    }                    
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=LoadPhieuChiByIDPhieuChi&idPhieuChi="+idPhieuChi+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function ShowPhieuChi(PhieuChiID,SoPhieuChi,NgayChi,MaNCC,TenNCC,DienGiai,TKCo,Tien,NguoiGiao,soctgoc,chungtugoc,diachi)
{
    ResetTableDSPhieuThu();
    document.getElementById('txtMaNCC').value= MaNCC;
    document.getElementById('txtTenNCC').value=TenNCC;
    document.getElementById('txtMaPC').value=SoPhieuChi;
    document.getElementById('hdPhieuChiID').value=PhieuChiID;
    
    document.getElementById('txtTaiKhoanCo').value=TKCo;
    document.getElementById('txtDienGiai').value=DienGiai;
    document.getElementById('txtNgayLapPhieuChi').value=NgayChi;
    document.getElementById('txtnguoigiaotien').value=NguoiGiao;
    document.getElementById('txtdiachi').value=diachi;
    document.getElementById('txtsoctgoc').value=soctgoc;
    document.getElementById('txtchungtugoc').value=chungtugoc;
    LoadChiTietPhieuChiBySoPhieuChi(SoPhieuChi);
}
function LoadChiTietPhieuChiBySoPhieuChi(SoPhieuChi)
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
                       //phieu_chi_ct_id(0),tk_no(1),ps_no(2),tk_thue(3),tien_thue(4),so_hd(5),so_seri(6),ngay_lap_hd(7),dien_giai(8),ThueSuat(9)
                        ShowChiTieTPhieuChi(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7],Column[8],Column[9]);
                        j++;
                    }                    
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=ChiTietPhieuChiKhacBySoPhieuChi&SoPhieuChi="+SoPhieuChi+"&times="+Math.random(),false);
        xmlHttp.send(null);
}
function ShowChiTieTPhieuChi(PhieuChiID,TKNo,PSNo,TKThue,TienThue,SoHD,SoSeri,NgayLapHD,DienGiai,ThueSuat)
{
        if(NgayLapHD=="01/01/1900")
            NgayLapHD="";
       var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
                     
            shtml += "		<td class=\"Column0\" style=\"width:50px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\" style=\"width:50px\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/></td>";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"TaiKhoanNo_"+(lastRow)+"\"  value=\""+TKNo+"\" onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoHD_"+(lastRow)+"\"  value=\""+SoHD+"\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoSeri_"+(lastRow)+"\"  value=\""+SoSeri+"\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"NgayLapHD_"+(lastRow)+"\"  value=\""+NgayLapHD+"\" onchange=\"TestDate(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml +="       <td class=\"Column3_CK\"><input type=\"text\" id =\"DienGiai_"+(lastRow)+"\"  value=\""+DienGiai+"\" style=\"width:99%;text-align:left\" /></td>";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"PhatSinhNo_"+(lastRow)+"\"  value=\""+FormatSoTien(PSNo)+"\" onchange=\"getFormatSoTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" /></td>	"; 
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"ThueSuat_"+(lastRow)+"\"  value=\""+ThueSuat+"\" onkeyup=\"TestNumberofInput(this)\" onchange=\"TinhThanhTien(this)\"  style=\"width:99%;text-align:right\" /></td>	"; 
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"TienThue_"+(lastRow)+"\"  value=\""+FormatSoTien(TienThue)+"\" onchange=\"getFormatSoTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" /></td>	"; 
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"TaiKhoanThue_"+(lastRow)+"\"  value=\""+TKThue+"\" onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"ThanhTien_"+(lastRow)+"\"   readonly=\"readonly\"  style=\"width:99%;text-align:right\"/></td>	";
                                         
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
      TinhThanhTien_IDRow(lastRow);
      
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
    if(document.getElementById('bt_Luu').value =="Sửa")
    {
        document.getElementById('bt_Luu').value = "Lưu";        
    }
    //document.getElementById('txtMaPC').focus();
    document.getElementById('txtMaNCC').value="";
    document.getElementById('txtTenNCC').value="";
    document.getElementById('txtMaPC').value="";
     document.getElementById('txtdiachi').value="";
    document.getElementById('hdPhieuChiID').value="";
    
    document.getElementById('txtTaiKhoanCo').value="";
    document.getElementById('txtDienGiai').value="";
    document.getElementById('txtNgayLapPhieuChi').value="";
    document.getElementById('txtnguoigiaotien').value="";
    document.getElementById('txtNgayLapPhieuChi').focus();
    ResetTableDSPhieuThu();                            
    //TaoMaSoHoaDon();
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
TongTien = 0;
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
                                                             //   document.getElementById(obj).blur();
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
      
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachNhaCungCap&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:300,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    setChonNCC(data[2],data[3],data[4],data[5],data[6]);
                                                                  //  document.getElementById(obj).blur();                                                                 
                                                                }
                                                            ); 
    
}

function setChonNCC(idNCC,MaNCC,TenNCC,nguoilienhe,diachi)
{
      
      var txtMaNCC=document.getElementById('txtMaNCC');
      var txtTenNCC=document.getElementById('txtTenNCC');
     
      txtMaNCC.value=MaNCC;
      txtTenNCC.value = TenNCC;
      document.getElementById('txtnguoigiaotien').value=nguoilienhe;
      document.getElementById('txtdiachi').value=diachi;
     
      //alert(hd_IDBN.value);
      document.getElementById('txtTenNCC').focus();
}



function ThemDong()
{ 
    var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td class=\"Column0\" style=\"width:50px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\" style=\"width:50px\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/></td>";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"TaiKhoanNo_"+(lastRow)+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoHD_"+(lastRow)+"\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoSeri_"+(lastRow)+"\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"NgayLapHD_"+(lastRow)+"\" onchange=\"TestDate(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml +="       <td class=\"Column3_CK\"><input type=\"text\" id =\"DienGiai_"+(lastRow)+"\" style=\"width:99%;text-align:left\" /></td>";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"PhatSinhNo_"+(lastRow)+"\" onchange=\"getFormatSoTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" /></td>	"; 
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"ThueSuat_"+(lastRow)+"\" onkeyup=\"TestNumberofInput(this)\" onchange=\"TinhThanhTien(this)\"  style=\"width:99%;text-align:right\" /></td>	"; 
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"TienThue_"+(lastRow)+"\" onchange=\"getFormatSoTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" /></td>	"; 
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"TaiKhoanThue_"+(lastRow)+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"ThanhTien_"+(lastRow)+"\" readonly=\"readonly\"  onclick=\"TinhThanhTien(this)\" style=\"width:99%;text-align:right\"/></td>	";                       
                    
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
                // UpdateRowOfTable();                               
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
             TableDanhSach.rows[i].cells[2].getElementsByTagName("input")[0].id = "TaiKhoanNo_"+i;
             TableDanhSach.rows[i].cells[3].getElementsByTagName("input")[0].id = "SoHD_"+i;
             TableDanhSach.rows[i].cells[4].getElementsByTagName("input")[0].id = "SoSeri_"+i;
             TableDanhSach.rows[i].cells[5].getElementsByTagName("input")[0].id = "NgayLapHD_"+i;
             TableDanhSach.rows[i].cells[6].getElementsByTagName("input")[0].id = "DienGiai_"+i;
             TableDanhSach.rows[i].cells[7].getElementsByTagName("input")[0].id = "PhatSinhNo_"+i;
             TableDanhSach.rows[i].cells[8].getElementsByTagName("input")[0].id = "ThueSuat_"+i;
             
             TableDanhSach.rows[i].cells[9].getElementsByTagName("input")[0].id = "TienThue_"+i;
             TableDanhSach.rows[i].cells[10].getElementsByTagName("input")[0].id = "TaiKhoanThue_"+i;
             TableDanhSach.rows[i].cells[11].getElementsByTagName("input")[0].id = "ThanhTien_"+i;
             
        }
      }
        TinhTongTien();
}
//================================================================================================================
function TinhThanhTien_IDRow(RowID)
{   
    var idPhatSinhNo = "PhatSinhNo_"+RowID;
    var valuePhatSinhNo = document.getElementById(idPhatSinhNo).value;
    
    var idThue = "ThueSuat_"+RowID;
    var valueThue = document.getElementById(idThue).value;
    
    var idTienThue = "TienThue_"+RowID;
    var TienThue = document.getElementById(idTienThue);
    TienThue.value = FormatSoTien(Math.round(eval(ChangeFormatCurrency(valuePhatSinhNo)) * eval(ChangeFormatCurrency(valueThue))/100));
    
    var idThanhTien = "ThanhTien_"+RowID;
    valueThanhTien = eval(ChangeFormatCurrency(valuePhatSinhNo)) + eval(ChangeFormatCurrency(TienThue.value));
    document.getElementById(idThanhTien).value = FormatSoTien(valueThanhTien);
   // CongTongTien(valueThanhTien);
   TinhTongTien();
}

function TinhThanhTien(Ctr)
{
    var IDCtr = Ctr.id;
    var RowID = IDCtr.split('_')[1];
    var idPhatSinhNo = "PhatSinhNo_"+RowID;
    var valuePhatSinhNo = document.getElementById(idPhatSinhNo).value;
    
    var idThue = "ThueSuat_"+RowID;
    var valueThue = document.getElementById(idThue).value;
    
    var idTienThue = "TienThue_"+RowID;
    var TienThue = document.getElementById(idTienThue);
    TienThue.value = FormatSoTien(eval(ChangeFormatCurrency(valuePhatSinhNo)) * eval(ChangeFormatCurrency(valueThue))/100);
    
    var idThanhTien = "ThanhTien_"+RowID;
    valueThanhTien = eval(ChangeFormatCurrency(valuePhatSinhNo)) + eval(ChangeFormatCurrency(TienThue.value));
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
//================================================================================================================
//=============================================Lưu phiếu chi khác=================================================
//================================================================================================================
function LuuPhieuChi(Ctr)
{   
    Ctr.disabled  = true;
    document.getElementById('message').style.visibility = "visible";
    var PhieuChiID = document.getElementById('hdPhieuChiID').value;
    var SoPhieuChi = document.getElementById('txtMaPC').value;
    var NgayChi = document.getElementById('txtNgayLapPhieuChi').value;
    var MaNCC = document.getElementById('txtMaNCC').value;
    var NguoiGiao = document.getElementById('txtnguoigiaotien').value;
    var DienGiai = document.getElementById('txtDienGiai').value;
    var TKCo = document.getElementById('txtTaiKhoanCo').value;
    var TongTien = document.getElementById('TongTien').value;
    var soctgoc = document.getElementById('txtsoctgoc').value;
    var chungtugoc = document.getElementById('txtchungtugoc').value;
    var UserDau = "Tăng Thúy Ngọc";
    var UserCuoi = "CyberTang";
    var Status = 0;
//    if(SoPhieuChi=="")
//    {
//        alert("Chưa nhập số phiếu chi. Vui lòng kiểm tra lại, cảm ơn!");
//        Ctr.disabled = false;
//        document.getElementById('message').style.visibility = "hidden";
//    }
//    else
    if(NgayChi=="")
    {
        alert("Chưa chọn ngày chi. Vui lòng kiểm tra lại, cảm ơn!");
        Ctr.disabled = false;
          document.getElementById('message').style.visibility = "hidden";
    }
    else    
    if(TKCo=="")
    {
        alert("Chưa chọn tài khoản có. Vui lòng kiểm tra lại, cảm ơn!");
        Ctr.disabled = false;
          document.getElementById('message').style.visibility = "hidden";
    }
     else
    if(TongTien=="")
    {
        alert("Chưa có tổng tiền. Vui lòng kiểm tra lại, cảm ơn!");
        Ctr.disabled = false;
          document.getElementById('message').style.visibility = "hidden";
    }
    else
        getFunctionLuuPhieuChi(Ctr,PhieuChiID,SoPhieuChi,NgayChi,MaNCC,NguoiGiao,DienGiai,TKCo,ChangeFormatCurrency(TongTien),UserDau,UserCuoi,Status,soctgoc,chungtugoc);
}
function getFunctionLuuPhieuChi(Ctr,PhieuChiID,SoPhieuChi,NgayChi,MaNCC,NguoiGiao,DienGiai,TKCo,TongTien,UserDau,UserCuoi,Status,soctgoc,chungtugoc)
{
     xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;                    
                      if (value=="1")
                      {  
                        XoaChiTietPhieuChi(Ctr,SoPhieuChi);                      
                      }
                      else
                      {
                            alert("Lưu phiếu chi thất bại!");
                       }
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=LuuPhieuChi&PhieuChiID="+PhieuChiID+"&SoPhieuChi="+SoPhieuChi+"&NgayChi="+NgayChi+"&MaNCC="+MaNCC+"&NguoiGiao="+encodeURIComponent(NguoiGiao)+"&DienGiai="+encodeURIComponent(DienGiai)+"&TKCo="+TKCo+"&TongTien="+TongTien+"&UserDau="+encodeURIComponent(UserDau)+"&UserCuoi="+encodeURIComponent(UserCuoi)+"&soctgoc="+soctgoc+"&chungtugoc="+encodeURIComponent(chungtugoc)+"&Status="+Status+"&times="+Math.random(),false);
            xmlHttp.send(null);
}
//================================================================================================================
//=============================================Lưu chi tiết phiếu chi khác=================================================
//================================================================================================================
function XoaPhieuChi(SoPhieuChi)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {                         
                      }                      
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=spPhieu_Chi_fault_Delete&SoPhieuChi="+SoPhieuChi+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function XoaChiTietPhieuChi(Ctr,SoPhieuChi)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;                     
                    XoaSoCai_PhieuChi(Ctr,SoPhieuChi);  
                                 
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=XoaChiTietPhieuChi&SoPhieuChi="+SoPhieuChi+"&times="+Math.random(),false);
            xmlHttp.send(null);
}
function XoaSoCai_PhieuChi(Ctr,SoPhieuChi)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;                   
                    LuuChiTietPhieuChiKhac(Ctr);                    
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=XoaSoCai_PhieuChi&SoPhieuChi="+SoPhieuChi+"&times="+Math.random(),false);
            xmlHttp.send(null);
}
function LuuChiTietPhieuChiKhac(Ctr)
{     
     var PhieuChiID = document.getElementById('txtMaPC').value;
     var SoPhieuChi = document.getElementById('txtMaPC').value;  
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var x;
    var rs = 1;
    var valueTkNo ="";
    var valuePhatSinhNo ="";
    var valueThueSuat="";
    var valueTKThue ="";
    var valueTienThue="";
    var valueSoHD="";
    var valueSoSeri="";
    var valueNgayLapHD="";
    var valueDienGiai="";
    var flag = false;
    if(Row>2)
    {
        for(var i=2;i<Row;i++)
        {             
                var TKNo = "TaiKhoanNo_"+i;
                var PhatSinhNo = "PhatSinhNo_"+i;
                var ThueSuat = "ThueSuat_"+i;
                var SoSeri = "SoSeri_"+i;
                var TKThue = "TaiKhoanThue_"+i;
                var TienThue = "TienThue_"+i;
                var SoHD = "SoHD_"+i;
                var NgayLapHD = "NgayLapHD_"+i;
                var DienGiai = "DienGiai_"+i;
             if(document.getElementById(TKNo).value=="")
             {
                alert("Chưa nhập tài khoản nợ. Vui lòng kiểm tra lại. Nếu không dùng dòng này vui lòng xóa đi cảm ơn!");
                 //XoaPhieuChi(SoPhieuChi);
                 document.getElementById('message').style.visibility = "hidden";
                Ctr.disabled = false;
                 //XoaPhieuChi(SoPhieuChi);                
             }
             else
             if(document.getElementById(PhatSinhNo).value=="")
             {
                alert("Chưa có phát sinh nợ. Vui lòng kiểm tra lại, cảm ơn!");
                document.getElementById('message').style.visibility = "hidden";
                Ctr.disabled = false;
                 //XoaPhieuChi(SoPhieuChi);
             }             
             else
             {
               flag= true;
                 valueTkNo +=";"+ document.getElementById(TKNo).value;
                                 
                 var PSNo = document.getElementById(PhatSinhNo).value;
                 valuePhatSinhNo +=";"+ ChangeFormatCurrency(PSNo);
                               
                 valueThueSuat +=";"+ document.getElementById(ThueSuat).value;
                                 
                 valueTKThue +=";"+ document.getElementById(TKThue).value;
                                 
                 var tien_thue  = document.getElementById(TienThue).value;
                 valueTienThue +=";"+ ChangeFormatCurrency(tien_thue);
                                 
                 valueSoHD +=";"+ document.getElementById(SoHD).value;
                                
                 valueSoSeri +=";"+ document.getElementById(SoSeri).value;
                             
                 valueNgayLapHD +=";"+ document.getElementById(NgayLapHD).value;
                 
                 var valueTienTrenHD = "0";
                                  
                  valueDienGiai +=";"+ document.getElementById(DienGiai).value;
                 var Status = 0;             
             }           
        }
        if(flag)
        {
             getFunctionLuuChiTietPhieuChi(Ctr,SoPhieuChi,valueTkNo,valuePhatSinhNo,valueThueSuat,valueTKThue,valueTienThue,valueSoHD,valueSoSeri,valueNgayLapHD,valueTienTrenHD,valueDienGiai,Status);
        }
         else
         {
             alert("Chưa có chi tiết phiếu thu.Vui lòng kiểm tra lại, cảm ơn!");
            document.getElementById('message').style.visibility = "hidden";
            Ctr.disabled = false;
            XoaPhieuChi(SoPhieuChi);
         }    
     }
     else
     {
        alert("Chưa có chi tiết phiếu thu.Vui lòng kiểm tra lại, cảm ơn!");
        document.getElementById('message').style.visibility = "hidden";
        Ctr.disabled = false;
        XoaPhieuChi(SoPhieuChi);
     }
}
function getFunctionLuuChiTietPhieuChi(Ctr,SoPhieuChi,TKNo,PhatSinhNo,ThueSuat,TKThue,TienThue,SoHD,SoSeri,NgayLapHD,TienTrenHD,DienGiai,Status)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                   
                      if (value=="1")
                      {                          
                        LuuSoCai_PhieuChiKhac(Ctr,TKNo,TKThue,PhatSinhNo,DienGiai,TienThue,SoHD,SoSeri,NgayLapHD);       
                      }
                      else
                      {                      
                         alert("Lưu chi tiết phiếu chi thất bại!");
                         document.getElementById('message').style.visibility = "hidden";
                         Ctr.disabled = false;
                         XoaPhieuChi(SoPhieuChi);
                      }                     
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=LuuChiTietPhieuChi&SoPhieuChi="+SoPhieuChi+"&TKNo="+TKNo+"&PhatSinhNo="+PhatSinhNo+"&ThueSuat="+ThueSuat+"&TKThue="+TKThue+"&TienThue="+TienThue+"&DienGiai="+encodeURIComponent(DienGiai)+"&SoHD="+SoHD+"&SoSeri="+SoSeri+"&NgayLapHD="+NgayLapHD+"&TienTrenHD="+TienTrenHD+"&Status="+Status+"&times="+Math.random(),false);
            xmlHttp.send(null);
}
function LuuSoCai_PhieuChiKhac(Ctr,TKNo,TKThue,PhatSinhNo,DienGiai,TienThue,SoHD,SoSeri,NgayLapHD)
{    
    var SoPhieuChi = document.getElementById('txtMaPC').value;
    var NgayChi = document.getElementById('txtNgayLapPhieuChi').value;
    var MaNCC = document.getElementById('txtMaNCC').value;
    var dien_giai = document.getElementById('txtDienGiai').value;    
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
                        alert("Lưu  phiếu chi khác thành công!");
                        ResetTableDSPhieuThu();
                        LoadChiTietPhieuChiBySoPhieuChi(SoPhieuChi);      
                        document.getElementById('bt_Luu').value ="Sửa";
                    }
                    else
                    {
                        alert("Lưu phiếu chi khác thất bại!");
                        XoaPhieuChi(SoPhieuChi);
                    }
                    Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";                                            
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=LuuSoCai_PhieuChiKhac&SoPhieuChi="+SoPhieuChi+"&NgayChi="+NgayChi+"&MaNCC="+MaNCC+"&TKCo="+TKCo+"&TKNo="+TKNo+"&PhatSinhNo="+PhatSinhNo+"&TKThue="+TKThue+"&TienThue="+TienThue+"&DienGiai="+encodeURIComponent(DienGiai)+"&SoHD="+SoHD+"&SoSeri="+SoSeri+"&NgayLapHD="+NgayLapHD+"&UserDau="+UserDau+"&UserCuoi"+UserCuoi+"&times="+Math.random(),false);
            xmlHttp.send(null);
}
function In_phieu_chi()
{
    var sophieuchi=document.getElementById('txtMaPC').value;
    var ngaychi =document.getElementById ('txtNgayLapPhieuChi').value;
    var soctgoc=document.getElementById('txtsoctgoc').value;
    var chungtugoc=document.getElementById('txtchungtugoc').value;
    if(ngaychi=="")
    {
        alert('Chưa có ngày lập phiếu chi, xin nhập vào!');
    }
    else
        window.open("KTTM_rptPhieu_Chi.aspx?so_phieu_chi=" + sophieuchi + "&ngay_chi=" + ngaychi+"&soctgoc="+soctgoc+"&chungtugoc="+chungtugoc);
}

function kiemtramaphieuchi()
{
   
    var tenbang="phieu_chi";
    var tenfield="so_phieu_chi";
    var dieukien=document.getElementById('txtMaPC').value;       
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {            
            var value=xmlHttp.responseText;
            if (value==1)
            {
                alert('Số phiếu chi này đã có, xin nhập lại số khác!');
                document.getElementById('txtMaPC').focus();
            }            
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrathongtinTable&tenbang="+tenbang+"&tenfield="+tenfield+"&dieukien="+dieukien,"&times="+Math.random(),true);
    xmlHttp.send(null);    
}
function ngaychi()
{
    dinhdangngay(document.getElementById('txtNgayLapPhieuChi'));
}
//ham kiem tra ma khach hang da co hay chua
function kiemtramancc()
{
    var tenbang="nhacungcap";
    var tenfield="manhacungcap";    
    var dieukien=document.getElementById('txtMaNCC').value;  
    var kq;  
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {               
            var value=xmlHttp.responseText;                       
            xacnhan(value);
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrathongtinTable&tenbang="+tenbang+"&tenfield="+tenfield+"&dieukien="+encodeURIComponent(dieukien)+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
function xacnhan(kq)
{
    if (kq==0)
    {
        if (confirm('Mã nhà cung cấp này chưa có!Bạn muốn thêm mới không?'))
            {                    
              document.getElementById('txtTenNCC').focus();                               
            }           
        else
            document.getElementById('txtnguoigiaotien').focus();            
     }
}
function themnhacungcap()
{
    var mancc=document.getElementById('txtMaNCC').value;
    var tenncc=document.getElementById('txtTenNCC').value;
    var nguoilienhe=document.getElementById('txtnguoigiaotien').value;
    var nganhang="";
    var tknganhang="";
    var diachi=document.getElementById('txtdiachi').value;  
    xmlHttp=GetMSXmlHttp();
    xmlHttp.open("GET","ajax.aspx?do=themnhacungcap&mancc="+mancc+"&tenncc="+encodeURIComponent(tenncc)+"&diachi="+encodeURIComponent(diachi)+"&nguoilienhe="+encodeURIComponent(nguoilienhe)+"&nganhang="+encodeURIComponent(nganhang)+"&tknganhang="+tknganhang+"&times="+Math.random(),true);
    xmlHttp.send(null);    
}
function copynoidung()
{
    var ngaylapphieu=document.getElementById('txtNgayLapPhieuChi').value;
    var makh=document.getElementById('txtMaNCC').value;
    var tenkh=document.getElementById('txtTenNCC').value;    
    var nguoimua=document.getElementById('txtnguoigiaotien').value;
    var diachi=document.getElementById('txtdiachi').value;
    var tkno=document.getElementById('txtTaiKhoanCo').value;    
    var diengiai=document.getElementById('txtDienGiai').value;           
    ResetDataOnTable();
    document.getElementById('txtMaPC').value='PC-';
    document.getElementById('txtNgayLapPhieuChi').value=ngaylapphieu;    
    document.getElementById('txtMaNCC').value=makh;    
    document.getElementById('txtTenNCC').value=tenkh;    
    document.getElementById('txtnguoigiaotien').value=nguoimua;
    document.getElementById('txtdiachi').value=diachi;
    document.getElementById('txtTaiKhoanCo').value=tkno;    
    document.getElementById('txtMaPC').focus();
    document.getElementById('txtDienGiai').value = diengiai;
    alert('Copy nội dung thành công');
}
</script>
<form id="form1" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:menu_ketoantienmat ID="menu_ketoantienmat1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr style="height:10px">
                    <td><div  class = "tdHeader">PHIẾU CHI KHÁC</div></td>
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
                                                            <td class="tdLabel">Mã phiếu chi : </td>
                                                            <td class="tdText"><input  id="txtMaPC"  type="text"  onblur="kiemtramaphieuchi()" class="InputText" /><input type="hidden" id="hdPhieuChiID" /></td>
                                                            
                                                            <td class="tdLabel" >Ngày lập PC:</td>
                                                            <td  class="tdText" ><input id="txtNgayLapPhieuChi"  runat="server" onblur="ngaychi();" style="width:100px;"   type="text"/>&nbsp (dd/mm/yyyy)</td>                                                                                                                      
                                                            
                                                            <td class="tdLabel">Mã nhà cung cấp : </td>
                                                            <td class="tdText"><input id="txtMaNCC"  type="text" onfocus="ShowNhaCungCap(this)" onblur="kiemtramancc()" class="InputText" /><input type="hidden" id="hd_idBenhNhan" /></td>

                                                        </tr>
                                                        <tr>                                                                                                                        
                                                            <td class="tdLabel">Tên nhà cung cấp: </td>
                                                            <td  class="tdText"><input id="txtTenNCC" type="text"  onfocus="ShowNhaCungCap(this)" class="InputText" /></td>
                                                            
                                                             <td class="tdLabel"> Địa chỉ : </td>
                                                            <td  class="tdText"><input id="txtdiachi" type="text" class="InputText" /></td>
                                                           
                                                           <td class="tdLabel"> Người giao tiền : </td>
                                                            <td  class="tdText"><input id="txtnguoigiaotien" type="text" class="InputText" /></td>

                                                        </tr>
                                                                                                       
                                                        <tr>
                                                            
                                                            <td class="tdLabel">Tài khoản có: </td>
                                                            <td  class="tdText"><input id="txtTaiKhoanCo" type="text" class="InputText" onchange="TestMaTaiKhoan(this)" onfocus="ShowTaiKhoan(this)" /></td>
                                                            
                                                            <td class="tdLabel"> Số CT gốc: </td>
                                                            <td  class="tdText"><input id="txtsoctgoc" style="width:50px" type="text" class="InputText" /></td>
                                                            
                                                            <td class="tdLabel"> Chứng từ gốc : </td>
                                                            <td  class="tdText"><input id="txtchungtugoc" type="text" class="InputText" /></td>
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
                                                                <input type="button" value="IN"  style="width:100px" id="bt_in" onclick="In_phieu_chi()" />
                                                                <input type="button" value="Copy"  style="width:100px" id="copy" onclick="copynoidung();" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="9" style="text-align:center">
                                                                <label id="message"  style="display:none" > Đang xử lý vui lòng chờ trong giây lát....</label>
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
              <td class ="tdHeader" colspan="12" >Chi tiết phiếu chi khác</td>
         </tr>
		<tr class="HeaderGidView">
		     <td class="HeaderColumn0_CK">STT</td>
		    <td class="HeaderColumn0_CK">Xóa</td>
		    
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