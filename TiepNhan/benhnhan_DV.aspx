<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="benhnhan_DV.aspx.cs" Inherits="benhnhan_DV" Title="Tiếp nhận" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="javascript/benhnhan.js">
    </script>
    <script type="text/javascript">
      $(document).ready(function(){
        $("#loai").attr("disabled","disabled");
        $("#loai").val("2");
      });
      
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div" style="margin-top: -62px; border-top: none; padding-bottom: 10px;
        border: 1px solid #999">
        <p class="header-div">
            Tiếp nhận bệnh nhân
        </p>
        <div class="in-a">
            <fieldset id="thongtincoban">
                <legend style="color: blue; font-weight: bold">Thông tin cơ bản</legend>
                <div class="div-Out" style="width: 475px">
                    <h4>
                        Mã bệnh nhân
                    </h4>
                    <p style="width: 75%; left: 0px; bottom: 0px;">
                        <input mkv="true" id="mabenhnhan" type="text" onfocus="Find(this);chuyenphim(this);"
                            style="width: 66%" />
                    </p>
                </div>
                <div class="div-Out" style="width: 260px; left: 160px;">
                    <h4>
                        Ngày tiếp nhận
                    </h4>
                    <p style="width: 60%; text-transform: none">
                        <input mkv="true" id="ngaytiepnhan" placeholder="Không bỏ trống" type="text" onfocus="Find(this);chuyenphim(this);$(this).validDate();$(this).datepick();"
                            style="width: 69%" /></p>
                </div>
                <div class="div-Out" style="width: 372px; left: 0px; top: 0px;">
                    <h4>
                        Tên bệnh nhân
                    </h4>
                    <p style="width: 68%; left: 0px; bottom: 0px;">
                        <input mkv="true" id="tenbenhnhan" placeholder="Không bỏ trống" type="text" onfocus="Find(this);chuyenphim(this);"
                            style="width: 94%" />
                    </p>
                </div>
                <div class="div-Out" style="width: 127px">
                    <h4>
                        Giới tính
                    </h4>
                    <p style="width: 50%; left: 0px;">
                        <select mkv="true" id="gioitinh" onfocus="chuyenphim(this);" style="width: 60px">
                            <option value="0" selected="selected">Nam </option>
                            <option value="1">Nữ </option>
                        </select>
                    </p>
                    
                </div>
                <div class="div-Out" style="width: 335px; left: 9px;">
                    <h4>
                        Ngày sinh
                    </h4>
                    <p style="text-transform: none; width:75%; ">
                        <input mkv="true" id="ngaysinh" type="text"  onfocus="chuyenphim(this);"
                            style="width: 27%" onblur="TestNgaySinh(this);TinhTuoiBenhNhan();" />
                        &nbsp;Năm,tháng tuổi
                            <input type="button" id="checkBN" onclick="KiemTraBN(this);" style="display:none;">
                          <input mkv='true' id="SoTuoi" type="text" onfocus="chuyenphim(this);$('#checkBN').click();" 
                            onblur="TinhNamSinh_TheoTuoi();" 
                            style="width: 11%" />
                                <input mkv='true' id="SoThang" type="text" onfocus="chuyenphim(this);"
                                 onblur="TinhNamSinh_TheoThang();"
                            style="width: 11%" />
                    </p>
                </div>
                
                <div class="div-Out" style="width: 635px; left: 0px; top: 0px;">
                    <h4>
                        Địa chỉ nhập
                    </h4>
                    <p style="width: 81.1%">
                        <input mkv="true" id="txtMaDiaChi" placeholder="Địa chỉ viết tắt" type="text" onfocus="TimDiaChi_DV();"
                            style="width: 11.5%" />
                        <input mkv="true" id="diachi" placeholder="Địa chỉ đầy đủ" type="text" onfocus="chuyenphim(this);"
                            style="width: 70.5%" />
                    </p>
                </div>
                  <div class="div-Out" style="width: 225px; left: 0px; top: 0px;">
                    <h4>
                       Đ.Thoại
                    </h4>
                    <p style="width: 54%">
                        <input mkv="true" id="dienthoai" placeholder="Điện thoại" type="text"  onblur="$('#idphongkhambenh').focus();"
                            style="width: 89%" />
                        
                    </p>
                </div>
                <div class="div-Out" style="width: 911px">
                    <h4>
                        Chọn địa chỉ
                    </h4>
                    <p style="width: 84%; left: -25px;">
                        <select mkv="true" id="tinhid" onfocus="chuyenphim(this);" onchange="tinhidchuyen(this);"
                            style="width: 192px">
                        </select>
                        <select mkv="true" id="quanhuyenid" onfocus="chuyenphim(this);" onchange="quanhuyenidchuyen(this);"
                            style="width: 135px">
                        </select>
                        <select mkv="true" id="phuongxaid" onfocus="chuyenphim(this);" style="width: 109px">
                        </select>
                        <input mkv="true" type="text" onfocus="chuyenphim(this);diachichuyen(this)"
                            style="width: 302px" />
                    </p>
                </div>
                <div class="div-Out" style="width: 313px">
                    <h4>
                        Loại khám
                    </h4>
                    <p style="width: 61%;">
                        <select id="loai" mkv="true"  onchange="loaichuyen(this)" onfocus="chuyenphim(this);"
                            style="width: 189px">
                        </select>
                    </p>
                </div>
                <div class="div-Out" style="width: 242px; left: 0px; top: 0px;">
                    <h4 style="left: -15px; bottom: 0px">
                        Loại u.t
                    </h4>
                    <p style="left: -17px; width: 72%; bottom: 0px">
                        <select id="idloaiuutien" mkv="true" onfocus="chuyenphim(this);" style="width: 179px">
                        </select>
                    </p>
                </div>
                <div class="div-Out" style="left: 0px; width: 277px; top: 0px">
                    <h4 style="left: -15px; bottom: -1px">
                        Nơi g.t
                    </h4>
                    <p style="width: 83%">
                        <input mkv="true" id="noigioithieu" type="text" onfocus="Find(this);chuyenphim(this);"
                            style="width: 98%" />
                    </p>
                </div>
            </fieldset>
         
            <fieldset id="thontindangkykham">
                <legend style="color: blue; font-weight: bold">Đăng ký khám bệnh </legend>
                <input mkv="true" id="iddangkykhambn" type="hidden" style="width: 1px" />
                <div class="div-Out" style="width: 200px">
                    <h4>
                        Ngày Đk
                    </h4>
                    <p style="text-transform: none; width: 70%; left: 63px; bottom: -2px;">
                        <input mkv="true" id="ngaydangky"  type="text" onfocus="chuyenphim(this);$(this).validDate();$(this).datepick();"
                            style="width: 61%" />&nbsp;
                    </p>
                </div>
                <div class="div-Out" style="width: 696px; left: 21px; top: 0px;">
                    <p style="width: 103%">
                        &nbsp; Khoa
                        <select id="idkhoa" mkv="true" onchange="idkhoa_change(this)" onfocus="chuyenphim(this);"
                            style="width: 100px">
                        </select>
                        Phòng
                        <select id="idphongkhambenh" mkv="true" onchange="idphongkhambenhchuyen(this)" onfocus="chuyenphim(this);"
                            style="width: 170px">
                        </select>
                        &nbsp;
                        <%=StaticData.ChuyenKhoaNameInTiepNhan %>
                        &nbsp;
                        <select id="idchuyenkhoa" mkv="true" onfocus="chuyenphim(this);" style="<%=StaticData.HaveChuyenKhoaInTiepNhan %>">
                        </select>
                        Mua sổ
                        <input mkv="true" id="ismuaso" type="checkbox" onfocus="chuyenphim(this);"  />
                        STT
                        <input mkv="true" id="STT" type="text" onfocus="chuyenphim(this);" style="width: 20px"
                            disabled="disabled" />
                        SLBN chờ
                        <input mkv="true" id="slbncho" type="text" onfocus="chuyenphim(this);" style="width: 20px"
                            disabled="disabled" />
                        SLBN khám
                        <input mkv="true" id="slbnkham" type="text" onfocus="chuyenphim(this);" style="width: 20px"
                            disabled="disabled" />
                    </p>
                </div>
            </fieldset>
        </div>
    </div>
    <div class="body-div-button" style="padding-bottom: 60px">
        <p class="in-a">
            <input id="luu" type="button" value="Lưu" />
            <input id="dangKy" type="button" value="Đăng ký" />
          
            <input id="dkNhieuKhoa" type="button" value="ĐK nhiều khoa" style="width: 110px;" />
              <input id="dangkyCLS" type="button" value="Đăng ký CLS" />
             <input id="dangkyCLS_edit" type="button" value="Sửa ĐK CLS" />

            <input id="moi" type="button" value="Mới" />
            <input id="timKiem" type="button" value="Tìm Kiếm" />
            <input id="nhapvien" type="button" value="Nhập viện" onclick="nhapvienmoi(this);" />
            
        </p>
    </div>
    <div id="tableDangkykham">
    </div>
</asp:Content>
