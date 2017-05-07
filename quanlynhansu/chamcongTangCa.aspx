<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chamcongTangCa.aspx.cs" Inherits="chamcongTangCa" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file = "header.htm" -->

<script language="javascript" type="text/javascript">
    var dp_cal, dp_cal1;      
	window.onload = function () 
	{
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtNgay'));
	};
	function TestdateClient(t)
	{
		if (t.value != "")
		{
			t.value=AddString(t.value);
			if (isDate(t.value)==false)
				{
					alert("Bạn nhập ngày tháng không hợp lệ ! ");
					t.focus();
				}
		}
		else
		{
		    alert("Bạn chưa nhập ngày tháng. Vui lòng kiểm tra lại! ");
			t.focus();
		}
		return;
	}  
	function TestNum(objname)
	{
		var obj = document.getElementById(objname);
		if (obj.value!="")
		{				
			if (CheckNumberFloat(obj.value)==false)
			{
				obj.value="0";
				alert("Bạn phải nhập giá trị số! ");
				obj.focus();
				
			}
		}
	}	
	
	function ChamCong()
	{
	    var othang = document.getElementById("ddlthang");
	    if (othang.value == "0")
	    {
	        alert("Bạn chưa chọn tháng làm việc. Vui lòng kiểm tra lại");
	        othang.focus();
	        return false;
	    }
	    var onam = document.getElementById("ddlnam");
	    if (onam.value == "0")
	    {
	        alert("Bạn chưa chọn năm làm việc. Vui lòng kiểm tra lại");
	        onam.focus();
	        return false;
	    }
	    var olistnv = document.getElementById("listidnhanvien");
	    var ongaytrongthang = document.getElementById("idngay");
	    var arrnv = olistnv.value.split(',');
	    var snoidung = "";
	    	    
	    var ost = document.getElementById("showstatus");
	    ost.style.display = '';
	    var obt = document.getElementById("btluuchamcong");
	    obt.style.display = "none";
	    
	    for(var i = 0; i < arrnv.length; i++)
	    {
	        for (var j = 1; j <= eval(ongaytrongthang.value); j++)
	        {
	            var ngaythang = onam.value+"/"+othang.value+"/"+j;
	            var ogiolam = document.getElementById("ngaycong_"+arrnv[i]+"_"+j+othang.value+onam.value);
	            var ogiotangca = document.getElementById("giotangca_"+arrnv[i]+"_"+j+othang.value+onam.value);        
	            snoidung = snoidung + arrnv[i] + "^" + ogiolam.value + "^" + ogiotangca.value + "^" + ngaythang + "@";
	        }	        	        
	    }
	    //alert(snoidung);
	    
	    LuuBangChamCong(othang.value, onam.value, snoidung);
	}
	 
	function LuuBangChamCong(thang, nam, snoidungchamcong)
	{
	    xmlHttp = GetMSXmlHttp();
	    xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var ost = document.getElementById("showstatus");
	            ost.style.display = 'none';
                if(eval(value) == 0)
                {
                    alert("Lỗi xảy ra trong quá trình lưu bàng chấm công . Vui lòng xem lại ");
                    return false;
                }
                else if(value == 1)
                {
                    alert("Đã lưu bảng chấm công thành công.");
                    document.location.href = "chamcongentry.aspx";
                    return true;
               }
            }
        }
        xmlHttp.open("POST", "ajax.aspx", true);
        xmlHttp.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
        xmlHttp.send("do=luubangchamcong&thang=" + thang + "&nam=" + nam + "&noidungchamcong=" + snoidungchamcong + "&times="+Math.random());

	}
</script>

<form id="Form1" method="post" runat="server">
    <asp:scriptmanager id="Script1" runat="server"></asp:scriptmanager>
    <asp:updatepanel id="update1" runat="server"><ContentTemplate>
<table style="BACKGROUND-COLOR: #c0c0c0" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><tr><td style="HEIGHT: 19px; BACKGROUND-COLOR: #fbf8f1" align=left width="100%"><uc1:uscmenu id="Uscmenu1" runat="server"></uc1:uscmenu> </td></tr><tr><td style="BACKGROUND-COLOR: #d4d0c8" align=left width="100%">&nbsp;</td></tr><tr><td style="BACKGROUND-COLOR: #d4d0c8" align=left width="100%"><table id="user" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><tr><td style="HEIGHT: 26px" class="header" width="100%">&nbsp;BẢNG CHẤM CÔNG TĂNG CA<INPUT id="listidnhanvien" type=hidden runat="server" /><INPUT id="idngay" type=hidden runat="server" /></td></tr><tr><td vAlign=top width="100%"><table cellPadding=0 width="100%" border=0><TBODY><tr><td style="HEIGHT: 175px" vAlign=top align=center width="100%"><table cellSpacing=0 cellPadding=0 width="98%" border=0><TBODY><TR style="PADDING-BOTTOM: 5px; PADDING-TOP: 10px"><td style="HEIGHT: 18px" align=left width="100%"><table style="HEIGHT: 17px" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><tr><td style="HEIGHT: 122px" colSpan=2><table style="BORDER-RIGHT: 3px; BORDER-TOP: 3px; PADDING-LEFT: 0px; BORDER-LEFT: 3px; BORDER-BOTTOM: 3px" cellSpacing=0 cellPadding=0 rules=none width=700><%--<tr>
                                                                                    <td valign="top" nowrap align="right" style="height: 23px; padding-left: 10px; width: 110px;">
                                                                                        <p class="ptext">
                                                                                            Mã loại tăng ca :&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="left" width="430" style="width: 430px; height: 23px;" colspan="3">
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txtmachucvu" runat="server" width="248px" tabindex="2" height="19px"></asp:textbox>
                                                                                        </p>
                                                                                    </td>
                                                                                </tr>--%><TBODY><tr><td style="HEIGHT: 10px" colSpan=4></td></tr><tr><td style="PADDING-LEFT: 10px; WIDTH: 13%; HEIGHT: 41px" vAlign=top align=left><P class="ptext">Phòng&nbsp; </P></td><td style="PADDING-RIGHT: 0px; WIDTH: 25%; HEIGHT: 41px" vAlign=top align=left><P class="ptext"><%--<asp:textbox id="txtMaLoaiNgayNghi" runat="server" width="248px" tabindex="4"></asp:textbox>--%><asp:dropdownlist id="ddlPhongBan" tabIndex=1 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPhongBan_SelectedIndexChanged" width="100%" CssClass="input"></asp:dropdownlist> &nbsp;</P></td><td style="PADDING-RIGHT: 2px; WIDTH: 12%; HEIGHT: 41px" vAlign=top align=right><P class="ptext">Loại tăng ca : </P></td><td style="PADDING-RIGHT: 0px; WIDTH: 40%; HEIGHT: 41px" vAlign=top align=left><P class="ptext"><asp:dropdownlist id="ddlCaLamViec" tabIndex=1 runat="server" width="63%" CssClass="input"></asp:dropdownlist> &nbsp;&nbsp;&nbsp; </P></td></tr><tr><td style="PADDING-LEFT: 10px; WIDTH: 13%; HEIGHT: 41px" vAlign=top align=left><P class="ptext">Nhân viên :</P></td><td style="PADDING-RIGHT: 0px; WIDTH: 25%; HEIGHT: 41px" vAlign=top align=left><P class="ptext"><%--<asp:textbox id="txtMaLoaiNgayNghi" runat="server" width="248px" tabindex="4"></asp:textbox>--%><asp:dropdownlist id="ddlNhanVien" tabIndex=1 runat="server" width="100%" CssClass="input"></asp:dropdownlist> &nbsp;</P></td><td style="PADDING-RIGHT: 2px; WIDTH: 12%; HEIGHT: 41px" vAlign=top align=right><P class="ptext">Ngày: </P></td><td style="PADDING-RIGHT: 0px; WIDTH: 40%; HEIGHT: 41px" vAlign=top align=left><P class="ptext"><asp:textbox id="txtNgay" tabIndex=5 runat="server" width="38%" CssClass="input"></asp:textbox> <INPUT id="Button2" onclick="dp_cal.toggle()" type=button value="..." />&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;<asp:button id="btnGetDanhSach" onclick="btnGetDanhSach_Click" runat="server" width="102px" CssClass="input" text="Lấy danh sách"></asp:button>&nbsp;</P></td></tr><%--<tr height="auto">
                                                                        <td colspan="4" style="height: auto" id="showtipNhanVien">
                                                                    </tr>--%></TBODY></TABLE></td></tr></TBODY></TABLE></td></tr></TBODY></TABLE></td></tr></TBODY></TABLE><table cellPadding=0 width="100%" border=0><TBODY><tr><td width="100%"><table class="khung" cellSpacing=1 cellPadding=1 width="100%" border=1><TBODY><tr><td class="ptext" align=center width="100%"><B><div style="OVERFLOW: auto" id="idthang" runat="server">THÔNG TIN CHẤM CÔNG TĂNG CA</div></b></td></tr><tr><td class="ptext" vAlign=top align=left width="100%"><div id="chitietchamcong" runat="server"><%--khoe--%><asp:DataGrid id="dgr" tabIndex=12 runat="server" BorderStyle="None" BackColor="White" CellPadding="4" OnItemDataBound="dgr_ItemDataBound" BorderColor="#3366CC" BorderWidth="1px" DataKeyField="idnhanvien" AutoGenerateColumns="False" AllowSorting="True" Width="100%">
<FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

<SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedItemStyle>

<PagerStyle Mode="NumericPages" HorizontalAlign="Left" BackColor="#99CCCC" Font-Names="Arial" Font-Size="Small" ForeColor="#003399"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" BackColor="White" CssClass="dgrNoSelectItem" ForeColor="#003399"></ItemStyle>
<Columns>
<asp:BoundColumn DataField="STT" HeaderText="STT"></asp:BoundColumn>
<%--<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtDelete" runat="server" CssClass="alink3" CommandName="Delete">Xoá</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="8%"></HeaderStyle>
</asp:TemplateColumn>--%>
<asp:BoundColumn DataField="idnhanvien" HeaderText="idnhanvien" Visible="False"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="Mã Nhân Viên"><ItemTemplate>
        <asp:TextBox ID="tbsttindm05" readonly="true" runat="server" Text='<%#Bind("manhanvien") %>' Visible="true" BorderWidth="0"></asp:TextBox>
    
</ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Tên Nhân Viên"><ItemTemplate>
        <asp:TextBox BorderWidth="0" readonly="true" ID="tbtennhanvien" runat="server" Text='<%#Bind("tennhanvien") %>' Visible="true"></asp:TextBox>
    
</ItemTemplate>

<HeaderStyle Width="15%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Phòng"><ItemTemplate>
        <asp:TextBox BorderWidth="0" readonly="true" ID="tbcongthuc" runat="server" Text='<%#Bind("tenphongban") %>' Visible="true"></asp:TextBox>
    
</ItemTemplate>

<HeaderStyle Wrap="False" Width="15%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Ca làm việc"><ItemTemplate>
        <asp:TextBox BorderWidth="0" readonly="true" ID="tbgiabanhientai" runat="server" Text='<%#bind("tenloaitangca") %>'></asp:TextBox>
    
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Giờ vào"><ItemTemplate>
        <%--<asp:DropDownList ID="droptendvt" runat="server" Visible="true" AutoPostBack="false">
        </asp:DropDownList>--%>
        <asp:TextBox BorderWidth="1" ID="txtTuGio" width="50px" runat="server" Text='<%#bind("tugio") %>'></asp:TextBox>
    
</ItemTemplate>

<FooterStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></FooterStyle>

<HeaderStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Width="6%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Giờ ra"><ItemTemplate>
       <%-- <asp:DropDownList ID="dropduongdung"  runat="server">
        </asp:DropDownList>--%>
        <asp:TextBox BorderWidth="1" ID="txtDenGio" width="50px" runat="server" Text='<%#bind("dengio") %>'></asp:TextBox>
    
</ItemTemplate>

<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Nghỉ ?"><ItemTemplate>
       <%-- <asp:DropDownList ID="dropduongdung"  runat="server">
        </asp:DropDownList>--%>
       <asp:CheckBox id="checkNghi" runat="server"></asp:CheckBox>
    
</ItemTemplate>

<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn DataField="idtangca" HeaderText="idtangca" Visible="False"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="" visible="false"><ItemTemplate>
        <asp:DropDownList ID="droptennhom" runat="server" Visible="true">
        </asp:DropDownList>
    
</ItemTemplate>

<HeaderStyle Wrap="False" Width="20%"></HeaderStyle>
</asp:TemplateColumn>


</Columns>

<HeaderStyle HorizontalAlign="Center" BackColor="#003399" CssClass="dgrHeader" Font-Bold="True" ForeColor="#CCCCFF"></HeaderStyle>
</asp:DataGrid> <%--khoe--%></div></td></tr></TBODY></TABLE></td></tr><tr><td width="100%"><div id="showchitiet" runat="server"></div></td></tr><tr><td style="PADDING-TOP: 7px; HEIGHT: 31px" align=center width="100%"><SPAN style="DISPLAY: none" id="showstatus" class="ptext" runat="server"><IMG src="images/processing.gif" align=left />&nbsp;Đang lưu thông tin chấm công, vui lòng đợi trong giây lát ...</SPAN>&nbsp;<%--<input type="button" style="background-color: WHITE;
                                                width: 100px" value="CẬP NHẬT" onclick="ChamCong()" id="btluuchamcong" />--%> <asp:Button id="btnLuuChamCong" onclick="btnLuuChamCong_Click" runat="server" Text="Lưu chấm công" Visible="False"></asp:Button> </td></tr></TBODY></TABLE></td></tr></TBODY></TABLE></td></tr></TBODY></TABLE>
</ContentTemplate>
</asp:updatepanel>
</form>
<!--#include file = "footer.htm" -->
