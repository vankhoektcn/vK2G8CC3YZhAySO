<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_DS_PhieuYCXuatKho.aspx.cs" Inherits="frm_DS_PhieuYCXuatKho" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!--#include file ="header.htm"-->
<script language = "javascript">
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
	function InXemPhieuYC(Link)
	{
	    window.open(Link);
	}
	function nvk_CanhBaoTreoThuoc()
	{
	    if(confirm("Có thuốc bị treo lại. Bạn vẫn muốn duyệt trong khi có thuốc treo ?"))
	    {
	        document.getElementById("nvk_hd_IsCanhBao").value="1";
	        document.getElementById("<%=Dongy.ClientID %>").click();
	    }
	    else
	        document.getElementById("nvk_hd_IsCanhBao").value="2";
	}
	function nvk_BaoKhoXuat()
	{
	    alert("Số lượng xuất phải >0 !");
	    
	}
</script>
<%@ Register Src="uscMenu.ascx" TagName="uscMenu" TagPrefix="uc1" %>
<form id="Form1" runat = "server">
<asp:scriptmanager runat="server" id="script1"></asp:scriptmanager>
    <asp:updatepanel runat="server" id="updatepanel3"><ContentTemplate>
<table border="0" cellpadding="1" cellspacing="1" width="100%"  id = "user">
    <tr>
        <td width = "100%" height = "12px" bgcolor = "#EAEBE6">
            <uc1:uscMenu ID="UscMenu1" runat="server" />
        </td>
    </tr> 
    <tr>
    <td align="center">
        <strong>
                DANH SÁCH PHIẾU YÊU CẦU XUẤT KHO </strong>
    </td>
    </tr>
				    <TR>
					    <TD width="100%">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%">
									    <TABLE cellSpacing="0" cellPadding="0" width="98%" border="0">
										    
										    <TR style="PADDING-BOTTOM: 5px; PADDING-TOP: 10px">
											    <TD align="left" width="100%" style="height: 41px">
												    <TABLE style="HEIGHT: 17px" cellSpacing="0" cellPadding="0" width="100%" border="0">
													    <TR>
														    <TD vAlign="top" align="right" style="WIDTH: 188px; height: 24px;">
															    <P class="ptext">Ngày yêu cầu từ:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 84%; height: 24px;" colspan="3">
															    <P class="ptext"><asp:TextBox ID="txtTuNgay" Runat="server" Width="148px" tabIndex="1" ReadOnly="False" OnBlur = "TestDatePhieu(this)"></asp:TextBox>
                                                                    &nbsp; đến
                                                                    <asp:textbox id="txtDenNgay" runat="server" onblur="TestDatePhieu(this)" readonly="False"
                                                                        tabindex="1" width="148px"></asp:textbox>
                                                                    (dd/MM/yyyy)</P>
														    </TD>
													    </TR>
													    <TR>
														    <TD vAlign="top" align="right" style="WIDTH: 188px; height: 24px;">
															    <P class="ptext">
                                                                    Kho yêu cầu:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 84%; height: 24px;" colspan="2">
															    <P class="ptext">
                                                                    <asp:dropdownlist id="ddlKhoThuoc" runat="server" tabindex="1" width="444px"></asp:dropdownlist>
                                                                    <asp:button id="btnGetList" runat="server" onclick="btnGetList_Click" text="Lấy danh sách" />
                                                                </P>
														    </TD>
														     
													    </TR>													   
													   
												    </TABLE>
                                                                    </TD>
										    </TR>
									    </TABLE>
								    </TD>
							    </TR>
						    </TABLE>
						    
						    <TABLE cellPadding="0" width="100%" border="0">
							  
						    </TABLE>						   
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" colSpan="2" height="20">
									    <asp:datagrid id="dgr" tabIndex="12" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
											    DataKeyField="IdPhieuYC" BorderWidth="1px" BorderColor="Silver"  CellPadding="2"    AllowPaging="True"
											     PageSize="10000" OnItemCommand="dgr_ItemCommand" OnItemDataBound="dgr_ItemDataBound" >
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>

<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnEdit" runat="server" Width="87px" Font-Bold="True" __designer:wfdid="w2" CommandName="Edit" CssClass="alink3" text='<%#Eval("tinhtrangXuat") %>'></asp:LinkButton> 
</ItemTemplate>
<%--<% =StaticData.MacDinhTenThaoTacXuat %>--%>
<HeaderStyle Width="9%"></HeaderStyle>
</asp:TemplateColumn>

<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnView" runat="server" Width="87px" Font-Bold="True" CommandName="View" CssClass="alink3"> Chi tiết</asp:LinkButton> 
</ItemTemplate>
<HeaderStyle Width="9%"></HeaderStyle>
</asp:TemplateColumn>


<asp:BoundColumn DataField="STT" HeaderText="STT">
<HeaderStyle Width="5%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="sophieu" HeaderText="S&#244;́ phi&#234;́u"></asp:BoundColumn>
<asp:BoundColumn DataField="ngayYC" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày YC">
<HeaderStyle Wrap="False" Width="9%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TenNguoiYeuCau" HeaderText="T&#234;n người YC">
<HeaderStyle Wrap="False" Width="17%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenkho" HeaderText="T&#234;n kho">
<HeaderStyle Wrap="False" Width="30%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Trangthai" HeaderText="Trạng th&#225;i"></asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" CssClass="dgrHeader"></HeaderStyle>
</asp:datagrid>&nbsp;												
								    </TD>
							    </TR>
						    </TABLE>
					    </TD>
				    </TR>
				       <tr>
        <td class = "title" style="padding-bottom:10px; width: 945px; height: 176px;"><p class="title">&nbsp;
			    <input type="hidden" runat="server" id="nvk_hd_IsCanhBao" value="0"/>
                   
        </p></td>
    </tr>
			    </table>
			    <div style="display:none;overflow:scroll;width:90%;height:auto;position:absolute;top:20%;left:5%;background-color:White;border:2px solid black" id="divgrid">
                    &nbsp;
                    
                     <asp:gridview runat="server" id="grid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="80%" Width="100%" AutoGenerateColumns="False">
<RowStyle ForeColor="#000066"></RowStyle>
<Columns>
<asp:BoundField DataField="STT" HeaderText="STT">
<ItemStyle Width="50px"></ItemStyle>
</asp:BoundField>
<%--<asp:BoundField DataField="mabenhnhan" HeaderText="Mã BN">
<ItemStyle Width="100px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="tenbenhnhan" HeaderText="Tên BN">
<ItemStyle Width="150px"></ItemStyle>
</asp:BoundField>--%>
<asp:BoundField DataField="TenThuoc" HeaderText="T&#234;n thuốc-VTYT...">
<ItemStyle Width="200px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="congthuc" HeaderText="Hoạt chất">
<ItemStyle Width="200px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Soluong" HeaderText="Số lượng y&#234;u c&#226;̀u">
<ItemStyle Width="50px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SLXuat" HeaderText="SL c&#243; thể xuất">
<ItemStyle Width="50px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SLTon" HeaderText="SL Tồn"></asp:BoundField>
<asp:TemplateField HeaderText="SL Xuất"><ItemTemplate>
<asp:TextBox id="iSLXuat" runat="server" Width="119px" __designer:wfdid="w1" Text='<%# Eval("SLXuat1") %>'></asp:TextBox> 
<asp:HiddenField runat="server" id="hdIdThuocAsp" value=<%# Eval("idthuoc") %> ></asp:HiddenField>
<asp:HiddenField runat="server" id="hdSoLuongYCAsp" value=<%# Eval("Soluong") %> ></asp:HiddenField>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

<PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

<SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

<HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>
</asp:gridview>
                    <p style="float:left;text-align:center;width:100%">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        <asp:button runat="server" text="Đồng ý" id="btncheckCanhBao" OnClick="CanhBao_Click" BackColor="Teal" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True"/>
                        <asp:button runat="server" width="0px" text="" id="Dongy" OnClick="Dongy_Click" BackColor="Teal" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True"/>
                        &nbsp; &nbsp;&nbsp; &nbsp;<asp:button runat="server" text="Thoát" id="Thoat" BackColor="Teal" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True"/></p>
			    </div>
  </ContentTemplate></asp:updatepanel>
		    
 </form>
<!--#include file ="footer.htm"-->