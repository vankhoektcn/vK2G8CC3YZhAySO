 $(document).ready(function() {
     $('input[id^=luuTable]').click(function () {
        $(this).LuuTable({ajax:"../ajax/KB_NOIDANGKYKB_ajax2.aspx?do=luuTable",tablename:"gridTable"});
     });
     $("#timKiem").click(function () {
            Find(this);
     });
      $("#timKiem").click();
 });
 function xoa(control,bool){
    if(bool || bool == null)
      $(control).XoaRow({ajax:'../ajax/KB_NOIDANGKYKB_ajax2.aspx?do=xoa'});
 }
  function Find(control) {
      $(control).TimKiem({
             ajax:"../ajax/KB_NOIDANGKYKB_ajax2.aspx?do=TimKiem",dataType:'json',showPopup:false
       },function () {
             $("#tableAjax_KB_NOIDANGKYKB").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
             return true;
       },function (data) {
            var html = "";
            html+="<table class='jtable' id=\"gridTable\">";
            html+="<tr>";
            html+="<th>STT</th>";
            html+="<th></th>";
            html+="<th>MADANGKY</th>";
            html+="<th>TENNOIDANGKY</th>";
            html+="<th>DUNGTUYEN</th>";
            html+="<th></th>";
            html+="</tr>";
            html+="</table>";
            html+="<div id='paging' style='width:100%;height:50px'/>";
            $("#tableAjax_KB_NOIDANGKYKB").html(html);
      }).myfilter({
           txtfilter:"#gridTable [name=search]",
           paging:function(json,data){
                $("#tableAjax_KB_NOIDANGKYKB").find("#paging").html(data);
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
                      html[j++]="<td><input mkv='true' id='MADANGKY' type='text' value='" + item[i].MADANGKY + "' style='width:200px' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='TENNOIDANGKY' type='text' value='" + item[i].TENNOIDANGKY + "' style='width:600px' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='DUNGTUYEN' type='checkbox' " + (item[i].DUNGTUYEN == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + " style='width:50px'  /></td>";
                      html[j++]="<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].IDNOIDANGKY + "'/></td>";
                      html[j++]="</tr>";
                }
                html[j++]="<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
                $("#gridTable").find("tr:gt(1)").empty().remove();
                $("#gridTable").append($(html.join('')));
           }
      });
 }
