<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>


<html>
    <head>
        <title>QUẢN LÝ BỆNH VIỆN</title>   
        <link type="text/css" rel="stylesheet" href="css/default.css" />
       <script language = "javascript">
    function SetFocus()
	{
	    var obj = document.getElementById('txtdangnhap');
	    obj.focus();
	}	
    </script>
    <script language='javascript'>
	function lockWarning()
	{
		alert('Tài khoản của bạn đã bị khóa!');
	}
    </script>	
    <script language="javascript">
    function logins() 
    { 
        if (event.keyCode==13) 
        { 
            document.login.submit(); 
        } 
    }
    </script>     
    </head>
    <body onunload="SetFocus()" style="background:#c2e2f7 url(images/QLBV.jpg);background-position:center; width:100%;background-repeat:no-repeat;">
    
    
    <form id="Form1" method="post" runat="server">
    
    &nbsp;<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="middle"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="center"><table border="0" cellspacing="0" cellpadding="0" id="Table1">
                    <tr>
                        <td height="25" width="612" class="header font13">&nbsp;Đăng Nhập</td>
                    </tr>
                    <tr>
                        <td height="185" width="612"><div align="center">
                        <table border="0" width="98%" id="Table2" cellspacing="0" cellpadding="0">
                              <tr>
                                    <td class="batch font13">
        			                    <div class="warning font13"></div> <br/>           
                    	                Hệ thống đã được bảo mật, vui lòng nhập tên truy cập và mật khẩu để 
                    	                truy xuất vào hệ thống . 
                                        <br />
                                      <br><br>
                          <fieldset style="padding: 2; width:100%">

                          <legend>Thông tin đăng nhập</legend>
                          <br>
                          <br>
                            <table border="0" width="60%" id="tbForm" align="center" cellspacing="0" cellpadding="0">
                            <tr>
                              <td class="font13">Tên truy cập:</td>
                            </tr>
                            <tr>
                              <td><asp:TextBox ID="txtdangnhap" runat="server" Width="299px"></asp:TextBox></td>
                            </tr>

                            <tr>
                              <td class="font13">Mật khẩu:</td>
                            </tr>
                            <tr>
                              <td><asp:TextBox ID="txtmatkhau" runat="server" Width="299px" TextMode="Password"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td align="right"><br/>

                                  <asp:Button ID="Button1" runat="server" OnClick="bntdnt_Click" Text="Đăng nhập" CssClass="menu" />
                                  <input type="button" value="Quay Lại" name="B2" onclick = "javascript:history.back()">
                                <br/>
                                &nbsp;</td>
                            </tr>
                          </table>
                            </fieldset>
                      <p class="font13">Hãy liên hệ với <b>Quản trị</b> khi bạn mất tài khoản.</td>
                  </tr>
                </table>
            </div></td>
          </tr>
        </table></td>
      </tr>
    </table></td>
  </tr>
</table>  
    </form>
    <marquee style="position:fixed;bottom:0;width:100%;text-align:center;height:20px;border-top:1px solid #666666;left:auto;background-color:#EAE7E2;color:Blue;left:0"><%= StaticData.TenPhanMem %> - <%= StaticData.TenCty %> | Người dùng:&nbsp;<%= (SysParameter.UserLogin.FullName(this)) %></marquee>

        </body>
</html>

