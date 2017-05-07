<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kcb_tkbenhan_phukhoa.ascx.cs"
    Inherits="kcb_chandoan_khoangoai" %>

<script type="text/javascript" src="../javascript/kcb_phukhoa3.js">
</script>

<style type="text/css">
        .div-Out
        {
	        float: none;
	        padding: 10px 0px 0px 10px;
	        width: 940px;
	        height: 140px;
	        background-color: #ece9d8;
	        border-bottom: 1px solid #cfcfcf;
	        border-left: 1px solid #ece9d8;
	        clear: both
        }

        .div-Left
        {
	        float: none;
	        padding: 10px 0px 10px 0px;
	        width:100%;
	        border-bottom: 1px solid #ece9d8;
	        height:20px;
        }

        .div-Right
        {
	        width: 99%;
	        background-color: #ece9d8;
	        float: right;
	        padding: 10px 0px 0px 10px;
	        display:table;
	        height:80px
        }
        .body-div .in-a textarea
        {
	        height:60px;
	        padding: 4px 4px;
        }
        </style>
<div class="body-div" style="margin-top: -98px; border-top: none">
    <div class="header-div">
        B.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_tkbenhan_khoangoai")%>
    </div>
    <div class="in-a">
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tk_quatrinhbenhly")%>
            </div>
            <div class="div-Right">
                <textarea mkv="true" id="tk_quatrinhbenhly" type="text" onfocus="chuyenphim(this);"
                    style="width: 90%"></textarea>
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tk_ketquacanlamsan")%>
            </div>
            <div class="div-Right">
                <textarea mkv="true" id="tk_ketquacanlamsan" type="text" onfocus="chuyenphim(this);"
                    style="width: 90%"></textarea>
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tk_phuongphapdieutri")%>
            </div>
            <div class="div-Right">
                <textarea mkv="true" id="tk_phuongphapdieutri" type="text" onfocus="chuyenphim(this);"
                    style="width: 90%"></textarea>
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tk_tinhtrangravien")%>
            </div>
            <div class="div-Right">
                <textarea mkv="true" id="tk_tinhtrangravien" type="text" onfocus="chuyenphim(this);"
                    style="width: 90%"></textarea>
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tk_huongdieutritieptheo")%>
            </div>
            <div class="div-Right">
                <textarea mkv="true" id="tk_huongdieutritieptheo" type="text" onfocus="chuyenphim(this);"
                    style="width: 90%"></textarea>
            </div>
        </div>
    </div>
    <div class="reload" onclick="loadTableAjaxKCB_PhuongPhapDieuTri($.mkv.queryString('idkhoachinh'))">
    </div>
    <div id="tableAjax_KCB_PhuongPhapDieuTri" class="in-b">
    </div>
</div>
<div class="body-div-button">
    <div class="in-a">
        <input id="luu" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
        <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
        <input id="xoa" type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
    </div>
</div>
