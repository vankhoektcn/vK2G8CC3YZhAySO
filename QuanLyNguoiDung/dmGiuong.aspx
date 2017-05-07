<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dmGiuong.aspx.cs" Inherits="QuanLyNguoiDung_dmGiuong" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--#include file ="header.htm"-->
 <link type="text/css" rel="stylesheet" href="../css/style.css" />
  <link type="text/css" rel="stylesheet" href="../css/jquery.autocomplete.css" />
 <script type="text/javascript" src="../js/jquery.autocomplete.js"></script>
  <script type="text/javascript">
         function timPhong() {
         $("#txtPhongKham").unautocomplete().autocomplete("ajax.aspx?do=timPhong&ID="+$("#txtPhongKham").val(),{
	    scroll: true
	    },{formatItem: function(data) {
                return data[0];
            },width:900,scroll:true})
       .result(function(event,data){
           $("#txtPhongKham").val(data[1]); 
           $("#txtIdPhong").val(data[2]);        
	    });
}
  </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Danh mục giường</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
          <div style="background-color:#D4D0C8;height:10px;width:100%" >
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </div>
             <div class="khung" runat="server" id="divMain">
                   <div style="width:100%;background-color: #4D67A2;text-align:center" class="title">
                     <p class="title" style ="color:#FFFFFF">DANH MỤC GIƯỜNG BỆNH</p>
                   </div>
                <div>
                    <span id="headerntt">I.Thông tin giường bệnh</span>
                </div>
                <div style="padding-left:2%">
                    <table>
                        <tr>
                            <td style="width: 100px">
                                Mã giường:</td>
                            <td style="width: 200px">
                            <input type="text" id="txtMaGiuong" runat="server"/>
                            <input type="hidden" runat="server" id="txtidGiuong" />
                            </td>
                            <td style="width: 100px">
                                Giá BH:</td>
                            <td style="width: 100px">
                             <input type="text" id="txtGiaBH" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                Loại Giường:</td>
                            <td style="width: 100px">
                             <input type="text" id="txtLoaiGiuong" runat="server" />
                            </td>
                            <td style="width: 100px">
                                Giá DV:</td>
                            <td style="width: 100px">
                              <input type="text" id="txtGiaDV" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                Đơn Vị Tính:</td>
                            <td style="width: 100px">
                            <input type="text" id="txtDVT" runat="server" />
                            </td>
                            <td style="width: 100px">
                                Giá Ngoài Giờ:</td>
                            <td style="width: 100px">
                            <input type="text" id="txtGiaNgoaiGio" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                Phòng Khám:</td>
                            <td style="width: 100px">
                            <input type="text" id="txtPhongKham" runat="server" onfocus="timPhong();" />
                             <input type="hidden" id="txtIdPhong" runat="server" />
                            </td>
                            <td style="width: 100px">
                                Đã đặt:</td>
                            <td style="width: 100px">
                            <asp:CheckBox ID="ckbDaDat" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>   
                
               <div id="button">
                   <asp:ImageButton ID="btnLuu" runat="server" ImageUrl="~/images/nut_add.gif" OnClick="btnLuu_Click" />
                   <asp:ImageButton ID="btnSua" runat="server" ImageUrl="~/images/sua.gif" OnClick="btnSua_Click" />
                   <asp:ImageButton ID="btnMoi" runat="server" ImageUrl="~/images/MOI.gif" OnClick="btnMoi_Click" />
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/tim.png" OnClick="ImageButton1_Click"  />
               </div>  
            </div>
            <div>
                <span style="font-style:italic">II.Danh sách giường bệnh</span>
            </div>
            <div id="danhsach">
            <asp:DataGrid id="dgrDanhMucGiuong" tabIndex="12" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
	        DataKeyField="giuongid" BorderWidth="1px" BorderColor="#CCCCCC" OnItemDataBound="dgr_ItemDataBound" CellPadding="3" AllowPaging="True"
	        OnPageIndexChanged="PageIndexStyleChanged" PageSize="30" BackColor="White" BorderStyle="None" OnItemCommand="dgr_ItemCommand">
	        <Columns>
                <asp:TemplateColumn HeaderText="Sửa"><ItemTemplate>
			    <asp:LinkButton id="lbtnEdit" CommandName="Edit" runat="server" CssClass="alink3">Sửa</asp:LinkButton>											    
                </ItemTemplate>
                <HeaderStyle Width="4%"></HeaderStyle>
                </asp:TemplateColumn>
                 <asp:TemplateColumn HeaderText="X&#243;a"><ItemTemplate>
			    <asp:LinkButton id="lbtnDel" CommandName="Del" runat="server" CssClass="alink3">Xóa</asp:LinkButton>											    
                </ItemTemplate>
                <HeaderStyle Width="4%"></HeaderStyle>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="GiuongCode" HeaderText="M&#227; Giường" SortExpression="GiuongCode">
                <HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
                <ItemStyle Wrap="True"></ItemStyle>
                </asp:BoundColumn>
                
                 <asp:BoundColumn DataField="LoaiGiuong" HeaderText="Loại Giường" SortExpression="LoaiGiuong">
                <HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
                <ItemStyle Wrap="True"></ItemStyle>
                </asp:BoundColumn>
                
                <asp:BoundColumn DataField="DVT" HeaderText="Đơn Vị T&#237;nh" SortExpression="DVT">
                <HeaderStyle Wrap="False" Width="8%"></HeaderStyle>
                <ItemStyle Wrap="True"></ItemStyle>
                </asp:BoundColumn>
                
                <asp:BoundColumn DataField="GiaDV" HeaderText="Gi&#225; DV" DataFormatString="{0:0,00}" SortExpression="GiaDv">
                <HeaderStyle Wrap="False" Width="8%"></HeaderStyle>
                <ItemStyle Wrap="True"></ItemStyle>
                </asp:BoundColumn>
                
                 <asp:BoundColumn DataField="GiaBH" HeaderText="Gi&#225; BH" DataFormatString="{0:0,00}" SortExpression="GiaBH">
                <HeaderStyle Wrap="False" Width="8%"></HeaderStyle>
                <ItemStyle Wrap="True"></ItemStyle>
                </asp:BoundColumn>
                
                 <asp:BoundColumn DataField="GiaNgoaiGio" HeaderText="Gi&#225; ngo&#224;i giờ" DataFormatString="{0:0,00}" SortExpression="GiaNgoaiGio">
                <HeaderStyle Wrap="False" Width="8%"></HeaderStyle>
                <ItemStyle Wrap="True"></ItemStyle>
                </asp:BoundColumn>
                
                    <asp:BoundColumn DataField="TenPhong" HeaderText="Ph&#242;ng" SortExpression="TenPhong">
                <HeaderStyle Wrap="False" Width="15%"></HeaderStyle>
                <ItemStyle Wrap="True"></ItemStyle>
                </asp:BoundColumn>
                
                <asp:BoundColumn DataField="TrangThai" HeaderText="Trạng th&#225;i" SortExpression="TrangThai">
                <HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
                <ItemStyle Wrap="True"></ItemStyle>
                </asp:BoundColumn>
            </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                <ItemStyle ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" HorizontalAlign="Center" Font-Underline="true" Font-Bold="True" ForeColor="White" />
            </asp:DataGrid>
            </div>
    </div>
    </form>
</body>
</html>
<!--#include file ="footer.htm"-->