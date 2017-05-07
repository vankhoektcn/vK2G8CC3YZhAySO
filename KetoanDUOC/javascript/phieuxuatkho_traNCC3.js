         $(document).ready(function() {
               setIdKho();
               $.mkv.moveUpandDown("#tablefind");
               setControlFind($.mkv.queryString("idkhoachinh"));
                 $("#luu").click(function () {
                   $(this).Luu({
                         ajax:"../ajax/phieuxuatkho_traNCC_ajax3.aspx?do=Luu"
                      },null,function () {
                           $.LuuTable({
                                 ajax:"../ajax/phieuxuatkho_traNCC_ajax3.aspx?do=luuTablechitietphieuxuatkho&idphieuxuat=" + $.mkv.queryString("idkhoachinh"),
                                 tablename:"gridTable"
                           });
                            $.ajax({
                                async:false,
                                cache:false,
                                url:"../ajax/phieuxuatkho_ajax3.aspx?do=GetMaPhieuXuat&IdPhieuXuat=" + $.mkv.queryString("idkhoachinh"),
                                success:function(data){
                                    $("#maphieuxuat").val(data);
                                }
                            });     
                      });
                });
                $("#moi").click(function () {
                     $(this).Moi();                    
                     loadTableAjaxchitietphieuxuatkho('');
                     setIdKho();
                });
                $("#xoa").click(function () {
                   $(this).Xoa({
                         ajax:"../ajax/phieuxuatkho_traNCC_ajax3.aspx?do=xoa"
                    },null,function () {
                         loadTableAjaxchitietphieuxuatkho('');
                     });
                });
                $("#timKiem").click(function () {
                    Find($(this)); 
                 });
                
                $("#ViewDetail").click(function () {
                        var idkhoachinh= $.mkv.queryString("idkhoachinh");
                        window.open("HS_ChiTietPhieuXuat.aspx?idkhoachinh="+PhieuXuatKho );
                });
         });
           function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/phieuxuatkho_traNCC_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
                     loadTableAjaxchitietphieuxuatkho($.mkv.queryString("idkhoachinh"));                    
                 });
              }else{loadTableAjaxchitietphieuxuatkho();}         
            }
          function Find(control,page) {
              if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/phieuxuatkho_traNCC_ajax3.aspx?do=TimKiem&page="+page,"width":"1100px","height":"350px",title:"Danh sách phiếu xuất trả nhà cung cấp"
               });
          }
         function xoaontable(control,bool){
           if(bool || bool == null)
              $(control).XoaRow({
                 ajax:"../ajax/phieuxuatkho_traNCC_ajax3.aspx?do=xoachitietphieuxuatkho"
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
                 url:"../ajax/phieuxuatkho_traNCC_ajax3.aspx?do=loadTablechitietphieuxuatkho&idphieuxuat="+idkhoa+"&page="+page,
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
             var TenLoaiThuoc="";
             if($("#IdLoaiThuoc").val()=="2") TenLoaiThuoc="Hoá chất";
             else if($("#IdLoaiThuoc").val()=="4")TenLoaiThuoc="VTYT";
             else if($("#IdLoaiThuoc").val()=="1")TenLoaiThuoc="Tên thuốc";
             
             $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_traNCC_ajax3.aspx?do=idthuocSearch&LoaiThuocID=" + $("#IdLoaiThuoc").val() + "&idnhacungcap=" + $("#idnhacungcap").val() + "&ngaythang=" + $("#ngaythang").val() + "&idkho=" + $.mkv.queryString("idkho"),{
             minChars:0,
             width:850,
             scroll:true,
             header:  "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
                            + "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
                            + "<div style=\"width:33%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;\" >" + TenLoaiThuoc + "</div>"
                            + "<div style=\"width:7%;height:30px;color:#000;font-weight:bold;float:left\" >Số CT</div>"
                            + "<div style=\"width:20%;height:30px;color:#000;font-weight:bold;float:left\" >Ngày CT</div>"
                            + "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left;\" >ĐVT</div>"
                            + "<div style=\"width:12%;height:30px;color:#000;font-weight:bold;float:left\" >SLTồn </div>"
                            + "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left\" >Đơn giá </div>"
                     + "</div>",
                     
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $(obj).val(data[4]);
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#dvt").val(data[3]);
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_dvt").val(data[11]);
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val(data[7]);
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SLTON").val(data[10]);
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#VAT").val(data[12]);
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idchitietphieunhapkho").val(data[15]);
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idchitietphieunhapkho").val(data[13]);
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#NgayHoaDon").val(data[14]);
                     if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }
                 setTimeout(function () {
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluong").focus();
                 },100);
             });
         }
         function idchitietphieunhapkhoSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_traNCC_ajax3.aspx?do=idchitietphieunhapkhoSearch",{
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
             $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_traNCC_ajax3.aspx?do=dvtSearch",{
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
         function idnhacungcapSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_traNCC_ajax3.aspx?do=idnhacungcapSearch",{
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
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_traNCC_ajax3.aspx?do=IdLoaiThuocSearch",{
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
 function setIdKho()
 {
    $.BindFind({
        ajax:"../ajax/phieuxuatkho_ajax3.aspx?do=setIdKho"
    });
 }
 function CheckSLTon(obj)
 {
    var slton=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SLTON");
    if(eval($(obj).val())>eval(slton.val()))
    {
        $.mkv.myerror("Số lượng không vượt quá : " + slton.val());
        $(obj).focus();
        $("#luu").attr("disabled",true);
        $("#_luu").attr("disabled",true);
        return false;
    }
    else
    {
         $("#luu").attr("disabled",false);
         $("#_luu").attr("disabled",false);
         return true;
    }
 }
 function tinhthanhtien(obj)
 {
    var thanhtientruocthue=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val())*eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val());
    $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#thanhtientruocthue").val(formatCurrency(thanhtientruocthue));
    var thanhtiensauthue=(thanhtientruocthue*eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#VAT").val())/100) + thanhtientruocthue;
    $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(formatCurrency(thanhtiensauthue));
 }
