 $(document).ready(function() {
       setControlFind($.mkv.queryString("idkhoachinh"));
       $("#luu").click(function () {
           $(this).Luu({
              ajax:"../ajax/frm_DM_Kho_ajax.aspx?do=Luu"
              },null,function () {
                 $("#timKiem").click();
           });
        });
        $("#moi").click(function () {
             $(this).Moi();  
        });
        $("#xoa").click(function () {
            $(this).Xoa({
                ajax:'../ajax/frm_DM_Kho_ajax.aspx?do=xoa'
            },null,function () {
                 $("#timKiem").click();
            });
        });
        $("#timKiem").click(function () {
            Find(this);
        });
        $("#timKiem").click();
 });
  function setControlFind(idkhoatimkiem) {
      if(idkhoatimkiem != "" && idkhoatimkiem != null){
         $.BindFind({ajax:"../ajax/frm_DM_Kho_ajax.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem});
      }      
  }
   function Find(control,page) {
   if(page == null) page = "1";
      $(control).TimKiem({
             ajax:"../ajax/frm_DM_Kho_ajax.aspx?do=TimKiem&page="+page,showPopup:false
       },function(){
              $("#tableAjax_khothuoc").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
            return true;
       },function(data){
              $("#tableAjax_khothuoc").html(data);
             $("table.jtable tr:nth-child(odd)").addClass("odd");
                 $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                 $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
       });
  }
function IdKhoaSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/frm_DM_Kho_ajax.aspx?do=IdKhoaSearch",{
     minChars:0,
     width:350,
     scroll:true,
     header:"DANH SÁCH",
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
         $("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }