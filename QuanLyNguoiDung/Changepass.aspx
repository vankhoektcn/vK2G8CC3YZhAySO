<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changepass.aspx.cs" Inherits="changepass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <script type="text/javascript" src="../js/script.js"></script>
 <link type="text/css" rel="stylesheet" href="../css/default.css" />
    <title>Hospital manager software -Change pass</title>
</head>
<body style="background:url(../images/QLBV.jpg) ">
    <form id="form1" runat="server">
    <div style="margin-top:200px;margin-left:300px">
     <fieldset style="padding: 2; width:50%">

                          <legend style="color:Red;font-size:14pt">Thay đổi mật khẩu</legend>
         <br />
         <div style="margin-left:50px">
        <asp:Label ID="Label1" runat="server" Text="Tên đăng nhập: " Width="160px"></asp:Label>
        <asp:TextBox ID="txtUser" runat="server" Width="300px"></asp:TextBox>
        <br />
        <br />
         <asp:Label ID="Label4" runat="server" Text="Mật khẩu cũ: " Width="160px"></asp:Label>
        <asp:TextBox ID="txtOldPass" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Mật khẩu mới: " Width="160px"></asp:Label>
        <asp:TextBox ID="txtNewPass" TextMode="Password" runat="server" Width="300px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Xác nhận mật khẩu mới: " Width="160px"></asp:Label>
        <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnChangePass" runat="server" Text="Lưu" Width="100px" OnClick="btnChangePass_Click"/>
       <input type="button" value="Quay Lại" name="B2" Width="100px" onclick = "javascript:history.back()">
      <asp:Button ID="btnHomePage" runat="server" Text="Quay trở lại Trang Chủ" Visible="false" OnClick="btnHomePage_Click"/>
        </div>
        </fieldset>
    </div>
    </form>
</body>
</html>
