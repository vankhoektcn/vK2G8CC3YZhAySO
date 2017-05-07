 var today=new Date();
 var dd=today.getDate();
 var MM=today.getMonth() + 1;
 var yyyy=today.getFullYear();
 if(dd<10) dd ='0' + dd;
 if(MM<10) MM='0' + MM;
 $(document).ready(function() {
       $("#NgayYeuCau").val(dd + "/" + MM + "/" + yyyy);
       //----------------------------------------------
       $.mkv.moveUpandDown("#tablefind");
       setControlFind($.mkv.queryString("idkhoachinh"));
         $("#luu").click(function () {
           $(this).Luu({
                 ajax:"../ajax/THUOC_YEUCAUTRAHONGVO_ajax3.aspx?do=Luu"
              },function(){
                if($("#IdKhoNhanTra").val()==null || $("#IdKhoNhanTra").val()=="")
                {
                    $.mkv.myerror("Phải có kho nhận trả.");
                    $("#mkv_IdKhoNhanTra").focus();
                    return false;
                }
                return true;
              },function () {
                   $.LuuTable({
                         ajax:"../ajax/THUOC_YEUCAUTRAHONGVO_ajax3.aspx?do=luuTableTHUOC_YEUCAUTRAHONGVO_CHITIET&IdYeuCauTraHongVo=" + $.mkv.queryString("idkhoachinh"),
                         tablename:"gridTable"
                   });
              });
        });
        if($.mkv.queryString("isdaduyet")=="1"){
            $("#DUYETYC").css("display","none");
        }
         if($.mkv.queryString("isduyet")!=null && $.mkv.queryString("isduyet")!="" && $.mkv.queryString("isduyet")=="0")
        {
            $("#DUYETYC").css("display","none");
            $("#ngayduyet").css("display","none");
            
        }
        $("#moi").click(function () {
             $(this).Moi();  
             $("#NgayYeuCau").val(dd + "/" + MM + "/" + yyyy);
         //    $("#SoYeuCau").attr("disabled",true);
             TaoSoPhieuYC();
       //----------------------------------------------                  
             loadTableAjaxTHUOC_YEUCAUTRAHONGVO_CHITIET('');
        });
        $("#xoa").click(function () {
           $(this).Xoa({
                 ajax:"../ajax/THUOC_YEUCAUTRAHONGVO_ajax3.aspx?do=xoa"
            },null,function () {
                 loadTableAjaxTHUOC_YEUCAUTRAHONGVO_CHITIET('');
             });
        });
        $("#timKiem").click(function () {
            Find($(this)); 
         });
          $("#printBienBan").click(function(){
           var idphieuxuat=$.mkv.queryString("idkhoachinh");
            if(idphieuxuat==null ||idphieuxuat=="") return false;
            $.mkv.loading();
                  $.ajax({
                    type:"POST",
                    url:"../ajax/THUOC_YEUCAUTRAHONGVO_ajax3.aspx?do=PrintBienBan"
                             +"&idphieuxuat=" + idphieuxuat,
                    dataType:"text",
                    success:function(data){
                         $("#loadingAjax").remove();
                        window.open(data,"_blank");
                    }
             });
        });
        
        $("#DUYETYC").click(function(){
            if($.mkv.queryString("idkhoachinh")==null || $.mkv.queryString("idkhoachinh")=="")return;
            $.ajax({
                async:false,
                url:"../ajax/THUOC_YEUCAUTRAHONGVO_ajax3.aspx",
                data:{
                    "do":"DuyetYeuCauTra",
                    IdPhieuYeuCauTraHongVo: $.mkv.queryString("idkhoachinh"),
                    ngayduyetyc:$("#ngayduyetyc").val(),
                    SoYeuCau: $("#SoYeuCau").val(),
                    IdKhoYeuCau: $("#IdKhoYeuCau").val(),
                    IdKhoNhanTra: $("#IdKhoNhanTra").val()
                },success:function(data){
                    if(data){
                        $.mkv.myalert("Duyệt nhận thành công",2000,"success");
                    }else {
                             $("#loadingAjax").remove();
                            $.mkv.myerror("Có lỗi trong quá trình duyệt nhận");
                        }
                },error:function(value){
                    $.mkv.myerror(value);
                }
            });
        }); 
     
       
 });
   function setControlFind(idkhoatimkiem) {
      if(idkhoatimkiem != "" && idkhoatimkiem != null){
         $.BindFind({ajax:"../ajax/THUOC_YEUCAUTRAHONGVO_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
                $("#ngayduyetyc").val($.mkv.queryString("ngayduyet"));
             loadTableAjaxTHUOC_YEUCAUTRAHONGVO_CHITIET($.mkv.queryString("idkhoachinh"));     
                if($.mkv.queryString("isduyet")!=null && $.mkv.queryString("isduyet")!="" && $.mkv.queryString("isduyet")=="0")
                {
                    $("#DUYETYC").css("display","none");
                      $("#ngayduyet").css("display","none");
                }
                else if ($.mkv.queryString("isduyet")!=null && $.mkv.queryString("isduyet")!="" && $.mkv.queryString("isduyet")=="1")
                {
                    $("#luu, #_luu, #xoa").css("display","none");
                }
                
                           
         });
      }else{loadTableAjaxTHUOC_YEUCAUTRAHONGVO_CHITIET();}         
    }
  function Find(control,page) {
      if(page == null)page = "1";
      $(control).TimKiem({
             ajax:"../ajax/THUOC_YEUCAUTRAHONGVO_ajax3.aspx?do=TimKiem&page="+page
       });
  }
 function xoaontable(control,bool){
   if(bool || bool == null)
      $(control).XoaRow({
         ajax:"../ajax/THUOC_YEUCAUTRAHONGVO_ajax3.aspx?do=xoaTHUOC_YEUCAUTRAHONGVO_CHITIET"
      });
 }
 function loadTableAjaxTHUOC_YEUCAUTRAHONGVO_CHITIET(idkhoa,page)
 {
     if(idkhoa == null) idkhoa = "";
         if(page == null) page = "1";
         $("#tableAjax_THUOC_YEUCAUTRAHONGVO_CHITIET").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
          $.ajax({
         type:"GET",
         cache:false,
         url:"../ajax/THUOC_YEUCAUTRAHONGVO_ajax3.aspx?do=loadTableTHUOC_YEUCAUTRAHONGVO_CHITIET&IdYeuCauTraHongVo="+idkhoa+"&page="+page + "&ngayduyetyc="+$("#ngayduyetyc").val(),
          success: function (value){
                 $("#tableAjax_THUOC_YEUCAUTRAHONGVO_CHITIET").html(value);
            }
     });
 }
 function LoaiThuocIdSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/THUOC_YEUCAUTRAHONGVO_ajax3.aspx?do=LoaiThuocIdSearch",{
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
 function IdThuocSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/THUOC_YEUCAUTRAHONGVO_ajax3.aspx?do=IdThuocSearch&loaithuocid=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#LoaiThuocId").val() + "&idkho="+$("#IdKhoYeuCau").val(),{
     minChars:0,
     width:850,
     scroll:true,
     addRow:true,
     header:  "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
            + "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
            + "<div style=\"width:37%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;padding-left:5px;\" >Tên thuốc/VTYT/HC</div>"
            + "<div style=\"width:12%;height:30px;color:#000;font-weight:bold;float:left\" >TT HC</div>"
            + "<div style=\"width:18%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;\" >Hoạt chất</div>"
            + "<div style=\"width:11%;height:30px;color:#000;font-weight:bold;float:left;\" >ĐVT</div>"
            + "<div style=\"width:6%;height:30px;color:#000;font-weight:bold;float:left\" >SLTon </div>"
            + "<div style=\"width:7%;height:30px;color:#000;font-weight:bold;float:left\" >Tồn ảo </div>"
            + "</div>",
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         if($(obj).parents("#gridTable").attr("id") != null){
                 $(obj).val(data[4]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IdDVT").val(data[9]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_IdDVT").val(data[10]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SLTON").val(data[6]);
                 if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                 $.mkv.themDongTable("gridTable");
         }
         setTimeout(function () {
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SoLuong").focus();
         },100);
     });
 }
 function IdDVTSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/THUOC_YEUCAUTRAHONGVO_ajax3.aspx?do=IdDVTSearch",{
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
 function IdKhoYeuCauSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/THUOC_YEUCAUTRAHONGVO_ajax3.aspx?do=IdKhoYeuCauSearch&IdKhoa="+ $.mkv.queryString("IdKhoa"),{
     minChars:0,
     width:350,
     scroll:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
             $("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
                TaoSoPhieuYC();
             obj.focus();
         },100);
     });
 }
 function IdKhoNhanTraSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/THUOC_YEUCAUTRAHONGVO_ajax3.aspx?do=IdKhoNhanTraSearch",{
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
 function IdNguoiYeuCauSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/THUOC_YEUCAUTRAHONGVO_ajax3.aspx?do=IdNguoiYeuCauSearch",{
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
function checkSLNhap(obj)
{
    var SLTon=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SLTON").val());
    var SL=eval($(obj).val());
    if(SL>SLTon)
    {
        $.mkv.myerror("Số lượng phải nhỏ hơn : " + SLTon);
        $(obj).focus();
        return false;
    }
}
function TaoSoPhieuYC()
{
    var idkhoa=$.mkv.queryString("IdKhoa");
    var idkho=$("#IdKhoYeuCau").val();
    if(idkhoa!=null && idkhoa !=""){
        $.ajax({
            async:false,
            url:"../ajax/THUOC_YEUCAUTRAHONGVO_ajax3.aspx",
            data:{
                "do":"TaoSoPhieuYC",
                idkhoa:idkhoa,
                ngaythang:$("#NgayYeuCau").val(),
                idkhoyeucau:idkho
            },
            success:function(data){
                $("#SoYeuCau").val(data);
            }
        });
      }
}