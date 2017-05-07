<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TienGiuongXuatKhoa.aspx.cs" Inherits="TienGiuongXuatKhoa" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!--#include file ="header.htm"-->
<style type="text/css">
		.black_overlay{
			display: none;
			position: absolute;
			top: 0%;
			left: 0%;
			width: 100%;
			height: 100%;
			background: url('../images/trongsuot.png');
			z-index:1001;
			-moz-opacity: 0.8;
			opacity:.80;
			filter: alpha;
		}
		.white_content {
			display: none;
			position:fixed;
			top: 25%;
			left: 25%;
			width: 20%;
			height: 15%;
			padding: 8px;
			border: 8px solid silver;
			background-color: white;
			z-index:1002;
			overflow: auto;
		}
		input[type="button"],input[type="submit"]{border:2px solid #cfcfcf;height:25px;background-color:#648ccc;color:white;font-weight:bold;}
        input[type="button"],input[type="submit"]:focus{border:1px solid #000;}
        input[type="button"],input[type="submit"]:hover{padding:1px 1px 1px 1px;background-color:#1d4b74;margin-bottom:-1px;cursor:pointer;}
	</style>
<script language = "javascript">
     
    var dp_cal1; 
      var dp_cal; 
	window.onload = function () 
	{
	  dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));
	    dp_cal= new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
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
    function loadPopupTTBN1()
	{
            
            document.getElementById('light1').style.display='block';
	}
	 function Close()
	{
            
            document.getElementById('light1').style.display='none';
            document.getElementById('divlydo').style.display='block';
	}//CloseChild
	 function CloseChild()
	{
            document.getElementById('divlydo').style.display='none';
            document.getElementById('divChiTietGiuongNgay').style.display='none';
            document.getElementById("hdloaiBN").value="";
            document.getElementById("hdidchitietdangkykham").value="";
	}
	function CloseDivGiuong()
	{
            document.getElementById('divChiTietGiuongNgay').style.display='none';
	}	
	 function CloseThuoc()
	{
            document.getElementById('divToaThuoc').style.display='none';
            document.getElementById('divlydo').style.display='block';
	}//divToaThuoc
	
	function OpenLinkKhamBenhCapCuu(dkmenu,idkhambenh)
	{
            window.open("../CapCuu/KhamTiepNhanCapCuu.aspx?dkmenu=Khong#idkhoachinh=" + idkhambenh + "");
            document.getElementById('divlydo').style.display='block';
	}
	function OpenLinkKhamBenhKhoaSan(dkmenu,idkhambenh)
	{
            window.open("../KhoaSan/KhamTiepNhanKhoaSan.aspx?dkmenu=Khong#idkhoachinh=" + idkhambenh + "");
            document.getElementById('divlydo').style.display='block';
	}
	function OpenLinkChiDinh(link)
	{
            window.open(link);
            document.getElementById('divlydo').style.display='block';
	}
	// Nội Dung xủ lý trong table 
	function xoaontablecls(control){
	        //alert($("gridTablecls").index()); 
                  var valueCLS = $(control).parents("table").find("tr").eq($(control).parent().parent().index()).find("#idkhoa").val();
                  alert("valueCLS="+valueCLS)
                  $("gridTablecls").XoaRow({
                     ajax:"../ajax/khambenh_ajax3.aspx?do=xoaGiuongBenhNhan"
                  });
               
                  (($(control).parent().parent().index() == -1) ? CheckXoaCLS(valueCLS):"");              
         }
    $(document).ready(function () {
             
//             if($.mkv.queryString("LuuMoiKhamBenh")=='0')
//             {
//                loadTableAjaxkhambenhcanlamsan($.mkv.queryString("idkhoachinh"));
//                SetBacSiChiDinh();
//             }
//             else
//             {             
//                loadTableAjaxkhambenhcanlamsan();
//                SetBacSiChiDinh();
//             }
         });
      function thanhtiencls(obj)
      {
        var dongia= $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val();
        var songay= $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#songay").val();
        dongia = dongia.toString().replace(/\$|\,/g,'');
        songay = songay.toString().replace(/\$|\,/g,'');
        var thanhtien=dongia*songay ;
        
        var tiencu=$("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val();
        tiencu=tiencu.toString().replace(/\$|\,/g,'');
        var TongTien=document.getElementById("txtTongtien").value.toString().replace(/\$|\,/g,'');
        document.getElementById("txtTongtien").value= TongTien- tiencu + thanhtien;    
        
        $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(thanhtien);
        //alert($("gridTablecls").find("tr").length);
        var Sodong = document.getElementById("gridTableGiuong").rows.length;
//        for(var i=3;i<Sodong;i++)
//        {
//            var tieni=document.getElementById("idtien_"+i);            
//        }
      }
      function idGiuongsearch(obj)
         {
            var idbenhnhan= document.getElementById("hdidbenhnhan");
            var loaiBN= document.getElementById("hdloaiBN").value;
            if(loaiBN=="0" || loaiBN=="")
                loaiBN="2";
            //alert("idbenhnhan="+idbenhnhan.value);return;
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=idGiuongsearch&loaiBN="+loaiBN+"&idkhoa="+$("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#idkhoa").val()+"",{
             minChars:0,
             width:550,
             scroll:true,
             addRow:false,
             header:"Danh sách giường",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                $(obj).val(data[4]);
                $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val(data[2]);
                var thanhtien= data[2] * $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#songay").val();
                var tiencu= $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val();
                tiencu=tiencu.toString().replace(/\$|\,/g,'')
                var TongTien=document.getElementById("txtTongtien").value.toString().replace(/\$|\,/g,'');
                TongTien=TongTien-tiencu+thanhtien;
                document.getElementById("txtTongtien").value=TongTien;
                $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(thanhtien);
                 if($(obj).parents("#gridTableGiuong").attr("id") != null){
                     $("#gridTableGiuong").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 }
                 
                 setTimeout(function () {
                     obj.focus();
                 },100);
                 
             });
             
         }
      function luuNoiDungGiuong()
      {
        $.ajax({
                            type:"GET",
                            dataType:"text",
                            cache:false,
                            async:false,
                            //url:"../ajax/khambenh_ajax3.aspx?do=BeforeluuTableGiuongNoiTru&idkhoa="+$.mkv.queryString("IdKhoa"),
                            success:function (value) {
                                if(value !="0")
                                 { //$.mkv.queryString("idkhoachinh",value); 
                                 }
                                $.LuuTable({
                     ajax:"../ajax/khambenh_ajax3.aspx?do=luuTableGiuongNoiTru",
                        tablename:"gridTableGiuong"
             },null,function () {
                                //sau khi lưu table    $.mkv.queryString("LuuMoiKhamBenh","0");
                                alert("Đã lưu !");
                                } );//end LuuTable
             }
                           }); 
      }   
         ///
	// End Nội Dung xủ lý trong table 
	
	// Chọn giường trong ngày
	function Ngay_click(obj)
	{
	    var idctdkk=document.getElementById('hdidchitietdangkykham').value;
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
	            document.getElementById('divChiTietGiuongNgay').innerHTML=value;
	            document.getElementById('divChiTietGiuongNgay').style.display='';
	            document.getElementById('btndongCTG').focus();
	        }
        }
        xmlHttp.open("GET","../ajax/khambenh_ajax3.aspx?do=getPhongBNMotNgay&idctdkk="+idctdkk+"&ngay="+obj.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	function LuuChonGiuong(idchitietdangkykham,ngay,sogiuong)
	{
	    //alert("idchitietdangkykham="+idchitietdangkykham+";ngày:"+ngay+"; số giường:"+sogiuong);
	    var radio;var valid=false;
	    for(var i=0;i<sogiuong;i++)
	    {
	        radio=document.getElementById("rdGiuong_"+i);
	        if(radio.checked==true)
	            {//alert(radio.value);
	             valid=true; break;}
	    }
	    if(valid==false)
	    {
	        alert("Chưa check giường !");return;
	    }
	    //alert(radio.value);
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if(value=="0")//lỗi
                    alert("Lỗi");
                else
                { 
                    alert("Đã lưu!");
                    document.getElementById('tableAjax_EditTienGiuong').innerHTML=value;
                }
	            //document.getElementById('divGiuong').style.display='';
	        }
        }
        xmlHttp.open("GET","../ajax/khambenh_ajax3.aspx?do=saveChonGiuongNgay&idctdkk="+idchitietdangkykham+"&ngay="+ngay+"&idnoitru="+radio.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	// End Chọn giường trong ngày
</script>
<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#D4D0C8; height: 10px;">
              <asp:placeholder ID="PlaceHolder1" runat="server"></asp:placeholder>
              
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
		    <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px">
			    <table id="user" cellSpacing="1" cellPadding="1" width="100%" border="0" class = "khung">
				    <tr>
				        <td class="title" align = "center" style ="background-color: #4D67A2">
			                <span class="title" style ="color:#FFFFFF">DANH SÁCH BỆNH NHÂN XÉT TIỀN GIƯỜNG</span></td>
				    </tr>
				    <TR>
					    <TD width="100%">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" style="height: auto">
									    <TABLE cellSpacing="0" cellPadding="0" width="98%" border="0">
										   
				
										    <TR style="PADDING-BOTTOM: 5px; PADDING-TOP: 10px">
											    <TD align="center" width="100%" style="height: 100px">
												    <TABLE style="HEIGHT: 17px" cellSpacing="0" cellPadding="0" width="100%" border="0">
												    <tr>
												        <td valign="top" nowrap align="right" style="WIDTH: 112px; height: 23px;">
												            <p class="ptext">Chọn khoa:</p>
												        </td>
												        <td valign="top" align="left" style="WIDTH: 161px; height: 23px;" colspan="1">
												            <p class="ptext"><asp:dropdownlist autopostback="true" id="ddlKhoa" runat="server" width="150px" OnSelectedIndexChanged="ddlKhoa_SelectedIndexChanged"></asp:dropdownlist></p>
												        </td>
												        <td valign="top" align="left" style="WIDTH: 161px; height: 23px;" colspan="1">
												            <p class="ptext">Loại khám:</p>
												        </td>
												         <td valign="top" align="left" style="WIDTH: 480px; height: 23px;" colspan="3">
												            <p class="ptext">
												                <asp:dropdownlist id="ddlLoaiKham" runat="server" width="150px"></asp:dropdownlist>
												                <asp:dropdownlist autopostback="true" visible="false" id="ddlNoidung" runat="server" width="191px" OnSelectedIndexChanged="ddlNoidung_SelectedIndexChanged"></asp:dropdownlist>
                                                                <%--&nbsp;Phòng khám:&nbsp;--%>
                                                                <asp:dropdownlist id="ddlPhong" visible="false"  runat="server" width="189px"></asp:dropdownlist></p>
												            
												        </td>
												       
												    </tr>
													    <TR>
													 
														    <TD vAlign="top" noWrap align="right" style="WIDTH: 112px; height: 24px;">
															    <P class="ptext">Mã bệnh nhân:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 161px; height: 24px;" colspan="1">
															    <P class="ptext"><asp:TextBox ID="txtMaBenhNhan" Runat="server" Width="142px" tabIndex="1" ReadOnly="False"></asp:TextBox></P>
														    </TD>
														     <TD vAlign="top" noWrap align="left" style="WIDTH: 114px; height: 24px;">
															    <P class="ptext">
                                                                    Tên bệnh nhân:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left"  style=" WIDTH: 350px;height: 24px;">
															    <P class="ptext"><asp:TextBox ID="txtTenBenhNhan" Runat="server" Width="335px" tabIndex="2"></asp:TextBox></P>
														    </TD>
														      <TD vAlign="top" noWrap align="left" >
															    <P class="ptext">
                                                                    &nbsp;Giới tính:&nbsp;
                                                                    <asp:dropdownlist id="ddlGioiTinh" runat="server" width="74px" TabIndex="3"><asp:ListItem Selected="True" Value="-1">---</asp:ListItem>
<asp:ListItem Value="0">Nam</asp:ListItem>
<asp:ListItem Value="1">Nữ</asp:ListItem>
</asp:dropdownlist></P>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 150px; height: 24px;">
															    <P class="ptext">
                                                                    &nbsp;</P>															    
														    </TD>
													    </TR>
													   
													    <TR>
														    <TD vAlign="top" noWrap align="right" style="WIDTH: 112px; height: 3px;">
															    <P class="ptext">
                                                                    Điện thoại:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 161px; height: 3px;" colspan="1">
															    <P class="ptext"><asp:TextBox ID="txtDienThoai" Runat="server" Width="141px" tabIndex="4"></asp:TextBox></P>
														    </TD>
														     <TD vAlign="top" noWrap align="left" style="WIDTH: 114px; height: 3px;">
															    <P class="ptext">
                                                                    Địa chỉ:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 100px; height: 3px;" >
															    <P class="ptext"><asp:TextBox ID="txtDiaChi" Runat="server" Width="334px" tabIndex="5"></asp:TextBox>
															    
															    </P>															    
														    </TD>
														    <td align="left"> <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../images/tim.png" TabIndex="8" OnClick="ImageButton1_Click"></asp:ImageButton>
                                                          <asp:imagebutton id="btnCancel" tabIndex="9" onclick="btnCancel_Click" runat="server" imageurl="../images/MOI.gif"></asp:imagebutton> </td>
														    
														    
													    </TR>
													  <%--<tr>
													  <td   align="right"  >
													<P class="ptext">
                                                                    Từ ngày :&nbsp;
															    </P>
                                                          </td>
													  <TD vAlign="top" align="left" style="WIDTH: 100px; height: auto;" colspan="1">
													   <asp:textbox id="txtTuNgay"  visible="false" runat="server"
                                                              tabindex="6" width="105px" ></asp:textbox>
													  </TD>
													  <TD vAlign="top" align="left" style="WIDTH: 100px; height: auto;" >
													  <P class="ptext">
                                                                    Đến ngày:&nbsp;
															    </P></TD>
													  <td vAlign="top" align="left" style="WIDTH: 250px; height: auto;" >
													  <asp:textbox id="txtDenNgay" visible="false" runat="server" 
                                                              tabindex="7" width="104px"></asp:textbox>
                                                              </td>								  
													  <TD >
                                                          &nbsp;&nbsp;
                                                      </TD>
													<TD vAlign="top" align="left" style="WIDTH: 100px; height: auto;" >	&nbsp;</TD>    
													  </tr>--%>
													   
													   
												    </TABLE>
                                                    <%--&nbsp; <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../images/tim.png" TabIndex="8" OnClick="ImageButton1_Click"></asp:ImageButton>
                                                          <asp:imagebutton id="btnCancel" tabIndex="9" onclick="btnCancel_Click" runat="server" imageurl="../images/MOI.gif"></asp:imagebutton>--%>
                                                    </TD>
										    </TR>
									    </TABLE>
								    </TD>
							    </TR>
						    </TABLE>
						     <%--<TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="left" width="100%" height="20"><asp:Label forecolor="red" ID="lblTotal" runat="server" ></asp:Label>
								    </TD>
							    </TR>
						    </TABLE>	--%>
						    <%--<TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD  align="left" width="100%"><P class="title">Danh sách Bệnh Nhân</P>
								    </TD>
							    </TR>
						    </TABLE>	--%>					   
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR style="width:100%">
								    <TD vAlign="top" align="center" width="100%" colSpan="2" height="20">
                                        <asp:scriptmanager runat="server" id="script1"></asp:scriptmanager>
                                         <asp:updatepanel runat="server" id="script2"><ContentTemplate>
<asp:datagrid id="dgr" tabIndex=10 runat="server" Width="100%" OnPageIndexChanged="PageIndexStyleChanged" AllowPaging="True" onitemcommand="dgr_ItemCommand" OnDeleteCommand="DelBenhNhan" CellPadding="2" OnItemDataBound="dgr_ItemDataBound" BorderColor="Silver" BorderWidth="1px" DataKeyField="idkhambenh" AutoGenerateColumns="false" AllowSorting="True" PageSize="30">
<PagerStyle Mode="NumericPages" ForeColor="DarkBlue" Font-Size="Small" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>

<AlternatingItemStyle CssClass="dgrSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></AlternatingItemStyle>

<ItemStyle CssClass="dgrNoSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle CssClass="dgrHeader" HorizontalAlign="Center"></HeaderStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnEdit" runat="server" __designer:wfdid="w6" CommandName="Edit" CommandArgument='<%# Eval("idbenhnhan") %>' width="70px" Text="Chi tiết giường" CssClass="alink3"></asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnMau01" runat="server" CommandName="ViewTTBN" CommandArgument='<%# Eval("idbenhnhan") %>' width="40px" >Chi phí</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="4%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="STT"><ItemTemplate>
		<%=STT()%>	
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<ItemStyle Wrap="True"></ItemStyle>
<HeaderStyle Width="14%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
<HeaderStyle Width="14%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="sobhyt" HeaderText="Số BHYT">
<ItemStyle Wrap="True"></ItemStyle>
<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="diachi" HeaderText="Địa chỉ">
<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="20%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<%--<asp:BoundColumn DataField="dienthoai" HeaderText="Điện thoại">
<HeaderStyle Width="13%" Wrap="False" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundColumn>--%>
<asp:BoundColumn DataField="gioitinh" HeaderText="Giới t&#237;nh">
<HeaderStyle Width="3%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="namsinh" HeaderText="Năm sinh">
<ItemStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

<HeaderStyle Width="5%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaykham" HeaderText="Ng&#224;y nhập kh&#225;m" DataFormatString="{0:dd/MM/yyyy HH:mm}">
<ItemStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
<HeaderStyle Width="12%"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="tenphongnoitru" HeaderText="Ph&#242;ng kh&#225;m">
<ItemStyle HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

<HeaderStyle Width="12%"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="TienGiuong" DataFormatString="{0:N0}" HeaderText="Tiền giường">
<ItemStyle HorizontalAlign="Right" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

<HeaderStyle Width="15%"></HeaderStyle>
</asp:BoundColumn>
</Columns>
</asp:datagrid>&nbsp; <asp:hiddenfield id="name1" runat="server"></asp:hiddenfield> <asp:hiddenfield id="name2" runat="server"></asp:hiddenfield> <asp:hiddenfield id="name3" runat="server"></asp:hiddenfield> <asp:hiddenfield id="name4" runat="server"></asp:hiddenfield> 

<div style="display:none;position:fixed;top:0%;bottom:10%;left:10%;width:80%;background-color:White;z-index:1000;padding:10px 10px 10px 10px;border:10px solid #4D67A2;overflow-y:scroll;" id="divlydo" runat="server">
        <table style="text-align:left;" border="1" cellpadding="3" cellspacing="0"  bordercolor="black">
            <tr>
                <td width="100px">Mã bệnh nhân</td>
                <td width="200px"><asp:Label forecolor="blue" ID="lbMaBN" runat="server" ></asp:Label></td>
                <td width="100px">Tên bệnh nhân</td>
                <td width="200px"><asp:Label forecolor="blue" ID="lbTenBenhNhan" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td>Địa chỉ</td>
                <td colspan="3"><asp:Label forecolor="blue" ID="lbDiaChi" runat="server" ></asp:Label></td>
            </tr>
        </table>
        <span class="title">Thông tin chi tiết giường</span>
        <asp:datagrid  id="dgrChiTietGiuong" visible="true" tabIndex="11" runat="server" Width="95%" OnPageIndexChanged="PageIndexStyleChanged" AllowPaging="False" OnItemCommand="dgrChiTietGiuong_ItemCommand" OnItemDataBound="dgrChiTietGiuong_ItemDataBound" CellPadding="2"
          BorderColor="Silver" BorderWidth="1px" DataKeyField="idnoitru" AutoGenerateColumns="false" AllowSorting="True">
              <Columns> 
            <asp:BoundColumn DataField="tenkhoa" HeaderText="Khoa">
                <HeaderStyle Width="20%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
            <asp:BoundColumn DataField="giuong" HeaderText="Giường">
                <HeaderStyle Width="30%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
            
            <asp:BoundColumn DataField="tungay" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Ngày">
                <HeaderStyle Width="30%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
            
            <%--<asp:BoundColumn DataField="denngay" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Đến ngày">
                <HeaderStyle Width="20%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>--%>
            
            <asp:BoundColumn DataField="Giagiuong" HeaderText="Đơn giá/ngày">
                <HeaderStyle Width="20%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
            
            <%--<asp:BoundColumn DataField="sogio" HeaderText="Số giờ">
                <HeaderStyle Width="10%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
             <asp:BoundColumn DataField="thanhtien" DataFormatString="{0:N0}" HeaderText="Thành tiền">
                <HeaderStyle Width="10%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>--%>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

            <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedItemStyle>

            <PagerStyle Mode="NumericPages" HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

            <ItemStyle ForeColor="#000066"></ItemStyle>

            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>
    </asp:datagrid>
        <span class="title">Tính tiền giường</span>         
        <table>
            <tr>
                <td><asp:label runat="server" id="lblTenBN"></asp:label></td>
                <%--<td style="padding-left:20%"><asp:label runat="server" id="lblDC"></asp:label></td>--%>
            </tr>
        </table>
        <%--<asp:datagrid runat="server" visible="false" id="dgrChiTiet" OnEditCommand="EditListPopup" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
        allowsorting="True" autogeneratecolumns="False" datakeyfield="idkhambenh">--%>
        <asp:datagrid  id="dgrChiTietChild" visible="false" tabIndex="11" runat="server" Width="95%" OnPageIndexChanged="PageIndexStyleChanged" AllowPaging="False" OnItemCommand="dgrChiTietChild_ItemCommand" OnItemDataBound="dgrChiTietChild_ItemDataBound" CellPadding="2"
          BorderColor="Silver" BorderWidth="1px" DataKeyField="idnoitrunamnhieunhat" AutoGenerateColumns="false" AllowSorting="True">
              <Columns> 
            <asp:BoundColumn DataField="Khoa" HeaderText="Khoa">
                <HeaderStyle Width="10%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
            
            <asp:BoundColumn DataField="ngay" DataFormatString="{0:HH:mm dd/MM}" HeaderText="Từ ngày">
                <HeaderStyle Width="15%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
            
            <asp:BoundColumn DataField="denngay" DataFormatString="{0:HH:mm dd/MM}" HeaderText="Đến ngày">
                <HeaderStyle Width="15%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
            
            <asp:BoundColumn DataField="tengiuong" HeaderText="Giường">
                <HeaderStyle Width="30%"></HeaderStyle>
                <ItemStyle HorizontalAlign="left" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
            <asp:BoundColumn DataField="tiengiuongNamNhieuNhat" HeaderText="Đơn giá/ngày">
                <HeaderStyle Width="10%"></HeaderStyle>
                <ItemStyle HorizontalAlign="right" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
            
            <asp:BoundColumn DataField="songay" HeaderText="Số Ngày">
                <HeaderStyle Width="10%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
             <asp:BoundColumn DataField="thanhtien" DataFormatString="{0:N0}" HeaderText="Thành tiền">
                <HeaderStyle Width="10%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

            <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedItemStyle>

            <PagerStyle Mode="NumericPages" HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

            <ItemStyle ForeColor="#000066"></ItemStyle>

            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>
    </asp:datagrid>
    <br />
    <div runat="server" id="divNgayNhieuGiuong">
    </div>
    <br />
    <div id="divChiTietGiuongNgay" style="display:none;top:20%;bottom:50%;left:35%;width:30%;background-color:white;z-index:1001;padding:5px 5px 5px 5px;border:10px solid black;"></div>
    <div id="tableAjax_EditTienGiuong" runat="server">        
    </div>
    <%--<div style="text-align:right;width:95%">
        Tổng tiền : 
        <input type="text" style="text-align:right;color:Red" runat="server" id="txtTongtien" disabled="disabled" value="0"/>
        <asp:Label id="lbTongTien" text="" style="text-align:right;color:Red" runat="server"></asp:Label>
    </div>--%>
    <%--<span class="title">Thông tin toa thuốc</span>--%>
    <%--<div style="text-align:right;width:95%">
    <asp:Label id="TT" text="Xét tổng tiền giường" visible="false" runat="server"></asp:Label>
    <input type="text" style="text-align:right;color:Red" runat="server" id="txtTongtien" visible="false" value="0"/>
    </div>--%>
    <div>
    <asp:Button ID="btnLuuRaVien" runat="server" Text="Lưu tiền giường" visible="false" onclick="btnLuuRaVien_click" />
    <input type="button" id="CapNhatGiuong" onclick="luuNoiDungGiuong();" value="Lưu bảng giường" />
    <input type="button" value="Đóng"  onclick="CloseChild();"/>    
    </div>
    
    
</div>
<div style="display:none;position:fixed;top:20%;bottom:50%;left:35%;width:30%;background-color:#D4D0C8;z-index:1001;padding:10px 10px 10px 10px;border:10px solid Blue;overflow-y:scroll;" id="divGiuong" runat="server">
</div>
</ContentTemplate>
</asp:updatepanel>											
								    </TD>
							    </TR>
						    </TABLE>
					    </TD>
				    </TR>
			    </table>
		    </td>
	    </tr>				
    </table>
    <asp:updatepanel id="updatepanelHidden" runat="server">	
        <ContentTemplate>        
            <input id="hdIdKhamBenh" type="hidden" runat="server" />
            <input id="hdidbenhnhan" type="hidden" runat="server" />
            <input id="hdloaiBN" type="hidden" runat="server" />
            <input id="hdTienCu" type="hidden" runat="server" />
            <input id="hdidchitietdangkykham" type="hidden" runat="server" />
         </ContentTemplate>
    </asp:updatepanel>	
    </td>
   </tr>
  </table>  
 
 </form>
<!--#include file ="footer.htm"-->