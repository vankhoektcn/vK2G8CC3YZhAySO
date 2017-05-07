<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="Yc_PhieuYCTra3.aspx.cs" Inherits="Yc_PhieuYCTra" Title="Yc_PhieuYCTra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/Yc_PhieuYCTra3.js">
    </script>

    <style type="text/css">
     .div-Out{
        width: 325px;
     }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("PHIẾU YÊU CẦU TRẢ")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SoPhieuYc")%>
                </h4>
                <p>
                    <input mkv="true" id="SoPhieuYc" onfocus='Find(this);' type="text" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày YC")%>
                </h4>
                <p>
                    <input mkv="true" id="NgayYc" isget="true" type="text" style="width: 80px;" onfocus='Find(this);'
                        onblur="$.TestDate(this);" />
                    <input mkv="true" id="GioYc" type="text" style="width: 20px;" />:
                    <input mkv="true" id="PhutYC" type="text" style="width: 20px;" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdKhoYc")%>
                </h4>
                <p>
                      <select id="IdKhoYc" mkv="true" onfocus="chuyenphim(this);" style="width: 90%;">
                    </select>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdKhoDuyet")%>
                </h4>
                <p>
                      <select id="IdKhoDuyet" mkv="true" onfocus="chuyenphim(this);" style="width: 90%;">
                    </select>
                </p>
            </div>
        
            <div class="div-Out">
                <h4>
                   </h4>
                <p>
                    Duyệt trả
                    <input mkv="true" id="IsDuyetTra" disabled="disabled" type="checkbox" />
                    Trả tiền BN?
                    <input mkv="true" id="IsTraTienBN"  type="checkbox" />
                    
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    Phiếu xuất
                </h4>
                <p>
                    <input mkv="true" id="maphieuxuat" onfocus='Find(this);' type="text" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đối tượng")%>
                </h4>
                <p>
                          <select id="LoaiThuocID" mkv="true" onfocus="chuyenphim(this);" style="width: 80%;">     </select>

                </p>
            </div>
            <div class="div-Out" style="width: 650px;">
     <p style="width: 650px;">
        Từ ngày :
        <input mkv="true" id="TuNgay" isGet="true" type="text" style="width:80px;margin-left: 25px;" onfocus='Find(this);' onblur="$.TestDate(this);" />
        <input mkv="true" id="TuGio"  type="text" style="width:20px;" />:
        <input mkv="true" id="TuPhut"  type="text" style="width:20px;" />
        Đến ngày :
        <input mkv="true" id="DenNgay" isGet="true" type="text" style="width:80px;" onfocus='Find(this);' onblur="$.TestDate(this);" />
        <input mkv="true" id="DenGio"  type="text" style="width:20px;" />:
        <input mkv="true" id="DenPhut"  type="text" style="width:20px;" />
        <input mkv="true" id="btngetList" value="Lấy Danh Sách" type="button" style="width: 110px;margin-left:10px;"/>
     </p>
       
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày Duyệt")%>
     </h4>
     <p>
        <input mkv="true" id="NgayDuyet" isGet="true" type="text" style="width:80px;" onfocus='Find(this);' onblur="$.TestDate(this);" />
        <input mkv="true" id="GioDuyet"  type="text" style="width:20px;" />:
        <input mkv="true" id="PhutDuyet"  type="text" style="width:20px;" />
     </p>
 </div>
 
            <input mkv="true" id="perDuyetTra" type="hidden" value="0" />
             
        </div>
        <a id="reload" class="reload" onclick="loadTableAjaxYc_PhieuYcTraChiTiet($.mkv.queryString('idkhoachinh'))">
        </a>
        <br />
        <div id="tableAjax_Yc_PhieuYCTraChiTiet" class="in-b">
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="<%=Userlogin_new.HavePermision(this, "Yc_PhieuYCTra_Edit") %>"
                add="<%=Userlogin_new.HavePermision(this, "Yc_PhieuYCTra_Add") %>" type="button"
                value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " style="<%=Userlogin_new.HavePermision(this, "yc_phieuyctra_add")?"": "display:none" %>" />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" delete="<%=Userlogin_new.HavePermision(this, "Yc_PhieuYCTra_Delete") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>"
                style="<%=Userlogin_new.HavePermision(this, "yc_phieuyctra_delete")?"": "display:none" %>" />
            <input id="btnprint" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("print") %>"
                 />
            <input id="btnDuyetTra" type="button" value="Duyệt Trả" style="<%=Userlogin_new.HavePermision(this, "xetduyet1")?"": "display:none" %>" />
            <input id="btnHuyDuyetTra" type="button" value="Hủy Duyệt Trả" style="width: 110px;
                <%=Userlogin_new.HavePermision(this, "xetduyet1")?"": "display:none" %>" />
            <input mkv="true" id="perDuyetIn" type="hidden" value="0" />
            <input  id="Thoat" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Thoát") %>"                   />
        </p>
    </div>
</asp:Content>
