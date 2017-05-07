 $(document).ready(function() {
     $('input[id^=luuTable]').click(function () {
        $(this).LuuTable({ajax:"../ajax/ChanDoanICD_ajax2.aspx?do=luuTable",tablename:"gridTable"});
     });
     $("#timKiem").click(function () {
            Find(this);
     });
     $("#timKiem").click();
 });
 function xoa(control,bool){
    if(bool || bool == null)
      $(control).XoaRow({ajax:'../ajax/ChanDoanICD_ajax2.aspx?do=xoa'});
 }
  function Find(control) {
      $(control).TimKiem({
             ajax:"../ajax/ChanDoanICD_ajax2.aspx?do=TimKiem",dataType:'json',showPopup:false
       },function () {
             $("#tableAjax_ChanDoanICD").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
             return true;
       },function (data) {
            var html = "";
            html+="<table class='jtable' id=\"gridTable\">";
            html+="<tr>";
            html+="<th>STT</th>";
            html+="<th></th>";
            html+="<th>SoTT</th>";
            html+="<th>IDChuongICD</th>";
            html+="<th>IDNhomICD</th>";
            html+="<th>MaICD</th>";
            html+="<th>MoTa</th>";
            html+="<th>EnglishName</th>";
            html+="<th></th>";
            html+="</tr>";
            html+="</table>";
            html+="<div id='paging' style='width:100%;height:50px'/>";
            $("#tableAjax_ChanDoanICD").html(html);
      }).myfilter({
           txtfilter:"#gridTable [name=search]",
           paging:function(json,data){
                $("#tableAjax_ChanDoanICD").find("#paging").html(data);
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
                      html[j++]="<td><input mkv='true' id='SoTT' type='text' value='" + item[i].SOTT + "' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='IDChuongICD' type='hidden' value='" + item[i].IDCHUONGICD + "'/><input mkv='true' id='mkv_IDChuongICD' type='text' value='"+ item[i].TENCHUONGICD +"' onfocus='IDChuongICDSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='IDNhomICD' type='hidden' value='" + item[i].IDNHOMICD + "'/><input mkv='true' id='mkv_IDNhomICD' type='text' value='"+ item[i].TENNHOMICD +"' onfocus='IDNhomICDSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='MaICD' type='text' value='" + item[i].MAICD + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='MoTa' type='text' value='" + item[i].MOTA + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='EnglishName' type='text' value='" + item[i].ENGLISHNAME + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].IDICD + "'/></td>";
                      html[j++]="</tr>";
                }
                html[j++]="<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
                $("#gridTable").find("tr:gt(1)").empty().remove();
                $("#gridTable").append($(html.join('')));
           }
      });
 }
 function IDChuongICDSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/ChanDoanICD_ajax2.aspx?do=IDChuongICDSearch",{
     minChars:0,
     width:350,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 function IDNhomICDSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/ChanDoanICD_ajax2.aspx?do=IDNhomICDSearch",{
     minChars:0,
     width:350,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
