        
         
         
         
         
         $(document).ready(function() {
              Find();
         });
           function Find(page) {
                 if(page == null) page = "1";
                 $("#tableAjax_bangkebienlai").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/bienlai_CapCuu_ajax.aspx?do=TimKiem&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc")+"&page="+page,
                  success: function (value){
                         $("#tableAjax_bangkebienlai").html(value);
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                    }
             });
              
          }
