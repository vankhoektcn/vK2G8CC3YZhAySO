         $(document).ready(function() {
                 $.mkv.moveUpandDown("#tablefind");
               setControlFind($.mkv.queryString("idkhoachinh"));
                 $("#luu").click(function () {
                   $(this).Luu({
                         ajax:"../ajax/KTTM_DoanhThuKhoa_ajax.aspx?do=Luu"
                      },null,function () {
                           $.LuuTable({
                                 ajax:"../ajax/KTTM_DoanhThuKhoa_ajax.aspx?do=luuTabledoanhthu_khoa_kt_ct&doanhthukhoaid=" + $.mkv.queryString("idkhoachinh"),
                                 tablename:"gridTable"
                           });
                      });
                });
                $("#moi").click(function () {
                     $(this).Moi();                    
                     loadTableAjaxdoanhthu_khoa_kt_ct('');
                });
                $("#xoa").click(function () {
                   $(this).Xoa({
                         ajax:"../ajax/KTTM_DoanhThuKhoa_ajax.aspx?do=xoa"
                    },null,function () {
                         loadTableAjaxdoanhthu_khoa_kt_ct('');
                     });
                });
                $("#timKiem").click(function () {
                    Find($(this)); 
                 });
         });
           function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/KTTM_DoanhThuKhoa_ajax.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
                     loadTableAjaxdoanhthu_khoa_kt_ct($.mkv.queryString("idkhoachinh"));                    
                 });
              }else{loadTableAjaxdoanhthu_khoa_kt_ct();}         
            }
          function Find(control,page) {
              if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/KTTM_DoanhThuKhoa_ajax.aspx?do=TimKiem&page="+page
               });
          }
         function xoaontable(control,bool){
           if(bool || bool == null)
              $(control).XoaRow({
                 ajax:"../ajax/KTTM_DoanhThuKhoa_ajax.aspx?do=xoadoanhthu_khoa_kt_ct"
              });
         }
         function loadTableAjaxdoanhthu_khoa_kt_ct(idkhoa,page)
         {
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_doanhthu_khoa_kt_ct").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/KTTM_DoanhThuKhoa_ajax.aspx?do=loadTabledoanhthu_khoa_kt_ct&doanhthukhoaid="+idkhoa+"&page="+page,
                  success: function (value){
                         document.getElementById("tableAjax_doanhthu_khoa_kt_ct").innerHTML=value;
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                    }
             });
         }
