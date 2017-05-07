<%@ Page Language="C#" AutoEventWireup="true" CodeFile="phieuKQSieuAm.aspx.cs" Inherits="canlamsang_phieuKQSieuAm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Kết quả siêu âm</title>
      <script type="text/javascript">
    function ClickToPrint()
     {
       window.print();
}
    </script>
    <style type="text/css">
                    @media print {
                    input.noPrint { display: none; }
                    }
                </style>
</head>
<body>
    <form id="form1" runat="server">
    <div >
     <div style="width:100%;text-align:center">
    <br />
    </div>
    <div runat="server" id="divBenhNhan" style="padding-left:12px;width:99%;padding-top:8%">
       <%-- <table style=" border: 1px solid #000000; border-bottom: none;" width="100%" cellpadding="0">
         <tr>
            <td style="width:250px;border:1px solid #000000; " >
                <span class="ptext" id="lblBN" runat="server" style="font-weight:bold" ></span>
            </td>
            <td style="border:1px solid #000000;">
             <span class="ptext" id="lblTuoi" runat="server"  ></span>
            </td>
            </tr>
            <tr>
            <td style="border:1px solid #000000; ">
                  <span class="ptext" id="spMa" runat="server"></span>
            </td>
            <td style="border:1px solid #000000;">
             <span class="ptext" id="lblDC" runat="server"  ></span>
            </td>
             </tr>
            <tr>
                <td style="border:1px solid #000000;">
                     <span class="ptext" id="lblBS" runat="server" ></span>
                </td>
                <td style="border:1px solid #000000;">
                     <span class="ptext" id="lblSieuAm" runat="server"  ></span>
                </td>
            </tr>
            <tr>
                <td style="border:1px solid #000000;" colspan="2">
                         <span class="ptext" id="lblChanDoan" runat="server" ></span>
                </td>
            </tr>
        </table>--%>
     </div>
     <div style="width:99%;padding-left:12px">
     <span class="ptext" id="lblKQ" runat="server" ></span> <div>
     <br />
     <%--<span class="ptext" id="lblngay" runat="server" style="position:absolute;left:67%;top:90%;font-size:17px" ></span>
      <span id="Span1" class="ptext" runat="server" style="position:absolute;left:67%;top:90%;font-size:17px">Bác sĩ siêu âm</span>--%>
     </div>
     
     <%-- <br />
      <br />
      <span class="ptext" id="lblBSLamCLS" runat="server" style="padding-left:68%" ></span>--%>
     </div>
     <div style="padding-top:5%">
    
     </div>
    </div>
    <input type="button" class="noPrint" value="In Phiếu" runat="server" onclick="ClickToPrint();" />
    </form>
</body>
</html>
