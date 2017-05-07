<%@ Page Language="C#" MasterPageFile="MasterPageBNNV.master" AutoEventWireup="true"
    CodeFile="hs_DangKyCLS3.aspx.cs" Inherits="hs_DangKyCLS" Title="hs_DangKyCLS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="javascript/hs_DangKyCLS3.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("CHI TIẾT ĐĂNG KÝ CẬN LÂM SÀNG")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("MaPhieuCLS")%>
                </h4>
                <p>
                    <input mkv="true" id="MaPhieuCLS" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày đăng ký")%>
                </h4>
                <p>
                    <input mkv="true" id="NgayDK" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 50%" />
                    (dd/MM/yyyy)
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Người thu")%>
                </h4>
                <p>
                    <input mkv="true" id="idnguoidung" type="hidden" />
                    <input mkv="true" id="mkv_idnguoidung" type="text" onfocus="Find(this);chuyenphim(this);idnguoidungSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Bệnh nhân")%>
                </h4>
                <p>
                    <input mkv="true" id="dathu" type="hidden" />
                    <input mkv="true" id="idkhambenh" type="hidden" />
                    <input mkv="true" id="idbenhnhan" type="hidden" />
                    <input mkv="true" id="mkv_idbenhnhan" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Bác sĩ chỉ định")%>
                </h4>
                <p>
                    <input mkv="true" id="idbacsicd" type="hidden" />
                    <input mkv="true" id="tenbschidinh" type="text" onfocus="Find(this);chuyenphim(this);LoadDanhSachBacSiCD(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đăng ký tại khoa")%>
                </h4>
                <p>
                    <input mkv="true" id="idkhoadangky" type="hidden" />
                    <input mkv="true" id="mkv_idkhoadangky" type="text" onfocus="Find(this);chuyenphim(this);idkhoadangkysearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
        </div>
        <a class="reload" onclick="loadTableAjaxkhambenhcanlamsan($.mkv.queryString('idkhoachinh'))">
        </a>
        <div id="tableAjax_khambenhcanlamsan" class="in-b">
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="<%=StaticData.HavePermision1(this, "hs_DangKyCLS_Edit") %>"
                add="<%=StaticData.HavePermision1(this, "hs_DangKyCLS_Add") %>" type="button"
                value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" delete="<%=StaticData.HavePermision1(this, "hs_DangKyCLS_Delete") %>"
                type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
            <input id="timKiem" search="<%=StaticData.HavePermision1(this, "hs_DangKyCLS_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
    </div>
</asp:Content>
