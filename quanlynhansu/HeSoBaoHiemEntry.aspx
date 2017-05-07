<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HeSoBaoHiemEntry.aspx.cs" Inherits="HeSoBaoHiemEntry" %>

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
	function CheckValid()
	{
	    var Ma = document.getElementById("txtMaBaoHiem");
	    if(Ma.value =="")
	        {
	            alert("Bạn chưa nhập Mã Bảo Hiểm !");
	            return false;
	        }
	    var Ten = document.getElementById("txtTenBaoHiem");
	    if(Ten.value =="")
	        {
	            alert("Bạn chưa nhập Tên Bảo Hiểm !");
	            return false;
	        }
	    var so1 = document.getElementById("txtCtyTra");
	    if(so1.value =="")
	        {
	            alert("Bạn chưa nhập % Cty trả !");
	            return false;
	        }
	    if(eval(so1.value) < 0 || eval(so1.value) > 100)
	        {
	            alert("% Cty trả không hợp lệ !");
	            return false;
	        }
	    var so2 = document.getElementById("txtNhanVienTra");
	    if(so2.value =="")
	        {
	            alert("Bạn chưa nhập % Nhân Viên trả !");
	            return false;
	        }
	    if(eval(so2.value) < 0 || eval(so2.value) > 100)
	        {
	            alert("% Nhân Viên trả không hợp lệ !");
	            return false;
	        }
	    return true;
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
                                                    HỆ SỐ BẢO HIỂM
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="100%">
                                                    <table cellpadding="0" width="100%" border="0">
                                                        <tr>
                                                            <td valign="top" align="center" width="100%" style="height: 151px">
                                                                <table cellspacing="0" cellpadding="0" width="98%" border="0">
                                                                    <tr style="padding-bottom: 5px; padding-top: 10px">
                                                                        <td align="center" width="100%" style="height: 81px; padding-left: 50px">
                                                                            <table width="400px" rules="none" style="border-color: Blue; border-style: double;
                                                                                border: 2px">
                                                                                 <tr>
                                                                                    <td valign="top" nowrap align="right" style="height: 23px; padding-left: 10px; width: 110px;">
                                                                                        <p class="ptext">
                                                                                            Mã Bảo Hiểm :&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="left" style="width: 430px; height: 23px;" colspan="3">
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txtMaBaoHiem" CssClass="input" runat="server" width="248px" tabindex="2" height="19px"></asp:textbox>
                                                                                        </p>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" nowrap align="right" style="height: 23px; padding-left: 10px; width: 110px;">
                                                                                        <p class="ptext">
                                                                                            Tên Bảo Hiểm :&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="left" style="width: 430px; height: 23px;" colspan="3">
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txtTenBaoHiem" CssClass="input" runat="server" width="248px" tabindex="2" height="19px"></asp:textbox>
                                                                                        </p>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" nowrap align="right" style="height: 40px; padding-left: 10px; width: 110px;">
                                                                                        <p class="ptext">
                                                                                            Cty Trả :&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="left" style="width: 430px; height: 40px;" colspan="3">
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txtCtyTra" CssClass="input" onblur="TestNum(this);" runat="server" width="39px" tabindex="4"></asp:textbox>
                                                                                            % &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Nhân Viên trả :
                                                                                            <asp:textbox id="txtNhanVienTra" CssClass="input" onblur="TestNum(this);" runat="server" tabindex="4" width="39px"></asp:textbox>
                                                                                        </p>
                                                                                        <input id="txtmaphieu"  type="hidden" value='""' name="txtmaphieu" runat="server"
                                                                                            style="width: 32px; height: 22px" size="1">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" nowrap align="right" style="height: 40px; padding-left: 10px; width: 110px;">
                                                                                        <p class="ptext">
                                                                                            Ghi chú :&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="left" style="width: 430px; height: 40px;" colspan="3">
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txtGhiChu" CssClass="input" runat="server" width="248px" tabindex="4" textmode="MultiLine"></asp:textbox>
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
                                                                                                    <asp:imagebutton id="btnAdd" onclientclick="return CheckValid();" onclick="btnAdd_Click" runat="server" imageurl="../images/nut_add.gif"
                                                                                                        tabindex="8"></asp:imagebutton>
                                                                                                    &nbsp;
                                                                                                    <asp:imagebutton id="btnEdit" onclientclick="return CheckValid();" onclick="btnEdit_Click"  runat="server" imageurl="../images/sua.gif"
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
                                                                THÔNG TIN DANH MỤC CHỨC VỤ
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" width="100%" border="0">
                                                        <tr>
                                                            <td valign="top" align="center" width="100%" colspan="2" height="20">
                                                                <asp:datagrid id="dgr" tabindex="12" runat="server" width="100%" allowsorting="True"
                                                                    autogeneratecolumns="False" datakeyfield="IdHeSoBH" borderwidth="1px" bordercolor="Silver"
                                                                    onitemdatabound="dgr_ItemDataBound" cellpadding="2" ondeletecommand="DelPhongKham"
                                                                    oneditcommand="Edit" allowpaging="True" onpageindexchanged="PageIndexStyleChanged"
                                                                    pagesize="30">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
														    <asp:LinkButton id="lbtnDel" CommandName="Delete" runat="server" CssClass="alink3">Xóa</asp:LinkButton>
													    
</ItemTemplate>

<HeaderStyle Width="4%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
														    <asp:LinkButton id="lbtnEdit" CommandName="Edit" runat="server" CssClass="alink3">Sửa</asp:LinkButton>
													    
</ItemTemplate>

<HeaderStyle Width="4%"></HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn DataField="MaHSBH" HeaderText="M&#227; Bảo Hiểm" SortExpression="MaHSBH">
<HeaderStyle Wrap="False" Width="15%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TenBaoHiem" HeaderText="T&#234;n Bảo Hiểm">
<HeaderStyle Wrap="False" Width="30%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CtyTra" HeaderText="Cty trả(%)">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle Wrap="False" ></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NVTra" HeaderText="Nh&#226;n vi&#234;n trả(%)">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ghichu" HeaderText="Ghi ch&#250;">
<HeaderStyle Wrap="False" Width="20%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" BackColor="#FFE0C0" CssClass="dgrHeader" Font-Bold="True" Font-Size="Smaller" ForeColor="Blue"></HeaderStyle>
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
