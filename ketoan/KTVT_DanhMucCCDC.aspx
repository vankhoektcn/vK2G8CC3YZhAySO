 <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KTVT_DanhMucCCDC.aspx.cs" Inherits="DanhMucCCDC" Title="DanhMucCCDC" %>
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
     <script type="text/javascript" src="../javascript/DanhMucCCDC1.js">
     </script>
 </asp:Content>

 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
             <div  style="margin-top:30px;padding: 2px 0px 2px 0px; background-color: #4473ca; border: 2px solid #cfcfcf;
                 text-align: center; color: White;font-size: 25px;font-weight:bold">
                 Danh Sách Công Cụ Dụng Cụ</div>
     <div style="margin-top: 10px; padding: 5px 5px 5px 5px; border: 1px solid #cfcfcf;background: white">
 <div style="padding-bottom: 10px;display:table;width:100%">
 <uc2:TextBox id="phieu_nhap_id" runat="server" IDTextBox="phieu_nhap_id" onkeyup="Find(this,'ListControlTimKiemphieu_nhap_id');" boolTestSo="true" styleTextBox="width:250px" Title="Id phiếu nhập">
             </uc2:TextBox>
 <uc2:TextBox id="ma_ccdc" runat="server" IDTextBox="ma_ccdc" onkeyup="Find(this,'ListControlTimKiemma_ccdc');" styleTextBox="width:250px" Title="Mã CCDC">
             </uc2:TextBox>
 <uc2:TextBox id="ten_ccdc" runat="server" IDTextBox="ten_ccdc" onkeyup="Find(this,'ListControlTimKiemten_ccdc');" styleTextBox="width:250px" Title="Tên CCDC">
             </uc2:TextBox>
 <uc2:TextBox id="hang_sx" runat="server" IDTextBox="hang_sx" onkeyup="Find(this,'ListControlTimKiemhang_sx');" styleTextBox="width:250px" Title="Nước SX">
             </uc2:TextBox>
 <uc2:TextBox id="nam_sx" runat="server" IDTextBox="nam_sx" onkeyup="Find(this,'ListControlTimKiemnam_sx');" boolTestSo="true" styleTextBox="width:250px" Title="Năm SX">
             </uc2:TextBox>
 <uc2:TextBox id="nguyen_gia" runat="server" IDTextBox="nguyen_gia" onkeyup="Find(this,'ListControlTimKiemnguyen_gia');" boolTestSo="true" styleTextBox="width:250px" Title="Nguyên giá">
             </uc2:TextBox>
 <uc4:DateTime id="ngay_nhap" runat="server" IDTextBox="ngay_nhap" onkeyup="Find(this,'ListControlTimKiemngay_nhap');"  Title="ngay_nhap" Text_AfterTextBox="(dd\MM\yyyy)">
             </uc4:DateTime>
 <uc4:DateTime id="ngay_khau_hao" runat="server" IDTextBox="ngay_khau_hao" onkeyup="Find(this,'ListControlTimKiemngay_khau_hao');"  Title="Ngày khấu hao" Text_AfterTextBox="(dd\MM\yyyy)">
             </uc4:DateTime>
 <uc2:TextBox id="so_thang_khau_hao" runat="server" IDTextBox="so_thang_khau_hao" onkeyup="Find(this,'ListControlTimKiemso_thang_khau_hao');" boolTestSo="true" styleTextBox="width:250px" Title="Số tháng KH">
             </uc2:TextBox>
 <uc2:TextBox id="Tk_ccdc" runat="server" IDTextBox="Tk_ccdc" onkeyup="Find(this,'ListControlTimKiemTk_ccdc');" onfocus="ShowTaiKhoan(this);" styleTextBox="width:250px" Title="TK CCDC">
             </uc2:TextBox>
 <uc2:TextBox id="Tk_doi_ung" runat="server" IDTextBox="Tk_doi_ung" onkeyup="Find(this,'ListControlTimKiemTk_doi_ung');" onfocus="ShowTaiKhoan(this);" styleTextBox="width:250px" Title="TK đối ứng">
             </uc2:TextBox>
 <uc2:TextBox id="tk_chi_phi" runat="server" IDTextBox="tk_chi_phi" onkeyup="Find(this,'ListControlTimKiemtk_chi_phi');" onfocus="ShowTaiKhoan(this);" styleTextBox="width:250px" Title="TK chi phí">
             </uc2:TextBox>
 <uc2:TextBox id="tk_phan_bo" runat="server" IDTextBox="tk_phan_bo" onkeyup="Find(this,'ListControlTimKiemtk_phan_bo');" onfocus="ShowTaiKhoan(this);" styleTextBox="width:250px" Title="TK phân bổ">
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
             <asp:GridView DataKeyNames="ccdc_id" ID="gridTable" AllowPaging="true" PageSize="100" OnPageIndexChanging="gridTable_PageIndexChanging" runat="server" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowDataBound="gridTable_RowDataBound" AutoGenerateColumns="false">
    <Columns>
   <asp:BoundField DataField="phieu_nhap_id" HeaderText="Id PN"/>
   <asp:BoundField DataField="ma_ccdc" HeaderText="Mã CCDC"/>
   <asp:BoundField DataField="ten_ccdc" HeaderText="Tên CCDC"/>
   <asp:BoundField DataField="hang_sx" HeaderText="Nước SX"/>
   <asp:BoundField DataField="nam_sx" HeaderText="Năm SX"/>
   <asp:BoundField DataField="nguyen_gia" HeaderText="Nguyên giá"/>
   <asp:BoundField DataField="ngay_nhap" HeaderText="Ngày nhập"/>
   <asp:BoundField DataField="ngay_khau_hao" HeaderText="Ngày khấu hao"/>
   <asp:BoundField DataField="so_thang_khau_hao" HeaderText="Số tháng KH"/>
   <asp:BoundField DataField="Tk_ccdc" HeaderText="TK CCDC"/>
   <asp:BoundField DataField="Tk_doi_ung" HeaderText="TK đối ứng"/>
   <asp:BoundField DataField="tk_chi_phi" HeaderText="TK chi phí"/>
   <asp:BoundField DataField="tk_phan_bo" HeaderText="TK phân bổ"/>
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
