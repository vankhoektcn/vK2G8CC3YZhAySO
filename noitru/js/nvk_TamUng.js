// JScript File
function tamung(IsSua,idtamung)
	{
	    var td = document.getElementById("tdPopup");
            createTipTU(td,"tipbenhnhan","Tamung","Xét tạm ứng","ajaxbenhnhanexists"," đang load ...","Lỗi trong quá trình load","../ajax/nvk_khamTongHop_ajax.aspx?do=tamUng&idkhoa="+$.mkv.queryString("IdKhoa")+"&idbn="+$.mkv.queryString("idctdkk")+"&IsSua="+IsSua +"&idtamung="+idtamung+"", "820", "155","200","200"); 
	}
function luuTU(iddangkykham,idtamung)
	{
	var sotien = document.getElementById("txtSoTien").value;
	var QuyenSo = 0;//document.getElementById("txtQuyenSo").value; //Khoe
	var SoCT = 0;//document.getElementById("txtSoCT").value; 
	var LyDoTU = document.getElementById("txtLyDo").value; 
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
	             if(value != "" && value != "0")
                {
                    hideTip("tipbenhnhan");
                    InPhieuTamUngSauLuu(value);
                    try{
                    loadInfoTamUng();
                    } catch(Ex){
                    loadChiTietCongNoBenhNhan();
                    }
                }
                  else{
                   if(value=="")
                        alert("Lưu thông tin thất bại!");
                    else
                        alert(value);
                }
            }
        }
        xmlHttp.open("GET","../ajax/nvk_khamTongHop_ajax.aspx?do=nvk_LuuTamUng&idtamung="+idtamung+"&idkhoa="+queryString('IdKhoa')+"&iddangkykham=" + iddangkykham + "&SoDangKy=&quyenso="+ QuyenSo+"&SoCT="+SoCT +"&sotien=" + sotien + "&lydoTU="+encodeURIComponent(LyDoTU)+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
function SuaTU(iddangkykham,idtamung)
	{
	var sotien = document.getElementById("txtSoTien").value;
	var QuyenSo =0;// document.getElementById("txtQuyenSo").value; //Khoe
	//var SoDangKy = document.getElementById("txtSoDangKy").value;
	var SoCT =0; //document.getElementById("txtSoCT").value; 
	var LyDoTU = document.getElementById("txtLyDo").value; 
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
	             if(value == "1")
                {
                    hideTip("tipbenhnhan");
                    InPhieuTamUngSauLuu(idtamung);
                    try{
                    loadInfoTamUng();
                    } catch(Ex){
                    loadChiTietCongNoBenhNhan();
                    }
                }
                  else{
                   if(value=="")
                        alert("Sửa thông tin thất bại!");
//                    else
//                        alert(value);
                }
            }
        }
        xmlHttp.open("GET","../CapCuu/ajax.aspx?do=luuThuPhiTU&hdIdTamUng="+idtamung+"&iddangkykham=" + iddangkykham + "&SoDangKy=&quyenso="+ QuyenSo+"&SoCT="+SoCT +"&sotien=" + sotien + "&lydoTU="+encodeURIComponent(LyDoTU)+"&times="+Math.random(),true);
        xmlHttp.send(null);

	}
function InPhieuTamUngSauLuu(IdTamUng)
   {
        if(IdTamUng=="" || IdTamUng=="0")
            {alert("Chưa lưu tạm ứng !"); return; }	 
//        if (confirm("Đã Lưu tạm ứng. Bạn có muốn in phiếu báo tạm ứng không ?"))
//	    {   
            window.open("../capcuu/frmPhieuBaoThuTamUng.aspx?dkMenu=capcuu&hdIdTamUng="+IdTamUng+"#isPrint=1");
//        }
   }
function InPhieuTamUng(IdTamUng)
   {
       if(IdTamUng=="" || IdTamUng=="0")
	            {alert("Chưa lưu tạm ứng !"); return; }	    
            window.open("../capcuu/frmPhieuBaoThuTamUng.aspx?dkMenu=capcuu&hdIdTamUng="+IdTamUng+"#isPrint=1");
   }
function XoaPhieuTamUng(IdTamUng)
   {
       if(IdTamUng=="" || IdTamUng=="0")
	            {alert("Xóa không được !"); return; }
	   if(confirm('Bạn thực sự muốn xóa !'))
	   {
	    var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=deleteTamUng&idtamung="+IdTamUng+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            if(value!="")
                            {
                                alert("Đã xóa Tạm Ứng !");
                                try{
                                loadInfoTamUng();
                                } catch(Ex){
                                loadChiTietCongNoBenhNhan();
                                }                               
                            }
                        }
                });
	   }  
   }