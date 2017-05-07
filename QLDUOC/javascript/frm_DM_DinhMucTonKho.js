         $(document).ready(function() {
             $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"../ajax/frm_DM_DinhMucTonKho_ajax.aspx?do=luuTable&IDKHO="+$("#IdKho").val(),tablename:"gridTable"});
             });
             $("#timKiem").click(function () {
                    Find(this);
             });
            setIdKho();
            $("#timKiem").click();
         });
         function xoa(control){
              $(control).XoaRow({ajax:'../ajax/frm_DM_DinhMucTonKho_ajax.aspx?do=xoa'});
         }
          function Find(control,page) {
           if(page == null) page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/frm_DM_DinhMucTonKho_ajax.aspx?do=TimKiem&page="+page,showPopup:false
               },function () {
                     $("#tableAjax_Thuoc_DinhMucTonKho").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
               },function (data) {
                         $("#tableAjax_Thuoc_DinhMucTonKho").html(data);
                         $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
               });
              
         }
         function IdthuocSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/frm_DM_DinhMucTonKho_ajax.aspx?do=IdthuocSearch&cateid="+$("#cateid").val()+"&loaithuocid="+$("#loaithuocid").val(),{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function IdKhoSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/frm_DM_DinhMucTonKho_ajax.aspx?do=IdKhoSearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function loaithuocidSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/frm_DM_DinhMucTonKho_ajax.aspx?do=loaithuocidSearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function cateidSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/frm_DM_DinhMucTonKho_ajax.aspx?do=cateidSearch&loaithuocid="+$("#loaithuocid").val(),{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         
function setIdKho()
{
           
    $.BindFind({
                ajax:"../ajax/phieunhapkho_ajax3.aspx?do=setIdKho"
                            +"&idkhoa="+$.mkv.queryString("idkhoa")
                            +"&IdKho="+$.mkv.queryString("IdKho")
                            +"&LoaiThuocID="+$.mkv.queryString("LoaiThuocID"),useEnabled:false
                });
}
//───────────────────────────────────────────────────────────────────────────────────────