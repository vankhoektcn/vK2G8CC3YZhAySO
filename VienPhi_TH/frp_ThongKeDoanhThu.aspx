<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frp_ThongKeDoanhThu.aspx.cs" Inherits="frp_ThongKeDoanhThu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--#include file ="header.htm"-->
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Báo cáo doanh thu</title>
</head>
<script language="javascript" type="text/javascript" defer="defer">
    var dp_cal;     
    var dp_cal1; 
    var noigioithieu;
	window.onload = function () 
	{
	 dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
	   
	    
	};
</script>
<body>
    <form id="form1" runat="server">
    
    <div style="width:100%;position:fixed">
    <asp:PlaceHolder ID="plcMenu" runat="server" ></asp:PlaceHolder>
    </div>
    <br />
    <div style="padding-left:20px" class="khung">
    <table style="width:98%;border:1px;" border="0" rules="none">
        <tr style="padding-left:40px">
            <td class="title" colspan="8" align = "center" style ="background-color: #4D67A2;width:100%;">
                <p class="title" style ="color:#FFFFFF">BÁO CÁO DOANH THU THEO NGƯỜI DÙNG</p>
            </td>
        </tr>
     <tr>
        <td colspan="8">
            <br />
        </td>
     </tr>
        <tr>
        <td style="width:111px;" align="right">
            Từ ngày:
        </td>
        <td style="width:128px" align="left">
            <asp:TextBox ID="txtTuNgay" Width="104px" runat="server" onclick="dp_cal1.toggle()"></asp:TextBox>
        </td>
        <td style="width: 121px">
           Đến ngày:
        </td>
        <td style="width: 110px">
            <asp:TextBox ID="txtDenNgay" runat="server" onclick="dp_cal2.toggle()" Width="119px"></asp:TextBox>
        </td>
         <td style="width:147px" align="left">
           Người dùng:
        </td>
        <td style="width:200px" align="left">
            <asp:DropDownList Width="200px" ID="ddlNguoiDung" runat="server"></asp:DropDownList>
        </td>
        <td style="width: 130px">
            <asp:Button Text="Lấy danh sách" runat="server" ID="txtLayDS" />
        </td>
        <td style="width:50px">
            <asp:Button Text="Xuất Excel" ID="btnExcel" runat="server" OnClick="btnExcel_Click1" />
        </td>
        </tr>
    </table>
    <br />
    <div >
    <table style="width:100%;background-color:white" rules="groups">
        <tr>
            <td style="width:100%" colspan="8">
             <asp:DataGrid ID="dgrDanhSach" DataKeyField="idbenhnhan" OnItemDataBound="dgrDanhSach_ItemDataBound" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
       <Columns>
         <asp:BoundColumn DataField="STT" HeaderText="STT">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
         </asp:BoundColumn>
         
         <asp:BoundColumn DataField="maphieudangky" HeaderText="Số phiếu thu">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
         </asp:BoundColumn>
         
         <asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" Width="10%" />
         </asp:BoundColumn>
         
           <asp:BoundColumn DataField="TienSo" HeaderText="Tiền sổ" DataFormatString="{0:0,00}">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" HorizontalAlign="Right" Width="10%" />
         </asp:BoundColumn>
         
         <asp:BoundColumn DataField="TienKham" HeaderText="Tiền kh&#225;m" DataFormatString="{0:0,00}">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" HorizontalAlign="Right" Width="10%" />
         </asp:BoundColumn>
         
       
         <asp:BoundColumn DataField="TienCLS" HeaderText="Tiền CLS" DataFormatString="{0:0,00}">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" HorizontalAlign="Right" Width="10%" />
         </asp:BoundColumn>
         
         <asp:BoundColumn DataField="TIENTHUOC" HeaderText="Tiền thuốc" DataFormatString="{0:0,00}">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" HorizontalAlign="Right" Width="10%" />
         </asp:BoundColumn>
         
         
         
         <asp:BoundColumn DataField="tamung" DataFormatString="{0:0,00}" HeaderText="Tạm ứng">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False"  HorizontalAlign="Right"/>
         </asp:BoundColumn>
         
         <asp:BoundColumn DataField="hoanung" DataFormatString="{0:0,00}" HeaderText="Ho&#224;n ứng">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False"  HorizontalAlign="Right"/>
         </asp:BoundColumn>
         
              <asp:BoundColumn DataField="HoanTra" DataFormatString="{0:0,00}" HeaderText="Hoàn Trả">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False"  HorizontalAlign="Right"/>
         </asp:BoundColumn>
         
         
         <asp:BoundColumn DataField="thutienxe" HeaderText="Thu tiền xe">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False"  HorizontalAlign="Right"/>
         </asp:BoundColumn>
         
         <asp:BoundColumn DataField="thanhtoanravien"  HeaderText="Thanh to&#225;n ra viện" DataFormatString="{0:0,00}">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" HorizontalAlign="Right" />
         </asp:BoundColumn>
       </Columns>
           <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
           <SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
           <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" Mode="NumericPages" />
           <ItemStyle BackColor="White" ForeColor="#003399" />
           <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="white" />
       </asp:DataGrid>
            </td>
        </tr>
         <tr style="width:100%" >
            <td>
            <table runat="server" id="tbTongTien">
            <tr>
            <td style="width:380px;font-weight:bold; height: 23px;"><asp:Label runat="server" ID="lblHeader"></asp:Label></td>
            <td style="width:90px;font-weight:bold;" align="right"><asp:Label runat="server" ID="lblTienKham"></asp:Label></td>
            <td style="width:90px;font-weight:bold;" align="right"><asp:Label runat="server" ID="lblTienSo"></asp:Label></td>
            <td style="width:100px;font-weight:bold;" align="right"><asp:Label runat="server" ID="lblCLS"></asp:Label></td>
            <td style="width:100px;font-weight:bold;" align="right"><asp:Label runat="server" ID="lblTienThuoc"></asp:Label></td>
            <td style="width:100px;font-weight:bold;" align="right"><asp:Label runat="server" ID="lblTamUng"></asp:Label></td>
            <td style="width:105px;font-weight:bold;" align="right"><asp:Label runat="server" ID="lblHoanUng"></asp:Label></td>
            <td style="width:105px;font-weight:bold;" align="right"><asp:Label runat="server" ID="lbHoanTra"></asp:Label></td>
            <td style="width:120px;font-weight:bold;" align="right"><asp:Label runat="server" ID="lblTienXe"></asp:Label></td>
            <td style="font-weight:bold;" align="right"><asp:Label runat="server" ID="lblRaVien"></asp:Label></td>
        </tr>
        </table>
        </td>
        </tr>
    </table>
      
    </div>
    </div>
    </form>
</body>
</html>
<!--#include file ="footer.htm"-->
