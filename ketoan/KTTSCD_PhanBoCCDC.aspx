<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTSCD_PhanBoCCDC.aspx.cs" Inherits="ketoan_KTTSCD_PhanBoCCDC" %>
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
<script type="text/javascript">


 window.onload = function () 
	{
    var currentTime = new Date();
    var inam=document.getElementById("txtNam");
    inam.value=currentTime.getFullYear();
    LoadDienGiai();
    TaoMaSoTuDong();
    phanquyen();
 };
 function phanquyen() 
	{
	    var quyenthem = '<%=StaticData.HavePermision(this.Page, "KeToanCCDC_KTTSCD_PhanBoCCDC_Them")%>';
        var quyensua = '<%=StaticData.HavePermision(this.Page, "KeToanCCDC_KTTSCD_PhanBoCCDC_Sua")%>';
        var quyenxoa = '<%=StaticData.HavePermision(this.Page, "KeToanCCDC_KTTSCD_PhanBoCCDC_Xoa")%>';
        if(document.getElementById('bt_Luu').value == "Lưu")
        {
            if(quyenthem == 'False')
                document.getElementById('bt_Luu').disabled = true;
            else
                document.getElementById('bt_Luu').disabled = false;
        }
        if(document.getElementById('bt_Luu').value == "Sửa")
        {
            if(quyensua == 'False')
                document.getElementById('bt_Luu').disabled = true;
            else
                document.getElementById('bt_Luu').disabled = false;
        }
        //alert(quyenxoa);
        if(quyenxoa == 'False')
        {
            document.getElementById('Button1').disabled = true;
        }
        else
        {
            document.getElementById('Button1').disabled = false;
        }
	}
 function LoadDienGiai()
 {
    var nam=document.getElementById("txtNam").value;
    
    var index=document.getElementById("SelectMonth").selectedIndex;
    var thang = document.getElementsByTagName("option")[index].value;
    document.getElementById('txtDienGiai').value= "Phân bổ khấu hao công cụ dụng cụ tháng "+thang+"/"+nam;
 }
function GetNam()
{
    var currentTime = new Date()
    var inam=document.getElementById("txtNam");
    inam.value=currentTime.getFullYear();
}

function TaoMaSoTuDong()
{
       var Table = "So_Cai";
       var KyTuDau = "KHCC";
       var Column = "Ma_CT";
       var Nam=document.getElementById("txtNam").value;
       
       var index=document.getElementById("SelectMonth").selectedIndex;
       var Thang = document.getElementsByTagName("option")[index].value;
      xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="")
                      {  
                        document.getElementById('txtSoKhauHao').value = value;  
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TaoMaSoTuDong_TheoNgayTuChon&Table="+Table+"&KyTuDau="+KyTuDau+"&Column="+Column+"&Thang="+Thang+"&Nam="+Nam+"&times="+Math.random(),true);
            xmlHttp.send(null);
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

 function TestNumberofInput(obj)
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

function SelectMonth_SelectChange(obj)
{
    LoadDienGiai();
    TaoMaSoTuDong();
  // LoadDanhSachTaiSanByMonthYear();
}
//==================================================Xử lý control Button Lưu============================
function bt_Luu_Click()
{
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    if(Row>2)
        CheckIsPhieuPhanBoCCDC();
     else
     {
        alert("Chưa tập hợp khấu hao công cụ dụng cụ. Vui lòng tập hợp trước khi lưu. Cảm ơn!");
     }
}
//==================================================Kiem tra Khau hao tai san theo thang nam da phan bo trong so cai chua============================
function CheckIsPhieuPhanBoCCDC()
{
     var index=document.getElementById("SelectMonth").selectedIndex;
    var Thang = document.getElementsByTagName("option")[index].value;
    var Nam = document.getElementById('txtNam').value;
      xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var IsExitsSoKhauHao = false;
                    var SoKhauHao = "";
                    var value = xmlHttp.responseText;
                    if (value!="")
                      {
                        SoKhauHao = value;
                        IsExitsSoKhauHao = true;
                      } 
                      else
                      {
                        SoKhauHao = "";
                        IsExitsSoKhauHao = false;
                      }
                      bt_Luu_Proccess(IsExitsSoKhauHao,SoKhauHao,Thang,Nam);
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=CheckIsPhieuPhanBoCCDC&thang="+Thang+"&nam="+Nam+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function bt_Luu_Proccess(IsExitsSoKhauHao,SoKhauHao,Thang,Nam)
{
    if(IsExitsSoKhauHao==true)
    {
        var rs = confirm("Đã phân bổ khấu hao công cụ dụng cụ của tháng  "+Thang+"/"+Nam +". Bạn có muốn phân bổ lại không?");
        if(rs)
        {
            getFunctionXoaPhanBoKhauHaoTaiSan(SoKhauHao);
            LuuPhanBoCongCuDungCu_SoCai();
        }
        
    }
    else
    {
        LuuPhanBoCongCuDungCu_SoCai();
    }
    
}
//==================================================Lưu phân bo khau hao tai san vao so cai ============================

function LuuPhanBoCongCuDungCu_SoCai()
{
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    
    var SoKhauHao = document.getElementById('txtSoKhauHao').value;
    
    var index=document.getElementById("SelectMonth").selectedIndex;
    var Thang = document.getElementsByTagName("option")[index].value;
    if(Thang<10)
        Thang = "0"+Thang;
    var Nam = document.getElementById('txtNam').value;
    
    var NgayKH = "28/"+ Thang+"/"+Nam;
    
    var DienGiai = document.getElementById('txtDienGiai').value;
    
    SoKhauHao="PBCCDC"+Thang+Nam.substr(2,2);
     
    var valueTKChiPhi ="";
    var valueTKKhauHao ="";
    var valueGiaTriKH ="";
    var flag = false;
    if(Row>2)
    {
        while(Row>2)
        {
            var idTKKhauHao= "hdTKKhauHao_"+(Row-2);
            var idTKChiPhi= "hdTKChiPhi_"+(Row-2);
            var idGiaTriKhauHao= "hdGiaTriKhauHao_"+(Row-2);
            
            valueTKChiPhi+=";"+document.getElementById(idTKChiPhi).value;
            valueTKKhauHao+=";"+document.getElementById(idTKKhauHao).value;
            var tien =  document.getElementById(idGiaTriKhauHao).value;
            valueGiaTriKH+=";"+ ChangeFormatCurrency(tien);
            Row--;
        }
        getFunctionLuuPhanBoCongCuDungCu_SoCai(SoKhauHao,NgayKH,DienGiai,valueTKChiPhi,valueTKKhauHao,valueGiaTriKH,Thang,Nam);
    }
    else
    {
        alert("Chưa có chi tiết phân bổ khấu hao công cụ dụng cụ. Vui lòng kiểm tra lại. Cảm ơn!");
    }
}
function getFunctionLuuPhanBoCongCuDungCu_SoCai(SoKhauHao,NgayKH,DienGiai,TKChiPhi,TKKhauHao,GiaTriKH,Thang,Nam)
{
     xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {
                        alert("Phân bổ công cụ dụng cụ khấu hao trong "+Thang +"/" +Nam +" thành công!");
                       } 
                      else
                      {
                        alert("Phân bổ công cụ dụng cụ khấu hao trong "+Thang +"/" +Nam +" thất bại!");
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=LuuPhanBoCongCuDungCu_SoCai&SoKhauHao="+SoKhauHao+"&NgayKH="+NgayKH+"&DienGiai="+encodeURIComponent(DienGiai)+"&TKChiPhi="+TKChiPhi+"&TKKhauHao="+TKKhauHao+"&GiaTriKH="+GiaTriKH+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
//==================================================Xóa phân bổ khau hao tai san trong so cai ============================
function getFunctionXoaPhanBoKhauHaoCCDC(SoKhauHao)
{
     xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {
                        TaoMaSoTuDong();
                       // alert("Phân bổ công cụ dụng cụ khấu hao trong "+Thang +"/" +Nam +" thành công!");
                       } 
                      else
                      {
                       // alert("Phân bổ công cụ dụng cụ khấu hao trong "+Thang +"/" +Nam +" thất bại!");
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=XoaPhanBoCongCuDungCu_SoCai&SoKhauHao="+SoKhauHao+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
//==================================================Tập hợp khấu hao công cụ dụng cụ  ============================
function TapHopKhauHaoCCDC()
{
    var index=document.getElementById("SelectMonth").selectedIndex;
    var Thang = document.getElementsByTagName("option")[index].value;
    var Nam = document.getElementById('txtNam').value;
    ResetTableDSCCDC();
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
                                        //tkchiphi,tkkhauhao,giatrikh;
                                      ShowChiTietPhanBoCCDC(column[0],column[1],column[2]);
                                    }
                                }
                            }
                        }                        
                        
                      }
                      else
                      {
                        alert("Không có công cụ dụng cụ khấu hao trong "+Thang +"/" +Nam);
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TapHopKhauHaoCongCuDungCu&Thang="+Thang+"&Nam="+Nam+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function ShowChiTietPhanBoCCDC(TKChiPhi,TKKhauHao,GiaTriKhauHao)
{                
        var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td class=\"Column0\">" + (lastRow-1) + "</td>";
            shtml +="      <td class=\"Column2\" style=\"text-align:left\" > <input type=\"hidden\" id=\"hdTKChiPhi_"+(lastRow-1)+"\" value=\""+TKChiPhi+"\"/>"+TKChiPhi+"</td>";          
            shtml +="      <td class=\"Column2\" style=\"text-align:center\"> <input type=\"hidden\" id=\"hdTKKhauHao_"+(lastRow-1)+"\" value=\""+TKKhauHao+"\"/>"+TKKhauHao+"</td>";
            shtml += "	   <td class=\"Column2\" style=\"text-align:right\"><input type=\"hidden\" id=\"hdGiaTriKhauHao_"+(lastRow-1)+"\" value=\""+GiaTriKhauHao+"\" />"+FormatSoTien(GiaTriKhauHao)+"</td>	";
                                
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
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
<form id="tinhkhauhao" name="tinhkhauhao" method="post" runat="server">
<%--<input type="hidden" name="secondtime" id="secondtime" />--%>
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
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr style="height:10px">
                    <td><div  class = "tdHeader">PHÂN BỔ CÔNG CỤ DỤNG CỤ</div></td>
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
                                                            <td class="tdLabel">Tháng phân bổ: </td>
                                                            <td  class="tdText">
                                                                <select id="SelectMonth" onchange="SelectMonth_SelectChange(this)" >
                                                                    <option value="1">1</option>
                                                                    <option value="2">2</option>
                                                                    <option value="3">3</option>
                                                                    <option value="4">4</option>
                                                                    <option value="5">5</option>
                                                                    <option value="6">6</option>
                                                                    <option value="7">7</option>
                                                                    <option value="8">8</option>
                                                                    <option value="9">9</option>
                                                                    <option value="10">10</option>
                                                                    <option value="11">11</option>
                                                                    <option value="12">12</option>
                                                                </select>                                                                
                                                                Năm :
                                                                <input id="txtNam" type="text" style="width:50px" />
                                                                <input id="txtSoKhauHao" type="hidden" style="width:50px" />
                                                            </td>                                                            
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">Diễn giải : </td>
                                                            <td colspan="6"  class="tdText">
                                                              <textarea id="txtDienGiai" style="width:570px" cols="20"  rows="2"></textarea></td>
                                                            
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td colspan="6" style="text-align:center">
                                                                                                                               
                                                                <input type="button" value="Tập hợp khấu hao CCDC" id="bt_Tim" onclick="TapHopKhauHaoCCDC()" style="width:169px;"  />
                                                                <input type="button" value="Lưu" id="bt_Luu" onclick="bt_Luu_Click()" style="width:100px;"  />
                                                                <input type="button" value="Xóa" id="Button1" onclick="XoaPhanBoKhauHaoTaiSan()" style="width:100px;"  />
                                                                <input type="button" value="Tạo mới"  style="width:100px" onclick="ResetTableDSCCDC()" id="bt_Reset" />
                                                                
                                                                
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
	    <tr>
	        <td>
	            <table class="TableGidview" id="TableDanhSach" style="width:700px;text-align:center;margin-left:200px;margin-right:200px">
                         <tr>
                              <td class ="tdHeader" colspan="4" >Chi tiết tập hợp khấu hao</td>
                         </tr>
		                <tr class="HeaderGidView">
		                     <td class="HeaderColumn0">STT</td>
                		    
		                     <td class="HeaderColumn1">
		                        Tài khoản chi phí
		                     </td>
                		     
		                     <td class="HeaderColumn2">
		                       Tài khoản khấu hao
                		       
		                    </td>
		                    <td class="HeaderColumn2">
		                       Giá trị khấu hao
		                    </td>
                		     
		                </tr>					 
                	 
	                </table>

	        </td>
	    </tr>
     </table>
   
</form>
<!--#include file = "footer.htm" -->
                                                  