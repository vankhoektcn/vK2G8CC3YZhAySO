<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTH_CongThucKC.aspx.cs" Inherits="ketoan_KTTH_CongThucKC" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_TongHop.ascx" TagName="uscmenuKT_TongHopCTKC" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->
<link type="text/css" rel="stylesheet" href="../ketoan/css_KeToan/sheet_index.css" />
<link href="../ketoan/css_KeToan/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/style.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/epoch_styles.css" />
<link href="../ketoan/css_ketoan/dropdown/themes/default/default.css" media="screen" rel="stylesheet" type="text/css" />
<link href="../ketoan/css_KeToan/epoch_styles.css" type="text/css" rel="stylesheet" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/default.css" />
<script type="text/javascript" src="../ketoan/js_KeToan/libary.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/script.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jscript.js"></script>
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/table_TCHD.css" />
<link href="../ketoan/css_ketoan/dropdown/dropdown.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../ketoan/js_KeToan/epoch_classes.js"></script>
<script type="text/javascript" src="../ketoan/editor/editor.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jquery-1.4.2.js"></script>
<script src="../js/jquery.autocomplete.js" type="text/javascript"></script>
<script language = "javascript" type="text/javascript">
var dp_cal, dp_cals;      
	window.onload = function () 
	{
	    //LoadTieuDe();
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtNgay'));
	    dp_cals = new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
	};
	function LoadTieuDe()
    {
        var obj = document.getElementById("tieudepk");
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                obj.innerHTML = value;                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=LoadTieuDe&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    
function ChonHD()
{
    var chk=document.getElementById("chkChon");
    var idhoadon=document.getElementById("idtoathuoc");
    var tt=document.getElementById("txtNgay");
    var strhoadon="";
    if(chk.checked)
    {
        strhoadon=strhoadon+idhoadon.value+',';
        tt.value=tt.value+strhoadon;
    }
}
function ShowTaiKhoan(obj)
{
    var objsrc = document.getElementById(obj);
  
        $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=DanhSachTaiKhoan_Jquery&Key="+objsrc.value+"&obj="+obj,
                                                    {width:350,scroll:true,formatItem:function(data)
                                                        {return data[1];}
                                                    }
                                                ).result(
                                                            function(event,data)
                                                            {
                                                                setChonTaiKhoan(data[2],obj);
                                                              
                                                            }
                                                        );           
}
function setChonTaiKhoan(MaTaiKhoan,obj)
{      
      var txtTaiKhoan=document.getElementById(obj);
      txtTaiKhoan.value=MaTaiKhoan;      
}

function TestMaTaiKhoan(txtTaiKhoan)
{
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
function chonketchuyen()
{    
    //var kq=document.getElementById("dgr").rows[2].cells[2].getElementsByTagName("chk_kc");    
    var table=document.getElementById("dgr"); 
    alert(table.rows.length);   
    alert(table.rows[2].cells[3].getElementsByTagName("input")[0].value);
//    for(var i=0;i<table.rows.count
//    alert(ketqua);
//    if (kq.checked)
//        alert('duoc chon');
//    else
//        alert('bo chon');
}
</script>
<form id="Form1" runat = "server">
<table border="0" cellpadding="1" cellspacing="1" width="100%"  id = "user">
    <tr>
        <td width = "100%" height = "12px" bgcolor = "#EAEBE6">
            <uc1:uscmenuKT_TongHopCTKC ID="uscmenuKT_TongHopCTKC1" runat="server" />
        </td>
    </tr> 
    <tr>
        <td class = "title" style="padding-bottom:10px; width: 945px;"><p class="title"><img src="../images/quanhuyen.gif" border="0" align="absmiddle">&nbsp;CÔNG THỨC KẾT CHUYỂN</p></td>
    </tr>
    
    <TR>
	    <TD width="100%">
            <span class="ptext">Mã KC:</span>
            <asp:textbox id="txtMaKetChuyen" runat="server" height="20px" tabindex="2" width="149px"></asp:textbox>
            <span class="ptext">Diễn giải:</span>
            <asp:textbox id="txtDienGiai" runat="server" height="20px" tabindex="2" width="149px"></asp:textbox>
            <span class="ptext">STT:</span>
            <asp:textbox id="txtSTT" runat="server" height="20px" tabindex="2" width="29px"></asp:textbox>
        </TD>
    </TR>
    <TR>
	    <TD width="100%">
            <span class="ptext">TK nợ:
            <asp:textbox id="txtTuTK" runat="server" height="20px" onclick="ShowTaiKhoan('txtTuTK')" onchange="TestMaTaiKhoan('txtTuTK')" tabindex="2" width="149px"></asp:textbox>
            Tk có :
            <asp:textbox id="txtDenTK" runat="server" height="20px"  onclick="ShowTaiKhoan('txtDenTK')"   onchange="TestMaTaiKhoan('txtDenTK')" tabindex="2" width="149px"></asp:textbox>
            Công thức:</span>
           <%-- <asp:textbox id="txtCT" runat="server" height="20px" tabindex="2" width="150px"></asp:textbox>--%>
             <asp:dropdownlist id="ddlCongThuc" runat="server" width="150px">
                <asp:ListItem Value="0">---Chọn công thức---</asp:ListItem>
                <asp:ListItem Value="1">KC Nợ -> Có</asp:ListItem>
                <asp:ListItem Value="2">KC Có -> Nợ</asp:ListItem>
                <asp:ListItem Value="3">KC Lãi-Lỗ</asp:ListItem>
             </asp:dropdownlist>
            &nbsp;<asp:button id="btnLuu" runat="server" onclick="btnLuu_Click" text="Cập nhật" />
        </TD>
    </TR>
    <tr>
        <td>
            <span class="ptext">
                Tháng: 
                <asp:dropdownlist id="ddlThang" runat="server" width="50px"></asp:dropdownlist>
                Năm:
                <asp:dropdownlist id="ddlNam" runat="server" width="80px"></asp:dropdownlist>
                &nbsp;<asp:button id="btnKetChuyen" runat="server" onclick="btnKetChuyen_Click" text="Thực hiện KC" />
            </span>
        </td>
    </tr>
    <TR>
		<TD style="width: 100%">
		   <TABLE cellPadding="0" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="center" width="100%" height="20">
						<asp:datagrid id="dgr" tabIndex="6" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
								DataKeyField="MaKC" BorderWidth="1px" BorderColor="Silver" OnItemDataBound="dgr_ItemDataBound" CellPadding="2" OnEditCommand="Edit" AllowPaging="True" OnDeleteCommand = "DelPhieuNhap"
								OnPageIndexChanged="PageIndexStyleChanged" 
								OnCancelCommand="dgr_CancelCommand" OnUpdateCommand="dgr_UpdateCommand" 
							    PageSize="50" OnItemCommand="dgr_ItemCommand">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnDel" runat="server" __designer:wfdid="w16" CommandName="Delete" CssClass="alink3">Xóa</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="3%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
&nbsp;<asp:CheckBox id="chon_kc" runat="server" __designer:wfdid="w14" name="chon_kc" checked='<%#Eval("status_kc") %>' Enable="True"></asp:CheckBox> 
</ItemTemplate>

<HeaderStyle Width="3%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn Visible="False"><ItemTemplate>
<asp:LinkButton id="lbtnEdit" runat="server" __designer:wfdid="w7" CommandName="Edit" CssClass="alink3">Cập nhật</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="8%"></HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn DataField="MaKC" HeaderText="MaKC" Visible="False"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="M&#227; KC" SortExpression="MaKC"><ItemTemplate>
<asp:Label id="MaKC" runat="server" Width="100px" __designer:wfdid="w8" Text='<%#Eval("MaKC") %>'></asp:Label> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Diễn giải" SortExpression="TenKC"><EditItemTemplate>
                                    <asp:TextBox ID="txtTenKC" runat="server" Text='<%#Eval("TenKC") %>' 
                                        Width="420px" />
                                
</EditItemTemplate>
<ItemTemplate>
                                    <asp:Label ID="TenKC" runat="server" Text='<%#Eval("TenKC") %>' 
                                        Width="420px" />
                                
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="STT" SortExpression="STT"><EditItemTemplate>
                                        <asp:TextBox ID="txtSTT" runat="server" Text='<%#Eval("STT") %>' 
                                            Width="30px" />
                                    
                                        
</EditItemTemplate>
<ItemTemplate>
                                                    <asp:Label ID="STT" runat="server" Text='<%#Eval("STT") %>' 
                                                        Width="30px" />
                                                
                                        
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="TK Nợ" SortExpression="TuTaiKhoan"><EditItemTemplate>
                                            <asp:TextBox ID="txtTuTaiKhoan" runat="server" Text='<%#Eval("TuTaiKhoan") %>' 
                                                Width="70px" />
                                        
                                
</EditItemTemplate>
<ItemTemplate>
                                            <asp:Label ID="TuTaiKhoan" runat="server" Text='<%#Eval("TuTaiKhoan") %>' 
                                                Width="70px" />
                                        
                                
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="TK Có" SortExpression="DenTaiKhoan"><EditItemTemplate>
                                    <asp:TextBox ID="txtDenTaiKhoan" runat="server" Text='<%#Eval("DenTaiKhoan") %>' 
                                        Width="70px" />
                                
                                    
</EditItemTemplate>
<ItemTemplate>
                                                <asp:Label ID="DenTaiKhoan" runat="server" Text='<%#Eval("DenTaiKhoan") %>' 
                                                    Width="70px" />                                            
                                    
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="C&#244;ng thức" SortExpression="CongThuc"><EditItemTemplate>
                                  <%--  <asp:TextBox ID="txtCongThuc" runat="server" Text='<%#Eval("CongThuc") %>' Width="120px" />--%>
                                       <asp:dropdownlist id="ddlCongThuc_Datalist" runat="server" width="150px">
                                            <asp:ListItem Value="0">---Chọn công thức---</asp:ListItem>
                                            <asp:ListItem Value="1">KC Nợ -> Có</asp:ListItem>
                                            <asp:ListItem Value="2">KC Có -> Nợ</asp:ListItem>
                                            <asp:ListItem Value="3">KC Lãi-Lỗ</asp:ListItem>
                                       </asp:dropdownlist>
                                
                                    
</EditItemTemplate>
<ItemTemplate>
                                                <asp:Label ID="CongThuc" runat="server" Text='<%#Eval("CongThuc") %>' 
                                                    Width="120px" />                                            
                                    
</ItemTemplate>
</asp:TemplateColumn>
<asp:EditCommandColumn CancelText="Tho&#225;t" EditText="Sửa" UpdateText="Cập nhật" HeaderText="Cập nhật"></asp:EditCommandColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" CssClass="dgrHeader" Font-Bold="True"></HeaderStyle>
</asp:datagrid>						
					</TD>
				</TR>
			</TABLE>			
           						
		</TD>		
	</TR>
	<tr>
	    <td style ="width: 100%;">
	        <div id  = "infospace" runat = "server"></div>
	    </td>
	</tr>
	
</table>
</form>
<!--#include file ="footer.htm"-->

