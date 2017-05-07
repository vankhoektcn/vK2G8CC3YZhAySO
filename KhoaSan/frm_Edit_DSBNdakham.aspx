<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="frm_Edit_DSBNdakham.aspx.cs" Inherits="frm_Edit_DSBNdakham" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Cập nhật phiếu khám</title>
    
    
    <script language = "javascript" type="text/javascript">

    var dp_cal;//
    var idNDCD="0";
    var idPCD="0";
	window.onload = function () 
	{
	    var a = document.getElementById("txtidkham");
	    var idBN = document.getElementById("txtidbn");
	    document.getElementById("Button6").style.display="inline";
	    //alert(a.value,idBN.value);	    
	    //LoadThongTinKhamBenh(a.value);	
	    LoadThongTinSinhHieu(idBN.value,a.value);    
	};
	function PhieuMoi()
	{
	    document.location.href = "thambenhentry.aspx";
	}	

function tamung(idchitietdangkykham,IsSua)
	{
	    var idchitietdangkykham=document.getElementById("hdidchitietdangkykham").value;
	    var IsSua="0";
	    var td = document.getElementById("popupTamUng");
            createTipTU(td,"tipbenhnhan","Tamung","Xét tạm ứng","ajaxbenhnhanexists"," đang load ...","Lỗi trong quá trình load","../CapCuu/ajax.aspx?do=tamUng&idbn="+idchitietdangkykham+"&IsSua="+IsSua +"", "650", "130"); 
        setTimeout(function() {document.getElementById("txtSoTien").focus();},1250);
        
	}
	function luuTU(iddangkykham)
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
                    document.getElementById("hdIdTamUng").value=value;
                    hideTip("tipbenhnhan");
                    InPhieuTamUngSauLuu();
                }
                  else{
                   if(value=="")
                        alert("Lưu thông tin thất bại!");
                    else
                        alert(value);
                }
            }
        }
        xmlHttp.open("GET","../CapCuu/ajax.aspx?do=luuTU&idkhoa="+queryString('idkhoa')+"&iddangkykham=" + iddangkykham + "&SoDangKy=&quyenso="+ QuyenSo+"&SoCT="+SoCT +"&sotien=" + sotien + "&lydoTU="+encodeURIComponent(LyDoTU)+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
function InPhieuTamUngSauLuu()
   {
   if (confirm("Đã Lưu tạm ứng. Bạn có muốn in phiếu báo tạm ứng không ?"))
	     {
	        var hdIdTamUng=document.getElementById("hdIdTamUng").value;
	        if(hdIdTamUng=="" || hdIdTamUng=="0")
	            {alert("Chưa lưu tạm ứng !"); return; }	    
            window.open("../CapCuu/frmPhieuBaoThuTamUng.aspx?dkMenu=capcuu&hdIdTamUng="+hdIdTamUng+"");        
        }
   }
  
 function getOldTT()
   {
    var idBNTT = document.getElementById('idbntoathuoc');
       
            xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
	                if(value != "")
                    {
//                       
                        var ttOld = document.getElementById("thongtintoathuoc");
                        infotoathuocold.style.display = '';
                        ttOld.innerHTML =value;// value;
                       
                    }else
                    {
                        
                    } 
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=LayToaThuocCu&idBNTT=" + idBNTT.value + "&times="+Math.random(),true);
            xmlHttp.send(null);
        
   }
	function timkiemCLSS()
	{
	   


    	        var listID = document.getElementById('listIdDV').value;

	    $("#timkiemCLS").unautocomplete().autocomplete("ajax.aspx?do=timkiemCLSOK&listID="+listID+"&idpkb=''&tN=''&checkTN=''",{
	    scroll: true
	    }).result(function(event,data){
                if(data[2] == ""){
                }
                else{
	            
	            setChonDichVuCLS(data[2],true);
	            showKQCLS();
	            }
	            document.getElementById("timkiemCLS").value="";
	            document.getElementById("timkiemCLS").blur();
	            document.getElementById("timkiemCLS").focus();
                
	    });
	}
	function ViewHSBA_Click()
	{
	
	var idbn = document.getElementById('txtidbn').value;
	var idkb =document.getElementById("txtidkham").value;
	
	window.open("../khambenh/inlisthosobenhan01.aspx?idkb="+idkb+"&idbn="+idbn,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	}
	function checkThuoc(curDong)
	{

	var tenThuoc = document.getElementById("txtthuoc_"+curDong);
	    
	    var dvt = document.getElementById("txtdonvitinh_"+curDong);
	    
	      
	    var cachdung = document.getElementById("txtcachdung_"+curDong);
	if(tenThuoc.value=="" || cachdung.value=="" || dvt.value=="")
	{
	alert("Bạn chưa nhập đầy đủ thông tin toa thuốc. Vui lòng kiểm tra lại!");
	}
	else{
	xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                
               
              if(value =="chua")
                {
                var doconfirm= confirm('Thuốc '+tenThuoc.value +' chưa có trong danh mục. Bạn có muốn lưu vào danh mục không?');
              
                if(doconfirm)
                {
                    idthuoc =  luuThuocMoi(tenThuoc.value,cachdung.value,dvt.value,curDong);
                    
                    //alert(idthuoc);
                  
                }
                 else
               {
              document.getElementById("txtthuoc_"+curDong).value="";
              document.getElementById("txtdonvitinh_"+curDong).value="";
              document.getElementById("txtcachdung_"+curDong).value="";
              document.getElementById("txtidthuoc_"+curDong).value="0";
             document.getElementById("txtsoluong_"+curDong).value="1";
             document.getElementById("txtlandung_"+curDong).value="";
             document.getElementById("txtluongdung_"+curDong).value="";
             document.getElementById("txtdonvidung_"+curDong).value="";
             document.getElementById("txtghichu_"+curDong).value="";
            // document.getElementById("txtheso_"+curDong).value="";
                }
               }
              
            }
        }
        
        xmlHttp.open("GET","ajax.aspx?do=checkThuoc&tenThuoc="+encodeURIComponent(tenThuoc.value)+"&cachdung="+encodeURIComponent(cachdung.value)+"&dvt="+encodeURIComponent(dvt.value)+"&times="+Math.random(),true);
        xmlHttp.send(null);
        }
	}
	function luuThuocMoi(tenthuoc,cachdung,dvt,curDong)
	{
	xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                document.getElementById("txtidthuoc_"+curDong).value=value;
               //alert(document.getElementById("txtidthuoc_"+curDong).value);
               ThemThuoc(eval(curDong)+1);
               
            }
        }
        
        xmlHttp.open("GET","ajax.aspx?do=luuNewThuoc&tenThuoc="+encodeURIComponent(tenthuoc)+"&cachdung="+encodeURIComponent(cachdung)+"&dvt="+encodeURIComponent(dvt)+"&times="+Math.random(),true);
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
		function trimAll(sString) 
    { 
    while (sString.substring(0,1) == ' ') 
    { 
    sString = sString.substring(1, sString.length); 
    } 
    while (sString.substring(sString.length-1, sString.length) == ' ') 
    { 
    sString = sString.substring(0,sString.length-1); 
    } 
    return sString; 
   } 

 function LuuChanDoanMoi(TenChanDoan,MaChanDoan,IdChanDoan)
    {
        var ojbTenCD= document.getElementById(TenChanDoan);
        var ojbMaCD= document.getElementById(MaChanDoan);
        var ojbIDCD= document.getElementById(IdChanDoan);
        if(ojbMaCD.value=='')
        {            
            return;
        }
        if(ojbTenCD.value=='')
        {           
            return;
        }
                xmlHttp = GetMSXmlHttp();
                xmlHttp.onreadystatechange = function()
                {
                    if(xmlHttp.readyState == 4)
                    {
                        var value = xmlHttp.responseText;                        
	                    if(value != "")
                        {                                 
                           if(eval(value)>1) {
                                ojbIDCD.value=value;
                           }                          
                        }else
                        {
                            alert('Đã xãy ra lỗi trong quá trình lưu.');
                        } 
                    }
                }
                xmlHttp.open("GET","ajax.aspx?do=luuNewChanDoan&TenChanDoan=" + ojbTenCD.value + "&MaChanDoan="+ojbMaCD.value+"&IdChanDoan="+ojbIDCD.value,true);
                xmlHttp.send(null);

    }
    function checkICD(TenChanDoan,MaChanDoan,IdChanDoan)
	{
	     var ojbTenCD= document.getElementById(TenChanDoan);
        var ojbMaCD= document.getElementById(MaChanDoan);
        var ojbIDCD= document.getElementById(IdChanDoan);
        if(ojbMaCD.value=='')
        {            
            return;
        }
        if(ojbTenCD.value=='')
        {           
            return;
        }
	   	xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
               
               if(value =="chua")
               {
                  var doconfirm= confirm('Chẩn đoán '+ojbTenCD.value +' chưa có trong danh mục. Bạn có muốn lưu vào danh mục không?');
                  
                  if(doconfirm)
                  {
                    LuuChanDoanMoi(TenChanDoan,MaChanDoan,IdChanDoan)
                  }
                  else
                  {
                    ojbTenCD.value=""; 
                    ojbMaCD.value="";            
                  }
             
               }
            }
        }
        
        xmlHttp.open("GET","ajax.aspx?do=checkICD&maicd="+encodeURIComponent(ojbMaCD.value)+"&times="+Math.random(),true);
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
	 
	function LoadIDBenhNhan()
	{
	    //var obn = document.getElementById("txtidbn");
	    xmlHttp = GetMSXmlHttp();	    
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var oidbenhnhan = document.getElementById("txtidbn");
	            oidbenhnhan.value = eval(value);
	            LoadInFoBenhNhan(obn.value);	            
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loadidbnbymaphieukham&idkhambenh="+obn.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	//Load thong tin kham benh dua vao id phieu kham benh
	function LoadThongTinKhamBenh(idkhambenh)
	{
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                //alert(value);
                if (value != "")
                {
                    var arrval = value.split('@');
//                document.getElementById("txtLoaiBN").value=oLoaiBenhNhan;
//	            document.getElementById("txtSoNgayBH").value=songayBH;
                    var omapk = document.getElementById("txtMaPhieuKham");
    	            omapk.value = arrval[0];
    	            var ongaykham = document.getElementById("txtNgayKham");
    	            ongaykham.value = arrval[1];
                    var otrieuchung = document.getElementById("txtTrieuChung");
    	            otrieuchung.value = arrval[2];
    	            var ochandoansobo = document.getElementById("txtChanDoanSoBo");
    	            ochandoansobo.value = arrval[3];
    	            
    	            if(arrval[arrval.length-3].length > 0){
    	            var oidcd4 = document.getElementById("txtIdChanDoan_4");
    	            oidcd4.value = arrval[arrval.length-3];
    	            var otencd4 = document.getElementById("txtchandoan_4");
    	            otencd4.value = arrval[arrval.length-2];
    	            var omacd4 = document.getElementById("txtmachandoan_4");
    	            omacd4.value = arrval[arrval.length-1];
    	            }
    	            
    	            var oidcd1 = document.getElementById("txtIdChanDoan_1");
    	            oidcd1.value = arrval[4];
    	            var otencd1 = document.getElementById("txtchandoan_1");
    	            otencd1.value = arrval[5];
    	            var omacd1 = document.getElementById("txtmachandoan_1");
    	            omacd1.value = arrval[6];
    	            
                        var kiemtra1=document.getElementById("txt_kiemtra1").value;
	                var kiemtra2=document.getElementById("txt_kiemtra2").value;

	                   /* if(kiemtra1==1)
	                    {
    	                        var oidcd2 = document.getElementById("txtIdChanDoan_2");
    	                        oidcd2.value = arrval[7];
    	                        var otencd2 = document.getElementById("txtchandoan_2");
    	                        otencd2.value = arrval[8];
    	                        var omacd2 = document.getElementById("txtmachandoan_2");
    	                        omacd2.value = arrval[9];
	                    }      */
	                    if(kiemtra2==1)
	                    {
    	                   /* var oidcd3 = document.getElementById("txtIdChanDoan_3");
    	                    oidcd3.value = arrval[10];
    	                    var otencd3 = document.getElementById("txtchandoan_3");
    	                    otencd3.value = arrval[11];
    	                    var omacd3 = document.getElementById("txtmachandoan_3");
    	                    omacd3.value = arrval[12];   */ 
    	                    for(var t=1;t<document.getElementById("chandoanicd10_1").rows.length;t++){
    	                        document.getElementById("chandoanicd10_1").deleteRow(t);
    	                   }
    	                    document.getElementById("chandoanicd10_1").style.display = 'block';
    	                    $("#chandoanicd10_1").append(arrval[10]);
	                    }
    	           	            
    	            
    	            var odando = document.getElementById("txtDanDo");
    	            odando.value = arrval[14];
    	            var onoidungtk = document.getElementById("txtNoiDungTaiKham");
    	            onoidungtk.value = arrval[15];
    	            var ongaytk = document.getElementById("txtngayhen");
    	            ongaytk.value = arrval[16];
    	            
    	            var TienSuBenh = document.getElementById("txtTienSuBenh");
    	            TienSuBenh.value = arrval[arrval.length-4];
    	            
    	            //alert("TienSuBenh="+TienSuBenh.value);
    	             
//    	            //var oghichu = document.getElementById("txtHuongKhac");
//    	            //oghichu.value = arrval[18];
//    	            
    	            var ohuongdieutri = document.getElementById("ohuongdieutri");
    	            ohuongdieutri.innerHTML = arrval[19];
    	            var listphongkhamSpan = document.getElementById("listphongkham");
    	            //alert("vaoday");
    	            if (arrval[21] == "1" || arrval[21] == "7" || arrval[21] == "9")
    	            {
    	                //alert("hiện combo");
    	                listphongkhamSpan.style.display = '';
    	                document.getElementById("ddlPhongKhamBenh").value=arrval[20];
    	                idNDCD=arrval[arrval.length-7];    	                
    	                idPCD=arrval[arrval.length-6];
    	                LoadNoiDungChuyenDen(); 
    	                
    	            }
    	            else if (eval(arrval[21]) == 3 )    
    	            {
    	                var ohuongkhac = document.getElementById("spText");
    	                ohuongkhac.style.display = '';
    	            } 
    	            else if ( eval(arrval[21]) == 4)    
    	            {
    	                 var benhVienChuyenDen = document.getElementById("benhVienChuyenDen");
    	                benhVienChuyenDen.style.display = '';
    	                document.getElementById('btnGiayChuyenVien').style.display="block";
    	                //document.getElementById("txtBVChuyenDen").value=arrval[18];
    	                //Khoe 1807 set thông tin BV chuyển đến
    	                //alert("idbenhvien="+arrval[36]+",MaBV="+arrval[37]+",TênBV="+arrval[38]);
    	                document.getElementById("txtidBenhVien").value=arrval[36];
    	                document.getElementById("txtmaBenhVien").value=arrval[37];
    	                document.getElementById("txtTenBenhVien").value=arrval[38];
    	                //End Khoe 1807
    	            }   
    	            else if (eval(arrval[21]) == 8 )    
    	            {
    	                var KhoaNhapVien = document.getElementById("KhoaNhapVien");
    	                KhoaNhapVien.style.display = '';
    	            } 
    	            if(eval(arrval[21]) == 2 || eval(arrval[21]) == 7 || eval(arrval[21]) == 10)
	                {
	                     var toaThuocMau = document.getElementById("toathuocmau");
	                     toaThuocMau.style.display = '';
	                }
    	            //alert("ghichu HDT="+arrval[18]);
    	            var olistchidinhcanlamsan = document.getElementById("listchidinhcanlamsan");
    	            olistchidinhcanlamsan.innerHTML = arrval[22];
    	            var ketquacanlamsan = document.getElementById("ketquacanlamsan");
    	            ketquacanlamsan.innerHTML = arrval[23];
    	           // alert(arrval[28]);
    	           //document.getElementById("listIDKBCLS").value = '<%=Session["listidchidinhcls"]%>';
    	          
    	           //document.getElementById("listIdDV_Old").value=arrval[27];//chi dinh CLS cũ
    	           document.getElementById("listIdDV_Old").value=arrval[27]+","+arrval[arrval.length-5];//chi dinh CLS cũ cả "đã thu" và chưa thu để IN CLS cũ
    	           
    	           //alert("listIdDV_Old="+document.getElementById("listIdDV_Old").value);
    	                if(arrval[28]=="1")
    	                {
    	               document.getElementById("btnUpdateChiDinhCls").style.display = 'none';
    	                  document.getElementById("btnInsertNewCLS").style.display = '';
    	                document.getElementById("listIdDV").value=""; 
    	                document.getElementById("lastSL").value="";
    	                document.getElementById("lastID").value="";
    	                document.getElementById("lastDG").value="";
    	                document.getElementById("lastCK").value="";
    	                document.getElementById("lastTT").value="";
    	                document.getElementById("lastGC").value="";
    	                document.getElementById("statusCDCLS").value="Insert";    	                
    	                //alert("ĐÃ thu CLS,listIdDV="+ document.getElementById("listIdDV").value+"_aa");    	                
    	                }
    	              else
    	                {
    	                document.getElementById("tenDVCLSChuaThu").value =arrval[34];
    	                document.getElementById("btnUpdateChiDinhCls").style.display = '';
    	                document.getElementById("btnInsertNewCLS").style.display = 'none';
    	               // Khỏe 07/12 : Thông tin CLS có số lượng của phiếu khám
    	               var IdvaSoLuong= arrval[27].split(";");
    	                document.getElementById("listIdDV").value=IdvaSoLuong[0]+",";
    	                document.getElementById("lastID").value=IdvaSoLuong[0];
    	                document.getElementById("lastSL").value=IdvaSoLuong[1];
    	                document.getElementById("lastDG").value=IdvaSoLuong[2];
    	                document.getElementById("lastCK").value=IdvaSoLuong[3];
    	                document.getElementById("lastTT").value=IdvaSoLuong[4];
    	                document.getElementById("lastGC").value=IdvaSoLuong[5];
    	                 document.getElementById("listIdDV_Old").value=IdvaSoLuong[0]+","+arrval[arrval.length-5];
    	               //End Khỏe 07/12 : Thông tin CLS có số lượng của phiếu khám 
    	               
	                    var t = document.getElementById('listIdDV').value;                    	
	                        if(document.getElementById('listIdDV').value.indexOf(",") ==-1)
	                        {
	                        document.getElementById('listIdDV').value=document.getElementById('listIdDV').value+",";                    	
	                        }    	                
    	                document.getElementById("statusCDCLS").value="Update";
    	                //alert("Chưa thu CLS,listIdDV="+ document.getElementById("listIdDV").value+"_bb");
    	                }
    	            
    	            
    	            if(arrval[23]==""&& arrval[22]=="")
    	            {
    	             document.getElementById("btnUpdateChiDinhCls").style.display = 'none';
    	              document.getElementById("btnInsertNewCLS").style.display = '';
    	            document.getElementById("listIdDV").value="";
    	            document.getElementById("lastSL").value="";
    	            document.getElementById("lastID").value="";
    	            document.getElementById("lastDG").value="";
    	            document.getElementById("lastCK").value="";
    	            document.getElementById("lastTT").value="";
    	            document.getElementById("lastGC").value="";
    	            document.getElementById("statusCDCLS").value="Insert";
    	            
    	            }
    	            
    	           var obenhsu = document.getElementById("txtbenhsu");
    	            obenhsu.value= arrval[26];
    	            
    	            document.getElementById("lblIDThuocCheck").value=arrval[24];
//    	            if (arrval[24] != 0)
//    	            {
    	                var othongtintoathuoc = document.getElementById("thongtintoathuoc");
    	                othongtintoathuoc.innerHTML = arrval[25];
    	                //alert("othongtintoathuoc="+arrval[25]);
    	                //document.getElementById("infotoathuoc").style.display='';
    	                
//    	            }
//    	            else
//    	            {
//    	           
//    	            document.getElementById("infotoathuoc").style.display='';
//    	            }
    	            
    	              if(document.getElementById("txtngayhen").value!="")
                    {
                    document.getElementById('btnInPH').style.display = '';
                    }
                    document.getElementById("ddlBS").value=arrval[30];
                     document.getElementById("ddlPK").value=arrval[31];
                     //document.getElementById("idpkbCLS").value=arrval[31];
                     document.getElementById("iddangkykham").value = arrval[32];
                       document.getElementById("txtgiohen").value = arrval[33];
                     
    	            dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtngayhen')); 
                }
	          }
        }
        xmlHttp.open("GET","ajax.aspx?do=loadthongtinphieukham&idkhoa="+queryString('idkhoa')+"&loai='edit'&idkhambenh="+idkhambenh+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	
	function LoadInFoBenhNhan(idkhambenh)
	{
	    var obn = document.getElementById("txtidbn");
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var oarr = value.split('@');
                var idbenhnhan = document.getElementById("txtidbn");
                idbenhnhan.value = oarr[0];
                var mabenhnhan = document.getElementById("txtMaBenhNhan");
                mabenhnhan.value = oarr[1];
	            var tenbenhnhan = document.getElementById("txtTenBenhNhan");
	            tenbenhnhan.value = oarr[2];
	            var tuoi = document.getElementById("txtTuoi");
	            tuoi.value = oarr[3];
	            var gioitinh = document.getElementById("txtGioiTinh");
	            gioitinh.value = oarr[4];
	            var sobh = document.getElementById("txtSoBHYT");
	            sobh.value = oarr[5];
	            var ngayhh = document.getElementById("txtNgayHH");
	            ngayhh.value = oarr[6];
	            var soDTBN = document.getElementById("txtSoDTBN");
	            soDTBN.value = oarr[11];
	            var diachi = document.getElementById("txtDiaChi");
	            diachi.value = oarr[7];
	            LoadThongTinSinhHieu(obn.value, idkhambenh);	            
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=getinfobenhnhan&idbenhnhan="+obn.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	function LoadThongTinSinhHieu(idbenhnhan, idkhambenh)
	{
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var osinhhieu = document.getElementById("infosinhhieu");
	            osinhhieu.innerHTML = value;
	            LoadThongTinKhamBenh(idkhambenh);
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loadsinhhieu&idbenhnhan="+idbenhnhan+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	
	function LoadChanDoanICD10(obj, Curdong)
	{
	    var typeSearch;
           if(obj.split("_")[0] != "txtchandoan")
           {
                typeSearch = "Mã ICD";
           }
           else{
                typeSearch = "Mô tả";
           }
	     $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=getallchandoan&typeSearch="+encodeURIComponent(typeSearch),
        {formatItem: function(data) {
                return data[0];
            },width:700,scroll: true}
        )
        
        .result(function(event, data){
               setChonChanDoan(data[1],data[2],data[3]);
               $("#"+obj).val("");
              $("#"+obj).blur(); 
               document.getElementById(obj).focus();
        });
	}
	
	function Luuchandoanphoihop(idkhambenh){
		var listidchandoanicd10;
	 for (var i = 1; i < document.getElementById("chandoanicd10_1").rows.length; i++)
                { 
                   if(document.getElementById("idchandoanicd10_"+i) != null)
                   {
                        listidchandoanicd10 = listidchandoanicd10 +"@"+ document.getElementById("idchandoanicd10_"+i).value;
                   }
                }
	     xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
               
            }
        }
            xmlHttp.open("GET","ajax.aspx?do=luuchandoanphoihop&idchandoan="+listidchandoanicd10+"&idkhambenh="+idkhambenh,true);
        xmlHttp.send(null);
	}
	
	function ShowChanDoan(obj, curdong)
	{
	    var objsrc = document.getElementById(obj);
	    var objshowtip = document.getElementById("listchandoan_"+curdong);
	    var objtip = document.getElementById("tipchandoan");
	    if (objtip != null || objtip != "undefined")
	        hideTip("tipchandoan");
	    createTip(objshowtip,"tipchandoan","danhsachchandoanicd","Danh sách chẩn đoán ICD10","ajaxdichvuexists"," đang load danh sách chẩn đoán ICD 10...","Lỗi trong quá trình load danh sách chẩn đoán ICD 10.","ajax.aspx?do=getallchandoan&tenchandoan="+encodeURIComponent(objsrc.value), "750", "200");           
	}
	
	function setChonChanDoan(idchandoan, machandoan, tenchandoan)
	{
	    var Curdong = document.getElementById('chandoanicd10_1').rows.length;
	    document.getElementById("chandoanicd10_1").style.display ='';
	    	    for(var i=0;i<Curdong;i++)
	    	    {
	    	    try{
	    	        if(idchandoan == document.getElementById('chandoanicd10_1').rows[i].cells[1].getElementsByTagName("input")[0].value)
	    	        {
	    	            return;
	    	        }
	    	        }catch(ex){}
	    	    }
	    $("#chandoanicd10_1").append("<tr bgcolor='yellow'><td style=\"cursor:pointer\" onclick=\"javascript:document.getElementById('chandoanicd10_1').deleteRow(this.parentNode.rowIndex);\">X</td><td><input type='hidden' id='idchandoanicd10_"+Curdong+"' value='"+idchandoan+"' />"+machandoan+"</td><td>"+tenchandoan+"</td></tr>");
	}
	function LoadLoiDanDo(obj)
	{
	    if (event.keyCode == 13)   DanhSachLoiDan(obj);
	}
	
	function DanhSachLoiDan(obj)
	{
	    var objsrc = document.getElementById(obj);
	    var objshowtip = document.getElementById("td_DanDo");
	    var obbenhly = document.getElementById("ddlbenhlymau");
	    
	        hideTip("tipLoiDan");
	    createTip(objshowtip,"tipLoiDan","DanhSachLoiDan","Danh sách lời dặn mẫu","ajaxdichvuexists",
	    " Đang load danh sách lời dặn mẫu","Lỗi trong quá trình load danh sách lời dặn mẫu",
	    "ajax.aspx?do=GetListLoiDan&TenLoiDan="+encodeURIComponent(objsrc.value)+"&BenhLyID="+encodeURIComponent(obbenhly.value), "750", "500");           
	}
	
	function SetLoiDan(NoiDung)
	{
	    var obLoiDan = document.getElementById("txtDanDo");
	    obLoiDan.value = NoiDung;
	    hideTip("tipLoiDan");
	}
	
	
	//Phan toa thuoc
	
	function LoadListThuoc(obj, Curdong)
	{
		//if (event.keyCode == 13) {
	    var ocurdong = document.getElementById("curdong");
	   
	    ocurdong.value = Curdong;
	    ShowThuoc(obj, Curdong);
	   // }
	}
	
	function ShowThuoc(obj, curdong)
	{
	var dongs = parseInt(curdong)+1;
	    var objsrc = document.getElementById(obj);
	    var objshowtip = document.getElementById("listdichvu_"+curdong);
	    var objtip = document.getElementById("tipthuoc");
	    
	    if (objtip != null || objtip != "undefined")
	        hideTip("tipthuoc");	    
	        var oidkhambenh = document.getElementById("txtidkham");
	        
	    //createTip(objshowtip,"tipthuoc","danhsachnoidungthuoc","Danh sách thuốc","ajaxdichvuexists"," đang hiện thỉ danh sách thuốc...","Lỗi trong quá trình load danh sách thuốc","ajax.aspx?do=getallthuoc&tenthuoc="+encodeURIComponent(objsrc.value) +"&IdKhamBenh="+oidkhambenh, "750", "300");           
	    $("#"+obj).autocomplete("ajax.aspx?do=getallthuoc",
        {formatItem: function(data) {
                return data[0];
            },width:700,scroll: true}
        )
        
        .result(function(event, data){
                setChonThuoc(data[1],data[2],data[3],data[4],data[5],data[6]);
                ThemThuoc(dongs);
                var orow = document.getElementById("row_"+(parseInt(curdong)+1));
	            orow.style.display = '';
	            document.getElementById("txtsoluong_"+(parseInt(curdong))).focus(); 
	           $("#"+obj).blur(); 
                
        });
	}		
	function ThemThuoc(dongs)
	{
	    if(document.getElementById("row_"+dongs) == null)
                      {
$("#thuochiep > tbody:last").append("<tr id='row_"+ dongs +"' style=\"display:'';\">"
                                   + "<td style=\"height: 27px;width:70px;overflow:hidden\"><span class = \"ptext\">"+dongs+".</span><span class = \"ptext\" style =\"cursor:pointer\" onclick = \"DeleteThuoc("+dongs+")\">X</span></td>"
                                   + "<td id = \"listdichvu_"+dongs+"\" style=\"height: 27px;\"><span class = \"ptext\"><input type=\"hidden\" id = \"idchitiettoathuoc_"+dongs+"\" value=\"\"><input type=\"hidden\" name=\"txtidthuoc_"+dongs+"\" id =\"txtidthuoc_"+dongs+"\" value = \"0\" style=\"width: 16px\"><input type=\"text\" name=\"txtthuoc_"+dongs+"\" id =\"txtthuoc_"+dongs+"\" style =\"width:150px\" onfocus = \"LoadListThuoc('txtthuoc_"+dongs+"','"+dongs+"')\"></span></td>"
                                   + "<td width=\"10%\"  style=\"height: 26px;\"><span class = \"ptext\"><input type=\"text\" name=\"txtcongthuc_"+dongs+"\" id=\"txtcongthuc_"+dongs+"\" style=\"width:120px\" ></span></td>"
                                   + "<td style=\"width: 47px; height: 27px\"><span class = \"ptext\"><input type=\"text\" name=\"txtdonvitinh_"+dongs+"\" id=\"txtdonvitinh_"+dongs+"\" style =\"width:30px; \" ></span></td>"
                                   + "<td style=\"height: 27px\"><span class = \"ptext\"><input type=\"text\" name=\"txtsoluong_"+dongs+"\" id=\"txtsoluong_"+dongs+"\" style =\"width:30px; text-align: right\"  onblur = \"TestNum(this); \"></span></td>"
                                    
                                   + "<td style=\"height: 27px\"><span class = \"ptext\"><input type=\"text\" name=\"txtcachdung_"+dongs+"\" id=\"txtcachdung_"+dongs+"\" style =\"width:90px; \" ></span></td>"
                                    +"<td style=\"height: 27px; width: 30px;\"><span class = \"ptext\"><input type=\"text\" name=\"txtlandung_"+dongs+"\" id=\"txtlandung_"+dongs+"\" onkeypress=\"isNumber(this);\"  onblur=\"isNumber(this);\" style =\"width:30px; \" ></span></td>"
                                    +"<td style=\"height: 27px; width: 33px;\"><span class = \"ptext\"><input type=\"text\" name=\"txtluongdung_"+dongs+"\" id=\"txtluongdung_"+dongs+"\"  style =\"width:30px; \" value=\"1\" ></span></td>"
                                    +"<td style=\"width: 100px; height: 27px\"><span class = \"ptext\"><input type=\"text\" name=\"txtdonvidung_"+dongs+"\" id=\"txtdonvidung_"+dongs+"\" onblur=\"checkThuoc('"+dongs+"');\" style =\"width:80px; \" ></span></td>"
                                    +"<td style=\"width: 350px; height: 26px;\"><span class = \"ptext\">"
                                    +"<input type=\"checkbox\" id=\"chksang_"+dongs+"\" name=\"chksang_"+dongs+"\" />&nbsp;&nbsp;&nbsp;&nbsp;"
                                     +"<input type=\"checkbox\" id=\"chkTrua_"+dongs+"\" name=\"chkTrua_"+dongs+"\" />&nbsp;&nbsp;&nbsp;&nbsp;"
                                     + "<input type=\"checkbox\" id=\"chkChiu_"+dongs+"\" name=\"chkChiu_"+dongs+"\" />&nbsp;&nbsp;&nbsp;&nbsp;"
                                      + "<input type=\"checkbox\" id=\"chkToi_"+dongs+"\" name=\"chkToi_"+dongs+"\" />"
                                    + "</span></td>"
                                    
                                   + "<td style=\"height: 27px; width: 100px;\"><span class = \"ptext\"><input type=\"hidden\" name=\"idphongkham_"+dongs+"\" id =\"idphongkham_3\" value = \"0\"><input type=\"text\" name=\"txtghichu_"+dongs+"\" id=\"txtghichu_"+dongs+"\" style =\"width:100px\"></span></td>"
//                                   + "<td style=\"height: 26px; width: 61px;\"><span class = \"ptext\"><input type=\"text\" name=\"txtheso_"+dongs+"\" id=\"txtheso_"+dongs+"\" style =\"width:58px\"></span></td>"
                                   +  "<td style=\"height: 26px; width: 170px;\">"
                                  + "<span class = \"ptext\">"
                                   + "<input type=\"radio\" checked name=\"rblTenND_"+dongs+"\" value=\"Ngày dùng\"/>Ngày <br/>"
                                   + "<input type=\"radio\" name=\"rblTenND_"+dongs+"\" value=\"Tu&#226;̀n dùng\"/>Tuần "
                                  + "</span>"
                                  + "</td>"
                                 + "</tr>");
                                 
                }
	}
	function setChonThuoc(idthuoc, tenthuoc, donvitinh, duongdung,ghichu,congthuc)
	{
	    var ocurdong = document.getElementById("curdong");
	    
	    var oidthuoc = document.getElementById("txtidthuoc_"+ocurdong.value);
	    oidthuoc.value = idthuoc;
	    var otenthuoc = document.getElementById("txtthuoc_"+ocurdong.value);
	    otenthuoc.value = tenthuoc;
	    var ocongthuc = document.getElementById("txtcongthuc_"+ocurdong.value);
	    ocongthuc.value = congthuc;
	    var odvt = document.getElementById("txtdonvitinh_"+ocurdong.value);
	    odvt.value = donvitinh;
	    var ocachdung = document.getElementById("txtcachdung_"+ocurdong.value);
	    ocachdung.value = duongdung;
	   document.getElementById("txtdonvidung_"+ocurdong.value).value =donvitinh;
	   var oGhiChu = document.getElementById("txtghichu_"+ocurdong.value);
	    oGhiChu.value = ghichu;
	    	   var oheso ="0";// document.getElementById("txtheso_"+ocurdong.value);
	    oheso.value = "";
	    hideTip("tipthuoc");    
	    
	}
	
	function DeleteThuoc(dong)
	{
	    var oidthuoc = document.getElementById("txtidthuoc_"+dong);
	    oidthuoc.value = "0";
	    var otenthuoc = document.getElementById("txtthuoc_"+dong);
	    otenthuoc.value = "";
	    var odvt = document.getElementById("txtdonvitinh_"+dong);
	    odvt.value = "";
	    var ocachdung = document.getElementById("txtcachdung_"+dong);
	    ocachdung.value = "";
	    
	    var olandung = document.getElementById("txtlandung_"+dong);
	    olandung.value = "";
	    var oluongdung = document.getElementById("txtluongdung_"+dong);
	    oluongdung.value = "";
	    var odvtdung = document.getElementById("txtdonvidung_"+dong);
	    odvtdung.value = "";
	    var oghichu = document.getElementById("txtghichu_"+dong);
	    oghichu.value = "";
	    	    	    var oheso ="0";// document.getElementById("txtheso_"+dong);
	    oheso.value = "";
	     document.getElementById("txtsoluong_"+dong).value="1";
	       document.getElementById("chksang_"+dong).checked=false;
              
              document.getElementById("chkTrua_"+dong).checked =false;
                
              document.getElementById("chkChiu_"+dong).checked =false;
                
              document.getElementById("chkToi_"+dong).checked =false;
              if(dong < eval($("#thuochiep > tbody > tr:last").attr("id").split("_")[1]))
                document.getElementById("row_"+dong).style.display = 'none';
	}
	
	function DeleteThuocUpdate(idCTbenhNhanToaThuoc,tenthuoc,dong)
	{
	
	if(confirm('Bạn có chắc muốn xóa Thuốc : '+tenthuoc+' ?'))
	{
	   var oidthuoc = document.getElementById("txtidthuoc_"+dong);
	    oidthuoc.value = "0";
	    var otenthuoc = document.getElementById("txtthuoc_"+dong);
	    otenthuoc.value = "";
	    var odvt = document.getElementById("txtdonvitinh_"+dong);
	    odvt.value = "";
	    var ocachdung = document.getElementById("txtcachdung_"+dong);
	    ocachdung.value = "";
	    
	    var olandung = document.getElementById("txtlandung_"+dong);
	    olandung.value = "";
	    var oluongdung = document.getElementById("txtluongdung_"+dong);
	    oluongdung.value = "";
	    var odvtdung = document.getElementById("txtdonvidung_"+dong);
	    odvtdung.value = "";
	    var oghichu = document.getElementById("txtghichu_"+dong);
	    oghichu.value = "";
	    	    	    	    var oheso ="0";// document.getElementById("txtheso_"+dong);
	    oheso.value = "";
	     document.getElementById("txtsoluong_"+dong).value="1";
	       document.getElementById("chksang_"+dong).checked=false;
              
              document.getElementById("chkTrua_"+dong).checked =false;
                
              document.getElementById("chkChiu_"+dong).checked =false;
                
              document.getElementById("chkToi_"+dong).checked =false;
	      xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
               
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=deleteChiTietToaThuoc&idCTbenhNhanToaThuoc="+idCTbenhNhanToaThuoc+"&times="+Math.random(),true);
        xmlHttp.send(null);
	    }
	}
	function TinhTien()
	{   
	   var tongtien = 0;    
	   var listIdDV=  document.getElementById('listIdDV').value;
	   
	   var arrIdCLS=document.getElementById('listIdDV').value.split(",");	
	   for(var i=1;i<arrIdCLS.length;i++)
	   {
	        if(document.getElementById('txtSoLuongCLS_'+i)=='undefined' ||document.getElementById('txtSoLuongCLS_'+i)==null)
	        {
	            continue;
	            }
	        else
	        {
	            var ChietKhau=eval(document.getElementById('txtChietKhauCLS_'+i).value.replace(/,/g,''))/100 ;
	            var TienChuaCK=eval(document.getElementById('txtSoLuongCLS_'+i).value.replace(/,/g,''))*eval(document.getElementById('txtDonGiaCLS_'+i).value.replace(/,/g,''));
	            var ThanhTienDong=TienChuaCK - (TienChuaCK * ChietKhau);
	            document.getElementById('txtThanhTienCLS_'+i).value=formatCurrency(ThanhTienDong);
	            tongtien+=ThanhTienDong;
	            //tongtien+=eval(document.getElementById('txtSoLuongCLS_'+i).value.replace(/,/g,''))*eval(document.getElementById('txtDonGiaCLS_'+i).value.replace(/,/g,''));
	        }	        
	   }
	   document.getElementById('tdTongTien').innerHTML=formatCurrency(tongtien);       
	}
	 function showKQCLS()
	 {
	     var listIDCLS = document.getElementById('listIdDV').value;
	 if(listIDCLS != "")
	 {
	  xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value1 = xmlHttp.responseText;
                var value = value1.split('@');
                var oCLS = document.getElementById("showchidinhCLS");
	            oCLS.innerHTML = value[0];
	            hideTip("tipcls");
	             document.getElementById("showchidinhCLS").style.display = '';
	               document.getElementById("showDivCLS").style.display = '';
	            
    	           
    	            var t =  document.getElementById("listchidinhcanlamsan").innerHTML;
    	            var tenDVOld =   document.getElementById("tenDVCLSChuaThu").value;
    	            //document.getElementById("listchidinhcanlamsan").style.display='none';
	            document.getElementById("tenDVCLSChuaThu").value = value[1];
    	           document.getElementById("listchidinhcanlamsan").innerHTML = t.replace(tenDVOld,value[1]);
    	          
    	            document.getElementById("HuyCLS").style.display='';
            }
        }
         var oidkhambenh = document.getElementById("txtidkham");
         
        xmlHttp.open("GET","ajax.aspx?do=showKQCLS&listIdcls="+listIDCLS+"&IdKhambenh="+oidkhambenh.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
        }
        else
        {
          document.getElementById("showchidinhCLS").style.display = 'none';
            document.getElementById("showDivCLS").style.display = 'none';
            document.getElementById('divLuuCLS').style.display='none';
            document.getElementById("HuyCLS").style.display='none';
            
    	           var t =  document.getElementById("listchidinhcanlamsan").innerHTML;
    	            var tenDVOld =   document.getElementById("tenDVCLSChuaThu").value;
    	          
	            document.getElementById("tenDVCLSChuaThu").value = "";
    	           document.getElementById("listchidinhcanlamsan").innerHTML = t.replace(tenDVOld,"");
    	           
        }
	 }
//	 function showKQCLS_Old()
//	 {
//	 var mp = document.getElementById("mp");
//	 var dkUpdate = document.getElementById("dkUpdate");
//	 var dk = document.getElementById("dkmenu");
//	 var listIDCLS = document.getElementById('listIdDV').value;
//	 if(listIDCLS != "")
//	 {
//	  xmlHttp = GetMSXmlHttp();
//        xmlHttp.onreadystatechange = function()
//        {
//            if(xmlHttp.readyState == 4)
//            {
//                var value1 = xmlHttp.responseText;
//                var value = value1.split('@');
//                var oCLS = document.getElementById("showchidinhCLS");
//	            oCLS.innerHTML = value[0];
//	            hideTip("tipcls");
//	             document.getElementById("showchidinhCLS").style.display = '';
//	               document.getElementById("showDivCLS").style.display = '';    	           
//    	            var t =  document.getElementById("listchidinhcanlamsan").innerHTML;
//    	            var tenDVOld =   document.getElementById("tenDVCLSChuaThu").value;
//    	            //document.getElementById("listchidinhcanlamsan").style.display='none';
//	            document.getElementById("tenDVCLSChuaThu").value = value[1];
//    	           document.getElementById("listchidinhcanlamsan").innerHTML = t.replace(tenDVOld,value[1]);
//    	          
//    	            document.getElementById("HuyCLS").style.display='';
//            }
//        }
//        var ChietKhau = document.getElementById('txtChietKhau').value;
//        var idbenhnhan = document.getElementById('txtidbenhnhan').value;
//        var LoaiBN=document.getElementById("cbLoaiBN");// sau khi chọn cận lâm sàng
//        var MaPhieu = document.getElementById('txtMaPhieuCLS_Old').value; 
//        xmlHttp.open("GET","thuphiCLS_BNTuDen_Ajax.aspx?do=showKQCLS_Old&MaPhieuCLS="+MaPhieu+"&listIdcls="+listIDCLS+"&cpu="+queryString("cpu")+"&dk="+dk.value+"&dkUpdate="+dkUpdate.value+"&mp="+mp.value+"&times="+Math.random() +"&ChietKhau="+ChietKhau+"&idbenhnhan="+idbenhnhan +"&LoaiBN="+LoaiBN.value,true); /// sau khi đóng chọn cận lâm sàng
//        xmlHttp.send(null);
//        }
//        else
//        {
//        hideTip("tipcls");
//         document.getElementById('divLuuCLS').style.display='none';
//	
//          document.getElementById("showchidinhCLS").style.display = 'none';
//            document.getElementById("showDivCLS").style.display = 'none';
//        }
//	 }
	 //Hiển thị CLS có số lượng đã chọn
	function showKQCLS()
	 {
	 //alert("aaaa");
	 var listIDCLS = document.getElementById('listIdDV').value;
	 if(listIDCLS != "")
	 {
	  xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value1 = xmlHttp.responseText;
                var value = value1.split('@');
                var oCLS = document.getElementById("showchidinhCLS");
	            oCLS.innerHTML = value[0];
	            hideTip("tipcls");
	             document.getElementById("showchidinhCLS").style.display = '';
	               document.getElementById("showDivCLS").style.display = '';    	           
    	            var t =  document.getElementById("listchidinhcanlamsan").innerHTML;
    	            var tenDVOld =   document.getElementById("tenDVCLSChuaThu").value;
    	            //document.getElementById("listchidinhcanlamsan").style.display='none';
	            document.getElementById("SoDongCLS").value = value[1];
    	           //document.getElementById("listchidinhcanlamsan").innerHTML = t.replace(tenDVOld,value[1]);
    	          
    	            document.getElementById("HuyCLS").style.display='';
	
            }
        }
        //var ChietKhau = document.getElementById('txtChietKhau').value;
        //var idbenhnhan = document.getElementById('txtidbenhnhan').value;
        var IdKhambenh= document.getElementById("txtidkham").value;
        ///////////////
        var slistdv = "";
	     var slistsoluong = "";
	     var slistdongia = "";
	     var slistbhchi = "";
	     var slistgiamgia = "";
	     var slistbacsi = "";
	      var slistBSCD = "";
	      var slistghichu = "";
	        var dk = document.getElementById("dkmenu");
	      
	      var slistChietKhau = "";
	      var slistThanhTien = "";
	     var osodong = document.getElementById("SoDongCLS");
	     //alert("osodong showKQ="+osodong.value);
	     for (var i = 1; i <= eval(osodong.value); i++)
         {
            var oiddichvu = document.getElementById('txtiddichvu_'+i);
            if (oiddichvu.value != "0")
            {
            
                slistdv = slistdv + oiddichvu.value + ",";
                var osoluong = document.getElementById("txtSoLuongCLS_"+i);
                if(osoluong.value=='') slistsoluong = slistsoluong + "1/";
                else
                slistsoluong = slistsoluong + osoluong.value + "/";
                var oghichu = document.getElementById("txtGhiChuCLS_"+i);
                if(oghichu.value !="")
                    slistghichu = slistghichu + oghichu.value + "/";
                else
                    slistghichu = slistghichu + " . /";
                var ogiadv = document.getElementById("txtDonGiaCLS_"+i);
                if(ogiadv.value=='') slistdongia = slistdongia + "0/";
                else
                    slistdongia = slistdongia + ogiadv.value + "/";
                var ogiamgia ="0";
                slistgiamgia = slistgiamgia + ogiamgia.value + "/";
                var obhchi = "0";
                slistbhchi = slistbhchi + obhchi.value + "/";
               
                var oChietKhau = document.getElementById("txtChietKhauCLS_"+i);
                if(oChietKhau.value=='') slistChietKhau = slistChietKhau + "0/";
                else
                    slistChietKhau = slistChietKhau + oChietKhau.value + "/";
                //slistChietKhau = slistChietKhau + "0/";
                var oThanhtien = document.getElementById("txtThanhTienCLS_"+i);
                //alert("oThanhtien="+oThanhtien.value+"oChietKhau="+oChietKhau.value);
                if(oThanhtien.value=='') slistThanhTien = slistThanhTien + "0/";
                else
                    slistThanhTien = slistThanhTien + oThanhtien.value + "/";
                //slistThanhTien = slistThanhTien +   ogiadv.value+ "/";
             }
         }
        //////////////////////
        var LoaiBN= document.getElementById("txtLoaiBN");// sau khi chọn cận lâm sàng
        var lastSL=document.getElementById("lastSL").value;
        var lastID=document.getElementById("lastID").value;
        var lastDG=document.getElementById("lastDG").value;
        var lastCK=document.getElementById("lastCK").value;
        var lastTT=document.getElementById("lastTT").value;
        var lastGC=document.getElementById("lastGC").value;
        //alert("slistThanhTien="+slistThanhTien);
        //alert("listIDCLS="+listIDCLS+",lastID="+lastID);
        //xmlHttp.open("GET","ajax.aspx?do=showKQCLS&IdKhambenh="+IdKhambenh+"&lastID="+lastID+"&lastSL="+lastSL+"&lastDG="+lastDG+"&lastCK="+lastCK+"&lastTT="+lastTT+"&lastGC="+encodeURIComponent(lastGC)+"&SoDongTruocDo="+osodong.value+"&listIdcls="+listIDCLS+"&LoaiBN="+LoaiBN.value+"&ListCLSOld="+slistdv+"&ListDonGia="+slistdongia+"&ListSoLuong="+slistsoluong+"&ListChietKhau="+slistChietKhau+"&ListTT="+slistThanhTien+"&ListGhiChu="+encodeURIComponent(slistghichu)+"&times="+Math.random() +"",true); /// sau khi đóng chọn cận lâm sàng
        xmlHttp.open("GET","ajax.aspx?do=showKQCLS_SoLuong&IdKhambenh="+IdKhambenh+"&lastID="+lastID+"&lastSL="+lastSL+"&lastDG="+lastDG+"&lastCK="+lastCK+"&lastTT="+lastTT+"&lastGC="+encodeURIComponent(lastGC)+"&SoDongTruocDo="+osodong.value+"&listIdcls="+listIDCLS+"&LoaiBN="+LoaiBN.value+"&ListCLSOld="+slistdv+"&ListDonGia="+slistdongia+"&ListSoLuong="+slistsoluong+"&ListChietKhau="+slistChietKhau+"&ListTT="+slistThanhTien+"&ListGhiChu="+encodeURIComponent(slistghichu)+"&times="+Math.random() +"",true); /// sau khi đóng chọn cận lâm sàng
        xmlHttp.send(null);
        }
        else
        {
        hideTip("tipcls");
	        document.getElementById("HuyCLS").style.display='none';//
	        document.getElementById("showchidinhCLS").style.display = 'none';
	        document.getElementById("showDivCLS").style.display = 'none'; 
        }
	 }	
	////End Hiển thị CLS có số lượng đã chọn
	  	function HienThiChiDinhCLS()
	{
	var idpkb = document.getElementById("idpkbCLS").value;
	var listID = document.getElementById('listIdDV').value;
	var listTN=document.getElementById("listTenNhom").value
	hideTip("tipcls");
    var td = document.getElementById("showtipCLS");
   var oidkhambenh = document.getElementById("txtidkham");
 //alert("danh sách dịch vụ cũ:"+listID);
     var oidbenhnhan = document.getElementById("txtidbn");     
 createTipFocus(td,"tipcls","danhsachDichVuCLS","Danh sách dịch vụ CLS","ajaxbenhnhanexists"," đang load danh sách DV CLS...","Lỗi trong quá trình load danh sách bệnh nhân","../khambenh/ajax.aspx?do=showDSCLS&listID="+listID+"&dautien=1&idpkb="+idpkb+"&tN=''&checkTN="+encodeURIComponent(listTN)+"&IdKhambenh="+oidkhambenh.value+"&IdBenhNhan="+oidbenhnhan.value, "750", "500",null);   
//    var obj = document.getElementById("showchidinhCLS");
//    var objCLS = document.getElementById("showDivCLS");
//	    
//	    if (obj.style.display == 'none' && objCLS.style.display == 'none')
//	    {
//	        obj.style.display = '';
//	      objCLS.style.display = '';
//	        }
if(document.getElementById('ddlHuongDieuTri').value=="" || document.getElementById('ddlHuongDieuTri').value=="0")
                document.getElementById('ddlHuongDieuTri').value="6";
	           //document.frmThamBenh.ddlHuongDieuTri.selectedIndex =9;
	            var btHuyCLS = document.getElementById("HuyCLS"); 
	        btHuyCLS.style.display = '';
	        var ThongTinCLS = document.getElementById("listchidinhcanlamsan"); 
	        ThongTinCLS.style.display = '';
	}
	function HuyChiDinhCLS()
	{
	    var obj = document.getElementById("showDivCLS");
	   
	        obj.style.display = 'none';
	         
	        var listcls = document.getElementById("listIdDV");
	        listcls.value = "";
	    var btHuyCLS = document.getElementById("HuyCLS"); 
	        btHuyCLS.style.display = 'none';
	        //reset giá trị 
	        document.getElementById("SoDongCLS").value="0";
	        document.getElementById("lastSL").value="";
    	            document.getElementById("lastID").value="";
    	            document.getElementById("lastDG").value="";
    	            document.getElementById("lastCK").value="";
    	            document.getElementById("lastTT").value="";
    	            document.getElementById("lastGC").value="";
	        
	        //var ThongTinCLS = document.getElementById("listchidinhcanlamsan"); 
	        //ThongTinCLS.style.display = 'none';
	        
	}
	function searchCLS(valueSearch)
	{
	var typeSearch=valueSearch;
	document.getElementById("idpkbCLS").value=valueSearch;
//	var radio = document.getElementsByName("rbnSearch");
//            for (var j = 0; j < radio.length; j++)
//            {
//                if (radio[j].checked)
//                {
//                    typeSearch = radio[j].value
//                }
//            }
    	var listID = document.getElementById('listIdDV').value;
	hideTip("tipcls");
 var td = document.getElementById("showtipCLS");
var listTN=document.getElementById("listTenNhom").value
 var idkb =document.getElementById("txtidkham").value;
    var oidbenhnhan = document.getElementById("txtidbn");  
 createTipFocus(td,"tipcls","danhsachDichVuCLS","Danh sách dịch vụ CLS","ajaxbenhnhanexists"," đang load danh sách DV CLS...","Lỗi trong quá trình load danh sách bệnh nhân","../khambenh/ajax.aspx?do=showDSCLS&listID="+listID+"&idpkb="+encodeURIComponent(typeSearch)+"&tN=''&checkTN="+encodeURIComponent(listTN)+"&IdKhambenh="+idkb +"&IdBenhNhan="+oidbenhnhan.value, "750", "500",null);           
            
	
	}
	function searchCLSByTenNhom(idpkb,valueSearch)
	{
	var listTN=document.getElementById("listTenNhom").value
	
	document.getElementById("idpkbCLS").value=idpkb;
	var tam =valueSearch;
	var typeSearch=idpkb;
//	var radio = document.getElementsByName("rbnSearch");
//            for (var j = 0; j < radio.length; j++)
//            {

//                if (radio[j].checked)
//                {
//                    typeSearch = radio[j].value
//                }
//            }
    	var listID = document.getElementById('listIdDV').value;
	hideTip("tipcls");
 var td = document.getElementById("showtipCLS");
  var oidbenhnhan = document.getElementById("txtidbn");       
 createTipFocus(td,"tipcls","danhsachDichVuCLS","Danh sách dịch vụ CLS","ajaxbenhnhanexists"," đang load danh sách DV CLS...","Lỗi trong quá trình load danh sách bệnh nhân","../khambenh/ajax.aspx?do=showDSCLS&listID="+listID+"&idpkb="+encodeURIComponent(typeSearch)+"&tN="+encodeURIComponent(valueSearch.value)+"&checkTN="+encodeURIComponent(listTN)+"&IdBenhNhan="+oidbenhnhan.value, "750", "520",tam);           
 
  //document.getElementById(tam).focus();
	
    }
    function searchNhomCLS(idbanggiadichvu)
    {
      document.getElementById('listIdDV').value= idbanggiadichvu;
      hideTip("tipcls");
    var td = document.getElementById("showtipCLS");
    createTipFocus(td,"tipcls","danhsachDichVuCLS","Danh sách dịch vụ CLS","ajaxbenhnhanexists"," đang load danh sách DV CLS...","Lỗi trong quá trình load danh sách bệnh nhân","../khambenh/ajax.aspx?do=showDSCLS&listID="+idbanggiadichvu+"&idpkb='0'&tN=''", "750", "520",null);           
 
    }
	function setAllDV(idbanggiadichvu,tenNhom,idPkb)
	{
	var tenNhomCheckAll;
	
	document.getElementById("listTenNhom").value= document.getElementById("listTenNhom").value+tenNhom+",";
	tenNhomCheckAll=document.getElementById("listTenNhom").value;
	
    document.getElementById('listIdDV').value=idbanggiadichvu;
	document.getElementById("idpkbCLS").value=idPkb;
	hideTip("tipcls");
    var td = document.getElementById("showtipCLS");
    createTipFocus(td,"tipcls","danhsachDichVuCLS","Danh sách dịch vụ CLS","ajaxbenhnhanexists"," đang load danh sách DV CLS...","Lỗi trong quá trình load danh sách bệnh nhân","../khambenh/ajax.aspx?do=showDSCLS&listID="+idbanggiadichvu+"&idpkb="+encodeURIComponent(idPkb)+"&tN="+encodeURIComponent(tenNhom)+"&checkTN="+encodeURIComponent(tenNhomCheckAll)+"", "750", "520",null);           

	}
	function setAllDichVuByTN(idbanggiadichvu,tenNhom,idPkb,idCheck)
	{
	var tenNhomCheckAll;
	if(idCheck.checked == true)
	{
	document.getElementById("listTenNhom").value= document.getElementById("listTenNhom").value+tenNhom+",";
	tenNhomCheckAll=document.getElementById("listTenNhom").value;
	}
	else
	{
	var tam =  document.getElementById('listTenNhom').value.replace(tenNhom +",","");
	document.getElementById('listTenNhom').value =tam;
	tenNhomCheckAll=tam;
	}
	
	var arrIDDV  = idbanggiadichvu.split(',');
	
	
	if(idCheck.checked == true)
	{
	for(var i =0 ;i<arrIDDV.length;i++)
	{
	   if(document.getElementById('listIdDV').value.indexOf(",")!=-1)
	    {
	        var dk = 0;
	        var arrTextIDDV = document.getElementById('listIdDV').value.split(',');
	        for(var j = 0 ; j<arrTextIDDV.length;j++)
	        {
	            if(arrIDDV[i]==arrTextIDDV[j])
	            {
        	    dk=1;
        	    break;
	            }
	            else
                {
                    dk = 0;
                }
	        }
	        if (dk == 1)
            {

            }
            else
            {
               document.getElementById('listIdDV').value=document.getElementById('listIdDV').value+arrIDDV[i]+",";
	            
            }
	    }
	    else
	    {
	    document.getElementById('listIdDV').value=document.getElementById('listIdDV').value+arrIDDV[i]+",";
	    }
	}
	}
	
	if(idCheck.checked == false)
	{
	if(document.getElementById('listIdDV').value.indexOf(",")!=-1)
	    {
	    	
	        var arrTextIDDV = document.getElementById('listIdDV').value.split(',');
	        var arrIDDV  = idbanggiadichvu.split(',');
	         document.getElementById('listIdDV').value="";
	        for(var j = 0 ; j<arrTextIDDV.length;j++)
	        {
	        
               var dk=0;
	            for(var i =0 ;i<arrIDDV.length;i++)
	            {
	           
	                if(arrTextIDDV[j]==arrIDDV[i])
	                {
        	       dk=1;
        	        break;
	                }
	                else
                    {
                    dk=0;
                        
                    }
	            }
	             if (dk == 1)
                {

                }
                else
                  {
	              document.getElementById('listIdDV').value =document.getElementById('listIdDV').value+ arrTextIDDV[j]+",";
	              }
	        }
	         
	    }
	}
	
	idbanggiadichvu=document.getElementById('listIdDV').value;
	document.getElementById("idpkbCLS").value=idPkb;
		hideTip("tipcls");
 var td = document.getElementById("showtipCLS");
 var oidkhambenh = document.getElementById("txtidkham");
 createTipFocus(td,"tipcls","danhsachDichVuCLS","Danh sách dịch vụ CLS","ajaxbenhnhanexists"," đang load danh sách DV CLS...","Lỗi trong quá trình load danh sách bệnh nhân","../khambenh/ajax.aspx?do=showDSCLS&IdKhambenh="+oidkhambenh.value+"&listID="+idbanggiadichvu+"&idpkb="+encodeURIComponent(idPkb)+"&tN="+encodeURIComponent(tenNhom)+"&checkTN="+encodeURIComponent(tenNhomCheckAll)+"", "750", "520",tenNhom);           

	}
	function setChonDichVuCLS(idbanggiadichvu,idCheck)
	{
	
	if(idCheck.checked == true || idCheck == true)
	{
	var strIDDV = document.getElementById('listIdDV').value;
	document.getElementById('listIdDV').value = strIDDV + idbanggiadichvu + ",";
	
	}
	else
	{
	
	  if(document.getElementById('listIdDV').value.indexOf(",")!=-1)
	    {
	    	
	    var arrIDDVDelete = document.getElementById('listIdDV').value.split(',');
	   document.getElementById('listIdDV').value="";
	        for(var i=0;i<arrIDDVDelete.length;i++)
	        {
	         
    	        if(arrIDDVDelete[i]==idbanggiadichvu)
    	        {
    	        }
    	        else
    	        {
    	         if(arrIDDVDelete[i]!="")
    	         {
    	        document.getElementById('listIdDV').value =document.getElementById('listIdDV').value+ arrIDDVDelete[i]+",";
    	        }
    	        }
    	        
	        }
	     
	    }
	    
	}
	//document.getElementById('divLuuCLS').style.display='';
	//document.getElementById('showKQ').focus();
	}

	function LoadCanLamSan(obj, curdong) 
	{
	    var objsrc = document.getElementById(obj);
	    var objcurdong = document.getElementById("ocurdongcls");
	    objcurdong.value = curdong;
	    var objshowtip = document.getElementById("listcanlamsan_"+curdong);
	    var objtip = document.getElementById("tipcls");
	    if (objtip != null || objtip != "undefined")
	        hideTip("tipcls");
	    
	    createTip(objshowtip,"tipcls","danhsachnoidungcanlamsan","Danh sách dịch vụ cận lâm sàng","ajaxdichvuexists"," đang load danh sách dịch vụ cận lâm sàng...","Lỗi trong quá trình load danh sách cận lâm sàng","ajax.aspx?do=getalldichvucls&tencls="+encodeURIComponent(objsrc.value), "750", "300");           
	}
	
	function setChonDichVu(idbanggiadichvu, tendichvu, giadichvu)
	{
	    var ocurdong = document.getElementById("ocurdongcls");
	    
	    var oiddichvu = document.getElementById("iddvcls_"+ocurdong.value);
	    oiddichvu.value = idbanggiadichvu;
	    var otendv = document.getElementById("txttencanlamsan_"+ocurdong.value);
	    otendv.value = tendichvu;
	    var ogiadv = document.getElementById("txtgiacls_"+ocurdong.value);
	    ogiadv.value = giadichvu;
	    hideTip("tipcls");  
	    
	}
	function DeleteCanLamSan(dong)
	{
	    var oiddichvu = document.getElementById("iddvcls_"+dong);
	    oiddichvu.value = "0";
	    var otendv = document.getElementById("txttencanlamsan_"+dong);
	    otendv.value = "";
	    var ogiadv = document.getElementById("txtgiacls_"+dong);
	    ogiadv.value = "";
	}
	function ThemDongCLS(dongtiep)
	{
	    var onext = document.getElementById("dong_" + dongtiep);
	    onext.style.display = '';
	}
	function HideDongCLS(dong)
	{
	    var onext = document.getElementById("dong_" + dong);
	    onext.style.display = 'none';
	}
	
	function ShowHuongDieuTri()
	{
	   var obj1 = document.getElementById("listphongkham");
	    var obj2 = document.getElementById("spText");
	    var obj3 = document.getElementById("toathuocmau");
	    var obj4 = document.getElementById("benhVienChuyenDen");
	    var objKhoaNhapVien = document.getElementById("KhoaNhapVien");
	    
	    var oinfotoathuoc = document.getElementById("infotoathuoc");
	    var olistpk = document.getElementById("ddlHuongDieuTri");
	    var cur= document.getElementById("curdong");
	   var sd= document.getElementById("sodong");
	    if(olistpk.value == "1" )
	    {
	    //alert("olistpk.value ==1");
	        obj1.style.display = '';
	        obj2.style.display = 'none';	
	        obj3.style.display = 'none';  
	        obj4.style.display = 'none';     
	        objKhoaNhapVien.style.display = 'none'; 
	        oinfotoathuoc.style.display = '';
	        return;
	          //  var obj = document.getElementById("showDivCLS");
	   
	       // obj.style.display = 'none';
	         
	       // var listcls = document.getElementById("listIdDV");
	       // listcls.value = "";
	    }
	    if ( olistpk.value == "8" )
	    {
	      //var obj = document.getElementById("showDivCLS");
	   
	        //obj.style.display = 'none';
	         
	        //var listcls = document.getElementById("listIdDV");
	        //listcls.value = "";
	        obj1.style.display = 'none';
	        obj2.style.display = 'none';
	        obj3.style.display = 'none';
	        obj4.style.display = 'none';
	        objKhoaNhapVien.style.display = '';
	        oinfotoathuoc.style.display = 'none';
	        
	    }
	    else if (olistpk.value == "2")
	    {
	        obj1.style.display = 'none';
	        obj2.style.display = 'none';	
	        obj3.style.display = '';  
	        obj4.style.display = 'none'; 
	        objKhoaNhapVien.style.display = 'none';     
	        oinfotoathuoc.style.display = '';
	           // var obj = document.getElementById("showDivCLS");
	   
	        //obj.style.display = 'none';
	          
	        //var listcls = document.getElementById("listIdDV");
	        //listcls.value = "";
	    }
	    else if(olistpk.value == "7" || olistpk.value == "9")
	    {
	    obj1.style.display = '';
	        obj2.style.display = 'none';	
	        obj3.style.display = '';  
	        obj4.style.display = 'none';     
	        objKhoaNhapVien.style.display = 'none'; 
	        oinfotoathuoc.style.display = '';
	          //  var obj = document.getElementById("showDivCLS");
	   
	       // obj.style.display = 'none';
	         
	       // var listcls = document.getElementById("listIdDV");
	       // listcls.value = "";
	    }
	    else if(olistpk.value == "6")
	    {
	     var obj = document.getElementById("showchidinhCLS");
	   
	        obj.style.display = '';
	        obj1.style.display = 'none';
	        obj2.style.display = '';
	        obj3.style.display = 'none';
	        obj4.style.display = 'none';
	        objKhoaNhapVien.style.display = 'none';
	        oinfotoathuoc.style.display = 'none';
	    }
	    else if(olistpk.value == "10")
	    {
	    
	      var obj = document.getElementById("showchidinhCLS");
	   
	        obj.style.display = '';
	     
	        obj1.style.display = 'none';
	        obj2.style.display = 'none';	
	        obj3.style.display = '';   
	        obj4.style.display = 'none';     
	        objKhoaNhapVien.style.display = 'none';
	        oinfotoathuoc.style.display = '';
	    }
	    else
	    {
	        obj1.style.display = 'none';
	        obj2.style.display = '';
	        obj3.style.display = 'none';
	        objKhoaNhapVien.style.display = 'none';
	        oinfotoathuoc.style.display = 'none';
	        if(olistpk.value == "4")
	        {
    	        obj4.style.display = ''; 
    	        obj2.style.display = 'none';
	        }
	      //var obj = document.getElementById("showDivCLS");
	   
	        //obj.style.display = 'none';
	         
	        //var listcls = document.getElementById("listIdDV");
	        //listcls.value = "";
	        var cur = document.getElementById("curdong");
	        cur.value=0;
	        
	    }
	}
	
	//Luu phieu kham benh
	function UpdatePhieuKhamBenh()
	{
	 
	    An("Button5",true);
	    var omabn = document.getElementById("txtMaBenhNhan");
	    if (omabn.value == "")
	    {
	        alert("Bạn chưa chọn bệnh nhân khám bệnh. Vui lòng kiểm tra lại.");
	        An("Button5",false);
	        return false;
	    }
	    var otrieuchung = document.getElementById("txtTrieuChung");
	    /*if (otrieuchung.value == "")
	    {
	        alert("Bạn chưa nhập phần triệu chứng của bệnh nhân. Vui lòng kiểm tra lại.");
	        otrieuchung.focus();
	        return false;	        
	    }*/
	    var ohuongdieutri = document.getElementById("ddlHuongDieuTri");
	    


//Khoe 0907
    if (ohuongdieutri.value == "")
	    {
	        alert("Bạn chưa chọn hướng giải quyết cho bệnh nhân. Vui lòng kiểm tra lại.");
	        ohuongdieutri.focus();
	        An("Button5",false);
	        return false;	        
	    }
	    if (ohuongdieutri.value == "2" || ohuongdieutri.value == "9" || ohuongdieutri.value == "10")
	    {
	        var chuanDoanXacDinh = document.getElementById("txtIdChanDoan_1");
	        if(chuanDoanXacDinh.value =="" || chuanDoanXacDinh.value =="0")
	        {
	        alert("Bạn chưa xác định chuẩn đoán cho bệnh nhân. Vui lòng kiểm tra lại.");
	        An("Button5",false);
	        chuanDoanXacDinh.focus();	        
	        return false;	        
	        }
	    }	
	    var ophongchuyenden="0";
	    var ophongKhamDen="0";
	     var oDVChuyenDen="0";
	    
	   if(ohuongdieutri.value == "1" || ohuongdieutri.value == "7" || ohuongdieutri.value == "9")
	   {
	        ophongchuyenden = document.getElementById("ddlPhongKhamBenh");
	        if (ophongchuyenden.value == "0" )
	        {
	            alert("Bạn chưa chọn khoa khám bệnh chuyển đến ! Vui lòng kiểm tra lại.");
	            ophongchuyenden.focus();
    	        An("Button5",false);
	            return false;	        
	        }
    	    
	        else
	        {
	            ophongKhamDen = document.getElementById("ddlPKBCD");
	            if(ophongKhamDen.value =="0" || ophongKhamDen.value =="" )
	            {
	                alert("Bạn chưa chọn Phòng khám chuyển đến ! Vui lòng kiểm tra lại.");
	                ophongKhamDen.focus();
	                An("Button5",false);
	                return false;
	            }
	            oDVChuyenDen=document.getElementById("ddlNdCD");
	            if(oDVChuyenDen.value =="0" || oDVChuyenDen.value =="" )
	            {
	                alert("Bạn chưa chọn dịch vụ chuyển đến! Vui lòng kiểm tra lại.");
	                oDVChuyenDen.focus();
	                An("Button5",false);
	                return false;
	            }
	        }
	    }
	   if(ohuongdieutri.value == "8" )
	   {
	        ophongchuyenden = document.getElementById("ddlKhoaNhapVien");
	        if (ophongchuyenden.value == "0" )
	        {
	            alert("Bạn chưa chọn khoa nhập viện ! Vui lòng kiểm tra lại.");
	            ophongchuyenden.focus();
    	        An("Button5",false);
	            return false;	        
	        }
	   }
	    //var ochidinhbacsi = document.getElementById("txtChiDinhBacSi");
	    var ochidinhbacsi ="";
	    var oghichuhdt = "";
	    if(ohuongdieutri.value == "5")
	    {
	        ochidinhbacsi = document.getElementById("txtHuongKhac").value;
	    }
	    //Khoe 1807
	    if(ohuongdieutri.value == "4")
	    {
	        //oghichuhdt = document.getElementById("txtBVChuyenDen").value;
	        oghichuhdt = document.getElementById("txtidBenhVien").value; 
	        if(oghichuhdt=="0" || oghichuhdt=="" || oghichuhdt==" ")
	        {
	        var tenBenhVien= document.getElementById("txtTenBenhVien").value;
	            if(tenBenhVien !="" && tenBenhVien !=" " && tenBenhVien !="  ")
	            {
	             var maBenhVien= document.getElementById("txtmaBenhVien").value;
	                if(maBenhVien!="" && maBenhVien!="  " && maBenhVien!="  ")
	                {
	                    var doconfirm= confirm('Bệnh Viện "'+tenBenhVien +'" chưa có trong danh mục. Bạn có muốn lưu vào danh mục không?');
                  
                        if(doconfirm)
                        {
                            //alert("Thuc hien them BV mới!");
                            luuBenhVienMoi(tenBenhVien,maBenhVien);
                            oghichuhdt="benhvienmoi";                         
                        }
                        else
                        {
                            alert("Vui lòng chọn bệnh viện chuyển đến ! ");
	                    document.getElementById("txtmaBenhVien").focus();
	                    An("Button5",false);
	                    return;
                        }
                    }
                    else
                    {
                        alert("Bạn chưa nhập Mã Bệnh Viện chuyển đến ! ");
	                    document.getElementById("txtmaBenhVien").focus();
	                    An("Button5",false);
	                    return;
                    }
	            }
	            else
	            {
	            alert("Bạn chưa chọn Bệnh Viện chuyển đến ! ");
	            document.getElementById("txtTenBenhVien").focus();
	            An("Button5",false);
	            return;
	            }
	        }	        
	    }
	    //End Khoe 1807	
//end Khoa 0907
	    var TienSuBenh = document.getElementById("txtTienSuBenh");
	    
	    var odando = document.getElementById("txtDanDo");
	    if (odando.value == "")
	    {
	    }
	    
	    var ocurdong = document.getElementById("curdong");
	   if(ohuongdieutri.value == "2" || ohuongdieutri.value == "7" || ohuongdieutri.value == "10")
	   {
	        if(ocurdong.value == "0")
	        {
	           // alert("Chưa nhập nội dung toa thuốc !.Vui lòng kiểm tra lại.");
	           // return false;
	        }
	        else
	        {
	       //Kiem tra Số ngày ra toa và số ngày hết hạn Bảo Hiểm
	        var ooloaiBN=  document.getElementById("txtLoaiBN").value;
	        if(ooloaiBN=="1")//nếu là bệnh nhân BH
	        {	        
	            var songayratoa = document.getElementById("txtSoNgayRaToa");
	            if(songayratoa.value =="0" || songayratoa.value =="")
	            {
	                alert("Số ngày ra toa không hợp lệ !Vui lòng kiểm tra lại.");
	                songayratoa.focus();
	                An("Button5",false);
	                return false;
	            }
	            var SoNgayBH = document.getElementById("txtSoNgayBH").value;
	            if(eval(SoNgayBH)< eval(songayratoa.value))
	            {
	                alert("Số ngày bảo hiểm còn lại của bệnh nhân "+document.getElementById("txtTenBenhNhan").value+"_"+document.getElementById("txtMaBenhNhan").value+" là "+SoNgayBH+" ngày < số ngày ra toa thuốc.Vui lòng giảm số ngày ra toa thuốc <= "+SoNgayBH+".");
	                songayratoa.focus();
	                An("Button5",false);
	                return false;
	            }
	        }
	        }
	        //End Kiem tra Số ngày ra toa và số ngày hết hạn Bảo Hiểm
	   }
	    //Kiểm tra hợp lệ thông tin toa thuốc
	    
	    if (ocurdong.value != "0")
	    {
	        for (var i = 1; i <=eval($("#thuochiep > tbody > tr:last").attr("id").split("_")[1]) ; i++)
	        {
	            debugger;
    	         var oidthuoc = document.getElementById("txtidthuoc_"+i);
    	        var otenthuoc = document.getElementById("txtthuoc_"+i);
	                var odvt = document.getElementById("txtdonvitinh_"+i);
	                var ocachdung = document.getElementById("txtcachdung_"+i);
	                var olandung = document.getElementById("txtlandung_"+i);
	                  var oluongdung = document.getElementById("txtluongdung_"+i);
	                  var odvtdung = document.getElementById("txtdonvidung_"+i);
	                   var oghichu = document.getElementById("txtghichu_"+i);
	                    var oheso = "0";///document.getElementById("txtheso_"+i);
    	     	        if((otenthuoc.value!="" && odvt.value=="") || (otenthuoc.value!="" && ocachdung.value=="") || (otenthuoc.value!="" && olandung.value=="") || (otenthuoc.value!="" && oluongdung.value=="") || (otenthuoc.value!="" && odvtdung.value==""))
    	        {
    	        alert("Bạn chưa nhập đầy đủ thông tin toa thuốc. Vui lòng kiểm tra lại.");
    	        An("Button5",false);
    	        return false;
    	        }
	            if (eval(oidthuoc.value) != 0 && oidthuoc.value != "")
	            {
	               
	                if (ocachdung.value == "")
	                {
	                    alert("Bạn chưa cho biết cách sử dụng thuốc. Vui lòng kiểm tra lại.");
	                    ocachdung.focus();
	                    An("Button5",false);
	                    return false;
	                }            	    
	                
	                if (olandung.value == "" || eval(olandung.value) == 0)
	                {
	                    alert("Bạn chưa cho biết số lượng mỗi lần dùng của thuốc. Vui lòng kiểm tra lại.");
	                    olandung.focus();
	                    An("Button5",false);
	                    return false;
	                }
	               
	                if (oluongdung.value == "" || eval(oluongdung.value) == 0)
	                {
	                    alert("Bạn chưa cho biết lượng dùng của thuốc. Vui lòng kiểm tra lại.");
	                    oluongdung.focus();
	                    An("Button5",false);
	                    return false;
	                }
	                
	                if (odvtdung.value == "")
	                {
	                    alert("Bạn chưa cho biết đơn vị dùng của thuốc. Vui lòng kiểm tra lại.");
	                    odvtdung.focus();
	                    An("Button5",false);
	                    return false;
	                }
	                
	            }    
	            //Kiêm Tra trùng thuốc Khoe 2807 
	            if(ocurdong.value > 1)  
	            {
	            var isTrungThuoc=0;
	                for (var j = 1; j < i; j++)
	                {	                
	                    if(document.getElementById("txtidthuoc_"+i).value ==document.getElementById("txtidthuoc_"+j).value)
	                    { isTrungThuoc=1;break; }
	                }
	                if(isTrungThuoc==1)
	                {
	                 var doconfirm= confirm('Thuốc "'+document.getElementById("txtthuoc_"+j).value +'" xuất hiện hơn một lần trong toa. Bạn có muốn tiếp tục lưu toa thuốc không?');
                  
                        if(doconfirm)
                        {                       
                        }
                        else//Người dùng chọn không lưu
                        {
                            An("Button5",false);
                            return;
                        }
                    }
	             }
	            //End Kiêm Tra trùng thuốc Khoe 2807   
	        }// end for i
	    }   //end Kiểm tra hợp lệ thông tin toa thuốc
	    var oidkhambenh = document.getElementById("txtidkham");
	    
	    var oidbn = document.getElementById("txtidbn");
	    var ongaykham = document.getElementById("txtNgayKham");
	    var osophieukham = document.getElementById("txtMaPhieuKham");
	    var ochandoanbandau = document.getElementById("txtChanDoanSoBo");
	    var ochandoan = document.getElementById("txtchandoan_1");
	    var oketluan = document.getElementById("txtIdChanDoan_1");
	    var omachandoan = document.getElementById("txtmachandoan_1");
	    
	    var ochandoan4 = document.getElementById("txtchandoan_4");
	    var oketluan4 = document.getElementById("txtIdChanDoan_4");
	    var omachandoan4 = document.getElementById("txtmachandoan_4");
	    	     
	    var kiemtra1=document.getElementById("txt_kiemtra1").value;
	    var kiemtra2=document.getElementById("txt_kiemtra2").value;
	    var oketluan1="0";
	    var ochandoan1="0";
	    var omachandoan1="0";
	    if(kiemtra1==1)
	    {
	        oketluan1 = "";
	        ochandoan1 = "";
	        omachandoan1 = "";
	    }      
	    var oketluan2="0";
	    var ochandoan2="0";
	    var omachandoan2="0";
	    if(kiemtra2==1)
	    {
	    	oketluan2 = "";
	        ochandoan2 = "";
	        omachandoan2 = "";
	    }
	    
	    var onoidungtaikham = document.getElementById("txtNoiDungTaiKham");
	    var ongaytk = document.getElementById("txtngayhen");
	    var obenhsu = document.getElementById("txtbenhsu");
	    var obj = document.getElementById("showstatus");
	    obj.style.display = '';
	    
	    
	    var IdBacSi = document.getElementById("ddBacSi");
	    
	    
	    CapNhatPhieuKhamBenh(oidkhambenh.value, oidbn.value,ongaykham.value, osophieukham.value, otrieuchung.value,
	     ochandoanbandau.value, oketluan.value, oketluan1, oketluan2, ohuongdieutri.value, 
	     ophongchuyenden.value,ophongKhamDen.value,oDVChuyenDen.value, oghichuhdt, ochidinhbacsi,
	      odando.value, onoidungtaikham.value, ongaytk.value,obenhsu.value,ochandoan.value,
	     ochandoan1,ochandoan2,omachandoan.value,omachandoan1,omachandoan2,TienSuBenh.value,omachandoan.value,oketluan4.value,ochandoan4.value,IdBacSi.value);
	     
	    //document.getElementById("Button5").style.display='none';
	   
	  
	}
	
	//Luu phieu kham benh xuong database
	function CapNhatPhieuKhamBenh(idkhambenh, idbn, ngaykham, sophieukham, trieuchung, chandoanbandau, ketluan, ketluan1, ketluan2, huongdieutri, khoachuyenden,phongchuyenden,dichvuchuyenden, ghichuhdt, chidinhbacsi,  dando, noidungtaikham, ngaytk,benhsu,ochandoan,ochandoan1,ochandoan2,omachandoan,omachandoan1,omachandoan2,TienSuBenh,machandoantuyenduoi,idchandoantuyenduoi,chandoantuyenduoi,IdBacSi)
	{
	    xmlHttp = GetMSXmlHttp();
	    
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if(eval(value) != 0)
                {
                   alert("Có lỗi xảy ra trong quá trình cập nhật thông tin phiếu khám bệnh. Vui lòng thử lại lần sau.");
                    An("Button5",false);
                   return false;
                }               

                  else
                {
                
                    var ocurdongtoathuoc = document.getElementById("curdong");
                    
	                 CapNhatToaThuocBenhNhan(idkhambenh,idbn,huongdieutri);
//	                var listidCLS = document.getElementById("listIdDV").value;
                    var osodong = document.getElementById("SoDongCLS");
                    //alert("SoDongCLS="+osodong.value);
                    //return;
                    //alert("osodong.value="+osodong.value);
//	                if(osodong.value !="0" && osodong.value !="")
//	                    {	             
	                        UpdateCDCLS(idkhambenh);
	                        document.getElementById("luuchidinhcls").value="1"; 
//	                    }
	                    Luuchandoanphoihop(idkhambenh);
	                ThongBaoTinhTrangLuuDuLieu();
                } 
                // Khoe 1807
            }
        }
          var  idpk=document.getElementById("ddlPK").value;
	var  idbs=document.getElementById("ddlBS").value;
          var giohen = document.getElementById("txtgiohen").value;
        xmlHttp.open("GET","ajax.aspx?do=updatephieukhambenh&idkhambenh="+idkhambenh+"&idbn="+idbn+"&ngaykham="+ngaykham+"&sophieukham="+sophieukham+"&trieuchung="+encodeURIComponent(trieuchung)+"&chandoanbandau="+encodeURIComponent(chandoanbandau)+"&ketluan="+ketluan+"&=ketluan1="+ketluan1+"&ketluan2="+ketluan2+"&huongdieutri="+huongdieutri+"&khoachuyenden="+khoachuyenden+"&phongchuyenden="+phongchuyenden+"&dichvuchuyenden="+dichvuchuyenden+"&ghichuhdt="+ghichuhdt+"&chidinhbacsi="+encodeURIComponent("0")+"&dando="+encodeURIComponent(dando)+"&noidungtaikham="+encodeURIComponent(noidungtaikham)+"&ngaytk="+ngaytk+"&benhsu="+encodeURIComponent(benhsu)+"&chandoan="+encodeURIComponent(ochandoan)+"&chandoan1="+encodeURIComponent(ochandoan1)+"&chandoan2="+encodeURIComponent(ochandoan2)+"&machandoan="+encodeURIComponent(omachandoan)+"&machandoan1="+encodeURIComponent(omachandoan1)+"&machandoan2="+encodeURIComponent(omachandoan2)+"&idbs="+idbs+"&idpk="+idpk+"&giohen="+giohen+"&times="+Math.random() +"&TienSuBenh="+encodeURIComponent(TienSuBenh)+"&chandoantuyenduoi="+encodeURIComponent(chandoantuyenduoi)+"&chandoantuyenduoiid="+idchandoantuyenduoi+"&chandoantuyenduoima="+machandoantuyenduoi+"&IdBacSi="+IdBacSi,true);
        xmlHttp.send(null);
	}
	
//	function UpdateCDCLS(idkhambenh)
//	{
//        var obj = document.getElementById("luuchidinhcls");
//        obj.value = "1";
//        var listidKBCLS = document.getElementById('listIDKBCLS').value; 
//       var ongaykham = document.getElementById("txtNgayKham");
//	   
//	   var listIdDV=  document.getElementById('listIdDV').value;
//	    xmlHttp = GetMSXmlHttp();
//        xmlHttp.onreadystatechange = function()
//        {
//            if(xmlHttp.readyState == 4)
//            {                
//               var value = xmlHttp.responseText;                
//            }
//        }
//        xmlHttp.open("GET","ajax.aspx?do=UpdateCDCLS&idkhambenh="+idkhambenh+"&idkhambenhcls="+listidKBCLS+"&listidcls="+listIdDV+"&ngaykham="+ongaykham.value+"&times="+Math.random(),true);
//        xmlHttp.send(null);
//	}
	function UpdateCDCLS(idkhambenh)
	{         
	    var khoa=document.getElementById("ddlPK");
       var ongaykham = document.getElementById("txtNgayKham");
	   var tinhTrangCapNhat =document.getElementById("statusCDCLS").value;
	   var listIdDV=  document.getElementById('listIdDV').value;
	   var arrIdCLS=document.getElementById('listIdDV').value.split(",");
	   var listSoLuongCLS ="";
	   var listGhiChuCLS ="";
         var slistdv = "";
	     var slistsoluong = "";
	     var slistdongia = "";
	     var slistbhchi = "";
	     var slistChietKhau = "";
	     var slistbacsi = "";
	      var slistBSCD = "";
	      var slistghichu = "";
	      var slistThanhTien = "";
       var osodong = document.getElementById("SoDongCLS");
       //alert("osodong="+osodong.value);
	     for (var i = 1; i <= eval(osodong.value); i++)
         {
            var oiddichvu = document.getElementById('txtiddichvu_'+i);
            if (oiddichvu.value != "0")
            {
            
                slistdv = slistdv + oiddichvu.value + ",";
                var osoluong = document.getElementById("txtSoLuongCLS_"+i).value.replace(/,/g,'');
                if(osoluong=='') slistsoluong = slistsoluong + "1/";
                else
                slistsoluong = slistsoluong + osoluong + "/";
                                
                var ogiadv = document.getElementById("txtDonGiaCLS_"+i).value.replace(/,/g,'');
                if(ogiadv=='') slistdongia = slistdongia + "0/";
                else
                slistdongia = slistdongia + ogiadv + "/";
               
                var oChietKhau = document.getElementById("txtChietKhauCLS_"+i).value.replace(/,/g,'');
                if(oChietKhau=='') slistChietKhau = slistChietKhau + "0/";
                else
                slistChietKhau = slistChietKhau + oChietKhau + "/";
                
                var oThanhtien = document.getElementById("txtThanhTienCLS_"+i).value.replace(/,/g,'');
                if(oThanhtien=='') slistThanhTien = slistThanhTien + "0/";
                else
                slistThanhTien = slistThanhTien + oThanhtien + "/";
                
                if(document.getElementById('txtGhiChuCLS_'+i).value !="")
	            listGhiChuCLS += document.getElementById('txtGhiChuCLS_'+i).value +"/";
	            else
	            listGhiChuCLS += "./";
             }
         }
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {                
               var value = xmlHttp.responseText; 
               if(eval(value) != 0)
               {
               }               
            }
        }
        //xmlHttp.open("GET","ajax.aspx?do=UpdateCDCLS&tinhtrang="+tinhTrangCapNhat+"&idkhambenh="+idkhambenh+"&listidcls="+listIdDV+"&listSoLuongCLS="+listSoLuongCLS+"&listGhiChuCLS="+encodeURIComponent(listGhiChuCLS)+"&ngaykham="+ongaykham.value+"&times="+Math.random(),true);
        //alert("&slistThanhTien="+slistThanhTien+"&slistChietKhau="+slistChietKhau);//return;
        xmlHttp.open("GET","../KhoaSan/ajax.aspx?do=UpdateCDCLS&tinhtrang="+tinhTrangCapNhat+"&idkhambenh="+idkhambenh+"&listidcls="+slistdv+"&listDonGiaCLS="+slistdongia+"&listSoLuongCLS="+slistsoluong+"&listChietKhauCLS="+slistChietKhau+"&listThanhTienCLS="+slistThanhTien+"&listGhiChuCLS="+encodeURIComponent(listGhiChuCLS)+"&ngaykham="+ongaykham.value+"&khoa="+khoa.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	
	function LuuChiDinhCanLanSan(idkhambenh)
	{
	   var slistiddichvucls = "";
	   var listIdDV=  document.getElementById('listIdDV').value;
	   
//	    for (var i = 1; i <= 5; i++)
//        {
//	        var oiddichvu = document.getElementById("iddvcls_"+i);
//            if (eval(oiddichvu.value) != 0 && oiddichvu.value != "")
//            {
//            
//                slistiddichvucls = slistiddichvucls + eval(oiddichvu.value) + "/";
//            }    
//        }
        SaveAsChiDinhCanLamSan(idkhambenh, listIdDV)
	}
	//Cap nhat chi dinh can lam san xuong database
	function SaveAsChiDinhCanLamSan(idkhambenh, slistiddichvucls)
	{
        var obj = document.getElementById("luuchidinhcls");
        obj.value = "1";
          var ongaykham = document.getElementById("txtNgayKham");
	    
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {                
               var value = xmlHttp.responseText;                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=saveasphieuchidinhcls&idkhambenh="+idkhambenh+"&listidcls="+slistiddichvucls+"&ngaykham="+ongaykham.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	
	function InPhieuChiDinhCLS()
	{
//	    var ocurdong = document.getElementById("ocurdongcls");
//	    if (ocurdong.value == "0")
//	    {
//	        alert("Bạn chưa ra phiếu chỉ định cận lâm sàn cho bệnh nhân. Vui lòng kiểm tra lại.");
//	        return false;
//	    }
        
	    var ocheksss = document.getElementById("luuchidinhcls"); 
	  
	    if(ocheksss.value == "")
	    {
	         alert("Bạn chưa lưu các chỉ định cận lâm sàng mới cho bệnh nhân. Vui lòng kiểm tra lại.");
	        return false;
	    }
	    else
	    {
            var oidkhambenh = document.getElementById("txtidkham").value;
	        window.open("../khambenh/inchidinhLamsan.aspx?idkhambenh="+oidkhambenh+"",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');	   
	    }
	}
	function InPhieuChiDinhCLS_Cu()
	{
	      var oidkhambenh = document.getElementById("txtidkham").value;
	      var listIdCLS_Old = document.getElementById("listIdDV_Old").value;//chi dinh CLS cũ
	        window.open("../khambenh/inchidinhLamsan.aspx?idkhambenh="+oidkhambenh+"&listIdClsCu="+listIdCLS_Old+"&TrangThaiThu=1",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');	   
	}//InPhieuChiDinhCLS_Cu
	
	
	//Luu toa thuoc 
	function CapNhatToaThuocBenhNhan(idkhambenh, idbenhnhan,huongdieutri)
	{
	    var slistidthuoc = "";
	   var slistidthuocmoi= "";
	    for (var i = 1; i <= eval($("#thuochiep > tbody > tr:last").attr("id").split("_")[1]) - 1; i++)
        {
	      
	      
            if (eval( document.getElementById("txtidthuoc_"+i).value) != 0 &&  document.getElementById("txtidthuoc_"+i).value != null)
            {
            var oidthuoc = document.getElementById("txtidthuoc_"+i);
            var sang=""; var trua="";var chiu="";var toi="";
                if(document.getElementById("chksang_"+i).checked ==true)
                {
                sang= "Sáng , ";
                }
                if(document.getElementById("chkTrua_"+i).checked ==true)
                {
                trua= "Trưa , ";
                }
                if(document.getElementById("chkChiu_"+i).checked ==true)
                {
                chiu ="Chiều , ";
                }
                if(document.getElementById("chkToi_"+i).checked ==true)
                {
                toi = "Tối ,";
                }
                var tenNgaydung;
              	var radio = document.getElementsByName("rblTenND_"+i);

                for (var j = 0; j < radio.length; j++)

                {

                if (radio[j].checked)
                {
                    tenNgaydung = radio[j].value;
                    
                }
                if(tenNgaydung=="undefined")
                    {
                     tenNgaydung="Ngày dùng";
                    }
                    
                }
            var tgdung = sang+trua+chiu+toi;
                 var idCT =  document.getElementById("idchitiettoathuoc_"+i);
               var olandung = document.getElementById("txtlandung_"+i);
                var oluongdung = document.getElementById("txtluongdung_"+i);
                var odvtdung = document.getElementById("txtdonvidung_"+i);
                var oghichu = document.getElementById("txtghichu_"+i);
                var osoluong = document.getElementById("txtsoluong_"+i);
                 var odvt = document.getElementById("txtdonvitinh_"+i);
	        var ocachdung = document.getElementById("txtcachdung_"+i);
	          var oTenthuoc = document.getElementById("txtthuoc_"+i);
	          //alert(oghichu.value);
                var oheso = "0";//document.getElementById("txtheso_"+i);
                slistidthuoc = slistidthuoc + eval(oidthuoc.value) + "^" + olandung.value + "^" + oluongdung.value + "^" + encodeURIComponent(odvtdung.value)+ "^" + encodeURIComponent(oghichu.value) + "^" + osoluong.value +"^"+encodeURIComponent(tgdung)+"^"+ idCT.value + "^" + encodeURIComponent(oTenthuoc.value) + "^" + encodeURIComponent(odvt.value) + "^" + encodeURIComponent(ocachdung.value)+ "^"+encodeURIComponent(tenNgaydung)+"^"+ eval(oheso) +"@";

            }    
           
               
        }
        CapNhatToaThuoc(idkhambenh, slistidthuoc, idbenhnhan,huongdieutri)
	}
	
	//Lưu toa thuốc xuống database
	function CapNhatToaThuoc(idkhambenh, slistidthuoc, idbenhnhan,huongdieutri)
	{
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {

            
            }
        }
         var  idpk=document.getElementById("ddlPK").value;
	            var  idbs=document.getElementById("ddlBS").value;
	            //alert("huongdieutri="+huongdieutri);
        xmlHttp.open("GET","ajax.aspx?do=updatetoathuoc&huongdieutri="+huongdieutri+"&idkhambenh="+idkhambenh+"&slistidthuoc="+slistidthuoc+"&idbenhnhan="+idbenhnhan+"&idbs="+idbs+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	
	function ThongBaoTinhTrangLuuDuLieu()
	{
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("showstatus");
	            obj.style.display = 'none';
                if(eval(value) != 0)
                {
                    alert("Có lỗi xảy ra trong quá trình cập nhật thông tin phiếu khám bệnh. Vui lòng thử lại lần sau.");
                    return false;
                } 
                else
                {                    
                    var txtidbn = document.getElementById("txtidbn").value;
                    alert("Đã cập nhật thông tin phiếu khám bệnh thành công.");
                    var btIntoathuoc=document.getElementById("Button6");
                    btIntoathuoc.style.display='inline';
                    btIntoathuoc.focus();
                    //document.location.href = "../khambenh/frm_Edit_DSBNdakham.aspx?idbenhnhan="+txtidbn;
                }
                An("Button5",false);

            }
        }
        xmlHttp.open("GET","ajax.aspx?do=checktinhtrangluu"+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	
	function InToaThuoc()
	{
	var oidkhambenh = document.getElementById("txtidkham");
	
	   // window.open("../khambenh/IntoathuocRP.aspx?IdKhamBenh="+oidkhambenh.value);
	    window.open("../khambenh/IntoathuocRP.aspx?IdKhamBenh="+oidkhambenh.value,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');  
	}
	
function SetNullIDBV()
    {
        var maBV = document.getElementById("txtidBenhVien");
        maBV.value="0";
    }
	
	
//Khoe 2907
 function LoadNoiDungChuyenDen()
 {
   var ddlNdCD = document.getElementById('ddlNdCD');
    var ddlPKBCD = document.getElementById('ddlPKBCD');
    //removeall option ddlNdCD
    for(i=ddlNdCD.length-1; i>=0; i--)
    {
        ddlNdCD.remove(i);
    }
    //removeall option ddlPKBCD
    for(i=ddlPKBCD.length-1; i>=0; i--)
    {
        ddlPKBCD.remove(i);
    }
    // Load noi dung moi
    var IdKhoaChuyenDen= document.getElementById('ddlPhongKhamBenh').value;
       if(IdKhoaChuyenDen =="0")
       {
        return;
       }
            xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
	                if(value != "0" && value != "")
                    {
                       var arrTable= value.split("@");
                       if(arrTable[0] != "")
                       {
                       //Load noi dung kham
                            var arrRow=arrTable[0].split(";");
                            if(arrRow.length >0)
                            {
                                for(var i=0;i<arrRow.length-1;i++)//for (var i = 0; i < children.length; i++) {
                                {
                                    var arrColumns=arrRow[i].split(",");
                                    var newOption = document.createElement("option");
                                    newOption.text = arrColumns[1];
                                    newOption.value = arrColumns[0];
                                    ddlNdCD.options.add(newOption);
                                }
                                if(window.event.type=="" ||window.event.type==null){                                    
                                    if(idNDCD!="0" && idNDCD!="") ddlNdCD.value=idNDCD;
                                    idNDCD="0";
                                }else ddlNdCD.selectedIndex=0;
                            }
                        
                       }// end if(arrTable[0] != "")
                       
                       if(arrTable[1] != "")
                       {
                        // Load combo Phong
                         var arrRow=arrTable[1].split(";");
                            if(arrRow.length >0)
                            {
                                for(var i=0;i<arrRow.length-1;i++)//for (var i = 0; i < children.length; i++) {
                                {
                                    var arrColumns=arrRow[i].split(",");
                                    var newOption = document.createElement("option");
                                    newOption.text = arrColumns[1];
                                    newOption.value = arrColumns[0];
                                    ddlPKBCD.options.add(newOption);
                                }
                                if(window.event.type=="" ||window.event.type==null)
                                {                                
                                    if(idPCD!="0" && idPCD!="") ddlPKBCD.value=idPCD;
                                    idPCD="0";
                                }
                            }
                       }
                    }
                    else if( value == "")
                    {
                        
                    }
                    else
                    {
                        alert("Lỗi khi load nội dung combo!");
                    } 
                }
            }
             var LoaiBN = document.getElementById('txtLoaiBN').value;
            xmlHttp.open("GET","../khambenh/thambenhentry_Ajax.aspx?do=LoadComboContent&IdKhoa=" + IdKhoaChuyenDen + "&LoaiBN="+LoaiBN+"&TableName=banggiadichvu&IdName=idbanggiadichvu&TextName=tendichvu&NDCD="+idNDCD,false);
            xmlHttp.send(null);
}

function LoadPhongKhamChuyenDen()
 { 
    var ddlNdCD = document.getElementById('ddlNdCD').value;
    var ddlPKBCD = document.getElementById('ddlPKBCD');
    //removeall option ddlNdCD
    for(i=ddlPKBCD.length-1; i>=0; i--)
    {
        ddlPKBCD.remove(i);
    }
    if(ddlNdCD =="0")
       {
        return;
       }
       xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
	                if(value != "0")
                    {
                       //Load noi Phong kham
                            var arrRow=value.split(";");
                            if(arrRow.length >0)
                            {
                                for(var i=0;i<arrRow.length-1;i++)//for (var i = 0; i < children.length; i++) {
                                {
                                    var arrColumns=arrRow[i].split(",");
                                    var newOption = document.createElement("option");
                                    newOption.text = arrColumns[1];
                                    newOption.value = arrColumns[0];
                                    ddlPKBCD.options.add(newOption);
                                }
                                if(window.event.type=="" ||window.event.type==null)
                                {                                    
                                    if(idPCD!="0" && idPCD!="") ddlPKBCD.value=idPCD;
                                    idPCD="0";
                                 }
                            }
                    }else
                    {
                        alert("Lỗi khi load nội dung combo!");
                    } 
                }
            }
             var LoaiBN = document.getElementById('txtLoaiBN').value;
            xmlHttp.open("GET","../khambenh/thambenhentry_Ajax.aspx?do=LoadComboContent&idNoiDungKham=" + ddlNdCD + "&LoaiBN="+LoaiBN+"&TableName=kb_phong&IdName=id&TextName=tenphong&times="+Math.random(),true);
            xmlHttp.send(null);
 }
 //and Khoe 2907	
</script>

<script type="text/javascript">
function isNumber(field) 
  {
var re = /^[0-9-'.'-',']*$/;
if (!re.test(field.value)) {
//alert('Value must be all numberic charcters, including "." or "," non numerics will be removed from field!');
field.value = field.value.replace(/[^0-9-'.'-',']/g,"");
}
}


function LoadtoaThuocMau()
    {
        var obbenhly = document.getElementById("ddlbenhlymau");
        var ddlReport = document.getElementById("<%=ddlbenhlymau.ClientID%>"); 
        var txtchandoan_1 = document.getElementById("txtchandoan_1");
        txtchandoan_1.value=ddlReport.options[ddlReport.selectedIndex].text;
        var ddGhiChuBenhLy = document.getElementById("ddGhiChuBenhLy");
        ddGhiChuBenhLy.value= obbenhly.value;
        var ddlReport1 = document.getElementById("<%=ddGhiChuBenhLy.ClientID%>"); 
        var txtDanDo = document.getElementById("txtDanDo");
        txtDanDo.value=ddlReport1.options[ddlReport1.selectedIndex].text;
        
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
	            if(value != "")
                {
                    var oinfotoathuoc = document.getElementById("thongtintoathuoc");
                    oinfotoathuoc.innerHTML = value;
                } 
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loadnoidungtoathuocmau&idtoathuocmau=" + obbenhly.value + "&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    function inPH()
   {
   var ongaytk = document.getElementById("txtngayhen");
   if(ongaytk.value!="")
   {
    window.open("../khambenh/phieuHenTK.aspx",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');	
    }
    else
    {
    alert("Bạn chưa nhập ngày tái khám. Vui lòng kiểm tra lại");
    }
   }
   function InGiayChuyenVien()
    {
        var idBN= document.getElementById('txtidbn').value;        
        if(idBN!='undefined')
            if(idBN.value!='0')        
                window.open("frmGiayChuyenVien.aspx?idbn="+idBN);
        else{ 
            alert('Bạn chưa chọn bệnh nhân');
            return;
        }
    }
</script>
<style>
 .button{
    width: 147px; background-color:silver; border-top-width: 1px; border-right: 1px; border-left: 1px; border-bottom: 1px;display:none;
 }
</style>
</head>
<body>
<form id="frmThamBenh" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

     <ajaxToolkit:AutoCompleteExtender ID="autocompleteextender1" runat="server" ServicePath="../WebService.asmx" 
    MinimumPrefixLength="1" CompletionInterval="1000" 
    ServiceMethod="getICD" TargetControlID="txtchandoan_1" FirstRowSelected="false"
    CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem"
        OnClientItemSelected="AutoComlete_Selected" OnClientPopulating="ShowImage" 
        OnClientPopulated="HideImage"
         CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </ajaxToolkit:AutoCompleteExtender>
    
    <ajaxToolkit:AutoCompleteExtender ID="autocompleteextender2" runat="server" ServicePath="../WebService.asmx" 
    MinimumPrefixLength="1" CompletionInterval="1000" 
    ServiceMethod="getMaICD" TargetControlID="txtmachandoan_1" FirstRowSelected="false"
    CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem"
        OnClientItemSelected="AutoComlete_Selected" OnClientPopulating="ShowImage" 
        OnClientPopulated="HideImage"
         CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </ajaxToolkit:AutoCompleteExtender>
    
    <ajaxToolkit:AutoCompleteExtender ID="autocompleteextenderBenhVien" runat="server" ServicePath="../WebService.asmx" 
    MinimumPrefixLength="1" CompletionInterval="1000" 
    ServiceMethod="getTenBenhVien" TargetControlID="txtTenBenhVien" FirstRowSelected="false"
    CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem"
        OnClientItemSelected="AutoComlete_SelectedBenhVien" OnClientPopulating="ShowImageTenBV" 
        OnClientPopulated="HideImageTenBenhVien"
         CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </ajaxToolkit:AutoCompleteExtender>
    <ajaxToolkit:AutoCompleteExtender ID="autocompleteextenderMaBV" runat="server" ServicePath="../WebService.asmx" 
    MinimumPrefixLength="1" CompletionInterval="1000" 
    ServiceMethod="getMaBenhVien" TargetControlID="txtmaBenhVien" FirstRowSelected="false"
    CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem"
        OnClientItemSelected="AutoComlete_SelectedBenhVien" OnClientPopulating="ShowImageMaBV" 
        OnClientPopulated="HideImageMaBenhVien"
         CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </ajaxToolkit:AutoCompleteExtender>
    <ajaxToolkit:AutoCompleteExtender ID="autocompleteextender8" runat="server" ServicePath="../WebService.asmx" 
    MinimumPrefixLength="1" CompletionInterval="1000" 
    ServiceMethod="getICD" TargetControlID="txtchandoan_4" FirstRowSelected="false"
    CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem"
        OnClientItemSelected="AutoComlete_Selected" OnClientPopulating="ShowImage" 
        OnClientPopulated="HideImage"
         CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </ajaxToolkit:AutoCompleteExtender>
    <ajaxToolkit:AutoCompleteExtender ID="autocompleteextender7" runat="server" ServicePath="../WebService.asmx" 
    MinimumPrefixLength="1" CompletionInterval="1000" 
    ServiceMethod="getMaICD" TargetControlID="txtmachandoan_4" FirstRowSelected="false"
    CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem"
        OnClientItemSelected="AutoComlete_Selected" OnClientPopulating="ShowImage" 
        OnClientPopulated="HideImage"
         CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </ajaxToolkit:AutoCompleteExtender>
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#D4D0C8; height: 10px;">
              <asp:placeholder ID="PlaceHolder1" runat="server"></asp:placeholder>
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "center" style ="background-color:#D4D0C8">
        <table cellspacing="1" cellpadding="1" width="98%" border="0" class = "khung">
	    <tr>
		    <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px; height: 1013px;">
		     
			    <table id="user" cellSpacing="0" cellPadding="0" width="100%" border="0">
				    <tr>
				        <td class="title" colspan = "2" align = "center" style ="background-color: #4D67A2">
					        <p class="title" style ="color:#FFFFFF">PHIẾU KHÁM BỆNH</p>
				        </td>
			        </tr>
			        <tr>
			        <td colspan="2"><asp:updatepanel runat="server" id="updatepanel1">
					     <ContentTemplate>
						    
                            Nội dung khám : 
                            <asp:dropdownlist id="ddlnd" autopostback="true"  runat="server" OnSelectedIndexChanged="ddlnd_SelectedIndexChanged" ></asp:dropdownlist>
                            &nbsp; &nbsp;&nbsp;
                            Phòng Khám :
                            <asp:dropdownlist id="ddlphongkhamdo" autopostback="true"  runat="server" ></asp:dropdownlist>
                            
                            
                       
                        </ContentTemplate>
                        </asp:updatepanel></td>
			        </tr>
			        <tr>
					    <td style="padding-top:10px; width:12%; padding-left:20px; height: 29px;"  align = "left">
						    <span class="ptext">Mã bệnh nhân</span> :</td>
					    <td style="padding-top:2px; width:85%; height: 29px;" align = "left">
					        <asp:textbox id="txtMaBenhNhan" runat="server" Width="118px" TabIndex="1"></asp:textbox>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  Tên BN:&nbsp;  &nbsp; &nbsp; &nbsp;<asp:textbox id="txtTenBenhNhan" runat="server" Width="231px" TabIndex="4"></asp:textbox>
                                &nbsp;
                                &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                            <input type = "hidden" id="txtidkham" runat="server"/>
                            <input type = "hidden" id="txtidbn" runat="server"/>
                            <input type = "hidden" id="txtLoaiBN" runat="server"/>
                            <input type = "hidden" id="hdidchitietdangkykham" runat="server"/>
                            <input type="hidden" value="0" name="hdIdTamUng" id="hdIdTamUng"/> <%--Khoe--%> 
                            </td>
				    </tr>
				    <tr>
					    <td style="padding-top:2px; padding-left:20px; width:12%" align = "left">
						    <span class="ptext"></span>Mã phiếu khám :&nbsp;
					    </td>
					    <td style ="padding-top:2px; width:85%" align = "left">
						    <span class="ptext"> <asp:textbox id="txtMaPhieuKham" runat="server" Width="118px" TabIndex="4"></asp:textbox>&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; Ngày khám :<asp:textbox id="txtNgayKham" runat="server" Width="118px" TabIndex="3"></asp:textbox>
                                &nbsp; Bác sĩ :
                                <asp:DropDownList ID="ddBacSi" runat="server" Width="213px">
                                </asp:DropDownList></span></td>
				    </tr>
				    
				    <tr>
					    <td style="padding-top:2px; width:12%; padding-left:20px"  align = "left">
						    <span class="ptext">Năm sinh :</span></td>
					    <td style ="padding-top:2px; width:85%" align = "left">
						    <span class="ptext">
                                <asp:textbox id="txtTuoi" runat="server" tabindex="5" width="47px"></asp:textbox>
                            &nbsp; &nbsp;Giới tính&nbsp;
                                <asp:textbox id="txtGioiTinh" runat="server" tabindex="6" width="58px"></asp:textbox>&nbsp;Số BHYT <asp:textbox id="txtSoBHYT" runat="server" tabindex="7" width="118px"></asp:textbox>
                                &nbsp; Ngày HH
                                <asp:textbox id="txtNgayHH" runat="server" tabindex="8" width="115px" ></asp:textbox>
                                &nbsp; Số ĐT 
                                <asp:textbox id="txtSoDTBN" runat="server" tabindex="9" width="115px"></asp:textbox>
                                &nbsp;
                            </span>
                        </td>
				    </tr>
				    <tr>
					    <td style="padding-top:2px; width:12%; padding-left:20px"  align = "left">
						    <span class="ptext">Địa chỉ</span> :</td>
					    <td style ="padding-top:2px; width:85%" align = "left">
						    <span class="ptext"><asp:textbox id="txtDiaChi" runat="server" Width="640px" TabIndex="9"></asp:textbox>
                            </span></td>
				    </tr>
				    <tr>
					    <td style="padding-top:2px; width:14%; padding-left:20px"  align = "left" >
						    <span class="ptext">Tiền sử</span>
					    </td>
					    <td style ="padding-top:2px; width:85%" align = "left">
						    <span class="ptext"><asp:textbox id="txtTienSuBenh" runat="server" Width="763px" Height="47px" TextMode="MultiLine"></asp:textbox>
                            </span></td>
				    </tr>
				    
				    <tr>
					   <td style="padding-top:2px; width:15%; padding-left:20px; height: 53px;"  align = "left" valign = "top">
						    <span class="ptext">Bệnh sử</span>
					    </td>
					    <td style="padding-top:2px; width:85%; height: 53px;" align = "left" valign = "top">
					        
						     <table width = "100%" cellpadding = "0" cellspacing = "0" border = "0">
					            <tr>
					                <td style="width: 350px; height: 17px" valign = "top">
                                       <span class="ptext"><asp:textbox id="txtTrieuChung" runat="server" height="134px" Text="" textmode="MultiLine" width="352px"></asp:textbox>
                            </span>
                                    </td>
					                <td style="height: 17px; padding-left:5px" valign = "top">
					                    <span class = "ptext">
					                        <fieldset style="padding:2; width:88%; border:1.5px; border-color:Blue"><legend>Thông tin sinh hiệu &nbsp;</legend>
				                                <span id = "infosinhhieu"></span>                                					
			                                </fieldset>
					                    </span>
					                </td>
					            </tr>
					        </table>
					       
					       
						</td>
				    </tr>
				    <tr>
				      <td style="padding-top:2px; width:15%; padding-left:20px"  align = "left">
						    <span class="ptext">Thăm khám</span>
					    </td>
					    <td style ="padding-top:2px; width:85%" align = "left">
						    <table width = "100%" cellpadding = "0" cellspacing = "0" border = "0">
					            <tr>
					                <td style="width: 350px; height: 17px" valign = "top">
                                        <asp:textbox id="txtbenhsu" runat="server" height="134px" Text="" textmode="MultiLine" width="756px"></asp:textbox>
                                    </td>
					                
					            </tr>
					        </table>
						    </td>
					   
				    </tr>
				    
				    
				    <tr>
					    <td style="padding-top:2px; width:12%; padding-left:20px"  align = "left">
						    <span class="ptext"></span>
                            <asp:label id="Label1" runat="server" Text ="Chẩn đoán sơ bộ :" width="123px"></asp:label>
                            <br />
                             <span class="ptext" >Thông tin CLS</span>
					    </td>
					    <td style ="padding-top:2px; width:85%" align = "left">
						    <span class="ptext"><asp:textbox id="txtChanDoanSoBo" runat="server" Width="640px" TabIndex="9"></asp:textbox>
						    <br />
						    <asp:textbox id="timkiemCLS"  runat="server" Width="640px" onfocus="timkiemCLSS()"  ></asp:textbox>
                                &nbsp;<input type="button" id="btnUpdateChiDinhCls" style="width: 112px; background-color:ButtonHighlight; border-top-width: 1px; border-right: 1px; border-left: 1px; border-bottom: 1px; cursor:pointer;display:none" onclick = "HienThiChiDinhCLS()"  value="Sửa chỉ định cls"/>
                                
                                <input type="button" id="btnInsertNewCLS" style="width: 112px; background-color:ButtonHighlight; border-top-width: 1px; border-right: 1px; border-left: 1px; border-bottom: 1px; cursor:pointer;display:none" value="Chỉ định cls" onclick = "HienThiChiDinhCLS()"/>
                               
                            </span>
                             <div id="divLuuCLS" style="display:none">	<%--<input type="button" id="showKQ" name="showKQ" value="." onclick="showKQCLS();" />			            --%>
											</div>
                            </td>
                             
				    </tr>
				    <tr>
				    <td style="padding-top:2px; width:12%; padding-left:20px"  align = "left"></td>
				    <td valign="top"  align="left" style="height: 20px;" colspan = "2" id = "showtipCLS">
											
                                                                    </td>
				    </tr>
				        				  				  
				    <tr>
	                    <td id="popupTamUng" align = "left" valign = "top" style="width:12%; padding-left:20px; padding-top:2px; height: 21px;">
	                        <span class = "ptext">Chỉ định CLS cũ </span>
	                    </td>
	                    <td  style="width:85%; padding-top:2px; height: 21px;" align = "left">
	                         <div id="showDivCLS" style="overflow:auto;height:300px;display:none">
				        <span id = "showchidinhCLS" style="display:none"></span>     
				       </div>
	                        <span class="ptext" id = "listchidinhcanlamsan"></span>
	                        
	                    </td>
	                </tr>
	                <tr >
				     <td style="padding-top:2px; width:14%; padding-left:20px"  align = "left">
				      
				       </td> 
				       <td style="padding-top:2px; width:883px" align = "right">
				       <div id="HuyCLS" style="display:none">
				      <input id="Buttonn" style="display:none;width: 112px; background-color:ButtonHighlight;color:Red; border-top-width: 1px; border-right: 1px; border-left: 1px; border-bottom: 1px; cursor:pointer;display:" type="button" value="Hủy Chỉ định CLS" onclick = "HuyChiDinhCLS()" />
				       </div>
				       </td>
				    </tr>
	                <tr id = "dong_2">
                        <td align = "left" valign = "top" style="width:12%; padding-left:20px; padding-top:2px; height: 21px;">
                            <span class = "ptext">Kết quả CLS</span>
                        </td>
                        <td  style="width:85%; padding-top:2px; height: 21px;" align = "left">
                            <span class="ptext" id = "ketquacanlamsan">
                            </span>
                        </td>
                    </tr>
                    <tr>
					    <td style="padding-top:2px; width:14%; padding-left:20px; height: 26px;"  align = "left">
						    <span class="ptext">Chẩn đoán tuyến dưới</span></td>
					    <td style="padding-top:2px; width:882px; height: 26px;" align = "left" id = "Td3">
						    <span class="ptext"><input type = "hidden" id = "txtIdChanDoan_4" value = "0" /><asp:textbox  id="txtchandoan_4" runat="server" Width="435px" onfocus="xacdinh('4','txtchandoan_4')" ></asp:textbox>
                               
                                <asp:textbox id="txtmachandoan_4" runat="server" width="56px" onfocus="xacdinh('4','txtmachandoan_4')" onblur="checkICD('txtchandoan_4','txtmachandoan_4','txtIdChanDoan_4');"></asp:textbox>
                                (theo ICD10)
                                </span></td>
				    </tr>
				    <tr>
					    <td style="padding-top:2px; width:14%; padding-left:20px; height: 26px;"  align = "left">
						    <span class="ptext">Chẩn đoán xác định</span></td>
					    <td style="padding-top:2px; width:882px; height: 26px;" align = "left" id = "listchandoan_1">
						    <span class="ptext"><input type = "hidden" id = "txtIdChanDoan_1" value = "0" /><asp:textbox  id="txtchandoan_1" runat="server" Width="435px" onfocus="xacdinh('1','txtchandoan_1')" ></asp:textbox>
                               
                                <asp:textbox id="txtmachandoan_1" runat="server" width="56px" onfocus="xacdinh('1','txtmachandoan_1')" onblur="checkICD('txtchandoan_1','txtmachandoan_1','txtIdChanDoan_1');"></asp:textbox>
                                <%--<input id="Button2" style="width: 112px; background-color:silver; border-top-width: 1px; border-right: 1px; border-left: 1px; border-bottom: 1px;" type="button" value="Tra cứu ICD 10"/>--%>
                                (theo ICD10)
                          <%--      <input type="button" value="Ẩn DS" onclick="LoadChanDoanICD10('txtchandoan_1', '1')"/>
                                <input type="hidden" value="" id="txtAnHien"/>--%>
                                </span></td>
				    </tr>
				     <tr>
					    <td style="padding-top:2px; width:14%; padding-left:20px; "  align = "left">
						    <span class="ptext">
                                <asp:label id="lblCDPB2" runat="server"></asp:label>
                            </span></td>
					    <td style="padding-top:2px; width:882px;" align = "left" id = "listchandoan_3">
						    <span class="ptext"><input type = "hidden" id = "txtIdChanDoan_3" value = "0" /><asp:textbox id="txtchandoan_3" runat="server" Width="435px" onfocus="LoadChanDoanICD10('txtchandoan_3', '3')" ></asp:textbox>
                                <asp:textbox id="txtmachandoan_3" runat="server" width="56px" onfocus="LoadChanDoanICD10('txtmachandoan_3', '3')" onblur="checkICD('txtchandoan_3','txtmachandoan_3','txtIdChanDoan_3');" ></asp:textbox>
                                <asp:label id="lb2" runat="server" text="(theo ICD10)"></asp:label>
                            </span></td>
				    </tr>
				    <tr align="center">
				        <td colspan="2">
				            <table id="chandoanicd10_1" border="1" style="display:none" >
				                <tr bgcolor="#0066ff" style="font-weight:bolder;color:White">
				                    <td></td>
				                    <td>
				                        Mã ICD
				                    </td>
				                    <td>
				                        Mô tả
				                    </td>
				                </tr>
				            </table>
				        </td>
				    </tr>
				    <tr>
					    <td style="padding-top:2px; width:12%; padding-left:20px; height: 27px;"  align = "left">
						    <span class="ptext"><label id="lbHuongDieuTri" runat="server" ></label></span>
					    </td>
					    <td style="padding-top:2px; width:85%; height: 27px;" align = "left">
						    <span class="ptext" id = "ohuongdieutri">
						    <asp:dropdownlist id="ddlHuongDieuTri" runat="server" width="200px"  onchange = "ShowHuongDieuTri()"><asp:ListItem>Chọn Hướng giải quyết</asp:ListItem>
                   <asp:ListItem Value="2">Ra toa thuốc</asp:ListItem>
						    <asp:ListItem Value="4">Chuyển viện</asp:ListItem>
						    <%--<asp:ListItem Value="1">Khám thêm chuyên khoa khác</asp:ListItem>
                            <asp:ListItem Value="8">Đề nghị khám thêm khoa khác</asp:ListItem>
                             <asp:ListItem Value="7">Toa về - khám thêm chuyên khoa</asp:ListItem>
						     <asp:ListItem Value="9">Toa về - đề nghị khám thêm chuyên khoa khác</asp:ListItem>--%>
						     
						     <asp:ListItem Value="1">Chuyển phòng KTP</asp:ListItem>
						    <asp:ListItem Value="9">Ra toa thuốc và Chuyển phòng</asp:ListItem>
                             <asp:ListItem Value="7">Chuyển phòng thu phí</asp:ListItem>
						     <asp:ListItem Value="3">Cho về-Không thuốc</asp:ListItem>
                             <asp:ListItem Value="10">Cho toa thuốc và chỉ định cận lâm sàng</asp:ListItem>
                            
                            <asp:ListItem Value="6">Chờ kết quả chỉ định cận lâm sàng</asp:ListItem>
                            <asp:ListItem Value="5">Hướng giải quyết kh&#225;c</asp:ListItem>
</asp:dropdownlist></span>
<%--<span id = "toathuocmau" class = "ptext" style="display: none"><asp:dropdownlist id="ddlbenhlymau" onchange = "LoadtoaThuocMau()" runat="server" width="200px"></asp:dropdownlist></span>
                              
&nbsp;<span id = "listphongkham" class = "ptext" style="display: none"><asp:dropdownlist id="ddlPhongKhamBenh" runat="server" width="200px"></asp:dropdownlist></span>
                            <asp:DropDownList ID="ddGhiChuBenhLy" runat="server" onchange="LoadtoaThuocMau()"
                                Width="5px" Enabled="False">
                            </asp:DropDownList><span id = "spText" class = "ptext" style="display: none"></span>
                            </td>
				    </tr>--%>
				    <span id = "toathuocmau" class = "ptext" style="display: none"><asp:dropdownlist id="ddlbenhlymau" onchange = "LoadtoaThuocMau()" runat="server" width="200px"></asp:dropdownlist>
                                    <asp:dropdownlist id="ddGhiChuBenhLy" runat="server" onchange="LoadtoaThuocMau()" width="2px" Enabled="False"></asp:dropdownlist>
                                    &nbsp;&nbsp;Số ngày ra toa:
                                    <asp:textbox id="txtSoNgayRaToa" runat="server" text="1" width="20px" onblur = "TestNum(this); "></asp:textbox>
                                    </span>
                                <span id = "spText" class = "ptext" style="display: none"><asp:textbox id="txtHuongKhac" runat="server"  width="88px"></asp:textbox>
                                    
                                </span>
                                <span id = "benhVienChuyenDen" class = "ptext" style="display: none">
                                <label id="Label2"  runat="server" >&nbsp;Đến BV:</label> 
                                <asp:textbox id="txtBVChuyenDen" runat="server" text="" width="300px" visible="false"></asp:textbox>
                                    
                                    <span class="ptext"><input type = "hidden" id = "txtidBenhVien" value = "0" /><asp:textbox  id="txtTenBenhVien" runat="server" Width="300px" onKeyPress = "SetNullIDBV()"  ></asp:textbox>
                               
                                <asp:textbox id="txtmaBenhVien" runat="server" width="56px" onKeyPress = "SetNullIDBV()"  ></asp:textbox>
                                </span>
                                </span>
                                <span id = "KhoaNhapVien" class = "ptext" style="display: none">
                                <label id="Label3"  runat="server" >&nbsp;&nbsp;Nhập vào Khoa:&nbsp;</label> 
                                <asp:dropdownlist id="ddlKhoaNhapVien" runat="server" width="180px" autopostback="false" ></asp:dropdownlist>
                                    &nbsp;&nbsp;
                                </span>
                                </td>
				    </tr>
				    <tr>
				        <td style="padding-top:2px; width:14%; padding-left:20px; height: 27px;"  align = "left">
						    <span class="ptext" id = "labeChuyen"><label id="LabelPCD"  runat="server" ></label> </span>
					    </td>
				        <td style="padding-top:2px; width:882px; height: 27px;" align = "left">
				        
                                    <span id = "listphongkham" class = "ptext" style="display: none">
                                    <asp:updatepanel runat="server" id="updatepanelCP">
                                        <contenttemplate>
                                    <asp:dropdownlist id="ddlPhongKhamBenh" runat="server" width="180px" autopostback="false" onchange="LoadNoiDungChuyenDen()" ></asp:dropdownlist>
                                    <%--onselectedindexchanged="ddlPhongKhamBenh_SelectedIndexChanged"--%>
                                    &nbsp;&nbsp;
                                    <asp:dropdownlist id="ddlNdCD" runat="server" width="150px" autopostback="false" onchange="LoadPhongKhamChuyenDen()" ></asp:dropdownlist>
                                    <%--onselectedindexchanged="ddlNdCD_SelectedIndexChanged"--%>
                                    &nbsp;&nbsp;
                                    <asp:dropdownlist id="ddlPKBCD" runat="server" width="180px" ></asp:dropdownlist>
                                    
                                    </contenttemplate>
                                    </asp:updatepanel >
                                        
                                    </span>                                    
                                <input type = "hidden" id="KhoaChuyenDenOld" runat="server" tabindex="6"  style="width: 37px" />
                                <input type = "hidden" id="DVChuyenDenOld" runat="server" tabindex="6"  style="width: 37px" />
                                <input type = "hidden" id="PhongChuyenDenOld" runat="server" tabindex="6"  style="width: 37px" />
				        </td>
				    </tr>
				    <tr>
				    <td>
				    <span class="ptext">
<%--				    <asp:Button ID="btnLayToaCu" runat="server" Text="Lấy toa cũ" onclick="getOldTT();" />
--%>				   
				        <input onclick="getOldTT();" type="button" value="Lấy toa thuốc cũ" runat="server"  id="btnXemTTOld"/>

 </span>
				    </td>
				 </tr>
				     <%-- <tr id = "infotoathuocold" style="display:none">
                        <td class="title" align = "left" colspan = "2" style = "padding-top:7px; padding-left:20px" id = "thongtintoathuoc">
                            
                               <div  runat="server"  id= "infotoathuoc">
                               </div>                              
                        </td>
                    </tr>--%>
                    <tr id = "infotoathuocold" style="display:''">
                        <td class="title" align = "left" colspan = "2" style = "padding-top:7px; padding-left:20px" id = "thongtintoathuoc">
                            
                               <div id = "infotoathuoc" style="display:''">
                               
                               </div>                              

                        </td>
                    </tr>
				    <tr>
					    <td style="padding-top:2px; width:12%; padding-left:20px; height: 26px;"  align = "left">
						    <span class="ptext">Dặn dò của BS</span>
					    </td>
					    <td style="padding-top:2px; width:85%; height: 26px;" align = "left" id = "td_DanDo" >
						    <span class="ptext"><asp:textbox id="txtDanDo" runat="server" Width="640px" TabIndex="9" onKeyPress = "LoadLoiDanDo('txtDanDo')" ></asp:textbox>
                                </span></td>
				    </tr>
				    <tr>
					    <td style="padding-top:2px; width:12%; padding-left:20px; height: 26px;"  align = "left">
						    <span class="ptext">Nội dung tái khám</span>
					    </td>
					    <td style="padding-top:2px; width:85%; height: 26px;" align = "left">
						    <span class="ptext"><asp:textbox id="txtNoiDungTaiKham" runat="server" Width="420px" TabIndex="9"></asp:textbox>&nbsp;Ngày hẹn:&nbsp; 
                                <asp:textbox id="txtngayhen" runat="server" width="100px"  onblur = "TestDatePhieu(this)"></asp:textbox>
                                <input type = "button"  id="Button3" value ="..." style="width: 25px" onclick="dp_cal.toggle()" />
                                &nbsp;
                                <asp:textbox id="txtgiohen" runat="server" onblur="" width="47px"></asp:textbox>
                                (dd/MM/yyyy HH:mm)
                            </span></td>
				    </tr>
				    <tr>
					    <td style=" padding-top:3px;text-align:center; width:100%; padding-bottom:0px; height: 29px;"  colspan = "2">
						    <span id = "showstatus" style="display:none" class = "ptext"><img src="../images/processing.gif" align = "left" />&nbsp;Đang lưu thông tin phiếu khám bệnh, vui lòng đợi trong giây lát ...</span>
						    <INPUT style="BORDER-TOP-WIDTH: 1px; BORDER-RIGHT: 1px; BORDER-LEFT: 1px; WIDTH: 147px; BORDER-BOTTOM: 1px; BACKGROUND-COLOR: silver" id="Button5" onclick="UpdatePhieuKhamBenh()" type=button value="Lưu Phiếu" />
						    <INPUT style="BORDER-TOP-WIDTH: 1px; BORDER-RIGHT: 1px; BORDER-LEFT: 1px; WIDTH: 147px; BORDER-BOTTOM: 1px; BACKGROUND-COLOR: silver" id="btnTamUng" onclick="tamung()" type=button value="Tạm ứng" />
						    <%--<input id="Button5" style="width: 147px; background-color:silver; border-top-width: 1px; border-right: 1px; border-left: 1px; border-bottom: 1px;" type="button" value="Lưu Phiếu" onclick = "UpdatePhieuKhamBenh()"/>&nbsp;--%>
						    <input id="Button6" class="button" type="button" value="In Toa Thuốc" onclick = "InToaThuoc()"/>&nbsp;
						    <INPUT style="BORDER-TOP-WIDTH: 1px; BORDER-RIGHT: 1px; BORDER-LEFT: 1px; WIDTH: 175px; CURSOR: pointer; BORDER-BOTTOM: 1px; BACKGROUND-COLOR: silver" id="Button2" onclick="InPhieuChiDinhCLS()" type=button value="In Phiếu Chỉ Định CLS Mới" />
                                <INPUT style="BORDER-TOP-WIDTH: 1px; BORDER-RIGHT: 1px; BORDER-LEFT: 1px; WIDTH: 175px; CURSOR: pointer; BORDER-BOTTOM: 1px; BACKGROUND-COLOR: silver" id="Button1" onclick="InPhieuChiDinhCLS_Cu()" type=button value="In Phiếu Chỉ Định CLS Cũ" />
						     <INPUT class="button" id="btnInPH" onclick="inPH()" type="button" value="In Phiếu Hẹn" />
                                <input id="btnXemHSBA" onclick="ViewHSBA_Click();" style="border-top-width: 1px;
                                    border-right: 1px;border-left: 1px; width: 147px; border-bottom: 1px;
                                    background-color: silver" type="button" value="Xem HSBA" />
                                    <input id="btnGiayChuyenVien" runat="server" style="display:none;float:right;margin-left:5px" class="button" type="button" onclick="InGiayChuyenVien();" value="In giấy chuyển viện" />
                                <input id="btnPhieuMoi" onclick="PhieuMoi()" class="button"  type="button" value="Phiếu mới" />
                            </td>
				    </tr>
			    </table>
		    </td>
	    </tr>				
    </table>
    </td>
   </tr>
   
  </table>  
  <input type="hidden" value="" name="listIdDV" id="listIdDV"/>
  <input type="hidden" value="0" name="SoDongCLS" id="SoDongCLS"/>
  <input type="hidden" value="" name="listIdDV_Old" id="listIdDV_Old"/>
  <input type="hidden" value="" name="luuchidinhcls" id="luuchidinhcls"/>
  <input type="hidden" value="" name="statusCDCLS" id="statusCDCLS"/>
    <input type="hidden" value="" name="lblIDThuocCheck" id="lblIDThuocCheck"/>
      <input type="hidden" runat="server" value="" name="listIDKBCLS" id="listIDKBCLS"/>
      <input type="hidden" runat="server" value="" name="ddlBS" id="ddlBS"/> 
      <input type="hidden" runat="server" value="" name="ddlPK" id="ddlPK"/> 
      <input type="hidden" name="iddangkykham" id="iddangkykham"/>
      <input type="hidden" name="idbenhnhantoathuoc" id="idbntoathuoc" runat="server"/>
       <input type="hidden" name="tenDVCLSChuaThu" id="tenDVCLSChuaThu"/>
          <input type="hidden" value="" runat="server" name="listTenNhom" id="listTenNhom"/>    
        <input type="hidden" value="0" runat="server" name="idpkbCLS" id="idpkbCLS"/>  <input type="hidden" value="0" runat="server" name="idpkbCLS" id="txt_kiemtra1"/>
    <input type="hidden" value="0" runat="server" name="idpkbCLS" id="txt_kiemtra2"/>    
    <input type="hidden" value="" runat="server" name="txtSoNgayBH" id="txtSoNgayBH"/>
    <%--Khỏe 20_07--%>
    <input type="hidden" value="" runat="server" name="txtTinhTrangThuCLS" id="txtTinhTrangThuCLS"/>
    <%--Khỏe 07/12 : Số lượng CLS--%>
    <input type="hidden" value="" name="lastSL" id="lastSL"/>
    <input type="hidden" value="" name="lastID" id="lastID"/>
    <input type="hidden" value="" name="lastDG" id="lastDG"/>
    <input type="hidden" value="" name="lastCK" id="lastCK"/>
    <input type="hidden" value="" name="lastTT" id="lastTT"/>
    <input type="hidden" value="" name="lastGC" id="lastGC"/>
    
    </form>
<!--#include file ="footer.htm"-->