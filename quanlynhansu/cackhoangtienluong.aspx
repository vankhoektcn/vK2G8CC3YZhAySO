<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cackhoangtienluong.aspx.cs" Inherits="cackhoangtienluong" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->
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
</script>
<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#FBF8F1; height: 19px;">
            <uc1:uscmenu ID="Uscmenu1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
		    <td valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px; width: 100%;">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
		    <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px">
			    <table id="user" cellSpacing="1" cellPadding="1" width="100%" border="0" class = "khung">
				    <tr>
				        <td class="title" align = "center" style ="background-color: #4D67A2">
                            QUẢN LÝ CÁC KHOẢNG LƯƠNG TĂNG CA, LƯƠNG NGÀY CHỦ NHẬT&nbsp;</td>
				    </tr>
				    <tr>
					    <td width="100%">
						    <table cellPadding="0" width="100%" border="0">
							    <tr>
								    <td vAlign="top" align="center" width="100%" style="height: 151px">
									    <table cellSpacing="0" cellPadding="0" width="98%" border="0">
										    
										    <TR style="PADDING-BOTTOM: 5px; PADDING-TOP: 10px">
											    <td align="left" width="100%" style="height: 81px">
												    <table style="HEIGHT: 17px" cellSpacing="0" cellPadding="0" width="100%" border="0">
													    
													    <tr>
														    <td vAlign="top" noWrap align="right" style="height: 23px" >
															    <P class="ptext">
                                                                    Lương tăng ca / 1 giờ :&nbsp;
															    </P>
														    </td>
														    <td vAlign="top" align="left" width="430" style="WIDTH: 430px; height: 23px;" colspan="3">
															    <P class="ptext"><asp:TextBox ID="txtluongtangca" Runat="server" Width="440px" tabIndex="2" Height="19px"></asp:TextBox></P>
														    </td>
													    </tr>
													    
													    <tr>
														    <td vAlign="top" noWrap align="right" style="HEIGHT: 40px">
															    <P class="ptext">
                                                                    Lương làm ngày chủ nhật :&nbsp;
															    </P>
														    </td>
														    <td vAlign="top" align="left" width="430" style="WIDTH: 430px; height: 40px;" colspan="3">
															    <P class="ptext"><asp:TextBox ID="txtluongngaychunhat" Runat="server" Width="440px" tabIndex="4"></asp:TextBox></P>
															    <INPUT id="txtnew" type="hidden" value='""' name="txtnew" runat="server" style="WIDTH: 32px; HEIGHT: 22px"
																	    size="1"><INPUT id="idsetting" type="hidden" value="" name="idsetting" runat="server" style="WIDTH: 32px; HEIGHT: 22px"
																	    size="1">
														    </td>
													    </tr>
													    <TR style="PADDING-TOP: 2px">
														    <td vAlign="top" noWrap align="left" style="PADDING-LEFT: 50px; WIDTH: 102px; height: 19px;"></td>
														    <td colspan="3" vAlign="top" align="left" width="430" style="WIDTH: 430px; height: 19px;"
															    nowrap><asp:imagebutton id="btnAdd" onclick="btnAdd_Click" runat="server" imageurl="../images/nut_add.gif"
																    tabIndex="8"></asp:imagebutton>&nbsp;
															    </td>
													    </tr>
												    </TABLE>
                                                  </td>
										    </tr>
									    </TABLE>
								    </td>
							    </tr>
						    </TABLE>
						    
						    <table cellPadding="0" width="100%" border="0">
							    <tr>
								    <td vAlign="top" align="left" width="100%" height="20"><P class="title">
                                        &nbsp;</P>
                                        <p>
                                            &nbsp;</p>
                                        <p>
                                            &nbsp;</p>
                                        <p>
                                            &nbsp;</p>
								    </td>
							    </tr>
						    </TABLE>						   
						    <table cellPadding="0" width="100%" border="0">
							    <tr>
								    <td vAlign="top" align="center" width="100%" colSpan="2" height="20">
									    &nbsp;												
								    </td>
							    </tr>
						    </TABLE>
					    </td>
				    </tr>
			    </table>
		    </td>
	    </tr>				
    </table>
        </td>
       </tr>
     </table>    
 </form>
<!--#include file ="footer.htm"-->