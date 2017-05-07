 $(document).ready(function() {
       
     $.mkv.moveUpandDown("#tablefind");
       setControlFind($.mkv.queryString("idkhoachinh"));
        
         $("#luu").click(function () {
            
           $(this).Luu({
                 ajax:"ajax/hs_DangKyCLS_ajax3.aspx?do=Luu"
              },null,function () {
                   $.LuuTable({
                         ajax:"ajax/hs_DangKyCLS_ajax3.aspx?do=luuTablekhambenhcanlamsan&IdDangKyCLS=" + $.mkv.queryString("idkhoachinh") + "&bscd=" + encodeURIComponent($("#tenbschidinh").val()) + "&idkhoadangky=" + $("#idkhoadangky").val(),
                         tablename:"gridTablecls"
                   });
              });
        });
        $("#moi").click(function () {
//                     $(this).Moi();                    
//                     loadTableAjaxkhambenhcanlamsan('');
            window.close();
        });
        $("#xoa").click(function () {
           $(this).Xoa({
                 ajax:"ajax/hs_DangKyCLS_ajax3.aspx?do=xoa"
            },null,function () {
                 loadTableAjaxkhambenhcanlamsan('');
             });
        });
        $("#timKiem").click(function () {
            Find($(this)); 
         });
        /* $("#gridTablecls #mkv_idkhoa").live('hover', function() {
        if ($(this).val().length < 1) {
            layfirst = true;

            if ($(this).attr("id") == "mkv_idkhoa")
                idkhoasearch($(this));

            layfirst = false;
        }
    });*/
 });
 
function idkhoasearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/hs_DangKyCLS_ajax3.aspx?do=idkhoasearch", {
        minChars: 0,
        width: 150,
        scroll: true,
        catche: false,
        addRow: true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        
        $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}
function idphongsearch(obj) {

    $(obj).unautocomplete().autocomplete("ajax/hs_DangKyCLS_ajax3.aspx?do=idphongsearch&idpkb=" + $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#idkhoa").val(), {
        minChars: 0,
        width: 200,
        scroll: true,
        catche: false,
        addRow: true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
    
        $("#gridTableclscls").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}
   function setControlFind(idkhoatimkiem) {
      if(idkhoatimkiem != "" && idkhoatimkiem != null){
         $.BindFind({ajax:"ajax/hs_DangKyCLS_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
             loadTableAjaxkhambenhcanlamsan($.mkv.queryString("idkhoachinh"));   
            if($("#dathu").val()=="1" ||(  $("#idkhambenh").val()!="0"  && $("#idkhambenh").val()!="")  ){
                 $("#_luu").attr("disabled","disabled");
            }
         });
      }else{loadTableAjaxkhambenhcanlamsan();}         
    }
  function Find(control,page) {
      if(page == null)page = "1";
      $(control).TimKiem({
             ajax:"ajax/hs_DangKyCLS_ajax3.aspx?do=TimKiem&page="+page
       });
  }
 function xoaontable(control,bool){
   var sttmoi=$(control).parent().parent().index();
   if(bool || bool == null)
      $(control).XoaRow({
         ajax:"ajax/hs_DangKyCLS_ajax3.aspx?do=xoakhambenhcanlamsan"
      });
    var row=$("#gridTableclscls").find("tr");
    for(var i=sttmoi;i<row.length-1;i++){
        row[i].childNodes[0].innerHTML=i;
    }
 }
 function loadTableAjaxkhambenhcanlamsan(idkhoa,page)
 {
     if(idkhoa == null) idkhoa = "";
         if(page == null) page = "1";
         $("#tableAjax_khambenhcanlamsan").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
          $.ajax({
         type:"GET",
         cache:false,
         url:"ajax/hs_DangKyCLS_ajax3.aspx?do=loadTablekhambenhcanlamsan&IdDangKyCLS="+idkhoa+"&page="+page,
          success: function (value){
                 document.getElementById("tableAjax_khambenhcanlamsan").innerHTML=value;
                $("table.jtable tr:nth-child(odd)").addClass("odd");
                 $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                 $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
            }
     });
 }

 function idcanlamsanSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("ajax/hs_DangKyCLS_ajax3.aspx?do=idcanlamsanSearch" + "&tennhom=" +  encodeURIComponent($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#mkv_tennhom").val()),{
     minChars:0,
     width:350,
     scroll:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         if($(obj).parents("#gridTablecls").attr("id") != null){
             $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
            $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val("1");
  
             if ($("#gridTablecls").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
          
                 $.mkv.themDongTable("gridTablecls");
         }
         setTimeout(function () {
            $("#gridTablecls").find("tr").next().eq($(obj).parent().parent().index()).find("#mkv_idcanlamsan").focus();
         },100);
     });
 }
  $.mkv.afterThemDong = function(tablename, dongso) {
    if (tablename == "gridTablecls") {
        //xac dinh select row below
        $("#"+tablename).find("tr").eq(dongso+1).find("#idkhoa").val($("#"+tablename).find("tr").eq(dongso).find("#idkhoa").val());
        $("#"+tablename).find("tr").eq(dongso+1).find("#mkv_idkhoa").val($("#"+tablename).find("tr").eq(dongso).find("#mkv_idkhoa").val());
        $("#"+tablename).find("tr").eq(dongso+1).find("#mkv_tennhom").val($("#"+tablename).find("tr").eq(dongso).find("#mkv_tennhom").val());
        //end xac dinh 
    }
}
function idbenhnhanSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("ajax/hs_DangKyCLS_ajax3.aspx?do=idbenhnhanSearch&tenbenhnhan="+ $("#idbenhnhan").val(),{
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

function idnguoidungSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("ajax/hs_DangKyCLS_ajax3.aspx?do=idnguoidungSearch",{
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
function LoadDanhSachBacSiCD(obj) {

    $(obj).unautocomplete().autocomplete("ajax/hs_DangKyCLS_ajax3.aspx?do=LoadDanhSachBacSiCD", {
        minChars: 0,
        width: 240,
        scroll: true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
            $("#idbacsicd").val(data[1]);
                $(obj).val(data[0]);
            setTimeout(function() {
         
        }, 100);
    });
}
 function idkhoadangkysearch(obj) {
$(obj).unautocomplete().autocomplete("ajax/hs_DangKyCLS_ajax3.aspx?do=idkhoadangkysearch", {
    minChars: 0,
    width: 240,
    scroll: true,
    catche: false,
    addRow: true,
    header:false,
    formatItem: function(data) {
        return data[0];
    } 
}).result(function(event, data) {
     $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
    setTimeout(function() {
        obj.focus();
    }, 100);
});
}
function huyontablecls(control)
{
 if($("#gridTablecls").find("tr").eq($(control).parent().parent().index()).find("#idcanlamsan").val()==""){ 
        $(control).parent().parent().remove();
            return;
    }
  jConfirm("Bạn có thực sự muốn hủy cận lâm sàn này ? ","Xác nhận hủy",function(r){
    if(r){
         var stssmoi =$(control).parent().parent().index();
            $.ajax({
                async:false,
                cache:false,
                type:'post',
                url:"ajax/hs_DangKyCLS_ajax3.aspx?do=HuyCLS&idkhambenhcanlamsan="+$("#gridTablecls").find("tr").eq($(control).parent().parent().index()).find("#idkhoachinh").val()  + "&idcanlamsan=" + $("#gridTablecls").find("tr").eq($(control).parent().parent().index()).find("#idcanlamsan").val(),
                success:function(data){
                    $.mkv.myalert(data,2000,"info");
                        $(control).parent().parent().remove();
                }
            });
            var row=$("#gridTablecls").find("tr");
            for(var i=stssmoi;i<row.length-1;i++){
                row[i].childNodes[0].innerHTML=i;
            }
            tongtiencls();
        }
  });
}