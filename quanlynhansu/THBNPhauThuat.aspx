<%@ Page Language="C#" AutoEventWireup="true" CodeFile="THBNPhauThuat.aspx.cs" Inherits="THBNPhauThuat" %>

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
                    BẢNG TỔNG HỢP BỆNH NHÂN PHẨU THUẬT</div>
            </strong></span>
        </div>
        <br />
        <div style="text-align: center; width: 900px">
            <table rules="groups" style="width: 750px; background-color:#99b0cb">
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
                        <td style="padding-left: 10px; width: 5%;" valign="top" align="right">
                            <p class="ptext">
                                Từ ngày&nbsp;:
                            </p>
                        </td>
                        <td style="padding-right: 0px; width: 3%;" valign="top" align="left">
                            <p class="ptext">
                                &nbsp;&nbsp;
                                <asp:textbox id="txttungay" runat="server"></asp:textbox>
                            </p>
                        </td>
                        <td style="padding-right: 2px; width:5%;" valign="top" align="right">
                            <p class="ptext">
                                Đến ngày :
                            </p>
                        </td>
                        <td style="padding-right: 0px; width:5%;" valign="top" align="left">
                            <p class="ptext">
                                &nbsp;<asp:textbox id="txtdenngay" runat="server"></asp:textbox>
                                &nbsp;&nbsp;&nbsp;
                            </p>
                        </td>
                        <td style="padding-right: 2px; width:5%;" valign="top" align="right">
                            <p class="ptext">
                                Phòng ban:
                            </p>
                        </td>
                        <td style="padding-right: 0px; width:10%;" valign="top" align="left">
                            <p class="ptext">
                                        <asp:dropdownlist id="ddlPhong" runat="server"></asp:dropdownlist>
                                &nbsp;&nbsp;&nbsp;&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 0px; width: 40%;" valign="top" align="left" colspan="6">
                            <p class="ptext">
                                &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:button id="btnGetDanhSach" onclick="btnGetDanhSach_Click" runat="server" cssclass="input"
                                    width="102px" text="Lấy danh sách" TabIndex="4"></asp:button>
                                &nbsp;
                            </p>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br />
    </div>
        <br />
</form>
<!--#include file ="footer.htm"-->
