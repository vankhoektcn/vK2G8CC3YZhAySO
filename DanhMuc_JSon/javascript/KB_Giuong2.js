 $(document).ready(function() {
     $('input[id^=luuTable]').click(function () {
        $(this).LuuTable({ajax:"../ajax/KB_Giuong_ajax2.aspx?do=luuTable",tablename:"gridTable"});
     });
     $("#timKiem").click(function () {
            Find(this);
     });
    $("#timKiem").click();
 });
 function xoa(control,bool){
    if(bool || bool == null)
      $(control).XoaRow({ajax:'../ajax/KB_Giuong_ajax2.aspx?do=xoa'});
 }
  function Find(control) {
      $(control).TimKiem({
             ajax:"../ajax/KB_Giuong_ajax2.aspx?do=TimKiem",dataType:'json',showPopup:false
       },function () {
             $("#tableAjax_KB_Giuong").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
             return true;
       },function (data) {
            var html = "";
            html+="<table class='jtable' id=\"gridTable\">";
            html+="<tr>";
            html+="<th>STT</th>";
            html+="<th></th>";
            html+="<th>Khoa</th>";
            html+="<th>Phòng</th>";
            html+="<th>Tên giường</th>";
            html+="<th>Loại giường</th>";
            html+="<th></th>";
            html+="</tr>";
            html+="</table>";
            html+="<div id='paging' style='width:100%;height:50px'/>";
            $("#tableAjax_KB_Giuong").html(html);
      }).myfilter({
           txtfilter:"#gridTable [name=search]",
           paging:function(json,data){
                $("#tableAjax_KB_Giuong").find("#paging").html(data);
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
                      html[j++]="<td><input mkv='true' id='IdKhoa' type='hidden' value='" + item[i].IDKHOA + "'/><input mkv='true' id='mkv_IdKhoa' type='text' value='"+ item[i].TENKHOA +"' onfocus='IdKhoaSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='idPhong' type='hidden' value='" + item[i].IDPHONG + "'/><input mkv='true' id='mkv_idPhong' type='text' value='"+ item[i].TENPHONG +"' onfocus='idPhongSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='GiuongCode' type='text' value='" + item[i].GIUONGCODE + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='IDLOAIGIUONG' type='hidden' value='" + item[i].IDLOAIGIUONG + "'/><input mkv='true' id='mkv_IDLOAIGIUONG' type='text' value='"+ item[i].TENLOAIGIUONG +"' onfocus='IDLOAIGIUONGSEARCH(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].GIUONGID + "'/></td>";
                      html[j++]="</tr>";
                }
                html[j++]="<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
                $("#gridTable").find("tr:gt(0)").empty().remove();
                $("#gridTable").append($(html.join('')));
           }
      });
 }
 function idPhongSearch1(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/KB_Giuong_ajax2.aspx?do=idPhongSearch&IdKhoa=" + $("#IdKhoa").val() ,{
     minChars:0,
     width:350,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         setTimeout(function () {
         if($(obj).parents("#gridTable").attr("id") != null)
                $("#"+obj.id.replace("mkv_","")).val(data[1]);
             obj.focus();
         },100);
     });
 }
 function idPhongSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/KB_Giuong_ajax2.aspx?do=idPhongSearch&IdKhoa=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IdKhoa").val() ,{
     minChars:0,
     width:350,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         setTimeout(function () {
         if($(obj).parents("#gridTable").attr("id") != null)
                $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
             obj.focus();
         },100);
     });
 }
 
  function IDLOAIGIUONGSEARCH(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/KB_Giuong_ajax2.aspx?do=IDLOAIGIUONGSEARCH" ,{
     minChars:0,
     width:350,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         setTimeout(function () {
         if($(obj).parents("#gridTable").attr("id") != null)
                    $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
             obj.focus();
         },100);
     });
 }
 
 
 function IdKhoaSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/KB_Giuong_ajax2.aspx?do=IdKhoaSearch",{
     minChars:0,
     width:350,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         setTimeout(function () {
         if($(obj).parents("#gridTable").attr("id") != null)
                $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
             obj.focus();
         },100);
     });
 }
