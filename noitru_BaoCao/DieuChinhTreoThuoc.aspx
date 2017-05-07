
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DieuChinhTreoThuoc.aspx.cs"
    Inherits="noitru_BaoCao_DieuChinhTreoThuoc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Danh sách dự trù thuốc</title>
    <link href="../css/timepicker.css" rel="stylesheet" type="text/css" />
    <link href="../css/jtable.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/jquery-1.6.1.min.js"></script>

    <script type="text/javascript" src="../js/timepicker.js"></script>

    <script type="text/javascript" src="../js/myscript.jqr.js"></script>
    
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />

    <script src="../js/jquery-1.6.1.min.js" type="text/javascript"></script>

    <script src="../js/jquery-ui.js" type="text/javascript"></script>

    <script src="../js/jquery.autocomplete.js" type="text/javascript"></script>

    <script src="../js/jquery.validate.js" type="text/javascript"></script>

    <script src="../js/myscriptvalid.js" type="text/javascript"></script>


    <script type="text/javascript" src="../js/timepicker.js"></script>

    <script type="text/javascript" src="../js/myscript.js"></script>

    <script type="text/javascript" src="../js/myscript.jqr.js"></script>

    <script type="text/javascript">
        $(document).ready(function(){
            
            var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth() + 1; 
            var yyyy = today.getFullYear();
            if (dd < 10) { dd = '0' + dd }
            if (mm < 10) { mm = '0' + mm }
            $("#tungay").val(dd + "/" + mm + "/" + yyyy);
            $("#denngay").val(dd + "/" + mm + "/" + yyyy);
            $("#loaithuocid").DropList({
                ajax:"../ajax/DuTruThuoc_ajax2.aspx?do=loaithuocidsearch",defaultVal:"-Chọn đối tượng-",async:false
            });
            $("#khothuocid").DropList({
                ajax:"../ajax/DuTruThuoc_ajax2.aspx?do=khothuocidsearch&idkhoa=" + $.mkv.queryString("idphongkhambenh"),defaultVal:"-Chọn kho-",async:false
            });
            $("#layds").click(function(){
                $(this).TimKiem({
                    ajax:"../ajax/DuTruThuoc_ajax2.aspx?do=LoadDSKhoaTreoThuoc"
                    ,showPopup:false
                    ,readMKV:true
                },function(){
                         $("#tableAjaxDSChiDinh").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
                },function(data){
                     $("#tableAjaxDSChiDinh").html(data);
                     $("table.jtable tr:nth-child(odd)").addClass("odd");
                     $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                     $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                });
            });
        });
function CapNhatTreo(idtreo_yc,isXoa)
{
     $.ajax({
         type:"GET",
         cache:false,
         url:"../ajax/DuTruThuoc_ajax2.aspx?do=CapNhatIsXoaTreo&idtreoyc="+idtreo_yc+"&isXoa="+isXoa+"&page=",
          success: function (value){
                if(value=="1")
                {
                    if(isXoa==0)
                        alert("Đã Phục hồi treo !");
                    else
                        alert("Đã Xóa treo !");
                    $("#layds").click();
                }
                else
                   alert("Lỗi !");
            }
      });
}
    </script>

    <style type="text/css">
         *
        {
	        font-size:12px;
	        font-weight: normal;
	        font-family: Tahoma;
        }
        .divMain
        {
            margin: 0;
	        color: #326ea1;
	        width: 100%;
	        border: 1px solid #cfcfcf;
	        padding: 0;
	        position: relative;
	        box-radius: 0px 0px 5px #cae3ff;
	        -moz-box-radius: 0px 0px 5px #cae3ff;
	        -webkit-box-radius: 0px 0px 5px #cae3ff;
	        background:#dedede;
        }
        .body-div
        {
	        margin-top: -40px;
	        padding: 5px 5px 5px 5px;
	        border-bottom: none;
        }
        .body-div .in-a
        {
	        padding-bottom: 10px;
	        display: table;
	        width: 100%;
	        padding-top: 35px;
	        color: #4473ca;
	        text-transform: uppercase;
	        font-family: Arial, Helvetica, sans-serif;
	        font-size: 12px;
        }
        .body-div .in-a input, select
        {
	        padding: 5px 4px;
        }
       .header-div
        {
	        background: #4d67a2 url(../images/bottom_nav_bg1.jpg) no-repeat top center;
	        color: white;
	        text-transform: uppercase;
	        height: 20px;
	        padding: 7px 40px 6px 0px;
	        text-align: center;
	        position: relative;
	        font-size: 20px;
	        width: 95%;
	        margin: 0 auto;
	        top: 26px;
	        left: 0px;
	        z-index: 999;
	        font-weight: bolder;
        }
       .div-Out
        {
	        float: left;
	        padding: 0px 0px 0px 20px;
	        width: 380px;
	        position: relative;
	        border-bottom: 1px solid #cfcfcf;
	        border-left: 1px solid #cfcfcf;
	        height:35px;
        }

        .div-Out h4
        {
	        float: left;
	        color: black;
	        font-size: 12px;
	        position: relative;
	        bottom: 0;
	        height:35px;
	        line-height:35px;
	        margin:0;
        }
        .div-Out p
        {
	        margin:0;
	        width: 75%;
	        float: right;
	        padding: 0px 0px 0px 10px;
	        position: relative;
	        bottom: 0;
	        line-height:35px;
        }
        .div-Out p input[type="text"]
        {
	        width:90%;
	        padding:4px 5px;
	        font-size:12px;
	        color:#444;
        }
        .div-Out p input[type="checkbox"]
        {
            vertical-align:middle;
            margin-top:10px;
        }
        legend
        {
            font-size:10pt;
            font-weight:bold;
        }
        #divalert.success
        {
	        background: 16px 16px no-repeat url(../images/success.png);
	        color: #4F8A10;
	        background-color: #DFF2BF;
        }

        #divalert.info
        {
	        background: 16px 16px no-repeat url(../images/info.png);
	        color: #00529B;
	        background-color: #BDE5F8;
        }

        #diverror.error
        {
	        background: 16px 16px no-repeat url(../images/error.png);
	        color: #d8000c;
	        background-color: #ffbaba;
        }
.sola{position:fixed;top:0;margin:0;left:0;width:100%;z-index:1000;}
.hovermenu
{
	padding: 3px 2px 3px 2px;
	font-size: 16px!important;
	color: #333;
	font-weight: normal;
	font-family: Times New Roman;
	z-index: 1000;
}

.shovermenu
{
	padding: 3px 2px 3px 2px;
	font-size: 16px!important;
	color: #333;
	font-weight: bold;
	font-family: Arial;
	z-index: 1000;
}

    </style>
</head>
<body>
    <form id="frmMain" runat="server">
        <div class="divMain">
            <div style="width:100%;height:26px">
                <asp:placeholder id='PlaceHolder1' runat="server"> </asp:placeholder>
            </div>
            <div class="body-div">
                <p class="header-div" id="pHeader" runat="server">
                    Kiểm Tra Chỉ Định
                </p>
                <div class="in-a">
                    
                    <div class="div-Out">
                        <h4>
                            Kho
                        </h4>
                        <p>
                            <select id="khothuocid" mkv="true" style="width:170px">
                            </select>
                        </p>
                    </div>
                    <div class="div-Out">
                        <h4>
                            Từ ngày
                        </h4>
                        <p>
                            <input id="tungay" style="width:80px;" type="text" onfocus="$(this).datepick();" mkv="true" />
                        </p>
                    </div>
                    <div class="div-Out" style="border-right: 1px solid #ccc">
                        <h4>
                            Đến ngày
                        </h4>
                        <p>
                            <input id="denngay" style="width:80px;" type="text" onfocus="$(this).datepick();" mkv="true" />
                        </p>
                    </div>
                    <div class="div-Out">
                        <h4>
                            Loại thuốc
                        </h4>
                        <p>
                            <select id="loaithuocid" mkv="true" style="width:170px">
                            </select>
                        </p>
                    </div>
                    <div class="div-Out" style="border-right: 1px solid #ccc;">
                        <h4>
                            Tên thuốc</h4>
                        <p>
                            <input type="text" id="tenthuoc" mkv="true" />
                        </p>
                    </div>
                    <div class="div-Out" style="border-right: 1px solid #ccc;">
                        <h4>
                            </h4>
                        <p>
                            <input type="button" style="padding: 6px 10px;font-weight:bold;" value="Lấy danh sách" id="layds" />
                        </p>
                    </div>
                    <%--<div style="border:1px solid #ccc;width:100%;text-align:center;float:left;">
                        <input type="button" value="Lấy danh sách" id="layds" />
                    </div>--%>
                </div>
                <fieldset>
                    <legend>Danh sách chỉ định </legend>
                    <div id="tableAjaxDSChiDinh">
                    </div>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>
