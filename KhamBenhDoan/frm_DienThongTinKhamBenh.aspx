<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_DienThongTinKhamBenh.aspx.cs"
    Inherits="khambenh_frm_DienThongTinKhamBenh" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!--#include file ="header.htm"-->

<script language="javascript" type="text/javascript">
    var dp_cal;     
    var dp_cal1; 
    var noigioithieu;
	window.onload = function () 
	{
	    
	    document.getElementById("Button10").focus();
	 dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtNgayKham'));
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtngayhen'));
	    $("table .down_select_thuoc").live('hover',function(){
        $(this).after($("<img onmouseout='this.style.backgroundColor=\"\";this.style.border=\"0\";' onmouseover='this.style.backgroundColor=\"#ece9d8\"' src='../images/asc.gif' style='position:absolute;margin-left:-25px;margin-top:6px;padding:5px 0 5px 0;border:none;' onclick=\"$(this).parents('table').find('#"+$(this).attr("id")+"').abc();\"/>"));
     });            
	};
	
	// FUNCTION CALL USING 
	function  calculateBMI() 
	{
        var weight =0;// eval(document.getElementById("txtcannang").value);
        var cannang=$("#txtcannang").val();
        if(cannang != null && cannang !="" && cannang != "undefined")
            weight= eval(cannang);
        var height =0;// document.getElementById("txtchieucao");
        var chieucao=$("#txtchieucao").val();
        if(chieucao != null && chieucao !="" && chieucao != "undefined")
            height= eval(chieucao);
        var height2 = height / 100.0
        var BMI = weight  / (height2 * height2)
        $("#txtbmi").val(Math.round(BMI * 100)/100);
        
    }
	// END FUNCTION CALL USING

function showDanhSachBenhNhan(IsKQCLS)
{
	var dk = document.getElementById("dkLoadCho").value;
	var  idpk=document.getElementById("idPKbenh").value;
	var  idbs=document.getElementById("ddlBS").value;
	if(idpk=="0" && idbs == "0")
	{
	    alert("Vui lòng chọn phòng khám và bác sĩ trước khi lấy DS bệnh nhân chờ sinh hiệu!");
	}
	else
    {
        var ngaytp = document.getElementById("txtNgayKham");
        var td = document.getElementById("showtipbenhnhan");
        var LoaiBN="";
        var LoaiBN=document.getElementById("loaiBN").value;
        var NoiDungKCB="";
        var PhongID=document.getElementById("ddlphongkham");
        createTip(td,"tipbenhnhan","danhsachnoidungbenhnhan","Danh sách bệnh nhân","ajaxbenhnhanexists"," đang load danh sách bệnh nhân...","Lỗi trong quá trình load danh sách bệnh nhân","ajax.aspx?do=getallbenhnhanKB&ngaytp="+ngaytp.value+"&idpk="+idpk+"&idbs="+idbs+"&LoaiBN="+LoaiBN +"&NoiDungKCB="+NoiDungKCB +"&PhongID="+PhongID.value+"&IsKQCLS="+IsKQCLS+"&isDoan=1", "870", "350");   
    }
}

function LoadInFoBenhNhan(idbenhnhan,iddangkykham,IdChiTietDangKyKham,makb,oLoaiBenhNhan,songayBH,idphongkhambenh)
	{	
	document.getElementById("txtLoaiBNhidden").value=oLoaiBenhNhan; 
	document.getElementById("txtSoNgayBH").value=songayBH;
	document.getElementById("txtMaPhieuKham").value=makb;
	document.getElementById("iddangkykham").value=iddangkykham;
	document.getElementById("IdChiTietDangKyKham").value=IdChiTietDangKyKham;
	document.getElementById("idPKbenh").value=idphongkhambenh;
    
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                //alert(value);
                if(value=="")
                    alert("Không lấy được thông tin phiếu khám !");
                else
                {
                    var arr1= value.split('&');
                    for(var i=0;i<arr1.length;i++)
                    {
                        if(arr1[i] != null && arr1[i] !="")
                        {
                        try
                            {
                                var arr2= arr1[i].split('=');
                                var inPut_i=$("#"+arr2[0]+"");                               
                                switch(inPut_i[0].type)
			                    {
				                    case"checkbox":
				                        if(arr2[1]=="1")
				                        {
				                            inPut_i.attr("checked",true)
				                        }
				                        break;
				                    case"radio":
				                        if(arr2[1]=="1")
				                            inPut_i.attr("checked",true)
				                        break;
				                    default:inPut_i.val(arr2[1]);;break
			                    }
                                
                            }
                        catch (e) { }
                        }
                    }
                }
               hideTip('tipbenhnhan'); 
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=ThongTinKhamBenhTuDien&iddangkykham="+iddangkykham+"&idbenhnhan="+idbenhnhan+"&IdChiTietDangKyKham="+IdChiTietDangKyKham+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	
function LuuKBNew()
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            if (value!="0" && value!="")
            {
              $("#idkhambenh").val(value);
              alert("Lưu phiếu khám thành công");
              document.getElementById("Button10").style.display='block';
            }
            else if (value=="2")
            {
                alert("Update phiếu khám thành công");
            }
            else
            {
                alert("Thất bại");
            }
            $("#bntInPhieu2").css("display","block");
        }
    }
    var oidbn = document.getElementById("txtidbenhnhan");
    var idkhambenh = document.getElementById("idkhambenh");
    var ongaykham = document.getElementById("txtNgayKham");
    var osophieukham = document.getElementById("txtMaPhieuKham");
    var idphongkham= document.getElementById("idPKbenh");
    var IdChiTietDangKyKham=document.getElementById("IdChiTietDangKyKham");
    var chieucao=document.getElementById("txtchieucao");
    var cannang=document.getElementById("txtcannang");
    var vongnguc=document.getElementById("txtvongnguc");
    var mach=document.getElementById("txtmach");
    var huyetap=document.getElementById("txthuyetap");
    var nhietdo=document.getElementById("txtnhietdo");
    var nhiptho=document.getElementById("txtnhiptho");
    var bmi=document.getElementById("txtbmi");
    var timmach=document.getElementById("txttimmach");
    var hohap=document.getElementById("txthohap");
    var tieuhoa=document.getElementById("txttieuhoa");
    var thantietnieusinhduc=document.getElementById("txtthantietlieusinhduc");
    var thankinh=document.getElementById("txtthankinh");
    var coxuongkhopcotsong=document.getElementById("txtcoxuongkhopcotsong");
    var dalieu=document.getElementById("txtdalieu");
    //var SanPhuKhoa=document.getElementById("SanPhuKhoa");
    var KetLuanspk=document.getElementById("txtklspk");
    var matphai=document.getElementById("txtmpbt");
    var mattrai=document.getElementById("txtmtbt");
    var matphaidk=document.getElementById("txtmpdk");
    var mattraidk=document.getElementById("txtmtdk");
    var klkm=document.getElementById("txtklkm");
    var taitrai=document.getElementById("txttaitraibt");
    var taiphai=document.getElementById("txttaiphaibt");
    var taitraitt=document.getElementById("txttaitraitt");
    var taiphaitt=document.getElementById("txttaiphaitt");
    var mui=document.getElementById("txtmui");
    var hong=document.getElementById("txthong");
    var kltmh=document.getElementById("txtkltmh");
    var rhm1=document.getElementById("txtrhm1");
    var rhm2=document.getElementById("txtrhm2");
    var rhm3=document.getElementById("txtrhm3");
    var rhm4=document.getElementById("txtrhm4");
    var klrhm=document.getElementById("txtklrhm");
    var idbacsi=document.getElementById('ddlBS').value;
    //iddangkykham
    var iddangkykham=document.getElementById("iddangkykham");
    var cbXetNghiemMau= ($("#cbXetNghiemMau").is(":checked")==true ? "1":"0");
    var cbXetNghiemNuocTieu= ($("#cbXetNghiemNuocTieu").is(":checked")==true ? "1":"0");
    var cbXetNghiemKhac= ($("#cbXetNghiemKhac").is(":checked")==true ? "1":"0");
    var cbXQPhoi= ($("#cbXQPhoi").is(":checked")==true ? "1":"0");
    var cbSieuAmBung= ($("#cbSieuAmBung").is(":checked")==true ? "1":"0");
    var cbCLSkhac= ($("#cbCLSKhac").is(":checked")==true ? "1":"0");
    var IsMacBenh= ($("#rdMacBenh").is(":checked")==true ? "1":"0");
    var txtTenBenhMac="";
    if(IsMacBenh=="1")
        txtTenBenhMac= $("#txtTenBenhMac").val();
    var LoaiSK="0";
    LoaiSK= ($("#rdLoai1").is(":checked")==true ? "1":"0");
    LoaiSK= ($("#rdLoai2").is(":checked")==true ? "2":LoaiSK);
    LoaiSK= ($("#rdLoai3").is(":checked")==true ? "3":LoaiSK);
    LoaiSK= ($("#rdLoai4").is(":checked")==true ? "4":LoaiSK);
    LoaiSK= ($("#rdLoai5").is(":checked")==true ? "5":LoaiSK);
    var IsKoDuSucKhoe= ($("#rdKoDuSucKhoe").is(":checked")==true ? "1":"0");
    var tencongviec= $("#txtTenCongViec").val();
    var BSKetLuan= $("#txtBSKetLuan").val();
    var HuongGiaiQ= $("#txtHuongGiaiQ").val();
    var idHuongGiaiQuyet=$("#idHuongGiaiQuyet").val();
    var link="ajax.aspx?do=LuuKBNew&idkhambenh="+idkhambenh.value+"&idbenhnhan="+oidbn.value+"&ngaykham="+ongaykham.value+"&sophieukham="+osophieukham.value+"&idphongkham="+idphongkham.value+"&idchitietdangkykham="+IdChiTietDangKyKham.value+"&chieucao="+chieucao.value+"&cannang="+cannang.value+"&vongnguc="+vongnguc.value+"&bmi="+bmi.value+"&mach="+mach.value+"&huyetap="+huyetap.value+"&nhietdo="+nhietdo.value+"&nhiptho="+nhiptho.value+"&timmach="+encodeURIComponent(timmach.value)+"&hohap="+encodeURIComponent(hohap.value)+"&tieuhoa="+encodeURIComponent(tieuhoa.value);
    link +="&thantietnieusinhduc="+encodeURIComponent(thantietnieusinhduc.value)+"&thankinh="+encodeURIComponent(thankinh.value)+"&coxuongkhopcotsong="+encodeURIComponent(coxuongkhopcotsong.value)+"&dalieu="+encodeURIComponent(dalieu.value)+"&sanphukhoa="+encodeURIComponent(KetLuanspk.value)+"&mattrai="+encodeURIComponent(mattrai.value)+"&matphai="+encodeURIComponent(matphai.value)+"&mattraidk="+encodeURIComponent(mattraidk.value)+"&matphaidk="+encodeURIComponent(matphaidk.value)+"&klkm="+encodeURIComponent(klkm.value)+"&taitrai="+encodeURIComponent(taitrai.value)+"&taitraitt="+encodeURIComponent(taitraitt.value)+"&taiphaitt="+encodeURIComponent(taiphaitt.value)+"&taiphai="+encodeURIComponent(taiphai.value)+"&mui="+encodeURIComponent(mui.value)+"&hong="+encodeURIComponent(hong.value);
    link +="&kltmh="+encodeURIComponent(kltmh.value)+"&rhm1="+encodeURIComponent(rhm1.value)+"&rhm2="+encodeURIComponent(rhm2.value)+"&rhm3="+encodeURIComponent(rhm3.value)+"&rhm4="+encodeURIComponent(rhm4.value)+"&klrhm="+encodeURIComponent(klrhm.value)+"&iddangkykham="+iddangkykham.value+"&idbacsi="+idbacsi+"";
    link +="&xnmau="+cbXetNghiemMau+"&xnnt="+cbXetNghiemNuocTieu+"&xnk="+cbXetNghiemKhac+"&xqp="+cbXQPhoi+"&sab="+cbSieuAmBung+"&clsk="+cbCLSkhac+"&isBenh="+IsMacBenh+"&TenBenhM="+encodeURIComponent(txtTenBenhMac);
    link +="&LoaiSK="+LoaiSK+"&IsKoDuSucKhoe="+IsKoDuSucKhoe+"&tencongviec="+encodeURIComponent(tencongviec)+"&BSKetLuan="+encodeURIComponent(BSKetLuan)+"&idHGQ="+idHuongGiaiQuyet+"&HuongGiaiQ="+encodeURIComponent(HuongGiaiQ)+"";
    link +="&isxnmau_text="+encodeURIComponent($("#isxnmau_text").val())+"&isxnnt_text="+encodeURIComponent($("#isxnnt_text").val())+"&xnk_text="+encodeURIComponent($("#xnk_text").val())+"&xqp_text="+encodeURIComponent($("#xqp_text").val())+"&sab_text="+encodeURIComponent($("#sab_text").val())+"&clsk_text="+encodeURIComponent($("#clsk_text").val())+"&NgoaiDaLieu="+encodeURIComponent($("#NgoaiDaLieu").val())+"&noiTQ="+encodeURIComponent($("#noiTQ").val())+"";
    if(oidbn.value=="")
    {
        //alert("&LoaiSK="+LoaiSK+" =::>"+link);
        alert("Chưa chọn bệnh nhân !");
        return;
    }
    $("#bntInPhieu2").css("display","none");
    xmlHttp.open("GET",link);
    xmlHttp.send(null);
}

function ajaxQuyeryString(strkhoachinh,frame)
{
var list="&"+strkhoachinh+"="+$.mkv.queryString(strkhoachinh);
var arrInput= $("#"+frame+" [mkv=true]");
    for(var i=0; i< arrInput.length; i++)
    {
        var inPut_i= arrInput[i];
        //if(inPut_i.is("input")||inPut_i.is("select")||inPut_i.is("textarea"))
        if(inPut_i.tagName=="INPUT" || inPut_i.tagName=="SELECT" || inPut_i.tagName=="TEXTAREA")
		        {
			        switch(inPut_i.type)
			        {
				        case"checkbox":list+="&"+inPut_i.id+"="+inPut_i.checked;break;
				        case"radio":if(inPut_i.checked)list+="&"+inPut_i.id+"="+encodeURIComponent(inPut_i.value);break;
				        default:list+="&"+inPut_i.id +"="+encodeURIComponent(inPut_i.value);break
			        }
		        }
		        else list+="&"+inPut_i.id+"="+encodeURIComponent(inPut_i.text());
    }
    return list;
}
function kiemtraso(obj)
{
   if(isNaN(obj.value)){
        obj.value='';
        return false;
   }
}
</script>

<style>
 .button{
   background-color:ButtonHighlight; border-top-width: 1px; border-right: 1px; border-left: 1px; border-bottom: 1px; cursor:pointer
 }
 .div-Out,.div-Left
 {
    float:left;
 }
 .body-div{
    position:absolute;
    left:100px;
    top:10px;
   
    }
    .style1
    {
        width: 401px;
    }
    .style2
    {
        width: 107px;
    }
    .style3
    {
        width: 107px;
        height: 50px;
    }
    .style4
    {
        width: 401px;
        height: 50px;
    }
    .style5
    {
        height: 50px;
    }
    #infosinhhieu
    {
        text-align: center;
    }
    .style6
    {
        text-align: center;
        font-weight: bold;
        width: 1144px;
    }
    .style7
    {
        color: #3366FF;
    }
    .style8
    {
        text-align: center;
        font-weight: bold;
        width: 1164px;
        color: #3333CC;
    }
    .style11
    {
        width: 797px;
        height: 50px;
    }
    .style12
    {
        height: 50px;
        width: 278px;
    }
    .style13
    {
        height: 50px;
        width: 273px;
    }
    .style14
    {
        width: 273px;
    }
    .style19
    {
        width: 104px;
    }
    .style22
    {
        width: 113px;
        height: 50px;
    }
    .style25
    {
        width: 451px;
        height: 50px;
    }
    .style26
    {
        height: 50px;
        width: 275px;
    }
    .style28
    {
        width: 104px;
        height: 50px;
    }
    .style29
    {
        width: 81px;
        height: 50px;
    }
    .style30
    {
        width: 387px;
        height: 50px;
    }
    .style31
    {
        width: 387px;
    }
    .style32
    {
        width: 441px;
        height: 50px;
    }
   
    #bntInPhieu2
    {
        width: 154px;
    }.header-div {
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
    z-index: 100;
    font-weight: bolder;
}
</style>
<body>
    <form id="frmThamBenh" method="post" runat="server">
        <input mkv=true type="hidden" name="txtIdChanDoanTD" id="txtIdChanDoanTD" runat="server" value="0"
            style="width: 16px" />
        <input mkv=true type="hidden" name="txtIdChanDoanXD" id="txtIdChanDoanXD" runat="server" value="0"
            style="width: 16px" />
        <div style="width: 100%; margin: auto; clear: both;" align="center">
            <asp:ScriptManager runat="server" ID="ScriptM">
            </asp:ScriptManager>
            <table align="center" cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: #C0C0C0">
                <tr>
                    <td width="100%" align="left" style="background-color: #D4D0C8; height: 10px;" colspan="2">
                        <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
                    </td>
                </tr>
                <%--    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8"></td>
    </tr>--%>
                <tr>
                    <td width="100%" align="center" style="background-color: #D4D0C8; margin: auto;"
                        colspan="2">
                        <table cellspacing="1" cellpadding="1" width="100%" border="0" style="width: 980px;">
                            <tr>
                                <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px">
                                    <table id="user" cellspacing="0" cellpadding="0" border="0">
                                        <tr>
                                            <td class="header-div">
                                                PHIẾU KHÁM SỨC KHỎE
                                            </td>
                                        </tr><tr>
                                            <td style="height:45px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 80%;">
                                                <div style="font-weight: bold; color: White; width: 500px; float: left; text-align">
                                                    &nbsp;</div>
                                                <div style="float: left; width: 250px">
                                                    <asp:UpdatePanel runat="server" ID="uppanel5">
                                                        <ContentTemplate>
                                                            Ngày khám :
                                                            <asp:TextBox ID="txtNgayKham" runat="server" Width="80px"></asp:TextBox><input mkv=true style="width: 25px"
                                                                id="Button1" onclick="dp_cal1.toggle()" type="button" value="..." class="lich" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div style="float: left">
                                                    <asp:UpdatePanel runat="server" ID="updatepanel5">
                                                        <ContentTemplate>
                                                            Bác sĩ :
                                                            <asp:DropDownList ID="ddlBS" TabIndex="1" runat="server" Width="230px">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <asp:UpdatePanel runat="server" ID="updatepanel2">
                                                    <ContentTemplate>
                                                        <asp:DropDownList Visible="false" ID="ddlPK" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPK_SelectedIndexChanged1">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:HiddenField ID="txtMaPhieuKham" runat="server"></asp:HiddenField>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding-left: 5px; padding-top: 1px;">
                                                <table border="1" style="border-collapse: collapse;" bordercolor="#ECECEC" cellspacing="0"
                                                    cellpadding="3">
                                                    <tr height="auto">
                                                        <td align="left" style="width: 75px">
                                                            Phòng</td>
                                                        <td style="width: 210px">
                                                            <asp:UpdatePanel runat="server" ID="updatepanel4">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlphongkham" runat="server" AutoPostBack="false" Width="100%"
                                                                        __designer:wfdid="w4">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td align="left" colspan="" id="showtipbenhnhan" style="width: 200px">
                                                            <span id="tileDSBNCho"></span>
                                                            <input mkv=true id="Button10" onclick="showDanhSachBenhNhan(0);" type="button" value="DSBN Chờ Khám"
                                                                accesskey="w" class="btn3" />
                                                            <input mkv=true value="Xem HSBA" style="display: none" id="btnViewHSBA" type="button" onclick="ViewHSBA_Click();" />
                                                        </td>
                                                        <td style="width: 265px">
                                                            <input mkv=true id="btnDS_KQCLS" onclick="showDanhSachBenhNhan(1);" type="button" value="DSBN Đã Khám"
                                                                accesskey="k" class="btn3" />
                                                            &nbsp;<asp:UpdatePanel runat="server" ID="updatepanel3">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlnd" runat="server" __designer:wfdid="w2" Width="255px" AutoPostBack="true"
                                                                        Visible="false" OnSelectedIndexChanged="ddlnd_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <asp:UpdatePanel runat="server" ID="updatepanel1">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="cbLoaiBN" runat="server" Width="100%" AutoPostBack="true" Visible="false"
                                                                        __designer:wfdid="w2" OnSelectedIndexChanged="cbLoaiBN_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 75px">
                                                            <strong style="color: blue">Tên BN:</strong></td>
                                                        <td style="width: 210px">
                                                            <asp:TextBox ID="txtTenBenhNhan" runat="server" Width="99%" ForeColor="Blue" TabIndex="2"></asp:TextBox>
                                                            <td colspan="" style="width: 200px">
                                                            </td>
                                                            <td style="width: 265px">
                                                                Giới tính :&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtGioiTinh" runat="server" Width="141px"
                                                                    TabIndex="3"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 250px">
                                                                Ngày sinh :<asp:TextBox ID="txtTuoi" runat="server" Width="120px" TabIndex="4"></asp:TextBox>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 75px">
                                                            Mã BN:</td>
                                                        <td style="width: 210px">
                                                            <asp:TextBox ID="txtMaBenhNhan" runat="server" Width="99%" TabIndex="5" ></asp:TextBox></td>
                                                        <td style="width: 200px">
                                                            <asp:DropDownList ID="ddlChoKham" runat="server" Width="33px" Visible="False">
                                                            </asp:DropDownList>
                                                            <input mkv=true type="hidden" id="Hidden3" value="0" style="width: 14px" />
                                                            <input mkv=true type="hidden" id="Hidden4" value="0" style="width: 9px" /></td>
                                                        <td colspan="" style="width: 265px">
                                                            <div id="lbbhyt">
                                                                Số BHYT :<asp:TextBox ID="txtSoBHYT" runat="server" Width="141px" Font-Bold="True"
                                                                    TabIndex="6"></asp:TextBox></div>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <div id="lbngayhh">
                                                                Hết hạn :&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtNgayHH" runat="server" Width="120px"
                                                                    TabIndex="7"></asp:TextBox></div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 75px">
                                                            Số ĐT</td>
                                                        <td style="width: 210px">
                                                            <asp:TextBox ID="txtSoDTBN" runat="server" Width="99%" TabIndex="8"></asp:TextBox></td>
                                                        <td align="right" colspan="" style="width: 200px">
                                                        </td>
                                                        <td colspan="2" style="height: 21px">
                                                            Địa chỉ :&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtDiaChi" runat="server" Width="85%" TabIndex="9"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="height: 14px">
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td style="padding-left: 5px; height: 17px;" valign="top" id="thongtinsinhieu">
                                                                        <fieldset style="padding: 2px; border-right: 1px none gray; border-top: 1px none gray;
                                                                            border-left: 2px none gray; width: -2147483648%; border-bottom: gray 1px">
                                                                            <div class="style6">
                                                                                <span id="infosinhhieu" class="style7">Sinh Hiệu</span></div>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table cellpadding="3" cellspacing="0" rules="all" border="1" bordercolor="#ECECEC"
                                                                style="width: 100%; border-collapse: collapse">
                                                                <tr>
                                                                    <td class="style3">
                                                                        Chiều cao:</td>
                                                                    <td class="style4">
                                                                        <asp:TextBox ID="txtTienSuBenh" runat="server" Width="50%" Style="display: none;"></asp:TextBox>
                                                                        &nbsp;<asp:TextBox ID="txtchieucao" onblur="kiemtraso(this);calculateBMI();" runat="server" Width="98%" TabIndex="10"></asp:TextBox>
                                                                    </td>
                                                                    <td align="right" class="style5">
                                                                        Mạch :
                                                                    </td>
                                                                    <td class="style5">
                                                                        <asp:TextBox ID="txtmach" onblur="kiemtraso(this);"  runat="server" Text="" Width="98%" TabIndex="11"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style2">
                                                                        Cân nặng :
                                                                    </td>
                                                                    <td class="style1">
                                                                        <asp:TextBox ID="txtBenhsu" runat="server" Style="display: none;" Text="" Width="58%"></asp:TextBox>
                                                                        &nbsp;<asp:TextBox ID="txtcannang" onblur="kiemtraso(this);calculateBMI();" runat="server" Width="98%"
                                                                            TabIndex="12"></asp:TextBox>
                                                                    </td>
                                                                    <td align="right" style="width: 350px">
                                                                        Huyết áp:
                                                                    </td>
                                                                    <td style="width: 350px">
                                                                        <asp:TextBox ID="txthuyetap" runat="server" Width="98%" TabIndex="13"></asp:TextBox>
                                                                        <input mkv=true type="hidden" id="curdong_chandoan" value="0" style="width: 11px">
                                                                        <input mkv=true type="hidden" id="ocurdongcls" value="0" style="width: 13px" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style2">
                                                                        Vòng ngực:
                                                                    </td>
                                                                    <td class="style1">
                                                                        <asp:TextBox ID="txtvongnguc" onblur="kiemtraso(this);" runat="server" Width="98%" TabIndex="14"></asp:TextBox>
                                                                    </td>
                                                                    <td align="right" style="width: 350px">
                                                                        Nhiệt độ:
                                                                    </td>
                                                                    <td colspan="2">
                                                                        <asp:TextBox ID="txtnhietdo" onblur="kiemtraso(this);" runat="server" Width="98%" TabIndex="15"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style2">
                                                                        Chỉ số BMI:
                                                                    </td>
                                                                    <td class="style1">
                                                                        <asp:TextBox ID="txtbmi" onblur="kiemtraso(this);" runat="server" Width="98%" TabIndex="16"></asp:TextBox>
                                                                    </td>
                                                                    <td align="right" style="width: 350px">
                                                                        Nhịp thở:
                                                                    </td>
                                                                    <td colspan="2">
                                                                        <asp:TextBox ID="txtnhiptho" onblur="kiemtraso(this);" runat="server" Width="98%" TabIndex="17"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td style="padding-left: 5px; height: 17px;" valign="top" id="Td1">
                                                                <fieldset style="padding: 2px; border-right: 1px none gray; border-top: 1px none gray;
                                                                    border-left: 2px none gray; width: -2147483648%; border-bottom: gray 1px">
                                                                    <div class="style8">
                                                                        Khám bệnh</div>
                                                                </fieldset>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="3" cellspacing="0" rules="all" border="1" bordercolor="#ECECEC"
                                                        style="width: 100%; border-collapse: collapse">
                                                        <tr>
                                                            <td class="style28">
                                                                Tim mạch:</td>
                                                            <td class="style30">
                                                                <asp:TextBox ID="Textbox2" runat="server" Width="50%" Style="display: none;"></asp:TextBox>
                                                                &nbsp;<asp:TextBox ID="txttimmach" runat="server" Width="98%" TabIndex="18"></asp:TextBox>
                                                            </td>
                                                            <td align="right" class="style13">
                                                                Hô hấp :
                                                            </td>
                                                            <td class="style5">
                                                                <asp:TextBox ID="txthohap" runat="server" Text="" Width="98%" TabIndex="19"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style19">
                                                                Tiêu hóa :
                                                            </td>
                                                            <td class="style31">
                                                                <asp:TextBox ID="Textbox5" runat="server" Style="display: none;" Text="" Width="58%"></asp:TextBox>
                                                                &nbsp;<asp:TextBox ID="txttieuhoa" runat="server" Width="98%" TabIndex="20"></asp:TextBox>
                                                            </td>
                                                            <td align="right" class="style14">
                                                                Thận-Tiết liệu -Sinh dục:
                                                            </td>
                                                            <td colspan="4" >
                                                                <asp:TextBox ID="txtthantietlieusinhduc" runat="server" Width="98%" TabIndex="21"></asp:TextBox>
                                                                <input mkv=true type="hidden" id="Hidden1" value="0" style="width: 11px">
                                                                <input mkv=true type="hidden" id="Hidden2" value="0" style="width: 13px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style19">
                                                                Nội tổng quát:
                                                            </td>
                                                            <td class="style31">
                                                                <asp:TextBox ID="noiTQ" runat="server" Width="98%" TabIndex="22"></asp:TextBox>
                                                            </td>
                                                            <td align="right" class="style14">
                                                                Thần kinh:
                                                            </td>
                                                            <td colspan="2">
                                                                <asp:TextBox ID="txtthankinh" runat="server" Width="98%" TabIndex="22"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style19">
                                                                Cơ xương khớp-Cột sống:
                                                            </td>
                                                            <td class="style31">
                                                                <asp:TextBox ID="txtcoxuongkhopcotsong" runat="server" Width="98%" TabIndex="23"></asp:TextBox>
                                                            </td>
                                                            <td align="right" class="style14">
                                                                Da liễu:
                                                                &nbsp;</td>
                                                            <td colspan="2">
                                                                <asp:TextBox ID="txtdalieu" runat="server" Width="98%" TabIndex="24"></asp:TextBox>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style19">
                                                                Kết luận:
                                                            </td>
                                                            <td class="style31" colspan="4" >
                                                                <asp:TextBox ID="NgoaiDaLieu" runat="server" Width="98%" ></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                        </tr>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td style="padding-left: 5px; height: 17px; display: none" valign="top" id="Td2">
                                                    <fieldset style="padding: 2px; border-right: 1px none gray; border-top: 1px none gray;
                                                        border-left: 2px none gray; width: -2147483648%; border-bottom: gray 1px">
                                                        <div class="style8">
                                                            Sản phụ khoa</div>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="3" cellspacing="0" rules="all" border="1" bordercolor="#ECECEC"
                                            style="width: 100%; border-collapse: collapse">
                                            <tr>
                                                <td class="style29">
                                                    <div class="style8" style="width:150px;">
                                                                        Kết luận sản phụ khoa:</div></td>
                                                <td class="style11">
                                                    <asp:TextBox ID="Textbox3" runat="server" Width="50%" Style="display: none;"></asp:TextBox>
                                                    &nbsp;<asp:TextBox ID="txtklspk" runat="server" Width="98%" TabIndex="25"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td style="padding-left: 5px; height: 17px;" valign="top" id="Td3">
                                                    <fieldset style="padding: 2px; border-right: 1px none gray; border-top: 1px none gray;
                                                        border-left: 2px none gray; width: -2147483648%; border-bottom: gray 1px">
                                                        <div class="style8">
                                                            Khám mắt</div>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="3" cellspacing="0" rules="all" border="1" bordercolor="#ECECEC"
                                            style="width: 100%; border-collapse: collapse">
                                            <tr>
                                                <td class="style22">
                                                    Mắt trái BT:</td>
                                                <td class="style25">
                                                    <asp:TextBox ID="Textbox6" runat="server" Width="50%" Style="display: none;"></asp:TextBox>
                                                    &nbsp;<asp:TextBox ID="txtmtbt" runat="server" Width="98%" TabIndex="26"></asp:TextBox>
                                                </td>
                                                <td align="right" class="style26">
                                                    Mắt phải BT :
                                                </td>
                                                <td class="style5">
                                                    <asp:TextBox ID="txtmpbt" runat="server" Text="" Width="98%" Style="margin-left: 0px"
                                                        TabIndex="27"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style22">
                                                    Mắt trái đeo kính:</td>
                                                <td class="style25">
                                                    <asp:TextBox ID="Textbox7" runat="server" Width="50%" Style="display: none;"></asp:TextBox>
                                                    &nbsp;<asp:TextBox ID="txtmtdk" runat="server" Width="98%" TabIndex="28"></asp:TextBox>
                                                </td>
                                                <td align="right" class="style26">
                                                    Mắt phải đeo kính :
                                                </td>
                                                <td class="style5">
                                                    <asp:TextBox ID="txtmpdk" runat="server" Text="" Width="98%" TabIndex="29"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style22">
                                                    Kết luận:</td>
                                                <td class="style25">
                                                    <asp:TextBox ID="Textbox20" runat="server" Width="50%" Style="display: none;"></asp:TextBox>
                                                    &nbsp;<asp:TextBox ID="txtklkm" runat="server" Width="126%" TabIndex="30"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td style="padding-left: 5px; height: 17px;" valign="top" id="Td4">
                                                    <fieldset style="padding: 2px; border-right: 1px none gray; border-top: 1px none gray;
                                                        border-left: 2px none gray; width: -2147483648%; border-bottom: gray 1px">
                                                        <div class="style8">
                                                            Tai Mũi Họng</div>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="3" cellspacing="0" rules="all" border="1" bordercolor="#ECECEC"
                                            style="width: 100%; border-collapse: collapse">
                                            <tr>
                                                <td class="style22">
                                                    Tai trái BT:</td>
                                                <td class="style32">
                                                    <asp:TextBox ID="Textbox9" runat="server" Width="50%" Style="display: none;"></asp:TextBox>
                                                    &nbsp;<asp:TextBox ID="txttaitraibt" runat="server" Width="98%" TabIndex="31"></asp:TextBox>
                                                </td>
                                                <td align="right" class="style12">
                                                    Tai phải BT :
                                                </td>
                                                <td class="style5">
                                                    <asp:TextBox ID="txttaiphaibt" runat="server" Text="" Width="98%" TabIndex="32"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style22">
                                                    Tai trái thì thầm:</td>
                                                <td class="style32">
                                                    <asp:TextBox ID="Textbox12" runat="server" Width="50%" Style="display: none;"></asp:TextBox>
                                                    &nbsp;<asp:TextBox ID="txttaitraitt" runat="server" Width="98%" TabIndex="33"></asp:TextBox>
                                                </td>
                                                <td align="right" class="style12">
                                                    Tai phải thì thầm:
                                                </td>
                                                <td class="style5">
                                                    <asp:TextBox ID="txttaiphaitt" runat="server" Text="" Width="98%" TabIndex="34"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style22">
                                                    Mũi:</td>
                                                <td class="style32">
                                                    <asp:TextBox ID="Textbox15" runat="server" Width="50%" Style="display: none;"></asp:TextBox>
                                                    &nbsp;<asp:TextBox ID="txtmui" runat="server" Width="98%" TabIndex="35"></asp:TextBox>
                                                </td>
                                                <td align="right" class="style12">
                                                    Họng :
                                                </td>
                                                <td class="style5">
                                                    <asp:TextBox ID="txthong" runat="server" Text="" Width="98%" TabIndex="36"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style22">
                                                    Kết luận:</td>
                                                <td class="style32">
                                                    <asp:TextBox ID="Textbox18" runat="server" Width="50%" Style="display: none;"></asp:TextBox>
                                                    &nbsp;<asp:TextBox ID="txtkltmh" runat="server" Width="98%" TabIndex="37"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td style="padding-left: 5px; height: 17px;" valign="top" id="Td5">
                                                    <fieldset style="padding: 2px; border-right: 1px none gray; border-top: 1px none gray;
                                                        border-left: 2px none gray; width: -2147483648%; border-bottom: gray 1px">
                                                        <div class="style8">
                                                            Răng Hàm Mặt</div>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="3" cellspacing="0" rules="all" border="1" bordercolor="#ECECEC"
                                            style="width: 100%; border-collapse: collapse">
                                            <tr>
                                                <td class="style22">
                                                    1:</td>
                                                <td class="style32">
                                                    <asp:TextBox ID="Textbox10" runat="server" Width="50%" Style="display: none;"></asp:TextBox>
                                                    &nbsp;<asp:TextBox ID="txtrhm1" runat="server" Width="98%" TabIndex="38"></asp:TextBox>
                                                </td>
                                                <td align="right" class="style12">
                                                    2:
                                                </td>
                                                <td class="style5">
                                                    <asp:TextBox ID="txtrhm2" runat="server" Text="" Width="98%" TabIndex="39"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style22">
                                                    3:</td>
                                                <td class="style32">
                                                    <asp:TextBox ID="Textbox14" runat="server" Width="50%" Style="display: none;"></asp:TextBox>
                                                    &nbsp;<asp:TextBox ID="txtrhm3" runat="server" Width="98%" TabIndex="40"></asp:TextBox>
                                                </td>
                                                <td align="right" class="style12">
                                                    4 :
                                                </td>
                                                <td class="style5">
                                                    <asp:TextBox ID="txtrhm4" runat="server" Text="" Width="98%" TabIndex="41"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style22">
                                                    Kết luận:</td>
                                                <td class="style32">
                                                    <asp:TextBox ID="Textbox19" runat="server" Width="50%" Style="display: none;"></asp:TextBox>
                                                    &nbsp;<asp:TextBox ID="txtklrhm" runat="server" Width="98%" TabIndex="42"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td style="padding-left: 5px; height: 30px;" valign="bottom" id="Td6" colspan="all">
                                                    <fieldset style="padding: 2px; border-right: 1px none gray; border-top: 1px none gray;
                                                        border-left: 2px none gray; width: -2147483648%; border-bottom: gray 1px">
                                                        <div class="style8" style="text-align: left;">
                                                            CẬN LÂM SÀNG</div>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="3" cellspacing="0" rules="all" border="1" bordercolor="#ECECEC"
                                                        style="width: 100%; border-collapse: collapse">
                                                        <tr>
                                                            <td style="text-align:left">
                                                               <span style="padding:10px 10px 10px 10px">Xét nghiệm máu:</span> 
                                                               <input mkv=true type="checkbox" id="cbXetNghiemMau"/>
                                                               <input type="text" style="width:150px;" id="isxnmau_text"/>
                                                            </td>
                                                            <td  style="text-align:left">
                                                                <span style="padding:10px 10px 10px 10px">Xét nghiệm nước tiểu:</span> 
                                                               <input mkv=true type="checkbox" id="cbXetNghiemNuocTieu"/>                                                                
                                                               <input type="text" style="width:150px;" id="isxnnt_text"/>
                                                            </td >
                                                            <td style="text-align:left">
                                                                <span style="padding:10px 10px 10px 10px">Xét nghiệm khác:</span> 
                                                               <input mkv=true type="checkbox" id="cbXetNghiemKhac"/>
                                                               <input type="text" style="width:150px;" id="xnk_text"/>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td  style="text-align:left">
                                                                <span style="padding:10px 10px 10px 10px">X Quang phổi:</span> 
                                                               <input mkv=true type="checkbox" id="cbXQPhoi"/>
                                                               <input type="text" style="width:150px;" id="xqp_text"/>
                                                            </td>
                                                            <td  style="text-align:left">
                                                                <span style="padding:10px 10px 10px 10px">Siêu âm bụng:</span> 
                                                               <input mkv=true type="checkbox" id="cbSieuAmBung"/>
                                                               <input type="text" style="width:150px;" id="sab_text"/>
                                                            </td>
                                                            <td  style="text-align:left">
                                                                <span style="padding:10px 10px 10px 10px">Khác:</span> 
                                                               <input mkv=true type="checkbox" id="cbCLSKhac"/>
                                                               <input type="text" style="width:150px;" id="clsk_text"/>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left: 5px; height: 10px;" valign="bottom" id="Td7" colspan="all">
                                                </td>
                                            </tr>
                                            <tr>
                                            <td style="text-align:left;">
                                                <fieldset style="border:1px;border-style:solid;border-color:Gray;"><legend style="font-weight:bold;color:#3333CC;">KẾT LUẬN</legend>
                                                    <span style="padding:10px 145px 10px 10px;"></span> <input mkv=true type="radio" name="KLCoBenh" style="margin-right:0px" id="rdKhoeManh"/><span style="padding:10px 70px 10px 10px">Khỏe mạnh:</span> 
                                                    <input mkv=true type="radio" name="KLCoBenh" style="" id="rdMacBenh"/><span style="padding:10px 10px 10px 10px">Mắc bệnh:</span> 
                                                    <span style="padding:10px 10px 10px 10px">Tên bệnh:</span> <input mkv=true type="text" id="txtTenBenhMac"  style="width:627px;"/> 
                                                        <br />
                                                        <br />
                                                    <span style="padding:10px 33px 10px 10px">Đạt sức khỏe loại:</span> 
                                                        <input mkv=true type="radio" name="LoaiSucKhoe" style="padding-right:100px" id="rdLoai1"/><span style="padding:10px 10px 10px 10px">Loại I:</span>
                                                        <input mkv=true type="radio" name="LoaiSucKhoe" style="padding-right:100px" id="rdLoai2"/><span style="padding:10px 10px 10px 10px">Loại II:</span>
                                                        <input mkv=true type="radio" name="LoaiSucKhoe" style="padding-right:100px" id="rdLoai3"/><span style="padding:10px 10px 10px 10px">Loại III:</span>
                                                        <input mkv=true type="radio" name="LoaiSucKhoe" style="padding-right:100px" id="rdLoai4"/><span style="padding:10px 10px 10px 10px">Loại IV:</span>
                                                        <input mkv=true type="radio" name="LoaiSucKhoe" style="padding-right:100px" id="rdLoai5"/><span style="padding:10px 10px 10px 10px">Loại V:</span>
                                                        <br />
                                                        <br />
                                                    <span style="padding:10px 20px 10px 10px;font-weight:bold;">Hiện tại đối tượng:</span>
                                                    <input mkv=true type="radio" name="KLDuSucKhoe" style="margin-right:0px" id="rdDuSucKhoe"/> <span style="padding:10px 10px 10px 10px">Đủ sức khỏe:</span> 
                                                    <input mkv=true type="radio" name="KLDuSucKhoe" style="margin-right:0px" id="rdKoDuSucKhoe"/> <span style="padding:10px 10px 10px 10px">Không đủ sức khỏe:</span>
                                                    <span style="padding:10px 10px 10px 70px">Làm công việc:</span><input mkv=true type="text" id="txtTenCongViec" style="width:530px;"/>
                                                        <br />
                                                        <br />
                                                    <span style="padding:10px 79px 10px 10px;font-weight:bold;">BÁC SĨ KẾT LUẬN:</span> <input mkv=true type="text" id="txtBSKetLuan" style="width:930px;"/>
                                                        <br />
                                                        <br />
                                                    <span style="padding:10px 30px 10px 10px;font-weight:bold;">Đề nghị hướng giải quyết:</span> <input type="hidden" mkv="true" id="idHuongGiaiQuyet" /><input mkv=true type="text" id="txtHuongGiaiQ" onfocus="idHuongGiaiQuyetSearch(this);" style="width:840px;"/>
                                                    <input mkv=true type="button" id="Button2" value="Danh mục HGQ" onclick="OpenDanhMucHuongGiaiQuyet()" accesskey="L" class="btn2" />
                                                        <br />
                                                    
                                                </fieldset>
                                            </td>
                                            </tr>
                                        </table>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 12px" id="showtipCLS">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="display: none" id="HuyCLS">
                                                &nbsp;</td>
                                            <%--  <td colspan="1"></td>--%>
                                        </tr>
                                        <tr>
                                            <td align="center" style="height: 28px">
                                                <input mkv=true id="btnUpdatePhieu" style="width: 147px; display: none" class="button" type="button"
                                                    value="Cập nhật" onclick="UpdatePhieuKhamBenh();" />
                                                <input mkv=true type="button" id="bntInPhieu2" value="[L]ưu phiếu" onclick="LuuKBNew()" accesskey="L"
                                                    class="btn2" tabindex="44" />&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%--<tr>
                        <td align="left" colspan="2" style="padding-left: 20px; padding-top: 2px; height: 11px">
                            <legend style="font-weight: bold"><strong>
                                </strong></legend>
                        </td>
                    </tr>--%>
                            <%--				    <tr>
					    <td style="padding-top:2px;width:667px; " align = "left" id = "Td1">
						   <div style="float:left;padding-right:5px;">
						     <asp:radiobuttonlist  visible="false" id="rblSearchICD" runat="server" Repeatdirection="Horizontal" Width="140px" ><asp:ListItem>M&#227; ICD</asp:ListItem>
                                <asp:ListItem Selected="True">M&#244; tả</asp:ListItem>
                                  </asp:radiobuttonlist>
                            </div>	
                        
                            </td>                             
				    </tr>--%>
                        </table>
                    </td>
                </tr>
            </table>
            </td> </tr> </table>
            <div style="display: none; position: fixed; top: 15%; left: 25%; background-color: White;
                z-index: 900; padding: 10px 10px 10px 10px; border: 10px solid #4D67A2" id="chondvcls"
                runat="server">
                <asp:UpdatePanel runat="server" ID="updatepanel10">
                    <ContentTemplate>
                        <table>
                            <tbody>
                                <tr>
                                    <td>
                                        Chọn nhóm CLS :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlnhomcls" runat="server" OnSelectedIndexChanged="ddlnhomcls_SelectedIndexChanged"
                                            Width="200px" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <span style="position: absolute" id="SPAN2"></span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <input mkv=true id="Button7" type="button" value="Đóng Lại" style="padding: buttom; color: #ffffff;
                    background-color: DeepSkyBlue;" onclick="javascript:chondvcls.style.display = 'none';" />
            </div>
            <input mkv=true type="hidden" runat="server" value="" name="idPKbenh" id="idPKbenh" />
            <input mkv=true type="hidden" runat="server" name="loaiBN" id="loaiBN" />
            <input mkv=true type="hidden" name="tontai" id="tontai" />
            <input mkv=true type="hidden" value="" name="txtidbenhnhan" id="txtidbenhnhan" />
            <input mkv=true type="hidden" value="" name="listIdDV" id="listIdDV" />
            <input mkv=true type="hidden" value="" name="luuchidinhcls" id="luuchidinhcls" />
            <input mkv=true type="hidden" value="" name="txtHetHanThuoc" id="txtHetHanThuoc" />
            <input mkv=true type="hidden" value="" name="luutoathuoc" id="luutoathuoc" />
            <input mkv=true type="hidden" value="" name="iddangkykham" id="iddangkykham" />
            <input mkv=true type="hidden" value="" name="IdChiTietDangKyKham" id="IdChiTietDangKyKham" />
            <input mkv=true type="hidden" value="" runat="server" name="dkLoadCho" id="dkLoadCho" />
            <input mkv=true type="hidden" value="" runat="server" name="listTenNhom" id="listTenNhom" />
            <input mkv=true type="hidden" value="0" runat="server" name="idpkbCLS" id="idpkbCLS" />
            <input mkv=true type="hidden" value="0" runat="server" name="txtIDBNTTOld" id="txtIDBNTTOld" />
            <input mkv=true type="hidden" value="0" runat="server" name="txtIDBNTTOld" id="txt_kiemtra1" />
            <input mkv=true type="hidden" value="0" runat="server" name="txtIDBNTTOld" id="txt_kiemtra2" />
            <input mkv=true type="hidden" runat="server" name="txtLoaiBNhidden" id="txtLoaiBNhidden" />
            <%--<input mkv=true id="txtLoaiBNhidden"  runat="server" type="text" />  --%>
            <input mkv=true type="hidden" value="" runat="server" name="txtSoNgayBH" id="txtSoNgayBH" />
            <input mkv=true type="hidden" id="txtidkham" runat="server" tabindex="6" style="width: 37px" />
            
            <input mkv=true type="hidden" id="idkhambenh" />
        </div>
        <%-- Div Tien su --%>
        <div class="body-div" id="divTienSu" style="display: none">
            <div class="header-div">
                Tiền sử
            </div>
            <div class="in-a">
                <div class="div-Out" style="width: 200px">
                    <div class="div-Left" style="width: 70%">
                        Dị ứng
                    </div>
                    <div class="div-Right" style="width: 14%">
                        <input mkv=true mkv="true" id="IsDiUng" type="checkbox" />
                    </div>
                </div>
                <div class="div-Out" style="width: 200px">
                    <div class="div-Left">
                        Tiểu đường
                    </div>
                    <div class="div-Right">
                        <input mkv=true mkv="true" id="IsTieuDuong" type="checkbox" />
                    </div>
                </div>
                <div class="div-Out">
                    <div class="div-Left">
                        Viêm khớp
                    </div>
                    <div class="div-Right">
                        <input mkv=true mkv="true" id="IsVienKhop" type="checkbox" />
                    </div>
                </div>
                <div class="div-Out">
                    <div class="div-Left">
                        Tăng huyết áp
                    </div>
                    <div class="div-Right">
                        <input mkv=true mkv="true" id="IsTangHuyetAp" type="checkbox" />
                    </div>
                </div>
                <div class="div-Out">
                    <div class="div-Left">
                        Suyễn
                    </div>
                    <div class="div-Right">
                        <input mkv=true mkv="true" id="IsSuyen" type="checkbox" />
                    </div>
                </div>
                <div class="div-Out">
                    <div class="div-Left">
                        Hút thuốc
                    </div>
                    <div class="div-Right">
                        <input mkv=true mkv="true" id="IsHutThuoc" type="checkbox" />
                    </div>
                </div>
                <div class="div-Out">
                    <div class="div-Left">
                        Rượu
                    </div>
                    <div class="div-Right">
                        <input mkv=true mkv="true" id="IsRuou" type="checkbox" />
                    </div>
                </div>
                <div class="div-Out">
                    <div class="div-Left">
                        Viêm gan B
                    </div>
                    <div class="div-Right">
                        <input mkv=true mkv="true" id="IsVienGanB" type="checkbox" />
                    </div>
                </div>
                <div class="div-Out">
                    <div class="div-Left">
                        Lao
                    </div>
                    <div class="div-Right">
                        <input mkv=true mkv="true" id="IsLao" type="checkbox" />
                    </div>
                </div>
                <div class="div-Out">
                    <div class="div-Left">
                        Phẫu thuật
                    </div>
                    <div class="div-Right">
                        <input mkv=true mkv="true" id="IsPhauThuat" type="checkbox" />
                    </div>
                </div>
                <div class="div-Out">
                    <div class="div-Left">
                        Viêm dạ dày
                    </div>
                    <div class="div-Right">
                        <input mkv=true mkv="true" id="IsVienDaGiay" type="checkbox" />
                    </div>
                </div>
                <div class="div-Out">
                    <div class="div-Left" style="width: 10%;">
                        Khác
                    </div>
                    <div class="div-Right" style="width: 70%; padding-left: 3px">
                        <input mkv=true mkv="true" style="width: 95%" id="Khac" type="text" />
                    </div>
                </div>
                <div class="div-Out" style="width: 90%">
                    <div class="div-Left">
                        Thuốc đang dùng
                    </div>
                    <div class="div-Right" style="width: 60%">
                        <input mkv=true mkv="true" id="ThuocDangDung" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 90%" id="sanphukhoadiv">
                    <div class="div-Left">
                        Sản phụ khoa
                    </div>
                    <div class="div-Right" style="width: 60%">
                        <input mkv=true mkv="true" id="SanPhuKhoa" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 90%" id="para">
                    <div class="div-Left" style="text-align: right; width: 90px;">
                        PARA &nbsp;&nbsp;&nbsp;
                    </div>
                    <div class="div-Right" style="width: 60%">
                        <input mkv=true mkv="true" id="Para" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 90%">
                    <div class="div-Left">
                        Nội khoa
                    </div>
                    <div class="div-Right" style="width: 60%">
                        <input mkv=true mkv="true" id="NoiKhoa" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 90%">
                    <div class="div-Left">
                        Ngoại khoa
                    </div>
                    <div class="div-Right" style="width: 60%">
                        <input mkv=true mkv="true" id="NgoaiKhoa" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 90%">
                    <div class="div-Left">
                        Gia đình
                    </div>
                    <div class="div-Right" style="width: 60%">
                        <input mkv=true mkv="true" id="GiaDinh" type="text" style="width: 90%" />
                    </div>
                </div>
            </div>
            <div class="body-div-button">
                <div class="in-a" style="width: 90%">
                    <input mkv=true id="btnMoi" type="button" style="width: 100px;" onclick="MoiTienSu(this);"
                        value="Mới" />
                    <input mkv=true id="btnLuu" type="button" onclick="javascript:document.getElementById('divTienSu').style.display='none';"
                        style="width: 100px;" value="Lưu" />
                </div>
            </div>
        </div>
        <%-- Div Tham benh --%>
        <div class="body-div" id="divThamKham" style="display: none">
            <div class="header-div">
                Thăm khám
            </div>
            <div class="in-a">
                <div class="div-Out" style="width: 93%">
                    <div class="div-Left">
                        Da,niêm, tóc, móng
                    </div>
                    <div class="div-Right" style="width: 70%">
                        <input mkv=true mkv="true" id="DaNiemTocMong" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 93%">
                    <div class="div-Left">
                        Mắt
                    </div>
                    <div class="div-Right" style="width: 70%">
                        <input mkv=true mkv="true" id="MatTrai" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 93%">
                    <div class="div-Left">
                        Tai
                    </div>
                    <div class="div-Right" style="width: 70%">
                        <input mkv=true mkv="true" id="Tai" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 93%">
                    <div class="div-Left">
                        Mũi
                    </div>
                    <div class="div-Right" style="width: 70%">
                        <input mkv=true mkv="true" id="Mui" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 93%">
                    <div class="div-Left">
                        Họng
                    </div>
                    <div class="div-Right" style="width: 70%">
                        <input mkv=true mkv="true" id="Hong" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 93%">
                    <div class="div-Left">
                        Hạch
                    </div>
                    <div class="div-Right" style="width: 70%">
                        <input mkv=true mkv="true" id="Hach" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 93%">
                    <div class="div-Left">
                        Tuyến giáp
                    </div>
                    <div class="div-Right" style="width: 70%">
                        <input mkv=true mkv="true" id="TuyenGiap" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 93%">
                    <div class="div-Left">
                        Phổi
                    </div>
                    <div class="div-Right" style="width: 70%">
                        <input mkv=true mkv="true" id="Phoi" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 93%">
                    <div class="div-Left">
                        Tim
                    </div>
                    <div class="div-Right" style="width: 70%">
                        <input mkv=true mkv="true" id="Tim" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 93%">
                    <div class="div-Left">
                        Bụng
                    </div>
                    <div class="div-Right" style="width: 70%">
                        <input mkv=true mkv="true" id="Bung" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 93%">
                    <div class="div-Left">
                        Niệu sinh dục
                    </div>
                    <div class="div-Right" style="width: 70%">
                        <input mkv=true mkv="true" id="NieuSinhDuc" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 93%">
                    <div class="div-Left">
                        Thần kinh, cảm giác, vận động
                    </div>
                    <div class="div-Right" style="width: 60%">
                        <input mkv=true mkv="true" id="ThanKinh" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 93%">
                    <div class="div-Left">
                        Chi trên, chi dưới, cột sống
                    </div>
                    <div class="div-Right" style="width: 70%">
                        <input mkv=true mkv="true" id="CoXuongKhop" type="text" style="width: 90%" />
                    </div>
                </div>
                <div class="div-Out" style="width: 93%">
                    <div class="div-Left">
                        Khác
                    </div>
                    <div class="div-Right" style="width: 70%">
                        <input mkv=true mkv="true" id="Khac1" type="text" style="width: 90%" />
                    </div>
                </div>
            </div>
            <div class="in-a" style="width: 90%">
                <input mkv=true id="Button8" type="button" style="width: 100px;" onclick="MoiThamKham(this);"
                    value="Mới" />
                <input mkv=true id="Button11" type="button" onclick="javascript:document.getElementById('divThamKham').style.display='none';"
                    style="width: 100px;" value="Lưu" />
            </div>
        </div>
        </div>
    </form>
    <!--#include file ="footer.htm"-->
<script type="text/javascript">
function idHuongGiaiQuyetSearch(obj)
	{	
	    $(obj).unautocomplete().autocomplete("../nhanbenh/thuphiCLS_DKKDinhky_Ajax.aspx?do=idHuongGiaiQuyetSearch",{
	    scroll: true,minChars:0,
	    header:"Hướng giải quyết",
	    formatItem:function (data) {
                return data[0];
            }
	    }).result(function(event,data){
                $("#txtHuongGiaiQ").val(data[0]);
                $("#idHuongGiaiQuyet").val(data[1]);
	            $(obj).focus();
                
	    });
	}
	function OpenDanhMucHuongGiaiQuyet()
	{
        window.open("../DanhMuc/web/DM_HuongGiaiQuyet2.aspx", '_blank', 'location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	}
</script>