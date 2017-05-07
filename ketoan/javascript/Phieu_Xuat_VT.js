         $(document).ready(function() {
                 $.mkv.moveUpandDown("#tablefind");
               setControlFind($.mkv.queryString("idkhoachinh"));
                 $("#luu").click(function () {
                   $(this).Luu({
                         ajax:"../ketoan/ajax/Phieu_Xuat_VT_ajax.aspx?do=Luu"
                      },null,function () {
                           $.LuuTable({
                                 ajax:"../ketoan/ajax/Phieu_Xuat_VT_ajax.aspx?do=luuTablePHIEU_XUAT_VT_CT&phieu_xuat_id=" + $.mkv.queryString("idkhoachinh"),
                                 tablename:"gridTable"
                           });
                      });
                });
                $("#moi").click(function () {
                     $(this).Moi();                    
                     loadTableAjaxPHIEU_XUAT_VT_CT('');
                });
                $("#xoa").click(function () {
                   $(this).Xoa({
                         ajax:"../ketoan/ajax/Phieu_Xuat_VT_ajax.aspx?do=xoa"
                    },null,function () {
                         loadTableAjaxPHIEU_XUAT_VT_CT('');
                     });
                });
                $("#timKiem").click(function () {
                    Find($(this)); 
                 });
         });
           function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"../ketoan/ajax/Phieu_Xuat_VT_ajax.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
                     loadTableAjaxPHIEU_XUAT_VT_CT($.mkv.queryString("idkhoachinh"));                    
                 });
              }else{loadTableAjaxPHIEU_XUAT_VT_CT();}         
            }
          function Find(control,page) {
              if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"../ketoan/ajax/Phieu_Xuat_VT_ajax.aspx?do=TimKiem&page="+page
               });
          }
         function xoaontable(control){
              $(control).XoaRow({
                 ajax:"../ketoan/ajax/Phieu_Xuat_VT_ajax.aspx?do=xoaPHIEU_XUAT_VT_CT"
              });
         }
         function loadTableAjaxPHIEU_XUAT_VT_CT(idkhoa,page)
         {
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_PHIEU_XUAT_VT_CT").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ketoan/ajax/Phieu_Xuat_VT_ajax.aspx?do=loadTablePHIEU_XUAT_VT_CT&phieu_xuat_id="+idkhoa+"&page="+page,
                  success: function (value){
                         document.getElementById("tableAjax_PHIEU_XUAT_VT_CT").innerHTML=value;
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                    }
             });
         }
         function ShowVatTu(obj)
         {
             var data1;
             $(obj).unautocomplete().autocomplete("../ketoan/ajax/PHIEU_NHAP_VT_ajax.aspx?do=ShowVatTu",{
             minChars:0,
             width:150,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[2];
             }}).result(function(event,data){
                 if($(obj).parents("#tableAjax_PHIEU_XUAT_VT_CT").attr("danhmuc_vattu_id") != null){
                     $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[2]);
                     $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#ma_vt").val(data[1]);
                     if ($("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[2]); 
                     $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#ma_vt").val(data[1]); 
                     data1 = null;                  
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }

