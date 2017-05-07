         $(document).ready(function() {
            $.mkv.moveUpandDown("#gridTable");
                setControlFind($.mkv.queryString("idkhambenhgoc"));
                 $("#luu").click(function () {
                     $(this).Luu({
                         ajax:"../ajax/kcb_sosinh_ajax.aspx?do=Luu&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc"),idkhoachinh:"idkcbsosinh"
                     });
                });
                $("#moi").click(function () {
                    $(this).Moi({idkhoachinh:""});
                });
                $("#xoa").click(function () {
                   $.mkv.XoaTrangData();
                    $("#_luu").click();
                    $("#luu").click();
                });
                
         });
        function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/kcb_sosinh_ajax.aspx?do=setTimKiem&idkhambenhgoc="+idkhoatimkiem,idkhoachinh:"idkcbsosinh",readMKV:false});                    
             }        
         }

