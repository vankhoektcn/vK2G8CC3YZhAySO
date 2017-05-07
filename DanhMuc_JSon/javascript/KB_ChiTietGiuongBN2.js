
         $(document).ready(function() {
             $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"../ajax/KB_ChiTietGiuongBN_ajax2.aspx?do=luuTable",tablename:"#gridTable"});
             });
             $("#timKiem").click(function () {
                    Find(this);
             });
             $("#timKiem").click();
         });
         function xoa(control,bool){
            if(bool || bool == null)
              $(control).XoaRow({ajax:'../ajax/KB_ChiTietGiuongBN_ajax2.aspx?do=xoa'});
         }
          function Find(control) {
              $(control).TimKiem({
                     ajax:"../ajax/KB_ChiTietGiuongBN_ajax2.aspx?do=TimKiem&IDBENHBHDONGTIEN="+$.mkv.queryString("IDBENHBHDONGTIEN"),dataType:'json',showPopup:false
               },function () {
                     $("#tableAjax_KB_ChiTietGiuongBN").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
               },function (data) {
                    var html = "";
                    html+="<div id='paging' style='width:100%;height:50px'/>";
                    html+="<table class='jtable' id=\"gridTable\">";
                    html+="<tr>";
                    html+="<th>STT</th>";
                    html+="<th></th>";
                    html+="<th>"+data.TABLE[0].TENKHOA+"</th>";
                    html+="<th>"+data.TABLE[0].LOAIGIUONG+"</th>";
                    html+="<th>"+data.TABLE[0].TUNGAY+"</th>";
                    html+="<th>"+data.TABLE[0].DENNGAY+"</th>";
                    html+="<th>"+data.TABLE[0].SL+"</th>";
                    html+="<th>"+data.TABLE[0].DONGIADV+"</th>";
                    html+="<th>"+data.TABLE[0].THANHTIENDV+"</th>";
                    html+="<th>"+data.TABLE[0].ISBHYT+"</th>";
                    html+="<th>"+data.TABLE[0].DONGIABH+"</th>";
                    html+="<th>"+data.TABLE[0].THANHTIENBH+"</th>";
                    html+="<th>"+data.TABLE[0].BHTRA+"</th>";
                    html+="<th>"+data.TABLE[0].BNTRA+"</th>";
                    html+="<th>"+data.TABLE[0].PHUTHUBH+"</th>";
                    html+="<th></th>";
                    html+="</tr>";
                    html+="</table>";
                    html+="<div id='paging' style='width:100%;height:50px'/>";
                    $("#tableAjax_KB_ChiTietGiuongBN").html(html);
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
                              html[j++]="<td><input mkv='true' id='TENKHOA' type='text' value='" + item[i].TENKHOA + "'  style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='LOAIGIUONG' type='text' value='" + item[i].LOAIGIUONG + "' style='width:200px' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='TuNgay' type='text' value='" + $.dateVN(item[i].TUNGAY) + "' onblur='$.TestDate(this)' style='width:100px' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='DenNgay' type='text' value='" + $.dateVN(item[i].DENNGAY) + "' onblur='$.TestDate(this)' style='width:100px' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='SL' type='text' value='" + item[i].SL + "'  style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='DonGiaDV' type='text' value='" + item[i].DONGIADV + "'  style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='ThanhTienDV' type='text' value='" + item[i].THANHTIENDV + "'  style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='IsBHYT' type='checkbox' " + (item[i].ISBHYT == "True" ? "checked" : "") + " " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='DonGiaBH' type='text' value='" + item[i].DONGIABH + "'  style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='ThanhTienBH' type='text' value='" + item[i].THANHTIENBH + "'  style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='BHTra' type='text' value='" + item[i].BHTRA + "'  style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='BNTra' type='text' value='" + item[i].BNTRA + "'  style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='PHUTHUBH' type='text' value='" + item[i].PHUTHUBH + "'  style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id=\"TENKHOAchinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].IDCHITIETGIUONGBN + "'/></td>";
                              html[j++]="</tr>";
                        }
                        html[j++]="<tr><td></td><td colspan='3'>" + add + "</td></tr>";
                        $("#gridTable").find("tr:gt(0)").empty().remove();
                        $("#gridTable").append($(html.join('')));
                   }
              });
         }
