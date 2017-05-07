<%@ Page Language="C#" MasterPageFile="~/MasterPage_New.master" AutoEventWireup="true" CodeFile="Benhannoikhoa_CapCuu.aspx.cs" Inherits="Benhannoikhoa_CapCuu" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
     <style type="text/css">
        #tabb ul
        {
            background: transparent;
            border:1px solid transparent
        }
    </style>

    <script type="text/javascript">
	$(function() {
	    $( "#tabb" ).tabs();
		chuyentab('hanhchinh');
	});
	function chuyentab(tabb){
        var fileascx = "";
        if(tabb == "quanly")
        	fileascx = "~/usercontrols/kcb_quanly_khoanoi.ascx";
        else if(tabb == "chandoan")
            fileascx = "~/usercontrols/kcb_chandoan_khoanoi.ascx";
        else if(tabb == "tinhtrang")
            fileascx = "~/usercontrols/kcb_tinhtrang_khoanoi.ascx";
        else if(tabb == "hoibenh")
            fileascx = "~/usercontrols/kcb_hoibenh_khoanoi.ascx";
        else if(tabb == "khambenh")
            fileascx = "~/usercontrols/kcb_khambenh_khoanoi.ascx";
        else if(tabb == "chandoanvaokhoa")
            fileascx = "~/usercontrols/kcb_chandoanvaokhoa_khoanoi.ascx";
        else if(tabb == "tkbenhan")
            fileascx = "~/usercontrols/kcb_tkbenhan_khoanoi.ascx";
        else if(tabb == "phieuchamsoc")
        	fileascx = "~/usercontrols/capcuu_khambenh.ascx";
        else if(tabb == "chucnangsong")
            fileascx = "~/usercontrols/capcuu_sinhhieu.ascx";
        else if(tabb == "bienlai")
            fileascx = "~/usercontrols/capcuu_bienlai.ascx";
        else if(tabb == "hanhchinh")
            fileascx = "~/usercontrols/kcb_hanhchinh_khoanoi.ascx";
            
	    $("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
	    $.ajax({
              type: "POST",
              contentType: "application/json; charset=utf-8",
              url: "Benhannoikhoa.aspx/Result",
              data: "{controlName:'"+fileascx+"'}",
               success: function (response) {
                    $("#tabs-1").html(response);
                    $("#loadingAjax").remove();
               }
         });
	}
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="tabb" style="padding-top: 70px;padding-bottom:20px">
        <div style="position: absolute; text-align: center; text-transform: uppercase; font-size: xx-large;
            top: 20px; z-index: 1000; width: 100%; color: #4473ca">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_khoanoi")%>
        </div>
                <ul>
                    <li><a href="#Div3" onclick="chuyentab('hanhchinh')">I.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_hanhchinh_khoanoi")%></a></li>
                    <li><a href="#Div3" onclick="chuyentab('quanly')">II.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_quanly_khoanoi")%></a></li>
                    <li><a href="#Div3" onclick="chuyentab('chandoan');">III.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_chandoan_khoanoi")%></a></li>
                    <li><a href="#Div3" onclick="chuyentab('tinhtrang');">IV.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_tinhtrang_khoanoi")%></a></li>
                    <li><a href="#Div3" onclick="chuyentab('hoibenh')">A.II.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_hoibenh_khoanoi")%></a></li>
                    <li><a href="#Div3" onclick="chuyentab('khambenh');">A.III.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_khambenh_khoanoi")%></a></li>
                    <li><a href="#Div3" onclick="chuyentab('chandoanvaokhoa');">A.IV,V,VI.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_chandoanvaokhoa_khoanoi")%></a></li>
                    <li><a href="#Div3" onclick="chuyentab('bienlai')">A.VII.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("bienlai")%></a></li>
                    <li><a href="#Div3" onclick="chuyentab('chucnangsong');">A.VIII.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("chucnangsong")%></a></li>
                    <li><a href="#Div3" onclick="chuyentab('phieuchamsoc')">A.IX.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("phieuchamsoc")%></a></li>
                    <li><a href="#Div3" onclick="chuyentab('tkbenhan');">B.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_tkbenhan_khoanoi")%></a></li>
                </ul>
                <div id="Div3"></div>
        </div>
        <div id="tabs-1"></div>
</asp:Content>


