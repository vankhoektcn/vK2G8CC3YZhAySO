<%@ Page Language="C#" AutoEventWireup="true" CodeFile="danhmuckho.aspx.cs" Inherits="danhmuckho" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_HeThongDanhMuc.ascx" TagName="uscmenuKT_HeThongDanhMuc" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<!--#include file ="header.htm"-->
<script type="text/javascript">
_editor_url = "editor/";

function savenewkho()
{
    var makho = document.getElementById("txtmakho");
    var tenkho = document.getElementById("txtmakho");
    if(makho.value == "")
    {
        alert("Vui lòng nhập mã kho!");
        makho.focus();
        return false;
    }
    if(tenkho.value == "")
    {
        alert("Vui lòng nhập tên kho!")
        tenkho.focus();
        return false;
    }
    return true;
}
</script>
<%@ Register Src="hethongdanhmuc.ascx" TagName="hethongdanhmuc" TagPrefix="uc2" %>
<form name="kho" id="kho" method="post" runat = "server">
<input type="hidden" name="secondtime" id="secondtime" />
<table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:uscmenuKT_HeThongDanhMuc ID="uscmenuKT_HeThongDanhMuc" runat="server" />
            <a href="../ketoan/BaoCaoVATDauRa.aspx">../ketoan/BaoCaoVATDauRa.aspx</a>
        </td>
    </tr> 
    <tr>
        <td class="title" width="100%"><img src="../images/kho.gif" border="0" align="absmiddle">&nbsp;Danh mục kho<p/></td>
    </tr>
   <tr>
       <td width="100%" id="chitietkho">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr>
                    <td colspan="2" class="header" background="../images/header.gif">Thêm hoặc cập nhật kho mới</td>
                </tr>
                <tr><td colspan="2"><br /></td></tr>
                <tr>
                    <td width="20%" class="tieude">Mã kho (&nbsp;<font color="red">*</font>&nbsp;)&nbsp;: </td>
                    <td width="80%" id="showtipkho">
                        <asp:textbox name="txtmakho" id = "txtmakho" onChange="this.value = this.value.toUpperCase();" style="width:250px" class="text" onmouseout="this.className='text'" tabindex="1" onmouseover="this.className='textover'" runat="server"></asp:textbox>
                    <img src="../images/quest.gif" style="cursor:pointer;" align="middle" title="click vào để xem danh sách mã kho"  onclick="showDanhSachKho(0)"/>
                    &nbsp;(&nbsp;<font color="red">*</font>&nbsp;)&nbsp;là các thông tin bắt buộc</td>
                </tr>
                 <tr>
                    <td width="20%" class="tieude">Tên kho (&nbsp;<font color="red">*</font>&nbsp;)&nbsp;: </td>
                    <td width="80%">
                        <asp:textbox name="txttenkho" id ="txttenkho" style="width:250px" class="text" onmouseout="this.className='text'" tabindex="2"  onmouseover="this.className='textover'" runat="server"></asp:textbox>
                        <span class="ajax" id="ajaxkho" style="display:none;">
                            <img src="../images/processing.gif" border="0" align="absmiddle" />&nbsp;&nbsp;kiểm tra mã kho...
                            <asp:label id="lblidkho" runat="server" visible="False"></asp:label>
                        </span></td>
                </tr>                
                <tr>
                    <td colspan="2" align="center" id="functionkho" style="height: 45px"><br/>
                        <asp:button id="btnAddKho" runat="server" style="width:80px;" text="Thêm" tabindex="3" onClientClick="return savenewkho();" OnClick="btnAddKho_Click" />
                        <asp:button id="btnEditKho" runat="server" style="width:80px;" text="Sửa" Visible="false" OnClick="btnEditKho_Click" />
                        <asp:button id="btnDeleteKho" runat="server" style="width:80px;" text="Xoá" Visible="false" OnClick="btnDeleteKho_Click" />
                        &nbsp;&nbsp;
                        <asp:button id="btnTimKho" runat="server" style="width:80px;" text="Tìm" tabindex="4" OnClick="btnTimKho_Click" />
                        &nbsp;&nbsp;
                        <input type="Reset" name="btnlamlai" id="btnLamLai" value ="Mới" style="width:80px;" tabindex="5" onclick="location.href='danhmuckho.aspx';" />&nbsp;&nbsp;
                        <input type="button" id="btnQuayLai" onclick="location.href='index.aspx';" tabindex="6"  value="Quay lại" runat="server" style="width:80px"/>
                        <span class="ajax" id="ajaxdanhmuckho" style="display:none;"><img src="../images/processing.gif" border="0" />&nbsp;đang load dữ liệu ...</span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
    <td width="100%">
        <asp:datagrid id="dgrkho" tabIndex="6" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
								DataKeyField="idkho" BorderWidth="1px" BorderColor="Silver" OnItemDataBound="dgrkho_ItemDataBound" CellPadding="2" OnEditCommand="EditKho"
								OnPageIndexChanged="PageIndexStyleChanged" PageSize="20">
<PagerStyle Mode="NumericPages" ForeColor="DarkBlue" Font-Size="X-Small" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>

<AlternatingItemStyle CssClass="dgrSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></AlternatingItemStyle>

<ItemStyle CssClass="dgrNoSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle CssClass="dgrHeader" HorizontalAlign="Center"></HeaderStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnEdit" runat="server" CssClass="alink3" CommandName="Edit" __designer:wfdid="w8">Chọn</asp:LinkButton>&nbsp;&nbsp; 
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn DataField="idkho" HeaderText="idkho" Visible="False"></asp:BoundColumn>
<asp:BoundColumn DataField="makho" HeaderText="M&#227; kho">
<ItemStyle Wrap="False"></ItemStyle>

<HeaderStyle Width="20%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenkho" HeaderText="T&#234;n kho">
<ItemStyle Wrap="False"></ItemStyle>

<HeaderStyle Width="70%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
</Columns>
</asp:datagrid>
    </td>
   </tr>
</table>   
</form>
<!--#include file ="footer.htm"-->


