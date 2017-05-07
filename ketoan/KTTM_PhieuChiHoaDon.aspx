<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTM_PhieuChiHoaDon.aspx.cs" Inherits="ketoan_KTTM_PhieuChiHoaDon" %>


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
    
    
 //========================Các hàm kiểm tra===================   
     var dp_cal;
  
	window.onload = function () 
	{
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtNgayLapPhieuThu'));	
	    //TaoMaSoHoaDon();
	    var queryString = "";
	    queryString =  window.location.search.substring(1).split('&');
	    if(queryString!="")
	    {
	        var idPhieuThu = queryString[0].split('=');
	        var SoPT = queryString[1].split('=');
	        var MaKH = queryString[2].split('=');  
	        if(MaKH[1]!="")
	        {
	            var typeKH = MaKH[1].substring(0,2);
	            if(typeKH=="KH")
	            {
	                DanhSachPhieuThuOfKhachHang(idPhieuThu[1]);
	            }
	            else
	            if(typeKH=="BN")
	            {
	                DanhSachPhieuThuOfBenhNhan(idPhieuThu[1]);
	            }    
	        }
	    }
	    
	    
	};
function TaoMaSoHoaDon()
{
       var Table = "Phieu_Chi";
       var KyTuDau = "PC";
       var Column = "so_phieu_chi";
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
              xmlHttp.open("GET","ajax.aspx?do=TaoMaSoTuDong&Table="+Table+"&KyTuDau="+KyTuDau+"&Column="+Column+"&times="+Math.random(),true);
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
    document.getElementById('txtMaKH').value="";
    document.getElementById('txtTenKH').value="";
    document.getElementById('txtMaPC').value="";
    
    document.getElementById('txtTaiKhoanNo').value="";
    document.getElementById('txtDienGiai').value="";
    document.getElementById('txtNgayLapPhieuThu').value="";
   
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
document.getElementById('TongTien') = 0;
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
                                                                document.getElementById(obj).blur();
                                                            }
                                                        );           
}

function setChonTaiKhoan(MaTaiKhoan,idText)
{
      if(idText!="")
      {
          var txtTaiKhoan=document.getElementById(idText);
          txtTaiKhoan.value=MaTaiKhoan;
      }
}
function ShowKhachHang(obj)
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
                                                                    document.getElementById(obj).blur();
                                                                }
                                                            ); 
    
}

function setChonNCC(idNCC,MaNCC,TenNCC)
{
      
      var txtMaKH=document.getElementById('txtMaKH');
      var txtTenKH=document.getElementById('txtTenKH');
      var hd_IDBN = document.getElementById('hd_idNCC');
      txtMaKH.value=idNCC;
      txtTenKH.value = TenNCC;
      hd_IDBN.value = idNCC;
      //alert(hd_IDBN.value);
}


///=================================Load danh sách hóa đơn========================================================
function LoadDanhSachHoaDon()
{
    var MaNCC = document.getElementById('txtMaKH').value;
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
                        ShowDanhSachHoaDon(data[0],data[1],data[2],data[3],0);
                    }
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=LoadDanhSachHoaDonPhieuChi&MaNCC="+MaNCC+"&times="+Math.random(),true);
        xmlHttp.send(null);
   
}
function ShowDanhSachHoaDon(SoHD,TKNo,NgayLapHD,ThanhTien,IDPhieuChiCT)
{
    
    var TableDanhSach = document.getElementById('TableDanhSach');
    var lastRow = TableDanhSach.rows.length; 
    var shtml = "<tr class=\"RowGidView\">";
       shtml += "		<td class=\"Column0\" style=\"width:20px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\" style=\"width:50px\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/><input type=\"hidden\" id=\"IDPhieuChiCT_"+(lastRow)+"\" value=\""+IDPhieuChiCT+"\"/></td>";
            shtml += "		<td class=\"Column1_TK\"><input type=\"text\" id=\"SoHD_"+(lastRow)+"\" value=\""+SoHD+"\"   style=\"width:150px;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column1_TK\"><input type=\"text\" id=\"NgatLapHD_"+(lastRow)+"\" value=\""+NgayLapHD+"\"  style=\"width:150px;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column1_TK\"><input type=\"text\" id=\"TaiKhoanNo_"+(lastRow)+"\" value=\""+TKNo+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:150px;text-align:center\"/></td>	";
            shtml +="       <td class=\"Column2_TK\"><input type=\"text\" id =\"DienGiai_"+(lastRow)+"\" style=\"width:500px;text-align:left\" /></td>";
            shtml += "		<td class=\"Column1_TK\"><input type=\"text\" id=\"txtTongTien_"+(lastRow)+"\" value=\""+ThanhTien+"\" onchange=\"getFormatSoTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:200px;text-align:right\" /></td>	"; 
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
var TongTien = 0;
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
            shtml +="       <td class=\"Column2_TK\"><input type=\"text\" id =\"DienGiai_"+(lastRow)+"\" style=\"width:500px;text-align:left\" /></td>";
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
                                                            <td class="tdLabel">Mã phiếu chi : </td>
                                                            <td class="tdText"><input id="txtMaPC"  runat="server"  type="text" class="InputText" /><input type="hidden" id="hdPhieuThuID" /></td>
                                                            
                                                            <td class="tdLabel" >Ngày lập PC:</td>
                                                            <td  class="tdCalenda" ><input id="txtNgayLapPhieuThu" runat="server" onchange="TestDate('txtNgayLapPhieuThu')"  onclick="dp_cal.toggle()"  style="width:100px;"   type="text"/></td>
                                                           
                                                           
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">Mã nhà cung cấp : </td>
                                                            <td class="tdText"><input id="txtMaNCC"  type="text" onfocus="ShowKhachHang('txtMaNCC')" class="InputText" /><input type="hidden" id="hd_idNCC" /></td>
                                                            
                                                            <td class="tdLabel">Tên NCC : </td>
                                                            <td  class="tdText"><input id="txtTenNCC" type="text"  onfocus="ShowKhachHang('txtTenNCC')" class="InputText" /></td>
                                                            
                                                             <td class="tdLabel"> Người nộp tiền : </td>
                                                            <td  class="tdText"><input id="txtNguoiNopTien" type="text" class="InputText" /></td>
                                                           
                                                        </tr>
                                                                                                       
                                                        <tr>
                                                            <td class="tdLabel">Tài khoản có: </td>
                                                            <td  class="tdText"><input id="txtTaiKhoanCo" type="text" class="InputText" onchange="TestMaTaiKhoan('txtTaiKhoanCo')" onfocus="ShowTaiKhoan('txtTaiKhoanCo')" /></td>
                                                            
                                                        </tr>
                                                        
                                                        
                                                        <tr>
                                                            <td class="tdLabel">Diễn giải : </td>
                                                            <td colspan="6"  class="tdText">
                                                                <textarea id="txtDienGiai" style="width:570px" cols="20"  rows="2"></textarea></td>
                                                            
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td colspan="6" style="text-align:center">
                                                                <input type="button" id="bt_LoadDSPT" onclick="LoadDanhSachHoaDon()" value="Load danh sách hóa đơn" />
                                                                
                                                                <input type="button" value="Lưu" id="bt_Luu" onclick="LuuPhieuThuHoaDon()" style="width:100px" />
                                                            
                                                                <input type="reset" value="Tạo mới"  style="width:100px" onclick="ResetTableDSPhieuThu()" id="bt_Reset" />
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
		      <td class="HeaderColumn0" >Xóa</td>
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
		        Tiền trên HĐ
		       
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
    <div class ="tdHeader" style="font-size:14px;padding-left:900px">Tổng tiền : <input type="text" style="width:200px;text-align:right" id="TongTien" readonly="readonly" onclick="TinhTongTien()"/></div>      
    <div>
        <input type="button" id="bt_ThemDong" value="Thêm dòng" onclick="ThemDong()" />
        <input type="button" id="bt_XoaDong" value="Xóa dòng" onclick="XoaDong()" />
    </div>
</form>
<!--#include file ="footer.htm"-->