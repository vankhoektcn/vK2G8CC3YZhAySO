<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmListKhamBenh_XuatKhoa.aspx.cs"
    Inherits="frmListKhamBenh_XuatKhoa" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!--#include file ="../noitru/nvk_headerTongHop.htm"-->
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
		a
    {
         text-decoration:underline;
         color:blue;
         font-weight:bold;
    }
    a:hover
    {
         text-decoration:none;
        color:red;
        cursor:hand;
    }
		
	.LinkTheoDoi{
	    color : Green;
	    font: blold;
	}
</style>

<script language="javascript">
    
    var dp_cal1; 
      var dp_cal; 
	window.onload = function () 
	{
	    document.getElementById('<%=mabN.ClientID %>').focus();
//	    dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));
//	    dp_cal= new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
        if($.mkv.queryString("idkhoa")!="15")
        {
            $("#trTaiNan").css("display","none");
        }
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
	
	
function TABLE1_onclick() {



}
function OpenLinkKhamBenhCapCuu(dkmenu,idkhambenh)
	{
            window.open("../CapCuu/KhamTiepNhanCapCuu.aspx?dkmenu=Khong#idkhoachinh=" + idkhambenh + "");
            document.getElementById('divNoiDungKham').style.display='block';
	}
function OpenLinkKhamBenhKhoaSan(dkmenu,idkhambenh,loaiPhieukham)
	{
	    if(loaiPhieukham=="0")
            window.open("../KhoaSan/frm_Edit_DSBNdakham.aspx?dkmenu=Khong&idkhambenh=" + idkhambenh + "");
        else
            window.open("../CapCuu/KhamTiepNhanCapCuu.aspx?dkmenu=Khong#idkhoachinh=" + idkhambenh + "");
            document.getElementById('divNoiDungKham').style.display='block';
	}
function ClosedivNoiDungKham()
	{
            document.getElementById('divNoiDungKham').style.display='none';
	}
	function OpenLinkChiDinh(link)
	{
            window.open(link,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
            document.getElementById('divNoiDungKham').style.display='block';
	}
function nvk_InRaVien(str_loaiin,idctdkk,idkhambenh,idbenhnhan,idkhoa)
{
    if(str_loaiin=="Giấy RV")
        InPhieuRaVien(idkhambenh,idkhoa);
    else
        InPhieuChuyenVien(idctdkk,idbenhnhan,idkhoa);
}
function InPhieuRaVien(idkhambenh,idkhoa)
{
    //var link = "../noitru_BaoCao/rptRaVien_InDe.aspx?idphieutt="+idkhambenh+"&IdKhoa="+idkhoa+"#isPrint=1";
    var link = "../noitru_BaoCao/rptRaVien.aspx?idphieutt="+idkhambenh+"&IdKhoa="+idkhoa+"#isPrint=1";
    window.open(link,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
}
function InPhieuChuyenVien(idctdkk,idbenhnhan,idkhoa)
{
    var link = "../khambenh/frmGiayChuyenVien.aspx?idctdkk="+idctdkk+"&IdKhoa="+idkhoa+"#isPrint=1";
    window.open(link,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
}
//function InToaThuocRaVien(idkhambenh,idkhoa)// có trong nvk_ThuocVtyt oy
//{
//    window.open("../noitru_BaoCao/nvk_InToaXuatVien.aspx?IsToaRV=1&IdKhamBenh="+idkhambenh,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');  

//}
</script>

<form id="Form1" method="post" runat="server">
    <asp:scriptmanager runat="server" id="script1"></asp:scriptmanager>
    <%-- <asp:updatepanel runat="server" id="script2"><ContentTemplate>--%>
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: #C0C0C0">
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8; height: 10px;">
                <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px">
                            <table id="user" cellspacing="1" cellpadding="1" width="100%" border="0" class="khung">
                                <tr>
                                    <td class="title" align="center" style="background-color: #4D67A2; height: 25px;">
                                        <strong><span class="title" id="spHeader" runat="server" style="color: #FFFFFF; font-weight: bold">
                                            DANH SÁCH BỆNH NHÂN XUẤT KHOA</span></strong></td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table cellpadding="0" width="100%" border="2" bordercolor="white">
                                            <tr>
                                                <td valign="top" align="center" width="100%" style="height: 133px">
                                                    <label runat="server" id="lbKhoa">
                                                        Khoa:</label>
                                                    &nbsp;&nbsp;
                                                    <asp:dropdownlist id="ddlPK" runat="server" autopostback="true" width="153px" onselectedindexchanged="ddlPK_SelectedIndexChanged"></asp:dropdownlist>
                                                    Từ ngày :
                                                    <asp:textbox id="txtTuNgay" runat="server" onfocus="$(this).datepick();" onblur="nvk_testDate_this(this);"
                                                        tabindex="1" width="77px"></asp:textbox>
                                                    &nbsp; Đến ngày: &nbsp;<asp:textbox id="txtDenNgay" runat="server" onfocus="$(this).datepick();"
                                                        onblur="nvk_testDate_this(this);" tabindex="1" width="73px"></asp:textbox>
                                                    &nbsp; &nbsp;
                                                    <%--<br />
                                        &nbsp; &nbsp;
													  Nội dung khám: &nbsp;&nbsp;--%>
                                                    <asp:dropdownlist id="ddndk" visible="false" runat="server" autopostback="true" width="153px"
                                                        onselectedindexchanged="ddndk_SelectedIndexChanged"></asp:dropdownlist>
                                                    <%--&nbsp; &nbsp;
													  Phòng: &nbsp;&nbsp;--%>
                                                    <asp:dropdownlist id="ddlPhong" visible="false" runat="server" autopostback="false"
                                                        width="153px"></asp:dropdownlist>
                                                    <br />
                                                    &nbsp; &nbsp;Mã BN: &nbsp;&nbsp;
                                                    <asp:textbox id="mabN" runat="server"></asp:textbox>
                                                    &nbsp; &nbsp;Tên BN: &nbsp;&nbsp;
                                                    <asp:textbox id="tenbN" runat="server"></asp:textbox>
                                                    &nbsp; &nbsp;Số vào viện: &nbsp;&nbsp;
                                                    <asp:textbox id="soVaoVien" width="50px" runat="server"></asp:textbox>
                                                    &nbsp; &nbsp; &nbsp;<asp:label id="lbLoaiBN" runat="server" text="Loại BN"></asp:label>
                                                    <asp:dropdownlist id="cbLoaiBN" runat="server" autopostback="true" width="92px"></asp:dropdownlist>
                                                    &nbsp; &nbsp;<asp:label id="lbLoaiXuat" runat="server" text="Hướng điều trị"></asp:label>
                                                    <asp:dropdownlist id="ddlHuongDT" runat="server" autopostback="false" width="150px"></asp:dropdownlist>
                                                    &nbsp; &nbsp; &nbsp;&nbsp;<asp:button id="btnGetList" runat="server" onclick="btnGetList_Click"
                                                        text="Lấy danh sách" width="112px" />&nbsp;
                                                    <br />
                                                    <strong>Kết quả tìm kiếm: </strong>
                                                    <br />
                                                    <table border="true">
                                                        <tr>
                                                            <td  style="width: 100px">
                                                                <asp:label id="Label1" runat="server" text="Tổng số bệnh nhân: " width="138px"></asp:label>
                                                            </td>
                                                            <td  style="width: 47px">
                                                                <asp:textbox id="txtSLBN" runat="server" width="48px"></asp:textbox>
                                                            </td>
                                                            <td  style="width: 73px;text-align:right;">
                                                                <asp:label id="Label2" runat="server" text="Bảo hiểm: "></asp:label>
                                                            </td>
                                                            <td  style="width: 48px">
                                                                <asp:textbox id="txtSLKBH" runat="server" width="48px"></asp:textbox>
                                                            </td>
                                                            <td  style="width: 95px;text-align:right;">
                                                                <asp:label id="Label3" runat="server" text="Thường: "></asp:label>
                                                            </td>
                                                            <td  style="width: 45px">
                                                                <asp:textbox id="txtSLKT" runat="server" width="48px"></asp:textbox>
                                                            </td>
                                                            <td  style="width: 100px;text-align:right;">
                                                                <asp:label id="Label4" runat="server" text="Dịch vụ: "></asp:label>
                                                            </td>
                                                            <td  style="width: 48px">
                                                                <asp:textbox id="txtSLKDV" runat="server" width="48px"></asp:textbox>
                                                            </td>
                                                        </tr>
                                                        <tr id="trTaiNan">
                                                            <td  style="width: 100px">
                                                                <asp:label id="Label11" runat="server" text="Tai nạn giao thông: " width="138px"></asp:label>
                                                            </td>
                                                            <td  style="width: 47px">
                                                                <asp:textbox id="txtTNGT" runat="server" width="48px"></asp:textbox>
                                                            </td>
                                                            <td  style="width: 73px;text-align:right;">
                                                                <asp:label id="Label21" runat="server" text="Tai nạn SH: "></asp:label>
                                                            </td>
                                                            <td  style="width: 48px">
                                                                <asp:textbox id="txtTNSH" runat="server" width="48px"></asp:textbox>
                                                            </td>
                                                            <td  style="width: 95px;text-align:right;">
                                                                <asp:label id="Label31" runat="server" text="Bị đánh, chém: "></asp:label>
                                                            </td>
                                                            <td  style="width: 45px">
                                                                <asp:textbox id="txtBdBc" runat="server" width="48px"></asp:textbox>
                                                            </td>
                                                            <td  style="width: 57px;text-align:right;">
                                                                <asp:label id="Label41" runat="server" text="Tai Nạn khác: "></asp:label>
                                                            </td>
                                                            <td  style="width: 48px">
                                                                <asp:textbox id="txtTNKhac" runat="server" width="48px"></asp:textbox>
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
                                                    DANH SÁCH XUẤT KHOA</td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="center" width="100%" colspan="2" height="20">
                                                    <asp:datagrid id="dgr" tabindex="12" runat="server" width="100%" allowsorting="True"
                                                        autogeneratecolumns="False" datakeyfield="IdKhamBenh" borderwidth="1px" bordercolor="#3366CC"
                                                        cellpadding="4" onitemcommand="dgr_ItemCommand" backcolor="White" borderstyle="None"
                                                        allowpaging="True" onpageindexchanged="dgr_PageIndexChanged" pagesize="20" onitemdatabound="dgr_ItemDataBound">
<FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

<SelectedItemStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True"></SelectedItemStyle>

<PagerStyle Mode="NumericPages" BackColor="#99CCCC" ForeColor="#003399" Font-Size="Small" Font-Names="Arial" HorizontalAlign="Left"></PagerStyle>

<AlternatingItemStyle CssClass="dgrSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></AlternatingItemStyle>

<ItemStyle BackColor="White" ForeColor="#003399" CssClass="dgrNoSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle BackColor="#C0C0FF" ForeColor="Blue" CssClass="dgrHeader" HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
                <%--<asp:LinkButton id="lbtnChiTiet" runat="server" CommandName="Edit" CommandArgument='<%# Eval("idchitietdangkykham") %>' width="40px" CssClass="alink3">Chi tiết</asp:LinkButton> --%>
    <a onclick="nvk_TuyChinhXuatKhoa(<%#Eval("idbenhnhan") %>,<%#Eval("idchitietdangkykham") %>,<%#Eval("idkhambenhXK") %>,<%#Eval("nvk_idkhoa")%>,0)" >Cập nhật</a>
                </ItemTemplate>
                </asp:TemplateColumn>
<asp:TemplateColumn>
    <ItemTemplate>
    <asp:LinkButton id="lbtnTheoDoi" runat="server" CommandName="TheoDoi" Text='Theo Dõi' CommandArgument='<%# Eval("idkhambenhXK") %>' width="55px" CssClass="LinkTheoDoi"></asp:LinkButton> 
    </ItemTemplate>                
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
                <asp:LinkButton id="lbtnTraBA" runat="server" CommandName="TraBenhAn" Text='<%# Eval("TraBenhAn")%>' CommandArgument='<%# Eval("idkhambenhXK") %>' width="50px" CssClass="alink3"></asp:LinkButton> 
                </ItemTemplate>                
                </asp:TemplateColumn>
<asp:BoundColumn DataField="STT" HeaderText="STT"></asp:BoundColumn>
<asp:BoundColumn DataField="sovaovien" HeaderText="Số vào viện"></asp:BoundColumn>
<asp:BoundColumn DataField="NgayKham" HeaderText="Ngày xuất" DataFormatString="{0:dd/MM/yyyy HH:mm}"></asp:BoundColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<ItemStyle Wrap="True"></ItemStyle>

<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="15%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NamSinh" HeaderText="Năm sinh">
<HeaderStyle Width="5%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="GioiTinh" HeaderText="Giới tính">
<HeaderStyle Width="3%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="LoaiBN" HeaderText="Loại BN"></asp:BoundColumn>
<asp:BoundColumn DataField="SOBHYT" HeaderText="Số BHYT"></asp:BoundColumn>
<%--<asp:BoundColumn DataField="KHOAChuyen" HeaderText="Khoa xuất">
<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="15%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
--%><asp:BoundColumn DataField="KHOADen" HeaderText="Nơi đến"></asp:BoundColumn>

<asp:TemplateColumn><ItemTemplate>
    <%--<asp:LinkButton id="lbtnInGiayHDT" runat="server" CommandName="InRaVien" Text='<%# Eval("InRaVien")%>' CommandArgument='<%# Eval("idkhambenhXK") %>' width="55px" CssClass="alink3"></asp:LinkButton> --%>
    <a  onclick="nvk_InRaVien('<%#Eval("InRaVien") %>',<%#Eval("idchitietdangkykham") %>,<%#Eval("idkhambenhXK") %>,<%#Eval("idbenhnhan") %>,<%#Eval("nvk_idkhoa")%>)" ><%#Eval("InRaVien") %></a>&nbsp;
  </ItemTemplate>                
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
    <%--<asp:LinkButton id="lbtnToaRaVien" runat="server" CommandName="InToaRaVien" Text='<%# Eval("InToaRaVien")%>' CommandArgument='<%# Eval("idkhambenhXK") %>' width="55px" CssClass="alink3"></asp:LinkButton> --%>
    <a  onclick="InToaThuocRaVien(<%#Eval("idkhambenhXK") %>,<%#Eval("nvk_idkhoa")%>)" ><%#Eval("InToaRaVien")%></a>&nbsp;
                </ItemTemplate>                
</asp:TemplateColumn>
<asp:BoundColumn DataField="IsNoiTru" HeaderText="Loại ĐTrị"></asp:BoundColumn>
</Columns>
</asp:datagrid>
                                                    &nbsp;
                                                    <br />
                                                    <asp:panel id="pnlDV" runat="server" width="100%"><BR /></asp:panel>
                                                    <br />
                                                    <asp:panel id="pnlKB" runat="server" width="100%"></asp:panel>
                                                    <asp:panel id="pnlCLS" runat="server" width="100%"></asp:panel>
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
    <%-- /////
  /////--%>
    <div style="display: none; position: fixed; top: 15%; bottom: 15%; left: 10%; width: 80%;
        background-color: White; z-index: 1000; padding: 10px 10px 10px 10px; border: 10px solid #4D67A2;
        overflow-y: scroll;" id="divNoiDungKham" runat="server">
        <table style="text-align: left;" border="1" cellpadding="3" cellspacing="0" bordercolor="black">
            <tr>
                <td width="100px">
                    Mã bệnh nhân</td>
                <td width="200px">
                    <asp:label forecolor="blue" id="lbMaBN" runat="server"></asp:label>
                </td>
                <td width="100px">
                    Tên bệnh nhân</td>
                <td width="200px">
                    <asp:label forecolor="blue" id="lbTenBenhNhan" runat="server"></asp:label>
                </td>
            </tr>
            <tr>
                <td>
                    Địa chỉ</td>
                <td colspan="3">
                    <asp:label forecolor="blue" id="lbDiaChi" runat="server"></asp:label>
                </td>
            </tr>
        </table>
        <span class="title">Thông tin chi tiết điều trị</span>
        <table>
            <tr>
                <td>
                    <asp:label runat="server" id="lblTenBN"></asp:label>
                </td>
                <%--<td style="padding-left:20%"><asp:label runat="server" id="lblDC"></asp:label></td>--%>
            </tr>
        </table>
        <asp:datagrid id="dgrChiTietChild" visible="false" tabindex="11" runat="server" width="100%"
            onpageindexchanged="PageIndexStyleChanged" allowpaging="False" cellpadding="2"
            onitemcommand="dgrChiTietChild_ItemCommand" bordercolor="Silver" borderwidth="1px"
            datakeyfield="idkhambenh" autogeneratecolumns="false" allowsorting="True">
              <Columns> 
                <asp:TemplateColumn><ItemTemplate>
                <asp:LinkButton id="lbtnEdit1" runat="server" CommandName="EditKhamBenh" CommandArgument='<%# Eval("idkhambenh") %>' width="40px" CssClass="alink3">Sửa PK</asp:LinkButton> 
                </ItemTemplate>
                <HeaderStyle Width="10%"></HeaderStyle>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Lan" HeaderText="Số lần chỉ đinh">
            <HeaderStyle Width="30%"></HeaderStyle>

            <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
            <asp:BoundColumn DataField="ngaykham" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Ngày tháng">
            <HeaderStyle Width="30%"></HeaderStyle>

            <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
                         
             <asp:BoundColumn DataField="maphieukham" HeaderText="Phiếu khám">
            <HeaderStyle Width="30%"></HeaderStyle>

            <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

            <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedItemStyle>

            <PagerStyle Mode="NumericPages" HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

            <ItemStyle ForeColor="#000066"></ItemStyle>

            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>
    </asp:datagrid>
        <br />
        <%--<span class="title">Thông tin toa thuốc</span>--%>
        <br />
        <asp:button id="btnHuyXuatKhoa"  runat="server" text="Hủy chỉ định xuất khoa" width="170px" onclick="btnHuyXuatKhoa_click" />
        <input type="button" value="Đóng" onclick="ClosedivNoiDungKham();" />
        <input id="hdidkhamBenh1311" type="hidden" runat="server" />
        <input id="hdidkhoa1411" type="hidden" runat="server" />
        <input id="hdidbenhnhan1411" type="hidden" runat="server" />
        <input id="hdIdChiTietDangKyKham" type="hidden" runat="server" />
    </div>
    <div style="display:none;position:fixed;top:10%;bottom:5%;left:2%;width:94%;background-color:White;z-index:1000;padding:10px 10px 10px 10px;border:10px solid #4D67A2;overflow-y:scroll" id="nvkDivGFather" >
        <div style="width:100%;height:5%;background: url(../images/bgmenu.gif) repeat;">
            <span align="left" style="float:left;padding-top:2px;padding-left:10px;cursor:pointer;font-weight:bold;" onmousedown="mouseDown('nvkDivGFather')" onmouseup="mouseRelease()">Thông Tin Xuất Khoa</span>
            <span style="float:right"><img src="../images/close.gif" align="right" style="width:25px;height:25px;" title="click vào để đóng danh sách" onclick="hideDivG_BN('nvkDivGFather')" style="cursor:pointer;"></span>
        </div>
        <div id="Div1" style="width:100%;height:95% !inportant;">
        <div id="nvk_divBN" style="width:100%;height:10% !inportant;">
        </div>
        <div id="nvk_divChua" style="width:100%;height:90%;">
        </div>
        </div>
        <input id='btnHuyXK' type='button' value='Hủy xuất khoa' style='width:110px;color:Red' onclick='btnHuyXk_click()'/>
    </div>
    <%--</ContentTemplate>
</asp:updatepanel>--%>
</form>
<script type="text/javascript">  

function nvk_TuyChinhXuatKhoa(idbenhnhan,idctdkk,idkhambenh,idkhoa,HdtID)
{
     var PathUrl="../ajax/nvk_TienGiuongPhongSanh_ajax.aspx?do=TT_BenhnhanXuatKhoa&idkhoa="+queryString("idkhoa")+"&idctdkk="+idctdkk+""
        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            var divG=document.getElementById("nvkDivGFather");
                            divG.style.display="block";                            
                            document.getElementById("nvk_divBN").innerHTML=value;
                            $.mkv.queryString("idctdkk",idctdkk);
    document.getElementById("hdIdChiTietDangKyKham").value=idctdkk;
    document.getElementById("hdidbenhnhan1411").value=idbenhnhan;
    document.getElementById("hdidkhoa1411").value=idkhoa;
                            loadInfoXuatKhoa(idbenhnhan,idctdkk,idkhoa,HdtID);
                        }
                });
}
function LoadNoiDungHuongDieuTri(idbenhnhan,idctdkk,idkhoa)
{
    var HdtID=document.getElementById("slHuongDieuTri").value;
    loadInfoXuatKhoa(idbenhnhan,idctdkk,idkhoa,HdtID)
}
function loadInfoXuatKhoa(idbenhnhan,idctdkk,idkhoa,HdtID)
{
    var idhuongdieutri=HdtID;
        if(HdtID ==null)
        {
            idhuongdieutri="0";
        $("#nvk_divChua").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load thông tin xuất khoa.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        }
        var PathUrl="../ajax/nvk_khamTongHop_ajax.aspx?do=LoadThongTinXuatKhoa&idbenhnhan="+idbenhnhan+"&idctdkk="+idctdkk+"&IdKhoaNoiTru="+idkhoa+"&hdtQueRy="+idhuongdieutri+"&SuaXK=1";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                        document.getElementById('nvk_divChua').innerHTML=value;
                        }
                });
}
function btnHuyXk_click()
{
    var idbenhnhan=$("#hdidbenhnhan1411").val();
    var idctdkk=$("#hdIdChiTietDangKyKham").val();
    var idkhoa=$("#hdidkhoa1411").val();
    //alert(idctdkk+";"+idbenhnhan+";"+idkhoa+"");
    //return;
    var Path="../ajax/nvk_khamTongHop_ajax.aspx?do=nvkHuyChiDinhXuatKhoa&idbenhnhan="+idbenhnhan+"&idctdkk="+idctdkk+"&idkhoa="+idkhoa+"";
    $.ajax
        ({
            type:"GET",
            cache:false,
            url:Path,
            success: function (value)
                {
                    if(value== "1")
                    {
                        alert("Đã hủy lệnh xuất khoa !");
                        hideDivG_BN("nvkDivGFather");
                        $("#btnGetList").click();
                    }
                    else
                        alert("Lỗi không thể hủy lệnh xuất khoa !");
                }
        });
}
function hideDivG_BN(divname)
{
    document.getElementById(divname).style.display="none";
    $.mkv.removeQueryString('idctdkk');
}
</script>
<!--#include file ="footer.htm"-->
