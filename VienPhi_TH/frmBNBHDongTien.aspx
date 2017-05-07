<%@ Page Language="C#" MasterPageFile="~/VienPhi_TH/Page.master" AutoEventWireup="true"
    CodeFile="frmBNBHDongTien.aspx.cs" Inherits="VienPhi_TH_frmBNBHDongTien" Title="Danh sách bệnh nhân " %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="javascript/bnbhdongtien.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Danh sách bệnh nhân đóng tiền")%>
        </p>
        <div class="in-a">
            <div class="div-Out" style="width: 15%;">
                <h4>
                    Từ ngày
                </h4>
                <p>
                    <input type="text" id="tungay" mkv="true" onfocus="chuyenphim(this);" style="width: 70%;" />
                </p>
            </div>
            <div class="div-Out" style="width: 15%;">
                <h4>
                    Đến ngày
                </h4>
                <p>
                    <input type="text" id="denngay" mkv="true" onfocus="chuyenphim(this);" style="width: 70%;" />
                </p>
            </div>
            <div class="div-Out" onfocus="chuyenphim(this);">
                <h4>
                    Mã bệnh nhân
                </h4>
                <p>
                    <input type="text" id="mabn" mkv="true" />
                </p>
            </div>
            <div class="div-Out" onfocus="chuyenphim(this);" style="width: 38%;">
                <h4>
                    Họ tên bệnh nhân
                </h4>
                <p style="width: 70%">
                    <input type="text" id="hotenbn" mkv="true" />
                    <input type="button" id="layds" value="Lấy danh sách" />
                    <input type="hidden" id="userid" value="<%=SysParameter.UserLogin.UserID(this) %>"
                        mkv='true' />
                </p>
            </div>
        </div>
        <div id="tableAjax_Z_BENHNHANBHDT">
        </div>
    </div>
</asp:Content>
