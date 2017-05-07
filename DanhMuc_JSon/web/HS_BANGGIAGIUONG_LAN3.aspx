<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="HS_BANGGIAGIUONG_LAN3.aspx.cs" Inherits="HS_BANGGIAGIUONG_LAN" Title="HS_BANGGIAGIUONG_LAN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/HS_BANGGIAGIUONG_LAN3.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("BẢNG GIÁ GIƯỜNG")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TUNGAY")%>
                </h4>
                <p>
                    <input mkv="true" id="TUNGAY" type="text" onfocus='Find(this);' onblur="TestDate(this);"
                        style="width: 50%" />
                    (dd\MM\yyyy)
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Lần thứ")%>
                </h4>
                <p>
                    <input mkv="true" id="LANID" type="text" onfocus='Find(this);' style="width: 90%" />
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="<%=Userlogin_new.HavePermision(this, "HS_BANGGIAGIUONG_LAN_Edit") %>"
                add="<%=Userlogin_new.HavePermision(this, "HS_BANGGIAGIUONG_LAN_Add") %>" type="button"
                value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" delete="<%=Userlogin_new.HavePermision(this, "HS_BANGGIAGIUONG_LAN_Delete") %>"
                type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
            <input id="timKiem" search="<%=Userlogin_new.HavePermision(this, "HS_BANGGIAGIUONG_LAN_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
        <div id="tableAjax_HS_BANGGIAGIUONG" class="in-b">
        </div>
    </div>
</asp:Content>
