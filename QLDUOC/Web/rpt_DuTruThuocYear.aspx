<%@ Page Language="C#" MasterPageFile="~/QLDUOC/MasterPage.master" AutoEventWireup="true"
    CodeFile="rpt_DuTruThuocYear.aspx.cs" Inherits="QLDUOC_Web_rpt_DuTruThuocYear"
    Title="Dự trù thuốc - năm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <style type="text/css">
        .div-Out
        {
            width:30%;
        }
    </style>

    <script type="text/javascript">
    function TenThuocSearch(obj)
     {
         $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=TenThuocSearch",{
         minChars:0,
         width:250,
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
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Dự trù thuốc theo năm")%>
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
            <div class="div-Out" style="width:50%;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Năm")%>
                </h4>
                <p>
                    <asp:TextBox ID="txtNam" runat="server" TabIndex="1" Width="63px"></asp:TextBox>
                     <asp:CheckBox ID="chbThuocGN" runat="server" Text="Thuốc gây nghiện"></asp:CheckBox>
                    <asp:CheckBox ID="chbThuocHTT" runat="server" Text="Thuốc hướng tâm thần"></asp:CheckBox>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên thuốc")%>
                </h4>
                <p>
                    <input type="text" id="txtTenThuoc" onfocus="TenThuocSearch(this);" runat="server" style="width:90%;" class="down_select" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <asp:Button ID="btnTim" runat="server" Text="Lấy Danh sách"
                        OnClick="btnTim_Click" Width="120px" />
                </h4>
            </div>
        </div>
    </div>
</asp:Content>
