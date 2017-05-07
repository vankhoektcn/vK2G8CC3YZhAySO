
<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="thambenhentry.aspx.cs" Inherits="thambenhentry" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!--#include file ="header.htm"-->
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<script type="text/javascript" src="js/autoresize.jquery.js"></script>
<script language = "javascript">
   var dp_cal1;         
	window.onload = function () 
	{
	   
	};
	
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
	        alert("Bạn chưa có kết quả khám bệnh. Vui lòng kiểm tra lại.");
	        return false;
	    }
	    else
	    {
	        window.open("inketquadieutrichidinh.aspx?idt=" + obj.value);
	    }
	}
function sz(t) {
            a = t.value.split('\n');
            b=1;
            for (x=0;x < a.length; x++) {
             if (a[x].length >= t.cols) b+= Math.floor(a[x].length/t.cols);
             }
            b+= a.length;
            if (b > t.rows) t.rows = b;
}
</script>
<script>
$("textarea").autoresize();
</script>

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
</script>

<form id="doc" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#FBF8F1; height: 19px;">
            <uc1:uscmenu ID="Uscmenu1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style="background-color:#D4D0C8; height: 10px;">
            <asp:placeholder ID="PlaceHolder1" runat="server"></asp:placeholder>
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table cellspacing="1" cellpadding="1" width="98%" align = "center" border="0" class = "khung">
	        <tr>
		        <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px">
			        <table id="user" cellSpacing="1" cellPadding="1" width="100%" border="0">
				        <tr>
					        <td class="title" align = "center" style ="background-color: #4D67A2">
						        <p class="title" style ="color:#FFFFFF">KẾT QUẢ CẬN LÂM SÀNG (BSCĐ)<input type = "hidden" id = "iddieutri" value = "0" runat = "server"></p>
					        </td>
				        </tr>
				    <tr>
					    <td width = "100%" class="title"><br>
						    <span class="ptext" runat="server" id = "thongtinbenhnhan">
						        
						    </span>
					    </td>
				    </tr>
				    <tr>
					    <td class="title" style =" padding-top:10px; padding-bottom:0px">
						   
					    </td>
				    </tr>
				    <TR>
					    <TD width="100%">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%">
									    <TABLE cellSpacing="0" cellPadding="0" width="98%" border="0">
										    
										    <TR style="PADDING-BOTTOM: 5px; PADDING-TOP: 10px">
											    <TD align="left" width="100%" style="height: 100px">
												    <TABLE style="HEIGHT: 17px" cellSpacing="0" cellPadding="0" width="100%" border="0">
													    
													      <TR style ="padding-bottom:10px">
														    <TD vAlign="top" noWrap align="right" style="height: 9px; width: 174px">
															    <span class="ptext">
                                                                    Ngày làm CLS:
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 834px; height: 9px;">
															    <span class="ptext">
															    <asp:textbox onblur="TestDatePhieu(this)" id="txtngayCLS" tabIndex=3 runat="server" Enabled="true" width="155px"></asp:textbox>
                                                                    &nbsp; Chọn Phòng/Khoa:&nbsp;
                                                                    <asp:dropdownlist id="ddlPK" runat="server" autopostback="true"  width="294px"></asp:dropdownlist>
                                                                </span></TD>
													    </TR>
													    <TR style ="padding-bottom:10px">
														    <TD vAlign="top" noWrap align="right" style="height: 9px; width: 174px">
															    <span class="ptext">
                                                                    Bác sĩ CLS:&nbsp;
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 834px; height: 9px;">
															    <span class="ptext">
                                                                    <asp:dropdownlist id="ddlBacSi" runat="server" width="570px"></asp:dropdownlist>
                                                                </span>															    
														    </TD>
													    </TR>
													    <TR style ="padding-bottom:10px">
														    <TD vAlign="top" noWrap align="right" style="height: 9px; width: 174px">
															    <span class="ptext">
                                                                    Chỉ định của bác sĩ:&nbsp;
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 834px;;">
                                                                
                                                              <FCKeditorV2:FCKeditor ID="txtChiDinhBacSi" runat="server" Width="98%" Height="300px" BasePath="../Javascripts/FCKEditor/" FullPage="true">
                                                                </FCKeditorV2:FCKeditor>
                                                                  
                                                                    
                                                                   														    
														    </TD>
													    </TR>
													    <TR style ="padding-bottom:10px">
														    <TD vAlign="top" noWrap align="right" style="height: 24px; width: 174px; border:none;">
                                                                Kết quả CLS</TD>
														    <TD vAlign="top" align="left" style="WIDTH: 834px; height: 24px;">
															    <div id = "showvideo" runat = "server">
															   <fieldset style="padding: 2; width:100%">

                                                                  <legend></legend>
                                                                  </fieldset>
															    </div>
														    </TD>
													    </TR>
													    <tr>

													    <TR style ="padding-bottom:10px">
														    <TD vAlign="top" noWrap align="right" style="height: 24px; width: 174px;">
															    <span class="ptext">Đường dẫn lưu KQ:&nbsp;
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 834px; height: 24px;">
															    <span class="ptext">
                                                                    <asp:fileupload id="vdoCanLamSan" runat="server" width="830px" Enabled="false"></asp:fileupload></span>															    
														    </TD>
													    </TR>
													    <TR style ="padding-bottom:10px">
														    <TD vAlign="top" noWrap align="right" style="height: 25px; width: 174px;">
															    <span class="ptext">
                                                                    Kết luận của bác sĩ:&nbsp;
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 834px; height: 25px;">
															    <span class="ptext">
                                                                    <asp:textbox id="txtKetLuan" runat="server" height="22px" tabindex="4"
                                                                        width="831px">Xem phiếu KQ k&#232;m theo</asp:textbox>
                                                                    </span>															    
														    </TD>
													    </TR>
													    <tr>
													     <TD vAlign="top" noWrap align="right" style="height: 25px; width: 174px;">
															    <span class="ptext">
                                                                   Ngày hẹn trả KQ:
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 834px; height: 25px;">
															    <span class="ptext">
                                                                    <asp:textbox id="txtNgayHen" runat="server" tabindex="5"
                                                                        width="184px"></asp:textbox>
                                                                        &nbsp;
                                                                    <asp:textbox id="txtGioHen" runat="server" width="67px"></asp:textbox>
                                                                    (dd/MM/yyyy  hh:mm)
                                                                    <input type="button"  onserverclick="btnluuphieuhen_Click" class="btn" value="Lưu phiếu" id="btnluuphieuhen" runat="server" tabIndex="11" /> 
                                                                    <input type="button" id="btnInPhieuHen" onserverclick="btnInPhieuHen_Click" class="btn" Visible="true" value="In phiếu" runat="server" />
                                                                    </span>															    
														    </TD>
													    </tr>
													    
													    <TR style="PADDING-TOP: 2px">
														    <TD vAlign="top" noWrap align="left" style="PADDING-LEFT: 0px; height: 19px; width: 174px;">
															    <INPUT id="action" type="hidden" value='""' name="action" runat="server" style="WIDTH: 32px; HEIGHT: 22px"
																	    size="1">
                                                               
                                                            </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 834px; height: 19px;"
															    nowrap><asp:imagebutton id="btnAdd" runat="server" imageurl="../images/luu.png"
																    tabIndex="11" OnClick="btnAdd_Click" ></asp:imagebutton>&nbsp;
															    <asp:imagebutton id="btnEdit" runat="server" OnClick="btnEdit_Click" imageurl="../images/sua.gif" tabIndex="12"></asp:imagebutton>&nbsp;
															    <asp:imagebutton id="btnCancel" runat="server" imageurl="../images/MOI.gif"
																    tabIndex="13"></asp:imagebutton>&nbsp;&nbsp;
																      
																    <img src = "../images/IN.gif" style ="cursor: pointer;DISPLAY:NONE" onclick = "InKetQua()"/>&nbsp;
																    
																    <asp:imagebutton id="btnIn"  runat="server" onclick="InCLS_Click" imageurl="../images/IN.gif"
																    tabindex="14" ></asp:imagebutton>
																       
																    
																    
															    </TD>
													    </TR>
												    </TABLE>
                                                  </TD>
										    </TR>
									    </TABLE>
								    </TD>
							    </TR>
						    </TABLE>
					    </TD>
				    </TR>
			    </table>
		    </td>
	    </tr>				
    </table>
     <asp:textbox id="txtidBN" runat="server" Visible="false" width="66px"></asp:textbox>
      <asp:textbox id="txidPH" runat="server" Visible="false" width="66px"></asp:textbox>
       <input type="hidden" runat="server" id="idcls" />
 </form>
<!--#include file ="footer.htm"-->