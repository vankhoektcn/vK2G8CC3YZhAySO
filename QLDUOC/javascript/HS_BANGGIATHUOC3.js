$(document).ready(function() {
     $.mkv.moveUpandDown("#tablefind");
   setControlFind($.mkv.queryString("idkhoachinh"));
   SetDefaultInfor();
     $("#luu").click(function () {
       $(this).Luu({
             ajax:"../ajax/HS_BANGGIATHUOC_ajax3.aspx?do=Luu"
          },null,function () {
               $.LuuTable({
                     ajax:"../ajax/HS_BANGGIATHUOC_ajax3.aspx?do=luuTableHS_BANGGIATHUOC_DETAIL&IDBANGGIA=" + $.mkv.queryString("idkhoachinh"),
                     tablename:"gridTable"
               });
          });
    });
    $("#moi").click(function () {
         
         $(this).Moi();                    
         loadTableAjaxHS_BANGGIATHUOC_DETAIL('');
         SetDefaultInfor();
    });
    $("#xoa").click(function () {
       $(this).Xoa({
             ajax:"../ajax/HS_BANGGIATHUOC_ajax3.aspx?do=xoa"
        },null,function () {
             loadTableAjaxHS_BANGGIATHUOC_DETAIL('');
             SetDefaultInfor();
         });
    });
    $("#timKiem").click(function () {
        Find($(this)); 
     });
    $("#TuNgay").bind("focus",function(){
        $(this).datepick();
     });
});
function setControlFind(idkhoatimkiem) {
  if(idkhoatimkiem != "" && idkhoatimkiem != null){
     $.BindFind({ajax:"../ajax/HS_BANGGIATHUOC_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
         loadTableAjaxHS_BANGGIATHUOC_DETAIL($.mkv.queryString("idkhoachinh"));                    
     });
  }else{loadTableAjaxHS_BANGGIATHUOC_DETAIL();}         
}
function Find(control,page) {
  if(page == null)page = "1";
  $(control).TimKiem({
         ajax:"../ajax/HS_BANGGIATHUOC_ajax3.aspx?do=TimKiem&page="+page
   },null,function(data){
        if(data==""|| data==null){
            $.mkv.closeDivTimKiem();
        }
   });
}
function xoaontable(control,bool){
if(bool || bool == null)
  $(control).XoaRow({
     ajax:"../ajax/HS_BANGGIATHUOC_ajax3.aspx?do=xoaHS_BANGGIATHUOC_DETAIL"
  });
}
function loadTableAjaxHS_BANGGIATHUOC_DETAIL(idkhoa,page)
{
 if(idkhoa == null) idkhoa = "";
     if(page == null) page = "1";
     $("#tableAjax_HS_BANGGIATHUOC_DETAIL").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
      $.ajax({
     type:"GET",
     cache:false,
     url:"../ajax/HS_BANGGIATHUOC_ajax3.aspx?do=loadTableHS_BANGGIATHUOC_DETAIL&IDBANGGIA="+idkhoa+"&page="+page,
      success: function (value){
             document.getElementById("tableAjax_HS_BANGGIATHUOC_DETAIL").innerHTML=value;
            $("table.jtable tr:nth-child(odd)").addClass("odd");
             $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
             $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
        }
 });
}
function IDTHUOCSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/HS_BANGGIATHUOC_ajax3.aspx?do=IDTHUOCSearch&ISBHYT="+$("#ISBHYT").is(":checked"),{
 minChars:0,
 scroll:true,
 header:false,
 formatItem:function (data) {
      return data[0];
 }}).result(function(event,data){
     if($(obj).parents("#gridTable").attr("id") != null){
         $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
         $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IdDVT").val(data[2]);
         $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_IdDVT").val(data[3]);
         if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
             $.mkv.themDongTable("gridTable");
     }
     setTimeout(function () {
         //obj.focus();
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#DonGia").focus();
     },100);
 });
}
function IdDVTSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/HS_BANGGIATHUOC_ajax3.aspx?do=IdDVTSearch",{
 minChars:0,
 width:350,
 scroll:true,
 formatItem:function (data) {
      return data[0];
 }}).result(function(event,data){
     if($(obj).parents("#gridTable").attr("id") != null){
         $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
         if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
             $.mkv.themDongTable("gridTable");
     }
     setTimeout(function () {
         obj.focus();
     },100);
 });
}
function LoaiThuocIDSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/HS_BANGGIATHUOC_ajax3.aspx?do=LoaiThuocIDSearch",{
 minChars:0,
 width:350,
 scroll:true,
 formatItem:function (data) {
      return data[0];
 }}).result(function(event,data){
         $("#"+obj.id.replace("mkv_","")).val(data[1]);
     setTimeout(function () {
         //obj.focus();
        $("#gridTable").find("tr").find("td:eq(1").find("#mkv_IdThuoc").focus();
     },100);
 });
}
function SetDefaultInfor()
{
      var  ISBHYT_query=$.mkv.queryString("ISBHYT");
      if(ISBHYT_query!=null && ISBHYT_query!="")
      {
        $("#ISBHYT").attr("disabled",true);
        if(ISBHYT_query=="1")
        {
          $("#ISBHYT").attr("checked",true);
        }
        else 
          $("#ISBHYT").attr("checked",false);
      }
      
      
      var  LoaiThuocID_query=$.mkv.queryString("LoaiThuocID");
      if(LoaiThuocID_query!=null && LoaiThuocID_query!="")
      {
        $("#mkv_LoaiThuocID").attr("disabled",true);
        $("#LoaiThuocID").val(LoaiThuocID_query);
        if(LoaiThuocID_query=="1")
        {
          $("#mkv_LoaiThuocID").val("Thuốc");
        }
        if(LoaiThuocID_query=="4")
        {
          $("#mkv_LoaiThuocID").val("Vật tư y tế");
        }
      }
      
      
}//end function