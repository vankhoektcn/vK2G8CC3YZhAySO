<%@ Page Language="C#" MasterPageFile="~/ketoan/MasterPage_KT.master"AutoEventWireup="true" CodeFile="KTDM_DanhMucKhoa.aspx.cs" Inherits="KTDM_DanhMucKhoa" Title="phongkhambenh" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_HeThongDanhMuc.ascx"TagName="uscmenuKT_HeThongDanhMuc"
   TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <script type="text/javascript" src="../../js/jquery.autocomplete.new.js"></script>
    <script type="text/javascript" src="javascript/KTDM_DanhMucKhoa.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
    <div class="div-Right">
        <uc1:uscmenuKT_HeThongDanhMuc ID="UscmenuKT_HeThongDanhMuc1" runat="server" />
    </div>
        <p class="header-div">        
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("phongkhambenh")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("maphongkhambenh")%>
                </h4>
                <p>
                    <input mkv="true" id="maphongkhambenh" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tenphongkhambenh")%>
                </h4>
                <p>
                    <input mkv="true" id="tenphongkhambenh" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("truongphong")%>
                </h4>
                <p>
                    <input mkv="true" id="truongphong" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("loaiphong")%>
                </h4>
                <p>
                    <input mkv="true" id="loaiphong" type="text" onfocus="Find(this);chuyenphim(this);"
                        onblur="TestSo(this,false,true);" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tkdoanhthu")%>
                </h4>
                <p>
                    <input mkv="true" id="tkdoanhthu" type="hidden" />
                    <input mkv="true" id="mkv_tkdoanhthu" type="text" onfocus="Find(this);chuyenphim(this);tkdoanhthuSearch(this)"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tkchiphi")%>
                </h4>
                <p>
                    <input mkv="true" id="tkchiphi" type="hidden" />
                    <input mkv="true" id="mkv_tkchiphi" type="text" onfocus="Find(this);chuyenphim(this);tkchiphiSearch(this)"
                        style="width: 90%" />
                </p>
            </div>            
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="<%=StaticData.HavePermision(this, "phongkhambenh_Edit") %>"
                add="<%=StaticData.HavePermision(this, "phongkhambenh_Add") %>" type="button"
                value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" delete="<%=StaticData.HavePermision(this, "phongkhambenh_Delete") %>"
                type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
            <input id="timKiem" search="<%=StaticData.HavePermision(this, "phongkhambenh_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
        <div class="in-b" id="tableAjax_phongkhambenh">
        </div>
    </div>
</asp:Content>
