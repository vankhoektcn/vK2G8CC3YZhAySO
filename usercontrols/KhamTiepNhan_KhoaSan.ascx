<%@ Control Language="C#" AutoEventWireup="true" CodeFile="KhamTiepNhan_KhoaSan.ascx.cs"
    Inherits="usercontrols_KhoaSan_KhamTiepNhan" %>
<script type="text/javascript" src="../js/script.js">
</script>
<script type="text/javascript" src="../javascript/KhamTiepNhanKhoaSan.js">
</script>

<style type="text/css">
    #style1
    {
        width: 30%;
        font-weight: bold;
    }
    #style2
    {
        width: 40%;
        font-weight: bold;
    }
    .style3
    {
        width: 40%;
        
    }
    #gridTable.jtable tr th
    {
    	padding: 8px 1px 4px 1px;
    	width:20px;
    	text-align:center;
    }
    table.jtable tr td
    {
    	padding: 8px 1px 4px 1px;
    	text-align:center;
    }
</style>
<div class="body-div" style="margin-top: -85px; border-top: none">
    <div class="header-div">
    KHÁM SẢN
        <%--<%=hsLibrary.clDictionaryDB.sGetValueLanguage("capcuu_khambenh")%>--%>
    </div>
    
    <div class="in-a" style="padding-top: 100px;">
        <input mkv="true" clearVal="false" type="hidden" id="idbenhnhan" />
        <input mkv="true" clearVal="false" type="hidden" id="IdChiTietDangKyKham" />
        <input mkv="true" clearVal="false" type="hidden" id="idphongkhambenh" />
        <input mkv="true" clearVal="false" type="hidden" id="iddangkykham" />
        <div class="div-Out" style="margin-top:-20px;width: 300px;padding:0px 0px 140px 0px;float:right;background:none;border:none;">
                    <table style="width: 85%;" class="jtable">
                        <tr>
                            <th colspan="3" align="center">
                                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("thongtinsinhhieu")%>
                            </th>
                        </tr>
                        <tr>
                            <td class="style1">
                                Mạch
                            </td>
                            <td class="style3">
                                <span mkv="true" id="MACH"></span>
                                
                            </td>
                            <td>
                                lần/ph
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                Huyết áp
                            </td>
                            <td class="style3">
                                <span mkv="true" id="HUYETAP"></span>
                                
                            </td>
                           <td>mmHg</td>
                        </tr>
                         <tr>
                            <td class="style1">
                                Nhiệt độ
                            </td>
                            <td>
                                <span mkv="true" id="NHIETDO"></span>
                                
                            </td>
                            <td>độ C</td>
                        </tr>
                        <tr>
                             <td class="style1">
                                Nhịp thở
                            </td>
                            <td>
                                <span mkv="true" id="NHIPTHO"></span>
                                
                            </td>
                            <td>lần/ph</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                Cân nặng
                            </td>
                            <td class="style3">
                                <span mkv="true" id="CANNANG"></span>
                                
                            </td>
                            <td>kg</td>
                        </tr>
                        
                    </table>
            </div>
        <div class="div-Out" style="width: 300px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TENKHOA")%>
            </div>
            <div class="div-Right">
                <span mkv="true" id="TENKHOA" type="text" onfocus="chuyenphim(this);" style="width: 90%">
                </span>
            </div>
        </div>
        <div class="div-Out" style="width: 320px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TENPHONG")%>
            </div>
            <div class="div-Right">
                <span mkv="true" id="TENPHONG" type="text" onfocus="chuyenphim(this);" style="width: 90%">
                </span>
            </div>
        </div>
        <div class="div-Out" style="width: 640px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SOVAOVIEN")%>
            </div>
            <div class="div-Right" style="width:75%">
                <span mkv="true" id="sovaovien" type="text" onfocus="chuyenphim(this);" style="width: 90%">
                </span>
            </div>
        </div>
        <div class="div-Out" style="width: 640px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TENBENHNHAN")%>
            </div>
            <div class="div-Right" style="width:75%">
                <span mkv="true" id="TENBENHNHAN" type="text" onfocus="chuyenphim(this);" style="width: 90%">
                </span>
            </div>
        </div>
        <div class="div-Out" style="width: 640px">
            <div class="div-Left">
                Mã bệnh nhân
            </div>
            <div class="div-Right" style="width:75%">
                <span mkv="true" id="mabenhnhan" type="text" onfocus="chuyenphim(this);" style="width: 90%">
                </span>
            </div>
        </div>
        <div class="div-Out" style="width: 300px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NGAYSINH")%>
            </div>
            <div class="div-Right">
                <span mkv="true" id="NGAYSINH" type="text" onfocus="chuyenphim(this);" style="width: 90%">
                </span>
            </div>
        </div>
        <div class="div-Out" style="width: 320px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("GIOITINH")%>
            </div>
            <div class="div-Right">
                <span mkv="true" id="GIOITINH" type="text" onfocus="chuyenphim(this);" style="width: 90%">
                </span>
            </div>
        </div>
        <div class="div-Out" style="width:940px">
            <div class="div-Left">
            Triệu chứng
            </div>
            <div class="div-Right" style="width:85.3%">
                <input mkv="true" id="trieuchung" type="text" onfocus="chuyenphim(this);" style="width: 90%" />
            </div>
        </div>
        <div class="div-Out" style="width:940px">
            <div class="div-Left">
            Bệnh sử
            </div>
            <div class="div-Right" style="width:85.3%">
                <input mkv="true" id="benhsu" type="text" onfocus="chuyenphim(this);" style="width: 90%" />
            </div>
        </div>
        <div class="div-Out" style="width:940px">
            <div class="div-Left">
            Chuẩn đoán ban đầu
            </div>
            <div class="div-Right" style="width:85.3%">
                <input mkv="true" id="chandoanbandau" type="text" onfocus="chuyenphim(this);" style="width: 90%" />
            </div>
        </div>
         <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("huongdieutri")%>
            </div>
            <div class="div-Right">
                <input mkv="true" id="huongdieutri" type="hidden" />
                <input mkv="true" id="mkv_huongdieutri" type="text" onfocus="chuyenphim(this);huongdieutrisearch(this);"
                    class="down_select_hover" style="width: 90%" />
            </div>
        </div>
        <div id="loadsauhuongdieutri">
        </div>
        <div class="div-Out" style="width:940px">
            <div class="div-Left">
            Chuẩn đoán tuyến dưới
            </div>
            <div class="div-Right" style="width:85%">
                <input mkv="true" id="ChanDoanTuyenDuoi" type="hidden" />
                <select id="loaiicdTD" >
                    <option value="maicd">Mã ICD</option>
                    <option value="mota">Mô tả</option>
                </select>
                <input mkv="true" id="mkv_ChanDoanTuyenDuoi" type="text" onfocus="chuyenphim(this);chandoanbandausearch(this,'tuyenduoi');"
                    style="width: 70%" class="down_select_hover" />
            </div>
        </div>
         
        <div class="div-Out" style="width:940px">
            <div class="div-Left">
            Chuẩn đoán xác định
            </div>
            <div class="div-Right" style="width:85.3%">
                <input mkv="true" id="ketluan" type="hidden" />
                <select id="loaiicd" >
                    <option value="maicd">Mã ICD</option>
                    <option value="mota">Mô tả</option>
                </select>
                <input mkv="true" id="mkv_ketluan" type="text" onfocus="chuyenphim(this);chandoanbandausearch(this,'xacdinh');"
                    style="width: 70%" class="down_select_hover" />
            </div>
        </div>
        <div class="div-Out" style="width:940px">
            <div class="div-Left">
            Chuẩn đoán phối hợp
            </div>
            <div class="div-Right" style="width:85.3%">
                <input mkv="true" id="Hidden1" type="hidden" />
                <select id="loaiphoihop" >
                    <option value="maicd">Mã ICD</option>
                    <option value="mota">Mô tả</option>
                </select>
                <input mkv="true" id="Text1" type="text" onfocus="chuyenphim(this);chandoanbandausearch(this,'phoihop');"
                    style="width: 70%" class="down_select_hover" />
            </div>
        </div>
       <div id="tableAjax_chandoanphoihop">
            
       </div>
           <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idbacsi")%>
            </div>
            <div class="div-Right">
                <input mkv="true" id="idbacsi" type="hidden" />
                <input mkv="true" id="mkv_idbacsi" type="text" onfocus="chuyenphim(this);idbacsisearch(this);"
                    class="down_select_hover" style="width: 90%" />
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left" style="display:none">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("giuong")%>
            </div>
            <div class="div-Right" style="display:none">
                <input mkv="true" id="giuong" type="hidden" />
                <input mkv="true" id="mkv_giuong" type="text" onfocus="chuyenphim(this);giuongsearch(this);"
                    class="down_select_hover" style="width: 50%" />
                <input mkv="true" id="giagiuong" type="text" onfocus="chuyenphim(this);" style="width: 30%;
                    text-align: right" />
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("iddieuduong")%>
            </div>
            <div class="div-Right">
                <input mkv="true" id="IdDieuDuong" type="hidden" />
                <input mkv="true" id="mkv_IdDieuDuong" type="text" onfocus="chuyenphim(this);IdDieuDuongsearch(this);" class="down_select_hover" style="width: 90%;" />
            </div>
        </div>
        <div class="div-Out" style="width: 96%">
        <div class="div-Left" style="text-transform: uppercase">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("choncanlamsan")%>
        </div>
        <div class="div-Right" style="width: 80%;">
            <input type="button" value="Chọn cận lâm sàn" onclick="ChonCLS(this);" style="width: auto" />
        </div>
    </div>
    </div>
    
    <div>
        <div style="margin: 10px auto 10px auto; background: #fff; text-align: center;
            width: 100%; padding: 5px 0px 5px 0px; border: 1px solid #f0e5b4" >
            <a onclick="slideCLS(this);" style="cursor: pointer">
            <img src="../images/desc.gif" alt="" />
            Ẩn CLS
            </a>
            </div>

        <script type="text/javascript">
                    function slideCLS(obj) {
                        if ($("#tableAjax_khambenhcanlamsan").is(":hidden")) {
                          $(obj).html("<img src='../images/desc.gif'/>Ẩn CLS");
                          $("#tableAjax_khambenhcanlamsan").show("slow");
                        } else {
                            $(obj).html("<img src='../images/asc.gif'/>Hiện CLS");
                          $("#tableAjax_khambenhcanlamsan").slideUp();
                        }
                    }
        </script>

    </div>
    <div id="tableAjax_khambenhcanlamsan" class="in-b">
    </div>
    <div>
        <div style="margin:auto auto 10px auto; background: #fff; text-align: center;
            width: 100%; padding: 5px 0px 5px 0px; border: 1px solid #f0e5b4" >
            <a onclick="slideToathuoc(this);" style="cursor: pointer">
            <img src="../images/desc.gif" alt="" />
            Ẩn Thuốc
            </a>
            </div>

        <script type="text/javascript">
                    function slideToathuoc(obj) {
                        if ($("#tableAjax_chitietbenhnhantoathuoc").is(":hidden")) {
                          $(obj).html("<img src='../images/desc.gif'/>Ẩn Thuốc");
                          $("#tableAjax_chitietbenhnhantoathuoc").show("slow");
                        } else {
                            $(obj).html("<img src='../images/asc.gif'/>Hiện Thuốc");
                          $("#tableAjax_chitietbenhnhantoathuoc").slideUp();
                        }
                    }
        </script>

    </div>
<div id="tableAjax_chitietbenhnhantoathuoc" class="in-c">
</div>
<div id="PopUpTamUng" class="in-c">
</div>
</div>
<%--<table id="TableTamUng" width="100%" border="0">
    <tr><td id="PopUpTamUng"></td></tr>
    </table>--%>
    
<div class="body-div-button">
    <div class="in-a">
    
        <input id="luu" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
        <input id="TamUng" style="display:none" type="button" value="Tạm ứng" />
        <input id="moi" style="display:none" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
        <input id="xoa" type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
        <input id="intoathuoc" type="button"  value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("intoathuoc") %>" />
        <input id="incls" type="button"  value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("incls") %>" />
        <input id="ingiaychuyenvien" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("ingiaychuyenvien") %>" />
    </div>
</div>
