<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nvk_KhamNoiTruTongHop.aspx.cs"
    Inherits="nvk_KhamNoiTruTongHop" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%--<%@ Register Src="../usercontrols/NVK_sinhhieu.ascx" TagName="sinhhieu" TagPrefix="uc1" %>
<%@ Register Src="~/noitru/usercontrol/DichvuCLSChonTheoDoiCC.ascx" TagName="ChiDinhDichVu"
    TagPrefix="uc2" %>
<%@ Register Src="~/noitru/usercontrol/ThuocChonTheoDoiCC.ascx" TagName="ChiDinhThuoc"
    TagPrefix="uc3" %>--%>
<!--#include file ="../noitru/nvk_headerTongHop.htm"-->
<link href="../css/jquery.ui.tabs.css" rel="stylesheet" type="text/css" />

<style type="text/css">
.div-Out
{
	float: left;
	padding: 0px 0px 0px 20px;
	width: 460px;
	height:40px;
	background-color:#D4D0C8;
	border-bottom: 1px solid #D4D0C8;
	border-right: 1px solid #D4D0C8;
	clear:none
}
.body-div .in-a
     {
        padding-bottom: 10px;display:table;width:100%;padding-top:0px;
     }
.div-Left
{
	float: left; 
	padding: 10px 0px 10px 0px;
	height:100%;
}

.div-Right
{
	width: 70%; 
	background-color:#D4D0C8;
	float: right;
	height:75%; 
	border-left: 1px solid #D4D0C8; 
	padding: 10px 0px 0px 20px;
}
.body-div-button{
        background: #D4D0C8; text-align: center;
        position:relative;
        margin:auto;
         border: 1px solid #D4D0C8;
        padding: 5px 5px 5px 5px;border-Top:none;width:98.8%;
        
     }
fieldset 
{
 border:1px solid white ;
 padding-bottom:3px;
 padding-top:10px;
 }

legend {
 color:Blue;
    padding:2px;
    margin-left: 14px;
    font-weight:bold;
    font-size: 14px;
    font-style:italic;
  }
</style>
<script type="text/javascript">

$(function() {
	$(".tabmenu").removeClass("hidden");
	$(".tabs h2").addClass("hidden");
	$(".tabs").tabs();
	$.mkv.removeQueryString('idkhoachinh');
    $.mkv.removeQueryString('idbenhnhan');
    $.mkv.removeQueryString('idctdkk');
    $.mkv.removeQueryString('LuuMoiKhamBenh');
    $.mkv.removeQueryString('LoaiBN');
    $("input[type=text],input[type=checkbox],select,textarea").live("focus",function(){
            $(this).css("background-color","yellow");//#AABBCC, #CAE3FF
          }).live("blur",function(){
                  $(this).css("background-color","");
          });
});
function ClearQueryString()
{
    document.getElementById('<%=hdIdKhambenhGoc.ClientID%>').value='';
    document.getElementById('<%=hdIdbenhnhan.ClientID%>').value='';
    document.getElementById('<%=hdIdCtDkk.ClientID%>').value='';
    document.getElementById('<%=hdLoaiBN.ClientID%>').value='';
    $.mkv.removeQueryString('idkhoachinh');
    $.mkv.removeQueryString('idbenhnhan');
    $.mkv.removeQueryString('idctdkk');
    $.mkv.removeQueryString('LuuMoiKhamBenh');
    $.mkv.removeQueryString('LoaiBN');
    ClearTabContent();
    $("#divBenhNhanChon").html("<span style='height: auto; width: 100%;text-align:center; color: RED; font-weight: bold;font-style:italic' class='Tieude'> CHƯA CHỌN BỆNH NHÂN !</span>");
    $("#divDSBN").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang tìm bệnh nhân.....<img id='imgLoading' src='../images/processing.gif' /></span>");
}
function ClearTabContent()
{
    $("#spTamUng").html("");
    $("#spSinhHieu").html("");
    $("#spChiDinhDichVu").html("");
    $("#spChiDinhThuoc").html("");
    $("#spTraThuoc").html("");
    $("#spTienGiuong").html("");
    $("#sXuatKhoa").html("");
    $("#spVienPhi").html("");

    $("#spSinhHieu").css("display","none");
    $("#spTamUng").css("display","none");
    $("#spChiDinhDichVu").css("display","none");
    $("#spTienGiuong").css("display","none");
    $("#spVienPhi").css("display","none");
    $("#sXuatKhoa").css("display","none");
    $("#spChiDinhThuoc").css("display","none");
    $("#spTraThuoc").css("display","none");
    $("#idKhamBenhMoiLuuDV").val("");
}
function loadInfoTamUng()
{
    if(KiemTraChonBN())
    {
        ClearTabContent();
        $('#spTamUng').css("display","");
        $("#spTamUng").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load thông tin tạm ứng.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=LoadThongTinTamUng&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"&idctdkk="+$.mkv.queryString('idctdkk')+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            $('#spTamUng').html(value);
                        }
                });
    }
}
function LoadInFoSinhHieu()
{
    if(KiemTraChonBN())
    {
        ClearTabContent();
        $("#spSinhHieu").css("display","");
        $.mkv.queryString("LuuMoiKhamBenh","1");
        $("#spSinhHieu").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load thông tin SINH HIỆU.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=LoadThongTinSinhHieu&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"&idctdkk="+$.mkv.queryString('idctdkk')+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            $("#spSinhHieu").html(value);
                            
                        }
                });
    }
}
function LoadChiDinhDichVu(page)
{
    if(page == null)
        page = "1";
    if(KiemTraChonBN())
    {
        ClearTabContent();
        $("#spChiDinhDichVu").css("display","");
        $.mkv.queryString("LuuMoiKhamBenh","1");
        $("#spChiDinhDichVu").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load thông tin dịch vụ.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=LoadThongTinCDDichVu&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"&idctdkk="+$.mkv.queryString('idctdkk')+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"&nvk_idkhoachinh="+$.mkv.queryString("idkhoachinh")+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl+"&page="+page,
                      success: function (value)
                        {
                            $("#spChiDinhDichVu").html(value);
                        }
                });
    }
}
function LoadInfoChiDinhThuoc()
{
    if(KiemTraChonBN())
    {
        ClearTabContent();
        $("#spChiDinhThuoc").css("display","");
        $.mkv.queryString("LuuMoiKhamBenh","1");
        $("#spChiDinhThuoc").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load thông tin Thuốc,VTYT.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=LoadInfoCDThuoc&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"&idctdkk="+$.mkv.queryString('idctdkk')+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            //$("#spChiDinhThuoc").html(value);
                            document.getElementById("spChiDinhThuoc").innerHTML=value;
                            loadTableAjaxchitietbenhnhantoathuoc();
                            SetBacSiChiDinh();
                            SetChanDoanXacDinh();
                            SetChanDoanPhoiHop();  
                            LoadDsThuocCd();                          
                        }
                });
    }
}
function LoadInfoTraThuoc()
{
    if(KiemTraChonBN())
    {
        ClearTabContent();
        $("#spTraThuoc").css("display","");                           
        //$.mkv.queryString("LuuMoiKhamBenh","1");
        $("#spTraThuoc").html("<span style='height: auto; width: 100%;text-align:center; color: Green; font-weight: bold;font-style:italic' class='Tieude'> Đang load thông tin trả Thuốc,VTYT.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=LoadInfoTraThuoc&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"&idctdkk="+$.mkv.queryString('idctdkk')+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            $("#spTraThuoc").html(value);                           
                        }
                });
    }
}
function loadInfoTienGiuong()
{
    if(KiemTraChonBN())
    {
        ClearTabContent();
        $('#spTienGiuong').css("display","");
        $("#spTienGiuong").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load thông tin tiền giường.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=LoadThongTinTienGiuong&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"&idctdkk="+$.mkv.queryString('idctdkk')+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            $('#spTienGiuong').html(value);
                        }
                });
    }
}
function loadInfoVienPhi()
{
    if(KiemTraChonBN())
    {
        ClearTabContent();
        $('#spVienPhi').css("display","");
        $("#spVienPhi").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load thông tin viện phí.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=LoadThongTinVienPhi&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"&idctdkk="+$.mkv.queryString('idctdkk')+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            $('#spVienPhi').html(value);
                        }
                });
    }
}
function loadInfoXuatKhoa(HdtID)
{
    if(KiemTraChonBN())
    {
        ClearTabContent();
    var idhuongdieutri=HdtID;
        if(HdtID ==null)
        {
            idhuongdieutri="0";
        }
        $('#sXuatKhoa').css("display","");
        $("#sXuatKhoa").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load thông tin xuất khoa.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=LoadThongTinXuatKhoa&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"&idctdkk="+$.mkv.queryString('idctdkk')+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"&hdtQueRy="+idhuongdieutri+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                        $('#sXuatKhoa').html(value);
                        }
                });
    }
}     
function KiemTraChonBN()
{
    var idkhoachinh= document.getElementById('<%=hdIdKhambenhGoc.ClientID%>').value;
    if($.mkv.queryString("idkhoachinh")==null || $.mkv.queryString("idkhoachinh")=="" || idkhoachinh=="" || idkhoachinh=="0")
    {
        alert("Chưa chọn bệnh nhân !");
        document.getElementById('tab-2').innerHTML="";
        return false;
    }
    else
        return true;
}
function TimKiemBenhNhan()
{
    ClearQueryString();
    var mabenhnhan= document.getElementById('<%=txtMaBenhNhan.ClientID %>').value;
    var tenbenhnhan= document.getElementById('<%=txtTenBenhNhan.ClientID %>').value;
    var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=TimKiemBenhNhan&mabenhnhan="+mabenhnhan+"&tenbenhnhan="+encodeURIComponent(tenbenhnhan)+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            document.getElementById('<%=divDSBN.ClientID %>').innerHTML=value;
                        }
                });
}

function XuatExcelDSNoiTru()
{
    var mabenhnhan= document.getElementById('<%=txtMaBenhNhan.ClientID %>').value;
    var tenbenhnhan= document.getElementById('<%=txtTenBenhNhan.ClientID %>').value;
    var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=XuatExcelDSNoiTru&mabenhnhan="+mabenhnhan+"&tenbenhnhan="+encodeURIComponent(tenbenhnhan)+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            window.open(value,"_blank");
                        }
                });
}
function LoadUsercontrol(tabb)
{
    if(KiemTraChonBN())
    {
        var fileascx = "";
        if(tabb == "sinhhieu")
        	fileascx = "~/usercontrols/NVK_sinhhieu.ascx";
        else if(tabb == "dichvu")
            fileascx = "~/noitru/usercontrol/DichvuCLSChonTheoDoiCC.ascx";
        else if(tabb == "thuoc")
            fileascx = "~/noitru/usercontrol/ThuocChonTheoDoiCC.ascx";
	    $("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
	    $.ajax({
              type: "GET",
              contentType: "application/json; charset=utf-8",
              url: "nvk_KhamNoiTruTongHop.aspx/Result",
              data: "{controlName:'"+fileascx+"'}",
               success: function (response) {
                    $("#tab-2").html(response);
                    $("#loadingAjax").remove();
               }
         });

    }
}
function SetBenhNhanDangKham(idbn,idchitietdangkykham)
{
        ClearTabContent();
            $("#divBenhNhanChon").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang chọn.....<img id='imgLoading' src='../images/processing.gif' /></span>");
	        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=SetBenhNhanDangKham&idbenhnhan="+idbn+"&idctdkk="+idchitietdangkykham+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            var arrValue=value.split('~~');
                                $("#divBenhNhanChon").html(arrValue[0]);
                                document.getElementById('<%=hdHtmlBenhNhanChon.ClientID%>').innerHTML=arrValue[0];
                                document.getElementById('<%=hdIdKhambenhGoc.ClientID%>').value=arrValue[1];
                                document.getElementById('<%=hdLoaiBN.ClientID%>').value=arrValue[2];
                                document.getElementById('<%=hdIdbenhnhan.ClientID%>').value=idbn;
                                document.getElementById('<%=hdIdCtDkk.ClientID%>').value=idchitietdangkykham;
                                    $.mkv.queryString("idkhoachinh",arrValue[1]);
                                    $.mkv.queryString("idbenhnhan",idbn);
                                    $.mkv.queryString("idctdkk",idchitietdangkykham);
                                    $.mkv.queryString("LoaiBN",arrValue[2]);
                        }
                });
	    }
//-----------------TẠM ỨNG nvk tamung---------------------------

//-----------------END TẠM ỨNG---------------------------
//-----------------TIỀN GIƯỜNG nvk tiengiuong---------------------------
//--------------------\?/---------------------------------

      ///
	// End Nội Dung xủ lý trong table 
	
	
//-----------------END TIỀN GIƯỜNG---------------------------
//\\\\\\\\\\\\\\\\\\\\\\\////////////////////////////////////

//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]ư[[[[[[[[[[[[[[[[[[[[[[[[[[[[ơ
//-=========-=-=-=-=-=-=-=-= CHỈ ĐỊNH DỊCH VỤ nvk dichvu
function DongChiDinhCLS_Click(idbenhnhan,idkhambenhDong)
{
    document.getElementById('idKhamBenhMoiLuuDV').value=idkhambenhDong;
    $.mkv.queryString("LuuMoiKhamBenh","0");//alert(document.getElementById('idKhamBenhMoiLuuDV').value);
    loadTableAjaxkhambenhcanlamsan(idkhambenhDong);
    SetBacSiChiDinh();SetChanDoanXacDinh();SetChanDoanPhoiHop();
}
function DongChiDinhThuoc_Click(idbenhnhan,idkhambenhDong)
{
    document.getElementById('idKhamBenhMoiLuuDV').value=idkhambenhDong;
    $.mkv.queryString("LuuMoiKhamBenh","0");//alert(document.getElementById('idKhamBenhMoiLuuDV').value);
    loadTableAjaxchitietbenhnhantoathuoc(idkhambenhDong);
    document.getElementById("btnToaThuocCu").style.display="none";
    SetBacSiChiDinh();SetChanDoanXacDinh();SetChanDoanPhoiHop();
}

function DongVienPhiCLS_Click(idbenhnhan,idkhambenhDong,maPhieuCLS,obj)
{
    $(obj).TimKiem({
            ajax:"../ajax/nvk_khamTongHop_ajax.aspx?do=LoadChiTietVienPhiCLS&idKBVienPhi="+idkhambenhDong+"&MaPhieuCLS="+maPhieuCLS+"&idbenhnhan="+idbenhnhan+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+""
        },null,null,function(){
        });
}
function DongVienPhiThuoc_Click(idbenhnhan,idkhambenhDong,LanCDthuoc,obj)
{
    $(obj).TimKiem({
            ajax:"../ajax/nvk_khamTongHop_ajax.aspx?do=LoadChiTietVienPhiThuoc&idKBVienPhi="+idkhambenhDong+"&LanCDthuoc="+LanCDthuoc+"&idbenhnhan="+idbenhnhan+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+""
        },null,null,function(){
        });
}
function btnMau02_click()
{
    window.open("../noitru/frm_Rpt_BieuMau02.aspx?idchitietdangkykham="+$.mkv.queryString('idctdkk'),'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');  
}
function btnMauTH_click()
{
    window.open("../noitru/frm_rpt_BangKeVienPhiTheoKhoa.aspx?idchitietdangkykham="+$.mkv.queryString('idctdkk'),'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');  
}
function btnMauHaoPhi_click()
{
    window.open("../noitru_BaoCao/TT_rptDanhsachhaophi.aspx?idctdkk="+$.mkv.queryString('idctdkk')+"&idkhoa="+$.mkv.queryString("IdKhoa")+"",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');  
}

function btnDongChiTra_click()
{
    window.open("../VienPhi_BH/frm_rpt_ChiPhiDongChiTra_new.aspx?idchitietdangkykham="+$.mkv.queryString('idctdkk'),'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');  
}

function btnCongNo_click()//
{
    window.open("../noitru_BaoCao/nvk_ChiTietCongNoBenhNhan.aspx?dkmenu="+$.mkv.queryString('dkmenu')+"&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"&idctdkk="+$.mkv.queryString('idctdkk')+"&IdKhoa="+$.mkv.queryString("IdKhoa")+"",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');  
}

function btnXemHSBA_click()
{
    alert("3");    
}
function btnInHSBA_click()
{
    alert("6");    
}
//-----------------END CHỈ ĐỊNH DỊCH VỤ nvk dichvu---------------------------
//\\\\\\\\\\\\\\\\\\\\\\\////////////////////////////////////

// /ư/ư/ư/ư/ư/ư/ư/ư/ư   XUẤT KHOA - HƯỚNG ĐIỀU TRỊ nvk xuatkhoa \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
function LoadNoiDungHuongDieuTri(idbenhnhan,idctdkk,idkhoa)
{
    var HdtID=document.getElementById("slHuongDieuTri").value;
    loadInfoXuatKhoa(HdtID);
}
function LoadNoiDungPhongDen(idloaiBN)
{
    var HdtID=document.getElementById("slHuongDieuTri").value;
    var IDKhoaSelect=document.getElementById("slKhoaChuyenToi").value;    
    if(HdtID=="1")
    {
        $("#spchuyenPhong").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load phòng khám.....<img id='imgLoading' src='../images/processing.gif' /></span>");        
        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=LoadNoiDungPhongDen&IdKhoaSelect="+IDKhoaSelect+"&idloaiBN="+idloaiBN+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            if(value!="")
                            {
                            document.getElementById("spchuyenPhong").innerHTML=value;
                            }              
                        }
                });
    }
}
 
	function InPhieuChuyenVien(idctdkk_CV,idbenhnhan,idkhoa)
	{
	    window.open("../khambenh/frmGiayChuyenVien.aspx?idctdkk="+idctdkk_CV+"&IdKhoa="+$.mkv.queryString('IdKhoa')+"#isPrint=1",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	}
	function InPhieuRaVien(idkhambenh,nvk_idkhoa)
	{
	    //window.open("../nhanbenh/rptRaVien.aspx?idphieutt="+idkhambenh+"&IdKhoa="+nvk_idkhoa+"#isPrint=1",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	    //window.open("../noitru_BaoCao/rptRaVien_InDe.aspx?idphieutt="+idkhambenh+"&IdKhoa="+nvk_idkhoa+"#isPrint=1",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	    window.open("../noitru_BaoCao/rptRaVien.aspx?idphieutt="+idkhambenh+"&IdKhoa="+nvk_idkhoa+"#isPrint=1",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	}
	
//	$.mkv.afterThemDong= function(tableName, dongso) 
//	    {	    
//	    var DonViCoBan=$("#"+tableName).find("tr").eq(dongso+1).find("#DonViCoBan");
//	    if(DonViCoBan.lenght>0 )
//	        {
//	        DonViCoBan.attr("disabled",true);
//	        }
//		}


// /ư/ư/ư/ư/ư/ư/ư/ư/ư end  XUẤT KHOA - HƯỚNG ĐIỀU TRỊ nvk xuatkhoa \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

/// THÔNG TIN ĐO SINH HIỆU nvk sinhhieu
function tinhBMI()
          {
             //$("#BMI").val((eval($("#chieucao").val())*eval($("#chieucao").val()))/eval($("#cannang").val()));
             var BpChieuCao= (eval($("#chieucao").val())/100) * (eval($("#chieucao").val())/100);
             var CanNang = eval($("#cannang").val());
             $("#BMI").val(CanNang / BpChieuCao);
          }
function btnLuuSH_click()
{
    var idSinhHieu=document.getElementById("hdIdSinhHieu").value;
    var ngaydo=document.getElementById("txtNgayDo").value;
    var mach=document.getElementById("mach").value;
    var nhietdo=document.getElementById("nhietdo").value;
    var huyetap1=document.getElementById("huyetap1").value;
    var huyetap2=document.getElementById("huyetap2").value;
    var nhiptho=document.getElementById("nhiptho").value;
    var chieucao=document.getElementById("chieucao").value;
    var cannang=document.getElementById("cannang").value;
    var BMI=document.getElementById("BMI").value;
    
        $("#spDangLuuSH").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang luu sinh hiệu.....<img id='imgLoading' src='../images/processing.gif' /></span>");        
        var LisQueRy="&idSinhHieu="+idSinhHieu+"&ngaydo="+ngaydo+"&mach="+mach+"&nhietdo="+nhietdo+"&huyetap1="+huyetap1+"&huyetap2="+huyetap2+"&nhiptho="+nhiptho+"&chieucao="+chieucao+"&cannang="+cannang+"&BMI="+BMI;
        //alert(LisQueRy);//return;
        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=LuuThongTinSinhHieu&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"&idctdkk="+$.mkv.queryString('idctdkk')+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+""+LisQueRy;
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            if(value!="")
                            {
                            document.getElementById("hdIdSinhHieu").value=value;
                            document.getElementById("spDangLuuSH").innerHTML="";
                            LoadDanhSachSinhHieu();
                            }              
                        }
                });
}
function LoadDanhSachSinhHieu()
{
    $("#divDSSinhHieu").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load danh sách Sinh Hiệu.....<img id='imgLoading' src='../images/processing.gif' /></span>");        
        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=LoadDanhSachSinhHieu&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"&idctdkk="+$.mkv.queryString('idctdkk')+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"";
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            if(value!="")
                            {
                            document.getElementById("divDSSinhHieu").innerHTML=value;                            
                            }              
                        }
                });
}
function LoadNoiDungSinhHieu(idsinhHieu)
{
    $("#divDoSinhHieu").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load nội dung Sinh Hiệu.....<img id='imgLoading' src='../images/processing.gif' /></span>");        
        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=LoadNoiDungDoSinhHieu&idsinhHieu="+idsinhHieu+"&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"&idctdkk="+$.mkv.queryString('idctdkk')+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"";
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            if(value!="")
                            {
                            document.getElementById("divDoSinhHieu").innerHTML=value;                            
                            }              
                        }
                });
}
function HuyTheoDoi(idctdkk,idkhoanoitru)
{
    var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=HuyTamTheoDoi&idctdkk="+idctdkk+"&IdKhoaNoiTru="+idkhoanoitru+"";
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            if(value=="1")
                            {
                                alert("Đã Loại bệnh nhân khỏi danh sách theo dõi !");
                                TimKiemBenhNhan();
                            }
                            else
                            {
                                alert(value);
                            }
                        }
                });
}
function view_tamung(idtamung)
{
    window.open("../DanhMuc_JSon/web/tamUng.aspx?idkhoachinh=" + idtamung + "&dkmenu=" + $.mkv.queryString("dkmenu"),"_blank");
}

// END THÔNG TIN ĐO SINH HIỆU NVK SINHHIEU
</script>

<form id="Form1" method="post" runat="server" style="background-color: #D4D0C8">
    <asp:scriptmanager runat="server" id="script"></asp:scriptmanager>
    <div>
        <span id="hdHtmlBenhNhanChon" style="display: none" runat="server"></span>
        <div class="tabs" style="padding-top: 1%; background-color: #D4D0C8">
            <asp:placeholder id='PlaceHolder1' runat="server"> </asp:placeholder>
            <div style="text-align: center; background: #4d67a2 url(../images/bottom_nav_bg1.jpg) no-repeat top center; height: 30px;margin:10 auto;padding-top:5px">
                <span style="font-weight: bold; font-size: 18px; color: White;">
                KHÁM CHỮA BỆNH TỔNG HỢP
                </span>
            </div>
            <table style="width: 100%; background-color: Silver;border-collapse:separate;" bordercolor="white" border=3 >
                <tr>
                    <td style="height: auto; width: 75%;">
                        <span style="height: auto; width: 70%; color: #0000cc; font-weight: bold" class="Tieude">
                            I. Danh sách bệnh nhân chờ :</span>
                        <input style="width: 33px" id="hdIdbenhnhan" type="hidden" runat="server" />
                        <input style="width: 33px" id="hdIdKhambenhGoc" type="hidden" runat="server" />
                        <input style="width: 33px" id="hdIdCtDkk" type="hidden" runat="server" />
                        <input style="width: 33px" id="hdLoaiBN" type="hidden" runat="server" />
                        Mã bệnh nhân :<input type="text" id="txtMaBenhNhan" runat="server" style="width: 120px;
                            height: 15px" />
                        Tên bệnh nhân :<input type="text" id="txtTenBenhNhan" runat="server" style="width: 180px;
                            height: 15px" />
                        <input type="button" value="Lấy DS" style="width: 80px" onclick="TimKiemBenhNhan()" />
                        <input type="button" value="Xuất Excel" style="width: 100px" onclick="XuatExcelDSNoiTru()" />
                        &nbsp;&nbsp;
                        <div runat="server" id="divDSBN" style="height: 150px; overflow-y: scroll">
                        </div>
                    </td>
                    <td style="width: 25%">
                        <span style="height: auto; width: 70%; color: #0000cc; font-weight: bold" class="Tieude">
                            II. Bệnh nhân đang khám :</span>
                        <br />
                        <div runat="server" id="divBenhNhanChon"  style="height: 150px; overflow-y: scroll">
                            <span style="height: auto; width: 100%; text-align: center; color: RED; font-weight: bold;
                                font-style: italic" class="Tieude">CHƯA CHỌN BỆNH NHÂN ! </span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                    </td>
                </tr>
            </table>
            <!--begin edit-->
            <div id="tabs" class="ui-tabs ui-widget ui-widget-content ui-corner-all" style="width:98%">
                <ul class="main_tab ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all"
                    id="menu_tab">
                    <li class="ui-state-default ui-corner-top">
                        <a href="#tab-1" name="hr_Tamung" onclick="loadInfoTamUng();">Công Nợ - Tạm ứng<div class="nav_right"></div></a>
                    </li>
                    <li class="ui-state-default ui-corner-top " >
                        <a href="#tab-2" name="hr_SinhHieu" onclick="LoadInFoSinhHieu();">Sinh hiệu<div class="nav_right"></div></a>
                    </li>
                    <li class="ui-state-default ui-corner-top " >
                        <a href="#tab-3" name="hr_DichVu" onclick="LoadChiDinhDichVu();">Chỉ đinh dịch vụ<div class="nav_right"></div></a>
                    </li>
                    <li class="ui-state-default ui-corner-top " >
                        <a href="#tab-4" name="hr_Thuocvtyt" onclick="LoadInfoChiDinhThuoc();">Chỉ định thuốc, VTYT...<div class="nav_right"></div></a>
                    </li>
                    <li class="ui-state-default ui-corner-top " >
                        <a href="#tab-8" name="hr_Trathuoc" onclick="LoadInfoTraThuoc();">Trả thuốc, VTYT...<div class="nav_right"></div></a>
                    </li>
                    <li class="ui-state-default ui-corner-top " >
                        <a href="#tab-5" name="hr_SocialRelation" onclick="loadInfoTienGiuong();">Tiền giường<div class="nav_right"></div></a>
                    </li>
                   
                    <li class="ui-state-default ui-corner-top " >
                        <a href="#tab-6" name="hr_XuatKhoa" onclick="loadInfoXuatKhoa();">Xuất khoa - hướng điều trị<div class="nav_right"></div></a>
                    </li>
                 </ul>
            </div>
         
            <div id="tab-1" style="width: 98%;clear:both">
                <div id="spTamUng"></div>
            </div>
            <div id="tab-2" style="width: 98%;clear:both;">
                <div id="spSinhHieu">
                </div>
            </div>
            <div id="tab-3" style="width: 98%;clear:both;">
                <div id="spChiDinhDichVu">
                </div>
            </div>
            <div id="tab-4" style="width: 98%;clear:both;">
                <div id="spChiDinhThuoc">
                </div>
            </div>
            <div id="tab-8" style="width: 98%;clear:both;">
                <div id="spTraThuoc">
                </div>
            </div>
            <div id="tab-5" style="width: 98%;clear:both;">
                <div id="spTienGiuong" style="text-align: center"></div>
            </div>
            <div id="tab-6" style="width: 98%;clear:both;">
                <div runat="server" id="spVienPhi"></div>
            </div>
            <div id="tab-7" style="width: 98%;clear:both;">
                <div runat="server" id="sXuatKhoa"></div>
            </div>
        </div>
    </div>
    <input type="hidden" id="txtidbn" />
    <input type="hidden" id="idddk" />
    <div id="test"></div>
</form>
<!--#include file ="footer.htm"-->