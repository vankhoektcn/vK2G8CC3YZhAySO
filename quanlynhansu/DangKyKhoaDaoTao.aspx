<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DangKyKhoaDaoTao.aspx.cs" Inherits="quanlynhansu_DangKyKhoaDaoTao" %>

<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->  
<script language="javascript">
var dp_cal, dp_cal1;      
	window.onload = function () 
	{
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtNgayDangKy'));
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
	 function LoadDSNhanVien()
        {
            
            $("#txtTenNhanVien").autocomplete("ajax.aspx?do=LoadDSNV",{ formatItem: function(data) { return data[1]; }, width: 700,scrollHeight: 500,scroll:true,resultsClass: "ac_results",loadingClass: "ac_loading"
            ,autoFill:true})
            .result(function(event,data,formated)
                {
                    if(data){
                        document.getElementById("txtIdNhanVien").value=data[2];   
                        document.getElementById("txtMaNV").value=data[4]                                          
                    }
                });
            ;
        }
function showDanhSachNhanVien()
{ 
	var listID = document.getElementById('listIdNV').value;
	hideTip("tipnhanvien");
 var td = document.getElementById("showtipNhanVien");
 var txtListIdPhongCheckAll= document.getElementById("txtListIdPhongCheckAll").value;
 createTipFocus(td,"tipnhanvien","danhsachNhanVien","Danh sách Nhân Viên","ajaxbenhnhanexists"," đang load danh sách Nhân Viên...","Lỗi trong quá trình load danh sách nhân viên","../quanlynhansu/ajax.aspx?do=showDSNV&listID="+listID+"&txtListIdPhongCheckAll="+txtListIdPhongCheckAll+"&idpb="+idpb+"", "750", "500",null);   
}
</script>

<form id="Form1" method="post" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: #C0C0C0">
        <tr>
            <td width="100%" align="left" style="background-color: #FBF8F1; height: 19px;">
                <uc1:uscmenu ID="Uscmenu1" runat="server" />
            </td>
        </tr>
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="100%" align="left" style="background-color: White">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td valign="top" style="padding-left: 0px; padding-top: 0px; width: 100%;">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px">
                                        <table id="user" cellspacing="1" cellpadding="1" width="100%" border="0" class="khung">
                                            <tr>
                                                <td align="center" style="width: 100%; background-color: #FBF8F1; height: 19px; background-image: url(../images/menu.jpg);
                                                    color: Red; font-weight: bold">
                                                    ĐĂNG KÝ KHÓA ĐÀO TẠO</td>
                                            </tr>
                                            <tr>
                                                <td width="100%" align="center">
                                                    <table cellpadding="0" width="100%" border="0">
                                                        <tr>
                                                            <td valign="top" align="center" width="100%" style="height: 151px">
                                                                <table cellspacing="0" cellpadding="0" width="98%" border="0">
                                                                    <tr style="padding-bottom: 5px; padding-top: 10px">
                                                                        <td align="center" style="height: 81px; padding-left: 50px; width: 100%;">
                                                                            <table width="1000px" rules="none" style="border-color: Blue; border-style: double;
                                                                                border: 4px">
                                                                                <tr align="left">
                                                                                    <td valign="top" colspan="6" nowrap align="left" style="height: 23px; width: 110px;">
                                                                                        <p class="ptext">
                                                                                            Khóa đào tạo :&nbsp;
                                                                                             <asp:dropdownlist id="ddlKhoaDaoTao" runat="server" width="180px" TabIndex="4" AutoPostBack="True" OnSelectedIndexChanged="ddlKhoaDaoTao_SelectedIndexChanged" ></asp:dropdownlist>
                                                                                        </p>
                                                                                    </td>
                                                                                   
                                                                                </tr>
                                                                                <tr align="left">                                                                          
                                                                                    <td valign="top"   style="padding-right:2px; width: 169px;">
                                                                                        <p class="ptext">
                                                                                            Nhân viên:&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="right"  style="width: 200px; height: 40px;padding-right:10px" >
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txtTenNhanVien" runat="server" width="200px" class="input" onfocus="LoadDSNhanVien();" tabindex="4"></asp:textbox>                                                                                        
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top"  align="right" style="padding-right:2px; width: 169px;">
                                                                                        
                                                                                        <p class="ptext">
                                                                                            Mã NV:
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="right"  style="width: 248px; height: 40px;padding-right:10px" >
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txtMaNV" runat="server" class="input" width="154px" enable="false" tabindex="4" Enabled="False"></asp:textbox>                                                                                            
                                                                                        </p>
                                                                                    </td>
                                                                                
                                                                                    <td valign="top"  align="left" style="height: 40px; padding-left: 10px; width: 250px;">
                                                                                        <p class="ptext">
                                                                                            Ngày đăng ký:
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="right"  style="width: 136px; height: 40px;padding-right:10px" >
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txtNgayDangKy" class="input" runat="server" width="180px" tabindex="4"></asp:textbox>
                                                                                            &nbsp;</p>
                                                                                    </td>
                                                                                    <td valign="top"  align="left" style="padding-right:2px; width: 269px;">
                                                                                        <p class="ptext">
                                                                                            Đã đóng: <asp:checkbox runat="server" tabindex="4" id="chck_DaDong"></asp:checkbox>
                                                                                        </p>
                                                                                    </td>
                                                                                    
                                                                                
                                                                                <tr valign="top" align="left" >
                                                                                    <td>Ghi chú</td>
                                                                                    <td colspan="5">  <asp:textbox id="txtGhiChu" runat="server" width="580px" tabindex="4"></asp:textbox></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td id="showtipNhanVien"></td>
                                                                                </tr>
                                                                            </table>
                                                                            <table width="400px">
                                                                                <tr>
                                                                                    <td style="height: 20px; width: 437px;">
                                                                                        <input id="txtIdChiTietKhoaDaoTao" type="hidden" value='' name="txtIdChiTietKhoaDaoTao" runat="server" size="1"/>
                                                                                        <input id="txtIdNhanVien" type="hidden" value='' name="txtIdNhanVien" runat="server" size="1"/>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" style="width: 70%">
                                                                                        <table style="border-color: Gray; border-style: double; border: 0px;">
                                                                                            <tr style="padding-top: 2px">
                                                                                                <td valign="top" align="center" width="430" style="width: 430px; height: 19px;" nowrap>
                                                                                                    <asp:imagebutton id="btnAdd" onclick="btnAdd_Click" runat="server" imageurl="../images/nut_add.gif"
                                                                                                        tabindex="8"></asp:imagebutton>
                                                                                                    &nbsp;
                                                                                                    <asp:imagebutton id="btnEdit" onclick="btnEdit_Click" runat="server" imageurl="../images/sua.gif"
                                                                                                        tabindex="9"></asp:imagebutton>
                                                                                                    &nbsp;
                                                                                                    <asp:imagebutton id="btnCancel" onclick="btnCancel_Click" runat="server" imageurl="../images/cancel.gif"
                                                                                                        tabindex="10"></asp:imagebutton>
                                                                                                    &nbsp;
                                                                                                    <asp:imagebutton id="btnTim" runat="server" imageurl="../images/tim.png" tabindex="10"
                                                                                                        onclick="btnTim_Click"></asp:imagebutton>
                                                                                                         &nbsp;
                                                                                              <asp:imagebutton id="imgInExel" runat="server" imageurl="~/images/btnExcel.jpg" tabindex="11"
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
                                                            <td align="left" style="width: 100%; background-color: #FBF8F1; height: 19px; background-image: url(../images/menu.jpg);
                                                                color: White; font-weight: bold">
                                                                &nbsp;DANH SÁCH ĐĂNG KÝ KHÓA ĐÀO TẠO</td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" width="100%" border="0" style="background-color: #D4D0C8">
                                                        <tr>
                                                            <td valign="top" align="right" colspan="2"  style="width:80%;background-color: #D4D0C8">
                                                                <asp:datagrid id="dgr" tabindex="12" runat="server" width="100%" allowsorting="True"
                                                                    autogeneratecolumns="False" datakeyfield="idchitietkhoadaotao" borderwidth="1px" bordercolor="Silver"
                                                                    onitemdatabound="dgr_ItemDataBound" cellpadding="2" ondeletecommand="Dellete"
                                                                    oneditcommand="Edit" allowpaging="True" onpageindexchanged="PageIndexStyleChanged"
                                                                    pagesize="30">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnDel" runat="server" CssClass="alink3" CommandName="Delete" __designer:wfdid="w1">Xóa</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="3%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
														    <asp:LinkButton id="lbtnEdit" CommandName="Edit" runat="server" CssClass="alink3">Sửa</asp:LinkButton>
													    
</ItemTemplate>

<HeaderStyle Width="3%"></HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn DataField="MucDichDaoTao" HeaderText="Khóa đào tạo">
<HeaderStyle Wrap="False" Width="20%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tungay" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Từ ngày">
<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tennhanvien" HeaderText="Nh&#226;n vi&#234;n">
<HeaderStyle Wrap="False" Width="20%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="manhanvien" DataFormatString="manhanvien" HeaderText="Mã nh&#226;n vi&#234;n">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaydangky" HeaderText="Ngày đăng ký">
<HeaderStyle Width="10px"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ghichu" HeaderText="GhiChu">
<HeaderStyle Width="20px"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="dadong" HeaderText="Đã đóng">
<HeaderStyle Width="3px"></HeaderStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" BackColor="#FFE0C0" CssClass="dgrHeader" Font-Bold="True" ForeColor="Blue"></HeaderStyle>
</asp:datagrid>
                                                                &nbsp;
                                                                <input id="listIdNV" type="hidden" />
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
