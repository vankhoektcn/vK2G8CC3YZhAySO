<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhSachBNDaKham.aspx.cs"
    Inherits="DanhSachBNDaKham" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
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
<style type="text/css">
    a
    {
         text-decoration:underline;
         color:blue;
         font-weight:bold;
    }
    a:hover
    {
         text-decoration:none;
        color:red;
        cursor:hand;
    }
</style>
<form id="Form1" method="post" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: #C0C0C0">
        <tr>
            <td style="background-color: #fff">
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
                                        <span class="title" style="color: #FFFFFF">DANH SÁCH BỆNH NHÂN ĐÃ KHÁM</span></td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="center" width="100%" style="height: 133px">
                                                    <table cellspacing="0" cellpadding="0" width="98%" border="0">
                                                        <tr style="padding-bottom: 5px; padding-top: 10px">
                                                            <td align="left" width="100%" style="height: 100px">
                                                               
                                                               <asp:scriptmanager runat="server" id="sdfs"></asp:scriptmanager>
                                                                <div style="float:left; ">
                                                                <asp:updatepanel runat="server" id="edfa"><ContentTemplate>
Khoa : <asp:DropDownList id="Khoa" runat="server" style="width:170px;" OnSelectedIndexChanged="Khoa_SelectedIndexChanged" AutoPostBack="true">
    </asp:DropDownList> <asp:Label id="lbChuyenKhoa" runat="server" Text="Nội dung KCB :" __designer:wfdid="w1"></asp:Label> <asp:DropDownList id="DichvuKCB" runat="server" OnSelectedIndexChanged="DichvuKCB_SelectedIndexChanged" AutoPostBack="true">
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
                                                                    allowpaging="True" pagesize="100" cellpadding="4" forecolor="#333333" autogeneratecolumns="False"
                                                                    onrowcommand="GridView1_RowCommand" onpageindexchanging="GridView1_PageIndexChanging"
                                                                    onrowdatabound="GridView1_RowDataBound">
<RowStyle CssClass="dgrNoSelectItem"></RowStyle>
<Columns>
<asp:ButtonField CommandName="Kham" Text="Chi tiết">
<ItemStyle HorizontalAlign="Center" Font-Bold="True" ForeColor="Blue" Width="50px"></ItemStyle>
</asp:ButtonField>
<asp:TemplateField HeaderText="STT"><ItemTemplate>
<asp:Label id="STT" runat="server" __designer:wfdid="w5" Text='<%#Bind("STT") %>' Height="20" Width="30px" Visible="true"></asp:Label> <asp:Label id="IDBENHNHAN" runat="server" __designer:wfdid="w6" Text='<%#Bind("IDBENHNHAN") %>' Height="30" Width="30px" Visible="false"></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="M&#227; BN"><ItemTemplate>
                                    <asp:Label ID="mabenhnhan" runat="server" Width="120px" Text='<%# Bind("mabenhnhan") %>'>' ></asp:Label>
                                
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="T&#234;n bệnh nh&#226;n"><ItemTemplate>
                                    <asp:Label ID="TENBENHNHAN" runat="server" Width="180px" Text='<%# Bind("TENBENHNHAN") %>'>' ></asp:Label>
                                
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ng&#224;y sinh"><ItemTemplate>
                                    <asp:Label ID="TUOI" runat="server" Text='<%# Bind("ngaysinh") %>'></asp:Label>
                                
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Giới t&#237;nh"><ItemTemplate>
                                    <asp:Label ID="GIOITINH" runat="server" Text='<%# Eval("GIOITINH") %>'></asp:Label>
                                
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ng&#224;y kh&#225;m"><ItemTemplate>
                                    <asp:Label ID="NGAYKHAM" runat="server" Text='<%# string.Format("{0:dd/MM/yyyy hh:mm:ss}",Eval("NGAYKHAM")) %>'></asp:Label>
                                
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="B&#225;c sĩ"><ItemTemplate>
                                    <asp:Label ID="TENBACSI" runat="server" Text='<%# Eval("TENBACSI") %>'></asp:Label>
                                
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Hướng điều trị"><ItemTemplate>
                                    <asp:Label ID="TenHuongDieuTri" runat="server" Text='<%# Eval("TenHuongDieuTri") %>'></asp:Label>
                                
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Thao t&#225;c "><ItemTemplate>
  
    <a  onclick="window.open('rptPhieuChiDinh.aspx?IdKhamBenh=<%#Eval("IDKHAMBENH") %>&IsAll=1', '_blank', 'location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');" ><%#Eval("HaveCLS") %></a>&nbsp;
    <a  onclick="window.open('rpt_Toathuoc.aspx?IdKhamBenh=<%#Eval("IDKHAMBENH") %>&IsAll=1', '_blank', 'location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');" ><%#Eval("HaveThuoc") %></a>
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="220px"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="CreateUser" HeaderText="Người tạo"></asp:BoundField>
<asp:BoundField DataField="EditUser" HeaderText="Người sửa"></asp:BoundField>
<asp:BoundField DataField="LoaiDK" HeaderText="Loại hình"></asp:BoundField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle CssClass="dgrSelectItem"></AlternatingRowStyle>
</asp:gridview>
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
