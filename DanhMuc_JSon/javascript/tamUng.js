         $(document).ready(function() {
            $.mkv.moveUpandDown("#gridTable");
                setControlFind($.mkv.queryString("idkhoachinh"));
                
                 $("#luu").click(function () {
                     $(this).Luu({
                         ajax:"../ajax/tamUng_ajax.aspx?do=Luu"
                     });
                });
                $("#moi").click(function () {
                    $(this).Moi();
                });
                $("#xoa").click(function () {
                    $(this).Xoa({ajax:"../ajax/tamUng_ajax.aspx?do=xoa"});
                });
                $("#Print").click(function () {
                     window.open("../../capcuu/frmPhieuBaoThuTamUng.aspx?dkMenu="+$.mkv.queryString("dkMenu")+"&hdIdTamUng="+$.mkv.queryString("idkhoachinh")+"#isPrint=1");
                });
         });
        function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/tamUng_ajax.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem});                    
             }     
            
         }
          function Find(control,page) {
             if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/tamUng_ajax.aspx?do=TimKiem&page="+page
               });
          }
