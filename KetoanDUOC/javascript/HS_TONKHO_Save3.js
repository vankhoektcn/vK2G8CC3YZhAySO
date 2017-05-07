         $(document).ready(function() {
                 $.mkv.moveUpandDown("#tablefind");
                 SetDeaultValue();
               setControlFind($.mkv.queryString("idkhoachinh"));
                 $("#luu").click(function () {
                   $(this).Luu({
                         ajax:"../ajax/HS_TONKHO_Save_ajax3.aspx?do=Luu"
                      },null,function () {
                           $.LuuTable({
                                 ajax:"../ajax/HS_TONKHO_Save_ajax3.aspx?do=luuTableHS_TonKhoViewDetail&IdTonKho=" + $.mkv.queryString("idkhoachinh"),
                                 tablename:"gridTable"
                           });
                      });
                });
                $("#moi").click(function () {
                     $(this).Moi();                    
                     loadTableAjaxHS_TonKhoViewDetail('');
                     SetDeaultValue();
                });
                $("#xoa").click(function () {
                   $(this).Xoa({
                         ajax:"../ajax/HS_TONKHO_Save_ajax3.aspx?do=xoa"
                    },null,function () {
                         loadTableAjaxHS_TonKhoViewDetail('');
                         SetDeaultValue();
                     });
                });
                $("#timKiem").click(function () {
                        var LoaiThuocID = $("#LoaiThuocID").val();
                         var mkv_LoaiThuocID =  $("#mkv_LoaiThuocID").val();
                         var tungay = $("#TuNgay").val();
                         var denngay =  $("#DenNgay").val();
                         var IdKho = $("#IdKho").val();
                         if( LoaiThuocID==null ||LoaiThuocID=="" ||      mkv_LoaiThuocID==null ||mkv_LoaiThuocID==""
                             ||  tungay==null ||tungay==""||   denngay==null ||denngay==""
                             || IdKho==null ||IdKho==""
                            )
                            {
                              $.mkv.myerror(" Vui lòng xác định thông tin : Từ ngày, đến ngày, kho, đối tượng");
                              return;
                            }
                            
                      Find($(this)); 
                 });
                  //───────────────────────────────────────────────────────────────────────────────────────
               $("#btnXuatExel").click(function(){
                 var LoaiThuocID = $("#LoaiThuocID").val();
                 var mkv_LoaiThuocID =  $("#mkv_LoaiThuocID").val();
                 var tungay = $("#TuNgay").val();
                 var denngay =  $("#DenNgay").val();
                 var IdKho = $("#IdKho").val();
                 var IdTonKho = $.mkv.queryString("idkhoachinh");
                 if( LoaiThuocID==null ||LoaiThuocID=="" ||      mkv_LoaiThuocID==null ||mkv_LoaiThuocID==""
                     ||  tungay==null ||tungay==""||   denngay==null ||denngay==""
                     || IdKho==null ||IdKho==""||    IdTonKho==null ||IdTonKho==""
                    )
                    {
                      $.mkv.myerror(" Vui lòng xác định thông tin : Từ ngày, đến ngày, kho, đối tượng");
                      return;
                    }
                   $.mkv.loading();
                      $.ajax({
                        type:"POST",
                        url:"../ajax/HS_TONKHO_Save_ajax3.aspx?do=XuatExcel"
                                 +"&LoaiThuocID="+LoaiThuocID
                                 +"&mkv_LoaiThuocID="+mkv_LoaiThuocID
                                 +"&tungay="+tungay
                                 +"&denngay="+denngay
                                 +"&IdKho="+IdKho
                                 +"&IdTonKho="+IdTonKho
                                 ,
                        dataType:"text",
                        success:function(data){
                             $("#loadingAjax").remove();
                            window.open(data,"_blank");
                        }
                    });
                });     
            //───────────────────────────────────────────────────────────────────────────────────────
               $("#btnDieuChinhKho").click(function(){
                 var IdTonKho = $.mkv.queryString("idkhoachinh");
                 if( IdTonKho==null ||IdTonKho==""  
                    )
                    {
                      $.mkv.myerror(" Vui lòng lấy danh sách và lưu số lượng và đơn giá thực trước");
                      return;
                    }
                      $.ajax({
                        async:false,
                        cache:false,
                        type:"POST",
                        url:"../ajax/HS_TONKHO_Save_ajax3.aspx?do=DieuChinhKho"
                                 +"&IdTonKho="+IdTonKho
                                 ,
                        success:function(data){
                            if(data!=null && data!=""){
                                $.mkv.myalert(data,2000,"success");
                                $("#timKiem").click();
                            }
                        },
                        error:function(data){
                            $.mkv.myerror("" + data);
                        }   
                    }); 
                });
                     
            //───────────────────────────────────────────────────────────────────────────────────────
                $("#help").click(function(){
                    $(this).TimKiem({
                        ajax:"../ajax/HS_TONKHO_Save_ajax3.aspx?do=help",title:"Hướng dẫn ",width:"1000px",height:"400px"
                    });    
                });
                     
            //───────────────────────────────────────────────────────────────────────────────────────
                
         });
           function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/HS_TONKHO_Save_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
                     loadTableAjaxHS_TonKhoViewDetail($.mkv.queryString("idkhoachinh"));                    
                 });
              }else{loadTableAjaxHS_TonKhoViewDetail();}         
            }
          function Find(control,page) {
              if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/HS_TONKHO_Save_ajax3.aspx?do=TimKiem&page="+page
               });
          }
         function xoaontable(control,bool){
           if(bool || bool == null)
              $(control).XoaRow({
                 ajax:"../ajax/HS_TONKHO_Save_ajax3.aspx?do=xoaHS_TonKhoViewDetail"
              });
         }
         function loadTableAjaxHS_TonKhoViewDetail(idkhoa,page)
         {
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_HS_TonKhoViewDetail").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/HS_TONKHO_Save_ajax3.aspx?do=loadTableHS_TonKhoViewDetail&IdTonKho="+idkhoa+"&page="+page,
                  success: function (value){
                         document.getElementById("tableAjax_HS_TonKhoViewDetail").innerHTML=value;
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                    }
             });
         }
         //───────────────────────────────────────────────────────────────────────────────────────
function IdNuocSX_NSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/HS_TONKHO_Save_ajax3.aspx?do=IdNuocSX_NSearch",{
 minChars:0,
 width:150,
 scroll:true,
 header:false,
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
//───────────────────────────────────────────────────────────────────────────────────────
         function IdKhoSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/HS_TONKHO_Save_ajax3.aspx?do=IdKhoSearch"
                +"&idkhoa="+$.mkv.queryString("idkhoa")
                +"&IdKho="+$.mkv.queryString("IdKho"),{
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
         function LoaiThuocIDSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/HS_TONKHO_Save_ajax3.aspx?do=LoaiThuocIDSearch",{
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
         function IdThuocSearch(obj)
         {
              var idkhoachinh=  $.mkv.queryString("idkhoachinh");
              if(idkhoachinh==null ||idkhoachinh=="")
              {
                       $.mkv.myerror(" Vui lòng xác định thông tin : Từ ngày, đến ngày, kho, đối tượng, rồi nhấn nút tìm kiếm");
                      return;
              }
             $(obj).unautocomplete().autocomplete("../ajax/HS_TONKHO_Save_ajax3.aspx?do=IdThuocSearch",{
             minChars:0,
             width:350,
             scroll:true,
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                    $("#"+obj.id.replace("mkv_","")).val(data[1]);
                    $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                    $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#TENDVT").val(data[3]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
          function SetDeaultValue()
         { 
                     
            $.BindFind({
                        ajax:"../ajax/HS_TONKHO_Save_ajax3.aspx?do=SetDeaultValue"
                                        +"&idkhoa="+$.mkv.queryString("idkhoa")
                                        +"&IdKho="+$.mkv.queryString("IdKho")
                                        +"&LoaiThuocID="+$.mkv.queryString("LoaiThuocID")
                      });
         }
//───────────────────────────────────────────────────────────────────────────────────────         
function CheckExistThuoc(obj){
    if($(obj).val()=="") return false;
    var idthuoc= $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val();
    if(idthuoc==null || idthuoc==""){
        $.mkv.myalert("Thuốc không tồn tại, phần mềm sẽ tự lưu thuốc này vào danh mục thuốc!",2000,"info");
    }
    else
    {
    
        $.ajax({
                async:false,
                cache:false,
                url:"../ajax/phieunhapkho_ajax3.aspx?do=SetNuocSX&idthuoc=" + idthuoc,
                success:function(data){
                    if(data!="")
                    {
                        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IdNuocSX_N").val(data.split('|')[0]);
                        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_IdNuocSX_N").val(data.split('|')[1]);
                        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IdHangSX_N").val(data.split('|')[2]);
                        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_IdHangSX_N").val(data.split('|')[3]);
                    }
                }
            });
    
    }
    
}
//───────────────────────────────────────────────────────────────────────────────────────
function checkAllDelete(obj) {
    var tableCLS = $(obj).parents("table").find("tr");
    for (var i = 0; i < tableCLS.length; i++) {
        if ($(obj).is(":checked")) {
            tableCLS.eq(i).find("td").eq(11).find("input[type=checkbox]").attr("checked", true);
        } else {
            tableCLS.eq(i).find("td").eq(11).find("input[type=checkbox]").attr("checked", false);
        }
    }
}
function checkAllDieuChinh(obj) {
    var tableCLS = $(obj).parents("table").find("tr");
    for (var i = 0; i < tableCLS.length; i++) {
        if ($(obj).is(":checked")) {
            tableCLS.eq(i).find("td").eq(12).find("input[type=checkbox]").attr("checked", true);
        } else {
            tableCLS.eq(i).find("td").eq(12).find("input[type=checkbox]").attr("checked", false);
        }
    }
}