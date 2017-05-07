<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XepLoaiEntry.aspx.cs" Inherits="XepLoaiEntry" %>

<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->

<script language="javascript">
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
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: #C0C0C0">
        <tr>
            <td width="100%" align="left" style="background-color: #FBF8F1; height: 19px;">
                <uc1:uscmenu ID="Uscmenu1" runat="server" />
            </td>
        </tr>
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td valign="top" style="padding-left: 0px; padding-top: 0px; width: 100%;">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px">
                                        <table id="user" cellspacing="1" cellpadding="1" width="100%" border="0" class="khung">
                                            <tr>
                                                <td align="center" style="width: 100%; background-color: #FBF8F1; height: 19px; background-image: url(../images/menu.jpg);
                                                    color: Red; font-weight: bold">
                                                    QUẢN LÝ DANH MỤC XẾP LOẠI
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="100%" align="center">
                                                    <table cellpadding="0" width="100%" border="0">
                                                        <tr>
                                                            <td valign="top" align="center" width="100%" style="height: 151px">
                                                                <table cellspacing="0" cellpadding="0" width="98%" border="0">
                                                                    <tr style="padding-bottom: 5px; padding-top: 10px">
                                                                        <td align="center" width="100%" style="height: 81px; padding-left: 50px">
                                                                            <table width="400px" rules="none" style="border-color: Blue; border-style: double;
                                                                                border: 4px">
                                                                                <%--<tr>
                                                                                    <td valign="top" nowrap align="right" style="height: 23px; padding-left: 10px; width: 110px;">
                                                                                        <p class="ptext">
                                                                                            Mã loại tăng ca :&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="left" width="430" style="width: 430px; height: 23px;" colspan="3">
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txtmachucvu" runat="server" width="248px" tabindex="2" height="19px"></asp:textbox>
                                                                                        </p>
                                                                                    </td>
                                                                                </tr>--%>
                                                                                <tr>
                                                                                    <td valign="top" nowrap align="right" style="height: 40px; padding-left: 10px; width: 120px;">
                                                                                        <p class="ptext">
                                                                                            Tên xếp loại:&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="left" width="430" style="width: 430px; height: 40px;" colspan="3">
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txttenxeploai" runat="server" width="248px" tabindex="4"></asp:textbox>
                                                                                        </p>
                                                                                        <input id="txtmaphieu" type="hidden" value='""' name="txtmaphieu" runat="server"
                                                                                            style="width: 32px; height: 22px" size="1">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" nowrap align="right" style="height: 40px; padding-left: 10px; width: 120px;">
                                                                                        <p class="ptext">
                                                                                            Ghi chú:&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="left" width="430" style="width: 430px; height: 40px;" colspan="3">
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txtGhiChu" runat="server" width="248px"  tabindex="4" TextMode="MultiLine"></asp:textbox>
                                                                                        </p>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <table width="400px">
                                                                                <tr>
                                                                                    <td style="height: 20px; width: 437px;">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" style="width: 70%">
                                                                                        <table style="border-color: Gray; border-style: double; border: 0px;">
                                                                                            <tr style="padding-top: 2px">
                                                                                                <td valign="top" align="center" width="430" style="width: 430px; height: 19px;" nowrap>
                                                                                                    <asp:imagebutton id="btnAdd" onclick="btnAdd_Click" runat="server" imageurl="../images/nut_add.gif"
                                                                                                        tabindex="8"></asp:imagebutton>
                                                                                                    &nbsp;
                                                                                                    <asp:imagebutton id="btnEdit" onclick="btnEdit_Click" runat="server" imageurl="../images/sua.gif"
                                                                                                        tabindex="9"></asp:imagebutton>
                                                                                                    &nbsp;
                                                                                                    <asp:imagebutton id="btnCancel" onclick="btnCancel_Click" runat="server" imageurl="../images/cancel.gif"
                                                                                                        tabindex="10"></asp:imagebutton>
                                                                                                    &nbsp;
                                                                                                    <asp:imagebutton id="btnTim" runat="server" imageurl="../images/tim.png" tabindex="10"
                                                                                                        onclick="btnTim_Click"></asp:imagebutton>
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
                                                    <table cellpadding="0" width="100%" border="0">
                                                        <tr>
                                                            <td align="left" style="width: 100%; background-color: #FBF8F1; height: 19px; background-image: url(../images/menu.jpg);
                                                                color: White; font-weight: bold">
                                                                THÔNG TIN DANH MỤC XẾP LOẠI
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" width="70%" border="0">
                                                        <tr>
                                                            <td valign="top" align="right" width="100%" colspan="2" height="20">
                                                                <asp:datagrid id="dgr" tabindex="12" runat="server" width="100%" allowsorting="True"
                                                                    autogeneratecolumns="False" datakeyfield="idxeploai" borderwidth="1px" bordercolor="Silver"
                                                                    onitemdatabound="dgr_ItemDataBound" cellpadding="2" ondeletecommand="DelXepLoai"
                                                                    oneditcommand="Edit" allowpaging="True" onpageindexchanged="PageIndexStyleChanged"
                                                                    pagesize="30">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
														    <asp:LinkButton id="lbtnDel" CommandName="Delete" runat="server" CssClass="alink3">Xóa</asp:LinkButton>
													    
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
														    <asp:LinkButton id="lbtnEdit" CommandName="Edit" runat="server" CssClass="alink3">Sửa</asp:LinkButton>
													    
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<%--<asp:BoundColumn DataField="machucvu" HeaderText="M&#227; chức vụ" SortExpression="machucvu">
<HeaderStyle Wrap="False" Width="15%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>--%>
<asp:BoundColumn DataField="tenxeploai" HeaderText="Tên xếp loại">
<HeaderStyle Wrap="False" Width="40%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ghichu" HeaderText="Ghi chú">
<HeaderStyle Wrap="False" Width="40%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" BackColor="#FFE0C0" CssClass="dgrHeader" Font-Bold="True" ForeColor="Blue"></HeaderStyle>
</asp:datagrid>
                                                                &nbsp;
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
</form>
<!--#include file ="footer.htm"-->
