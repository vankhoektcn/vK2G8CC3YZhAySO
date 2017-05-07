<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nvk_BaoCao15NgaySuDung.aspx.cs"
    Inherits="nvk_BaoCao15NgaySuDung" %>

<!--#include file ="../KhoaNoi/header.htm" -->

<script language="javascript">
    
    var dp_cal1; 
      var dp_cal; 
	window.onload = function () 
	{
//	  dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));
//	    dp_cal= new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
	};
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
	
	
function TABLE1_onclick() {



}
function Excel_Click()
	{
	    $("#spDangXuatExcell").html("<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang chạy xin chờ.....<img id='imgLoading' src='../images/processing.gif' /></span>");
	}
	function DoneExcell()
	{
	    $("#spDangXuatExcell").html("");
	}
</script>

<form id="Form1" method="post" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: #C0C0C0">
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8; height: 10px;">
                <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px">
                            <table id="user" cellspacing="1" cellpadding="1" width="100%" border="0" class="khung">
                                <tr>
                                    <td class="title" align="center" style="background-color: #4D67A2; height: 25px;">
                                        <strong><span class="title" style="color: #FFFFFF">BÁO CÁO SỬ DỤNG THUỐC 15 NGÀY</span></strong></td>
                                </tr>
                                <tr>
                                    <td width="100%" align="center">
                                    <table>
                                           
                                            <tr>
                                                <td style="width: 100px">
                                                    Đối tượng</td>
                                                <td style="width: 100px">
                                                    <asp:dropdownlist id="chbLoaiThuoc" runat="server" width="150px"></asp:dropdownlist>
                                                </td>
                                                <td style="width: 100px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                                    Từ Ngày :</td>
                                                <td style="width: 100px">
													     <asp:textbox id="txtTuNgay" runat="server" tabindex="1" width="145px"  onfocus="$(this).datepick();" onblur="nvk_testDate_this(this);" ></asp:textbox>
                                                </td>
                                                <td style="width: 100px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px; height: 26px">
                                                    &nbsp;Đến Ngày :</td>
                                                <td style="width: 100px; height: 26px">
                                                                      <asp:textbox id="txtDenNgay" runat="server" tabindex="1" width="142px"  onfocus="$(this).datepick();" onblur="nvk_testDate_this(this);" ></asp:textbox>
                                                </td>
                                                <td style="width: 100px; height: 26px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                                </td>
                                                <td style="width: 100px">
                                                    <asp:button id="btnTim" runat="server" text="Lấy Danh sách"  OnClientClick="Excel_Click();"  OnClick="btnTim_Click" Width="145px" />
                                                    
                                                </td>
                                                <td style="width: 100px">
                                                </td>
                                            </tr>
                                        </table>
                                        <div runat="server" id="spDangXuatExcell"></div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</form>
<!--#include file ="../KhoaNoi/footer.htm"-->
