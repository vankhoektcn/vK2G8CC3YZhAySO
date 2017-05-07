
         $(document).ready(function() {
             $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"../ajax/khambenhcanlamsan_ajax2.aspx?do=luuTable",tablename:"#gridTable"});
             });
             $("#timKiem").click(function () {
                    Find(this);
             });
             $("#timKiem").click();
         });
         function xoa(control,bool){
            if(bool || bool == null)
              $(control).XoaRow({ajax:'../ajax/khambenhcanlamsan_ajax2.aspx?do=xoa'});
         }
          function Find(control) {
              $(control).TimKiem({
                     ajax:"../ajax/khambenhcanlamsan_ajax2.aspx?do=TimKiem&IDBENHBHDONGTIEN="+$.mkv.queryString("IDBENHBHDONGTIEN"),dataType:'json',showPopup:false
               },function () {
                     $("#tableAjax_khambenhcanlamsan").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
               },function (data) {
                    var html = "";
                    html+="<div id='paging' style='width:100%;height:50px'/>";
                    html+="<table class='jtable' id=\"gridTable\">";
                    html+="<tr>";
                    html+="<th>STT</th>";
                    html+="<th></th>";
                    html+="<th>"+data.TABLE[0].TENKHOA+"</th>";
                    html+="<th>"+data.TABLE[0].TENDICHVU+"</th>";
                    html+="<th>"+"Ngày Cđ"+"</th>";
                    html+="<th>"+data.TABLE[0].SOLUONG+"</th>";
                    html+="<th>"+data.TABLE[0].DONGIADV+"</th>";
                    html+="<th>"+data.TABLE[0].THANHTIENDV+"</th>";
                    html+="<th>"+"BHYT?"+"</th>";
                    html+="<th>"+data.TABLE[0].DONGIABH+"</th>";
                    html+="<th>"+data.TABLE[0].THANHTIENBH+"</th>";
                    html+="<th>"+data.TABLE[0].BHTRA+"</th>";
                    html+="<th>"+data.TABLE[0].BNTRA+"</th>";
                    html+="<th></th>";
                    html+="</tr>";
                    html+="</table>";
                    html+="<div id='paging' style='width:100%;height:50px'/>";
                    $("#tableAjax_khambenhcanlamsan").html(html);
              }).myfilter({
                   txtfilter:"#gridTable [name=search]",
                   paging:function(json,data){
                        
                   },
                   result:function(json,item){
                        var del = (!eval(json.TABLE[0].DEL) ? "#cfcfcf" : "");
                        var edit = (!eval(json.TABLE[0].EDIT) ? "disabled" : "");
                        var add = (eval(json.TABLE[0].ADD) ? "" : "Bạn không có quyền thêm mới");
                        var html=[],j=0;
                        for( var i = -1, y = item.length; ++i != y;){ 
                              html[j++]="<tr>";
                              html[j++]="<td>" + item[i].STT + "</td>";
                              html[j++]="<td> <a id=\"xoaRow\" style='color:" + del + "' onclick=\"xoa(this," + json.TABLE[0].DEL + ");\">Xoá</a></td>";
                              html[j++]="<td><input mkv='true' id='TENKHOA' type='text' value='" + item[i].TENKHOA + "'  style='width:100px' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='TENDICHVU' type='text' value='" + item[i].TENDICHVU + "'  style='width:280px' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='ngaythu' type='text' value='" + $.dateVN(item[i].NGAYTHU) + "' onblur='$.TestDate(this)' style='width:100px' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='soluong' type='text' value='" + item[i].SOLUONG + "' onblur='TestSo(this,false,false);' style='width:30px' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='DonGiaDV' type='text' value='" + item[i].DONGIADV + "' onblur='TestSo(this,false,false);' style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='ThanhTienDV' type='text' value='" + item[i].THANHTIENDV + "' onblur='TestSo(this,false,false);' style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='IsBHYT' type='checkbox' " + (item[i].ISBHYT == "True" ? "checked" : "") + " " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='DonGiaBH' type='text' value='" + item[i].DONGIABH + "' onblur='TestSo(this,false,false);' style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='ThanhTienBH' type='text' value='" + item[i].THANHTIENBH + "' onblur='TestSo(this,false,false);' style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='BHTra' type='text' value='" + item[i].BHTRA + "' onblur='TestSo(this,false,false);' style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='BNTra' type='text' value='" + item[i].BNTRA + "' onblur='TestSo(this,false,false);' style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].IDKHAMBENHCANLAMSAN + "'/></td>";
                              html[j++]="</tr>";
                        }
                        html[j++]="<tr><td></td><td colspan='3'>" + add + "</td></tr>";
                        $("#gridTable").find("tr:gt(0)").empty().remove();
                        $("#gridTable").append($(html.join('')));
                   }
              });
         }
