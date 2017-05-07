         $(document).ready(function() {
               setControlFind($.mkv.queryString("idkhoachinh"));
               $("#KetThucCLS").click(function () {
                 if($("#idkhambenh").val()=="")
                  {
                    alert("Bạn chưa chọn 1 dòng mà");
                    return false;
                  }
                   $(this).Luu({
                      ajax:"../ajax/khambenh_ajax1.aspx?do=KetThucCLS"
                      },null,function () {
                         $("#timKiem").click();
                   });
                });
                $("#moi").click(function () {
                     $(this).Moi();  
                });
               
                $("#timKiem").click(function () {
                    Find(this);
                });
         });
          function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/khambenh_ajax1.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem,dataType:'json'});
              }      
          }
           function Find(control) {
               $(control).TimKiem({
                     ajax:"../ajax/khambenh_ajax1.aspx?do=TimKiem",dataType:'json',showPopup:false
               },function () {
                    $("#tableAjax_khambenh").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                    return true;
               },function (data) {
                      var html="";
                      html+="<div id='paging' style='width:100%;height:50px'/>";
                      html+="<table class='jtable' id=\"gridTable\">";
                      html+="<tr>";
                      html+="<th>STT</th>";
                      html+="<th> Ngày khám </th>";
                      html+="<th> Mã BN</th>";
                      html+="<th> Tên BN </th>";
                      html+="<th> Ngày sinh </th>";
                      html+="<th> Giới tính </th>";
                      html+="<th> Tên bác sĩ </th>";
                      html+="<th> Khoa </th>";
                      html+="<th> Phòng </th>";
                      html+="<th> Đã CLS? </th>";
                      html+="</tr>";
                      html+="</table>";
                      html+="<div id='paging' style='width:100%;height:50px'/>";
                      $("#tableAjax_khambenh").html(html);
               }).myfilter({
                     txtfilter:"#gridTable [name=search]",
                     paging:function(json,data){
                           $("#tableAjax_khambenh").find("#paging").html(data);
                     },
                     result:function(json,item){
                         var html=[],j=0;
                         for( var i = -1, y = item.length; ++i != y;){ 
                                 html[j++]="<tr style='cursor:pointer;' onclick=\"setControlFind('" + item[i].IDKHAMBENH + "')\">";
                                 html[j++]="<td>" + item[i].STT + "</td>";
                                 html[j++]="<td>" + $.dateVN(item[i].NGAYKHAM) + "</td>";
                                 html[j++]="<td>" + item[i].MABENHNHAN + "</td>";
                                 html[j++]="<td>" + item[i].TENBENHNHAN + "</td>";
                                 html[j++]="<td>" + item[i].NGAYSINH + "</td>";
                                 html[j++]="<td>" + item[i].TENGIOITINH + "</td>";
                                 html[j++]="<td>" + item[i].TENBACSI + "</td>";
                                 html[j++]="<td>" + item[i].KHOA + "</td>";
                                 html[j++]="<td>" + item[i].PHONG + "</td>";
                                 html[j++]="<td><input type='checkbox' disabled='true' " + (item[i].IsDaCLS == "True" ? "checked" : "") + "/></td>";
                                 html[j++]="</tr>";
                         }
                         $("#gridTable").find("tr:gt(0)").empty().remove();
                         $("#gridTable").append($(html.join('')));
                     }
               });
         }
