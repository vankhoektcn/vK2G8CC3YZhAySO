         $(document).ready(function() {
                 $.mkv.moveUpandDown("#tablefind");
               setControlFind($.mkv.queryString("idkhambenhgoc"));
                 $("#luu").click(function () {
                   $(this).Luu({
                         ajax:"../ajax/kcb_khoasan_ajax.aspx?do=Luu&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc"),idkhoachinh:"idkcbkhoasan"
                      },null,function () {
                           $.LuuTable({
                                 ajax:"../ajax/kcb_khoasan_ajax.aspx?do=luuTableKCB_PhuongPhapDieuTri&idkcbkhoasan=" + $.mkv.queryString("idkcbkhoasan"),
                                 tablename:"gridTable"
                           });
                      });
                });
                $("#moi").click(function () {
                     $(this).Moi({idkhoachinh:""});                    
                     loadTableAjaxKCB_PhuongPhapDieuTri('');
                });
                $("#xoa").click(function () {
                   $.mkv.XoaTrangData();
                    $("#_luu").click();
                    $("#luu").Luu({
                         ajax:"../ajax/kcb_khoasan_ajax.aspx?do=Luu&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc"),idkhoachinh:"idkcbkhoasan"
                      });
                    $(this).Xoa({
                         ajax:"../ajax/kcb_khoasan_ajax.aspx?do=xoaKCB_PhuongPhapDieuTri&idkcbkhoasan="+$.mkv.queryString("idkcbkhoasan"),valueConfirm: "Xác nhận xoá danh sách phương pháp điều trị ?"
                      });
                      loadTableAjaxKCB_PhuongPhapDieuTri('');
                });
         });
           function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != null && idkhoatimkiem != ""){
                 $.BindFind({ajax:"../ajax/kcb_khoasan_ajax.aspx?do=setTimKiem&idkhambenhgoc="+idkhoatimkiem},null,function () {
                     loadTableAjaxKCB_PhuongPhapDieuTri($.mkv.queryString("idkcbkhoasan"));                    
                 });
              }else{loadTableAjaxKCB_PhuongPhapDieuTri();}         
         }
         function xoaontable(control){
              $(control).XoaRow({
                 ajax:"../ajax/kcb_khoasan_ajax.aspx?do=xoaKCB_PhuongPhapDieuTri"
              });
         }
         function loadTableAjaxKCB_PhuongPhapDieuTri(idkhoa,page)
         {
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_KCB_PhuongPhapDieuTri").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/kcb_khoasan_ajax.aspx?do=loadTableKCB_PhuongPhapDieuTri&idkcbkhoasan="+idkhoa+"&page="+page,
                  success: function (value){
                         $("#tableAjax_KCB_PhuongPhapDieuTri").html(value);
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                    }
             });
         }
