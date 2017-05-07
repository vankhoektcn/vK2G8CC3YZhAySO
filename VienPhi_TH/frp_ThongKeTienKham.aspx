<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="frp_ThongKeTienKham.aspx.cs" Inherits="frp_ThongKeTienKham" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
 
<!-- #include file="header.htm" -->
<%@ Register Src="uscmenu.ascx" TagName="uscMenu" TagPrefix="uc1" %>
<script language = "javascript">
   var dp_cal1; 
      var dp_cal; 
	window.onload = function () 
	{
	  dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));
	    dp_cal= new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
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
	function checkvalid()
	{
	    //var kho = document.getElementById("ddlkho");
	    var tungay = document.getElementById("txtTuNgay");
	    var denngay = document.getElementById("txtDenNgay");
	    if(tungay.value == "")
	    {
	        alert("Vui lòng chọn ngày!");
	        tungay.focus();
	        return false;
	    }
	    if(denngay.value == "")
	    {
	        alert("Vui lòng chọn ngày!");
	        denngay.focus();
	        return false;
	    }
	    return true;
	}
</script>
<form id="Form1" method="post" runat="server">

<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
   <%-- <tr>
        <td width = "100%" align = "left" style="background-color:#D4D0C8; height: 10px;">
            &nbsp;<uc3:uscmenu ID="Uscmenu" runat="server" />
        </td>
    </tr>--%>
    <tr>
                    <td >
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
        <table cellspacing="1" cellpadding="1" width="98%" border="0" class = "khung">
	    <tr>
		    <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px">
			    <table id="user" cellSpacing="0" cellPadding="0" width="100%" border="0">
				    <tr>
				        <td class="title" colspan = "2" align = "center" style="background-color: #4D67A2; height: 19px;">
					        <p class="title" style ="color:#FFFFFF">
                                BÁO CÁO THU TIỀN KHÁM BỆNH + BÁN SỔ</p>
				        </td>
			        </tr>
				    <TR>
					    <TD width="100%">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="left" width="100%">
									    <TABLE cellSpacing="0" cellPadding="0" width="98%" border="0" style="height: 40px">
										    
										    <TR >
											    <TD align="left" style="height: 23px; width: 100%;">
												    <TABLE style="HEIGHT: 1px; width: 100%;" cellSpacing="0" cellPadding="3PX" border="0">
													   <tr style="text-align:left">	
													        <td align="center" colspan="2">Từ Ngày :<asp:textbox id="txtTuNgay" runat="server" tabindex="1" width="118px"></asp:textbox>
                                                                <input id="Button4" onclick="dp_cal1.toggle()" style="width: 25px" type="button"
                                                                    value="..." />&nbsp; 
                                                                    Đến Ngày :
                                                                      <asp:textbox id="txtDenNgay" runat="server" tabindex="1" width="118px"></asp:textbox>
                                                                <input id="Button1" onclick="dp_cal.toggle()" style="width: 25px" type="button"
                                                                    value="..." />
                                                                &nbsp; &nbsp;                                                               </td>				                                        
                                                           
				                                        </tr>
				                                        <tr style="text-align:left">
				                                            <td align="center" style="height: 22px" colspan="2">
                                                           <asp:scriptmanager runat="server" id="ScriptM"></asp:scriptmanager>
				                                              <asp:updatepanel runat="server" id="updatep"><ContentTemplate>
                                                                &nbsp;Khoa phòng
                                                                <asp:dropdownlist id="ddlPhongKhoa" runat="server"  AutoPostback="True" onselectedindexchanged="ddlPhongKhoa_SelectedIndexChanged"
                                                                    width="189px"></asp:dropdownlist>&nbsp;
                                                                &nbsp;&nbsp;&nbsp;
                                                                Phòng số:<asp:dropdownlist id="ddPhongSo" runat="server" Width="226px"  AutoPostback="True"></asp:dropdownlist>
                                                                <asp:dropdownlist id="ddlBacSi" runat="server" Width="206px"  AutoPostback="True" Visible="False"></asp:dropdownlist>
                                                           </ContentTemplate>
                                                        </asp:updatepanel>
				                                            
				                                            </td>				                                           
				                                        </tr>
				                                        <tr >
				                                            <td align="center" colspan="2">
				                                                <asp:button id="btnTim" runat="server" text="Lấy Danh sách" onClientClick="return checkvalid();" OnClick="btnTim_Click" />
				                                            </td>
				                                        </tr>
												    </TABLE>
                                                  </TD>
										    </TR>
									    </TABLE>
								    </TD>
							    </TR>
						    </TABLE>
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="left" width="100%" colSpan="2" height="20">
                                        &nbsp;</TD>
							    </TR>
						    </TABLE>
					    </TD>
				    </TR>
				    <tr>
	                    <td style ="width: 100%;">
	                        <div id  = "infospace" runat = "server"></div>
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
<!-- #include file="footer.htm" -->