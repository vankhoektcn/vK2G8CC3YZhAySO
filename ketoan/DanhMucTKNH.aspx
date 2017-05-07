<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhMucTKNH.aspx.cs" Inherits="DanhMucTKNH" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_NganHang.ascx" TagName="menu_ketoannganhang1" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<!--#include file ="header.htm"-->
<link type="text/css" rel="stylesheet" href="../ketoan/css_KeToan/sheet_index.css" />
<link href="../ketoan/css_KeToan/epoch_styles.css" type="text/css" rel="stylesheet" />
<link href="../ketoan/css_KeToan/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/default.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/style.css" /
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/table_TCHD.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/epoch_styles.css" />
<link href="../ketoan/css_ketoan/dropdown/dropdown.css" media="screen" rel="stylesheet" type="text/css" />
<link href="../ketoan/css_ketoan/dropdown/themes/default/default.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../ketoan/js_KeToan/libary.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/script.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jscript.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/epoch_classes.js"></script>
<script type="text/javascript" src="../ketoan/editor/editor.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jquery-1.4.2.js"></script>
<script src="../js/jquery.autocomplete.js" type="text/javascript"></script>
    
<script type="text/javascript" language="javascript">
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
                                                                document.getElementById(obj).blur();
                                                            }
                                                        );           
}

function setChonTaiKhoan(MaTaiKhoan,idText)
{
      if(idText!="")
      {
          var txtTaiKhoan=document.getElementById(idText);
          txtTaiKhoan.value=MaTaiKhoan;
        document.getElementById(idText).focus();
      }
}
</script>
<div>
<body>
<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0"   border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:menu_ketoannganhang1 ID="Menu_ketoannganhang2" runat="server" />
        </td>
    </tr>   
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr>
                    <td width = "100%" class = "header">PHẦN MỀM QUẢN LÝ: DANH MỤC TÀI KHOẢN NGÂN HÀNG</td>
                </tr>
                <TR>
					    <TD width="100%" valign = "top">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" style="height: 172px">
									    <TABLE cellSpacing="0" cellPadding="0" width="98%" border="0">
										    
										    <TR style="PADDING-BOTTOM: 5px; PADDING-TOP: 10px">
											    <TD align="left" width="100%" style="height: 20px">
												    <TABLE style="HEIGHT: 17px" cellSpacing="0" cellPadding="0" width="100%" border="0">
													    
													    <TR>
														    <TD  noWrap align="right" style="WIDTH: 12%; height: 24px;">
															    <span class="ptext">Số hiệu tài khoản NH:&nbsp;
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH:18%; height: 24px;">
															    <span class="ptext">&nbsp;<asp:textbox id="txtSoHieuTKNH" runat="server" width="238px" TabIndex="1"></asp:textbox></span></TD>
														    <TD  noWrap align="right" style="WIDTH: 9%; height: 24px;">
														    </TD>
														    <TD  noWrap align="left" style="WIDTH: 25%; height: 24px;">
														    </TD>
													    </TR>
													    <TR>
														    <TD  noWrap align="right" style="WIDTH: 12%; height: 24px;">
															    <span class="ptext">Tài khoản kế toán:&nbsp;
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH:18%; height: 24px;">
															    <span class="ptext">&nbsp;</span><asp:textbox id="txtTaiKhoanKT" onfocus="ShowTaiKhoan('txtTaiKhoanKT')" runat="server" width="238px" TabIndex="4"></asp:textbox></TD>
														    <TD  noWrap align="right" style="WIDTH: 9%; height: 24px;">
														    </TD>
														    <TD  noWrap align="left" style="WIDTH: 25%; height: 24px;">
															    </TD>
													    </TR>
													    <TR>
														    <TD  noWrap align="right" style="WIDTH: 12%; height: 24px;">
															    <span class="ptext">Tên tài khoản NH:&nbsp;
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH:18%; height: 24px;" colspan = "3">
															    <span class="ptext">&nbsp;</span><asp:textbox id="txtTenTKNH" runat="server" Width="665px" TabIndex="9"></asp:textbox></TD>
														    
													    </TR>
													    <TR>
														    <TD  noWrap align="right" style="WIDTH: 12%; height: 24px;">
															    <span class="ptext">
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH:18%; height: 24px;" colspan = "3">
															    <span class="ptext"><br>
															        &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                    <asp:imagebutton id="btnAdd" runat="server" imageurl="../images/nut_add.gif"
																    tabIndex="10" OnClick="btnAdd_Click"></asp:imagebutton>&nbsp;
															    <asp:imagebutton id="btnEdit" runat="server" OnClick="btnEdit_Click" imageurl="../images/sua.gif" tabIndex="11"></asp:imagebutton>&nbsp;
															    <asp:imagebutton id="btnCancel" OnClick="btnCancel_Click"  runat="server" imageurl="../images/cancel.gif"
																    tabIndex="12"></asp:imagebutton>&nbsp;
															    <asp:ImageButton id="ImageButton1" OnClick="ImageButton1_Click" runat="server" ImageUrl="~/images/tim.png" TabIndex="13"></asp:ImageButton>
															    </span>
														    </TD>
														    
													    </TR>
												    </TABLE>
                                                  </TD>
										    </TR>
									    </TABLE>
								    </TD>
							    </TR>
							    <tr>
                                    <td width = "100%" class = "header">DANH SÁCH TÀI KHOẢN NGÂN HÀNG</td>
                                </tr>
						    </TABLE>
						    
						    				   
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" colSpan="2" height="20">
									    <asp:datagrid id="dgr" tabIndex="12" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
											    DataKeyField="SoHieuTKNH" BorderWidth="1px" BorderColor="Silver" OnItemDataBound="dgr_ItemDataBound" CellPadding="2" OnDeleteCommand = "DeltiepNhanDT" OnEditCommand="Edit" AllowPaging="True"
											    OnPageIndexChanged="PageIndexStyleChanged" PageSize="100">
<PagerStyle Mode="NumericPages" ForeColor="DarkBlue" Font-Size="Small" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>

<AlternatingItemStyle CssClass="dgrSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></AlternatingItemStyle>

<ItemStyle CssClass="dgrNoSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle CssClass="dgrHeader" HorizontalAlign="Center"></HeaderStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnDel" runat="server" CssClass="alink3" CommandName="Delete" __designer:wfdid="w4">Xóa</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="4%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnEdit" runat="server" CssClass="alink3" CommandName="Edit" __designer:wfdid="w3">Sửa</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="4%"></HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn DataField="SoHieuTKNH" HeaderText="Số hiệu TKNH">
<ItemStyle Wrap="False"></ItemStyle>

<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TenTKNH" HeaderText="T&#234;n t&#224;i khoản NH">
<ItemStyle Wrap="False" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

<HeaderStyle Width="20%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TaiKhoanKT" HeaderText="T&#224;i khoản kế to&#225;n">
<HeaderStyle Width="8%"></HeaderStyle>
</asp:BoundColumn>
</Columns>
</asp:datagrid>&nbsp;												
								    </TD>
							    </TR>
							    
						    </TABLE>
					    </TD>
				    </TR>
            </table>
         </td>
        </tr>       
	    
      </table>
   </form>  
   </body> 
   </div>      
