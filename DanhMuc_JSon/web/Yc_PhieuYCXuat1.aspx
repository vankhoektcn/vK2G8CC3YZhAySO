<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="Yc_PhieuYCXuat1.aspx.cs" Inherits="Yc_PhieuYCXuat" Title="Yc_PhieuYCXuat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/Yc_PhieuYCXuat1.js">
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
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH SÁCH PHIẾU YÊU CẦU LÃNH")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TuNgay")%>
                </h4>
                <p>
                    <input mkv="true" id="TuNgay" type="text" onfocus='Find(this);' onblur="$.TestDate(this);"
                        style="width: 75px" />
                    <input mkv="true" id="TuGio" type="text" style="width: 20px;" />:
                    <input mkv="true" id="TuPhut" type="text" style="width: 20px;" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DenNgay")%>
                </h4>
                <p>
                    <input mkv="true" id="DenNgay" type="text" onfocus='Find(this);' onblur="$.TestDate(this);"
                        style="width: 75px" />
                    <input mkv="true" id="DenGio" type="text" style="width: 20px;" />:
                    <input mkv="true" id="DenPhut" type="text" style="width: 20px;" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho duyệt")%>
                </h4>
                <p>
                            <select id="IdKhoDuyet" mkv="true" onfocus="chuyenphim(this);" style="width: 90%;">
                        </select>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho yêu cầu")%>
                </h4>
                <p>
                             <select id="IdKhoYc" mkv="true" onfocus="chuyenphim(this);" style="width: 90%;">
                        </select>
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
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SoPhieuYc")%>
                </h4>
                <p>
                    <input mkv="true" id="SoPhieuYc" onfocus='Find(this);' type="text" style="width: 90%;"   />
                    
                </p>
            </div>
             <div class="div-Out" style="width:500px">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdThuoc")%>
                </h4>
                <p  >
                    <input mkv="true" id="IdThuoc" type="hidden" />
                   <input mkv="true" id="mkv_IdThuoc" type="text" onfocus="Find(this);chuyenphim(this);TenThuocSearch(this);"
                        style="width: 90%" class="down_select" />
                </p>
            </div>
       
            
            <div class="div-Out" style="width:700px">
                <p style="width:100%">
                    
                    <input id="timKiem" search="<%=Userlogin_new.HavePermision(this, "Yc_PhieuYCXuat_Search") %>"
                        type="button" style="width:150px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
                    <input id="new" search="<%=Userlogin_new.HavePermision(this, "Yc_PhieuYCXuat_Add") %>"
                        type="button"   style="width:150px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Phiếu mới-YC lẻ") %>" />
                        <input id="new_TheoCD" search="<%=Userlogin_new.HavePermision(this, "Yc_PhieuYCXuat_Add") %>"
                        type="button" style="width:150px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Phiếu mới-YC theo CĐ") %>" />
                        <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tìm mới") %>" style="display:none" />
                    <input mkv="true" id="perDuyetPhat" type="hidden" value="0" />
                </p>
            </div>
        </div>
    </div>
    Lưu ý: Bạn muốn lập yêu cầu lãnh dựa theo những chỉ định đã có, hãy chọn Phiếu mới- Theo CĐ
    <p>
    Trường hợp lập yêu cầu theo kho bệnh nhân, bắt buộc phải chọn Phiếu mới- Theo CĐ 
    </p>
    <div class="body-div-button">
        <div class="in-b" id="tableAjax_Yc_PhieuYCXuat">
        </div>
    </div>
</asp:Content>
