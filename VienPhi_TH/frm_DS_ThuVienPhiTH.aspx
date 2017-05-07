<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_DS_ThuVienPhiTH.aspx.cs" Inherits="frm_DS_ThuVienPhiTH" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/VienPhi_TH/uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<%@ Register Src="~/MaVach/txtMaVach.ascx" TagName="txtMaVach" TagPrefix="ucMV" %>

<!--#include file ="header.htm"-->
<script type="text/javascript">
	     var dp_cal;      
       window.onload = function () {
	            dp_cal  = new Epoch('epoch_popup','popup',document.getElementById('txtNgayBD'));
	            dp_cal1  = new Epoch('epoch_popup','popup',document.getElementById('txtNgayKT'));

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
<style>
     td,table,tr,p,div,span,font,input,select,textarea
    {
    	 font-family:Arial, Tahoma, Verdana;
    	 font-size:13px;
    	}
 .button{
    background:#3199C4 url('../images/ui-bg_gloss-wave_75_2191c0_500x100.png') repeat-x center; height:25px;
    cursor:pointer;
    font-size:12px;
    border:1px solid #EEEEEE;
    color:#FFFFFF;
    padding:2px 5px 2px 5px;
 /*  background-color:ButtonHighlight; border-top-width: 1px; border-right: 1px; border-left: 1px; border-bottom: 1px; */
 }
 .button2{
    background:#E15625 url('../images/ui-bg_gloss-wave_45_e14f1c_500x100.png') repeat-x center; height:25px;
    cursor:pointer;
    font-size:12px;
    border:1px solid #EEEEEE;
    color:#FFFFFF;
    padding:2px 5px 2px 5px;
 /*  background-color:ButtonHighlight; border-top-width: 1px; border-right: 1px; border-left: 1px; border-bottom: 1px; */
 }
 .main
  {
  	 background:#FFFFFF;
 	 width:350px;
 	 height:180px;
 	 z-index:1000;
 	  position:relative;
  	}
.Hien
 {
     display:block;
 	 position:fixed;     
 	 z-index:500;
 	 margin:auto;
 	 top:25%;
 	 left:20%;
    
 } 
 .Hien td
 {
 	 text-align:center;
 	}
 .An
 {
 	 position:absolute;
 	 display:none;
 } 
 
</style>
<script language="javascript">
function XacNhanHuyPhieu(giatri,tt,row)
{
    if(tt=="True") return ;
    var frm=document.getElementById("formxacnhan");
    var mp=document.getElementById("<%=txtsophieu.ClientID %>");
    document.getElementById("txtRow").value=row;
    if(tt=="")
    {
       frm.className="Hien";
       frm.style.width=window.screen.width+"px";
       frm.style.height="2000px";
       mp.value=giatri;
    }
    else
     if(tt=="2")
    {
        mp.value="";
        frm.className="An";
    }
}
function KiemTra()
{
    if(document.getElementById("<%=txtsophieu.ClientID %>").value=="")
    {
        alert("Phiếu hủy chưa được chọn");
        document.getElementById("<%=txtsophieu.ClientID %>").focus();
        return false;
    }
    else if(document.getElementById("<%=txtlydo.ClientID %>").value=="")
    {
        alert("Cho biết lý do cần xóa");
        document.getElementById("<%=txtlydo.ClientID %>").focus();
        return false;
    }
    else
    {
       return true;
    }
}
</script>
<form id="Form1" method="post" runat="server">
<table width="100%" class="An" id="formxacnhan" cellpadding="0" cellspacing="0">
<tr><td valign="top" align="left" style="height: 196px">
<div align="left" style="padding-left:50%">
<div class="main">
<div class="button" style="padding-top:5px;">XÁC NHẬN HỦY PHIẾU</div>
<div style="clear:both; padding:7px;" align="left">Mã phiếu: &nbsp;<asp:TextBox Width="120px" 
        ID="txtsophieu" runat="server" ValidationGroup="dongy"></asp:TextBox>
</div>
<div style="clear:both; padding:7px;" align="left">Lý do hủy: &nbsp;<asp:TextBox Width="200px" 
        ID="txtlydo" runat="server" ValidationGroup="dongy"></asp:TextBox>
 
 
</div>
<div style="clear:both" align="center"><asp:Button ID="btnDongY" runat="server" 
        Text="Đồng ý" CssClass="button" onclick="btnDongY_Click" 
        OnClientClick="return KiemTra()" 
        ValidationGroup="dongy" /> 
<input type="button" value="Bỏ qua" class="button2" onclick="XacNhanHuyPhieu('','2',0)" />
</div>
</div></div>

</td></tr>
</table>
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td>
            <asp:placeholder runat="server" id="PlaceHolder1"></asp:placeholder>
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "center" style ="background-color:#D4D0C8">
        <table cellspacing="1" cellpadding="1" width="98%" border="0" class = "khung">
	    <tr>
		    <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px; height: 332px;">
			    <table id="user" cellSpacing="0" cellPadding="0" width="100%" border="0">
				    <tr>
				        <td colspan = "2" align = "center" class="button">
					        
                                <strong>DANH SÁCH PHIẾU THU </strong>
                            
				        </td>
			        </tr>
				    <TR style="color: #000000">
					    <TD width="100%">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" style="height: 150px">
                                        <table>
                                            <tr>
                                                <td style="width: 30px; height: 27px;">
                                                    &nbsp;Ngày :</td>
                                                <td style="width: 148px; height: 27px;">
															    <asp:textbox id="txtNgayBD" runat="server" width="75px" onblur = "TestDatePhieu(this)"></asp:textbox>
															       
                                                                    <input id="Button1" style="width: 26px" type="button" value="..." 
                                                                    onclick="dp_cal.toggle()" class="button" /></td>
                                                 <td style="width: 100px; height: 27px;">
                                                    &nbsp;Mã phiếu</td>
                                                <td style="width: 100px; height: 27px;">
                                                    <asp:TextBox ID="txtMaPhieu" Runat="server"  Width="108px" tabIndex="0" ReadOnly="False"></asp:TextBox>
                                                </td>
                                                <td style="width: 100px; height: 27px;">
                                                    &nbsp;Mã BN</td>
                                                <td style="width: 100px; height: 27px;">
                                                    <asp:TextBox ID="txtMaBenhNhan" Runat="server" Width="128px" tabIndex="1" ReadOnly="False"></asp:TextBox>
                                                </td>
                                                <td style="width: 100px; height: 27px;">
                                                                    Tên BN :</td>
                                                <td style="width: 89px; height: 27px;">
                                                                    <asp:TextBox ID="txtTenBenhNhan" Runat="server" Width="180px" tabIndex="2"></asp:TextBox>
                                                </td>
                                                <td style="width: 100px; height: 27px;">
                                                    <asp:button id="btnLayDS" runat="server" text="Lấy danh sách" width="112px" 
                                                        OnClick="btnLayDS_Click" CssClass="button2" />
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:datagrid id="dgr" runat="server" allowsorting="True" autogeneratecolumns="False"
                                            bordercolor="Silver" borderwidth="1px" cellpadding="2"  
                                             onpageindexchanged="PageIndexStyleChanged"
                                            tabindex="12" width="100%" OnItemCommand="dgr_ItemCommand" DataKeyField="MaPhieu" OnItemDataBound="dgr_ItemDataBound">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>
<asp:BoundColumn DataField="STT" HeaderText="STT">
<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MAPHIEU" HeaderText="Số phiếu">
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; BN">
<HeaderStyle Width="12%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<HeaderStyle Width="20%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaysinh" HeaderText="Ng&#224;y sinh">
<HeaderStyle Width="7%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NOIDUNGTHU" HeaderText="Nội dung thu">
<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TONGTIEN" DataFormatString="{0:##,0}" HeaderText="Số tiền">
<HeaderStyle Width="7%"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="tennguoithu"   HeaderText="Người thu">
<HeaderStyle Width="7%"></HeaderStyle>
<ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>


<asp:BoundColumn DataField="Khoa"   HeaderText="Khoa">
<HeaderStyle Width="7%"></HeaderStyle>
<ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>


<asp:TemplateColumn HeaderText="Chức năng"><ItemTemplate>
<asp:Button id="inlai" runat="server" CssClass="button" Text="In lại" __designer:wfdid="w6" CommandArgument='<%#Eval("MAPHIEU") %>' CommandName="InLai">
</asp:Button> 
<input id="btAction" runat=server type=button  value='<%#Eval("HuyPhieu") %>' onclick=<%#"XacNhanHuyPhieu('"+Eval("MAPHIEU")+"','"+Eval("IsDaHuy")+"','"+Eval("STT")+"')"%> />
</ItemTemplate>

<HeaderStyle Width="14%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateColumn>

<asp:BoundColumn DataField="LyDoHuy" HeaderText="Lý do huỷ">
<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="TenNguoiHuy" HeaderText="Người huỷ">
<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" CssClass="button"></HeaderStyle>
</asp:datagrid>
                                        &nbsp;</TD>
							    </TR>
						    </TABLE>
						    
						    						   
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" colSpan="2" height="20">
                                        &nbsp;</TD>
							    </TR>
						    </TABLE>
					    </TD>
				    </TR>
				    <tr style="color: #000000">
	                    <td style ="width: 100%;">
	                        <div id  = "infospace" runat = "server"></div>
	                    </td>
	                     
	                </tr>	
			    </table>
		    </td>
	    </tr>				
    </table>
    <div style="display:none;position:fixed;top:35%;left:35%;background-color:White;z-index:1000;padding:10px 10px 10px 10px;border:10px solid #4D67A2" id="divlydo" runat="server">
        &nbsp;&nbsp;
  </div>  
  <input type = "hidden" id="txtRow" runat="server" tabindex="6" style="width: 37px  " />
 </form>
<!--#include file ="footer.htm"-->
