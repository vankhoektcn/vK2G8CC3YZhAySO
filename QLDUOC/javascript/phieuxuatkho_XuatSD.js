$(document).ready(function() {
        if ($.browser.msie<8) {
$("input[type=text],input[type=checkbox],select,textarea").live("focus",function(){
    $(this).css("background-color","#ffff99");
  }).live("blur",function(){
          $(this).css("background-color","");
  });
  
}
setIdKho();
         $.mkv.moveUpandDown("#tablefind");
       setControlFind($.mkv.queryString("idkhoachinh"));
         $("#luu").click(function () {
           $(this).Luu({
                 ajax:"../ajax/phieuxuatkho_XuatSD_ajax.aspx?do=Luu"
              },null,function () {
                   $.LuuTable({
                         ajax:"../ajax/phieuxuatkho_XuatSD_ajax.aspx?do=luuTableHS_OutPutDetail&IdPhieuXuat=" + $.mkv.queryString("idkhoachinh"),
                         tablename:"gridTable"
                   });
                    $.ajax({
                        async:false,
                        cache:false,
                        url:"../ajax/phieuxuatkho_XuatSD_ajax.aspx?do=GetMaPhieuXuat&IdPhieuXuat=" + $.mkv.queryString("idkhoachinh"),
                        success:function(data){
                            $("#maphieuxuat").val(data);
                        }
                    });     
                 
              });
        });
        
        
        $("#TimMoi").click(function () {
           $(this).Moi(); 
            loadTableAjaxHS_OutPutDetail('');
            setIdKho();
        });
        $("#btnPrin").click(function () {
                var idphieuxuat=$.mkv.queryString("idkhoachinh");
                if(idphieuxuat==null ||idphieuxuat=="") return false;
                window.open("frm_PhieuXuatKho_Crpt.aspx?idphieuxuat="+idphieuxuat );
        });
        
        
        
        $("#ViewDetail").click(function () {
                var idkhoachinh= $.mkv.queryString("idkhoachinh");
                window.open("HS_ChiTietPhieuXuat.aspx?idkhoachinh="+PhieuXuatKho );
        });
        
        
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
                    url:"../ajax/phieuxuatkho_XuatSD_ajax.aspx?do=PrevInfo",
                    success:function(data){
                         $("#idkho").val(data.split('|')[0]);
                         $("#mkv_idkho").val(data.split('|')[1]);
                          $("#IdLoaiThuoc").val(data.split('|')[4]);
                         $("#mkv_IdLoaiThuoc").val(data.split('|')[5]);
                    }
                });                          
                setIdKho();
             loadTableAjaxHS_OutPutDetail('');
        });
        $("#xoa").click(function () {
           $(this).Xoa({
                 ajax:"../ajax/phieuxuatkho_XuatSD_ajax.aspx?do=xoa"
            },null,function () {
                 loadTableAjaxHS_OutPutDetail('');
             });
        });
        $("#timKiem").click(function () {
            Find($(this)); 
         });
 });
  function setIdKho()
 {
        var IDKHOA=null;
        var IdKhoa=$.mkv.queryString("IdKhoa");
        if(IdKhoa!=null && IdKhoa!="")
            IDKHOA=IdKhoa;
        else
            IDKHOA=$.mkv.queryString("idkhoa");
        
        if($.mkv.queryString("idkhoachinh")!=null && $.mkv.queryString("idkhoachinh")!="")   return false;
        $.BindFind({
        ajax:"../ajax/phieuxuatkho_XuatSD_ajax.aspx?do=setIdKho"
        +"&idkhoa="+IDKHOA
        +"&IdKho="+$.mkv.queryString("IdKho")
        +"&LoaiThuocID="+$.mkv.queryString("LoaiThuocID"),useEnabled:false
    });
 }
   function setControlFind(idkhoatimkiem) {
      if(idkhoatimkiem != "" && idkhoatimkiem != null){
         $.BindFind({ajax:"../ajax/phieuxuatkho_XuatSD_ajax.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
             loadTableAjaxHS_OutPutDetail($.mkv.queryString("idkhoachinh"));                    
         });
      }else{loadTableAjaxHS_OutPutDetail();}         
    }
  function Find(control,page) {
      if(page == null)page = "1";
      $(control).TimKiem({
             ajax:"../ajax/phieuxuatkho_XuatSD_ajax.aspx?do=TimKiem&page="+page 
             ,width:"1000"
       },null,function(data){
            if(data==null|| data==""){
                $.mkv.closeDivTimKiem();
            }
       });
  }
 function xoaontable(control,bool){
   if(bool || bool == null)
      $(control).XoaRow({
         ajax:"../ajax/phieuxuatkho_XuatSD_ajax.aspx?do=xoaHS_OutPutDetail"
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
         url:"../ajax/phieuxuatkho_XuatSD_ajax.aspx?do=loadTableHS_OutPutDetail&idphieuxuat="+idkhoa+"&page="+page,
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
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_XuatSD_ajax.aspx?do=IdThuocSearch&loaithuoc="+$("#IdLoaiThuoc").val()+"&idkho="+$("#idkho").val()+"&NgayCT="+$("#ngaythang").val(),{
     minChars:0,
     width:750,
     scroll:true,
     header:  "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
                + "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
                + "<div style=\"width:35%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;padding-left:5px;\" >Biệt dược</div>"
                + "<div style=\"width:15%;height:30px;color:#000;font-weight:bold;float:left\" >TT HC</div>"
                + "<div style=\"width:20%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;\" >Hoạt chất</div>"
                + "<div style=\"width:7%;height:30px;color:#000;font-weight:bold;float:left;\" >ĐVT</div>"
                + "<div style=\"width:8%;height:30px;color:#000;font-weight:bold;float:left\" >SLTon </div>"
                + "<div style=\"width:7%;height:30px;color:#000;font-weight:bold;float:left\" >Dự trù</div>"
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
  function ghichuSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_XuatSD_ajax.aspx?do=ghichuSearch" + "&IsCLS="+$.mkv.queryString("IsCLS")+ "&IsHangTuan="+$.mkv.queryString("IsHangTuan"),{
     minChars:0,
     width:350,
     scroll:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 
 function UnitIDSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_XuatSD_ajax.aspx?do=UnitIDSearch",{
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
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_XuatSD_ajax.aspx?do=idkhoSearch"
        +"&idkhoa="+$.mkv.queryString("idkhoa")
        +"&idkho="+$.mkv.queryString("idkho")
        ,{
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
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_XuatSD_ajax.aspx?do=IdLoaiThuocSearch" + "&LoaiThuocID="+$.mkv.queryString("LoaiThuocID"),{
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
   
    var slton= $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SLTON");
    if(eval($(obj).val())>eval(slton.val()))
    {
        $.mkv.myerror("Số lượng không vượt quá : " + slton.val());
        $(obj).val("0");
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
