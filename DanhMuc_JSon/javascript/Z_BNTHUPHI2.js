 $(document).ready(function() {
     var today=new Date();
     var yyyy=today.getFullYear();
     var MM=today.getMonth()+1;
     var dd=today.getDate();
     if(MM<0)MM='0' + MM;
     if(dd<0) dd='0' + dd;
     $("#NgayThuPhi").val(dd + "/" + MM + "/" + yyyy);
     $("#timKiem").click(function () {
            Find(this);
     });
     $("#MABENHNHAN").focus();
     $("#NgayThuPhi").bind("focus",function(){
        $(this).datepick();
     });
     $("#timKiem").click();
     var headertext="";
     if($.mkv.queryString("HaveVPNT")=="1")
     {
        headertext="Thanh toán ra viện";  
     }
     else
     if($.mkv.queryString("IsPhiKham_CLS_TuDK")=="1")
     {
        headertext="Thu phí khám & cận lâm sàng tự ĐK";  
     }
     else
     if($.mkv.queryString("IsPhiKham")=="1")
     {
        headertext="Thu phí khám";  
     }
     else
     if($.mkv.queryString("IsCLS")=="1")
     {
        headertext="Thu phí cận lâm sàng (BSCĐ)";  
     }
     else
     if($.mkv.queryString("IsTamUng")=="1")
     {
        headertext="Thu phí tạm ứng";  
     }
     else
            headertext="Viện phí chung";  
     
     if($.mkv.queryString("IsBNBH")=="1")
     {
        headertext +="- BNBH";  
     } 
     if($.mkv.queryString("IsBNDV")=="1")
     {
        headertext +="- BNDV";  
     } 
    
     $(".header-div").html(headertext);
     $("#TENBENHNHAN").keyup(function(e){
          var key=(e.keyCode)? e.keyCode : ((e.charCode) ? e.charCode: e.which);
            if(key==13){  
                $("#timKiem").click();
           }          
     });
     $("#divPopup").css("display","none");
     $("#divPopup .close").click(function(){
         $("#divPopup").css("display","none");
     });
 });
 function Find(control) {
      $(control).TimKiem({
             ajax:"../ajax/Z_BNTHUPHI_ajax2.aspx?do=TimKiem"
             +"&HaveVPNT=" + $.mkv.queryString("HaveVPNT") 
             + "&IsBNDV=" + $.mkv.queryString("IsBNDV")
             + "&IsBNBH=" + $.mkv.queryString("IsBNBH")
             + "&IsPhiKham=" + $.mkv.queryString("IsPhiKham")
             + "&IsCLS=" + $.mkv.queryString("IsCLS")
             + "&IsTamUng=" + $.mkv.queryString("IsTamUng")
             + "&IsPhiKham_CLS_TuDK=" + $.mkv.queryString("IsPhiKham_CLS_TuDK")
              ,dataType:'json',showPopup:false
       },function () {
             $("#tableAjax_Z_BNTHUPHI").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
             return true;
       },function (data) {
            var html = "";
            html+="<table class='jtable' id=\"gridTable\">";
            html+="<tr>";
            html+="<th></th>";
            html+="<th>STT</th>";
            html+="<th>MÃ BN</th>";
            html+="<th>TÊN BỆNH NHÂN</th>";
            html+="<th>GIỚI TÍNH</th>";
            html+="<th>NGÀY SINH</th>";
            html+="<th>KHOA</th>";
            html+="<th>NỘI DUNG THU</th>";
            html+="<th>SỐ TIỀN</th>";
            html+="<th></th>";
            html+="</tr>";
            html+="</table>";
            html+="<div id='paging' style='width:100%;height:50px'/>";
            $("#tableAjax_Z_BNTHUPHI").html(html);
      }).myfilter({
           txtfilter:"#gridTable [name=search]",
           paging:function(json,data){
                $("#tableAjax_Z_BNTHUPHI").find("#paging").html(data);
           },
           result:function(json,item){
                var html=[],j=0;
                for( var i = -1, y = item.length; ++i != y;){ 
                    if(!$.isNullOrEmpty(item[i].ID))
                    {
                      html[j++]="<tr>";
                      html[j++]="<td><a href='javascript:;' style='font-weight:bold;color:#ff0000' onclick=\"Thutien(this,'"+item[i].ID + "','"+ item[i].LOAITHU2 +"','" + item[i].MAPHIEUCLS +"','" + item[i].LOAITHU + "','" + encodeURIComponent(item[i].NOIDUNGTHU) + "');\"'>Thu tiền</a></td>";
                      html[j++]="<td>" + item[i].STT + "</td>";
                      html[j++]="<td>" + item[i].MABENHNHAN + "</td>";
                      html[j++]="<td style='text-align:left;'>" + item[i].TENBENHNHAN + "</td>";
                      html[j++]="<td>" + item[i].GIOITINH + "</td>";
                      html[j++]="<td>" + item[i].NGAYSINH + "</td>";
                      html[j++]="<td>" + item[i].KHOA + "</td>";
                      html[j++]="<td>" + item[i].NOIDUNGTHU + "</td>";
                      html[j++]="<td style='font-weight:bold;'>" + formatCurrency1(item[i].TONGTIEN) + "</td>";
                      html[j++]="<td><a href='javascript:;' style='font-weight:bold;' onclick=\"Preview('"+item[i].ID + "','"+ item[i].LOAITHU2 +"','" + item[i].MAPHIEUCLS +"','" + item[i].LOAITHU + "','" + encodeURIComponent(item[i].NOIDUNGTHU) + "');\"'>Xem trước</a></td>";
                      html[j++]="</tr>";
                    }
                }
                $("#gridTable").find("tr:gt(0)").empty().remove();
                $("#gridTable").append($(html.join('')));
           }
      });
 }
var id="",loaithu2="",maphieucls="",loaithu="",noidungthu="";
function Thutien(obj,ID,LoaiThu2,MaPhieuCLS,LoaiThu,NOIDUNGTHU)
{
    if($("#isChietKhauThuPhi").val()=="1")
    {
      //$("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
      id=ID;
      loaithu2=LoaiThu2;
      maphieucls=MaPhieuCLS;
      loaithu=LoaiThu;
      noidungthu=NOIDUNGTHU;
      var tenbenhnhan= $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("td").eq(3).text();
      $("#divPopup").css("display","block");
      $("#divPopup #title").text("Chi tiết: "+ decodeURIComponent(tenbenhnhan.toUpperCase())+ " - " + decodeURIComponent(NOIDUNGTHU));
      $("#divPopup #idmaphieu").val(id);
      $.ajax({
        async:false,
        url:"../ajax/Z_BNTHUPHI_ajax2.aspx?do=showview&id=" + id,
        type:"post",
        dataType:"text",
        success:function(data){
            if(data!=null && data !=""){
                $("#divPopup #detail").html(data);
                $("#divPopup #detail #divbutton #txtRow").val($(obj).parent().parent().index());
            }
                //$("#loadingAjax").remove();            
        }
        ,error: function (jqXHR, textStatus, errorThrown)
        {
                //$("#loadingAjax").remove();            
        }
       });  
    }
    else
    {
        $.ajax({
            async:false,
            url:"../ajax/Z_BNTHUPHI_ajax2.aspx?do=MaPhieu_new",
            type:"post",
            success:function(data){
                if(data!=null){
                    $(obj).parent().parent().remove();
                    window.open("../../VienPhi_TH/frm_rpt_InPhieuThuTH.aspx?ID=" + ID + "&LoaiThu2=" + LoaiThu2 + "&MaPhieuCLS=" + MaPhieuCLS + "&LoaiThu=" + LoaiThu + "&MaPhieu=" + data + "&NOIDUNGTHU=" + NOIDUNGTHU + "&PrevView=0&InTrucTiep=1");   
                }
            }
        });
    }
}
 function DongY(obj,isthucthu)
 {
    var name= obj.value;
    var idmaphieu=$("#divPopup #idmaphieu").val();
    if(idmaphieu!=null && idmaphieu !=""){
        $(obj).LuuTable({
            ajax:"../ajax/Z_BNThuPhi_ajax2.aspx?do=LuuChietKhau&idmaphieu="+idmaphieu
            ,tablename:"gridDetail"
        },null,function(){
            obj.value= name;
            if(isthucthu != null && isthucthu)
            {
                $("#btnThucThu").click();
            }
            else
            {
                $("#btnThucThu").css("color","Red");
                $("#btnThucThu").css("border-color","Blue");
                $("#btnThucThu").focus();
            }
        });
    }
 }
 function thucthu(obj)
 {
    if(isAllCheck())
    {
        $.mkv.myerror("Đã hủy hết nội dung thu!");
        return false;
    }
    if(!$.isNullOrEmpty(id))
    {
        $.ajax({
            async:false,
            url:"../ajax/Z_BNTHUPHI_ajax2.aspx?do=MaPhieu_new",
            type:"post",
            success:function(data){
                if(data!=null){
                    $("#divPopup").css("display","none");
                    window.open("../../VienPhi_TH/frm_rpt_InPhieuThuTH.aspx?ID=" + 
                    id + "&LoaiThu2=" + loaithu2 + "&MaPhieuCLS=" + maphieucls 
                    + "&LoaiThu=" + loaithu + "&MaPhieu=" + data + "&NOIDUNGTHU=" + noidungthu + "&PrevView=0&InTrucTiep=1"); 
                     $("#gridTable").find("tr").eq($("#divPopup #detail #divbutton #txtRow").val()).remove();  
                }
            }
        });
    }
    else
    {
        $.mkv.myerror("Chưa lưu thu phí !");
        return false;
    }
 }
 function isAllCheck()
 {
    var rowcount= $("#gridDetail tr").length;
    var value= true;
    for(var i=1;i<rowcount-1;i++)
    {
        if(!$("#gridDetail").find("tr").eq(i).find("#IsHuy").is(":checked"))
            value= false;
    }
    return  value;
 }
 function exit()
 {
     $("#divPopup").css("display","none");
 }
function Preview(ID,LoaiThu2,MaPhieuCLS,LoaiThu,NOIDUNGTHU)
{
     window.open("../../VienPhi_TH/frm_rpt_InPhieuThuTH.aspx?ID=" + ID + "&LoaiThu2=" + LoaiThu2 + "&MaPhieuCLS=" + MaPhieuCLS + "&LoaiThu=" + LoaiThu + "&MaPhieu=" + "000000000" + "&NOIDUNGTHU=" + NOIDUNGTHU + "&PrevView=1&InTrucTiep=1");   
}
function TinhThanhTien(obj)
{
    var soluong=$("#gridDetail").find("tr").eq($(obj).parent().parent().index()).find("td").eq(4).text();
    var dongia=$("#gridDetail").find("tr").eq($(obj).parent().parent().index()).find("td").eq(5).text().replace(/\./g,'');
    var thanhtien=0;
    thanhtien=(soluong*dongia)-(soluong*dongia)*$(obj).val()/100;
    $("#gridDetail").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(formatCurrencyOption(thanhtien,".",",",false));
    TongThanhTien();
}
function TongThanhTien()
{
    var thanhtien=0;
    for(var i=1;i<$("#gridDetail").find("tr").length-1;i++)
    {
        var tien_i= toJavaNum($("#gridDetail").find("tr").eq(i).find("#thanhtien").val());
        thanhtien+=eval(tien_i);
    }
    $("#gridDetail").find("tr").eq($("#gridDetail").find("tr").length-1).find("td").eq(2).text(formatCurrencyOption(thanhtien,".",",",true));
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
            //e.preventDefault(); 
        }).on("mouseup", function() {
            if(opt.handle === "") {
                $(this).removeClass('draggable');
            } else {
                $(this).removeClass('active-handle').parent().removeClass('draggable');
            }
        });
    }
})(jQuery);
