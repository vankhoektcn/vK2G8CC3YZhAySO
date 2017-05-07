<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTHT_CongNoDauKy.aspx.cs" Inherits="KTHT_CongNoDauKy" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_HeThong.ascx" TagName="uscmenuKT_HeThong" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<!--#include file = "header.htm" -->

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
   
    window.window.onload = function () 
    {
         var queryString = "";
	    queryString =  window.location.search.substring(1).split('&');
	    if(queryString!="")
	    {
	        var Nam = queryString[0].split('=');
	        var TaiKhoan = queryString[1].split('=');
	        var MaKH = queryString[2].split('=');  
	        var TenBenhNhan = queryString[3].split('=');  
	        var TenKhachHang = queryString[4].split('=');  
	        var TenNhaCungCap = queryString[5].split('=');  
	        var DuNo = queryString[6].split('=');  
	        var DuCo = queryString[7].split('=');  
	          ShowChiTietCongNoDauKy(Nam[1],TaiKhoan[1],MaKH[1],TenBenhNhan[1],TenKhachHang[1],TenNhaCungCap[1],DuNo[1],DuCo[1]);

	    }
        
    }
	function LoadTieuDe()
    {
        var obj = document.getElementById("tieudepk");
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                obj.innerHTML = value;                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=LoadTieuDe&times="+Math.random(),true);
        xmlHttp.send(null);
    }
  
    function TestdatePhieu(t)
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
	
function FormatSoTien(obj)
{
   return formatCurrency(obj);
}
function getFunctionFormatSoTien(Ctr)
{
    Ctr.value = FormatSoTien(Ctr.value);
}


var CheckType="BenhNhan";
function RadioChecked(Ctr)
{
    
    if(Ctr == "NhaCungCap")
    {
      CheckType="NhaCungCap";
      document.getElementById('txtMaKH').value="";
      document.getElementById('txtTenKH').value="";
             
      ResetDataonTable();
    }
    
    else
    if(Ctr == "KhachHang")
    {
      CheckType="KhachHang";
      document.getElementById('txtMaKH').value="";
      document.getElementById('txtTenKH').value="";
      ResetDataonTable();
  
    }
    else
    if(Ctr == "BenhNhan")
    {
      CheckType="BenhNhan";
      document.getElementById('txtMaKH').value="";
      document.getElementById('txtTenKH').value="";
      ResetDataonTable();
  
    }
   
   
}

function ResetDataonTable()
{
   document.getElementById('tb_Nam').value="";
   document.getElementById('tb_MaTK').value="";
   document.getElementById('txtMaKH').value="";
   document.getElementById('txtTenKH').value="";
   document.getElementById('tb_DuNoDauKy').value="";
   document.getElementById('tb_DuCoDauKy').value="";
   
   ResetTableDSPhieuThu();   
    
}
function ResetTableDSPhieuThu()
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

function ShowKhachHang(obj)
{
    if(CheckType =="BenhNhan")
    {
        var objsrc = document.getElementById(obj);
      
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachBenhNhan&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:700,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    setChonBenhNhan(data[2],data[3],data[4]);
                                                                   // document.getElementById(obj).blur();
                                                                }
                                                            ); 
    }         
    else
    if(CheckType =="KhachHang")
    {
         var objsrc = document.getElementById(obj);
      
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachKhachHang&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:700,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    setChonKhachHang(data[2],data[3]);
                                                                   // document.getElementById(obj).blur();
                                                                }
                                                            ); 
    }
    else
    if(CheckType =="NhaCungCap")
    {
          var objsrc = document.getElementById(obj);
      
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachNhaCungCap&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:300,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    setChonNCC(data[2],data[3],data[4]);
                                                                    //document.getElementById(obj).blur();
                                                                }
                                                            ); 
    }
}

function setChonBenhNhan(MaKH,TenKH,idBenhNhan)
{
      
      var txtMaKH=document.getElementById('txtMaKH');
      var txtTenKH=document.getElementById('txtMaKH');
      txtMaKH.value=MaKH;
      txtTenKH.value = TenKH;
      
}
function setChonKhachHang(MaKH,TenKH)
{
      
      var txtMaKH=document.getElementById('txtMaKH');
      var txtTenKH=document.getElementById('txtTenKH');
      txtMaKH.value=MaKH;
      txtTenKH.value = TenKH;
      
     
}
function setChonNCC(idNCC,MaNCC,TenNCC)
{
      
      var txtMaNCC=document.getElementById('txtMaKH');
      var txtTenNCC=document.getElementById('txtTenKH');
     
      txtMaNCC.value=idNCC;
      txtTenNCC.value = TenNCC;
     
      //alert(hd_IDBN.value);
      document.getElementById('txtTenNCC').focus();
}
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
                                                                setChonTaiKhoan(data[2],obj);
                                                               // document.getElementById(obj).blur();
                                                            }
                                                        );           
}

function setChonTaiKhoan(MaTaiKhoan,idText)
{
      if(idText!="")
      {
          var txtTaiKhoan=document.getElementById(idText);
          txtTaiKhoan.value=MaTaiKhoan;
        document.getElementById(idText).focus();
      }
}
function LuuCongNoDauKy(Ctr)
{
     var Nam  = document.getElementById('tb_Nam').value;
     var TK  = document.getElementById('tb_MaTK').value;
     var Ma_KH  = document.getElementById('txtMaKH').value;
     var DuNo  = document.getElementById('tb_DuNoDauKy').value;
     var DuCo  = document.getElementById('tb_DuCoDauKy').value;
     if(Nam=="")
     {
        alert("Chưa nhập năm. Vui lòng kiểm tra lại. Cảm ơn!");
     }
     else
     if(TK=="")
     {
        alert("Chưa nhập năm. Vui lòng kiểm tra lại. Cảm ơn!");
     }else
     if(Ma_KH=="")
     {
        alert("Chưa nhập năm. Vui lòng kiểm tra lại. Cảm ơn!");
     }
     else
     {
        getFunctionLuuCongNoDauKy(Nam,TK,Ma_KH,ChangeFormatCurrency(DuNo),ChangeFormatCurrency(DuCo));
     }
}
function getFunctionLuuCongNoDauKy(nam,tk,ma_kh,du_no0,du_co0)
{
     xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
               if(value=="1")
               {
                    alert("Lưu công nợ đầu kỳ thành công!");
                    LoadDanhSachCongNoDauKy();
               }
               else
                alert("Lưu công nợ đầu kỳ thất bại!");
                
            }
        }
         
          xmlHttp.open("GET","ajax.aspx?do=LuuCongNoDauKy&nam="+nam+"&tk="+tk+"&ma_kh="+ma_kh+"&du_no0="+du_no0+"&du_co0="+du_co0+"&times="+Math.random(),true);
        xmlHttp.send(null);
}

function LoadDanhSachCongNoDauKy()
{
    
      var nam = document.getElementById('tb_Nam').value;
      var tk  = document.getElementById('tb_MaTK').value;
      var ma_kh = document.getElementById('txtMaKH').value;
      ResetTableDSPhieuThu();
      xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
               if(value!="")
               {
                   var Row = value.split('&');
                   for(i=1;i<Row.length;i++)
                   {
                        var data = Row[i].split('|');
                        //nam0,tk1,tk.tentaikhoan2,ma_kh3,bn.tenbenhnhan4, kh.tenkhachhang5,ncc.TenNhaCungCap6,du_no07,du_co08
                        ShowDanhSachCongNoDauKy(data[0],data[1],data[2],data[3],data[4],data[5],data[6],data[7],data[8]);
                   }
               }
               else
                alert("Không có danh sách công nợ!");
                
            }
        }
         
          xmlHttp.open("GET","ajax.aspx?do=LoadDanhSachCongNoDauKy&nam="+nam+"&tk="+tk+"&ma_kh="+ma_kh+"&type="+CheckType+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function ShowDanhSachCongNoDauKy(Nam,TaiKhoan,TenTaiKhoan,MaKH,TenBenhNhan,TenKhachHang,TenNhaCungCap,DuNo,DuCo)
{
    var TenKH = "";
    if(TenBenhNhan!="")
     {
        TenKH = TenBenhNhan;
     }
    else
    if(TenKhachHang!="")
       {
         TenKH = TenKhachHang;
       }
         else
        if(TenNhaCungCap!="")
        {
            TenKH = TenNhaCungCap;
        }
        var link = "KTHT_CongNoDauKy.aspx";
    var TableDanhSach = document.getElementById('TableDanhSach');
    var lastRow = TableDanhSach.rows.length; 
    var shtml = "<tr class=\"RowGidView\">";
        shtml += "		<td class=\"Column0\">" + (lastRow-1) + "</td>";
        shtml += "		<td style=\"width:50px\"> <label onclick=\"ShowChiTietCongNoDauKy('"+Nam+"','"+TaiKhoan+"','"+MaKH+"','"+TenBenhNhan+"','"+TenKhachHang+"','"+TenNhaCungCap+"','"+DuNo+"','"+DuCo+"')\" style=\"cursor:pointer;color:Blue\" >Sửa</label></td>	";
        shtml += "		<td style=\"width:50px\">"+Nam+"</td>	";
        shtml +="       <td style=\"width:100px\"><input type=\"hidden\" id=\"hdTaiKhoan_"+(lastRow)+"\" value=\""+TaiKhoan+"\"/>"+TaiKhoan+"</td>";
        shtml +="       <td style=\"width:200px\"><input type=\"hidden\" id=\"hdTenTaiKhoan_"+(lastRow)+"\" value=\""+TenTaiKhoan+"\"/>"+TenTaiKhoan+"</td>";
        shtml += "		<td style=\"width:200px\"><input type=\"hidden\" id=\"hdMaKH_"+(lastRow)+"\" value=\""+MaKH+"\"/>"+MaKH+"</td>	";
        shtml += "		<td style=\"width:300px\" style=\"text-align:left\">"+TenKH+"</td>	"; 
        shtml += "		<td style=\"width:200px\"> <input id=\"txtDuNo_"+(lastRow)+"\" class=\"InputTien\" type=\"text\" readonly=\"readonly\" value=\""+FormatSoTien(DuNo)+"\" /></td>	"; 
        shtml += "		<td style=\"width:200px\"> <input id=\"txtDuCo_"+(lastRow)+"\" class=\"InputTien\" type=\"text\" readonly=\"readonly\" value=\""+FormatSoTien(DuCo)+"\" /></td>	";  
               
     shtml += "	</tr>";
  $("#TableDanhSach:last").append(shtml);
 
}
function ShowChiTietCongNoDauKy(Nam,TaiKhoan,MaKH,TenBenhNhan,TenKhachHang,TenNhaCungCap,DuNo,DuCo)
{
   document.getElementById('tb_Nam').value=Nam;
   document.getElementById('tb_MaTK').value=TaiKhoan;
   
   document.getElementById('txtMaKH').value=MaKH;
   if(TenBenhNhan!="")
    document.getElementById('txtTenKH').value=TenBenhNhan;
    else
    if(TenKhachHang!="")
        document.getElementById('txtTenKH').value=TenKhachHang;
    else
    if(TenNhaCungCap!="")
        document.getElementById('txtTenKH').value=TenNhaCungCap;        
   document.getElementById('tb_DuNoDauKy').value=FormatSoTien(DuNo);
   document.getElementById('tb_DuCoDauKy').value=FormatSoTien(DuCo);
}
</script><form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:uscmenuKT_HeThong ID="uscmenuKT_HeThong" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr>
                  <td class ="tdHeader" colspan="10" >CÔNG NỢ ĐẦU KỲ</td>
                </tr>
                <tr>
					    <td width="100%" valign = "top">
						    <table cellPadding="0" width="100%" border="0">
							    <tr>
								    <td vAlign="top" align="center" width="100%">
									    <table cellSpacing="0" cellPadding="0" width="98%" border="0">
										    
										    <tr style="PADDING-BOTTOM: 5px; PADDING-TOP: 10px">
											    <td align="left"  style="height: 20px;width:100%;padding-left:200px">
												     <table>
                                                            <tr>
                                                                <td align="left">
                                                                   <b> Năm : </b> 
                                                                   
                                                                </td>
                                                                <td>
                                                                   <%-- <asp:TextBox runat="server" ID="tb_Nam" Width="50px" ></asp:TextBox>
                                                                    <asp:DropDownList runat="server" ID="ddl_LoaiTK" OnSelectedIndexChanged="ddl_LoaiTK_SelectedIndexChanged">
                                                                        <asp:ListItem Text="Nợ" Value="N" Selected="True"></asp:ListItem>
                                                                        <asp:ListItem Text="Có" Value="C" Selected="false"></asp:ListItem>
                                                                    </asp:DropDownList>--%>
                                                                    <input type="text" id="tb_Nam" title="Năm" style="width:50px" />
                                                                   
                                                                </td>
                                                               
                                                            </tr>
                                                            <tr>
                                                                <td> <b>Tài khoản : </b></td>
                                                                <td align="left">
                                                                    <%--<asp:TextBox runat="server" ToolTip="Chọn mã tài khoản" ID="" Width="100px" ></asp:TextBox>--%>
                                                                      <input type="text" id="tb_MaTK" onfocus="ShowTaiKhoan('tb_MaTK')" title="Chọn mã tài khoản" style="width:100px" />
                                                                </td>
                                                               
                                                            </tr>
                                                           
                                                            <tr>
                                                                <td align="center">
                                                                  <input id="rd_KhachHang" name="CheckType" type="radio" value="KhachHang" title="Khách hàng" checked="checked" onclick='RadioChecked(this.value)' /><b style="color:Blue"> Khách hàng</b>
                                                                </td>
                                                                <td align="center">
                                                                  <input id="rd_BenhNhan" name="CheckType" type="radio" value="BenhNhan" title="Bệnh nhân" checked="checked" onclick='RadioChecked(this.value)' /><b style="color:Blue"> Bệnh nhân</b>
                                                                </td>
												                <td align="center">
                                                                    <input id="rd_NhaCungCap" name="CheckType" type="radio" value="NhaCungCap" title="Nhà cung cấp"   onclick='RadioChecked(this.value)' /><b style="color:Blue"> Nhà cung cấp</b>
                                                                   
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <b>Khách hàng/Nhà cung cấp :</b>
                                                                </td>
                                                                <td align="left" colspan="2">                                                                   
                                                                   <input type="text" id="txtTenKH" onfocus="ShowKhachHang('txtTenKH')" title="Tên khách hàng hoặc nhà cung cấp" style="width:200px" /> 
                                                                </td>
                                                                <td> 
                                                                    <input type="hidden" id="txtMaKH" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 26px">
                                                                    <b>Dư nợ :</b>
                                                                </td>
                                                                 <td align="left" style="height: 26px">                                                                    
                                                                    <input type="text" id="tb_DuNoDauKy" title="Số dự nợ đầu kỳ" onchange="getFunctionFormatSoTien(this)" style="width:200px;text-align:right" /> 
                                                                </td>
                                                                <td style="height: 26px"><b>VND</b></td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td>
                                                                    <b>Dư có :</b>
                                                                </td>
                                                                 <td align="left">
                                                                    <%--<asp:TextBox runat="server" ToolTip="Số dư có đầu kỳ" ID="tb_DuCoDauKy"  Width="200px" ></asp:TextBox>--%>
                                                                    <input type="text" id="tb_DuCoDauKy" title="Số dư có đầu kỳ" onchange="getFunctionFormatSoTien(this)" style="width:200px;text-align:right" /> 
                                                                </td>
                                                                <td><b>VND</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 26px">
                                                                    <b>Số hóa đơn:</b>
                                                                </td>
                                                                 <td align="left" style="height: 26px">                                                                    
                                                                    <input type="text" id="txtsohoadon" style="width:200px;text-align:right" /> 
                                                                </td>                                                               
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 26px">
                                                                    <b>Hạn Thanh Toán:</b>
                                                                </td>
                                                                 <td align="left" style="height: 26px">                                                                    
                                                                    <input type="text" id="txthanthanhtoan" style="width:200px;text-align:right" /> 
                                                                </td>                                                               
                                                            </tr>
                                                           <tr>
							                                    <td colspan="3" align="center">
							                                        <input type="button" id="bt_Add" onclick="LuuCongNoDauKy(this)" style="width:80px" value="Lưu"/>
							                                        <input type="button" id="bt_Search" style="width:80px" value="Tìm kiếm" onclick="LoadDanhSachCongNoDauKy()"/>
							                                           <input type="button" id="bt_TaoMoi" style="width:80px" value="Tạo mới" onclick="ResetDataonTable()"/>
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
              <td class ="tdHeader" colspan="10" >Danh sách công nợ đầu kỳ</td>
         </tr>
		<tr class="HeaderGidView">
		     <td class="HeaderColumn0" >STT</td>
		    <td style="width:50px">
		        Sửa
		     </td>
		     <td style="width:50px">
		        Năm
		     </td>
		     <td style="width:100px">
		       Tài khoản
		       
		    </td>
		    <td style="width:200px">
		        Tên tài khoản
		    </td>
		    <td style="width:200px">
		        Mã khách hàng
		       
		    </td>
		    <td style="width:300px">
		        Tên khách hàng
		       
		    </td>
		    <td style="width:200px">
		        Dư nợ đầu kỳ
		       
		    </td>
		    <td style="width:200px">
		        Dư có đầu kỳ
		       
		    </td>
		</tr>					 
					  
	</table>    
   </form>         
<!--#include file = "footer.htm" -->
