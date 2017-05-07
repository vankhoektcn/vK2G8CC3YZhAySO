<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="Z_DSPHIEUTHU_VIEW2.aspx.cs" Inherits="Z_DSPHIEUTHU_VIEW" Title="Z_DSPHIEUTHU_VIEW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/Z_DSPHIEUTHU_VIEW2.js">
    </script>

    <style type="text/css">
        .div-Out p
        {
            border:none;
        }
        #divPopup
        {
            width:350px;
            height:180px;
            position:fixed;
            top:30%;
            left:35%;
            background:url(../images/popup.png) no-repeat 0 10px;
            margin:0;
            border:0;
            z-index:999999;
            display:block;
        }
        #divPopup h4
        {
            margin: 0;
            font-weight: bold;
            position: relative;
            top: 20px;
            left: 13px;
            width: 90%;
            line-height:18px;
            height:15px;
        }
        #divPopup a.close
        {
             background:url(../images/popup.png) no-repeat;
             text-decoration:none;
             float:right;
             height:25px;
             width:25px;
             position: relative;
             top: 4px;
             right:9px;
             background-position: -8px -169px;  
             cursor:pointer;
        }
        #divPopup a.close:hover
        {
          background-position: -32px -169px;  
        }
        #divPopup #box
        {
            padding: 0;
            height: 128px;
            width: 325px;
            margin: 26px 4px 4px 10px;
            line-height: 1.6em;
            overflow: hidden;
            border:1px solid #ccc;
            padding-top:5px;
        }
        #divPopup #box div
        {
            float:left;
            margin:0 auto;
            padding:0;
            height:35px;
            line-height:35px;
            width:320px;
            position:relative;
        }
        #divPopup #box div h4
        {
            line-height:30px;
            margin:0;
            float:left;
            color:#333;
            position:absolute;
            top:5px;
            left:7px;
        }
        #divPopup #box div p
        {
            width:75%;
            float:right;
            padding:2px 0px 1px 5px;
            margin-top:5px;
        }
        #divPopup #box div p input[type="text"]
        {
            border:1px solid #ccc;
            padding:4px;
            width:90%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Danh sách phiếu thu")%>
        </p>
        <div class="in-a">
            <div class="div-Out" style="width: 15%">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("MAPHIEU")%>
                </h4>
                <p>
                    <input mkv="true" id="MAPHIEU" type="text" onfocus='chuyenphim(this);' style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 18%">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("mabenhnhan")%>
                </h4>
                <p style="width: 55%">
                    <input mkv="true" id="mabenhnhan" type="text" onfocus='chuyenphim(this);' style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 25%">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tenbenhnhan")%>
                </h4>
                <p>
                    <input mkv="true" id="tenbenhnhan" type="text" onfocus='chuyenphim(this);' style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 25%">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythu")%>
                </h4>
                <p style="width: 75%">
                    <input mkv="true" id="ngaythu" type="text" onfocus='chuyenphim(this);$(this).datepick();$(this).validDate();'
                        style="width: 40%" />
                    <input id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <div class="in-b" id="tableAjax_Z_DSPHIEUTHU_VIEW">
        </div>
    </div>
    <div id="divPopup">
        <h4>
            Xác nhận hủy phiếu ?
        </h4>
        <a class="close"></a>
        <div id="box">
            <div>
                <h4>
                    Mã phiếu</h4>
                <p>
                    <input type="text" id="txtMaPhieu" />
                </p>
            </div>
            <div>
                <h4>
                    Lý do
                </h4>
                <p>
                    <input type="text" id="txtLyDo" />
                </p>
            </div>
            <div style="text-align: center; margin-top: 5px;">
                <input type="button" value="Xác nhận" id="btnOK" /><input type="hidden" id="txtRow" />
            </div>
        </div>
    </div>
</asp:Content>
