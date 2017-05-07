
 $(document).ready(function() {
     $('input[id^=luuTable]').click(function () {
        $(this).LuuTable({ajax:"../ajax/nguoidung_ajax2.aspx?do=luuTable",tablename:"gridTable"});
     });
     $("#timKiem").click(function () {
            Find(this);
     });
     $("#timKiem").click();
 });
 function xoa(control,bool){
    if(bool || bool == null)
      $(control).XoaRow({ajax:'../ajax/nguoidung_ajax2.aspx?do=xoa'});
 }
  function Find(control) {
      $(control).TimKiem({
             ajax:"../ajax/nguoidung_ajax2.aspx?do=TimKiem",dataType:'json',showPopup:false
       },function () {
             $("#tableAjax_nguoidung").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
             return true;
       },function (data) {
            var html = "";
            html+="<table class='jtable' id=\"gridTable\">";
            html+="<tr>";
            html+="<th>STT</th>";
            html+="<th></th>";
            html+="<th>Tên người dùng</th>";
            html+="<th>Tên đăng nhập</th>";
            html+="<th>Mật khẩu</th>";
            html+="<th>?Admin</th>";
            html += "<th>Nhóm người dùng</th>";
            html += "<th>Phòng</th>";
            html+="<th></th>";
            html+="</table>";
            html+="<div id='paging' style='width:100%;height:50px'/>";
            $("#tableAjax_nguoidung").html(html);
      }).myfilter({
           txtfilter:"#gridTable [name=search]",
           paging:function(json,data){
                $("#tableAjax_nguoidung").find("#paging").html(data);
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
                      html[j++]="<td><input mkv='true' id='tennguoidung' type='text' value='" + item[i].TENNGUOIDUNG + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='username' type='text' value='" + item[i].USERNAME + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='matkhau' type='password' value='" + item[i].MATKHAU + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='isadmin' type='checkbox' " + (item[i].ISADMIN=="True" ? " checked":"") + " " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++] = "<td><input mkv='true' id='nhomID' type='hidden' value='" + item[i].NHOMID + "'/><input mkv='true' id='mkv_nhomID' type='text' value='" + item[i].TENNHOM + "' onfocus='nhomIDSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++] = "<td><input mkv='true' id='idphong' type='hidden' value='" + item[i].IDPHONG + "'/><input mkv='true' id='mkv_idphong' type='text' value='" + item[i].TENPHONG + "' onfocus='phongidSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].IDNGUOIDUNG + "'/></td>";
                      html[j++]="</tr>";
                }
                html[j++]="<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
                $("#gridTable").find("tr:gt(0)").empty().remove();
                $("#gridTable").append($(html.join('')));
           }
      });
 }
 function nhomIDSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/nguoidung_ajax2.aspx?do=nhomIDSearch",{
     minChars:0,
     width:350,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
              $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 function nhomIDSearch2(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/nguoidung_ajax2.aspx?do=nhomIDSearch",{
     minChars:0,
     width:350,
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

function phongidSearch(obj) {
    $(obj).unautocomplete().autocomplete("../ajax/nguoidung_ajax2.aspx?do=phongidSearch", {
         minChars: 0,
         width: 350,
         scroll: true,
         addRow: true,
         formatItem: function (data) {
             return data[0];
         } 
     }).result(function (event, data) {
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         }, 100);
     });
 }

