
var today=new Date();
var dd=today.getDate();
var MM=today.getMonth() + 1;
var yyyy=today.getFullYear();
if(dd<10) dd='0' + dd;
if(MM<10) MM='0' + MM;
$(document).ready(function() {
     $("#ngaythu").val(dd + "/" + MM + "/" + yyyy);
     $("#timKiem").click(function () {
            Find(this);
     });
     $("#timKiem").click();
});
function Find(control) {
  $(control).TimKiem({
         ajax:"../ajax/Z_DSPHIEUTHU_VIEW_ajax2.aspx?do=TimKiem",dataType:'json',showPopup:false
   },function () {
         $("#tableAjax_Z_DSPHIEUTHU_VIEW").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
         return true;
   },function (data) {
        var html = "";
        html+="<table class='jtable' id=\"gridTable\">";
        html+="<tr>";
        html+="<th>STT</th>";
        html+="<th>MÃ PHIẾU</th>";
        html+="<th>MÃ BỆNH NHÂN</th>";
        html+="<th>TÊN BỆNH NHÂN</th>";
        html+="<th>N.SINH</th>";
        html+="<th>NỘI DUNG THU</th>";
        html+="<th>TỔNG TIỀN</th>";
        html+="<th>NGƯỜI THU</th>";
        html+="<th>Khoa</th>";
        html+="<th></th>";
        html+="<th>L.do hủy</th>";
        html+="<th>N.hủy</th>";
        html+="<th></th>";
        html+="</tr>";
        html+="</table>";
        html+="<div id='paging' style='width:100%;height:50px'/>";
        $("#tableAjax_Z_DSPHIEUTHU_VIEW").html(html);
  }).myfilter({
       txtfilter:"#gridTable [name=search]",
       paging:function(json,data){
            $("#tableAjax_Z_DSPHIEUTHU_VIEW").find("#paging").html(data);
       },
       result:function(json,item){
            var del = json.TABLE[0].DEL;
            var edit = json.TABLE[0].EDIT;
            var add = json.TABLE[0].ADD;
            var html=[],j=0;
            for( var i = -1, y = item.length; ++i != y;){ 
                  html[j++]="<tr>";
                  html[j++]="<td>" + item[i].STT + "</td>";
                  html[j++]="<td style='width:10%'>" + item[i].MAPHIEU + "</td>";
                  html[j++]="<td style='width:10%'>" + item[i].MABENHNHAN + "</td>";
                  html[j++]="<td style='text-align:left;width:15%;'>" + item[i].TENBENHNHAN + "</td>";
                  html[j++]="<td>" + item[i].NGAYSINH + "</td>";
                  html[j++]="<td style='text-align:left;width:10%;'>" + item[i].NOIDUNGTHU + "</td>";
                  html[j++]="<td style='font-weight:bold; color:#f0244a; width:10%;'>" + formatCurrency1(item[i].TONGTIEN) + "</td>";
                  html[j++]="<td style='text-align:left;width:15%;'>" + item[i].TENNGUOITHU + "</td>";
                  html[j++]="<td style='width:10%;'>" + item[i].KHOA + "</td>";
                  html[j++]="<td style='width:12%; margin:0 auto; padding:0 auto;'><input type='button' value='In lại' id='btnRePrint' onclick=\"RePrint('"+ item[i].MAPHIEU +"');\" style='float:left; width:40px;color:#0a4bad' /><input type='button' value='"+ ((item[i].ISDAHUY=="True") ? "Đã hủy": "Hủy")+"' id='btnHuyPhieu' onclick=\"HuyPhieu(this,'"+ item[i].MAPHIEU +"',"+item[i].ISDAHUY.toLowerCase()+","+ i +");\" style='width:52px;color:" + ((item[i].ISDAHUY=="True") ? "#0a4bad": "#ff0000")+ "' /></td>";
                  html[j++]="<td style='width:10%;'>" + item[i].LYDOHUY + "</td>";
                  html[j++]="<td style='width:10%;'>" + item[i].TENNGUOIHUY + "</td>";
                  html[j++]="</tr>";
            }
            $("#gridTable").find("tr:gt(0)").empty().remove();
            $("#gridTable").append($(html.join('')));
       }
  });
}
function RePrint(MAPHIEU)
{
    window.open("../../VIENPHI_TH/frm_rpt_InPhieuThuTH.aspx?MaPhieu=" + MAPHIEU,"_blank");
}
function HuyPhieu(obj,MAPHIEU,isdahuy,row)
{
    if(!isdahuy){
        $("#divPopup").css("display","block");
        $("#divPopup #txtMaPhieu").val(MAPHIEU);
        $("#divPopup #txtMaPhieu").attr("disabled",true);
        $("#divPopup #txtRow").val(row+1);
    }
}

//-------------------------drag div ------------------------------------------------------
(function($) {
    $.fn.drags = function(opt) {
        opt = $.extend({handle:"",cursor:"move"}, opt);
        if(opt.handle === "") {
            var $el = this;
        } else {
            var $el = this.find(opt.handle);
        }
        return $el.css('cursor', opt.cursor).on("mousedown", function(e) {
            if(opt.handle === "") {
                var $drag = $(this).addClass('draggable');
            } else {
                var $drag = $(this).addClass('active-handle').parent().addClass('draggable');
            }
            var z_idx = $drag.css('z-index'),
                drg_h = $drag.outerHeight(),
                drg_w = $drag.outerWidth(),
                pos_y = $drag.offset().top + drg_h - e.pageY,
                pos_x = $drag.offset().left + drg_w - e.pageX;
            $drag.css('z-index', 1000).parents().on("mousemove", function(e) {
                $('.draggable').offset({
                    top:e.pageY + pos_y - drg_h,
                    left:e.pageX + pos_x - drg_w
                }).on("mouseup", function() {
                    $(this).removeClass('draggable').css('z-index', z_idx);
                });
            });
            //e.preventDefault(); // disable selection
        }).on("mouseup", function() {
            if(opt.handle === "") {
                $(this).removeClass('draggable');
            } else {
                $(this).removeClass('active-handle').parent().removeClass('draggable');
            }
        });
    }
})(jQuery);
//-------------------------end drag div ------------------------------------------------------
$(function(){
    $("#divPopup").css("display","none");
    $("#divPopup").drags();
    $("#divPopup .close").click(function(){
        $(this).parent().css("display","none");
    });
    $("#btnOK").click(function(){
           if($("#txtMaPhieu").val()!=null || $("#txtMaPhieu").val()!=""){
                $.ajax({
                    async:false,
                    url:"../ajax/Z_DSPHIEUTHU_VIEW_ajax2.aspx",
                    data:{
                        "do":"XacNhanHuy",
                        maphieu:$("#txtMaPhieu").val(),
                        lydo:$("#txtLyDo").val()
                    },
                    success:function(data){
                        if(data!=null && data!=""){
                            var i=$("#txtRow").val();
                            if(data.split("|")[0]=="0"){
                                 $.mkv.myerror(data.split("|")[1]);
                                  $("#divPopup #txtLyDo").val("");
                                 return false;       
                            }
                            else if(data.split("|")[0]=="1"){
                                $.mkv.myerror(data.split("|")[1]);
                                 $("#divPopup #txtLyDo").val("");
                                return false;
                            }  
                            else if(data.split("|")[0]=="-1"){
                                $.mkv.myalert(data.split("|")[1],2000,"success");
                                $("#gridTable").find("tr").eq(i).find("td").eq(9).find("#btnHuyPhieu").val("Đã hủy");
                                $("#gridTable").find("tr").eq(i).find("td").eq(9).find("#btnHuyPhieu").css("color","#0a4bad");
                                $("#gridTable").find("tr").eq(i).find("td").eq(10).html($("#txtLyDo").val());
                                $("#gridTable").find("tr").eq(i).find("td").eq(11).html(data.split("|")[2]);
                                $("#divPopup #txtMaphieu").val("");
                                $("#divPopup #txtLyDo").val("");
                                $("#divPopup").css("display","none");
                            }
                        }
                    }
            });
        }
    });
});