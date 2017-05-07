 var loaithuocid=$.mkv.queryString("loaithuocid");
 $(document).ready(function() {
     $('input[id^=luuTable]').click(function () {
        $(this).LuuTable({
                ajax:"../ajax/thuoc_ajax2.aspx?do=luuTable",
                tablename:"gridTable"
        });
     });
     $("#timKiem").click(function () {
            Find(this);
     });
     $("#timKiem").click();
    var tieude="";
    if(loaithuocid=="1")
       tieude="Phân bổ thuốc bảo hiểm";
    else if(loaithuocid=="2")
       tieude="Phân bổ Hóa chất bảo hiểm";
    else if(loaithuocid=="3")
       tieude="Phân bổ Dụng cụ bảo hiểm";
    else if(loaithuocid=="4")
       tieude="Phân bổ V.T.Y.T bảo hiểm";
    $(".header-div").html(tieude);
 });    
  function Find(control) {
      var header="";
      if(loaithuocid=="1")
            header="Tên thuốc";
      else if(loaithuocid=="2")
            header="Hóa chất";
      else if(loaithuocid=="3")
            header="Dụng cụ";
      else if(loaithuocid=="4")
            header="Vật tư y tế";
      $(control).TimKiem({
             ajax:"../ajax/thuoc_ajax2.aspx?do=TimKiem&loaithuocid=" +loaithuocid ,dataType:'json',showPopup:false
       },function () {
             $("#tableAjax_thuoc").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
             return true;
       },function (data) {
            var html = "";
            html+="<table class='jtable' id=\"gridTable\">";
            html+="<tr>";
            html+="<th style='width:70px;'>STT</th>";
            html+="<th style='text-align:left; padding-left:20px;'>"+ header +"</th>";
            if(loaithuocid=="1")html+="<th>TT.H.Chất</th>";
            if(loaithuocid=="1")html+="<th>Công thức</th>";
            html+="<th style='width:70px;'>ĐVT</th>";
            html+="<th style='width:70px; text-align:center;'>B.Hiểm<input type='checkbox' id='chkAllBaoHiem' onclick=\"checkAllBaoHiem(this);\" /></th>";
            html+="<th style='width:70px; text-align:center;'>Ngoại.trú<input type='checkbox' id='chkAllNo' onclick=\"checkAllNo(this);\"'/></th>";
            html+="</tr>";
            html+="</table>";
            html+="<div id='paging' style='width:100%;height:50px'/>";
            $("#tableAjax_thuoc").html(html);
      }).myfilter({
           txtfilter:"#gridTable [name=search]",
           paging:function(json,data){
                $("#tableAjax_thuoc").find("#paging").html(data);
           },
           result:function(json,item){
                var del = json.TABLE[0].DEL;
                var edit = json.TABLE[0].EDIT;
                var add = json.TABLE[0].ADD;
                var html=[],j=0;
                for( var i = -1, y = item.length; ++i != y;){ 
                      html[j++]="<tr>";
                      html[j++]="<td>" + item[i].STT + "</td>";
                      html[j++]="<td style='width:20%;text-align:left;'>" + item[i].TENTHUOC + "</td>";
                      if(loaithuocid=="1")html[j++]="<td style='width:10%'><input mkv='true' id='TTHoatChat' type='text' value='" + item[i].TTHOATCHAT + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      if(loaithuocid=="1")html[j++]="<td style='width:20%;text-align:left;'><input mkv='true' id='CONGTHUC' type='text' value='" + item[i].CONGTHUC + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td>" + item[i].TENDVT + "</td>";
                      html[j++]="<td><input mkv='true' id='sudungchobh' type='checkbox' " + (item[i].SUDUNGCHOBH == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                      html[j++]="<td><input mkv='true' id='IsNgoaiTru' type='checkbox' " + (item[i].ISNGOAITRU == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].IDTHUOC + "'/></td>";
                      html[j++]="</tr>";
                }
  	html[j++]="<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
                $("#gridTable").find("tr:gt(0)").empty().remove();
                $("#gridTable").append($(html.join('')));
           }
      });
 }

 function CateIDSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax2.aspx?do=CateIDSearch&loaithuocid="+ loaithuocid,{
     minChars:0,
     scroll:true,
     width:450,
     header:false,
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
         $("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             $("#mkv_idnhomthuoc").focus();
         },100);
     });
 }
 function IDNHOMTHUOCSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax2.aspx?do=IDNHOMTHUOCSearch&cateid="+$("#CateID").val(),{
     minChars:0,
     width:350,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
            $("#"+obj.id.replace("mkv_","")).val(data[1]);
            if($(obj).parents("#gridTable").attr("id") != null)
                $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 function TenThuocSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax2.aspx?do=TenThuocSearch&idnhomthuoc="+ $("#idnhomthuoc").val() + "&LOAITHUOCID=" + loaithuocid + "&CATEID=" + $("#CateID").val(),{
     minChars:0,
     scroll:true,
     header:false,
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }

 function checkAllBaoHiem(obj) {
    if(loaithuocid=="1"){
        for (var i = 0; i < $(obj).parents("table").find("tr").length; i++) {
            if ($(obj).is(":checked")) {
                $(obj).parents("table").find("tr").eq(i).find("td").eq(6).find("input[type=checkbox]").attr("checked", true);
            } else {
                $(obj).parents("table").find("tr").eq(i).find("td").eq(6).find("input[type=checkbox]").attr("checked", false);
            }
        }
    }else
    {
       for (var i = 0; i < $(obj).parents("table").find("tr").length; i++) {
            if ($(obj).is(":checked")) {
                $(obj).parents("table").find("tr").eq(i).find("td").eq(3).find("input[type=checkbox]").attr("checked", true);
            } else {
                $(obj).parents("table").find("tr").eq(i).find("td").eq(3).find("input[type=checkbox]").attr("checked", false);
            }
        }   
    }
}
function checkAllNo(obj) {
   if(loaithuocid=="1"){
        for (var i = 0; i < $(obj).parents("table").find("tr").length; i++) {
            if ($(obj).is(":checked")) {
                $(obj).parents("table").find("tr").eq(i).find("td").eq(7).find("input[type=checkbox]").attr("checked", true);
            } else {
                $(obj).parents("table").find("tr").eq(i).find("td").eq(7).find("input[type=checkbox]").attr("checked", false);
            }
        }
    }
    else
    {
          for (var i = 0; i < $(obj).parents("table").find("tr").length; i++) {
            if ($(obj).is(":checked")) {
                $(obj).parents("table").find("tr").eq(i).find("td").eq(4).find("input[type=checkbox]").attr("checked", true);
            } else {
                $(obj).parents("table").find("tr").eq(i).find("td").eq(4).find("input[type=checkbox]").attr("checked", false);
            }
        }
    }
}