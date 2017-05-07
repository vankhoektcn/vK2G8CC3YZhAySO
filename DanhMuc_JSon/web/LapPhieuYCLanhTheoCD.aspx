<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="LapPhieuYCLanhTheoCD.aspx.cs" Inherits="LapPhieuYCLanhTheoCD" Title="LẬP PHIẾU YÊU CẦU LÃNH THEO CHỈ ĐỊNH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">


    <script type="text/javascript" src="../javascript/LapPhieuYCLanhTheoCD.js">
    </script>

    <style type="text/css">
        .div-Out
        {
            width:22%;
        }
        table.jtable tr th 
        {
            background: #C1DAFE;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("LẬP PHIẾU YÊU CẦU LÃNH THEO CHỈ ĐỊNH")%>
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
                        onblur="$.TestDate(this);ChangeNgayYc(this);" />
                    <input mkv="true" id="GioYc" type="text" style="width: 20px;" />:
                    <input mkv="true" id="PhutYC" type="text" style="width: 20px;" />
                </p>
            </div>
            <div class="div-Out" ">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho YC")%>
                </h4>
                <p>
                    <select id="IdKhoYc" mkv="true" style="width: 90%">
                    </select>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đối tượng")%>
                </h4>
                <p>
                    <select id="LoaiThuocID" mkv="true" onfocus="chuyenphim(this);" style="width: 90%;">
                    </select>
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
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày Duyệt")%>
                </h4>
                <p>
                    <input mkv="true" id="NgayDuyet" isget="true" type="text" style="width: 80px;" onfocus='Find(this);'
                        onblur="$.TestDate(this);" />
                    <input mkv="true" id="GioDuyet" type="text" style="width: 20px;" />:
                    <input mkv="true" id="PhutDuyet" type="text" style="width: 20px;" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Từ ngày")%>
                </h4>
                <p>
                    <input mkv="true" id="TuNgay" type="text" style="width: 50%" onfocus="$(this).datepick();" />
                    <input mkv="true" id="TuGio" type="text" style="width: 20px;" />:
                    <input mkv="true" id="TuPhut" type="text" style="width: 20px;" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đến ngày")%>
                </h4>
                <p>
                    <input mkv="true" id="DenNgay" type="text" style="width: 50%" onfocus="$(this).datepick();" />
                    <input mkv="true" id="DenGio" type="text" style="width: 20px;" />:
                    <input mkv="true" id="DenPhut" type="text" style="width: 20px;" />
                </p>
            </div>
          
            <div class="div-Out">
                <h4>
                Dự trù? <input id="IsDuTru" mkv="true"  type="checkbox">
                <input type="hidden" id="IdPhieuYc" value="" />
                    
                </h4>
                <p>
                <input id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Lấy DS") %>" />
            <input type="hidden" id="perLuu" value="1"  mkv='true' />
            <input type="hidden" id="perXoa" value="0"  mkv='true' />
            <input type="hidden" id="perPint" value="1" mkv='true' />
                </p>
            </div>
        </div>
        <div class="in-b" id="tableAjax_LapPhieuYCLanhTheoCD">
        </div>
        <div class="button_div">
            <input id="save" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Lưu") %>"
                onclick="CheckValidSaveYc();" />
            <input id="delete" style="display:none;" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Xóa") %>" onclick="DeletePhieuYCXuat();"  />
            <input id="PrintPhieuYCXuat" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("In phiếu") %>"
                onclick="PrintPhieuYCXuat_function();" />
            <input id="Exit" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Thoát") %>" />
            <input id="new" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
        </div>
    </div>
</asp:Content>
