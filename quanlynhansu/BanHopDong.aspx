<%@ Page Language="C#" CodeFile="BanHopDong.aspx.cs" Inherits="BanHopDong" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!--#include file ="header.htm"-->
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>

<script language = "javascript">
   
    function TestDatePhieu(t)
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
	
	function InKetQua()
	{
	    var obj = document.getElementById("iddieutri");
	    if(obj.value == "0")
	    {
	        alert("Bạn chưa cho biết kết quả khám bệnh. Vui lòng kiểm tra lại.");
	        return false;
	    }
	    else
	    {
	        window.open("inketquakhambenhcls.aspx?idthambenh=" + obj.value,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	    }
	}
	
	function InCLS()
	{
	    var obj = document.getElementById("idbn");
	    if(obj.value == "0")
	    {
	        alert("Bạn chưa cho biết kết quả khám bệnh. Vui lòng kiểm tra lại.");
	        return false;
	    }
	    else
	    {
	        window.open("../khambenh/inlisthosobenhan01.aspx?idbn=" + obj.value,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	    }
	}
	
	function CanCel()
	{
	window.location="../canlamsang/dieutricanlamsan.aspx";
	}
</script>
<script>
$("textarea").autoresize();
</script>
<script type="text/javascript">
_editor_url = "editor/";    
</script>

<script type="text/javascript">
function mOnKup(){
var oHeight = document.doc.txtChiDinhBacSi.scrollHeight;
var cHeight = document.doc.txtChiDinhBacSi.clientHeight;
if (cHeight+10 < oHeight) {
        document.doc.tx.style.height = oHeight+2+ "px";
        document.doc.tx.value += cHeight + " : " + oHeight;
    }
}



</script>
<form id="doc" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" height="100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#D4D0C8; height: 10px;">
            <uc1:uscmenu ID="Uscmenu1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
	    <TD vAlign="top" align="left" width="85%" style="WIDTH: 85%; height:100%">
		    
            <FCKeditorV2:FCKeditor ID="txtHopDong" runat="server" Width="98%" Height="800px" BasePath="Javascripts/FCKEditor/" FullPage="true">
            </FCKeditorV2:FCKeditor>                                                                   
               														    
	    </TD>
    </tr>
    <tr><td>
    <table align="center">													    
	    <TR style="PADDING-TOP: 2px"><td>
		    <input runat="server" onserverclick="btnLuu_Click" style="width:100px" class="btn" type="button" id="btnLuu" value="Lưu"  />&nbsp;
		</TD>
		</TR>
    </table>
    </td></tr>											
 </table>     
      <input type="hidden" runat="server" id="txtidhopdong" />
 </form>
<!--#include file ="footer.htm"-->