<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhanQuyen.aspx.cs" Inherits="PhanQuyenNew" %>
<!--#include file ="header_hethong.htm"-->
<%@ Register Src="menu_HeThong.ascx" TagName="menu_HeThong" TagPrefix="uc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<script language = "javascript">
   
   function LoadListNguoiDung(obj)
	{
	     $(obj).unautocomplete().autocomplete("../khambenh/ajax.aspx?do=LoadDanhSachNguoiDung",
        {formatItem: function(data) {
                return data[0];
            },width:700,scroll:true,header:"<div style='font-weight:bold;height:15px;text-align:left'><div style=\"width:30%;color:white;float:left\" >Tên người dùng</div>"
       + "<div style=\"width:30%;float:left\" >Phòng ban</div>"
        + "<div style=\"width:20%;float:left\" >Nhóm ND</div>"
        + "<div style=\"width:20%;float:left\" >Tên Đăng Nhập</div></div>"}
        )        
        .result(function(event, data){
        if(document.getElementById("btnSave") != null)
          document.getElementById("btnSave").style.display= 'none';        
        deleterows(0);
        setChonNguoiDung(data[1],data[2],data[3],data[4],data[5]); 
        
        });
         
	}
	function LoadListNguoiDung_CPY(obj)
	{
	     $(obj).unautocomplete().autocomplete("../khambenh/ajax.aspx?do=LoadDanhSachNguoiDung",
        {formatItem: function(data) {
                return data[0];
            },width:700,scroll:true,header:"<div style='font-weight:bold;height:15px;text-align:left'><div style=\"width:30%;color:white;float:left\" >Tên người dùng</div>"
       + "<div style=\"width:30%;float:left\" >Phòng ban</div>"
        + "<div style=\"width:20%;float:left\" >Nhóm ND</div>"
        + "<div style=\"width:20%;float:left\" >Tên Đăng Nhập</div></div>"}
        )        
        .result(function(event, data){    
	            var id = document.getElementById("<%=txtIdNguoiDung_CPY.ClientID%>");
	            id.value = data[1];
	            var Ten = document.getElementById("<%=mkv_txtIdNguoiDung_CPY.ClientID%>");
	            Ten.value = data[2];
        
        });
         
	}
	function deleterows()
	{
	   var idtable = document.getElementById("dgView");
	   if(idtable != null)
	   {
	       for(var i=0;i<idtable.rows.length;i++)
	       {
                idtable.deleteRow(i);	   	   	       
	       }
	       if(idtable.rows.length > 0){
	        deleterows();
	       }
	   }	   
	}
	function setChonNguoiDung(idNguoiDung, TenNguoiDung, PhongBan, Nhom,Username)
	{	
	    document.getElementById("txtIdNguoiDung").value="0";
	    var id = document.getElementById("txtNguoiDung");
	       id.value = idNguoiDung;
	    var Ten = document.getElementById("mkv_txtNguoiDung");
	       Ten.value = TenNguoiDung;
	    
	}    
</script>
<form id="Form1" method="post" runat="server"> 
<asp:scriptmanager runat="server" id="ScriptM"></asp:scriptmanager>
<asp:updatepanel runat="server" id="updatepanel1"><ContentTemplate>
<TABLE style="BACKGROUND-COLOR: #c0c0c0" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY>
<TR><TD style="HEIGHT: 10px; BACKGROUND-COLOR: #d4d0c8" align=left width="100%">
<asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder> </TD></TR>
<TR><TD style="BACKGROUND-COLOR: #d4d0c8" align=left width="100%">&nbsp;</TD></TR>
<TR><TD style="BACKGROUND-COLOR: #d4d0c8" align=left width="100%">
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY>
<TR><TD style="PADDING-LEFT: 0px; PADDING-TOP: 0px" vAlign=top width="100%">
<TABLE id="user" class="khung" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY>
<TR><TD style="BACKGROUND-COLOR: #4d67a2" class="title" align=center><SPAN style="COLOR: #ffffff" class="title"><STRONG>PHÂN QUYỀN NGƯỜI DÙNG</STRONG></SPAN></TD>
</TR>
<TR>
    <TD width="100%">&nbsp; <asp:label id="Label1" runat="server" width="120px" text="Tên người dùng" font-bold="True"></asp:label>
 <%--<asp:dropdownlist id="cbNguoiDung" runat="server" width="288px"></asp:dropdownlist>--%>
 <INPUT style="WIDTH: 16px" id="txtIdNguoiDung" type=hidden value="0" name="txtIdNguoiDung" runat="server" /> 
 <INPUT style="WIDTH: 16px" id="txtNguoiDung" type=hidden value="0" name="txtTenNguoiDung" runat="server" /> 
 <INPUT style="WIDTH: 200px" id="mkv_txtNguoiDung" onfocus="LoadListNguoiDung(this)" type=text name="txtTenNguoiDung" runat="server" />
 &nbsp;Loại quyền:&nbsp;<asp:DropDownList runat="server" id="ddlLoaiQuyen" width="150px"></asp:DropDownList> <%--fffffffffffff--%>
 <asp:button id="btnGetList" onclick="btnGetList_Click" runat="server" width="151px" text="Danh sách quyền" backcolor="Turquoise"></asp:button>
  </TD>
 </TR><TR>
    <TD width="100%"><SPAN style="FONT-SIZE: 0.7em; COLOR: #000" class="title">Hỗ trợ:</SPAN> 
 <SPAN style="FONT-SIZE: 0.7em; COLOR: #000" class="title"><STRONG>Lấy quyền từ</STRONG></SPAN> 
 <INPUT style="WIDTH: 16px" id="txtIdNguoiDung_CPY" type=hidden value="0" name="txtIdNguoiDung_CPY" runat="server" /> 
 <INPUT style="WIDTH: 200px" id="mkv_txtIdNguoiDung_CPY" onfocus="LoadListNguoiDung_CPY(this)" type=text name="mkv_txtIdNguoiDung_CPY" runat="server" />
  <asp:button id="btnCopy" onclick="btnCopy_Click" runat="server" width="151px" text="Copy quyền" backcolor="Turquoise"></asp:button> </TD></TR>
  <TR><TD width="100%"><TABLE cellPadding=0 width="100%" border=0><TBODY><TR><TD style="HEIGHT: 20px" vAlign=top align=center width="100%" colSpan=2>
  <asp:button id="btnSave1" onclick="btnSave_Click" runat="server" width="127px" text="Lưu" backcolor="LightSeaGreen" forecolor="Black"></asp:button> 
  
  <asp:datagrid id="dgView" tabIndex=12 runat="server" width="700px" backcolor="#DEBA84" pagesize="50" cellspacing="2" cellpadding="3" borderwidth="1px"
   borderstyle="None" bordercolor="#DEBA84" autogeneratecolumns="False" allowsorting="True" OnItemDataBound="dgView_ItemDataBound">
<FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510"></FooterStyle>

<SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White"></SelectedItemStyle>

<PagerStyle Mode="NumericPages" HorizontalAlign="Left" Font-Names="Arial" Font-Size="Small" ForeColor="#8C4510"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" BackColor="#FFF7E7" CssClass="dgrNoSelectItem" ForeColor="#8C4510"></ItemStyle>
<Columns>
<asp:BoundColumn DataField="STT" HeaderText="STT">
<HeaderStyle Width="3%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="PermDesc" HeaderText="Chức năng">
<HeaderStyle Width="35%" ></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="Xem"><ItemTemplate>
    <asp:CheckBox id="chbXem" runat="server" Checked='<%# Eval("XEM") %>'></asp:CheckBox>
    <input  type="hidden" id="IDXem" runat="server" value='<%# Eval("IDXem") %>'/>
</ItemTemplate>

<HeaderStyle Width="3%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Thêm"><ItemTemplate>
<asp:CheckBox id="chbThem" runat="server" Checked='<%# Eval("THEM") %>'></asp:CheckBox> 
    <input  type="hidden" runat="server" id="IDThem" value='<%# Eval("IDThem") %>'/>
</ItemTemplate>

<HeaderStyle Width="3%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Xóa"><ItemTemplate>
<asp:CheckBox id="chbXoa" runat="server" Checked='<%# Eval("XOA") %>'></asp:CheckBox>
    <input  type="hidden" id="IDXoa" runat="server" value='<%# Eval("IDXoa") %>'/>
</ItemTemplate>

<HeaderStyle Width="3%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Sửa"><ItemTemplate>
<asp:CheckBox id="chbSua" runat="server" Checked='<%# Eval("SUA") %>'></asp:CheckBox> 
<input  type="hidden" id="IDSua" runat="server" value='<%# Eval("IDSua") %>'/>
</ItemTemplate>

<HeaderStyle Width="3%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:TemplateColumn>
</Columns>

<HeaderStyle HorizontalAlign="Left" BackColor="#A55129" CssClass="dgrHeader" Font-Bold="True" ForeColor="White"></HeaderStyle>
</asp:datagrid>&nbsp; <asp:button id="btnSave" onclick="btnSave_Click" runat="server" width="127px" text="Lưu" backcolor="LightSeaGreen" forecolor="Black"></asp:button> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:updatepanel>
 </form>
<!--#include file ="footer.htm"-->