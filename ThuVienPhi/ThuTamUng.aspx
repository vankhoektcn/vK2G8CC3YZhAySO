<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThuTamUng.aspx.cs" Inherits="ThuVienPhi_ThuTamUng_New" %>

<!--#include file ="header.htm"-->
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<script language="javascript" type="text/javascript">
    var dp_cal1; 
	window.onload = function () 
	{	    
//	    dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));	    
//	    dp_cal2 = new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));	    
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
	
	function ThuPhiTamUng(idbn,IsSua)
	{
	    var td = document.getElementById("popupTamUng");
            createTipTU(td,"tipbenhnhan","Tamung","Tam Ung","ajaxbenhnhanexists"," đang load ...","Lỗi trong quá trình load","../CapCuu/ajax.aspx?do=ThuPhiTamUng&idbn="+idbn+"&IsSua="+IsSua +"", "800", "150");   
	}
	function luuThuPhiTU(iddangkykham)
	{
	var sotien = document.getElementById("txtSoTien").value;
	var QuyenSo = document.getElementById("txtQuyenSo").value; //Khoe
	//var SoDangKy = document.getElementById("txtSoDangKy").value;
	var SoCT = document.getElementById("txtSoCT").value; 
	var LyDoTU = document.getElementById("txtLyDo").value; 
	if(QuyenSo == "")
	{
	    alert("Bạn Chưa nhập Số Quyển phiếu tạm ứng!");
	    return false ;
	}
		if(SoCT == "")
	{
	    alert("Bạn Chưa nhập số chứng từ phiếu tạm ứng!");
	    return false ;
	}
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
	             if(value == "1")
                {
                    alert("Lưu tạm ứng thành công!");
                    hideTip("tipbenhnhan");
                    var HDidCHiTietDKK = document.getElementById("HDidCHiTietDKK").value;
                    var hdIdTamUng = document.getElementById("hdIdTamUng").value;
                    InPhieuSauThu(hdIdTamUng,HDidCHiTietDKK);
                    var hddkmenu = document.getElementById("hddkmenu").value;
                    var hdidbenhnhan = document.getElementById("hdidbenhnhan").value;
                    var idkhoa='';
                    if(queryString("idkhoa") != null) idkhoa="&idkhoa="+queryString("idkhoa");
                    alert(idkhoa);
                    window.location = "../ThuVienPhi/ThuTamUng.aspx?dkMenu="+hddkmenu+"CapCuu&idbenhnhan="+hdidbenhnhan+""+idkhoa;
                }
                  else{
                   if(value=="")
                        alert("Lưu thông tin thất bại!");
//                    else
//                        alert(value);
                }
            }
        }
        var hdIdTamUng=document.getElementById('hdIdTamUng').value;
        xmlHttp.open("GET","../CapCuu/ajax.aspx?do=luuThuPhiTU&hdIdTamUng="+hdIdTamUng+"&iddangkykham=" + iddangkykham + "&SoDangKy=&quyenso="+ QuyenSo+"&SoCT="+SoCT +"&sotien=" + sotien + "&lydoTU="+encodeURIComponent(LyDoTU)+"&times="+Math.random(),true);
        xmlHttp.send(null);

	}
	function InPhieuSauThu(hdIdTamUng,iddangkykham)
	{
	     if (confirm("Đã thu phí. Bạn có muốn in phiếu thu không ?"))
	     {
	        window.open("frmBienlaitamung.aspx?idTamUng="+hdIdTamUng+"&iddkk="+iddangkykham+"#isPrint=1",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	     }
	}	
	function InPhieuSauSua(hdIdTamUng,iddangkykham)
	{
	     if (confirm("Đã Sửa tạm ứng. Bạn có muốn in phiếu báo không?"))
	     {
	        window.open("../capcuu/frmPhieuBaoThuTamUng.aspx?hdIdTamUng="+hdIdTamUng+"&iddkk="+iddangkykham+"#isPrint=1",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	     }
	}	
	function SuaTamUng(idchitietdangkykham,IsSua,idtamung)
	{
	    var td = document.getElementById("popupTamUng");
            createTipTU(td,"tipbenhnhan","Tamung","Sửa tạm ứng","ajaxbenhnhanexists"," đang load ...","Lỗi trong quá trình load","../CapCuu/ajax.aspx?do=tamUng&idbn="+idchitietdangkykham+"&IsSua="+IsSua +"&idtamung="+idtamung+"", "650", "130"); 
	}
	function luuTU(iddangkykham,idtamung)
	{
	var sotien = document.getElementById("txtSoTien").value;
	var LyDoTU = document.getElementById("txtLyDo").value;
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
	             if(value == "1")
                {
                    hideTip("tipbenhnhan");
                    var HDidCHiTietDKK = document.getElementById("HDidCHiTietDKK").value;
                    var hdIdTamUng = document.getElementById("hdIdTamUng").value;
                    InPhieuSauSua(hdIdTamUng,HDidCHiTietDKK);
                    var hddkmenu = document.getElementById("hddkmenu").value;
                    var hdidbenhnhan = document.getElementById("hdidbenhnhan").value;
                    var idkhoa='';
                    if(queryString("idkhoa") != null) idkhoa="&idkhoa="+queryString("idkhoa");
                    window.location = "../ThuVienPhi/ThuTamUng.aspx?dkMenu="+hddkmenu+"CapCuu&idbenhnhan="+hdidbenhnhan+""+idkhoa;
                }
                  else{
                   if(value=="0")
                        alert("Sửa thông tin thất bại!");
//                    else
                     //   alert(value);
                }
            }
        }
        var hdIdTamUng=document.getElementById('hdIdTamUng').value;
        xmlHttp.open("GET","../CapCuu/ajax.aspx?do=SuaTamUng&IdTamUng="+idtamung+"&iddangkykham=" + iddangkykham + "&sotien=" + sotien + "&lydoTU="+encodeURIComponent(LyDoTU)+"&times="+Math.random(),true);
        xmlHttp.send(null);

	}
</script>

<form id="Form1" method="post" runat="server">
<asp:scriptmanager runat="server" id="script1"></asp:scriptmanager>
    <table cellpadding="0" cellspacing="0" border="0" style="background-color: #C0C0C0; width: 100%;">
        <%--<tr>
            <td align="left" style="background-color: #FBF8F1; height: 19px; width: 99%;">
                <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
            </td>
        </tr>--%>
        <tr>
            <td align="left" style="background-color: #D4D0C8; width: 99%;">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" style="background-color: #D4D0C8; width: 99%;">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px">
                            <table id="user" cellspacing="1" cellpadding="1" width="100%" border="0" class="khung">
                                <tr>
                                    <td class="title" align="center" style="background-color: #4D67A2">
                                        <span class="title" style="color: #FFFFFF">BỆNH NHÂN TẠM ỨNG</span></td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="center" width="100%" style="height: 133px">
                                                    <table cellspacing="0" cellpadding="0" width="98%" border="0">
                                                        <tr style="padding-bottom: 5px; padding-top: 10px">
                                                            <td width="100%" style="height: 100px;padding-left:0px" align="center">
                                                                <table cellspacing="0" cellpadding="0" width="800px" border="0">
                                                                    <tr>
                                                                        <td style="padding-top: 2px; padding-left: 20px; width: 20%;" align="left">
                                                                            Mã bệnh nhân:
                                                                        </td>
                                                                        <td style="padding-top: 2px; height: 26px; " align="left">
                                                                            <span class="ptext">
                                                                                <asp:textbox id="txtMaBenhNhan" runat="server" width="178px" tabindex="4"></asp:textbox>
                                                                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </span>Tên bệnh nhân :&nbsp;<asp:textbox id="txtTenBenhNhan"
                                                                                    runat="server" width="280px" tabindex="4"></asp:textbox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-top: 2px; padding-left: 20px; height: 24px; width: 20%;" align="left">
                                                                            <span class="ptext">Địa chỉ :</span></td>
                                                                        <td style="padding-top: 2px; width: 100%; height: 24px;" align="left">
                                                                            <span class="ptext">
                                                                                <asp:textbox id="txtDiaChi" runat="server" tabindex="9" width="416px"></asp:textbox>
                                                                                Ngày sinh:
                                                                                <asp:textbox id="txtNgaySinh" runat="server" tabindex="9" width="110px"></asp:textbox>
                                                                            </span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-top: 2px; padding-left: 20px; height: 26px; width: 20%;" align="left">
                                                                            Ngày nhập khám:</td>
                                                                        <td style="padding-top: 2px; width: 100%; height: 26px;" align="left">
                                                                            &nbsp;<asp:textbox id="txtNgayTiepNhan" runat="server" tabindex="9" width="177px"></asp:textbox>
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; Giới tính : &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:textbox
                                                                                id="txtGioiTinh" runat="server" tabindex="9" width="71px"></asp:textbox>
                                                                            &nbsp; Số điện thoại:
                                                                            <asp:textbox id="txtSoDienThoai" runat="server" tabindex="9" width="110px"></asp:textbox>
                                                                        </td>
                                                                    </tr>
                                                                    <%--<tr visible="false">
                                                                        <td nowrap valign="top" align="right" style="height: 3px; width: 173px;">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td valign="top" visible="false" align="left" style="width: 1141px; height: 3px;">
                                                                            &nbsp;<asp:imagebutton id="ImageButton1" runat="server" imageurl="../images/tim.png"
                                                                                tabindex="10" onclick="ImageButton1_Click"></asp:imagebutton>
                                                                            <asp:imagebutton id="btnCancel"  tabindex="11" onclick="btnCancel_Click" runat="server"
                                                                                imageurl="../images/MOI.gif"></asp:imagebutton>
                                                                               
                                                                        </td>
                                                                    </tr>--%>
                                                                </table>
                                                                &nbsp;
                                                                         <input type="hidden" runat="server" name="loaibn" id="loaibn" />
                                                                         <input type="hidden" runat="server" name="loaibn" id="hddkmenu" />
                                                                         <input type="hidden" runat="server" name="loaibn" id="hdidbenhnhan" />
                                                                         <input type="hidden" runat="server" name="loaibn" id="HDidCHiTietDKK" />
                                                                         <input type="hidden" runat="server" name="loaibn" id="hdIdTamUng" />
                                                                         </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="left" width="100%" class="title" style="color: #FFFFFF; background-color: #4D67A2;
                                                    height: 20px;">
                                                    Danh sách tạm ứng</td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td id="popupTamUng" valign="top" align="left" width="100%" colspan="2" height="20">
                                                    <asp:datagrid id="dgr" tabindex="12" runat="server" width="100%" allowsorting="True"
                                                        autogeneratecolumns="False" datakeyfield="idchitietdangkykham" borderwidth="1px" bordercolor="Silver"
                                                        cellpadding="2" onitemcommand="dgr_ItemCommand1" OnItemDataBound="dgr_ItemDataBound">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
<%--<asp:LinkButton id="lbnSua" runat="server" CommandName="TU" CssClass="alink3" Width="69px" Text="Sửa" __designer:wfdid="w1"></asp:LinkButton> --%>
<asp:LinkButton id="lbnIn" runat="server" CommandName="inBLTU" CommandArgument='<%# Eval("idtamung") %>' CssClass="alink3" Width="69px" Text="In BL tạm ứng" __designer:wfdid="w2"></asp:LinkButton> 
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lnbtnStatus" Text='<%#Eval("status") %>' runat="server"  CssClass="alink3" CommandName="Status" CommandArgument='<%# Eval("idtamung") %>'></asp:LinkButton> 

</ItemTemplate>
<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lnbtnSua" Text='<%#Eval("Sua") %>' runat="server"  CssClass="alink3" CommandName="SuaTU" CommandArgument='<%# Eval("idtamung") %>'></asp:LinkButton> 

</ItemTemplate>
<HeaderStyle Width="3%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lnbtnXoa" Text='<%#Eval("Xoa") %>' runat="server"  CssClass="alink3" CommandName="XoaTU" CommandArgument='<%# Eval("idtamung") %>'></asp:LinkButton> 

</ItemTemplate>
<HeaderStyle Width="3%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn Visible="False"><ItemTemplate>
                                                            <asp:Label id="lblidbenhnhan" runat="server" Text='<%# Eval("idbenhnhan") %>' Visible="False"></asp:Label>
                                                            <HeaderStyle Wrap="False" Width="9%"/>
                                                                
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="STT" HeaderText="STT">
<HeaderStyle HorizontalAlign="Center" Wrap="False" Width="4%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="True"></ItemStyle>
</asp:BoundColumn>
<%--<asp:BoundColumn DataField="quyenso" HeaderText="Quyển Số"></asp:BoundColumn>--%>
<asp:BoundColumn DataField="sochungtu" HeaderText="Số Chứng Từ">
<HeaderStyle Wrap="False" Width="8%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<%--<asp:BoundColumn DataField="Phongkhambenh" HeaderText="Phòng khám">
<HeaderStyle Wrap="False" Width="9%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>--%>
<%--<asp:BoundColumn DataField="dichvukham" HeaderText="Dịch vụ">
<HeaderStyle Wrap="False" Width="20%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>--%>
<asp:BoundColumn DataField="ngayTamung" DataFormatString="{0: dd/MM/yyyy HH:mm}" HeaderText="Ngày tạm ứng">
<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenphongkhambenh" HeaderText="Khoa chỉ định">
<HeaderStyle Wrap="False" Width="15%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>

<asp:TemplateColumn><HeaderTemplate>
<asp:Label ID="lblTien" runat="server" Text="Số tiền TU"></asp:Label>
</HeaderTemplate>
<ItemTemplate>
<asp:Label ID="Label2" runat="server" Text='<%#Eval("sotien","{0:0,000} VNĐ") %>'></asp:Label>
</ItemTemplate>
<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn DataField="LydoTamUng" DataFormatString="{0: dd/MM/yyyy HH:mm}" HeaderText="Lý do TU">
<HeaderStyle Wrap="False" Width="30%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" CssClass="dgrHeader"></HeaderStyle>
</asp:datagrid>
                                                    &nbsp;
                                                    <br />
                                                    <br />
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
    <div style="display:none;position:fixed;top:35%;left:35%;background-color:White;z-index:1000;padding:10px 10px 10px 10px;border:10px solid #4D67A2" id="divlydo" runat="server">
       <asp:updatepanel runat="server" id="updatepanel1"><ContentTemplate>
      <table>
          <tr>
              <td>
                 Người dùng 
              </td>
              <td>
                  <asp:textbox runat="server" id="nguoidung" enabled="false"></asp:textbox>
              </td>
          </tr>
          <tr>
              <td>
                 Ngày thực hiên 
              </td>
              <td>
              <asp:textbox runat="server" id="ngaythang" enabled="false"></asp:textbox>
              </td>
          </tr>
          <tr>
              <td>
                  Kiểu thao tác
              </td>
              <td>
              <asp:textbox runat="server" id="kieutt" enabled="false"></asp:textbox>
              </td>
          </tr>
          <tr>
              <td>
                  Lý do
              </td>
              <td>
              <asp:textbox runat="server" id="lydo"></asp:textbox>
              </td>
          </tr>
      </table>
      </ContentTemplate></asp:updatepanel>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:button runat="server" text="Lưu" id="btlydo" OnClick="btlydo_Click"/>
      <input id="Button3" type="button" value="Huỷ" onclick="javascript:divlydo.style.display = 'none';"/>
      
  </div> 
</form>
