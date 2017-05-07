<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation ="false" CodeFile="nhanvienentry.aspx.cs" Inherits="nhanvienentry" %>

<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->  
<script language="javascript">
var dp_cal1;
        var dp_cal2;
        var dp_cal3;
        var dp_cal4;
        var dp_cal5;
	    window.onload = function () 
	    {
	        dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtngaysinh'));  
	        dp_cal2 = new Epoch('epoch_popup','popup',document.getElementById('txtNgayVaoLam'));	
	        dp_cal3 = new Epoch('epoch_popup','popup',document.getElementById('txtNgayCapCMND'));	   
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
</script>

<form id="Form1" method="post" runat="server">
<div style="width:100%;text-align:left">
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: White">
            <tr>
            <td width="100%" align="left" style="background-color: #FBF8F1; height: 19px;">
                <uc1:uscmenu ID="Uscmenu1" runat="server" />
            </td>
        </tr>
    </table>
</div>
    <table cellpadding="0" cellspacing="0" border="0" width="95%" style="background-color: White">
        <%--#C0C0C0,#D4D0C8--%>

        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="100%" align="left" style="background-color: White">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px">
                            <table id="user" cellspacing="1" cellpadding="1" width="100%" border="0">
                                <tr>
                                    <td  id="tdHeader"  runat="server" align="left" style="width: 100%; padding-left: 20px; background-color: #FBF8F1;
                                        height: 19px; background-image: url(../images/menu.jpg); color: Red; font-weight: bold">
                                        DANH MỤC NHÂN VIÊN
                                    </td>
                                    <%--<td class="title" align = "center" style ="background-color: #4D67A2">
			                <span class="title" style ="color:#FFFFFF">DANH SÁCH NHÂN VIÊN</span>
		                </td>--%>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="center" width="100%" style="height: 230px">
                                                    <table cellspacing="0" cellpadding="0" width="98%" border="0">
                                                        <tr style="padding-bottom: 5px; padding-top: 10px">
                                                            <td align="left" width="100%" style="height: 100px; padding-left: 50px">
                                                                <table width="700px" rules="none" style="border-color: Blue; border-style: double;
                                                                    border: 4px" id="TABLE1" onclick="return TABLE1_onclick()" bgcolor="#d0ccd9">
                                                                    <tr>
                                                                        <td valign="top" align="right" style="width: 119px; height: 27px;" >
                                                                            <span class="ptext">Tên nhân viên :</span></td>
                                                                        <td valign="top" align="left" style="width: 240px; height: 27px;" colspan="3">
                                                                            <span class="ptext">
                                                                                <asp:textbox CssClass="input" id="txtTenNhanVien" runat="server" width="193px" tabindex="1" readonly="False"></asp:textbox>
                                                                                <asp:label id="Label3" runat="server" forecolor="Red" text="(*)"></asp:label></span></td>
                                                                        <td align="right" style="padding-left:0px;padding-right:0px; height: 27px; width: 99px;">
                                                                        Mã nhân viên:
                                                                        </td>
                                                                        <td align="left" style="width: 225px; height: 27px;">
                                                                        <asp:textbox id="txtMaNhanVien" CssClass="input"
                                                                                    runat="server" width="185px" tabindex="20"></asp:textbox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" nowrap align="right" style="width: 119px" >
                                                                            <span class="ptext">Ngày sinh :</span></td>
                                                                        <td valign="top" align="left"  style="width:240px; height: 27px;" colspan="3">
                                                                            <span class="ptext"><asp:textbox CssClass="input" id="txtngaysinh" runat="server" tabindex="3"
                                                                                width="100px"></asp:textbox>(dd/MM/yyyy)&nbsp;
                                                                                <asp:label id="Label4" runat="server" forecolor="Red" text="(*)"></asp:label>
                                                                            </span></td>
                                                                        <td align="right" style="width: 99px;padding-left:0px;padding-right:0px;  height: 27px;">
                                                                        Giới tính:
                                                                        </td>
                                                                        <td align="left" style="width: 225px; height: 27px;">
                                                                        <asp:dropdownlist id="ddlGioiTinh" runat="server" width="120px" tabindex="4"><asp:ListItem Value="-1">--Chọn--</asp:ListItem>
<asp:ListItem Selected="True" Value="0">Nam</asp:ListItem>
<asp:ListItem Value="1">Nữ</asp:ListItem>
</asp:dropdownlist>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" nowrap align="right" style="width: 119px; height: 27px;" >
                                                                            <span class="ptext">Điện thoại :</span></td>
                                                                        <td valign="top" align="left" style="width: 240px; height: 27px;" colspan="3">
                                                                            <span class="ptext">
                                                                                <asp:textbox id="txtDienThoai" CssClass="input" runat="server" width="195px" tabindex="5"></asp:textbox></span></td>
                                                                        <td align="right" style="width: 99px;padding-left:0px;padding-right:0px;  height: 27px;">
                                                                        Di động:
                                                                        </td>
                                                                        <td align="left" style="width: 225px; height: 27px;">
                                                                        <asp:textbox id="txtDiDong" CssClass="input" runat="server" tabindex="5" width="187px"></asp:textbox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top"  align="right" style="width: 119px; height: 25px" >
                                                                            <span class="ptext">Email :</span></td>
                                                                        <td colspan="6" valign="top" align="left"  style=" height: 25px; width: 564px;" >
                                                                             <asp:textbox id="txtEmail" CssClass="input" runat="server" width="534px" tabindex="6"></asp:textbox>
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" nowrap align="right" style="width: 119px; height: 27px;" >
                                                                            <span class="ptext">CMND :</span></td>
                                                                        <td valign="top" align="left" style="width: 240px; height: 27px;" colspan="3">
                                                                            <span class="ptext">
                                                                                <asp:textbox id="txtCMND" CssClass="input" runat="server" width="195px" tabindex="6"></asp:textbox></span></td>
                                                                        <td align="right" style="width: 99px;padding-left:0px;padding-right:0px;  height: 27px;">
                                                                        Ngày cấp:
                                                                        </td>
                                                                        <td align="left" style="width: 225px; height: 27px;">
                                                                        <asp:textbox id="txtNgayCapCMND" CssClass="input" runat="server" tabindex="6" width="187px"></asp:textbox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top"  align="right" style="width: 119px; height: 25px" >
                                                                            <span class="ptext">Nơi cấp CMND :</span></td>
                                                                        <td colspan="6" valign="top" align="left"  style=" height: 25px; width: 564px;" >
                                                                             <asp:textbox id="txtNoiCapCMND" CssClass="input" runat="server" width="534px" tabindex="6"></asp:textbox>
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" nowrap align="right" style="width: 119px; height: 27px;" >
                                                                            <span class="ptext">Loại nhân viên :</span></td>
                                                                        <td valign="top" align="left" style="width: 240px; height: 27px;" colspan="3">
                                                                            <span class="ptext">
                                                                                <asp:dropdownlist id="ddlLoaiNhanVien" runat="server" tabindex="7" width="193px"><asp:ListItem Value="-1">--Chọn loại nhân viên--</asp:ListItem>
<asp:ListItem Selected="True" Value="0">Thường xuyên</asp:ListItem>
<asp:ListItem Value="1">Không thường xuyên</asp:ListItem>
</asp:dropdownlist>
                                                                            </span></td>
                                                                        <td align="right" style="width: 99px;padding-left:0px;padding-right:0px;  height: 27px;">
                                                                        Trình độ:
                                                                        </td>
                                                                        <td align="left" style="width: 225px; height: 27px;">
                                                                        <asp:textbox id="txtTrinhDo" CssClass="input" runat="server" tabindex="7" width="187px"></asp:textbox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" nowrap="nowrap" style="width: 119px; height: 27px" valign="top">
                                                                            Chuyên môn:</td>
                                                                        <td align="left" colspan="5" style="height: 27px" valign="top">
                                                                            <asp:textbox id="txtChuyenmon" runat="server" cssclass="input" tabindex="6" width="534px"></asp:textbox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="right" style="width: 119px; height: 27px;" >
                                                                            <span class="ptext">Ngày vào làm :</span></td>
                                                                        <td valign="top" align="left" style="width: 240px; height: 27px;" colspan="3">
                                                                            <span class="ptext">
                                                                                <asp:textbox CssClass="input" id="txtNgayVaoLam" runat="server" tabindex="7" width="100px"></asp:textbox>
                                                                                (dd/MM/yyyy)
                                                                                <asp:label id="Lagfg" runat="server" forecolor="Red" text="(*)"></asp:label>
                                                                                </span></td>
                                                                        <td align="right" style="width: 99px;padding-left:0px;padding-right:0px;  height: 27px;">
                                                                        Hôn nhân:
                                                                        </td>
                                                                        <td align="left" style="width: 225px; height: 27px;">
                                                                        <asp:dropdownlist id="ddlHonNhan" runat="server" width="120px" tabindex="7">
                                                                        <asp:ListItem Value="-1">--Chọn--</asp:ListItem>
                                                                        <asp:ListItem Selected="True" Value="0">Độc thân</asp:ListItem>
                                                                        <asp:ListItem Value="1">Đã kết hôn</asp:ListItem>
                                                                        </asp:dropdownlist>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top"  align="right" style="width: 119px" >
                                                                            <span class="ptext">Địa chỉ tạm trú :</span></td>
                                                                        <td colspan="6" valign="top" align="left"  style="width:564px; height: 24px;" >
                                                                                <asp:textbox id="txtDiaChiTamTru" CssClass="input" runat="server" width="530px" tabindex="8"></asp:textbox>
                                                                                <asp:label id="Label2" runat="server" forecolor="Red" text="(*)"></asp:label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top"  align="right" style="width: 119px" >
                                                                            <span class="ptext">Địa chỉ thường trú :</span></td>
                                                                        <td colspan="6" valign="top" align="left"  style="width:564px; height: 24px;">
                                                                                <asp:textbox id="txtDiaChiThuongTru" CssClass="input" runat="server" width="94%" tabindex="9"></asp:textbox>
                                                                        </td>
                                                                        
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top"  align="right" style="width: 119px" >
                                                                            <span class="ptext">Tên phòng ban :</span></td>
                                                                        <td valign="top" align="left" style="width: 240px;height: 15px;" colspan="3">
                                                                            <span class="ptext">
                                                                                <asp:dropdownlist id="ddlPhongKham" runat="server" width="219px" tabindex="10"></asp:dropdownlist></span></td>
                                                                        <td align="right" style="width: 99px;padding-left:0px;padding-right:0px;  height: 27px;">
                                                                        Chức vụ:
                                                                        </td>
                                                                        <td align="left" style="width: 225px; height: 27px;">
                                                                        <asp:dropdownlist id="ddlchucvu"
                                                                                    runat="server" tabindex="11" width="190px"><asp:ListItem Selected="True" Value="0">Nam</asp:ListItem>
<asp:ListItem Value="1">Nữ</asp:ListItem>
</asp:dropdownlist>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table width="700px">
                                                                    <tr>
                                                                        <td style="width: 100%">
                                                                            <input id="txtmaphieu" type="hidden" value='""' name="txtmaphieu" runat="server" />
                                                                            <input id="txtMaNhanVien_edit" type="hidden" value='""' name="txtmabacsi" runat="server"
                                                                                style="width: 32px; height: 22px" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%; height: 27px;" align="center">
                                                                            <table width="50%" rules="none" style="border-color: Gray; border-style: double;
                                                                                border: 3px">
                                                                                <tr>
                                                                                    <td valign="top" align="center" style="width: 600px; height: 19px;">
                                                                                        <asp:imagebutton id="btnAdd" onclick="btnAdd_Click" runat="server" imageurl="../images/nut_add.gif"
                                                                                            tabindex="12"></asp:imagebutton>
                                                                                        &nbsp;
                                                                                        <asp:imagebutton id="btnEdit" onclick="btnEdit_Click" runat="server" imageurl="../images/sua.gif"
                                                                                            tabindex="13"></asp:imagebutton>
                                                                                        &nbsp;
                                                                                        <asp:imagebutton id="btnCancel" onclick="btnCancel_Click" runat="server" imageurl="../images/cancel.gif"
                                                                                            tabindex="14"></asp:imagebutton>
                                                                                        &nbsp;
                                                                                        <asp:imagebutton id="ImageButton1" runat="server" imageurl="~/images/tim.png" tabindex="15"
                                                                                            onclick="ImageButton1_Click"></asp:imagebutton>
                                                                                            
                                                                                             &nbsp;
                                                                                        <asp:imagebutton id="imgInExel" runat="server" imageurl="~/images/btnExcel.jpg" tabindex="16"
                                                                                            onclick="imgInExel_Click"></asp:imagebutton>
                                                                                            
                                                                                           
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
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td align="left" style="width: 100%;padding-left: 20px; background-color: #FBF8F1; height: 19px; background-image: url(../images/menu.jpg);
                                                    color: White; font-weight: bold">
                                                    DANH SÁCH NHÂN VIÊN
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left:50px">
                                                    <asp:label runat="server" id="lbTongSoNV" text="Label" Font-Bold="True" ForeColor="Red"></asp:label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="left" width="100%" style="font-size:12px" colspan="2" height="20">
                                                    <asp:datagrid id="dgr" tabindex="17" runat="server" width="1200px" allowsorting="True"
                                                        autogeneratecolumns="False" datakeyfield="idnhanvien" borderwidth="1px" bordercolor="Silver"
                                                        onitemdatabound="dgr_ItemDataBound" cellpadding="2" ondeletecommand="DelNhanVien"
                                                        oneditcommand="Edit" onpageindexchanged="PageIndexStyleChanged"
                                                        pagesize="30" 		    
                                                        HeaderStyle-CssClass="HeaderStyle" CssClass="GridViewStyle" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle" Font-Names="Times New Roman" Font-Size="12pt">
<PagerStyle Mode="NumericPages" CssClass="PagerStyle"></PagerStyle>

<ItemStyle Font-Size="Small"></ItemStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnDel" runat="server" CssClass="alink3" CommandName="Delete">Xóa</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="2%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnEdit" runat="server" CssClass="alink3" CommandName="Edit">Sửa</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="2%"></HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn DataField="STT" HeaderText="STT">
<HeaderStyle Wrap="False" Width="2%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="manhanvien" HeaderText="M&#227; NV">
<HeaderStyle Wrap="False" Width="8%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tennhanvien" HeaderText="T&#234;n nh&#226;n vi&#234;n">
<HeaderStyle Wrap="False" Width="13%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="LoaiNV" HeaderText="Loại">
<HeaderStyle Wrap="False" Width="13%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TrinhDo" HeaderText="Tr&#236;nh độ">
<HeaderStyle Wrap="False" Width="13%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ChuyenMon" HeaderText="Chuyên Môn">
<HeaderStyle Wrap="False" Width="13%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="sinhnhat" HeaderText="Ng&#224;y sinh">
<HeaderStyle Wrap="False" Width="7%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="gioitinh1" HeaderText="Giới t&#237;nh">
<HeaderStyle Wrap="False" Width="7%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="dienthoai" HeaderText="Điện thoại">
<HeaderStyle Wrap="False" Width="7%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="diachitamtru" HeaderText="Địa chỉ tạm tr&#250;">
<HeaderStyle Wrap="False" Width="15%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="diachithuongtru" HeaderText="Thường tr&#250;">
<HeaderStyle Wrap="False" Width="15%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="honnhan" HeaderText="H&#244;n nh&#226;n">
<HeaderStyle Wrap="False" Width="7%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenphongban" HeaderText="Ph&#242;ng ban">
<HeaderStyle Width="14%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenchucvu" HeaderText="Chức vụ">
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cmnd" HeaderText="CMND">
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaycapCMND1" HeaderText="Ng&#224;y cấp">
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="noicapCMND" HeaderText="Nơi cấp">
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle CssClass="HeaderStyle" Font-Bold="True" ForeColor="Blue"></HeaderStyle>
</asp:datagrid>
                                                    &nbsp;
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
