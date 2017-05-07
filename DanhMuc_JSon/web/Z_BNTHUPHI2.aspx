<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="Z_BNTHUPHI2.aspx.cs" Inherits="Z_BNTHUPHI" Title="Thu phí KCB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/Z_BNTHUPHI2.js">
    </script>

    <style type="text/css">
        .div-Out
        {
            width:25%;
        }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Thu phí")%>
        </p>
        <div class="in-a">
            <div class="div-Out" style="width:20%">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NGAYTHU")%>
                </h4>
                <p style="width:58%">
                    <input mkv="true" id="NgayThuPhi" type="text" style="width: 75%" onfocus="$(this).validDate();" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("MABENHNHAN")%>
                </h4>
                <p style="width:55%;">
                    <input mkv="true" id="MABENHNHAN" type="text" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 40%">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TENBENHNHAN")%>
                </h4>
                <p style="width: 72%">
                    <input mkv="true" id="TENBENHNHAN" type="text" style="width: 63%" />
                    <input id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button" style="margin: 0; margin-top: 0.2%; border: 1px solid #ccc;
        border-top: none; padding: 0; width: 100%">
        <div class="in-b" style="top: 0" id="tableAjax_Z_BNTHUPHI">
        </div>
        <input type="hidden" id="isChietKhauThuPhi" value="<%=StaticData.GetParameter("isChietKhauThuPhi")%>"/>
    </div>
    <div id="divPopup">
        <input type="hidden" id='idmaphieu' />
        <div id="title">
        </div>
        <div id="detail">
        </div>
        <a class="close"></a>
    </div>
</asp:Content>
