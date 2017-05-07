 $(document).ready(function() {
     $('input[id^=luuTable]').click(function () {
        $(this).LuuTable({ajax:"../ajax/dantoc_ajax2.aspx?do=luuTable",tablename:"gridTable"});
     });
     $("#timKiem").click(function () {
            Find(this);
     });
    $("#timKiem").click();
 });
 function xoa(control,bool){
    if(bool || bool == null)
      $(control).XoaRow({ajax:'../ajax/dantoc_ajax2.aspx?do=xoa'});
 }
  function Find(control) {
      $(control).TimKiem({
             ajax:"../ajax/dantoc_ajax2.aspx?do=TimKiem",dataType:'json',showPopup:false
       },function () {
             $("#tableAjax_dantoc").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
             return true;
       },function (data) {
            var html = "";
            html+="<table class='jtable' id=\"gridTable\">";
            html+="<tr>";
            html+="<th>STT</th>";
            html+="<th></th>";
            html+="<th>tendantoc</th>";
            html+="<th>madantoc</th>";
            html+="<th>diengiai</th>";
            html+="<th></th>";
            html+="</tr>";
            html+="</table>";
            html+="<div id='paging' style='width:100%;height:50px'/>";
            $("#tableAjax_dantoc").html(html);
      }).myfilter({
           txtfilter:"#gridTable [name=search]",
           paging:function(json,data){
                $("#tableAjax_dantoc").find("#paging").html(data);
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
                      html[j++]="<td><input mkv='true' id='tendantoc' type='text' value='" + item[i].TENDANTOC + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='madantoc' type='text' value='" + item[i].MADANTOC + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='diengiai' type='text' value='" + item[i].DIENGIAI + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].ID + "'/></td>";
                      html[j++]="</tr>";
                }
                html[j++]="<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
                $("#gridTable").find("tr:gt(1)").empty().remove();
                $("#gridTable").append($(html.join('')));
           }
      });
 }
