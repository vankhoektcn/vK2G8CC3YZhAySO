<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="index1.aspx.cs" Inherits="index1" %>
<html>
    <head>
        <title>PHAN MEM KE TOAN</title>   
        <link type="text/css" rel="stylesheet" href="../ketoan/css_KeToan/sheet_index.css" />
<link href="../ketoan/css_KeToan/epoch_styles.css" type="text/css" rel="stylesheet" />
<link href="../ketoan/css_KeToan/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/default.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/style.css" />
<script type="text/javascript" src="../ketoan/js_KeToan/libary.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/script.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jscript.js"></script>
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/epoch_styles.css" />
<link href="../ketoan/css_ketoan/dropdown/dropdown.css" media="screen" rel="stylesheet" type="text/css" />
<link href="../ketoan/css_ketoan/dropdown/themes/default/default.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../ketoan/js_KeToan/epoch_classes.js"></script>
<script type="text/javascript" src="../ketoan/editor/editor.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jquery-1.4.2.js"></script>
<script src="../js/jquery.autocomplete.js" type="text/javascript"></script>
        <script language="javascript" type="text/javascript">

         if(this.name != 'fullscreen')  {
                    window.open('','_parent','');
                    window.close();                   
                   window.open(location.href,'fullscreen','fullscreen=1,location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no'); 
         }     
</script>
        <style>
            .tieude{
	            font-size:15px;
	            font-weight:bold;
	            color:red;
            }

            .tieude A{
	            font-size:12px;
	            font-weight:bold;
	            color:#666666;
	            text-decoration:none;
            }

            .tieude A:link{
	            font-family:tahoma;
	            font-size:12px;
	            color:#5E5F61;
	            font-weight:bold;	
	            text-decoration:none;
            }

            .tieude A:hover{
	            font-family:tahoma;
	            font-size:12px;
	            color:Red;
	            font-weight:bold;	
	            text-decoration:none;
            }
            .menu{
                font-size:12px;
                font-weight:bold;
                color:#666666;
            }

            .menu A{
                font-size:12px;
                font-weight:bold;
                color:#666666;
                text-decoration:none;
            }

            .menu A:link{
                font-family:tahoma;
                font-size:12px;
                color:#5E5F61;
                font-weight:bold;	
                text-decoration:none;
            }

            .menu A:hover{
                font-family:tahoma;
                font-size:12px;
                color:Red;
                font-weight:bold;	
                text-decoration:none;
            }
            
.style2 {font-size: 16px; font-weight: bold; color: #666666; }
        .style3 {color: #000000}
        </style>     
<script language = "javascript">
    
	function Thoat()
    {
        document.location.href = "../pagehome.aspx";
    }
</script>
 
    </head>
    <body style="background:url(../images/pageindex_.png);background-position:center; width:100%;background-repeat:no-repeat;">
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" >
                    <tr>
                        <%--<td class="menu" style="width: 376px"></td>--%> <%--<img width="48" height="48" align="middle"/>src="images/customer.gif"--%>
                        <td align="center"><span style="font-size:x-large;color:#3243ff;font-weight:bold;text-align:center;font-family:Arial Baltic">PHẦN MỀM QUẢN LÝ</span></td>
                    </tr>
                    <tr>
                      <td valign="middle" width="100%">
                        
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                
                                <tr>
                                    <td align="center">
                                    
                                        <table border="0" cellspacing="0" cellpadding="0" id="tbMainLogin" style="width: 810px">
                                            <tr>
                                                <td height="370" style="width: 98%"><div align="center">
                                                   <div align="center" class="style2" style="width: 100%">HỆ THỐNG KẾ TOÁN </div> 
                                                   <br/>           
                                                    <table border="0" width="98%" id="tbContainer" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="batch font13" width="100%">
                                                                
                                                                    <fieldset style="padding: 2; width:100%; height:100%; border:0; text-align: right;">
                                                                        <div id="pageload" runat="server">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                              
                                                                              <tr>
                                                                                
                                                                                <td width="10%">&nbsp;</td>
                                                                                <td class="menu" style="width: 376px"><img src="../images/customer.gif" width="48" height="48" align="middle"/>&nbsp;&nbsp;<a href = "../ketoan/KTHT_SoDuDauKyTaiKhoan.aspx"><b>HỆ THỐNG</b></a></td>
                                                                                <td class="menu" style="width: 225px"><img src="../images/money.gif" width="48" height="48" align="middle"/>&nbsp;&nbsp;<a href = "../ketoan/ketoantienmat.aspx"><b>KẾ TOÁN TIỀN MẶT</b></a></td>
                                                                                <td class="menu" style="width: 260px"><img src="../images/bacsi1.png" width="48" height="48"  align="middle"/>&nbsp;<a href = "../ketoan/ketoantonghop.aspx"><b>KẾ TOÁN TỔNG HỢP</b></a></td>
                                                                                <td width="5%">&nbsp;</td>
                                                                              </tr>
                                                                              <tr>
                                                                                <td colspan="5"><p>&nbsp;</p>                                                                                </td>
                                                                          </tr>
                                                                              <tr>
                                                                                <td>&nbsp;</td>
                                                                                <td class="menu" style="width: 376px"><img src="../images/kho.gif" width="48" height="48" align="middle"/>&nbsp;&nbsp;<a href = "../ketoan/hethongdanhmuc.aspx"><b>HỆ THỐNG DANH MỤC </b></a></td>
                                                                                <td class="menu" nowrap="nowrap" style="width: 225px"><img src="../images/user.png" width="48" height="48" align="middle"/>&nbsp;&nbsp;<a href = "../ketoan/ketoannganhang.aspx"><b><span style="font-size: 9pt">KẾ TOÁN NGÂN HÀNG </span></b><!--</a>--></td>
                                                                                <td class="menu" align="left" style="width: 260px"><img src="../images/chungtu.gif" width="48" height="48" align="middle"/><a href = "../ketoan/BaoCaoTaiChinh.aspx"><b>BÁO CÁO TÀI CHÍNH </b></a></td>
                                                                                <td>&nbsp;</td>
                                                                              </tr>
																			  <tr>
                                                                                <td colspan="5"><p>&nbsp;</p>                                                                                </td>
                                                                              </tr>
																			  <tr>
                                                                                <td>&nbsp;</td>
                                                                                <td class="menu" align="left" style="width: 376px"><img src="../images/bacsi1.png" width="48" height="48" align="middle"/>&nbsp;&nbsp;<a href = "../ketoan/HDDV_XuatHoaDon.aspx"><b>HÓA ĐƠN DV  </b></a></td>
                                                                                <td class="menu" align="left" style="width: 260px"><img src="../images/bacsi1.png" width="48" height="48" align="middle"/>&nbsp;<a href = "../ketoan/KTCN_Khach_Hang_CT.aspx" <b>KT CÔNG NỢ </b><!--</a>--></td>
                                                                                <td class="menu" align="left" style="width: 260px"><img src="../images/chungtu.gif" width="48" height="48" align="middle"/><a href = "../ketoan/baocaothue.aspx"><b>BÁO CÁO THUẾ</b></a></td>
                                                                                <td>&nbsp;</td>
                                                                              </tr>
                                                                              <tr>
                                                                                <td colspan="5"><p>&nbsp;</p>                                                                                </td>
                                                                              </tr>
                                                                              <tr>
                                                                                <td>&nbsp;</td>
                                                                                <td class="menu" style="width: 376px"><img src="../images/khuvuc.png" width="48" height="48" align="middle"/>&nbsp;&nbsp;<a href = "../ketoan/KTVT_DanhMucTaiSan.aspx"><b>KẾ TOÁN TSCĐ </b></a></td>
                                                                                <td class="menu" nowrap="nowrap" style="width: 225px"><img src="../images/user.png" width="48" height="48" align="middle"/>&nbsp;&nbsp;<a href = "../ketoan/KTVT_DanhMucCCDC.aspx"><b>KẾ TOÁN CCDC</b></a></td>                                                                                
                                                                                <td class="menu" nowrap="nowrap" style="width: 225px"><img src="../images/user.png" width="48" height="48" align="middle"/>&nbsp;&nbsp;<a href ="../KetoanDUOC/Web/index.aspx"><b>KẾ TOÁN DƯỢC</b></a></td>                                                                                
                                                                                
                                                                                <td>&nbsp;</td>
                                                                              </tr>
                                                                              <tr>
                                                                                <td colspan="5" style="height: 16px"><p>&nbsp;</p>   </td>
                                                                          </tr>
                                                                    </table>
                                                                    </div>
                                                                        <a href = "../pagehome.aspx"><strong>Trở về</strong></a>
                                                                    </fieldset>
                                                                <br />
                                                          </td>
                                                      </tr>
                                                  </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                          </table>
                        </td>
                    </tr>
                </table>       
        </body>
</html>
