<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NVK_HenTaiKham.aspx.cs" Inherits="NVK_HenTaiKham" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!--#include file ="header.htm"-->

<script language="javascript">
     
	window.onload = function () 
	{
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
	function InPhieuHen(Link)
	{
	     if (confirm("Đã hẹn tái khám. Bạn có muốn in phiếu hẹn ?"))
	     {
	        window.open(Link,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	     }
	}
</script>

<form id="Form1" method="post" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: #C0C0C0">
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8; height: 10px;">
                <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
            </td>
        </tr>
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px">
                            <table id="user" cellspacing="1" cellpadding="1" width="100%" border="0" class="khung">
                                <tr>
                                    <td class="title" align="center" style="background-color: #4D67A2">
                                        <span class="title"  runat="server" style="color: #FFFFFF;font-weight:bold">LẬP PHIẾU HẸN
                                            TÁI KHÁM</span></td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="center" width="100%" style="height: auto">
                                                    <table cellspacing="0" cellpadding="0" width="98%" border="0">
                                                        <tr style="padding-bottom: 5px; padding-top: 0px">
                                                            <td align="center" style="height: auto">
                                                                <table style="height: 17px" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td valign="top" nowrap align="right" style="width: 112px; height: 24px;">
                                                                            <p class="ptext">
                                                                                Mã bệnh nhân:&nbsp;
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top" align="left" style="width: 140px; height: 24px;" colspan="1">
                                                                            <p class="ptext">
                                                                                <asp:textbox id="txtMaBenhNhan" runat="server" width="120px" tabindex="1" readonly="False"></asp:textbox>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top" nowrap align="left" style="width: 114px; height: 24px;">
                                                                            <p class="ptext">
                                                                                Tên bệnh nhân:&nbsp;
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top" align="left" style="width: 500px; height: 24px;">
                                                                            <p class="ptext">
                                                                                <asp:textbox id="txtTenBenhNhan" runat="server" width="230px" tabindex="2"></asp:textbox>
                                                                                &nbsp;Loại khám:&nbsp;
                                                                                <asp:dropdownlist id="ddlLoaiKham" runat="server" width="150px" tabindex="3">
                                                                                </asp:dropdownlist>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top" nowrap align="left">
                                                                            <p class="ptext">
                                                                                &nbsp;Giới tính:&nbsp;
                                                                                <asp:dropdownlist id="ddlGioiTinh" runat="server" width="74px" tabindex="3">
                                                                                    <asp:ListItem Selected="True" Value="-1">---</asp:ListItem>
                                                                                    <asp:ListItem Value="0">Nam</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Nữ</asp:ListItem>
                                                                                </asp:dropdownlist>
                                                                                &nbsp;&nbsp;&nbsp;
                                                                                <asp:imagebutton id="ImageButton1" runat="server" imageurl="../images/tim.png" tabindex="8"
                                                                                    onclick="ImageButton1_Click"></asp:imagebutton>
                                                                                <asp:imagebutton id="btnCancel" tabindex="9" onclick="btnCancel_Click" runat="server"
                                                                                    imageurl="../images/MOI.gif"></asp:imagebutton>
                                                                            </p>
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
                                            <tr style="width: 100%">
                                                <td valign="top" align="center" width="100%" colspan="2" height="20">
                                                    <asp:scriptmanager runat="server" id="script1"></asp:scriptmanager>
                                                    <asp:updatepanel runat="server" id="script2"><ContentTemplate>
<asp:datagrid id="dgr" tabIndex=10 runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyField="idchitietdangkykham" OnItemDataBound="dgr_ItemDataBound" CellPadding="4" OnDeleteCommand="DelBenhNhan" OnEditCommand="Edit" AllowPaging="True" OnPageIndexChanged="PageIndexStyleChanged" Width="100%" PageSize="20" ForeColor="#333333" GridLines="None">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>

<EditItemStyle BackColor="#2461BF"></EditItemStyle>

<SelectedItemStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedItemStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" Font-Size="Small" Font-Names="Arial" HorizontalAlign="Center"></PagerStyle>

<AlternatingItemStyle BackColor="White" CssClass="dgrSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></AlternatingItemStyle>

<ItemStyle BackColor="#EFF3FB" CssClass="dgrNoSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle BackColor="#4D67A2" ForeColor="White" CssClass="dgrHeader" HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnEdit" runat="server" width="80px" CssClass="alink3" text='<%# Eval("ChucNang") %>' CommandArgument='<%# Eval("idbenhnhan") %>' CommandName="Edit" __designer:wfdid="w1"></asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn DataField="STT" HeaderText="Stt">
<ItemStyle Wrap="True"></ItemStyle>

<HeaderStyle Width="3%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<ItemStyle Wrap="True"></ItemStyle>

<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="15%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="sobhyt" HeaderText="Số BHYT">
<ItemStyle Wrap="True"></ItemStyle>

<HeaderStyle Width="9%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="diachi" HeaderText="Địa chỉ">
<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="30%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="gioitinh" HeaderText="Giới t&#237;nh">
<HeaderStyle Width="3%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="namsinh" HeaderText="Năm sinh">
<ItemStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

<HeaderStyle Width="5%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="KhoaTaiKham" HeaderText="Khoa t&#225;i kh&#225;m">
<HeaderStyle Width="7%" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NgayTaiKham" HeaderText="Ng&#224;y t&#225;i kh&#225;m" DataFormatString="{0:dd/MM/yyyy hh:mm}">
<ItemStyle HorizontalAlign="Right" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

<HeaderStyle Width="8%"></HeaderStyle>
</asp:BoundColumn>
</Columns>
</asp:datagrid>&nbsp; <asp:hiddenfield id="name1" runat="server"></asp:hiddenfield> <asp:hiddenfield id="name2" runat="server"></asp:hiddenfield> <asp:hiddenfield id="name3" runat="server"></asp:hiddenfield> <asp:hiddenfield id="name4" runat="server"></asp:hiddenfield> 
</ContentTemplate>
</asp:updatepanel>
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
    <div style="display: none; position: fixed; top: 25%; left: 15%; background-color: White;
        z-index: 0.5; padding: 10px 10px 10px 10px; border: 10px solid #4D67A2; height: auto"
        id="divlydo" runat="server">
        <asp:updatepanel runat="server" id="updatepanel1"><ContentTemplate>
        <%--<asp:hiddenfield id="hdIdKhamBenh" runat="server"></asp:hiddenfield>
         <asp:hiddenfield id="hdIdBenhNhan" runat="server"></asp:hiddenfield> 
        <asp:hiddenfield id="hdTenBenhNhan" runat="server"></asp:hiddenfield>--%>
        <input type="hidden" id="hdIdchitietdangkykham" runat="server"/> 
        <input type="hidden" id="hdIdKhamBenh" runat="server"/> 
        <input type="hidden" id="hdIdBenhNhan" runat="server"/> 
        <input type="hidden" id="hdTenBenhNhan" runat="server"/>
        <input type="hidden" id="hdLoaiBN" runat="server"/> 
        <input type="hidden" id="hdIdGiuongNhap" value="0" runat="server"/> 
        <input type="hidden" id="hdGiaGiuong" value="0" runat="server"/> 
         <input type="hidden" id="Hidden1" runat="server"/> 
      <table style="width:85%">
            <tr>
              <td style="width:100%" colspan="2">
                <table style="width:100%">
                <tr>
                <td> Bệnh nhân:<asp:textbox runat="server" id="txtTenBNNhap" enabled="false"></asp:textbox> </td>
                <td> Mã bệnh nhân :<asp:textbox runat="server" style="width:100px" id="txtMaBNNhap" enabled="false"></asp:textbox></td>
                <td> Giới tính : <asp:textbox runat="server" style="width:40px" id="txtGioiTinhNhap" enabled="false"></asp:textbox></td>
                <td> Ngày lập phiếu :<asp:textbox runat="server" style="width:120px" id="txtNgayHen" enabled="false"></asp:textbox></td>
                </tr>
                </table>
              </td>
          </tr>
          <%--<tr>
              <td style="width:100%" colspan="2">
                <table>
                <tr>
                <td> Khoa chuyển đến :<asp:textbox runat="server" id="txtKhoaChuyen" enabled="false"></asp:textbox> </td>
                <td> Khoa nhập : <asp:textbox runat="server" id="txtKhoaNhap" enabled="false"></asp:textbox></td>
                <td> Ngày nhập : <asp:textbox runat="server" id="txtNgayNhap" enabled="false"></asp:textbox></td>
                </tr>
                </table>
              </td>
          </tr>
          <tr>
              <td style="width:100%" colspan="2">
                <table>
                <tr>                
                <td>Chuẩn đoán khoa chuyển : 
                <span class="ptext">
                            <asp:textbox id="txtmachandoanKhoaChuyen" runat="server" width="56px"  ></asp:textbox>
                            <asp:textbox id="txtchandoanKhoaChuyen" runat="server" Width="500px" ></asp:textbox>                                
                                <asp:label id="lb2" runat="server" text="(theo ICD10)"></asp:label>
                            </span>
                </td>
                </tr>
                </table>
              </td>
          </tr>          
          <tr>
              <td style="width:100%" colspan="2">
                <table>
                <tr>                
                <td>Chuẩn đoán nhập khoa : 
                <span class="ptext"><input type = "hidden" runat="server" id = "txtIdChanDoan_3" value = "0" />
                                <asp:textbox id="txtmachandoan_3" runat="server" width="56px" onfocus="LoadChanDoanICD10('txtmachandoan_3', '3')" ></asp:textbox>
                                <asp:textbox id="txtchandoan_3" runat="server" Width="500px" onfocus="LoadChanDoanICD10('txtchandoan_3', '3')" ></asp:textbox>
                                <asp:label id="lb3" runat="server" text="(theo ICD10)"></asp:label>
                            </span>
                </td>
                </tr>
                </table>
              </td>
          </tr>
          <tr style="width:100%">
          <td>
            <table id="chandoanicd10_1" runat="server" style="width:50%;display:none" >
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
          </tr>--%>
          <tr>
             <td style="width:100%" colspan="all">
                <table>
                <tr>
                <td colspan="all" align="center">
                    <asp:Label runat="server" Text="Khoa Hẹn: " id="lbPhong"></asp:Label><asp:textbox runat="server"  enabled="false" id="txtKhoaHen" width="150px" ></asp:textbox>
                    &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label runat="server" Text="Ngày tái khám: " id="lbNgay"></asp:Label><asp:textbox visible="true" id="txtNgayTaiKham" runat="server" width="80px"  onfocus="$(this).datepick();" onblur="nvk_testDate_this(this);"  ></asp:textbox><asp:textbox visible="true" id="txtGioTaiKham" runat="server" width="40px"></asp:textbox> 
                
                    &nbsp;&nbsp; <asp:Label runat="server" Text="Khoa tái khám:" id="lbGiuong"></asp:Label> <asp:DropDownList runat="server" id="ddlKhoaTaiKham" autopostback="false" OnSelectedIndexChanged="ddlKhoaTaiKham_SelectedIndexChanged" style="width:200px"></asp:DropDownList>
                </td>    
                </tr>
                <tr>
                <td colspan="all">
                    &nbsp;&nbsp; Ghi chú:&nbsp;<asp:textbox runat="server" id="txtGhiChuTaiKham" width="500px" ></asp:textbox>
                </td>
                </tr>
                </table>
              </td>
          </tr> 
          <tr>
          <td align="center">
            <asp:button runat="server" text="Lưu" style="width:80px" id="btlydo" OnClick="btlydo_Click"/>
      <input id="Button3" type="button" style="width:80px" value="Đóng" onclick="javascript:divlydo.style.display = 'none';"/>
          </td>
          </tr>         
      </table>
      </ContentTemplate></asp:updatepanel>
    </div>
</form>
<!--#include file ="footer.htm"-->
