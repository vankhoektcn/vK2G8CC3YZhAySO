         $(document).ready(function() {
                 $.mkv.moveUpandDown("#tablefind");
               setControlFind($.mkv.queryString("idkhoachinh"));
                 $("#luu").click(function () {
                   $(this).Luu({
                         ajax:"../ajax/HS_ChiTietPhieuXuat_ajax.aspx?do=Luu"
                      },null,function () {
                           $.LuuTable({
                                 ajax:"../ajax/HS_ChiTietPhieuXuat_ajax.aspx?do=luuTablechitietphieuxuatkho&idphieuxuat=" + $.mkv.queryString("idkhoachinh"),
                                 tablename:"gridTable"
                           });
                      });
                });
                $("#moi").click(function () {
                     $(this).Moi();                    
                     loadTableAjaxchitietphieuxuatkho('');
                });
                $("#xoa").click(function () {
                   $(this).Xoa({
                         ajax:"../ajax/HS_ChiTietPhieuXuat_ajax.aspx?do=xoa"
                    },null,function () {
                         loadTableAjaxchitietphieuxuatkho('');
                     });
                });
                $("#timKiem").click(function () {
                    Find($(this)); 
                 });
         });
           function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/HS_ChiTietPhieuXuat_ajax.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
                     loadTableAjaxchitietphieuxuatkho($.mkv.queryString("idkhoachinh"));                    
                 });
              }else{loadTableAjaxchitietphieuxuatkho();}         
            }
          function Find(control,page) {
              if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/HS_ChiTietPhieuXuat_ajax.aspx?do=TimKiem&page="+page
               });
          }
         function xoaontable(control,bool){
           if(bool || bool == null)
              $(control).XoaRow({
                 ajax:"../ajax/HS_ChiTietPhieuXuat_ajax.aspx?do=xoachitietphieuxuatkho"
              });
         }
         function loadTableAjaxchitietphieuxuatkho(idkhoa,page)
         {
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_chitietphieuxuatkho").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/HS_ChiTietPhieuXuat_ajax.aspx?do=loadTablechitietphieuxuatkho&idphieuxuat="+idkhoa+"&page="+page,
                  success: function (value){
                         document.getElementById("tableAjax_chitietphieuxuatkho").innerHTML=value;
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                    }
             });
         }
         function idthuocSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/HS_ChiTietPhieuXuat_ajax.aspx?do=idthuocSearch",{
             minChars:0,
             width:350,
             scroll:true,
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function dvtSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/HS_ChiTietPhieuXuat_ajax.aspx?do=dvtSearch",{
             minChars:0,
             width:350,
             scroll:true,
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
