 $(document).ready(function() {
         $.mkv.moveUpandDown("#tablefind");
       setControlFind($.mkv.queryString("idkhoachinh"));
         $("#luu").click(function () {
           $(this).Luu({
                 ajax:"../ajax/HS_BANGGIAGIUONG_LAN_ajax3.aspx?do=Luu"
              },
              null
              ,function () {
                   $.LuuTable({
                         ajax:"../ajax/HS_BANGGIAGIUONG_LAN_ajax3.aspx?do=luuTableHS_BANGGIAGIUONG&BANGGIAID=" + $.mkv.queryString("idkhoachinh"),
                         tablename:"gridTable"
                   },null,function(){
                                           $.ajax({
				                                        url:"../ajax/HS_BANGGIAGIUONG_LAN_ajax3.aspx?do=PhanBoBangGia&BangGiaID=" + $.mkv.queryString("idkhoachinh"),
				                                        cache:false,
				                                        async:false,
				                                        type:"GET",
				                                        success:function(data){
				                                        }
			                                        });
                   
                                    });
              });
        });
        $("#moi").click(function () {
             $(this).Moi();                    
             loadTableAjaxHS_BANGGIAGIUONG('');
        });
        $("#xoa").click(function () {
           $(this).Xoa({
                 ajax:"../ajax/HS_BANGGIAGIUONG_LAN_ajax3.aspx?do=xoa"
            },null,function () {
                 loadTableAjaxHS_BANGGIAGIUONG('');
             });
        });
        $("#timKiem").click(function () {
            Find($(this)); 
         });
 });
   function setControlFind(idkhoatimkiem) {
      if(idkhoatimkiem != "" && idkhoatimkiem != null){
           $.BindFind({ajax:"../ajax/HS_BANGGIAGIUONG_LAN_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem,dataType:"json"},null,function () {
             loadTableAjaxHS_BANGGIAGIUONG($.mkv.queryString("idkhoachinh"));                    
         });
      }else{loadTableAjaxHS_BANGGIAGIUONG();}         
    }
  function Find(control,page) {
      if(page == null)page = "1";
      $(control).TimKiem({
             ajax:"../ajax/HS_BANGGIAGIUONG_LAN_ajax3.aspx?do=TimKiem&page="+page
       });
  }
 function xoaontable(control,bool){
   if(bool || bool == null)
      $(control).XoaRow({
         ajax:"../ajax/HS_BANGGIAGIUONG_LAN_ajax3.aspx?do=xoaHS_BANGGIAGIUONG"
      });
 }
 function loadTableAjaxHS_BANGGIAGIUONG(idkhoa,page)
 {
     if(idkhoa == null) idkhoa = "";
         if(page == null) page = "1";
         $("#tableAjax_HS_BANGGIAGIUONG").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
          $.ajax({
         type:"GET",
         cache:false,
         url:"../ajax/HS_BANGGIAGIUONG_LAN_ajax3.aspx?do=loadTableHS_BANGGIAGIUONG&BANGGIAID="+idkhoa+"&page="+page,
          success: function (value){
                 document.getElementById("tableAjax_HS_BANGGIAGIUONG").innerHTML=value;
                $("table.jtable tr:nth-child(odd)").addClass("odd");
                 $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                 $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
            }
     });
 }
 function IDLOAIGIUONGSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/HS_BANGGIAGIUONG_LAN_ajax3.aspx?do=IDLOAIGIUONGSearch",{
     minChars:0,
     width:350,
     addRow:true,
     scroll:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
