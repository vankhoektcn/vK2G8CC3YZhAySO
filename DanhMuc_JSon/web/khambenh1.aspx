<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="khambenh1.aspx.cs" Inherits="khambenh" Title="khambenh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/khambenh1.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH SÁCH BỆNH NHÂN TRẢ KẾT QUẢ CẬN LÂM SÀNG")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaykham")%>
                </h4>
                <p>
                    <input mkv="true" id="ngaykham" type="text" onblur="TestDate(this);" style="width: 50%" />
                    (dd\MM\yyyy)
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("MÃ BN")%>
                </h4>
                <p>
                    <input mkv="true" id="MABENHNHAN" type="text" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TÊN BN")%>
                </h4>
                <p>
                    <input mkv="true" id="TENBENHNHAN" type="text" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đã có KQCLS")%>
                </h4>
                <p>
                    <input mkv="true" id="IsDaCLS" type="checkbox" style="width: 90%" />
                    <input type="hidden" mkv="true" id="idkhambenh" />
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="KetThucCLS"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kết thúc CLS") %> "  style="width:150px"/>
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="timKiem" search="<%=Userlogin_new.HavePermision(this, "khambenh_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_khambenh">
        </div>
    </div>
</asp:Content>
