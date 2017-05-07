<%@ Page Language="C#" MasterPageFile="MasterPageBNNV.master" AutoEventWireup="true"
    CodeFile="dangkykham3.aspx.cs" Inherits="dangkykham" Title="dangkykham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script language="javascript">
   
     function InPhieuDangKy()
	{
	   $.get("ajax.aspx?do=InPhieuDangKyNhieuChuyenKhoa&IdDangKyKham="+$.mkv.queryString("idkhoachinh"),function(data){
                    window.open(" frm_rpt_InPhieuThuTH.aspx?MaPhieuCLS=" + $.mkv.queryString("idkhoachinh") + "&LoaiThu=PhiKham&MaPhieu=" + data + "&InTrucTiep=1",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');  
                 });
       
	}
    </script>

    <script type="text/javascript" src="js/myscript_new.jqr.js">
    </script>

    <script type="text/javascript" src="javascript/dangkykham3.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ĐĂNG KÝ KHÁM")%>
        </p>
        <div class="in-a" id="abc">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Mã BN")%>
                </h4>
                <p>
                    <input type="hidden" id="maphieudangky" mkv="true" />
                    <input mkv="true" id="mabenhnhan" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Bệnh nhân")%>
                </h4>
                <p>
                    <input mkv="true" id="idbenhnhan" type="hidden" />
                    <input mkv="true" id="mkv_idbenhnhan" type="text" onfocus="Find(this);chuyenphim(this);idbenhnhanSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày ĐK")%>
                </h4>
                <p>
                    <input mkv="true" id="ngaydangky" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);"  style="width:70px" />
                        <input mkv="true" id="giodk" type="text"   style="width:20px" />
                        <input mkv="true" id="phutdk" type="text"  style="width:20px" />
                        <input mkv="true" id="giaydk" type="text"  style="width:20px" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Người thu")%>
                </h4>
                <p>
                    <input mkv="true" id="idnguoidung" type="hidden" />
                    <input mkv="true" id="mkv_idnguoidung" type="text" onfocus="Find(this);chuyenphim(this);idnguoidungSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div id="chonbhyt">
                <div class="div-Out">
                    <h4>
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Chọn BHYT")%>
                    </h4>
                    <p>
                        <input mkv="true" id="IDBENHNHAN_BH" type="hidden" />
                        <input mkv="true" id="mkv_IDBENHNHAN_BH" type="text" onfocus="chuyenphim(this);IDBENHNHAN_BHSearch(this);"
                            class="down_select" style="width: 90%" />
                    </p>
                </div>
                <div class="div-Out" ">
                    <h4>
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Loại ĐK khám")%>
                    </h4>
                    <p>
                        <input mkv="true" id="LoaiKhamID" type="hidden" />
                        <input mkv="true" id="mkv_LoaiKhamID" type="text" onfocus="chuyenphim(this);LoaiKhamIDsearch(this);"
                            class="down_select" style="width: 90%" />
                    </p>
                </div>
                <div class="div-Out">
                    <h4>
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày trình thẻ")%>
                    </h4>
                    <p>
                        <input mkv="true" id="NGAYTRINHTHE" type="text" onfocus="Find(this);chuyenphim(this);$(this).validDate();"
                            style="width: 60%" />
                         <input mkv="true" id="giott" type="text"   style="width:20px" />
                        <input mkv="true" id="phuttt" type="text"  style="width:20px" />
                    </p>
                </div>
                <div class="div-Out">
                    <h4 id="dsPhong">
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("(*)Lưu ý: Các phòng đã đăng ký trong ngày : ")%>
                    </h4>
                </div>
            </div>
        </div>
        <a class="reload" onclick="loadTableAjaxchitietdangkykham($.mkv.queryString('idkhoachinh'))">
        </a>
        <div id="tableAjax_chitietdangkykham" class="in-b">
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu1" edit="true" add="true" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" delete="<%=Userlogin_new.HavePermision(this, "dangkykham_Delete") %>"
                type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
            <input id="dangkyCLS" type="button" value="Đăng ký CLS" />
            <input id="btnInPhieu" class="button" type="button" value="In phiếu" />
            <input id="tinhlaitien" type="button" value="Tính lại tiền" onclick="tinhlaitien_function();" />
        </p>
    </div>
</asp:Content>
