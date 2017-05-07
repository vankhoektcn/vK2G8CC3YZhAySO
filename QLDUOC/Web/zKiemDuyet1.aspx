 <%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true" CodeFile="zKiemDuyet1.aspx.cs" Inherits="zKiemDuyet" Title="zKiemDuyet" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/zKiemDuyet1.js">
     </script>
     <style type="text/css">
     .div-Out {
        width: 350px;
        }
     </style>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("zKiemDuyet")%>
           </p>
 <div class="in-a">
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày duyệt: ")%>
     </h4>
     <p>
        <input mkv="true" id="TUNGAY" type="text" onblur="$.TestDate(this);"  style="width:80px;"/>
        <input mkv="true" id="TUGIO" type="text" style="width:60px;"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("đến ngày: ")%>
     </h4>
     <p>
        <input mkv="true" id="DENNGAY" type="text" onblur="$.TestDate(this);"  style="width:50%"/>
        <input mkv="true" id="DENGIO" type="text" style="width:60px;"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SOPHIEUYC")%>
     </h4>
     <p>
        <input mkv="true" id="SOPHIEUYC" onfocus='Find(this);' type="text" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("KHOYC")%>
     </h4>
     <p>
        <select mkv="true" id="KHOYC" style="width:90%;"></select>
        <%--<input mkv="true" id="Hidden1" type="hidden" />
        <input mkv="true" id="mkv_KHOYC" type="text" onfocus="Find(this);KHOYCSearch(this);" class="down_select" style="width:90%"/>--%>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IDTHUOC")%>
     </h4>
     <p>
        <input mkv="true" id="IDTHUOC" type="hidden" />
        <input mkv="true" id="mkv_IDTHUOC" type="text" onfocus="Find(this);IDTHUOCSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>
 <%--<div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TENDVT")%>
     </h4>
     <p>
        <input mkv="true" id="TENDVT" onfocus='Find(this);' type="text" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SOLUONGYC")%>
     </h4>
     <p>
        <input mkv="true" id="SOLUONGYC" type="text" onfocus='Find(this);' onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SOLUONGDUYET")%>
     </h4>
     <p>
        <input mkv="true" id="SOLUONGDUYET" type="text" onfocus='Find(this);' onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("THUCXUAT")%>
     </h4>
     <p>
        <input mkv="true" id="THUCXUAT" type="text" onfocus='Find(this);' onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ISDUYETPHAT")%>
     </h4>
     <p>
        <input mkv="true" id="ISDUYETPHAT" type="checkbox" />
     </p>
 </div>--%>
         </div></div>
 <div class="body-div-button">
             <p class="in-a">
                 <input  id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" 
                      />
                 <input  id="timKiem" search="<%=StaticData.HavePermision(this, "zKiemDuyet_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" 
                      />
             </p>
         <%--<a class="reload" onclick="Find(this)"></a>--%>
         <div  class="in-b" style="top:0px;" id="tableAjax_zKiemDuyet">
         </div>
         </div>
 </asp:Content>
