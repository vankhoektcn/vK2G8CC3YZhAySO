         $(document).ready(function() {
               setControlFind($.mkv.queryString("idkhoachinh"));
               $("#luu").click(function () {
                   $(this).Luu({
                      ajax:"ajax/KTDM_DanhMucKhoa_ajax.aspx?do=Luu"
                      },null,function () {
                         $("#timKiem").click();
                   });
                });
                $("#moi").click(function () {
                     $(this).Moi();  
                });
                $("#xoa").click(function () {
                    $(this).Xoa({
                        ajax:'ajax/KTDM_DanhMucKhoa_ajax.aspx?do=xoa'
                    },null,function () {
                         $("#timKiem").click();
                    });
                });
                $("#timKiem").click(function () {
                    Find(this);
                });
         });
          function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"ajax/KTDM_DanhMucKhoa_ajax.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem});
              }      
          }
           function Find(control,page) {
           if(page == null) page = "1";
              $(control).TimKiem({
                     ajax:"ajax/KTDM_DanhMucKhoa_ajax.aspx?do=TimKiem&page="+page,showPopup:false
               },function () {
                 $("#tableAjax_phongkhambenh").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                 return true;
              },function (data) {
                     $("#tableAjax_phongkhambenh").html(data);
                     $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
               });              
          }
function tkdoanhthuSearch(obj)
 {  
     $(obj).unautocomplete().autocomplete("ajax/ajax.aspx?do=taikhoanSearch",{
     minChars:0,
     width:390,
     scroll:true,
     header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:20%;color:white;float:left; font-size:12px;text-algin:left;\" >Tài khoản</div>"
                      + "<div style=\"width:80%;color:white;float:left;font-size:12px;\" >Tên tài khoản</div>"
                  + "</div>",
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
             $("#"+obj.id.replace("mkv_","")).val(data[1]);
                $(this).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 
 function tkchiphiSearch(obj)
 {  
     $(obj).unautocomplete().autocomplete("ajax/ajax.aspx?do=taikhoanSearch",{
     minChars:0,
     width:390,
     scroll:true,
     header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:20%;color:white;float:left; font-size:12px;text-algin:left;\" >Tài khoản</div>"
                      + "<div style=\"width:80%;color:white;float:left;font-size:12px;\" >Tên tài khoản</div>"
                  + "</div>",
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
             $("#"+obj.id.replace("mkv_","")).val(data[1]);
                $(this).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 

