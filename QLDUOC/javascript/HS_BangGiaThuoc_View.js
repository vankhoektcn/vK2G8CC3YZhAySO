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
                  //───────────────────────────────────────────────────────────────────────────────────────
               $("#btnXuatExel").click(function(){
                 var LoaiThuocID = $("#IdLoaiThuoc").val();
                 var mkv_LoaiThuocID =  $("#mkv_IdLoaiThuoc").val();
                 var tungay = $("#tungay").val();
                 var denngay =  $("#denngay").val();
                 var IdKho = $("#IDKHO_NHAP").val();
                 var TenKho= $("#mkv_IDKHO_NHAP").val();
                 if( LoaiThuocID==null ||LoaiThuocID=="" ||      mkv_LoaiThuocID==null ||mkv_LoaiThuocID==""
                     ||  tungay==null ||tungay==""||   denngay==null ||denngay==""
                     || IdKho==null ||IdKho=="" 
                    )
                    {
                      $.mkv.myerror(" Vui lòng xác định thông tin : Từ ngày, đến ngày, kho, đối tượng");
                      return;
                    }
                   $.mkv.loading();
                      $.ajax({
                        type:"POST",
                        url:"../ajax/HS_BangGiaThuoc_View_ajax.aspx?do=XuatExcel"
                                 +"&LoaiThuocID="+LoaiThuocID
                                 +"&tungay="+tungay
                                 +"&denngay="+denngay
                                 +"&IdKho="+IdKho
                                 +"&TenKho="+encodeURIComponent(TenKho)
                                 ,
                        dataType:"text",
                        success:function(data){
                             $("#loadingAjax").remove();
                            window.open(data,"_blank");
                        }
                    });
                });     
            //───────────────────────────────────────────────────────────────────────────────────────
         function setIdKho()
         {
            var idkho=$.mkv.queryString("IDKHO_NHAP");
            var IdLoaiThuoc=$.mkv.queryString("IdLoaiThuoc");
            var idkhoa=$.mkv.queryString("idkhoa");
            $.BindFind({
                ajax:"../ajax/HS_BangGiaThuoc_View_ajax.aspx?do=setIdKho&idkho="+idkho+"&IdLoaiThuoc="+IdLoaiThuoc
                +"&idkhoa="+idkhoa,useEnabled:false
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
                     ajax:"../ajax/HS_BangGiaThuoc_View_ajax.aspx?do=TimKiem&page="+page,showPopup:false
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
              $(obj).unautocomplete().autocomplete("../ajax/HS_BangGiaThuoc_View_ajax.aspx?do=idkhoSearch"
                +"&idkhoa="+$.mkv.queryString("idkhoa")
                +"&IdKho="+$.mkv.queryString("IdKho"),{
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
         function TinhDonGiaTruocVAT(obj)
         {
            //var ThanhTien= eval( $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val().replace(/\./g,'').replace(/\,/g,'.') );
            var VAT= eval( $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#VAT").val().replace(/\./g,'').replace(/\,/g,'.') );
            var tt= $(obj).val().replace(/\./g,'').replace(/\,/g,'.') ;
            var dongia=  tt*100 /(100+VAT);
            dongia = Math.round(dongia * 100) /100;
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val(dongia.toString().replace(/\./g,','));
         }
         function TinhDonGiaSauVAT(obj)
         {
            var VAT= eval( $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#VAT").val().replace(/\./g,'').replace(/\,/g,'.') );
            var dongia= $(obj).val().replace(/\./g,'').replace(/\,/g,'.') ;
            var tt=  dongia * (100 + VAT)/100 ; 
            tt = Math.round(tt * 100) /100;
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#DonGiaView").val(tt.toString().replace(/\./g,','));
         }
         function LuuTableBangGia()
         {
            $.LuuTable({
                     ajax:"../ajax/HS_BangGiaThuoc_View_ajax.aspx?do=luuTableBangGia"
                     ,tablename:"gridTable"
               });
         }