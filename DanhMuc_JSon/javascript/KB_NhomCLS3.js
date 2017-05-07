         $(document).ready(function() {
                 $.mkv.moveUpandDown("#tablefind");
               setControlFind($.mkv.queryString("idkhoachinh"));
                 $("#luu").click(function () {
                   $(this).Luu({
                         ajax:"../ajax/KB_NhomCLS_ajax3.aspx?do=Luu"
                      },null,function () {
                           $.LuuTable({
                                 ajax:"../ajax/KB_NhomCLS_ajax3.aspx?do=luuTableKB_ChiTietNhomCLS&NhomID=" + $.mkv.queryString("idkhoachinh"),
                                 tablename:"gridTable"
                           });
                      });
                });
                $("#moi").click(function () {
                     $(this).Moi();                    
                     loadTableAjaxKB_ChiTietNhomCLS('');
                });
                $("#xoa").click(function () {
                   $(this).Xoa({
                         ajax:"../ajax/KB_NhomCLS_ajax3.aspx?do=xoa"
                    },null,function () {
                         loadTableAjaxKB_ChiTietNhomCLS('');
                     });
                });
                $("#timKiem").click(function () {
                    Find($(this)); 
                 });
         });
           function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                   $.BindFind({ajax:"../ajax/KB_NhomCLS_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem,dataType:"json"},null,function () {
                     loadTableAjaxKB_ChiTietNhomCLS($.mkv.queryString("idkhoachinh"));                    
                 });
              }else{loadTableAjaxKB_ChiTietNhomCLS();}         
            }
          function Find(control,page) {
              if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/KB_NhomCLS_ajax3.aspx?do=TimKiem&page="+page
               });
          }
         function xoaontable(control,bool){
           if(bool || bool == null)
              $(control).XoaRow({
                 ajax:"../ajax/KB_NhomCLS_ajax3.aspx?do=xoaKB_ChiTietNhomCLS"
              });
         }
         function loadTableAjaxKB_ChiTietNhomCLS(idkhoa,page)
         {
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_KB_ChiTietNhomCLS").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/KB_NhomCLS_ajax3.aspx?do=loadTableKB_ChiTietNhomCLS&NhomId="+idkhoa+"&page="+page,
                  success: function (value){
                         document.getElementById("tableAjax_KB_ChiTietNhomCLS").innerHTML=value;
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                    }
             });
         }
         function idbanggiadichvuSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/KB_NhomCLS_ajax3.aspx?do=idbanggiadichvuSearch",{
             minChars:0,
             width:350,
             addRow:true,
             scroll:true,
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                       if($(obj).parents("#gridTable").attr("id") != null)
                            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
