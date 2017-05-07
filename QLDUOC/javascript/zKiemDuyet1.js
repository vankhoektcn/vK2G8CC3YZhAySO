var now = new Date();
         $(document).ready(function() {
               setControlFind($.mkv.queryString("idkhoachinh"));
               $("#luu").click(function () {
                   $(this).Luu({
                      ajax:"../ajax/zKiemDuyet_ajax1.aspx?do=Luu"
                      },null,function () {
                         $("#timKiem").click();
                   });
                });
                $("#moi").click(function () {
                     $(this).Moi();  
                });
                $("#xoa").click(function () {
                    $(this).Xoa({
                        ajax:'../ajax/zKiemDuyet_ajax1.aspx?do=xoa'
                    },null,function () {
                         $("#timKiem").click();
                    });
                });
                $("#timKiem").click(function () {
                    Find(this);
                });
                $("#KHOYC").DropList({
                    ajax: "../ajax/zKiemDuyet_ajax1.aspx?do=KHOYCSearch"
                    ,defaultVal: "Chọn kho"
                });
                SetDefault();
         });
         function SetDefault()
         {
            $("#TUNGAY").val(now.format("d/m/Y"));
            $("#DENNGAY").val(now.format("d/m/Y"));
            $("#TUGIO").val("00:00:00");
            $("#DENGIO").val("23:59:59");
         }
          function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 //$.BindFind({ajax:"../ajax/zKiemDuyet_ajax1.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem,dataType:'json'});
              }      
          }
           function Find(control) {
               $(control).TimKiem({
                     ajax:"../ajax/zKiemDuyet_ajax1.aspx?do=TimKiem",dataType:'json',showPopup:false
               },function () {
                    $("#tableAjax_zKiemDuyet").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                    return true;
               },function (data) {
                      var html="";
                      //html+="<div id='paging' style='width:100%;height:50px'/>";
                      html+="<table class='jtable' id=\"gridTable\">";
                      html+="<tr>";
                      html+="<th>STT</th>";
                      //html+="<th>"+ data.TABLE[0].NGAYYC +"</th>";
                      html+="<th>Ngày duyệt</th>";
                      html+="<th>"+ data.TABLE[0].TENKHO +"</th>";
                      html+="<th>"+ data.TABLE[0].TENTHUOC +"</th>";
                      //html+="<th>"+ data.TABLE[0].IDTHUOC +"</th>";
                      html+="<th>"+ data.TABLE[0].SOPHIEUYC +"</th>";
                      html+="<th>"+ data.TABLE[0].TENDVT +"</th>";
                      html+="<th>"+ data.TABLE[0].SOLUONGYC +"</th>";
                      html+="<th>"+ data.TABLE[0].SOLUONGDUYET +"</th>";
                      html+="<th>Thực xuất</th>";
                      html+="<th>Đã phát?</th>";
                      html+="</tr>";
                      html+="</table>";
                      html+="<div id='paging' style='width:100%;height:50px'/>";
                      $("#tableAjax_zKiemDuyet").html(html);
               }).myfilter({
                     txtfilter:"#gridTable [name=search]",
                     paging:function(json,data){
                           $("#tableAjax_zKiemDuyet").find("#paging").html(data);
                     },
                     result:function(json,item){
                         var html=[],j=0;
                         for( var i = -1, y = item.length; ++i != y;){ 
                                 html[j++]="<tr style='cursor:pointer;' onclick=\"setControlFind('" + item[i].IDKIEMDUYET + "')\">";
                                 html[j++]="<td>" + item[i].STT + "</td>";
                                 //html[j++]="<td>" + $.dateVN(item[i].NGAYYC) + "</td>";
                                 html[j++]="<td>" + item[i].NGAYDUYET103 + "</td>";
                                 html[j++]="<td style='text-align: left;'>" + item[i].TENKHO + "</td>";
                                 html[j++]="<td style='text-align: left;'>" + item[i].TENTHUOC + "</td>";
                                 //html[j++]="<td>" + item[i].TENTHUOC + "</td>";
                                 html[j++]="<td style='text-align: left;'>" + item[i].SOPHIEUYC + "</td>";
                                 html[j++]="<td style='text-align: left;'>" + item[i].TENDVT + "</td>";
                                 html[j++]="<td>" + item[i].SOLUONGYC + "</td>";
                                 html[j++]="<td>" + item[i].SOLUONGDUYET + "</td>";
                                 html[j++]="<td>" + item[i].THUCXUAT + "</td>";
                                 html[j++]="<td><input type='checkbox' disabled='true' " + (item[i].ISDUYETPHAT == "True" ? "checked" : "") + "/></td>";
                                 html[j++]="</tr>";
                         }
                         $("#gridTable").find("tr:gt(0)").empty().remove();
                         $("#gridTable").append($(html.join('')));
                     }
               });
         }
        function KHOYCSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/zKiemDuyet_ajax1.aspx?do=KHOYCSearch",{
             minChars:0,
             scroll:true,
             formatItem:function (data) {
                 return data[0];
             }}).result(function(event,data){
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
        function IDTHUOCSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/zKiemDuyet_ajax1.aspx?do=IDTHUOCSearch",{
             minChars:0,
             scroll:true,
             formatItem:function (data) {
                 return data[0];
             }}).result(function(event,data){
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
