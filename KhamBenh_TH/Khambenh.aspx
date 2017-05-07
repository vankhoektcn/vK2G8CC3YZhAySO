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
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div" style="margin-top: -41px; border-top: none; padding-bottom: 10px;
        border: 1px solid #999">
        <div class="header-div">
            Phiếu khám bệnh
        </div>
        <div class="in-a" style="padding-top: 70px; border-bottom: none; padding-bottom: 0px;">
            <input mkv="true" clearval="false" type="hidden" id="maphieucls" />
            <input mkv="true" clearval="false" type="hidden" id="iddangkycls" />
            <input mkv="true" clearval="false" type="hidden" id="idbenhnhan" />
            <input mkv="true" clearval="false" type="hidden" id="IdChiTietDangKyKham" />
            <input mkv="true" clearval="false" type="hidden" id="IDBENHNHANBHDONGTIEN" />
            <input mkv="true" clearval="false" type="hidden" id="iddangkykham" />
            <input mkv="true" clearval="false" type="hidden" id="ListIdThuocKhamBenhKhac" />
            <input mkv="true" clearval="false" type="hidden" id="PhongID" />
            <input mkv="true" clearval="false" type="hidden" id="DichVuKCBID" />
            <input mkv="true" clearval="false" type="hidden" id="IdKhoa" />
            <input mkv="true" clearval="false" type="hidden" id="loaidk" />
            
            
            <div class="div-Out" style="width: 259px; padding: 0px 0px 20px 0px; float: right;
                background: none; border: none; left: -15px; top: 0px;">
                <table style="width: 100%; float: right" class="jtable">
                    <tr>
                        <th colspan="3" align="center">
                            Thông tin sinh hiệu
                        </th>
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
                            mmHg
                        </td>
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
                            độ C
                        </td>
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
                            lần/ph
                        </td>
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
                            kg
                        </td>
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
                            cm
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            BMI
                        </td>
                        <td class="style3">
                            <span>
                                <input type="text" id="BMI" mkv="true" style="width: 80px; height: 12px;" onfocus="tinhbmi();" />
                                <input type="text" style="width: 80px; display: none; height: 12px;" />
                            </span>
                        </td>
                        <td>
                            kg/m2
                        </td>
                    </tr>
                </table>
            </div>
            <fieldset style="width: 75%;">
                <legend style="font-weight: bold; color: blue">Thông tin bệnh nhân <span style="position: absolute;
                    right: 3%; top: 6.5%">Ngày khám:
                    <input mkv="true" id="ngaykham_gio" type="text" onfocus="chuyenphim(this);" style="width: 7%" />
                    :<input mkv="true" id="ngaykham_phut" type="text" onfocus="chuyenphim(this);" style="width: 7%" />
                    <input mkv="true" id="ngaykham" type="text" onfocus="chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 20%" />
                </span></legend>
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
                            style="width: 90%"></span>
                    </p>
                </div>
                <div class="div-Out" style="width: 190px; padding-left: 0px;">
                    <p style="padding-left: 0px;">
                        <input type="checkbox" mkv="true" id="IsDungTuyen" /><span style="bottom: 0px;"> ? Đúng
                            tuyến</span>
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
                <div class="div-Out" style="width: 250px;">
                    <h4>
                        Vào viện lúc
                    </h4>
                    <p style="top: 0px; width: 54.9%">
                        <span mkv="true" id="NgayDangKy" clearval="false" type="text" onfocus="chuyenphim(this);"
                            style="width: 60%"></span>
                    </p>
                </div>
            </fieldset>
            <div class="div-Out" style="left: -1px; width: 920px; margin-top: 5px">
                <h4>
                    Bác sỹ 1</h4>
                <p style="left: -17px; width: 80%; top: 0px">
                    <input id="idbacsi" type="hidden" style="width: 2px" mkv="true" />
                    <input mkv="true" id="mkv_idbacsi" type="text" onfocus="chuyenphim(this);idbacsisearch(this);"
                        class="down_select_hover" style="width: 38%" />
                    <input type="text" id="TENKHOA" disabled mkv='true' style="width: 25%" />
                    <input type="text" id="TENPHONG" disabled mkv='true' style="width: 31%" />
                </p>
            </div>
            <div class="div-Out" style="width: 940px; margin-top: 7px">
                <h4>
                    Triệu chứng
                </h4>
                <p style="width: 83.9%; left: 14px; top: 0px;">
                    <input mkv="true" id="trieuchung" type="text" onfocus="chuyenphim(this);" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 940px">
                <h4>
                    Tiền sử
                </h4>
                <p style="width: 83.9%; left: 14px; top: 0px;">
                    <input mkv="true" id="tiensu" type="text" onfocus="chuyenphim(this);" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 940px">
                <h4>
                    Bệnh sử
                </h4>
                <p style="width: 83.9%; left: 14px; top: 0px;">
                    <input mkv="true" id="benhsu" type="text" onfocus="chuyenphim(this);" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 940px">
                <h4>
                    Chẩn đoán sơ bộ
                </h4>
                <p style="width: 83.9%; left: 14px; top: 0px;">
                    <input mkv="true" id="chandoanbandau" type="text" onfocus="chuyenphim(this);" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 940px">
                <h4>
                    Chẩn đoán tuyến dưới
                </h4>
                <p style="width: 66%; left: -155px; top: 0px;">
                    <input mkv="true" id="idchandoantuyenduoi" type="hidden" style="width: 1px" />
                    <input mkv="true" id="mkv_idchandoantuyenduoi" type="text" placeholder="Mã ICD" onfocus="chuyenphim(this);LoadChanDoanMaICD_tuyenduoi(this,'xacdinh');"
                        style="width: 10%" class="down_select_hover" />
                    <input mkv="true" id="mkv_mota_idchandoantuyenduoi" type="text" placeholder="Mô tả"
                        onfocus="chuyenphim(this);LoadChanDoanMoTaICD_tuyenduoi(this,'xacdinh');" style="width: 70%"
                        class="down_select_hover" />
                </p>
            </div>
            <div class="div-Out" style="width: 940px">
                <h4>
                    Chẩn đoán xác định
                </h4>
                <p style="width: 66%; left: -155px; top: 0px;">
                    <input mkv="true" id="idchandoan" type="hidden" style="width: 1px" />
                    <input mkv="true" id="mkv_idchandoan" type="text" placeholder="Mã ICD" onfocus="chuyenphim(this);LoadChanDoanMaICD(this,'xacdinh');"
                        style="width: 10%" class="down_select_hover" />
                    <input mkv="true" id="mkv_mota" type="text" placeholder="Mô tả" onfocus="chuyenphim(this);LoadChanDoanMoTaICD(this,'xacdinh');"
                        style="width: 70%" class="down_select_hover" />
                </p>
            </div>
        </div>
        <fieldset style="width: 97%;">
            <legend style="color: Blue; font-weight: bold;">Chẩn đoán phối hợp</legend>
            <div id="tableAjax_chandoanphoihop" class="in-b">
            </div>
        </fieldset>
        <div>
           Ngày chỉ định bổ sung: 
                 <input mkv="true" id="txtGioCDBS" type="text" onfocus="chuyenphim(this);" style="width:50px" />
                    :<input mkv="true" id="txtPhutCDBS" type="text" onfocus="chuyenphim(this);" style="width: 50px" />
                    <input mkv="true" id="txtNgayCDBS" type="text" onfocus="chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width:100px" />   
              ( Giờ, phút, ngày )          
        
        </div>
        <fieldset>
            <legend style="color: blue; font-weight: bold; width: 37%;">Thông tin CLS
                <input type="button" value="Chọn cận lâm sàng" id="chonCLS" onclick="ChonCLS(this,null,null,'cls');" />
                <input type="button" value="Cận lâm sàng thường quy" id="canlamsangThuongquy" style="color: #18538c"
                    onclick="ChoncanlamsangThuongquy(this);" />
                  
                    
                    
                <input type="button" style="position: absolute; right: 0;" value="DS CLS Tự ĐK" onclick="ShowDSCLSTDK(this);" />
            </legend>
            <div id="tableAjax_khambenhcanlamsan" class="in-b">
            </div>
        </fieldset>
        <fieldset style="width: 98%;">
            <legend style="color: blue; font-weight: bold; width: 90%;">Thông tin thuốc
                <input type="button" value="Lấy toa thuốc cũ" onclick="ChonTT(this,null,'thuoc');"
                    id="chontt" />
                <input type="button" value="Lấy toa thuốc mẫu" onclick="chonToaThuocMau(this);" id="toathuocmau"
                    style="color: #ff0000" />
                <div class="in-a" style="margin-top: -0.5%; float: right; width: 63%; padding: 0;">
                    <div class="div-Out" style="width: 38%; top: 0px; float: left;">
                        <h4 style="left: 0px;">
                            Số ngày ra toa
                        </h4>
                        <p style="left: 0px; top: 0px; width: 52%;">
                            <input mkv='true' id='songayratoa' type="text" onfocus="chuyenphim(this);" onblur="TestSo(this,false,false);tinhsongayratoa();"
                                style="width: 25%;" />
                        </p>
                    </div>
                    <div class="div-Out" style="width: 55%; float: left;">
                        <h4 style="left: 0px;">
                            Ngày tái khám
                        </h4>
                        <p style="left: 0px; top: 0px; width: 62%;">
                            <input mkv="true" id="ngayhentaikham" type="text" onfocus="chuyenphim(this);$(this).datepick();"
                                onblur="TestDate(this);" style="width: 52%" />
                            (dd/MM/yyyy)
                        </p>
                    </div>
                </div>
            </legend>
            <div id="tableAjax_chitietbenhnhantoathuoc" class="in-c">
            </div>
        </fieldset>
        <div class="in-a" style="padding: 0; border: none">
            <div class="div-Out" style="width: 95%">
                <h4>
                    Ghi Chú :
                </h4>
                <p style="width: 93%; left: 14px; top: 0px;">
                    <input mkv='true' id='ghichu' type="text" onfocus="chuyenphim(this);" style="width: 100%" />
                </p>
            </div>
            <div class="div-Out" style="width: 95%">
                <h4>
                    Lời dặn :
                </h4>
                <p style="width: 93%; left: 14px; top: 0px;">
                    <input mkv='true' id='loidan' type="text" onfocus="chuyenphim(this);" style="width: 100%" />
                </p>
            </div>
            <div style="clear: both">
            </div>
            <fieldset style="padding-bottom: 10px; margin: 0; padding: 0; width: 99.6%;">
                <legend style="color: red; font-weight: bold">Chuyển phòng</legend>
                <div class='div-Out' style='width: 15%'>
                    <h4 style='color: green;'>
                        Khoa
                    </h4>
                    <p style="width: 66%; top: 0px; left: 0px;">
                        <input mkv='true' id='IdkhoaChuyen' type='hidden' style="width: 1px" />
                        <input mkv='true' id='mkv_IdkhoaChuyen' type='text' onfocus='chuyenphim(this);IdkhoaChuyenSearch(this);'
                            class='down_select_hover' style='width: 90%' />
                    </p>
                </div>
                <div class='div-Out' style='width: 50%'>
                    <h4 style='color: green'>
                        Phòng
                    </h4>
                    <p style='width: 85%'>
                        <input mkv='true' id='IdChuyenPK' type='hidden' style="width: 1px" />
                        <input mkv='true' id='mkv_IdChuyenPK' type='text' onfocus='chuyenphim(this);phongkhambenhSearch(this);'
                            class='down_select_hover' style='width: 35%' />
                        &nbsp; Thu phí ?
                        <input mkv='true' type="checkbox" id="IsChuyenPhongCoPhi" />
                        Số TT mới
                        <input mkv='true' type="text" id="SoTTChuyenP" disabled="disabled" style="width:5%" />
                    </p>
                </div>
                <div class="div-Out" style="width: 30%; margin-top: 0px;">
                    <h4>
                        Bác sỹ 2</h4>
                    <p style="left: 1px; width: 80%; top: 0px">
                        <input mkv='true' id="idbacsi2" type="hidden" style="width: 2px" />
                        <input mkv='true' id="mkv_idbacsi2" type="text" onfocus="chuyenphim(this);idbacsisearch2(this);"
                            class="down_select_hover" style="width: 63%" />
                        &nbsp; Mời khám ?<input mkv='true' type="checkbox" id="IsBSMoiKham" />
                    </p>
                </div>
            </fieldset>
        </div>
        <div class="in-a" style="padding-top: 4px; position: relative;">
            <fieldset>
                <legend style="width: 35%;"><span style="color: #ff0000; font-weight: bold;">Ra viện/Chuyển
                    khoa/ra toa
                    <input type="checkbox" mkv="true" id="IsXuatVien" onclick="chuyenkhoavaravien(this);" />
                </span></legend>
                <div class="div-Out" style="width: 20%; text-transform: uppercase">
                    <h4>
                        <input mkv="true" id="gioravien" type="text" onfocus="chuyenphim(this);" style="width: 7%" />
                        :
                        <input mkv="true" id="phutravien" type="text" onfocus="chuyenphim(this);" style="width: 7%" />
                        <input mkv="true" id="TGXuatVien" type="text" onfocus="chuyenphim(this);$(this).datepick();"
                            onblur="TestDate(this);" style="width: 30%" />
                        (dd/MM/yyyy)
                    </h4>
                </div>
                <div id="huongdieutri">
                    <div class="div-Out" style="width: 10%; top: 0px; left: 1%;">
                        <h4 style="left: 0px;">
                            Không khám ?
                            <input type="checkbox" mkv="true" id="iskhongkham" />
                        </h4>
                    </div>
                    <div class="div-Out" style="left: -1px; width: 14%; top: 0px; float: left;">
                        <h4 style="left: 0px;">
                            Cho về không thuốc ?
                            <input type="checkbox" mkv="true" id="ischovekt" />
                        </h4>
                    </div>
                    <div class="div-Out" style="left: -1px; width: 33%; top: 0px; float: left;">
                        <h4 style="left: 0px;">
                            Chuyển viện ?
                            <input type="checkbox" mkv="true" id="ischuyenvien" />
                        </h4>
                        <p style="left: -15px; top: 0px; width: 60%;">
                            <input type="hidden" id="idbenhvienchuyen" mkv="true" />
                            <input mkv="true" id="mkv_idbenhvienchuyen" type="text" onfocus="loadbenhvien(this);chuyenphim(this);"
                                style="width: 95%" class="down_select_hover" disabled="disabled" />
                        </p>
                    </div>
                    <div class="div-Out" style="width: 13%">
                        <h4>
                            Tiểu phẩu rồi về
                            <input type="checkbox" id="IsTieuPhauRoiVe" mkv="true" />
                        </h4>
                    </div>
                </div>
                <div class="div-Out" style="padding-top: 4px; position: relative;width: 97%;text-align: right;">
                    <h4>
                    </h4>
                    <p style="">
                        Nội trú?
                        <input type="checkbox" mkv="true" id="isNoiTru" onclick="$('#isNgoaiTru').attr('checked',false);" />
                        Ngoại trú?
                        <input type="checkbox" mkv="true" id="isNgoaiTru" onclick="$('#isNoiTru').attr('checked',false);" />
                        <input type="button" id="MakeSoVaoVien" value="Tạo số vào viện" style="width: 120px;" />
                        Số vào viện:
                        <input type="text" id="SOVAOVIEN1" disabled="disabled" mkv="true" style="font-size: larger; background-color: Yellow" />
                    </p>
                </div>
            </fieldset>
        </div>
    </div>
    <div class="body-div-button" style="left: 0px; top: 0px; padding: 2%; width: auto;">
        <div class="in-a" style="padding: 0; top: 5%;">
            <input id="luu" type="button" value="Lưu" style="width: 100px;" />
            <input id="phieumoi" type="button" value="Mới" style="width: 70px;" />
            <input id="xoa" type="button" style="display: none" value="Xoá" />
            <input id="intoathuoc_dv" type="button" value="In Toa Thuốc DV " style="width: 120px;" />
            <input id="intoathuoc_bh" type="button" value="In Toa Thuốc BH " style="width: 120px;" />
            <input id="inchidinhCLS" type="button" value="In Phiếu CĐ.CLS " style="width: 120px;" />
            <input id="inchidinhDV" type="button" value="In Phiếu CĐ.DV " style="width: 120px;" />
            <input type="button" id="viewHSBA" value="Xem HSBA" />
            <input type="button" id="xuatthuoc" value="Xuất thuốc & VTYT & HC" style="width: 120px;"/>
            <input type="button" id="xuatvtyt" value="Xuất VTYT & HC" style="width: 120px;"/>
            
            <input type="button" id="InGiayChuyenVien" value="In Giấy Chuyển viện" style="width: 130px;" />
            
            <input type="button" id="GiuongBenh" value="Giường bệnh" style="width: 130px;" />
            <input type="button" id="InBV01" value="BV01" style="width: 70px;" />
        </div>
    </div>
    <div id="dialog" title="Basic dialog" style="display: none;">
        <p>
            <input type="password" id="user_pass" /><input type="button" id="confirm" value="OK" /></p>
    </div>
</asp:Content>
