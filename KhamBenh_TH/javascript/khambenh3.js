 //1. Nếu có idkhoachinh thì trạng thái là cập nhật phiếu
 //2. Ngược lại nếu có idkhambenhchuyenphong thì khám mới với phongid=idchuyenpk
 //3. Ngược lại nếu có idbenhnhan,idchitietdangkykham trạng thái sẽ là khám mới

$(document).ready(function() {
    if ($.browser.msie<8) {
      $("input[type=text],input[type=checkbox],select,textarea").live("focus",function(){
            $(this).css("background-color","yellow");
          }).live("blur",function(){
                  $(this).css("background-color","");
          });
          
     }
    setControlFind($.mkv.queryString("idkhoachinh"));
    $("#luu").click(function() {
          $(this).Luu({
            ajax: "ajax/khambenh_ajax3.aspx?do=Luu&idkhambenhchuyenphong=" + $.mkv.queryString("idkhambenhchuyenphong") 
        }, function() {
            var tablegrid="gridTable";
            var thuoctrung="";
            if ($("#idbacsi").val() == "" || $("#idbacsi").val() == "0") {
                    $.mkv.myerror("Chưa chọn bác sỹ.");
                    $("#mkv_idbacsi").focus();
                return false;
             }
             if($("#NgayCDBS").val()!="" && ( $("#GioCDBS").val()==""||$("#PhutCDBS").val()=="") )
             {
                    $.mkv.myerror("Vùi lòng nhập giờ , phút chỉ định bổ sung");
                    $("#GioCDBS").focus();
                    return false;
             }
                                     
                                    
             
             for(var j=1;j<document.getElementById(tablegrid).rows.length-2;j++){
                if($("#idchandoan").val()==""||$("#idchandoan").val()==null){
                    $.mkv.myerror("Chưa có chẩn đoán xác định. Không thể lưu thuốc!");
                    $("#mkv_idchandoan").focus();
                    return false;
                }
            }
            if(document.getElementById(tablegrid).rows.length-3 >0 && $("#IsXuatVien").is(":checked")!=true){
                $.mkv.myerror("Chưa chọn thời gian");
                $("#IsXuatVien").focus();
                return false;
            }
            if(!checkSLTon_Grid())return false;
            for(var i=1;i<document.getElementById(tablegrid).rows.length-1;i++)
            {
                for(var j=i+1;j<document.getElementById(tablegrid).rows.length-1;j++){
                    if(document.getElementById(tablegrid).rows[i].cells[4].getElementsByTagName("input")[0].value==document.getElementById(tablegrid).rows[j].cells[4].getElementsByTagName("input")[0].value  
                        && document.getElementById(tablegrid).rows[i].cells[20].getElementsByTagName("input")[0].checked==document.getElementById(tablegrid).rows[j].cells[20].getElementsByTagName("input")[0].checked
                      ){
                            thuoctrung+=document.getElementById(tablegrid).rows[j].cells[4].getElementsByTagName("input")[1].value + ",";
                    }
                }
              
            } 
            if(thuoctrung.split(',')[0].length-1>0){
                 $.mkv.myerror(thuoctrung + " trùng nhau");
                    return false;        
            }
           return true;
        }, function(value) {
             $.LuuTable({
                        ajax:"ajax/khambenh_ajax3.aspx?do=LuuCDPH"+"&idkhambenh="+ $.mkv.queryString("idkhoachinh"),
                             tablename:"gridTableCDPH"
                        },null,function(){
                                $.LuuTable({
                                    ajax: "ajax/khambenh_ajax3.aspx?do=luuTablekhambenhcanlamsan&idkhambenh=" + $.mkv.queryString("idkhoachinh") + "&idbenhnhan=" + $("#idbenhnhan").val()+ "&idbacsi=" + $("#idbacsi").val()
                                    + "&NgayCDBS=" + $("#NgayCDBS").val()
                                    + "&GioCDBS=" + $("#GioCDBS").val()
                                    + "&PhutCDBS=" + $("#PhutCDBS").val()
                                     ,
                                    tablename: "gridTablecls"
                                }, null, function() {
                                    $.LuuTable({
                                        ajax: "ajax/khambenh_ajax3.aspx?do=luuTablechitietbenhnhantoathuoc&idkhambenh=" + $.mkv.queryString("idkhoachinh") + "&idbenhnhan=" + $("#idbenhnhan").val() ,
                                        tablename: "gridTable"
                                    },null, function() {
					                    $.ajax({
						                    url:"ajax/khambenh_ajax3.aspx?do=luuTongTienKham&idkhambenh=" + $.mkv.queryString("idkhoachinh")+"&IdChuyenPK="+$("#IdChuyenPK").val(),
						                    cache:false,
						                    async:false,
						                    type:"GET",
						                    success:function(data){
							                    if(data != ""){
								                    $.mkv.myalert("Đã hoàn thành lưu phiếu.",2000,"success");
							                         $("#luu").focus();
							                    }else
								                    $.mkv.myerror("Tính tổng tiền phiếu khám thất bại.");
								                
							                      if(data.split(';')[0]!="1")  $.mkv.myalert(data.split(';')[0],2000,"info");
							                      else
							                      {
							                        $("#SoTTChuyenP").val(data.split(';')[1]);
							                      }
						                    }
					                    });
					                    $("#intoathuoc_dv").focus();
                                    });
                                    
                                });
                         });
        });
    });
     $("#iskhongkham").click(function(){
       if($(this).is(":checked")){
            $("#mkv_idbenhvienchuyen").attr("disabled",true);
            $("#ischuyenvien").attr("disabled",true);
            $("#ischovekt").attr("disabled",true);
            $("#IsTieuPhauRoiVe").attr("disabled",true);
        }else{
            $("#ischovekt").attr("disabled",false);
             $("#ischuyenvien").attr("disabled",false);
             $("#ischuyenvien").attr("disabled",false);
             $("#IsTieuPhauRoiVe").attr("disabled",false);
        }
    });
     $("#ischovekt").click(function(){
       if($(this).is(":checked")){
            $("#mkv_idbenhvienchuyen").attr("disabled",true);
            $("#ischuyenvien").attr("disabled",true);
            $("#iskhongkham").attr("disabled",true);
            $("#IsTieuPhauRoiVe").attr("disabled",true);
            
        }else{
            $("#ischuyenvien").attr("disabled",false);
            $("#iskhongkham").attr("disabled",false);
            $("#IsTieuPhauRoiVe").attr("disabled",false);
        }
    });
     $("#ischuyenvien").click(function(){
        if($(this).is(":checked")){
            $("#iskhongkham").attr("disabled",true);
            $("#ischovekt").attr("disabled",true);
            $("#mkv_idbenhvienchuyen").attr("disabled",false);
            $("#IsTieuPhauRoiVe").attr("disabled",true);
            
        }else{
            $("#mkv_idbenhvienchuyen").attr("disabled",true);
            $("#iskhongkham").attr("disabled",false);
            $("#ischovekt").attr("disabled",false);
            $("#IsTieuPhauRoiVe").attr("disabled",false);
        }
   
    });
      $("#IsTieuPhauRoiVe").click(function(){
        if($(this).is(":checked")){
            $("#iskhongkham").attr("disabled",true);
            $("#ischovekt").attr("disabled",true);
            $("#ischuyenvien").attr("disabled",true);
            $("#mkv_idbenhvienchuyen").attr("disabled",true);
            
        }else{
            $("#iskhongkham").attr("disabled",false);
            $("#ischovekt").attr("disabled",false);
            $("#ischuyenvien").attr("disabled",false);
            $("#mkv_idbenhvienchuyen").attr("disabled",false);
        }
       });
      //───────────────────────────────────────────────────────────────────────────────────────
   $("#phieumoi").click(function() {
        window.close();
    });
    //───────────────────────────────────────────────────────────────────────────────────────
    $("#inchidinhCLS").click(function() {
        window.open("rptPhieuChiDinh.aspx?idkhambenh=" + $.mkv.queryString("idkhoachinh")+"&idkhoa="+$("#IdKhoa").val()+"&IsAll=0&isdvkt=0","_blank");
    });
    //───────────────────────────────────────────────────────────────────────────────────────
    $("#inchidinhDV").click(function() {
        window.open("rptPhieuChiDinh.aspx?idkhambenh=" + $.mkv.queryString("idkhoachinh")+"&idkhoa="+$("#IdKhoa").val()+"&IsAll=0&isdvkt=1","_blank");
    });
    //───────────────────────────────────────────────────────────────────────────────────────
    $("#intoathuoc_bh").click(function() {
        window.open("rpt_Toathuoc.aspx?IdKhamBenh=" + $.mkv.queryString("idkhoachinh")+"&IsBHYT=1&IsAll=1", '_blank', 'location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
    });
    //───────────────────────────────────────────────────────────────────────────────────────
    $("#InBV01").click(function() {
        window.open("../VienPhi_BH/frm_rpt_chiphikhambenh.aspx?idphieutt="+ $("#IDBENHNHANBHDONGTIEN").val()+"", '_blank', 'location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
    });
    //───────────────────────────────────────────────────────────────────────────────────────
    
      $("#GiuongBenh").click(function() {
        window.open("../noitru/nvk_TinhTienGiuongBenh.aspx?dkmenu="+$.mkv.queryString("dkMenu")+"&idbenhnhan="+ $("#idbenhnhan").val()+"&idctdkk="+ $("#IdChiTietDangKyKham").val()+"&IdKhoa="+ $("#IdKhoa").val()+"", '_blank', 'location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
    });
    //───────────────────────────────────────────────────────────────────────────────────────
    $("#intoathuoc_dv").click(function() {
        window.open("rpt_Toathuoc.aspx?IdKhamBenh=" + $.mkv.queryString("idkhoachinh")+"&IsDV=1&IsAll=1", '_blank', 'location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
    });
    //───────────────────────────────────────────────────────────────────────────────────────
    
    $("#InGiayChuyenVien").click(function() {
        window.open("../khambenh/frmGiayChuyenVien.aspx?idkhambenh=" + $.mkv.queryString("idkhoachinh")+"&IdKhoa="+$("#IdKhoa").val()+"&idctdkk="+$("#IdChiTietDangKyKham").val()+"&IsGetByKhamBenh=1", '_blank', 'location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
    });
    //───────────────────────────────────────────────────────────────────────────────────────
    $("#MakeSoVaoVien").click(function(){
        $.ajax({
            type:"GET",
            cache:false,
            url:"ajax/khambenh_ajax3.aspx?do=MakeSoVaoVien&idkhambenh=" + $.mkv.queryString("idkhoachinh")
                                                +"&idctdkk="+$("#IdChiTietDangKyKham").val()
                                                +"&IsNoiTru="+$("#isNoiTru").is(":checked"),
            success:function(data){
                if(data!="" && data !=null){
                                              $("#SOVAOVIEN1").val(data);
                                              $("#MakeSoVaoVien").attr("disabled",true);
                                           }
            },
            error:function(data){
               $.mkv.myerror(data); 
            }
        });
    });
    //───────────────────────────────────────────────────────────────────────────────────────
    $("#viewHSBA").click(function(){
        $.ajax({
            type:"GET",
            cache:false,
            url:"ajax/khambenh_ajax3.aspx?do=checkHSBA&idbenhnhan=" + $("#idbenhnhan").val(),
            success:function(data){
                if(data!="" && data !=null){
                    window.open("HSBA.aspx?idkb=" + $.mkv.queryString("idkhoachinh") + "&idbn=" + $("#idbenhnhan").val(),"_blank","location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no");
                }
            },
            error:function(data){
               $.mkv.myerror(data); 
            }
        });
    });
    //───────────────────────────────────────────────────────────────────────────────────────
    $("#moi").click(function() {
        $(this).Moi();
        listCLS = "";
        loadTableAjaxchitietbenhnhantoathuoc('');
        loadTableAjaxkhambenhcanlamsan('');
    });
    //───────────────────────────────────────────────────────────────────────────────────────
    $("#confirm").click(function(){
        $.ajax({
            async:true,
            cache:false,
            type:'get',
            url:"ajax/khambenh_ajax3.aspx?do=checkpass&pass="+$("#user_pass").val(),
            dataType:'text',
            success:function(value){
                if(value=='true'){
                    $("#dialog").dialog("close");
                     $(this).Xoa({
                       ajax: "ajax/khambenh_ajax3.aspx?do=xoa"
                        }, null, function() {
                            listCLS = "";
                            loadTableAjaxchitietbenhnhantoathuoc('');
                            loadTableAjaxkhambenhcanlamsan('');
                      });
               }else{
                    $.mkv.myerror(value);
               }
             }
        });
           
    });
    //───────────────────────────────────────────────────────────────────────────────────────
    $("#xoa").click(function() {            
     var yourCondition = true;
            if (yourCondition) {
                $('#dialog').dialog({
                    modal: 'true',
                    title: 'Xác thực mật khẩu ? ',
                    height:'100',
                    width:'250'
                });
            }

    });
    //───────────────────────────────────────────────────────────────────────────────────────
    var AllowXuatLai="0";
    //───────────────────────────────────────────────────────────────────────────────────────
    $("#xuatvtyt").click(function(){
          
            $.ajax({
                async:false,
                cache:true,
                dataType:"text",
                url:"ajax/khambenh_ajax3.aspx?do=xuatvtyt&idkhambenh="+$.mkv.queryString("idkhoachinh") 
                + "&AllowXuatLai=" + AllowXuatLai
                + "&loaikhamid=" + $("#loaidk").val()
                + "&idkhoa=" + $("#IdKhoa").val()
                ,
                success:function(value){
                  if(value=="2"){
                     $.mkv.myerror("VTYT&HC đã xuất rồi !");
                     AllowXuatLai="1";
                  }
                  else if(value=="1"){
                     $.mkv.myalert("Xuất VTYT&HC thành công !",2000,"success"); 
                     AllowXuatLai="0";
                  }else if(value=="0"){
                     $.mkv.myerror("Xuất VTYT&HC chưa được");
                     AllowXuatLai="0";
                  }
                },
                error:function(data){
                    $.mkv.myerror(data);
                }
            });
    });
     //───────────────────────────────────────────────────────────────────────────────────────
    $("#xuatthuoc").click(function(){
          
            $.ajax({
                async:false,
                cache:true,
                dataType:"text",
                url:"ajax/khambenh_ajax3.aspx?do=xuatthuoc&idkhambenh="+$.mkv.queryString("idkhoachinh") + "&AllowXuatLai=" + AllowXuatLai,
                success:function(value){
                  if(value=="2"){
                     $.mkv.myerror("Thuốc đã xuất rồi !");
                     AllowXuatLai="1";
                  }
                  else if(value=="1"){
                     $.mkv.myalert("Xuất thuốc thành công !",2000,"success"); 
                     AllowXuatLai="0";
                  }else if(value=="0"){
                     $.mkv.myerror("Xuất thuốc chưa được");
                     AllowXuatLai="0";
                  }
                },
                error:function(data){
                    $.mkv.myerror(data);
                }
            });
    });
   setInterval(function(){
        RealTimeSLTon();
   },10000);
});

 
//───────────────────────────────────────────────────────────────────────────────────────
function idkhoxuatsearch(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idkhoxuatsearch&idkhoa=" + $("#IdKhoa").val()
     +"&LoaiKhamID=" + $("#loaidk").val()
     
     , {
        minChars: 0,
        width: 350,
        scroll: true,
        addRow: false,
        header:"<div style =\"width:100%;height:30px;Background-color:Blue;margin-top:-40px;\">"
                          + "<div algin='left' style=\"width:15%;color:white;font-weight:bold;float:left; font-size:14px;\" >Mã kho</div>"
                          + "<div style=\"width:65%;color:white;font-weight:bold;float:left; font-size:14px; \" >Tên kho</div>"
               + "</div>",
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
            $(obj).val(data[3]);
              $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}
function tinhbmi()
{
  if($("#CANNANG").val()=="" || $("#CANNANG").val()=="0" ||$("#CHIEUCAO").val()=="" ||$("#CHIEUCAO").val()=="0")
    return;
  $("#BMI").val(custRound(10000*($("#CANNANG").val()/($("#CHIEUCAO").val()*$("#CHIEUCAO").val())),1));
}
function custRound(x,places) {
  return (Math.round(x*Math.pow(10,places)))/Math.pow(10,places)
}

function setControlFind(idkhoatimkiem) {

    $.mkv.queryString("temps", "");
    $.mkv.removeQueryString("temps");
    //////
    if (idkhoatimkiem != null && idkhoatimkiem != "") {
        $.BindFind({ ajax: "ajax/khambenh_ajax3.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem }, null, function() {
            if($("#IdKhoa").val()=="1"){
               $("#xuatthuoc").css("display","none");
               $("#xuatvtyt").css("display","");
            }
            else
            {
               $("#xuatvtyt").css("display","none");
               $("#xuatthuoc").css("display","")
            }
            
            $("#loadingAjax").remove();
            loadTableAjaxchitietbenhnhantoathuoc($.mkv.queryString("idkhoachinh"));
            loadTableAjaxkhambenhcanlamsan($.mkv.queryString("idkhoachinh"));
            loadTableAjaxchandoanphoihop($.mkv.queryString("idkhoachinh"));

            $("#_luu").click();
            $("#TENKHOA").attr("disabled","disabled");
            $("#TENPHONG").attr("disabled","disabled");
             
        });
    } else if ($.mkv.queryString("idkhambenhchuyenphong") != null && $.mkv.queryString("idkhambenhchuyenphong") != "") {
        $.BindFind({ ajax: "ajax/khambenh_ajax3.aspx?do=setTimKiem_KhamMoiChuyenPhong"
                        + "&idkhambenhchuyenphong=" + $.mkv.queryString("idkhambenhchuyenphong")
        }, null, function(value) {
            if($("#IdKhoa").val()=="1"){
               $("#xuatthuoc").css("display","none");
               $("#xuatvtyt").css("display","");
            }
            else
            {
               $("#xuatvtyt").css("display","none");
               $("#xuatthuoc").css("display","")
            }
            $("#loadingAjax").remove();
            loadTableAjaxchitietbenhnhantoathuoc($.mkv.queryString("idkhoachinh"));
            loadTableAjaxkhambenhcanlamsan($.mkv.queryString("idkhambenhchuyenphong"),null,1);
            loadTableAjaxchandoanphoihop($.mkv.queryString("idkhambenhchuyenphong"));

            $("#_luu").click();
        });
    }
    else {
        $.BindFind({ ajax: "ajax/khambenh_ajax3.aspx?do=setTimKiem_KhamMoi&idchitietdangkykham=" + $.mkv.queryString("idchitietdangkykham")
                     + "&idbenhnhan=" + $.mkv.queryString("idbenhnhan")
        }, null, function() {
             if($("#IdKhoa").val()=="1"){
               $("#xuatthuoc").css("display","none");
               $("#xuatvtyt").css("display","");
            }
            else
            {
               $("#xuatvtyt").css("display","none");
               $("#xuatthuoc").css("display","")
            }
            $("#loadingAjax").remove();
            loadTableAjaxchitietbenhnhantoathuoc($.mkv.queryString("idkhoachinh"));
            loadTableAjaxkhambenhcanlamsan($.mkv.queryString("idkhoachinh"));
            loadTableAjaxchandoanphoihop($.mkv.queryString("idkhoachinh"));

            $("#_luu").click();
        });
    }
}

function xoaontable(control) {
    var stssmoi =$(control).parent().parent().index();
    $(control).XoaRow({
        ajax: "ajax/khambenh_ajax3.aspx?do=xoachitietbenhnhantoathuoc"
    });
     var row=$("#gridTable").find("tr");
    for(var i=stssmoi;i<row.length-1;i++){
       row[i].childNodes[0].innerHTML=i;
    }
}

function xoaontablecls(control) {
    var valueCLS = $(control).parents("table").find("tr").eq($(control).parent().parent().index()).find("#idcanlamsan").val();
    var stssmoi =$(control).parent().parent().index();
    $(control).XoaRow({
        ajax: "ajax/khambenh_ajax3.aspx?do=xoakhambenhcanlamsan"
    });

    (($(control).parent().parent().index() == -1) ? CheckXoaCLS(valueCLS) : "");
    var row=$("#gridTablecls").find("tr");
    for(var i=stssmoi;i<row.length-1;i++){
        row[i].childNodes[0].innerHTML=i;
    }
  tongtiencls();
}
function loadTableAjaxchitietbenhnhantoathuoc(idkhoa, page) {
    if (idkhoa == null) idkhoa = "";
    if (page == null) page = "1";
    $("#tableAjax_chitietbenhnhantoathuoc").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>');
    $.ajax({
        type: "GET",
        cache: false,
        url: "ajax/khambenh_ajax3.aspx?do=loadTablechitietbenhnhantoathuoc&idkhambenh=" 
        + idkhoa + "&page=" + page + "&idkhoa=" + $("#IdKhoa").val() + "&loaidk=" + $("#loaidk").val(),
        success: function(value) {
            $("#tableAjax_chitietbenhnhantoathuoc").html(value);

        }
    });
}
function loadTableAjaxkhambenhcanlamsan(idkhoa, page,IsChuyenPhong) {
    if (idkhoa == null) idkhoa = "";
    if (page == null) page = "1";
     if (IsChuyenPhong == null) IsChuyenPhong = "0";
    $("#tableAjax_khambenhcanlamsan").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>');
    $.ajax({
        type: "GET",
        cache: false,
        url: "ajax/khambenh_ajax3.aspx?do=loadTablekhambenhcanlamsan&idkhambenh=" 
        + idkhoa + "&page=" + page+"&IsChuyenPhong="+IsChuyenPhong + "&loaidk=" + $("#loaidk").val(),
        success: function(value) {
            $("#tableAjax_khambenhcanlamsan").html(value);
            tongtiencls();
        }
    });
    if($("#SOVAOVIEN1").val()!="")
         $("#MakeSoVaoVien").attr("disabled",true);
}
function huyontablecls(control)
{
 if($("#gridTablecls").find("tr").eq($(control).parent().parent().index()).find("#idcanlamsan").val()==""){ 
        $(control).parent().parent().remove();
            return;
    }
  jConfirm("Bạn có thực sự muốn hủy cận lâm sàn này ? ","Xác nhận hủy",function(r){
    if(r){
         var stssmoi =$(control).parent().parent().index();
            $.ajax({
                async:false,
                cache:false,
                type:'post',
                url:"ajax/khambenh_ajax3.aspx?do=HuyCLS&idkhambenhcanlamsan="+$("#gridTablecls").find("tr").eq($(control).parent().parent().index()).find("#idkhoachinh").val() + "&idkhambenh="+$.mkv.queryString("idkhoachinh") + "&idcanlamsan=" + $("#gridTablecls").find("tr").eq($(control).parent().parent().index()).find("#idcanlamsan").val(),
                success:function(data){
                    $.mkv.myalert(data,2000,"info");
                        $(control).parent().parent().remove();
                }
            });
            var row=$("#gridTablecls").find("tr");
            for(var i=stssmoi;i<row.length-1;i++){
                row[i].childNodes[0].innerHTML=i;
            }
            tongtiencls();
        }
  });
}
function loadTableAjaxchandoanphoihop(idkhoa, page) {
    if (idkhoa == null) idkhoa = "";
    if (page == null) page = "1";
    $("#tableAjax_chandoanphoihop").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>');
    $.ajax({
        type: "GET",
        cache: false,
        url: "ajax/khambenh_ajax3.aspx?do=loadTablechandoanphoihop&idkhambenh=" + idkhoa + "&page=" + page,
        success: function(value) {
            $("#tableAjax_chandoanphoihop").html(value);
            $("table.jtable tr:nth-child(odd)").addClass("odd");
            $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
            $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");

        }
    });
}

function LoadChanDoanMoTaICD_tuyenduoi(obj,loaichuandoan)
{
     $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=LoadChanDoanMoTaICD", {
        minChars: 0,
        width: 437,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:10%;color:white;float:left; font-size:12px;text-algin:left;\" >Mã ICD</div>"
                      + "<div style=\"width:80%;color:white;float:left;font-size:12px;\" >Mô tả</div>"
                  + "</div>",
        formatItem: function(data) {
            return "<div style='float:left; width:15%; height:30px'>" + data[1] + "</div><div style='float:left;width:85%; height:30px;'>" + data[2] + "</div>";
        } 
    }).result(function(event, data) {
      $(obj).val(data[1]);
                      $("#idchandoantuyenduoi").val(data[3]);
                $("#mkv_mota_idchandoantuyenduoi").val(data[2]);
                $("#mkv_idchandoantuyenduoi").val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
     });
}
function LoadChanDoanMoTaICD(obj,loaichuandoan)
{
     $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=LoadChanDoanMoTaICD", {
        minChars: 0,
        width: 437,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:10%;color:white;float:left; font-size:12px;text-algin:left;\" >Mã ICD</div>"
                      + "<div style=\"width:80%;color:white;float:left;font-size:12px;\" >Mô tả</div>"
                  + "</div>",
        formatItem: function(data) {
            return "<div style='float:left; width:15%; height:30px'>" + data[1] + "</div><div style='float:left;width:85%; height:30px;'>" + data[2] + "</div>";
        } 
    }).result(function(event, data) {
        if (loaichuandoan == "phoihop") {
            $("#tableAjax_chandoanphoihop").append("<div style='text-align:left; padding-left:30px;float:left;width:500px;height:30px'>"
                        + "<a style='cursor:pointer' onclick='$(this).parent().remove();'>Xoá--</a>"
                        + "<input type='hidden' mkv='true' id='idicd' value='" + data[3] + "' />"
                        + " " +  data[1] + " - " +  data[2]
                        + "</div>");
            $(obj).val("");
            }else {
                      $(obj).val(data[1]);
                      $("#idchandoan").val(data[3]);
                $("#mkv_mota").val(data[2]);
                $("#mkv_idchandoan").val(data[1]);
            }
        setTimeout(function() {
            obj.focus();
        }, 100);
     });
}
function LoadChanDoanMaICD(obj,loaichuandoan)
{
     $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=LoadChanDoanMaICD", {
        minChars: 0,
        width: 507,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:10%;color:white;float:left; font-size:12px;text-algin:left;\" >Mã ICD</div>"
                      + "<div style=\"width:80%;color:white;float:left;font-size:12px;\" >Mô tả</div>"
                  + "</div>",
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
         if (loaichuandoan == "phoihop") {
            $("#tableAjax_chandoanphoihop").append("<div style='text-align:left; padding-left:30px;float:left;width:500px;height:30px'>"
                        + "<a style='cursor:pointer' onclick='$(this).parent().remove();'>Xoá--</a>"
                        + "<input type='hidden' mkv='true' id='idicd' value='" + data[3] + "' />"
                        + " " +  data[1] + " - " +  data[2]
                        + "</div>");
            $(obj).val("");
            }else {
                      $(obj).val(data[1]);
                      $("#idchandoan").val(data[3]);
                $("#mkv_mota").val(data[2]);
                $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[3]);
            }
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}
function LoadChanDoanMaICD_tuyenduoi(obj,loaichuandoan)
{
     $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=LoadChanDoanMaICD", {
        minChars: 0,
        width: 507,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:10%;color:white;float:left; font-size:12px;text-algin:left;\" >Mã ICD</div>"
                      + "<div style=\"width:80%;color:white;float:left;font-size:12px;\" >Mô tả</div>"
                  + "</div>",
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
       $(obj).val(data[1]);
                      $("#idchandoantuyenduoi").val(data[3]);
                $("#mkv_mota_idchandoantuyenduoi").val(data[2]);
                $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[3]);
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}

function chandoanbandausearch(obj, loaichandoan) {
    var chandoanloai = "";
    if (loaichandoan == "tuyenduoi")
        chandoanloai = "loaiicdTD";
    else if (loaichandoan == "phoihop")
        chandoanloai = "loaiphoihop";
    else
        chandoanloai = "loaiicd";

    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=chandoanbandausearch&loaiicd=" + $("#" + chandoanloai + "").val(), {
        minChars: 0,
        scroll: true,

        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        if (loaichandoan == "phoihop") {
            $("#tableAjax_chandoanphoihop").append("<div style='text-align:right;float:left;width:400px;height:30px'>"
                        + "<a style='cursor:pointer' onclick='$(this).parent().remove();'>Xoá</a> -- "
                        + "<input type='hidden' mkv='true' id='idicd' value='" + data[1] + "' />"
                        + data[0]
                        + "</div>");
            $(obj).val("");
        } else {
            $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        }
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}
function loaithuocidsearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=loaithuocidsearch", {
        minChars: 0,
        width: 100,
        scroll: true,
        catche: false,
        addRow: false,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}
function iddvtsearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=iddvtsearch", {
        minChars: 0,
        width: 100,
        scroll: true,
        catche: false,
        addRow: true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}
function idcachdungsearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idcachdungsearch", {
        minChars: 0,
        width: 150,
        scroll: true,
        catche: false,
        addRow: true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}
function cateidsearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=cateidsearch&loaithuocid=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#DoiTuongThuocID").val(), {
        minChars: 0,
        width: 350,
        scroll: true,
        catche: false,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:75%;color:white;font-weight:bold;float:left\" >Tên nhóm</div>"
                     // + "<div style=\"width:15%;color:white;font-weight:bold;float:left\" >Thứ tự</div>"
                  + "</div>",
        
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        $(obj).val(data[2]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}
function idkhoachange(obj)
{
  $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#mkv_tennhom").val('');
  $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idcanlamsan").val('');
    
}
function idkhoasearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idkhoasearch", {
        minChars: 0,
        width: 150,
        scroll: true,
        catche: false,
        addRow: true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        
        $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}
function idphongsearch(obj) {

    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idphongsearch&idpkb=" + $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#idkhoa").val(), {
        minChars: 0,
        width: 200,
        scroll: true,
        catche: false,
        addRow: true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
    
        $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}
function chuyenhuong(obj)
{
     $("#gridTable").find("tr").next().eq($(obj).parent().parent().index()).find("#mkv_idthuoc").focus();
}

 function CheckSLTON(obj)
 {
       var  IsCheckSLTon=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IsCheckSLTon").val( );
       var  SLTON=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#slton").val();
      var  idkhoxuat=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idkhoxuat").val();



       var SLKe=$(obj).val();
       if(IsCheckSLTon==""||IsCheckSLTon=="0") return false;
       if(SLKe==""||SLKe=="0") return false;
      if(   idkhoxuat!=null && idkhoxuat!="" && idkhoxuat!="0" && idkhoxuat!="-1" &&   eval(SLKe)>eval( SLTON))
        {
            $.mkv.myerror("Số lượng kê không > " + SLTON);      
            $(obj).focus();
        }
 }
 
function idthuocsearch(obj,TypeSearch) {
    var LoaiThuocID=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#DoiTuongThuocID").val();
    if(LoaiThuocID==null || LoaiThuocID=="") LoaiThuocID="1";
    var TenLoaiThuoc="thuốc";
    if(LoaiThuocID=="2")  TenLoaiThuoc="hoá chất";
    if(LoaiThuocID=="3")  TenLoaiThuoc="dụng cụ";
    if(LoaiThuocID=="4")  TenLoaiThuoc="VTYT";
    
    
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idthuocsearch&iddangkykham="+$("#iddangkykham").val()+"&idbenhnhan=" + $("#idbenhnhan").val() 
     + "&loaithuocid=" + LoaiThuocID
     + "&idkho=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idkhoxuat").val() 
     + "&cateid=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#cateid").val() 
     + "&IsTuTruc=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IsTuTruc").is(":checked")
     + "&IdKhoa=" + $("#IdKhoa").val()+"&TypeSearch="+TypeSearch 
     + "&loaidk=" + $("#loaidk").val(), {
        minChars: 0,
        width: 930,
        scroll: true,
        isEnterFind: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px;Background-color:Blue;margin-top:-40px;\">"
                          + "<div algin='left' style=\"width:8%;color:white;font-weight:bold;float:left;\" >Tên "+TenLoaiThuoc+"</div>"
                          + "<div style=\"width:33%;color:white;font-weight:bold;float:left; text-algin:center;\" >Công thức</div>"
                          + "<div style=\"width:10%;color:white;font-weight:bold;float:left\" >Đường dùng</div>"
                          + "<div style=\"width:10%;color:white;font-weight:bold;float:left\" >ĐVT</div>"
                          + "<div style=\"width:9%;color:white;font-weight:bold;float:left\" >Giá</div>"
                          + "<div style=\"width:8%;color:white;font-weight:bold;float:left\" >SL tồn</div>"
                          + "<div style=\"width:9%;color:white;font-weight:bold;float:left\" >?BH</div>"
                          + "<div style=\"width:9%;color:white;font-weight:bold;float:left\" >?Trong BV</div>"
                          + "</div>",
        formatItem: function(data) {
              return data[0];
        } 
    }).result(function(event, data) {
        $(obj).val(data[4]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val(data[5]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idcachdung").val(data[3]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_iddvt").val(data[2]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_iddvdung").val(data[2]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(data[5]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_congthuc").val(data[7]);
        if(data[8]=="True"){
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SuDungChoBH").attr("checked",true);
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_Save").attr("checked",true);
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_Save").attr("disabled",false);
            $(obj).parent().parent().css("background-color","");
        }else{
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_Save").attr("disabled",true);
            $(obj).parent().parent().css("background-color","#CAE3FF");
        }
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#iddvt").val(data[9]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#iddvdung").val(data[9]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idcachdung").val(data[10]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idkho").val(data[11]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluongke").val("");
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idthuoc").val(data[4]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idthuoc").val(data[1]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#slton").val(data[6]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IsCheckSLTon").val(data[12]);
         setTimeout(function() {
                $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluongke").focus();
         }, 100);
    });
     
}
$.mkv.afterThemDong = function(tablename, dongso) {
    if (tablename[0].id == "gridTable"   ) {
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#idkhoxuat").val($("#"+tablename[0].id).find("tr").eq(dongso).find("#idkhoxuat").val());
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#mkv_idkhoxuat").val($("#"+tablename[0].id).find("tr").eq(dongso).find("#mkv_idkhoxuat").val());
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#SuDungChoBH").attr("disabled",true);
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#IsBHYT_Save").attr("disabled",true);
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#slton").attr("disabled",true);
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#isngay").attr("checked",$("#"+tablename[0].id).find("tr").eq(dongso).find("#isngay").is(":checked"));
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#istuan").attr("checked",$("#"+tablename[0].id).find("tr").eq(dongso).find("#istuan").is(":checked"));
    }
    if (tablename[0].id == "gridTablecls") {
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#SuDungChoBH").attr("disabled",true);
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#IsBHYT_Save").attr("disabled",true);
    }
}
function IdkhoaChuyenSearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=IdkhoaChuyenSearch", {
        minChars: 0,
        header:false,
        scroll: true,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        if ($("#" + $(obj).attr("id").replace("mkv_", "")).val() != data[1]) {
            $("#mkv_idDVPhongChuyenDen").val("");
            $("#idDVPhongChuyenDen").val("");
            $("#mkv_idPhongChuyenDen").val("");
            $("#idPhongChuyenDen").val("");
        }
        $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
       
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}
function banggiadichvuSearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=banggiadichvuSearch&IdkhoaChuyen=" + $("#IdkhoaChuyen").val() + "&huongdieutri=" + $("#huongdieutri").val(), {
        minChars: 0,
        width: 350,
        scroll: true,

        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        if ($("#" + $(obj).attr("id").replace("mkv_", "")).val() != data[1]) {
            $("#mkv_idPhongChuyenDen").val("");
            $("#idPhongChuyenDen").val("");
        }
        $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}
function phongkhambenhSearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=phongkhambenhSearch"+ "&IdkhoaChuyen=" + $("#IdkhoaChuyen").val()+"&banggiadichvu=" + $("#idDVPhongChuyenDen").val() + "&idbenhnhan=" + $("#idbenhnhan").val(), {
        minChars: 0,
        scroll: true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}
function idcanlamsansearch(obj) {
  
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idcanlamsansearch&idbenhnhan=" + $("#idbenhnhan").val() + "&loaidk=" + $("#loaidk").val()+ "&tennhom=" +  encodeURIComponent($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#mkv_tennhom").val()) + "&idphongkhambenh=" + $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#idkhoa").val(), {
        minChars: 0,
        width: 550,
        scroll: true,
        addRow: true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {

        if ($(obj).parents("#gridTablecls").attr("id") != null) {
           $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
            $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val("1");
            $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val(data[2]);
            if(data[3]=="True"){
                $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#SuDungChoBH").attr("checked",true);
                $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_Save").attr("checked",true);
                $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_Save").attr("disabled",false);
                $(obj).parent().parent().css("background-color","");
            }else{
                $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_Save").attr("disabled",true);
                $(obj).parent().parent().css("background-color","#CAE3FF");
            }
            $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#chietkhau").val("0");
            $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
            thanhtiencls(obj);
            tongtiencls();
        }
        setTimeout(function() {
             $("#gridTablecls").find("tr").next().eq($(obj).parent().parent().index()).find("#mkv_idcanlamsan").focus();
        },0);
    });
}
function tinhtienthuoc(obj) {
    var sl = obj.value;
    var dongia = $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val();
    $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(eval(sl) * eval(dongia));
}
function idbacsisearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idbacsisearch&idkhoa=" + $("#IdKhoa").val(), {
        minChars: 0,
        width: 290,
        scroll: true,
        cache:true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
           $("#trieuchung").focus();
        }, 100);
    });
}
function idbacsisearch2(obj) {
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idbacsisearch&idkhoa=" + $("#IdKhoa").val(), {
        minChars: 0,
        width: 290,
        scroll: true,
        cache:true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
        }, 100);
    });
}
function formatCurrency(num) 
 {
    num = num.toString().replace(/\$|\,/g,'');
    if(isNaN(num))
    num = "0";
    var sign = (num == (num = Math.abs(num)));
    num = Math.floor(num*100+0.50000000001);
    var sole = num % 100;
    num = Math.floor(num/100).toString();
    
    for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
    {
        num = num.substring(0,num.length-(4*i+3))+'.'+
        num.substring(num.length-(4*i+3));
    }
    return (((sign)?'':'-') + num+","+sole);
}
function tongtiencls()
{
    var tablegrid="gridTablecls";   
    var tongtien=0;
    for(var i=1;i<document.getElementById(tablegrid).rows.length-1;i++)
    {
    try{
        if(typeof eval(document.getElementById(tablegrid).rows[i].cells[8].getElementsByTagName("input")[0].value.replace(/\$|\,/g,''))!='undefined')
             tongtien += eval(document.getElementById(tablegrid).rows[i].cells[8].getElementsByTagName("input")[0].value.replace(/\$|\,/g,''));
        }catch(ex){}
    }
    document.getElementById(tablegrid).rows[document.getElementById(tablegrid).rows.length-1].cells[2].innerHTML =formatCurrency(tongtien).split(',')[0] + "đ";
}

function thanhtiencls(obj) {
    var tientruocck = eval($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val()) * eval($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val());
    var tienck = (eval(tientruocck) * eval($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#chietkhau").val())) / 100;
    $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(tientruocck - tienck);
}
function thanhtiengiuong(obj) {
    var thanhtien = eval($("#gridTablegiuong").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val()) * eval($("#gridTablegiuong").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val());
    $("#gridTablegiuong").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(thanhtien);
}
// ----------------------- xu ly danh sach CLS-----------------------------------------
var listCLS = "";
function ChonCLS(obj, idnhom, idpkb,loai) {
    if (idpkb == null)
        listCLS = "";
    for (var i = 1; i < $("#gridTablecls").find("tr").length; i++) {
        if ($.trim($("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val()).length > 0)
            listCLS += $("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val() + ",";
    }
    if (idpkb == null)
        idpkb = 0;
    $(obj).TimKiem({
        ajax: "ajax/khambenh_ajax3.aspx?do=ChonCLS&listID=" 
        + listCLS + "&idpkb=" + idpkb + "&IdBenhNhan=" 
        + $("#idbenhnhan").val()+"&loaidk="+$("#loaidk").val()
        ,readMKV: false
        ,onlyPopup:false
        ,width:1000
        ,height:350
    });

}
function checkAllCLS(obj) {
    var tableCLS = $(obj).parents("table").find("tr");
    for (var i = 0; i < tableCLS.length; i++) {
        CheckXoaCLS(tableCLS.eq(i).find("input[type=checkbox]").val());
        if ($(obj).is(":checked")) {
            tableCLS.eq(i).find("input[type=checkbox]").attr("checked", true);
            listCLS += tableCLS.eq(i).find("input[type=checkbox]").val() + ",";
        } else {
            tableCLS.eq(i).find("input[type=checkbox]").attr("checked", false);
        }
    }
}
function setChonDichVuCLS(obj) {
    CheckXoaCLS($(obj).val());
    if ($(obj).is(":checked")) {
        listCLS += $(obj).val() + ",";
    }
}

function CheckXoaCLS(vals) {
    if (listCLS.indexOf(",") != -1) {
        var arrIDDV = listCLS.split(',');
        for (var j = 0; j < arrIDDV.length; j++) {
            if (arrIDDV[j] == vals) {
                var stemp = new RegExp(arrIDDV[j] + ",", 'g');
                listCLS = listCLS.replace(stemp, '');
                break;
            }

        }
    }
}
//--------------------------xy ly toa thuoc cu------------------------------------
var lstTT = "";
function ChonTT(obj, idkb,loai) {
    if (idkb == null)
        lstTT = "";
    for (var i = 1; i < $("#gridTable").find("tr").length; i++) {
        if ($.trim($("#gridTable").find("tr").eq(i).find("#idchitietbenhnhantoathuoc").val()).length > 0)
            lstTT += $("#gridTable").find("tr").eq(i).find("#idchitietbenhnhantoathuoc").val() + ",";
    }
    if (idkb == null)
        idkb = 0;
	$(obj).TimKiem({
	    ajax: "ajax/khambenh_ajax3.aspx?do=ChonTT&listID=" 
	        + lstTT + "&idkb=" + idkb + "&IdBenhNhan=" 
	        + $("#idbenhnhan").val() + "&idkhambenh=" 
	        + $.mkv.queryString("idkhoachinh"),
	    title: "Danh sách toa thuốc cũ",
	    readMKV: false,
	    onlyPopup:false,
	    width: 1100,
	    heigth: 800
	    
	},null,function (value){
	    if(value==""|| value.length<0){
	        $.mkv.myerror("Không có toa thuốc cũ nào.");
	        return false;
	    }else if(value=="1907"){
	        $.mkv.myerror("Không thể lấy toa thuốc cũ khi đã có toa thuốc.");
	        return false;
	    }
	});
}
function checkAllTT(obj) {
    var tableTT = $(obj).parents("table").find("tr");
    for (var i = 0; i < tableTT.length; i++) {
        checkXoaTT(tableTT.eq(i).find("input[type=checkbox]").val());
        if ($(obj).is(":checked")) {
            tableTT.eq(i).find("input[type=checkbox]").attr("checked", true);
            lstTT += tableTT.eq(i).find("input[type=checkbox]").val() + ",";
        } else {
            tableTT.eq(i).find("input[type=checkbox]").attr("checked", false);
        }
    }
}
function setChonTT(obj) {
   
    checkXoaTT($(obj).val());
    if ($(obj).is(":checked")) {
        lstTT += $(obj).val() + ",";
    }
  
}
function checkXoaTT(vals) {
  
    if (lstTT.indexOf(",") != -1) {
        var arrTT = lstTT.split(',');
        for (var j = 0; j < arrTT.length; j++) {
            if (arrTT[j] == vals) {
                var stemp = new RegExp(arrTT[j] + ",", 'g');
                lstTT = lstTT.replace(stemp, '');
                break;
            }

        }
    }
}
//-------------------------set chon tuy theo cls hay toa thuoc-------------------------------------------
$.mkv.runCloseTimKiem = function(obj) {
       var form = $(obj).closest(".body-div");
       var loai = "";
       if($(obj).attr("onclick").indexOf("cls") != -1){
            form = form.find("#gridTablecls");
            loai = "cls";
       }
       else if($(obj).attr("onclick").indexOf("thuoc") != -1){
            form = form.find("#gridTable");
            loai = "thuoc";
       }
      if(loai=="cls"){
        var slvack = "";
        for (var i = 0; i < $("#gridTablecls").find("tr").length; i++) {
            var idcls = $("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val();
            var sl = $("#gridTablecls").find("tr").eq(i).find("#soluong").val();
            var ck = $("#gridTablecls").find("tr").eq(i).find("#chietkhau").val();
            var idkhoachinh = $("#gridTablecls").find("tr").eq(i).find("#idkhoachinh").val();
            if ((sl > 1 || ck > 0) || (idkhoachinh != null && idkhoachinh != ""))
                slvack += "@" + idcls + "^" + sl + "^" + ck+"^"+idkhoachinh;

        }
        $("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
        $.ajax({
            type: "GET",
            dataType: "text",
            url: "ajax/khambenh_ajax3.aspx?do=GetDSCLS&listID=" + listCLS + "&IdBenhNhan=" + $("#idbenhnhan").val() + "&IdKhambenh=" + $.mkv.queryString("idkhoachinh") + "&slvack=" + slvack +"&loaidk="+$("#loaidk").val(),
            success: function(data) {
                if(data!=null && data!="" && data!="error")
                {
                   $("#tableAjax_khambenhcanlamsan").html(data);
                   tongtiencls();
                }
                $("#loadingAjax").remove();
            }
        });
      }
    else if(loai=="thuoc"){
         var slvack = "";
        for (var i = 0; i < $("#gridTable").find("tr").length; i++) {
            var idTT = $("#gridTable").find("tr").eq(i).find("#idchitietbenhnhantoathuoc").val();
            var sl = $("#gridTable").find("tr").eq(i).find("#soluongke").val();
            var idkhoachinh = $("#gridTable").find("tr").eq(i).find("#idkhoachinh").val();
            if ((sl > 1) || (idkhoachinh != null && idkhoachinh != ""))
                slvack += "@" + idTT + "^" + sl + "^" + idkhoachinh;
         
        }
        $("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
        $.ajax({
            async:false,
            cache:false,
            type: "GET",
            dataType: "text",
            url: "ajax/khambenh_ajax3.aspx?do=GetDSTT&listID=" + lstTT + "&IdBenhNhan=" + $("#idbenhnhan").val()  + "&slvack=" + slvack + "&idkhoa=" + $("#IdKhoa").val() + "&loaidk=" + $("#loaidk").val() ,
            success: function(data) {
                if(data!=null && data!="" && data!="error")
                {
                   $("#tableAjax_chitietbenhnhantoathuoc").html(data);
                }
                $("#loadingAjax").remove();
            }
        });
      }
}

//----------------------------cac function xu ly khac--------------------------------------------------------
function chuyenkhoavaravien(obj) {

    if (obj.checked == true) {
        var today = new Date();
        var gio = today.getHours();
        var phut = today.getMinutes();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();
        if (dd < 10) { dd = '0' + dd }
        if (mm < 10) { mm = '0' + mm }
        if (gio < 10) { gio = '0' + gio }
        if (phut < 10) { phut = '0' + phut }

        $("#gioravien").val(gio);
        $("#phutravien").val(phut);
        $("#TGXuatVien").val(dd + "/" + mm + "/" + yyyy);
    } else {
        $("#gioravien").val('');
        $("#phutravien").val('');
        $("#TGXuatVien").val('');
    }
}
function tinhsongayratoa()
{
    $.ajax({
        type:'GET',
        cache:false,
        url:"ajax/khambenh_ajax3.aspx?do=TinhSoNgayRaToa&iddangkykham=" + $("#iddangkykham").val()+"&loaidk=" + $("#loaidk").val()+"&songay=" + $("#songayratoa").val(),
        success:function(data)
        {
            var arrtoa = data.split('@');
            if(arrtoa[1]=="1")
                $("#ngayhentaikham").val(arrtoa[0]);
            else
            {
                $("#songayratoa").val("");
                $.mkv.myerror(arrtoa[2]);
            }
        }
    });
}
//---------------------------------------------------------------------------
function loadbenhvien(obj)
{
      $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=loadbenhvien", {
        minChars: 0,
        width: 220,
        scroll: true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            
        }, 100);
    });
}
function ChanDoansearch(obj,IsMa)
{
     $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=ChanDoansearch&IsMaICD="+IsMa+"",{
     minChars:0,
     scroll:true,
     addRow:false,
     width:900,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
        $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#idicd").val(data[1]);
        $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idicd").val(data[2]);
        $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idicdMoTa").val(data[3]);
        themdongCDPK(obj);
         setTimeout(function () {
            $("#gridTableCDPH").find("tr").next().eq($(obj).parent().parent().index()).find("#mkv_idicd").focus();
         },100);
         
     });
}
function themdongCDPK(obj)
{
     if(document.getElementById("gridTableCDPH").rows[obj.parentNode.parentNode.rowIndex + 1] == null)
        {
            var htmlPH="<tr>"
                +"<td>" + (obj.parentNode.parentNode.rowIndex + 1) + "</td>"
                +"<td><a onclick='xoaontableCDPH(this)'>Xóa</a></td>"
                +"<td><input mkv='true' id='idicd' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idicd' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,1)' value='' class='down_select'/></td>"
                +"<td><input mkv='true' id='mkv_idicdMoTa' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,0)' value='' class='down_select' style='width:98%'/></td>"
                +"<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>"
                +"</tr>";
            $("#gridTableCDPH").append(htmlPH);
         }
}
function xoaontableCDPH(control){
    if($(control).parents("table").find("tr").length < 4){
        themdongCDPK(control);
     }
    var stssmoi =$(control).parent().parent().index();
    var valueCLS = $(control).parents("table").find("tr").eq($(control).parent().parent().index()).find("#idicd").val();
          $(control).XoaRow({
             ajax:"ajax/khambenh_ajax3.aspx?do=XoaCDPH",
             valueErXoa:"Không có quyền xóa !"
     });    
    var row=$("#gridTableCDPH").find("tr");
    for(var i=stssmoi;i<row.length-1;i++){
        row[i].childNodes[0].innerHTML=i;
    }           
 }
 function ShowDSCLSTDK(obj)
 {
    $(obj).TimKiem({
       ajax:"ajax/khambenh_ajax3.aspx?do=ShowDSCLSTDK&idbenhnhan=" + $("#idbenhnhan").val() + "&idkhoa=" + $("#IdKhoa").val()
       ,title:"Danh sách đăng ký CLS tự đến"
       ,readMKV:false
       ,onlyPopup:false
       ,width:1000
       ,height:300
    });
 }
 //------------------------------can lam sang thuong quy ----------------------------------
 $.fn.rowCount = function() {
    return $('tr', $(this).find('tbody')).length;
 };
 function ChoncanlamsangThuongquy(obj)
 {
   
    $(obj).TimKiem({
        ajax:"ajax/khambenh_ajax3.aspx?do=ChonclsThuongquy"
            ,title:"Cận lâm sàng thường quy"
            ,readMKV:false
            ,onlyPopup:false
    },function(){
       /* var rowsCount=$("#gridTablecls").rowCount()-2;
        if(rowsCount >1){
            $.mkv.myerror("Đã có chỉ định cận lâm sàng rồi.");
            return false;
        }*/
        return true;
    },null);
 }
function setCSLThuongQuy(idkhoa,page)
 {
         listCLS="";
         var slvack = "";
         var ghichu="";
         for (var i = 1; i < $("#gridTablecls").find("tr").length; i++) {
            if ($.trim($("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val()).length > 0)
                listCLS += $("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val() + ",";
            var idcls = $("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val();
            var sl = $("#gridTablecls").find("tr").eq(i).find("#soluong").val();
            var ck = $("#gridTablecls").find("tr").eq(i).find("#chietkhau").val();
            var idkhoachinh = $("#gridTablecls").find("tr").eq(i).find("#idkhoachinh").val();
            var ighichu = $("#gridTablecls").find("tr").eq(i).find("#ghichu").val();
            ghichu+=ighichu+",";
            if ((sl > 1 || ck > 0) || (idkhoachinh != null && idkhoachinh != ""))
                slvack += "@" + idcls + "^" + sl + "^" + ck+"^"+idkhoachinh;
         }
         if(idkhoa == null) idkhoa = "";
         if(page == null) page = "1";
            $.mkv.dongtimkiem('default');
         $("#tableAjax_khambenhcanlamsan").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
         $.ajax({
            async:false,
             type:"GET",
             cache:false,
             url:"ajax/khambenh_ajax3.aspx?do=setCSLThuongQuy&NhomId="+idkhoa+"&page="+page 
                + "&loaidk=" + $("#loaidk").val() + "&listID="  + listCLS + "&slvack=" + slvack+ "&ghichu=" + ghichu
                + "&IdKhamBenh=" + $.mkv.queryString("idkhoachinh")
                + "&IdBenhNhan=" + $("#idbenhnhan").val(),
             success: function (value){
                     document.getElementById("tableAjax_khambenhcanlamsan").innerHTML=value;
                     $("table.jtable tr:nth-child(odd)").addClass("odd");
                     $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                     $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                      tongtiencls();
                }
         });
 }
 //--------------------------------toa thuoc mau ------------------------------------------------------------
function chonToaThuocMau(obj)
{
 $(obj).TimKiem({
        ajax:"ajax/khambenh_ajax3.aspx?do=chonToaThuocMau"
            ,title:"Toa thuốc mẫu"
            ,readMKV:false
            ,onlyPopup:false
    },function(){
        var rowsCount=$("#gridTable").rowCount()-2;
        if(rowsCount >1){
            $.mkv.myerror("Đã có chỉ định thuốc rồi.");
            return false;
        }
        return true;
    },null);   
}
function setToaThuocMau(idtoathuoc,songay,idchandoan,maicd,tenchandoan)
 {
        if(idtoathuoc == null) idtoathuoc = "";
            $.mkv.dongtimkiem('default');
        $("#tableAjax_chitietbenhnhantoathuoc").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
          $.ajax({
                 async:false,
                 type:"GET",
                 cache:false,
                 url:"ajax/khambenh_ajax3.aspx?do=setToaThuocMau&idtoathuoc="+idtoathuoc + "&idkhoa=" + $("#IdKhoa").val() + "&loaidk=" + $("#loaidk").val(),
                  success: function (value){
                         document.getElementById("tableAjax_chitietbenhnhantoathuoc").innerHTML=value;
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                         $("#songayratoa").val(songay);
                         $("#idchandoan").val(idchandoan);
                         $("#mkv_idchandoan").val(maicd);
                         $("#mkv_mota").val(tenchandoan);
                         tinhsongayratoa();
                    }
          });
 }
function checkSLTon_Grid()
{
    var msg=true;
    for(var j=1;j<$('#gridTable >tbody >tr').length;j++)
    {
        var tenthuoc=$("#gridTable").find("tr").eq(j).find("#mkv_idthuoc").val(); 
        var sl=eval($("#gridTable").find("tr").eq(j).find("#soluongke").val()); 
        var slton=eval($("#gridTable").find("tr").eq(j).find("#slton").val()); 
        var idkhoxuat=eval($("#gridTable").find("tr").eq(j).find("#idkhoxuat").val()); 
        var ischeckslton=eval($("#gridTable").find("tr").eq(j).find("#IsCheckSLTon").val());
        if(ischeckslton=="" || ischeckslton=="0") return true;
        if(sl<=0)
        {
            $.mkv.myerror("Số lượng kê " + tenthuoc + " không phù hợp");
            $("#gridTable").find("tr").eq(j).css("background-color","#f09090");
            msg=false;           
        }
        if(idkhoxuat!=null && idkhoxuat!="" && idkhoxuat!="0" && idkhoxuat!="-1" && sl>slton)
        {
            $.mkv.myerror(tenthuoc + ": không đủ tồn.");
            $("#gridTable").find("tr").eq(j).css("background-color","#f09090");
            msg=false;
        }
    }
    return msg;
}
function RealTimeSLTon()
{
 return false;
    var lstIdThuoc="";
    for(var i=1;i<$('#gridTable >tbody >tr').length -2;i++)
    {
        var idthuoc=$("#gridTable").find("tr").eq(i).find("#idthuoc").val();
        var idkho=$("#gridTable").find("tr").eq(i).find("#idkhoxuat").val();
        var IdLoaiThuoc=$("#gridTable").find("tr").eq(i).find("#DoiTuongThuocID").val();
        lstIdThuoc += "@" + idthuoc +"|" + idkho + "|" + IdLoaiThuoc  
    }
    if(lstIdThuoc !=null && lstIdThuoc !="")
    {
        $.ajax({
            async:false,
            url:"ajax/khambenh_ajax3.aspx",
            type:'get',
            dataType:"json",
            data:{
                "do":"getListSLTON",
                listThuoc:lstIdThuoc,
                idkhoa:$("#IdKhoa").val(),
                loaidk: $("#loaidk").val()
            },
            success:function(data){
                $.each(data,function(index,item){
                    for(var j=0;j<item.length;j++)
                    {
                        var slton=eval($("#gridTable").find("tr").eq(j+1).find("#slton").val());
                        $("#gridTable").find("tr").eq(j+1).find("#slton").val(item[j].SLTon);
                        $("#gridTable").find("tr").eq(j+1).find("#slton").fadeIn(3000,function(){
                            $(this).css({"color":"#ff0000","font-weight":"bold"});
                        });
                    }
                });
            }
        });
    }
   
}