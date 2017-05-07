<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NVK_dsChoTaiKham.aspx.cs"
    Inherits="NVK_dsChoTaiKham" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!--#include file ="header.htm"-->

<script language="javascript">
     
    var dp_cal1; 
      var dp_cal; 
      
	window.onload = function () 
	{
//	  dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));
//	    dp_cal= new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
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
	function LoadChanDoanICD10(obj, Curdong)
	{
	    var typeSearch;
           if(obj.split("_")[0] != "txtchandoan")
           {
                typeSearch = "Mã ICD";
           }
           else{
                typeSearch = "Mô tả";
           }
	     $("#"+obj).unautocomplete().autocomplete("../CapCuu/ajax.aspx?do=getallchandoan&typeSearch="+encodeURIComponent(typeSearch),
        {formatItem: function(data) {
                return data[0];
            },width:700,scroll: true}
        )
        
        .result(function(event, data){
               setChonChanDoan(data[1],data[2],data[3]);
               $("#"+obj).val("");
              $("#"+obj).blur(); 
               document.getElementById(obj).focus();
        });
	}
	function setChonChanDoan(idchandoan, machandoan, tenchandoan)
	{
	    var Curdong = document.getElementById('chandoanicd10_1').rows.length;
	    document.getElementById("chandoanicd10_1").style.display ='';
	    	    for(var i=0;i<Curdong;i++)
	    	    {
	    	    try{
	    	        if(idchandoan == document.getElementById('chandoanicd10_1').rows[i].cells[1].getElementsByTagName("input")[0].value)
	    	        {
	    	            return;
	    	        }
	    	        }catch(ex){}
	    	    }
	    $("#chandoanicd10_1").append("<tr bgcolor='yellow'><td style=\"cursor:pointer\" onclick=\"javascript:document.getElementById('chandoanicd10_1').deleteRow(this.parentNode.rowIndex);\">X</td><td><input type='hidden'  id='idchandoanicd10_"+Curdong+"' value='"+idchandoan+"' />"+machandoan+"</td><td>"+tenchandoan+"</td></tr>");
	    document.getElementById('txtIdChanDoan_3').value=document.getElementById('txtIdChanDoan_3').value+ ','+idchandoan;
	    //alert(document.getElementById('txtIdChanDoan_3').value);
	    
	}
	function HuyClick()
	{
	    //alert(document.getElementById('txtIdChanDoan_3').value);
	    document.getElementById('txtIdChanDoan_3').value="0";
	    var otable=document.getElementById("<%= chandoanicd10_1.ClientID %>")
	    while (otable.firstChild) 
            { 
            otable.removeChild(otable.firstChild); 
            }
	    //.innerHTML="<tr bgcolor=\"#0066ff\" style=\"font-weight: bolder; color: White\"><td></td><td>Mã ICD</td><td>Mô tả</td></tr>";
	}
	
	function TimBacSi()
 {     
	    $("#txtTenBacSi").unautocomplete().autocomplete("../nhanbenh/ajax.aspx?do=TimBacSiNhapKhoa&idkhoa="+queryString("idkhoa")+"&idphongban="+queryString("idphongban")+"",
        {formatItem: function(data) {
                return data[0];
            },width:700,scroll: true}
        )        
        .result(function(event, data){
               document.getElementById("txtTenBacSi").value =data[1] ;
               document.getElementById("hdIdBacSi").value = data[2];
        });
 }
 function TimDieuDuong()
 {     
	    $("#txtTenDieuDuong").unautocomplete().autocomplete("../nhanbenh/ajax.aspx?do=TimDieuDuongNhapKhoa&idkhoa="+queryString("idkhoa")+"&idphongban="+queryString("idphongban")+"",
        {formatItem: function(data) {
                return data[0];
            },width:700,scroll: true}
        )        
        .result(function(event, data){
               document.getElementById("txtTenDieuDuong").value =data[1] ;
               document.getElementById("hdIdDieuDuong").value = data[2];
        });
 }
 function idbacsisearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/nvk_commonFuntion_ajax.aspx?do=idbacsisearch",{
             minChars:0,
             width:550,
             scroll:true,
             header:"Danh sách bác sĩ",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                    $("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
  function iddieuduongsearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=iddieuduongNhapKhoasearch",{
             minChars:0,
             width:550,
             scroll:true,
             header:"Danh sách điều dưỡng",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                    $("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
</script>

<form id="Form1" method="post" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: #C0C0C0">
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8; height: 10px;">
                <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
            </td>
        </tr>
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px">
                            <table id="user" cellspacing="1" cellpadding="1" width="100%" border="0" class="khung">
                                <tr>
                                    <td class="title" align="center" style="background-color: #4D67A2">
                                        <span class="title" id="spHeader" runat="server"  style="color: #FFFFFF">DANH SÁCH BỆNH NHÂN CHỜ TÁI KHÁM TÁN SỎI</span></td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="center" width="100%" style="height: auto">
                                                    <table cellspacing="0" cellpadding="0" width="98%" border="0">
                                                        <tr style="padding-bottom: 5px; padding-top: 10px">
                                                            <td align="center" width="100%" style="height: 100px">
                                                                <table style="height: 17px" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tr id="trKhoa" runat="server">
                                                                        <td valign="top" nowrap align="right" style="width: 112px; height: 23px;">
                                                                            <p class="ptext" id="spChonKhoa" runat="server">
                                                                                Chọn khoa:</p>
                                                                        </td>
                                                                        <td valign="top" align="left" style="width: 161px; height: 23px;" colspan="1">
                                                                            <p class="ptext">
                                                                                <asp:dropdownlist autopostback="false" id="ddlKhoa" runat="server" width="150px"
                                                                                    onselectedindexchanged="ddlKhoa_SelectedIndexChanged"></asp:dropdownlist>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top" align="left" style="width: 161px; height: 23px;" colspan="1">
                                                                            <p class="ptext">
                                                                                <%--Nội dung khám:--%>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top" align="left" style="width: 480px; height: 23px;" colspan="3">
                                                                            <p class="ptext">
                                                                                <asp:checkbox runat="server" visible="False" id="cbIsChuaNhapVien" text="Chưa xét nhập viện"></asp:checkbox>
                                                                                <asp:dropdownlist autopostback="true" visible="False" id="ddlNoidung" runat="server"
                                                                                    width="191px" onselectedindexchanged="ddlNoidung_SelectedIndexChanged"></asp:dropdownlist>
                                                                                &nbsp;<%--Phòng khám:--%>&nbsp;
                                                                                <asp:dropdownlist id="ddlPhong" visible="False" runat="server" width="189px"></asp:dropdownlist>
                                                                            </p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" nowrap align="right" style="width: 112px; height: 24px;">
                                                                            <p class="ptext">
                                                                                Mã bệnh nhân:&nbsp;
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top" align="left" style="width: 161px; height: 24px;" colspan="1">
                                                                            <p class="ptext">
                                                                                <asp:textbox id="txtMaBenhNhan" runat="server" width="142px" tabindex="1" readonly="False"></asp:textbox>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top" nowrap align="left" style="width: 114px; height: 24px;">
                                                                            <p class="ptext">
                                                                                Tên bệnh nhân:&nbsp;
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top" align="left" style="width: 350px; height: 24px;">
                                                                            <p class="ptext">
                                                                                <asp:textbox id="txtTenBenhNhan" runat="server" width="335px" tabindex="2"></asp:textbox>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top" nowrap align="left">
                                                                            <p class="ptext">
                                                                                &nbsp;Giới tính:&nbsp;
                                                                                <asp:dropdownlist id="ddlGioiTinh" runat="server" width="74px" tabindex="3"><asp:ListItem Selected="True" Value="-1">---</asp:ListItem>
<asp:ListItem Value="0">Nam</asp:ListItem>
<asp:ListItem Value="1">Nữ</asp:ListItem>
</asp:dropdownlist>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top" align="left" style="width: 150px; height: 24px;">
                                                                            <p class="ptext">
                                                                                &nbsp;</p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" nowrap align="right" style="width: 112px; height: 3px;">
                                                                            <p class="ptext">
                                                                                Điện thoại:&nbsp;
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top" align="left" style="width: 161px; height: 3px;" colspan="1">
                                                                            <p class="ptext">
                                                                                <asp:textbox id="txtDienThoai" runat="server" width="141px" tabindex="4"></asp:textbox>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top" nowrap align="left" style="width: 114px; height: 3px;">
                                                                            <p class="ptext">
                                                                                Địa chỉ:&nbsp;
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top" align="left" style="width: 100px; height: 3px;">
                                                                            <p class="ptext">
                                                                                <asp:textbox id="txtDiaChi" runat="server" width="334px" tabindex="5"></asp:textbox>
                                                                            </p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td nowrap valign="top" align="right" style="width: 70px; height: 3px;">
                                                                            Ngày hẹn :
                                                                        </td>
                                                                        <td valign="top" align="left" style="width: 100px; height: 3px;" colspan="1">
                                                                            <asp:textbox id="txtTuNgay" runat="server" tabindex="6" width="80px"  onfocus="$(this).datepick();" onblur="nvk_testDate_this(this);" ></asp:textbox>
                                                                        </td>
                                                                        <td valign="top" align="left" style="width: 100px; height: 3px;">
                                                                            Đến ngày :</td>
                                                                        <td valign="top" align="left" style="width: 250px; height: 3px;">
                                                                            <asp:textbox id="txtDenNgay" runat="server" tabindex="7" width="80px"  onfocus="$(this).datepick();" onblur="nvk_testDate_this(this);" ></asp:textbox>
                                                                            <asp:imagebutton id="ImageButton1" runat="server" imageurl="../images/tim.png" tabindex="8"
                                                                            onclick="ImageButton1_Click"></asp:imagebutton>
                                                                            <asp:imagebutton id="btnCancel" tabindex="9" onclick="btnCancel_Click" runat="server"
                                                                            imageurl="../images/MOI.gif"></asp:imagebutton>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;&nbsp;
                                                                        </td>   
                                                                        <td valign="top" align="left" style="width: 100px; height: 3px;">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <%--<table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="left" width="100%" height="20">
                                                    <asp:label forecolor="red" id="lblTotal" runat="server"></asp:label>
                                                </td>
                                            </tr>
                                        </table>--%>
                                        <%--<table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="left" width="100%" height="20">
                                                    <p class="title">
                                                        Danh sách Bệnh Nhân chờ nhập khoa</p>
                                                </td>
                                            </tr>
                                        </table>--%>
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr style="width: 100%">
                                                <td valign="top" align="center" width="100%" colspan="2" height="20">
                                                    <asp:scriptmanager runat="server" id="script1"></asp:scriptmanager>
                                                    <asp:updatepanel runat="server" id="script2"><ContentTemplate>
<asp:datagrid id="dgr" tabIndex="10" runat="server" Width="100%" OnPageIndexChanged="PageIndexStyleChanged" AllowPaging="False" OnEditCommand="Edit" OnItemCommand="dgr_ItemCommand" OnDeleteCommand="DelBenhNhan" CellPadding="2" OnItemDataBound="dgr_ItemDataBound" BorderColor="Silver" BorderWidth="1px" DataKeyField="idkhambenh" AutoGenerateColumns="false" AllowSorting="True">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnEdit" runat="server" __designer:wfdid="w6" CommandName="Edit" Text='<%#Eval("TinhTrang") %>' CommandArgument='<%# Eval("idkhambenhnhap") %>' width="60px" CssClass="alink3"></asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="7%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="STT"><ItemTemplate>
		<%=STT()%>	
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="9%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="14%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="diachi" HeaderText="Địa chỉ">
<HeaderStyle Wrap="False" Width="20%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="dienthoai" HeaderText="Điện thoại">
<HeaderStyle HorizontalAlign="Center" Wrap="False" Width="13%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Gioi" HeaderText="Giới t&#237;nh">
<HeaderStyle Width="3%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="namsinh" HeaderText="Năm sinh">
<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaykham" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Ngày tái khám">
<HeaderStyle Width="12%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<%--<asp:BoundColumn DataField="tenphonggoc" HeaderText="Chuyển từ">
<HeaderStyle Width="9%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>--%>
<%--<asp:BoundColumn DataField="tenphongnoitru" HeaderText="Phòng nhập">
<HeaderStyle Width="20%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>--%>
</Columns>

<HeaderStyle HorizontalAlign="Center" CssClass="dgrHeader"></HeaderStyle>
</asp:datagrid>&nbsp;
</ContentTemplate>
</asp:updatepanel>
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
    <div style="display: none; position: fixed; top: 15%; left: 15%; background-color: White;
        z-index:0.5; padding: 10px 10px 10px 10px; border: 10px solid #4D67A2; height: auto"
        id="divlydo" runat="server">
        <asp:updatepanel runat="server" id="updatepanelhidden"><ContentTemplate>
        <%--<asp:hiddenfield id="hdIdKhamBenh" runat="server"></asp:hiddenfield>
         <asp:hiddenfield id="hdIdBenhNhan" runat="server"></asp:hiddenfield> 
        <asp:hiddenfield id="hdTenBenhNhan" runat="server"></asp:hiddenfield>--%>
        <input type="hidden" id="hdIdKhamBenh" runat="server" />
        <input type="hidden" id="hdIdKhamBenhNhap" runat="server" />
        <input type="hidden" id="hdIdBenhNhan" runat="server" />
        <input type="hidden" id="hdTenBenhNhan" runat="server" />
        <input type="hidden" id="hdLoaiBN" runat="server" />
        <input type="hidden" id="name4" runat="server" />
        
        <input type="hidden" id="hdIdNoiTruSuaNhap" runat="server" />
        </ContentTemplate></asp:updatepanel>
        <table style="width: 85%">
        <tr>
        <td style="width: 100%" colspan="2">
        <asp:updatepanel runat="server" id="updatepanelBN"><ContentTemplate>
        <table style="width: 100%">
            <tr>
                <td style="width: 100%" colspan="2">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                Bệnh nhân:<asp:textbox runat="server" id="txtTenBNNhap" enabled="false"></asp:textbox>
                            </td>
                            <td>
                                Mã bệnh nhân :<asp:textbox runat="server" style="width: 100px" id="txtMaBNNhap" enabled="false"></asp:textbox></td>
                            <td>
                                Giới tính :
                                <asp:textbox runat="server" style="width: 40px" id="txtGioiTinhNhap" enabled="false"></asp:textbox>
                            </td>
                            <td>
                                Ngày vào viện :<asp:textbox runat="server" style="width: 120px" id="txtNgayVaoVien"
                                    enabled="false"></asp:textbox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 100%" colspan="2">
                    <table>
                        <tr>
                            <td>
                                Khoa chuyển đến :<asp:textbox runat="server" id="txtKhoaChuyen" enabled="false"></asp:textbox>
                            </td>
                            <td>
                                <span id="spKhoaNhap" runat="server">Khoa nhập :</span> 
                                <asp:textbox runat="server" id="txtKhoaNhap" enabled="false"></asp:textbox>
                            </td>
                            <td>
                                Ngày nhập :
                                <asp:textbox runat="server" id="txtNgayNhap" enabled="true" width="80px" ></asp:textbox>
                                <asp:textbox visible="true" id="txtGioNhap" runat="server" width="40px"></asp:textbox> 
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 100%" colspan="2">
                    <table>
                        <tr>
                            <td>
                                Chuẩn đoán khoa chuyển : <span class="ptext">
                                    <asp:textbox id="txtmachandoanKhoaChuyen" runat="server" width="56px"></asp:textbox>
                                    <asp:textbox id="txtchandoanKhoaChuyen" runat="server" width="500px"></asp:textbox>
                                    <asp:label id="lb2" runat="server" text="(theo ICD10)"></asp:label>
                                </span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table>
            </ContentTemplate></asp:updatepanel>
            </td>
            </tr>
            <%--gdgd--%>
            <tr>
                <td style="width: 100%" colspan="2">
                    <table>
                        <tr>
                            <td>
                                Chuẩn đoán nhập khoa : <span class="ptext">
                                    <input type="hidden" runat="server" id="txtIdChanDoan_3" value="0" />
                                    <asp:textbox id="txtmachandoan_3" runat="server" width="56px" onfocus="LoadChanDoanICD10('txtmachandoan_3', '3')"></asp:textbox>
                                    <asp:textbox id="txtchandoan_3" runat="server" width="500px" onfocus="LoadChanDoanICD10('txtchandoan_3', '3')"></asp:textbox>
                                    <asp:label id="lb3" runat="server" text="(theo ICD10)"></asp:label>
                                </span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="width: 100%">
                <td>
                    <table id="chandoanicd10_1" runat="server" style="width: 50%; display: none">
                        <tr bgcolor="#0066ff" style="font-weight: bolder; color: White">
                            <td>
                            </td>
                            <td>
                                Mã ICD
                            </td>
                            <td>
                                Mô tả
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 100%" colspan="2">
                    <asp:updatepanel runat="server" id="updatepanelphong"><ContentTemplate>
                    <span id="spoidungGiuong" runat="server">
                <table>
                <tr>
                <td> Chọn phòng:<asp:DropDownList runat="server" width="214px" id="ddlPhongNhapVien" autopostback="true" OnSelectedIndexChanged="ddlPhongNhapVien_SelectedIndexChanged"></asp:DropDownList></td>
                <td> Giường: <asp:DropDownList runat="server" width="200px" id="ddlGiuongNhapVien" autopostback="true" OnSelectedIndexChanged="ddlGiuongNhapVien_SelectedIndexChanged"></asp:DropDownList></td>
                <td> Giá giường: <asp:textbox runat="server" width="109px" id="txtTienGiuong" ></asp:textbox> </td>                
                </tr>
                <tr>
                <td style="width:100%" colspan="3">
                <table style="width:100%">
                <tr style="width:100%">               
                <td> Bác sĩ:<%-- <asp:DropDownList runat="server" width="343px" id="ddlBacSiKhoa"></asp:DropDownList>--%>
                    <%--<input onfocus="TimBacSi();" style="WIDTH: 30px;" runat="server" id="txtTenBacSi"  type="text" />
                    <input runat="server" type="hidden" id="hdIdBacSi" />--%>
                    <input mkv="true" id="idbacsi" type="hidden" runat="server" />
                    <input mkv="true" id="mkv_idbacsi" runat="server" type="text" onfocus="chuyenphim(this);idbacsisearch(this);"
                    class="down_select_hover" style="width: 250px" />
                </td>
                <td> Điều dưỡng:<%-- <asp:DropDownList runat="server" width="386px" id="ddlDieuDuongKhoa"></asp:DropDownList>--%>
                    <input mkv="true" id="iddieuduong" type="hidden" runat="server" />
                    <input mkv="true" id="mkv_iddieuduong" runat="server" type="text" onfocus="chuyenphim(this);iddieuduongsearch(this);"
                    class="down_select_hover" style="width: 250px" />
                    <asp:checkbox runat="server" id="cbTinhTienTrongNgay" style="color:red" text="Tính nguyên ngày"></asp:checkbox>
                </td>
                </tr>
                </table>
              </td>
                </tr>
                </table>
                </span>
                </ContentTemplate></asp:updatepanel>
                </td>
            </tr>
            <%--<tr>
                <td style="width: 100%" colspan="2">
                    <table>
                        <tr>
                            <td>
                                Bác sĩ:
                                <asp:dropdownlist runat="server" width="343px" id="ddlBacSiKhoa"></asp:dropdownlist>
                            </td>
                            <td>
                                Điều dưỡng:
                                <asp:dropdownlist runat="server" width="386px" id="ddlDieuDuongKhoa"></asp:dropdownlist>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
            <tr>
                <td align="center">
                <asp:updatepanel  runat="server" id="updateBtn"><ContentTemplate>
                    <asp:button runat="server" text="Lưu" style="width: 80px" id="btlydo" onclick="btlydo_Click" />
                    <asp:button runat="server" text="Sửa" style="width: 80px" id="btSuaNhapVien" visible="false" onclick="btlydo_Click" />
                    <input id="Button3" type="button" style="width: 80px" value="Đóng" onclick="javascript:divlydo.style.display = 'none';HuyClick();" />
                </ContentTemplate></asp:updatepanel>                    
                </td>
            </tr>
        </table>
        <%-- </ContentTemplate></asp:updatepanel>--%>
    </div>
</form>
<!--#include file ="footer.htm"-->
