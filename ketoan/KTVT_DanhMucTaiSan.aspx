 <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KTVT_DanhMucTaiSan.aspx.cs" Inherits="DanhMucTaiSan" Title="DanhMucTaiSan" %>
 <%@ Register Src="~/usercontrols/DropDownList.ascx" TagName="DropDownList" TagPrefix="uc1" %>
 <%@ Register Src="~/usercontrols/TextBox.ascx" TagName="TextBox" TagPrefix="uc2" %>
 <%@ Register Src="~/usercontrols/CheckBox.ascx" TagName="CheckBox" TagPrefix="uc3" %>
 <%@ Register Src="~/usercontrols/DateTime.ascx" TagName="DateTime" TagPrefix="uc4" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
 <style type="text/css">
         tr#background:hover
         {
             background-color: #f6ebcd;
             z-index: 1000;
             color: green;
         }
     </style>
     <script type="text/javascript" src="../javascript/DanhMucTaiSan1.js">
     </script>
 </asp:Content> 
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
             <div  style="margin-top:30px;padding: 2px 0px 2px 0px; background-color: #4473ca; border: 2px solid #cfcfcf;
                 text-align: center; color: White;font-size: 25px;font-weight:bold">
                 Danh Sách Tài Sản</div>
     <div style="margin-top: 10px; padding: 5px 5px 5px 5px; border: 1px solid #cfcfcf;background: white">
 <div style="padding-bottom: 10px;display:table;width:100%">
 <uc2:TextBox id="phieu_nhap_id" runat="server" IDTextBox="phieu_nhap_id" onkeyup="Find(this,'ListControlTimKiemphieu_nhap_id');" boolTestSo="true" styleTextBox="width:250px" Title="ID phiếu nhập">
             </uc2:TextBox>
 <uc2:TextBox id="MaTS" runat="server" IDTextBox="MaTS" onkeyup="Find(this,'ListControlTimKiemMaTS');" styleTextBox="width:250px" Title="Mã tài sản">
             </uc2:TextBox>
 <uc2:TextBox id="TenTaiSan" runat="server" IDTextBox="TenTaiSan" onkeyup="Find(this,'ListControlTimKiemTenTaiSan');" styleTextBox="width:250px" Title="Tên tài sản">
             </uc2:TextBox>
 <uc2:TextBox id="HangSX" runat="server" IDTextBox="HangSX" onkeyup="Find(this,'ListControlTimKiemHangSX');" styleTextBox="width:250px" Title="Nước SX">
             </uc2:TextBox>
 <uc2:TextBox id="NamSX" runat="server" IDTextBox="NamSX" onkeyup="Find(this,'ListControlTimKiemNamSX');" boolTestSo="true" styleTextBox="width:250px" Title="Năm sản xuất">
             </uc2:TextBox>
 <uc2:TextBox id="NguyenGia" runat="server" IDTextBox="NguyenGia" onkeyup="Find(this,'ListControlTimKiemNguyenGia');" boolTestSo="true" styleTextBox="width:250px" Title="Nguyên giá">
             </uc2:TextBox>
 <uc2:TextBox id="KhauHaoLK" runat="server" IDTextBox="KhauHaoLK" onkeyup="Find(this,'ListControlTimKiemKhauHaoLK');" boolTestSo="true" styleTextBox="width:250px" Title="Khấu hao lk">
             </uc2:TextBox>
 <uc4:DateTime id="NgayNhap" runat="server" IDTextBox="NgayNhap" onkeyup="Find(this,'ListControlTimKiemNgayNhap');"  Title="Ngày nhập" Text_AfterTextBox="(dd\MM\yyyy)">
             </uc4:DateTime>
 <uc4:DateTime id="NgayKhauHao" runat="server" IDTextBox="NgayKhauHao" onkeyup="Find(this,'ListControlTimKiemNgayKhauHao');"  Title="Ngày khấu hao" Text_AfterTextBox="(dd\MM\yyyy)">
             </uc4:DateTime>
 <uc2:TextBox id="SoNamKH" runat="server" IDTextBox="SoNamKH" onkeyup="Find(this,'ListControlTimKiemSoNamKH');" boolTestSo="true" styleTextBox="width:250px" Title="số tháng khâu hao">
             </uc2:TextBox>
 <uc2:TextBox id="TKNguyenGia" runat="server" IDTextBox="TKNguyenGia" onkeyup="Find(this,'ListControlTimKiemTKNguyenGia');" onfocus="ShowTaiKhoan(this);" styleTextBox="width:250px" Title="TK tài sản">
             </uc2:TextBox>
<uc2:TextBox id="TKDoiUng" runat="server" IDTextBox="TKDoiUng" onkeyup="Find(this,'ListControlTimKiemTKDoiUng');" onfocus="ShowTaiKhoan(this);" styleTextBox="width:250px" Title="TK đối ứng">
             </uc2:TextBox>             
 <uc2:TextBox id="TKKhauHao" runat="server" IDTextBox="TKKhauHao" onkeyup="Find(this,'ListControlTimKiemTKKhauHao');" onfocus="ShowTaiKhoan(this);" styleTextBox="width:250px" Title="TK khấu hao">
             </uc2:TextBox>
 <uc2:TextBox id="TKChiPhi" runat="server" IDTextBox="TKChiPhi" onkeyup="Find(this,'ListControlTimKiemTKChiPhi');" onfocus="ShowTaiKhoan(this);" styleTextBox="width:250px" Title="TK chi phí">
             </uc2:TextBox>
         </div></div>
         <div style="border: 1px solid #cfcfcf; background: white; text-align: center;
             padding: 5px 5px 5px 5px;border-Top:none;">
             <!-- voi cac 'xoa','luu','sua' khi onclick la id cua control -->
             <!-- voi cac ListControlThem,ListControlSua,ListControlTimKiemEnter la cac function -->
             <div style=" padding: 10px 0 10px 0;background-color:#fafafa;border-top:1px solid #cfcfcf;">
                 <input  id="luu" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " onclick="FunctionLuu(this,'<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> ','<%=hsLibrary.clDictionaryDB.sGetValueLanguage("update") %>','ListControlThemSua','ListControlThemSua');"
                      />
                 <input  id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" onclick="LamMoi('<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>');"
                      />
                 <input  id="xoa" type="button" style="display:none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" onclick="Xoa(this,'<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>');"
                      />
                 <asp:Button UseSubmitBehavior="false" ID="Button1" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("timkiem") %>' OnClick="Button1_Click" />
             </div>
  <div  style="overflow:auto">
             <asp:GridView DataKeyNames="danh_muc_ts_id" ID="gridTable" AllowPaging="true" PageSize="100" OnPageIndexChanging="gridTable_PageIndexChanging" runat="server" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowDataBound="gridTable_RowDataBound" AutoGenerateColumns="false">
    <Columns>
   <asp:BoundField DataField="phieu_nhap_id" HeaderText="Id PN"/>
   <asp:BoundField DataField="MaTS" HeaderText="Mã TS"/>
   <asp:BoundField DataField="TenTaiSan" HeaderText="Tên tài sản"/>
   <asp:BoundField DataField="HangSX" HeaderText="Nước SX"/>
   <asp:BoundField DataField="NamSX" HeaderText="Năm sx"/>
   <asp:BoundField DataField="NguyenGia" HeaderText="Nguyên giá"/>
   <asp:BoundField DataField="KhauHaoLK" HeaderText="Khấu hao lk"/>
   <asp:BoundField DataField="NgayNhap" HeaderText="Ngày nhập"/>
   <asp:BoundField DataField="NgayKhauHao" HeaderText="ngày khấu hao"/>
   <asp:BoundField DataField="SoNamKH" HeaderText="số tháng KH"/>
   <asp:BoundField DataField="TKNguyenGia" HeaderText="Tk tài sản"/>
   <asp:BoundField DataField="TKDoiUng" HeaderText="Tk đối ứng"/>
   <asp:BoundField DataField="TKKhauHao" HeaderText="Tk Khấu hao"/>
   <asp:BoundField DataField="TKChiPhi" HeaderText="Tk chi phí"/>
    </Columns>
                 <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                 <RowStyle BackColor="White" ForeColor="Black" />
                 <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                 <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#4473ca" Font-Bold="True" ForeColor="White" />
                 <AlternatingRowStyle BackColor="#CAE3FF" ForeColor="Green"/>
             </asp:GridView>
             <asp:HiddenField ID="HiddenField1" runat="server" />
             <asp:HiddenField ID="HiddenField2" runat="server" />
         </div>
         </div>
 </asp:Content>
