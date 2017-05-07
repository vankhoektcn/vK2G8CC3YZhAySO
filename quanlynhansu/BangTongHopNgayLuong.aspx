<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BangTongHopNgayLuong.aspx.cs" Inherits="BangTongHopNgayLuong" %>

<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->

<script type="text/javascript" src="js/jsNhanSu.js"></script>

<script type="text/javascript">
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
                    Bảng tổng hợp tiền lương</div>
            </strong></span>
        </div>
        <br />
        <div style="text-align: center; width: 900px">
            <table rules="groups" style="width: 700px" bgcolor="#99b0cb">
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
                        <td style="height: 10px" colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px; width: 13%; height: 41px" valign="top" align="left">
                            <p class="ptext">
                                Phòng&nbsp;
                            </p>
                        </td>
                        <td style="padding-right: 0px; width: 25%; height: 41px" valign="top" align="left">
                            <p class="ptext">
                                <asp:dropdownlist id="ddlPhongBan" tabindex="1" runat="server" cssclass="input" width="100%"
                                     autopostback="True">
                                                                                 </asp:dropdownlist>
                                &nbsp;
                            </p>
                        </td>
                        <td style="padding-right: 0px; width: 25%; height: 41px;padding-left:10px" valign="top" align="left" colspan="2">
                           Loại NV :<asp:dropdownlist id="ddlLoaiNV" runat="server" Width="156px"><asp:ListItem Value="-1">----Chọn loại NV----</asp:ListItem>
                            <asp:ListItem Value="0">Thường xuy&#234;n</asp:ListItem>
                            <asp:ListItem Value="1">Kh&#244;ng thường xuy&#234;n</asp:ListItem>
                            </asp:dropdownlist>
                        </td>
                       
                    </tr>
                    <tr>
                        <td style="padding-left: 10px; width: 13%; height: 41px" valign="top" align="left">
                            <p class="ptext">
                                Tháng&nbsp;:</p>
                        </td>
                        <td style="padding-right: 0px; width: 25%; height: 41px" valign="top" align="left">
                            <p class="ptext">
                                <asp:dropdownlist id="ddlThang" tabindex="2" runat="server" width="23%"><asp:ListItem Value="1">1</asp:ListItem>
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
</asp:dropdownlist>
                                &nbsp;&nbsp;&nbsp;&nbsp;Năm&nbsp;
                                <asp:dropdownlist id="ddlNam" tabindex="3" runat="server" width="35%"></asp:dropdownlist>
                            </p>
                        </td>
                        <td style="padding-right: 2px; width: 12%; height: 41px" valign="top" align="right">
                            <p class="ptext">
                            </p>
                        </td>
                        <td style="padding-right: 0px; width: 40%; height: 41px" valign="top" align="left">
                            <p class="ptext">
                                &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:button id="btnGetDanhSach" runat="server" cssclass="input"
                                    width="102px" text="Lấy danh sách" TabIndex="4" OnClick="btnGetDanhSach_Click"></asp:button>
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
    
        
<br />

   </div>
    </div>
        <div style="text-align: center; width: 900px">
            <asp:panel id="pnl1" runat="server" visible="false" width="100%">&nbsp; <DIV style="WIDTH: 100%; TEXT-ALIGN: center"> </DIV></asp:panel>
            <input id="txtIdNhanVienHd" runat="server" type="hidden" />
            <INPUT id="txtThangHidden" type=hidden name="txtThangHidden" runat="server" /> 
<INPUT id="txtNamHidden" type=hidden name="txtNamHidden" runat="server" />
        </div>
        <br />
</form>
<!--#include file ="footer.htm"-->
