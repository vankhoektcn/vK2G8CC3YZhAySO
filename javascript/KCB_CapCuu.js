         
         
         
         $(document).ready(function() {
                 $("#luu").click(function () {
                     $(this).Luu({
                         ajax:"../ajax/KCB_CapCuu_ajax.aspx?do=Luu&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc"),idkhoachinh:"idkcbcapcuu"
                     });
                });
                $("#moi").click(function () {
                    $(this).Moi({idkhoachinh:""});
                });
                $("#xoa").click(function () {
                    $.mkv.XoaTrangData();
                    $("#_luu").click();
                    $("#luu").Luu({
                         ajax:"../ajax/KCB_CapCuu_ajax.aspx?do=Luu&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc"),idkhoachinh:"idkcbcapcuu"
                      });
                });
                setControlFind($.mkv.queryString("idkhambenhgoc"));
         });
        function setControlFind(idkhoatimkiem) {
                 $.BindFind({ajax:"../ajax/KCB_CapCuu_ajax.aspx?do=setTimKiem&idkhambenhgoc="+idkhoatimkiem,idkhoachinh:"idkcbcapcuu",readMKV:false});                    
         }