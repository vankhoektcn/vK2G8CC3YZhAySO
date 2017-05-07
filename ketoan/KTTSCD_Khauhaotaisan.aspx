<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTSCD_Khauhaotaisan.aspx.cs" Inherits="ketoan_KTTSCD_Khauhaotaisan" %>
<!--#include file = "header.htm" -->
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_TaiSan.ascx" TagName="menu_ketoantaisan" TagPrefix="uc1" %>
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
<script type="text/javascript">


 window.onload = function () 
	{
    var currentTime = new Date();
    var inam=document.getElementById("txtNam");
    inam.value=currentTime.getFullYear();
    LoadDienGiai();
    //document.getElementById('bt_TinhKhauHao').setAttribute('readOnly',true);
    phanquyen();
 };
 function phanquyen() 
	{
	    var quyenthem = '<%=StaticData.HavePermision(this.Page, "KeToanTSCD_KTTSCD_Khauhaotaisan_Them")%>';
        var quyensua = '<%=StaticData.HavePermision(this.Page, "KeToanTSCD_KTTSCD_Khauhaotaisan_Sua")%>';
        var quyenxoa = '<%=StaticData.HavePermision(this.Page, "KeToanTSCD_KTTSCD_Khauhaotaisan_Xoa")%>';
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
        if(quyenxoa == 'False')
                document.getElementById('bt_in').disabled = true;
            else
                document.getElementById('bt_in').disabled = false;
	}
function LoadDienGiai()
 {
    var nam=document.getElementById("txtNam").value;
    
    var index=document.getElementById("SelectMonth").selectedIndex;
    var thang = document.getElementsByTagName("option")[index].value;
    document.getElementById('txtDienGiai').value= "Phân bổ khấu hao tài sản tháng "+thang+"/"+nam;
 }
function GetNam()
{
    var currentTime = new Date()
    var inam=document.getElementById("txtNam");
    inam.value=currentTime.getFullYear();
}

function LoadTieuDe()
    {
        var obj = document.getElementById("tieudepk");
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                obj.innerHTML = value;                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=LoadTieuDe&times="+Math.random(),true);
        xmlHttp.send(null);
    }
function getFormatSoTien(idText)
{
    var txtPhatSinh = document.getElementById(idText);
    txtPhatSinh.value = FormatSoTien(txtPhatSinh.value);    
}
function FormatSoTien(num)
{
	    return formatCurrency(num);
}

 function TestNumberofInput(obj)
{
        var key;
        if(window.event)
        {
          key = window.event.keyCode; 
        }
        //alert(key);
        var currentvalue = document.getElementById(obj).value;
        var txtObj = document.getElementById(obj);
        //if((key<48||key>57)&&key!=190&&key!=8&&key!=9&&key!=37&&key!=38&&key!=39&&key!=40)
        if((key>=65&&key<=90))
        {
            alert("Chỉ được nhập số!");            
            txtObj.value =currentvalue;
        }
        else
        {
            var number = txtObj.value;
             if(number=="")
                number=currentvalue;
             if(!isFinite(parseFloat(number))||parseFloat(number)>999999999999)
             {   alert("Nhập sai định dạng.Chỉ được nhập số!Vui lòng kiểm tra lại cảm ơn!"); 
                 txtObj.value =currentvalue;
             }
         }     
}
function CheckTinhKhauHao(checkname)
{
    try
    {
        var f = document.tinhkhauhao;
        f.secondtime.value = "newca";
        
        var ajax = document.getElementById("ajaxkhauhao");
        ajax.style.display = "";
        
        var iCount = checkItemChecked(checkname);
        if(iCount == 0)
        {
            alert("Vui lòng chọn ít nhất một tài sản trước khi tính khấu hao!");
            return false;
        }
        f.submit();
    }
    catch(exception)
    {
        alert("Lỗi cập nhật dữ liệu!");
        return false;
    } 
}
function deleteTS(checkname)
{
    try
    {
        var f = document.tinhkhauhao;
        f.secondtime.value = "deletemultica";
        
        var ajax = document.getElementById("ajaxkhauhao");
        ajax.style.display = "";
        
        var iCount = checkItemChecked(checkname);
        if(iCount == 0)
        {
            alert("Vui lòng chọn ít nhất một tài sản trước khi xóa!");
            return false;
        }
        f.submit();
    }
    catch(exception)
    {
        alert("Lỗi xóa dữ liệu!");
        return false;
    } 
}
function SelectMonth_SelectChange(obj)
{   
    LoadDanhSachTaiSanByMonthYear();
    LoadDienGiai();
}
function LoadDanhSachTaiSanByMonthYear()
{
    var index=document.getElementById("SelectMonth").selectedIndex;    
    var Thang = document.getElementsByTagName("option")[index].value;
    var Nam = document.getElementById('txtNam').value;
    ResetTableDSTaiSan();
      xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="")
                      {
                        var row = value.split('&');
                        if(row!=null)
                        {
                            for(var i=0;i<row.length;i++)
                            {
                                var data = row[i];
                                if(data!="")
                                {
                                    var column = data.split('|');
                                    if(column.length>0)
                                    {
                                      //MaTS,TenTaiSan ,NguyenGia,SoNamKH ,TKKhauHao,TKChiPhi,ngaykhauhao,GiaTriKH = '',DienGiai = ''
                                      ShowDanhSachTaiSan(column[0],column[1],column[2],column[3],column[4],column[5],column[6],column[7],column[8]);
                                    }
                                }
                            }
                        }                                                
                      }
                      else
                      {
                        alert("Không có tài sản khấu hao trong "+Thang +"/" +Nam);
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=LoadDanhSachTaiSan&Thang="+Thang+"&Nam="+Nam+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function ShowDanhSachTaiSan(MaTS,TenTaiSan,NguyenGia,SoNamKH,TKKhauHao,TKChiPhi,NgayKhauHao,GiaTriKhauHao,DienGiai)
{
        LoadDienGiai();
        //document.getElementById('txtDienGiai').value = DienGiai;        
        var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td class=\"Column0\">" + (lastRow-1) + "</td>";          
            shtml += "		<td style=\"width:15%; text-align:left\" class=\"Column2\"><input  type=\"hidden\" id=\"hdMaTS_"+(lastRow-1)+"\" value=\""+MaTS+"\"/>"+MaTS+"</td>	";
            shtml += "		<td style=\"width:30%; text-align:left\"  class=\"Column2\">"+TenTaiSan+"</td>	";            
            shtml +="      <td  style=\"width:10%; text-align:left\"  class=\"Column2\"> <input type=\"hidden\" id=\"hdTKKhauHao_"+(lastRow-1)+"\" value=\""+TKKhauHao+"\"/>"+TKKhauHao+"</td>";            
            shtml +="      <td style=\"width:10%; text-align:left\" class=\"Column2\"> <input  type=\"hidden\" id=\"hdTkChiPhi_"+(lastRow-1)+"\" value=\""+TKChiPhi+"\"/>"+TKChiPhi+"</td>";          
            shtml +="      <td style=\"width:10%; text-align:left\"  class=\"Column2\"> <input type=\"hidden\" id=\"hdNgayKhauHao_"+(lastRow-1)+"\" value=\""+NgayKhauHao+"\"/>"+NgayKhauHao+"</td>";
            shtml += "	   <td style=\"width:15%; text-align:right\" class=\"Column2\"><input  type=\"hidden\" id=\"hdNguyenGia_"+(lastRow-1)+"\" value=\""+NguyenGia+"\"/><input type=\"hidden\" id=\"hdSoNamKH_"+(lastRow-1)+"\" value=\""+SoNamKH+"\"/><input  type=\"text\" id=\"GiaTriKhauHao_"+(lastRow-1)+"\" readonly=\"readonly\" value=\""+FormatSoTien(GiaTriKhauHao)+"\" onkeyup=\"TestNumberofInput('GiaTriKhauHao_"+(lastRow-1)+"')\" onchange=\"getFormatSoTien('GiaTriKhauHao_"+(lastRow-1)+"')\" style=\"width:200px;text-align:right\" /></td>	";          
            shtml += "	   <td class=\"Column0\"><input type=\"button\" id=\"btnSua_"+(lastRow-1)+"\" value=\"Sửa\"  onclick=\"SuaThongTinKhauHao('btnSua_"+(lastRow-1)+"','GiaTriKhauHao_"+(lastRow-1)+"','"+MaTS+"','"+TKChiPhi+"','"+NgayKhauHao+"')\"></td>	";
//          shtml += "	   <td class=\"Column0\"><label id=\"btnXoa_"+(lastRow-1)+"\" style=\"font-style:italic;color:Blue\" onclick=\"XoaThongTinKhauHao('btnXoa_"+(lastRow-1)+"','"+MaTS+"')\">Xóa</label>  </td>	";
            		              
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
 }
 function ResetTableDSTaiSan()
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
function TinhKhauHao()
{   
    var nam=document.getElementById("txtNam").value;    
    var index=document.getElementById("SelectMonth").selectedIndex;
    var thang = document.getElementsByTagName("option")[index].value;
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;    
    if(Row>2)
    {
        while(Row>2)
        {
              var idNguyenGia = "hdNguyenGia_"+(Row-2);
              var idSoThangKH = "hdSoNamKH_"+(Row-2);
              var idGiaTriKhauHao =  "GiaTriKhauHao_"+(Row-2);
              var idNgayKhauHao="hdNgayKhauHao_"+(Row-2);
              var valueNG = document.getElementById(idNguyenGia).value;
              var NguyenGia = ChangeFormatCurrency(valueNG);
              var SoThangKH = document.getElementById(idSoThangKH).value;
              var NgayKhauHao = document.getElementById(idNgayKhauHao).value;            
              xmlHttp = GetMSXmlHttp();
              xmlHttp.onreadystatechange = function()
              {
                if(xmlHttp.readyState == 4)
                {                 
                    var value = xmlHttp.responseText;                    
                    document.getElementById(idGiaTriKhauHao).value = FormatSoTien(value);                
                }
             }
            xmlHttp.open("GET","ajax.aspx?do=TinhKhauHao&ngaykhauhao="+NgayKhauHao+"&sothangkhauhao="+SoThangKH+"&nguyengia="+NguyenGia+"&thang="+thang+"&nam="+nam+"&times="+Math.random(),false);
            xmlHttp.send(null);           
            Row--;          
        }         
     }
     else
     {
        alert("Không có tài sản để tính khấu hao. Vui lòng kiểm tra lại. Cảm ơn!");
     }     
}
 function SuaThongTinKhauHao(Ctr,idGiaTriKH,MaTS,TKChiPhi,NgayKhauHao)
 {
    var btnSua = document.getElementById(Ctr);
    if(btnSua.value=="Sửa")
    {
    
      btnSua.value= "Cập nhật";
      document.getElementById(idGiaTriKH).removeAttribute('readOnly');       
    }
    else
    {
        document.getElementById(idGiaTriKH).setAttribute('readOnly', true);
        CapNhatKhauHaoTaiSan(MaTS,idGiaTriKH,TKChiPhi,NgayKhauHao)
        btnSua.value="Sửa";        
    }
 }
 function XoaThongTinKhauHao()
 {
    var index=document.getElementById("SelectMonth").selectedIndex;
   var Thang = document.getElementsByTagName("option")[index].value;
   var Nam = document.getElementById('txtNam').value;
    var rs = confirm("Bạn có chắc là muốn xóa thông tin khấu hao tài sản tháng "+Thang+"/"+Nam+ "?" );
    if(rs==true)
    {
        getFunctionXoaKhauHaoTaiSanByThangNam(Thang,Nam);
    }    
 }
 
 function getFunctionXoaKhauHaoTaiSanByThangNam(Thang,Nam)
 {
   
     xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {
                                             
                        alert("Xóa khấu hao tài sản tháng "+Thang +"/" +Nam +" thành công!");
                        LoadDanhSachTaiSanByMonthYear();
                      }
                      else
                      if(value=="0")
                      {
                        alert("Xóa khấu hao tài sản tháng "+Thang +"/" +Nam +" thất bại!");
                      }
                      else
                      {
                         alert("Không có tài sản khấu hao trong   "+Thang +"/" +Nam +".");
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=XoaKhauHaoTaiSanByThangNam&Thang="+Thang+"&Nam="+Nam+"&times="+Math.random(),true);
            xmlHttp.send(null);  
 }
 function LuuKhauHaoTaiSan()
 {
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var x;
    var rs = 1;     
    var index=document.getElementById("SelectMonth").selectedIndex;
    var valueThang = document.getElementsByTagName("option")[index].value;
    var valueNam = document.getElementById('txtNam').value;
    var valueMaTS ="";
    var valueGiaTriKH ="";
    var valueTKChiPhi="";
    var valueNgayKhauHao="";
    var valueDienGiai = document.getElementById('txtDienGiai').value;
    
    if(Row>2)
    {
        while(Row>2)
        {
        //null,sophieuthu,tkco,psco,null,soHD,NgaylapHD,tientrenHD,null,null,null,diengiai,0         
                  var idMaTS= "hdMaTS_"+(Row-2);
                  var idGiaTriKH = "GiaTriKhauHao_"+(Row-2);
                  var idtkchiphi="hdTkChiPhi_"+(Row-2);
                  var idngaykhauhao="hdNgayKhauHao_"+(Row-2);
                  valueMaTS +=";"+ document.getElementById(idMaTS).value;
                  
                  var GTKH = document.getElementById(idGiaTriKH).value;
                  valueGiaTriKH +=";"+ ChangeFormatCurrency(GTKH);
                  valueTKChiPhi += ";"+ document.getElementById(idtkchiphi).value;
                  valueNgayKhauHao += ";"+ document.getElementById(idngaykhauhao).value;
                    
            Row--;
        }
         getFunctionLuuTSCD("Save",valueMaTS,valueThang,valueNam,valueGiaTriKH,valueDienGiai,valueTKChiPhi,valueNgayKhauHao);                  
     }
     else
     {
        alert("Chưa có chi tiết tài sản khấu hao. Vui lòng kiểm tra lại.Vui lòng xóa dòng trống nếu không dùng Cảm ơn!");
            Ctr.disabled = false;
            document.getElementById('message').style.visibility = "hidden";
          //  XoaPhieuThu(SoPT);
     }
 }
 function CapNhatKhauHaoTaiSan(valueMaTS,idGiaTriKH,tkchiphi,ngaykhauhao)
 {
    var index=document.getElementById("SelectMonth").selectedIndex;
    var valueThang = document.getElementsByTagName("option")[index].value;
    var valueNam = document.getElementById('txtNam').value;
    var valueDienGiai = document.getElementById('txtDienGiai').value;
    var GTKH = document.getElementById(idGiaTriKH).value;
    var valueGiaTriKH =ChangeFormatCurrency(GTKH);
    
    if(valueGiaTriKH!=""&&valueGiaTriKH !="0")
    {
        getFunctionLuuTSCD("Update",valueMaTS,valueThang,valueNam,valueGiaTriKH,valueDienGiai,tkchiphi,ngaykhauhao);
        
    }
    else
    {
        alert("Tài sản "+valueMaTS+" chưa có giá trị khấu hao.Vui lòng kiểm tra lại cảm ơn! ");
    }
 }
 function getFunctionLuuTSCD(TypeSave,MaTS,Thang,Nam,GiaTriKhauHao,DienGiai,TKChiPhi,NgayKhauHao)
 {    
     xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {                                             
                        alert("Lưu khấu hao tài sản tháng "+Thang +"/" +Nam +" thành công!");
                        LoadDanhSachTaiSanByMonthYear();
                      }
                      else
                      if(value=="0")
                      {
                        alert("Lưu khấu hao tài sản tháng "+Thang +"/" +Nam +" thất bại!");
                      }
                      else
                      if(value=="2")
                      {
                        alert("Tài sản "+MaTS+" của tháng "+Thang +"/" +Nam +" chưa được lưu trong bảng khấu hao!");
                        TinhKhauHao();
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=LuuKhauHaoTaiSan&TypeSave="+TypeSave+"&MaTS="+MaTS+"&Thang="+Thang+"&Nam="+Nam+"&GiaTriKhauHao="+GiaTriKhauHao+"&DienGiai="+encodeURIComponent(DienGiai)+"&tkchiphi="+TKChiPhi+"&ngaykhauhao="+NgayKhauHao+"&times="+Math.random(),true);
            xmlHttp.send(null);  
 }

</script>
<form id="tinhkhauhao" name="tinhkhauhao" method="post" runat="server">
<%--<input type="hidden" name="secondtime" id="secondtime" />--%>
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:menu_ketoantaisan ID="menu_ketoantaisan1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr style="height:10px">
                    <td><div  class = "tdHeader">TÍNH KHẤU HAO TÀI SẢN</div></td>
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
                                                            <td class="tdLabel">Tháng khấu hao: </td>
                                                            <td  class="tdText">
                                                                <select id="SelectMonth" onchange="SelectMonth_SelectChange(this)" >
                                                                    <option value="1">1</option>
                                                                    <option value="2">2</option>
                                                                    <option value="3">3</option>
                                                                    <option value="4">4</option>
                                                                    <option value="5">5</option>
                                                                    <option value="6">6</option>
                                                                    <option value="7">7</option>
                                                                    <option value="8">8</option>
                                                                    <option value="9">9</option>
                                                                    <option value="10">10</option>
                                                                    <option value="11">11</option>
                                                                    <option value="12">12</option>
                                                                </select>                                                                
                                                                Năm :
                                                                <input id="txtNam" type="text" style="width:50px" />
                                                            </td>
                                                            
                                                        </tr>
                                                        
                                                        
                                                        <tr>
                                                            <td class="tdLabel">Diễn giải : </td>
                                                            <td colspan="6"  class="tdText">
                                                                <textarea id="txtDienGiai" style="width:570px" cols="20"  rows="2"></textarea></td>
                                                            
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td colspan="6" style="text-align:center">
                                                                                                                               
                                                                <input type="button" value="Tính khấu hao" id="bt_TinhKhauHao" onclick="TinhKhauHao()" style="width:100px;"  />
                                                                <input type="button" value="Lưu" id="bt_Luu" onclick="LuuKhauHaoTaiSan()" style="width:100px;"  />
                                                                <input type="button" value="Tạo mới"  style="width:100px" onclick="ResetTableDSTaiSan()" id="bt_Reset" />
                                                                <input type="button" value="Xóa"  style="width:100px" id="bt_in" onclick="XoaThongTinKhauHao()" />
                                                                
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
              <td class ="tdHeader" colspan="11" >Chi tiết khấu hao tài sản</td>
         </tr>
		<tr class="HeaderGidView">
		     <td class="HeaderColumn0">STT</td>
		    
		     <td class="HeaderColumn1" style="width:15%;">
		        Mã tài sản
		     </td>
		     
		     <td class="HeaderColumn2" style="width:30%;">
		       Tên tài sản
		       
		    </td>
		    
		    <td class="HeaderColumn2" style="width:15%; ">
		       Tài khoản khấu hao
		    </td>
		     <td class="HeaderColumn2" style="width:15%;">
		       Tài khoản chi phí
		    </td>	
		    
		    <td class="HeaderColumn2" style="width:15%;">
		       Ngày khấu hao
		    </td>
		    
		    <td class="HeaderColumn2" style="width:15%;">
		       Giá trị khấu hao
		    </td>	  
		    <td class="HeaderColumn0">
		        
		    </td>  
		    
		</tr>					 	  				 
	</table>

</form>
<!--#include file = "footer.htm" -->
                                                  