 $(document).ready(function() {
   if ($.browser.msie<8) {
      $("input[type=text],input[type=checkbox],select,textarea").live("focus",function(){
            $(this).css("background-color","#ffff99");
          }).live("blur",function(){
                  $(this).css("background-color","");
          });
          
     }       
     //───────────────────────────────────────────────────────────────────────────────────────
        setIdKho();
        $.mkv.moveUpandDown("#tablefind");
        setControlFind($.mkv.queryString("idkhoachinh"));
         $("#luu").click(function () {
           $(this).Luu({
                 ajax:"../ajax/phieuxuatkho_ajax3.aspx?do=Luu"
              },null,function () {
                   $.LuuTable({
                         ajax:"../ajax/phieuxuatkho_ajax3.aspx?do=luuTableHS_OutPutDetail&IdPhieuXuat=" + $.mkv.queryString("idkhoachinh"),
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
  //───────────────────────────────────────────────────────────────────────────────────────
        $("#TimMoi").click(function () {
           $(this).Moi(); 
            loadTableAjaxHS_OutPutDetail('');
        });
  //───────────────────────────────────────────────────────────────────────────────────────
        $("#moi").click(function () {
           $(this).Moi(); 
           var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth() + 1; //January is 0!
            var yyyy = today.getFullYear();
            if (dd < 10) { dd = '0' + dd }
            if (mm < 10) { mm = '0' + mm }
            $("#ngaythang").val(dd + "/" + mm + "/" + yyyy);
             $.ajax({
                    async:false,
                    cache:false,
                    url:"../ajax/phieuxuatkho_ajax3.aspx?do=PrevInfo",
                    success:function(data){
                         $("#idkho").val(data.split('|')[0]);
                         $("#mkv_idkho").val(data.split('|')[1]);
                         $("#idkho2").val(data.split('|')[2]);
                         $("#mkv_idkho2").val(data.split('|')[3]);
                          $("#IdLoaiThuoc").val(data.split('|')[4]);
                         $("#mkv_IdLoaiThuoc").val(data.split('|')[5]);
                    }
                });                          
             loadTableAjaxHS_OutPutDetail('');
        });
        $("#xoa").click(function () {
           $(this).Xoa({
                 ajax:"../ajax/phieuxuatkho_ajax3.aspx?do=xoa"
            },null,function () {
                 loadTableAjaxHS_OutPutDetail('');
             });
        });
        $("#timKiem").click(function () {
            Find($(this)); 
         });
         
         
         $("#ViewDetail").click(function () {
          
           var idkhoachinh= $.mkv.queryString("idkhoachinh");
           window.open("HS_ChiTietPhieuXuat.aspx?idkhoachinh="+idkhoachinh );
         });
         
 });
   function setControlFind(idkhoatimkiem) {
      if(idkhoatimkiem != "" && idkhoatimkiem != null){
         $.BindFind({ajax:"../ajax/phieuxuatkho_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
             loadTableAjaxHS_OutPutDetail($.mkv.queryString("idkhoachinh"));                    
         });
      }else{loadTableAjaxHS_OutPutDetail();}         
    }
  function Find(control,page) {
      if(page == null)page = "1";
      $(control).TimKiem({
             ajax:"../ajax/phieuxuatkho_ajax3.aspx?do=TimKiem&page="+page
       });
  }
 function xoaontable(control,bool){
   if(bool || bool == null)
      $(control).XoaRow({
         ajax:"../ajax/phieuxuatkho_ajax3.aspx?do=xoaHS_OutPutDetail"
      });
 }
 function setIdKho()
 {
    $.BindFind({
        ajax:"../ajax/phieuxuatkho_ajax3.aspx?do=setIdKho"
    });
 }
 function loadTableAjaxHS_OutPutDetail(idkhoa,page)
 {
     if(idkhoa == null) idkhoa = "";
         if(page == null) page = "1";
         $("#tableAjax_HS_OutPutDetail").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
          $.ajax({
         type:"GET",
         cache:false,
         url:"../ajax/phieuxuatkho_ajax3.aspx?do=loadTableHS_OutPutDetail&idphieuxuat="+idkhoa+"&page="+page,
          success: function (value){
                 document.getElementById("tableAjax_HS_OutPutDetail").innerHTML=value;
                $("table.jtable tr:nth-child(odd)").addClass("odd");
                 $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                 $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
            }
     });
 }
 function IdThuocSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax3.aspx?do=IdThuocSearch&loaithuoc="+$("#IdLoaiThuoc").val()+"&idkho="+$("#idkho").val()+"&NgayCT="+$("#ngaythang").val(),{
     minChars:0,
     width:750,
     scroll:true,
     header:  "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
                + "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
                + "<div style=\"width:29%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;padding-left:5px;\" >Biệt dược</div>"
                + "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left\" >TT HC</div>"
                + "<div style=\"width:30%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;\" >Hoạt chất</div>"
                + "<div style=\"width:11%;height:30px;color:#000;font-weight:bold;float:left;\" >ĐVT</div>"
                + "<div style=\"width:13%;height:30px;color:#000;font-weight:bold;float:left\" >SLTon </div>"
                + "</div>",
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         if($(obj).parents("#gridTable").attr("id") != null){
                $(obj).val(data[4]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#UnitID").val(data[3]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_UnitID").val(data[7]);
                        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SLTON").val(data[6]);
             if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                 $.mkv.themDongTable("gridTable");
         }
         setTimeout(function () {
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#Quantity").focus();
         },100);
     });
 }
 function UnitIDSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax3.aspx?do=UnitIDSearch",{
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
 function idkhoSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax3.aspx?do=idkhoSearch",{
     minChars:0,
     width:250,
     scroll:true,
     header:false,
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
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax3.aspx?do=IdLoaiThuocSearch",{
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
         $("#gridTable").find("tr").next().eq($(obj).parent().parent().index()).find("#mkv_IdThuoc").focus();   
         return true;
    }
 }
