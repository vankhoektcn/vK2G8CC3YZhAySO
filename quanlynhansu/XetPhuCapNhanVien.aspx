<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XetPhuCapNhanVien.aspx.cs"
    Inherits="XetPhuCapNhanVien" %>

<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->

<script type="text/javascript">
 function CheckAll(Ctl, GridName, BeginIndex, EndIndexExt, GridCtl)
{
	var value = document.getElementById(Ctl).checked;
	
	var i;
	count = document.getElementById(GridName).rows.length;	
	if (count >1 )
	{
	
		for (i=BeginIndex; i<document.getElementById(GridName).rows.length + EndIndexExt; i++)
		{
		
		    if(i<=9)
		    {
		     
		        if(document.frmBSPK(GridName + "_ctl0" + i + "_" + GridCtl).disabled==false)
			    {
			    
				    document.frmBSPK(GridName + "_ctl0" + i + "_" + GridCtl).checked = value;	
			    }   
		    }
		    else
		    {
		        if(document.frmBSPK(GridName + "_ctl" + i + "_" + GridCtl).disabled==false)
			    {
				    document.frmBSPK(GridName + "_ctl" + i + "_" + GridCtl).checked = value;	
			    }    
		    }
		}
	}
}

</script>

<form id="frmBSPK" method="post" runat="server">
    <div style="background-color: #C0C0C0">
        <div style="background-color: #FBF8F1;padding-left:20px;text-align:left">
            <uc1:uscmenu ID="Uscmenu1" runat="server" />
        </div>
        <br />
        <div style="background-color: #4D67A2; height: auto; text-align: left; width: 100%">
            <span style="color: #ffffff; font-size: 14pt;"><strong>
                <div style="margin-top: 5px">
                    Xét phụ cấp Nhân Viên</div>
            </strong></span>
        </div>
        <br />
        <div style="text-align: center; width: 900px">
            <table rules="groups" style="width: 700px" bgcolor="#99b0cb">
                <tr>
                    <td style="width: 100%;" align="center">
                    <br />
                        <asp:label id="lblPhong" runat="server" text="Chọn phòng ban : "></asp:label>
                        <asp:dropdownlist id="ddlPhongBan" tabIndex=1 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPhongBan_SelectedIndexChanged" width="212px" CssClass="input"></asp:dropdownlist>
                        &nbsp;
                        <asp:label id="lblBSi" runat="server" text="Chọn Nhân Viên : "></asp:label>
                        <asp:dropdownlist id="ddlNhanVien" runat="server" width="222px" autopostback="True"
                            onselectedindexchanged="ddlNhanVien_SelectedIndexChanged"></asp:dropdownlist>
                        &nbsp;
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div style="text-align: center; width: 900px">
            <asp:panel id="pnl1" runat="server" visible="false" width="100%"><asp:datagrid id="dtgListPK" runat="server" width="800px" align="center" ForeColor="#333333" GridLines="None" CellPadding="4" AutoGenerateColumns="False">
<FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></FooterStyle>

<EditItemStyle HorizontalAlign="Left"></EditItemStyle>

<SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy"></SelectedItemStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#FFCC66" ForeColor="#333333"></PagerStyle>

<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" BackColor="#FFFBD6" ForeColor="#333333"></ItemStyle>
<Columns>
<asp:TemplateColumn HeaderText="Stt"><ItemTemplate>
   <asp:Label ID="lblStt" runat="server" Text='<%#Eval("STT") %>' Width="20px" Height="30"></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="T&#234;n phụ cấp"><ItemTemplate>
   <asp:Label ID="lblMaPK" runat="server" Text='<%#Eval("TenPhuCap") %>' Width="200px" Height="30"></asp:Label>
   <asp:Label ID="lblIdPhuCap" Visible="false" runat="server" Text='<%#Eval("idPhuCap") %>' Width="10px" Height="30"></asp:Label>
   
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Mức(nếu c&#243;)"><ItemTemplate>
   <asp:TextBox id="txtGiaTriMuc" Text='<%#Eval("GiaTriMuc") %>' onblur="isNumber(this);" Width="100px" Height="15" runat="server"></asp:TextBox>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn><HeaderTemplate>
Chọn?
</HeaderTemplate>
<ItemTemplate>
                            <asp:CheckBox Checked='<%#Eval("IsCheck") %>' ID="chkSelect" runat="server" Width="30px" Height="30" />
                            
</ItemTemplate>
</asp:TemplateColumn>
</Columns>

<HeaderStyle HorizontalAlign="Left" BackColor="#FFE0C0" BorderColor="White" Font-Bold="True" ForeColor="Blue"></HeaderStyle>
</asp:datagrid> <DIV style="WIDTH: 100%; TEXT-ALIGN: center"><asp:button id="Button1" onclick="Button1_Click" runat="server" text="Lưu" width="92px"></asp:button> <asp:Button id="btnMoi" onclick="btnMoi_Click" runat="server" Width="82px" __designer:wfdid="w3" Text="Mới"></asp:Button> </DIV></asp:panel>
<input id="txtIdNhanVienHd" runat="server" type="hidden" />
        </div>
        <br />
    </div>
</form>
<!--#include file ="footer.htm"-->
