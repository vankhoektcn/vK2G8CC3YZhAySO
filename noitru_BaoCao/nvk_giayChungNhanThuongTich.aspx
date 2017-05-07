<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nvk_giayChungNhanThuongTich.aspx.cs"
    Inherits="nvk_giayChungNhanThuongTich" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!--#include file ="../noitru/nvk_headerTongHop.htm"-->
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
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
function btnTimKiem_click(control)
{
var mabenhnhan= $("#txtmabenhnhan").val();
var tenbenhnhan= $("#txttenbenhnhan").val();
    $(control).TimKiem({
                    ajax: "../ajax/nvk_commonFuntion_ajax.aspx?do=TimKiemBenhNhan&mabenhnhan="+mabenhnhan +"&tenbenhnhan="+tenbenhnhan+""
                    ,tilte: "Danh dách bệnh nhân", width:"1000px", height:"400px"
            });
}
function setNoiDungChungNhan(idbenhnhan)
{
    var PathUrl="../ajax/nvk_commonFuntion_ajax.aspx?do=setNoiDungChungNhan&idbenhnhan="+idbenhnhan+"";	            
        $.ajax
            ({
                 type:"GET",
                 cache:false,
                 url:PathUrl,
                  success: function (value)
                    {
                        if(value != "")
                        {
                            var data= value.split('|');
                            $("#soCN").val(data[0]);
                            $("#txtSoVaoVien").val(data[1]);
                            $("#TenBenhNhan").val(data[2]);
                            $("#txtNgaySinh").val(data[3]);
                            $("#txtGioiTinh").val(data[4]);
                            $("#txtNgheNghiep").val(data[5]);
                            $("#txtNoiLamViec").val(data[6]);
                            
                            $("#txtCMND").val(data[7]);
                            $("#txtNgay_noiCM").val(data[8]);
                            $("#txtDiaChi").val(data[9]);
                            $("#txtVaoVienLuc").val(data[10]);
                            $("#txtRaVienLuc").val(data[11]);
                            $("#lyDoVaoVien").val(data[12]);
                            
                            $("#chanDoan").val(data[13]);
                            $("#dieuTri").val(data[14]);
                            $("#thuongTichVaovien").val(data[15]);
                            $("#thuongTichRavien").val(data[16]);
                        //$.mkv.dongtimkiem('default');                            
				        //$.mkv.closeDivTimKiem();
                          $.mkv.dongtimkiem('default'); 
                        }
                    }
            });
}
function btnMoi_click()
{
    $("#soCN").val("");
    $("#txtSoVaoVien").val("");
    $("#TenBenhNhan").val("");
    $("#txtNgaySinh").val("");
    $("#txtGioiTinh").val("");
    $("#txtNgheNghiep").val("");
    $("#txtNoiLamViec").val("");
    
    $("#txtCMND").val("");
    $("#txtNgay_noiCM").val("");
    $("#txtDiaChi").val("");
    $("#txtVaoVienLuc").val("");
    $("#txtRaVienLuc").val("");
    $("#lyDoVaoVien").val("");
    
    $("#chanDoan").val("");
    $("#dieuTri").val("");
    $("#thuongTichVaovien").val("");
    $("#thuongTichRavien").val("");
    
  $("#isXacNhanThongTinChungNhan").val("0");
}
</script>

<style type="text/css">
.divControl
{
    width: 98%;
    padding:0px 5px 5px 5px;
    height:auto;
    margin: 0px 5px 5px 5px;
    text-align:center;
    
}
.fieldset_CT 
{
 border:3px solid white ;
 padding-bottom:3px;
 padding-top:3px;
 }
 .spanText
{
    padding:5px 5px 5px 5px;
    font-family:Arial;
}
.spanText_Blue
{
    padding:5px 5px 5px 5px;
    font-family:Arial;
    color:Blue;
    font-weight:bold;
}
</style>
<form id="form1" runat="server">
    <div id="divFather" style="padding: 0px 0px 0px 0px">
        <div style="height: 20px">
            <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
        </div>
        <div style="text-align: center; background: #4d67a2 url(../images/bottom_nav_bg1.jpg) no-repeat top center;
            height: 30px; margin: 10 auto; padding-top: 5px">
            <%--#D4c0c0,#808080 ; background-color: #AAE3FF--%>
            <span style="font-weight: bold; font-size: 18px; color: White;">Giấy Chứng Nhận Thương
                Tích </span>
        </div>
        <div id="divTK1" class="divControl">
            <fieldset class="fieldset_CT">
                <legend class="legend_CT">Tìm kiếm bệnh nhân</legend><span class="spanText">Mã bệnh
                    nhân:</span><input mkv="true" id="txtmabenhnhan" type="text" style="width: 110px" />
                <span class="spanText">Tên bệnh nhân:</span>
                <input mkv="true" id="txttenbenhnhan" type="text" style="width: 150px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" id="btnTimKiem" onclick="btnTimKiem_click(this)" value="Tìm Kiếm"
                    style="width: 80px" />
                <input type="button" id="btnMoi" onclick="btnMoi_click()" value="Mới" style="width: 80px" />
            </fieldset>
        </div>
        <table style="width: 1300px; height: auto; border: solid 2px White">
            <tr>
                <td style="width: 50%; border: solid 1px Black; text-align: justify; vertical-align: top;">
                    <div id="divBenhNhan" style="padding: 10px 10px 10px 10px; width: 650px; overflow-x: scroll;">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    Số:
                                </td>
                                <td>
                                    <input type="text" runat="server"  style="width: 80px"  id="soCN" />/CN:
                                </td>
                                <td>
                                    Số vào viện:
                                </td>
                                <td>
                                    <input type="text" runat="server" style="width: 80px" id="txtSoVaoVien" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Bệnh nhân:
                                </td>
                                <td>
                                    <input type="text" runat="server" style="width: 150px" id="TenBenhNhan" /></td>
                                <td>
                                    Sinh ngày:
                                </td>
                                <td>
                                    <input type="text" runat="server" style="width: 150px" id="txtNgaySinh" />
                                    <input type="text" runat="server" style="width: 50px" id="txtGioiTinh" />
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    Nghề nghiệp:
                                </td>
                                <td>
                                    <input type="text" runat="server" style="width: 150px" id="txtNgheNghiep" /></td>
                                <td>
                                    Nơi làm việc:
                                </td>
                                <td>
                                    <input type="text" runat="server" style="width: 150px" id="txtNoiLamViec" /></td>
                            </tr>
                            <tr>
                                <td>
                                    Số CMDN/Hộ khẩu:
                                </td>
                                <td>
                                    <input type="text" runat="server" style="width: 150px" id="txtCMND" /></td>
                                <td>
                                    Ngày và nơi cấp:
                                </td>
                                <td>
                                    <input type="text" runat="server" style="width: 150px" id="txtNgay_noiCM" /></td>
                            </tr>
                            <tr>
                                <td >Địa chỉ: </td>
                                <td colspan="3">
                                <input type="text" runat="server" style="width: 500px" id="txtDiaChi" />
                                </td>
                            </tr>
                            
                            <tr>
                                <td >Vào viện lúc: </td>
                                <td colspan="3">
                                <input type="text" runat="server" style="width: 500px" id="txtVaoVienLuc" />
                                </td>
                            </tr>
                            
                            <tr>
                                <td >Ra viện lúc: </td>
                                <td colspan="3">
                                <input type="text" runat="server" style="width: 500px" id="txtRaVienLuc" />
                                </td>
                            </tr>
                            
                            <tr>
                                <td >Lý do vào viện: </td>
                                <td colspan="3">
                                <textarea runat="server" style="width: 500px" id="lyDoVaoVien" rows="3" ></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td >Chẩn đoán: </td>
                                <td colspan="3">
                                <textarea runat="server" style="width: 500px" id="chanDoan" rows="4" ></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td >Điều trị: </td>
                                <td colspan="3">
                                <textarea runat="server" style="width: 500px" id="dieuTri" rows="4" ></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td >Tình trạng thương tích lúc vào viện: </td>
                                <td colspan="3">
                                <textarea runat="server" style="width: 500px" id="thuongTichVaovien" rows="6" ></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td >Tình trạng thương tích lúc ra viện: </td>
                                <td colspan="3">
                                <textarea runat="server" style="width: 500px" id="thuongTichRavien" rows="6" ></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center"><input type="button" runat="server" value="Đồng ý" id="btnDongY" onserverclick="btnDongY_ServerClick" />
                                    <input type="hidden" runat="server" id="isXacNhanThongTinChungNhan" value="0"/>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 50%; border: solid 1px Black">
                    <div id="divCongNo" style="width: 100%; overflow-y: scroll; overflow-x: scroll">
                        <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"
                            displaygrouptree="False" printmode="ActiveX" width="99%" onunload="CrystalReportViewer1_Unload" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</form>
<!--#include file ="../noitru/footer.htm"-->
