<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KiemTraDuTru.aspx.cs"
    Inherits="noitru_BaoCao_KiemTraDuTru" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Danh sách dự trù thuốc</title>
    <link href="../css/timepicker.css" rel="stylesheet" type="text/css" />
    <link href="../css/jtable.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="../KhamBenh_TH/css/jquery.autocomplete.new.css" rel="stylesheet" />

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
            var editHaoPhi= queryString("editHaoPhi");
            if(editHaoPhi != null && editHaoPhi=="1")
                {
                    $("#divYeuCau").css("display","none");
                }
            var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth() + 1; 
            var yyyy = today.getFullYear();
            if (dd < 10) { dd = '0' + dd }
            if (mm < 10) { mm = '0' + mm }
            $("#loaithuocid").DropList({
                ajax:"../ajax/DuTruThuoc_ajax2.aspx?do=loaithuocidsearch",defaultVal:"-Chọn đối tượng-",async:false
            });
            $("#layds").click(function(){
                var idthuoc =$("#idthuoc").val();
                if(idthuoc ==null || idthuoc =="" || idthuoc =="0")
                {
                    $.mkv.myerror("Chưa chọn thuốc.");
                    return;
                }
                $(this).TimKiem({
                    ajax:"../ajax/DuTruThuoc_ajax2.aspx?do=LayDSDuTruBenhNhan&idthuoc ="+idthuoc+""
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
                     LoadDanhSachDuTruDuTruc(idthuoc);
                });
            });
        });
function LoadDanhSachDuTruDuTruc(idthuoc)
{
    $.ajax({
            type:"GET",
            cache:false,
            url:"../ajax/DuTruThuoc_ajax2.aspx?do=LoadDanhSachDuTruDuTruc&idthuoc="+idthuoc+"",
            success:function(data){
                if(data!="" && data !=null)
                {
                     $("#tableAjaxDSYEUCAU").html(data);                                              
                }
            },
            error:function(data){
               $.mkv.myerror(data); 
            }
        });
}

function idthuocsearch(obj) {
    var LoaiThuocID=$("#loaithuocid").val();
    if(LoaiThuocID==null || LoaiThuocID=="") LoaiThuocID="1";    
    $(obj).unautocomplete().autocomplete("../QLDUOC/ajax/phieuxuatkho_XuatLe_ajax.aspx?do=IdThuocSearch&loaithuocid=" + LoaiThuocID+"&loaidk=1&TypeSearch=1", {
        minChars: 0,
        width: 800,
        scroll: true,
        addRow: true,
        header:  "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
                + "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
                + "<div style=\"width:35%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;padding-left:5px;\" >Biệt dược</div>"
                + "<div style=\"width:15%;height:30px;color:#000;font-weight:bold;float:left\" >TT HC</div>"
                + "<div style=\"width:20%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;\" >Hoạt chất</div>"
                + "<div style=\"width:7%;height:30px;color:#000;font-weight:bold;float:left;\" >ĐVT</div>"
                + "<div style=\"width:8%;height:30px;color:#000;font-weight:bold;float:left\" >SLTon </div>"
                + "<div style=\"width:7%;height:30px;color:#000;font-weight:bold;float:left\" >Dự trù</div>"
                + "</div>",
        formatItem: function(data) {
              return data[0];
        } 
    }).result(function(event, data) {
        $(obj).val(data[4]);
        $("#idthuoc").val(data[1]);
         setTimeout(function() {
            $("#layds").focus();            
         }, 100);
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
	        width: 280px;
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
	        width: 63%;
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
                    Kiểm Tra Dự Trù
                </p>
                <div class="in-a">
                    <div class="div-Out" style="border: 1px solid #ccc;">
                        <h4>
                            Đối tượng
                        </h4>
                        <p>
                            <select id="loaithuocid" mkv="true" style="width:170px">
                            </select>
                        </p>
                    </div>
                    <div class="div-Out" style="border: 1px solid #ccc;width:400px;">
                        <h4>
                            Tên thuốc</h4>
                        <p style="width: 80%;">
                            <input type="hidden" id="idthuoc" mkv="true" />
                            <input type="text" id="tenthuoc" onfocus="idthuocsearch(this);" mkv="true" />
                        </p>
                    </div>
                    <div style="border:1px solid #ccc;" class="div-Out">
                        <input type="button" value="Lấy danh sách" id="layds" />
                    </div>
                </div>
                <fieldset>
                    <legend>DỰ TRÙ CHO BỆNH NHÂN</legend>
                    <div id="tableAjaxDSChiDinh">
                    </div>
                </fieldset>
                <fieldset style="padding-top:10px;">
                    <legend>DỰ TRÙ TỪ YÊU CẦU BÙ TỦ TRỰC</legend>
                    <div id="tableAjaxDSYEUCAU">
                    </div>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>
