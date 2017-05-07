$(document).ready(function(){
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1;
    var yyyy = today.getFullYear();
    if (dd < 10) { dd = '0' + dd }
    if (mm < 10) { mm = '0' + mm }
    $("#tungay").val(dd + "/" + mm + "/" + yyyy);
    $("#denngay").val(dd + "/" + mm + "/" + yyyy);
    $("#tungay").bind("focus",function(){
        $(this).datepick();
    });
     $("#denngay").bind("focus",function(){
        $(this).datepick();
    });
    $("#layds").click(function(){
        Find(this);
    });
    $("#layds").click();
});
function theodoicongno(idkhoachinh)
{
    if(idkhoachinh!=null && idkhoachinh !=""){
        window.open("frmBangTheoDoiBN.aspx#idkhoachinh=" + idkhoachinh,"_blank","location=0,menubar=0,statusbar=0,scrollbars=1");
    }
}
function Find(control) {
      $(control).TimKiem({
             ajax:"ajax/benhnhanbhdongtien.ashx?do=layds",dataType:'json',showPopup:false
       },function () {
             $("#tableAjax_Z_BENHNHANBHDT").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
             return true;
       },function (data) {
            var html = "";
            html+="<table class='jtable' id=\"gridTable\">";
            html+="<tr>";
            html+="<th>STT</th>";
            html+="<th>Mã BN</th>";
            html+="<th>Họ tên bệnh nhân</th>";
            html+="<th>Ngày sinh</th>";
            html+="<th>Giới tính</th>";
            html+="<th>Vào viện</th>";
            html+="<th>Khoa</th>";
            html+="<th>Tổng tiền</th>";
            html+="<th>Đã trả</th>";
            html+="<th>Còn lại</th>";
            html+="<th></th>";
            html+="</tr>";
            html+="</table>";
            html+="<div id='paging' style='width:100%;height:50px'/>";
            $("#tableAjax_Z_BENHNHANBHDT").html(html);
      }).myfilter({
           txtfilter:"#gridTable [name=search]",
           paging:function(json,data){
                $("#tableAjax_Z_BENHNHANBHDT").find("#paging").html(data);
           },
           result:function(json,item){
                var del = json.TABLE[0].DEL;
                var edit = json.TABLE[0].EDIT;
                var add = json.TABLE[0].ADD;
                var html=[],j=0;
                for( var i = -1, y = item.length; ++i != y;){ 
                      html[j++]="<tr>";
                      html[j++]="<td>" + item[i].STT + "</td>";
                      html[j++]="<td>" + item[i].MABENHNHAN + "</td>";
                      html[j++]="<td>" + item[i].HOTENBN + "</td>";
                      html[j++]="<td>" + item[i].NGAYSINH + "</td>";
                      html[j++]="<td>" + item[i].GIOITINH + "</td>";
                      html[j++]="<td>" + item[i].NGAYTINHBH + "</td>";
                      html[j++]="<td>" + item[i].KHOA + "</td>";
                      html[j++]="<td>" + formatCurrency1(item[i].TONGTIENBNPT) + "</td>";
                      html[j++]="<td>" + formatCurrency1(item[i].TONGTIENBNDATRA) + "</td>";
                      html[j++]="<td>" + formatCurrency1(item[i].TONGTIENBNPTCONLAI) + "</td>";
                      html[j++]="<td><a href='javascript:;' onclick=\"theodoicongno(" + item[i].ID + ");\">Xem chi tiết</a></td>";
                      html[j++]="</tr>";
                }
                $("#gridTable").find("tr:gt(0)").empty().remove();
                $("#gridTable").append($(html.join('')));
           }
      });
 }
