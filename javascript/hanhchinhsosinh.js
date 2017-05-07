         $(document).ready(function() {
                setControlFind($.mkv.queryString("idkhambenhgoc"));
         });
        function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/hanhchinhsosinh_ajax.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem});                    
             }        
         }
