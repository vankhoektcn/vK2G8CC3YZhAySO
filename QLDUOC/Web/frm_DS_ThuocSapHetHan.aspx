<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_DS_ThuocSapHetHan.aspx.cs" Inherits="frm_DS_ThuocSapHetHan" %>
<!--#include file ="header.htm"-->
<%@ Register Src="uscMenu.ascx" TagName="uscMenu" TagPrefix="uc1" %>
<form id="Form1" runat = "server">
<table border="0" cellpadding="1" cellspacing="1" width="100%"  id = "user">
    <tr>
        <td width = "100%" height = "12px" bgcolor = "#EAEBE6">
            <uc1:uscMenu ID="UscMenu1" runat="server" />
        </td>
    </tr> 
    
    <tr>
        <td class = "title" style="padding-bottom:10px; width: 945px;"><p class="title">
            &nbsp;<strong>DANH SÁCH THUỐC SẮP HẾT HẠN SỬ DỤNG</strong></p></td>
    </tr>
    
    <tr>
        <td align = "left" style="padding-bottom:10px; width: 945px;">
            <table width = "100%" cellpadding="0" cellspacing = "0" border = "0">
                <tr>
                    <td align = "right" style="width: 56%; height: 25px;">
                    <span class = "ptext">Kho :
                        <asp:dropdownlist id="ddlkho" runat="server" width="158px"></asp:dropdownlist>
                        &nbsp; &nbsp;&nbsp; Số ngày cảnh báo: </span>
                    </td>  
                    <td align = "left" style="width: 9%; height: 25px;">
                        <span class = "ptext">&nbsp;<asp:textbox id="txtsongay" runat="server" width="49px">0</asp:textbox>
                            </span>
                    </td> 
                    <td width = "100%" align = "left" style="height: 25px">
                        &nbsp; &nbsp;
                        <input type = "button" value = "Xem" style="width: 88px" runat = "server" id = "btnXem" onserverclick="btnXem_ServerClick"/>
                        &nbsp; &nbsp; *. Lưu ý : Chỉ lấy danh sách còn tồn kho
                    </td>                    
                </tr>
            </table>            
        </td>
    </tr>
    
    <TR>
		<TD style="width: 100%">
		    <TABLE cellPadding="0" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="center" width="100%" height="20">
						<asp:datagrid id="dgr" tabIndex="6" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
								DataKeyField="idchitietphieunhapkho" BorderWidth="1px" BorderColor="Silver" OnItemDataBound="dgr_ItemDataBound" CellPadding="2" OnEditCommand="Edit" OnDeleteCommand = "DelPhieuNhap"
								OnPageIndexChanged="PageIndexStyleChanged" PageSize="50">
<PagerStyle Mode="NumericPages" ForeColor="DarkBlue" Font-Size="X-Small" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>

<AlternatingItemStyle CssClass="dgrSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></AlternatingItemStyle>

<ItemStyle CssClass="dgrNoSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle CssClass="dgrHeader" HorizontalAlign="Center"></HeaderStyle>
<Columns>
<asp:BoundColumn DataField="tenthuoc" HeaderText="T&#234;n thuốc">
<HeaderStyle Width="20%"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="congthuc" HeaderText="C&#244;ng thức">
<HeaderStyle Width="20%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="tendvt" HeaderText="ĐVT">
<HeaderStyle Width="5%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="ngaynhap" HeaderText="Ng&#224;y nhập">
<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="losanxuat" HeaderText="L&#244; SX">
<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="ngayhethan" HeaderText="Ngày HH">
<HeaderStyle Width="5%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="soluongton" HeaderText="Số lượng tồn">
<HeaderStyle Width="5%"></HeaderStyle>
</asp:BoundColumn>

</Columns>
</asp:datagrid>
						
					</TD>
				</TR>
			</TABLE>		
           						
		</TD>		
	</TR>
	<tr>
	    <td style ="width: 100%;">
	        <div id  = "infospace" runat = "server"></div>
	    </td>
	</tr>
	
</table>
</form>
<!--#include file ="footer.htm"-->

