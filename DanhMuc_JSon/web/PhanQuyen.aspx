<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="PhanQuyen.aspx.cs" Inherits="DanhMuc_JSon_web_PhanQuyen" Title="Phân quyền người dùng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <link href="../css/jqx.base.css" rel="stylesheet" type="text/css" />

    <script src="../js/jqxcore.js" type="text/javascript"></script>

    <script src="../js/jqxdata.js" type="text/javascript"></script>

    <script src="../js/jqxbuttons.js" type="text/javascript"></script>

    <script src="../js/jqxscrollbar.js" type="text/javascript"></script>

    <script src="../js/jqxcombobox.js" type="text/javascript"></script>

    <script src="../js/jqxlistbox.js" type="text/javascript"></script>

    <script src="../js/jqxcheckbox.js" type="text/javascript"></script>

    <script type="text/javascript" src="../javascript/phanquyen.js"></script>

    <style type="text/css">
        .ui-button
        {
            margin-left: -1px;
        }
        .ui-button-icon-only .ui-button-text
        {
            padding: 0.35em;
        }
        .ui-autocomplete-input
        {
            margin: 0;
            padding: 0.48em 0 0.47em 0.45em;
        }
        .ui-autocomplete
        {
            height: 200px;
            overflow-y: scroll;
            overflow-x: hidden;
        }
        p a:hover
        {
            background: none;
        }
        #divButton input[type="button"]
        {
            float: left;
            margin: 2%;
            padding: 1%;
            clear: both;
            
        }
    </style>
    <link href="../css/jqx.classic.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            Phân quyền
        </p>
        <div class="in-a">
            <div class="div-Out" style="border: none; padding: 2px">
                <h4 style="font-weight: bold; color: #18538c;">
                    Người dùng
                </h4>
                <div id="ddlNguoiDung" style="float: right; margin: 5px;">
                </div>
            </div>
            <div style="float: left; clear: both; width: 45%;">
            <input type="text" id="searchListQuyen" style="float: left; width: 91%;" />
                <div id="ddlListQuyen" style="margin-top:9%;width:100%">
                </div>
            </div>
            <div style="float: left; margin-top: 10%;" id="divButton">
                <input type="button" value=">" id="btnNext" />
                <input type="button" value="<" id="btnPrev" />
            </div>
            <div style="margin-left: 2%; float: left; width: 40%">
                <div id="chkPrevAll">
                    All select/unselect</div>
                <div id="ddlQuyen" style="width:100%;margin-top:6%">
                </div>
            </div>
            <div style="margin: 0 auto; padding: 1%; width: 60%; float: left; clear: both; text-align: center">
                <input type="button" id="btnSaveQuyen" value="Lưu" />
            </div>
        </div>
    </div>
</asp:Content>
