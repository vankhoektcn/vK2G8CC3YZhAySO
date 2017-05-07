<%@ Page Language="C#" AutoEventWireup="true" CodeFile="danhmucnhacungcap.aspx.cs" Inherits="danhmucnhacungcap" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_HeThongDanhMuc.ascx" TagName="uscmenuKT_HeThongDanhMuc" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<!--#include file ="header.htm"-->
<script type="text/javascript">
_editor_url = "editor/";
    
    function validate()
    {
        var manhacungcap = document.getElementById("txtmancc");
        var tennhacungcap = document.getElementById("txttennhacungcap");
        var tennguoilienhe = document.getElementById("txttennguoilienhe");
        var diachi = document.getElementById("txtdiachi");
        var dienthoai = document.getElementById("txtdienthoai");
        if(manhacungcap.value == "")
        {
            alert("Vui lòng nhập mã nhà cung cấp!");
            manhacungcap.focus();
            return false;
        }
        if(tennhacungcap.value == "")
        {
            alert("Vui lòng nhập tên nhà cung cấp!");
            tennhacungcap.focus();
            return false;
        }       
        return true;
    }
</script>
<%@ Register Src="hethongdanhmuc.ascx" TagName="hethongdanhmuc" TagPrefix="uc2" %>
<form name="kho" id = "kho" method="post" runat = "server">
<input type="hidden" name="secondtime" id="secondtime" />
<table border="0" cellpadding="1" cellspacing="1" width="100%" id="user" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:uscmenuKT_HeThongDanhMuc ID="uscmenuKT_HeThongDanhMuc" runat="server" />
        </td>
    </tr> 
    <tr>
        <td class="title" width="100%"><img src="../images/customer.gif" border="0" align="absmiddle">&nbsp;DANH MỤC NHÀ CUNG CẤP<p/></td>
    </tr>
   <tr>
       <td width="100%" id="chitietkho">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr>
                    <td colspan="4" class="header" bgcolor="#3F86F8">Thêm hoặc cập nhật thông tin nhà cung cấp</td>
                </tr>
                <tr>
                    <td colspan ="4">&nbsp;(&nbsp;<font color="red">*</font>&nbsp;)&nbsp;là các thông tin bắt buộc<asp:label  id="lblidnhacungcap" runat="server" visible="False"></asp:label></td></td>
                </tr>
                <tr><td colspan="4"><br /></td></tr>
                <tr>
                    <td width="15%" class="tieude">Mã nhà cung cấp (&nbsp;<font color="red">*</font>&nbsp;)&nbsp;: </td>
                    <td width="40%" id="showtipkho">
                    <asp:textbox name="mancc" id = "txtmancc" onChange="this.value = this.value.toUpperCase();" style="width:200px" class="text" onmouseout="this.className='text'" onmouseover="this.className='textover'" tabindex="1" runat="server"></asp:textbox>
                    <td width="15%" class="tieude">Điện thoại &nbsp;&nbsp;: </td>
                    <td width="30%">
                        <asp:textbox id="txtdienthoai" name="dienthoai" style="width:200px" class="text" onmouseout="this.className='text'" onmouseover="this.className='textover'" tabindex="5" runat="server"/>                        
                        <span class="ajax" id="Span1" style="display:none;">
                            <img src="images/processing.gif" border="0" align="absmiddle" />&nbsp;&nbsp;kiểm tra mã nhà cung cấp...
                        </span>
                    </td>                    
                 </tr>
                 <tr>
                    <td width="15%" class="tieude">Tên nhà cung cấp (&nbsp;<font color="red">*</font>&nbsp;)&nbsp;: </td>
                    <td width="40%">
                        <asp:textbox name="tenncc" id="txttennhacungcap" style="width:400px" class="text" onmouseout="this.className='text'" onmouseover="this.className='textover'" tabindex="2" runat="server"/>                        
                        <span class="ajax" id="ajaxkho" style="display:none;">
                            <img src="images/processing.gif" border="0" align="absmiddle" />&nbsp;&nbsp;kiểm tra mã nhà cung cấp...
                        </span>
                    </td>
                     <td width="15%" class="tieude">Mã số thuế: </td>
                    <td width="30%" id="masothue">
                    <asp:textbox name="masothue" id = "txtmasothue" style="width:200px" class="text"  tabindex="6" runat="server"></asp:textbox></td>                    
                </tr>     
				<tr>
                    <td width="15%" class="tieude">Tên người liên hệ : </td>
                    <td width="40%">
                        <asp:textbox id="txttennguoilienhe" name="tennguoilienhe" style="width:400px" class="text" onmouseout="this.className='text'" onmouseover="this.className='textover'" tabindex="3" runat="server"/>                                               
                    </td>
                    <td width="15%" class="tieude">TK NH: </td>
                    <td width="30%" id="tknh">
                    <asp:textbox name="tknh" id = "txttknh" style="width:200px" class="text"  tabindex="7" runat="server"></asp:textbox></td>                                        
                </tr>     
				<tr>
                    <td width="15%" class="tieude">Địa chỉ &nbsp;&nbsp;: </td>
                    <td width="40%">
                        <asp:textbox id="txtdiachi" name="diachi" style="width:400px" class="text" onmouseout="this.className='text'" onmouseover="this.className='textover'" tabindex="4" runat="server"/>    
                    </td>
                                        
                    <td width="15%" class="tieude">Tên Ngân Hàng: </td>
                    <td width="30%" id="tennh">
                    <asp:textbox name="tennh" id = "txttennh" style="width:400px" class="text"  tabindex="8" runat="server"></asp:textbox></td>
                </tr>     
                <tr>
                    <td colspan="4" align="center" id="functionkho" style="height: 55px"><br/>
                        <asp:button id="btnLuu" runat="server" onClientClick="return validate();" text="Lưu" style="width:80px" OnClick="btnLuu_Click" />
                        <asp:button id="btnSua" runat="server" text="Sửa" style="width:80px" visible="false" OnClick="btnSua_Click" />
                        <asp:button id="btnXoa" runat="server" text="Xoá" style="width:80px" visible="false" OnClick="btnXoa_Click" />
                        &nbsp;&nbsp;&nbsp;<asp:button id="btnTim" runat="server" onclick="btnTim_Click" text="Tìm"
                            width="80px" />
                        <input type="reset" name="btnMoi" value="Mới" onclick="location.href='danhmucnhacungcap.aspx';" style="width:80px;"/>&nbsp;&nbsp;
                        <input type="button" name="Quaylai" value ="Quay lại" onclick="location.href='index.aspx';" style="width:80px;" />&nbsp;&nbsp;
                        <span class="ajax" id="ajaxdanhmuckho" style="display:none;"><img src="images/processing.gif" border="0" />&nbsp;đang load dữ liệu ...</span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
    <td width="100%">
        <asp:datagrid id="dgrnhacungcap" tabIndex="9" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
								DataKeyField="nhacungcapid" BorderWidth="1px" BorderColor="Silver" OnItemDataBound="dgrNhaCC_ItemDataBound" CellPadding="2" OnEditCommand="EditNhaCC"
								OnPageIndexChanged="PageIndexStyleChanged" PageSize="20">
<PagerStyle Mode="NumericPages" ForeColor="DarkBlue" Font-Size="X-Small" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>

<AlternatingItemStyle CssClass="dgrSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></AlternatingItemStyle>

<ItemStyle CssClass="dgrNoSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle CssClass="dgrHeader" HorizontalAlign="Center"></HeaderStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnEdit" runat="server" CssClass="alink3" CommandName="Edit">Chọn</asp:LinkButton>&nbsp;&nbsp; 
</ItemTemplate>
<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn DataField="nhacungcapid" HeaderText="nhacungcapid" Visible="False"></asp:BoundColumn>
<asp:BoundColumn DataField="manhacungcap" HeaderText="Mã NCC">
<ItemStyle Wrap="False"></ItemStyle>

<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tennhacungcap" HeaderText="T&#234;n nh&#224; cung cấp">
<ItemStyle Wrap="False"></ItemStyle>

<HeaderStyle Width="20%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="nguoilienhe" HeaderText="Người li&#234;n hệ">
<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="diachi" HeaderText="Địa chỉ">
<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="dienthoai" HeaderText="Điện thoại">
<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="masothue" HeaderText="Mã số thuế">
<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="taikhoannganhang" HeaderText="TK Ngân hàng">
<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="nganhang" HeaderText="Tên Ngân hàng">
<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
</Columns>
</asp:datagrid>
    </td>
   </tr>
</table>   
</form>
<!--#include file ="footer.htm"-->


