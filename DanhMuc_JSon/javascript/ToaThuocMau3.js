 $(document).ready(function() {
         $.mkv.moveUpandDown("#tablefind");
       setControlFind($.mkv.queryString("idkhoachinh"));
         $("#luu").click(function () {
           $(this).Luu({
                 ajax:"../ajax/ToaThuocMau_ajax3.aspx?do=Luu"
              },null,function () {
                   $.LuuTable({
                         ajax:"../ajax/ToaThuocMau_ajax3.aspx?do=luuTableToaThuocMauChiTiet&idtoathuoc=" + $.mkv.queryString("idkhoachinh"),
                         tablename:"gridTable"
                   });
              });
        });
        $("#moi").click(function () {
             $(this).Moi();                    
             loadTableAjaxToaThuocMauChiTiet('');
        });
        $("#xoa").click(function () {
           $(this).Xoa({
                 ajax:"../ajax/ToaThuocMau_ajax3.aspx?do=xoa"
            },null,function () {
                 loadTableAjaxToaThuocMauChiTiet('');
             });
        });
        $("#timKiem").click(function () {
            Find($(this)); 
         });
 });
   function setControlFind(idkhoatimkiem) {
      if(idkhoatimkiem != "" && idkhoatimkiem != null){
         $.BindFind({ajax:"../ajax/ToaThuocMau_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem,dataType:"json"},null,function () {
             loadTableAjaxToaThuocMauChiTiet($.mkv.queryString("idkhoachinh"));                    
         });
      }else{loadTableAjaxToaThuocMauChiTiet();}         
    }
  function Find(control,page) {
      if(page == null)page = "1";
      $(control).TimKiem({
             ajax:"../ajax/ToaThuocMau_ajax3.aspx?do=TimKiem&page="+page
       });
  }
 function xoaontable(control,bool){
   if(bool || bool == null)
      $(control).XoaRow({
         ajax:"../ajax/ToaThuocMau_ajax3.aspx?do=xoaToaThuocMauChiTiet"
      });
 }
 function loadTableAjaxToaThuocMauChiTiet(idkhoa,page)
 {
     if(idkhoa == null) idkhoa = "";
         if(page == null) page = "1";
         $("#tableAjax_ToaThuocMauChiTiet").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
          $.ajax({
         type:"GET",
         cache:false,
         url:"../ajax/ToaThuocMau_ajax3.aspx?do=loadTableToaThuocMauChiTiet&idToaThuoc="+idkhoa+"&page="+page,
          success: function (value){
                 document.getElementById("tableAjax_ToaThuocMauChiTiet").innerHTML=value;
                $("table.jtable tr:nth-child(odd)").addClass("odd");
                 $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                 $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
            }
     });
 }
 function DoiTuongThuocIDSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/ToaThuocMau_ajax3.aspx?do=DoiTuongThuocIDSearch",{
     minChars:0,
     addRow:false,
     scroll:true,
     header:false,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 function idthuocSearch(obj,type)
 {
     $(obj).unautocomplete().autocomplete("../ajax/ToaThuocMau_ajax3.aspx?do=idthuocSearch&loaithuocid=" 
        + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#DoiTuongThuocID").val() 
        + "&TypeSearch=" + type,{
     minChars:0,
     width:950,
     addRow:true,
     scroll:true,
    header: "<div style =\"width:100%;height:30px\">"
                          + "<div algin='left' style=\"width:8%;color:white;font-weight:bold;float:left;font-size:11px;\" >Tên thuốc</div>"
                          + "<div style=\"width:33%;color:white;font-weight:bold;float:left; text-algin:center;font-size:11px;\" >Công thức</div>"
                          + "<div style=\"width:10%;color:white;font-weight:bold;float:left;font-size:11px;\" >Đường dùng</div>"
                          + "<div style=\"width:10%;color:white;font-weight:bold;float:left;font-size:11px;\" >ĐVT</div>"
                          + "<div style=\"width:9%;color:white;font-weight:bold;float:left;font-size:11px;\" >Giá</div>"
                          + "<div style=\"width:8%;color:white;font-weight:bold;float:left;font-size:11px;\" >SL tồn</div>"
                          + "<div style=\"width:9%;color:white;font-weight:bold;float:left;font-size:11px;\" >?BH</div>"
                          + "<div style=\"width:9%;color:white;font-weight:bold;float:left;font-size:11px;\" >?Thuốc BV</div>"
                          + "</div>",
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        //dvt
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#iddvt").val(data[9]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_iddvt").val(data[2]);
        //dvdung
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#iddvdung").val(data[9]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_iddvdung").val(data[2]);
        //cachdung
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idcachdung").val(data[10]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idcachdung").val(data[3]);
        //thuoc
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idthuoc").val(data[1]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idthuoc").val(data[4]);
        //congthuoc
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_congthuc").val(data[7]);
         setTimeout(function () {
              $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluongke").focus();
         },100);
     });
 }
 function idcachdungSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/ToaThuocMau_ajax3.aspx?do=idcachdungSearch",{
     minChars:0,
     scroll:true,
     header:false,
     addRow:false,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 function iddvdungSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/ToaThuocMau_ajax3.aspx?do=iddvdungSearch",{
     minChars:0,
     scroll:true,
     header:false,
     addRow:false,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 function iddvtSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/ToaThuocMau_ajax3.aspx?do=iddvtSearch",{
     minChars:0,
     addRow:false,
     header:false,
     scroll:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 function IdChanDoanSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/ToaThuocMau_ajax3.aspx?do=IdChanDoanSearch",{
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
 function IdNguoiDungSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/ToaThuocMau_ajax3.aspx?do=IdNguoiDungSearch",{
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
