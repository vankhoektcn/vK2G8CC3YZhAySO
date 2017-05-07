<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhSachCongNoBenhNhan.aspx.cs"
    Inherits="CapCuu_DanhSachCongNoBenhNhan" %>

<!--#include file ="header.htm"-->

<script language="javascript" type="text/javascript">
    var dp_cal1; 
	window.onload = function () 
	{	    
	    dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtRaVienLuc'));	    
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
	function InPhieuSauThu(IdKhamBenh)
	{
	     if (confirm("Đã thu phí. Bạn có muốn in phiếu thu không ?"))
	     {
	        window.open("../ThuVienPhi/frpt_PhieuThuCapCuu.aspx?idKhamBenh="+IdKhamBenh+"",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	     }
	}
	function InPhieuThuCapCuu(idKhamBenh)
	{
	        window.open("../ThuVienPhi/frpt_PhieuThuCapCuu.aspx?idKhamBenh="+idKhamBenh+"",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	}
	function tamung(idchitietdangkykham,IsSua)
	{
	    var td = document.getElementById("popupTamUng");
            createTipTU(td,"tipbenhnhan","Tamung","Xét tạm ứng","ajaxbenhnhanexists"," đang load ...","Lỗi trong quá trình load","../CapCuu/ajax.aspx?do=tamUng&idbn="+idchitietdangkykham+"&IsSua="+IsSua +"", "650", "130"); 
	}
	function luuTU(iddangkykham)
	{
	var sotien = document.getElementById("txtSoTien").value;
	var QuyenSo = 0;//document.getElementById("txtQuyenSo").value; //Khoe
	var SoCT = 0;//document.getElementById("txtSoCT").value; 
	var LyDoTU = document.getElementById("txtLyDo").value; 
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
	             if(value != "" && value != "0")
                {
                    document.getElementById("hdIdTamUng").value=value;
                    hideTip("tipbenhnhan");
                    InPhieuTamUngSauLuu();
                }
                  else{
                   if(value=="")
                        alert("Lưu thông tin thất bại!");
                    else
                        alert(value);
                }
            }
        }
        xmlHttp.open("GET","../CapCuu/ajax.aspx?do=luuTU&idkhoa="+queryString('idkhoa')+"&iddangkykham=" + iddangkykham + "&SoDangKy=&quyenso="+ QuyenSo+"&SoCT="+SoCT +"&sotien=" + sotien + "&lydoTU="+encodeURIComponent(LyDoTU)+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
function InPhieuTamUngSauLuu()
   {
   if (confirm("Đã Lưu tạm ứng. Bạn có muốn in phiếu báo tạm ứng không ?"))
	     {
	        var hdIdTamUng=document.getElementById("hdIdTamUng").value;
	        if(hdIdTamUng=="" || hdIdTamUng=="0")
	            {alert("Chưa lưu tạm ứng !"); return; }	    
            window.open("frmPhieuBaoThuTamUng.aspx?dkMenu=capcuu&hdIdTamUng="+hdIdTamUng+"");        
        }
   }
</script>

<form id="Form1"  method="post" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: #C0C0C0">
        <tr>
            <td width="100%" align="left" style="background-color:#D4D0C8; height: 10px;">
                <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
            </td>
        </tr>
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px">
                            <table id="user" cellspacing="1" cellpadding="1" width="100%" border="0" class="khung">
                                <tr>
                                    <td class="title" align="center" style="background-color: #4D67A2; height: 21px;">
                                        <span class="title" style="color: #FFFFFF"><strong>THANH TOÁN VIỆN PHÍ</strong></span></td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="center" width="100%" style="height: 64px">
                                                    <table cellspacing="0" cellpadding="0" width="98%" border="0" style="height: 14px">
                                                        <tr style="padding-bottom: 5px; padding-top: 10px">
                                                            <td id="popupTamUng" align="left" width="100%" style="height: 100px">
                                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 1236px">
                                                                    <tr>
                                                                        <td style="padding-top: 2px; padding-left: 20px; height: 26px; width: 140px;" align="left">
                                                                            Mã bệnh nhân
                                                                        </td>
                                                                        <td style="padding-top: 2px; height: 26px;" align="left">
                                                                            <span class="ptext">
                                                                                <asp:textbox id="txtMaBenhNhan" runat="server" width="178px" tabindex="4"></asp:textbox>
                                                                                &nbsp; &nbsp;
                                                                                &nbsp; &nbsp;Tên bệnh nhân &nbsp; &nbsp;&nbsp;
                                                                                <asp:textbox id="txtTenBenhNhan" runat="server" width="178px" tabindex="4"></asp:textbox>&nbsp; Ngày thanh toán
                                                                                <asp:textbox id="txtRaVienLuc" runat="server" tabindex="9" width="123px"></asp:textbox><INPUT style="WIDTH: 25px" id="Button4" onclick="dp_cal1.toggle()" type=button value="..." />
                                                                                <asp:imagebutton id="ImageButton1" runat="server" imageurl="../images/tim.png" tabindex="10"
                                                                                onclick="ImageButton1_Click"></asp:imagebutton><asp:imagebutton id="btnCancel" tabindex="11" onclick="btnCancel_Click" runat="server"
                                                                                imageurl="../images/MOI.gif"></asp:imagebutton></span></td>
                                                                    </tr>
                                                                    <!--
                                                                    <tr>
                                                                        <td style="padding-top: 2px; width: 15%; padding-left: 20px; height: 26px;" align="left">
                                                                            <span class="ptext">Loại BHYT</span>&nbsp;</td>
                                                                        <td style="padding-top: 2px; width: 85%; height: 26px;" align="left">
                                                                            <span class="ptext">
                                                                                <asp:dropdownlist id="ddlLoaiBHYT" runat="server"><asp:ListItem Value="2">Chọn loại BHYT</asp:ListItem>
                                                                                <asp:ListItem Value="0">Dịch vụ</asp:ListItem>
                                                                                <asp:ListItem Value="1">C&#243; BH</asp:ListItem>
                                                                                </asp:dropdownlist>
                                                                            </span>
                                                                        </td>
                                                                    </tr>
                                                                    -->
                                                                </table>
                                                                &nbsp;
                                                    <asp:datagrid id="dgr" tabindex="12" runat="server" width="100%" allowsorting="True"
                                                        autogeneratecolumns="False" datakeyfield="idkhambenh" borderwidth="1px" bordercolor="#3366CC"
                                                        cellpadding="4" OnItemDataBound="dgr_ItemDataBound" onitemcommand="dgr_ItemCommand" BackColor="White" BorderStyle="None">
<FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

<SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedItemStyle>

<PagerStyle Mode="NumericPages" HorizontalAlign="Left" BackColor="#99CCCC" Font-Names="Arial" Font-Size="Small" ForeColor="#003399"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" BackColor="White" CssClass="dgrNoSelectItem" ForeColor="#003399"></ItemStyle>
<Columns>
<%--<asp:ButtonColumn CommandName="ViewTTBN" Commandargument='<%# Eval("idbenhnhan") %>' Text="In Mẫu 01">
<HeaderStyle Wrap="False" Width="9%"></HeaderStyle>
</asp:ButtonColumn>--%>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lnbtnInMau01" Text="Chi phí" runat="server"  CommandName="ViewTTBN" CommandArgument='<%# Eval("idbenhnhan") %>'></asp:LinkButton> 
</ItemTemplate>
<HeaderStyle Width="7%"></HeaderStyle>
</asp:TemplateColumn>
<%--<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnEdit" runat="server" Width="55px" CssClass="alink3" CommandName="InPhieuThu"></asp:LinkButton> 
</ItemTemplate>
<HeaderStyle Width="7%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lnbtnStatus" Text='<%#Eval("status") %>' runat="server"  CssClass="alink3" CommandName="ThuTien" CommandArgument='<%# Eval("iddangkykham") %>'></asp:LinkButton> 
</ItemTemplate>
<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>--%>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lnbtnStatus" Text='<%#Eval("status") %>' runat="server"  CssClass="alink3" CommandName="Status" CommandArgument='<%# Eval("idchitietdangkykham") %>'></asp:LinkButton> 
</ItemTemplate>
<HeaderStyle Width="7%"></HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn DataField="ngaykham" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ng&#224;y t&#237;nh BHYT">
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="9%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="9%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaysinh" HeaderText="Ng&#224;y sinh"></asp:BoundColumn>
<asp:BoundColumn DataField="GIOITINH" HeaderText="Giới t&#237;nh"></asp:BoundColumn>
<asp:BoundColumn DataField="sobhyt" HeaderText="Số BHYT"></asp:BoundColumn>
<asp:BoundColumn DataField="DungTuyen" HeaderText="Đ&#250;ng / tr&#225;i truyến"></asp:BoundColumn>
<asp:BoundColumn DataField="TongSoTien"  DataFormatString="{0:N0}"  HeaderText="Tổng số tiền"></asp:BoundColumn>
<asp:BoundColumn DataField="SoTienTamUng" DataFormatString="{0:N0}"  HeaderText="Số tiền tạm ứng"></asp:BoundColumn>
<asp:BoundColumn DataField="SoTienDaDong" DataFormatString="{0:N0}"  HeaderText="Số tiền đ&#227; đ&#243;ng"></asp:BoundColumn>
<asp:BoundColumn DataField="SoTienBNPhaiTra" DataFormatString="{0:N0}"  HeaderText="Số tiền BN phải trả"></asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" BackColor="#003399" CssClass="dgrHeader" Font-Bold="True" ForeColor="#CCCCFF"></HeaderStyle>
</asp:datagrid></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="left" width="100%" colspan="2" style="height: 20px">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <input type="hidden" value="0" name="hdIdTamUng" id="hdIdTamUng"/> <%--Khoe--%>   
            </td>
        </tr>
    </table>
</form>
