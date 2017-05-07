<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="HS_THUOCNHOM2.aspx.cs" Inherits="HS_THUOCNHOM" Title="HS_THUOCNHOM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/HS_THUOCNHOM2.js">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("PHÂN BỔ NHÓM THUỐC")%>
        </p>
        <div class="in-a">
           
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("CATEID")%>
                </h4>
                <p>
                    <input mkv="true" id="CATEID_CRT" type="hidden" />
                    <input mkv="true" id="mkv_CATEID_CRT" type="text" onfocus="Find(this);CATEIDSearch1(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IDNHOMTHUOC")%>
                </h4>
                <p>
                    <input mkv="true" id="IDNHOMTHUOC_CRT" type="hidden" />
                    <input mkv="true" id="mkv_IDNHOMTHUOC_CRT" type="text" onfocus="Find(this);IDNHOMTHUOCSearch(this,1);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
             <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IDTHUOC")%>
                </h4>
                <p>
                    <input mkv="true" id="IDTHUOC_CRT" type="hidden" />
                    <input mkv="true" id="mkv_IDTHUOC_CRT" type="text" onfocus="Find(this);IDTHUOCSearch1(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luuTable_1" type="button" style="margin-right: 10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
            <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
            <input id="timKiem" search="<%=StaticData.HavePermision(this, "HS_THUOCNHOM_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_HS_THUOCNHOM">
        </div>
        <p class="in-c">
            <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>' />
        </p>
    </div>
</asp:Content>
