<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="phieunhapkho3_dauky.aspx.cs" Inherits="phieunhapkho3_dauky" Title="phieunhapkho3_dauky" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/phieunhapkho3_dauky.js">
    </script>

    <style>
        .div-Out 
        {
            width:290px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("KHAI BÁO SỐ DƯ CUỐI KỲ")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythang")%>
                </h4>
                <p>
                    <input mkv="true" id="ngaythang" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 40%" />
                    <input mkv="true" id="gio" type="text" style="width: 8%" onfocus="chuyenphim(this);" />:
                    <input mkv="true" id="phut" type="text" style="width: 8%" onfocus="chuyenphim(this);" />                  
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idkho")%>
                </h4>
                <p>
                    <input mkv="true" id="idkho" type="hidden" />
                    <input mkv="true" id="mkv_idkho" type="text" onfocus="Find(this);chuyenphim(this);idkhoSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu")%>
                </h4>
                <p>
                    <input mkv="true" id="ghichu" type="text" onfocus="Find(this);chuyenphim(this);"
                     />
                </p>
            </div>
                                    
            <div class="div-Out">
                <h4>
                    <input id="TimMoi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tìm mới") %>" />
                    <input id="timKiem" search="<%=StaticData.HavePermision(this, "phieunhapkho_Search") %>"
                        type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />                     
                </h4>
            </div>
        </div>
        (*)Lưu ý: định dạng ngày tháng (dd/MM/yyyy) <a class="reload" onclick="loadTableAjaxchitietphieunhapkho($.mkv.queryString('idkhoachinh'))">
        </a>
        <div id="tableAjax_chitietphieunhapkho" class="in-b">
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="<%=StaticData.HavePermision(this, "phieunhapkho_Edit") %>"
                add="<%=StaticData.HavePermision(this, "phieunhapkho_Add") %>" type="button"
                value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" delete="<%=StaticData.HavePermision(this, "phieunhapkho_Delete") %>"
                type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
        </p>
    </div>
</asp:Content>
