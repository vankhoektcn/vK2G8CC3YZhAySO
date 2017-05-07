<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTSCD_TangGiamTaiSan.aspx.cs" Inherits="ketoan_KTTSCD_TangGiamTaiSan" %>
<!--#include file = "header.htm" -->
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_TaiSan.ascx" TagName="menu_ketoantaisan" TagPrefix="uc1" %>
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
<script type="text/javascript">


 window.onload = function () 
	{
        dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtNgayTangGiam'));
        document.getElementById('txtNgayTangGiam').value = getCurrentDate();
        var type = getKyTuDauMaSoPhieu();
        TaoMaSoPhieu(type);
        var queryString = "";
	    queryString =  window.location.search.substring(1).split('&');
	    if(queryString!="")
	    {
	        
	        var SoPG = queryString[1].split('=');
	        
	        LoadThongTinPhieuGiamTaiSan(SoPG[1]);
            document.getElementById('btnSave').value ="Sửa";
	    }
	    else
	    {
             ThemDong();
           
        }
 };
 function TaoMoi_Click()
 {
    
    document.getElementById('txtMaPhieu').value =   "";
    document.getElementById('txtMaTS').value =  "";
    document.getElementById('txtTenTS').value =   "";
    document.getElementById('txtNgayTangGiam').value = "";
    document.getElementById('txtNguyenGia').value =   "";
    document.getElementById('txtTKChiPhi').value =   "";
    document.getElementById('txtTKKhauHao').value =   ""
    document.getElementById('txtDienGiai').value =   "";
    var type = getKyTuDauMaSoPhieu();
      TaoMaSoPhieu(type);
      ResetTableDSTaiSan();
      ThemDong();
 }
function getCurrentDate()
{
    var date = new Date();
    var day =   date.getDate();
    if(day<10)
        day = "0" + day;
    var month = date.getMonth();
    if(month<10)
        month = "0"+month;
    var rs = day+"/"+month+"/"+date.getFullYear();
    return rs;    
}

function TestMaTaiKhoan(Ctr)
{
    var txtTaiKhoan = Ctr.id;
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
function getKyTuDauMaSoPhieu()
{
   var rs = "";
   var index=document.getElementById("SelectType").selectedIndex;
   var type = document.getElementsByTagName("option")[index].value;
   if(type=="1")
        rs ="TTS";
   else
        rs = "GTS";
        return rs;
}
function TaoMaSoPhieu(KyTuDau)
{
       var Table = "Giam_TSCD";
       //var KyTuDau = "PTKH";
       var Column = "so_phieu_giam";
      xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="")
                      {  
                        document.getElementById('txtMaPhieu').value = value;  
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TaoMaSoTuDong&Table="+Table+"&KyTuDau="+KyTuDau+"&Column="+Column+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function getFormatSoTien(Ctr)
{
    var idText = Ctr.id;
    var txtPhatSinh = document.getElementById(idText);
    txtPhatSinh.value = FormatSoTien(txtPhatSinh.value);
    
}
function FormatSoTien(num)
{
	    return formatCurrency(num);
}

 function TestNumberofInput(Ctr)
{
        var obj = Ctr.id;
        if(obj.value!="")
        {
        var key;
        if(window.event)
        {
          key = window.event.keyCode; 
        }
        //alert(key);
        var currentvalue = document.getElementById(obj).value;
        var txtObj = document.getElementById(obj);
        //if((key<48||key>57)&&key!=190&&key!=8&&key!=9&&key!=37&&key!=38&&key!=39&&key!=40)
        if((key>=65&&key<=90))
        {
            alert("Chỉ được nhập số!");
            
            txtObj.value =currentvalue;
        }
        else
        {
            var number = txtObj.value;
             if(number=="")
                number=currentvalue;
             if(!isFinite(parseFloat(number))||parseFloat(number)>999999999999)
             {   alert("Nhập sai định dạng.Chỉ được nhập số!Vui lòng kiểm tra lại cảm ơn!"); 
                 txtObj.value =currentvalue;
             }
         }
     }
}

function SelectType_SelectChange(obj)
{
       var KyTuDau = getKyTuDauMaSoPhieu();
         TaoMaSoPhieu(KyTuDau);
    
}
function ShowTaiKhoan(Ctr)
{
    var obj = Ctr.id;
    var objsrc = document.getElementById(obj);
  
        $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=DanhSachTaiKhoan_Jquery&Key="+objsrc.value+"&obj="+obj,
                                                    {width:350,scroll:true,formatItem:function(data)
                                                        {return data[1];}
                                                    }
                                                ).result(
                                                            function(event,data)
                                                            {
                                                                setChonTaiKhoan(data[2],obj);
                                                             //   document.getElementById(obj).blur();
                                                            }
                                                        );           
}

function setChonTaiKhoan(MaTaiKhoan,idText)
{
      if(idText!="")
      {
          var txtTaiKhoan=document.getElementById(idText);
          txtTaiKhoan.value=MaTaiKhoan;
          txtTaiKhoan.focus();
      }
}
function ShowDanhMucTaiSan(Ctr)
{
        var obj = Ctr.id;
        var objsrc = document.getElementById(obj);
      
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhMucTaiSan&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:500,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    setChonTaiSan(data[2],data[3],data[4],data[5],data[6]);
                                                                  //  document.getElementById(obj).blur();
                                                                }
                                                            ); 
    
}

function setChonTaiSan(MaTS,TenTaiSan,NguyenGia,TKChiPhi,TKKhauHao)
{
      
      var txtMaTS=document.getElementById('txtMaTS');
      var txtTenTS=document.getElementById('txtTenTS');
      var txtNguyenGia=document.getElementById('txtNguyenGia');
      var txtTKChiPhi=document.getElementById('txtTKChiPhi');
      var txtTKKhauHao=document.getElementById('txtTKKhauHao');
     
      txtMaTS.value=MaTS;
      txtTenTS.value = TenTaiSan;
      txtNguyenGia.value = FormatSoTien(NguyenGia);
      txtTKChiPhi.value = TKChiPhi;
      txtTKKhauHao.value = TKKhauHao;
     
}
//=================================================Load Chi tiết phiếu giảm tài sản=======================================================
//========================================================================================================================================
function LoadChiTietPhieuGiamTaiSan(SoPG)
{
     
    ResetTableDSTaiSan();
      xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="")
                      {
                        var row = value.split('&');
                        if(row!=null)
                        {
                            for(var i=0;i<row.length;i++)
                            {
                                var data = row[i];
                                if(data!="")
                                {
                                    var column = data.split('|');
                                    if(column.length>0)
                                    {
                                      //so_phieu_giam,TK_Co,TK_No,Tien,Dien_Giai
                                      ShowChiTietPhieuGiamTaiSan(column[0],column[1],column[2],column[3],column[4]);
                                    }
                                }
                            }
                        } 
                       
                        
                      }
                      else
                      {
                        alert("Không có chi tiết phiếu tăng giảm");
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=LoadChiTietPhieuGiamTaiSan&SoPG="+SoPG+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function ShowChiTietPhieuGiamTaiSan(SoPG,TKCo,TKNo,Tien,DienGiai)
{
        var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td class=\"Column0\" style=\"width:50px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/></td>";
            shtml += "		<td class=\"Column1\"><input type=\"text\" id=\"TaiKhoanNo_"+(lastRow)+"\" value=\""+TKNo+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column1\"><input type=\"text\" id=\"TaiKhoanCo_"+(lastRow)+"\"  value=\""+TKCo+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column1\"><input type=\"text\" id=\"DienGiai_"+(lastRow)+"\" value=\""+DienGiai+"\"  style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2\"><input type=\"text\" id=\"SoTien_"+(lastRow)+"\" value=\""+FormatSoTien(Tien)+"\" onchange=\"getFormatSoTien(this)\" onblur=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" /></td>	"; 
                
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
 }
//=================================================Load thông tin phiếu giảm tài sản=======================================================
function LoadThongTinPhieuGiamTaiSan(SoPG)
{
     
    ResetTableDSTaiSan();
      xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="")
                      {
                        var row = value.split('&');
                        if(row!=null)
                        {
                            for(var i=0;i<row.length;i++)
                            {
                                var data = row[i];
                                if(data!="")
                                {
                                    var column = data.split('|');
                                    if(column.length>0)
                                    {
                                      //So_Phieu_Giam,Ma_TS,dmts.TenTaiSan,Ngay_Giam,NguyenGia,TKChiPhi,TKKhauHao,Dien_Giai
                                      ShowThongTinPhieuGiamTaiSan(column[0],column[1],column[2],column[3],column[4],column[5],column[6],column[7]);
                                    }
                                }
                            }
                        } 
                       
                        
                      }
                      else// trong truong hop rong 
                      {
                        alert("Không có phiếu tăng giảm này. ");
                      }
                }
            }
               xmlHttp.open("GET","ajax.aspx?do=LoadPhieuGiamTaiSan&SoPG="+SoPG+"&TuNgay=&DenNgay=&MaTS=&times="+Math.random(),true);
            xmlHttp.send(null);
}
function ShowThongTinPhieuGiamTaiSan(SoPG,MaTS,TenTaiSan,NgayGiam,NguyenGia,TKChiPhi,TKKhauHao,DienGiai)
{
    document.getElementById('txtMaPhieu').value =   SoPG;
    document.getElementById('txtMaTS').value =  MaTS;
    document.getElementById('txtTenTS').value =   TenTaiSan;
    document.getElementById('txtNgayTangGiam').value =   NgayGiam;
    document.getElementById('txtNguyenGia').value = FormatSoTien(NguyenGia);
    document.getElementById('txtTKChiPhi').value =   TKChiPhi;
    document.getElementById('txtTKKhauHao').value =   TKKhauHao;
    document.getElementById('txtDienGiai').value =   DienGiai;
    LoadChiTietPhieuGiamTaiSan(SoPG);
}
//========================================================================================================================================

 function ThemDong()
{ 
    var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td class=\"Column0\" style=\"width:50px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/></td>";
            shtml += "		<td class=\"Column1\"><input type=\"text\" id=\"TaiKhoanNo_"+(lastRow)+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column1\"><input type=\"text\" id=\"TaiKhoanCo_"+(lastRow)+"\"  onchange=\"TestMaTaiKhoan(this)\" onfocus=\"ShowTaiKhoan(this)\" style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column1\"><input type=\"text\" id=\"DienGiai_"+(lastRow)+"\"   style=\"width:99%;text-align:center\"/></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"SoTien_"+(lastRow)+"\" onchange=\"getFormatSoTien(this)\" onblur=\"TestNumberofInput(this)\"  style=\"width:99%;text-align:right\" /></td>	"; 
                
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
}
function XoaDong()
{
     var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        if(lastRow>2)
        {
                for(var i=2;i<lastRow;i++)
                {
                     var idCheckBox = "checkbox_"+i;
                     var checkbox = document.getElementById(idCheckBox);
                    if(checkbox.checked)
                    {
                        
                        TableDanhSach.deleteRow(i);
                        UpdateRowOfTable();
                        XoaDong();
                          break;
                        
                    }
                }
              //  UpdateRowOfTable();
            
        }
      
}
function UpdateRowOfTable()
{
      var TableDanhSach = document.getElementById('TableDanhSach');
      var lastRow = TableDanhSach.rows.length; 
      if(lastRow>2)
      {
        for(var i=2;i<lastRow;i++)
        {
             TableDanhSach.rows[i].cells[0].getElementsByTagName("input")[0].id = "STT_"+i;
             TableDanhSach.rows[i].cells[0].getElementsByTagName("input")[0].value = i-1;
             TableDanhSach.rows[i].cells[1].getElementsByTagName("input")[0].id = "checkbox_"+i;
             TableDanhSach.rows[i].cells[2].getElementsByTagName("input")[0].id = "TaiKhoanNo_"+i;
             TableDanhSach.rows[i].cells[3].getElementsByTagName("input")[0].id = "TaiKhoanCo_"+i;
             TableDanhSach.rows[i].cells[4].getElementsByTagName("input")[0].id = "DienGiai_"+i;
             TableDanhSach.rows[i].cells[5].getElementsByTagName("input")[0].id = "SoTien_"+i;
        }
      }
}

 function ResetTableDSTaiSan()
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

//============================================Lưu thông tin phiếu tăng giảm tài sản cố định =========================
var IsSaveOrUpdate = "Save";
function btnSave_OnClick(Ctr)
{
    if(Ctr.value=="Sửa")
    {
        IsSaveOrUpdate = "Update";
        Ctr.value = "Lưu";
    }
    else
    if(Ctr.value=="Lưu")
    {
        LuuGiamTaiSanCoDinh(Ctr);
        //Ctr.value = "Sửa";
    }
    
}
function LuuGiamTaiSanCoDinh(Ctr)
{
     Ctr.disabled = true;
     document.getElementById('message').style.visibility = "visible";
    var SoPG = document.getElementById('txtMaPhieu').value;
    var MaTS =  document.getElementById('txtMaTS').value;
    var NgayGiam =  document.getElementById('txtNgayTangGiam').value;
    var DienGiai =  document.getElementById('txtDienGiai').value;
    var LoaiTS ="";
    var index=document.getElementById("SelectType").selectedIndex;
    LoaiTS =document.getElementsByTagName("option")[index].value;
    
      if(SoPG=="")
      {
        alert('Chưa có số phiếu tăng/giảm. Vui lòng kiểm tra lại. Cảm ơn!');
        Ctr.disabled = false;
        document.getElementById('message').style.visibility = "hidden";
        return;
      }
      else
      if(MaTS=="")
      {
        alert('Chưa có mã tài sản. Vui lòng kiểm tra lại. Cảm ơn!');
        Ctr.disabled = false;
        document.getElementById('message').style.visibility = "hidden";
        return;
      }
      else
      if(NgayGiam=="")
      {
        alert('Chưa có ngày lập phiếu. Vui lòng kiểm tra lại. Cảm ơn!');
        Ctr.disabled = false;
        document.getElementById('message').style.visibility = "hidden";
        return;
      }
      else       
         getFunctionLuuGiamTSCD(Ctr,SoPG,MaTS,NgayGiam,DienGiai,LoaiTS);
        
}
function getFunctionLuuGiamTSCD(Ctr,SoPG,MaTS,NgayGiam,DienGiai,LoaiTS)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {
                          if(IsSaveOrUpdate=="Update")
                          {
                            getFunctionXoaPhieuGiamTSCD_ChiTiet_SoCai(Ctr,SoPG);
                          }
                          else
                          if(IsSaveOrUpdate=="Save")
                          {
                            LuuGiamTaiSanCoDinh_ChiTiet_SoCai(Ctr);
                          }
                             
                       
                      }
                      else
                      if(value=="0")
                      {
                        alert("Lưu thông tin tăng/ giảm tài sản thất bại!");
                        Ctr.disabled = false;
                        document.getElementById('message').style.visibility = "hidden";
                        return;
                      }
                     
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=LuuGiamTaiSanCoDinh&SoPG="+SoPG+"&MaTS="+MaTS+"&NgayGiam="+NgayGiam+"&DienGiai="+encodeURIComponent(DienGiai)+"&LoaiTS="+LoaiTS+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
//======================================================================================================================================================================================================================
//=====================================================Xóa phiếu tăng giảm tài sản cố định==============================================================================================================================
function getFunctionXoaPhieuGiamTSCD(SoPG)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {
                                             
                       
                      }
                   
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=XoaPhieuGiamTaiSanCoDinh&SoPG="+SoPG+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
//======================================================================================================================================================================================================================
//=====================================================Xóa phiếu tăng giảm tài sản cố định trong bảng chi tiết và sổ cái==============================================================================================================================

function getFunctionXoaPhieuGiamTSCD_ChiTiet_SoCai(Ctr,SoPG)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                    LuuGiamTaiSanCoDinh_ChiTiet_SoCai(Ctr);
                    
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=XoaPhieuGiamTaiSanCoDinh_ChiTiet_SoCai&SoPG="+SoPG+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
//======================================================================================================================================================================================================================
//=====================================================Lưu phiếu tăng giảm tài sản cố định chi tiết==============================================================================================================================

 function LuuGiamTaiSanCoDinh_ChiTiet_SoCai(Ctr)
 {
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var x;
    var rs = 1;
    var SoPG = document.getElementById('txtMaPhieu').value;
    var NgayGiam = document.getElementById('txtNgayTangGiam').value;
    var valueTKNo = "";
    var valueTKCo ="";
    var valueSoTien ="";
    var valueDienGiai = "";
    var flag = true;
    if(Row>2)
    {
//        while(Row>2)
//        {
        //null,sophieuthu,tkco,psco,null,soHD,NgaylapHD,tientrenHD,null,null,null,diengiai,0
         for(var i=2;i<Row;i++)
         {
                  var idTKNo= "TaiKhoanNo_"+i;//(Row-1);
                  var idTKCo = "TaiKhoanCo_"+i;//(Row-1);
                  var idSoTien = "SoTien_"+i;//(Row-1);
                  var idDienGiai = "DienGiai_"+i//(Row-1);
                  //flag = true;
                  if(document.getElementById(idTKNo).value=="")
                  {
//                    flag = false;
//                    return;
                    alert('Chưa có mã tài khoản nợ. Vui lòng kiểm tra lại. Cảm ơn!');
                    Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
                    getFunctionXoaPhieuGiamTSCD();
                  }
                  else
                  if(document.getElementById(idTKCo).value=="")
                  {
//                    flag = false;
//                     return;
                    alert('Chưa có mã tài khoản có. Vui lòng kiểm tra lại. Cảm ơn!');
                    Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
                    getFunctionXoaPhieuGiamTSCD();
                  }
                  else
                  if(document.getElementById(idSoTien).value=="")
                  {
//                    flag = false;
//                     return;
                    alert('Chưa nhập số tiền. Vui lòng kiểm tra lại. Cảm ơn!');
                    Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
                    getFunctionXoaPhieuGiamTSCD();
                  }
                  valueTKNo +=";"+ document.getElementById(idTKNo).value;
                  valueTKCo +=";"+ document.getElementById(idTKCo).value;
                  valueDienGiai+=";"+ document.getElementById(idDienGiai).value;
                  
                  var tien = document.getElementById(idSoTien).value;
                  valueSoTien +=";"+ ChangeFormatCurrency(tien);
            
            
        }
         getFunctionLuuGiamTSCD_ChiTiet_SoCai(Ctr,SoPG,NgayGiam,valueTKNo,valueTKCo,valueSoTien,valueDienGiai);
        
     }
     else
     {
        alert("Chưa có chi tiết tài sản khấu hao. Vui lòng kiểm tra lại.Vui lòng xóa dòng trống nếu không dùng Cảm ơn!");
            Ctr.disabled = false;
            document.getElementById('message').style.visibility = "hidden";
         getFunctionXoaPhieuGiamTSCD();
     }
 }

 function getFunctionLuuGiamTSCD_ChiTiet_SoCai(Ctr,SoPG,NgayGiam,TKNo,TKCo,SoTien,DienGiai)
 {

     xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {
                                             
                        alert("Lưu phiếu tăng/giảm tài sản thành công. ");
                         Ctr.disabled = false;
                        document.getElementById('message').style.visibility = "hidden";
                        Ctr.value = "Sửa";
                        LoadChiTietPhieuGiamTaiSan(SoPG);
                      }
                      else
                      if(value=="0")
                      {
                         alert("Lưu phiếu tăng/giảm tài sản thất bại. ");
                         Ctr.disabled = false;
                         document.getElementById('message').style.visibility = "hidden";
                         getFunctionXoaPhieuGiamTSCD(SoPG);
                      }
                      
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=LuuGiamTaiSanCoDinh_ChiTiet_SoCai&SoPG="+SoPG+"&NgayGiam="+NgayGiam+"&TKNo="+TKNo+"&TKCo="+TKCo+"&SoTien="+SoTien+"&DienGiai="+encodeURIComponent(DienGiai)+"&times="+Math.random(),true);
            xmlHttp.send(null);  
 }

</script>
<form id="tinhkhauhao" name="tinhkhauhao" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:menu_ketoantaisan ID="menu_ketoantaisan1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr style="height:10px">
                    <td><div  class = "tdHeader">TĂNG/GIẢM TÀI SẢN</div></td>
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
                                                            <td class="tdLabel">Tăng/giảm : </td>
                                                            <td  class="tdText">
                                                                <select id="SelectType" onchange="SelectType_SelectChange(this)" >
                                                                    <option value="1">Tăng</option>
                                                                    <option value="0">Giảm</option>
                                                                    
                                                                </select>
                                                               
                                                               
                                                            </td>
                                                            
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">Mã phiếu : </td>
                                                            <td class="tdText"><input  id="txtMaPhieu" readonly="readonly"  type="text" class="InputText" /></td>
                                                            
                                                            <td class="tdLabel" >Ngày tăng giảm :</td>
                                                            <td  class="tdCalenda" ><input id="txtNgayTangGiam" onchange="TestDate('txtNgayTangGiam')" onclick="dp_cal.toggle()"  style="width:100px;"   type="text"/></td>
                                                           
                                                           
                                                        </tr>
                                                         <tr>
                                                            <td class="tdLabel">Mã nhà tài sản : </td>
                                                            <td class="tdText"><input id="txtMaTS"   type="text" onfocus="ShowDanhMucTaiSan('txtMaTS')" class="InputText" /></td>
                                                            
                                                            <td class="tdLabel">Tên nhà tài sản : </td>
                                                            <td  class="tdText"><input id="txtTenTS" type="text"  onfocus="ShowDanhMucTaiSan('txtTenTS')" class="InputText" /></td>
                                                      
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">Nguyên giá : </td>
                                                            <td  class="tdText"><input id="txtNguyenGia"  readonly="readonly" type="text" class="InputText"  /></td>
                                                             
                                                            <td class="tdLabel">TK chi phí : </td>
                                                            <td  class="tdText"><input id="txtTKChiPhi" style="width:100px" readonly="readonly" type="text" class="InputText" /></td>
                                                             <td class="tdLabel">TK khấu hao : </td>
                                                            <td  class="tdText"><input id="txtTKKhauHao" style="width:100px" readonly="readonly" type="text" class="InputText"  /></td>
                                                        </tr>                                                    
                                                         <tr>
                                                            <td class="tdLabel">Diễn giải : </td>
                                                            <td colspan="6"  class="tdText">
                                                                <textarea id="txtDienGiai" style="width:570px" cols="20"  rows="2"></textarea></td>
                                                            
                                                        </tr>                                             
                                                        
                                                        <tr>
                                                            <td colspan="6" style="text-align:center">
                                                                                                                               
                                                                
                                                                <input type="button" value="Lưu" id="btnSave" onclick="btnSave_OnClick(this)" style="width:100px;"  />
                                                                <input type="button" value="Tạo mới" onclick="TaoMoi_Click()"  style="width:100px"  id="bt_Reset" />
                                                                
                                                                
                                                            </td>
                                                        </tr>
                                                           <tr>
                                                            <td colspan="9" style="text-align:center">
                                                                <label id="message"  style="display:none" > Đang xử lý vui lòng chờ trong giây lát....</label>
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
              <td class ="tdHeader" colspan="11" >Bảng định khoản</td>
         </tr>
		<tr class="HeaderGidView">
		     <td class="HeaderColumn0">STT</td>
		     <td class="HeaderColumn0">Xóa</td>
		     <td class="HeaderColumn1">
		       Tài khoản nợ
		     </td>
		     
		     <td class="HeaderColumn2">
		       Tài khoản có
		       
		    </td>
		    <td class="HeaderColumn2">
		       Diễn giải
		       
		    </td>
		    <td class="HeaderColumn2">
		       Số tiền
		    </td>
		    
		    
		</tr>					 
	  
		
		
		 
	</table>
 <div><input type="button" id="bt_ThemDong" value="Thêm dòng" onclick="ThemDong()"/><input type="button" id="bt_XoaDong" value="Xóa dòng" onclick="XoaDong()" /></div>

</form>
<!--#include file = "footer.htm" -->
                                                  