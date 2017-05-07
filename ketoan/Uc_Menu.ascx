<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Uc_Menu.ascx.cs" Inherits="ketoan_Uc_Menu" %>
 <script src="Scripts/jquery.sidebarToggler.102.js" type="text/javascript"></script>
    <link href="Scripts/AddReciepsBill.css" rel="stylesheet" type="text/css" />
    
     <link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/default.css" />
    <link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/sheet_index.css" />
    <link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/style.css" />    

    <script type="text/javascript" src="../ketoan/js_KeToan/libary.js"></script>
    <script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
    <script type="text/javascript" src="../ketoan/js_KeToan/script.js"></script>
    <script type="text/javascript" src="../ketoan/js_KeToan/jscript.js"></script>
    <link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/epoch_styles.css" />
    <link href="../ketoan/css_ketoan/dropdown/dropdown.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../ketoan/css_ketoan/dropdown/themes/default/default.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../ketoan/js_KeToan/epoch_classes.js"></script>
	<style type="text/css" >
            .tieude{
	            font-size:15px;
	            font-weight:bold;
	            color:red;
            }

            .tieude A{
	            font-size:12px;
	            font-weight:bold;
	            color:#666666;
	            text-decoration:none;
            }

            .tieude A:link{
	            font-family:tahoma;
	            font-size:12px;
	            color:#5E5F61;
	            font-weight:bold;	
	            text-decoration:none;
            }

            .tieude A:hover{
	            font-family:tahoma;
	            font-size:12px;
	            color:Red;
	            font-weight:bold;	
	            text-decoration:none;
            }
            .menu1{
                font-size:12px;
                font-weight:bold;
                color:#666666;
				font-family:Tahoma;
            }

            .menu1 A{
                font-size:12px;
                font-weight:bold;
                color:#666666;
                text-decoration:none;
				font-family:Tahoma;
            }

            .menu1 A:hover{
                font-family:tahoma;
                font-size:12px;
                color:Red;
                font-weight:bold;	
                text-decoration:none;
            }
        </style>
    <script language = "javascript" type="text/javascript">
    function LoadTieuDe()
    {
        var obj = document.getElementById("tieudepk");
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                obj.innerHTML = value;                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=LoadTieuDe&times="+Math.random(),true);
        xmlHttp.send(null);
    }
//    window.onload=LoadTieuDe();
    window.onload=function()
    {
        LoadTieuDe();
    };
    function TestDate(t)
	{
		if (t.value != "")
		{
			t.value=AddString(t.value);
			if (isDate(t.value)==false)
			{
				t.value="";
				alert("Bạn nhập ngày tháng không hợp lệ ! ");
				t.focus();
			}
		}
		return;
	}
	function Thoat()
    {
        document.location.href = "../ketoan/index1.aspx";
    }
    
</script>
 <div align = "center">
    <div>
        <ul id="nav" class="dropdown dropdown-horizontal">
	        <li><a href="../pagehome.aspx">Home</a></li>
	         <li class="dir">Hệ thống
		        <ul>                    
                    <li><a href="KTHT_ThamSoTuyChon.aspx">DS tham số tùy chọn</a></li>
                     <li><a href="KTHT_SoDuDauKyTaiKhoan.aspx">Số dư đầu kỳ TK</a></li>
		             <li><a href="KTHT_CongNoDauKy.aspx">Công nợ đầu kỳ</a></li>
		             <li><a href="ketoan_hethong.aspx">Tồn kho đầu kỳ</a></li>
		             <li><a href="ketoan_hethong.aspx">Chuyển số dư</a></li>			        			        		       			        
		        </ul>
	        </li>
	        <li class="dir">Danh mục
		        <ul>
                    <li><a href="danhmuctaikhoan.aspx">Tài khoản</a></li>			       
			        <li><a href="danhmucnhacungcap.aspx">Nhà cung cấp</a></li>
			        <li><a href="danhmuckhachhang.aspx">Khách hàng</a></li>		
			        <li><a href="danhmuckho.aspx">Kho</a></li>	
			        <li><a href="KTVT_DM_Vat_Tu.aspx">Vật Tư</a></li>			        
		        </ul>
	        </li>	        	        
	        <li class="dir">KT Dược
	            <ul>
	                <li><a href="KT_PhieuNhapKho.aspx">Phiếu Nhập Kho</a></li>
                    <li><a href="phieuxuatkho3.aspx">Phiếu Xuất Kho</a></li>
                    <li class="dir"><a href="#">Danh Mục</a>
		                <ul>		                    
		                    <li><a href="DMKhoanMucPhi.aspx">Khoản Mục Phí</a></li>
		                    <li><a href="DMNghiepVu.aspx">Loại Nghiệp Vụ</a></li>
		                    <li><a href="DMNgoaiTe.aspx">Ngoại Tệ</a></li>
		                    <li><a href="DMNganHang.aspx">Ngân Hàng</a></li>
		                    <li><a href="DMPhongBan.aspx">Phòng Ban</a></li>
		                    <li><a href="QuanLyChungTu.aspx">Danh Sách Chứng Từ</a></li>
		                </ul>
		            </li>
		            <li class="dir"><a href="#">Thu Chi TM</a>
		                <ul>		                    
		                    <li><a href="KT_PhieuNhapKho.aspx">Phiếu Thu</a></li>
		                    <li><a href="KT_PhieuNhapKho.aspx">Phiếu Chi</a></li>
		                </ul>
		            </li>
		            <li class="dir"><a href="#">Thu Chi NH</a>
		                <ul>		                    
		                    <li><a href="KT_PhieuNhapKho.aspx">Phiếu Thu</a></li>
		                    <li><a href="KT_PhieuNhapKho.aspx">Phiếu Chi</a></li>
		                </ul>
		            </li>
		            <li><a href="phieuxuatkho3.aspx">CCDC & TSCD</a></li>
		            <li><a href="phieuxuatkho3.aspx">KT Tổng Hợp</a></li>
                </ul>    
	        </li>	        
            <li class="dir">Hóa đơn DV
		        <ul>
                    <li><a href="HDDV_XuatHoaDon.aspx">Xuất hóa đơn</a>
			         
			        </li>
			        <li><a href="HDDV_DanhSachHoaDon.aspx">Danh sách hóa đơn</a></li>
			        <li><a href="HDDV_rptDoanhThuChiTiet.aspx">BCDT Chi Tiết</a></li>
			        <li><a href="HDDV_rptDoanhThuTongHop.aspx">BCDT Tổng Hợp Theo Ngày </a></li>
			        <li><a href="HDDV_rptDoanhThuTongHop2.aspx">BCDT Tổng Hợp </a></li>
			        <li><a href="HDDV_rptDTTheoNguoiDung.aspx">BCDT Theo Người Dùng </a></li>
		        </ul>
	        </li>
	        <li class="dir">Tiền mặt
	            <ul>
	                <li><a href="KTTM_PhieuThuHoaDon.aspx">Phiếu thu hóa đơn</a></li>
                    <li><a href="KTTM_ThuKhac.aspx">Phiếu thu khác</a></li>
                    <li><a href="KTTM_PhieuChiHoaDon.aspx">Phiếu chi hóa đơn</a></li>
                    <li><a href="KTTM_PhieuChiKhac.aspx">Phiếu chi khác</a></li>
                    <li><a href="KTTM_DanhSachPhieuThuHoaDon.aspx">Danh sách phiếu thu</a></li>
                    <li><a href="KTTM_DanhSachPhieuChi.aspx">Danh sách phiếu chi</a></li>
                    <li class="dir"><a href="#">Báo cáo</a>
		                <ul>		                    
		                    <li><a href="SoQuyTM.aspx">Sổ quỹ tiền mặt</a></li>
		                    <!--<li><a href="SoChiTietTK.aspx">Sổ CT tài khoản</a></li>
		                    <li><a href="rptNhatKyThuTien.aspx">Nhật ký thu tiền</a></li>
		                    <li><a href="rptNhatKyChiTien.aspx">Nhật ký chi tiền</a></li>-->
		                </ul>
		            </li>
		        </ul>    
	        </li>
	        <li class="dir">Ngân hàng
	            <ul>
	                <li><a href="DanhMucTKNH.aspx">Danh mục TKNH</a></li>
                    <li><a href="KTNH_UyNhiemChi.aspx">Lập UNC</a></li>
                    <li><a href="KTNH_DanhSachUyNhiemChi.aspx">DS ủy nhiệm chi</a></li>
                    <li class="dir"><a href="#">Báo cáo</a>		                
		            </li>
		        </ul>
	        </li>
	       <li class="dir">KT Công Nợ
	            <ul>
	                <li><a href="KTCN_Khach_Hang_CT.aspx">BC Chi tiết CN</a></li>
		            <li><a href="KTCN_Khach_Hang_TH.aspx">BC Tổng hợp CN</a></li>                    
		        </ul>
	        </li>	        
	        <li class="dir">Tài sản CĐ
	            <ul>
	                <li><a href="KTVT_PHIEU_NHAP_VT.aspx">Phiếu nhập</a></li>
	                <li><a href="KTVT_PHIEU_XUAT_VT.aspx">Phiếu xuất</a></li> 
	                <li><a href="KTVT_DanhMucTaiSan.aspx">Danh mục TSCĐ</a></li>
	                <li><a href="KTVT_DanhMucTaiSanDuBi.aspx">TS chưa hình thành</a></li>	                
                    <li><a href="KTTSCD_Khauhaotaisan.aspx">Khấu hao TSCĐ</a></li>
                    <li><a href="KTTSCD_PhanBoTSCD.aspx">Tập hợp khấu hao TSCĐ</a></li>                    
                    <li><a href="KTVT_BaoCaoKhauHaoTSCD.aspx">Báo cáo khấu hao TSCĐ</a></li>                                     
                    <li class="dir">Báo cáo	                    
	                </li>
                </ul>
	        </li>
	         <li class="dir">Công cụ dụng cụ
	            <ul>
	                <li><a href="KTVT_PHIEU_NHAP_VT.aspx">Phiếu nhập</a></li>
	                <li><a href="KTVT_PHIEU_XUAT_VT.aspx">Phiếu xuất</a></li>    
	                <li><a href="KTVT_DanhMucCCDC.aspx">Danh mục CCDC</a></li>
                    <li><a href="KTTSCD_KhauHaoCCDC.aspx">Phân bổ CCDC</a></li>
                    <li><a href="KTTSCD_PhanBoCCDC.aspx">Tập hợp phân bổ CCDC</a></li>                    
                    <li><a href="KTVT_BaoCaoKhauHaoCCDC.aspx">Báo cáo khấu hao CCDC</a></li>                    
                    <li><a href="KTVT_BangTongHopNXT_VT.aspx">Bảng tổng hợp NXT </a></li>  
                </ul>
	        </li>
	        <li class="dir">KT Tổng hợp
	            <ul>
	                <li><a href="PHIEU_KE_TOAN3.aspx">Chứng từ tổng hợp</a></li> 
	                <li><a href="KTTH_CongThucKC.aspx">Định nghĩa CTKC</a></li>                                                                                               
                </ul>
	        </li>
	        <li class="dir">Báo cáo TC
	            <ul>
	                <li><a href="BCTC_BangCanDoi_TK.aspx">Bảng cân đối TK</a></li>
                    <li><a href="BangCanDoiKT.aspx">Bảng cân đối KT</a></li>                    
                </ul>
	        </li>

	        <li class="dir">Thuế
	            <ul>
	                <li><a href="BaoCaoVATDauVao.aspx">VAT đầu vào</a></li>
                    <li><a href="BaoCaoVATDauRa.aspx">VAT đầu ra</a></li>
                </ul>    
	        </li>

        </ul>
    </div>
    <br />
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
		<td valign="top" style="padding-left:0px;padding-right:0px; width: 100%;"  align = "left">
		    <table cellpadding = "0" cellspacing = "0" border = "0" width = "100%">
		        <tr>
		            <td width = "100%" align = "left"  style ="height:25px; background:url(../images/menuloop.png) repeat-x scroll 0 0 transparent;">
		                <div id="tieudepk"></div>
		                <!--<span class = "Tieude">PHẦN MỀM QUẢN LÝ - Người dùng: <%= (Session["tennguoidung"] == null ? "": Session["tennguoidung"].ToString()) %> </span>
		                <span onclick = "Thoat()" style="cursor:pointer" class = "Tieude">[Thoát]</span>-->
		            </td>
		        </tr>		        
		    </table>
		</td>
    </tr>
</table>
</div>