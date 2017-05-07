<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmListKhamBenh_NoiTru.aspx.cs" Inherits="frmListKhamBenh_NoiTru1" %>
<!--#include file ="header.htm"-->
<script language = "javascript">
    
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

</script>
<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#D4D0C8; height: 10px;">
              <asp:placeholder ID="PlaceHolder1" runat="server"></asp:placeholder>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
		    <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px">
			    <table id="user" cellSpacing="1" cellPadding="1" width="100%" border="0" class = "khung">
				    <tr>
				        <td class="title" align = "center" style="background-color: #4D67A2; height: 25px;">
                            <strong>
			                <span class="title" style ="color:#FFFFFF">DANH SÁCH PHIẾU KHÁM BỆNH</span></strong></td>
				    </tr>
				    <TR>
					    <TD width="100%">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" style="height: 133px">
                                         Khoa: &nbsp;&nbsp;
                                        <asp:dropdownlist id="ddlPK" runat="server" autopostback="true" width="153px" OnSelectedIndexChanged="ddlPK_SelectedIndexChanged"></asp:dropdownlist>
                                        &nbsp; &nbsp;
													  Nội dung khám: &nbsp;&nbsp;
                                        <asp:dropdownlist id="ddndk" runat="server" autopostback="true" width="153px" OnSelectedIndexChanged="ddndk_SelectedIndexChanged"></asp:dropdownlist>
                                        &nbsp; &nbsp;
													  Phòng: &nbsp;&nbsp;
                                        <asp:dropdownlist id="ddlPhong" runat="server" autopostback="false" width="153px"></asp:dropdownlist>
                                        
                                        <br />&nbsp; &nbsp;Mã BN: &nbsp;&nbsp;
                                        <asp:textbox id="mabN" runat="server" tabindex="0"></asp:textbox>
                                        &nbsp; &nbsp;Tên BN: &nbsp;&nbsp;
                                        <asp:textbox id="tenbN" runat="server"></asp:textbox>
                                        &nbsp; &nbsp; &nbsp;<asp:label id="lbLoaiBN" runat="server" text="Loại BN"></asp:label>
                                        <asp:dropdownlist id="cbLoaiBN" runat="server" autopostback="true" width="92px"></asp:dropdownlist>
                                        &nbsp; &nbsp;
                                        Từ ngày :
                                                          <asp:textbox id="txtTuNgay" runat="server"  onfocus="$(this).datepick();" onblur="nvk_testDate_this(this);" 
                                                               width="77px" ></asp:textbox>
                                        &nbsp;
													  Đến ngày: &nbsp;<asp:textbox id="txtDenNgay" runat="server"   onfocus="$(this).datepick();" onblur="nvk_testDate_this(this);" 
                                                               width="73px"></asp:textbox>
                                        &nbsp; &nbsp; &nbsp;&nbsp;<asp:button id="btnGetList" runat="server" onclick="btnGetList_Click"
                                            text="Lấy danh sách" width="112px" />&nbsp;
                                        <br />
                                        <strong>
                                            Kết quả tìm kiếm: </strong>
                                        <br />
                                        <table border="true">
                                            <tr>
                                                <td rowspan="2" style="width: 100px">
                                                    <asp:label id="Label1" runat="server" text="Tổng số bệnh nhân: " width="138px"></asp:label>
                                                </td>
                                                <td rowspan="2" style="width: 47px">
                                                    <asp:textbox id="txtSLBN" runat="server" width="48px"></asp:textbox>
                                                </td>
                                                <td rowspan="2" style="width: 73px">
                                                    <asp:label id="Label2" runat="server" text="Bảo hiểm"></asp:label>
                                                </td>
                                                <td rowspan="2" style="width: 48px">
                                                    <asp:textbox id="txtSLKBH" runat="server" width="48px"></asp:textbox>
                                                </td>
                                                <td style="width: 21px; height: 26px">
                                                </td>
                                                <td rowspan="2" style="width: 95px">
                                                    <asp:label id="Label3" runat="server" text="Thường"></asp:label>
                                                </td>
                                                <td rowspan="2" style="width: 45px">
                                                    <asp:textbox id="txtSLKT" runat="server" width="48px"></asp:textbox>
                                                </td>
                                                <td style="width: 9px; height: 26px">
                                                </td>
                                                <td rowspan="2" style="width: 57px">
                                                    <asp:label id="Label4" runat="server" text="Dịch vụ"></asp:label>
                                                </td>
                                                <td rowspan="2" style="width: 48px">
                                                    <asp:textbox id="txtSLKDV" runat="server" width="48px"></asp:textbox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 21px">
                                                </td>
                                                <td style="width: 9px">
                                                </td>
                                            </tr>
                                        </table>
								    </TD>
							    </TR>
						    </TABLE>
						    
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="left" width="100%"  class="title"  style="color:#FFFFFF;background-color: #4D67A2; height: 20px;">DANH SÁCH PHIẾU KHÁM BỆNH</TD>
							    </TR>
						    </TABLE>						   
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" colSpan="2" height="20">
									    <asp:datagrid id="dgr" tabIndex="12" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
											    DataKeyField="IdKhamBenh" BorderWidth="1px" BorderColor="#3366CC" CellPadding="4"  
											    OnItemCommand="dgr_ItemCommand" BackColor="White" BorderStyle="None">
<FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

<SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedItemStyle>

<PagerStyle Mode="NumericPages" HorizontalAlign="Left" BackColor="#99CCCC" Font-Names="Arial" Font-Size="Small" ForeColor="#003399"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" BackColor="White" CssClass="dgrNoSelectItem" ForeColor="#003399"></ItemStyle>
<Columns>
<asp:BoundColumn DataField="STT" HeaderText="STT"></asp:BoundColumn>
<asp:ButtonColumn CommandName="ViewDetail" Text="Chi tiết" HeaderText="Xem chi tiết"></asp:ButtonColumn>
<asp:BoundColumn DataField="NgayKham" DataFormatString="{0:dd/MM HH:mm}" HeaderText="Ng&#224;y kh&#225;m"></asp:BoundColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="15%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NamSinh" HeaderText="Năm sinh">
<HeaderStyle Width="5%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="GioiTinh" HeaderText="Giới t&#237;nh">
<HeaderStyle Width="3%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="LoaiBN" HeaderText="Loại BN"></asp:BoundColumn>
<asp:BoundColumn DataField="SOBHYT" HeaderText="Số BHYT"></asp:BoundColumn>
<asp:BoundColumn DataField="KHOA" HeaderText="Khoa">
<HeaderStyle Wrap="False" Width="15%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TENBACSI" HeaderText="B&#225;c sĩ kh&#225;m"></asp:BoundColumn>
<asp:BoundColumn DataField="CHANDOANSOBO" HeaderText="Chẩn đo&#225;n sơ bộ"></asp:BoundColumn>
<asp:BoundColumn DataField="chandoanxacdinh" HeaderText="Chẩn đo&#225;n x&#225;c định"></asp:BoundColumn>
<asp:BoundColumn DataField="HuongGiaiQuyet" HeaderText="Hướng giải quyết"></asp:BoundColumn>
<%--<asp:TemplateColumn HeaderText="?BN mới"><ItemTemplate>
<asp:CheckBox id="cbiIsBNMoi" runat="server" __designer:wfdid="w2" Checked='<%# Eval("IsBNMoi") %>'></asp:CheckBox>
</ItemTemplate>
</asp:TemplateColumn>--%>
<asp:TemplateColumn HeaderText="?C&#243; CĐCLS"><ItemTemplate>
<asp:CheckBox id="cbiIsHaveCLS" runat="server" Checked='<%# Eval("IsHaveCLS") %>'></asp:CheckBox>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="?Đ&#227; CLS"><ItemTemplate>
<asp:CheckBox id="cbiDaCLS" runat="server" Checked='<%# Eval("DaCLS") %>'></asp:CheckBox>
</ItemTemplate>
</asp:TemplateColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" BackColor="#003399" CssClass="dgrHeader" Font-Bold="True" ForeColor="#CCCCFF"></HeaderStyle>
</asp:datagrid>&nbsp;
<br />
 <asp:Panel ID="pnlDV" runat="server" Width="100%"><BR /></asp:Panel>				

<br />


<asp:Panel ID="pnlKB" runat="server" Width="100%"></asp:Panel>	
 
 <asp:Panel ID="pnlCLS" runat="server" Width="100%"></asp:Panel>


								    </TD>
							    </TR>
						    </TABLE>
					    </TD>
				    </TR>
			    </table>
		    </td>
	    </tr>				
    </table>
    </td>
   </tr>
  </table>  
 </form>
<!--#include file ="footer.htm"-->