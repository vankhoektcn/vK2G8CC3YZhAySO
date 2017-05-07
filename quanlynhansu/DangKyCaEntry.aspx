<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DangKyCaEntry.aspx.cs" Inherits="NhanSu_DangKyCaEntry" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--#include file ="header.htm"-->
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1">
    <title>Đăng ký ca</title>
    <link href="css/NhanSu.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<div id="MyPage">
    <div id="Menu" style="background-color:White;text-align:left">
	    <uc1:uscmenu ID="Uscmenu1" runat="server" />
	</div>
	<br />
	<div id="header">
	ĐĂNG KÝ CA
	</div>
	<div id="NoiDung" style=" background-color:White;width:95%">
		<div id="tableBig">			
			<div class="tableBig-row">
			    <div style="width:80px;float:left">Nhân viên:&nbsp;</div>
			    <div style="width:240px;float:left;">
                    <asp:DropDownList ID="ddlNhanVien"  runat="server" Width="130px">
                    </asp:DropDownList></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:80px;float:left">Ca làm việc:&nbsp;</div>
			   <div style="width:200px;float:left;" >
			        <asp:DropDownList ID="ddlCaLamViec" CssClass="combobox" runat="server" Width="123px">
                    </asp:DropDownList>
                   </div>
			</div>
			<div class="tableBig-row">
			   <div style="width:50px;float:left">Thứ:&nbsp;</div>
			   <div style="width:150px;float:left;" ><asp:textbox CssClass="input" runat="server" id="txtThu"></asp:textbox></div>
			</div>						
			<div  class="tableBig-row" style="clear:both;text-align:center;width:500px;">
			    <div style="width:60px;float:left;">
                    <asp:Button ID="btnLuu" Width="50px" runat="server" Text="Lưu" OnClick="btnLuu_Click"   />
                </div>
                <div style="width:60px;float:left;">
                    <asp:Button ID="btnMoi" Width="50px" runat="server" Text="Mới" OnClick="btnMoi_Click"   />
			    </div>
			    <div style="width:60px;float:left">
                    <asp:Button ID="btnXoan" Width="50px" runat="server" Text="Xóa" OnClick="btnXoan_Click"   />
			    </div>
			    <div style="width:60px;float:left">
                    <asp:Button ID="bntTim" Width="50px" runat="server" Text="Tìm" OnClick="bntTim_Click"  />
			    </div>	
			    <div style="width:100px;float:left">
                    <asp:Button ID="btnExcel" Width="96px" runat="server" Text="Xuất Excel" OnClick="btnExcel_Click" />
			    </div>	
			    <div><asp:textbox runat="server" id="txtidDangKyCa" Width="10px" Visible="false"></asp:textbox></div>		    
			</div>
		</div>
		<br />
		<div style="background-image:url(../images/menu.jpg);font-weight:bold;color:White;text-align:left;padding-left:10px">
		DANH SÁCH NHÂN VIÊN ĐĂNG KÝ CA
	</div>
	<br />
		<div style="clear:both;margin:0 auto;display:table;">
		    <asp:GridView ID="gidDangKyCa" runat="server" Width="993px" DataKeyNames="iddangkyca" AutoGenerateColumns="False" OnRowDeleting="gidDangKyCa_RowDeleting" OnSelectedIndexChanging="gidDangKyCa_SelectedIndexChanging"              
               		    HeaderStyle-CssClass="HeaderStyle" CssClass="GridViewStyle" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle">              

                <Columns>
                  
                    <asp:CommandField SelectText="Xem" ShowSelectButton="True" />
                    <asp:CommandField DeleteText="X&#243;a" SelectText="Sửa" ShowDeleteButton="True" />
                    <asp:BoundField DataField="STT" HeaderText="STT" />
                    <asp:BoundField DataField="tennhanvien" HeaderText="Nh&#226;n vi&#234;n" />
                    <asp:BoundField DataField="tencalamviec" HeaderText="Ca l&#224;m việc" />
                    <asp:BoundField DataField="thu" HeaderText="Thứ" />
                </Columns>
                               
            </asp:GridView>            
		</div>
		
	</div>
</div>
    </form>
</body>
</html>
<!--#include file ="footer.htm"-->