<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="TieuDeCty.aspx.cs" Inherits="DanhMuc_JSon_web_TieuDeCty" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <style type="text/css">
* {
font-size: 16px;
font-weight: normal;
font-family: none;
}
input[type="text"], select {
border: 1px solid black;
}
 #copyright {
    position: fixed;
    width: 100%;
    bottom: 0;
    right: 0;
    z-index: 1000;
    margin-right: 0;
    background: url(../../images/line.jpg) repeat-x top center;
    height: 29px;
    font-family: Tahoma;
    font-size: 12px;
    font-weight: bold;
    padding-right: 1%;
    line-height: 25px;
    color: black;
}
#copy-l {
float: left;
padding-left: 1.5%;
}
#copy-r {
float: right;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div style="position: absolute; top: 50px; left: 20%; padding: 40px 10px 10px 10px;
        border: 1px solid black;">
        <div style="position: absolute; top: 0px; text-align: center; padding: 5px 5px 5px 5px;
            width: 96%; font-size: 20px; border-bottom: 2px solid;">
            Thông tin đơn vị</div>
        <asp:Label ID="Label8" runat="server" Text="Logo : " Width="95px"></asp:Label>
        <asp:FileUpload ID="fulLogo" runat="server" Width="246px" />
        &nbsp;
        <asp:Image ID="Image1" runat="server" Style="height: 150px; width: auto;" ImageAlign="Middle">
        </asp:Image>
        &nbsp; &nbsp;<asp:Button ID="btnSaveLogo" runat="server" OnClick="btnSaveLogo_Click"
            Text="Lưu Logo" /><br />
        <asp:Label ID="Label1" runat="server" Text="Tên đơn vị :" Width="91px"></asp:Label>
        <asp:TextBox ID="txtTenCty" runat="server" Width="490px"></asp:TextBox>&nbsp;&nbsp;<br />
        <asp:Label ID="Label2" runat="server" Text="Địa chỉ : " Width="95px"></asp:Label>
        <asp:TextBox ID="txtDC" runat="server" Width="490px"></asp:TextBox>&nbsp;&nbsp;&nbsp;<br />
        <asp:Label ID="Label3" runat="server" Text="Điện thoại :" Width="91px"></asp:Label>
        <asp:TextBox ID="txtDT" runat="server"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label4" runat="server" Text="Fax:" Width="91px"></asp:Label>
        <asp:TextBox ID="txtFax" runat="server" Width="245px"></asp:TextBox><br />
        <asp:Label ID="Label6" runat="server" Text="Email :" Width="91px"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label5" runat="server" Text="Mã số thuế : " Width="93px"></asp:Label>
        <asp:TextBox ID="txtMST" runat="server" Width="245px"></asp:TextBox><br />
        <asp:Label ID="Label7" runat="server" Text="Website : " Width="94px"></asp:Label>
        <asp:TextBox ID="txtWebsite" runat="server" Width="262px"></asp:TextBox>&nbsp;&nbsp;
        &nbsp;&nbsp; &nbsp; &nbsp;
        <asp:Button ID="btnLuu" runat="server" Text="Lưu" Width="98px" OnClick="btnLuu_Click" /><asp:Button
            ID="btnMoi" runat="server" Text="Mới" Width="92px" />
        &nbsp; &nbsp; &nbsp;&nbsp;<br />
        &nbsp;
        <input type="hidden" runat="server" id="IdTieuDeCty" />
    </div>
    <div id="copyright">
        <div id="copy-l">
            <%= StaticData.TenPhanMem %>
            -
            <%= StaticData.TenCty %>
            | Người dùng:
            <%= (SysParameter.UserLogin.FullName(this)) %>
        </div>
        <div id="copy-r">
            Phát triển bởi <a href="https://ketnoimoi.com/" target="_blank">Kết Nối Mới </a>
            , Ltd.,Co
        </div>
    </div>
</asp:Content>
