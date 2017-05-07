<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhuCapHienVat.aspx.cs" Inherits="PhuCapHienVat" %>

<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->

<script type="text/javascript" src="js/jsNhanSu.js"></script>

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
        <div style="background-color: #FBF8F1; padding-left: 20px; text-align: left">
            <uc1:uscmenu ID="Uscmenu1" runat="server" />
        </div>
        <br />
        <div style="background-color: #4D67A2; height: auto; text-align: left; width: 100%">
            <span style="color: #ffffff; font-size: 14pt;"><strong>
                <div style="margin-top: 5px">
                    Phụ cấp hiện vật</div>
            </strong></span>
        </div>
        <br />
        <div style="text-align: center; width: 900px">
            <table rules="groups" style="width: 700px" bgcolor="#99b0cb">
                <%--<tr>
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
                </tr>--%>
                <tbody>
                    <tr>
                        <td style="height: 10px" colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px; width: 13%; height: 41px" valign="top" align="left">
                            <p class="ptext">
                                Phòng&nbsp;
                            </p>
                        </td>
                        <td style="padding-right: 0px; width: 25%; height: 41px" valign="top" align="left">
                            <p class="ptext">
                                <asp:dropdownlist id="ddlPhongBan" tabindex="1" runat="server" cssclass="input" width="100%"
                                    onselectedindexchanged="ddlPhongBan_SelectedIndexChanged" autopostback="True">
                                                                                 </asp:dropdownlist>
                                &nbsp;
                            </p>
                        </td>
                        <td style="padding-right: 2px; width: 12%; height: 41px" valign="top" align="right">
                            <p class="ptext">
                                Nhân viên :
                            </p>
                        </td>
                        <td style="padding-right: 0px; width: 40%; height: 41px" valign="top" align="left">
                            <p class="ptext">
                                <asp:dropdownlist id="ddlNhanVien" tabindex="1" runat="server" cssclass="input" width="63%">
                                                                                 </asp:dropdownlist>
                                &nbsp;&nbsp;&nbsp;
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px; width: 13%; height: 41px" valign="top" align="left">
                            <p class="ptext">
                                Tháng&nbsp;:</p>
                        </td>
                        <td style="padding-right: 0px; width: 25%; height: 41px" valign="top" align="left">
                            <p class="ptext">
                                <asp:dropdownlist id="ddlThang" tabindex="2" runat="server" width="23%"><asp:ListItem Value="1">1</asp:ListItem>
<asp:ListItem Value="2">2</asp:ListItem>
<asp:ListItem Value="3">3</asp:ListItem>
<asp:ListItem Value="4">4</asp:ListItem>
<asp:ListItem Value="5">5</asp:ListItem>
<asp:ListItem Value="6">6</asp:ListItem>
<asp:ListItem Value="7">7</asp:ListItem>
<asp:ListItem Value="8">8</asp:ListItem>
<asp:ListItem Value="9">9</asp:ListItem>
<asp:ListItem Value="10">10</asp:ListItem>
<asp:ListItem Value="11">11</asp:ListItem>
<asp:ListItem Value="12">12</asp:ListItem>
</asp:dropdownlist>
                                &nbsp;&nbsp;&nbsp;&nbsp;Năm&nbsp;
                                <asp:dropdownlist id="ddlNam" tabindex="3" runat="server" width="35%"></asp:dropdownlist>
                            </p>
                        </td>
                        <td style="padding-right: 2px; width: 12%; height: 41px" valign="top" align="right">
                            <p class="ptext">
                            </p>
                        </td>
                        <td style="padding-right: 0px; width: 40%; height: 41px" valign="top" align="left">
                            <p class="ptext">
                                &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:button id="btnGetDanhSach" onclick="btnGetDanhSach_Click" runat="server" cssclass="input"
                                    width="102px" text="Lấy danh sách" TabIndex="4"></asp:button>
                                &nbsp;
                            </p>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br />
        <div style="background-color: #4D67A2; height: auto; text-align: left; width: 100%"">
        <%--//////////////
        //////////////
        ///////////// --%>  
        <div style="background-color: #003399; height: auto; text-align: left; width: 100%">
            <span style="color: #ffffff; font-size: 14pt;"><strong>
                <div style="margin-top: 5px">
                    DANH SÁCH TIỀN PHỤ CẤP HIỆN VẬT&nbsp;&nbsp; <asp:Label id="lbThangNam" runat="server" Text=""></asp:Label></div>
            </strong></span>
        </div>
         <asp:DataGrid id="dgr" tabIndex=5 runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False" DataKeyField="idnhanvien" BorderWidth="1px" BorderColor="#3366CC" OnItemDataBound="dgr_ItemDataBound" OnEditCommand="Edit" CellPadding="4" BackColor="White" BorderStyle="None">
<FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

<SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedItemStyle>

<PagerStyle Mode="NumericPages" HorizontalAlign="Left" BackColor="#99CCCC" Font-Names="Arial" Font-Size="Small" ForeColor="#003399"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" BackColor="White" CssClass="dgrNoSelectItem" ForeColor="#003399"></ItemStyle>
<Columns>
<asp:BoundColumn DataField="STT" HeaderText="STT">
<HeaderStyle Wrap="False" Width="2%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="idnhanvien" HeaderText="idnhanvien" Visible="False"></asp:BoundColumn>
<asp:BoundColumn DataField="tennhanvien" HeaderText="T&#234;n Nh&#226;n Vi&#234;n">
<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenphongban" HeaderText="Ph&#242;ng">
<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="chucvu" HeaderText="Chức vụ">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SoNgayLamViec"  HeaderText="Số ngày làm việc">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="giatrimuc" HeaderText="Mức phụ cấp">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TienPhucap" DataFormatString="{0:0,000}" HeaderText="Tiền phụ cấp">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="" visible="false"><ItemTemplate>
        <asp:TextBox ID="txtIdPhuCap" runat="server" Text='<%#Bind("idphucap") %>' Visible="false" BorderWidth="0"></asp:TextBox>
</ItemTemplate>
<HeaderStyle Width="2%"></HeaderStyle>
<ItemStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="" visible="false"><ItemTemplate>
        <asp:TextBox ID="txtMucLuongCoBan" runat="server" Text='<%#Bind("MucLuongCoBan") %>' Visible="false" BorderWidth="0"></asp:TextBox>
</ItemTemplate>
<HeaderStyle Width="2%"></HeaderStyle>
<ItemStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="" visible="false"><ItemTemplate>
        <asp:TextBox ID="txtSoNgayLamViec" runat="server" Text='<%#Bind("SoNgayLamViec") %>' Visible="false" BorderWidth="0"></asp:TextBox>
</ItemTemplate>
<HeaderStyle Width="2%"></HeaderStyle>
<ItemStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="" visible="false"><ItemTemplate>
        <asp:TextBox ID="txtGiaTriMuc" runat="server" Text='<%#Bind("giatrimuc") %>' Visible="false" BorderWidth="0"></asp:TextBox>
</ItemTemplate>
<HeaderStyle Width="2%"></HeaderStyle>
<ItemStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="" visible="false"><ItemTemplate>
        <asp:TextBox ID="txtTienPhucap" runat="server" Text='<%#Bind("TienPhucap") %>' Visible="false" BorderWidth="0"></asp:TextBox>
</ItemTemplate>
<HeaderStyle Width="2%"></HeaderStyle>
<ItemStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="" visible="false"><ItemTemplate>
        <asp:TextBox ID="txtIdNhanVien" runat="server" Text='<%#Bind("idnhanvien") %>' Visible="false" BorderWidth="0"></asp:TextBox>
</ItemTemplate>
<HeaderStyle Width="2%"></HeaderStyle>
<ItemStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:TemplateColumn>

</Columns>

<HeaderStyle HorizontalAlign="Center" BackColor="#FFE0C0" CssClass="dgrHeader" Font-Bold="True" ForeColor="Blue"></HeaderStyle>
</asp:DataGrid> 
<br />
<asp:Button id="btnExcel" runat="server" visible="true" Text="Xuất Excel" OnClick="btnExcel_Click" TabIndex="6"></asp:Button> 
            <asp:button id="btnLuuPhuCap" runat="server" onclick="btnLuuPhuCap_Click" text="Lưu phụ cấp"
                width="92px" />
            <%--/////////////
        /////////////
        ////////////--%></div>
    </div>
        <div style="text-align: center; width: 900px">
            <asp:panel id="pnl1" runat="server" visible="false" width="100%">&nbsp; <DIV style="WIDTH: 100%; TEXT-ALIGN: center">&nbsp;<asp:Button id="btnMoi" onclick="btnMoi_Click" runat="server" Width="82px" __designer:wfdid="w3" Text="Mới"></asp:Button> </DIV></asp:panel>
            <input id="txtIdNhanVienHd" runat="server" type="hidden" />
            <INPUT id="txtThangHidden" type=hidden name="txtThangHidden" runat="server" /> 
<INPUT id="txtNamHidden" type=hidden name="txtNamHidden" runat="server" />
        </div>
        <br />
</form>
<!--#include file ="footer.htm"-->
