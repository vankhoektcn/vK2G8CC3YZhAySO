<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fr_rptBangTongHopKQSucKhoeTheoCty.aspx.cs" Inherits="thongke_fr_rptBangTongHopKQSucKhoeTheoCty" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Bảng Tổng Hợp Kế Quả Khám Sức Khoẻ</title>
    <style type="text/css">
    a:hover {
    color: #a84444;
    border-bottom: 1px dotted #a80000;
    background: transparent;
    cursor: pointer;
    }
    a {
    color: Blue;
    cursor: pointer;
    font-style: italic;
    text-decoration: underline;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <span style="padding:10px 10px 10px 10px"> Người lập:</span><input runat="server" id="txtNguoiLap" style="width:150px;"/>
        <span style="padding:10px 10px 10px 10px"> Trưởng đoàn:</span><input runat="server" id="txtTruongDoan" style="width:250px;"/>
        <%--<asp:Button ID="Button1" runat="server" Text="Tham số" class="btn2"  OnClientClick="OpenThamSo();" />--%>
        <a  onclick="OpenThamSo();">Tham số</a>
        <br />
        <span style="padding:10px 10px 10px 10px"> Ghi chú:</span><input runat="server" id="txtGhiChu" style="width:800px;"/>
        <asp:Button ID="btnBaoCao" runat="server" Text="Lấy báo cáo" OnClick="btnBaoCao_Click" />
        <cr:crystalreportviewer id="rptThongKe" runat="server" autodatabind="true"  PrintMode="ActiveX"  DisplayGroupTree="False" />
    </form>
</body>
</html>
<script type="text/javascript">
function OpenThamSo()
{
        window.open("../DanhMuc/web/KB_Parameter2.aspx", '_blank', 'location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
}
</script>
