function trim(s)
{
	return rtrim(ltrim(s));
}

function ltrim(s)
{
	var l=0;
	while(l < s.length && s[l] == ' ')
	{	l++; }
	return s.substring(l, s.length);
}

function rtrim(s)
{
	var r=s.length -1;
	while(r > 0 && s[r] == ' ')
	{	r-=1;	}
	return s.substring(0, r+1);
}

function Left(str, n){
	if (n <= 0)
	    return "";
	else if (n > String(str).length)
	    return str;
	else
	    return String(str).substring(0,n);
}
function Right(str, n){
    if (n <= 0)
       return "";
    else if (n > String(str).length)
       return str;
    else {
       var iLen = String(str).length;
       return String(str).substring(iLen, iLen - n);
    }
}


function ShowOptionChiTiet(valobj)
{
    var i;
    for (i = 0; i < 4; i++)
    {
        var obj = document.getElementById("option_" + i);
        obj.style.display = "none";
    }
    var objdt = document.getElementById("option_" + valobj);
    objdt.style.display = "";
}


function SearchTuNgayDenNgay()
{
    var obj1 = document.getElementById("txtbatdau");
    
    if (obj1.value == "")
    {
        alert("Bạn chưa nhập ngày tháng bắt đầu. Vui lòng kiểm tra lại! ");
		obj1.focus();
		return false;
    }
    else
    {
        obj1.value=AddString(obj1.value);
        if (isDate(obj1.value)==false)
		{
			alert("Bạn nhập ngày tháng không hợp lệ ! ");
			obj1.focus();
			return false;
		}   
    }
    var obj2 = document.getElementById("txtketthuc");
    if (obj2.value == "")
    {
        alert("Bạn chưa nhập ngày tháng kết thúc. Vui lòng kiểm tra lại! ");
		obj2.focus();
		return false;
    }
    else
    {
        if (isDate(obj2.value)==false)
		{
			alert("Bạn nhập ngày tháng không hợp lệ ! ");
			obj2.focus();
			return false;
		}   
    }
    var obj = new Object();
        obj = window.showModalDialog("rptthongkebenhnhantheongay.aspx?sdate=" + obj1.value + "&edate=" + obj2.value + "&times="+Math.random(),"","DialogWidth:900px;DialogHeight:500px;overflow:hidden;");
    //window.Open("");
    return;    
}

function SearchTheoQuy()
{
    var objquy = document.getElementById("quy");
    if (objquy.value == "0")
    {
        alert("Bạn chưa chọn quý để xem. Vui lòng kiểm tra lại! ");
		objquy.focus();
		return false;
    }
    var objnam = document.getElementById("year11111");
    if (objnam.value == "0")
    {
        alert("Bạn chưa chọn năm để xem. Vui lòng kiểm tra lại! ");
		objnam.focus();
		return false;
    }
    var obj = new Object();
        obj = window.showModalDialog("rptthongkebenhnhantheoquy.aspx?quy=" + objquy.value + "&nam=" + objnam.value + "&times="+Math.random(),"","DialogWidth:900px;DialogHeight:500px;overflow:hidden;");
    //window.Open("");
    return;       
}

function SearchTheoNam()
{
    var objnam = document.getElementById("year1");
    if (objnam.value == "0")
    {
        alert("Bạn chưa chọn năm để xem. Vui lòng kiểm tra lại! ");
		objnam.focus();
		return false;
    }
    var obj = new Object();
        obj = window.showModalDialog("rptthongkebenhnhantheonam.aspx?nam=" + objnam.value + "&times="+Math.random(),"","DialogWidth:900px;DialogHeight:500px;overflow:hidden;");
    //window.Open("");
    return;       
}

function SearchTheoLoaiBenhNhan()
{
    var objtype = document.getElementById("loaibenhnhan");
  
    var obj = new Object();
        obj = window.showModalDialog("rptthongkebenhnhantheoloai.aspx?itype=" + objtype.value + "&times="+Math.random(),"","DialogWidth:900px;DialogHeight:500px;overflow:hidden;");
    //window.Open("");
    return;       
}

//Bac si kham benh
function DoanhSoBacSiTuNgayDenNgay()
{
    var obj1 = document.getElementById("txtbatdau");
    if (obj1.value == "")
    {
        alert("Bạn chưa nhập ngày tháng bắt đầu. Vui lòng kiểm tra lại! ");
		obj1.focus();
		return false;
    }
    else
    {
        if (isDate(obj1.value)==false)
		{
			alert("Bạn nhập ngày tháng không hợp lệ ! ");
			obj1.focus();
			return false;
		}   
    }
    var obj2 = document.getElementById("txtketthuc");
    if (obj2.value == "")
    {
        alert("Bạn chưa nhập ngày tháng kết thúc. Vui lòng kiểm tra lại! ");
		obj2.focus();
		return false;
    }
    else
    {
        if (isDate(obj2.value)==false)
		{
			alert("Bạn nhập ngày tháng không hợp lệ ! ");
			obj2.focus();
			return false;
		}   
    }
    var objbs= document.getElementById("listbacsi11");
    if (objbs.value == "0")
    {
        alert("Bạn chưa chọn tên bác sĩ cần thống kê. Vui lòng kiểm tra lại! ");
		objbs.focus();
		return false;
    }
    var obj = new Object();
        obj = window.showModalDialog("rptdoanhsobacsitheongay.aspx?sdate=" + obj1.value + "&edate=" + obj2.value + "&idbacsi=" + objbs.value + "&times="+Math.random(),"","DialogWidth:900px;DialogHeight:500px;overflow:hidden;");
    window.Open("");
    return;    
}

function DoanhSoBacSiTheoQuy()
{
    var objquy = document.getElementById("quy");
    if (objquy.value == "0")
    {
        alert("Bạn chưa chọn quý để xem. Vui lòng kiểm tra lại! ");
		objquy.focus();
		return false;
    }
    var objnam = document.getElementById("year11111");
    if (objnam.value == "0")
    {
        alert("Bạn chưa chọn năm để xem. Vui lòng kiểm tra lại! ");
		objnam.focus();
		return false;
    }
    var objbs= document.getElementById("listbacsi12");
    if (objbs.value == "0")
    {
        alert("Bạn chưa chọn tên bác sĩ cần thống kê. Vui lòng kiểm tra lại! ");
		objbs.focus();
		return false;
    }
    var obj = new Object();
        obj = window.showModalDialog("rptdoanhsobacsitheoquy.aspx?quy=" + objquy.value + "&nam=" + objnam.value + "&idbacsi=" + objbs.value + "&times="+Math.random(),"","DialogWidth:900px;DialogHeight:500px;overflow:hidden;");
    window.Open("");
    return;       
}

function DoanhSoBacSiTheoNam()
{
    var objnam = document.getElementById("year1");
    if (objnam.value == "0")
    {
        alert("Bạn chưa chọn năm để xem. Vui lòng kiểm tra lại! ");
		objnam.focus();
		return false;
    }
    
    var objbs= document.getElementById("listbacsi13");
    if (objbs.value == "0")
    {
        alert("Bạn chưa chọn tên bác sĩ cần thống kê. Vui lòng kiểm tra lại! ");
		objbs.focus();
		return false;
    }
    var obj = new Object();
        obj = window.showModalDialog("rptdoanhsobacsitheonam.aspx?nam=" + objnam.value + "&idbacsi=" + objbs.value + "&times="+Math.random(),"","DialogWidth:900px;DialogHeight:500px;overflow:hidden;");
    window.Open("");
    return;       
}


//Bac si can lam san

function DoanhSoBacSiCLSTuNgayDenNgay()
{
    var obj1 = document.getElementById("txtbatdau");
    if (obj1.value == "")
    {
        alert("Bạn chưa nhập ngày tháng bắt đầu. Vui lòng kiểm tra lại! ");
		obj1.focus();
		return false;
    }
    else
    {
        if (isDate(obj1.value)==false)
		{
			alert("Bạn nhập ngày tháng không hợp lệ ! ");
			obj1.focus();
			return false;
		}   
    }
    var obj2 = document.getElementById("txtketthuc");
    if (obj2.value == "")
    {
        alert("Bạn chưa nhập ngày tháng kết thúc. Vui lòng kiểm tra lại! ");
		obj2.focus();
		return false;
    }
    else
    {
        if (isDate(obj2.value)==false)
		{
			alert("Bạn nhập ngày tháng không hợp lệ ! ");
			obj2.focus();
			return false;
		}   
    }
    var objbs= document.getElementById("listbacsi11");
    if (objbs.value == "0")
    {
        alert("Bạn chưa chọn tên bác sĩ cần thống kê. Vui lòng kiểm tra lại! ");
		objbs.focus();
		return false;
    }
    var obj = new Object();
        obj = window.showModalDialog("rptdoanhsobacsiclstheongay.aspx?sdate=" + obj1.value + "&edate=" + obj2.value + "&idbacsi=" + objbs.value + "&times="+Math.random(),"","DialogWidth:900px;DialogHeight:500px;overflow:hidden;");
    window.Open("");
    return;    
}

function DoanhSoBacSiCLSTheoQuy()
{
    var objquy = document.getElementById("quy");
    if (objquy.value == "0")
    {
        alert("Bạn chưa chọn quý để xem. Vui lòng kiểm tra lại! ");
		objquy.focus();
		return false;
    }
    var objnam = document.getElementById("year11111");
    if (objnam.value == "0")
    {
        alert("Bạn chưa chọn năm để xem. Vui lòng kiểm tra lại! ");
		objnam.focus();
		return false;
    }
    var objbs= document.getElementById("listbacsi12");
    if (objbs.value == "0")
    {
        alert("Bạn chưa chọn tên bác sĩ cần thống kê. Vui lòng kiểm tra lại! ");
		objbs.focus();
		return false;
    }
    var obj = new Object();
        obj = window.showModalDialog("rptdoanhsobacsiclstheoquy.aspx?quy=" + objquy.value + "&nam=" + objnam.value + "&idbacsi=" + objbs.value + "&times="+Math.random(),"","DialogWidth:900px;DialogHeight:500px;overflow:hidden;");
    window.Open("");
    return;       
}

function DoanhSoBacSiCLSTheoNam()
{
    var objnam = document.getElementById("year1");
    if (objnam.value == "0")
    {
        alert("Bạn chưa chọn năm để xem. Vui lòng kiểm tra lại! ");
		objnam.focus();
		return false;
    }
    
    var objbs= document.getElementById("listbacsi13");
    if (objbs.value == "0")
    {
        alert("Bạn chưa chọn tên bác sĩ cần thống kê. Vui lòng kiểm tra lại! ");
		objbs.focus();
		return false;
    }
    var obj = new Object();
        obj = window.showModalDialog("rptdoanhsobacsiclstheonam.aspx?nam=" + objnam.value + "&idbacsi=" + objbs.value + "&times="+Math.random(),"","DialogWidth:900px;DialogHeight:500px;overflow:hidden;");
    window.Open("");
    return;       
}
//ThuanNH 26/05/2010
function LoadLuuUNC()
    {
        var opxid = document.getElementById("txtpxid");         
        var oSoCt = document.getElementById("txtSoCT"); 
        var oNgayCt = document.getElementById("txtNgayCT"); 
        var oNCC = document.getElementById("ddlncc"); 
        var odvnhan = document.getElementById("ddlDVNhan");
        var oDienGiai = document.getElementById("txtDienGiai"); 
        var osotien = document.getElementById("txtSoTien"); 
        osotien.value=(osotien.value).replace('.','').replace('.','');
        var ovat = document.getElementById("txtVAT");
        var otienvat = document.getElementById("txtTienVAT");
        var otaikhoanvat = document.getElementById("txtTaiKhoanVAT");   
        var loaitien = document.getElementById("ddlLoaiTien");//30/06/2011
        var tygia=document.getElementById("txtTyGia");
        //ThuanNH 25/02/2011
        var ock = document.getElementById("txtCK");
        var otienck = document.getElementById("txtTienCK");
        var otaikhoanck = document.getElementById("txtTaiKhoanCK");   
        
//        var otaikhoannhno = document.getElementById("ddlTaiKhoanNHNo"); 
//        var otaikhoannh = document.getElementById("ddlTaiKhoanNH");
        var otaikhoannhno = document.getElementById("txtTaiKhoanNHNo"); 
        var otaikhoannh = document.getElementById("txtTaiKhoanNH");
        var otaikhoanno = document.getElementById("txtTaiKhoanNo");
        var otaikhoanco = document.getElementById("txtTaiKhoanCo");
        var osohoadon = document.getElementById("txtSoHoaDon");
        var ongayhoadon = document.getElementById("txtngayhoadon");    
        //alert("test");
        LuuUNC(opxid.value, oSoCt.value, oNgayCt.value, oDienGiai.value, oNCC.value, odvnhan.value, osotien.value, otaikhoannhno.value, otaikhoannh.value, otaikhoanno.value, otaikhoanco.value, osohoadon.value, ongayhoadon.value, ovat.value, otienvat.value, otaikhoanvat.value, ock.value, otienck.value, otaikhoanck.value, loaitien.value, tygia.value);
	    return;
    }
    
function LuuUNC(oPxid, oSoCt, oNgayCt, oDienGiai, oNCC, oDVNhan, oSoTien, oTaiKhoanNHNo, oTaiKhoanNH, oTaiKhoanNo, oTaiKhoanCo, oSoHoaDon, oNgayHoaDon, oVAT, oTienVAT, oTaiKhoanVAT, oCK, oTienCK, oTaiKhoanCK, oLoaiTien, oTyGia)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var obj = document.getElementById("chitietphieu"); 
                var value = xmlHttp.responseText;
                if (value == "0")
                {
                    alert("Số phiếu đã tồn tại!");
                    return;
                }
                if (value == "1")
                {
                    alert("Lỗi lưu thông tin dữ liệu!");
                    return;
                }
                else
                {
                    var opxid = document.getElementById("txtpxid"); 
                    opxid.value = "1";
                    //alert("Lưu thông tin dữ liệu thành công!");
                    //ResetSession();
                    obj.innerHTML = value;
                    //document.location.href = "UyNhiemChi.aspx";   
                }
            }
        }
        //alert(oNgayCt);
        xmlHttp.open("GET","ajax.aspx?do=LuuUyNhiemChi&Pxid="+oPxid+"&soct="+oSoCt+"&ngayct="+oNgayCt+"&diengiai="+encodeURIComponent(oDienGiai)+"&nccid="+oNCC+"&dvnhan="+encodeURIComponent(oDVNhan)+"&sotien="+oSoTien+"&taikhoannhno="+oTaiKhoanNHNo+"&taikhoannh="+oTaiKhoanNH+"&taikhoanno="+oTaiKhoanNo+"&taikhoanco="+oTaiKhoanCo+"&sohoadon="+oSoHoaDon+"&ngayhoadon="+oNgayHoaDon+"&VAT="+oVAT+"&TienVAT="+oTienVAT+"&TaiKhoanVAT="+oTaiKhoanVAT+"&CK="+oCK+"&TienCK="+oTienCK+"&TaiKhoanCK="+oTaiKhoanCK+"&LoaiTien="+oLoaiTien+"&TyGia="+oTyGia+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
 function SuaUNC(objmactp)
    {
        var oSoCt = document.getElementById("txtSoCT_"+objmactp); 
        //alert(oSoCt.value);
        var oNgayCt = document.getElementById("txtNgay_"+objmactp); 
        var oDienGiai = document.getElementById("txtNoiDungTT_"+objmactp); 
        var osotien = document.getElementById("txtSoTien_"+objmactp); 
        var otaikhoannhno = document.getElementById("txtTaiKhoanNHNo_"+objmactp); 
        var otaikhoannh = document.getElementById("txtTaiKhoanNH_"+objmactp);
        
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Lỗi cập nhật dữ liệu!");
                }
                else
                {
                    //alert("test");
                    obj.innerHTML = value;    
//                    alert("Cập nhật dữ liệu thành công!");  
//                    ResetSession();
//                    document.location.href = "UyNhiemChi.aspx";             
                }
                
            }
        }
        //alert(oSoCt.value);
        xmlHttp.open("GET","ajax.aspx?do=LoadSuaUNC&soct="+oSoCt.value+"&ngayct="+oNgayCt.value+"&diengiai="+encodeURIComponent(oDienGiai.value)+"&sotien="+osotien.value+"&taikhoannhno="+otaikhoannhno.value+"&taikhoannh="+otaikhoannh.value+"&times="+Math.random(),true);
        //alert(oSoCt.value)
        xmlHttp.send(null);
    }    
  
function LoadLuuThuChiNH()
    {
        var keycode = 9;
        var opxid = document.getElementById("txtpxid");         
        if(keycode == 9) // Phim Tab
        {
            
            if (opxid.value == "-1")
            {
                var oSoCt = document.getElementById("txtSoCT"); 
                var oNgayCt = document.getElementById("txtNgayCT"); 
                var oNCC = document.getElementById("ddlncc"); 
                var osohoadon = document.getElementById("txtSoHoaDon");
                var ongayhoadon = document.getElementById("txtngayhoadon");
                var oDienGiai = document.getElementById("txtDienGiai"); 
                var osotien = document.getElementById("txtSoTien"); 
                var otaikhoanno = document.getElementById("txtTaiKhoanNo"); 
                var otaikhoanco = document.getElementById("txtTaiKhoanCo"); 
                var otaikhoannh = document.getElementById("ddlTaiKhoanNH");
                var osoUNC = document.getElementById("txtUNC");
            }
            else
            {
                var oSoCt = document.getElementById("txtSoCT"); 
                var oNgayCt = document.getElementById("txtNgayCT"); 
                var oNCC = document.getElementById("ddlncc"); 
                var osohoadon = document.getElementById("txtSoHoaDon");
                var ongayhoadon = document.getElementById("txtngayhoadon");
                var oDienGiai = document.getElementById("txtDienGiai"); 
                var osotien = document.getElementById("txtSoTien"); 
                var otaikhoanno = document.getElementById("txtTaiKhoanNo"); 
                var otaikhoanco = document.getElementById("txtTaiKhoanCo"); 
                var otaikhoannh = document.getElementById("ddlTaiKhoanNH");
                var osoUNC = document.getElementById("txtUNC");
            }            
            
            if (opxid.value == "-1") // Them moi
            {
                LuuThuChiNH(opxid.value, oSoCt.value, oNgayCt.value, oDienGiai.value, oNCC.value, osohoadon.value, ongayhoadon.value, osotien.value, otaikhoanno.value, otaikhoanco.value, otaikhoannh.value, osoUNC.value);
            }

            else//Chinh sua, cap nhat
            {
                LuuThuChiNH(opxid.value, oSoCt.value, oNgayCt.value, oDienGiai.value, oNCC.value, osohoadon.value, ongayhoadon.value, osotien.value, otaikhoanno.value, otaikhoanco.value, otaikhoannh.value, osoUNC.value);
            }
	    }  
	    return;
    }
    
function LuuThuChiNH(oPxid, oSoCt, oNgayCt, oDienGiai, oNCC, oSoHoaDon, oNgayHoaDon, oSoTien, oTaiKhoanNo, oTaiKhoanCo, oTaiKhoanNH, oSoUNC)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            var obj = document.getElementById("chitietphieu"); 
            if(xmlHttp.readyState == 4)
            {
                //alert("test");
                var value = xmlHttp.responseText;
                if (value == "0")
                {
                    alert("Số phiếu đã tồn tại!");
                    return;
                }
                else if (value == "1")
                {
                    alert("Lỗi lưu thông tin dữ liệu!");
                    return;
                }
                else
                {
                    //alert("test");
                    obj.innerHTML = value;
                    var opxid = document.getElementById("txtpxid"); 
                    opxid.value = "1";
                    alert("Lưu thông tin dữ liệu thành công!");
                    ResetSession();
                    //document.location.href = "ThuChiHoaDonNH.aspx";   
                }
            }
        }
        //alert(oNgayCt);
        xmlHttp.open("GET","ajax.aspx?do=LuuThuChiNH&Pxid="+oPxid+"&soct="+oSoCt+"&ngayct="+oNgayCt+"&diengiai="+encodeURIComponent(oDienGiai)+"&nccid="+oNCC+"&sohoadon="+oSoHoaDon+"&ngayhoadon="+oNgayHoaDon+"&sotien="+oSoTien+"&taikhoanno="+oTaiKhoanNo+"&taikhoanco="+oTaiKhoanCo+"&taikhoannh="+oTaiKhoanNH+"&SoUNC="+oSoUNC+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
function LoadLuuThuChiTM()
    {
        var luu=document.getElementById("btnluu");
        luu.style.display='none';
        var sua=document.getElementById("btnSua");
        sua.style.display='';
        var keycode = 9;
        var loaitien = document.getElementById("ddlLoaiTien");//30/06/2011
        var tygia=document.getElementById("txtTyGia");
        var opxid = document.getElementById("txtpxid");
        var ovat = document.getElementById("txtVAT");
        var otienvat = document.getElementById("txtTienVAT");   
        var otaikhoanvat = document.getElementById("txtTaiKhoanVAT");
        var ohoten = document.getElementById("txtHoTen");
        var otenkh = document.getElementById("txtTenKH");
        var odiachi = document.getElementById("txtDiaChi");
        var odonvi = document.getElementById("ddlncc");   
        var okyhieuhd = document.getElementById("txtKyHieuHD");
        var omasothue = document.getElementById("txtMaSoThue");
        if(keycode == 9) // Phim Tab
        {
            
            if (opxid.value == "-1")
            {
                var oSoCt = document.getElementById("txtSoCT"); 
                var oNgayCt = document.getElementById("txtNgayCT"); 
                var oNCC = document.getElementById("ddlncc"); 
                var osohoadon = document.getElementById("txtSoHoaDon");
                var ongayhoadon = document.getElementById("txtngayhoadon");
                var oDienGiai = document.getElementById("txtDienGiai"); 
                var osotien = document.getElementById("txtSoTien"); 
                osotien.value=(osotien.value).replace('.','').replace('.','');
                var otaikhoanno = document.getElementById("txtTaiKhoanNo"); 
                var otaikhoanco = document.getElementById("txtTaiKhoanCo"); 
            }
            else
            {
                var oSoCt = document.getElementById("txtSoCT"); 
                var oNgayCt = document.getElementById("txtNgayCT"); 
                var oNCC = document.getElementById("ddlncc"); 
                var osohoadon = document.getElementById("txtSoHoaDon");
                var ongayhoadon = document.getElementById("txtngayhoadon");
                var oDienGiai = document.getElementById("txtDienGiai"); 
                var osotien = document.getElementById("txtSoTien"); 
                osotien.value=(osotien.value).replace('.','').replace('.','');
                var otaikhoanno = document.getElementById("txtTaiKhoanNo"); 
                var otaikhoanco = document.getElementById("txtTaiKhoanCo"); 
            }            
            if (otaikhoanco.value=="")
            {
                alert("Vui lòng nhập tài khoản có!");
                return;
            }
            if (opxid.value == "-1") // Them moi
            {
                LuuThuChiTM(opxid.value, oSoCt.value, oNgayCt.value, oDienGiai.value, oNCC.value, osohoadon.value, ongayhoadon.value, osotien.value, otaikhoanno.value, otaikhoanco.value, ovat.value, otienvat.value, otaikhoanvat.value, ohoten.value, odonvi.value, otenkh.value, odiachi.value, okyhieuhd.value, omasothue.value, loaitien.value, tygia.value);
            }

            else//Chinh sua, cap nhat
            {
                LuuThuChiTM(opxid.value, oSoCt.value, oNgayCt.value, oDienGiai.value, oNCC.value, osohoadon.value, ongayhoadon.value, osotien.value, otaikhoanno.value, otaikhoanco.value, ovat.value, otienvat.value, otaikhoanvat.value, ohoten.value, odonvi.value, otenkh.value, odiachi.value, okyhieuhd.value, omasothue.value, loaitien.value, tygia.value);
            }
	    }  
	    return;
    }
    
    function LuuThuChiTM(oPxid, oSoCt, oNgayCt, oDienGiai, oNCC, oSoHoaDon, oNgayHoaDon, oSoTien, oTaiKhoanNo, oTaiKhoanCo, oVAT, oTienVAT, oTaiKhoanVAT, oHoTen, oDonVi, oTenKH, oDiaChi, oKyHieuHD, oMaSoThue, oLoaiTien, oTyGia)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var opxid = document.getElementById("txtpxid");
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Số phiếu đã tồn tại!");
                    return;
                }
                else if (value == "1")
                {
                    alert("Lỗi lưu thông tin dữ liệu!");
                    return;
                }
                else //if (value == "2")
                {
                    obj.innerHTML = value;    
                    opxid.value = "1";
//                    alert("Lưu thông tin dữ liệu thành công!");
//                    ResetSession();
                    //document.location.href = "ThuChiHoaDonTM1.aspx";   
                }
            }
        }
        //alert(oNgayCt);
        xmlHttp.open("GET","ajax.aspx?do=LuuThuChiTM&Pxid="+oPxid+"&soct="+oSoCt+"&ngayct="+oNgayCt+"&diengiai="+encodeURIComponent(oDienGiai)+"&nccid="+oNCC+"&sohoadon="+oSoHoaDon+"&ngayhoadon="+oNgayHoaDon+"&sotien="+oSoTien+"&taikhoanno="+oTaiKhoanNo+"&taikhoanco="+oTaiKhoanCo+"&VAT="+oVAT+"&TienVAT="+oTienVAT+"&TaiKhoanVAT="+oTaiKhoanVAT+"&HoTen="+encodeURIComponent(oHoTen)+"&DonVi="+oDonVi+"&TenKH="+encodeURIComponent(oTenKH)+"&DiaChi="+encodeURIComponent(oDiaChi)+"&KyHieuHD="+oKyHieuHD+"&MaSoThue="+oMaSoThue+"&LoaiTien="+oLoaiTien+"&TyGia="+oTyGia+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    
    function XoaThuChiTM(stt, objmactp, objsohoadon, objsotien, objnguoinop)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var opxid = document.getElementById("txtpxid");
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Lỗi xóa dữ liệu!");
                }
                else
                {
                    obj.innerHTML = value;    
                    //alert("Xóa dữ liệu thành công!");   
                    opxid.value = "-1";      
//                    ResetSession();
//                    if (Left(objmactp,2)=="PT"||Left(objmactp,2)=="PC")
//                        document.location.href = "ThuChiHoaDonTM1.aspx";   
//                     else
//                        document.location.href = "ThuChiHoaDonNH.aspx";   
                }
                
            }
        }
        //alert(objmactp);
        xmlHttp.open("GET","ajax.aspx?do=XoaThuChiTM&mactp="+objmactp+"&sohoadon="+objsohoadon+"&sotien="+objsotien+"&nguoinop="+objnguoinop+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    
    function SuaThuChiTM(stt, objmactp)
    {
        var osohoadon = document.getElementById("txtSoHoaDon_" + stt); 
        var ongayhoadon = document.getElementById("txtNgayHoaDon_" + stt);
        var onguoinop = document.getElementById("list_" + stt);
        var otaikhoanno = document.getElementById("txtTaiKhoanNo_" + stt);
        var otaikhoanco = document.getElementById("txtTaiKhoanCo_" + stt);
        var osotien = document.getElementById("txtSoTien_" + stt);
        
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Lỗi cập nhật dữ liệu!");
                }
                else
                {
                    //alert("test");
                    obj.innerHTML = value;    
//                    alert("Cập nhật dữ liệu thành công!");  
//                    ResetSession();
//                    if (Left(objmactp,2)=="PT"||Left(objmactp,2)=="PC")
//                        document.location.href = "ThuChiHoaDonTM1.aspx";   
//                     else
//                        document.location.href = "ThuChiHoaDonNH.aspx";   
                }
                
            }
        }
        //alert(objmactp);
        //alert(osohoadon.value);
        xmlHttp.open("GET","ajax.aspx?do=SuaThuChiTM&sophieu="+objmactp+"&sohoadon="+osohoadon.value+"&ngayhoadon="+ongayhoadon.value+"&nguoinop="+onguoinop.value+"&taikhoanno="+otaikhoanno.value+"&taikhoanco="+otaikhoanco.value+"&sotien="+osotien.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    
    function LoadLuuCanTru()
    {
        var opxid = document.getElementById("txtpxid");         
        var oSoCt = document.getElementById("txtSoCT"); 
        var oNgayCt = document.getElementById("txtNgayCT"); 
        var oNCC = document.getElementById("ddlncc"); 
        var oNCCc = document.getElementById("ddlnccc"); 
        var osohoadon = document.getElementById("txtSoHoaDon");
        var osohoadonc = document.getElementById("txtSoHoaDonC");
        var ongayhoadon = document.getElementById("txtngayhoadon");
        var ongayhoadonc = document.getElementById("Textbox2");
        var oDienGiai = document.getElementById("txtDienGiai"); 
        var osotien = document.getElementById("txtSoTien"); 
        var osotienc = document.getElementById("txtsotienc"); 
        var otaikhoanno = document.getElementById("txtTaiKhoanNo"); 
        var otaikhoanco = document.getElementById("txtTaiKhoanCo"); 
        LuuCanTru(opxid.value, oSoCt.value, oNgayCt.value, oDienGiai.value, oNCC.value, oNCCc.value, osohoadon.value, osohoadonc.value, ongayhoadon.value, ongayhoadonc.value, osotien.value, osotienc.value, otaikhoanno.value, otaikhoanco.value);
        return;
    }
    
    function LuuCanTru(oPxid, oSoCt, oNgayCt, oDienGiai, oNCC, oNCCc, oSoHoaDon, oSoHoaDonc, oNgayHoaDon, oNgayHoaDonc, oSoTien, oSoTienc, oTaiKhoanNo, oTaiKhoanCo)
    {
        var obj = document.getElementById("chitietphieu");
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if (value == "0")
                {
                    alert("Số phiếu đã tồn tại!");
                    return;
                }
                if (value == "1")
                {
                    alert("Lỗi lưu thông tin dữ liệu!");
                    return;
                }
                else//if (value == "2")
                {
                    var opxid = document.getElementById("txtpxid"); 
                    opxid.value = "1";
                    //alert("Lưu thông tin dữ liệu thành công!");
                    ResetSession();
                    obj.innerHTML=value;
                    //document.location.href = "CanTruCongNo.aspx";   
                }
            }
        }
        //alert(oNgayCt);
        xmlHttp.open("GET","ajax.aspx?do=LuuCanTru&Pxid="+oPxid+"&soct="+oSoCt+"&ngayct="+oNgayCt+"&diengiai="+encodeURIComponent(oDienGiai)+"&nccid="+oNCC+"&nccidc="+oNCCc+"&sohoadon="+oSoHoaDon+"&sohoadonc="+oSoHoaDonc+"&ngayhoadon="+oNgayHoaDon+"&ngayhoadonc="+oNgayHoaDonc+"&sotien="+oSoTien+"&sotienc="+oSoTienc+"&taikhoanno="+oTaiKhoanNo+"&taikhoanco="+oTaiKhoanCo+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    
    function LoadLuuCTTH()
    {
        var opxid = document.getElementById("txtpxid");         
        var oSoCt = document.getElementById("txtSoCT"); 
        var oNgayCt = document.getElementById("txtNgayCT"); 
        var oNCC = document.getElementById("ddlncc"); 
        var oNCCc = document.getElementById("ddlnccc"); 
        var osohoadon = document.getElementById("txtSoHoaDon");
        var osohoadonc = document.getElementById("txtSoHoaDonC");
        var ongayhoadon = document.getElementById("txtngayhoadon");
        var ongayhoadonc = document.getElementById("Textbox2");
        var oDienGiai = document.getElementById("txtDienGiai"); 
        var osotien = document.getElementById("txtSoTien"); 
        var osotienc = document.getElementById("txtsotienc"); 
        var otaikhoanno = document.getElementById("txtTaiKhoanNo"); 
        var otaikhoanco = document.getElementById("txtTaiKhoanCo"); 
        LuuChungTuTH(opxid.value, oSoCt.value, oNgayCt.value, oDienGiai.value, oNCC.value, oNCCc.value, osohoadon.value, osohoadonc.value, ongayhoadon.value, ongayhoadonc.value, osotien.value, osotienc.value, otaikhoanno.value, otaikhoanco.value);
        return;
    }
    
    function LuuChungTuTH(oPxid, oSoCt, oNgayCt, oDienGiai, oNCC, oNCCc, oSoHoaDon, oSoHoaDonc, oNgayHoaDon, oNgayHoaDonc, oSoTien, oSoTienc, oTaiKhoanNo, oTaiKhoanCo)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if (value == "0")
                {
                    alert("Số phiếu đã tồn tại!");
                    return;
                }
                if (value == "1")
                {
                    alert("Lỗi lưu thông tin dữ liệu!");
                    return;
                }
                if (value == "2")
                {
                    var opxid = document.getElementById("txtpxid"); 
                    opxid.value = "1";
                    alert("Lưu thông tin dữ liệu thành công!");
                    ResetSession();
                    document.location.href = "ChungTuPhatSinh.aspx";   
                }
            }
        }
        //alert(oNgayCt);
        xmlHttp.open("GET","ajax.aspx?do=LuuChungTuTH&Pxid="+oPxid+"&soct="+oSoCt+"&ngayct="+oNgayCt+"&diengiai="+encodeURIComponent(oDienGiai)+"&nccid="+oNCC+"&nccidc="+oNCCc+"&sohoadon="+oSoHoaDon+"&sohoadonc="+oSoHoaDonc+"&ngayhoadon="+oNgayHoaDon+"&ngayhoadonc="+oNgayHoaDonc+"&sotien="+oSoTien+"&sotienc="+oSoTienc+"&taikhoanno="+oTaiKhoanNo+"&taikhoanco="+oTaiKhoanCo+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    
    function ShowDanhSachTaiKhoan()
	{
	    var otaikhoan = document.getElementById("tiptk");
	    createTip(otaikhoan,"tiptaikhoan","danhsachtk","Danh sách tài khoản","ajaxtkexists"," đang load danh sách tài khoản...","Lỗi trong quá trình load danh sách tài khoản","ajax.aspx?do=danhsachtaikhoan", "750", "350");   
	}
	
	function ShowDanhSachTaiKhoan1()
	{
	    var otaikhoan = document.getElementById("tiptk");
	    createTip(otaikhoan,"tiptaikhoan","danhsachtk","Danh sách tài khoản","ajaxtkexists"," đang load danh sách tài khoản...","Lỗi trong quá trình load danh sách tài khoản","ajax.aspx?do=danhsachtaikhoan1", "750", "350");   
	}
	
    function ChonTaiKhoan(taikhoan)
    {
        var otaikhoan = document.getElementById("txtTaiKhoanNo");
        otaikhoan.value=taikhoan;
        hideTip("tiptaikhoan");
    }
    function ChonTaiKhoan1(taikhoan)
    {
        var otaikhoan = document.getElementById("txtTaiKhoanCo");
        otaikhoan.value=taikhoan;
        hideTip("tiptaikhoan");
    }
    function TimKiem()
    {
        var otk = document.getElementById("tiptk");
        var otaikhoan = document.getElementById("taikhoan");
        var otentaikhoan = document.getElementById("tentaikhoan");
        createTip(otk,"tiptaikhoan","danhsachtk","Danh sách tài khoản","ajaxtkexists"," đang load danh sách tài khoản...","Lỗi trong quá trình load danh sách tài khoản","ajax.aspx?do=timkiem&taikhoan="+otaikhoan.value+"&tentaikhoan="+otentaikhoan.value, "750", "350");   
    }
    function TimKiem1()
    {
        var otk = document.getElementById("tiptk");
        var otaikhoan = document.getElementById("taikhoan");
        var otentaikhoan = document.getElementById("tentaikhoan");
        createTip(otk,"tiptaikhoan","danhsachtk","Danh sách tài khoản","ajaxtkexists"," đang load danh sách tài khoản...","Lỗi trong quá trình load danh sách tài khoản","ajax.aspx?do=timkiem1&taikhoan="+otaikhoan.value+"&tentaikhoan="+otentaikhoan.value, "750", "350");   
    }
    
    function DoActionPhieuNhap()
    {
        //alert("test");
        var keycode = 9;
        var opxid = document.getElementById("txtpxid");         
        if(keycode == 13)
        {
         
        }
        if(keycode == 9) // Phim Tab
        {
            
            var ochietkhau = document.getElementById("txtchietkhau");
            var ovat = document.getElementById("txtvat");
            var otkno = document.getElementById("txttkno");
            var otkco = document.getElementById("txttkco");
            var otkvat = document.getElementById("txttkvat");
//            var oloaitien = document.getElementById("ddlLoaiTien");
//            var otygia = document.getElementById("txtTyGia");
//            var othuenk = document.getElementById("txtthuenk");
            
            var osohoadon = document.getElementById("txtsohd");
            var okyhieuhd = document.getElementById("txtkyhieuhd");
            var optn=document.getElementById("ddl_ptn");
            if (opxid.value == "-1")
            {
                var oSoCt = document.getElementById("txtSoCT"); 
                var oNgayCt = document.getElementById("txtNgayCT"); 
                var oKho = document.getElementById("ddlKho"); 
                var oNCC = document.getElementById("ddlncc"); 
                var ongayhoadon = document.getElementById("txtngayhoadon");
                var otennguoigiao = document.getElementById("txttennguoigiao");
                var oDienGiai = document.getElementById("txtDienGiai"); 
                var onhapcho = document.getElementById("ddlKho");
                var omavt = document.getElementById("ddlVatTu"); 
                var osoluong = document.getElementById("txtSoLuong"); 
                var odongia = document.getElementById("txtDonGia");
                var olosx = document.getElementById("txtlosx");
                var ongayhethan = document.getElementById("txtngayhethan");
            }
            else
            {
                //var odongiagoc = document.getElementById("txtdongiagoc"); 
                var omavt = document.getElementById("ddlVatTu"); 
                var osoluong = document.getElementById("txtSoLuong"); 
                var odongia = document.getElementById("txtDonGia");
                var olosx = document.getElementById("txtlosx");
                var ongayhethan = document.getElementById("txtngayhethan");
            }            
            
            if (opxid.value == "-1") // da them moi thanh cong 1 phieu nhap
            {
                if ( CheckThongTinPhieuNhap(oSoCt, oNgayCt, oKho, oNCC, ongayhoadon, otennguoigiao, oDienGiai, otkno, otkco, otkvat) && CheckThongTinCTPhieuNhap(omavt,osoluong,odongia, olosx, ongayhethan))
                {
                    LuuPhieuNhap(oSoCt.value, oNgayCt.value, oKho.value, oDienGiai.value, oNCC.value, okyhieuhd.value, osohoadon.value, ongayhoadon.value, otennguoigiao.value, onhapcho.value, omavt.value,osoluong.value,odongia.value, ochietkhau.value, ovat.value, olosx.value, ongayhethan.value, otkno.value, otkco.value, otkvat.value, optn.value);//, oloaitien.value, otygia.value, othuenk.value
                }
            }
            else
            {
               if( CheckThongTinCTPhieuNhap(omavt,osoluong,odongia, olosx, ongayhethan))
               {
                     LuuChiTietPhieuNhap(omavt.value,osoluong.value,odongia.value,ochietkhau.value,ovat.value,olosx.value, ongayhethan.value);
                    
               }
            }
	    }  
	    return;
    }
    
        
    function CheckThongTinPhieuNhap(oSoCt, oNgayCt, oKho, oNCC, oNgayHoaDon, oTenNguoiGiao, oDienGiai, otkno, otkco, otkvat)
    {
        if (oSoCt.value == "")
        {
            alert("Bạn chưa nhập số chứng từ. Vui lòng kiểm tra lại.");
            oSoCt.focus();
            return false ;
        }
        if (oNgayCt.value == "")
        {
            alert("Bạn chưa nhập ngày chứng từ. Vui lòng kiểm tra lại.");
            oNgayCt.focus();
            return false;
        }
        
        if (oKho.value == "" || oKho.value == "0")
        {
            alert("Bạn chưa chọn kho nhập. Vui lòng kiểm tra lại.");
            oKho.focus();
            return false;
        }       
        
        if (oNCC.value == "" || oNCC.value == "0")
        {
            alert("Bạn chưa chọn nhà cung cấp. Vui lòng kiểm tra lại.");
            oNCC.focus();
            return false;
        } 
        if (oNCC.value == "" )
        {
            alert("Bạn chưa chọn nhà cung cấp. Vui lòng kiểm tra lại.");
            oNCC.focus();
            return false;
        } 
        if (otkno.value == "" )
        {
            alert("Bạn chưa chọn tài khoản nợ!");
            otkno.focus();
            return false;
        } 
        if (otkco.value == "" )
        {
            alert("Bạn chưa chọn tài khoản có!");
            otkco.focus();
            return false;
        } 
        if (otkvat.value == "" )
        {
            alert("Bạn chưa chọn tài khoản vat!");
            otkvat.focus();
            return false;
        } 
        return true;
    }
    
    function CheckThongTinCTPhieuNhap(omavt,osoluong,odongia, olosx, ongayhethan)
    {
        if (omavt.value == "0")
        {
            alert("Bạn chưa nhập tên thuốc. Vui lòng kiểm tra lại.");
            omavt.focus();
            return;
        }
        
        if (osoluong.value == "0")
        {
            alert("Bạn chưa nhập số lượng nhập. Vui lòng kiểm tra lại.");
            osoluong.focus();
            return;
        }
        
        if (odongia.value == "0")
        {
            alert("Bạn chưa nhập đơn giá nhập. Vui lòng kiểm tra lại.");
            odongia.focus();
            return;
        }
        if (olosx.value == "")
        {
            alert("Bạn chưa nhập lô sản xuất thuốc. Vui lòng kiểm tra lại.");
            olosx.focus();
            return;
        }
        if (ongayhethan.value == "")
        {
            alert("Bạn chưa nhập ngày hết hạn sử dụng thuốc. Vui lòng kiểm tra lại.");
            ongayhethan.focus();
            return;
        }
        return true;
    }
    function LuuPhieuNhap(oSoCt, oNgayCt, oKho, oDienGiai, oNCC, oKyHieuHoaDon, oSoHoaDon, oNgayHoaDon, oTenNguoiGiao, oNhapCho, omavt, osoluong, odongia, ochietkhau, ovat, olosx, ongayhethan, otkno, otkco, otkvat, optn)//, oloaitien, otygia, othuenk
    {
        //alert(oSoCt+ " " + oNgayCt+ " " + oKho+ " " + oDienGiai+ " " + oNCC+ " " + oNgayHoaDon+ " " + oTenNguoiGiao+ " " + omavt+ " " + osoluong+ " " + odongia+ " " + olosx+ " " + ongayhethan);
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if (value == "0")
                {
                    alert("Số phiếu nhập đã tồn tại. Vui lòng chọn số phiếu nhập khác.")
                    return;
                }
                if (value == "1")
                {
                    alert("Có lỗi trong quá trình lưu dữ liệu . Vui lòng kiểm tra lại thông tin nhập vào.")
                    return;
                }
                if (value == "2")
                {
                    var opxid = document.getElementById("txtpxid"); 
                    opxid.value = "1";
                    var omavt = document.getElementById("txtSearTP"); 
                    var osoluong = document.getElementById("txtSoLuong"); 
                    var odongia = document.getElementById("txtDonGia");
                    osoluong.value = "0";
                    odongia.value = "0";
                    omavt.value = "";
                    omavt.focus();
                    LoadChiTietPhieuNhap();                    
                }
            }
        }
        //alert("test");
        xmlHttp.open("GET","ajax.aspx?do=luuphieunhap&soct="+oSoCt+"&ngayct="+oNgayCt+"&kho="+oKho+"&diengiai="+encodeURIComponent(oDienGiai)+"&nccid="+oNCC+"&ngayhoadon="+oNgayHoaDon+"&tennguoigiao="+encodeURIComponent(oTenNguoiGiao)+"&nhapcho="+oNhapCho+"&mavt="+omavt+"&soluong="+osoluong+"&dongia="+odongia+"&losx="+olosx+"&ngayhethan="+ongayhethan+"&chietkhau="+ochietkhau+"&vat="+ovat+"&tkno="+otkno+"&tkco="+otkco+"&tkvat="+otkvat+"&kyhieuhd="+oKyHieuHoaDon+"&sohoadon="+oSoHoaDon+"&ptn="+optn+"&times="+Math.random(),true);//&loaitien="+oloaitien+"&tygia="+otygia+"&thuenk="+othuenk+"
        //xmlHttp.open("GET","ajax.aspx?do=luuphieunhap&soct="+oSoCt+"&ngayct="+oNgayCt+"&kho="+oKho+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    function LuuChiTietPhieuNhap(omavt,osoluong,odongia,ochietkhau,ovat,olosx,ongayhethan)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                                
                if (value == "1")
                {
                    alert("Có lỗi trong quá trình lưu dữ liệu . Vui lòng kiểm tra lại thông tin nhập vào.")
                    return;
                }
                if (value == "2")
                {
                    var opxid = document.getElementById("txtpxid");                     
                    opxid.value = "1";
                    var omavt = document.getElementById("txtSearTP"); 
                    var osoluong = document.getElementById("txtSoLuong"); 
                    var odongia = document.getElementById("txtDonGia");
                    osoluong.value = "0";
                    odongia.value = "0";
                    omavt.value = "";
                    omavt.focus();
                    LoadChiTietPhieuNhap();                    
                }
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=luuctphieunhap&mavt="+omavt+"&soluong="+osoluong+"&dongia="+odongia+"&chietkhau="+ochietkhau+"&vat="+ovat+"&losx="+olosx+"&ngayhethan="+ongayhethan+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    function LoadChiTietPhieuNhap()
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Có lỗi trong quá trình truyền dữ liệu.");
                }
                else
                {
                    obj.innerHTML = value;                
                }
                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loaddanhsachchitietphieunhap&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    function suaitemchitiet(objmactp,stt)
    {
        var omavt = document.getElementById("ddlVatTu_" + stt);
        var odongia = document.getElementById("txtdongia_" + stt); 
        var osoluong = document.getElementById("txtsoluong_" + stt);
        var omucck=document.getElementById("txtmucck_"+ stt);
        var ovat=document.getElementById("txtvat_"+ stt);
        //var olosx = document.getElementById("txtlosx_" + stt);
        //var ongayhethan = document.getElementById("txtngayhethan_" + stt);
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Cập nhật không thành công. Vui lòng kiểm tra lại.");
                }
                else
                {
                    obj.innerHTML = value;    
                    //alert("Cập nhật thành công.");            
                }
                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loadedititemphieunhap&mactp="+objmactp+"&mavt="+omavt.value+"&soluong="+osoluong.value+"&dongia="+odongia.value+"&mucck="+omucck.value+"&vat="+ovat.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    
    function xoaitemchitiet(objmactp)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Xóa không thành công. Vui lòng kiểm tra lại.");
                }
                else
                {
                    obj.innerHTML = value;    
                    //alert("Đã xóa dữ liệu thành công.");            
                }
                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loaddeleteitemphieunhap&mactp="+objmactp+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }