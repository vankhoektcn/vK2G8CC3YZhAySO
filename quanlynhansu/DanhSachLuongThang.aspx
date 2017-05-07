<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhSachLuongThang.aspx.cs"
    Inherits="DanhSachLuongThang" %>

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
<TABLE style="BACKGROUND-COLOR: #c0c0c0" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="HEIGHT: 19px; BACKGROUND-COLOR: #fbf8f1" align=left width="100%"><uc1:uscmenu id="Uscmenu1" runat="server"></uc1:uscmenu> </TD></TR><TR><TD style="BACKGROUND-COLOR: #d4d0c8" align=left width="100%">&nbsp; </TD></TR><TR><TD style="BACKGROUND-COLOR: #d4d0c8" align=left width="100%"><TABLE id="user" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD style="HEIGHT: 26px" class="header" width="100%">&nbsp;BẢNG LƯƠNG NHÂN VIÊN </TD></TR><TR><TD vAlign=top width="100%"><TABLE cellPadding=0 width="100%" border=0><TBODY><TR><TD style="HEIGHT: 175px" vAlign=top align=center width="100%"><TABLE cellSpacing=0 cellPadding=0 width="98%" border=0><TBODY><TR style="PADDING-BOTTOM: 5px; PADDING-TOP: 10px"><TD style="HEIGHT: 18px" align=left width="100%"><TABLE style="HEIGHT: 17px" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="HEIGHT: 122px" colSpan=2><TABLE style="BORDER-RIGHT: 3px; BORDER-TOP: 3px; PADDING-LEFT: 0px; BORDER-LEFT: 3px; BORDER-BOTTOM: 3px" cellSpacing=0 cellPadding=0 rules=groups width=700 bgColor=#b3b8e8 border=3>

<TBODY><TR><TD style="HEIGHT: 10px" colSpan=4></TD></TR><TR><TD style="PADDING-LEFT: 10px; WIDTH: 13%; HEIGHT: 41px" vAlign=top align=left><P class="ptext">Phòng&nbsp; </P></TD><TD style="PADDING-RIGHT: 0px; WIDTH: 25%; HEIGHT: 41px" vAlign=top align=left><P class="ptext"><asp:dropdownlist id="ddlPhongBan" tabIndex=1 runat="server" CssClass="input" width="100%" OnSelectedIndexChanged="ddlPhongBan_SelectedIndexChanged" AutoPostBack="True">
                                                                                 </asp:dropdownlist> &nbsp; </P></TD><TD style="PADDING-RIGHT: 2px; WIDTH: 12%; HEIGHT: 41px" vAlign=top align=right><P class="ptext">Nhân viên : </P></TD><TD style="PADDING-RIGHT: 0px; WIDTH: 40%; HEIGHT: 41px" vAlign=top align=left><P class="ptext"><asp:dropdownlist id="ddlNhanVien" tabIndex=1 runat="server" CssClass="input" width="63%">
                                                                                 </asp:dropdownlist> &nbsp;&nbsp;&nbsp; </P></TD></TR><TR><TD style="PADDING-LEFT: 10px; WIDTH: 13%; HEIGHT: 41px" vAlign=top align=left><P class="ptext">Tháng&nbsp;:</P></TD><TD style="PADDING-RIGHT: 0px; WIDTH: 25%; HEIGHT: 41px" vAlign=top align=left><P class="ptext"><asp:dropdownlist id="ddlThang" tabIndex=7 runat="server" width="23%">
 <asp:ListItem Value="1">1</asp:ListItem>
<asp:ListItem Value="2">2</asp:ListItem>
<asp:ListItem Value="3">3</asp:ListItem>
<asp:ListItem Value="4">4</asp:ListItem>
<asp:ListItem Value="5">5</asp:ListItem>
<asp:ListItem Value="6">6</asp:ListItem>
<asp:ListItem Value="7">7</asp:ListItem>
<asp:ListItem Value="8">8</asp:ListItem>
<asp:ListItem Value="9">9</asp:ListItem>
<asp:ListItem Value="10">10</asp:ListItem>
<asp:ListItem Value="11">11</asp:ListItem>
<asp:ListItem Value="12">12</asp:ListItem>
</asp:dropdownlist> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Năm&nbsp;
 <asp:dropdownlist id="ddlNam" tabIndex=7 runat="server" width="35%" __designer:wfdid="w1"></asp:dropdownlist> </P></TD><TD style="PADDING-RIGHT: 2px; WIDTH: 12%; HEIGHT: 41px" vAlign=top align=right><P class="ptext"></P></TD><TD style="PADDING-RIGHT: 0px; WIDTH: 40%; HEIGHT: 41px" vAlign=top align=left><P class="ptext">
&nbsp;&nbsp; &nbsp; &nbsp;&nbsp; <asp:button id="btnGetDanhSach" onclick="btnGetDanhSach_Click" runat="server" CssClass="input" width="102px" text="Lấy danh sách"></asp:button>&nbsp; </P></TD></TR></TBODY>
 
 </TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><TABLE cellPadding=0 width="100%" border=0><TBODY><TR><TD width="100%"><TABLE class="khung" cellSpacing=1 cellPadding=1 width="100%" border=1><TBODY><TR><TD class="ptext" align=left width="100%"><DIV style="PADDING-LEFT: 10px; OVERFLOW: auto" id="idthang" runat="server"><B>DANH SÁCH BẢNG LƯƠNG NHÂN VIÊN &nbsp;&nbsp; <asp:Label id="lbThangNam" runat="server" Text=""></asp:Label></B> </DIV></TD></TR><TR><TD class="ptext" vAlign=top align=left width="100%"><DIV id="chitietchamcong" runat="server"><%--khoe--%>
 <asp:DataGrid id="dgr" tabIndex=12 runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False" DataKeyField="idnhanvien" BorderWidth="1px" BorderColor="#3366CC" OnItemDataBound="dgr_ItemDataBound" OnEditCommand="Edit" CellPadding="4" BackColor="White" BorderStyle="None">
<FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

<SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedItemStyle>

<PagerStyle Mode="NumericPages" HorizontalAlign="Left" BackColor="#99CCCC" Font-Names="Arial" Font-Size="Small" ForeColor="#003399"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" BackColor="White" CssClass="dgrNoSelectItem" ForeColor="#003399"></ItemStyle>

<Columns>
<asp:BoundColumn DataField="STT" HeaderText="STT"  >
<HeaderStyle Wrap="False" Width="2%"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="idnhanvien" HeaderText="idnhanvien" Visible="False"></asp:BoundColumn>

<asp:BoundColumn DataField="manhanvien"  HeaderText="Mã NV">
                                                <HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="tennhanvien"  HeaderText="Tên Nhân Viên">
                                                <HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="left"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenphongban"  HeaderText="Phòng">
                                                <HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="left"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="chucvu"  HeaderText="Chức vụ">
                                                <HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="left"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="LuongCBGio"  HeaderText="Lương CB/Giờ">
                                                <HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="luongmotgioham" DataFormatString="{0:0,000.00}" HeaderText="Lương một giờ">
                                                <HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="SoNgayNghi"  HeaderText="Số ngày nghỉ">
                                                <HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="sogiolamca"  HeaderText="Tổng giờ ca">
                                                <HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="TongLuongTheoCaham" DataFormatString="{0:0,000}" HeaderText="Tổng lương theo ca">
                                                <HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="sogiolamtangca"  HeaderText="Tổng giờ tăng ca">
                                                <HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="TongLuongTangCa" DataFormatString="{0:0,000}" HeaderText="Tổng lương tăng ca">
                                                <HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TienBHXH" DataFormatString="{0:0,000}" HeaderText="BHXH">
                                                <HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="TienBHYT" DataFormatString="{0:0,000}" HeaderText="BHYT">
                                                <HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="ThueTNCN" DataFormatString="{0:0,000}" HeaderText="Thuế TNCN">
                                                <HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="TienPhuCapTrachNhiem" DataFormatString="{0:0,000}" HeaderText="Phụ cấp TN">
                                                <HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="TienPhuCapCongViec" DataFormatString="{0:0,000}" HeaderText="Phụ cấp CV">
                                                <HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="TienThuong" DataFormatString="{0:0,000}" HeaderText="Tổng thưởng">
                                                <HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="TienPhat" DataFormatString="{0:0,000}" HeaderText="Tổng phạt">
                                                <HeaderStyle Wrap="False" Width="3%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="ThucNhan" DataFormatString="{0:0,000}" HeaderText="Thực nhận">
                                                <HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="idnhanvien" HeaderText="idnhanvien" Visible="False"></asp:BoundColumn>

<asp:TemplateColumn HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnEdit" CommandName="Edit" runat="server" CssClass="alink3">Chi tiết</asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Width="4%"></HeaderStyle>
                                            </asp:TemplateColumn>


</Columns>

<HeaderStyle HorizontalAlign="Center" BackColor="#003399" CssClass="dgrHeader" Font-Bold="True" ForeColor="#CCCCFF"></HeaderStyle>
</asp:DataGrid> <%--khoe--%></DIV></TD></TR></TBODY></TABLE></TD></TR><TR><TD width="100%"><DIV id="showchitiet" runat="server"></DIV>
<INPUT id="txtThangHidden" type=hidden name="txtThangHidden" runat="server" /> 
<INPUT id="txtNamHidden" type=hidden name="txtNamHidden" runat="server" /> </TD></TR><TR><TD style="PADDING-TOP: 7px; HEIGHT: 31px" align=center width="100%"><SPAN style="DISPLAY: none" id="showstatus" class="ptext" runat="server"><IMG src="images/processing.gif" align=left />&nbsp;Đang lưu thông tin chấm công, vui lòng đợi trong giây lát ...</SPAN> &nbsp;<%--<input type="button" style="background-color: WHITE;
                                                width: 100px" value="CẬP NHẬT" onclick="ChamCong()" id="btluuchamcong" />--%> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:updatepanel>
<div style="padding-left: 20px;" align="left">
<asp:Button id="btnExcel" runat="server" visible="true" Text="Xuất Excel" OnClick="btnExcel_Click"></asp:Button> 
</div>
</form>
<!--#include file = "footer.htm" -->
