<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhSachBNChuyenKhoa.aspx.cs"
    Inherits="DanhSachBNChuyenKhoa" %>

<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<script language="javascript">
    var dp_cal, dp_cal1;      
	window.onload = function () 
	{
	 //   dp_cal = new Epoch('epoch_popup','popup',document.getElementById('Tungay'));
	   // dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('Denngay'));
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
            <td style="background-color:#fff">
                <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
            </td>
        </tr>
        <tr>
            <td align="left" style="background-color: #D4D0C8; width: 101%;">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px">
                            <table id="user" cellspacing="1" cellpadding="1" width="100%" border="0" class="khung">
                                <tr>
                                    <td class="title" align="center" style="background-color: #4D67A2; height: 21px;">
                                        <span class="title" style="color: #FFFFFF">DANH SÁCH BỆNH NHÂN CHUYỂN KHOA/PHÒNG</span></td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="center" style="height: 133px; width: 100%;">
                                                    <table cellspacing="0" cellpadding="0" width="98%" border="0">
                                                        <tr style="padding-bottom: 5px; padding-top: 10px">
                                                            <td align="left" width="100%" style="height: 100px">
                                                             <asp:scriptmanager runat="server" id="sdfs"></asp:scriptmanager>
                                                               <div style="float:left; ">
                                                                <asp:updatepanel runat="server" id="edfa"><ContentTemplate>
Khoa : <asp:DropDownList id="Khoa" runat="server" style="width:170px;" OnSelectedIndexChanged="Khoa_SelectedIndexChanged" AutoPostBack="true">
    </asp:DropDownList> <asp:Label id="lbChuyenKhoa" runat="server" Text="Nội dung KCB :"></asp:Label> <asp:DropDownList id="DichvuKCB" runat="server" OnSelectedIndexChanged="DichvuKCB_SelectedIndexChanged" AutoPostBack="true">
    </asp:DropDownList> Phòng : <asp:DropDownList id="Phong" runat="server" AutoPostBack="True">
    </asp:DropDownList> 
</ContentTemplate>
</asp:updatepanel></div>
                                                                <div style="float:left">&nbsp;
                                                                    Mã bệnh nhân :
                                                                    <asp:textbox id="txtMaBN" style="width:95px;" runat="server"></asp:textbox>
                                                                    Tên bệnh nhân :
                                                                    <asp:textbox id="txtTenBN" runat="server"></asp:textbox>
                                                                </div>
                                                                <div style="clear:both;"></div>
                                                                <div style="float:left;">
                                                                <fieldset style="width:100%; padding-bottom:10px;">
                                                                    <legend>Ngày khám</legend>
                                                                    <div style="padding:10px;">
                                                                        Từ ngày :
                                                                        <asp:textbox id="Tungay" runat="server" onfocus="$(this).datepick();"></asp:textbox>
                                                                        Đến ngày :
                                                                        <asp:textbox id="Denngay" runat="server" onfocus="$(this).datepick();"></asp:textbox>
                                                                        <asp:button id="TimKiem" runat="server" onclick="TimKiem_Click" text="Lấy danh sách" />
                                                                    </div>
                                                                </fieldset>
                                                                </div>
                                                                <asp:gridview id="GridView1" width="100%" runat="server" datakeynames="IDKHAMBENH"
                                                                    allowpaging="true" pagesize="100" cellpadding="4" forecolor="#333333" autogeneratecolumns="false"
                                                                    onrowcommand="GridView1_RowCommand" onpageindexchanging="GridView1_PageIndexChanging"
                                                                    onrowdatabound="GridView1_RowDataBound">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle CssClass="dgrNoSelectItem"/>
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle CssClass="dgrSelectItem"/>
                        <Columns>
                            <asp:ButtonField CommandName="Kham" Text="Khám" ><ItemStyle Font-Bold="True"  ForeColor="Blue"  HorizontalAlign="Center" /> </asp:ButtonField >
                            <asp:TemplateField HeaderText="STT">
                                <ItemStyle  HorizontalAlign="Center" />
                                <ItemTemplate>
                                <asp:Label ID="STT"  runat="server" Text='<%#Eval("STT") %>' Width="30px" Height="30"></asp:Label>
                                <asp:Label ID="IDBENHNHAN" Visible="false" runat="server" Text='<%#Eval("IDBENHNHAN") %>' Width="100px" Height="30"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Mã bệnh nhân">
                                <ItemTemplate>
                                    <asp:Label ID="MABENHNHAN" runat="server" Text='<%# bind("mabenhnhan") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Tên bệnh nhân">
                                <ItemTemplate>
                                    <asp:Label ID="TENBENHNHAN" runat="server" Text='<%# bind("TENBENHNHAN") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ngày sinh">
                                <ItemStyle  HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="TUOI" runat="server" Text='<%# bind("ngaysinh") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Giới tính">
                               <ItemStyle  HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="GIOITINH" runat="server" Text='<%# Eval("GIOITINH") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Ngày chuyển">
                               <ItemStyle  HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="TGXuatVien" runat="server" Text='<%# Bind("TGXuatVien") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Bác sĩ chuyển">
                                <ItemTemplate>
                                    <asp:Label ID="TENBACSI" runat="server" Text='<%# Eval("TENBACSI") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Khoa chuyển">
                               <ItemStyle  HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="TENKHOA" runat="server" Text='<%# Eval("TENKHOA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Phòng chuyển">
                                <ItemStyle  HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="TENPHONG" runat="server" Text='<%# Eval("TENPHONG") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:gridview>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="left" width="100%" height="20">
                                                    <p class="title">
                                                        &nbsp;</p>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="center" width="100%" colspan="2" height="20">
                                                    &nbsp;</td>
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
