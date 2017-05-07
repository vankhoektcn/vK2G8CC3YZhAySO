<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_ThuVienPhiTH.aspx.cs"
    Inherits="frm_ThuVienPhiTH" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/VienPhi_TH/uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<%@ Register Src="~/MaVach/txtMaVach.ascx" TagName="txtMaVach" TagPrefix="ucMV" %>
<!--#include file ="header.htm"-->

<script type="text/javascript">
	     var dp_cal;      
       window.onload = function () {
	            dp_cal  = new Epoch('epoch_popup','popup',document.getElementById('txtNgayBD'));
	            dp_cal1  = new Epoch('epoch_popup','popup',document.getElementById('txtNgayKT'));

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

<style type="text/css">
td,table,tr,p,div,span,font,input,select,textarea
{
 font-family:Arial, Tahoma, Verdana;
 font-size:13px;
}
a
{
	text-decoration:none;
}
a:hover
{
  color:#ff0000;
}
 #btnLayDS,#Button1,.button{
    background:#3199C4 url('../images/ui-bg_gloss-wave_75_2191c0_500x100.png') repeat-x center; height:25px;
    cursor:pointer;
    font-size:12px;
    border:1px solid #fff!important;
    color:#FFFFFF;
    padding:2px 5px 2px 5px;
 }
 
</style>
<form id="Form1" method="post" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: #C0C0C0">
        <tr>
            <td>
                <asp:placeholder runat="server" id="PlaceHolder1"></asp:placeholder>
            </td>
        </tr>
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="100%" align="center" style="background-color: #D4D0C8">
                <table cellspacing="1" cellpadding="1" width="98%" border="0" class="khung">
                    <tr>
                        <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px; height: 332px;">
                            <table id="user" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td class="button" colspan="2" align="center" style="background-color: #4D67A2">
                                        <p class="title" style="color: #FFFFFF; margin: 0">
                                            <strong>THU PHÍ </strong>
                                        </p>
                                    </td>
                                </tr>
                                <tr style="color: #000000">
                                    <td width="100%">
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="center" width="100%" style="height: 150px">
                                                    <table>
                                                        <tr>
                                                            <td style="width: 100px; height: 27px;">
                                                                &nbsp;Ngày :</td>
                                                            <td style="width: 128px; height: 27px;">
                                                                <asp:textbox id="txtNgayBD" runat="server" width="75px" onblur="TestDatePhieu(this)"></asp:textbox>
                                                                <input id="Button1" style="width: 26px" type="button" value="..." onclick="dp_cal.toggle()" /></td>
                                                            <td style="width: 100px; height: 27px;">
                                                                &nbsp;Mã BN</td>
                                                            <td style="width: 100px; height: 27px;">
                                                                <asp:textbox id="txtMaBenhNhan" runat="server" width="128px" tabindex="1" readonly="False"></asp:textbox>
                                                            </td>
                                                            <td style="width: 100px; height: 27px;">
                                                                Tên BN :</td>
                                                            <td style="width: 89px; height: 27px;">
                                                                <asp:textbox id="txtTenBenhNhan" runat="server" width="288px" tabindex="2"></asp:textbox>
                                                            </td>
                                                            <td style="width: 100px; height: 27px;">
                                                                <asp:button id="btnLayDS" runat="server" text="Lấy danh sách" width="112px" onclick="btnLayDS_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:datagrid id="dgr" runat="server" allowsorting="True" autogeneratecolumns="False"
                                                        bordercolor="Silver" borderwidth="1px" cellpadding="2" tabindex="12" width="100%"
                                                        onitemcommand="dgr_ItemCommand" datakeyfield="Id">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>
<asp:EditCommandColumn CancelText="Cancel" EditText="Thu tiền " UpdateText="Update" HeaderText="Thu tiền ">
<HeaderStyle HorizontalAlign="Center" Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:EditCommandColumn>
<asp:TemplateColumn HeaderText="maphieucls" Visible="False"><ItemTemplate>
&nbsp; <asp:TextBox id="txtIMaPhieuCLS" runat="server" Width="69px" Text='<%# Eval("MAPHIEUCLS") %>' Visible="False" Enabled="False"></asp:TextBox> <asp:TextBox id="txtILoaiThu" runat="server" Width="47px" Text='<%# Eval("LoaiThu") %>' Visible="False" Enabled="False"></asp:TextBox>
<asp:TextBox id="txtILoaiThu2" runat="server" Width="47px" Text='<%# Eval("LoaiThu2") %>' Visible="False" Enabled="False"></asp:TextBox>
<asp:TextBox id="txtIdChiTietDangKyKham" runat="server" Width="47px" Text='<%# Eval("IdChiTietDangKyKham") %>' Visible="False" Enabled="False"></asp:TextBox>
<asp:TextBox id="txtIdBenhNhan" runat="server" Width="47px" Text='<%# Eval("IdBenhNhan") %>' Visible="False" Enabled="False"></asp:TextBox>
<asp:TextBox id="txtIdBenhNhanBHDongTien" runat="server" Width="47px" Text='<%# Eval("IdBenhNhanBHDongTien") %>' Visible="False" Enabled="False"></asp:TextBox>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="STT" HeaderText="STT">
<HeaderStyle Wrap="False" Width="2%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="Mã bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="8%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="15%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
</asp:BoundColumn>

<%--<asp:BoundColumn DataField="diachi" HeaderText="Địa chỉ">
<HeaderStyle Wrap="False" Width="25%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
</asp:BoundColumn>--%>


<asp:BoundColumn DataField="gioitinh" HeaderText="G.T">
<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
<HeaderStyle HorizontalAlign="Center" Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Width="5%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NgaySinh" HeaderText="Ngày sinh">
<HeaderStyle Width="7%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NOIDUNGTHU" HeaderText="Nội dung">
<HeaderStyle Width="20%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TONGTIEN" DataFormatString="{0:00,00}" HeaderText="Số tiền">
<HeaderStyle Width="7%"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TONGTIENBHYT" DataFormatString="{0:00,00}" HeaderText="Cộng BHYT">
<HeaderStyle Width="7%"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="BHTRA" DataFormatString="{0:00,00}" HeaderText="BH.Trả">
<HeaderStyle Width="7%"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="BNPHAITRA" DataFormatString="{0:00,00}" HeaderText="BN.Trả">
<HeaderStyle Width="7%"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="BNDaTraChenhLechBHYT" DataFormatString="{0:00,00}" HeaderText="Đ&#227; trả">
<HeaderStyle Width="7%"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="LoaiBN" HeaderText="BH?">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>


<asp:BoundColumn DataField="Khoa" HeaderText="Khoa">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>


<asp:BoundColumn DataField="HuongDieuTri" HeaderText="Trạng thái" Visible="False">
<HeaderStyle Wrap="False" Width="5%" ></HeaderStyle>
<ItemStyle HorizontalAlign="Center" Wrap="False" ></ItemStyle>
</asp:BoundColumn>


<asp:ButtonColumn CommandName="PrevView" Text="Xem trước" HeaderText="Xem trước">
<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:ButtonColumn>

<asp:ButtonColumn CommandName="DebitView" Text="Xem C.Nợ" HeaderText="Xem C.Nợ">
<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:ButtonColumn>

<asp:ButtonColumn CommandName="BV02View" Text="BV01-02" HeaderText="BV01-02">
<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:ButtonColumn>


<asp:ButtonColumn CommandName="DONGCHITRAVIEW" Text="Đ.C.Trả" HeaderText="Đ.C.Trả">
<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:ButtonColumn>



</Columns>

<HeaderStyle HorizontalAlign="Center" CssClass="button"></HeaderStyle>
</asp:datagrid>
                                                    &nbsp;</td>
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
                                <tr style="color: #000000">
                                    <td style="width: 100%;">
                                        <div id="infospace" runat="server">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div style="display: none; position: fixed; top: 35%; left: 35%; background-color: White;
                    z-index: 1000; padding: 10px 10px 10px 10px; border: 10px solid #4D67A2" id="divlydo"
                    runat="server">
                    &nbsp;&nbsp;
                </div>
</form>
<!--#include file ="footer.htm"-->
