<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frTongHopKQKhamSucKhoeTheoCty.aspx.cs"
    Inherits="thongke_frTongHopKQKhamSucKhoeTheoCty" %>

<!--#include file ="header.htm"-->

<script src="../js/timepicker.js" type="text/javascript"></script>

<script type="text/javascript" language="javascript">
    function test()
    {
        alert("vui lọng nhập từ ngày và đến ngày ");
        var textfromday = document.getElementById("txtdatefrom").value;
        var texttoday = document.getElementById("txtdateto").value;
        alert(textfromday +"-" +texttoday);
        if(textfromday ==null || texttoday==null)
        {
            alert("vui lọng nhập từ ngày và đến ngày ");
        }
    }
</script>

<link type="text/css" rel="stylesheet" href="../css/timepicker.css" />
<body>
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: #C0C0C0">
            <tr>
                <td width="100%" align="left" style="background-color: #D4D0C8; height: 10px;">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="100%" align="left" style="background-color: #D4D0C8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="100%" align="left" style="background-color: #D4D0C8">
                    <table id="user" cellspacing="1" cellpadding="1" width="100%" border="0" class="khung">
                        <tr>
                            <td class="title" align="center" style="background-color: #4D67A2; height: 25px;">
                                <strong><span class="title" style="color: #FFFFFF">BẢNG TÔNG HỢP KẾT QUẢ KHÁM SỨC KHOẺ</span>
                                </strong>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%">
                                <table cellpadding="0" width="100%" border="0">
                                    <tr style="height: 35px;">
                                        <td style="height: 35px">
                                            Công Ty :&nbsp;</td>
                                        <td style="height: 35px">
                                            <asp:DropDownList ID="ddlBS" runat="server" AutoPostBack="false" Width="305px">
                                            </asp:DropDownList>
                                            Từ Ngày:
                                            <input mkv="true" id="txtdatefrom" type="text" runat="server" onfocus="$(this).datepick();"
                                                onblur="TestDate(this);" style="width: 100px;" />
                                            Đến Ngày:
                                            <input mkv="true" id="txtdateto" type="text" runat="server" onfocus="$(this).datepick();"
                                                onblur="TestDate(this);" style="width: 100px;" />
                                            <asp:Button runat="server" ID="btnSearch" Text="Tìm" OnClick="btnSearch_Onclick" />
                                            <asp:Button ID="btnprint" runat="server" Text="In Báo Cáo" OnClick="btnprint_OnClick" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="danhsachbenhnhan" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
