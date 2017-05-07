
 $(document).ready(function() {
     $('input[id^=luuTable]').click(function () {
        $(this).LuuTable({ajax:"../ajax/banggiadichvu_vc_ajax.aspx?do=luuTable",tablename:"gridTable"});
     });
     $("#timKiem").click(function () {
            Find(this);
     });
     $("#timKiem").click();
 });
 function xoa(control,bool){
    if(bool || bool == null)
      $(control).XoaRow({ajax:'../ajax/banggiadichvu_vc_ajax.aspx?do=xoa'});
 }
  function Find(control) {
      $(control).TimKiem({
             ajax:"../ajax/banggiadichvu_vc_ajax.aspx?do=TimKiem",dataType:'json',showPopup:false
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
            html+="<th>Giá DV</th>";
            html+="<th>BH?</th>";
            html+="<th>Giá BH</th>";
            html+="<th>ĐVT</th>";
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
                      html[j++]="<td><input mkv='true' id='tendichvu' type='text' value='" + item[i].TENDICHVU + "' style='width:700px' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='giadichvu' type='text' value='" + formatCurrency1(item[i].GIADICHVU) + "' onblur='TestSo(this,false,false);'  style='width:100px'  " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='IsSuDungChoBH' type='checkbox' " + (item[i].ISSUDUNGCHOBH == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "  style='width:50px' /></td>";
                      html[j++]="<td><input mkv='true' id='BHTra' type='text' value='" + formatCurrency1(item[i].BHTRA) + "' onblur='TestSo(this,false,false);'  style='width:100px'  " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='IDDVT' type='hidden' value='" + item[i].IDDVT + "'/><input mkv='true' id='mkv_IDDVT' type='text' value='"+ item[i].TENDVT +"' onfocus='IDDVTSearch(this);' class=\"down_select\" style='width:50px' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].IDBANGGIADICHVU + "'/></td>";
                      html[j++]="</tr>";
                }
                html[j++]="<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
                $("#gridTable").find("tr:gt(0)").empty().remove();
                $("#gridTable").append($(html.join('')));
           }
      });
 }
 function idphongkhambenhSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/banggiadichvu_vc_ajax.aspx?do=idphongkhambenhSearch",{
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
     $(obj).unautocomplete().autocomplete("../ajax/banggiadichvu_vc_ajax.aspx?do=IDDVTSearch",{
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