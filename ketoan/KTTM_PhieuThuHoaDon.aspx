<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTM_PhieuThuHoaDon.aspx.cs" Inherits="ketoan_KTTM_PhieuThuHoaDon" %>
 <!--#include file ="header.htm"-->
<link type="text/css" rel="stylesheet" href="../ketoan/css_KeToan/sheet_index.css" />
<link href="../ketoan/css_ketoan/dropdown/dropdown.css" media="screen" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/default.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/table_TCHD.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/epoch_styles.css" />
<link href="../ketoan/css_ketoan/dropdown/themes/default/default.css" media="screen" rel="stylesheet" type="text/css" />
<link href="../ketoan/css_KeToan/epoch_styles.css" type="text/css" rel="stylesheet" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/style.css" />
<link href="../ketoan/css_KeToan/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../ketoan/js_KeToan/scriptoflong.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/libary.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/script.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jscript.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/epoch_classes.js"></script>
<script type="text/javascript" src="../ketoan/editor/editor.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jquery-1.4.2.js"></script>
<script src="../js/jquery.autocomplete.js" type="text/javascript"></script>
<link type="text/css" href="../css/jquery.autocomplete.css" />
<link type="text/css" href="../css/jquery.autocomplete.new.css" />

    
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_TienMat.ascx" TagName="menu_ketoantienmat" TagPrefix="uc1" %>

 <script language="javascript" type="text/javascript">
    
    
 //========================Các hàm kiểm tra===================   
     var dp_cal;     
	window.onload = function () 
	{
	    document.getElementById('txtMaPT').disable=true;
	    loadData();	  	    
	    
	    phanquyen();
	}
	function phanquyen() 
	{
	    var quyenthem = '<%=StaticData.HavePermision(this.Page, "KeToanTM_KTTM_PhieuThuHoaDon_Them")%>';
        var quyensua = '<%=StaticData.HavePermision(this.Page, "KeToanTM_KTTM_PhieuThuHoaDon_Sua")%>';
        var quyenxoa = '<%=StaticData.HavePermision(this.Page, "KeToanTM_KTTM_PhieuThuHoaDon_Xoa")%>';
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
function loadData()
{
  var queryString = "";
	    queryString =  window.location.search.substring(1).split('&');	   
	    if(queryString !="dkmenu=kttienmat" && queryString!="" )
	    {	      
	        var idPhieuThu = queryString[1].split('=');
	        var SoPT = queryString[1].split('=');	      
	        //getChiTietPhieuThuHoaDon(SoPT[1]);
	        DanhSachPhieuThuOfKhachHang(idPhieuThu[1]);	       
	        document.getElementById('bt_LoadDSPT').style.visibility = 'hidden';
	        document.getElementById('bt_Luu').value ="Sửa";	        
	    }
}
function bt_Click(Ctr)
{
    var sophieu=document.getElementById('txtMaPT').value;
   if(document.getElementById('bt_Luu').value =="Sửa")
    {     
        document.getElementById('bt_Luu').value = "Lưu";
        document.getElementById('bt_LoadDSPT').style.visibility = "hidden";
    }
    else
    if(document.getElementById('bt_Luu').value =="Lưu")
    {
        if(sophieu=="")
            TaoMaSoHoaDon();
        LuuPhieuThuHoaDon(Ctr.id);  
    }
}
function TaoMaSoHoaDon()
{
       var Table = "Phieu_Thu";
       var manghiepvu = "PHIEU_THU";
       var Column = "So_Phieu_Thu";
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
	
	
function TestMaTaiKhoan(txtTaiKhoan)
{
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
function FormatSoTien(obj)
{
	    return formatCurrency(obj);
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
function ChangeFormatCurrency(obj)
{
   
    var result="";
    var buffer = obj.split('.');
    
    for(i=0;i<buffer.length;i++)
    {
        result+=buffer[i];
    }
   
        return result;
}
function TaoMoi()
{
   document.getElementById('bt_LoadDSPT').style.visibility = 'visible';
   
   ResetDataonTable();
   document.getElementById('bt_Luu').value = "Lưu";
   //alert($("#bt_luu").val());
   //$("#bt_LoadDSPT").show();
   document.getElementById('bt_LoadDSPT').disabled = false;
}
//==================Các hàm xử lý==============================
var CheckType="KhachHang";
function RadioChecked(Ctr)
{
    
    if(Ctr == "BenhNhan")
    {
         CheckType="BenhNhan";
       ResetDataonTable();
       
      document.getElementById('txtMaKH').value="";
      document.getElementById('txtTenKH').value="";
      document.getElementById('txtMaKH').removeAttribute('readOnly');
      document.getElementById('txtTenKH').removeAttribute('read0nly');
        
      
    }
    else
    if(Ctr =="KhachLe")
    {
         CheckType="KhachLe"; 
        ResetDataonTable();
       
        document.getElementById('txtMaKH').value="KhachLe";
        document.getElementById('txtTenKH').value="Khách lẻ";
        
        document.getElementById('txtMaKH').setAttribute('readOnly', true);
        document.getElementById('txtTenKH').setAttribute('readOnly', true);
        
        
    }
    else
    if(Ctr == "KhachHang")
    {
         CheckType="KhachHang";
      ResetDataonTable();
      document.getElementById('txtMaKH').value="";
      document.getElementById('txtTenKH').value="";
      document.getElementById('txtMaKH').removeAttribute('readOnly');
      document.getElementById('txtTenKH').removeAttribute('read0nly');
    }
   //TaoMaSoHoaDon();
   //  alert(CheckType);
}
function ResetDataonTable()
{
    document.getElementById('txtMaKH').value="";
    document.getElementById('txtTenKH').value="";
    document.getElementById('txtMaPT').value="";
    document.getElementById('txtNguoiNopTien').value="";
    
    document.getElementById('txtTaiKhoanNo').value="";
    document.getElementById('txtDienGiai').value="";
    document.getElementById('txtNgayLapPhieuThu').value="";
   
    ResetTableDSPhieuThu();   
    //TaoMaSoHoaDon();
}
function ResetTableDSPhieuThu()
{
    var TableDanhSachHD = document.getElementById('TableDanhSachHD');
    var Row = TableDanhSachHD.rows.length;
    var lastRow = Row;
    while(lastRow>2)
    {
        TableDanhSachHD.deleteRow(lastRow-1);
        lastRow--;
    }
    TongTien = 0;
    document.getElementById('TongTien').value = 0;
}

function ShowTaiKhoan(obj)
{
    var objsrc = document.getElementById(obj);
        $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=DanhSachTaiKhoan_Jquery&Key="+objsrc.value+"&obj="+obj,
                                                    {width:400,scroll:true,formatItem:function(data)
                                                        {return data[1];}
                                                    }
                                                ).result(
                                                            function(event,data)
                                                            {
                                                                setChonTaiKhoan(data[2],obj);
                                                                //document.getElementById(obj).blur();
                                                            }
                                                        );           
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
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachKhachHang_BN&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
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
      var txtTenKH=document.getElementById('txtTenKH');
      txtMaKH.value=MaKH;
      txtTenKH.value = TenKH;
      
      //alert(hd_IDBN.value);
}

///=================================Load danh sách hóa đơn========================================================
function LoadDanhSachHoaDon()
{   
    var MaKhachHang = document.getElementById('txtMaKH').value;
    var ngaylap = document.getElementById('txtngaylaphd').value;
    var loaihoadon = document.getElementById('ddlloaihd').value;    
    var NgoaiTe = document.getElementById('txtNgoaiTe').value;
    var TableDanhSachHD = document.getElementById('TableDanhSachHD');
    var lastRow = TableDanhSachHD.rows.length;
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
                        ShowDanhSachHoaDon(data[0],data[1],data[2],data[3],data[4],data[5],data[6],0);
                    }
                  }
                  else
                    alert('Không có hóa đơn nào thỏa điều kiện lọc!');
            }
        }
    xmlHttp.open("GET","ajax.aspx?do=LoadDanhSachHoaDon&MaKhachHang="+MaKhachHang+"&ngaylap="+ngaylap+"&loaihoadon="+loaihoadon+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
function ShowDanhSachHoaDon(makhach,tenkhach,sohoadon,ngaylap,diengiai,tkno,thanhtien,IDPhieuThuCT)
{        
    var TableDanhSachHD = document.getElementById('TableDanhSachHD');
    var lastRow = TableDanhSachHD.rows.length; 
    var shtml = "<tr class=\"RowGidView\">";
        shtml += "		<td class=\"Column0\">" + (lastRow-1) + "</td>";
        shtml += "		<td class=\"Column0\" id=\"td_checkbox\" style=\"width:5%\" ><input type=\"checkbox\" id=\"checkbox_"+(lastRow-1)+"\" onchange=\"TinhTongTien()\" checked=\"checked\" /><input type=\"hidden\" id=\"hdIDPhieuThuCT_"+(lastRow-1)+"\" value=\""+IDPhieuThuCT+"\"/></td>";        
        shtml += "		<td class=\"Column2\" id=\"txtMaKH_"+(lastRow-1)+"\" style=\"width:10%\"> <input type=\"hidden\" id=\"hdMaKH_"+(lastRow-1)+"\" value=\""+makhach+"\"/>"+makhach+"</td>	";        
        shtml += "		<td class=\"Column2\" id=\"txtTenKH_"+(lastRow-1)+"\" style=\"width:15%\"> <input type=\"hidden\" id=\"hdTenKH_"+(lastRow-1)+"\" value=\""+tenkhach+"\"/>"+tenkhach+"</td>	";        
        shtml += "		<td class=\"Column2\" id=\"txtSoHD_"+(lastRow-1)+"\" style=\"width:10%\"> <input type=\"hidden\" id=\"hdSoHoaDon_"+(lastRow-1)+"\" value=\""+sohoadon+"\"/>"+sohoadon+"</td>	";        
        shtml +="       <td class=\"Column2\" id=\"txtNgayLapHD_"+(lastRow-1)+"\" style=\"width:10%\"><input type=\"hidden\" id=\"hdNgayLapHoaDon_"+(lastRow-1)+"\" value=\""+ngaylap+"\"/>"+ngaylap+"</td>"; 
        shtml += "		<td class=\"Column2\" id=\"txtTKCo_"+(lastRow-1)+"\" style=\"width:10%\"><input type=\"hidden\" id=\"taikhoanco_"+(lastRow-1)+"\" value=\""+tkno+"\"/>"+tkno+"</td>	";                     
        shtml += "		<td class=\"Column2\" id=\"txtDienGiai_"+(lastRow-1)+"\" style=\"width:25%\"> <input type=\"hidden\" id=\"hdDienGiai_"+(lastRow-1)+"\" value=\""+diengiai+"\"/>"+diengiai+"</td>	";                
        shtml += "		<td class=\"Column2\" id=\"txtTT_"+(lastRow-1)+"\" style=\"width:15%\"> <input id=\"txtTongTien_"+(lastRow-1)+"\" type=\"text\" class=\"InputTien\" readonly=\"readonly\" value=\""+formatCurrency1(1*thanhtien)+"\" /></td>	";                 
     shtml += "	</tr>";
     //alert(shtml);    
  $("#TableDanhSachHD:last").append(shtml);
  CongTongTien(thanhtien);
  //shtml += "		<td class=\"Column2\" id=\"txtTT_"+(lastRow-1)+"\"> <input id=\"txtTongTien_"+(lastRow-1)+"\" type=\"text\" class=\"InputTien\" readonly=\"readonly\" value=\""+formatCurrency1(1*thanhtien)+"\" /></td>	";                   
}
//===============================================================
function TinhTongTien()
{
    var TableDanhSachHD = document.getElementById('TableDanhSachHD');
    var Row = TableDanhSachHD.rows.length;
    var Tien = 0;
    var x;
    //alert('Chán chán!!!!!!!!')
    if(Row>2)
    {
        while(Row>2)
        {
            var idCheckBox = "checkbox_"+(Row-2);
            var checkbox = document.getElementById(idCheckBox);
            if(checkbox.checked)
            {
                //var count = Tien;
                var txtSoTien = "txtTongTien_"+(Row-2);
                var sotien =  document.getElementById(txtSoTien);
                Tien =  1 * Tien + 1 * sotien.value.replace(/\$|\,/g,'');
            }
            Row--;
            
        }
     }
    // alert(Tien);
    var txtTongTien = document.getElementById('TongTien');
    txtTongTien.value = formatCurrency1(Tien);     
}
var TongTien = 0;
function CongTongTien(ThanhTien)
{
  
    var count = TongTien;
    TongTien =  eval(count) + (eval(ThanhTien));
    document.getElementById('TongTien').value = formatCurrency1(TongTien);
    document.getElementById('txtTongTien').value = FormatSoTien(TongTien);
}

//================================================Lưu phiếu thu hóa đơn===========================================
function LuuPhieuThuHoaDon(Ctr)
{       
      Ctr.disabled = true;
      document.getElementById('message').style.visibility = "visible";
      var PhieuThuID = document.getElementById('hdPhieuThuID').value;            
      var loaihoadon=document.getElementById('ddlloaihd').value;
      var MaKH = document.getElementById('txtMaKH').value;
      var NguoiNop = document.getElementById('txtNguoiNopTien').value;
      var DienGiai = document.getElementById('txtDienGiai').value;
      var TKNo = document.getElementById('txtTaiKhoanNo').value;
      var Tien = document.getElementById('TongTien').value;
      var soctgoc=document.getElementById('txtsoctgoc').value;
      var chungtugoc=document.getElementById('txtchungtugoc').value;
      var UserDau ='Tăng Thúy Ngọc';
      var UserCuoi='Cyber Tang'
      var Status='1';      
      var SoPT = document.getElementById('txtMaPT').value;                  
      var ngaylapphieuthu =document.getElementById('txtNgayLapPhieuThu').value;      
      if(SoPT=="/*-*_*-*")
      {
//        alert("Chưa nhập số phiếu thu. Vui lòng kiểm tra lại, cảm ơn!");
//          Ctr.disabled = false;
//        document.getElementById('message').style.display = "none";
      }
      else
      if(ngaylapphieuthu=="")
      {
        alert("Chưa chọn ngày lập phiếu thu. Vui lòng kiểm tra lại, cảm ơn!");
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
        alert("Chưa tính tổng tiền cho phiếu thu. Vui lòng kiểm tra lại, cảm ơn!");
           Ctr.disabled = false;
        document.getElementById('message').style.display = "none";
      }
      else
        GetFunctionLuuPTHD(Ctr,PhieuThuID,SoPT,ngaylapphieuthu,loaihoadon,MaKH,NguoiNop,DienGiai,TKNo,Tien,soctgoc,chungtugoc,UserDau,UserCuoi,Status)
}
function QuyDoiNgoaiTe()
{
    if($("#txtTiGia").val() != "")
    for(var i=2;i<document.getElementById("TableDanhSachHD").rows.length;i++)
    {
        var tongtien=document.getElementById("TableDanhSachHD").rows[i].cells[7].getElementsByTagName("input")[0].value;
        var tongtienquydoi=tongtien.replace(/\$|\,/g,'')/$("#txtTiGia").val();
        document.getElementById("TableDanhSachHD").rows[i].cells[5].getElementsByTagName("input")[0].value = formatCurrency1(tongtienquydoi);
    }
}
function formatCurrency1(num){
            Number.prototype.formatMoney = function(c, d, t){
            var n = this, c = isNaN(c = Math.abs(c)) ? 2 : c, d = d == undefined ? "," : d, t = t == undefined ? "." : t, s = n < 0 ? "-" : "", i =  parseInt(n = Math.abs(+n || 0).toFixed(c)) + "", j = (j = i.length) > 3 ? j % 3 : 0;
               return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : ""); 
               };
            return num.formatMoney(2,'.',',');
}

function GetFunctionLuuPTHD(Ctr,PhieuThuID,SoPT,NgayThu,loaihoadon,MaKH,NguoiNop,DienGiai,TKNo,Tien,soctgoc,chungtugoc,UserDau,UserCuoi,Status)
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
                    alert("Lưu phiếu thu thất bại. Vui lòng kiểm tra lại, cảm ơn!");
                       Ctr.disabled = false;
                    document.getElementById('message').style.display = "none";
                  }               
            }
        }     
        xmlHttp.open("GET","ajax.aspx?do=LuuPhieuThu&LoaiThu=ThuHoaDon&PhieuThuID="+PhieuThuID+"&ngoai_te_id="+$("#txtNgoaiTeID").val()+"&ty_gia="+$("#txtTiGia").val()+"&SoPT="+SoPT+"&NgayThu="+NgayThu+"&loaihoadon="+loaihoadon+"&MaKH="+MaKH+"&NguoiNop="+encodeURIComponent(NguoiNop)+"&DienGiai="+encodeURIComponent(DienGiai)+"&TKNo="+ TKNo+"&Tien="+Tien.replace(/\$|\,/g,'')+"&soctgoc="+soctgoc+"&chungtugoc="+chungtugoc+"&UserDau="+encodeURIComponent(UserDau)+"&UserCuoi="+encodeURIComponent(UserCuoi)+"&Status="+Status+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
//================================================================================================================
//=======================================Lưu chi tiết phiếu thu===================================================
function XoaSoCai(Ctr,SoPT)
{
     xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;                
                 XoaChiTietPhieuThu(Ctr,SoPT);                 
            }
        }
         
          xmlHttp.open("GET","ajax.aspx?do=XoaSoCaiBySoPT&SoPT="+SoPT+"&times="+Math.random(),true);
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
         // xmlHttp.open("GET","ajax.aspx?do=LuuPhieuThuHoaDon&SoPT="+SoPT+"&NgayThu="+NgayThu+"&MaKH="+MaKH+"&NguoiNop="+encodeURIComponent(NguoiNop)+"&DienGiai="+encodeURIComponent(DienGiai)+"&TKNo="+TKNo+"&Tien="+ChangeFormatCurrency(Tien)+"&UserDau="+encodeURIComponent(UserDau)+"&UserCuoi="+encodeURIComponent(UserCuoi)+"&Status="+Status+"&times="+Math.random(),true);
          xmlHttp.open("GET","ajax.aspx?do=XoaChiTietPhieuThu&SoPT="+SoPT+"&times="+Math.random(),true);
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
              xmlHttp.open("GET","ajax.aspx?do=XoaPhieuThu&SoPhieuThu="+SoPhieuThu+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function LuuChiTietPhieuThuHoaDon(Ctr)
{           
    var TableDanhSachHD = document.getElementById('TableDanhSachHD');
    
    var Row = TableDanhSachHD.rows.length;
    var x;
    var rs = 1;
    var SoPT = document.getElementById('txtMaPT').value;
    var valuePhieuThuCTID="";     
    var valueSoHD ="";
    var valueNgayLapHD ="";
    var valueDienGiai="";
    var valueTKCo ="";
    var valueTien ="";
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
                var idPhieuThuCT = "hdIDPhieuThuCT_"+(Row-2);
                 valuePhieuThuCTID +=";"+ document.getElementById(idPhieuThuCT).value;
                
                var idSoHD = "hdSoHoaDon_"+(Row-2);
                valueSoHD +=";"+ document.getElementById(idSoHD).value;
                
                var idNgayLapHD = "hdNgayLapHoaDon_"+(Row-2);
                valueNgayLapHD +=";"+ document.getElementById(idNgayLapHD).value;
                
                var iddiengiai = "hdDienGiai_"+(Row-2);
                valueDienGiai +=";"+ document.getElementById(iddiengiai).value;
                
                var idTKCo = "taikhoanco_"+(Row-2);
                valueTKCo +=";"+ document.getElementById(idTKCo).value;                              
               
                var idTien = "txtTongTien_"+(Row-2);
                var tien = document.getElementById(idTien).value;
                valueTien +=";"+ tien.replace(/\$|\,/g,'');              
            }
            Row--;
        }
        
        if(flag)
        {
             // Lưu chi tiết phiếu thu mới
           getFunctionLuuCTPTHoaDon(Ctr,valuePhieuThuCTID,SoPT,valueTKCo,valueSoHD,valueNgayLapHD,valueDienGiai,valueTien);
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
function getFunctionLuuCTPTHoaDon(Ctr,IDPhieuThuCT,SoPT,TKCo,SoHD,NgayLapHD,diengiai,TienTrenHD)
{        
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if(value==1)
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
        xmlHttp.open("GET","ajax.aspx?do=LuuChiTietPhieuThuHoaDon&LoaiThu=ThuHoaDon&IDPhieuThuCT="+IDPhieuThuCT+"&SoPT="+SoPT+"&TKCo="+TKCo+"&SoHD="+SoHD+"&NgayLapHD="+NgayLapHD+"&diengiai="+diengiai+"&TienTrenHD="+TienTrenHD+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function LuuSoCai(Ctr,TKCo,TienTrenHD,SoHD,NgayLapHD)
{
   var SoPT = document.getElementById('txtMaPT').value;   
   var NgayThu = document.getElementById('txtNgayLapPhieuThu').value;
   var MaKH = document.getElementById('txtMaKH').value;
   var DienGiai = document.getElementById('txtDienGiai').value;
   var TKNo = document.getElementById('txtTaiKhoanNo').value;
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
                        //document.getElementById('message').style.display = "none";
                        //document.getElementById('message').style.display = "True";
                        ResetTableDSPhieuThu();                        
                        getChiTietPhieuThuHoaDon(SoPT);
                        document.getElementById('bt_Luu').value =="Sửa";
                        document.getElementById('bt_Luu').disabled = false;
                        
                        //document.getElementById('bt_LoadDSPT').hide();
                        //$("#bt_LoadDSPT").hide();
                        document.getElementById('bt_LoadDSPT').disabled = true;
                        //alert('cái quái j vậy')
                  }
                  else
                  {   
                        alert("Lưu phiếu thu hóa đơn thất bại!");
                        Ctr.disabled = false;
                        document.getElementById('message').style.display = "none";
                        XoaPhieuThu(SoPT);
                        //ResetTableDSPhieuThu();
                        //getChiTietPhieuThuHoaDon(SoPT);
                  }
            }
        }
        
          xmlHttp.open("GET","ajax.aspx?do=LuuSoCai_PhieuThuHoaDon&SoPT="+SoPT+"&NgayThu="+NgayThu+"&MaKH="+MaKH+"&SoHD="+SoHD+"&DienGiai="+encodeURIComponent(DienGiai)+"&TKNo="+TKNo+"&TKCo="+TKCo+"&TienTrenHD="+TienTrenHD+"&NgayLapHD="+NgayLapHD+"&times="+Math.random(),true);
        xmlHttp.send(null);
  
}
//=======================================================================================================================================
//============================================Load phiếu thu và chi tiet phieu tu ben danh sách phieu thu chuyển qua=====================
//=======================================================================================================================================
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
                        LoadPhieuThuHoaDon(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7],Column[8],Column[9],Column[10]);                        
                    }                    
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=DanhSachPhieuThuOfKhachHang&idPhieuThu="+idPhieuThu+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function LoadPhieuThuHoaDon(idPhieuThu,SoPT,NgayLapPT,MaKH,TenKH,NguoiNop,DienGiai,TaiKhoanNo,TongTien,soctgoc,chungtugoc)
{       
  document.getElementById('hdPhieuThuID').value = idPhieuThu;
  document.getElementById('txtMaPT').value = SoPT;
  document.getElementById('txtNgayLapPhieuThu').value = NgayLapPT;
  document.getElementById('txtMaKH').value = MaKH;    
  document.getElementById('txtTenKH').value = TenKH; 
  document.getElementById('txtNguoiNopTien').value = NguoiNop;
  document.getElementById('txtDienGiai').value = DienGiai;
  document.getElementById('txtTaiKhoanNo').value = TaiKhoanNo;
  document.getElementById('txtsoctgoc').value = soctgoc;
  document.getElementById('txtchungtugoc').value = chungtugoc;
  //document.getElementById('txtTongTien').value = tongtien;
  getChiTietPhieuThuHoaDon(SoPT);
  document.getElementById('txtTongTien').value = formatCurrency1(TongTien.replace(/\$|\./g,''));  
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
                        ShowDanhSachHoaDon(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7]);                                                                      
                    }                                        
                  }
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=ChiTietPhieuThuHoaDon&SoPT="+SoPT+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
//================================================================================================================

function InPhieuThuKhac()
{
    var SoPhieuThu = document.getElementById('txtMaPT').value;
    var NgayThu = document.getElementById('txtNgayLapPhieuThu').value;
    var soctgoc=document.getElementById('txtsoctgoc').value;
    var chungtugoc=document.getElementById('txtchungtugoc').value;
    if(NgayThu=="")
    {
        alert("Chưa có ngày lập phiếu thu. Vui lòng kiểm tra lại. Cảm ơn!");
    }
    else
    {
        window.open("KTTM_rptPhieuThu.aspx?so_phieu_thu=" + SoPhieuThu + "&ngay_thu=" + NgayThu+"&soctgoc="+soctgoc+"&chungtugoc="+chungtugoc);
    }
}
function chonngay()
{
    dinhdangngay(document.getElementById('txtNgayLapPhieuThu'));
    dinhdangngay(document.getElementById('txtngaylaphd'));
}
</script>
<form id="form1" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td><uc1:menu_ketoantienmat runat="server" ID="menu_ketoantienmat1"/></td>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8"></td>
    </tr>
    <%--<tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
        </td>
    </tr>--%>    
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">            
        <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr style="height:30px; width:100%">
                    <td style="height: 30px"><div  class = "tdHeader">PHIẾU THU HÓA ĐƠN</div></td>
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
                                                            <td class="tdLabel" >Ngày lập PT:</td>
                                                            <td  class="tdText" ><input id="txtNgayLapPhieuThu" runat="server" onblur="chonngay()" style="width:100px;"   type="text"/>&nbsp(dd/mm/yyyy)</td>
                                                           
                                                            <td class="tdLabel" style="width: 127px">Mã phiếu thu : </td>
                                                            <td class="tdText"><input id="txtMaPT" disabled="disabled" runat="server"   type="text" class="InputText" /><input type="hidden" id="hdPhieuThuID" /></td>
                                                            
                                                            <td class="tdLabel" style="width: 127px">Chọn loại hóa đơn</td>
                                                            <td class="tdText">
                                                                <asp:dropdownlist id="ddlloaihd" runat="server">
                                                                    <asp:ListItem Value="8">H&#243;a đơn dịch vụ</asp:ListItem>
                                                                    <asp:ListItem Value="1">H&#243;a đơn b&#225;n thuốc lẻ</asp:ListItem>
                                                                    <asp:ListItem Value="2">H&#243;a đơn b&#225;n thuốc theo toa</asp:ListItem>
                                                                </asp:dropdownlist>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel" style="width: 127px">Mã BN/KH : </td>
                                                            <td class="tdText"><input id="txtMaKH"  type="text" onfocus="ShowKhachHang('txtMaKH')" class="InputText" /><input type="hidden" id="hd_idBenhNhan" /></td>
                                                            
                                                            <td class="tdLabel">Tên BN/KH : </td>
                                                            <td  class="tdText"><input id="txtTenKH" type="text"  onfocus="ShowKhachHang('txtTenKH')" class="InputText" /></td>
                                                            
                                                             <td class="tdLabel"> Người nộp tiền : </td>
                                                            <td  class="tdText"><input id="txtNguoiNopTien" type="text" class="InputText" /></td>
                                                           
                                                        </tr>                                          
                                                        <tr>
                                                            <td class="tdLabel" style="width: 127px">Tài khoản nợ: </td>
                                                            <td  class="tdText"><input id="txtTaiKhoanNo" type="text" class="InputText" onchange="TestMaTaiKhoan(this.id)" onfocus="ShowTaiKhoan(this.id)" /></td>
                                                            
                                                            <td class="tdLabel" style="width: 127px">Ngoại tệ: </td>
                                                            <td  class="tdText"><input id="txtNgoaiTeID" value="6" type="hidden"  onfocus="NgoaiTeSearch(this.id);" /><input id="txtNgoaiTe" type="text" class="InputText" value="VNĐ" onfocus="NgoaiTeSearch(this.id);" /></td>
                                                            
                                                            <td class="tdLabel" style="width: 127px">Tỉ giá: </td>
                                                            <td  class="tdText"><input id="txtTiGia" value="1.00" onfocus="" type="text" class="InputText"  /></td>
                                                            
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel"> Số CT gốc : </td>
                                                            <td  class="tdText"><input id="txtsoctgoc" style="width:50px" type="text" class="InputText" /></td>                                                           

                                                            <td class="tdLabel"> Chứng từ gốc : </td>
                                                            <td  class="tdText"><input id="txtchungtugoc" type="text" class="InputText" /></td>                                                           

                                                        </tr>
                                                        
                                                        <tr>
                                                            <td class="tdLabel" style="width: 127px; height: 40px;">Diễn giải : </td>
                                                            <td colspan="6"  class="tdText" style="height: 40px">
                                                                <textarea id="txtDienGiai" style="width:570px" cols="20"  rows="2"></textarea></td>
                                                            
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td colspan="6" style="padding-left:100px">
                                                                Chọn ngày lập HĐ:
                                                                <input id="txtngaylaphd" runat="server" onblur="chonngay()" style="width:70px;" type="text"/>&nbsp(dd/mm/yyyy)
                                                                <input type="button" id="bt_LoadDSPT" onclick="LoadDanhSachHoaDon()" value="Load DSHĐ" />
                                                                
                                                                <input type="button" value="Lưu" id="bt_Luu" onclick="bt_Click(this)" style="width:100px" />
                                                            
                                                                <input type="button" value="Tạo mới"  style="width:100px" onclick="TaoMoi()" id="bt_Reset" />
                                                                                                                                
                                                                <input type="button" value="IN"  style="width:100px" id="bt_in" onclick="InPhieuThuKhac()" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="9" style="text-align:center">
                                                                <label id="message"  style="display:none" > Đang xử lý vui lòng chờ trong giây lát....</label>
                                                            </td>
                                                        </tr>                                                        
                                                    </table>
                                                    
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
    <table class="TableGidview" id="TableDanhSachHD">
         <tr>
              <td class ="tdHeader" colspan="10" >DANH SÁCH HÓA ĐƠN</td>
         </tr>
		<tr class="HeaderGidView">
		     <td class="HeaderColumn0" >STT</td>
		     <td class="HeaderColumn0" id="td_checkbox" onclick='CheckAll(this)'><input  type="checkbox"  id="checkbox_all" /></td>		     
		     <td class="HeaderColumn2" style="width:10%">
		       Mã khách	       
		    </td>
		    <td class="HeaderColumn2" style="width:15%">
		       Tên Khách		       
		    </td>
		     <td class="HeaderColumn2" style="width:10%">
		       Số hóa đơn		       
		    </td>
		    <td class="HeaderColumn1" style="width:10%">
		       Ngày Lập
		    </td>
		     <td class="HeaderColumn1" style ="width:10%">
		      TK Có
		    </td>
		    <td class="HeaderColumn2" style="width:25%">
		        Diễn giải
		     </td>		   
		    <td class="HeaderColumn3" style="width:15%">
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
    <div class ="tdHeader" style="font-size:14px;padding-left:950px">Tổng tiền : <input type="text" style="width:200px;text-align:right" id="TongTien" readonly="readonly" onclick="TinhTongTien()"/><input type="hidden" id="txtTongTien" value=""></div>      
</form>
<!--#include file ="footer.htm"-->
                                