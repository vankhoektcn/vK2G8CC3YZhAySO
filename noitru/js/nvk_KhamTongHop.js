
//]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]ư[[[[[[[[[[[[[[[[[[[[[[[[[[[[ơ
//-=========-=-=-=-=-=-=-=-= CHỈ ĐỊNH DỊCH VỤ nvk dichvu

function TimBenhVienTheoMa()
 {     
	    $("#txtMaBenhVien").unautocomplete().autocomplete("../ajax/nvk_commonFuntion_ajax.aspx?do=TimBenhVienTheoMa",
        {formatItem: function(data) {
                return data[0];
            },width:700,scroll: true}
        )        
        .result(function(event, data){
               document.getElementById("txtMaBenhVien").value =data[1] ;
               document.getElementById("txtBenhVien").value =data[2];
               document.getElementById("hdIdBenhVien").value = data[3];
        });
 }
 function TimBenhVienTheoTen()
 {     
	    $("#txtBenhVien").unautocomplete().autocomplete("../ajax/nvk_commonFuntion_ajax.aspx?do=TimBenhVienTheoTen",
        {formatItem: function(data) {
                return data[0];
            },width:700,scroll: true}
        )        
        .result(function(event, data){
               document.getElementById("txtMaBenhVien").value =data[1] ;
               document.getElementById("txtBenhVien").value =data[2];
               document.getElementById("hdIdBenhVien").value = data[3];
        });
 }
 
 
function TimChanDoanTheoMa()
 {     
	    $("#txtMaChanDoan").unautocomplete().autocomplete("../ajax/nvk_commonFuntion_ajax.aspx?do=TimChanDoanTheoMa",
        {formatItem: function(data) {
                return data[0];
            },width:700,scroll: true}
        )        
        .result(function(event, data){
               document.getElementById("txtMaChanDoan").value =data[1] ;
               document.getElementById("txtChanDoan").value =data[2];
               document.getElementById("hdIdChanDoan").value = data[3];
        });
 }
 function TimChanDoanTheoTen()
 {     
	    $("#txtChanDoan").unautocomplete().autocomplete("../ajax/nvk_commonFuntion_ajax.aspx?do=TimChanDoanTheoTen",
        {formatItem: function(data) {
                return data[0];
            },width:700,scroll: true}
        )        
        .result(function(event, data){
               document.getElementById("txtMaChanDoan").value =data[1] ;
               document.getElementById("txtChanDoan").value =data[2];
               document.getElementById("hdIdChanDoan").value = data[3];
        });
 }
 function nvkEnableNgayTaiKham(obj)
{
    if(obj.checked==true)
    {
        $("#divNgayGioTK").css("display","block");
        $("#txtNgayTK").focus();       
    }
    else
    {
        $("#divNgayGioTK").css("display","none"); 
//        $("#txtNgayTK").val("");       
//        $("#txtNgayTK").val("");       
    }
}
 
 function btnLuuHDT_click(idbenhnhan,idctdkk,idkhoa)
 {
    // khai báo tham số 
    $("#spDangLuu").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang lưu dữ liệu.....<img id='imgLoading' src='../images/processing.gif' /></span>");
    $("#btnLuuHDT").css("display","none");
    var IdXK=document.getElementById("hdIdXuatKhoa").value; 
    var IdKbXK=document.getElementById("hdKbXuatKhoa").value; 
    
    var HuongDieuTri=document.getElementById("slHuongDieuTri").value;
    if(HuongDieuTri=="0")
    {
        alert("Chưa chọn hướng điều trị !");
        $("#spDangLuu").html('');
        $("#btnLuuHDT").css("display","");
        return;
    }
    
     var IsCheckTK="0";
    var NgayTK="0";
    var GioTK="0";
    var cbTK= document.getElementById("cbTaiKham");
    if(cbTK.checked==true)
    {
        var NgayTaiKham=document.getElementById("txtNgayTK");
        if(NgayTaiKham.value=="" || nvk_isDate(NgayTaiKham.value)== false)
        {
            alert("Vui lòng chọn ngày tái khám hợp lệ !");
            NgayTaiKham.focus();
            $("#spDangLuu").html('');
            $("#btnLuuHDT").css("display","");
            return;
        }
        IsCheckTK="1";NgayTK= $("#txtNgayTK").val();GioTK=$("#txtGioTK").val();
    }
    var Qr_TaiKham="&IsTK="+IsCheckTK+"&NtK="+NgayTK+"&GtK="+GioTK;
    var idBacSiXK=$("#idbacsi").val();
   
    var NgayXK=document.getElementById("txtNgayXK").value;
    var GioXK=document.getElementById("txtGioXK").value;
    var IDKhoaSelect=document.getElementById("slKhoaChuyenToi").value; 
    var IDPhongSelect=document.getElementById("slPhongChuyenToi").value; 
    var IDbenhVien=document.getElementById("hdIdBenhVien").value; 
    var cbIsDieuDuong =document.getElementById("cbCoDD").checked;
    var cbIsBacSi =document.getElementById("cbCoBS").checked;
    var IDchanDoan=document.getElementById("hdIdChanDoan").value; 
    var MoTaCD_edit=document.getElementById("txtChanDoan").value;
    var txtPPDT=document.getElementById("txtPPDT").value; 
    var txtLDToa=document.getElementById("txtLDToa").value; 
    var txtLDTT=document.getElementById("txtLDTT").value; 
    var IDTinhTrangSelect=document.getElementById("slTinhTrangXK").value; 
    var txtLyDoXK=document.getElementById("txtLyDoXK").value; 
    var ListQyeRy="&idXuatK="+IdXK+"&idKBXK="+IdKbXK+"";
    ListQyeRy+="&HuongDT="+HuongDieuTri+"&NgayXK="+NgayXK+"&GioXK="+GioXK+"&IdKhoaToi="+IDKhoaSelect+"&IdPhongToi="+IDPhongSelect+"&idBVToi="+IDbenhVien+"&IsDD="+cbIsDieuDuong+"&IsBS="+cbIsBacSi;
    ListQyeRy+="&idCD="+IDchanDoan+"&PPDTri="+encodeURIComponent(txtPPDT)+"&txtLDToa="+encodeURIComponent(txtLDToa)+"&LDTThuoc="+encodeURIComponent(txtLDTT)+"&idTT="+IDTinhTrangSelect+"&LyDoXK="+encodeURIComponent(txtLyDoXK)+"";
    ListQyeRy+="&MoTaCD_edit="+encodeURIComponent(MoTaCD_edit);
    ListQyeRy+="&idBSXK="+idBacSiXK;
   
    //alert("LisQyeRy="+ListQyeRy);
    //alert("Qr_TaiKham="+Qr_TaiKham);
    //return;
    //$("#spDangLuu").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang lưu dữ liệu.....<img id='imgLoading' src='../images/processing.gif' /></span>");        
        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=LuuHuongDieuTri_XuatKhoa&idbn="+idbenhnhan+"&idctdkk="+idctdkk+"&idKNT="+idkhoa+ListQyeRy+Qr_TaiKham;
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            if(value!="")
                            {
                                var arr = value.split("@@");
                                document.getElementById("hdIdXuatKhoa").value=arr[0];
                                if(HuongDieuTri=="4") //chuyển viện
                                {
                                    nvk_luutableChanDoanPhoiHop_XK(arr[0],"1");// from nvk_DichVu.js
                                    document.getElementById("btnInPhieuCV").style.display='block';
                                    document.getElementById("btnInPhieuRV").style.display='none';                                    
                                }
                                else if(HuongDieuTri=="17") //xuất viện
                                {
                                    nvk_luutableChanDoanPhoiHop_XK(arr[0],"0",IdKbXK,idbenhnhan);// from nvk_DichVu.js
                                    setTimeout(function () {
                                        //nvk_LuuToaXuatVien(IdKbXK,idbenhnhan); // lưu table toa thuốc xuất viện 
                                        document.getElementById("btnInPhieuRV").style.display='block';
                                        //alert("btnInPhieuRV="+document.getElementById("btnInPhieuRV"));
                                        document.getElementById("btnInToaRaVien").style.display='block';
                                    },2000);
                                    
                                }
                                else if(HuongDieuTri=="8") //Chuyển khoa
                                {
                                    nvk_luutableChanDoanPhoiHop_XK(arr[0],"1");// from nvk_DichVu.js
                                    setTimeout(function () {
                                        TimKiemBenhNhan();
                                    },1000);
                                }
                                else
                                {
                                    if(idkhoa="15")
                                        nvk_luutableChanDoanPhoiHop_XK(arr[0],"0");
                                    alertXuatKhoaThanhCong();
                                }
                                document.getElementById("spSoVaoVien").innerHTML=arr[1];
                                //alert("Lưu thành công !");
                            }
                            else
                            {
                                $.mkv.myerror("KHÔNG THÀNH CÔNG !");
                                $("#spDangLuu").html("");
                                $("#btnLuuHDT").css("display","");
                            }
                        }
                }); 
 }
function alertXuatKhoaThanhCong()
{
    $.mkv.myalert("Đã lưu thành công.",2000,"success");
    $("#spDangLuu").html("");
    $("#btnLuuHDT").css("display","");
}
function nvk_LuuToaXuatVien(idkhambenhXuatVien,idbenhnhan)
{
    $.LuuTable({
                 ajax:"../ajax/nvk_khamTongHop_ajax.aspx?do=luuTablechitietbenhnhantoathuoc_XuatVien&idkhambenh=" + idkhambenhXuatVien+"&idbenhnhan="+idbenhnhan,
                 tablename:"gridTable"
                },null,function () 
                    {
                        alertXuatKhoaThanhCong();
                    }
                 );//end LuuTable
}

function btnTaoSVV_click(idbenhnhan,idchitietdangkykham,idkhoa)
{
    document.getElementById("btnTaoSVV").style.display='none';
    var IsBANoiTru="";
    if($("#rd_NoiTru").is(':checked')==true)
        IsBANoiTru="1";
    else if($("#rd_NgoaiTru").is(':checked')==true)
        IsBANoiTru="0";
    if(IsBANoiTru =="")
        {
            alert("Chưa chọn loại bệnh án !");return;
        }
    $("#sp_KetQuaSoVaoVien").html("<span style='height: auto; width: 100%;text-align:center; color: white; font-weight: bold;font-style:italic' class='Tieude'> Đang tạo số vào viện .....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_commonFuntion_ajax.aspx?do=TaoSVV_click&idctdkk="+idchitietdangkykham+"&idkhoa="+idkhoa+"&IsBANoiTru="+IsBANoiTru+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            $("#sp_KetQuaSoVaoVien").html(value);
                            if(value != "")
                            {
                                document.getElementById("btnTaoSVV").style.display='none';
                            }
                            else
                            {
                                document.getElementById("btnTaoSVV").style.display='block';
                                alert("Lỗi tạo số vào viện !");
                            }
                        }
                });   
}

function btnTHChanDoan_click(idbenhnhan,idchitietdangkykham,idkhoa)
{
    $("#spTableCDPH").html("<span style='height: auto; width: 100%;text-align:center; color: white; font-weight: bold;font-style:italic' class='Tieude'> Đang load tổng hợp chẩn đoán .....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=THChanDoan_click&idctdkk="+idchitietdangkykham+"&idkhoa="+idkhoa+"&idbenhnhan="+idbenhnhan+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            if(value != "")
                            {
                                $("#spTableCDPH").html(value);
                            }
                            else
                            {
                                alert("Lỗi load tổng hợp chẩn đoán !");
                            }
                        }
                });   
}

// tính lại tiền by idchitietdangkykham
function nvk_TinhLaiTienBy_idctdkk(idctdkk)
{
    var spDangLuu= document.getElementById("spDangLuu");
    if(spDangLuu != null)
        spDangLuu.innerHTML= "<span style='height: auto; width: 100%;text-align:center; color: white; font-weight: bold;font-style:italic' class='Tieude'> Đang kiểm tra lại.....<img id='imgLoading' src='../images/processing.gif' /></span>";
    var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=nvk_TinhLaiTienBy_idctdkk&idctdkk="+idctdkk+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            if(spDangLuu != null)
                                spDangLuu.innerHTML = "";
                        }
                });
}
// End tính lại tiền by idchitietdangkykham