<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nvk_ChiTietCongNoBenhNhan.aspx.cs" Inherits="noitru_BaoCao_nvk_ChiTietCongNoBenhNhan" %>

<!--#include file ="../noitru/nvk_headerTongHop.htm"-->
<style type="text/css">

legend {
 color:Blue;
    padding:2px;
    margin-left: 14px;
    font-weight:bold;
    font-size: 14px;
    font-style:italic;
  }
#table_BenhNhanCongNo
{
	border: white 3px;
	/*background-color: #ecf1f7;*/
}
#table_BenhNhanCongNo td
{
	border: white 1.5px;
	padding: 5px 5px 5px 5px;
	text-align: left;
}
</style>
<script type="text/javascript">
window.onload = function () 
	{
	    ThongTinBenhNhan();
	};
function ThongTinBenhNhan()
{
    var idbn = $.mkv.queryString('idbenhnhan');
    var idchitietdangkykham = $.mkv.queryString('idctdkk');
            $("#divBenhNhan").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Thông tin Bệnh Nhân.....<img id='imgLoading' src='../images/processing.gif' /></span>");
	        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=SetBenhNhanCongNo&idbenhnhan="+idbn+"&idctdkk="+idchitietdangkykham+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            var arrValue=value.split('~~');
                            //alert("idbn="+idbn+"; idchitietdangkykham="+idchitietdangkykham+"; value="+value);
                                $("#divBenhNhan").html(arrValue[0]);
	                            loadChiTietCongNoBenhNhan();
                        }
                });
 }
function loadChiTietCongNoBenhNhan()
{
    $("#divCongNo").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load thông tin công nợ.....<img id='imgLoading' src='../images/processing.gif' /></span>");
    var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=loadChiTietCongNoBenhNhan&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"&idctdkk="+$.mkv.queryString('idctdkk')+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"&IsShowTamUng="+$.mkv.queryString("IsShowTamUng")+"";	            
        $.ajax
            ({
                 type:"GET",
                 cache:false,
                 url:PathUrl,
                  success: function (value)
                    {
                        document.getElementById('divCongNo').innerHTML=value;
                    }
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

</script>
    <form id="form1" runat="server">
    <div id="divFather" style="padding: 0px 0px 0px 0px">
    <div style="text-align: center; background: #4d67a2 url(../images/bottom_nav_bg1.jpg) no-repeat top center; height: 30px;margin:10 auto;padding-top:5px">
                <%--#D4c0c0,#808080 ; background-color: #AAE3FF--%>
                <span style="font-weight: bold; font-size: 18px; color: White;">
                Chi tiết công nợ bệnh nhân
                </span>
    </div>
    <div id="divBenhNhan" style="padding:10px 10px 10px 10px" align="center">
    </div>
    <div id="divCongNo"></div>
    </div>
    </form>
<!--#include file ="../noitru/footer.htm"-->
