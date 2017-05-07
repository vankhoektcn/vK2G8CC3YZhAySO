<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTSCD_DanhSachTangGiamTaiSan.aspx.cs" Inherits="ketoan_KTTSCD_TangGiamTaiSan" %>
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


 var dp_cal,dp_cal2;
 window.window.onload = function () 
{
     dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));	
	 dp_cal2 = new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
	 document.getElementById('txtTuNgay').value = getCurrentDate();
	 document.getElementById('txtDenNgay').value = getCurrentDate();

 };
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


function getFormatSoTien(idText)
{
    var txtPhatSinh = document.getElementById(idText);
    txtPhatSinh.value = FormatSoTien(txtPhatSinh.value);
    
}
function FormatSoTien(num)
{
	    return formatCurrency(num);
}


function ShowDanhMucTaiSan(obj)
{
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
      txtMaTS.value=MaTS;
      txtTenTS.value = TenTaiSan;
      
}

//===========================================Xóa phiếu tăng giảm tài sản cố định=======================================
function XoaPhieuGiam(SoPG)
{
     var rs = confirm("Bạn muốn xóa phiếu chi "+SoPG +" này?");
     if(rs==true)
     {
        getFunctionXoaPhieuGiamTSCD(SoPG);
        LoadDanhSachPhieuTangGiam();
     }
     
}
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
                        alert("Xóa phiếu tăng giảm"+SoPG+" thành công!");                     
                       
                      }
                      else
                        alert("Xóa phiếu tăng giảm"+SoPG+" thất bại. Vui lòng kiểm tra lại hệ thống. Cảm ơn!");                     
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=XoaPhieuGiamTaiSanCoDinh&SoPG="+SoPG+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
//=================================================Load thông tin phiếu giảm tài sản=======================================================
function LoadDanhSachPhieuTangGiam()
{
     ResetTableDSTaiSan();
    var SoPG = document.getElementById('txtSoPhieuGiam').value;
    var TuNgay = document.getElementById('txtTuNgay').value;
    var DenNgay = document.getElementById('txtDenNgay').value;
    var MaTS = document.getElementById('txtMaTS').value; 
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
                      else
                      {
                        alert("Không có danh sachs phiếu tăng giảm.");
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=LoadPhieuGiamTaiSan&SoPG="+SoPG+"&TuNgay="+TuNgay+"&DenNgay="+DenNgay+"&MaTS="+MaTS+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function ShowThongTinPhieuGiamTaiSan(SoPG,MaTS,TenTaiSan,NgayGiam,NguyenGia,TKChiPhi,TKKhauHao,DienGiai)
{
    var link = "KTTSCD_TangGiamTaiSan.aspx";
    var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td style=\"width:50px;text-align:center\">" + (lastRow-1) + "</td>";
            shtml += "		<td style=\"width:50px;text-align:center\"><label id=\"Xoa_"+(lastRow-1)+"\" style=\"cursor:pointer;font-style:italic;color:Blue\" onclick=\"XoaPhieuGiam('"+SoPG+"')\">Xóa</label></td>	";
            shtml += "		<td style=\"width:200px;text-align:center\"  id=\"txtSoPG_"+(lastRow-1)+"\"><a href=\""+link+"?&SoPG="+SoPG+"\"><input type=\"hidden\" id=\"hdSoPG_"+(lastRow-1)+"\" value=\""+SoPG+"\"/>"+SoPG+"</a></td>	";
            shtml += "		<td style=\"width:100px;text-align:center\">"+MaTS+"</td>	";
            shtml += "		<td style=\"width:300px;text-align:center\">"+TenTaiSan+"</td>	";
            shtml += "		<td style=\"width:100px;text-align:center\">"+NgayGiam+"</td>	";
            shtml += "		<td style=\"width:200px;text-align:center\">"+FormatSoTien(NguyenGia)+"</td>	";
            shtml += "		<td style=\"width:100px;text-align:center\">"+TKChiPhi+"</td>	";
            shtml += "		<td style=\"width:100px;text-align:center\">"+TKKhauHao+"</td>	";
            shtml += "		<td style=\"width:200px;text-align:center\">"+DienGiai+"</td>	";
            
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
}
//========================================================================================================================================


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


</script>
<form id="tinhkhauhao" name="tinhkhauhao" method="post" runat="server">
<div width = "100%" align = "left" style="height:  34px;background-color:#007138">   <uc1:menu_ketoantaisan ID="menu_ketoantaisan1" runat="server" /></div>
<div>
    <table>
        <tr>
            <td>Từ ngày : </td>
            <td><input type="text" id="txtTuNgay" onclick="dp_cal.toggle()" /></td>
            <td>Đến ngày :</td>
            <td><input type="text" id="txtDenNgay" onclick="dp_cal2.toggle()" /></td>
            <td>Số phiếu tăng giảm :</td>
            <td><input type="text" id="txtSoPhieuGiam" /></td>
            <td>Tài sản :</td>
            <td><input type="text" id="txtTenTS" onfocus="ShowDanhMucTaiSan('txtTenTS')" /><input type="hidden" id="txtMaTS" /></td>
            <td><input type="button" id="bt_TimKiem"  onclick="LoadDanhSachPhieuTangGiam()" value="Tìm kiếm" /></td>
        </tr>
    </table>
</div>
<div>

<table class="TableGidview" id="TableDanhSach">
         <tr>
              <td class ="tdHeader" colspan="10" >DANH SÁCH PHIẾU TĂNG/GIẢM TÀI SẢN</td>
         </tr>
		<tr class="HeaderGidView">
		  
		      <td style="width:50px">
		       STT
		      </td>
		      
		     <td style="width:50px">
		       		       
		     </td>
		     <td style="width:200px">
		       Số phiếu tăng/giảm
		       
		     </td>
		     <td style="width:100px">
		       Mã tài sản
		       
		    </td>
		    <td style="width:300px">
		       Tên tài sản
		       
		    </td>
		    <td style="width:100px">
		        Ngày lập phiếu
		    </td>
		     
		      <td style="width:200px">
		        Nguyên giá
		      
		      </td>
		      <td style="width:100px">
		        TK Chi phí
		      </td>
		      <td style="width:100px">
                TK khấu hao
		         
		      </td>
		      <td style="width:200px">
              Diễn giải
		         
		      </td>
		      
		</tr>					 
					  
	</table> 
</div>

</form>
<!--#include file = "footer.htm" -->
                                                  