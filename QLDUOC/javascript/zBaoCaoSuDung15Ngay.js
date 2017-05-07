         $(document).ready(function() {
            $.mkv.moveUpandDown("#gridTable");
                setControlFind($.mkv.queryString("idkhoachinh"));
                InitData();
                 $("#luu").click(function () {
                     $(this).Luu({
                         ajax:"../ajax/zBaoCaoSuDung15Ngay_ajax.aspx?do=Luu"
                     });
                });
                $("#moi").click(function () {
                    $(this).Moi();
                });
                $("#xoa").click(function () {
                    $(this).Xoa({ajax:"../ajax/zBaoCaoSuDung15Ngay_ajax.aspx?do=xoa"});
                });
                //───────────────────────────────────────────────────────────────────────────────────────
        $("#btnXuatExel").click(function(){
                 var LoaiThuocID = $("#IdLoaiThuoc").val();
                 var IdKho = $("#IdKho").val();
                 var nYear = $("#nYear").val();
                 var nMonth = $("#nMonth").val();
                 var IsDauThang=$("#IsDauThang").is(':checked');
                 var TenLoaiThuoc = $("#mkv_IdLoaiThuoc").val();
                 var TenKho = $("#mkv_IdKho").val();
                 $.mkv.loading();
                 $.ajax({
                        type:"POST",
                        url:"../ajax/zBaoCaoSuDung15Ngay_ajax.aspx?do=XuatExcel"
                                 +"&LoaiThuocID="+LoaiThuocID
                                 +"&IdKho="+IdKho
                                 +"&nYear="+nYear
                                 +"&nMonth="+nMonth
                                 +"&IsDauThang="+IsDauThang
                                 +"&TenLoaiThuoc="+TenLoaiThuoc
                                 +"&TenKho="+TenKho
                                 ,
                        dataType:"text",
                        success:function(data){
                             $("#loadingAjax").remove();
                            window.open(data,"_blank");
                        }
                    });
                });     
            //───────────────────────────────────────────────────────────────────────────────────────
                $("#timKiem").click(function () {
                    Find(this);
                });
         });
        function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/zBaoCaoSuDung15Ngay_ajax.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem});                    
             }        
         }
          function Find(control,page) {
             if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/zBaoCaoSuDung15Ngay_ajax.aspx?do=TimKiem&page="+page
               });
          }
        function IdKhoSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/zBaoCaoSuDung15Ngay_ajax.aspx?do=IdKhoSearch"
                +"&IdKhoa="+$.mkv.queryString("IdKhoa")
                +"&IdKho="+$.mkv.queryString("IdKho")
             ,{
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
             $(obj).unautocomplete().autocomplete("../ajax/zBaoCaoSuDung15Ngay_ajax.aspx?do=IdLoaiThuocSearch",{
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
function InitData()
{
    $.BindFind({
    ajax:"../ajax/zBaoCaoSuDung15Ngay_ajax.aspx?do=InitData"
                +"&IdKhoa="+$.mkv.queryString("IdKhoa")
                +"&IdKho="+$.mkv.queryString("IdKho")
                +"&LoaiThuocID="+$.mkv.queryString("LoaiThuocID"),useEnabled:false
});
}
//───────────────────────────────────────────────────────────────────────────────────────