<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThueTNCNEntry.aspx.cs" Inherits="ThueTNCNEntry" %>

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
	    var Ma = document.getElementById("txtMaThue");
	    if(Ma.value =="")
	        {
	            alert("Bạn chưa nhập mã loại thuế !");
	            return false;
	        }
	    var so1 = document.getElementById("txtLuongtu");
	    if(so1.value =="")
	        {
	            alert("Bạn chưa nhập khoảng lương !");
	            return false;
	        }
	    if(eval(so1.value) < 0 )
	        {
	            alert("Tiền lương không hợp lệ !");
	            return false;
	        }
	    var so2 = document.getElementById("txtLuongDen");
	    if(so2.value =="")
	        {
	            alert("Bạn chưa nhập khoảng lương !");
	            return false;
	        }
	    if(eval(so2.value) < 0 )
	        {
	            alert("Tiền lương không hợp lệ !");
	            return false;
	        }
	    var heso = document.getElementById("txtHeso");
	    if(heso.value =="")
	        {
	            alert("Bạn chưa nhập khoảng lương !");
	            return false;
	        }
	    if(eval(heso.value) < 0 || eval(heso.value) > 100)
	        {
	            alert("% hệ số không hợp lệ !");
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
                                                    HỆ SỐ THUẾ THU NHẬP CÁ NHÂN</td>
                                            </tr>
                                            <tr>
                                                <td width="100%">
                                                    <table cellpadding="0" width="100%" border="0">
                                                        <tr>
                                                            <td valign="top" align="center" width="100%" style="height: 151px">
                                                                <table cellspacing="0" cellpadding="0" width="98%" border="0">
                                                                    <tr style="padding-bottom: 5px; padding-top: 10px">
                                                                        <td align="center" width="100%" style="height: 81px; padding-left: 50px;padding-top:20px">
                                                                            <table rules="none" style="border-color: Blue; border-style: double;
                                                                                border: 4px; width: 755px;padding-top:20px">
                                                                                <tr>
                                                                                    <td valign="top" nowrap align="right" style="height: 23px; padding-left: 10px; width: 110px;">
                                                                                        <p class="ptext">
                                                                                            Mã Loại Thuế :&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="left" style=" height: 23px;padding-right:5px" colspan="3">
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txtMaThue" CssClass="input" runat="server" width="248px" tabindex="2" height="27px"></asp:textbox>
                                                                                            </p>
                                                                                    </td>
                                                                                </tr>
                                                                                <%--â  txtMaThue,txtLuongtu ,txtLuongDen ,txtHeso â--%>
                                                                                 <tr>
                                                                                    <td valign="top" nowrap align="right" style="height: 23px; padding-left: 10px; width: 110px;">
                                                                                        <p class="ptext">
                                                                                            Lương từ :&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="left" style=" height: 23px;padding-right:5px" colspan="3">
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txtLuongtu" CssClass="input" onblur="TestNum(this);" runat="server" width="150px" tabindex="2" height="20px"></asp:textbox>
                                                                                            &nbsp;&nbsp;<asp:label id="Label1" runat="server" font-bold="True" forecolor="Red"
                                                                                                text="VND"></asp:label>&nbsp; Đến :<asp:textbox id="txtLuongDen"  CssClass="input" onblur="TestNum(this);" runat="server" width="150px" tabindex="2" height="20px"></asp:textbox>
                                                                                            <asp:label id="Label2" runat="server" font-bold="True" forecolor="Red" text="VND"></asp:label>
                                                                                        </p>
                                                                                    </td>
                                                                                </tr>
                                                                                
                                                                                <tr>
                                                                                    <td valign="top" nowrap align="right" style="height: 40px; padding-left: 10px; width: 110px;">
                                                                                        <p class="ptext">
                                                                                            Hệ số :&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="left" style="width: 430px; height: 40px;" colspan="3">
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txtHeso" CssClass="input" onblur="TestNum(this);" runat="server" width="39px" tabindex="4"></asp:textbox>
                                                                                            % &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
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
                                                                                            <asp:textbox id="txtGhiChu" CssClass="input" runat="server" width="507px" tabindex="4" textmode="MultiLine"></asp:textbox>
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
                                                                THÔNG TIN DANH MỤC HỆ SỐ THUẾ THU NHẬP CÁ NHÂN&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" width="80%" align="center" style="" border="0">
                                                        <tr>
                                                            <td valign="top" align="center" width="100%" colspan="2" height="20">
                                                                <asp:datagrid id="dgr" tabindex="12" runat="server" width="100%" allowsorting="True"
                                                                    autogeneratecolumns="False" datakeyfield="idThueTNCN" borderwidth="1px" bordercolor="Silver"
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
<asp:BoundColumn DataField="MaTTNCN" HeaderText="Mã số" SortExpression="MaTTNCN">
<HeaderStyle Wrap="False" Width="15%"></HeaderStyle>

<ItemStyle Wrap="True" ></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="LuongTu" HeaderText="Lương từ">
<HeaderStyle Wrap="False" Width="15%"></HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="right"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="LuongDen" HeaderText="Lương đến">
<HeaderStyle Wrap="False" Width="15%"></HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="right"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="HeSo" HeaderText="Hệ số(%)">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ghichu" HeaderText="Ghi chú">
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
