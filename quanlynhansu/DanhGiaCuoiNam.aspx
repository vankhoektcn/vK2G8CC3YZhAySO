<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhGiaCuoiNam.aspx.cs" Inherits="NhanSu_DanhGiaCuoiNam" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--#include file ="header.htm"-->
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1">
    <title>Đánh giá cuối năm</title>
    <link href="css/NhanSu.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<div id="MyPage">
     <div id="Menu" style="background-color:White;text-align:left">
	    <uc1:uscmenu ID="Uscmenu1" runat="server" />
	</div>
	<div id="header">
		Đánh giá cuối năm
	</div>
	<div id="NoiDung" style="background-color:White;width:95%">
		<div id="tableBig">			
			<div class="tableBig-row">
			    <div style="width:80px;float:left">Nhân viên</div>
			    <div style="width:200px;float:left;">
                    <asp:DropDownList ID="ddlNhanVien" runat="server" Width="130px">
                    </asp:DropDownList></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:80px;float:left">Xếp loại</div>
			   <div style="width:200px;float:left;" >
			        <asp:DropDownList ID="ddlXepLoai" runat="server" Width="123px">
                    </asp:DropDownList>
                   </div>
			</div>
			<div class="tableBig-row">
			   <div style="width:80px;float:left">Ghi chú</div>
			   <div style="width:200px;float:left;" ><asp:textbox  CssClass="input" runat="server" id="txtGhiChu"></asp:textbox></div>
			</div>						
			<div  class="tableBig-row" style="clear:both;text-align:center;width:500px">
			    <div style="width:60px;float:left">
                    <asp:Button ID="btnLuu" Width="50px" runat="server" Text="Lưu" OnClick="btnLuu_Click"  />
                </div>
                <div style="width:60px;float:left">
                    <asp:Button ID="btnMoi" Width="50px" runat="server" Text="Mới" OnClick="btnMoi_Click"    />
			    </div>
			    <div style="width:60px;float:left">
                    <asp:Button ID="btnXoan" Width="50px" runat="server" Text="Xóa" OnClick="btnXoan_Click"  />
			    </div>
			    <div style="width:60px;float:left">
                    <asp:Button ID="bntTim" Width="50px" runat="server" Text="Tìm" OnClick="bntTim_Click"   />
			    </div>	
			    <div style="width:100px;float:left">
                    <asp:Button ID="btnExcel" Width="96px" runat="server" Text="Xuất Excel" OnClick="btnExcel_Click" />
			    </div>	
			    <div><asp:textbox runat="server" id="txtidDanhGiaCuoiNam" Width="10px" Visible="false"></asp:textbox></div>		    
			</div>
		</div>
		<br />
		<div style="background-image:url(../images/menu.jpg);font-weight:bold;color:White;text-align:left;padding-left:10px">
		DANH SÁCH ĐÁNH GIÁ NHÂN VIÊN CUỐI NĂM
	</div>
	<br />
		<div style="clear:both;margin:0 auto;display:table;">
		    <asp:GridView ID="gidDanhGiaCuoiNam" runat="server" Width="993px" DataKeyNames="iddanhgia" AutoGenerateColumns="False" OnRowDeleting="gidDanhGiaCuoiNam_RowDeleting" OnSelectedIndexChanging="gidDanhGiaCuoiNam_SelectedIndexChanging"         
              		    HeaderStyle-CssClass="HeaderStyle" CssClass="GridViewStyle" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle">              
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:CommandField DeleteText="X&#243;a" SelectText="Xem" ShowDeleteButton="True" />
                     <asp:BoundField DataField="STT" HeaderText="STT" />
                    <asp:BoundField DataField="tennhanvien" HeaderText="Nh&#226;n vi&#234;n" />
                    <asp:BoundField DataField="tenxeploai" HeaderText="Xếp loại" />
                    <asp:BoundField DataField="ghichu" HeaderText="Ghi ch&#250;" />
                </Columns>
                     
            </asp:GridView>            
		</div>
		
	</div>
</div>
    </form>
</body>
</html>
<!--#include file ="footer.htm"-->