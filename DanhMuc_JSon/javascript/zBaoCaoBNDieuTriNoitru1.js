         $(document).ready(function() {
                $("#moi").click(function () {
                     $(this).Moi();  
                     setDefault();
                });
                $("#timKiem").click(function () {
                    Find(this);
                });
                $("#Excel").click(function () {
                    ExportExcell(this);
                });
                setDefault();
         });
          function setControlFind(idkhoatimkiem) {
//              if(idkhoatimkiem != "" && idkhoatimkiem != null){
//                 $.BindFind({ajax:"../ajax/zBaoCaoBNDieuTriNoitru_ajax1.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem,dataType:'json'});
//              }      
          }
           function Find(control) {
               $(control).TimKiem({
                     ajax:"../ajax/zBaoCaoBNDieuTriNoitru_ajax1.aspx?do=TimKiem&idkhoa="+$.mkv.queryString("IdKhoa")+"",dataType:'json',showPopup:false
               },function () {
                    $("#tableAjax_zBaoCaoBNDieuTriNoitru").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                    return true;
               },function (data) {
                      var html="";
                      html+="<table class='jtable' id=\"gridTable\">";
                      html+="<tr>";
                      html+="<th>STT</th>";
                      html+="<th>"+ data.TABLE[0].MABENHNHAN +"</th>";
                      html+="<th>"+ data.TABLE[0].TENBENHNHAN +"</th>";
                      html+="<th>"+ data.TABLE[0].CHANDOAN +"</th>";
                      html+="<th>"+ data.TABLE[0].BHYT +"</th>";
                      html+="<th>"+ data.TABLE[0].DICHVU +"</th>";
                      html+="</tr>";
                      html+="</table>";
                      html+="<div id='paging' style='width:100%;height:50px'/>";
                      $("#tableAjax_zBaoCaoBNDieuTriNoitru").html(html);
               }).myfilter({
                     txtfilter:"#gridTable [name=search]",
                     paging:function(json,data){
                           $("#tableAjax_zBaoCaoBNDieuTriNoitru").find("#paging").html(data);
                     },
                     result:function(json,item){
                         var html=[],j=0;
                         for( var i = -1, y = item.length; ++i != y;){ 
                                 html[j++]="<tr style='cursor:pointer;' onclick=\"setControlFind('" + item[i].IDCHITIETDANGKYKHAM + "')\">";
                                 html[j++]="<td>" + item[i].STT + "</td>";
                                 html[j++]="<td style='text-align: left;'>" + item[i].MABENHNHAN + "</td>";
                                 html[j++]="<td style='text-align: left;'>" + item[i].TENBENHNHAN + "</td>";
                                 html[j++]="<td style='text-align: left;'>" + item[i].CHANDOAN + "</td>";
                                 html[j++]="<td><input type='checkbox' " + (item[i].BHYT == "a" ? "checked" : "") + "/></td>";
                                 html[j++]="<td><input type='checkbox' " + (item[i].DICHVU == "a" ? "checked" : "") + "/></td>";
                                 html[j++]="</tr>";
                         }
                         $("#gridTable").find("tr:gt(0)").empty().remove();
                         $("#gridTable").append($(html.join('')));
                     }
               });
         }
      
function setDefault()
{
  $.BindFind({
        ajax: "../ajax/zBaoCaoBNDieuTriNoitru_ajax1.aspx?do=setDefault"
                , useEnabled: false
    }, null, function () {
        }
    ); 
}
function ExportExcell(control)
{
    $(control).TimKiem({
                     ajax:"../ajax/zBaoCaoBNDieuTriNoitru_ajax1.aspx?do=XuatExcel&idkhoa="+$.mkv.queryString("IdKhoa")+"",dataType:'text',showPopup:false
               },function () {
                    //$("#tableAjax_zBaoCaoBNDieuTriNoitru").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                    $.mkv.loading();
                    return true;
               },function (data) {
                      $("#loadingAjax").remove();
                            window.open(data,"_blank");
               });
}