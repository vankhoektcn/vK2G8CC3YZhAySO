
         $(document).ready(function() {
           //_____________________________________________________________________________
            setControlFind2($.mkv.queryString("idbanggiadichvu"),$.mkv.queryString("tendichvu"));
            //_____________________________________________________________________________
             $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"../ajax/chitietdichvu_ajax2.aspx?do=luuTable&idbanggiadichvu="+$("#idbanggiadichvu").val()+"",tablename:"gridTable"});
             });
             $("#timKiem").click(function () {
                    Find(this);
             });
             
         });
         function xoa(control,bool){
            if(bool || bool == null)
              $(control).XoaRow({ajax:'../ajax/chitietdichvu_ajax2.aspx?do=xoa'});
         }
         
          function setControlFind2(idbanggiadichvu,tendichvu)
            {
                       if( idbanggiadichvu==null || idbanggiadichvu=="") return false;
                       $("#idbanggiadichvu").val(idbanggiadichvu);
                       $("#mkv_idbanggiadichvu").val(decodeURIComponent(tendichvu));
                        Find($("#timKiem"));
            }
         
          function Find(control) {
              $(control).TimKiem({
                     ajax:"../ajax/chitietdichvu_ajax2.aspx?do=TimKiem",dataType:'json',showPopup:false
               },function () {
                     $("#tableAjax_chitietdichvu").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
               },function (data) {
                    var html = "";
                    html+="<table class='jtable' id=\"gridTable\">";
                    html+="<tr>";
                    html+="<th>STT</th>";
                    html+="<th></th>";
                    html+="<th>Tên thông số</th>";
                    html+="<th> G.Trị Bình thường </th>";
                    html+="<th>ĐVT</th>";
                    html+="<th></th>";
                    html+="</tr>";
                    html+="</table>";
                    html+="<div id='paging' style='width:100%;height:50px'/>";
                    $("#tableAjax_chitietdichvu").html(html);
              }).myfilter({
                   txtfilter:"#gridTable [name=search]",
                   paging:function(json,data){
                        $("#tableAjax_chitietdichvu").find("#paging").html(data);
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
                              html[j++]="<td><input mkv='true' id='tenchitiet' type='text' value='" + item[i].TENCHITIET + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id='giatribinhthuong' type='text' value='" + item[i].GIATRIBINHTHUONG + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id='donvi' type='text' value='" + item[i].DONVI + "' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].IDCHITIETDICHVU + "'/></td>";
                              html[j++]="</tr>";
                        }
                        html[j++]="<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
                        $("#gridTable").find("tr:gt(1)").empty().remove();
                        $("#gridTable").append($(html.join('')));
                   }
              });
         }
         function idbanggiadichvuSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/chitietdichvu_ajax2.aspx?do=idbanggiadichvuSearch",{
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
     