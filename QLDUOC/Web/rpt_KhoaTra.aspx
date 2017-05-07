<%@ Page Language="C#" MasterPageFile="~/QLDUOC/MasterPage.master" AutoEventWireup="true"
    CodeFile="rpt_KhoaTra.aspx.cs" Inherits="QLDUOC_Web_rpt_KhoaTra" Title="Báo cáo nhập trả từ các khoa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <style type="text/css">
        .div-Out
        {
            width:30%;
            height:50px;
            line-height:50px;
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
     $(function(){
        if($.mkv.queryString("XuatTheoKhoa")!=null && $.mkv.queryString("XuatTheoKhoa")=="1")
        {
            $(".header-div").html("Báo cáo xuất theo khoa");
        }
     });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Báo cáo nhập trả từ các khoa")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho")%>
                </h4>
                <p>
                    <asp:DropDownList ID="ddlkho" runat="server">
                    </asp:DropDownList>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đối tượng")%>
                </h4>
                <p>
                    <asp:DropDownList ID="ddlLoaiThuoc" runat="server" >
                    </asp:DropDownList>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên thuốc")%>
                </h4>
                <p>
                    <asp:TextBox ID="txtTenThuoc" runat="server" onfocus="TenThuocSearch(this);" Width="220px"></asp:TextBox>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tháng")%>
                </h4>
                <p>
                    <select id="ddlThang" runat="server">
                        <option value="1">Tháng 1</option>
                        <option value="2">Tháng 2</option>
                        <option value="3">Tháng 3</option>
                        <option value="4">Tháng 4</option>
                        <option value="5">Tháng 5</option>
                        <option value="6">Tháng 6</option>
                        <option value="7">Tháng 7</option>
                        <option value="8">Tháng 8</option>
                        <option value="9">Tháng 9</option>
                        <option value="10">Tháng 10</option>
                        <option value="11">Tháng 11</option>
                        <option value="12">Tháng 12</option>
                    </select>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Năm")%>
                </h4>
                <p>
                    <input type="text" style="width: 50px" runat="server" id="txtNam" />
                    <asp:Button ID="btnTim" runat="server" Text="Lấy Danh sách" OnClick="btnTim_Click"
                        Width="120px" />
                </p>
            </div>
        </div>
    </div>
</asp:Content>
