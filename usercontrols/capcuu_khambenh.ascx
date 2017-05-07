<%@ Control Language="C#" AutoEventWireup="true" CodeFile="capcuu_khambenh.ascx.cs"
    Inherits="usercontrols_capcuu_khambenh" %>

<script type="text/javascript" src="../javascript/ChamSocCapCuu.js">
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
    <p class="header-div">
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("capcuu_khambenh")%>
    </p>
    <div style="margin: 70px auto 0 auto;height:30px;width:100%;">
        <div style="margin:auto;width:100%; background: #fff;text-align: center; padding: 5px 0px 5px 0px; border: 1px solid #f0e5b4" >
            <a onclick="slideDSKhamBenh(this);" style="cursor: pointer" id="dskhambenhslide_click">
            <img src="../images/desc.gif" alt="" />
            Ẩn DS Khám Bệnh
            </a>
            </div>

        <script type="text/javascript">
                    function slideDSKhamBenh(obj) {
                        if ($("#danhsachkhambenh_slide").is(":hidden")) {
                          $(obj).html("<img src='../images/desc.gif'/>Ẩn DS Khám Bệnh");
                          $("#danhsachkhambenh_slide").show("slow");
                        } else {
                            $(obj).html("<img src='../images/asc.gif'/>Hiện DS Khám Bệnh");
                          $("#danhsachkhambenh_slide").slideUp();
                        }
                    }
        </script>

    </div>
    <div id="danhsachkhambenh_slide">
    <div class="div-Out" style="width: 940px; padding-bottom: 0; background-color: #fff">
            <h4 style="font-weight: bold; font-size: 17px;text-transform:uppercase">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("danhsachkhambenh")%>
            </h4>
        </div>
        <div id="tableAjax_DSkhambenh">
        </div>
    </div>
    <div class="in-a" style="padding-top: 5px;">
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
            <h4>
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TENKHOA")%>
            </h4>
            <p>
                <span mkv="true" id="TENKHOA" type="text" onfocus="chuyenphim(this);" style="width: 90%">
                </span>
            </p>
        </div>
        <div class="div-Out" style="width: 320px">
            <h4>
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TENPHONG")%>
            </h4>
            <p>
                <span mkv="true" id="TENPHONG" type="text" onfocus="chuyenphim(this);" style="width: 90%">
                </span>
            </p>
        </div>
        <div class="div-Out" style="width: 640px">
            <h4>
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SOVAOVIEN")%>
            </h4>
            <p style="width:75%">
                <span mkv="true" id="sovaovien" type="text" onfocus="chuyenphim(this);" style="width: 90%">
                </span>
            </p>
        </div>
        <div class="div-Out" style="width: 640px">
            <h4>
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TENBENHNHAN")%>
            </h4>
            <p style="width:75%">
                <span mkv="true" id="TENBENHNHAN" type="text" onfocus="chuyenphim(this);" style="width: 90%">
                </span>
            </p>
        </div>
        <div class="div-Out" style="width: 640px">
            <h4>
                Mã bệnh nhân
            </h4>
            <p style="width:75%">
                <span mkv="true" id="mabenhnhan" type="text" onfocus="chuyenphim(this);" style="width: 90%">
                </span>
            </p>
        </div>
        <div class="div-Out" style="width: 300px">
            <h4>
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NGAYSINH")%>
            </h4>
            <p>
                <span mkv="true" id="NGAYSINH" type="text" onfocus="chuyenphim(this);" style="width: 90%">
                </span>
            </p>
        </div>
        <div class="div-Out" style="width: 320px">
            <h4>
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("GIOITINH")%>
            </h4>
            <p>
                <span mkv="true" id="GIOITINH" type="text" onfocus="chuyenphim(this);" style="width: 90%">
                </span>
            </p>
        </div>
        <div class="div-Out" style="width:940px">
            <h4>
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("trieuchung")%>
            </h4>
            <p style="width:85.3%">
                <input mkv="true" id="trieuchung" type="text" onfocus="chuyenphim(this);" style="width: 90%" />
            </p>
        </div>
         <div class="div-Out">
            <h4>
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("huongdieutri")%>
            </h4>
            <p>
                <input mkv="true" id="huongdieutri" type="hidden" />
                <input mkv="true" id="mkv_huongdieutri" type="text" onfocus="chuyenphim(this);huongdieutrisearch(this);"
                    class="down_select_hover" style="width: 90%" />
            </p>
        </div>
        <div id="loadsauhuongdieutri">
        </div>
         
        <div class="div-Out" style="width:940px">
            <h4>
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("chandoanbandau")%>
            </h4>
            <p style="width:85.3%">
                <input mkv="true" id="ketluan" type="hidden" />
                <select id="loaiicd" >
                    <option value="maicd">Mã ICD</option>
                    <option value="mota">Mô tả</option>
                </select>
                <input mkv="true" id="mkv_ketluan" type="text" onfocus="chuyenphim(this);chandoanbandausearch(this);"
                    style="width: 70%" class="down_select_hover" />
            </p>
        </div>
       
        
        <div class="div-Out">
            <h4>
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("giuong")%>
            </h4>
            <p>
                <input mkv="true" id="giuong" type="hidden" />
                <input mkv="true" id="mkv_giuong" type="text" onfocus="chuyenphim(this);giuongsearch(this);"
                    class="down_select_hover" style="width: 50%" />
                <input mkv="true" id="giagiuong" type="text" onfocus="chuyenphim(this);" style="width: 30%;
                    text-align: right" />
            </p>
        </div>
        <div class="div-Out">
            <h4>
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idbacsi")%>
            </h4>
            <p>
                <input mkv="true" id="idbacsi" type="hidden" />
                <input mkv="true" id="mkv_idbacsi" type="text" onfocus="chuyenphim(this);idbacsisearch(this);"
                    class="down_select_hover" style="width: 90%" />
            </p>
        </div>
        <div class="div-Out">
            <h4>
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("iddieuduong")%>
            </h4>
            <p>
                <input mkv="true" id="IdDieuDuong" type="hidden" />
                <input mkv="true" id="mkv_IdDieuDuong" type="text" onfocus="chuyenphim(this);IdDieuDuongsearch(this);" class="down_select_hover" style="width: 90%;" />
            </p>
        </div>
        <div class="div-Out" style="width: 96%">
        <h4 style="text-transform: uppercase">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("choncanlamsan")%>
        </h4>
        <p style="width: 80%;">
            <input type="button" value="Chọn cận lâm sàn" onclick="ChonCLS(this);" style="width: auto" />
        </p>
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
</div>
<div class="body-div-button">
    <p class="in-a">
        <input id="luu" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
        <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
        <input id="xoa" type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
        <input id="intoathuoc" type="button"  value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("intoathuoc") %>" />
        <input id="incls" type="button"  value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("incls") %>" />
        <input id="ingiaychuyenvien" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("ingiaychuyenvien") %>" />
    </p>
</div>
