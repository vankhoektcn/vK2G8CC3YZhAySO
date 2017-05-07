<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="phieuxuatkho3.aspx.cs" Inherits="phieuxuatkho" Title="phieuxuatkho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/phieuxuatkho3.js">
    </script>

    <style>
    .div-Out
    {
        width:350px;
    }
</style>

    <script type="text/javascript">
function externalLinks()
{
  if (!document.getElementsByTagName) return;
  var anchors = document.getElementsByTagName("input");
  for (var i=0; i<anchors.length; i++)
  {
      var anchor = anchors[i];
      if(anchor.getAttribute("href"))
		anchor.target = "_blank";
  }
}
window.onload = externalLinks;

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("PHIẾU XUẤT CHUYỂN KHO")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("maphieuxuat")%>
                </h4>
                <p>
                    <input mkv="true" id="maphieuxuat" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythang")%>
                </h4>
                <p>
                    <input mkv="true" id="ngaythang" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width:40%" />
                        <input mkv="true" id="gio" type="text" style="width: 8%" onfocus="chuyenphim(this);" />:
                    <input mkv="true" id="phut" type="text" style="width: 8%" onfocus="chuyenphim(this);" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu")%>
                </h4>
                <p>
                    <input mkv="true" id="ghichu" type="hidden" />
                    <input mkv="true" id="mkv_ghichu" type="text" onfocus="Find(this);chuyenphim(this);ghichuSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho xuất")%>
                </h4>
                <p>
                    <input mkv="true" id="idkho" type="hidden" />
                    <input mkv="true" id="mkv_idkho" type="text" onfocus="Find(this);chuyenphim(this);idkhoSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idkho2")%>
                </h4>
                <p>
                    <input mkv="true" id="idkho2" type="hidden" />
                    <input mkv="true" id="mkv_idkho2" type="text" onfocus="Find(this);chuyenphim(this);idkho2Search(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdLoaiThuoc")%>
                </h4>
                <p>
                    <input mkv="true" id="IdLoaiThuoc" type="hidden" />
                    <input mkv="true" id="mkv_IdLoaiThuoc" type="text" onfocus="Find(this);chuyenphim(this);IdLoaiThuocSearch(this);"
                        class="down_select" style="width: 90%" />
                         <input type="hidden" id="IDPHIEUYC" mkv="true" />
                        <input type="hidden" id="IDPHIEUYCTRA" mkv="true" />
                </p>
            </div>
            <div class="div-Out" >
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Phiếu YC.Xuất")%>
                </h4>
                <p>
                    <input mkv="true" id="SOPHIEUYC" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                        
                </p>
            </div>
            <div class="div-Out" >
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Phiếu YC.Trả")%>
                </h4>
                <p>
                    <input mkv="true" id="SoPhieuYCTra" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                        
                </p>
            </div>
           <%-- <div class="div-Out" id="Div1">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Số thứ tự")%>
                </h4>
                <p>
                    <input mkv="true" id="SOTT" type="text" onfocus="Find(this);chuyenphim(this);" style="width: 90%;"
                        disabled />
                </p>
            </div>--%>
            <div class="div-Out">
                <h4>
                </h4>
                <p>
                    <input id="TimMoi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tìm mới") %>" />
                    <input id="timKiem" search="<%=Userlogin_new.HavePermision(this, "phieuxuatkho_Search") %>"
                        type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
                       
                </p>
            </div>
        </div>
        <a class="reload" onclick="loadTableAjaxHS_OutPutDetail($.mkv.queryString('idkhoachinh'))">
        </a>
        <div id="tableAjax_HS_OutPutDetail" class="in-b">
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="<%=Userlogin_new.HavePermision(this, "phieuxuatkho_Edit") %>"
                add="<%=Userlogin_new.HavePermision(this, "phieuxuatkho_Add") %>" type="button"
                accesskey="L" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>"
                accesskey="M" />
            <input id="xoa" delete="<%=Userlogin_new.HavePermision(this, "phieuxuatkho_Delete") %>"
                type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>"
                accesskey="X" />
            <input id="ViewDetail" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Detail") %>"
                accesskey="C" />
            <input id="PrintBienBan" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("In biên bản") %>"
                style="display: none;" accesskey="P" />
            <input id="Button1" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("In Phiếu Xuất") %>"
                style="width: 12%" onclick="InPhieuXuat();" accesskey="I" />
        </p>
    </div>
</asp:Content>
