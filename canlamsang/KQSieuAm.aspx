<%@ Page Language="C#" CodeFile="KQSieuAm.aspx.cs" Inherits="KQSieuAm" %>

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
	     var id = document.getElementById("idkq");
	        window.open("phieuKQSieuAm.aspx?idbn=" + obj.value+"&id="+id.value,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	    }
	}
	
	function CanCel()
	{
	window.location="../canlamsang/dieutricanlamsan.aspx";
	}
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
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#D4D0C8; height: 10px;">
            <uc1:uscmenu ID="Uscmenu1" runat="server" />
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
					        <td class="title" align = "center" style="background-color: #4D67A2; height: 21px;">
						        <p class="title" style ="color:#FFFFFF">KẾT QUẢ CẬN LÂM SÀNG (BNĐK)</p>
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
						    <p class="title"><input type = "hidden" id = "iddieutri" value = "0" runat = "server" />
						    <input type = "hidden" id = "idkq" value = "0" runat = "server" />
						    </p>
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
                                                                    <asp:dropdownlist id="ddlPK" runat="server" autopostback="true"       width="294px"></asp:dropdownlist>
                                                                </span></TD>
													    </TR>
													    <TR style ="padding-bottom:10px">
														    <TD vAlign="top" noWrap align="right" style="height: 9px; width: 10%">
															    <P class="ptext">
                                                                    Bác sĩ CLS:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" width="90%" style="WIDTH: 90%; height: 9px;">
															    <P class="ptext">
                                                                    <asp:dropdownlist id="ddlBacSi" runat="server" width="570px"></asp:dropdownlist>
                                                                </P>															    
														    </TD>
													    </TR>
													 
													    <TR style ="padding-bottom:10px">
														    <TD vAlign="top" noWrap align="right" style="height: 9px; width: 15%">
															    <P class="ptext">
															    
                                                                    Chỉ định của bác sĩ:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" width="85%" style="WIDTH: 85%; height:900px">
															    
                                                                <FCKeditorV2:FCKeditor ID="txtChiDinhBacSi" runat="server" Width="98%" Height="900px" BasePath="../Javascripts/FCKEditor/" FullPage="true" >
                                                                </FCKeditorV2:FCKeditor>
                                                                   
                                                                   														    
														    </TD>
													    </TR>
													    <TR style ="padding-bottom:10px">
														    <TD vAlign="top" noWrap align="right" style="height: 24px; width: 15%;">
															    <span class="ptext">
                                                                    Video CLS:&nbsp;
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" width="85%" style="WIDTH: 85%; height: 24px;">
															    <span class="ptext">
                                                                    <asp:fileupload id="vdoCanLamSan" runat="server" width="564px"></asp:fileupload></span>															    
														    </TD>
													    </TR>
													    <TR style ="padding-bottom:10px">
														    <TD vAlign="top" noWrap align="right" style="height: 24px; width: 15%;">
															    <P class="ptext">
                                                                    Kết luận của bác sĩ:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" width="85%" style="WIDTH: 85%; height: 24px;">
															    <P class="ptext">
                                                                    <asp:textbox id="txtKetLuan" runat="server" height="20px" tabindex="4"
                                                                        width="570px">Xem phiếu KQ k&#232;m theo</asp:textbox>
                                                                    </P>															    
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
                                                                    <asp:textbox id="txtNgayHen" runat="server"  tabindex="5"
                                                                        width="138px"></asp:textbox>
                                                                    &nbsp;
                                                                    <asp:textbox id="txtGioHen" runat="server" width="67px"></asp:textbox>
                                                                    (dd/MM/yyyy  hh:mm)
                                                                    </span>															    
														    </TD>
													    </tr>  
													    
													    <TR style="PADDING-TOP: 2px">
														    <TD vAlign="top" noWrap align="left" style="PADDING-LEFT: 0px; height: 19px; width: 174px;">
															    <INPUT id="action" type="hidden" value='""' name="action" runat="server" style="WIDTH: 32px; HEIGHT: 22px"
																	    size="1"><INPUT id="idthambenh" type="hidden" value="0" name="idthambenh" runat="server" style="WIDTH: 32px; HEIGHT: 22px"
																	    size="1"></TD>
														    <TD vAlign="top" align="left" width="430" style="WIDTH: 430px; height: 19px;"
															    nowrap><asp:imagebutton id="btnAdd" runat="server" imageurl="../images/luu.png" 
																    tabIndex="11" ></asp:imagebutton>&nbsp;
															    <asp:imagebutton id="btnEdit" runat="server" OnClick="btnEdit_Click" imageurl="../images/sua.gif" tabIndex="12"></asp:imagebutton>&nbsp;
															    <asp:imagebutton id="btnCancel" runat="server" imageurl="../images/MOI.gif"
																    tabIndex="13" onclientclick = "CanCel()" OnClick="btnCancel_Click"></asp:imagebutton>&nbsp;&nbsp;
																          <asp:imagebutton id="btnInPhieuHen" Visible="false" runat="server" imageurl="../images/INkq.gif"
																    tabIndex="13" OnClick="btnInPhieuHen_Click"></asp:imagebutton>
																    <img src = "../images/IN.gif" style ="cursor: pointer;display:none" onclick = "InKetQua()"/>
																    
																    <asp:imagebutton id="btnIn"  runat="server" onclientclick="InCLS();" imageurl="../images/IN.gif"
																    tabindex="14" ></asp:imagebutton>
                                                             <%--       <asp:button id="btninphieu" text="In phiếu"  runat="server" OnClick="btninphieu_Click"/>--%>
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
                    </td>
    </tr>
 </table>
     
      <asp:textbox id="txidPH" runat="server" Visible="false" width="66px"></asp:textbox>
      <input type="hidden" runat="server" id="idcls" />
 </form>
<!--#include file ="footer.htm"-->