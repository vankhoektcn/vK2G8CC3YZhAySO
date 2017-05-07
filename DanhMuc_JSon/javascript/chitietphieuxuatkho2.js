
         $(document).ready(function() {
             $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"../ajax/chitietphieuxuatkho_ajax2.aspx?do=luuTable",tablename:"#gridTable"});
             });
             $("#timKiem").click(function () {
                    Find(this);
             });
             $("#timKiem").click();
         });
         function xoa(control,bool){
            if(bool || bool == null)
              $(control).XoaRow({ajax:'../ajax/chitietphieuxuatkho_ajax2.aspx?do=xoa'});
         }
          function Find(control) {
              $(control).TimKiem({
                     ajax:"../ajax/chitietphieuxuatkho_ajax2.aspx?do=TimKiem&IDBENHBHDONGTIEN="+$.mkv.queryString("IDBENHBHDONGTIEN"),dataType:'json',showPopup:false
               },function () {
                     $("#tableAjax_chitietphieuxuatkho").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
               },function (data) {
                    var html = "";
                    html+="<div id='paging' style='width:100%;height:50px'/>";
                    html+="<table class='jtable' id=\"gridTable\">";
                    html+="<tr>";
                    html+="<th>STT</th>";
                    html+="<th></th>";
                    html+="<th>"+data.TABLE[0].TENKHOA+"</th>";
                    html+="<th>"+data.TABLE[0].KHOXUAT+"</th>";
                    html+="<th>"+data.TABLE[0].IDTHUOC+"</th>";
                    html+="<th>"+data.TABLE[0].DVT+"</th>";
                    html+="<th>"+data.TABLE[0].SODK_X+"</th>";
                    html+="<th>"+data.TABLE[0].SOLUONG+"</th>";
                    html+="<th>"+data.TABLE[0].DONGIADV+"</th>";
                    html+="<th>"+data.TABLE[0].THANHTIENDV+"</th>";
                    html+="<th>"+data.TABLE[0].ISBHYT+"</th>";
                    html+="<th>"+data.TABLE[0].DONGIABH+"</th>";
                    html+="<th>"+data.TABLE[0].THANHTIENBH+"</th>";
                    html+="<th>"+data.TABLE[0].BHTRA+"</th>";
                    html+="<th>"+data.TABLE[0].BNTRA+"</th>";
                    html+="<th></th>";
                    html+="</tr>";
                    
                    html+="</table>";
                    html+="<div id='paging' style='width:100%;height:50px'/>";
                    $("#tableAjax_chitietphieuxuatkho").html(html);
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
                              html[j++]="<td><input mkv='true' id='TENKHOA' type='text' value='" + item[i].TENKHOA + "' style='width:90px' " + edit + "/></td>";
                              html[j++]="<td><input mkv='false' id='KHOXUAT' type='text' value='" + item[i].KHOXUAT + "' style='width:90px' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='idthuoc' type='hidden' value='" + item[i].IDTHUOC + "'/><input mkv='true' id='mkv_idthuoc' type='text' value='"+ item[i].TENTHUOC +"' onfocus='idthuocSearch(this);' class=\"down_select\" style='width:150px' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='DVT' type='text' value='" + item[i].TENDVT + "' style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='SODK_X' type='text' value='" + item[i].SODK_X + "' style='width:100px' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='SOLUONG' type='text' value='" + item[i].SOLUONGVIEW + "' onblur='TestSo(this,false,false);' style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='DonGiaDV' type='text' value='" + item[i].DONGIADV + "' onblur='TestSo(this,false,false);' style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='ThanhTienDV' type='text' value='" + item[i].THANHTIENDV + "' onblur='TestSo(this,false,false);' style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='IsBHYT' type='checkbox' " + (item[i].ISBHYT == "True" ? "checked" : "") + " " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='DonGiaBH' type='text' value='" + item[i].DONGIABH + "' onblur='TestSo(this,false,false);' style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='ThanhTienBH' type='text' value='" + item[i].THANHTIENBH + "' onblur='TestSo(this,false,false);' style='width:100%' " + edit + "/></td>";  
                              html[j++]="<td><input mkv='true' id='BHTra' type='text' value='" + item[i].BHTRA + "' onblur='TestSo(this,false,false);' style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id='BNTra' type='text' value='" + item[i].BNTRA + "' onblur='TestSo(this,false,false);' style='width:100%' " + edit + "/></td>";
                              html[j++]="<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].IDCHITIETPHIEUXUAT + "'/></td>";
                              html[j++]="</tr>";
                        }
                        html[j++]="<tr><td></td><td colspan='3'>" + add + "</td></tr>";
                        $("#gridTable").find("tr:gt(1)").empty().remove();
                        $("#gridTable").append($(html.join('')));
                   }
              });
         }
         function idphieuxuatSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/chitietphieuxuatkho_ajax2.aspx?do=idphieuxuatSearch",{
             minChars:0,
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
         function idthuocSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/chitietphieuxuatkho_ajax2.aspx?do=idthuocSearch",{
             minChars:0,
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
