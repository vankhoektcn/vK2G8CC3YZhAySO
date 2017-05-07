<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sys_login.aspx.cs" Inherits="sys_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <link href="css/sys_login.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="jquery/jquery-1.6.1.min.js"></script>

    <script type="text/javascript" src="jquery/jquery.cookie.js"></script>

    <script type="text/javascript" src="javascript/_sys_login.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="sad_Login_Form">
            <div id="swapper_login">
                <div class="swap_input_login">
                    <div class="swap_form">
                        <div class="title">
                            Đăng nhập vào hệ thống</div>
                        <div class="label">
                            Tên đăng nhập</div>
                        <div class="swap_input">
                            <input name="txt_User" type="text" id="txt_User" tabindex="1" />
                        </div>
                        <div class="label" style="margin-top: 16px;">
                            Mật Khẩu</div>
                        <div class="swap_input">
                            <input name="txt_Password" type="password" id="txt_Password" tabindex="2" />
                        </div>
                        <div style="float: left; font-size: 11px; display: none;">
                            <span style="float: left;">
                                <input type="checkbox" id="chk_Save" /></span> <span style="float: left; padding-top: 2px;
                                    padding-left: 3px; color: #454545; cursor: pointer; width: 200px;">Lưu thông tin
                                    đăng nhập</span>
                        </div>
                        <a id="btnDangnhap" class="link_button" tabindex="3"><span style="width: 80px;">Đăng
                            nhập</span><span class="nav_right"></span></a>
                    </div>
                    <div class="swap_logoSoftware">
                        <div class="version">
                            <span>Version:</span> 1.0.0
                        </div>
                    </div>
                </div>
                <div class="copy">
                    Copyright © 2012 <a href="http://www.mekongvietco.com" target="_blank" tabindex="4">
                        MeKongViet.com</a>. All rights reserved.</div>
            </div>
        </div>
    </form>
</body>
</html>
