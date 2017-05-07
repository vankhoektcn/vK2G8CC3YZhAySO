<%@ Page Language="C#" MasterPageFile="~/DanhMuc_Json/MasterPage_nomenu.master" AutoEventWireup="true"
    CodeFile="DoiMatKhau.aspx.cs" Inherits="Hethong_DoiMatKhau" Title="Đổi Mật Khẩu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/DoiMatKhau.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <div class="header-div" >
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("changepass")%>
        </div>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("UserName")%>
                </h4>
                <p>
                    <span id="username" style="width: 90%">
                        <%=SysParameter.UserLogin.UserName(this) %>
                    </span>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <span style="color: red">*</span>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Password")%>
                </h4>
                <p>
                    <input mkv="true" id="OldPass" type="password" onfocus="chuyenphim(this);" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <span style="color: red">*</span>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NewPass")%>
                </h4>
                <p>
                    <input mkv="true" id="NewPass" type="password" onfocus="chuyenphim(this);" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <span style="color: red">*</span>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TryPass")%>
                </h4>
                <p>
                    <input id="ConfirmPass" type="password" onfocus="chuyenphim(this);" style="width: 90%" />
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button" style="padding-right: 0">
        <div class="in-a" style="background: none; border: none">
            <input id="luu" type="button" style="margin-right: 10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
        </div>
    </div>
</asp:Content>
