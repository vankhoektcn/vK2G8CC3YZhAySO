<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhSachBNDKKham.aspx.cs"
    Inherits="DanhSachBNDKKham" %>

<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<style>
    .type1
    {
        background-color:#d2c2f6;
        
    }
    .type2
    {
        background-color:#00cccc;
        
    }
    .type3
    {
        background-color:#d3f9c2;
        
    }
</style>
<script language="javascript">
    var dp_cal, dp_cal1;      
	window.onload = function () 
	
	{
	  //  dp_cal = new Epoch('epoch_popup','popup',document.getElementById('Tungay'));
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
                                        <span class="title" style="color: #FFFFFF">DANH SÁCH BỆNH NHÂN CHỜ KHÁM BỆNH</span></td>
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
                                                                <fieldset style="width:100%;padding-bottom:10px;">
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
                                                                <asp:gridview id="GridView1" width="100%" runat="server" datakeynames="IDCHITIETDANGKYKHAM"
                                                                    allowpaging="True" pagesize="100" cellpadding="4" forecolor="#333333" autogeneratecolumns="False"
                                                                    onrowcommand="GridView1_RowCommand" onpageindexchanging="GridView1_PageIndexChanging"
                                                                    onrowdatabound="GridView1_RowDataBound">
<RowStyle CssClass="dgrNoSelectItem"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="STT"><ItemTemplate>
                                    <asp:Label ID="STT" runat="server" Text='<%# Eval("STT") %>'></asp:Label>
                                
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:ButtonField CommandName="Kham" Text="Kh&#225;m">
<ItemStyle HorizontalAlign="Center" Font-Bold="True" ForeColor="Blue"></ItemStyle>
</asp:ButtonField>
<asp:TemplateField HeaderText="M&#227; bệnh nh&#226;n"><ItemTemplate>
                                    <asp:Label ID="mabenhnhan" runat="server" Width="120px" Text='<%# Bind("mabenhnhan") %>'>' ></asp:Label>
                                
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="120px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="T&#234;n bệnh nh&#226;n"><ItemTemplate>
                                    <asp:Label ID="TENBENHNHAN" runat="server" Text='<%# bind("TENBENHNHAN") %>'>'></asp:Label>
                                
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
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
<asp:TemplateField HeaderText="Ngày đk/chuyển/trảKQ"><ItemTemplate>
                                    <asp:Label ID="NGAYDANGKY" runat="server" Text='<%# string.Format("{0:dd/MM/yyyy HH:mm:ss}", Eval("NGAYDANGKY")) %>'></asp:Label>
                                
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Loại ưu ti&#234;n"><ItemTemplate>
                                    <asp:Label ID="LoaiUT" runat="server" Text='<%# Eval(" LoaiUT") %>'></asp:Label>
                                
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Số.TTĐK"><ItemTemplate>
<asp:Label id="SOTT" runat="server" Text='<%#Eval("SOTT") %>' Width="30px" Height="20" Visible="true" __designer:wfdid="w7"></asp:Label> <asp:Label id="IDBENHNHAN" runat="server" Text='<%#Eval("IDBENHNHAN") %>' Width="120px" Height="30" Visible="false" __designer:wfdid="w8"></asp:Label> <asp:Label id="IDKHAMBENH" runat="server" Text='<%#Eval("IDKHAMBENH") %>' Width="120px" Height="30" Visible="false" __designer:wfdid="w9"></asp:Label> <asp:Label id="lbType" runat="server" Text='<%# Eval("Type") %>' Visible="false" __designer:wfdid="w10"></asp:Label>
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="T.Th&#225;i"><ItemTemplate>
<asp:Label id="lbTrThai" runat="server" Text='<%# Eval("TypeName") %>' __designer:wfdid="w6"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Trả KQ "><ItemTemplate>
                                    <asp:Label ID="THOIGIANTRAKQ" runat="server" Text='<%# string.Format("{0:HH:mm:ss}", Eval("THOIGIANTRAKQ")) %>'></asp:Label>
                                
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>

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
