<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTSCD_KhauHaoCCDC.aspx.cs" Inherits="ketoan_KTTSCD_KhauHaoCCDC" %>
<!--#include file = "header.htm" -->
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_CCDC.ascx" TagName="uscmenuKT_CCDC" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%--<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_TaiSan.ascx" TagName="menu_ketoantaisan" TagPrefix="uc1" %>
--%><link type="text/css" rel="stylesheet" href="../ketoan/css_KeToan/sheet_index.css" />
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
    phanquyen();
 };
 function phanquyen() 
	{
	    var quyenthem = '<%=StaticData.HavePermision(this.Page, "KeToanCCDC_KTTSCD_KhauHaoCCDC_Them")%>';
        var quyensua = '<%=StaticData.HavePermision(this.Page, "KeToanCCDC_KTTSCD_KhauHaoCCDC_Sua")%>';
        var quyenxoa = '<%=StaticData.HavePermision(this.Page, "KeToanCCDC_KTTSCD_KhauHaoCCDC_Xoa")%>';
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
    document.getElementById('txtDienGiai').value= "Phân bổ khấu hao công cụ dụng cụ tháng "+thang+"/"+nam;
 }
function GetNam()
{
    var currentTime = new Date()
    var inam=document.getElementById("txtNam");
    inam.value=currentTime.getFullYear();
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

function SelectMonth_SelectChange(obj)
{
    LoadDienGiai();
    LoadDanhSachCCDCByMonthYear();
}

function LoadDanhSachCCDCByMonthYear()
{
    var index=document.getElementById("SelectMonth").selectedIndex;
    
    var Thang = document.getElementsByTagName("option")[index].value;
    var Nam = document.getElementById('txtNam').value;
    ResetTableDSCCDC();
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
                                        //ccdc.Ma_CCDC,dm.Ten_CCDC,dm.Nguyen_Gia,dm.So_Thang_Khau_Hao ,dm.TK_Phan_Bo ,dm.TK_Chi_Phi ,ccdc.GiaTriKH  ,ccdc.Dien_Giai
                                      ShowDanhSachCCDC(column[0],column[1],column[2],column[3],column[4],column[5],column[6],column[7],column[8]);
                                    }
                                }
                            }
                        }                                                
                      }
                      else
                      {
                        alert("Không có CCDC khấu hao trong "+Thang +"/" +Nam);
                      }
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=LoadDanhSachCongCuDungCu&Thang="+Thang+"&Nam="+Nam+"&times="+Math.random(),false);
            xmlHttp.send(null);
//            xmlHttp.open("GET","ajax.aspx?do=LoadDanhSachCongCuDungCu&Thang="+Thang+"&Nam="+Nam+"&times="+Math.random(),true);
//            xmlHttp.send(null);
}
function ShowDanhSachCCDC(MaCCDC,TenCCDC,NguyenGia,SoThangKH,TKKhauHao,TKChiPhi,NgayKhauHao,GiaTriKhauHao,DienGiai)
{        
        var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td class=\"Column0\">" + (lastRow-1) + "</td>";
          
            shtml += "		<td class=\"Column2\" style=\"text-align:left\"><input type=\"hidden\" id=\"hdMaCCDC_"+(lastRow-1)+"\" value=\""+MaCCDC+"\"/>"+MaCCDC+"</td>	";
            shtml += "		<td class=\"Column2\" style=\"text-align:left\">"+TenCCDC+"</td>	";
            shtml +="      <td class=\"Column2\" style=\"text-align:left\"> <input type=\"hidden\" id=\"hdNgayKhauHao_"+(lastRow-1)+"\" value=\""+NgayKhauHao+"\"/>"+NgayKhauHao+"</td>";
            shtml +="      <td class=\"Column2\" style=\"text-align:left\"> <input type=\"hidden\" id=\"hdTKKhauHao_"+(lastRow-1)+"\" value=\""+TKKhauHao+"\"/>"+TKKhauHao+"</td>";
            shtml +="      <td class=\"Column2\" style=\"text-align:left\"> <input type=\"hidden\" id=\"hdTKChiPhi_"+(lastRow-1)+"\" value=\""+TKChiPhi+"\"/>"+TKChiPhi+"</td>";          
            shtml += "	   <td class=\"Column2\" style=\"text-align:right\"><input type=\"hidden\" id=\"hdNguyenGia_"+(lastRow-1)+"\" value=\""+NguyenGia+"\"/><input type=\"hidden\" id=\"hdSoThangKH_"+(lastRow-1)+"\" value=\""+SoThangKH+"\"/><input type=\"text\" id=\"GiaTriKhauHao_"+(lastRow-1)+"\" readonly=\"readonly\" value=\""+FormatSoTien(GiaTriKhauHao)+"\" onkeyup=\"TestNumberofInput('GiaTriKhauHao_"+(lastRow-1)+"')\" onchange=\"getFormatSoTien('GiaTriKhauHao_"+(lastRow-1)+"')\" style=\"width:200px;text-align:right\" /></td>	";          
          // shtml += "	   <td class=\"Column0\"><input type=\"button\" id=\"btnSua_"+(lastRow-1)+"\" value=\"Sửa\"  onclick=\"SuaThongTinKhauHao('btnSua_"+(lastRow-1)+"','GiaTriKhauHao_"+(lastRow-1)+"','"+MaCCDC+"','"+TKChiPhi+"','"+NgayKhauHao+"')/></td>";
//           shtml += "	   <td class=\"Column0\"><label id=\"btnXoa_"+(lastRow-1)+"\" style=\"font-style:italic;color:Blue\" onclick=\"XoaThongTinKhauHao('btnXoa_"+(lastRow-1)+"','"+MaTS+"')\">Xóa</label>  </td>	";
            		              
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
 }
 function ResetTableDSCCDC()
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
              var idSoThangKH = "hdSoThangKH_"+(Row-2);
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
        alert("Không có công cụ để tính khấu hao. Vui lòng kiểm tra lại. Cảm ơn!");
     }     
}
 function SuaThongTinKhauHao(Ctr,idGiaTriKH,MaCCDC,tkchiphi,ngaykhauhao)
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
        CapNhatKhauHaoCCDC(MaCCDC,idGiaTriKH,tkchiphi,ngaykhauhao)
        btnSua.value="Sửa";        
    }
 }
 function XoaThongTinKhauHao()
 {
    var index=document.getElementById("SelectMonth").selectedIndex;
   var Thang = document.getElementsByTagName("option")[index].value;
   var Nam = document.getElementById('txtNam').value;
    var rs = confirm("Bạn có chắc là muốn xóa thông tin khấu hao công cụ tháng "+Thang+"/"+Nam+ "?" );
    if(rs==true)
    {
        getFunctionXoaKhauHaoCCDCByThangNam(Thang,Nam);
    }
    
 }
 function getFunctionXoaKhauHaoCCDCByThangNam(Thang,Nam)
 {
   
     xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {
                                             
                        alert("Xóa khấu hao CCDCtháng "+Thang +"/" +Nam +" thành công!");
                        LoadDanhSachCCDCByMonthYear();
                      }
                      else
                      if(value=="0")
                      {
                        alert("Xóa khấu hao CCDCtháng "+Thang +"/" +Nam +" thất bại!");
                      }
                      else
                      {
                         alert("Không có công cụ khấu hao trong   "+Thang +"/" +Nam +".");
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=XoaKhauHaoCCDCByThangNam&Thang="+Thang+"&Nam="+Nam+"&times="+Math.random(),true);
            xmlHttp.send(null);  
 }
 function LuuKhauHaoCCDC()
 {
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var x;
    var rs = 1;     
    var index=document.getElementById("SelectMonth").selectedIndex;
    var valueThang = document.getElementsByTagName("option")[index].value;
    var valueNam = document.getElementById('txtNam').value;
    var valueMaCCDC ="";
    var valueGiaTriKH ="";
    var valueTkChiPhi="";
    var valueNgayKhauHao="";
    var valueDienGiai = document.getElementById('txtDienGiai').value;
    
    if(Row>2)
    {
        while(Row>2)
        {
        //null,sophieuthu,tkco,psco,null,soHD,NgaylapHD,tientrenHD,null,null,null,diengiai,0
         
                  var idMaCCDC= "hdMaCCDC_"+(Row-2);
                  var idGiaTriKH = "GiaTriKhauHao_"+(Row-2);
                  var idtkchiphi = "hdTKChiPhi_"+(Row-2);
                  var idngaykhauhao="hdNgayKhauHao_"+(Row-2);
                  valueMaCCDC +=";"+ document.getElementById(idMaCCDC).value;
                  valueTkChiPhi +=";"+ document.getElementById(idtkchiphi).value;
                  valueNgayKhauHao +=";"+document.getElementById(idngaykhauhao).value;
                  
                  var GTKH = document.getElementById(idGiaTriKH).value;
                  valueGiaTriKH +=";"+ ChangeFormatCurrency(GTKH);
            
            Row--;
        }
         getFunctionLuuCCDC("Save",valueMaCCDC,valueThang,valueNam,valueGiaTriKH,valueDienGiai,valueTkChiPhi,valueNgayKhauHao);                
     }
     else
     {
        alert("Chưa có chi tiết CCDC khấu hao. Vui lòng kiểm tra lại.Vui lòng xóa dòng trống nếu không dùng Cảm ơn!");
            Ctr.disabled = false;
            document.getElementById('message').style.visibility = "hidden";
          //  XoaPhieuThu(SoPT);
     }
 }
 function CapNhatKhauHaoCCDC(valueMaCCDC,idGiaTriKH,tkchiphi,ngaykhauhao)
 {
    var index=document.getElementById("SelectMonth").selectedIndex;
    var valueThang = document.getElementsByTagName("option")[index].value;
    var valueNam = document.getElementById('txtNam').value;
    var valueDienGiai = document.getElementById('txtDienGiai').value;
    var GTKH = document.getElementById(idGiaTriKH).value;
    var tk_chiphi=document.getElementById(tkchiphi).value;
    var valueGiaTriKH =ChangeFormatCurrency(GTKH);
    var ngay_khau_hao=document.getElementById(ngaykhauhao).value;
    
    if(valueGiaTriKH!=""&&valueGiaTriKH !="0")
    {
        getFunctionLuuCCDC("Update",valueMaCCDC,valueThang,valueNam,valueGiaTriKH,valueDienGiai,tk_chiphi,ngay_khau_hao);        
    }
    else
    {
        alert("Công cụ dụng cụ "+valueMaCCDC+" chưa có giá trị khấu hao.Vui lòng kiểm tra lại cảm ơn! ");
    }
 }
 function getFunctionLuuCCDC(TypeSave,MaCCDC,Thang,Nam,GiaTriKhauHao,DienGiai,TkChiPhi,Ngaykhauhao)
 {
    
     xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {
                                             
                        alert("Lưu khấu hao CCDC tháng "+Thang +"/" +Nam +" thành công!");
                        LoadDanhSachCCDCByMonthYear();
                      }
                      else
                      if(value=="0")
                      {
                        alert("Lưu khấu hao CCDC tháng "+Thang +"/" +Nam +" thất bại!");
                      }
                      else
                      if(value=="2")
                      {
                        alert("Công cụ dụng cụ "+MaCCDC+" của tháng "+Thang +"/" +Nam +" chưa được lưu trong bảng khấu hao!");
                        TinhKhauHao();
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=LuuKhauHaoCCDC&TypeSave="+TypeSave+"&MaCCDC="+MaCCDC+"&Thang="+Thang+"&Nam="+Nam+"&GiaTriKhauHao="+GiaTriKhauHao+"&DienGiai="+encodeURIComponent(DienGiai)+"&tkchiphi="+TkChiPhi+"&ngaykhauhao="+Ngaykhauhao+"&times="+Math.random(),true);
            xmlHttp.send(null);  
 }

</script>
<form id="tinhkhauhao" name="tinhkhauhao" method="post" runat="server">
<%--<input type="hidden" name="secondtime" id="secondtime" />--%>
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:uscmenuKT_CCDC ID="uscmenuKT_CCDC" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr style="height:10px">
                    <td><div  class = "tdHeader">TÍNH PHÂN BỔ CÔNG CỤ DỤNG CỤ</div></td>
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
                                                                <input type="button" value="Lưu" id="bt_Luu" onclick="LuuKhauHaoCCDC()" style="width:100px;"  />
                                                                <input type="button" value="Tạo mới"  style="width:100px" onclick="ResetTableDSCCDC()" id="bt_Reset" />
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
              <td class ="tdHeader" colspan="11" >Chi phân bổ công cụ dụng cụ</td>
         </tr>
		<tr class="HeaderGidView">
		     <td class="HeaderColumn0">STT</td>
		    
		     <td class="HeaderColumn1" style="width:15%;">
		        Mã CCDC
		     </td>
		     
		     <td class="HeaderColumn2" style="width:30%;">
		       Tên CCDC		       
		    </td>
		    
		    <td class="HeaderColumn2" style="width:15%;">
		       Ngày phân bổ	       
		    </td>
		    
		    <td class="HeaderColumn2" style="width:15%;">
		       Tài khoản phân bổ
		    </td>
		     <td class="HeaderColumn2" style="width:15%;">
		       Tài khoản chi phí
		    </td>	
		    <td class="HeaderColumn2" style="width:15%;">
		       Giá trị khấu hao
		    </td>	  
		    <td class="HeaderColumn0" style="width:15%;">
		        
		    </td>  
		    
		</tr>					 
	  
		
		
		 
	</table>

</form>
<!--#include file = "footer.htm" -->
                                                  