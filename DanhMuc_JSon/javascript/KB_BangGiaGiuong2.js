
 $(document).ready(function() {
     $('input[id^=luuTable]').click(function () {
        $(this).LuuTable({ajax:"../ajax/KB_BangGiaGiuong_ajax2.aspx?do=luuTable&TuNgay=" + $("#TuNgay").val(),tablename:"gridTable"});
     },function(){
        if($("#TuNgay").val()=="" || $("#TuNgay").val()==null){
                $.mkv.myerror("Vui lòng chọn ngày áp dụng");
            return false;
        }
        return true;
     },function(){
            $.mkv.myalert("Hoàn thành",2000,"success");
     });
     $("#timKiem").click(function () {
            Find(this);
            setControlFind($("#LANID").val());
     });
      $("#LANID").DropList({
        ajax:"../ajax/KB_BangGiaGiuong_ajax2.aspx?do=getLan",defaultVal:"---"
        },null,function(){
            $("#LANID")[0].selectedIndex=1;
                $("#timKiem").click();
        });
    $("#COPY").click(function(){
        CopyBangGia(this);
    });
 
 });
 function xoa(control,bool){
    if(bool || bool == null)
      $(control).XoaRow({ajax:'../ajax/KB_BangGiaGiuong_ajax2.aspx?do=xoa'});
 }
 function setControlFind(idkhoatimkiem)
 {
    if(idkhoatimkiem!=null && idkhoatimkiem!="")
    {
        $.BindFind({
            ajax:"../ajax/KB_BangGiaGiuong_ajax2.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem
            ,dataType:"json"
        },null,function(){
            $.mkv.ExtendtionLuu(false,{Frame:".in-a"});
        });
    }
 }
  function Find(control) {
      $(control).TimKiem({
             ajax:"../ajax/KB_BangGiaGiuong_ajax2.aspx?do=TimKiem",dataType:'json',showPopup:false
       },function () {
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
            html+="<th>Giá DV</th>";
            html+="<th>? BHYT</th>";
            html+="<th>Giá BH</th>";
            html+="<th></th>";
            html+="</tr>";
            html+="</table>";
            html+="<div id='paging' style='width:100%;height:50px'/>";
            $("#tableAjax_KB_BangGiaGiuong").html(html);
      }).myfilter({
           txtfilter:"#gridTable [name=search]",
           paging:function(json,data){
                $("#tableAjax_KB_BangGiaGiuong").find("#paging").html(data);
           },
           result:function(json,item){
                var del = json.TABLE[0].DEL;
                var edit = json.TABLE[0].EDIT;
                var add = false;
                var html=[],j=0;
                for( var i = -1, y = item.length; ++i != y;){ 
                      html[j++]="<tr>";
                      html[j++]="<td>" + item[i].STT + "</td>";
                      html[j++]="<td> <a id=\"xoaRow\" style='color:" + (!del ? "#cfcfcf" : "") + "' onclick=\"xoa(this," + del + ");\">Xoá</a></td>";
                      html[j++]="<td style='text-align:left;'>" + item[i].TENKHOA + "</td>";
                      html[j++]="<td style='text-align:left;'>" + item[i].TENPHONG +"</td>";
                      html[j++]="<td><input mkv='true' id='GiuongId' type='hidden' value='" + item[i].GIUONGID + "'/><input mkv='true' id='mkv_GiuongId' type='text' value='"+ item[i].GIUONGCODE +"' onfocus='GiuongIdSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='GiaBH' type='text' value='" + formatCurrency1(item[i].GIABH) + "' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='IsBHYT' type='checkbox' " + (item[i].ISBHYT == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='GiaDV' type='text' value='" + formatCurrency1(item[i].GIADV) + "' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].BANGGIAGIUONGID + "'/></td>";
                      html[j++]="</tr>";
                }
                $("#gridTable").find("tr:gt(1)").empty().remove();
                $("#gridTable").append($(html.join('')));
           }
      });
 }
 function GiuongIdSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/KB_BangGiaGiuong_ajax2.aspx?do=GiuongIdSearch",{
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
 function IdKhoaSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/KB_BangGiaGiuong_ajax2.aspx?do=IdKhoaSearch",{
     minChars:0,
     scroll:true,
     addRow:true,
     header:false,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 function CopyBangGia(obj)
 {
    var lanthu=$("#LANTHU").val();
    if(lanthu=="1" && lanthu=="null")
    {
        $.mkv.myerror("Không thể copy từ lần thứ 0 ");
        return false;
    }
    lanthu=lanthu-1;
     $(obj).TimKiem({
             ajax:"../ajax/KB_BangGiaGiuong_ajax2.aspx?do=CopyBangGia&lanthu=" + lanthu,dataType:'json',showPopup:false
       },function () {
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
            html+="<th>Giá DV</th>";
            html+="<th>? BHYT</th>";
            html+="<th>Giá BH</th>";
            html+="<th></th>";
            html+="</tr>";
            html+="</table>";
            html+="<div id='paging' style='width:100%;height:50px'/>";
            $("#tableAjax_KB_BangGiaGiuong").html(html);
      }).myfilter({
           txtfilter:"#gridTable [name=search]",
           paging:function(json,data){
                $("#tableAjax_KB_BangGiaGiuong").find("#paging").html(data);
           },
           result:function(json,item){
                var del = json.TABLE[0].DEL;
                var edit = json.TABLE[0].EDIT;
                var add = false;
                var html=[],j=0;
                for( var i = -1, y = item.length; ++i != y;){ 
                      html[j++]="<tr>";
                      html[j++]="<td>" + item[i].STT + "</td>";
                      html[j++]="<td> <a id=\"xoaRow\" style='color:" + (!del ? "#cfcfcf" : "") + "' onclick=\"xoa(this," + del + ");\">Xoá</a></td>";
                      html[j++]="<td style='text-align:left;'>" + item[i].TENKHOA + "</td>";
                      html[j++]="<td style='text-align:left;'>" + item[i].TENPHONG +"</td>";
                      html[j++]="<td><input mkv='true' id='GiuongId' type='hidden' value='" + item[i].GIUONGID + "'/><input mkv='true' id='mkv_GiuongId' type='text' value='"+ item[i].GIUONGCODE +"' onfocus='GiuongIdSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='GiaBH' type='text' value='" + formatCurrency1(item[i].GIABH) + "' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='IsBHYT' type='checkbox' " + (item[i].ISBHYT == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='GiaDV' type='text' value='" + formatCurrency1(item[i].GIADV) + "' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].BANGGIAGIUONGID + "'/></td>";
                      html[j++]="</tr>";
                }
                $("#gridTable").find("tr:gt(1)").empty().remove();
                $("#gridTable").append($(html.join('')));
           }
      });
 }
