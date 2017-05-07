<%@ Page Language="C#" MasterPageFile="~/MasterPageThuPhi_New.master" AutoEventWireup="true"
    CodeFile="PhanQuyenUser.aspx.cs" Inherits="Hethong_PhanQuyenUser" Title="Untitled Page" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <style type="text/css">
    .body-out
    {
        width:710px;
        margin-top:10%;
        padding-bottom:0px
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div" style="padding-top: 10px; width: 700px">
        <div class="header-div" style="top: 5px">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("UserProfile")%>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="updaate" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="in-a" style="padding-top: 5px">
                    <div style="clear: both; text-align: center">
                        Người dùng :<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="422px">
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                            AutoPostBack="True">
                            <asp:ListItem>Lấy quyền</asp:ListItem>
                            <asp:ListItem>Giữ quyền</asp:ListItem>
                        </asp:DropDownList></div>
                    <div style="float: left">
                        <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Height="437px"
                            Width="319px" BackColor="#ECE9D8"></asp:ListBox>
                    </div>
                    <div style="width: 50px; float: left; padding-top: 200px; padding-bottom: 200px;
                        text-align: center; position: relative">
                        <asp:Button ID="Button1" Width="50px" runat="server" OnClick="Button1_Click" Text=">"
                            BackColor="#C0C0FF" />
                        <asp:Button ID="Button2" Width="50px" runat="server" Text="<" OnClick="Button2_Click"
                            BackColor="#C0C0FF" />
                        <asp:Button ID="Button3" Width="50px" runat="server" OnClick="Button3_Click" Text=">>|"
                            BackColor="Gray" ForeColor="White" />
                        <asp:Button ID="Button4" Width="50px" runat="server" BackColor="Gray" ForeColor="White"
                            OnClick="Button4_Click" Text="|<<" />
                    </div>
                    <div style="float: left">
                        <asp:ListBox ID="ListBox2" runat="server" Height="437px" Width="322px" SelectionMode="Multiple"
                            BackColor="#ECE9D8"></asp:ListBox>
                    </div>
                    <div style="clear: both; text-align: center">
                        <asp:Button ID="Button5" runat="server" Text="Lưu" Width="80px" Height="25px" OnClick="Button5_Click" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
