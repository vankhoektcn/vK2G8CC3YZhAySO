<%@ Page Language="C#" MasterPageFile="~/QLDUOC/MasterPage_new.master" AutoEventWireup="true"
    CodeFile="frm_DM_DinhMucTonKho.aspx.cs" Inherits="frm_DM_DinhMucTonKho" Title="frm_DM_DinhMucTonKho.js" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/frm_DM_DinhMucTonKho.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <div class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Thuoc_DinhMucTonKho")%>
        </div>
         
        <div class="in-a">
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("loaithuocid")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="loaithuocid" type="hidden" />
                    <input mkv="true" id="mkv_loaithuocid" type="text" onfocus="Find(this);chuyenphim(this);loaithuocidSearch(this);"
                        class="down_select" style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cateid")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="cateid" type="hidden" />
                    <input mkv="true" id="mkv_cateid" type="text" onfocus="Find(this);chuyenphim(this);cateidSearch(this);"
                        class="down_select" style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Idthuoc")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="Idthuoc" type="hidden" />
                    <input mkv="true" id="mkv_Idthuoc" type="text" onfocus="Find(this);chuyenphim(this);IdthuocSearch(this);"
                        class="down_select" style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdKho")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="idkho" type="hidden" />
                    <input mkv="true" id="mkv_idkho" type="text" onfocus="Find(this);chuyenphim(this);IdKhoSearch(this);"
                        class="down_select" style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SL")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="SL" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);"
                        style="width: 90%" />
                </div>
            </div>
        </div>
        <div class="body-div-button">
            <div class="in-a">
                <input id="luuTable_1" type="button" style="margin-right: 10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
                <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
                <input id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
            </div>
            <a class="reload" onclick="Find(this)"></a>
            <div class="in-b" id="tableAjax_Thuoc_DinhMucTonKho">
            </div>
            <div class="in-c">
                <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>' />
            </div>
        </div>
    </div>
</asp:Content>
