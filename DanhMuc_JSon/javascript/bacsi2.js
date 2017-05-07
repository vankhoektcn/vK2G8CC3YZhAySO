
 $(document).ready(function() {
     $('input[id^=luuTable]').click(function () {
        $(this).LuuTable({ajax:"../ajax/bacsi_ajax2.aspx?do=luuTable",tablename:"gridTable",isGet:false});
     });
     $("#timKiem").click(function () {
            Find(this);
     });
     $("#timKiem").click();
 });
 function xoa(control,bool){
    if(bool || bool == null)
      $(control).XoaRow({ajax:'../ajax/bacsi_ajax2.aspx?do=xoa'});
 }
  function Find(control) {
      $(control).TimKiem({
             ajax:"../ajax/bacsi_ajax2.aspx?do=TimKiem",dataType:'json',showPopup:false
       },function () {
             $("#tableAjax_bacsi").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
             return true;
       },function (data) {
            var html = "";
            html+="<table class='jtable' id=\"gridTable\">";
            html+="<tr>";
            html+="<th>STT</th>";
            html+="<th></th>";
            html+="<th>mabacsi</th>";
            html+="<th>tenbacsi</th>";
            html+="<th>gioitinh</th>";
            html+="<th>idphongkhambenh</th>";
            html+="<th>username</th>";
            html+="<th>pass</th>";
            html+="<th></th>";
            html+="</table>";
            html+="<div id='paging' style='width:100%;height:50px'/>";
            $("#tableAjax_bacsi").html(html);
      }).myfilter({
           txtfilter:"#gridTable [name=search]",
           paging:function(json,data){
                $("#tableAjax_bacsi").find("#paging").html(data);
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
                      html[j++]="<td><input mkv='true' id='mabacsi' type='text' value='" + item[i].MABACSI + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='tenbacsi' type='text' value='" + item[i].TENBACSI + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='gioitinh' type='checkbox' " + (item[i].GIOITINH == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='idphongkhambenh' type='hidden' value='" + item[i].IDPHONGKHAMBENH + "'/><input mkv='true' id='mkv_idphongkhambenh' type='text' value='"+ item[i].TENPHONGKHAMBENH +"' onfocus='idphongkhambenhSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='username' type='text' value='" + item[i].USERNAME + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='pass' type='password' value='" + item[i].PASS + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].IDBACSI + "'/></td>";
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
     $(obj).unautocomplete().autocomplete("../ajax/bacsi_ajax2.aspx?do=idphongkhambenhSearch",{
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
