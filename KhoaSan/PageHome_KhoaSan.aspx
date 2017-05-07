<%@ Page Language="C#"  AutoEventWireup="true"  CodeFile="PageHome_KhoaSan.aspx.cs" Inherits="PageHome_KhoaSan" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="Server">
    
        <title>QUẢN LÝ KHOA SẢN</title>   
        <noscript>trình duyệt không hỗ trợ javascript</noscript>
        <link type="text/css" rel="stylesheet" href="css/default.css" />
        <script src="../js/libary.js" type="text/javascript"></script>
        <script src="../js/script.js" type="text/javascript">function IMG1_href() {}</script>  
        <script src="../js/jquery-1.6.1.min.js" type="text/javascript"></script>  
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
                text-align:center;
                width:210px;
                float:left;
                padding:10px 0px 20px 0px;
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
        </style>    
        <script type="text/javascript">
        var  openWins = new Array();curWin = 0;
        $(document).ready(function() {
            $(document).keyup(function(event) {
                var key = event.keyCode || event.charCode || 0;
                if(1==1)
                {
                //alert(key);//return;
                    if (key == 79) { // Page One Press 1
                        //window.location.href = $($('a[id$=lbnPhongSanh]')).attr("href");
                        $($('a[id$=lbnPhongSanh]')).click();
                    }
                    else if (key == 72) {
                         $($('a[id$=lbnHauSan]')).click();
                    }
                }
            });
                
        });        
        </script>    
    </head>
    <%--#c2e2f7,#D4D0C8 ,#D4DDDD--%>
    <%--bg_img.gif,HinhNenNoiTru.JPG--%>
    <body onunload="closeAll()" style="background:Black url(../images/bg_img.gif);background-position:center; width:100%;background-repeat:no-repeat;">
    <form runat="server" id="form">
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="middle" width="100%">
                        
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center" >
                                    
                                        <table border="20" rules="none" cellspacing="0" cellpadding="0" id="tbMainLogin" style="width: 580px;">
                                            <tr>
                                                <td height="200" style="width: 98%">
                                                <div align="center" style="height:100%;border-style:double;border-color:Blue;border-width:10px">
                                                        <div style="clear:both;width:100%;padding-left:40px;padding-bottom:20px;padding-top:40px;">
                                                            <div class="menu" >
                                                                <img alt="" align="middle" src="../images/BaBau.jpg" style="width:80px;height:80px" />
                                                                    <asp:LinkButton ID="lbnPhongSanh" runat="server" OnClientClick="openlink(this,'index.aspx?dkmenu=phongsanh')" OnClick="lbKhoaNgoai_Click">Ng<u>O</u>ại Sản</asp:LinkButton>
                                                            </div>
                                                            <div class="menu" >
                                                                <img alt="" align="middle" height="80px" style="margin-left:0px" src="../images/besosinh_4.jpg" width="80px" />
                                                                <a id="lbnHauSan" href="#" onclick="openlink(this,'index.aspx?dkmenu=khoasan')"><u>H</u>ậu Sản</a>
                                                            </div>  
                                                            <%--<div class="menu" >
                                                                <img alt="" src="../images/VienSoi.jpg" align="middle" style="width: 48px; height: 48px"/>
                                                                <a id="lbnPhongTanSoi" href="#" onclick="openlink(this,'TanSoi/index.aspx')">Phòng tán <u>S</u>ỏi</a>
                                                            </div> --%> 
                                                        </div>  
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
                <div runat="Server" id="head"></div>
                <script type="text/javascript">
                    function openlink(obj,link) {
                        if($(obj).attr("disabled") == null && $(obj).attr("disabled") != false)
                        {
                            window.open(link,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
                            //location.href=link;
                            window.close();
                        }
                            //openWins[curWin++] = window.open(link,'_blank');
                    }
                    function closeAll() {
//                        for(i=0; i<openWins.length; i++) if (openWins[i] && !openWins[i].closed)
//                        openWins[i].close();
                    }   
                </script>
                </form>  
                <marquee style="position:fixed;bottom:0;width:100%;text-align:center;height:20px;border-top:1px solid #666666;left:auto;background-color:#EAE7E2;color:Blue;left:0"><%= StaticData.TenPhanMem %> - <%= StaticData.TenCty %> | Người dùng:&nbsp;<%= (SysParameter.UserLogin.FullName(this)) %></marquee>
       
        </body>
</html>
