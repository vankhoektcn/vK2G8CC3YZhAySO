<%@ Page Language="C#" MasterPageFile="~/QLDUOC/MasterPage_new.master" AutoEventWireup="true"
    CodeFile="phieuxuatkho1_2.aspx.cs" Inherits="phieuxuatkho1_2" Title="phieuxuatkho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/phieuxuatkho1.js"></script>

    <script src="../../noitru/js/nvk_DateTime.js" type="text/javascript"> </script>

    <style type="text/css">
    .div-Out
    {
        width:30%;
    }
    </style>

    <script type="text/javascript">
    function idLoaiTraSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/nvk_frmNhanDu_TT_ajax.aspx?do=loaitrasearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"Loại Trả",
             //triggerDelete:"xoaloadsaukho()",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 $("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
    function ViewDetail_PhieuNhapTra(control,idphieunhap,page) {
      if(page == null)page = "1";
      $(control).TimKiem({
             ajax:"../ajax/phieuxuatkho_ajax1.aspx?do=ChiTiet_PhieuNhapTra&idphieunhap="+idphieunhap+"",width:"1000"
       },null,function(data){
            if(data==null || data==""){
                $.mkv.closeDivTimKiem();
            }
       });
    }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH SÁCH PHIẾU XUẤT TRẢ")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Số phiếu trả")%>
                </h4>
                <p>
                    <input mkv="true" id="SOPHIEUYC" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Từ ngày")%>
                </h4>
                <p>
                    <input mkv="true" id="tungay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đến ngày")%>
                </h4>
                <p>
                    <input mkv="true" id="denngay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho xuất trả")%>
                </h4>
                <p>
                    <input mkv="true" id="idkho" type="hidden" />
                    <input mkv="true" id="mkv_idkho" type="text" onfocus="Find(this);chuyenphim(this);idkhoSearch(this);"
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
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Loại trả")%>
                </h4>
                <p>
                    <input mkv="true" id="LoaiTraID" type="hidden" />
                    <input mkv="true" id="mkv_LoaiTraID" type="text" onfocus="Find(this);chuyenphim(this);idLoaiTraSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên thuốc")%>
                </h4>
                <p>
                    <input mkv="true" id="tenthuoc" type="hidden" />
                    <input mkv="true" id="mkv_tenthuoc" type="text" style="width: 90%" onfocus="idthuocSearch(this);chuyenphim(this);"
                        class="down_select" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                </h4>
                <p>
                    <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
                    <input id="nvk_timKiem" onclick="nvk_timKiemPhieuNhapTra(this)" search="<%=StaticData.HavePermision(this, "phieuxuatkho_Search") %>"
                        type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
                </p>
            </div>
        </div>
        <div class="in-b" id="tableAjax_phieuxuatkho">
        </div>
    </div>
</asp:Content>
