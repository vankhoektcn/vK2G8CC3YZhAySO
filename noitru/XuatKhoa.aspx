<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XuatKhoa.aspx.cs" Inherits="NoiTru_XuatKhoa" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!--#include file ="../khoanoi/header.htm"-->
<style type="text/css">
		.black_overlay{
			display: none;
			position: absolute;
			top: 0%;
			left: 0%;
			width: 100%;
			height: 100%;
			background: url('../images/trongsuot.png');
			z-index:1001;
			-moz-opacity: 0.8;
			opacity:.80;
			filter: alpha;
		}
		.white_content {
			display: none;
			position:fixed;
			top: 25%;
			left: 25%;
			width: 20%;
			height: 15%;
			padding: 8px;
			border: 8px solid silver;
			background-color: white;
			z-index:1002;
			overflow: auto;
		}
		input[type="button"],input[type="submit"]{border:2px solid #cfcfcf;height:25px;background-color:#648ccc;color:white;font-weight:bold;}
        input[type="button"],input[type="submit"]:focus{border:1px solid #000;}
        input[type="button"],input[type="submit"]:hover{padding:1px 1px 1px 1px;background-color:#1d4b74;margin-bottom:-1px;cursor:pointer;}
	</style>

<script src="../js/jquery-1.6.1.min.js" type="text/javascript"> </script>

<script src="../js/jquery-ui.js" type="text/javascript"> </script>

<script src="../js/jquery.autocomplete.new.js" type="text/javascript"> </script>

<script src="../js/jquery.validate.js" type="text/javascript"> </script>

<script src="../js/myscriptvalid.js" type="text/javascript"> </script>

<script src="../js/jquery.alerts.js" type="text/javascript"> </script>

<script src="../js/timepicker.js" type="text/javascript"> </script>

<script src="../js/myscript.jqr.js" type="text/javascript"> </script>

<%--<link type="text/css" href="../css/DefaultBV.css" rel="Stylesheet" />--%>
<link type="text/css" href="../css/timepicker.css" rel="Stylesheet" />
<link type="text/css" href="../css/jquery-ui.css" rel="Stylesheet" />
<link type="text/css" href="../css/jtable.css" rel="Stylesheet" />
<%--<link type="text/css" href="../css/jquery.autocomplete.new.css" rel="Stylesheet" />--%>

<script language="javascript">
     
    var dp_cal1; 
      var dp_cal; 
	window.onload = function () 
	{
	  dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));
	    dp_cal= new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
	};
    $(document).ready(function() {
 	$('div.sola div a,input:image').click(function() {
 		$('#imghiep').show();
 	});
 	$(window).load(function() {
 		$('#imghiep').hide();
 	});
 
 	$("table.jtable tr:nth-child(odd)").addClass("odd");
 	$("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
 	$("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
 
 });

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
	////////////////////
	function loadPopupTTBN()
	{
	document.getElementById('light1').style.display='block';
	//document.getElementById('fade1').style.display='block';
	}
	function InPhieuChuyenVien(idbenhnhan)
	{
	    window.open("../khambenh/frmGiayChuyenVien.aspx?idbn="+idbenhnhan,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	}
	function InPhieuRaVien(idkhambenh)
	{
	    window.open("../nhanbenh/rptRaVien.aspx?idphieutt="+idkhambenh,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	}
	function ClosePopup()
	{
	    document.getElementById('light1').style.display='none';
	}
	function idkhosearch(obj)
         {
         //alert(document.getElementById("idkho").value);
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=idBenhViensearch&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc"),{
             minChars:0,
             width:350,
             addRow:true,
             scroll:true,
             header:"DANH SÁCH BỆNH VIỆN",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 SetBenhVien(data[1]);
                 //$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
      function SetBenhVien(idbenhvien)
      {
        document.getElementById("idkho").value=idbenhvien;
      }
function TimBenhVienTheoMa()
 {     
	    $("#txtMaBenhVien").unautocomplete().autocomplete("../nhanbenh/ajax.aspx?do=TimBenhVienTheoMa",
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
	    $("#txtBenhVien").unautocomplete().autocomplete("../nhanbenh/ajax.aspx?do=TimBenhVienTheoTen",
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
	    $("#txtMaChanDoan").unautocomplete().autocomplete("../nhanbenh/ajax.aspx?do=TimChanDoanTheoMa",
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
	    $("#txtChanDoan").unautocomplete().autocomplete("../nhanbenh/ajax.aspx?do=TimChanDoanTheoTen",
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
</script>

<form id="Form1" method="post" runat="server">
    <asp:scriptmanager runat="server" id="script1"></asp:scriptmanager>
    <asp:updatepanel runat="server" id="updatepanel3"><ContentTemplate>
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#D4D0C8; height: 10px;">
              <asp:placeholder ID="PlaceHolder1" runat="server"></asp:placeholder>
        </td>
    </tr>
    </table><%--#4D67A2--%>
<div style="width:90%;background-color:#D4c0c0;border:0px solid #4D67A2;height:auto;text-align:center" id="div1" runat="server">
<table style="width:100%;height:auto">
<tr>
<td style="width:100%;text-align:center">
    <asp:label  runat="server" text="XUẤT KHOA" id="lbXuatKhoa" Font-Bold="True" ForeColor="Blue"></asp:label>
</td>
</tr>
</table>
</div>
<br />
  <div style="display:'';width:95%;background-color:White;padding:0px 0px 0px 0px;border:4px solid silver;height:auto" id="divlydo" runat="server">
       <%--<asp:updatepanel runat="server" id="updatepanel1"><ContentTemplate>--%>
        <table  style="width:100%;background-color:Silver">
        <tr>
        <TD style="HEIGHT: 32px;color: #0000cc;font-weight:bold" class="Tieude" colSpan=5>I. Thông tin bệnh nhân
            <INPUT style="WIDTH: 33px" id="LoaiBn" type=hidden runat="server" />:&nbsp;&nbsp; </td>
        </tr>
        <tr>
        <td align="center">
        <table id="table2" style="width:90%;" rules="none">
        <tr>
        <td style="width:13%;padding-left:10px;" align="left">
        Mã bệnh nhân:        
        </td>
        <td style="width:20%" align="left">
            <asp:textbox runat="server" width="100%" id="txtMaBenhNhan"></asp:textbox>
            
        </td>
        <td style="width:13%;padding-left:10px" align="left">
            Tên bệnh nhân:</td>
        <td style="width:21%" align="left">
        <asp:textbox runat="server" width="100%" id="txtTenBenhNhan"></asp:textbox>
        </td>
        <td style="width:13%;padding-left:10px" align="left">
            Giới tính:</td>
        <td style="width:20%" align="left">
            <asp:dropdownlist runat="server" width="100%" id="ddlGioiTinh">
                <asp:ListItem Selected="True" Value="-1">---</asp:ListItem>
                <asp:ListItem Value="0">Nam</asp:ListItem>
                <asp:ListItem Value="1">Nữ</asp:ListItem>
            </asp:dropdownlist>
        </td>
        </tr>
        <tr>
        <td style="width:13%;padding-left:10px" align="left">Địa chỉ:</td>
        <td style="width:54%" align="left" colspan="3"><asp:textbox runat="server" width="100%" id="txtDiaChi"></asp:textbox></td>
        <%--<td style="width:13%;padding-left:10px" align="left"></td>
        <td style="width:21%" align="left"></td>--%>
        <td style="width:13%;padding-left:10px" align="left">Loại khám:</td>
        <td style="width:20%" align="left"><asp:dropdownlist runat="server" width="100%" id="ddlLoaiKham"></asp:dropdownlist></td>
        </tr>
        <tr>
        <td colspan="6"> 
            <asp:button runat="server" text="Tìm" id="btnTim" width="60px" OnClick="btnTim_Click" />
            <asp:button runat="server" text="Mới" id="btnMoi" width="60px" OnClick="btnMoi_Click" />
        </td>
        </tr>
        </table>
        </td>
        </tr>
        </table>
      <%--</ContentTemplate></asp:updatepanel> --%>     
  </div>  
  <div style="display:'';width:95%;background-color:White;padding:0px 0px 0px 0px;border:4px solid silver;" id="div2" runat="server">
       <asp:updatepanel runat="server" id="updatepanel2"><ContentTemplate>
       <table  style="width:100%;background-color:Silver" id="tableHuongDieuTri" runat="server" >
        <tr>
        <TD style="HEIGHT: 32px;color: #0000cc;font-weight:bold" class="Tieude" colSpan=5>II. Thông tin xuất khoa
            <input style="WIDTH: 33px" id="Hidden1" type=hidden runat="server" />:&nbsp;&nbsp; 
            <input style="WIDTH: 33px" id="hdIdKhamBenh" type="hidden" runat="server" />
            <input style="WIDTH: 33px" id="hdIdChiTietDKK" type="hidden" runat="server" />
            <input style="WIDTH: 33px" id="hdIdKBGoc" type="hidden" runat="server" />
            <input style="WIDTH: 33px" id="hdIdBN" type="hidden" runat="server" />
            <input style="WIDTH: 33px" id="hdLoaiBN" type="hidden" runat="server" />
            </td>
        </tr>
        <tr>
        <td align="center">
            <table  style="width:100%" rules="none" id="gridTable">
            <tr>
            <td style="width:15%;padding-left:5px" align="left">Chọn hướng điều trị:</td>
            <td style="width:18%;padding-left:10px" align="left"><asp:dropdownlist runat="server" width="100%" id="ddlHuongDieuTri" OnSelectedIndexChanged="ddlHuongDieuTri_SelectedIndexChanged" AutoPostBack="True"></asp:dropdownlist></td>
            <td style="width:10%;padding-left:10px"  align="left"><asp:Label runat="server" id="lbKhoa" visible="false" Text="Chọn Khoa:"></asp:Label></td>
            <td style="width:25%;padding-left:2px;padding-right:2px" align="left">
                <asp:dropdownlist runat="server" visible="false" width="100%" id="ddlKhoa" AutoPostBack="True" OnSelectedIndexChanged="ddlKhoa_SelectedIndexChanged"></asp:dropdownlist>
                <%--<asp:dropdownlist runat="server" visible="false" width="100%" id="ddlBenhVien" ></asp:dropdownlist>--%>
                <span visible="false" id="spBV" runat="server">
                <INPUT onfocus="TimBenhVienTheoMa();" style="WIDTH: 70px" runat="server" id="txtMaBenhVien"  type=text /><asp:textbox onfocus="TimBenhVienTheoTen();" id="txtBenhVien"  runat="server" width="400px"></asp:textbox>
                 Có điều dưỡng <input type="checkbox"  runat="server" id="cbCoDD"/> 
                &nbsp;&nbsp; &nbsp;&nbsp;  Có bác sĩ <input type="checkbox"  runat="server" id="cbCoBS"/>
                <input runat="server" type="hidden" id="hdIdBenhVien" />
                </span>
                <%--<input mkv='true' id='idkho' runat="server" type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idkho' runat="server" type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhosearch(this)' value='0' class='down_select'/>--%>
            </td>
            <td style="width:10%;padding-left:2px" align="left"><asp:Label runat="server" id="lbPhong" visible="false" Text="Chọn phòng"></asp:Label></td>
            <td style="width:30%;padding-left:2px" align="left"><asp:dropdownlist runat="server" width="100%" visible="false" id="ddlPhong"></asp:dropdownlist>
                    <%--<input mkv='true' id='MabenhVien' runat="server" type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhosearch(this)' value='0' class='down_select'/>--%>
            </td>
            <td></td>
            </tr>
            <tr visible="false" id="trChanDoan">
               <td  colspan="6" visible="false" id="tdChanDoan" align="left">    
               <span id="spChanDoan" runat="server" visible="false">           
               <table style="width:100%" id="Table1" runat="server">
                <tr>
                <td align="left" style="width:20%;padding-left:10px">Chẩn đoán ra viện: </td>
                <td align="left" style="width:80%;padding-left:10px">
                <input onfocus="TimChanDoanTheoMa();" style="WIDTH: 5%;" runat="server" id="txtMaChanDoan"  type=text /><asp:textbox onfocus="TimChanDoanTheoTen();" id="txtChanDoan"  runat="server" width="80%"></asp:textbox>
                <input runat="server" type="hidden" id="hdIdChanDoan" />
                </td>
                </tr>                
                </table>
                </span>                
               </td>               
             </tr>
            <tr visible="false" id="trChuyenVien">
            <td  colspan="6" visible="false" id="tdChuyenVien" align="left">
                <table style="width:100%" id="tbRaVien" runat="server" visible="false">
                <tr>
                <td align="left" style="width:20%;padding-left:10px">Phương pháp điều trị: </td>
                <td align="left" style="width:80%;padding-left:10px"><asp:textbox runat="server" width="100%" id="txtPhuongphap" textmode="multiline"></asp:textbox> </td>
                </tr>
                <tr>
                <td align="left" style="width:20%;padding-left:10px">Lời dặn của thầy thuốc: </td>
                <td align="left" style="width:80%;padding-left:10px"><asp:textbox runat="server" width="100%" height="70px" id="txtLoiDan" textmode="multiline"></asp:textbox> </td>
                </tr>
                </table>
            </td>
            </tr>
            <tr visible="false" id="tr1">
            <td  colspan="6"  id="td1" align="left">
                <table style="width:100%" id="tbTinhTrang" runat="server" visible="true">
                <tr>
                <td align="left" style="width:20%;padding-left:10px">Tình trạng xuất khoa: </td>
                <td align="left" style="width:80%;padding-left:10px">
                        <asp:dropdownlist runat="server" width="100%" id="ddlTinhTrang"></asp:dropdownlist>
                        <%--<select runat="server" id="slTinhTrangXK"><option value="1">Khỏi</option><option value="2">Đỡ, giảm</option><option value="3">Không thay đổi</option>
                                                <option value="4">Nặng hơn</option><option value="5">Tử vong</option>
                        </select>--%>
                </td>
                </tr>
                <tr>
                <td align="left" style="width:20%;padding-left:10px">Lý do xuất khoa: </td>
                <td align="left" style="width:80%;padding-left:10px"><asp:textbox runat="server" width="100%" height="30px" id="txtLySoXK" textmode="multiline"></asp:textbox> </td>
                </tr>
                </table>
            </td>
            </tr>
            <tr visible="false" id="trLuuXuat">
            <td colspan="6" style="" >
                <asp:button runat="server" text="Lưu" id="btnLuuXuatKhoa" width="60px" OnClick="btnLuuXuatKhoa_Click" />
                <asp:button runat="server" text="In giấy chuyển viện" id="btnInChuyenVien"  OnClick="btnInChuyenVien_Click" />
                <asp:button runat="server" text="In giấy xuất viện" id="btnInXuatVien"  OnClick="btnInXuatVien_Click" />
                <%--<asp:button runat="server" text="Mới" width="50px" id="btnMoiXuatKhoa" OnClick="btnMoiXuatKhoa_Click" />--%>
            </td>
            </tr>
            </table>
        </td>
        </tr>
        </table>
  </ContentTemplate></asp:updatepanel>
  </div> 
  <%--<asp:updatepanel runat="server" id="updatepanel3"><ContentTemplate>--%>
 <div style="LEFT: 10%; WIDTH: 80%; TOP: 28%; HEIGHT: 50%" id="light1" class="white_content">
 <asp:datagrid id="dgrBenhNhanNoiTru" runat="server" width="100%" visible="false" onitemcommand="dgr_ItemCommand" gridlines="None" forecolor="#333333" cellpadding="4" autogeneratecolumns="False" datakeyfield="idbenhnhan">
<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<EditItemStyle BackColor="#2461BF"></EditItemStyle>

<SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedItemStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>

<ItemStyle BackColor="#EFF3FB"></ItemStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>
<Columns>
 <asp:ButtonColumn CommandName="ViewTTBN" Text="Chọn" HeaderText="Chọn BN" ></asp:ButtonColumn>
<asp:BoundColumn DataField="mabenhnhan"   HeaderText="Mã bệnh nhân">
<ItemStyle HorizontalAlign="left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

</asp:BoundColumn>

<asp:BoundColumn DataField="tenbenhnhan"   HeaderText="Tên bệnh nhân">
<ItemStyle HorizontalAlign="left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

</asp:BoundColumn>
 
 <asp:BoundColumn DataField="ngaysinh" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Ngày sinh">

<ItemStyle HorizontalAlign="left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
    
</asp:BoundColumn>

 </Columns>

</asp:datagrid> <BR /><div style="TEXT-ALIGN: center"><%--<asp:button id="btnAnTTBN" onclick="btnAnTTBN_Click" runat="server" text="Đóng lại"></asp:button>--%>
<input type="button" value="Đóng" onclick="ClosePopup()" id="btDongKhungTim" />
 </div>
 </div>
 </ContentTemplate></asp:updatepanel>
</form>
<!--#include file ="../khoanoi/footer.htm"-->
