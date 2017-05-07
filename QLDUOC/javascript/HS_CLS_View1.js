$(document).ready(function() {

var IsDaXuat=$.mkv.queryString("IsDaXuat");
if(IsDaXuat==null) IsDaXuat="0";
if(IsDaXuat=="1")$(".header-div").append("DANH SÁCH BỆNH NHÂN ĐÃ KIỂM TRA"); 
    else $(".header-div").append("DANH SÁCH BỆNH NHÂN CHỜ KIỂM TRA");
   SetDefaultData();
   setControlFind($.mkv.queryString("idkhoachinh"));
   $("#luu").click(function () {
       $(this).Luu({
          ajax:"../ajax/HS_CLS_View_ajax1.aspx?do=Luu"
          },null,function () {
             $("#timKiem").click();
       });
    });
    $("#moi").click(function () {
         $(this).Moi();  
    });
    $("#xoa").click(function () {
        $(this).Xoa({
            ajax:'../ajax/HS_CLS_View_ajax1.aspx?do=xoa'
        },null,function () {
             $("#timKiem").click();
        });
    });
    $("#timKiem").click(function () {
        Find(this);
    });
});
function setControlFind(idkhoatimkiem) {
  if(idkhoatimkiem != "" && idkhoatimkiem != null){
     window.open("HS_CLS_View3.aspx?idkhoachinh="+idkhoatimkiem+"&IsDaXuat=1" );
  }      
}
function PHATTHUOC(idkhambenh,NGAYTOA,obj) {
$(obj).css("display","none");
$.ajax({
        async:false,
        cache:false,
        url:"../ajax/HS_CLS_View_ajax1.aspx?do=PHATTHUOC&idkhambenh="+idkhambenh+"&NGAYTOA="+NGAYTOA,
        success:function(data){
            window.open("HS_CLS_View3.aspx?idkhoachinh="+data +"&IsDaXuat=0");
        }
    }); 
     
}


function Find(control,page) {
if(page == null) page = "1";
var IsDaXuat=$.mkv.queryString("IsDaXuat");
if(IsDaXuat==null) IsDaXuat="0";
  $(control).TimKiem({
         ajax:"../ajax/HS_CLS_View_ajax1.aspx?do=TimKiem"
                                                +"&IsDaXuat="+IsDaXuat
                                                +"&page="+page
                                                ,showPopup:false
   },function () {
     $("#tableAjax_HS_CLS_View").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
     return true;
  },function (data) {
         $("#tableAjax_HS_CLS_View").html(data);
         $("table.jtable tr:nth-child(odd)").addClass("odd");
             $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
             $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
   });
  
}
function SetDefaultData()
 {
    $.BindFind({
        ajax:"../ajax/HS_CLS_View_ajax1.aspx?do=SetDefaultData",useEnabled:false
    });
 }