         $(document).ready(function() {
               setControlFind($.mkv.queryString("idkhoachinh"));
               setIdKho();
               $("#luu").click(function () {
                   $(this).Luu({
                      ajax:"../ajax/HS_BangGiaThuoc_View_ajax.aspx?do=Luu"
                      },null,function () {
                         $("#timKiem").click();
                   });
                });
                $("#moi").click(function () {
                     $(this).Moi();  
                });
                $("#xoa").click(function () {
                    $(this).Xoa({
                        ajax:'../ajax/HS_BangGiaThuoc_View_ajax.aspx?do=xoa'
                    },null,function () {
                         $("#timKiem").click();
                    });
                });
                $("#timKiem").click(function () {
                    Find(this);
                });
         function setIdKho()
         {
            var idkho=$.mkv.queryString("IDKHO_NHAP");
            var IdLoaiThuoc=$.mkv.queryString("IdLoaiThuoc");
            
            $.BindFind({
                ajax:"../ajax/HS_BangGiaThuoc_View_ajax.aspx?do=setIdKho&idkho="+idkho+"&IdLoaiThuoc="+IdLoaiThuoc
            });
         }
         });
          function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/HS_BangGiaThuoc_View_ajax.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem});
              }      
          }
           function Find(control,page) {
           if(page == null) page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/HS_BangGiaThuoc_View_ajax.aspx?do=TimKiem&denngay="+$("#denngay").val()+"&page="+page,showPopup:false
               },function () {
                 $("#tableAjax_chitietphieunhapkho").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                 return true;
              },function (data) {
                     $("#tableAjax_chitietphieunhapkho").html(data);
                     $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
               });
              
          }
        function idphieunhapSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/HS_BangGiaThuoc_View_ajax.aspx?do=idphieunhapSearch",{
             minChars:0,
             width:350,
             scroll:true,
             formatItem:function (data) {
                 return data[0];
             }}).result(function(event,data){
                 $("#"+obj.id.replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
        function idthuocSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/HS_BangGiaThuoc_View_ajax.aspx?do=idthuocSearch&IdLoaiThuoc="+$("#IdLoaiThuoc").val(),{
             minChars:0,
             width:350,
             scroll:true,
             formatItem:function (data) {
                 return data[0];
             }}).result(function(event,data){
                 $("#"+obj.id.replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
        function dvtSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/HS_BangGiaThuoc_View_ajax.aspx?do=dvtSearch",{
             minChars:0,
             width:350,
             scroll:true,
             formatItem:function (data) {
                 return data[0];
             }}).result(function(event,data){
                 $("#"+obj.id.replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
        function IdLoaiThuocSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/HS_BangGiaThuoc_View_ajax.aspx?do=IdLoaiThuocSearch",{
             minChars:0,
             width:350,
             scroll:true,
             formatItem:function (data) {
                 return data[0];
             }}).result(function(event,data){
                 $("#"+obj.id.replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         //───────────────────────────────────────────────────────────────────────────────────────
        function idkhoSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/HS_BangGiaThuoc_View_ajax.aspx?do=idkhoSearch",{
             minChars:0,
             width:250,
             scroll:true,
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         //───────────────────────────────────────────────────────────────────────────────────────