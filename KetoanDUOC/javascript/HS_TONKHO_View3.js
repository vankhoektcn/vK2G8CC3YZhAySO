         $(document).ready(function() {
                 $.mkv.moveUpandDown("#tablefind");
                 SetDeaultValue();
                 
               setControlFind($.mkv.queryString("idkhoachinh"));
                 $("#luu").click(function () {
                   $(this).Luu({
                         ajax:"../ajax/HS_TONKHO_View_ajax3.aspx?do=Luu"
                      },null,null);
                });
                $("#moi").click(function () {
                     $(this).Moi();                    
                     loadTableAjaxHS_TonKhoViewDetail('');
                     SetDeaultValue();
                });
                $("#xoa").click(function () {
                   $(this).Xoa({
                         ajax:"../ajax/HS_TONKHO_View_ajax3.aspx?do=xoa"
                    },null,function () {
                         loadTableAjaxHS_TonKhoViewDetail('');
                     });
                });
                $("#timKiem").click(function () {
                 if($("#TuNgay").val()!="" && $("#DenNgay").val()!="" && $("#IdKho").val()!="" &&  $("#LoaiThuocID").val()!="" )
                 {
                    loadTableAjaxHS_TonKhoViewDetail(null,"1");
                 }
                 else
                 {
                    $.mkv.myerror(" Vui lòng xác định thông tin : Từ ngày, đến ngày, kho, đối tượng");
                    return;
                 }
                 });
                $("#XUATEXCEL").click(function(){
                
                 if($("#TuNgay").val()=="" || $("#DenNgay").val()=="" || $("#IdKho").val()=="" ||  $("#LoaiThuocID").val()=="" )
                 {
                   $.mkv.myerror(" Vui lòng xác định thông tin : Từ ngày, đến ngày, kho, đối tượng");
                    return;
                 }

                 var IdKho = $("#IdKho").val();
                  var TuNgay = $("#TuNgay").val();
                  var DenNgay = $("#DenNgay").val();
                  var LoaiThuocID = $("#LoaiThuocID").val();
                  var IdThuoc = $("#IdThuoc").val();
                  var TenThuoc = $("#TenThuoc").val();
                  var IsOrderByName = $("#IsOrderByName").is(':checked');
                  var IsHaveDonGia = $("#IsHaveDonGia").is(':checked');
                  var IsSoLuong = $("#IsSoLuong").is(':checked');
                  var IsRutGon = $("#IsRutGon").is(':checked');
                   var TenKho =$("#mkv_IdKho").val();
              
                     $.mkv.loading();
                      $.ajax({
                        type:"POST",
                        url:"../ajax/HS_TONKHO_View_ajax3.aspx?do=XuatExcel&idkhoachinh="+$.mkv.queryString("idkhoachinh")
                                 +"&IdKho="+IdKho
                                 +"&TuNgay="+TuNgay
                                 +"&DenNgay="+DenNgay
                                 +"&LoaiThuocID="+LoaiThuocID
                                 +"&TenThuoc="+TenThuoc
                                 +"&IsOrderByName="+IsOrderByName
                                 +"&IsHaveDonGia="+IsHaveDonGia
                                 +"&IsSoLuong="+IsSoLuong
                                 +"&IsRutGon="+IsRutGon
                                 +"&TenKho="+ encodeURIComponent(TenKho),
                        dataType:"text",
                        success:function(data){
                             $("#loadingAjax").remove();
                            window.open(data,"_blank");
                        }
                    });
                });     
         });
         
           function setControlFind(idkhoatimkiem,viewdetail) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/HS_TONKHO_View_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
                    if(viewdetail=="1"){
                        loadTableAjaxHS_TonKhoViewDetail($.mkv.queryString("idkhoachinh"));    
                    }                
                 });
                }
            }
          function Find(control,page) {
              if(page == null)page = "1";
              
              
        
              
              $(control).TimKiem({
                     ajax:"../ajax/HS_TONKHO_View_ajax3.aspx?do=TimKiem&page="+page
                                         
               });
          }
         function xoaontable(control,bool){
           if(bool || bool == null)
              $(control).XoaRow({
                 ajax:"../ajax/HS_TONKHO_View_ajax3.aspx?do=xoaHS_TonKhoViewDetail"
              });
         }
         function loadTableAjaxHS_TonKhoViewDetail(idkhoa,page)
         {
              var IdKho = $("#IdKho").val();
              var TuNgay = $("#TuNgay").val();
              var DenNgay = $("#DenNgay").val();
              var LoaiThuocID = $("#LoaiThuocID").val();
              var IdThuoc = $("#IdThuoc").val();
              var TenThuoc = $("#TenThuoc").val();
              var IsOrderByName = $("#IsOrderByName").is(':checked');
              var IsHaveDonGia = $("#IsHaveDonGia").is(':checked');
              var IsSoLuong = $("#IsSoLuong").is(':checked');
              var IsRutGon = $("#IsRutGon").is(':checked');
              var TenKho =$("#mkv_IdKho").val();
              
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_HS_TonKhoViewDetail").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                    async:false,
                    type:"GET",
                    cache:false,
                    url:"../ajax/HS_TONKHO_View_ajax3.aspx?do=loadTableHS_TonKhoViewDetail&IdTonKho="+idkhoa+"&page="+page
                     +"&IdKho="+IdKho
                     +"&TuNgay="+TuNgay
                     +"&DenNgay="+DenNgay
                     +"&LoaiThuocID="+LoaiThuocID
                     +"&TenThuoc="+TenThuoc
                     +"&IsOrderByName="+IsOrderByName
                     +"&IsHaveDonGia="+IsHaveDonGia
                     +"&IsSoLuong="+IsSoLuong
                     +"&IsRutGon="+IsRutGon
                     +"&TenKho="+TenKho
                     ,
                    success: function (value){
                         document.getElementById("tableAjax_HS_TonKhoViewDetail").innerHTML=value;
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                    }
             });
         }
         function IdThuocSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/HS_TONKHO_View_ajax3.aspx?do=IdThuocSearch",{
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
         function IdKhoSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/HS_TONKHO_View_ajax3.aspx?do=IdKhoSearch",{
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
         function LoaiThuocIDSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/HS_TONKHO_View_ajax3.aspx?do=LoaiThuocIDSearch",{
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
         function IdThuocSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/HS_TONKHO_View_ajax3.aspx?do=IdThuocSearch",{
             minChars:0,
             width:350,
             scroll:true,
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                    $("#IdThuoc").val(data[1]);
                    $("#TenThuoc").val(data[0]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function SetDeaultValue()
         {
            $.BindFind({
                        ajax:"../ajax/HS_TONKHO_View_ajax3.aspx?do=SetDeaultValue"
                      });
         }
