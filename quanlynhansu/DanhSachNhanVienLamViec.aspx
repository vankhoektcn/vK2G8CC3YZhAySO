<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhSachNhanVienLamViec.aspx.cs" EnableEventValidation ="false" Inherits="quanlynhansu_DanhSachNhanVienLamViec" %>

<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->

    
<script language="javascript">
var dp_cal, dp_cal1;      
	window.onload = function () 
	{
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtNgayLamViec'));
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

</script>

<form id="Form1" method="post" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: #C0C0C0">
        <tr>
            <td width="100%" align="left" style="background-color: #FBF8F1; height: 19px;">
                <uc1:uscmenu ID="Uscmenu1" runat="server" />
            </td>
        </tr>
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="100%" align="left" style="background-color: White">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td valign="top" style="padding-left: 0px; padding-top: 0px; width: 100%;">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px">
                                        <table id="user" cellspacing="1" cellpadding="1" width="100%" border="0" class="khung">
                                            <tr>
                                                <td align="center" style="width: 100%; background-color: #FBF8F1; height: 19px; background-image: url(../images/menu.jpg);
                                                    color: Red; font-weight: bold">
                                                    Danh sách nhân viên làm việc</td>
                                            </tr>
                                            <tr>
                                                <td width="100%" align="center">
                                                    <table cellpadding="0" width="100%" border="0">
                                                        <tr>
                                                            <td valign="top" align="center" width="100%" style="height: 151px">
                                                                <table cellspacing="0" cellpadding="0" width="98%" border="0">
                                                                    <tr style="padding-bottom: 5px; padding-top: 10px">
                                                                        <td align="center" style="height: 81px; padding-left: 50px; width: 100%;">
                                                                            <table width="1000px" rules="none" style="border-color: Blue; border-style: double;
                                                                                border: 4px">
                                                                                <tr align="left">
                                                                                    <td valign="top"  nowrap align="left" style="height: 23px; width: 250px;">
                                                                                        <p class="ptext">
                                                                                            Phòng ban :&nbsp;
                                                                                             <asp:dropdownlist id="ddlPhongBan" runat="server" width="180px" TabIndex="4" AutoPostBack="false"  ></asp:dropdownlist>
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top"  align="left" style="height: 40px; padding-left: 10px; width: 100px;">
                                                                                        <p class="ptext">
                                                                                            Ngày làm việc:
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="left"  style="width: 100px; height: 40px;padding-right:10px" >
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txtNgayLamViec" class="input" runat="server" width="100px" tabindex="4"></asp:textbox>
                                                                                            &nbsp;</p>
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <asp:button runat="server" onclick="btnTim_Click" CSSclass="btn" text="Tìm" id="btnTim" />
                                                                                         <asp:button runat="server" onclick="imgInExel_Click" CSSclass="btn" text="Xuất Excel" id="btnXuatExcel" />
                                                                                    </td>
                                                                                </tr>                                                                        
                                                                                
                                                                            </table>
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" width="100%" border="0">
                                                        <tr>
                                                            <td align="left" style="width: 100%; background-color: #FBF8F1; height: 19px; background-image: url(../images/menu.jpg);
                                                                color: White; font-weight: bold">
                                                                &nbsp;DANH SÁCH NHÂN VIÊN</td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" width="100%" border="0" style="background-color: #D4D0C8">
                                                        <tr>
                                                            <td valign="top" align="right" colspan="2"  style="width:80%;background-color: #D4D0C8">
                                                                <asp:datagrid id="dgr" tabindex="12" runat="server" width="100%" allowsorting="True"
                                                                    autogeneratecolumns="False" datakeyfield="idchamcongtheongay" borderwidth="1px" bordercolor="Silver"
                                                                    onitemdatabound="dgr_ItemDataBound" cellpadding="2" allowpaging="True"
                                                                    pagesize="40">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>
<asp:BoundColumn></asp:BoundColumn>
<asp:BoundColumn></asp:BoundColumn>
<asp:BoundColumn DataField="stt" HeaderText="STT"></asp:BoundColumn>
<asp:BoundColumn DataField="tennhanvien" HeaderText="Nh&#226;n vi&#234;n">
<HeaderStyle Wrap="False" Width="20%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="manhanvien" HeaderText="Mã nh&#226;n vi&#234;n">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaysinh" HeaderText="Ngày sinh"></asp:BoundColumn>
<asp:BoundColumn DataField="gioitinh" HeaderText="Giới tính"></asp:BoundColumn>
<asp:BoundColumn DataField="cmnd" HeaderText="CMND"></asp:BoundColumn>
<asp:BoundColumn DataField="diachithuongtru" HeaderText="ĐC thường trú"></asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" BackColor="#FFE0C0" CssClass="dgrHeader" Font-Bold="True" ForeColor="Blue"></HeaderStyle>
</asp:datagrid>
                                                                &nbsp;
                                                                <input id="listIdNV" type="hidden" />
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
</form>
<!--#include file ="footer.htm"-->
