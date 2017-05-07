         $(document).ready(function() {
               setControlFind($.mkv.queryString("idsinhhieu"));
               $("#luu").click(function () {
                   $(this).Luu({
                      ajax:"../ajax/sinhhieu_ajax1.aspx?do=Luu&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc")+"&idkhoachinh="+$.mkv.queryString("idkhoachinh"),idkhoachinh:"idsinhhieu"
                      },null,function () {
                         $("#timKiem").click();
                   });
                });
                $("#moi").click(function () {
                     $(this).Moi({idkhoachinh:"idsinhhieu"});
                });
                $("#xoa").click(function () {
                    $(this).Xoa({
                        ajax:'../ajax/sinhhieu_ajax1.aspx?do=xoa',idkhoachinh:"idsinhhieu"
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
              if(idkhoatimkiem != null && idkhoatimkiem != ""){
                 $.BindFind({ajax:"../ajax/sinhhieu_ajax1.aspx?do=setTimKiem&idsinhhieu="+idkhoatimkiem,idkhoachinh:"idsinhhieu"});
              }      
          }
           function Find(control,page) {
           if(page == null) page = "1";
              $(control).TimKiem({
                    readMKV:false,
                     ajax:"../ajax/sinhhieu_ajax1.aspx?do=TimKiem&page="+page+"&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc")
               },function (data) {
                     $("#tableAjax_sinhhieu").html(data);
                     $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
               },function () {
                 $("#tableAjax_sinhhieu").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                 return true;
               });
              
          }
          
          function tinhBMI()
          {
             $("#BMI").val((eval($("#chieucao").val())*eval($("#chieucao").val()))/eval($("#cannang").val()));
          }
