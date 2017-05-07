<%@ Page Language="C#" AutoEventWireup="true" CodeFile="THNgayCong.aspx.cs" Inherits="THNgayCong" %>

<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
    <link rel="stylesheet" type="text/css" href="js/epoch_styles.css" />
<!--#include file ="header.htm"-->

<script type="text/javascript" src="js/jsNhanSu.js"></script>
    <!--Epoch's styles-->

    <script type="text/javascript" src="js/epoch_classes.js"></script>

    <!--Epoch's Code-->
<script type="text/javascript">
 var dp_cal, dp_cal1;      
	window.onload = function () 
	{
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));
	    dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
	};
 function CheckAll(Ctl, GridName, BeginIndex, EndIndexExt, GridCtl)
{
	var value = document.getElementById(Ctl).checked;
	
	var i;
	count = document.getElementById(GridName).rows.length;	
	if (count >1 )
	{
	
		for (i=BeginIndex; i<document.getElementById(GridName).rows.length + EndIndexExt; i++)
		{
		
		    if(i<=9)
		    {
		     
		        if(document.frmBSPK(GridName + "_ctl0" + i + "_" + GridCtl).disabled==false)
			    {
			    
				    document.frmBSPK(GridName + "_ctl0" + i + "_" + GridCtl).checked = value;	
			    }   
		    }
		    else
		    {
		        if(document.frmBSPK(GridName + "_ctl" + i + "_" + GridCtl).disabled==false)
			    {
				    document.frmBSPK(GridName + "_ctl" + i + "_" + GridCtl).checked = value;	
			    }    
		    }
		}
	}
}

</script>

<form id="frmBSPK" method="post" runat="server">
    <div style="background-color: #C0C0C0">
        <div style="background-color: #FBF8F1; padding-left: 20px; text-align: left">
            <uc1:uscmenu ID="Uscmenu1" runat="server" />
        </div>
        <br />
        <div style="background-color: #4D67A2; height: auto; text-align: left; width: 100%">
            <span style="color: #ffffff; font-size: 14pt;"><strong>
                <div style="margin-top: 5px">
                    BẢNG TỔNG HỢP NGÀY CÔNG</div>
            </strong></span>
        </div>
        <br />
        <div style="text-align: center; width: 900px">
            <table rules="groups" style="width: 864px; background-color:#99b0cb">
                <%--<tr>
                    <td style="width: 100%;" align="center">
                    <br />
                        <asp:label id="lblPhong" runat="server" text="Chọn phòng ban : "></asp:label>
                        <asp:dropdownlist id="ddlPhongBan" tabIndex=1 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPhongBan_SelectedIndexChanged" width="212px" CssClass="input"></asp:dropdownlist>
                        &nbsp;
                        <asp:label id="lblBSi" runat="server" text="Chọn Nhân Viên : "></asp:label>
                        <asp:dropdownlist id="ddlNhanVien" runat="server" width="222px" autopostback="True"
                            onselectedindexchanged="ddlNhanVien_SelectedIndexChanged"></asp:dropdownlist>
                        &nbsp;
                        <br />
                    </td>
                </tr>--%>
                <tbody>
                    <tr>
                        <td style="padding-left: 10px; width: 1%;" valign="top" align="right">
                            <p class="ptext">
                                Tháng&nbsp;:
                            </p>
                        </td>
                        <td style="padding-right: 0px; width: 2%;" valign="top" align="left">
                            <p class="ptext">
                               <asp:dropdownlist id="ddlThang" runat="server"></asp:dropdownlist>
                                &nbsp;
                            </p>
                        </td>
                        <td style="padding-right: 2px; width:1%;" valign="top" align="right">
                            <p class="ptext">
                                Năm :
                            </p>
                        </td>
                        <td style="padding-right: 0px; width:2%;" valign="top" align="left">
                            <p class="ptext">
                                        <asp:dropdownlist id="ddlNam" runat="server"></asp:dropdownlist>
                                &nbsp;&nbsp;&nbsp;
                            </p>
                        </td>
                        <td style="padding-right: 2px; width:2%;" valign="top" align="right">
                            <p class="ptext">
                                Phòng ban:
                            </p>
                        </td>
                        <td style="padding-right: 0px; width:10%;" valign="top" align="left">
                            <p class="ptext">
                                        <asp:dropdownlist id="ddlPhong" runat="server" Width="200px"></asp:dropdownlist>
                                &nbsp;&nbsp;&nbsp; Loại NV :<asp:dropdownlist id="ddlLoaiNV" runat="server" Width="120px"><asp:ListItem Value="-1">----Chọn loại NV----</asp:ListItem>
<asp:ListItem Value="0">Thường xuy&#234;n</asp:ListItem>
<asp:ListItem Value="1">Kh&#244;ng thường xuy&#234;n</asp:ListItem>
</asp:dropdownlist></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 70px; width: 40%; height: 29px;" valign="top" align="right" colspan="6">
                            <p class="ptext">
                                &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:button id="btnGetDanhSach" onclick="btnGetDanhSach_Click" runat="server" cssclass="input"
                                    width="102px" text="Lấy danh sách" ></asp:button>
                                &nbsp;
                            </p>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br />
        <div style="background-color: #4D67A2; height: auto; text-align: left; width: 100%"">
        <%--//////////////
        //////////////
        ///////////// --%>  
        <div style="background-color: #003399; height: auto; text-align: left; width: 100%">
            <span style="color: #ffffff; font-size: 14pt;"><strong>
                <div style="margin-top: 5px">
                    BẢNG TỔNG HỢP NGÀY CÔNG VÀ TIỀN LƯƠNG&nbsp;&nbsp; <asp:Label id="lbThangNam" runat="server" Text=""></asp:Label></div>
            </strong></span>
        </div>
         <asp:DataGrid id="dgr" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False" DataKeyField="idnhanvien" BorderWidth="1px" BorderColor="#3366CC" CellPadding="4" BackColor="White" BorderStyle="None">
<FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

<SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedItemStyle>

<PagerStyle Mode="NumericPages" HorizontalAlign="Left" BackColor="#99CCCC" Font-Names="Arial" Font-Size="Small" ForeColor="#003399"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" BackColor="White" CssClass="dgrNoSelectItem" ForeColor="#003399"></ItemStyle>
<Columns>
<asp:BoundColumn DataField="STT" HeaderText="STT">
<HeaderStyle Wrap="False" Width="2%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="idnhanvien" HeaderText="idnhanvien" Visible="False"></asp:BoundColumn>
<asp:BoundColumn DataField="tennhanvien" HeaderText="T&#234;n Nh&#226;n Vi&#234;n">
<HeaderStyle Wrap="False" Width="8%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NgayThuong" HeaderText="Ngày thường">
<HeaderStyle Wrap="True" Width="3%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NgayTruc" HeaderText="Ngày trực">
<HeaderStyle Wrap="True" Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SoNgayPK"  HeaderText="Phép không lương">
<HeaderStyle Wrap="True" Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SoNgayPC" HeaderText="Phép có lương">
<HeaderStyle Wrap="True" Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="NgayNuaBuoi"  HeaderText="Làm thêm 1/2 buổi">
<HeaderStyle Wrap="True" Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>


<asp:BoundColumn DataField="LamThemMotNgay"  HeaderText="Làm thêm 1 ngày">
<HeaderStyle Wrap="True" Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="NghiOm"  HeaderText="Nghỉ ốm">
<HeaderStyle Wrap="True" Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="NghiBu"  HeaderText="Nghỉ bù">
<HeaderStyle Wrap="True" Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="NghiLe"  HeaderText="Nghỉ lễ">
<HeaderStyle Wrap="True" Width="4%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="NgoaiGio"  HeaderText="Ngoài giờ">
<HeaderStyle Wrap="True" Width="4%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="PhepNam"  HeaderText="Phép năm còn lại">
<HeaderStyle Wrap="True" Width="4%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" height="20px" BackColor="white" CssClass="dgrHeader" Font-Bold="True" ForeColor="Blue"></HeaderStyle>
</asp:DataGrid> 
<br />
<asp:Button id="btnExcel" runat="server" visible="true" Text="Xuất Excel" OnClick="btnExcel_Click"></asp:Button> 
            <asp:button id="btnLuuPhuCap" visible="false" runat="server" onclick="btnLuuPhuCap_Click" text="Lưu phụ cấp"
                width="92px" />
            <%--/////////////
        /////////////
        ////////////--%></div>
    </div>
        <div style="text-align: center; width: 900px">
            <asp:panel id="pnl1" runat="server" visible="false" width="100%">&nbsp; <DIV style="WIDTH: 100%; TEXT-ALIGN: center">&nbsp;<asp:Button id="btnMoi" onclick="btnMoi_Click" runat="server" Width="82px" __designer:wfdid="w3" Text="Mới"></asp:Button> </DIV></asp:panel>
            <input id="txtIdNhanVienHd" runat="server" type="hidden" />
            <INPUT id="txtThangHidden" type=hidden name="txtThangHidden" runat="server" /> 
<INPUT id="txtNamHidden" type=hidden name="txtNamHidden" runat="server" />
        </div>
        <br />
</form>
<!--#include file ="footer.htm"-->
