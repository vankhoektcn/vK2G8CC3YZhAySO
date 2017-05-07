<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTSCD_DanhMucCongCuDungCu.aspx.cs" Inherits="ketoan_KTTSCD_DanhMucCongCuDungCu" %>
<!--#include file = "header.htm" -->
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_CCDC.ascx" TagName="uscmenuKT_CCDC" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link type="text/css" rel="stylesheet" href="../ketoan/css_KeToan/sheet_index.css" />
<link href="../ketoan/css_KeToan/epoch_styles.css" type="text/css" rel="stylesheet" />
<link href="../ketoan/css_KeToan/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/default.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/style.css" />
<script type="text/javascript" src="../ketoan/js_KeToan/libary.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/script.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jscript.js"></script>
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/table_TCHD.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/epoch_styles.css" />
<link href="../ketoan/css_ketoan/dropdown/dropdown.css" media="screen" rel="stylesheet" type="text/css" />
<link href="../ketoan/css_ketoan/dropdown/themes/default/default.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../ketoan/js_KeToan/epoch_classes.js"></script>
<script type="text/javascript" src="../ketoan/editor/editor.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jquery-1.4.2.js"></script>
<script src="../js/jquery.autocomplete.js" type="text/javascript"></script>

<script language = "javascript" type="text/javascript">
    var dp_cal, dp_cals;  
    var SoPhieuCCDC = "";
   var IsSaveOrUpdate = "Save";
   var IsKhauHao=false;
	window.onload = function () 
	{
	    TaoMaSoTuDong();
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtNgayNhap'));
	    dp_cals = new Epoch('epoch_popup','popup',document.getElementById('txtNgayKH'));
	    
	};
	
function TaoMaSoTuDong()
{
       var Table = "DanhMucCCDC";
       var KyTuDau = "PNCCDC";
       var Column = "So_Phieu_CCDC";
 
      xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="")
                      {  
                        SoPhieuCCDC = value;  
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TaoMaSoTuDong&Table="+Table+"&KyTuDau="+KyTuDau+"&Column="+Column+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
    function TestDatePhieu(t)
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
	function TestNum(obj)
	{
		
		if (obj.value!="")
		{				
			if (CheckNumberFloat(obj.value)==false)
			{
				obj.value="0";
				alert("Bạn phải nhập giá trị số! ");
				obj.focus();
				
			}
		}
	}
	function FormatSoTien(obj)
	{
	  obj.value = formatCurrency(obj.value);
	}
	function FormatSoTien2(num)
	{
	  return formatCurrency(num);
// chu y thuc thi show danh sac tai khoan line% 
function ShowTaiKhoan(obj)
{
    var objsrc = document.getElementById(obj);
  
        $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=DanhSachTaiKhoan_Jquery&Key="+objsrc.value+"&obj="+obj,
                                                    {width:350,scroll:true,formatItem:function(data)
                                                        {return data[1];}
                                                    }
                                                ).result(
                                                            function(event,data)
                                                            {
                                                                setChonTaiKhoan(data[2],obj);//data[2] la ma 
                                                              
                                                            }
                                                        );           
}

function setChonTaiKhoan(MaTaiKhoan,obj)
{
      
      var txtTaiKhoan=document.getElementById(obj);
      txtTaiKhoan.value=MaTaiKhoan;
      
}
function TestEmptyData()
{
    var MaCCDC = document.getElementById('txtmaCCDC').value;
    var TenCCDC = document.getElementById('txtTenCCDC').value;
    var index=document.getElementById("ddlNuocSX").selectedIndex;
    var NguyenGia = document.getElementById('txtNguyenGia').value;
    var NgayNhap = document.getElementById('txtNgayNhap').value;
    var NgayKhauHao = document.getElementById('txtNgayKH').value;
    var SoThangKH = document.getElementById('txtSoNamKH').value;
    var TKNguyenGia = document.getElementById('txtTKNguyenGia').value;
    var TKDoiUng = document.getElementById('txtTKDoiUng').value;
    var TKChiPhi = document.getElementById('txtTKChiPhi').value;
    var TKKhauHao = document.getElementById('txtTKKhauHao').value;
   // var flag = true;
    if(MaCCDC=="")
    {
        alert("Chưa nhập mã công cụ dụng cụ. Vui lòng kiểm tra lại. Cảm ơn!");
        return false;
    }
    else
    if(TenCCDC=="")
    {
        alert("Chưa nhập tên công cụ dụng cụ. Vui lòng kiểm tra lại. Cảm ơn!");
        return false;
    }
     else
    if(NguyenGia=="")
    {
        alert("Chưa nhập nguyên giá của công cụ dụng cụ. Vui lòng kiểm tra lại. Cảm ơn!");
        return false;
    }
     else
    if(NgayNhap=="")
    {
        alert("Chưa chọn ngày nhập công cụ dụng cụ. Vui lòng kiểm tra lại. Cảm ơn!");
        return false;
    }
     else
    if(NgayKhauHao=="")
    {
        alert("Chưa chọn ngày khấu hao công cụ dụng cụ. Vui lòng kiểm tra lại. Cảm ơn!");
        return false;
        
    }
     else
    if(SoThangKH=="")
    {
        alert("Chưa thời gian khấu hao công cụ dụng cụ. Vui lòng kiểm tra lại. Cảm ơn!");
        return false;
    }
     else
    if(TKChiPhi=="")
    {
        alert("Chưa nhập tài khoản chi phí. Vui lòng kiểm tra lại. Cảm ơn!");
        return false;
    }
     else
    if(TKDoiUng=="")
    {
        alert("Chưa nhập tài khoản đối ứng. Vui lòng kiểm tra lại. Cảm ơn!");
       return false;
    }
     else
    if(TKKhauHao=="")
    {
        alert("Chưa nhập tài khoản khấu hao. Vui lòng kiểm tra lại. Cảm ơn!");
        return false;
    }
     else
    if(TKNguyenGia=="")
    {
        alert("Chưa nhậpnhập tài khoản nguyên giá. Vui lòng kiểm tra lại. Cảm ơn!");
        return false;
    }
   else
   return true;
   
}
function TestMaTaiKhoan(txtTaiKhoan)
{
    var MaTaiKhoan = document.getElementById(txtTaiKhoan);
    if(MaTaiKhoan.value!="")
    {
        xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="1")
                      {  
                        alert("Tài khoản bạn chọn chưa có trong danh mục tài khoản. Vui lòng kiểm tra lại. Cảm ơn!");
                         MaTaiKhoan.value ="";
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TestMaTaiKhoan&Key="+MaTaiKhoan.value+"&times="+Math.random(),true);
            xmlHttp.send(null);
    }
    
}
function TinhTienThue()
{
    var thuesuat=document.getElementById('txtThueSuat').value;
    var nguyengia=document.getElementById('txtNguyenGia').value;
    if(thuesuat=="")
        thuesuat="0";
    if(nguyengia=="")
        nguyengia="0";    
    var tienthue = eval(ChangeFormatCurrency(nguyengia))*eval(thuesuat)/100;//tinh dung ko ne troi
    document.getElementById('txtTienThue').value = formatCurrency(tienthue);
}
function btnTimKiem_Click()
{
    var MaCCDC = document.getElementById('txtmaCCDC').value;
    var TenCCDC = document.getElementById('txtTenCCDC').value;
    var HangSX = "";
    var NgayNhap = document.getElementById('txtNgayNhap').value;
    var NgayKH = document.getElementById('txtNgayKH').value;
    LoadThongTinCongCuDungCu("DanhSach","",MaCCDC,TenCCDC,HangSX,NgayNhap,NgayKH);
}
function btnTaoMoi_Click()
{
    TaoMaSoTuDong();
    IsSaveOrUpdate="Save";
    IsKhauHao=false;
    
    document.getElementById('checkbox_LuuSoCai').checked = false;
    document.getElementById('btnSave').value = "Lưu";
    document.getElementById('btnSave').disable = false;
    document.getElementById('message').style.visibility = "hidden";
    document.getElementById('txtDienGiai').value = "";
    document.getElementById('txtmaCCDC').value = "";
    document.getElementById('txtNamSX').value = "";
    document.getElementById('txtNgayKH').value = "";
    document.getElementById('txtNgayNhap').value = "";
    document.getElementById('txtNguyenGia').value = "";
    document.getElementById('txtSoNamKH').value = "";
    document.getElementById('txtTenCCDC').value = "";
    document.getElementById('txtThueSuat').value = "";
    document.getElementById('txtTienThue').value = "";
    document.getElementById('txtTKChiPhi').value = "";
    document.getElementById('txtTKDoiUng').value = "";
    document.getElementById('txtTKKhauHao').value = "";
    document.getElementById('txtTKNguyenGia').value = "";
    document.getElementById('txtTKThue').value = "";
    
}
function btnSave_Click(Ctr)
{
    Ctr.disable =  true;
   
   var btnSave = document.getElementById('btnSave');
    var MaCCDC = document.getElementById('txtmaCCDC').value;
    if(MaCCDC!="")
    {
        CheckCCDC_KhauHao(MaCCDC);
        if(IsKhauHao==false)
        {
         if(btnSave.value=="Sửa")
           {
                    btnSave.value = "Lưu";
                    IsSaveOrUpdate = "Update";
                    
            }
            else
            if(btnSave.value=="Lưu")
            {
                    if(IsSaveOrUpdate=="Update")
                    {
                         XoaCongCuDungCu_SoCai(Ctr,SoPhieuCCDC);
                          
                    }
                    else
                    if(IsSaveOrUpdate="Save")
                    {
                          LuuCongCuDungCu(Ctr);
                    } 
            }        
        }
    }
    else
        alert('Chưa nhập mã công cụ dụng cụ!');
}
function CheckCCDC_KhauHao(MaCCDC)
{
     xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {  
                        alert("Công cụ "+MaCCDC+" đã được tính khấu hao, không thể xóa hoặc sửa!");
                         IsKhauHao = true;
                        document.getElementById('checkbox_LuuSoCai').checked = true;
                      }
                      else
                      {
                           IsKhauHao = false;
                            document.getElementById('checkbox_LuuSoCai').checked = false;
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=CheckCCDC_KhauHao&MaCCDC="+MaCCDC+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function XoaCongCuDungCu_SoCai(Ctr,SoPhieuCCDC)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                     LuuCongCuDungCu(Ctr);
                     
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=XoaCongCuDungCu_SoCai&SoPhieuCCDC="+SoPhieuCCDC+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function LuuCongCuDungCu(Ctr)
{
  // TaoMaSoTuDong();
   document.getElementById('message').style.visibility = "visible";
    btnSave = document.getElementById('btnSave');
   var IsSaveSoCai="false";
    if(document.getElementById('checkbox_LuuSoCai').checked)
        IsSaveSoCai = "true";
       
    var MaCCDC = document.getElementById('txtmaCCDC').value;
  
    var TenCCDC = encodeURIComponent(document.getElementById('txtTenCCDC').value);

    var index=document.getElementById("ddlNuocSX").selectedIndex;
    var HangSX = encodeURIComponent(document.getElementsByTagName("option")[index].value);

    var NamSX = document.getElementById('txtNamSX').value;
    
    var tien =document.getElementById('txtNguyenGia').value;
    var NguyenGia = ChangeFormatCurrency(tien);
    var NgayNhap = document.getElementById('txtNgayNhap').value;
    var NgayKhauHao = document.getElementById('txtNgayKH').value;
    var SoThangKH = document.getElementById('txtSoNamKH').value;
    var TKNguyenGia = document.getElementById('txtTKNguyenGia').value;
    var TKDoiUng = document.getElementById('txtTKDoiUng').value;
    var TKThue = document.getElementById('txtTKThue').value;
    var TKChiPhi = document.getElementById('txtTKChiPhi').value;
    var TKKhauHao = document.getElementById('txtTKKhauHao').value;
    var ThueSuat = document.getElementById('txtThueSuat').value;
   
    var tienthue = document.getElementById('txtTienThue').value;
    var TienThue = ChangeFormatCurrency(tienthue);
    
    var DienGiai = encodeURIComponent(document.getElementById('txtDienGiai').value);
    var isEmpty = TestEmptyData();
    
    
    var Data2="";
    if(isEmpty==true)
    {
        if(IsKhauHao==false)
        {
        
            Data2 +=";"+SoPhieuCCDC;
            Data2 +=";"+ MaCCDC;
            Data2 +=";"+TenCCDC;
            Data2 +=";"+HangSX;
            Data2 +=";"+NamSX;
            Data2 +=";"+NguyenGia;
            Data2 +=";"+NgayNhap;
            Data2 +=";"+NgayKhauHao;
            Data2 +=";"+SoThangKH;
            Data2 +=";"+TKNguyenGia;
            Data2 +=";"+TKDoiUng;
            Data2 +=";"+TKThue;
            Data2 +=";"+TKChiPhi;
            Data2 +=";"+TKKhauHao;
            Data2 +=";"+TKThue;
            Data2 +=";"+TienThue;
            Data2 +=";"+DienGiai;
            
            getFunctionLuuCongCuDungCu(Ctr,Data2,IsSaveSoCai);
        }
    }
    
}
function getFunctionLuuCongCuDungCu(Ctr,Data,isSaveSoCai)
{
          xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {  
                       
                        alert("Lưu công cụ dụng cụ thành công!");
                        document.getElementById('btnSave').value = "Sửa";
                         //MaTaiKhoan.value ="";
                         LoadThongTinCongCuDungCu("DanhSach","","","","","","");
                      }
                      else
                      {
                         alert("Lưu công cụ dụng cụ thất bại!");
                      }
                      Ctr.disable =  false;
                      document.getElementById('message').style.visibility = "hidden";
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=LuuDanhMucCongCuDungCuAndSoCai&Data="+Data+"&SaveSoCai="+isSaveSoCai+"&times="+Math.random(),true);
            xmlHttp.send(null);
    
}

//thuc thi load thong tin ccdc
function LoadThongTinCongCuDungCu(typeLoad,SoPhieu_CCDC,MaCCDC,TenCCDC,HangSX,NgayNhap,NgayKH)
{
    ResetTableDSCCDC();//dau tien t hcu thi reload thong tin ccdc
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="")
                      {  
                        var row = value.split('&');
                        if(row.length>0)
                        {
                            for(var i=1;i<row.length;i++)
                            {
                                var column = row[i].split('|');
                                if(column.length>0)
                                {//So_Phieu_CCDC,Ma_CCDC,Ten_CCDC,Hang_SX,Nam_SX,Nguyen_Gia,Ngay_Nhap,Ngay_Khau_Hao,So_Thang_Khau_Hao,TK_CCDC,TK_Doi_Ung,TK_Thue,TK_Chi_Phi,TK_Phan_Bo,Thue_Suat,Tien_Thue,Dien_Giai
                                    if(typeLoad=="DanhSach")
                                        ShowDanhSachCCDC(column[0],column[1],column[2],column[3],column[4],column[5],column[6],column[7],column[8],column[9],column[10],column[11],column[12],column[13],column[14],column[15],column[16]);            
                                    else
                                    if(typeLoad=="ChiTiet")
                                        ShowChiTietCCDC(column[0],column[1],column[2],column[3],column[4],column[5],column[6],column[7],column[8],column[9],column[10],column[11],column[12],column[13],column[14],column[15],column[16]);            
                                    
                                }
                            }
                        }
                        
                      }
                      else
                      {
                        document.getElementById('btnSave').disable =  false;
                        document.getElementById('message').style.visibility = "hidden";
                      }
                }
            }
  //xmlHttp.open("GET","ajax.aspx?do=LoadThongTinCongCuDungCu&SoPhieuCCDC="+SoPhieu_CCDC+"&MaCCDC="+MaCCDC+"&TenCCDC="+encodeURIComponent(TenCCDC)+"&HangSX="+HangSX+"&NgayNhap="+NgayNhap+"&NgayKH="+NgayKH+"&times="+Math.random(),true);
              //  SoPhieuCCDC, MaCCDC,  TenCCDC, HangSX, NgayNhap,NgayKH   
              xmlHttp.open("GET","ajax.aspx?do=LoadThongTinCongCuDungCu&SoPhieuCCDC="+SoPhieu_CCDC+"&MaCCDC="+MaCCDC+"&TenCCDC="+encodeURIComponent(TenCCDC)+"&HangSX="+HangSX+"&NgayNhap="+NgayNhap+"&NgayKH="+NgayKH+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function ShowDanhSachCCDC(So_Phieu_CCDC,Ma_CCDC,Ten_CCDC,Hang_SX,Nam_SX,Nguyen_Gia,Ngay_Nhap,Ngay_Khau_Hao,So_Thang_Khau_Hao,TK_CCDC,TK_Doi_Ung,TK_Thue,TK_Chi_Phi,TK_Phan_Bo,Thue_Suat,Tien_Thue,Dien_Giai)
{
    
     var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td style=\"width:50px;text-align:center\">" + (lastRow-1) + "</td>";
            shtml += "		<td style=\"width:50px;text-align:center\"><label id=\"Xoa_"+(lastRow-1)+"\" style=\"cursor:pointer;font-style:italic;color:Blue\" onclick=\"XoaCCDC('"+So_Phieu_CCDC+"','"+Ma_CCDC+"')\">Xóa</label></td>	";
            shtml += "		<td style=\"width:50px;text-align:center\"><label id=\"Sua_"+(lastRow-1)+"\" style=\"cursor:pointer;font-style:italic;color:Blue\" onclick=\"SuaCCDC('"+So_Phieu_CCDC+"')\">Sửa</label></td>	";
            shtml += "		<td style=\"width:200px;text-align:center\">"+Ma_CCDC+"</a></td>	";
            shtml += "		<td style=\"width:100px;text-align:center\">"+Ten_CCDC+"</td>	";
            shtml += "		<td style=\"width:300px;text-align:center\">"+FormatSoTien2(Nguyen_Gia)+"</td>	";
            shtml += "		<td style=\"width:50px;text-align:center\">"+So_Thang_Khau_Hao+"</td>	";
            shtml += "		<td style=\"width:100px;text-align:center\">"+Ngay_Nhap+"</td>	";
            shtml += "		<td style=\"width:100px;text-align:center\">"+Ngay_Khau_Hao+"</td>	";
            shtml += "		<td style=\"width:200px;text-align:center\">"+Dien_Giai+"</td>	";
            
            
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
}
function ShowChiTietCCDC(So_Phieu,Ma_CCDC,Ten_CCDC,Hang_SX,Nam_SX,Nguyen_Gia,Ngay_Nhap,Ngay_Khau_Hao,So_Thang_Khau_Hao,TK_CCDC,TK_Doi_Ung,TK_Thue,TK_Chi_Phi,TK_Phan_Bo,Thue_Suat,Tien_Thue,Dien_Giai)
{
    
    IsSaveOrUpdate="Update";
     
    
    document.getElementById('btnSave').value = "Sửa";
    document.getElementById('btnSave').disable = false;
    document.getElementById('message').style.visibility = "hidden";
    
    SoPhieuCCDC = So_Phieu;
    document.getElementById('txtDienGiai').value = Dien_Giai;
    document.getElementById('ddlNuocSX').value = Hang_SX;
    document.getElementById('txtmaCCDC').value = Ma_CCDC;
    document.getElementById('txtTenCCDC').value = Ten_CCDC;
    document.getElementById('txtNamSX').value = Nam_SX;
    document.getElementById('txtNgayKH').value = Ngay_Khau_Hao;
    document.getElementById('txtNgayNhap').value = Ngay_Nhap;
    document.getElementById('txtNguyenGia').value = FormatSoTien2(Nguyen_Gia);
    document.getElementById('txtSoNamKH').value = So_Thang_Khau_Hao;
    document.getElementById('txtThueSuat').value = Thue_Suat;
    document.getElementById('txtTienThue').value = FormatSoTien2(Tien_Thue);
    document.getElementById('txtTKChiPhi').value = TK_Chi_Phi;
    document.getElementById('txtTKDoiUng').value = TK_Doi_Ung;
    document.getElementById('txtTKKhauHao').value = TK_Phan_Bo;
    document.getElementById('txtTKNguyenGia').value = TK_CCDC;
    document.getElementById('txtTKThue').value = TK_Thue;
    CheckCCDC_KhauHao(Ma_CCDC);
    
}
function XoaCCDC(SoPhieuCCDC,Ma_CCDC)
{
    var rs = confirm("Bạn có chắc muốn xóa công cụ dụng cụ " +Ma_CCDC+" này không?");
    if(rs==true)
    {
        CheckCCDC_KhauHao(Ma_CCDC);
        if(IsKhauHao==false)
        {
            XoaDanhMucCongCuDungCu(SoPhieuCCDC);
        }
        else
        {
            alert("Công cụ dụng cụ " +Ma_CCDC+" này đã được tính khấu hao nên không thể xóa được.");
        }
    }
}
function XoaDanhMucCongCuDungCu(SoPhieuCCDC)
{
     xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {
                       
                        LoadThongTinCongCuDungCu("DanhSach","","","","","","");
                      }
                      else
                      {
                        document.getElementById('btnSave').disable =  false;
                        document.getElementById('message').style.visibility = "hidden";
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=XoaDanhMucCongCuDungCu&SoPhieuCCDC="+SoPhieuCCDC+"&times="+Math.random(),true);
            xmlHttp.send(null);
}

function SuaCCDC(So_Phieu_CCDC)
{
    IsSaveOrUpdate="Update";
     var btnSave = document.getElementById('btnSave');
     btnSave.value = "Lưu";
    LoadThongTinCongCuDungCu("ChiTiet",So_Phieu_CCDC,"","","","","");
    
}
function ResetTableDSCCDC()
{
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var lastRow = Row;
    while(lastRow>2)
    {
        TableDanhSach.deleteRow(lastRow-1);
        lastRow--;
    }

}
</script>
<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:uscmenuKT_CCDC ID="uscmenuKT_CCDC" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="Table1">
                <tr style="height:10px">
                    <td><div  class = "tdHeader">DANH MỤC CÔNG CỤ DỤNG CỤ</div></td>
                </tr>
                <tr>
					    <td width="100%" valign = "top">
						    <table cellPadding="0" width="100%" border="0">
							    <tr>
								    <td vAlign="top" align="center" width="100%">
									    <table cellSpacing="0" cellPadding="0" width="98%" border="0">
										    
										    <tr style="padding-bottom: 5px; padding-top: 10px">
											    <td align="left"  style="height: 20px;width:100%;padding-left:200px">
												    <table class="Table" >
												      
												        <tr>
                                                            <td class="tdLabel">Mã CCDC: </td>
                                                            <td class="tdText"><input type="text" id="txtmaCCDC" tabindex="1"/></td>
                                                            
                                                            <td class="tdLabel" >Tên CCDC:</td>
                                                            <td  class="tdText" colspan="3" ><input type="text" id="txtTenCCDC" tabindex="2"/></td>
                                                           
                                                           
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">Ngày nhập : </td>
                                                            <td class="tdCalenda"><input type="text" id="txtNgayNhap"  tabindex="3" onblur = "TestDatePhieu(this)"/></td>
                                                            <td class="tdLabel">Nước sản xuất: </td>
                                                            <td  class="tdText">  <select id="ddlNuocSX" tabindex="4" >
                                                                    <option value="Mỹ">Mỹ</option>
                                                                    <option value="Anh">Anh</option>
                                                                    <option value="Pháp">Pháp</option>
                                                                    <option value="Đức">Đức</option>
                                                                    <option value="Nhật">Nhật</option>
                                                                    <option value="Đài Loan">Đài Loan</option>
                                                                    <option value="Khác">Khác</option>
                                                                    </select>
                                                            </td>
                                                            <td class="tdLabel">Năm sản xuất : </td>
                                                            <td class="tdText"><input type="text" id="txtNamSX" onblur="TestNum(this)" tabindex="5" /></td>
                                                           
                                                        </tr>
                                                       
                                                        <tr>
                                                            <td class="tdLabel">Số ngày khấu hao : </td>
                                                            <td  class="tdCalenda"><input type="text" id="txtSoNamKH"  onblur="TestNum(this);" tabindex="6"/>ngày</td>
                                                          
                                                            <td class="tdLabel">Ngày khấu hao : </td>
                                                            <td class="tdText"> <input type="text" id="txtNgayKH" onblur="TestDatePhieu(this)"  tabindex="7" /></td>
                                                            
                                                        </tr>
                                                         <tr>
                                                            <td class="tdLabel"> Nguyên giá : </td>
                                                            <td  class="tdText"><input type="text" id="txtNguyenGia"  onblur = "FormatSoTien(this);TestNum(this);TinhTienThue()" tabindex="8"/></td>
                                                            
                                                            <td class="tdLabel">Tài khoản CCDC: </td>
                                                            <td class="tdText"><input type="text" id="txtTKNguyenGia"  onfocus="ShowTaiKhoan('txtTKNguyenGia')" onchange="TestMaTaiKhoan('txtTKNguyenGia')"  tabindex="9" width="112px" /></td>
                                                            
                                                            <td class="tdLabel">TK đối ứng : </td>
                                                            <td class="tdText"><input type="text" id="txtTKDoiUng"  onfocus="ShowTaiKhoan('txtTKDoiUng')" onchange="TestMaTaiKhoan('txtTKDoiUng')" tabindex="10" width="112px" /></td>
                                                        </tr>
                                                       
                                                        <tr>
                                                            <td class="tdLabel">TK khấu hao : </td>
                                                            <td class="tdText"><input type="text" id="txtTKKhauHao" onfocus="ShowTaiKhoan('txtTKKhauHao')" onchange="TestMaTaiKhoan('txtTKKhauHao')"  tabindex="11" width="112px" /></td>
                                                             <td class="tdLabel">TK chi phí KH : </td>
                                                            <td class="tdText"><input type="text" id="txtTKChiPhi" onfocus="ShowTaiKhoan('txtTKChiPhi')" onchange="TestMaTaiKhoan('txtTKChiPhi')" tabindex="12" width="112px" /></td>
                                                            <%--<td class="tdLabel">TK chi phí trả trước : </td>
                                                            <td class="tdText"><input type="text" id="txtTKChiPhiKhac" onfocus="ShowTaiKhoan('txtTKChiPhiKhac')" onchange="TestMaTaiKhoan('txtTKChiPhiKhac')" tabindex="14" width="112px" /></td>--%>
                                                            
                                                        </tr>
                                                       <tr>
                                                            <td class="tdLabel">TK Thuế : </td>
                                                            <td class="tdText"><input type="text" id="txtTKThue" onfocus="ShowTaiKhoan('txtTKThue')" onchange="TestMaTaiKhoan('txtTKThue')" tabindex="13" width="112px" /></td>
                                                            <td class="tdLabel">Thuế suất : </td>
                                                            <td class="tdText"><input type="text" id="txtThueSuat"   onchange="TestNum(this);TinhTienThue()"  tabindex="14" width="112px" /></td>
                                                             <td class="tdLabel">Tiền thuế : </td>
                                                            <td class="tdText"><input type="text" id="txtTienThue" onblur = "FormatSoTien(this);TestNum(this);" tabindex="15"/></td>
                                                            
                                                            
                                                        </tr> 
                                                        <tr>    
                                                             <td class="tdLabel">Diễn giải : </td>
                                                            <td colspan="6"  class="tdText">
                                                                <textarea id="txtDienGiai" runat="server" style="width:510px" cols="20" tabindex="15"  rows="2"></textarea></td>
                                                        </tr>
                                                       <tr>    
                                                            
                                                            <td colspan="3" align="center"> <input type="checkbox" id="checkbox_LuuSoCai" tabindex="16" />Lưu sổ cái</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" style="text-align:center">
                                                                
															    
                                                                <input type="button" value="Lưu" id="btnSave" onclick="btnSave_Click(this)" style="width:100px;"  />
                                                                <input type="button" id="btnTimKiem" value="Tìm kiếm"style="width:100px" onclick="btnTimKiem_Click()" tabindex="18" />
                                                                <input type="button" value="Tạo mới"  style="width:100px" onclick="btnTaoMoi_Click()" id="bt_Reset" />
                                                                
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="9" style="text-align:center">
                                                                <label id="message" style="visibility:hidden" > Đang xử lý vui lòng chờ trong giây lát....</label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                  </td>
										    </tr>
									    </table>
								    </td>
							    </tr>
							   
						    </table>
						    
						    				   
					    </td>
				</tr>
            </table>
         </td>
       </tr>       
	    
</table>
<table class="TableGidview" id="TableDanhSach">
         <tr>
              <td class ="tdHeader" colspan="11" >Danh sách công cụ dụng cụ</td>
         </tr>
		<tr class="HeaderGidView">
		     <td class="HeaderColumn0">STT</td>
		     <td class="HeaderColumn0">Xóa</td>
		     <td class="HeaderColumn0">Sửa</td>
		     <td class="HeaderColumn1">
		       Mã CCDC
		     </td>
		     
		     <td class="HeaderColumn2">
		       Tên CCDC
		       
		    </td>
		    <td class="HeaderColumn2">
		       Nguyên giá
		       
		    </td>
		    <td class="HeaderColumn1">
		       Số tháng khấu hao
		    </td>
		    <td class="HeaderColumn1">
		       Ngày nhập
		    </td>
		    <td class="HeaderColumn1">
		       Ngày khấu hao
		    </td>
		     <td class="HeaderColumn3">
		       Diễn giải
		    </td>
		</tr>					 
	  
		
		
		 
	</table>

 
</form>         
<!--#include file = "footer.htm" -->