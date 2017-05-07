<%@ Page Language="C#" MasterPageFile="~/QLDUOC/MasterPage.master" AutoEventWireup="true"
    CodeFile="rpt_TongXuat.aspx.cs" Inherits="QLDUOC_Web_rpt_TongXuat" Title="Báo cáo tổng hợp đã xuất" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <style type="text/css">
        .div-Out
        {
            width: 25%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Báo cáo tổng hợp đã xuất")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho")%>
                </h4>
                <p>
                    <asp:DropDownList ID="ddlkho" runat="server" Width="158px">
                    </asp:DropDownList>
                </p>
            </div>
             <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đối tượng")%>
                </h4>
                <p>
                    <asp:DropDownList ID="chbLoaiThuoc" runat="server" Width="100px">
                    </asp:DropDownList>
                </p>
            </div>
            <div class="div-Out" style="width:30%;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Năm")%>
                </h4>
                <p>
                    <asp:TextBox ID="txtNam" runat="server" TabIndex="1" Width="63px"></asp:TextBox>
                 <asp:Button ID="btnTim" runat="server" Text="Lấy Danh sách" OnClick="btnTim_Click"
                        Width="120px" />
                </p>
            </div>
        </div>
    </div>
</asp:Content>
