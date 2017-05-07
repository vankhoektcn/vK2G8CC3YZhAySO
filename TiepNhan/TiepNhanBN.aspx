<%@ Page Language="C#" MasterPageFile="Page.master" AutoEventWireup="true" CodeFile="TiepNhanBN.aspx.cs"
    Inherits="tiepnhanbn" Title="Tiếp nhận" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="javascript/tiepnhanbn.js"></script>

    <style type="text/css">
        .div-Out
        {
            width:360px;
        }
        .div-Out p
        {
            width:65%;
        }
        .div-Out p input[type="text"]
        {
            width:90%;
        }
        .header-div
        {
	        background: #4d67a2 url(../images/bottom_nav_bg1.jpg) no-repeat top center;
	        color: white;
	        text-transform: uppercase;
	        height: 20px;
	        padding: 7px 40px 6px 0px;
	        text-align: center;
	        position: relative;
	        font-size: 20px;
	        width: 100%;
	        margin: 0 auto;
	        position: fixed;
	        top: 22px;
	        left: -5px;
	        z-index: 4444;
	        font-weight: bolder;
        }
        #TableDKKFather tr:hover
        {
            background: #f6ebcd;
            font-weight: bold;
        }
        #childTable0 tr:hover
        {
            background: #DCDCDC;
        }
        #childTable1 tr:hover
        {
            background: #DCDCDC;
        }
        #childTable2 tr:hover
        {
            background: #DCDCDC;
        }
        #childTable3 tr:hover
        {
            background: #DCDCDC;
        }
        #childTable4 tr:hover
        {
            background: #DCDCDC;
        }
        #childTable5 tr:hover
        {
            background: #DCDCDC;
        }
        #childTable6 tr:hover
        {
            background: #DCDCDC;
        }
        #childTable7 tr:hover
        {
            background: #DCDCDC;
        }
        #childTable8 tr:hover
        {
            background: #DCDCDC;
        }
        #childTable9 tr:hover
        {
            background: #DCDCDC;
        }
        #childTable10 tr:hover
        {
            background: #DCDCDC;
        }
        #inMaVach {
            line-height: 31px;
            font-weight: bold;
            width: 114px;
            height: 31px;
            margin: 0;
            padding: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div" style="border: 1px dashed #666">
        <p class="header-div">
            Tiếp nhận bệnh nhân
        </p>
        <div class="in-a" style="margin-top: 2.5%;">
            <fieldset id="thongtincoban">
                <legend style="color: blue; font-weight: bold">Thông tin cơ bản </legend>
                <div style="float: right; width: 50.5%;">
                    <div class="div-Out" style="width: 40%;">
                        <h4>
                            Khoa
                        </h4>
                        <p style="width: 70%;">
                            <select id="idkhoa" mkv="true" onchange="idkhoa_change(this)" onfocus="chuyenphim(this);"
                                style="width: 90%; color: #18538c; font-weight: bold; font-size: 10pt;">
                            </select>
                        </p>
                    </div>
                    <div class="div-Out" style="width: 43%;">
                        <h4 style="color: #ff0000; font-weight:bold;">
                            Ngày Đk
                        </h4>
                        <p style="width: 66%;">
                            <input mkv="true" id="ngaydangky" type="text" onfocus="chuyenphim(this);$(this).validDate();"
                                style="width: 42%; color: #18538c;" />&nbsp;
                            <input type="text" id="giodk" mkv="true" style="width: 10%; color: #18538c;" />:<input
                                type="text" id="phutdk" mkv="true" style="width: 10%; color: #18538c;" />
                        </p>
                    </div>
                </div>
                <div id="timkiemthongtin" class="timkiemthongtin">
                <div class="div-Out" style="width: 46.7%;">
                    <h4>
                        Mã bệnh nhân
                    </h4>
                    <p style="width: 77%; padding:0">
                        <input mkv="true" id="mabenhnhan" type="text" onfocus="Find(this);chuyenphim(this);"
                            style="width: 38%" placeholder="Nhập mã BN để tìm" />
                    </p>
                </div>
                <div class="div-Out" style="width: 32.9%;">
                    <h4>
                        Tên bệnh nhân
                    </h4>
                    <p style="width: 67.8%; padding:0;">
                        <input mkv="true" id="tenbenhnhan" style="width:92%" placeholder="Nhập tên bệnh nhân" type="text" onfocus="Find(this);" />
                    </p>
                </div>
                <div class="div-Out" style="width: 13%;">
                    <h4>
                        Giới tính
                    </h4>
                    <p style="width: 45%">
                        <select id="gioitinh" mkv="true" onfocus="chuyenphim(this);">
                            <option value="0">Nam</option>
                            <option value="1">Nữ</option>
                        </select>
                    </p>
                </div>
                <div class="div-Out" style="width: 43.5%;">
                    <h4>
                        Ngày sinh
                    </h4>
                    <p style="width: 75%; padding:0">
                        <input mkv="true" id="ngaysinh" type="text" onfocus="chuyenphim(this);" style="width: 30%"
                            placeholder="Ngày, tháng, năm sinh" />
                        <input mkv="true" id="SoTuoi" type="text" onfocus="chuyenphim(this);" onblur="TinhNamSinh_TheoTuoi();"
                            placeholder="tuổi" style="width: 10%" />
                        <input type="button" id="checkBN" onclick="KiemTraBN(this);" style="display: none;" />
                        <input mkv="true" id="SoThang" type="text" onfocus="chuyenphim(this);" onblur="TinhNamSinh_TheoThang();"
                            placeholder="tháng" style="width: 10%" />
                        <input type="button" value="Tìm BN trùng tên" onclick="KiemTraBN(this);" />
                        
                    </p>
                </div>
                <div class="div-Out" style="width: 61.4%;">
                    <h4>
                        Địa chỉ nhập
                    </h4>
                    <p style="width: 83%">
                        <input mkv="true" id="txtMaDiaChi" placeholder="Địa chỉ viết tắt" type="text" onfocus="TimDiaChi(this);"
                            style="width: 11.5%" />
                        <input mkv="true" id="diachi" placeholder="Địa chỉ đầy đủ" type="text" onfocus="chuyenphim(this);bindiachi(this);"
                            style="width: 82.2%" />
                    </p>
                </div>
                <div class="div-Out" style="width: 30%;">
                    <h4>
                        Đ.Thoại
                    </h4>
                    <p style="width: 75%;">
                        <input mkv="true" id="dienthoai" placeholder="Điện thoại" type="text" style="width: 90%;" />
                    </p>
                </div>
                </div>
                <div class="div-Out" style="width: 30%;">
                    <h4>
                        Quốc tịch
                    </h4>
                    <p>
                        <input type="hidden" id="quoctich" mkv="true" />
                        <input type="text" id="mkv_maquoctich" mkv="true" onfocus="chuyenphim(this);loadmaquoctich(this);"
                            style="width: 10.5%" />
                        <input type="text" id="mkv_tenquoctich" mkv="true" onfocus="chuyenphim(this);loadtenquoctich(this);"
                            style="width: 72.5%" />
                    </p>
                </div>
                <div class="div-Out" style="width: 62%">
                    <h4>
                        Chọn địa chỉ
                    </h4>
                    <p style="width: 83%">
                        <input type="hidden" id="tinhid" mkv="true" />
                        <input type="text" id="mkv_tinhid" class="down_select" mkv="true" placeholder="Tỉnh/thành phố"
                            onfocus="chuyenphim(this);tinhidsearch(this);" style="width: 20%" />
                        <input type="hidden" id="quanhuyenid" mkv="true" />
                        <input type="text" id="mkv_quanhuyenid" class="down_select" mkv="true" placeholder="Quận/huyện"
                            onfocus="chuyenphim(this);quanhuyenidsearch(this);" style="width: 20%" />
                        <input type="hidden" id="phuongxaid" mkv="true" />
                        <input type="text" id="mkv_phuongxaid" class="down_select" mkv="true" placeholder="Phường/xã"
                            onfocus="chuyenphim(this);phuongxaidsearch(this);" style="width: 20%" />
                        <input mkv="true" id="sonha" type="text" onfocus="chuyenphim(this);diachichuyen(this)"
                            style="width: 25%" />
                    </p>
                </div>
                <div class="div-Out" style="width: 30%;">
                    <h4>
                        CMND</h4>
                    <p>
                        <input type="text" mkv="true" id="chungminhthu" placeholder="Nhập CMND" onblur="check_chungminhthu(this);"
                            style="width: 89%;" />
                    </p>
                </div>
                <div class="div-Out" style="width: 30%;">
                    <h4>
                        Nghề nghiệp
                    </h4>
                    <p>
                        <input type="hidden" id="nghenghiep" mkv="true" />
                        <input type="text" id="mkv_manghenghiep" mkv="true" onfocus="chuyenphim(this);loadmanghenghiep(this);"
                            style="width: 10%" />&nbsp;
                        <input type="text" id="mkv_tennghenghiep" mkv="true" onfocus="chuyenphim(this);loadtennghenghiep(this);"
                            style="width: 72%" placeholder="Nghề nghiệp"/>
                    </p>
                </div>
                <div class="div-Out" style="width: 30%;">
                    <h4>
                        Dân tộc
                    </h4>
                    <p>
                        <input type="hidden" id="dantoc" mkv="true" />
                        <input type="text" id="mkv_madantoc" mkv="true" onfocus="chuyenphim(this);loadmadantoc(this);"
                            style="width: 10.5%" />
                        <input type="text" id="mkv_tendantoc" mkv="true" onfocus="chuyenphim(this);loadtendantoc(this);"
                            style="width: 68.5%" />
                    </p>
                </div>
                <div class="div-Out" style="width: 30%;">
                    <h4>
                        Nơi làm việc
                    </h4>
                    <p>
                        <input mkv="true" id="noicongtac" type="text" onfocus="chuyenphim(this);" style="width: 89%;" placeholder="Nơi làm việc"/>
                    </p>
                </div>
                <div class="div-Out" style="width: 61%;">
                    <h4>
                        Lý do vào viện</h4>
                    <p style="width: 82.5%;">
                        <input type="text" id="lidovaovien" mkv="true" style="width: 95%;" placeholder="Lý do vào viện"/>
                    </p>
                </div>
                <div class="div-Out" style="width: 30%;">
                    <h4>
                        Loại ưu tiên
                    </h4>
                    <p>
                        <select id="idloaiuutien" mkv="true" onfocus="chuyenphim(this);" style="width: 94%">
                        </select>
                    </p>
                </div>
                <div class="div-Out" style="width: 61%;">
                    <h4>
                        Người giám hộ</h4>
                    <p style="width: 82.5%;">
                        <input type="text" id="NguoiGiamHo" mkv="true" style="width: 95%;" placeholder="Người giám hộ"/>
                    </p>
                </div>
            </fieldset>
            <fieldset id="thongtindangkykham">
                <legend style="color: blue; font-weight: bold">Đăng ký khám bệnh</legend>
                <input mkv="true" id="iddangkykhambn" type="hidden" style="width: 1px" />
                <div class="div-Out" style="width: 30%;">
                    <h4 style="color: #18538c; font-weight: bold;">
                        Loại khám
                    </h4>
                    <p style="border-left: none;">
                        <select id="loai" mkv="true" style="width: 90%; color: #ff0000; font-weight: bold;
                            font-size: 10pt; background-color: #00ffff">
                        </select>
                    </p>
                </div>
                <div class="div-Out" style="width: 64%; padding-left: 0.4%;" id="thongtinkhoaphong">
                    <p style="width: 100%; border-left: none; float: left; padding-left: 0;">
                        <span id="muaso">Mua sổ
                            <input mkv="true" id="ismuaso" type="checkbox" onfocus="chuyenphim(this);" /></span>
                        ;Phòng
                        <select id="idphongkhambenh" mkv="true" onfocus="chuyenphim(this);" style="width: 25%;">
                        </select>
                        STT
                        <input mkv="true" id="STT" type="text" onfocus="chuyenphim(this);" style="width: 2.4%"
                            disabled="disabled" />;SLBN chờ
                        <input mkv="true" id="slbncho" type="text" onfocus="chuyenphim(this);" style="width: 2.4%"
                            disabled="disabled" />;SLBN khám
                        <input mkv="true" id="slbnkham" type="text" onfocus="chuyenphim(this);" style="width: 2.4%"
                            disabled="disabled" />
                        ; <span id="thuphicapcuu"><small style="color: #ff0000;">Miễn phí khám ? </small>
                            <input type="checkbox" mkv="true" id="isNotThuPhiCapCuu" /></span>
                            <%--<input id="tenloaitainan" type="text" value="; Tai nạn" visible="false"/>--%>
                        ; <small id="smTaiNan" style="display:none;">Tai nạn</small>
                        <select id="idloaitainan" mkv="true" style="width: 15%;display:none;">
                         <option>-- Loại tai nạn --</option>
                        <option value="1">Tai nạn giao thông</option>
                        <option value="2">Tai nạn sinh hoạt</option>
                        <option value="3">Bị đánh, bị chém</option>
                        <option value="4">Khác</option>
                        </select>
                    </p>
                </div>
                <div id="thongtinbh">
                    <div class="div-Out" style="width: 30%;">
                        <h4>
                            Số BHYT
                        </h4>
                        <p>
                           <%-- <input mkv="true" id="sobh1" type="text" onfocus="$(this).chuyenBH('2','char');" style="width: 7%" />
                            <input mkv="true" id="sobh2" type="text" onfocus="$(this).chuyenBH('1','num');" style="width: 5%" />
                            <input mkv="true" id="sobh3" type="text" onfocus="$(this).chuyenBH('2','num');" style="width: 7%" />
                            <input mkv="true" id="sobh4" type="text" onfocus="$(this).chuyenBH('2','num');" style="width: 7%" />
                            <input mkv="true" id="sobh5" type="text" onfocus="$(this).chuyenBH('3','num');" style="width: 10%" />
                            <input mkv="true" id="sobh6" type="text" onfocus="$(this).chuyenBH('5','num');" style="width: 16%" />--%>
                            
                             <input mkv="true" id="sobh1" type="text"   style="width: 7%" />
                            <input mkv="true" id="sobh2" type="text"   style="width: 5%" />
                            <input mkv="true" id="sobh3" type="text"   style="width: 7%" />
                            <input mkv="true" id="sobh4" type="text"   style="width: 7%" />
                            <input mkv="true" id="sobh5" type="text"   style="width: 10%" />
                            <input mkv="true" id="sobh6" type="text"  style="width: 16%" />
                        </p>
                    </div>
                    <div class="div-Out" style="width: 19.9%;">
                        <h4>
                            Giá trị từ
                        </h4>
                        <p style="width: 60%;">
                            <input mkv="true" id="ngaybatdau" type="text" onfocus="chuyenphim(this);" style="width: 72%;" />
                        </p>
                    </div>
                    <div class="div-Out" style="width: 40%;">
                        <h4>
                            đến
                        </h4>
                        <p style="width: 91%;">
                            <input mkv="true" id="ngayhethan" type="text" onfocus="chuyenphim(this);" style="width: 25%;" onblur="check_ngaybaohiem();" />
                            <input type="button" id="chonbhkhac" onclick="chonbh(this);" value="Chọn BH khác" />
                            <input type="button" id="bhmoi" value="BH Mới" />
                        </p>
                    </div>
                    <div class="div-Out" style="width: 55%">
                        <h4>
                            Nơi ĐK KCB BĐ
                        </h4>
                        <p style="width: 81%;padding:0">
                            <input type="hidden" id="IdNoiDangKyBH" mkv="true" />
                            <input type="text" id="mvk_MADANGKY" mkv="true" onfocus="chuyenphim(this);loadmadangky(this);"
                                onblur="ktramabh(this);TinhTile();" style="width: 10%" />
                            <input type="text" id="mkv_TENNOIDANGKY" mkv="true" onfocus="chuyenphim(this);loadnoidangky(this);"
                                onblur="ktramabh(this);TinhTile();" style="width:41%" />
                            <span>&nbsp; Cấp cứu
                                <input mkv="true" id="IsCapCuu" type="checkbox" onfocus="chuyenphim(this);" onclick="$('#dungtuyen').attr('checked',true);$('#TraiTuyen').attr('checked',false);TinhTile();" />
                                ; Đúng tuyến
                                <input mkv="true" id="dungtuyen" type="checkbox" onfocus="chuyenphim(this);" onclick="$('#TraiTuyen').attr('checked',false);TinhTile();" />
                            </span>
                        </p>
                    </div>
                    <div class="div-Out" style="width: 40%;">
                        <h4>
                            Nơi g.t
                        </h4>
                        <p style="width: 80%;">
                            <input type="hidden" id="idNoiGioiThieu" mkv="true" />
                            <input type="text" id="mkv_ma_noigioithieu" mkv="true" onfocus="chuyenphim(this);loadmagioithieu(this);"
                                style="width: 15%" />
                            <input type="text" id="mkv_ten_noigioithieu" mkv="true" onfocus="chuyenphim(this);loadtengioithieu(this);"
                                style="width: 45%" />; Trái tuyến
                            <input mkv="true" id="TraiTuyen" type="checkbox" onfocus="chuyenphim(this);" onclick="$('#dungtuyen').attr('checked',false);TinhTile();" />
                        </p>
                    </div>
                    <div class="div-Out" id="divHidden" style="display:none;">
                            <input type="hidden" id="isInMaVachBN" mkv="true" value="0" />
                            <input type="hidden" id="isInTheBN" mkv="true" value="0" />
                            <input type="hidden" id="isInBaoThuPK" mkv="true" value="0" />
                            <input type="hidden" id="isKhamBH" mkv="true" value="0" />
                    </div>
                </div>
            </fieldset>
              <div class="div-Out" id="divTiLeBHYT" style="width: 15%; float: right; border: none; padding:0; padding-right:3%;">
                <h4>
                    Tỉ lệ BHYT</h4>
                <p style="width: 45%;">
                    <input type="hidden" mkv="true" id="IDBENHNHAN_BH" />
                    <input mkv="true" id="tilebhyt" type="text" style="width: 40%; font-weight: bold;
                        color: #ff0000; font-size: 11pt;" />%
                </p>
            </div>
            <div class="body-div-button" id="divButton" style="background: none; padding: 0; width:82%; padding-top: 0.3%; float:right; margin:0; text-align:left;">
                <input id="luu" type="button" value="Lưu" style="width: 80px;"  />
                <input id="dangKy" type="button" value="Đăng ký" style="width: 100px;"/>
                <input id="dkNhieuKhoa" type="button" value="ĐK nhiều khoa" style="width: 150px;" />
                <input id="dangkyCLS" type="button" value="Đăng ký CLS" style="width: 150px;" />
                <input id="dangkyCLS_edit" type="button" value="Sửa ĐK CLS" style="width: 150px;" />
                <input id="moi" type="button" value="Mới" style="width: 80px;"/>
                <input id="timKiem" type="button" value="Tìm Kiếm" style="width: 100px;"/>
                <input id="nhapvien" type="button" value="Nhập viện" onclick="nhapvienmoi(this);" style="width: 100px;" />
                <input id="tinhlaitien" type="button" value="Tính lại tiền" onclick="TinhLaiTien();" style="width: 100px;"/>
                <input id="inMaVach" type="button" value="In Mã BN" onclick="javascript:if(!$.isNullOrEmpty($.mkv.queryString('idkhoachinh'))) {window.open('frmInMaVach.aspx?MaBenhNhan='+$('#mabenhnhan').val()+'&IdBenhNhan='+$.mkv.queryString('idkhoachinh')+'');}else $.mkv.myerror('Chưa có bệnh nhân !');" style="width: 100px;line-height: 31px;font-weight: bold;width: 114px;height: 31px;margin: 0;padding: 0;display:none;"/>
                <input id="inTheBN"  type="button" value="In thẻ BN" onclick="javascript:if(!$.isNullOrEmpty($.mkv.queryString('idkhoachinh'))) {window.open('InTheBenhNhan.aspx?mabenhnhan='+$('#mabenhnhan').val()+'');}else $.mkv.myerror('Chưa có bệnh nhân !');" style="width: 100px;line-height: 31px;font-weight: bold;width: 114px;height: 31px;margin: 0;padding: 0;;display:none;"/>
                
            </div>
          
        </div>
    </div>
    <div id="tableDangkykham">
    </div>
</asp:Content>
