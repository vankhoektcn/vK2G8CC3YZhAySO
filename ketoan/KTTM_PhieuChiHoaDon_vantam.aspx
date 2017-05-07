<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTM_PhieuChiHoaDon_vantam.aspx.cs" Inherits="ketoan_KTTM_PhieuChiHoaDon" %>


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
<script type="text/javascript" src="../ketoan/js_KeToan/scriptoflong.js"></script>
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
     var TongTien = 0;
	window.onload = function () 
	{
	    document.getElementById('txtMaPT').disable=true;	    
	    document.getElementById('txtNgayLapPhieuThu').focus();	    
	    phanquyen();   	    
	    //dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtNgayLapPhieuThu'));		    
	    var queryString = "";
	    queryString =  window.location.search.substring(1).split('&');
	    if(queryString!="" && queryString!="dkmenu=kttienmat")
	    {
	        if(queryString.length<1)
	            return;
	        var idPhieuThu = queryString[0].split('=');
	        var SoPT = queryString[1].split('=');
	        //var MaKH = queryString[2].split('=');  
	        if(idPhieuThu[1]!="")
	        {	           
	             DanhSachPhieuThuOfKhachHang(idPhieuThu[1]);
	             document.getElementById('bt_Luu').value="Sửa";
	        }
	        PageLoadNgoaiTe();
	        
	    }
	};
	function phanquyen() 
	{
	    var quyenthem = '<%=StaticData.HavePermision(this.Page, "KeToanTM_KTTM_PhieuChiHoaDon_Them")%>';
        var quyensua = '<%=StaticData.HavePermision(this.Page, "KeToanTM_KTTM_PhieuChiHoaDon_Sua")%>';
        var quyenxoa = '<%=StaticData.HavePermision(this.Page, "KeToanTM_KTTM_PhieuChiHoaDon_Xoa")%>';
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
	function PageLoadNgoaiTe()
    {
          xmlHttp = GetMSXmlHttp();
                xmlHttp.onreadystatechange = function()
                {
                    if(xmlHttp.readyState == 4)
                    {
                        var value = xmlHttp.responseText;
                          if (value!="")
                          {                             
                            var data = value.split('|');
                            document.getElementById('txtNgoaiTeID').value = data[0];                           
                            document.getElementById('txtNgoaiTe').value = data[1];                             
                            document.getElementById('txtTiGia').value = data[2];  
                          }
                    }
                }
                xmlHttp.open("GET","ajax.aspx?do=PageLoadNgoaiTe&times="+Math.random(),true);
                xmlHttp.send(null);
    }
function TaoMaSoHoaDon()
{
       var Table = "Phieu_Chi";
       var manghiepvu = "PHIEU_CHI";
       var Column = "so_phieu_chi";
       var ngaylap=document.getElementById('txtNgayLapPhieuThu').value;
       xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="")
                      {  
                        document.getElementById('txtMaPT').value = value;  
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TaoMaSoTuDong&Table="+Table+"&manghiepvu="+manghiepvu+"&Column="+Column+"&ngaylap="+ngaylap+"&times="+Math.random(),false);
            xmlHttp.send(null);
}
function NgoaiTeSearch(obj)
{
    $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=ngoaitesearch",
                                                    {width:350,scroll:true,formatItem:function(data)
                                                        {return data[0];}
                                                    }
                                                ).result(
                                                            function(event,data)
                                                            {
                                                                document.getElementById('txtTiGia').value=data[2];
                                                                document.getElementById('txtNgoaiTeID').value=data[1];
                                                                //$("#txtTiGia").val("123");
                                                                //document.getElementById('txtTiGia').value=data[0];
                                                                //alert(data[0]);
                                                            }
                                                        );           
}
function QuyDoiNgoaiTe()
{
    if($("#txtTiGia").val() != "")
    for(var i=2;i<document.getElementById("TableDanhSach").rows.length;i++)
    {
        var tongtien=document.getElementById("TableDanhSach").rows[i].cells[7].getElementsByTagName("input")[0].value;
        var tongtienquydoi=tongtien.replace(/\$|\,/g,'')/$("#txtTiGia").val();
        document.getElementById("TableDanhSach").rows[i].cells[6].getElementsByTagName("input")[0].value = formatCurrency1(tongtienquydoi);
    }
}
function formatCurrency1(num){
            Number.prototype.formatMoney = function(c, d, t){
            var n = this, c = isNaN(c = Math.abs(c)) ? 2 : c, d = d == undefined ? "," : d, t = t == undefined ? "." : t, s = n < 0 ? "-" : "", i =  parseInt(n = Math.abs(+n || 0).toFixed(c)) + "", j = (j = i.length) > 3 ? j % 3 : 0;
               return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
             };
            return eval(num).formatMoney(2,'.',',');
}
function TestDate(t)
	{
		if (t.value != "")
		{
			t.value=AddString(t.value);
			if (isDate(t.value)==false)
			{
				t.value="";
				alert("Bạn nhập ngày tháng không hợp lệ ! ");
				t.focus();
			}
		}
		return;
	}
function FormatSoTien(obj)
{
	    return formatCurrency(obj);
}
function getFormatSoTien(Ctr)
{
        return formatCurrency(Ctr.value);
}
function CheckAll(Ctr)
{
    var CheckedValue;
    
    for(i = 0;i<Ctr.childNodes.length;i++)
    {
        if(Ctr.childNodes[i].tagName!=undefined&&Ctr.childNodes[i].tagName.toLowerCase()=="input"&&Ctr.childNodes[i].type.toLowerCase()=="checkbox")
        {
            CheckedValue = Ctr.childNodes[i].checked;
            break;
        }
    }
     
    var parentNode_table = Ctr.parentNode.parentNode;
    for(j=2;j<parentNode_table.childNodes.length;j++)
    {
        var tr = parentNode_table.childNodes[j];
        for(k=0;k<tr.childNodes.length;k++)
        {
            td = tr.childNodes[k];
            if(td.id!=undefined&&td.id.toLowerCase()=="td_checkbox")
            {
                for(t=0;t<td.childNodes.length;t++)
                {
                    var CheckBox = td.childNodes[t];
                    if(CheckBox.type!=undefined&&CheckBox.type.toLowerCase()=="checkbox")
                    {
                        CheckBox.checked = CheckedValue;
                        break;
                    }
                }
            }
        }
    }
}

//==================Các hàm xử lý==============================
function ResetDataonTable()
{
    document.getElementById('txtMaNCC').value="";
    document.getElementById('txtTenNCC').value="";
    document.getElementById('txtMaPT').value="";
    
    document.getElementById('txtTaiKhoanCo').value="";
    document.getElementById('txtDienGiai').value="";
    document.getElementById('txtNgayLapPhieuThu').value="";
   
    ResetTableDSPhieuThu();       
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
    document.getElementById('TongTien').value= '0';
}
function Moi()
{
    ResetTableDSPhieuThu();
    document.getElementById('bt_LoadDSPT').style.visibility = "";
    document.getElementById('bt_LoadDSPT').disabled = false;
    window.open("KTTM_PhieuChiHoaDon.aspx","_self");
}
function ShowTaiKhoan(obj)
{
  
        $("#"+obj.id).unautocomplete().autocomplete("ajax.aspx?do=DanhSachTaiKhoan_Jquery&Key="+obj.value+"&obj="+obj,
                                                    {width:350,scroll:true,formatItem:function(data)
                                                        {return data[1];}
                                                    }
                                                ).result(
                                                            function(event,data)
                                                            {
                                                                //setChonTaiKhoan(data[2],obj);
                                                                obj.value = data[2];
                                                                obj.blur();
                                                            }
                                                        );           
}
function ShowKhachHang(obj)
{
        var objsrc = document.getElementById(obj);     
            $("#"+obj).unautocomplete().autocomplete("KTTM_PhieuChiHoaDon_Ajax.aspx?do=LoadDanhSachNhaCungCap&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:300,scroll:true,formatItem:function(data)
                                                            {return data[0];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    //setChonNCC(data[2],data[3],data[4]);
                                                                    document.getElementById('txtMaNCC').value = data[2];
                                                                    document.getElementById('txtTenNCC').value = data[3];
                                                                    document.getElementById('hd_idNCC').value = data[4];
                                                                    document.getElementById(obj).blur();
                                                                }
                                                            ); 
    
}

///=================================Load danh sách hóa đơn========================================================
function LoadDanhSachHoaDon()
{
    var MaNCC = document.getElementById('txtMaNCC').value;
    var TableDanhSach = document.getElementById('TableDanhSach');
    var lastRow = TableDanhSach.rows.length;
    if(lastRow>2)
        ResetTableDSPhieuThu();
    
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
                        ShowDanhSachHoaDon(data[0],data[1],data[2],data[3],data[4],data[5],data[6],data[7],0);
                    }
                  }
            }
        }
          xmlHttp.open("GET","KTTM_PhieuChiHoaDon_Ajax.aspx?do=LoadDanhSachHoaDonPhieuChi&MaNCC="+MaNCC+"&times="+Math.random(),true);
        xmlHttp.send(null);
   
}
function ShowDanhSachHoaDon(SoHD,TKNo,NgayLapHD,ThanhTien,NguyenTe,DienGiai,IdNhapVT,IdPhieuNhap,IDPhieuChiCT)
{
    var TableDanhSach = document.getElementById('TableDanhSach');
    var lastRow = TableDanhSach.rows.length;     
    var shtml = "<tr class=\"RowGidView\">";
       shtml += "		<td class=\"Column0\" style=\"width:20px;\"><input  type=\"text\" id=\"STT_" + (lastRow-1) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";            
            shtml += "		<td class=\"Column0\" style=\"width:50px\" id=\"td_checkbox\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow-1) + "\"/><input type=\"hidden\" id=\"IDPhieuChiCT_"+(lastRow-1)+"\" value=\""+IDPhieuChiCT+"\"/>"
                +"<input type=\"hidden\" id=\"IdNhapVT_"+(lastRow-1)+"\" value=\""+IdNhapVT+"\"/>"
                +"<input type=\"hidden\" id=\"IdPhieuNhap_"+(lastRow-1)+"\" value=\""+IdPhieuNhap+"\"/>"
            +"</td>";            
            shtml += "		<td class=\"Column1_TK\"><input type=\"text\" id=\"SoHD_"+(lastRow-1)+"\" value=\""+SoHD+"\"   style=\"width:90%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column1_TK\"><input type=\"text\" id=\"NgatLapHD_"+(lastRow-1)+"\" value=\""+NgayLapHD+"\"  style=\"width:90%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column1_TK\"><input type=\"text\" id=\"TaiKhoanNo_"+(lastRow-1)+"\" value=\""+TKNo+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:90%;text-align:center\"/></td>	";
            shtml +="       <td class=\"Column2_TK\"><input type=\"text\" id =\"DienGiai_"+(lastRow-1)+"\" value=\""+DienGiai+"\" style=\"width:90%;text-align:left\" /></td>";
            shtml += "		<td class=\"Column3\" id=\"txtNT_"+(lastRow-1)+"\"> <input id='txtNguyenTe' type=\"text\" class=\"InputTien\" readonly=\"readonly\" value=\""+formatCurrency1(1*NguyenTe)+"\" /></td>	"; 
            shtml += "		<td class=\"Column1_TK\"><input type=\"text\" id=\"txtTongTien_"+(lastRow-1)+"\" value=\""+formatCurrency1(ThanhTien)+"\" onchange=\"getFormatSoTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:200px;text-align:right\" /></td>	"; 
     shtml += "	</tr>";    
  $("#TableDanhSach:last").append(shtml);
  CongTongTien(ThanhTien);
}
//===============================================================
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
            
            var idCheckBox = "checkbox_"+i;
            var checkbox = document.getElementById(idCheckBox);
            if(checkbox.checked)
            {
                var count = Tien;
                var txtSoTien = "txtTongTien_"+i;
                var sotien =  document.getElementById(txtSoTien);
                Tien =  eval(count) + (eval(ChangeFormatCurrency(sotien.value)));
            }
        }
     }
     
    var txtTongTien = document.getElementById('TongTien');
    txtTongTien.value = FormatSoTien(Tien);
     
}

function CongTongTien(ThanhTien)
{
  
    var count = TongTien;
    TongTien =  eval(count) + (eval(ThanhTien));
    var txtTongTien = document.getElementById('TongTien');
    txtTongTien.value = FormatSoTien(TongTien);
     
}
function ThemDong()
{
     var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td class=\"Column0\" style=\"width:20px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\" style=\"width:50px\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/><input type=\"hidden\" id=\"IDPhieuChiCT_"+(lastRow)+"\"/></td>";
            shtml += "		<td class=\"Column1_TK\"><input type=\"text\" id=\"SoHD_"+(lastRow)+"\"   style=\"width:150px;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column1_TK\"><input type=\"text\" id=\"NgatLapHD_"+(lastRow)+"\"   style=\"width:150px;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column1_TK\"><input type=\"text\" id=\"TaiKhoanNo_"+(lastRow)+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:150px;text-align:center\"/></td>	";
            shtml +="       <td class=\"Column2_TK\"><input type=\"text\" id =\"DienGiai_"+(lastRow)+"\" style=\"width:350px;text-align:left\" /></td>";
            shtml += "		<td class=\"Column3\" id=\"txtNT_"+(lastRow)+"\"> <input id='txtNguyenTe' type=\"text\" class=\"InputTien\" style=\"width:150px;text-align:right\"  /></td>	"; 
            shtml += "		<td class=\"Column1_TK\"><input type=\"text\" id=\"txtTongTien_"+(lastRow)+"\" onchange=\"getFormatSoTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:200px;text-align:right\" /></td>	";
           
                    
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
//          shtml += "		<td class=\"Column0\" style=\"width:20px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
//            shtml += "		<td class=\"Column0\" style=\"width:50px\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/><input type=\"hidden\" id=\"IDPhieuChiCT_"+(lastRow)+"\"/></td>";
//            shtml += "		<td class=\"Column1_TK\"><input type=\"text\" id=\"SoHD_"+(lastRow)+"\"   style=\"width:150px;text-align:center\"/></td>	";
//            shtml += "		<td class=\"Column1_TK\"><input type=\"text\" id=\"NgatLapHD_"+(lastRow)+"\"   style=\"width:150px;text-align:center\"/></td>	";
//            shtml += "		<td class=\"Column1_TK\"><input type=\"text\" id=\"TaiKhoanNo_"+(lastRow)+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:150px;text-align:center\"/></td>	";
//            shtml +="       <td class=\"Column2_TK\"><input type=\"text\" id =\"DienGiai_"+(lastRow)+"\" style=\"width:500px;text-align:left\" /></td>";
//            shtml += "		<td class=\"Column1_TK\"><input type=\"text\" id=\"txtTongTien_"+(lastRow)+"\" onchange=\"getFormatSoTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:200px;text-align:right\" /></td>	";
//           
//                  
            TableDanhSach.rows[i].cells[0].getElementsByTagName("input")[0].id = "STT_"+i;
             TableDanhSach.rows[i].cells[0].getElementsByTagName("input")[0].value = i-1;
             TableDanhSach.rows[i].cells[1].getElementsByTagName("input")[0].id = "checkbox_"+i;
             TableDanhSach.rows[i].cells[1].getElementsByTagName("input")[1].id = "IDPhieuChiCT_"+i;
             TableDanhSach.rows[i].cells[2].getElementsByTagName("input")[0].id = "SoHD_"+i;
             TableDanhSach.rows[i].cells[3].getElementsByTagName("input")[0].id = "NgatLapHD_"+i;
             TableDanhSach.rows[i].cells[4].getElementsByTagName("input")[0].id = "TaiKhoanNo_"+i;
             TableDanhSach.rows[i].cells[5].getElementsByTagName("input")[0].id = "DienGiai_"+i;
             TableDanhSach.rows[i].cells[6].getElementsByTagName("input")[0].id = "txtTongTien_"+i;
        }
      }
        TinhTongTien();
}

//================================================================================================================

//================================================================================================================

//================================================Lưu phiếu chi hóa đơn===========================================
function LuuPhieuThuHoaDon(Ctr)
{
      Ctr.disabled = true;
      document.getElementById('message').style.visibility = "visible";
      var PhieuThuID = document.getElementById('hdPhieuThuID').value;
      var SoPT = document.getElementById('txtMaPT').value;
      var NgayThu = document.getElementById('txtNgayLapPhieuThu').value;
      var MaKH = document.getElementById('txtMaNCC').value;
      var NguoiNop = document.getElementById('txtNguoiNopTien').value;
      var DienGiai = document.getElementById('txtDienGiai').value;
      var TKNo = document.getElementById('txtTaiKhoanCo').value;
      var Tien = document.getElementById('TongTien').value;
      var UserDau ='Tăng Thúy Ngọc';
      var UserCuoi='Cyber Tang';
      var Status='1'; 
      if(NgayThu=="")
      {
        alert("Chưa chọn ngày lập phiếu chi. Vui lòng kiểm tra lại, cảm ơn!");
            Ctr.disabled = false;
        document.getElementById('message').style.display = "none";
      }
      else
      if(MaKH=="")
      { 
        alert("Chưa chọn mã khách hàng. Vui lòng kiểm tra lại, cảm ơn!");
           Ctr.disabled = false;
        document.getElementById('message').style.display = "none";
      }
      else
      if(TKNo=="")
      {
        alert("Chưa chọn tài khoản nợ. Vui lòng kiểm tra lại, cảm ơn!");
           Ctr.disabled = false;
        document.getElementById('message').style.display = "none";
      }
      else
      if(Tien=="")
      {
        alert("Chưa tính tổng tiền cho phiếu chi. Vui lòng kiểm tra lại, cảm ơn!");
           Ctr.disabled = false;
        document.getElementById('message').style.display = "none";
      }
      else
        GetFunctionLuuPTHD(Ctr,PhieuThuID,SoPT,NgayThu,MaKH,NguoiNop,DienGiai,TKNo,Tien,UserDau,UserCuoi,Status)
}
function GetFunctionLuuPTHD(Ctr,PhieuThuID,SoPT,NgayThu,MaKH,NguoiNop,DienGiai,TKNo,Tien,UserDau,UserCuoi,Status)
{
        Ctr.disabled = true;
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                  if (value==1)
                  {  
                   
                    XoaSoCai(Ctr,SoPT);
                    //alert(value);
                  }
                  else
                  {
                    alert("Lưu phiếu chi thất bại. Vui lòng kiểm tra lại, cảm ơn!");
                       Ctr.disabled = false;
                    document.getElementById('message').style.display = "none";
                  }
               
            }
        }
     
        xmlHttp.open("GET","KTTM_PhieuChiHoaDon_Ajax.aspx?do=LuuPhieuThu&LoaiThu=ThuHoaDon&PhieuThuID="+PhieuThuID+"&ngoai_te_id="+$("#txtNgoaiTeID").val()+"&ty_gia="+$("#txtTiGia").val()+"&SoPT="+SoPT+"&NgayThu="+NgayThu+"&MaKH="+MaKH+"&NguoiNop="+encodeURIComponent(NguoiNop)+"&DienGiai="+encodeURIComponent(DienGiai)+"&TKNo="+ TKNo+"&Tien="+Tien.replace(/\$|\,/g,'')+"&UserDau="+encodeURIComponent(UserDau)+"&UserCuoi="+encodeURIComponent(UserCuoi)+"&Status="+Status+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function bt_Click(Ctr)
{
    var SoPT = document.getElementById('txtMaPT').value;
   if(document.getElementById('bt_Luu').value =="Sửa")
    {     
        document.getElementById('bt_Luu').value = "Lưu";
        document.getElementById('bt_LoadDSPT').style.visibility = "hidden";
    }
    else
    if(document.getElementById('bt_Luu').value =="Lưu")
    {
        if(SoPT=="")
            TaoMaSoHoaDon();
        LuuPhieuThuHoaDon(Ctr);  
    }
}
function XoaSoCai(Ctr,SoPT)
{
     xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                //alert('toi day chua?');
                 XoaChiTietPhieuThu(Ctr,SoPT);
                 
            }
        }
         
          xmlHttp.open("GET","KTTM_PhieuChiHoaDon_Ajax.aspx?do=XoaSoCaiBySoPT&SoPT="+SoPT+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function XoaChiTietPhieuThu(Ctr,SoPT)
{
     xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;                   
                LuuChiTietPhieuThuHoaDon(Ctr);                
            }
        }
          xmlHttp.open("GET","KTTM_PhieuChiHoaDon_Ajax.aspx?do=XoaChiTietPhieuThu&SoPT="+SoPT+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function LuuChiTietPhieuThuHoaDon(Ctr)
{    
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var x;
    var rs = 1;
    var SoPT = document.getElementById('txtMaPT').value;
    var valuePhieuThuCTID="";     
    var valueSoHD ="";
    var valueNgayLapHD ="";
    var valueTKCo ="";
    var valueTien ="";
    var valueDienGiai="";
    var valueIdNhapVT="";
    var valueIdPhieuNhap="";
    var flag = false;
    if(Row>2)
    {
        while(Row>2)
        {
          
            var idCheckBox = "checkbox_"+(Row-2);
            var checkbox = document.getElementById(idCheckBox);
            if(checkbox.checked)
            {
                flag = true;
                var idPhieuThuCT = "IDPhieuChiCT_"+(Row-2);
                 valuePhieuThuCTID +=";"+ document.getElementById(idPhieuThuCT).value;
                var idSoHD = "SoHD_"+(Row-2);
                valueSoHD +=";"+ document.getElementById(idSoHD).value;
                
                var idNgayLapHD = "NgatLapHD_"+(Row-2);
                valueNgayLapHD +=";"+ document.getElementById(idNgayLapHD).value;
                
                var idTKCo = "TaiKhoanNo_"+(Row-2);
                valueTKCo +=";"+ document.getElementById(idTKCo).value;
                
                var idTien = "txtTongTien_"+(Row-2);
                var tien = document.getElementById(idTien).value;
                valueTien +=";"+ tien.replace(/\$|\,/g,'');
                
                var DienGiai = "DienGiai_"+(Row-2);
                valueDienGiai +=";"+ document.getElementById(DienGiai).value;
                
                var oIdNhapVT = "IdNhapVT_"+(Row-2);
                valueIdNhapVT +=";"+ document.getElementById(oIdNhapVT).value;
                
                var oIdPhieuNhap = "IdPhieuNhap_"+(Row-2);
                valueIdPhieuNhap +=";"+ document.getElementById(oIdPhieuNhap).value;
            }
            Row--;
        }
        
        if(flag)
        {
             // Lưu chi tiết phiếu thu mới
           getFunctionLuuCTPTHoaDon(Ctr,valuePhieuThuCTID,SoPT,valueTKCo,valueSoHD,valueNgayLapHD,valueTien,valueDienGiai,valueIdNhapVT,valueIdPhieuNhap);
        }
        else
        {
            alert("Chưa chọn hóa đơn. Vui lòng kiểm tra lại. Cảm ơn!");
            Ctr.disabled = false;
            document.getElementById('message').style.display = "none";
            XoaPhieuThu(SoPT);
        }          
    }
    else
    {
         alert("Không có hóa đơn để lập phiếu thu. Vui lòng kiểm tra lại. Cảm ơn!");
         Ctr.disabled = false;
         document.getElementById('message').style.display = "none";
         XoaPhieuThu(SoPT);
    }
     
     
}
function getFunctionLuuCTPTHoaDon(Ctr,IDPhieuThuCT,SoPT,TKCo,SoHD,NgayLapHD,TienTrenHD,valueDienGiai,valueIdNhapVT,valueIdPhieuNhap)
{
    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if(value=="1")
                 {
                      LuuSoCai(Ctr,TKCo,TienTrenHD,SoHD,NgayLapHD); 
                      
                 }
                else
                {
                    alert("Lưu phiếu thu hóa đơn thất bại!");
                    Ctr.disabled = false;
                    document.getElementById('message').style.display = "none";
                    XoaPhieuThu(SoPT);
                    
                }              
            }
        }
          xmlHttp.open("GET","KTTM_PhieuChiHoaDon_Ajax.aspx?do=LuuChiTietPhieuThuHoaDon&LoaiThu=ThuHoaDon&IDPhieuThuCT="+IDPhieuThuCT+"&SoPT="+SoPT+"&TKCo="+TKCo+"&SoHD="+SoHD+"&NgayLapHD="+NgayLapHD+"&TienTrenHD="+TienTrenHD
          +"&valueDienGiai="+encodeURIComponent(valueDienGiai)+"&valueIdNhapVT="+valueIdNhapVT+"&valueIdPhieuNhap="+valueIdPhieuNhap
          +"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function XoaPhieuThu(SoPhieuThu)
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
              xmlHttp.open("GET","KTTM_PhieuChiHoaDon_Ajax.aspx?do=XoaPhieuThu&SoPhieuThu="+SoPhieuThu+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function LuuSoCai(Ctr,TKCo,TienTrenHD,SoHD,NgayLapHD)
{
   var SoPT = document.getElementById('txtMaPT').value;
   var NgayThu = document.getElementById('txtNgayLapPhieuThu').value;
   var MaKH = document.getElementById('txtMaNCC').value;
   var DienGiai = document.getElementById('txtDienGiai').value;
   var TKNo = document.getElementById('txtTaiKhoanCo').value;
   xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                  if (value=="1")
                  {  
                        alert("Lưu phiếu thu hóa đơn thành công!");
                        Ctr.value = "Sửa";
                        ResetTableDSPhieuThu();
                        getChiTietPhieuThuHoaDon(SoPT);
                        document.getElementById('bt_Luu').value =="Sửa";
                        document.getElementById('bt_Luu').disabled = false;
                        document.getElementById('bt_LoadDSPT').disabled = true;
                  }
                  else
                  {   
                        alert("Lưu phiếu thu hóa đơn thất bại!");
                        Ctr.disabled = false;
                        document.getElementById('message').style.display = "none";
                        XoaPhieuThu(SoPT);
                  }
            }
        }
        
          xmlHttp.open("GET","KTTM_PhieuChiHoaDon_Ajax.aspx?do=LuuSoCai_PhieuThuHoaDon&SoPT="+SoPT+"&NgayThu="+NgayThu+"&MaKH="+MaKH+"&SoHD="+SoHD+"&DienGiai="+encodeURIComponent(DienGiai)+"&TKNo="+TKNo+"&TKCo="+TKCo+"&TienTrenHD="+TienTrenHD+"&NgayLapHD="+NgayLapHD+"&times="+Math.random(),true);
        xmlHttp.send(null);
  
}
function getChiTietPhieuThuHoaDon(SoPT)
{
     xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                  if (value!="")
                  {  
                    var Row = value.split('|');
                    for(i=1;i<Row.length;i++)
                    {
                        var Column = Row[i].split('&');
                        document.getElementById("txtMaPT").value = Column[6];
                        document.getElementById("txtNgoaiTeID").value = Column[9];
                        document.getElementById("txtNgoaiTe").value = Column[10];
                        document.getElementById("txtTiGia").value = Column[11];
                        ShowDanhSachHoaDon(Column[2],Column[1],Column[3],Column[5],Column[4],Column[12],Column[13],Column[14],Column[0]);
                    }                    
                  }
            }
        }
        xmlHttp.open("GET","KTTM_PhieuChiHoaDon_Ajax.aspx?do=ChiTietPhieuThuHoaDon&SoPT="+SoPT+"&times="+Math.random(),false);
        xmlHttp.send(null);
}
function DanhSachPhieuThuOfKhachHang(idPhieuThu)
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
                        //phieu_thu_id;so_phieu_thu;ngay_thu;ma_kh;tenkhachhang;nguoi_nop;dien_giai;tk_no;tien
                        LoadPhieuThuHoaDon(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7],Column[8]);
                        
                    }                    
                  }
            }
        }
          xmlHttp.open("GET","KTTM_PhieuChiHoaDon_Ajax.aspx?do=DanhSachPhieuThuOfKhachHang&idPhieuThu="+idPhieuThu+"&times="+Math.random(),false);
        xmlHttp.send(null);
}
function LoadPhieuThuHoaDon(idPhieuThu,SoPT,NgayLapPT,MaKH,TenKH,NguoiNop,DienGiai,TaiKhoanCo,TongTien)
{
    var typeKhachHang = MaKH.substring(0,2);
  if(typeKhachHang=="KH")
  {
      document.getElementById('txtTenNCC').value = TenKH;
  }
  document.getElementById('hdPhieuThuID').value = idPhieuThu;
  document.getElementById('txtMaPT').value = SoPT;
  document.getElementById('txtNgayLapPhieuThu').value = NgayLapPT;
  document.getElementById('txtMaNCC').value = MaKH;
  
  document.getElementById('txtNguoiNopTien').value = NguoiNop;
  document.getElementById('txtDienGiai').value = DienGiai;
  document.getElementById('txtTaiKhoanCo').value = TaiKhoanCo;
  document.getElementById('txtTongTien').value = TongTien;  
  document.getElementById('TongTien').value = formatCurrency1(TongTien.replace(/\$|\./g,'')); 
  getChiTietPhieuThuHoaDon(SoPT);
}
function ngaythu()
{
    dinhdangngay(document.getElementById('txtNgayLapPhieuThu'));
}
</script>
<form id="form1" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #007138">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;" class="bg_menu">
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
                    <td><div  class = "tdHeader">PHIẾU CHI HÓA ĐƠN</div></td>
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
												            <td class="tdLabel" >Ngày lập PC:</td>
                                                            <td  class="tdText" ><input id="txtNgayLapPhieuThu" runat="server" onblur="ngaythu();" style="width:100px;" type="text"/>&nbsp(dd/mm/yyyy)</td>
                                                            
                                                            <td class="tdLabel">Mã phiếu chi : </td>
                                                            <td class="tdText"><input id="txtMaPT"  runat="server"  type="text" class="InputText" disabled="disabled" /><input type="hidden" id="hdPhieuThuID" /></td>                                                                                                                        
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">Mã nhà cung cấp : </td>
                                                            <td class="tdText"><input id="txtMaNCC"  type="text" onfocus="ShowKhachHang('txtMaNCC');" class="InputText" /><input type="hidden" id="hd_idNCC" /></td>
                                                            
                                                            <td class="tdLabel">Tên NCC : </td>
                                                            <td  class="tdText"><input id="txtTenNCC" type="text"  onfocus="ShowKhachHang('txtTenNCC')" class="InputText" /></td>
                                                            
                                                             <td class="tdLabel"> Người nhận tiền : </td>
                                                            <td  class="tdText"><input id="txtNguoiNopTien" type="text" class="InputText" /></td>
                                                           
                                                        </tr>
                                                                                                       
                                                        <tr>
                                                            <td class="tdLabel">Tài khoản có: </td>
                                                            <td  class="tdText"><input id="txtTaiKhoanCo" type="text" class="InputText" onchange="TestMaTaiKhoan('txtTaiKhoanCo')" onfocus="ShowTaiKhoan(this)" /></td>
                                                            
                                                            <td class="tdLabel" style="width: 127px">Ngoại tệ: </td>
                                                            <td  class="tdText"><input id="txtNgoaiTeID" type="hidden" value="6" onfocus="NgoaiTeSearch(this.id);" /><input id="txtNgoaiTe" type="text" value="VNĐ" class="InputText" onfocus="NgoaiTeSearch(this.id);" onfocusout="QuyDoiNgoaiTe();" /></td>
                                                            
                                                            <td class="tdLabel" style="width: 127px">Tỉ giá: </td>
                                                            <td  class="tdText"><input id="txtTiGia" onfocus="" type="text" value="1" class="InputText"/></td>
                                                         </tr>
                                                        
                                                        <tr>
                                                            <td class="tdLabel">Diễn giải : </td>
                                                            <td colspan="6"  class="tdText">
                                                                <textarea id="txtDienGiai" style="width:570px" cols="20"  rows="2"></textarea></td>
                                                            
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td colspan="6" style="text-align:center">
                                                                <input type="button" id="bt_LoadDSPT" onclick="LoadDanhSachHoaDon()" value="Load danh sách hóa đơn" />
                                                                
                                                                <input type="button" value="Lưu" id="bt_Luu" onclick="bt_Click(this);" style="width:100px" />
                                                            
                                                                <input type="reset" value="Tạo mới"  style="width:100px" onclick="Moi();" id="bt_Reset" />
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
              <td class ="tdHeader" colspan="10" >DANH SÁCH HÓA ĐƠN</td>
         </tr>
		<tr class="HeaderGidView">
		     <td class="HeaderColumn0" >STT</td>
		      <td class="HeaderColumn0"  onclick='CheckAll(this);' ><input  type="checkbox"  id="checkbox_all" /></td>
		     <td class="HeaderColumn2">
		        Số HĐ
		     </td>
		     <td class="HeaderColumn2">
		       Ngày lập HĐ
		       
		    </td>
		    <td class="HeaderColumn1">
		        Tài khoản nợ
		    </td>
		    <td class="HeaderColumn3">
		        Diễn giải
		    </td>
		    <td class="HeaderColumn1">
		        Nguyên tệ
		    </td>
		    <td class="HeaderColumn1">
		        Tiền trên HĐ(VNĐ)
		       
		    </td>
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
    <div class ="tdHeader" style="font-size:14px;padding-left:900px">Tổng tiền : <input type="text" style="width:200px;text-align:right" id="TongTien" readonly="readonly" onclick="TinhTongTien()"/><input type="hidden" id="txtTongTien" value=""></div>      
    <div>
        <input type="button" id="bt_ThemDong" value="Thêm dòng" onclick="ThemDong()" />
        <input type="button" id="bt_XoaDong" value="Xóa dòng" onclick="XoaDong()" />
    </div>
</form>
<!--#include file ="footer.htm"-->