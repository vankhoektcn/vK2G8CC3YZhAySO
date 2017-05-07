<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTHT_ThamSoTuyChon.aspx.cs" Inherits="ketoan_KTHT_ThamSoTuyChon" %>
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

<script language ="javascript" type ="text/javascript">
function themlistthamso(Ctr)
{
    Ctr.disable=true;
    document.getElementById('message').style.visibility = "visible";
    var tlist_thamso=document.getElementById('TableDanhSach');
    var row=tlist_thamso.rows.length;
    var tham_so="";
    var gia_tri="";
    if(row>1)
    {
        for(j=1;j<row;j++)
        {
            var tham_so_id="tham_so_"+j;
            tham_so += document.getElementById(tham_so_id).value + ";";
            var gia_tri_id="gia_tri_"+j;
            gia_tri += document.getElementById(gia_tri_id).value +";";
        }     
        tham_so=tham_so.substring(0,tham_so.length-1);
        gia_tri=gia_tri.substring(0,gia_tri.length-1);
        getlistthamso(Ctr,tham_so,gia_tri);
    }
    else    
    {
        alert("Không có tham số");
        Ctr.disable=false;
        document.getElementById('message').style.visibility="hidden";        
    }
}
function getlistthamso(Ctr,ts,gt)
{    
    xmlHttp=GetMSXmlHttp();
        xmlHttp.onreadystatechange=function()
        {
            var value = xmlHttp.responseText;
            if(value=="1")
            {
                alert("Lưu tham số thành công!");                        
             }
             else
                alert("Lưu tham số thất bại!");
                document.getElementById('message').style.visibility = "hidden";
                Ctr.disabled  = false;
        }
        xmlHttp.open("GET","ajax.aspx?do=Luuthamso&tham_so="+ts+"&gia_tri="+encodeURIComponent(gt),false);
        xmlHttp.send(null);
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
                    <td><div  class = "tdHeader">Bảng Tham Số Tùy Chọn</div></td>
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
	            <div id="divlisttham_so" runat="server">
	            </div>              
	        </td>
	   </tr>
 </table>
   <div style="text-align:center">
        <input type="button" id="bt_ThemDong" value="Lưu" style="width:100px;" onclick="themlistthamso(this)"/>       
    </div> 
    
</form>

<!--#include file ="footer.htm"-->
