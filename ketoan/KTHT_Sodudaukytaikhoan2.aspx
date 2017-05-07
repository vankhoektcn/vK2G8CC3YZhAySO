<%@ Page Language="C#" MasterPageFile="MasterPage_KT.master" AutoEventWireup="true"
    CodeFile="KTHT_Sodudaukytaikhoan2.aspx.cs" Inherits="So_Du_Tk_Dau_Ky" Title="So_Du_Tk_Dau_Ky" %>

<%@ Register Src="Menu_KT/uscmenuKT_HeThong.ascx" TagName="uscmenuKT_HeThong" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="javascript/KTHT_Sodudaukytaikhoan2.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <uc1:uscmenuKT_HeThong ID="uscmenuKT_HeThong1" runat="server" />
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("số dư tài khoản đầu kì")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nam")%>
                </h4>
                <p>
                    <input mkv="true" id="nam" type="text" onfocus='Find(this);' style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tai_khoan")%>
                </h4>
                <p>
                    <input mkv="true" id="tai_khoan" type="text" onfocus='Find(this);taikhoansearch(this.id)' style="width: 90%" />
                </p>
            </div>
<%--            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Dư nợ đầu kì")%>
                </h4>
                <p>
                    <input mkv="true" id="du_no0" type="text" onfocus='Find(this);' onblur="TestSo(this,false,false);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Dư có đầu kì")%>
                </h4>
                <p>
                    <input mkv="true" id="du_co0" type="text" onfocus='Find(this);' onblur="TestSo(this,false,false);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Dư nợ nt")%>
                </h4>
                <p>
                    <input mkv="true" id="du_no_nt0" type="text" onfocus='Find(this);' onblur="TestSo(this,false,false);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Dư có nt")%>
                </h4>
                <p>
                    <input mkv="true" id="du_co_nt0" type="text" onfocus='Find(this);' onblur="TestSo(this,false,true);"
                        style="width: 90%" />
                </p>
            </div>--%>
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
<%--            <input id="luu" type="button" style="margin-right: 10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
--%>            <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
            <input id="timKiem" search="<%=StaticData.HavePermision(this, "So_Du_Tk_Dau_Ky_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_So_Du_Tk_Dau_Ky">
        </div>
        <p class="in-c">
            <input id="luuTable" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>' />
        </p>
    </div>
</asp:Content>
