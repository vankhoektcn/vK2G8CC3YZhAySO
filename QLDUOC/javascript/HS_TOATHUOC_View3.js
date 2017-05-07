 $(document).ready(function() {
 //───────────────────────────────────────────────────────────────────────────────────────
       $.mkv.moveUpandDown("#tablefind");
       setControlFind($.mkv.queryString("idkhoachinh"));
       var IsDaXuat=$.mkv.queryString("IsDaXuat");
       if(IsDaXuat=="1")
       {
            $("#PhatThuoc").css("display", "none");
       
       }
       else
       {
           $("#xoa").css("display", "none");
       }
       if($.isNullOrEmpty($.mkv.queryString("IdKho")) || $.mkv.queryString("IdKho")=="5")
            $("#InBV01").css("display", "");
       else            
            $("#InBV01").css("display", "none");
//───────────────────────────────────────────────────────────────────────────────────────
         $("#luu").click(function () {
           $(this).Luu({
                 ajax:"../ajax/HS_TOATHUOC_View_ajax3.aspx?do=Luu"
              },null,function () {
                   $.LuuTable({
                         ajax:"../ajax/HS_TOATHUOC_View_ajax3.aspx?do=luuTableHS_ToaThuoc_ViewDetail&IdToaThuoc=" + $.mkv.queryString("idkhoachinh"),
                         tablename:"gridTable"
                   });
              });
        });
//───────────────────────────────────────────────────────────────────────────────────────                
        $("#moi").click(function () {
             $(this).Moi();                    
             loadTableAjaxHS_ToaThuoc_ViewDetail('');
        });
 //───────────────────────────────────────────────────────────────────────────────────────
        $("#xoa").click(function () {
           $(this).Xoa({
                 ajax:"../ajax/HS_TOATHUOC_View_ajax3.aspx?do=xoa"
            },function () {
                 //$("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');                 
                 return true;
             },function () {
                 //$("#loadingAjax").remove();
                 loadTableAjaxHS_ToaThuoc_ViewDetail('');
             });
        });
 //───────────────────────────────────────────────────────────────────────────────────────
        $("#timKiem").click(function () {
            Find($(this)); 
         });
//───────────────────────────────────────────────────────────────────────────────────────
$("#InBV01").click(function () {
        $.ajax({
        async:false,
        cache:true,
        dataType:"text",
        url:"../ajax/HS_TOATHUOC_View_ajax3.aspx?do=InBV01&idkhoachinh="+$.mkv.queryString("idkhoachinh"),
        success:function(value){
          if(value!=""){
              window.open("../../VienPhi_BH/frm_rpt_chiphikhambenh.aspx?idphieutt="+value );
          }
        },
        error:function(data){
            $.mkv.myerror("Không thể In mẫu BV được");
        }
    }); 
         });
//───────────────────────────────────────────────────────────────────────────────────────
 $("#PhatThuoc").click(function(){
   if(checkSLTon())
   {
     $("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
     $.ajax({
        async:false,
        cache:true,
        dataType:"text",
        url:"../ajax/HS_TOATHUOC_View_ajax3.aspx?do=XuatThuoc&idkhoachinh="+$.mkv.queryString("idkhoachinh"),
        success:function(value){
          if(value=="1"){
             if($.isNullOrEmpty($.mkv.queryString("IdKho")) || $.mkv.queryString("IdKho")=="5")
             {
                $("#InBV01").click();
                window.close();
             }
             else
             {
                 $("#loadingAjax").remove();
                 $.mkv.myalert("Xuất thuốc thành công !",2000,"success");
                 $("#PhatThuoc").css("display", "none");
             }
          }
        },
        error:function(data){
            $("#loadingAjax").remove();
            $.mkv.myerror(""+data);
        }
    });
   } 
});
//───────────────────────────────────────────────────────────────────────────────────────
 }); //end ready
//───────────────────────────────────────────────────────────────────────────────────────
   function setControlFind(idkhoatimkiem) {
      if(idkhoatimkiem != "" && idkhoatimkiem != null){
         $.BindFind({ajax:"../ajax/HS_TOATHUOC_View_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
             loadTableAjaxHS_ToaThuoc_ViewDetail($.mkv.queryString("idkhoachinh"));                    
         });
      }else{loadTableAjaxHS_ToaThuoc_ViewDetail();}         
    }
    //───────────────────────────────────────────────────────────────────────────────────────
  function Find(control,page) {
      if(page == null)page = "1";
      $(control).TimKiem({
             ajax:"../ajax/HS_TOATHUOC_View_ajax3.aspx?do=TimKiem&page="+page
       });
  }
  //───────────────────────────────────────────────────────────────────────────────────────
 function xoaontable(control,bool){
   if(bool || bool == null)
      $(control).XoaRow({
         ajax:"../ajax/HS_TOATHUOC_View_ajax3.aspx?do=xoaHS_ToaThuoc_ViewDetail"
      });
 }
 //───────────────────────────────────────────────────────────────────────────────────────
 function loadTableAjaxHS_ToaThuoc_ViewDetail(idkhoa,page)
 {
     if(idkhoa == null) idkhoa = "";
         if(page == null) page = "1";
         $("#tableAjax_HS_ToaThuoc_ViewDetail").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
          $.ajax({
         type:"GET",
         cache:false,
         url:"../ajax/HS_TOATHUOC_View_ajax3.aspx?do=loadTableHS_ToaThuoc_ViewDetail&IdToaThuoc="+idkhoa+"&page="+page,
          success: function (value){
                 document.getElementById("tableAjax_HS_ToaThuoc_ViewDetail").innerHTML=value;
                $("table.jtable tr:nth-child(odd)").addClass("odd");
                 $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                 $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
            }
     });
 }
//───────────────────────────────────────────────────────────────────────────────────────
function checkSLTon()
{
    var rowParent=$('#gridTable >tbody >tr');
    var rowChild=$('#gridTableThuoc >tbody >tr');
    var msg=true;
    for(var i=1;i<rowParent.length;i++)
    {
        for(j=1;j<rowChild.length;j++)
        {
            var tenthuoc=$("#gridTableThuoc").find("tr").eq(j).find("td").eq(1).text(); //get ten thuoc
            var sl=eval($("#gridTableThuoc").find("tr").eq(j).find("td").eq(4).find("#soluong").val()); // get soluong row j
            var slton=eval($("#gridTableThuoc").find("tr").eq(j).find("td").eq(4).find("#slton").val()); //get slton row j
            if(sl>slton)
            {
                $.mkv.myerror(tenthuoc + ": không đủ tồn.");
                $("#gridTableThuoc").find("tr").eq(j).css("background-color","#f09090");
                msg=false;
            }
        }
    }
    return msg;
}