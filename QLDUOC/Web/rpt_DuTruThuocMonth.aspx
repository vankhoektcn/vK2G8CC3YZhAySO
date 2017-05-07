<%@ Page Language="C#" MasterPageFile="~/QLDUOC/MasterPage.master" AutoEventWireup="true"
    CodeFile="rpt_DuTruThuocMonth.aspx.cs" Inherits="QLDUOC_Web_rpt_DuTruThuocMonth"
    Title="Dự trù thuốc theo tháng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <style type="text/css">
        .div-Out
        {
            width: 27%;
        }
    </style>
    <script type="text/javascript">
    function TenThuocSearch(obj)
     {
         $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=TenThuocSearch",{
         minChars:0,
         scroll:true,
         header:false,
         formatItem:function (data) {
             return data[0];
         }}).result(function(event,data){
             setTimeout(function () {
                 obj.focus();
             },100);
         });
     }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Dự trù thuốc theo tháng")%>
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
            <div class="div-Out" style="width: 15%">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tháng")%>
                </h4>
                <p>
                    <input type="text" id="txtMonth" runat="server" style="width: 60%;" />
                </p>
            </div>
            <div class="div-Out" style="width: 15%;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Năm")%>
                </h4>
                <p>
                    <input type="text" id="txtYear" runat="server" style="width: 60%;" />
                </p>
            </div>
            <div class="div-Out" style="width: 27%;">
                <h4>
                    <asp:CheckBox ID="chbThuocGN" runat="server" Text="Thuốc gây nghiện"></asp:CheckBox>
                    <asp:CheckBox ID="chbThuocHTT" runat="server" Text="Thuốc hướng tâm thần"></asp:CheckBox>
                </h4>
            </div>
            <div class="div-Out" style="width:60%;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên thuốc")%>
                </h4>
                <p style="width:84.2%;">
                    <input type="text" id="txtTenThuoc" onfocus="TenThuocSearch(this);" runat="server"
                        style="width: 77%;" class="down_select" />
                        <asp:Button ID="btnTim" runat="server" Text="Lấy Danh sách" OnClick="btnTim_Click"
                        Width="120px" />
                </p>
            </div>
           
        </div>
    </div>
</asp:Content>
