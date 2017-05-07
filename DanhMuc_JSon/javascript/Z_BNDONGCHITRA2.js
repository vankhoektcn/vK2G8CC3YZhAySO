 var today=new Date();
 var yyyy=today.getFullYear();
 var MM=today.getMonth()+1;
 var dd=today.getDate();
 if(MM<0)MM='0' + MM;
 if(dd<0) dd='0' + dd;
$(document).ready(function() {
     $("#timKiem").click(function () {
            Find(this);
     });
   $("#tungay").val(dd + "/" + MM + "/" + yyyy);
   $("#denngay").val(dd + "/" + MM + "/" + yyyy);
   $("#timKiem").click();
   
});
function Find(control) {
    var IsBNBH = $.mkv.queryString("IsBNBH");
    var IsBNDV = $.mkv.queryString("IsBNDV");
  $(control).TimKiem({
         ajax:"../ajax/Z_BNDONGCHITRA_ajax2.aspx?do=TimKiem&IsBNBH=" + IsBNBH + "&IsBNDV=" + IsBNDV,dataType:'json',showPopup:false
   },function () {
         $("#tableAjax_Z_BNDONGCHITRA").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
         return true;
   },function (data) {
        var html = "";
        html+="<table class='jtable' id=\"gridTable\">";
        html+="<tr>";
        html+="<th>STT</th>";
        html+="<th>NGÀY VÀO VIỆN</th>";
        html+="<th>MÃ BỆNH NHÂN</th>";
        html+="<th>TÊN BỆNH NHÂN</th>";
        html+="<th>NGÀY SINH</th>";
        html+="<th>GIỚI TÍNH</th>";
        if(IsBNBH=="1")
        {
            html+="<th>SỐ BHYT</th>";
            html+="<th>?ĐÚNG TUYẾN</th>";
            html+="<th>TỔNG TIỀN</th>";
            html+="<th>BH.TRẢ</th>";
        }
        html+="<th>PHẢI TRẢ</th>";
        html+="<th>ĐÃ TRẢ</th>";
        html+="<th>C.LẠI</th>";
        html+="<th></th>";
        if(IsBNBH=="1")
        {
            html+="<th></th>";
        }
        html+="</tr>";
        html+="</table>";
        html+="<div id='paging' style='width:100%;height:50px'/>";
        $("#tableAjax_Z_BNDONGCHITRA").html(html);
  }).myfilter({
       txtfilter:"#gridTable [name=search]",
       paging:function(json,data){
            $("#tableAjax_Z_BNDONGCHITRA").find("#paging").html(data);
       },
       result:function(json,item){
            var html=[],j=0;
            for( var i = -1, y = item.length; ++i != y;){ 
                  html[j++]="<tr>";
                  html[j++]="<td>" + item[i].STT + "</td>";
                  html[j++]="<td>" + item[i].NGAYTINHBH + "</td>";
                  html[j++]="<td>" + item[i].MABENHNHAN + "</td>";
                  html[j++]="<td style='text-align:left;'>" + item[i].TENBENHNHAN + "</td>";
                  html[j++]="<td>" + item[i].NGAYSINH + "</td>";
                  html[j++]="<td>" + item[i].GIOITINH + "</td>";
                  if(IsBNBH=="1")
                  {
                      html[j++]="<td>" + item[i].SOBHYT + "</td>";
                      html[j++]="<td>" + item[i].DUNGTUYEN + "</td>";
                      html[j++]="<td>" + formatCurrency1(item[i].TONGSOTIEN) + "</td>";
                      html[j++]="<td>" + formatCurrency1(item[i].BHTRA) + "</td>";
                  }
                  html[j++]="<td>" + formatCurrency1(item[i].BNPHAITRA) + "</td>";
                  html[j++]="<td>" + formatCurrency1(item[i].BNDATRACHENHLECHBHYT) + "</td>";
                  html[j++]="<td>" + formatCurrency1(item[i].BNPHAITRACHENHLECHBHYT) + "</td>";
                  html[j++]="<td><a href='javascript:;' style='font-weight:bold;"+ (item[i].ISNOITRU=="False" ? "color:#ff0000":"")+"' onclick=\"InBV('" + item[i].ISNOITRU +"'," + item[i].ID + "," + item[i].IDCHITIETDANGKYKHAM +")\";'>" + (item[i].ISNOITRU=="False" ? "BV01":"BV02") + "</a></td>";
                  if(IsBNBH=="1")
                  {
                      html[j++]="<td><a href='javascript:;' style='font-weight:bold;color:#18538c;' onclick=\"InDongChiTra('"+ item[i].ID +"')\";'>Đ.Chi trả</a></td>";
                  }
                  html[j++]="</tr>";
            }
            $("#gridTable").find("tr:gt(0)").empty().remove();
            $("#gridTable").append($(html.join('')));
       }
  });
}
function InBV(ISNOITRU,idphieutt,IDCHITIETDANGKYKHAM)
{
    if(ISNOITRU=="False"){
        window.open("../../VienPhi_BH/frm_rpt_chiphikhambenh.aspx?idphieutt=" + idphieutt ,"_blank",'location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
    }
    else{
        window.open("../../noitru/frm_Rpt_BieuMau02.aspx?idchitietdangkykham=" + IDCHITIETDANGKYKHAM ,"_blank",'location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
    }
}
function InDongChiTra(idphieutt)
{
    window.open("../../VienPhi_BH/frm_rpt_ChiPhiDongChiTra_new.aspx?idphieutt=" + idphieutt,"_blank",'location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
}