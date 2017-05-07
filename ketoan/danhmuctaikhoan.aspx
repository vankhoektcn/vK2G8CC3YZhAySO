<%@ Page Language="C#" AutoEventWireup="true" CodeFile="danhmuctaikhoan.aspx.cs" Inherits="danhmuctaikhoan" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_HeThongDanhMuc.ascx" TagName="uscmenuKT_HeThongDanhMuc" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<!--#include file = "header.htm" -->
<%@ Register Src="hethongdanhmuc.ascx" TagName="hethongdanhmuc" TagPrefix="uc2" %>


<script language = "javascript">
    var dp_cal;      
	window.onload = function () 
	{
	    LoadTieuDe();
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtNgayBD'));
	};
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
	
	function FormatSoTien()
	{
	    var obj1 = document.getElementById("txtsotien");
	    var obj2 = document.getElementById("txtformatsotien");
	    obj2.value = formatCurrency(obj1.value);
	}
</script>
<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:uscmenuKT_HeThongDanhMuc ID="uscmenuKT_HeThongDanhMuc" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr>
                    <td width = "100%" class = "header">PHẦN MỀM QUẢN LÝ: DANH MỤC TÀI KHOẢN</td>
                </tr>
                <TR>
					    <TD width="100%" valign = "top">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%">
									    <TABLE cellSpacing="0" cellPadding="0" width="98%" border="0">
										    
										    <TR style="PADDING-BOTTOM: 5px; PADDING-TOP: 10px">
											    <TD align="left" width="100%" style="height: 20px">
												    <TABLE style="HEIGHT: 17px" cellSpacing="0" cellPadding="0" width="100%" border="0">
													    
													    <TR>
														    <TD  noWrap align="right" style="WIDTH: 12%; height: 24px;">
															    <span class="ptext">Tài khoản:&nbsp;
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH:18%; height: 24px;">
															    <span class="ptext">&nbsp;<asp:textbox id="txtTaiKhoan" runat="server" width="112px" TabIndex="1"></asp:textbox>&nbsp;
															    </span></TD>
														    <TD  noWrap align="right" style="WIDTH: 9%; height: 24px;">
															    <span class="ptext">Cấp:&nbsp;
															    </span>
														    </TD>
														    <TD  noWrap align="left" style="WIDTH: 25%; height: 24px;">
															    <span class="ptext">&nbsp;
                                                                    <asp:TextBox ID="txtCap" Runat="server" Width="38px" tabIndex="2" ReadOnly="False" ></asp:TextBox>&nbsp;</span>
														    </TD>
													    </TR>
													    <TR>
														    <TD  noWrap align="right" style="WIDTH: 12%; height: 24px;">
															    <span class="ptext">Tên tài khoản:&nbsp;
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH:18%; height: 24px;">
															    <span class="ptext">&nbsp;</span><asp:textbox id="txtTenTaiKhoan" runat="server" width="238px" TabIndex="4"></asp:textbox></TD>
														    <TD  noWrap align="right" style="WIDTH: 9%; height: 24px;">
															    <span class="ptext">Chi tiết:&nbsp;
															    </span>
														    </TD>
														    <TD  noWrap align="left" style="WIDTH: 25%; height: 24px;">
															    <span class="ptext">&nbsp;<asp:checkbox id="chkChiTiet" runat="server" textalign="right"
                                                                    width="96px"></asp:checkbox></span></TD>
													    </TR>
                                                        <tr>
                                                            <td align="right" nowrap="nowrap" style="width: 12%; height: 24px">
                                                                <span class="ptext">Loại tiền:&nbsp;</span></td>
                                                            <td align="left" style="width: 18%; height: 24px" valign="top">
                                                                &nbsp;<asp:textbox id="txtLoaiTien" runat="server" onblur="FormatSoTien()" tabindex="6"
                                                                    width="113px"></asp:textbox></td>
                                                            <td align="right" nowrap="nowrap" style="width: 9%; height: 24px">
                                                                <span class="ptext">Cấp cha:</span></td>
                                                            <td align="left" nowrap="nowrap" style="width: 25%; height: 24px">
                                                                &nbsp;
                                                                <asp:textbox id="txtCapCha" runat="server" readonly="False"
                                                                    tabindex="2" width="111px"></asp:textbox>
                                                            </td>
                                                        </tr>
													    <TR>
														    <TD  noWrap align="right" style="WIDTH: 12%; height: 24px;">
															    <span class="ptext">
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH:18%; height: 24px;" colspan = "3">
															    <span class="ptext"><br>
															        &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                    <asp:imagebutton id="btnAdd" runat="server" imageurl="../images/nut_add.gif"
																    tabIndex="10" OnClick="btnAdd_Click"></asp:imagebutton>&nbsp;
															    <asp:imagebutton id="btnEdit" runat="server" OnClick="btnEdit_Click" imageurl="../images/sua.gif" tabIndex="11"></asp:imagebutton>&nbsp;
															    <asp:imagebutton id="btnCancel" OnClick="btnCancel_Click"  runat="server" imageurl="../images/cancel.gif"
																    tabIndex="12"></asp:imagebutton>&nbsp;
															    <asp:ImageButton id="ImageButton1" OnClick="ImageButton1_Click" runat="server" ImageUrl="~/images/tim.png" TabIndex="13"></asp:ImageButton>
															    </span>
														    </TD>
														    
													    </TR>
												    </TABLE>
                                                  </TD>
										    </TR>
									    </TABLE>
								    </TD>
							    </TR>
							    <tr>
                                    <td width = "100%" class = "header">DANH SÁCH TÀI KHOẢN</td>
                                </tr>
						    </TABLE>
						    
						    				   
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" colSpan="2" height="20">
									    <asp:datagrid id="dgr" tabIndex="12" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
											    DataKeyField="TaiKhoan" BorderWidth="1px" BorderColor="Silver" OnItemDataBound="dgr_ItemDataBound" CellPadding="2" OnDeleteCommand = "DelTaiKhoan" OnEditCommand="Edit" AllowPaging="True"
											    OnPageIndexChanged="PageIndexStyleChanged" PageSize="100">
<PagerStyle Mode="NumericPages" ForeColor="DarkBlue" Font-Size="Small" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>

<AlternatingItemStyle CssClass="dgrSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></AlternatingItemStyle>

<ItemStyle CssClass="dgrNoSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle CssClass="dgrHeader" HorizontalAlign="Center"></HeaderStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnDel" runat="server" CssClass="alink3" CommandName="Delete" __designer:wfdid="w15">Xóa</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="3%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
														    <asp:LinkButton id="lbtnEdit" CommandName="Edit" runat="server" CssClass="alink3">Sửa</asp:LinkButton>
													    
</ItemTemplate>

<HeaderStyle Width="3%"></HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn DataField="TaiKhoan" HeaderText="T&#224;i khoản">
<ItemStyle Wrap="False"></ItemStyle>

<HeaderStyle Width="6%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TenTaiKhoan" HeaderText="T&#234;n t&#224;i khoản">
<ItemStyle Wrap="False" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

<HeaderStyle Width="15%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ChiTiet" HeaderText="Chi tiết">
<HeaderStyle Width="5%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TKCapCha" HeaderText="TK cấp cha">
<HeaderStyle Width="5%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="LoaiTien" HeaderText="Loại tiền">
<HeaderStyle Width="6%"></HeaderStyle>
</asp:BoundColumn>
</Columns>
</asp:datagrid>&nbsp;												
								    </TD>
							    </TR>
							    
						    </TABLE>
					    </TD>
				    </TR>
            </table>
         </td>
        </tr>       
	    
      </table>
   </form>         
<!--#include file = "footer.htm" -->
