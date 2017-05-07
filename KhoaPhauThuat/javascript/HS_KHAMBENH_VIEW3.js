         $(document).ready(function() {
         //───────────────────────────────────────────────────────────────────────────────────────
               $.mkv.moveUpandDown("#tablefind");
               setControlFind($.mkv.queryString("idkhoachinh"));
        //───────────────────────────────────────────────────────────────────────────────────────
                $("#moi").click(function () {
                     $(this).Moi();                    
                     loadTableAjaxHS_KHAMBENH_VIEWDetail('');
                });
         //───────────────────────────────────────────────────────────────────────────────────────
                $("#timKiem").click(function () {
                    Find($(this)); 
                 });
                 
        //───────────────────────────────────────────────────────────────────────────────────────
        $("#KhamBenhMoi").click(function () {
                     var LoaiBN=$.mkv.queryString("LoaiBN");
                     var idchitietdangkykham=$.mkv.queryString("idchitietdangkykham");
                     var IDBENHNHAN=$.mkv.queryString("IDBENHNHAN");
                     var idkhambenhchuyenphong=$.mkv.queryString("idkhambenhchuyenphong");
                     
                            window.open("KhamBenh.aspx?LoaiBN="+LoaiBN
                                    +"&idchitietdangkykham="+ idchitietdangkykham
                                    +"&IDBENHNHAN="+IDBENHNHAN
                                    +"&idkhambenhchuyenphong="+idkhambenhchuyenphong
                                    + "&disabledCaKipMo=1"
                                            );
                 });
        
         }); //end ready
      //───────────────────────────────────────────────────────────────────────────────────────
      function ViewKhamBenh(IdKhamBenh)
        {
             window.open("KhamBenh.aspx?idkhoachinh="+IdKhamBenh  + "&disabledCaKipMo=1");

        }
           function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"ajax/HS_KHAMBENH_VIEW_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
                     loadTableAjaxHS_KHAMBENH_VIEWDetail($.mkv.queryString("idkhoachinh"));                    
                 });
              }else{loadTableAjaxHS_KHAMBENH_VIEWDetail();}         
            }
            //───────────────────────────────────────────────────────────────────────────────────────
          function Find(control,page) {
              if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"ajax/HS_KHAMBENH_VIEW_ajax3.aspx?do=TimKiem&page="+page
               });
          }
          //───────────────────────────────────────────────────────────────────────────────────────
         function xoaontable(control,bool){
           if(bool || bool == null)
              $(control).XoaRow({
                 ajax:"ajax/HS_KHAMBENH_VIEW_ajax3.aspx?do=xoaHS_KHAMBENH_VIEWDetail"
              });
         }
         //───────────────────────────────────────────────────────────────────────────────────────
         function loadTableAjaxHS_KHAMBENH_VIEWDetail(idkhoachinh,page)
         {
                 var IdKhoa=$.mkv.queryString("IdKhoa");
                 if(idkhoachinh == null) idkhoachinh = "0";
                 if(page == null) page = "1";
                 $("#tableAjax_HS_KHAMBENH_VIEWDetail").html('<img src="images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"ajax/HS_KHAMBENH_VIEW_ajax3.aspx?do=loadTableHS_KHAMBENH_VIEWDetail&IdToaThuoc="+idkhoachinh
                                                                                                     +"&IdKhoa="+IdKhoa
                                                                                                     +"&page="+page,
                  success: function (value){
                         document.getElementById("tableAjax_HS_KHAMBENH_VIEWDetail").innerHTML=value;
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                    }
             });
         }
        //───────────────────────────────────────────────────────────────────────────────────────
        