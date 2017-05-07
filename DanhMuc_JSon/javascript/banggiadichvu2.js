
 $(document).ready(function() {
     $('input[id^=luuTable]').click(function () {
        $(this).LuuTable({ajax:"../ajax/banggiadichvu_ajax2.aspx?do=luuTable",tablename:"gridTable"});
     });
     $("#timKiem").click(function () {
            Find(this);
     });
     $("#timKiem").click();
 });
 function xoa(control,bool){
    if(bool || bool == null)
      $(control).XoaRow({ajax:'../ajax/banggiadichvu_ajax2.aspx?do=xoa'});
 }
 
  function ChiTiet(idbanggiadichvu,tendichvu){
           if(idbanggiadichvu != "" && idbanggiadichvu != null)
                 window.open("chitietdichvu2.aspx?idbanggiadichvu="+idbanggiadichvu +"&tendichvu="+ encodeURIComponent(tendichvu));
 }
 
 
  function Find(control) {
      $(control).TimKiem({
             ajax:"../ajax/banggiadichvu_ajax2.aspx?do=TimKiem",dataType:'json',showPopup:false
       },function () {
             $("#tableAjax_banggiadichvu").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
             return true;
       },function (data) {
            var html = "";
            html+="<table class='jtable' id=\"gridTable\">";
            html+="<tr>";
            html+="<th>STT</th>";
            html+="<th></th>";
            html+="<th>Tên dịch vụ</th>";
            html+="<th>BHYT?</th>";
            html+="<th>KTC?</th>";
            html+="<th>CLS?</th>";
            html+="<th>V.C?</th>";
            html+="<th>DVKT?</th>";
            html+="<th>ĐVT</th>";
            html+="<th>Tên nhóm CD</th>";
            html+="<th>Nhóm trên BV</th>";
            html+="<th></th>";
            html+="<th></th>";
            html+="</tr>";
            html+="</table>";
            html+="<div id='paging' style='width:100%;height:50px'/>";
            $("#tableAjax_banggiadichvu").html(html);
      }).myfilter({
           txtfilter:"#gridTable [name=search]",
           paging:function(json,data){
                $("#tableAjax_banggiadichvu").find("#paging").html(data);
           },
           result:function(json,item){
                var del = json.TABLE[0].DEL;
                var edit = json.TABLE[0].EDIT;
                var add = json.TABLE[0].ADD;
                var html=[],j=0;
                for( var i = -1, y = item.length; ++i != y;){ 
                      html[j++]="<tr>";
                      html[j++]="<td>" + item[i].STT + "</td>";
                      html[j++]="<td> <a id=\"xoaRow\" style='color:" + (!del ? "#cfcfcf" : "") + "' onclick=\"xoa(this," + del + ");\">Xoá</a></td>";
                      html[j++]="<td><input mkv='true' id='tendichvu' type='text' value='" + item[i].TENDICHVU + "'  style='width:300px' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='IsSuDungChoBH' type='checkbox' " + (item[i].IsSuDungChoBH == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "   style='width:30px' /></td>";
                      html[j++]="<td><input mkv='true' id='IsKTC' type='checkbox' " + (item[i].ISKTC == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + " style='width:30px'/></td>";
                      html[j++]="<td><input mkv='true' id='IsCLS' type='checkbox' " + (item[i].ISCLS == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + " style='width:30px'/></td>";
                      html[j++]="<td><input mkv='true' id='IsVC' type='checkbox' " + (item[i].ISVC == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + " style='width:30px'/></td>";
                      html[j++]="<td><input mkv='true' id='IsDVKT' type='checkbox' " + (item[i].ISDVKT == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + " style='width:30px'/></td>";
                      html[j++]="<td><input mkv='true' id='IDDVT' type='hidden' value='" + item[i].IDDVT + "'/><input mkv='true' id='mkv_IDDVT' type='text' value='"+ item[i].TENDVT +"' onfocus='IDDVTSearch(this);' class=\"down_select\" style='width:40px' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='TENNHOMCD' type='text' value='" + item[i].TENNHOMCD + "'  style='width:150px' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='IDNHOMINBV' type='hidden' value='" + item[i].IDNHOMINBV + "'/><input mkv='true' id='mkv_IDNHOMINBV' type='text' value='"+ item[i].TENHOMBV +"' onfocus='IDNhomINBV_Search(this);' class=\"down_select\" style='width:170px' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].IDBANGGIADICHVU + "'/></td>";
                      html[j++]="<td> <a id=\"ChiTiet\"  onclick=\"ChiTiet('"+item[i].IDBANGGIADICHVU+"','"+  item[i].TENDICHVU+"');\">Chi tiết</a></td>";
                      html[j++]="</tr>";
                }
                html[j++]="<tr><td></td><td colspan='3'>" + (1==2 ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
                $("#gridTable").find("tr:gt(0)").empty().remove();
                $("#gridTable").append($(html.join('')));
           }
      });
 }
 function idphongkhambenhSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/banggiadichvu_ajax2.aspx?do=idphongkhambenhSearch",{
     minChars:0,
     width:350,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
              if($(obj).parents("#gridTable").attr("id") != null)
                $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);

         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 
 function IDNhomINBV_Search(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/banggiadichvu_ajax2.aspx?do=IDNhomINBV_Search",{
     minChars:0,
     width:350,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
              if($(obj).parents("#gridTable").attr("id") != null)
                $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);

         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
  function IDDVTSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/banggiadichvu_ajax2.aspx?do=IDDVTSearch",{
     minChars:0,
     width:350,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
              if($(obj).parents("#gridTable").attr("id") != null)
                $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);

         setTimeout(function () {
             obj.focus();
         },100);
     });
 }