         $(document).ready(function() {
                 $.mkv.moveUpandDown("#tablefind");
               setControlFind($.mkv.queryString("idkhoachinh"));
                InitData();
                 $("#luu").click(function () {
                   $(this).Luu({
                         ajax:"../ajax/zDanhSachThuocSapHetHan_ajax3.aspx?do=Luu"
                      },null,function () {
                           $.LuuTable({
                                 ajax:"../ajax/zDanhSachThuocSapHetHan_ajax3.aspx?do=luuTablezDanhSachThuocSapHetHan_ChiTiet&IdDanhSach=" + $.mkv.queryString("idkhoachinh"),
                                 tablename:"gridTable"
                           });
                      });
                });
                $("#moi").click(function () {
                     $(this).Moi();                    
                     loadTableAjaxzDanhSachThuocSapHetHan_ChiTiet('');
                      InitData();
                });
                $("#xoa").click(function () {
                   $(this).Xoa({
                         ajax:"../ajax/zDanhSachThuocSapHetHan_ajax3.aspx?do=xoa"
                    },null,function () {
                         loadTableAjaxzDanhSachThuocSapHetHan_ChiTiet('');
                     });
                });
                $("#timKiem").click(function () {
                    Find($(this)); 
                 });
         });
           function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/zDanhSachThuocSapHetHan_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
                     loadTableAjaxzDanhSachThuocSapHetHan_ChiTiet($.mkv.queryString("idkhoachinh"));                    
                 });
              }else{loadTableAjaxzDanhSachThuocSapHetHan_ChiTiet();}         
            }
          function Find(control,page) {
              if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/zDanhSachThuocSapHetHan_ajax3.aspx?do=TimKiem&page="+page
               });
          }
         function xoaontable(control,bool){
           if(bool || bool == null)
              $(control).XoaRow({
                 ajax:"../ajax/zDanhSachThuocSapHetHan_ajax3.aspx?do=xoazDanhSachThuocSapHetHan_ChiTiet"
              });
         }
         function loadTableAjaxzDanhSachThuocSapHetHan_ChiTiet(idkhoa,page)
         {
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_zDanhSachThuocSapHetHan_ChiTiet").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/zDanhSachThuocSapHetHan_ajax3.aspx?do=loadTablezDanhSachThuocSapHetHan_ChiTiet&IdDanhSach="+idkhoa+"&page="+page,
                  success: function (value){
                         $("#tableAjax_zDanhSachThuocSapHetHan_ChiTiet").html(value);
                    }
             });
         }
         function IdLoaiThuocSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/zDanhSachThuocSapHetHan_ajax3.aspx?do=IdLoaiThuocSearch",{
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
         function IdKhoSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/zDanhSachThuocSapHetHan_ajax3.aspx?do=IdKhoSearch"
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
//───────────────────────────────────────────────────────────────────────────────────────        
function InitData()
{
    $.BindFind({
    ajax:"../ajax/zDanhSachThuocSapHetHan_ajax3.aspx?do=InitData"
                +"&IdKhoa="+$.mkv.queryString("IdKhoa")
                +"&IdKho="+$.mkv.queryString("IdKho")
                +"&LoaiThuocID="+$.mkv.queryString("LoaiThuocID"),useEnabled:false
});
}
//───────────────────────────────────────────────────────────────────────────────────────