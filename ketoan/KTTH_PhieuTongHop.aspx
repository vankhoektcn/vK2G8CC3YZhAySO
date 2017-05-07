<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTH_PhieuTongHop.aspx.cs" Inherits="ketoan_KTTH_PhieuTongHop" %>

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

<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_TongHop.ascx" TagName="uscmenuKT_TongHopPTH" TagPrefix="uc1" %>
 <script language="javascript" type="text/javascript">    
    
 //========================Các hàm kiểm tra===================   
     var dp_cal;
  
	window.onload = function () 
	{
	    document.getElementById('txtMaPTH').disable=true;
	    document.getElementById('txtNgayLapPhieuTH').focus();
	    var queryString = "";
	    queryString =  window.location.search.substring(1).split('&');	    
	    if(queryString!="")
	    {
	        var idPhieuChi = queryString[0].split('=');
	        
	        //var SoPC = queryString[1].split('=');
	        //var MaNCC = queryString[2].split('=');
	        //alert(idPhieuChi);
            if(idPhieuChi[1] != "kttienmat")
            {                
                if(document.getElementById('bt_Luu').value =="Lưu")
                {
                    document.getElementById('bt_Luu').value = "Sửa";        
                }               
	            LoadPhieuChi(idPhieuChi[1]);
	        }
	        else
	        {
	            PageLoadNgoaiTe();      
	            //alert('testtttttt');  
	        }    
	    }
	    
	    //document.getElementById('txtMaPTH').focus();
	    phanquyen();
	};
	function phanquyen() 
	{
	    var quyenthem = '<%=StaticData.HavePermision(this.Page, "KeToanTM_KTTM_PhieuChiKhac_Them")%>';
        var quyensua = '<%=StaticData.HavePermision(this.Page, "KeToanTM_KTTM_PhieuChiKhac_Sua")%>';
        var quyenxoa = '<%=StaticData.HavePermision(this.Page, "KeToanTM_KTTM_PhieuChiKhac_Xoa")%>';
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
    var chungtu = document.getElementById('txtMaPTH').value;
    if(document.getElementById('bt_Luu').value =="Sửa")
    {
         document.getElementById('bt_Luu').value = "Lưu";        
    }
    else
    if(document.getElementById('bt_Luu').value =="Lưu")
    {
        if(chungtu=="")
            TaoMaSoHoaDon();
        LuuPhieuTongHop(Ctr);
        //themnhacungcap();       
    }
}	
function QuyDoiNgoaiTe()
{
    var txttongtien = 0;
    if($("#txtTiGia").val() != "")
    for(var i=2;i<document.getElementById("TableDanhSach").rows.length;i++)
    {
        var tongtien=document.getElementById("TableDanhSach").rows[i].cells[11].getElementsByTagName("input")[0].value;
        var tongtienquydoi=tongtien.replace(/\$|\,/g,'')*$("#txtTiGia").val();
        document.getElementById("TableDanhSach").rows[i].cells[12].getElementsByTagName("input")[0].value = formatCurrency1(tongtienquydoi);
        txttongtien = txttongtien + eval(tongtienquydoi);
    }
    $("#TongTien").val(formatCurrency1(txttongtien));
}
function TaoMaSoHoaDon()
{
       var Table = "phieu_tong_hop";
       var manghiepvu ="PHIEU_KE_TOAN";
       var Column = "so_phieu";
       var ngaylap=document.getElementById('txtNgayLapPhieuTH').value;
      xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="")
                      {  
                        document.getElementById('txtMaPTH').value = value;  
                      }
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=TaoMaSoTuDong&Table="+Table+"&manghiepvu="+manghiepvu+"&Column="+Column+"&ngaylap="+ngaylap+"&times="+Math.random(),false);
            xmlHttp.send(null);
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
                       //alert(value);  
                        var data = value.split('|');
                        document.getElementById('txtNgoaiTeID').value = data[0];
                        document.getElementById('txtNgoaiTe').value = data[1];
                        document.getElementById('txtTiGia').value = data[2];  
                      }
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=PageLoadNgoaiTe&times="+Math.random(),false);
            xmlHttp.send(null);
}
function LoadPhieuChi(idPhieuTongHop)
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
                        ShowPhieuChi(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7],Column[8],Column[9],Column[10]);                        
                        document.getElementById("txtMaPTH").value = Column[1];                        
                    }                    
                  }
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=LoadPhieuTongHop&idPhieuTongHop="+idPhieuTongHop+"&times="+Math.random(),false);
        xmlHttp.send(null);
}
function ShowPhieuChi(PhieuChiID,SoPhieuTongHop,NgayLap,MaNCC,TenNCC,DiaChi,DienGiai,LoaiTK,TKCo,LoaiNT,tygia)
{      
    ResetTableDSPhieuThu();  
    document.getElementById('txtMaDT').value= MaNCC;
    document.getElementById('txtTenDT').value=TenNCC;
    document.getElementById('txtdiachi').value=DiaChi;
    document.getElementById('txtMaPTH').value=SoPhieuTongHop;
    document.getElementById('hdPhieuChiID').value=PhieuChiID;
    document.getElementById('txtTaiKhoanCo').value=TKCo;
//    document.getElementById('txtNgoaiTe').value=LoaiNT;
//    document.getElementById('txtTiGia').value=tygia;
    document.getElementById('txtDienGiai').value=DienGiai;
    document.getElementById('txtNgayLapPhieuTH').value=NgayLap;
    document.getElementById('ddlloai_tk').value=LoaiTK;
    LoadChiTietPhieuTongHop(SoPhieuTongHop);
}
function LoadChiTietPhieuTongHop(SoPhieuTongHop)
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
                    var j=1;
                    while(j<Row.length)
                    {   
                        var Column = Row[j].split('&');                        
                        ShowChiTieTPhieuChi(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7],Column[8],Column[9],Column[10],Column[11],Column[12],Column[13]);
                        j++;
                    }                    
                  }
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=XemChiTietPhieuTongHop&SoPhieuTongHop="+SoPhieuTongHop+"&times="+Math.random(),false);
        xmlHttp.send(null);
}
function ShowChiTieTPhieuChi(PhieuChiID,MaDT,TenDT,TKNo,TKCo,PSNo,DienGiai,SoHD,SoSeri,NgayLapHD,ThueSuat,LoaiHD,PhongBan,loaidt)
{              
        if(NgayLapHD=="01/01/1900")
            NgayLapHD="";
       var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";                                            
            shtml += "		<td class=\"Column0\" style=\"width:50px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\" style=\"width:50px\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/></td>";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"txtMaDT_"+(lastRow)+"\" value=\""+MaDT+"\"  onfocus=\"ShowDoiTuong(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"txtTenDT_"+(lastRow)+"\" value=\""+TenDT+"\"   onfocus=\"ShowDoiTuong(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "      <td class=\"Column3_CK\" style=\"display:block\"><input type=\"hidden\" id =\"txtLoaiDT_"+(lastRow)+"\" value=\""+loaidt+"\" /></td>";
            shtml +="       <td class=\"Column3_CK\"><input type=\"text\" id =\"DienGiai_"+(lastRow)+"\" value=\""+DienGiai+"\" style=\"width:99%;text-align:left\" /></td>";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoHD_"+(lastRow)+"\" value=\""+SoHD+"\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoSeri_"+(lastRow)+"\" value=\""+SoSeri+"\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"NgayLapHD_"+(lastRow)+"\" value=\""+NgayLapHD+"\" onchange=\"TestDate(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml +="       <td class=\"Column3_CK\"><input type=\"text\" id =\"Vat_"+(lastRow)+"\" value=\""+ThueSuat+"\" style=\"width:99%;text-align:left\" /></td>";
            shtml +="       <td class=\"Column3_CK\"><input type=\"text\" id =\"LoaiHoaDon_"+(lastRow)+"\" value=\""+LoaiHD+"\" style=\"width:99%;text-align:left\" /></td>";
            shtml +="       <td class=\"Column3_CK\"><input type=\"text\" id =\"PhongBan_"+(lastRow)+"\" value=\""+PhongBan+"\" style=\"width:99%;text-align:left\" /></td>";            
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"TaiKhoanNo_"+(lastRow)+"\" value=\""+TKNo+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"TaiKhoanCo_"+(lastRow)+"\" value=\""+TKCo+"\" onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"PhatSinhNo_"+(lastRow)+"\" value=\""+ formatCurrency1(eval(PSNo)) +"\" onchange=\"getFormatSoTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" /></td>	"; 
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"ThanhTien_"+(lastRow)+"\" value=\""+ formatCurrency1(eval(PSNo)) +"\"  readonly=\"readonly\"  onkeyup=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" /></td>	";                                          
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
      //TinhThanhTien_IDRow(lastRow);
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
function formatCurrency1(num){
            Number.prototype.formatMoney = function(c, d, t){
            var n = this, c = isNaN(c = Math.abs(c)) ? 2 : c, d = d == undefined ? "," : d, t = t == undefined ? "." : t, s = n < 0 ? "-" : "", i =  parseInt(n = Math.abs(+n || 0).toFixed(c)) + "", j = (j = i.length) > 3 ? j % 3 : 0;
               return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
             };
            return num.formatMoney(2,'.',',');
         }
function getFormatSoTien(Ctr)
{
    var idText = Ctr.id;   
    var txtPhatSinh = document.getElementById(idText);    
    txtPhatSinh.value = formatCurrency1(eval(txtPhatSinh.value));        
}
function FormatSoTien(obj)
{
	    return formatCurrency1(obj);
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
    //document.getElementById('txtMaPTH').focus();
    document.getElementById('txtMaDT').value="";
    document.getElementById('txtTenDT').value="";
    document.getElementById('txtMaPTH').value="";
    document.getElementById('hdPhieuChiID').value="";
    
    document.getElementById('txtTaiKhoanCo').value="";
    document.getElementById('txtDienGiai').value="";
    document.getElementById('txtNgayLapPhieuTH').value="";
    //document.getElementById('LoaiTK').value="";
    
    ResetTableDSPhieuThu();                            
    
    document.getElementById('bt_Luu').value="Lưu";
    //TaoMaSoHoaDon();
    PageLoadNgoaiTe();
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
                                                    {width:400,scroll:true,formatItem:function(data)
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
            $(Ctr).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachDoiTuong&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:300,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    setChonNCC(data[2],data[3],data[4],data[5]);
                                                                  //  document.getElementById(obj).blur();
                                                                }
                                                            ); 
    
}

function setChonNCC(MaNCC,TenNCC,DiaChi,loaidt)
{      
      var txtMaDT=document.getElementById('txtMaDT');
      var txtTenDT=document.getElementById('txtTenDT');
      document.getElementById('txtdiachi').value=DiaChi;           
      txtMaDT.value=MaNCC;
      txtTenDT.value = TenNCC;      
      document.getElementById('txtloaidt').value=loaidt;           
      //alert(hd_IDBN.value);
      document.getElementById('txtTenDT').focus();
}
function ShowDoiTuong(Ctr)
{
        var obj = Ctr.id;
        var objsrc = document.getElementById(obj);
      
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachDoiTuong2&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj.substring(0,obj.length-2),
                                                        {width:300,scroll:true,formatItem:function(data)
                                                            { if(data!="") return data[1];}
                                                        }
                                                    ).result(
                                                                 function(event,data)
                                                                {
                                                                    setChonDT(data[2],data[3],data[4],obj);
                                                                    document.getElementById(obj).blur();
                                                                }
                                                            ); 
    
}
function setChonDT(MaNCC,TenNCC,LoaiDT,obj)
{                   
      var dong=obj.substring(obj.length-1);     
      //alert(dong);
     document.getElementById('TableDanhSach').rows[dong].cells[2].getElementsByTagName("input")[0].value=MaNCC;
     document.getElementById('TableDanhSach').rows[dong].cells[3].getElementsByTagName("input")[0].value=TenNCC; 
     document.getElementById('TableDanhSach').rows[dong].cells[4].getElementsByTagName("input")[0].value=LoaiDT; 
     document.getElementById('TableDanhSach').rows[dong].cells[5].getElementsByTagName("input")[0].focus();
}
function phongSearch(Ctr)
         {            
             var obj = Ctr.id;          
             var objsrc = document.getElementById(obj);      
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=phongSearch&Key="+encodeURIComponent(objsrc.value),
                                                        {width:300,scroll:true,formatItem:function(data)
                                                            { if(data!="") return data[1];}
                                                        }
                                                    ).result(
                                                                 function(event,data)
                                                                {
                                                                    setChonPB(data[2],data[3],obj);                                                                    
                                                                }
                                                            ); 
         }
function setChonPB(maphong,tenphong,obj)
{    
     var dong=obj.substring(obj.length-1);           
     document.getElementById('TableDanhSach').rows[dong].cells[11].getElementsByTagName("input")[0].value=tenphong;
}
function ThemDong()
{     
    var loaitk=document.getElementById('ddlloai_tk').value;    
    var taikhoan=document.getElementById('txtTaiKhoanCo').value;
    var madt=document.getElementById('txtMaDT').value;
    var tendt=document.getElementById('txtTenDT').value;
    var loaidt=document.getElementById('txtloaidt').value;
    var TableDanhSach = document.getElementById('TableDanhSach');        
    var lastRow = TableDanhSach.rows.length;                      
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td class=\"Column0\" style=\"width:50px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\" style=\"width:50px\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/></td>";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"txtMaDT_"+(lastRow)+"\"  onfocus=\"ShowDoiTuong(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"txtTenDT_"+(lastRow)+"\"   onfocus=\"ShowDoiTuong(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml +="       <td class=\"Column3_CK\" style=\"display:block\"><input type=\"hidden\" id =\"txtLoaiDT_"+(lastRow)+"\" /></td>";
            shtml +="       <td class=\"Column3_CK\"><input type=\"text\" id =\"DienGiai_"+(lastRow)+"\" style=\"width:99%;text-align:left\" /></td>";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoHD_"+(lastRow)+"\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoSeri_"+(lastRow)+"\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"NgayLapHD_"+(lastRow)+"\" onchange=\"TestDate(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml +="       <td class=\"Column3_CK\"><input type=\"text\" id =\"Vat_"+(lastRow)+"\" style=\"width:99%;text-align:left\" /></td>";
            shtml +="       <td class=\"Column3_CK\"><select style=\"width:99%;text-align:center\" id=\"LoaiHoaDon_"+(lastRow)+"\"><option value=\"0\"> </option><option value=\"1\">Trực tiếp</option><option value=\"1\">GTGT</option></select></td>";
            shtml +="       <td class=\"Column3_CK\"><input type=\"text\" id =\"PhongBan_"+(lastRow)+"\" style=\"width:99%;text-align:left\" onfocus=\"phongSearch(this)\" /></td>";            
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"TaiKhoanNo_"+(lastRow)+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"TaiKhoanCo_"+(lastRow)+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"PhatSinhNo_"+(lastRow)+"\" onchange=\"getFormatSoTien(this);TinhThanhTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" /></td>	"; 
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"ThanhTien_"+(lastRow)+"\" readonly=\"readonly\"  onclick=\"TinhThanhTien(this)\" onkeyup=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" /></td>	"; 
         shtml += "	</tr>";     
      $("#TableDanhSach:last").append(shtml);
       if(loaitk==0)
        document.getElementById('TableDanhSach').rows[lastRow].cells[12].getElementsByTagName("input")[0].value=taikhoan;
      else
      document.getElementById('TableDanhSach').rows[lastRow].cells[13].getElementsByTagName("input")[0].value=taikhoan;
      document.getElementById('TableDanhSach').rows[lastRow].cells[2].getElementsByTagName("input")[0].value=madt;
      document.getElementById('TableDanhSach').rows[lastRow].cells[3].getElementsByTagName("input")[0].value=tendt;
      document.getElementById('TableDanhSach').rows[lastRow].cells[4].getElementsByTagName("input")[0].value=loaidt;
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
             TableDanhSach.rows[i].cells[2].getElementsByTagName("input")[0].id = "txtMaDT_"+i;
             TableDanhSach.rows[i].cells[3].getElementsByTagName("input")[0].id = "txtTenDT_"+i;
             TableDanhSach.rows[i].cells[4].getElementsByTagName("input")[0].id = "DienGiai_"+i;             
             TableDanhSach.rows[i].cells[5].getElementsByTagName("input")[0].id = "SoHD_"+i;             
             TableDanhSach.rows[i].cells[6].getElementsByTagName("input")[0].id = "SoSeri_"+i;
             TableDanhSach.rows[i].cells[7].getElementsByTagName("input")[0].id = "NgayLapHD_"+i;
             TableDanhSach.rows[i].cells[8].getElementsByTagName("input")[0].id = "Vat_"+i;             
             TableDanhSach.rows[i].cells[9].getElementsByTagName("input")[0].id = "LoaiHoaDon_"+i;             
             TableDanhSach.rows[i].cells[10].getElementsByTagName("input")[0].id = "PhongBan_"+i;             
             TableDanhSach.rows[i].cells[11].getElementsByTagName("input")[0].id = "TaiKhoanNo_"+i;
             TableDanhSach.rows[i].cells[12].getElementsByTagName("input")[0].id = "TaiKhoanCo_"+i;
             TableDanhSach.rows[i].cells[13].getElementsByTagName("input")[0].id = "PhatSinhNo_"+i;
             TableDanhSach.rows[i].cells[14].getElementsByTagName("input")[0].id = "ThanhTien_"+i;
        }
      }
        TinhTongTien();
}
//================================================================================================================
function TinhThanhTien_IDRow(RowID)
{  
    var idPhatSinhNo = "PhatSinhNo_"+RowID;
    var valuePhatSinhNo = document.getElementById(idPhatSinhNo).value;   
    valuePhatSinhNo=valuePhatSinhNo.replace(/\$|\,/g,'');           
    //var tigia = $("#txtTiGia").val().replace(/\$|\,/g,'');               
    //document.getElementById("ThanhTien_"+RowID).value = formatCurrency1(valuePhatSinhNo * tigia );      
    document.getElementById("ThanhTien_"+RowID).value = formatCurrency1(valuePhatSinhNo);      
    TinhTongTien();
}
function TinhThanhTien(Ctr)
{
    var IDCtr = Ctr.id;
    var RowID = IDCtr.split('_')[1];   
    var idPhatSinhNo = "PhatSinhNo_"+RowID;
    var valuePhatSinhNo = document.getElementById(idPhatSinhNo).value;                
    var idThanhTien = "ThanhTien_"+RowID;    
    valueThanhTien = eval(valuePhatSinhNo.replace(/\$|\,/g,''));
    //document.getElementById(idThanhTien).value = formatCurrency1( eval(valueThanhTien) * eval($("#txtTiGia").val().replace(/\$|\,/g,'')));
    document.getElementById(idThanhTien).value = formatCurrency1(eval(valueThanhTien));
    //CongTongTien(eval(valueThanhTien) * eval($("#txtTiGia").val().replace(/\$|\,/g,'')));
    CongTongTien(eval(valueThanhTien));
    TinhTongTien();
}
 var TongTien = 0;
function CongTongTien(ThanhTien)
{
    var txtTongTien = document.getElementById('TongTien');
    txtTongTien.value = formatCurrency1(ThanhTien);     
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
                Tien =  eval(count) + (eval(sotien.value.replace(/\$|\,/g,'')));
            }                                       
        }
     }     
    var txtTongTien = document.getElementById('TongTien');
    txtTongTien.value = formatCurrency1(Tien);     
}
//================================================================================================================
//=============================================Lưu phiếu chi khác=================================================
//================================================================================================================
function LuuPhieuTongHop(Ctr)
{
    Ctr.disabled  = true;
    document.getElementById('message').style.visibility = "visible";
    var PhieuChiID = document.getElementById('hdPhieuChiID').value;
    var SoPhieuTongHop = document.getElementById('txtMaPTH').value;
    var NgayLap = document.getElementById('txtNgayLapPhieuTH').value;
    var MaNCC = document.getElementById('txtMaDT').value;
    var LoaiTK = document.getElementById('ddlloai_tk').value;
//    var Loai_nt = document.getElementById('txtNgoaiTeID').value;
//    var TiGia = document.getElementById('txtTiGia').value;
    var Loai_nt="";
    var TiGia="1"
    var DienGiai = document.getElementById('txtDienGiai').value;
    var TKCo = document.getElementById('txtTaiKhoanCo').value;
    var UserDau = "Tăng Thúy Ngọc";
    var UserCuoi = "CyberTang";
    var Status = 0;
    if(SoPhieuTongHop=="*_*--*_*")
    {
        alert("Chưa nhập số phiếu . Vui lòng kiểm tra lại, cảm ơn!");
        Ctr.disabled = false;
        document.getElementById('message').style.visibility = "hidden";
    }
    else
    if(NgayLap=="")
    {
        alert("Chưa chọn ngày lập. Vui lòng kiểm tra lại, cảm ơn!");
        Ctr.disabled = false;
          document.getElementById('message').style.visibility = "hidden";
    }
    else    
    if(TKCo=="")
    {
        alert("Chưa chọn tài khoản. Vui lòng kiểm tra lại, cảm ơn!");
        Ctr.disabled = false;
        document.getElementById('message').style.visibility = "hidden";
    }         
    else
        getFunctionLuuPhieuTongHop(Ctr,PhieuChiID,SoPhieuTongHop,NgayLap,MaNCC,LoaiTK,DienGiai,TKCo,UserDau,UserCuoi,Status,Loai_nt,TiGia);
}
function getFunctionLuuPhieuTongHop(Ctr,PhieuChiID,SoPhieuTongHop,NgayLap,MaNCC,LoaiTK,DienGiai,TKCo,UserDau,UserCuoi,Status,Loai_nt,TiGia)
{    
     xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;                    
                      if (value=="1")
                      {  
                        XoaChiTietPhieuTongHop(Ctr,SoPhieuTongHop);                      
                      }
                      else
                      {
                        alert("Lưu phiếu tổng hợp thất bại!");
                      }
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=LuuPhieuTongHop&PhieuChiID="+PhieuChiID+"&Loai_nt="+Loai_nt+"&TiGia="+TiGia+"&SoPhieu="+SoPhieuTongHop+"&NgayLap="+NgayLap+"&MaNCC="+MaNCC+"&LoaiTK="+encodeURIComponent(LoaiTK)+"&DienGiai="+encodeURIComponent(DienGiai)+"&TKCo="+TKCo+"&TongTien="+TongTien+"&UserDau="+encodeURIComponent(UserDau)+"&UserCuoi="+encodeURIComponent(UserCuoi)+"&Status="+Status+"&times="+Math.random(),false);
            xmlHttp.send(null);
}
//================================================================================================================
//=============================================Lưu chi tiết phiếu chi khác=================================================
//================================================================================================================
function XoaPhieuTongHop(SoPhieuTongHop)
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
              xmlHttp.open("GET","ajax.aspx?do=XoaPhieuTongHop&SoPhieuTongHop="+SoPhieuTongHop+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function XoaChiTietPhieuTongHop(Ctr,SoPhieuTongHop)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;                     
                    XoaSoCai_PhieuTongHop(Ctr,SoPhieuTongHop);  
                                 
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=XoaChiTietPhieuTongHop&SoPhieuTongHop="+SoPhieuTongHop+"&times="+Math.random(),false);
            xmlHttp.send(null);
}
function XoaSoCai_PhieuTongHop(Ctr,SoPhieuTongHop)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;                   
                    LuuChiTietPhieuTongHop(Ctr);                    
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=XoaSoCai_PhieuTongHop&SoPhieuTongHop="+SoPhieuTongHop+"&times="+Math.random(),false);
            xmlHttp.send(null);
}
function LuuChiTietPhieuTongHop(Ctr)
{     
    var PhieuChiID = document.getElementById('txtMaPTH').value;
    var SoPhieuTongHop = document.getElementById('txtMaPTH').value;  
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var x;
    var rs = 1;
    var valueMaDT;
    var valueTenDT;
    var valueTkNo ="";
    var valueTkCo ="";
    var valuePhatSinhNo ="";    
    var valueThueSuat="";    
    var valueSoHD="";
    var valueSoSeri="";
    var valueNgayLapHD="";
    var valueDienGiai="";
    var valueLoaiHD="";
    var valuePhongBan="";
    var valueloaidt="";
    var flag = false;      
    if(Row>2)
    {
        for(var i=2;i<Row;i++)
        {
             
                var MaDT="txtMaDT_"+i;
                var TenDT="txtTenDT_"+i;
                var DienGiai = "DienGiai_"+i;
                var TKNo = "TaiKhoanNo_"+i;
                var TKCo = "TaiKhoanCo_"+i;
                var PhatSinhNo = "PhatSinhNo_"+i;               
                var SoHD = "SoHD_"+i;                
                var SoSeri = "SoSeri_"+i;                           
                var NgayLapHD = "NgayLapHD_"+i;
                var ThueSuat = "Vat_"+i;
                var LoaiHD="LoaiHoaDon_"+i;
                var PhongBan="PhongBan_"+i;
                var loaidt="txtLoaiDT_"+i;
                
             if(document.getElementById(TKNo).value=="")
             {
                alert("Chưa nhập tài khoản nợ. Vui lòng kiểm tra lại.");
                 XoaPhieuTongHop(SoPhieuTongHop);document.getElementById('message').style.visibility = "hidden";
                Ctr.disabled = false;
                 XoaPhieuTongHop(SoPhieuTongHop);
                
             }
             else
             if(document.getElementById(TKCo).value=="")
             {
                alert("Chưa nhập tài khoản có. Vui lòng kiểm tra lại.");
                 XoaPhieuTongHop(SoPhieuTongHop);document.getElementById('message').style.visibility = "hidden";
                Ctr.disabled = false;
                 XoaPhieuTongHop(SoPhieuTongHop);                
             }      
             else
             if(document.getElementById(PhatSinhNo).value=="")
             {
                alert("Chưa nhập số phát sinh. Vui lòng kiểm tra lại.");
                 XoaPhieuTongHop(SoPhieuTongHop);document.getElementById('message').style.visibility = "hidden";
                Ctr.disabled = false;
                 XoaPhieuTongHop(SoPhieuTongHop);                
             }                    
             else
             {
               flag= true;
                 valueMaDT+=";"+ document.getElementById(MaDT).value;
                 valueTenDT+=";"+ document.getElementById(TenDT).value;
                 valueDienGiai +=";"+ document.getElementById(DienGiai).value;
                 valueTkNo +=";"+ document.getElementById(TKNo).value;
                 valueTkCo +=";"+ document.getElementById(TKCo).value;                                 
                 var PSNo = document.getElementById(PhatSinhNo).value;
                 valuePhatSinhNo +=";"+ PSNo.replace(/\$|\,/g,'');                                                        
                 valueThueSuat +=";"+ document.getElementById(ThueSuat).value;                                                                                            
                                 
                 valueSoHD +=";"+ document.getElementById(SoHD).value;
                                
                 valueSoSeri +=";"+ document.getElementById(SoSeri).value;
                             
                 valueNgayLapHD +=";"+ document.getElementById(NgayLapHD).value;
                 
                 valueLoaiHD+=";"+ document.getElementById(LoaiHD).value;
                 valuePhongBan+=";"+ document.getElementById(PhongBan).value; 
                 valueloaidt+=";"+document.getElementById(loaidt).value;
             }
        }
        if(flag)
        {
             getFunctionLuuChiTietPhieuTongHop(Ctr,SoPhieuTongHop,valueMaDT,valueTenDT,valueDienGiai,valueTkNo,valueTkCo,valuePhatSinhNo,valueThueSuat,valueSoHD,valueSoSeri,valueNgayLapHD,valueLoaiHD,valuePhongBan,valueloaidt);
        }
         else
         {
            alert("Chưa có chi tiết phiếu tổng hợp.Vui lòng kiểm tra lại, cảm ơn!");
            document.getElementById('message').style.visibility = "hidden";
            Ctr.disabled = false;
            XoaPhieuTongHop(SoPhieuTongHop);
         }    
     }
     else
     {
        alert("Chưa có chi tiết phiếu tổng hợp.Vui lòng kiểm tra lại, cảm ơn!");
        document.getElementById('message').style.visibility = "hidden";
        Ctr.disabled = false;
        XoaPhieuTongHop(SoPhieuTongHop);
     }
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
/*function QuyDoiNgoaiTe()
{
    if($("#txtTiGia").val() != "")
    for(var i=2;i<document.getElementById("TableDanhSach").rows.length;i++)
    {
        var tongtien=document.getElementById("TableDanhSach").rows[i].cells[11].getElementsByTagName("input")[0].value;
        var tongtienquydoi=tongtien.replace(/\$|\,/g,'')*$("#txtTiGia").val();
        document.getElementById("TableDanhSach").rows[i].cells[12].getElementsByTagName("input")[0].value = formatCurrency1(tongtienquydoi);
    }
}*/
function getFunctionLuuChiTietPhieuTongHop(Ctr,SoPhieuTongHop,MaDT,TenDT,DienGiai,TKNo,TKCo,PhatSinhNo,ThueSuat,SoHD,SoSeri,NgayLapHD,LoaiHD,PhongBan,loaidt)
{   
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;                   
                      if (value=="1")
                      {                          
                        //alert('lưu thành công!');
                        LuuSoCai_PhieuChiKhac(Ctr,MaDT,TKNo,TKCo,PhatSinhNo,DienGiai,SoHD,SoSeri,NgayLapHD,ThueSuat,loaidt);       
                      }
                      else
                      {                      
                         alert("Lưu chi tiết phiếu chi thất bại!");
                         document.getElementById('message').style.visibility = "hidden";
                         Ctr.disabled = false;
                         XoaPhieuTongHop(SoPhieuTongHop);
                      }                     
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=LuuChiTietPhieuTongHop&SoPhieuTongHop="+SoPhieuTongHop+"&MaDT="+MaDT+"&TenDT="+TenDT+"&TKNo="+TKNo+"&TKCo="+TKCo+"&PhatSinhNo="+PhatSinhNo+"&ThueSuat="+ThueSuat+"&DienGiai="+encodeURIComponent(DienGiai)+"&SoHD="+SoHD+"&SoSeri="+SoSeri+"&NgayLapHD="+NgayLapHD+"&LoaiHD="+encodeURIComponent(LoaiHD)+"&PhongBan="+encodeURIComponent(PhongBan)+"&loaidt="+loaidt+"&times="+Math.random(),false);
            xmlHttp.send(null);
}
function LuuSoCai_PhieuChiKhac(Ctr,MaDT,TKNo,TKCo,PhatSinhNo,DienGiai,SoHD,SoSeri,NgayLapHD,ThueSuat,loaidt)
{    
    var SoPhieuTongHop = document.getElementById('txtMaPTH').value;
    var loaidt = document.getElementById('txtloaidt').value;
    var iskh="";
    var isncc="";
    if(loaidt=="kh")
        iskh="1";
    else
        isncc="1";
    var NgayLap = document.getElementById('txtNgayLapPhieuTH').value;
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
                        alert("Lưu  phiếu tổng hợp thành công!");
                        ResetTableDSPhieuThu();
                        LoadChiTietPhieuTongHop(SoPhieuTongHop);      
                        document.getElementById('bt_Luu').value ="Sửa";
                    }
                    else
                    {
                        alert("Lưu phiếu tổng hợp thất bại!");
                        XoaPhieuTongHop(SoPhieuTongHop);
                    }
                    Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";                                            
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=LuuSoCai_PhieuTongHop&SoPhieuTongHop="+SoPhieuTongHop+"&NgayLap="+NgayLap+"&MaDT="+MaDT+"&TKCo="+TKCo+"&TKNo="+TKNo+"&PhatSinhNo="+PhatSinhNo+"&DienGiai="+encodeURIComponent(DienGiai)+"&SoHD="+SoHD+"&SoSeri="+SoSeri+"&NgayLapHD="+NgayLapHD+"&ThueSuat="+ThueSuat+"&UserDau="+UserDau+"&UserCuoi"+UserCuoi+"&iskh="+iskh+"&isncc="+isncc+"&times="+Math.random(),false);
            xmlHttp.send(null);
}
function In_phieu_chi()
{
    var SoPhieuTongHop=document.getElementById('txtMaPTH').value;
    var NgayLap =document.getElementById ('txtNgayLapPhieuTH').value;
    if(NgayLap=="")
    {
        alert('Chưa có ngày lập phiếu kế toán, xin nhập vào!');
    }
    else
        window.open("KTTH_rptPhieu_Tong_Hop.aspx?so_phieu_kt=" + SoPhieuTongHop + "&ngay_lap=" + NgayLap);
}

function kiemtramaphieuchi()
{
    var tenbang="phieu_tong_hop";
    var tenfield="so_phieu";
    var dieukien=document.getElementById('txtMaPTH').value;       
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {            
            var value=xmlHttp.responseText;
            if (value==1)
            {
                alert('Số phiếu này đã có, xin nhập lại số khác!');
                document.getElementById('txtMaPTH').focus();
            }            
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrathongtinTable&tenbang="+tenbang+"&tenfield="+tenfield+"&dieukien="+dieukien,"&times="+Math.random(),true);
    xmlHttp.send(null);    
}
function NgayLap()
{
    dinhdangngay(document.getElementById('txtNgayLapPhieuTH'));
}
//ham kiem tra ma khach hang da co hay chua
function kiemtramancc()
{
    var tenbang="nhacungcap";
    var tenfield="manhacungcap";    
    var dieukien=document.getElementById('txtMaDT').value;  
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
              document.getElementById('txtTenDT').focus();                               
            }           
        else
            document.getElementById('txtNguoiGiaoTien').focus();            
     }
}
function themnhacungcap()
{
    var mancc=document.getElementById('txtMaDT').value;
    var tenncc=document.getElementById('txtTenDT').value;
    var nguoilienhe=document.getElementById('txtNguoiGiaoTien').value;
    var nganhang="";
    var tknganhang="";
    var diachi=document.getElementById('txtdiachi').value;  
    xmlHttp=GetMSXmlHttp();
    xmlHttp.open("GET","ajax.aspx?do=themnhacungcap&mancc="+mancc+"&tenncc="+encodeURIComponent(tenncc)+"&diachi="+encodeURIComponent(diachi)+"&nguoilienhe="+encodeURIComponent(nguoilienhe)+"&nganhang="+encodeURIComponent(nganhang)+"&tknganhang="+tknganhang+"&times="+Math.random(),true);
    xmlHttp.send(null);    
}
</script>
<form id="form1" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:uscmenuKT_TongHopPTH ID="uscmenuKT_TongHopPTH1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr style="height:10px">
                    <td><div  class = "tdHeader">PHIẾU KẾ TOÁN</div></td>
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
                                                            <td class="tdLabel" >Ngày lập :</td>
                                                            <td  class="tdText" ><input id="txtNgayLapPhieuTH"  runat="server" onblur="NgayLap();" style="width:100px;"   type="text"/>&nbsp (dd/mm/yyyy)</td>                                                                                                                      
                                                            <td class="tdLabel">Chứng từ : </td>
                                                            <td class="tdText"><input  id="txtMaPTH"  type="text" runat="server" disabled="disabled" class="InputText" /><input type="hidden" id="hdPhieuChiID" /></td>
                                                            <td class="tdLabel"> </td>
                                                            <td class="tdText"><input  id="txtMa_kt"  type="hidden" disabled="disabled" class="InputText" /><input type="hidden" id="txtloaidt" /></td>
                                                        </tr>
                                                        <tr>                                                                                                                                                                                 
                                                            <td class="tdLabel">Tên đối tượng: </td>
                                                            <td  class="tdText"><input id="txtTenDT" type="text"  onfocus="ShowNhaCungCap(this)" class="InputText" /></td>
                                                            
                                                             <td class="tdLabel"> Địa chỉ : </td>
                                                            <td  class="tdText" style="width:400px"><input id="txtdiachi" type="text" style="width:400px" class="InputText" /><input id="txtMaDT"  type="hidden" />                                      </td>                                                              
                                                        </tr>                                                                                                       
                                                        <tr>
                                                            <td class="tdLabel">Loại tài khoản:</td>
                                                            <td class="tdText">
                                                                <asp:dropdownlist id="ddlloai_tk" runat="server">
                                                                    <asp:ListItem Value="0">Tài Khoản Nợ</asp:ListItem>
                                                                    <asp:ListItem Value="1">Tài Khoản Có</asp:ListItem>                                                                    
                                                                </asp:dropdownlist>
                                                            </td>
                                                            <td class="tdLabel">Chọn TK: </td>
                                                            <td  class="tdText"><input id="txtTaiKhoanCo" type="text" class="InputText" onchange="TestMaTaiKhoan(this)" onfocus="ShowTaiKhoan(this)" /></td>
                                                            
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
              <td class ="tdHeader" colspan="16" >Chi tiết phiếu kế toán</td>
         </tr>
		<tr class="HeaderGidView">
		     <td class="HeaderColumn0_CK">STT</td>
		    <td class="HeaderColumn0_CK">Xóa</td>		    
		    <td class="HeaderColumn1_CK">		    
		        Mã ĐT
		    </td>		    
		    <td class="HeaderColumn1_CK">
		        Tên Đối Tượng
		    </td>	
		      <td style="display:block; ">		       
		    </td>	    	
		    <td class="HeaderColumn2_CK">
		        Diễn giải   
		    </td>	   
		   
		    <td class="HeaderColumn2_CK">
		        Số HĐ
		    </td>
		    <td class="HeaderColumn2_CK">
		        Số Seri
		    </td>
		    <td class="HeaderColumn2_CK">
		        Ngày lập HD
		    </td>		        		     
		    <td class="HeaderColumn2_CK">
		        VAT
		    </td>
		    <td class="HeaderColumn1_CK">
		        Loại HD
		    </td>
		     <td class="HeaderColumn2_CK">
		        Phòng Ban
		    </td>		    		    	    	    
             <td class="HeaderColumn2_CK">
		        TK Nợ    
		    </td>
		    <td class="HeaderColumn2_CK">
		        TK Có
		    </td>	
		    <td class="HeaderColumn1_CK" style="width:100px">
		        Phát sinh 
		    </td>	
		    <td class="HeaderColumn1_CK" style=" width:100px">
		        Thành Tiền
		        
		    </td>	  	    
		</tr>					  
	</table>         
    <div class ="tdHeader" style="font-size:14px; padding-left:86%">Tổng tiền :<input type="text" style="width:110px;text-align:right" readonly="readonly" id="TongTien" /></div>      
    <div><input type="button" id="bt_ThemDong" value="Thêm dòng" onclick="ThemDong()"/><input type="button" id="bt_XoaDong" value="Xóa dòng" onclick="XoaDong()" /></div>
</form>
<!--#include file ="footer.htm"-->