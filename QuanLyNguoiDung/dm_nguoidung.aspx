<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dm_nguoidung.aspx.cs" Inherits="dm_nguoidung" %>
<%@ Register Src="menu_HeThong.ascx" TagName="menu_HeThong" TagPrefix="uc1" %>
<!--#include file ="header_hethong.htm"-->

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
	function testinsertND()
	{
	    var onhom = document.getElementById("txtTenBacSi");
	    if(onhom.value=="")
	    {
	        alert("Bạn chưa nhập tên, hãy thử lại!")
	        return false;
	        onhom.focus();
	    }
	    var olinks = document.getElementById("txtUserName");
	     if(olinks.value=="")
	    {
	        alert("Bạn chưa nhập tên đăng nhập, hãy thử lại!")
	        return false;
	        olinks.focus();
	    }
	    var opass = document.getElementById("txtPassWord");
	    if(opass.value=="")
	    {
	        alert("Bạn chưa nhập mật khẩu, hãy thử lại!")
	        return false;
	        opass.focus();
	    }
	    var onhom = document.getElementById("DDlnhom");
	    if(onhom.value==""||onhom.value=="0")
	    {
	        alert("Bạn chưa chọn tên nhóm, hãy thử lại!")
	        return false;
	        onhom.focus();
	    }
	}
	$(document).ready(function()
    {
	    
	    $("#<%=txtTenBacSi.ClientID %>").unautocomplete().autocomplete("ajax.aspx?do=timNhanVien",
        {formatItem: function(data) {
                return data[1];
            },width:700,scroll: true}
        )
        
        .result(function(event, data){
               
               document.getElementById("<%=DDlnhom.ClientID %>").options.selectedIndex =0 ;
               document.getElementById("<%=txtUserName.ClientID %>").value = "";
               document.getElementById("<%=txtTenBacSi.ClientID %>").value = data[1];
               document.getElementById("<%=txtDienThoai.ClientID %>").value = data[2];

        });
	});
</script>
<form id="Form1" method="post" runat="server"> 
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
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
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
		    <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px">
			    <table id="user" cellSpacing="1" cellPadding="1" width="100%" border="0" class = "khung">
				    <tr>
				        <td class="title" align = "center" style ="background-color: #4D67A2">
			                <span class="title" style ="color:#FFFFFF">DANH MỤC NGƯỜI DÙNG</span></td>
				    </tr>				    <TR>
					    <TD width="100%">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" style="height: 179px">
									    <TABLE cellSpacing="0" cellPadding="0" width="98%" border="0">
										    
										    <TR style="PADDING-BOTTOM: 5px; PADDING-TOP: 10px">
											    <TD align="left" width="100%" style="height: 100px">
												    <TABLE style="HEIGHT: 17px" cellSpacing="0" cellPadding="0" width="100%" border="0">
													    <TR>
														    <TD vAlign="top" noWrap align="right" style="WIDTH: 159px; height: 24px;">
															    <P class="ptext">
                                                                    Tên người dùng:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" width="430" style="WIDTH: 600px; height: 24px;" colspan="3">
															    <P class="ptext"><asp:TextBox ID="txtTenBacSi" tabIndex="0" Runat="server" Width="200px"></asp:TextBox>
                                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                    Điện thoại:<asp:TextBox ID="txtDienThoai" Runat="server" Width="200px" tabIndex="1"></asp:TextBox></P>
														    </TD>
													    </TR>
													    <TR>
														    <TD vAlign="top" noWrap align="right" style="WIDTH: 159px; height: 24px;">
															    <P class="ptext">
                                                                    Tên đăng nhập:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" width="430" style="WIDTH: 85%; height: 24px;" colspan="3">
															    <P class="ptext"><asp:TextBox ID="txtUserName" Runat="server" Width="200px" tabIndex="2" Onblur = "CheckTrungTenDangNhap(this.value);"></asp:TextBox>
															        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
															        Mật khẩu&nbsp;:&nbsp;<asp:TextBox ID="txtPassWord" Runat="server" Width="194px" tabIndex="3" TextMode="Password"></asp:TextBox>
                                                                    <asp:textbox id="txtpassold" runat="server" visible="False"></asp:textbox>
                                                                </P>
														    </TD>
													    </TR>
													    <TR>
														    <TD vAlign="top" noWrap align="right" style="WIDTH: 159px; height: 19px;">
															    <P class="ptext">
                                                                    Nhóm người dùng:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" width="430" style="WIDTH: 430px; height: 19px;" colspan="3">
															    <P class="ptext">
                                                                    <asp:dropdownlist id="DDlnhom" runat="server" width="513px" TabIndex="4"></asp:dropdownlist>
                                                                    &nbsp;</P>
														    </TD>
													    </TR>
													    <TR>
														    <TD vAlign="top" noWrap align="right" style="WIDTH: 159px; height: 24px;">
															    <P class="ptext">
                                                                    &nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" width="430" style="WIDTH: 430px; height: 24px;" colspan="3">
															    <P class="ptext" id = "txtPermis" runat = "server">
                                                                    &nbsp;
                                                                    <asp:imagebutton id="btnAdd" onclick="btnAdd_Click" onfocus="testinsertND()" runat="server" imageurl="images/nut_add.gif"
																    tabIndex="5"></asp:imagebutton>
																    <asp:imagebutton id="btnEdit" onclick="btnEdit_Click" runat="server" imageurl="images/sua.gif" tabIndex="6"></asp:imagebutton>
																    <asp:imagebutton id="btnCancel" onclick="btnCancel_Click" runat="server" imageurl="images/MOI.gif"
																    tabIndex="7"></asp:imagebutton>
                                                                    <asp:imagebutton id="btnSearch" runat="server" imageurl="~/images/nut_search.jpg"
                                                                         tabindex="7" OnClick="btnSearch_Click"></asp:imagebutton>
                                                                </P>	<INPUT id="txtmabacsi_edit" type="hidden" value='""' name="txtmabacsi" runat="server" style="WIDTH: 32px; HEIGHT: 22px"
																	    size="1"/>														    
														    </TD>
													    </TR>
													    
													  
												    </TABLE>
                                                  </TD>
										    </TR>
									    </TABLE>
								    </TD>
							    </TR>
						    </TABLE>
						    
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="left" width="100%" height="20"><P class="title">DANH SÁCH NGƯỜI DÙNG HỆ THỐNG</P>
								    </TD>
							    </TR>
						    </TABLE>						   
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" colSpan="2" height="20">
                                        <asp:gridview id="GVlistUser" runat="server" autogeneratecolumns="False"
                                            onpageindexchanging="GVlistUser_PageIndexChanging" onrowcommand="GVlistUser_RowCommand"
                                            width="99%" CellPadding="4" ForeColor="#333333" GridLines="None">
<RowStyle HorizontalAlign="Left" BackColor="#EFF3FB" BorderColor="#006699" BorderStyle="None"></RowStyle>
<Columns>
<asp:TemplateField><ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" OnClientClick='return confirm("Bạn có muốn thực hiện thao tác !?")' CausesValidation="False" CommandArgument='<%# Eval("idnguoidung") %>' CommandName="delete1" CssClass="alink3" __designer:wfdid="w1">Xóa</asp:LinkButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
<asp:LinkButton id="LinkButton2" runat="server" CausesValidation="False" CommandArgument='<%# Eval("idnguoidung") %>' CommandName="edit1" CssClass="alink3" __designer:wfdid="w2">Sửa</asp:LinkButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="tennhom" HeaderText="Nh&#243;m người d&#249;ng"></asp:BoundField>
<asp:BoundField DataField="tennguoidung" HeaderText="T&#234;n người d&#249;ng">
<ItemStyle HorizontalAlign="Left" CssClass="ptext"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="username" HeaderText="T&#234;n đăng nhập">
<ItemStyle HorizontalAlign="Left" CssClass="ptext"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="dienthoai" HeaderText="Điện thoại">
<ItemStyle HorizontalAlign="Left" CssClass="ptext"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" CssClass="#F6EBCD" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" CssClass="dgrHeader" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle HorizontalAlign="Left" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:gridview>
                                        &nbsp;												
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
 </form>
<!--#include file ="footer.htm"-->