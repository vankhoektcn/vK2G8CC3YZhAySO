<%@ Page Language="C#" MasterPageFile="../MasterPage_new.master" AutoEventWireup="true"
    CodeFile="frm_DM_Kho.aspx.cs" Inherits="frm_DM_Kho" Title="khothuoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/frm_DM_Kho.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
    <p></p>
        <div class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("khothuoc")%>
        </div>
        <div class="in-a">
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("makho")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="makho" type="text" onfocus="chuyenphim(this);" style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tenkho")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="tenkho" type="text" onfocus="chuyenphim(this);" style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("diachi")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="diachi" type="text" onfocus="chuyenphim(this);" style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IsKT")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="IsKT" type="checkbox" onfocus="chuyenphim(this);" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IsCLS")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="IsCLS" type="checkbox" onfocus="chuyenphim(this);" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IsKB")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="IsKB" type="checkbox" onfocus="chuyenphim(this);" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdKhoa")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="IdKhoa" type="hidden" />
                    <input mkv="true" id="mkv_IdKhoa" type="text" onfocus="chuyenphim(this);IdKhoaSearch(this);"
                        class="down_select" style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    (*)Lưu ý: Tìm theo Mã và Tên kho</div>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <div class="in-a">
            <input id="luu" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
            <input id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </div>
        <a class="reload" onclick="Find(this);"></a>
        <div class="in-b" id="tableAjax_khothuoc">
        </div>
    </div>
</asp:Content>
