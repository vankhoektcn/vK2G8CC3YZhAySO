// JScript File
function CloseDivGiuong()
	{
            document.getElementById('divChiTietGiuongNgay').style.display='none';
	}	
function SuaGiuong(control,IdKhoa,idnoitru,idchitietdkkSG)
    {
	    var td = document.getElementById("tdPopupTG");
	    var loaiBN="2";
	    if(document.getElementById("hdLoaiBN") != null)
	    {
	        loaiBN=document.getElementById("hdLoaiBN").value;
	    }
            createTipTU(td,"tipbenhnhan","Tamung","Sửa thông tin giường bệnh","ajaxbenhnhanexists"," đang load ...","Lỗi trong quá trình thêm giường !","../ajax/nvk_khamTongHop_ajax.aspx?do=SuaGiuongPOPUP&idchitietdkkSG="+idchitietdkkSG+"&idkhoaSG="+IdKhoa+"&idnoitru="+idnoitru+"&loaiBN="+loaiBN+"", "820", "180","200","200"); 
	}
function ThemGiuong(control,idchitietdkk,IdKhoa)
    {
	    var td = document.getElementById("tdPopupTG");
	    var loaiBN="2";
	    if(document.getElementById("hdLoaiBN") != null)
	    {
	        loaiBN=document.getElementById("hdLoaiBN").value;
	    }
            createTipTU(td,"tipbenhnhan","Tamung","Thêm giường bệnh","ajaxbenhnhanexists"," đang load ...","Lỗi trong quá trình thêm giường !","../ajax/nvk_khamTongHop_ajax.aspx?do=ThemGiuongPOPUP&idkhoaTG="+IdKhoa+"&idchitietdkkTG="+idchitietdkk+"&loaiBN="+loaiBN+"", "820", "180","200","200"); 
	}
function idGiuongsearch(obj)
         {
            var idbenhnhan= document.getElementById("hdidbenhnhan");
            var loaiBN="2";
	            if(document.getElementById("hdLoaiBN") != null)
	            {
	                loaiBN=document.getElementById("hdLoaiBN").value;
	            }
            if(loaiBN=="0" || loaiBN=="")
                loaiBN="2";
            //alert("idbenhnhan="+idbenhnhan.value);return;
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=idGiuongsearch&loaiBN="+loaiBN+"&idkhoa="+$("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#idkhoa").val()+"",{
             minChars:0,
             width:550,
             scroll:true,
             addRow:false,
             header:"Danh sách giường",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                $(obj).val(data[4]);
                $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val(data[2]);
                var thanhtien= data[2] * $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#songay").val();
                var tiencu= $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val();
                tiencu=tiencu.toString().replace(/\$|\,/g,'')
                var TongTien=document.getElementById("txtTongtien").value.toString().replace(/\$|\,/g,'');
                TongTien=TongTien-tiencu+thanhtien;
                document.getElementById("txtTongtien").value=TongTien;
                $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(thanhtien);
                 if($(obj).parents("#gridTableGiuong").attr("id") != null){
                     $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 }
                 
                 setTimeout(function () {
                     obj.focus();
                 },100);
                 
             });
             
         }
function idGiuongsearch_2509(obj)
         {
            var IdKhoa_G= $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#idkhoa").val();
            if(IdKhoa_G == null || IdKhoa_G=="" || IdKhoa_G=="0")
                {
                    alert("Chưa chọn khoa !");
                     $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idkhoa").focus();
                     return;
                }
            var idbenhnhan= document.getElementById("hdidbenhnhan");
            var loaiBN="2";
	            if(document.getElementById("hdLoaiBN") != null)
	            {
	                loaiBN=document.getElementById("hdLoaiBN").value;
	            }
            if(loaiBN=="0" || loaiBN=="")
                loaiBN="2";
            //alert("idbenhnhan="+idbenhnhan.value);return;
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=idGiuongsearch&loaiBN="+loaiBN+"&IdKhoa_G="+IdKhoa_G+"&idkhoa="+$("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#idkhoa").val()+"",{
             minChars:0,
             width:550,
             scroll:true,
             addRow:true,
             header:"<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
       + "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
       + "<div style=\"width:30%;height:30px;color:#000;font-weight:bold;float:left\" >Giường</div>"
       + "<div style=\"width:30%;height:30px;color:#000;font-weight:bold;float:left\" >Phòng</div>"
       + "<div style=\"width:15%;height:30px;color:#000;font-weight:bold;float:left\" >Giá DV</div>"
       + "<div style=\"width:15%;height:30px;color:#000;font-weight:bold;float:left\" >Giá BH</div>"
       + "</div>",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                $(obj).val(data[4]);
                 if($(obj).parents("#gridTableGiuong").attr("id") != null){
                     $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                     $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#nvk_giadichvu").val(data[5]);
                     $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#nvk_giabaohiem").val(data[6]);
                     //$("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#songay").focus();// không chạy
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
                 
             });
             
         }
function IdKhoaSearch_2509(obj)
         {
                $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=IdKhoaSearch_2509",{
                 minChars:0,
                 width:350,
                 addRow:false,
                 scroll:true,
                 header:"Khoa",
                 formatItem:function (data) {
                      return data[0];
                 }}).result(function(event,data){
                     $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                     setTimeout(function () {
                         //obj.focus();
                     $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#tungay").focus();
                     },100);
                 });
         }
function IdKhoaSearch_2509_sss(obj)
         {
            var idbenhnhan= document.getElementById("hdidbenhnhan");
            var loaiBN="2";
	            if(document.getElementById("hdLoaiBN") != null)
	            {
	                loaiBN=document.getElementById("hdLoaiBN").value;
	            }
            if(loaiBN=="0" || loaiBN=="")
                loaiBN="2";
            //alert("idbenhnhan="+idbenhnhan.value);return;
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=IdKhoaSearch_2509&loaiBN="+loaiBN+"&idkhoa="+$("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#idkhoa").val()+"",{
             minChars:0,
             width:550,
             scroll:true,
             addRow:false,
             header:"<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;height:30px;width:400px;padding-right:25px\">"
       + "<div style=\"width:30%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
       + "<div style=\"width:70%;height:30px;color:#000;font-weight:bold;float:left\" >Tên Khoa</div>"
       + "</div>",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                $(obj).val(data[2]);
                 if($(obj).parents("#gridTableGiuong").attr("id") != null){
                     $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
                 
             });
             
         }
function thanhtienTableGiuong(obj)
      {
        var dongia= $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val();
        var songay= $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#songay").val();
        dongia = dongia.toString().replace(/\$|\,/g,'');
        songay = songay.toString().replace(/\$|\,/g,'');
        var thanhtien=dongia*songay ;
        
        var tiencu=$("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val();
        tiencu=tiencu.toString().replace(/\$|\,/g,'');
        var TongTien=document.getElementById("txtTongtien").value.toString().replace(/\$|\,/g,'');
        document.getElementById("txtTongtien").value= TongTien- tiencu + thanhtien;    
        
        $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(thanhtien);
        //alert($("gridTablecls").find("tr").length);
        var Sodong = document.getElementById("gridTableGiuong").rows.length;
//        for(var i=3;i<Sodong;i++)
//        {
//            var tieni=document.getElementById("idtien_"+i);            
//        }
      }
function luuNoiDungGiuong(idbenhnhan,IdCTDKK,idkhoa)
      {
        $.ajax({
                            type:"GET",
                            dataType:"text",
                            cache:false,
                            async:false,
                            //url:"../ajax/khambenh_ajax3.aspx?do=BeforeluuTableGiuongNoiTru&idkhoa="+$.mkv.queryString("IdKhoa"),
                            success:function (value) {
                                if(value !="0")
                                 { //$.mkv.queryString("idkhoachinh",value); 
                                 }
                                $.LuuTable({
                     ajax:"../ajax/nvk_khamTongHop_ajax.aspx?do=luuTableGiuongNoiTru&idctdkk="+IdCTDKK+"&idkhoa_noitru="+idkhoa+"&idbenhnhan="+idbenhnhan+"",
                        tablename:"gridTableGiuong"
             },null,function () {
                                //sau khi lưu table    $.mkv.queryString("LuuMoiKhamBenh","0");
                                nvk_TinhLaiTienBy_idctdkk(IdCTDKK);
                                alert("Đã lưu !");
                                try{
                                loadInfoTienGiuong();
                                }catch(Ex){
                                    try{
                                    DongTienGiuong_Click($.mkv.queryString('idctdkk'))
                                    }catch(Ex){
                                    loadChiTietTinhGiuongBenhNhan(idbenhnhan,IdCTDKK,idkhoa,0);
                                    }
                                }
                                } );//end LuuTable
             }
                           }); 
      }
function luuNoiDungGiuong_2509(idbenhnhan,IdCTDKK,idkhoa)
      {
             $.LuuTable({
                     ajax:"../ajax/nvk_khamTongHop_ajax.aspx?do=luuTableGiuongNoiTru&idctdkk="+$.mkv.queryString('idctdkk')+"&idkhoa_noitru="+$.mkv.queryString('IdKhoa')+"&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"",
                        tablename:"gridTableGiuong"
             },null,function () {
                                //sau khi lưu table    $.mkv.queryString("LuuMoiKhamBenh","0");
                                nvk_TinhLaiTienBy_idctdkk($.mkv.queryString('idctdkk'));
                                alert("Đã lưu !");
                                try{
                                loadInfoTienGiuong();
                                }catch(Ex){
                                    try{
                                    DongTienGiuong_Click($.mkv.queryString('idctdkk'))
                                    }catch(Ex){
                                    loadChiTietTinhGiuongBenhNhan(idbenhnhan,IdCTDKK,idkhoa,0);
                                    }
                                }
                                } );//end LuuTable
      }
// Chọn giường trong ngày
	function Ngay_click(obj,idbenhnhan,idctdkk,idkhoa)
	{
	    //var idctdkk=$.mkv.queryString("idctdkk");
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
	            document.getElementById('divChiTietGiuongNgay').innerHTML=value;
	            document.getElementById('divChiTietGiuongNgay').style.display='';
	            document.getElementById('btndongCTG').focus();
	        }
        }
        xmlHttp.open("GET","../ajax/khambenh_ajax3.aspx?do=getPhongBNMotNgay&idbenhnhan="+idbenhnhan+"&idctdkk="+idctdkk+"&idkhoa="+idkhoa+"&ngay="+obj.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	function LuuChonGiuong(idbenhnhan,idchitietdangkykham,idkhoa,ngay,sogiuong)
	{
	    //alert("idchitietdangkykham="+idchitietdangkykham+";ngày:"+ngay+"; số giường:"+sogiuong);
	    var radio;var valid=false;
	    for(var i=0;i<sogiuong;i++)
	    {
	        radio=document.getElementById("rdGiuong_"+i);
	        if(radio.checked==true)
	            {//alert(radio.value);
	             valid=true; break;}
	    }
	    if(valid==false)
	    {
	        alert("Chưa check giường !");return;
	    }
	    //alert(radio.value);
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if(value=="0")//lỗi
                    alert("Lỗi");
                else
                { 
                    alert("Đã lưu!");
                    //document.getElementById('tableAjax_EditTienGiuong').innerHTML=value;
                    loadChiTietTinhGiuongBenhNhan(idbenhnhan,idchitietdangkykham,idkhoa,0);
                }
	            //document.getElementById('divGiuong').style.display='';
	        }
        }
        xmlHttp.open("GET","../ajax/khambenh_ajax3.aspx?do=saveChonGiuongNgay&idctdkk="+idchitietdangkykham+"&ngay="+ngay+"&idnoitru="+radio.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	// End Chọn giường trong ngày
function LoadGiuongTheoPhong(objSelect)
{
    var loaiBN="2";
	    if(document.getElementById("hdLoaiBN") != null)
	    {
	        loaiBN=document.getElementById("hdLoaiBN").value;
	    }
    var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=SearchGiuongTheoPhong&idphongLoadG="+objSelect.value+"&loaiBN="+loaiBN+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            var arrValueG=value.split('~~');
                            document.getElementById('spSlGiuongTG').innerHTML=arrValueG[0];
                            document.getElementById('txtDonGiaGiuongTG').value=arrValueG[1];
                        }
                });
}
function LoadGiaTheoGiuong(objSelect)
{
    var loaiBN="2";
	    if(document.getElementById("hdLoaiBN") != null)
	    {
	        loaiBN=document.getElementById("hdLoaiBN").value;
	    }
    var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=SearchGiaTheoGiuong&idGiuongLoadGia="+objSelect.value+"&loaiBN="+loaiBN+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            document.getElementById('txtDonGiaGiuongTG').value=value;
                        }
                });
}

//function ThemGiuong(control,idchitietdkk,IdKhoa)
//    {
//	    var td = document.getElementById("tdPopupTG");
//	    var loaiBN=document.getElementById("hdLoaiBN").value;
//    alert("sdfds");
//        $(control).TimKiem({
//            ajax:"../ajax/nvk_khamTongHop_ajax.aspx?do=ThemGiuongPOPUP&idkhoaTG="+IdKhoa+"&idchitietdkkTG="+idchitietdkk+"&loaiBN="+loaiBN+""
//        },null,null,function(){
//        });
//	}
//function SuaGiuong(control,IdKhoa,idnoitru,idchitietdkkSG)
//    {
//	    var td = document.getElementById("tdPopupTG");
//	    var loaiBN=document.getElementById("hdLoaiBN").value;
//            //createTipTU(td,"tipbenhnhan","Tamung","Sửa thông tin giường bệnh","ajaxbenhnhanexists"," đang load ...","Lỗi trong quá trình thêm giường !","../ajax/nvk_khamTongHop_ajax.aspx?do=SuaGiuongPOPUP&idchitietdkkSG="+idchitietdkkSG+"&idkhoaSG="+IdKhoa+"&idnoitru="+idnoitru+"&loaiBN="+loaiBN+"", "820", "180","200","200"); 
//        $(control).TimKiem({
//            ajax:"../ajax/nvk_khamTongHop_ajax.aspx?do=SuaGiuongPOPUP&idchitietdkkSG="+idchitietdkkSG+"&idkhoaSG="+IdKhoa+"&idnoitru="+idnoitru+"&loaiBN="+loaiBN+""
//        },null,null,function(){
//        });
//	}
function KiemTraThongTinGiuong(Ngay,Gio,Phong,Giuong,DonGia)
{
    if(Ngay.value=="")
    {
        alert("Chưa chọn ngày !");
        Ngay.focus();
        return false;
    }
    if(Gio.value=="")
    {
        alert("Chưa chọn giờ !");
        Gio.focus();
        return false;
    }
    if(Phong.value=="")
    {
        alert("Chưa chọn phòng !");
        Phong.focus();
        return false;
    }
    if(DonGia.value=="")
    {
        alert("Chưa nhập giá giường !");
        DonGia.focus();
        return false;
    }
    return true;
}
function UpdateGiuong(idnoitru,idchitiedangkykhamSG)
{
//alert("Sua G");return;
    var Ngay=document.getElementById('NgayThemGiuong');
    var Gio=document.getElementById('GioThemGiuong');
    var Phong=document.getElementById('slPhongTG');
    var Giuong=document.getElementById('slGiuongTG');
    var DonGia=document.getElementById('txtDonGiaGiuongTG');
    var cbTnNgay=document.getElementById('cbTinhNguyenNgay');
    if(KiemTraThongTinGiuong(Ngay,Gio,Phong,Giuong,DonGia))
    {
     
    var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=UpdateGiuong&idCtDkkSG="+idchitiedangkykhamSG+"&idnoitruSua="+idnoitru+"&Ngay="+Ngay.value+"&Gio="+Gio.value+"&Phong="+Phong.value+"&Giuong="+Giuong.value+"&GiaGiuong="+DonGia.value+"&cbTnNgay="+cbTnNgay.checked+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            if(value=="1")
                            {
                                alert("Đã cập nhật thông tin giường bệnh !");
                                try{
                                loadInfoTienGiuong();
                                }catch(Ex){
                                DongTienGiuong_Click(idchitiedangkykhamSG)
                                }
                            } 
                            else
                                alert("Cập nhật Thất Bại (-_-)!");                
                        }
                });
     }
}
function LuuGuongMoi(idCtietDkk,IdKhoa)
{
//alert("Luu mới");return;
    var Ngay=document.getElementById('NgayThemGiuong');
    var Gio=document.getElementById('GioThemGiuong');
    var Phong=document.getElementById('slPhongTG');
    var Giuong=document.getElementById('slGiuongTG');
    var DonGia=document.getElementById('txtDonGiaGiuongTG');
    var cbTnNgay=document.getElementById('cbTinhNguyenNgay');
    if(KiemTraThongTinGiuong(Ngay,Gio,Phong,Giuong,DonGia))
    {
     
    var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=InsertGiuong&idCtietDkkTG="+idCtietDkk+"&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"&IdKhoaThemG="+IdKhoa+"&Ngay="+Ngay.value+"&Gio="+Gio.value+"&Phong="+Phong.value+"&Giuong="+Giuong.value+"&GiaGiuong="+DonGia.value+"&cbTnNgay="+cbTnNgay.checked+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            if(value=="1")
                            {
                                alert("Đã thêm giường bệnh !");
                                try{
                                loadInfoTienGiuong();
                                }catch(Ex){
                                DongTienGiuong_Click(idCtietDkk)
                                }
                            }
                            else
                                alert("Thêm Thất Bại (-_-)!");                
                        }
                });
     }
}

function loadChiTietTinhGiuongBenhNhan(idbenhnhan,IdCTDKK,idkhoa,isTinhLai)
{
    $("#spTienGiuong").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load thông tin giường.....<img id='imgLoading' src='../images/processing.gif' /></span>");
    var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=LoadThongTinTienGiuong&idbenhnhan="+idbenhnhan+"&idctdkk="+IdCTDKK+"&IdKhoaNoiTru="+idkhoa+"&isTinhLai="+isTinhLai+"";	            
        $.ajax
            ({
                 type:"GET",
                 cache:false,
                 url:PathUrl,
                  success: function (value)
                    {
                        document.getElementById('spTienGiuong').innerHTML=value;
                    }
            });
}
function btnTinhLaiGiuong_click(idbenhnhan,IdCTDKK,idkhoa)
{
	loadChiTietTinhGiuongBenhNhan(idbenhnhan,IdCTDKK,idkhoa,1);    
}
function xoaontableChiTietGiuong(control,idnoitruXoa){
//alert(idnoitruXoa); return;
     if($(control).parents("table").find("tr").length < 4){
            $.mkv.themDongTable($(control).parents("table").attr('id'));
        }
      $(control).XoaRow({
         ajax:"../ajax/nvk_khamTongHop_ajax.aspx?do=xoachitietGiuongbn_noitru&idnoitruXoa="+idnoitruXoa+"",
         valueErXoa:"Không có quyền xóa !"
      });
 }
