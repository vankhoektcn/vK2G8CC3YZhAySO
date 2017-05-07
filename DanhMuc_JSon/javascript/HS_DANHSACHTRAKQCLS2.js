
         $(document).ready(function() {
             $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"../ajax/HS_DANHSACHTRAKQCLS_ajax2.aspx?do=luuTable",tablename:"gridTable"});
             });
             $("#timKiem").click(function () {
                    Find(this);
             });
                var today = new Date();
                var dd = today.getDate();
                var mm = today.getMonth() + 1; //January is 0!
                var yyyy = today.getFullYear();
                if (dd < 10) { dd = '0' + dd }
                if (mm < 10) { mm = '0' + mm }
                $("#NGAYTHU").val(dd + "/" + mm + "/" + yyyy);
         });
         function xoa(control,bool){
            if(bool || bool == null)
              $(control).XoaRow({ajax:'../ajax/HS_DANHSACHTRAKQCLS_ajax2.aspx?do=xoa'});
         }
          function Find(control) {
              $(control).TimKiem({
                     ajax:"../ajax/HS_DANHSACHTRAKQCLS_ajax2.aspx?do=TimKiem",dataType:'json',showPopup:false
               },function () {
                     $("#tableAjax_HS_DANHSACHTRAKQCLS").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
               },function (data) {
                    var html = "";
                    html+="<table class='jtable' id=\"gridTable\">";
                    html+="<tr>";
                    html+="<th>STT</th>";
                    html+="<th>MÃ BN</th>";
                    html+="<th>TÊN BN</th>";
                    html+="<th>NGÀY SINH</th>";
                    html+="<th>GIỚI TÍNH</th>";
                    html+="<th>BÁC SĨ CĐ</th>";
                    html+="<th>PHÒNG KHÁM</th>";
                    html+="<th>NHÓM CLS</th>";
                    html+="<th>ĐÃ TRẢ?</th>";
                    html+="<th></th>";
                    html+="</tr>";
                    html+="</table>";
                    html+="<div id='paging' style='width:100%;height:50px'/>";
                    $("#tableAjax_HS_DANHSACHTRAKQCLS").html(html);
              }).myfilter({
                   txtfilter:"#gridTable [name=search]",
                   paging:function(json,data){
                        $("#tableAjax_HS_DANHSACHTRAKQCLS").find("#paging").html(data);
                   },
                   result:function(json,item){
                        var del = json.TABLE[0].DEL;
                        var edit = json.TABLE[0].EDIT;
                        var add = json.TABLE[0].ADD;
                        var html=[],j=0;
                        for( var i = -1, y = item.length; ++i != y;){ 
                              html[j++]="<tr>";
                              html[j++]="<td>" + item[i].STT + "</td>";
                              html[j++]="<td><input mkv='true' id='MABENHNHAN' type='text' value='" + item[i].MABENHNHAN + "' style='width:100px' " + (1==1?  "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id='TENBENHNHAN' type='text' value='" + item[i].TENBENHNHAN + "' style='width:200px' " + (1==1?  "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id='NGAYSINH' type='text' value='" + item[i].NGAYSINH + "' style='width:50px' " + (1==1?  "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id='TENGIOITINH' type='text' value='" + item[i].TENGIOITINH + "' style='width:50px' " + (1==1?  "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id='TENBACSI' type='text' value='" + item[i].TENBACSI + "' style='width:200px' " + (1==1?  "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id='PHONG' type='text' value='" + item[i].PHONG + "' style='width:100px' " + (1==1?  "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id='NHOMCLS' type='text' value='" + item[i].NHOMCLS + "' style='width:200px' " + (1==1?  "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id='ISDATRA' type='checkbox' style='width:50px'" + (item[i].ISDATRA == "True" ? "checked" : "") + " " + (1!=1?  "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].ID + "'/></td>";
                              html[j++]="</tr>";
                        }
                        html[j++]="<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
                        $("#gridTable").find("tr:gt(0)").empty().remove();
                        $("#gridTable").append($(html.join('')));
                   }
              });
         }
