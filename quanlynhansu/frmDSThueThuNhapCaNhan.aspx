<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmDSThueThuNhapCaNhan.aspx.cs" Inherits="quanlynhansu_frmDSThueThuNhapCaNhan" %>

<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->

    <form id="form1" runat="server">
    <div>
<table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: White">
    <tr>
        <td align="left" colspan="4" style="background-color: #FBF8F1; height: 19px;width:100%">
            <uc1:uscmenu ID="Uscmenu1" runat="server" />
        </td>
    </tr>
     <tr>
            <td  align="left" style="background-color: #D4D0C8;width:100%">
                &nbsp;</td>
        </tr>
        <tr>
        <td colspan="4" align="center" style="width: 100%; padding-left: 20px; background-color: #FBF8F1;
        height: 19px; background-image: url(../images/menu.jpg); color:White; font-weight: bold">
        DANH SÁCH NHÂN VIÊN NỘP THUẾ THU NHẬP CÁ NHÂN
         </td>
        </tr>
        
        <tr>
            <td  align="left" style="width:100%">
                &nbsp;</td>
        </tr>
          <tr style="padding-left:50px" align="left">
            <td>
                <table width="600px" rules="none" style="padding-left:100px; border-color: Blue; border-style: double;border: 4px">
                    <tr>
                        <td align="left" style="width:500px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Tên NV&nbsp; :&nbsp;<asp:TextBox runat="server" ID="txtTenNV"></asp:TextBox>
                        </td>
                         <td align="left" style="width:500px">
                            Mã NV&nbsp; :&nbsp;<asp:TextBox runat="server" ID="txtMaNV"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width:500px">
                            Loại hợp đồng&nbsp; :&nbsp;<asp:DropDownList runat="server" ID="ddlLoaiHD" Width="150px"></asp:DropDownList>
                        </td>
                         <td align="left" style="width:600px">&nbsp;&nbsp;
                            Tháng&nbsp; :&nbsp;<asp:DropDownList runat="server" ID="ddlThang" Width="50px">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
                            Năm&nbsp; :&nbsp;<asp:DropDownList runat="server" ID="ddlNam" Width="60px">
                            <asp:ListItem>2010</asp:ListItem>
                            <asp:ListItem>2011</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server" ID="btnTim" Text="Tìm" Width="80px" OnClick="btnTim_Click" />
                        </td>
                    </tr>
                </table>
            </td>
          </tr>
          <tr>
            <td align="left" style="width:100%">
            &nbsp;
            </td>
          </tr>
         <tr>
        <td colspan="4" align="center" style="width: 100%; padding-left: 20px; background-color: #FBF8F1;
        height: 19px; background-image: url(../images/menu.jpg); color:White; font-weight: bold">
        DANH SÁCH NHÂN VIÊN NỘP THUẾ THU NHẬP CÁ NHÂN
         </td>
        </tr>
        <tr>
            <td valign="top" align="center" colspan="2" style="width:100%;height:20%">
            <asp:DataGrid  runat="server" ID="dgrList"  width="1200px" allowsorting="True"
              autogeneratecolumns="False" datakeyfield="idnhanvien" borderwidth="1px" bordercolor="#999999"
              cellpadding="3" allowpaging="True" pagesize="30" BackColor="White" BorderStyle="None" GridLines="Vertical">
                
                <Columns>
                    <asp:BoundColumn HeaderText="STT" DataField="STT">
                        <HeaderStyle Wrap="False" Width="50px" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundColumn>
                    
                    <asp:BoundColumn HeaderText="M&#227; NV" DataField="MaNhanVien">
                        <HeaderStyle Wrap="False" Width="100px" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundColumn>
                    
                    <asp:BoundColumn HeaderText="T&#234;n NV" DataField="TenNhanVien">
                        <HeaderStyle Wrap="False" Width="150px" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundColumn>
                    
                    <asp:BoundColumn HeaderText="Giới t&#237;nh" DataField="GioiTinh">
                        <HeaderStyle Wrap="False" Width="50px" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundColumn>
                    
                    <asp:BoundColumn HeaderText="Ng&#224;y Sinh" DataFormatString="{0:dd/MM/yyyy}" DataField="NgaySinh">
                        <HeaderStyle Wrap="False" Width="100px" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundColumn>
                   
                   <asp:BoundColumn HeaderText="Địa Chỉ" DataField="DiaChiThuongTru">
                        <HeaderStyle Wrap="False" Width="200px" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundColumn>
                    
                    <asp:BoundColumn HeaderText="Chức vụ" DataField="TenChucVu">
                        <HeaderStyle Wrap="False" Width="100px" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundColumn>
                    
                    <asp:BoundColumn HeaderText="T&#234;n ph&#242;ng ban" DataField="TenPhongBan">
                        <HeaderStyle Wrap="False" Width="100px" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundColumn>
                    
                    <asp:BoundColumn HeaderText="Lương cơ bản" DataField="LuongCanBan">
                        <HeaderStyle Wrap="False" Width="100px" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundColumn>
                    
                    <asp:BoundColumn HeaderText="Thuế thu nhập" DataField="ThueThuNhap">
                        <HeaderStyle Wrap="False" Width="100px" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundColumn>
                    
                </Columns>                                       
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle BackColor="#DCDCDC" />
                <ItemStyle BackColor="#EEEEEE" ForeColor="Black" />
                <HeaderStyle BackColor="blue" Font-Bold="True" ForeColor="White" />
            </asp:DataGrid>
            </td>
        </tr>
</table>
</div>
    </form>

<!--#include file = "footer.htm" -->
