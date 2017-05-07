<%@ Page Language="C#" MasterPageFile="../MasterPage_new.master" AutoEventWireup="true"
    CodeFile="frmTheKho.aspx.cs" Inherits="QLDUOC_Web_frmTheKho" Title="Thẻ kho" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript">
    function ChonSanPham(obj){
        $(obj).unautocomplete().autocomplete("../ajax/frm_PhieuNhapKho_ajax.aspx?do=ChonSanPham&LoaiThuocID="+document.getElementById('ctl00_body_chbLoaiThuoc').value,
        {formatItem: function(data) {
                return data[0];
            },width:300,scroll:true}
        );
        
        }
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
	
	function checkvalid()
	{
	    var tungay = document.getElementById("txtTuNgay");
	    var denngay = document.getElementById("txtDenNgay");
	    var kho = document.getElementById("ddlkho");
	    var thuoc = document.getElementById("ddlthuoc");
	    if(tungay.value == "")
	    {
	        alert("Vui lòng chọn ngày!");
	        tungay.focus();
	        return false;
	    }
	    if(denngay.value == "")
	    {
	        alert("Vui lòng chọn ngày!");
	        denngay.focus();
	        return false;
	    }
	 
	    return true;
	}
    </script>

    <style>
        .div-Out
        {
            width:300px;
        }
        .div-Out p, .div-Out .div-Right {
width: 60%;
float: right;
border-left: 1px solid #EFEFEF;
padding: 0px 0px 10px 20px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Thẻ kho")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TuNgay")%>
                </h4>
                <p>
                    <asp:TextBox ID="txtTuNgay" runat="server" TabIndex="1" Width="118px" onfocus="chuyenphim(this);$(this).datepick();"></asp:TextBox>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DenNgay")%>
                </h4>
                <p>
                    <asp:TextBox ID="txtDenNgay" runat="server" TabIndex="1" Width="118px" onfocus="chuyenphim(this);$(this).datepick();"></asp:TextBox>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho")%>
                </h4>
                <p style="width: 80%">
                    <asp:DropDownList ID="ddlkho" runat="server" AutoPostBack="False" Width="180px">
                    </asp:DropDownList>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đối tượng")%>
                </h4>
                <p>
                    <asp:DropDownList ID="chbLoaiThuoc" runat="server" Width="127px" AutoPostBack="True">
                    </asp:DropDownList>
                </p>
            </div>
            <div class="div-Out" style="width: 833px">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên")%>
                </h4>
                <p style="width: 85.8%">
                    <asp:TextBox ID="txtTenThuoc" runat="server" onfocus="ChonSanPham(this);" Width="250px"></asp:TextBox>
                    <asp:Button ID="btnTim" runat="server" OnClientClick="return checkvalid();" Text="xuất report"
                        OnClick="btnTim_Click" Width="102px" />*.Lưu ý: các định dạng ngày tháng (dd/MM/yyyy)
                </p>
            </div>
        </div>
        <div style="clear: both" align="center">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" PrintMode="ActiveX" DisplayGroupTree="False"
                runat="server" AutoDataBind="true"></CR:CrystalReportViewer>
        </div>
    </div>
</asp:Content>
