<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTVT_DM_Vat_Tu_CCDC.aspx.cs" Inherits="DM_Vat_Tu_KT_CCDC" %>
<!--#include file ="header.htm"-->
<link type="text/css" rel="stylesheet" href="../ketoan/css_KeToan/sheet_index.css" />
<link href="../ketoan/css_KeToan/epoch_styles.css" type="text/css" rel="stylesheet" />
<link href="../ketoan/css_KeToan/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/default.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/style.css" />
<script type="text/javascript" src="../ketoan/js_KeToan/libary.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/script.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jscript.js"></script>
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/table_TCHD.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/epoch_styles.css" />
<link href="../ketoan/css_ketoan/dropdown/dropdown.css" media="screen" rel="stylesheet" type="text/css" />
<link href="../ketoan/css_ketoan/dropdown/themes/default/default.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../ketoan/js_KeToan/epoch_classes.js"></script>
<script type="text/javascript" src="../ketoan/editor/editor.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jquery-1.4.2.js"></script>
<script src="../js/jquery.autocomplete.js" type="text/javascript"></script>
<script type="text/javascript">
_editor_url = "editor/";
    
    function validate()
    {
        var mavt=document.getElementById("txtma_vt");
        if(mavt.value=="")
        {
            alert("Bạn chưa nhập mã ccdc!");
            mavt.focus();
            return false;
        }        
    }
    function ShowTaiKhoan(Ctr)
{
    var obj = Ctr.id;
    var objsrc = document.getElementById(obj);
        $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=DanhSachTaiKhoan_Jquery&Key="+objsrc.value+"&obj="+obj,
                                                    {width:350,scroll:true,formatItem:function(data)
                                                        {return data[1];}
                                                    }
                                                ).result(
                                                            function(event,data)
                                                            {
                                                                setChonTaiKhoan(data[2],obj);
                                                             //   document.getElementById(obj).blur();
                                                            }
                                                        );           
}

function setChonTaiKhoan(MaTaiKhoan,idText)
{
      if(idText!="")
      {
          var txtTaiKhoan=document.getElementById(idText);
          txtTaiKhoan.value=MaTaiKhoan;
          txtTaiKhoan.focus();
      }
}

function TestMaTaiKhoan(Ctr)
{
    var txtTaiKhoan = Ctr.id;
    var MaTaiKhoan = document.getElementById(txtTaiKhoan);
    if(MaTaiKhoan.value!="")
    {
        xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="1")
                      {  
                         alert("Tài khoản bạn chọn chưa có trong danh mục tài khoản. Vui lòng kiểm tra lại. Cảm ơn!");
                         MaTaiKhoan.value ="";
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TestMaTaiKhoan&Key="+MaTaiKhoan.value+"&times="+Math.random(),true);
            xmlHttp.send(null);
    }
}
</script>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_HeThongDanhMuc.ascx" TagName="uscmenuKT_HeThongDanhMuc" TagPrefix="uc2" %>
<form name="kho" id = "kho" method="post" runat = "server">
<input type="hidden" name="secondtime" id="secondtime" />
<table border="0" cellpadding="1" cellspacing="1" width="100%" id="user1" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc2:uscmenuKT_HeThongDanhMuc ID="uscmenuKT_HeThongDanhMuc1" runat="server" />
        </td>
    </tr> 
    <tr>
        <td class="title" width="100%"><img src="../images/customer.gif" border="0" align="absmiddle">&nbsp;DANH MỤC CÔNG CỤ DỤNG CỤ<p>
            </p></td>
    </tr>
   <tr>
       <td width="100%" id="chitietkho">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user1">
                <tr>
                    <td colspan="6" class="header" bgcolor="#3F86F8">Thêm hoặc cập nhật thông tin công cụ dụng cụ</td>
                </tr>
                <tr>
                    <td colspan ="6">&nbsp;(&nbsp;<font color="red">*</font>&nbsp;)&nbsp;là các thông tin bắt buộc<asp:label  id="lbldmvattuid" runat="server" visible="False"></asp:label></td>
                </tr>
                <tr><td colspan="6"><br /></td></tr>
                <tr>
                    <td width="10%" class="tieude">Mã CCDC (&nbsp;<font color="red">*</font>&nbsp;)&nbsp;: </td>
                    <td width="20%" id="showtipkho">
                    <asp:textbox name="txtmavt" id = "mavt" onChange="this.value = this.value.toUpperCase();" style="width:200px" class="text" onmouseout="this.className='text'" onmouseover="this.className='textover'" tabindex="1" runat="server"></asp:textbox>
                    </td>
                    <td width="10%" class="tieude">Tên CCDC (&nbsp;<font color="red">*</font>&nbsp;)&nbsp;: </td>
                    <td width="30%">
                        <asp:textbox id="tenvt" name="txttenvt" style="width:200px" class="text" onmouseout="this.className='text'" onmouseover="this.className='textover'" tabindex="2" runat="server"/>                                                
                    </td>  
                    <td width="10%" class="tieude">ĐVT (&nbsp;<font color="red">*</font>&nbsp;)&nbsp;: </td>
                    <td width="20%">
                        <asp:textbox id="dvt" name="dvt" style="width:100px" class="text" onmouseout="this.className='text'" onmouseover="this.className='textover'" tabindex="3" runat="server"/>                                                
                    </td>                    
                 </tr>
                 <tr>
                    <td width="10%" class="tieude">Nước SX : </td>
                    <td width="20%">
                        <asp:textbox name="txtnuoc_sx" id="nuoc_sx" style="width:200px" class="text" onmouseout="this.className='text'" onmouseover="this.className='textover'" tabindex="4" runat="server"/>                                                
                    </td>
                     <td width="10%" class="tieude">Năm SX: </td>
                    <td width="30%" >
                    <asp:textbox name="txtnam_sx" id="nam_sx"  style="width:200px" class="text"  tabindex="5" runat="server"></asp:textbox></td>                    
                     <td width="10%" class="tieude">TK Kho: </td>
                    <td width="20%" >
                    <asp:textbox name="txttk_kho" id="tk_kho"  style="width:100px" class="text" onfocus="ShowTaiKhoan(this);"  tabindex="6" runat="server"></asp:textbox></td>                    
                </tr>     
				<tr >
                    <td width="10%" class="tieude">TK khấu hao : </td>
                    <td width="20%">
                        <asp:textbox id="tk_khauhao" name="tk_khau_hao" style="width:200px" class="text" onfocus="ShowTaiKhoan(this);" onmouseout="this.className='text'" onmouseover="this.className='textover'" tabindex="7" runat="server"/>                                               
                    </td>
                    <td width="10%" class="tieude">TK chi phí: </td>
                    <td width="30%" >
                    <asp:textbox name="txttk_chiphi" id="tk_chiphi" style="width:200px" class="text" onfocus="ShowTaiKhoan(this);"  tabindex="8" runat="server"></asp:textbox></td>                                                                                
                    
                    <td></td>
                </tr>                     
				<tr >
                    <td   width="15%" class="tieude">Ghi chú &nbsp;&nbsp;: </td>
                    <td width="60%" colspan="5">
                        <asp:textbox id="ghi_chu" name="txtghi_chu" style="width:500px" class="text" onmouseout="this.className='text'" onmouseover="this.className='textover'" tabindex="9" runat="server"/>    
                    </td>                                                           
                </tr>                     				     
                <tr>
                    <td colspan="6" align="center" id="functionkho" style="height: 55px"><br/>
                        <asp:button id="btnLuu" runat="server" onClientClick="return validate();" text="Lưu" style="width:80px" OnClick="btnLuu_Click" />
                        <asp:button id="btnSua" runat="server" text="Sửa" style="width:80px" visible="false" OnClick="btnSua_Click" />
                        <asp:button id="btnXoa" runat="server" text="Xoá" style="width:80px" visible="false" OnClick="btnXoa_Click" />
                        &nbsp;&nbsp;&nbsp;<asp:button id="btnTim" runat="server" onclick="btnTim_Click" text="Tìm"
                            width="80px" />
                        <input type="reset" name="btnMoi" value="Mới" onclick="location.href='KTVT_DM_Vat_Tu.aspx';" style="width:80px;"/>&nbsp;&nbsp;
                        <input type="button" name="Quaylai" value ="Quay lại" onclick="location.href='index.aspx';" style="width:80px;" />&nbsp;&nbsp;
                        <span class="ajax" id="ajaxdanhmuckho" style="display:none;"><img src="images/processing.gif" border="0" />&nbsp;đang load dữ liệu ...</span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
    <td width="100%">        
  <asp:datagrid id="dgrdmvattu" tabIndex="9" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
								DataKeyField="danhmuc_vattu_id" BorderWidth="1px" BorderColor="Silver" OnItemDataBound="dgrDMVatTu_ItemDataBound" CellPadding="2" OnEditCommand="EditDMVatTu"
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
<asp:BoundColumn DataField="danhmuc_vattu_id" HeaderText="danhmuc_vattu_id" Visible="False"></asp:BoundColumn>

<asp:BoundColumn DataField="ma_vt" HeaderText="Mã CCDC">
<ItemStyle Wrap="False"></ItemStyle>
<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="ten_vt" HeaderText="Tên CCDC">
<ItemStyle Wrap="False"></ItemStyle>
<HeaderStyle Width="20%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="dvt" HeaderText="Đvt">
<ItemStyle Wrap="False"></ItemStyle>
<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="tk_kho" HeaderText="TK Kho">
<ItemStyle Wrap="False"></ItemStyle>
<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="tk_khau_hao" HeaderText="TK khấu hao">
<ItemStyle Wrap="False"></ItemStyle>
<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="tk_chi_phi" HeaderText="TK chi phí">
<ItemStyle Wrap="False"></ItemStyle>
<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="ghi_chu" HeaderText="Ghi chú">
<ItemStyle Wrap="False"></ItemStyle>
<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>

</Columns>
</asp:datagrid>
    </td>
   </tr>
</table>   
</form>
<!--#include file ="footer.htm"-->
