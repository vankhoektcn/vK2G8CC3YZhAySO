<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="zBaoCaoBNDieuTriNoitru1.aspx.cs" Inherits="zBaoCaoBNDieuTriNoitru"
    Title="Báo cáo điều trị nội trú" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/zBaoCaoBNDieuTriNoitru1.js">
    </script>

    <style type="text/css">
        .div-Out {
            width:300px;
        }
        .div-Out p {
            width: 60%;
        }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Báo cáo điều trị nội trú")%>
        </p>
        <div class="in-a">
            <div class="div-Out" style="width: 230px;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Từ ngày: ")%>
                </h4>
                <p style="width: 65%;">
                    <input mkv="true" id="tungay" onfocus='$(this).datepick();' type="text" style="width: 75px;" />
                    <input mkv="true" id="tugio" type="text" style="width: 40px;" />
                </p>
            </div>
            <div class="div-Out" style="width: 230px;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đến ngày: ")%>
                </h4>
                <p style="width: 65%;">
                    <input mkv="true" id="denngay" onfocus='$(this).datepick();' type="text" style="width: 75px;" />
                    <input mkv="true" id="dengio" type="text" style="width: 40px;" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("mabenhnhan")%>
                </h4>
                <p>
                    <input mkv="true" id="mabenhnhan" onfocus='Find(this);' type="text" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tenbenhnhan")%>
                </h4>
                <p>
                    <input mkv="true" id="tenbenhnhan" onfocus='Find(this);' type="text" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Loại khám: ")%>
                </h4>
                <p>
                    <select mkv="true" id="loaikham" style="width: 90%;">
                        <option value="">Tất cả</option>
                        <option value="1">Bảo hiểm</option>
                        <option value="2">Dịch vụ</option>
                    </select>
                </p>
            </div>
            <div class="div-Out" style="padding-top: 5px;width: 68%;border-right: 1px solid #ccc;">
                <input id="timKiem" search="true" type="button" style="width: 100px;" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Lấy báo cáo") %>" />
                <input id="Excel" search="true" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Xuất Excel") %>" />
                <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <%--<a class="reload" onclick="Find(this)"></a>--%>
        <div class="in-b" id="tableAjax_zBaoCaoBNDieuTriNoitru">
        </div>
    </div>
</asp:Content>
