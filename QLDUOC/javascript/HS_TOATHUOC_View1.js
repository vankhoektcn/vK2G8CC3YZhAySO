$(document).ready(function() {

var IsDaXuat=$.mkv.queryString("IsDaXuat");
if(IsDaXuat==null) IsDaXuat="0";
if(IsDaXuat=="1")$(".header-div").append("DANH SÁCH BỆNH NHÂN ĐÃ PHÁT THUỐC"); 
    else $(".header-div").append("DANH SÁCH BỆNH NHÂN CHỜ PHÁT THUỐC");
   SetDefaultData();
//   setControlFind($.mkv.queryString("idkhoachinh"));
   $("#luu").click(function () {
       $(this).Luu({
          ajax:"../ajax/HS_TOATHUOC_View_ajax1.aspx?do=Luu"
          },null,function () {
             $("#timKiem").click();
       });
    });
    $("#moi").click(function () {
         $(this).Moi();  
    });
    $("#xoa").click(function () {
        $(this).Xoa({
            ajax:'../ajax/HS_TOATHUOC_View_ajax1.aspx?do=xoa'
        },null,function () {
             $("#timKiem").click();
        });
    });
    $("#timKiem").click(function () {
        Find(this);
    });
});
function setControlFind(idkhoatimkiem,IdKhoPhat) {
  if(idkhoatimkiem != "" && idkhoatimkiem != null){
     window.open("HS_TOATHUOC_View3.aspx#idkhoachinh="+idkhoatimkiem+"&IdKho="+IdKhoPhat+"&IsDaXuat=1" ,"_main");
  }      
}
function PHATTHUOC(IDBENHNHAN,NGAYTOA,obj,IdKhoPhat) {
$(obj).css("display","none");
$("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
$.ajax({
        async:false,
        cache:false,
        url:"../ajax/HS_TOATHUOC_View_ajax1.aspx?do=PHATTHUOC&IDBENHNHAN="+IDBENHNHAN+"&NGAYTOA="+NGAYTOA+"&IdKho="+IdKhoPhat,
        success:function(data){
            $("#loadingAjax").remove();
            window.open("HS_TOATHUOC_View3.aspx#idkhoachinh="+data +"&IdKho="+IdKhoPhat+"&IsDaXuat=0","_main");
        }
    }); 
     
}


function Find(control,page) {
if(page == null) page = "1";
var IsDaXuat=$.mkv.queryString("IsDaXuat");
if(IsDaXuat==null) IsDaXuat="0";
  $(control).TimKiem({
         ajax:"../ajax/HS_TOATHUOC_View_ajax1.aspx?do=TimKiem"
                                                +"&IdKho="+$.mkv.queryString("IdKho")
                                                +"&IsDaXuat="+IsDaXuat
                                                +"&page="+page
                                                ,showPopup:false
   },function () {
     $("#tableAjax_HS_TOATHUOC_View").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
     return true;
  },function (data) {
         $("#tableAjax_HS_TOATHUOC_View").html(data);
         $("table.jtable tr:nth-child(odd)").addClass("odd");
             $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
             $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
   });
  
}
function SetDefaultData()
 {
    $.BindFind({
        ajax:"../ajax/HS_TOATHUOC_View_ajax1.aspx?do=SetDefaultData",useEnabled:false
    });
 }