<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KhoaDaoTaoEntry.aspx.cs"
    Inherits="KhoaDaoTaoEntry" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--#include file ="header.htm"-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Quản Lý Nhân Sư5</title>  
    <script language="javascript">
    var dp_cal, dp_cal1;      
	window.onload = function () 
	{
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));
	    dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
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

</head>
<body>
    <form id="form1" runat="server">
    <div id="Menu" style="background-color:White;text-align:left">
	    <uc1:uscmenu ID="Uscmenu1" runat="server" />
	</div>
        <div style="width: 95%;background-color:White">
            <table id="Khung" width="100%">
                <tr id="tieuDe">
                    <td align="left" style="width: 100%; background-color: #FBF8F1; height: 19px; background-image: url(../images/menu.jpg);
                        color: Red; font-weight: bold">
                        QUẢN LÝ DANH MỤC KHÓA ĐÀO TẠO
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                </tr>
                <tr id="nhapLieu">
                    <td align="left" style="padding-left: 50px">
                        <table width="900px" rules="none" style="border-color: Blue; border-style: double;
                            border: 4px">
                            <%-- <tr>
                                <td style=" width: 15%;padding-right:10px; height: 22px;">
                                
                                </td>
                                <td style="width: 35%;padding-right:10px; height: 22px;">
                                </td>
                                <td style="width: 15%;padding-right:10px; height: 22px;">
                                </td>
                                <td style="width: 35%;padding-right:10px; height: 22px;">
                                </td>
                            </tr>--%>
                            <tr>
                                <td  align="right" style="width:230px;height: 26px; padding-right: 5px">
                                    Mục đích đào tạo:
                                </td>
                                <td colspan="3"><input class="input" id="txtMucDDT" runat="server" type="text" style="width: 540px" /></td>
                            </tr>
                            <tr>
                                <td  align="right" style="height: 26px; padding-right: 5px">
                                    Địa điểm đào tạo:                                   
                                </td>
                                <td colspan="3"><input id="txtDiaDiem" class="input" type="text" runat="server" style="width: 540px" /></td>
                            </tr>
                            <tr>
                                <td align="right" style="width:230px; padding-right: 5px; height: 22px;">
                                    Từ ngày :
                                </td>
                                <td align="left" style="width: 30%; padding-right: 5px; height: 22px;">
                                    <input id="txtTuNgay" class="input" runat="server" style="width: 128px" type="text" />
                                    <input id="Submit1" style="width: 25px" type="button" value="..." onclick="dp_cal.toggle()" /></td>
                                <td align="right"  style="width: 15%; padding-right: 5px; height: 22px;">
                                    Đến ngày :
                                </td>
                                <td align="left" style="width: 35%; padding-right: 5px; height: 22px;">
                                    <input id="txtDenNgay" class="input" runat="server" style="width: 129px" type="text" />
                                    <input id="Submit2" style="width: 25px" type="button" value="..." onclick="dp_cal1.toggle()" /></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 230px; padding-right: 5px; height: 22px;">
                                    Học phí :
                                </td>
                                <td align="left" style="width: 35%; padding-right: 5px; height: 22px;">
                                    <input id="txtHocPhi" class="input" runat="server" style="width: 158px" type="text" /></td>
                                <td align="right" style="width: 15%; padding-right: 5px; height: 22px;">
                                    Công ty trả :
                                </td>
                                <td align="left" style="width: 35%; padding-right: 5px; height: 22px;">
                                    <input id="txtCtyTra" runat="server" class="input" style="width: 158px" type="text" /></td>
                            </tr>
                            <tr>
                                <td align="right" style="width:230px; padding-right: 5px; height: 22px;">
                                    Nhân viên trả :
                                </td>
                                <td align="left" style="width: 35%; padding-right: 5px; height: 22px;">
                                    <input id="txtNVTra" class="input" runat="server" style="width: 157px" type="text" /></td>
                                <td align="left" style="padding-right: 5px; height: 22px; padding-left: 100px" colspan="2">
                                    <asp:CheckBox ID="cbVanBang" runat="server" Text="Nộp văn bằng" /></td>
                            </tr>
                            <tr>
                                <td colspan="4" align="right" style="height: 26px; padding-right: 5px; padding-left: 60px">
                                    Ghi chú:&nbsp;&nbsp;
                                    <%--<input id="txtGhiChu" runat="server" type="text" style="width: 540px" />--%>
                                    <textarea id="txtGhiChu" class="input" runat="server" style="width: 540px" cols="20" rows="2"></textarea>
                                </td>
                            </tr>
                        </table>
                        <table width="700px">
                            <tr>
                                <td style="width: 100%">
                                    <input id="txtmaphieu" type="hidden" value='""' name="txtmaphieu" runat="server" />
                                </td>
                            </tr>
                            <tr>
                           
                                <td style="width: 100%; height: 27px;" align="center">
                                    <table width="40%" rules="none" style="border-color: Gray; border-style: double;
                                        border: 3px">
                                        <tr>
                                            <td valign="top" align="center" width="430" style="width: 430px; height: 19px;" nowrap>
                                                <asp:ImageButton ID="btnAdd" OnClick="btnAdd_Click" runat="server" ImageUrl="../images/nut_add.gif"
                                                    TabIndex="8"></asp:ImageButton>
                                                &nbsp;
                                                <asp:ImageButton ID="btnEdit" OnClick="btnEdit_Click" runat="server" ImageUrl="../images/sua.gif"
                                                    TabIndex="9"></asp:ImageButton>
                                                &nbsp;
                                                <asp:ImageButton ID="btnCancel" OnClick="btnCancel_Click" runat="server" ImageUrl="../images/cancel.gif"
                                                    TabIndex="10"></asp:ImageButton>
                                                &nbsp;
                                                <asp:ImageButton ID="btnTim" runat="server" ImageUrl="../images/tim.png" TabIndex="10"
                                                    OnClick="btnTim_Click"></asp:ImageButton>
                                                 &nbsp;
                                                <asp:ImageButton ID="btnEcel" runat="server" ImageUrl="../images/btnExcel.jpg" TabIndex="10"
                                                    OnClick="btnEcel_Click"></asp:ImageButton>
                                                   
                                            </td>
                                            <%--<td style="height: 28px">
                                                <asp:Button ID="Button1" runat="server" Text="Thêm" />
                                                &nbsp; &nbsp;
                                                <asp:Button ID="Button2" runat="server" Text="Sửa " />
                                                &nbsp; &nbsp;
                                                <asp:Button ID="Button3" runat="server" Text="Tìm kiếm" />&nbsp;
                                            </td>--%>
                                        </tr>
                                    </table>
                                    </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="luoiNoiDung">
                    <td align="left" style="width: 100%; padding-left: 0px">
                        <table width="1000px">
                            <tr>
                            <td align="left" style="width: 100%; background-color: #FBF8F1; height: 19px; background-image: url(../images/menu.jpg);
                                color: White; font-weight: bold">
                                DANH SÁCH KHÓA ĐÀO TẠO
                            </td>
                            </tr>
                            <tr>
                                <td style="height: 21px">
                                </td>
                            </tr>
                            <tr id="trLuoi">
                                <td style="">
                                    <%--Lưới hiển thị danh sách--%>
                                    <asp:DataGrid ID="dgr" TabIndex="12" runat="server" Width="100%" AllowSorting="True"
                                        AutoGenerateColumns="False" DataKeyField="idkhoadaotao" BorderWidth="1px" BorderColor="Silver"
                                        OnItemDataBound="dgr_ItemDataBound" CellPadding="2" OnDeleteCommand="DelKhoaDaoTao"
                                        OnEditCommand="Edit" AllowPaging="True" OnPageIndexChanged="PageIndexStyleChanged"
                                        PageSize="30"
                                        HeaderStyle-CssClass="HeaderStyle" CssClass="GridViewStyle" PagerStyle-CssClass="PagerStyle" OnItemCommand="dgr_ItemCommand" >              

                                        <PagerStyle Mode="NumericPages" CssClass="PagerStyle"></PagerStyle>
                                        <Columns>
                                            <asp:TemplateColumn HeaderText="X&#243;a KDT">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnDel" CommandName="Delete" runat="server" CssClass="alink3">Xóa</asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Width="4%"></HeaderStyle>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Sửa KDT">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnEdit" CommandName="Edit" runat="server" CssClass="alink3">Sửa</asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Width="4%"></HeaderStyle>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn>
                                                <ItemTemplate >
                                                    <asp:LinkButton ID="lbtnChiTiet" CommandName="ChiTiet" runat="server" CssClass="alink3">Chi tiết</asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%"></HeaderStyle>
                                            </asp:TemplateColumn>                                            
                                             <asp:BoundColumn DataField="STT" HeaderText="STT">
                                                <HeaderStyle Wrap="False" Width="2%"></HeaderStyle>
                                                <ItemStyle VerticalAlign="Middle" Wrap="True"></ItemStyle>
                                            </asp:BoundColumn>
                                            
                                            <asp:BoundColumn DataField="mucdichdaotao" HeaderText="Mục đ&#237;ch">
                                                <HeaderStyle Wrap="False" Width="17%"></HeaderStyle>
                                                <ItemStyle Wrap="True"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="diadiem" HeaderText="Địa điểm">
                                                <HeaderStyle Wrap="False" Width="20%"></HeaderStyle>
                                                <ItemStyle Wrap="False"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="tungay" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Từ ng&#224;y">
                                                <HeaderStyle Width="7%"></HeaderStyle>
                                                <ItemStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="denngay" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Đến ng&#224;y">
                                                <HeaderStyle Wrap="False" Width="8%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="hocphi" DataFormatString="{0:N}" HeaderText="Học ph&#237;">
                                                <HeaderStyle Wrap="False" Width="7%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="ctytra" DataFormatString="{0:C}" HeaderText="Cty trả">
                                                <HeaderStyle Wrap="False" Width="7%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="nvtra" DataFormatString="{0:0,000}" HeaderText="NV trả">
                                                <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:TemplateColumn >
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblTien" runat="server" Text="Văn Bằng"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbVanBang" runat="server" Text='<%# Eval("vanbang") %>'></asp:Label>
                                                    <headerstyle wrap="False" width="5%" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn DataField="ghichu" HeaderText="Ghi ch&#250;">
                                                <HeaderStyle Width="15%"></HeaderStyle>
                                            </asp:BoundColumn>
                                        </Columns>
                                        <HeaderStyle HorizontalAlign="Center" CssClass="dgrHeader" BackColor="#C0FFFF" Font-Bold="True"
                                            ForeColor="Blue"></HeaderStyle>
                                    </asp:DataGrid>&nbsp;
                                    <%--end Lưới hiển thị danh sách--%>
                                </td>
                            </tr>
                        </table>
                   </td>
                </tr>
            </table>
            
        
        </DIV>
    </form>
</body>
</html>
<!--#include file ="footer.htm"-->