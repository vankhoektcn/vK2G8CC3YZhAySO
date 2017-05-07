 $(document).ready(function() {
         $.mkv.moveUpandDown("#tablefind");
       setControlFind($.mkv.queryString("idkhoachinh"));
         $("#luu").click(function () {
           $(this).Luu({
                 ajax:"../ajax/KB_NHOMPHAUTHUAT_ajax3.aspx?do=Luu"
              },null,function () {
                   $.LuuTable({
                         ajax:"../ajax/KB_NHOMPHAUTHUAT_ajax3.aspx?do=luuTableKB_PHANNHOMPHAUTHUAT&IdNhomPhauThuat=" + $.mkv.queryString("idkhoachinh"),
                         tablename:"gridTable"
                   });
              });
        });
        $("#moi").click(function () {
             $(this).Moi();                    
             loadTableAjaxKB_PHANNHOMPHAUTHUAT('');
        });
        $("#xoa").click(function () {
           $(this).Xoa({
                 ajax:"../ajax/KB_NHOMPHAUTHUAT_ajax3.aspx?do=xoa"
            },null,function () {
                 loadTableAjaxKB_PHANNHOMPHAUTHUAT('');
             });
        });
        $("#timKiem").click(function () {
            Find($(this)); 
         });
 });
   function setControlFind(idkhoatimkiem) {
      if(idkhoatimkiem != "" && idkhoatimkiem != null){
         $.BindFind({ajax:"../ajax/KB_NHOMPHAUTHUAT_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem,dataType:"json"},null,function () {
             loadTableAjaxKB_PHANNHOMPHAUTHUAT($.mkv.queryString("idkhoachinh"));                    
         });
      }else{loadTableAjaxKB_PHANNHOMPHAUTHUAT();}         
    }
  function Find(control,page) {
      if(page == null)page = "1";
      $(control).TimKiem({
             ajax:"../ajax/KB_NHOMPHAUTHUAT_ajax3.aspx?do=TimKiem&page="+page
       });
  }
 function xoaontable(control,bool){
   if(bool || bool == null)
      $(control).XoaRow({
         ajax:"../ajax/KB_NHOMPHAUTHUAT_ajax3.aspx?do=xoaKB_PHANNHOMPHAUTHUAT"
      });
 }
 function loadTableAjaxKB_PHANNHOMPHAUTHUAT(idkhoa,page)
 {
     if(idkhoa == null) idkhoa = "";
         if(page == null) page = "1";
         $("#tableAjax_KB_PHANNHOMPHAUTHUAT").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
          $.ajax({
         type:"GET",
         cache:false,
         url:"../ajax/KB_NHOMPHAUTHUAT_ajax3.aspx?do=loadTableKB_PHANNHOMPHAUTHUAT&IdNhomPhauThuat="+idkhoa+"&page="+page,
          success: function (value){
                 document.getElementById("tableAjax_KB_PHANNHOMPHAUTHUAT").innerHTML=value;
                $("table.jtable tr:nth-child(odd)").addClass("odd");
                 $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                 $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
            }
     });
 }
