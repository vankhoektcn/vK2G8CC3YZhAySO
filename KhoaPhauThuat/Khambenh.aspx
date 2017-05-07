<%@ Page Language="C#" MasterPageFile="KhamBenh.master" AutoEventWireup="true" CodeFile="Khambenh.aspx.cs"
    Inherits="khambenh" Title="Khám bệnh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="javascript/khambenh3.js">
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
    table.jtable tr td
    {
    	padding: 1px 1px 1px 1px;
    	text-align:center;
    }
    .div-Out
    {
        padding:0;
    }
    .body-div-button
    {
        padding:5px 5px 50px 5px;
    }
    .body-out
    {
     padding:0 10px 20px 5px;   
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div" style="margin-top: -52px; border-top: none; padding-bottom: 10px;
        border: 1px solid #999">
        <div class="header-div">
            Thông tin phẫu thuật
        </div>
        <div class="in-a" style="padding-top: 70px; border-bottom: none; padding-bottom: 0px;">
            <input mkv="true" clearval="false" type="hidden" id="maphieucls" />
            <input mkv="true" clearval="false" type="hidden" id="iddangkycls" />
            <input mkv="true" clearval="false" type="hidden" id="idbenhnhan" />
            <input mkv="true" clearval="false" type="hidden" id="IdChiTietDangKyKham" />
            <input mkv="true" clearval="false" type="hidden" id="iddangkykham" />
            <input mkv="true" clearval="false" type="hidden" id="DichVuKCBID" />
            <input mkv="true" clearval="false" type="hidden" id="IdKhoa" />
            <input mkv="true" clearval="false" type="hidden" id="loaidk" />
            <div class="div-Out" style="width: 259px; padding: 0px 0px 20px 0px; float: right;
                background: none; border: none; left: -15px; top: 0px;">
                <table style="width: 100%; float: right" class="jtable">
                    <tr>
                        <th colspan="3" align="center">
                            Thông tin sinh hiệu</th>
                    </tr>
                    <tr>
                        <td class="style1">
                            Mạch
                        </td>
                        <td class="style3">
                            <span clearval="false">
                                <input type="text" id="MACH" mkv="true" style="width: 80px; height: 12px;" /></span>
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
                            <span clearval="false">
                                <input type="text" id="HUYETAP1" mkv="true" style="width: 35px; height: 12px;" />/<input
                                    type="text" id="HUYETAP2" mkv="true" style="width: 35px; height: 12px;" /></span>
                        </td>
                        <td>
                            mmHg</td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Nhiệt độ
                        </td>
                        <td>
                            <span clearval="false">
                                <input type="text" id="NHIETDO" mkv="true" style="width: 80px; height: 12px;" /></span>
                        </td>
                        <td>
                            độ C</td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Nhịp thở
                        </td>
                        <td>
                            <span clearval="false">
                                <input type="text" id="NHIPTHO" mkv="true" style="width: 80px; height: 12px;" /></span>
                        </td>
                        <td>
                            lần/ph</td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Cân nặng
                        </td>
                        <td class="style3">
                            <span clearval="false">
                                <input type="text" id="CANNANG" mkv="true" style="width: 80px; height: 12px;" /></span>
                        </td>
                        <td>
                            kg</td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Chiều cao
                        </td>
                        <td class="style3">
                            <span clearval="false">
                                <input type="text" id="CHIEUCAO" mkv="true" style="width: 80px; height: 12px;" /></span>
                        </td>
                        <td>
                            cm</td>
                    </tr>
                    <tr>
                        <td class="style1">
                            BMI
                        </td>
                        <td class="style3">
                            <span>
                                <input type="text" id="BMI" mkv="true" style="width: 80px; height: 12px;" onfocus="tinhbmi();" />
                                <input type="text" style="width: 80px; display: none; height: 12px;" />
                                <input type="text" style="width: 80px; display: none; height: 12px;" />
                            </span>
                        </td>
                        <td>
                            kg/m2</td>
                    </tr>
                </table>
            </div>
           <fieldset style="width: 75%">
                <legend style="font-weight: bold; color: blue">Thông tin bệnh nhân</legend>
                <div class="div-Out" style="width: 300px">
                    <h4>
                        Mã bệnh nhân
                    </h4>
                    <p>
                        <span mkv="true" id="mabenhnhan" clearval="false" type="text" onfocus="chuyenphim(this);"
                            style="width: 90%"></span>
                    </p>
                </div>
                <div class="div-Out" style="width: 540px">
                    <h4>
                        Tên bệnh nhân
                    </h4>
                    <p style="width: 78.7%">
                        <span mkv="true" id="tenbenhnhan" clearval="false" type="text" onfocus="chuyenphim(this);"
                            style="width: 90%"></span>
                    </p>
                </div>
                <div class="div-Out" style="width: 300px">
                    <h4>
                        Ngày sinh
                    </h4>
                    <p>
                        <span mkv="true" id="NGAYSINH" clearval="false" type="text" onfocus="chuyenphim(this);"
                            style="width: 90%"></span>
                    </p>
                </div>
                <div class="div-Out" style="width: 540px">
                    <h4>
                        Giới tính
                    </h4>
                    <p style="width: 78.7%">
                        <span mkv="true" id="GIOITINH" clearval="false" type="text" onfocus="chuyenphim(this);"
                            style="width: 90%"></span>
                    </p>
                </div>
                <div class="div-Out" style="width: 860px">
                    <h4>
                        Địa chỉ
                    </h4>
                    <p style="width: 84%; left: -18px; top: 0px;">
                        <span mkv="true" id="diachi" clearval="false" type="text" onfocus="chuyenphim(this);"
                            style="width: 90%"></span>
                    </p>
                </div>
                <div class="div-Out" style="width: 300px">
                    <h4>
                        Số BHYT
                    </h4>
                    <p style="width: 53%; left: -21px; top: 0px;">
                        <span mkv="true" id="sobhyt" clearval="false" type="text" onfocus="chuyenphim(this);"
                            style="width: 90%"></span>
                    </p>
                </div>
                <div class="div-Out" style="width: 350px">
                    <h4>
                        Nơi ĐK KCB
                    </h4>
                    <p style="width: 61.5%; left: -21px; top: 0px;">
                        <span mkv="true" id="NoiDangKyKCB" clearval="false" type="text" onfocus="chuyenphim(this);"
                            style="width: 90%">
                           </span>
                          
                    </p> 
                </div>
                 <div class="div-Out" style="width: 190px; padding-left:0px;">
                    <p style="padding-left:0px;">
                        <input type="checkbox" mkv="true" id="IsDungTuyen" /><span style="bottom:0px;"> ? Đúng tuyến</span>
                    </p>
                </div>
                <div class="div-Out" style="width: 300px">
                    <h4>
                        Ngày bắt đầu
                    </h4>
                    <p style="width: 53%; left: -21px; top: 0px;">
                        <span mkv="true" id="ngaybatdau" clearval="false" type="text" onfocus="chuyenphim(this);"
                            style="width: 90%"></span>
                    </p>
                </div>
                <div class="div-Out" style="width: 270px">
                    <h4>
                        Ngày hết hạn
                    </h4>
                    <p style="width: 50%; left: -21px; top: 0px;">
                        <span mkv="true" id="ngayhethan" clearval="false" type="text" onfocus="chuyenphim(this);"
                            style="width: 90%"></span>
                    </p>
                </div>
                <div class="div-Out" style="width: 280px;">
                    <h4>
                        Vào viện lúc
                    </h4>
                    <p style="top: 0px; width: 65%">
                        <input type="text" style="width:70px; margin:2px; padding:2px;" mkv='true' id='ngaykham' />
                        <input type="text" style="width:30px; margin:2px; padding:2px" mkv="true" id="giovaovien" />:
                        <input type="text" style="width:30px; margin:2px; padding:2px" mkv="true" id="phutvaovien" />
                    </p>
                </div>
            </fieldset>
            <div class="div-Out" style="left: -1px; width: 920px; margin-top: 5px">
                <h4>
                    Bác sỹ chính</h4>
                <p style="left: -17px; width: 80%; top: 0px">
                    <input id="idbacsi" type="hidden" style="width: 2px" mkv="true" />
                    <input mkv="true" id="mkv_idbacsi" type="text" onfocus="chuyenphim(this);idbacsisearch(this);"
                        class="down_select_hover" style="width: 28%" />
                    <input type="text" id="TENKHOA" disabled mkv='true' style="width: 25%" />
                    <input type="hidden" id="PhongID" mkv='true' />
                    <input type="text" id="mkv_PhongID" mkv='true' style="width: 21%" class="down_select"
                        onfocus="chuyenphim(this);loadlistphongmo(this);" />
                         <input type="hidden" mkv="true" id="giuongid" />
                        <input type="text" mkv="true" class="down_select" id="mkv_giuongid" style="width:20%" onfocus="chuyenphim(this);idgiuongsearch(this);" />
                </p>
            </div>
                 <div class="div-Out" style="width: 940px; margin-top: 7px">
                <h4>
                    Phương pháp vô cảm
                </h4>
                <p style="width: 83.9%; left: 14px; top: 0px;">
                    <input type="hidden" id="idphuongphapvocam" mkv="true" />
                    <input mkv="true" id="mkv_idphuongphapvocam" type="text" onfocus="chuyenphim(this);idphuongphapvocamsearch(this);" style="width: 90%" class="down_select" />
                </p>
            </div>
                      
            <div class="div-Out" style="width: 940px">
                <h4>
                    Chuẩn đoán trước mổ
                </h4>
                <p style="width: 66%; left: -155px; top: 0px;">
                    <input mkv="true" id="idchandoan" type="hidden" style="width: 1px" />
                    <input mkv="true" id="mkv_idchandoan" type="text" placeholder="Mã ICD" onfocus="chuyenphim(this);LoadChanDoanMaICD(this,'truocmo');"
                        style="width: 10%" class="down_select_hover" />
                    <input mkv="true" id="mkv_mota" type="text" placeholder="Mô tả" onfocus="chuyenphim(this);LoadChanDoanMoTaICD(this,'truocmo');"
                        style="width: 70%" class="down_select_hover" />
                </p>
            </div>
            <div class="div-Out" style="width: 940px">
                <h4>
                    Chuẩn đoán sau mổ
                </h4>
                <p style="width: 66%; left: -155px; top: 0px;">
                    <input mkv="true" id="ketluan1" type="hidden" style="width: 1px" />
                    <input mkv="true" id="mkv_ketluan1" type="text" placeholder="Mã ICD" onfocus="chuyenphim(this);LoadChanDoanMaICD(this,'saumo');"
                        style="width: 10%" class="down_select_hover" />
                    <input mkv="true" id="mkv_mota1" type="text" placeholder="Mô tả" onfocus="chuyenphim(this);LoadChanDoanMoTaICD(this,'saumo');"
                        style="width: 70%" class="down_select_hover" />
                </p>
            </div>
        </div>
        <fieldset id="ekipmo">
            <legend style="font-weight:bold;">Ekip mổ</legend>
            <div id="tableAjax_EkipMo" class="in-b">
            </div>
        </fieldset>
        <fieldset>
            <legend style="font-weight:bold;">Phương pháp phẫu thuật - thủ thuật
                <input type="button" value="Chọn" style="width: 130px;" id="chonCLS" onclick="ChonCLS(this);" />
            </legend>
            <div id="tableAjax_khambenhcanlamsan" class="in-b">
            </div>
        </fieldset>
        <fieldset>
            <legend style="font-weight:bold;">Thông tin Thuốc/VTYT/HC/DC <select id="khothuocid" mkv='true' style="width:200px"></select> <input type="button" value="Theo kho" id="phanloai" /></legend>
            <div id="tableAjax_chitietbenhnhantoathuoc" class="in-c">
            </div>
        </fieldset>
        <div class="in-a" style="padding: 0; border: none">
            <div style="clear: both">
            </div>
            <fieldset style="padding-bottom: 10px; display: table; padding-top: 10px; width:99%;">
                <legend style="font-weight: bold">Xuất khoa/phòng --<font color="red" size="2.5em"> Xuất viện ? </font><input type="checkbox" id="IsXuatVien" mkv="true" /> </legend>
                <div class="div-Out" style="width: 281px;">
                    <h4>
                        Thời gian
                        <input type="checkbox" mkv="true" id="chuyenkhoaravien" onclick="chuyenkhoavaravien(this);" />
                    </h4>
                    <p style="width: 63%;">
                        <input mkv="true" id="gioravien" type="text" onfocus="chuyenphim(this);" style="width: 16%" />
                        :
                        <input mkv="true" id="phutravien" type="text" onfocus="chuyenphim(this);" style="width: 14%" />
                        <input mkv="true" id="TGXuatVien" type="text" onfocus="chuyenphim(this);$(this).datepick();"
                            onblur="TestDate(this);" style="width: 50%" />
                    </p>
                </div>
                <div class='div-Out' style='width: 310px'>
                    <h4 style='color: green;'>
                        Khoa
                    </h4>
                    <p style="width: 79%;">
                        <input mkv='true' id='IdkhoaChuyen' type='hidden' style="width: 1px" />
                        <input mkv='true' id='mkv_IdkhoaChuyen' type='text' onfocus='chuyenphim(this);IdkhoaChuyenSearch(this);'
                            class='down_select_hover' style='width: 90%' />
                    </p>
                </div>
                <div class='div-Out' style="<%=StaticData.HaveChuyenKhoaInTiepNhan %>">
                    <h4 style='color: green'>
                        <%=StaticData.ChuyenKhoaNameInTiepNhan%>
                    </h4>
                    <p style='width: 60%'>
                        <input mkv='true' id='idDVPhongChuyenDen' type='hidden' style="width: 1px" />
                        <input mkv='true' id='mkv_idDVPhongChuyenDen' type='text' onfocus='chuyenphim(this);banggiadichvuSearch(this);'
                            mkv="true" class='down_select_hover' style="<%=StaticData.HaveChuyenKhoaInTiepNhan2 %>" />
                    </p>
                </div>
                <div class='div-Out' style='width: 238px'>
                    <h4 style='color: green'>
                        Phòng
                    </h4>
                    <p style='width: 71%'>
                        <input mkv='true' id='IdChuyenPK' type='hidden' style="width: 1px" />
                        <input mkv='true' id='mkv_IdChuyenPK' type='text' onfocus='chuyenphim(this);phongkhambenhSearch(this);'
                            class='down_select_hover' style='width: 72%' />
                    </p>
                </div>
                <div class="div-Out" style="width: 350px;">
                    <h4 style="left: 0px;">
                        Chuyển viện ?
                        <input type="checkbox" mkv="true" id="ischuyenvien" />
                    </h4>
                    <p style="width: 60%;">
                        <input type="hidden" id="idbenhvienchuyen" mkv="true" />
                        <input mkv="true" id="mkv_idbenhvienchuyen" type="text" onfocus="loadbenhvien(this);chuyenphim(this);"
                            style="width: 90%" class="down_select_hover" disabled="disabled" />
                    </p>
                </div>
                <div class="div-Out" style="padding-top: 4px; position: relative;">
                    <h4>
                        Nội trú?
                        <input type="checkbox" mkv="true" id="isNoiTru" onclick="$('#isNgoaiTru').attr('checked',false);" />
                        Ngoại trú?
                        <input type="checkbox" mkv="true" id="isNgoaiTru" onclick="$('#isNoiTru').attr('checked',false);" />
                        <input type="button" id="MakeSoVaoVien" value="Tạo số vào viện" style="width: 120px;" />
                    </h4>
                    <p style="left: 150px">
                        Số vào viện:
                        <input type="text" id="SOVAOVIEN1" disabled="disabled" mkv="true" style="font-size: larger; background-color: Yellow" />
                    </p>
                </div>
             
            </fieldset>
        </div>
    </div>
    <div class="body-div-button">
     <div class="in-a">
            <input id="luu" type="button" value="Lưu" style="width: 70px;" />
            <input id="phieumoi" type="button" value="Phiếu mới" style="width: 90px;" />
            <input id="xoa" type="button" style="display: none" value="Xoá" />
            <input id="intoathuoc_dv" type="button" value="In Toa Thuốc " style="width: 120px;" />
            <input id="inchidinhCLS" type="button" value="In Phiếu CĐ.CLS " style="width: 120px;" />
            <input id="inchidinhDV" type="button" value="In Phiếu CĐ.DV " style="width: 120px;" />
            <input type="button" id="viewHSBA" value="Xem HSBA" />
            <input type="button" id="xuatthuoc" value="Xuất thuốc/VTYT/HC.." style="width: 140px;" />
            <input type="button" id="btnTinhGiuong" value="Tính tiền giường"  style="width: 120px;"  onclick="ShowTinhTienGiuong(this);"  />
            <input type="button" id="xemcongno" value="Xem chi tiết công nợ"  style="width: 140px;" />
            <input type="button" id="xuatvien" value="Xuất viện"  style="width: 100px; display:none;" onclick="ShowXuatVien(this);" />
            <input type="button" id="InGiayChuyenVien" value="In Giấy Chuyển viện" style="width: 130px;" />
        </div>
    </div>
    <div id="dialog" title="Basic dialog" style="display: none;">
        <p>
            <input type="password" id="user_pass" /><input type="button" id="confirm" value="OK" /></p>
    </div>
</asp:Content>
