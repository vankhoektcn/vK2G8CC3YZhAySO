 $(document).ready(function() {
     $('input[id^=luuTable]').click(function () {
        $(this).LuuTable({ajax:"../ajax/HS_THUOCNHOM_ajax2.aspx?do=luuTable",tablename:"gridTable"});
     });
     $("#timKiem").click(function () {
            Find(this);
     });
     $("#timKiem").click();
     $("#moi").click(function(){
        $(this).Moi();
     });
 });
 function xoa(control,bool){
    if(bool || bool == null)
      $(control).XoaRow({ajax:'../ajax/HS_THUOCNHOM_ajax2.aspx?do=xoa'});
 }
  function Find(control) {
      $(control).TimKiem({
             ajax:"../ajax/HS_THUOCNHOM_ajax2.aspx?do=TimKiem",dataType:'json',showPopup:false
       },function () {
             $("#tableAjax_HS_THUOCNHOM").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
             return true;
       },function (data) {
            var html = "";
            html+="<table class='jtable' id=\"gridTable\">";
            html+="<tr>";
            html+="<th>STT</th>";
            html+="<th></th>";
            html+="<th>THUỐC</th>";
            html+="<th>NHÓM</th>";
            html+="<th>PHÂN NHÓM</th>";
            html+="<th>TT Hoạt chất</th>";
            html+="</tr>";
            html+="</table>";
            html+="<div id='paging' style='width:100%;height:50px'/>";
            $("#tableAjax_HS_THUOCNHOM").html(html);
      }).myfilter({
           txtfilter:"#gridTable [name=search]",
           paging:function(json,data){
                $("#tableAjax_HS_THUOCNHOM").find("#paging").html(data);
           },
           result:function(json,item){
                var del = json.TABLE[0].DEL;
                var edit = json.TABLE[0].EDIT;
                var add = json.TABLE[0].ADD;
                var html=[],j=0;
                for( var i = -1, y = item.length; ++i != y;){ 
                      html[j++]="<tr>";
                      html[j++]="<td style='width:2%'>" + item[i].STT + "</td>";
                      html[j++]="<td style='width:2%'><a id=\"xoaRow\" style='color:" + (!del ? "#cfcfcf" : "") + "' onclick=\"xoa(this," + del + ");\">Xoá</a></td>";
                      html[j++]="<td style='width:20%'><input mkv='true' id='IDTHUOC' type='hidden' value='" + item[i].IDTHUOC + "'/><input mkv='true' id='mkv_IDTHUOC' type='text' value='"+ item[i].TENTHUOC +"' onfocus='IDTHUOCSearch(this);' class=\"down_select\" style='width:98%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td style='width:25%'><input mkv='true' id='CATEID' type='hidden' value='" + item[i].CATEID + "'/><input mkv='true' id='mkv_CATEID' type='text' value='"+ item[i].CATENAME +"' onfocus='CATEIDSearch(this);' class=\"down_select\" style='width:98%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td style='width:30%'><input mkv='true' id='IDNHOMTHUOC' type='hidden' value='" + item[i].IDNHOMTHUOC + "'/><input mkv='true' id='mkv_IDNHOMTHUOC' type='text' value='"+ item[i].TENNHOM +"' onfocus='IDNHOMTHUOCSearch(this,2);' class=\"down_select\" style='width:98%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td style='width:20%'><input mkv='true' id='TTHOATCHAT' type='text' value='"+ item[i].TTHOATCHAT1 +"' /></td>";
                      html[j++]="<td style='width:1%'><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].IDTHUOCNHOM + "'/></td>";

                      html[j++]="</tr>";
                }
                html[j++]="<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
                $("#gridTable").find("tr:gt(0)").empty().remove();
                $("#gridTable").append($(html.join('')));
           }
      });
 }
 function IDTHUOCSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/HS_THUOCNHOM_ajax2.aspx?do=IDTHUOCSearch&IdLoaiThuoc=1",{
     minChars:0,
     width:350,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
              $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 function IDTHUOCSearch1(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/HS_THUOCNHOM_ajax2.aspx?do=IDTHUOCSearch&IdLoaiThuoc=1",{
     minChars:0,
     width:350,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
              $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 function CATEIDSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/HS_THUOCNHOM_ajax2.aspx?do=CATEIDSearch",{
     minChars:0,
     width:650,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
                $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
  function CATEIDSearch1(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/HS_THUOCNHOM_ajax2.aspx?do=CATEIDSearch",{
     minChars:0,
     width:650,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
            $("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 function IDNHOMTHUOCSearch(obj,typeS)
 {
   var CateID="";
   if(typeS=="1")
    CateID=$("#CATEID_CRT").val();
    else 
     CateID=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#CATEID").val();
     $(obj).unautocomplete().autocomplete("../ajax/HS_THUOCNHOM_ajax2.aspx?do=IDNHOMTHUOCSearch&cateid="+CateID,{
     minChars:0,
     width:400,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         $("#"+obj.id.replace("mkv_","")).val(data[1]);
            if(typeS=="2")
            if($(obj).parents("#gridTable").attr("id") != null)
                $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 


