<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NgayNghiNhanVienEntry.aspx.cs"
    Inherits="NgayNghiNhanVienEntry" %>

<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>

<!--#include file ="header.htm"-->



<script language="javascript">
var dp_cal, dp_cal1;      
	window.onload = function () 
	{
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtNgayBatDau'));
	    dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtNgayKetThuc'));
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
            <td width="100%" align="left" style="background-color: White">
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
                                                    QUẢN LÝ LỊCH NGHỈ NHÂN VIÊN</td>
                                            </tr>
                                            <tr>
                                                <td width="100%" align="center">
                                                    <table cellpadding="0" width="100%" border="0">
                                                        <tr>
                                                            <td valign="top" align="center" width="100%" style="height: 151px">
                                                                <table cellspacing="0" cellpadding="0" width="98%" border="0">
                                                                    <tr style="padding-bottom: 5px; padding-top: 10px">
                                                                        <td align="center" style="height: 81px; padding-left: 50px; width: 100%;">
                                                                            <table width="700px" rules="groups" cellpadding="0px" cellspacing="0px" style="border-color: Blue;border-style: double; border: 4px">
                                                                                
                                                                                <tr>
                                                                                    <td colspan="4" style="height: 10px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" align="left" style="height: 40px; padding-left: 10px; width: 15%;">
                                                                                        <p class="ptext">
                                                                                            Nhân viên:&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="right" style="width: 39%; height: 40px; padding-right: 10px">
                                                                                        <p class="ptext">
                                                                                            <%--<asp:textbox id="txtMaLoaiNgayNghi" runat="server" width="248px" tabindex="4"></asp:textbox>--%>
                                                                                            <asp:dropdownlist id="ddlNhanVien" runat="server" width="90%" tabindex="1"></asp:dropdownlist>
                                                                                            &nbsp;</p>
                                                                                    </td>
                                                                                    <td valign="top" align="right" style="padding-right: 2px; width: 15%; height: 40px;">
                                                                                        <p class="ptext">
                                                                                            Số ngày nghỉ:&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="right" style="width: 31%; height: 40px; padding-right: 10px">
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txtSoNgayNghi" runat="server" width="90%" tabindex="4"></asp:textbox>
                                                                                        </p>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" align="left" style="height: 40px; padding-left: 10px; width: 15%;">
                                                                                        <p class="ptext">
                                                                                            Ngày bắt đầu:&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="right" style="width: 39%; height: 40px; padding-right: 10px">
                                                                                        <asp:textbox id="txtNgayBatDau" runat="server" width="70%" tabindex="5"></asp:textbox>
                                                                                        <input id="Button1" type="button" value="..." onclick="dp_cal.toggle()" /></td>
                                                                                    <td valign="top" align="right" style="padding-right: 2px; width: 15%;">
                                                                                        <p class="ptext">
                                                                                            Ngày kết thúc:&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="right" style="width: 31%; height: 40px; padding-right: 10px">
                                                                                        <asp:textbox id="txtNgayKetThuc" runat="server" width="70%" tabindex="5"></asp:textbox>
                                                                                        <input id="Button2" type="button" value="..." onclick="dp_cal1.toggle()" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" align="left" style="height: 40px; padding-left: 10px; width: 15%;">
                                                                                        <p class="ptext">
                                                                                            Lý do:&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="right" style="width: 39%; height: 40px; padding-right: 10px">
                                                                                                    <asp:textbox id="txtLyDo" runat="server" width="93%" tabindex="4" TextMode="MultiLine"></asp:textbox></td>
                                                                                    <td valign="top" align="right" style="padding-right: 2px; width: 15%;">
                                                                                        <p class="ptext">
                                                                                            Trừ lương:&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="right" style="width: 31%; height: 40px; padding-right: 10px">
                                                                                                    <asp:textbox id="txtSoTien" runat="server" width="63%" tabindex="3"></asp:textbox>
                                                                                        <asp:label runat="server" id="vnd" text="VNĐ" Font-Bold="True" ForeColor="Red"></asp:label>
                                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <table width="400px">
                                                                                <tr>
                                                                                    <td style="height: 20px; width: 437px;">
                                                                                        <input id="txtmaphieu" type="hidden" value='""' name="txtmaphieu" runat="server"
                                                                                            style="width: 32px; height: 22px" size="1"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" style="width: 70%">
                                                                                        <table style="border-color: Gray; border-style: double; border: 0px;">
                                                                                            <tr style="padding-top: 2px">
                                                                                                <td valign="top" align="center" width="430" style="width: 430px; height: 19px;" nowrap>
                                                                                                    <asp:imagebutton id="btnAdd" onclick="btnAdd_Click" runat="server" imageurl="../images/nut_add.gif"
                                                                                                        tabindex="6"></asp:imagebutton>
                                                                                                    &nbsp;
                                                                                                    <asp:imagebutton id="btnEdit" onclick="btnEdit_Click" runat="server" imageurl="../images/sua.gif"
                                                                                                        tabindex="7"></asp:imagebutton>
                                                                                                    &nbsp;
                                                                                                    <asp:imagebutton id="btnCancel" onclick="btnCancel_Click" runat="server" imageurl="../images/cancel.gif"
                                                                                                        tabindex="8"></asp:imagebutton>
                                                                                                    &nbsp;
                                                                                                    <asp:imagebutton id="btnTim" runat="server" imageurl="../images/tim.png" tabindex="9"
                                                                                                        onclick="btnTim_Click"></asp:imagebutton>
                                                                                                    &nbsp;
                                                                                                <asp:imagebutton id="imgInExel" runat="server" imageurl="~/images/btnExcel.jpg"  onclick="imgInExel_Click"></asp:imagebutton>
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
                                                            <td align="left" style="width: 100%; background-color: #FBF8F1; height: 18px; background-image: url(../images/menu.jpg);
                                                                color: White; font-weight: bold">
                                                                &nbsp;LỊCH NGHỈ NHÂN VIÊN</td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" width="100%" border="0" style="background-color: #D4D0C8">
                                                        <tr>
                                                            <td valign="top" align="right" colspan="2" style="width: 80%; background-color: #D4D0C8">
                                                                <asp:datagrid id="dgr" tabindex="10" runat="server" width="100%" allowsorting="True"
                                                                    autogeneratecolumns="False" datakeyfield="idngaynghinhanvien" borderwidth="1px" bordercolor="Silver"
                                                                    onitemdatabound="dgr_ItemDataBound" cellpadding="2" ondeletecommand="Dellete"
                                                                    oneditcommand="Edit" allowpaging="True" onpageindexchanged="PageIndexStyleChanged"
                                                                    pagesize="30">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
														    <asp:LinkButton id="lbtnDel" CommandName="Delete" runat="server" CssClass="alink3">Xóa</asp:LinkButton>
													    
</ItemTemplate>

<HeaderStyle Width="7%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
														    <asp:LinkButton id="lbtnEdit" CommandName="Edit" runat="server" CssClass="alink3">Sửa</asp:LinkButton>
													    
</ItemTemplate>

<HeaderStyle Width="8%"></HeaderStyle>
</asp:TemplateColumn>

<asp:BoundColumn DataField="STT" HeaderText="STT">
<HeaderStyle Wrap="False" Width="2%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Ma_Ten" HeaderText="Nh&#226;n vi&#234;n">
<HeaderStyle Wrap="False" Width="30%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngayBD" HeaderText="Từ ngày">
<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="ngayKT"  HeaderText="Đên ngày">
<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="songaynghi" HeaderText="Số ngày">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="lydo" HeaderText="Lý do">
<HeaderStyle Wrap="False" Width="20%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<%--<asp:BoundColumn DataField="truluong" DataFormatString="{0:0,000}" HorizontalAlign="Right"  HeaderText="Trừ lương">
<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False">
</ItemStyle>
</asp:BoundColumn>--%>
<asp:TemplateColumn >
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblTien" runat="server" Text="Trừ lương"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbVanBang" runat="server" Text='<%# Eval("truluong") %>'></asp:Label>
                                                    <asp:Label ID="lbvnd" ForeColor="Red" runat="server" Text='VNĐ'></asp:Label>
                                                    <headerstyle wrap="False" width="10%" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
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
            </td>
        </tr>
    </table>
</form>
<!--#include file ="footer.htm"-->
