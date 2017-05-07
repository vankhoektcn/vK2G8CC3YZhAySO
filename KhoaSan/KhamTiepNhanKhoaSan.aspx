<%@ Page Language="C#" MasterPageFile="~/MasterPage_New.master" AutoEventWireup="true"
    CodeFile="KhamTiepNhanKhoaSan.aspx.cs" Inherits="KhamTiepNhanKhoaSan" Title="Untitled Page" %>


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
		chuyentab('phieuchamsoc');
	});
	function chuyentab(tabb){
        var fileascx = "";
        if(tabb == "phieuchamsoc")
        	//fileascx = "~/usercontrols/KhamTiepNhan_KhoaSan.ascx";
        	fileascx = "~/usercontrols/KhamCapCuu.ascx";
        else if(tabb == "chucnangsong")
            fileascx = "~/usercontrols/capcuu_sinhhieu.ascx";
               
        
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
    <%--<div>
        <uc1:uscmenu ID="Uscmenu1" runat="server" />
    </div>--%>
    <div id="tabs" style="padding-top: 0px;">
        <div style="position: absolute; text-align: center; text-transform: uppercase; font-size: xx-large;
            top: 20px; z-index: 100; width: 100%;color: #4473ca">
           <%-- KHÁM CẤP CỨU--%>
        </div>
        <ul>
            <li><a href="#tabs-1" onclick="chuyentab('phieuchamsoc')"> Khám bệnh</a></li><li><a href="#tabs-1" onclick="chuyentab('chucnangsong');">Sinh hiệu</a></li></ul>
        <div id="tabs-1"></div>
    </div>
    <div id="tabs_1"></div>
</asp:Content>
