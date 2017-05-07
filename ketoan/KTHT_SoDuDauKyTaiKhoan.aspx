<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTHT_SoDuDauKyTaiKhoan.aspx.cs" Inherits="ketoan_KTHT_SoDuDauKyTaiKhoan" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_HeThong.ascx" TagName="uscmenuKT_HeThong" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

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
    

 <script language="javascript" type="text/javascript">
 
 window.onload = function () 
	{
	   
	};
function getFormatSoTien(Ctr)
{
   // var txtPhatSinh = document.getElementById(idText);
    Ctr.value = FormatSoTien(Ctr.value);
    
    
}
function FormatSoTien(obj)
{
	    return formatCurrency(obj);
}

function TestNumberofInput(obj)
{
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
 function ThemSoDuDauKyTaiKhoan(Ctr)
 {
    Ctr.disabled  = true;
    document.getElementById('message').style.visibility = "visible";
    var Nam = document.getElementById('txtNam').value;
    if(!isFinite(Nam)||Nam==""||Nam<1900||Nam>2100)
    {
        alert("Nhập năm sai định dạng vui lòng nhập lại. Cảm ơn!");
        Ctr.disabled  = false;
        document.getElementById('message').style.visibility = "hidden";
    }
    else
    {
        var TableDanhSach = document.getElementById('TableDanhSach');
        var Row = TableDanhSach.rows.length;
        var flag = false;
        var TaiKhoan ="";
        var DuNo ="";
        var DuCo ="";
        var DuNo_nt ="";
        var DuCo_nt ="";
       
        if(Row>1)
        {
            for(var i=1;i<Row;i++)
            {
                var idTaiKhoan = "TaiKhoan_"+i;//(Row-1);
                 TaiKhoan +=";"+ document.getElementById(idTaiKhoan).value;
                 
                 var idDuNo = "NoDauKy_"+i;//(Row-1);
                 var du_no = ChangeFormatCurrency(document.getElementById(idDuNo).value);
                 DuNo += ";" + du_no;
                 
                 var idDuCo = "CoDauKy_"+i;//(Row-1);
                 var du_co  = ChangeFormatCurrency(document.getElementById(idDuCo).value);
                 DuCo += ";"+ du_co;
                 
                 var idNoDauKyNgoaiTe_ = "NoDauKyNgoaiTe_"+i;//(Row-1);
                 var du_no_nt = ChangeFormatCurrency(document.getElementById(idNoDauKyNgoaiTe_).value);
                 DuNo_nt +=";"+ du_no_nt;
                 
                 var idCoDauKyNgoaiTe = "CoDauKyNgoaiTe_"+i;//(Row-1);
                 var du_co_nt = ChangeFormatCurrency(document.getElementById(idCoDauKyNgoaiTe).value);
                 DuCo_nt +=";"+ du_co_nt;
                 //  Row--;
            }
           
                getFunctionLuuSoDuDauKyTaiKhoan(Ctr,Nam,TaiKhoan,DuNo,DuCo,DuNo_nt,DuCo_nt);
           
        }
        else
        {            
            alert("Không có danh sách tài khoản. Vui lòng kiểm tra lại dữ liệu.Cảm ơn!");
            Ctr.disabled  = false;
            document.getElementById('message').style.visibility = "hidden";            
        }
    }
    
    
 }
 function getFunctionLuuSoDuDauKyTaiKhoan(Ctr,Nam,TaiKhoan,DuNo,DuCo,DuNo_nt,DuCo_nt)
 {
     xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                    if(value=="1")
                    {
                        alert("Lưu số dư đầu kỳ tài khoản thành công!");
                        
                    }
                    else
                        alert("Lưu số dư đầu kỳ tài khoản thất bại!");
                    document.getElementById('message').style.visibility = "hidden";
                        Ctr.disabled  = false;
                }
            }
   
              xmlHttp.open("GET","ajax.aspx?do=LuuSoDuDauKyTaiKhoan&nam="+Nam+"&tai_khoan="+TaiKhoan+"&du_no0="+DuNo+"&du_co0="+DuCo+"&du_no_nt0="+DuNo_nt+"&du_co_nt0="+DuCo_nt+"&times="+Math.random(),true);
            xmlHttp.send(null); 
 }
 function ResetForm()
 {
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var lastRow = Row;
    for(i=1 ;i<Row;i++)
    {
    
         var idTaiKhoan = "TaiKhoan_"+i;
         document.getElementById(idTaiKhoan).value="";
         var idDuNo = "NoDauKy_"+i;
         document.getElementById(idDuNo).value="";
         var idDuCo = "CoDauKy_"+i;
         document.getElementById(idDuCo).value="";
         var idNoDauKyNgoaiTe_ = "NoDauKyNgoaiTe_"+i;
         document.getElementById(idNoDauKyNgoaiTe_).value="";
         var idCoDauKyNgoaiTe = "CoDauKyNgoaiTe_"+i;
         document.getElementById(idCoDauKyNgoaiTe).value="";
                   
    }
 }
 function LoadSoDuDauKyTaiKhoanByNam()
 {
    var Nam = document.getElementById('txtNam').value;
     xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                    if(value!="")
                    {
                        //alert("Lưu số dư đầu kỳ tài khoản thành công!");
                     
                       var  Row = value.split('&');
                       for(i = 1;i<Row.length;i++)
                       {
                         // nam(0),tai_khoan(1),du_no0(2),du_co0(3),du_no_nt0(4),du_co_nt0(5);
                         var data = Row[i].split('|');
                         if(data[2]!="0")
                         {  
                            var DuNo = "NoDauKy_" + i;
                            document.getElementById(DuNo).value = FormatSoTien(data[2]);
                         }
                         if(data[3]!="0")
                         {      
                            var DuCo = "CoDauKy_" + i;
                            document.getElementById(DuCo).value = FormatSoTien(data[3]);
                         }
                         if(data[4]!="0.00")
                         {
                             var DuNo_nt = "NoDauKyNgoaiTe_" +i;
                             document.getElementById(DuNo_nt).value = data[4];                                  
                         }
                         if(data[5]!="0.00")
                         {
                            var DuCo_nt = "CoDauKyNgoaiTe_" +i;
                            document.getElementById(DuCo_nt).value = data[5];
                         }                       
                       }                                              
                    }
                    else
                      {
                            alert("Không có số dư đầu kỳ tài khoản của năm " +Nam +"!");
                            ResetForm();
                      }                   
                }
            }  
            xmlHttp.open("GET","ajax.aspx?do=LoadSoDuDauKyTaiKhoanByNam&nam="+Nam+"&times="+Math.random(),true);
            xmlHttp.send(null); 
 }
 
  function ketchuyen()
 {
     var tunam=document.getElementById('txttunam').value;
     var dennam=document.getElementById('txtdennam').value;
     xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                    if(value=="1")
                    {
                        alert("Kết chuyển số dư tài khoản thành công!");                       
                    }
                    else
                        alert("Kết chuyển số dư tài khoản thất bại!");
                    document.getElementById('message').style.visibility = "hidden";                       
                }
            }   
            xmlHttp.open("GET","ajax.aspx?do=ket_chuyen_so_du_tk&tunam="+tunam+"&dennam="+dennam+"&times="+Math.random(),true);
            xmlHttp.send(null); 
 }
 function thuchien(Ctr)
 {       
    var giatri=document.getElementById(Ctr.id).value;
     if(giatri=='Chuyển số dư')
     {
        dkcontrol('visible')  ;
        document.getElementById('chuyensodu').value="Thực hiện";         
     }
     else
     if (giatri=='Thực hiện')
     {
        ketchuyen();
        dkcontrol('hiden');
        document.getElementById('chuyensodu').value="Chuyển số dư";     
     }
 }
 function dkcontrol(thamso)
 {
    if(thamso=='visible')
    {    
        document.getElementById('lbltunam').style.display='block';
        document.getElementById('lbldennam').style.display='block';
        document.getElementById('txttunam').style.display='block';
        document.getElementById('txtdennam').style.display='block';
    }
    else
    if (thamso='hiden')
    {
        document.getElementById('lbltunam').style.display='none';
        document.getElementById('lbldennam').style.display='none';
        document.getElementById('txttunam').style.display='none';
        document.getElementById('txtdennam').style.display='none';
    }
 }
 
 </script>
<form id="form1" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:uscmenuKT_HeThong ID="uscmenuKT_HeThong" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr style="height:10px; width:100%;padding-bottom:10px;text-align:center">
                    <td><div  class = "tdHeader">SỐ DƯ ĐẦU KỲ TÀI KHOẢN</div></td>
                </tr>
                <tr>
					  <td style="padding-top:20px;text-align:center">Năm: <input id="txtNam" type="text" style="width:50px" runat="server" />
					    <input type="button" id="bt_Xem" value="Xem" onclick="LoadSoDuDauKyTaiKhoanByNam()" />&nbsp
					    <input type="button" id="chuyensodu" value="Chuyển số dư" onclick="thuchien(this)" /><label id="lbltunam">Từ năm:</label>&nbsp<input id="txttunam" type="text" style="width:50px" runat="server"/>&nbsp
					    <label id="lbldennam">đến năm:</label>&nbsp<input id="txtdennam" type="text" style="width:50px" runat="server"/>
					 </td>			
				</tr>
				<tr>
				     <td>
				        <label id="message"  style="display:none" > Đang xử lý vui lòng chờ trong giây lát....</label>
				    </td>
				</tr>
            </table>
         </td>
       </tr>       
	   <tr>
	        <td>
	            <div id="divDanhSach" runat="server">
	            </div>
              
	        </td>
	   </tr>
 </table>
   <div style="text-align:center">
        <input type="button" id="bt_ThemDong" value="Lưu" style="width:100px;" onclick="ThemSoDuDauKyTaiKhoan(this)"/>
        <input type="button" id="Button1" value="Làm mới" style="width:100px;" onclick="ResetForm()"/>
    </div> 
    
</form>
<!--#include file ="footer.htm"--> 