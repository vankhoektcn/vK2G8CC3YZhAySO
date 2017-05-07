<%@ Page Language="C#" MasterPageFile="~/MasterPage_New.master" AutoEventWireup="true"
    CodeFile="Benhancapcuu.aspx.cs" Inherits="Benhancapcuu" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <style type="text/css">
        #tabs ul
        {
            background: transparent;
            border:1px solid transparent
        }
    </style>

    <script type="text/javascript">
	$(function() {
		$( "#tabs" ).tabs();
		chuyentab('hanhchinh');
	});
	function chuyentab(tabb){
        var fileascx = "";
        if(tabb == "phieuchamsoc")
        	fileascx = "~/usercontrols/capcuu_khambenh.ascx";
        else if(tabb == "chucnangsong")
            fileascx = "~/usercontrols/capcuu_sinhhieu.ascx";
        else if(tabb == "benhan")
            fileascx = "~/usercontrols/capcuu_benhan.ascx";
        else if(tabb == "benhan_tongket")
            fileascx = "~/usercontrols/capcuu_benhantongket.ascx";
        else if(tabb == "bienlai")
            fileascx = "~/usercontrols/capcuu_bienlai.ascx";
        else if(tabb == "hanhchinh")
            fileascx = "~/usercontrols/capcuu_hanhchinh.ascx";
        
        
	    $("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
	    $.ajax({
              type: "POST",
              contentType: "application/json; charset=utf-8",
              url: "Benhancapcuu.aspx/Result",
              data: "{controlName:'"+fileascx+"'}",
               success: function (response) {
                    $("#loadingAjax").remove();
                    $("#tabs_1").html(response);
               }
         });
	}
    </script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">

    <div id="tabs" style="padding-top: 70px;">
        <div style="position: absolute; text-align: center; text-transform: uppercase; font-size: xx-large;
            top: 20px; z-index: 100; width: 100%;color: #4473ca">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("capcuu_khoangoai")%>
        </div>
        <ul>
            <li><a href="#tabs-1" onclick="chuyentab('hanhchinh')"> <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hanhchinh")%></a></li>
            <li><a href="#tabs-1" onclick="chuyentab('benhan');"><%=hsLibrary.clDictionaryDB.sGetValueLanguage("benhan")%></a></li>
            <li><a href="#tabs-1" onclick="chuyentab('bienlai')"> <%=hsLibrary.clDictionaryDB.sGetValueLanguage("bienlai")%></a></li>
            <li><a href="#tabs-1" onclick="chuyentab('chucnangsong');"><%=hsLibrary.clDictionaryDB.sGetValueLanguage("chucnangsong")%></a></li>
            <li><a href="#tabs-1" onclick="chuyentab('phieuchamsoc')"> <%=hsLibrary.clDictionaryDB.sGetValueLanguage("phieuchamsoc")%></a></li>
            <li><a href="#tabs-1" onclick="chuyentab('benhan_tongket')"> <%=hsLibrary.clDictionaryDB.sGetValueLanguage("benhantongket")%></a></li>
            
        </ul>
        <div id="tabs-1"></div>
    </div>
    <div id="tabs_1"></div>
</asp:Content>
