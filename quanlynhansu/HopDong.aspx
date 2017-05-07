<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HopDong.aspx.cs" Inherits="NhanSu_HopDong" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--#include file ="header.htm"-->


<head id="Head1">
    <title>Hợp đồng</title>
    <link href="css/NhanSu.css" rel="stylesheet" type="text/css" />    
        
    <script type="text/javascript" language="javascript">        
        var dp_cal1;
        var dp_cal2;
        var dp_cal3;
        var dp_cal4;
        var dp_cal5;
	    window.onload = function () 
	    {
	        dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtNgayKy'));  
	        dp_cal2 = new Epoch('epoch_popup','popup',document.getElementById('txtNgayBatDau'));
	        dp_cal3 = new Epoch('epoch_popup','popup',document.getElementById('txtNgayKetThuc'));
	        dp_cal4 = new Epoch('epoch_popup','popup',document.getElementById('txtThuViecTuNgay'));
	        dp_cal5 = new Epoch('epoch_popup','popup',document.getElementById('txtThuViecDenNgay'));	   
	    };   
	    function TinhLuongCB()
	    {
	        var Luong = document.getElementById('<%=txtMucLuongCoBan.ClientID %>').value;
	        var HeSo = document.getElementById('<%=txtHeSo.ClientID %>').value;
	        var TongLuongCB = document.getElementById('<%=txtTongLCB.ClientID %>');
	        Luong=Luong.replace(".","").replace(".","").replace(",","").replace(",","");
	       // alert("txtMucLuongCoBan="+eval(Luong));
	        TongLuongCB.value=formatCurrency(eval(Luong) * eval(HeSo));
	    }
	        
        function LoadDSNhanVien()
        {
            
            $("#txtTenNhanVien").unautocomplete().autocomplete("ajax.aspx?do=LoadDSNV",{ formatItem: function(data) { return data[1]; }, width: 700,scrollHeight: 500,scroll:true,resultsClass: "ac_results",loadingClass: "ac_loading"
            ,autoFill:true,cacheLength:0})
            .result(function(event,data,formated)
                {
                    if(data){
                        document.getElementById("txtIdNhanVien").value=data[2];
                        document.getElementById("txtTrinhDo").value=data[3]; 
                        if(data[5]==1) 
                        document.frmHopDong.ddlLoaiNhanVien.selectedIndex =2; 
                        else //if(data[5]=="0")
                        document.frmHopDong.ddlLoaiNhanVien.selectedIndex =1;
                         $("#txtTenNhanVien").flushCache();
                          $("#txtTenNhanVien").blur();
                        //document.getElementById("ddlLoaiNhanVien").value=data[5];                     
                    }
                   
                });
            ;
        }
        
    </script>
</head> 
<form id="frmHopDong" runat="server">
<div id="MyPage">
    <div id="Menu"  style="background-color:White;text-align:left">
	    <uc1:uscmenu ID="Uscmenu1" runat="server" />
	</div>
	<br />
	<div id="header">
		HỢP ĐỒNG NHÂN VIÊN
	</div>
	<div id="NoiDung" style="background-color:White; width:95%;height:auto">
		<div id="tableBig" style="height:auto">			
			<div class="tableBig-row">
			    <div style="width:110px;float:left;text-align:right">Nhân viên:&nbsp;</div>
			    <div style="width:210px;float:left;"><input id="txtTenNhanVien" class="input" runat="server" style="width:163;" onfocus="LoadDSNhanVien();"  /><input type="hidden" runat="server" id="txtIdNhanVien" />  </div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Trình độ:&nbsp;</div>
			   <div style="width:210px;float:left;" >
			        <asp:textbox CssClass="input" runat="server"  id="txtTrinhDo" Width="150px" ReadOnly="True" TabIndex="20"></asp:textbox>
                   </div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Loại nhân viên:&nbsp;</div>
			   <div style="width:210px;float:left;" >
			        <asp:DropDownList ID="ddlLoaiNhanVien"  CssClass="dropdown" runat="server" Width="154px"><asp:ListItem Selected="True" Value="-1">Loại nh&#226;n vi&#234;n</asp:ListItem>
<asp:ListItem Value="0">Thường xuy&#234;n</asp:ListItem>
<asp:ListItem Value="1">Kh&#244;ng thường xuy&#234;n</asp:ListItem>
</asp:DropDownList>
                   </div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Loại hợp đồng:&nbsp;</div>
			   <div style="width:210px;float:left;" >
			        <asp:DropDownList ID="ddlLoaiHopDong"  CssClass="dropdown" runat="server" Width="154px">
                    </asp:DropDownList>
                   </div>
			</div>
			
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Mã hợp đồng:&nbsp;</div>
			   <div style="width:210px;float:left;" ><asp:textbox CssClass="input" runat="server"  id="txtMaHopDong" Width="150px"></asp:textbox></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Số hợp đồng:&nbsp;</div>
			   <div style="width:210px;float:left;" ><asp:textbox runat="server" CssClass="input" id="txtSoHopDong"></asp:textbox></div>
			</div>
			<br />
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Ngày ký:&nbsp;</div>
			   <div style="width:210px;float:left;" ><asp:textbox runat="server" CssClass="input" id="txtNgayKy" ></asp:textbox></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Ngày bắt đầu:&nbsp;</div>
			   <div style="width:210px;float:left;" ><asp:textbox runat="server" CssClass="input" id="txtNgayBatDau"></asp:textbox></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Ngày kết thúc:&nbsp;</div>
			   <div style="width:210px;float:left;" ><asp:textbox runat="server" id="txtNgayKetThuc" CssClass="input"></asp:textbox></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:120px;float:left;text-align:right">Thời hạn hợp đồng:&nbsp;</div>
			   <div style="width:200px;float:left;" ><asp:textbox runat="server" id="txtThoiHanHopDong" Width="150px" CssClass="input"></asp:textbox></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Nơi ký:&nbsp;</div>
			   <div style="width:210px;float:left;" ><asp:textbox runat="server" id="txtNoiKy" CssClass="input"></asp:textbox></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Chuyên môn:&nbsp;</div>
			   <div style="width:210px;float:left;" ><asp:textbox runat="server" id="txtChuyenMon" CssClass="input"></asp:textbox></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Mức lương cơ bản:&nbsp;</div>
			   <div style="width:210px;float:left;text-align:left;" ><asp:textbox runat="server"  id="txtMucLuongCoBan" Width="80px" CssClass="input" textAlign="right"></asp:textbox>
			   Hệ số<asp:textbox runat="server" id="txtHeSo" Width="30px" CssClass="input"></asp:textbox>
			   </div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Tổng LCB:&nbsp;</div>
			   <div style="width:210px;float:left;" ><asp:textbox runat="server" id="txtTongLCB" Width="150px" CssClass="input" ReadOnly="True"></asp:textbox></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Giờ làm:&nbsp;</div>
			   <div style="width:210px;float:left;" ><asp:textbox runat="server" id="txtGioLam" Width="150px" CssClass="input"></asp:textbox></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Mô tả công việc:&nbsp;</div>
			   <div style="width:210px;float:left;" ><asp:textbox runat="server" Width="200px" id="txtMoTaCongViec" CssClass="input"></asp:textbox></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Thử việc từ ngày:&nbsp;</div>
			   <div style="width:210px;float:left;" ><asp:textbox runat="server" id="txtThuViecTuNgay" Width="150px" CssClass="input"></asp:textbox></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Thử việc đến ngày:&nbsp;</div>
			   <div style="width:210px;float:left;" ><asp:textbox runat="server" id="txtThuViecDenNgay" Width="150px" CssClass="input"></asp:textbox></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Nơi làm việc:&nbsp;</div>
			   <div style="width:210px;float:left;" ><asp:textbox runat="server" id="txtDiaDiemLamViec" Width="200px" CssClass="input"></asp:textbox></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">Dụng cụ:&nbsp;</div>
			   <div style="width:210px;float:left;" ><asp:textbox runat="server" id="txtDungCu" Width="192px" CssClass="input"></asp:textbox></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:110px;float:left;text-align:right">TT khác:&nbsp;</div>
			   <div style="width:210px;float:left;" ><asp:textbox runat="server" id="txtThoaThuanKhac" Width="192px" CssClass="input"></asp:textbox></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:400px;float:left;padding-left:105px" >
                   <asp:checkbox runat="server" id="cbCoBaoHiem" Text="Có Bảo Hiểm"></asp:checkbox>
               </div>
			</div>												
			<div  class="tableBig-row" style="clear:left;text-align:center; width: 650px;">
			<div>
			    <div style="width:60px;float:left">
                    <asp:Button ID="btnLuu"  Width="50px" runat="server" Text="Lưu" OnClick="btnLuu_Click"  />
                </div>
                <div style="width:60px;float:left">
                    <asp:Button ID="btnMoi" Width="50px" runat="server" Text="Mới" OnClick="btnMoi_Click"  />
			    </div>
			    <div style="width:60px;float:left">
                    <asp:Button ID="btnXoan" Width="50px" runat="server" Text="Xóa" OnClick="btnXoan_Click"   />
			    </div>
			    <div style="width:60px;float:left">
                    <asp:Button ID="bntTim" Width="50px" runat="server" Text="Tìm" OnClick="bntTim_Click"   />
			    </div>
			    <div style="width:120px;float:left">
                    <asp:Button ID="btnXemHopDong" Width="96px" runat="server" Text="Xem hợp đồng" OnClick="btnXemHopDong_Click" />
			    </div>	
			  <div style="width:100px;float:left">
                    <asp:Button ID="btnExcel" Width="96px" runat="server" Text="Xuất Excel" OnClick="btnExcel_Click" />
			    </div>	

			    <div><asp:textbox runat="server" id="txtidHopDong" Width="10px" Visible="false"></asp:textbox></div>		    
			</div>
		</div>
		</div>
		<br />
		<div style="background-image:url(../images/menu.jpg);font-weight:bold;color:White;text-align:left;padding-left:10px">
		DANH SÁCH HỢP ĐỒNG NHÂN VIÊN
	</div>
	</div>
	<div style="padding-left:50px;height:25px" align="left">
        <asp:label runat="server" id="lbTongSoNV" text="Label" Font-Bold="True" ForeColor="Red"></asp:label>
	</div>
	
		<div  style="height:auto;width:auto">
		    <asp:GridView ID="gidHopDong" runat="server" Width="1200px" DataKeyNames="idhopdong" AutoGenerateColumns="False" OnRowDeleting="gidHopDong_RowDeleting" OnSelectedIndexChanging="gidHopDong_SelectedIndexChanging"
		    HeaderStyle-CssClass="HeaderStyle" CssClass="GridViewStyle" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle" >
<RowStyle CssClass="RowStyle"></RowStyle>
<Columns>
<asp:CommandField SelectText="Xem" ShowSelectButton="True"></asp:CommandField>
<asp:CommandField DeleteText="X&#243;a" ShowDeleteButton="True"></asp:CommandField>
<asp:BoundField DataField="STT" HeaderText="STT"></asp:BoundField>
<asp:BoundField DataField="masohopdong" HeaderText="M&#227; HĐ"></asp:BoundField>
<asp:BoundField DataField="SoHopDong1" HeaderText="Số HĐ"></asp:BoundField>
<asp:BoundField DataField="tenloaihopdong" HeaderText="Loại HĐ"></asp:BoundField>
<asp:BoundField DataField="tennhanvien" HeaderText="Nh&#226;n vi&#234;n"></asp:BoundField>
<asp:BoundField DataField="Loai" HeaderText="Loại"></asp:BoundField>
<asp:BoundField DataField="ngayky" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ng&#224;y k&#253;"></asp:BoundField>
<asp:BoundField DataField="ngaybatdau" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ng&#224;y bắt đầu"></asp:BoundField>
<asp:BoundField DataField="ngayketthuc" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ng&#224;y kết th&#250;c"></asp:BoundField>
<asp:BoundField DataField="noiky" HeaderText="Nơi k&#253;"></asp:BoundField>
<asp:BoundField DataField="chuyenmon" HeaderText="Chuy&#234;n m&#244;n"></asp:BoundField>
<asp:BoundField DataField="mucluongcoban" HeaderText="Tổng lương cơ bản"></asp:BoundField>
<asp:BoundField DataField="giolam" HeaderText="Giờ l&#224;m"></asp:BoundField>
<asp:BoundField DataField="motacongviec" HeaderText="M&#244; tả c&#244;ng việc"></asp:BoundField>
</Columns>

<PagerStyle CssClass="PagerStyle"></PagerStyle>

<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
</asp:GridView>            
		</div>	
		
	
</div>
    </form>
<!--#include file ="footer.htm"-->
