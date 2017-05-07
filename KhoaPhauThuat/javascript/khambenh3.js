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
    if($.mkv.queryString("disabledCaKipMo")=="1"){
        $("#ekipmo").css("display","none");
    }
    setControlFind($.mkv.queryString("idkhoachinh"));
    $("#luu").click(function() {
        $(this).focus();
       
        $(this).Luu({
            ajax: "ajax/khambenh_ajax3.aspx?do=Luu&idkhambenhchuyenphong=" + $.mkv.queryString("idkhambenhchuyenphong") +"&disabledCaKipMo="+ $.mkv.queryString("disabledCaKipMo")
        }, function() {
            var tablegrid="gridTable";
            var thuoctrung="";
            if ($("#idbacsi").val() == "" || $("#idbacsi").val() == "0") {
                    $.mkv.myerror("Chưa chọn bác sỹ.");
                    $("#mkv_idbacsi").focus();
                return false;
            }
            if($("#PhongID").val()==null || $("#PhongID").val()==""){
                $.mkv.myerror("Vui lòng chọn phòng thực hiện");
                $("#mkv_PhongID").focus();
                return false;    
            }
             if(!$("#chuyenkhoaravien").is(":checked")){
                $.mkv.myalert("Vui lòng chọn vào thời gian lưu",2000,"info");
                 $("#chuyenkhoaravien").focus();
                return false;
             }
            if(!checkSLTon_Grid()) return false;
            for(var i=1;i<document.getElementById(tablegrid).rows.length-1;i++)
            {
                for(var j=i+1;j<document.getElementById(tablegrid).rows.length-1;j++){
                    if(document.getElementById(tablegrid).rows[i].cells[2].getElementsByTagName("input")[0].value==document.getElementById(tablegrid).rows[j].cells[2].getElementsByTagName("input")[0].value 
                    && document.getElementById(tablegrid).rows[i].cells[4].getElementsByTagName("input")[0].value==document.getElementById(tablegrid).rows[j].cells[4].getElementsByTagName("input")[0].value
                    && document.getElementById(tablegrid).rows[i].cells[8].getElementsByTagName("input")[0].checked==document.getElementById(tablegrid).rows[j].cells[8].getElementsByTagName("input")[0].checked){
                            thuoctrung+=document.getElementById(tablegrid).rows[j].cells[4].getElementsByTagName("input")[1].value + ",";
                    }
                }
            }
            if(thuoctrung.split(',')[0].length-1>0){
               //  $.mkv.myerror(thuoctrung + " trùng nhau");
              //      return false;        
            }
           return true;
        }, function(value) {
         $.LuuTable({
                ajax:"ajax/khambenh_ajax3.aspx?do=LuuTablechitietEkipBacSiMo&idkhambenh="+$.mkv.queryString("idkhoachinh"),
                tablename:"gridTable_EkipMo"
            },null,function(){
             $.LuuTable({
                ajax: "ajax/khambenh_ajax3.aspx?do=luuTablekhambenhcanlamsan&idkhambenh=" + $.mkv.queryString("idkhoachinh") + "&idbenhnhan=" + $("#idbenhnhan").val()+ "&idbacsi=" + $("#idbacsi").val() ,
                tablename: "gridTablecls"
            }, null, function() {
                  
                $.LuuTable({
                    ajax: "ajax/khambenh_ajax3.aspx?do=luuTablechitietbenhnhantoathuoc&idkhambenh=" + $.mkv.queryString("idkhoachinh") + "&idbenhnhan=" + $("#idbenhnhan").val() ,
                    tablename: "gridTable"
                },null, function() {
    
					$.ajax({
						url:"ajax/khambenh_ajax3.aspx?do=luuTongTienKham&idkhambenh=" + $.mkv.queryString("idkhoachinh"),
						cache:false,
						async:false,
						type:"GET",
						success:function(data){
							if(data != ""){
								$.mkv.myalert("Đã hoàn thành lưu phiếu.",2000,"success");
							     $("#luu").focus();
							}else
								$.mkv.myerror("Tính tổng tiền phiếu khám thất bại.");
							if(data!="1")
							   $.mkv.myalert(data,2000,"info");
						}
					});
					$("#intoathuoc_dv").focus();
                });
                
            });
        });
       });
       $("#xemctcongno").click(function(){
            window.open("../noitru_BaoCao/nvk_ChiTietCongNoBenhNhan.aspx?dkmenu=" + $.mkv.queryString("dkMenu") + "&idbenhnhan=" + $("#idbenhnhan").val() +"&idctdkk=" + $("#IdChiTietDangKyKham").val() + "&IdKhoa=" + $("#IdKhoa").val() +"&IsShowTamUng=1","_blank","location=0,menubar=0,statusbar=0,scrollbars=1");
       });
    });
     $("#ischuyenvien").click(function(){
        if($(this).is(":checked")){
            $("#mkv_idbenhvienchuyen").attr("disabled",false);
        }else{
            $("#mkv_idbenhvienchuyen").attr("disabled",true);
        }
    });
  
   
    $("#IsXuatVien").click(function(){
        if($(this).is(":checked")){
            $("#mkv_IdkhoaChuyen").attr("disabled",true);
            $("#mkv_IdChuyenPK").attr("disabled",true);
            $("#ischuyenvien").attr("disabled",true);
            $("#mkv_idbenhvienchuyen").attr("disabled",true);
            $("#xuatvien").css("display","");
        }else
        {
            
            $("#mkv_IdkhoaChuyen").attr("disabled",false);
            $("#mkv_IdChuyenPK").attr("disabled",false);
            $("#ischuyenvien").attr("disabled",false);
            $("#mkv_idbenhvienchuyen").attr("disabled",true);
            $("#xuatvien").css("display","none");
            
        }
    });
   $("#phieumoi").click(function() {
       
        window.close();
       
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
                                           }
            },
            error:function(data){
               $.mkv.myerror(data); 
            }
        });
    });
    //───────────────────────────────────────────────────────────────────────────────────────
     $("#inchidinhCLS").click(function() {
        window.open("../KhamBenh_TH/rptPhieuChiDinh.aspx?idkhambenh=" + $.mkv.queryString("idkhoachinh")+"&IsAll=0&isdvkt=0","_blank");
    });
    
        
    $("#inchidinhDV").click(function() {
        window.open("../KhamBenh_TH/rptPhieuChiDinh.aspx?idkhambenh=" + $.mkv.queryString("idkhoachinh")+"&IsAll=0&isdvkt=1","_blank");
    });

    $("#intoathuoc_dv").click(function() {
        window.open("../KhamBenh_TH/rpt_Toathuoc.aspx?IdKhamBenh=" + $.mkv.queryString("idkhoachinh")+"&IsBHYT=0&IsAll=0", '_blank', 'location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
    });
     
    
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
    $("#moi").click(function() {
        $(this).Moi();
        listCLS = "";
        loadTableAjaxchitietbenhnhantoathuoc('');
        loadTableAjaxkhambenhcanlamsan('');
    });
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
     $("#phanloai").click(function(){
            loadTableAjaxchitietbenhnhantoathuoc($.mkv.queryString("idkhoachinh"),$("#khothuocid").val());
     });
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
    var AllowXuatLai="0";
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
      //  RealTimeSLTon();
   },10000);
});
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
function idkhoxuatsearch(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idkhoxuatsearch&idkhoa=" + $("#IdKhoa").val(), {
        minChars: 0,
        width: 350,
        scroll: true,
        addRow: false,
        header:"<div style =\"width:100%;height:30px\">"
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
              $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_LoaiThuocID").focus();
        }, 100);
    });
}
function idgiuongsearch(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idgiuongsearch&idphong=" + $("#PhongID").val(), {
        minChars: 0,
        width: 350,
        scroll: true,
        addRow: false,
        header:"<div style =\"width:100%;height:30px\">"
                          + "<div algin='left' style=\"width:25%;color:white;font-weight:bold;float:left; font-size:14px;\" >Giường code</div>"
                          + "<div style=\"width:55%;color:white;font-weight:bold;float:left; font-size:14px; \" >Loại giường</div>"
               + "</div>",
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
            $(obj).val(data[1]);
             $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[2]);
        setTimeout(function() {
             $(obj).focus();
        }, 100);
    });
}
function idvaitrosearch(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idvaitrosearch", {
        minChars: 0,
        width: 450,
        scroll: true,
        addRow: true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
              $("#gridTable_EkipMo").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
              $("#gridTable_EkipMo").find("tr").next().eq($(obj).parent().parent().index()).find("#mkv_idnhanvien").focus();
        }, 100);
    });
}
function idnhanviensearch(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idnhanviensearch", {
        minChars: 0,
        width: 450,
        scroll: true,
        addRow: false,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
              $("#gridTable_EkipMo").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
              $("#gridTable_EkipMo").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idvaitro").focus();
        }, 100);
    });
}
function tinhbmi()
{
  if($("#CANNANG").val()=="" || $("#CANNANG").val()=="0" ||$("#CHIEUCAO").val()=="" ||$("#CHIEUCAO").val()=="0")
    return;
  $("#BMI").val(custRound(10000*($("#CANNANG").val()/($("#CHIEUCAO").val()*$("#CHIEUCAO").val())),1));
}function custRound(x,places) {  return (Math.round(x*Math.pow(10,places)))/Math.pow(10,places)}function setControlFind(idkhoatimkiem) {

    $.mkv.queryString("temps", "");
    $.mkv.removeQueryString("temps");
    //////
    if (idkhoatimkiem != null && idkhoatimkiem != "") {
        $.BindFind({ ajax: "ajax/khambenh_ajax3.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem }, null, function() {
            if($("#IdKhoa").val()=="1"){
               $("#xuatthuoc").css("display","none");
            }
            $("#khothuocid").DropList({ajax:"ajax/khambenh_ajax3.aspx?do=getkhoxuat&idkhoa=" + $("#IdKhoa").val(),defaultVal:'-Tất cả- '});
            $("#loadingAjax").remove();
            loadTableAjaxchitietbenhnhantoathuoc($.mkv.queryString("idkhoachinh"),$("#khothuocid").val());
            loadTableAjaxkhambenhcanlamsan($.mkv.queryString("idkhoachinh"));
            loadTableAjaxchandoanphoihop($.mkv.queryString("idkhoachinh"));
            loadTableAjaxchitietEkipMo($.mkv.queryString("idkhoachinh"));
            $("#_luu").click();
            $("#TENKHOA").attr("disabled","disabled");
            $("#TENPHONG").attr("disabled","disabled");
             if($("#IsXuatVien").is(":checked")){
                 $("#mkv_IdkhoaChuyen").attr("disabled",true);
                    $("#mkv_IdChuyenPK").attr("disabled",true);
                    $("#ischuyenvien").attr("disabled",true);
                    $("#mkv_idbenhvienchuyen").attr("disabled",true);
                    $("#xuatvien").css("display","");
            }
           /* if($.mkv.queryString("disabledCaKipMo")=="1"){
                $("#IsXuatVien").attr("disabled",true);
            }*/       
        });
    } else if ($.mkv.queryString("idkhambenhchuyenphong") != null && $.mkv.queryString("idkhambenhchuyenphong") != "") {
        $.BindFind({ ajax: "ajax/khambenh_ajax3.aspx?do=setTimKiem_KhamMoiChuyenPhong"
                        + "&idkhambenhchuyenphong=" + $.mkv.queryString("idkhambenhchuyenphong")
        }, null, function(value) {
            if($("#IdKhoa").val()=="1"){
               $("#xuatthuoc").css("display","none");
            }
             $("#khothuocid").DropList({ajax:"ajax/khambenh_ajax3.aspx?do=getkhoxuat&idkhoa=" + $("#IdKhoa").val(),defaultVal:'-Tất cả- '});
            $("#loadingAjax").remove();
              loadTableAjaxchitietbenhnhantoathuoc($.mkv.queryString("idkhoachinh"),$("#khothuocid").val());
            loadTableAjaxkhambenhcanlamsan($.mkv.queryString("idkhambenhchuyenphong"),null,1);
            loadTableAjaxchandoanphoihop($.mkv.queryString("idkhambenhchuyenphong"));
            loadTableAjaxchitietEkipMo($.mkv.queryString("idkhoachinh"));
            $("#_luu").click();
          
        });
    }
    else {
        $.BindFind({ ajax: "ajax/khambenh_ajax3.aspx?do=setTimKiem_KhamMoi&idchitietdangkykham=" + $.mkv.queryString("idchitietdangkykham")
                     + "&idbenhnhan=" + $.mkv.queryString("idbenhnhan")
        }, null, function() {
            if($("#IdKhoa").val()=="1"){
               $("#xuatthuoc").css("display","none");
            }
            $("#khothuocid").DropList({ajax:"ajax/khambenh_ajax3.aspx?do=getkhoxuat&idkhoa=" + $("#IdKhoa").val(),defaultVal:'-Tất cả- '});
            $("#loadingAjax").remove();
            loadTableAjaxchitietbenhnhantoathuoc($.mkv.queryString("idkhoachinh"),$("#khothuocid").val());
            loadTableAjaxkhambenhcanlamsan($.mkv.queryString("idkhoachinh"));
            loadTableAjaxchandoanphoihop($.mkv.queryString("idkhoachinh"));
            loadTableAjaxchitietEkipMo($.mkv.queryString("idkhoachinh"));
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
function xoaontable_ekipmo(control) {
    var stssmoi =$(control).parent().parent().index();
    $(control).XoaRow({
        ajax: "ajax/khambenh_ajax3.aspx?do=XoaBacSiDieuTri"
    });
     var row=$("#gridTable_EkipMo").find("tr");
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
function loadTableAjaxchitietbenhnhantoathuoc(idkhoachinh,idkho, page) {
    if (idkhoachinh == null) idkhoachinh = "";
    if (page == null) page = "1";
    $("#tableAjax_chitietbenhnhantoathuoc").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>');
    $.ajax({
        aysnc:true,
        type: "GET",
        cache: false,
        url: "ajax/khambenh_ajax3.aspx?do=loadTablechitietbenhnhantoathuoc&idkhambenh=" + idkhoachinh + "&page=" + page + "&idkhoa=" + $("#IdKhoa").val() + "&idkho=" + idkho + "&loaidk=" + $("#loaidk").val(),
        success: function(value) {
            $("#tableAjax_chitietbenhnhantoathuoc").html(value);

        }
    });
}
function loadTableAjaxchitietEkipMo(idkhoachinh, page) {
    if (idkhoachinh == null) idkhoachinh = "";
    if (page == null) page = "1";
    $("#tableAjax_EkipMo").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>');
    $.ajax({
        type: "GET",
        cache: false,
        url: "ajax/khambenh_ajax3.aspx?do=loadTableAjaxchitietEkipMo&idkhambenh=" + idkhoachinh + "&page=" + page + "&idkhoa=" + $("#IdKhoa").val(),
        success: function(value) {
            $("#tableAjax_EkipMo").html(value);
        }
    });
}
function loadTableAjaxkhambenhcanlamsan(idkhoachinh, page,IsChuyenPhong) {
    if (idkhoachinh == null) idkhoachinh = "";
    if (page == null) page = "1";
     if (IsChuyenPhong == null) IsChuyenPhong = "0";
    $("#tableAjax_khambenhcanlamsan").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>');
    $.ajax({
        type: "GET",
        cache: false,
        url: "ajax/khambenh_ajax3.aspx?do=loadTablekhambenhcanlamsan&idkhambenh=" + idkhoachinh + "&page=" + page+"&IsChuyenPhong="+IsChuyenPhong + "&loaidk=" + $("#loaidk").val(),
        success: function(value) {
            $("#tableAjax_khambenhcanlamsan").html(value);
            tongtiencls();
        }
    });
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
function loadTableAjaxlistbacsi(idkhoa, page) {
    if (idkhoa == null) idkhoa = "";
    if (page == null) page = "1";
    $("#tableAjax_listbacsi").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>');
    $.ajax({
        type: "GET",
        cache: false,
        url: "ajax/khambenh_ajax3.aspx?do=loadTablelistbacsi&idkhambenh=" + idkhoa + "&page=" + page,
        success: function(value) {
            $("#tableAjax_listbacsi").html(value);
        }
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
         $(obj).val(data[1]);
         if (loaichuandoan == "truocmo") {
            $("#idchandoan").val(data[3]);
            $("#mkv_mota").val(data[2]);
            $("#mkv_idchandoan").val(data[1]);            
        }else {
            $("#ketluan1").val(data[3]);
            $("#mkv_mota1").val(data[2]);
            $("#mkv_ketluan1").val(data[1]);              
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
         $(obj).val(data[1]);
         $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[3]);  
         if (loaichuandoan == "truocmo") {
             $("#idchandoan").val(data[3]);
             $("#mkv_mota").val(data[2]);
             
         }else{
             $("#ketluan1").val(data[3]);
             $("#mkv_mota1").val(data[2]);
         }
        setTimeout(function() {
            $("#mkv_ketluan1").focus();
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
        width: 140,
        scroll: true,
        cache: false,
        addRow: false,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idthuoc").focus();
        }, 100);
    });
}
function doituongthuocidsearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=doituongthuocidsearch", {
        minChars: 0,
        width: 140,
        scroll: true,
        cache: false,
        addRow: false,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_cateid").focus();
        }, 100);
    });
}
function iddvtsearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=iddvtsearch", {
        minChars: 0,
        width: 100,
        scroll: true,
        cache: false,
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
        cache: false,
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
        cache: false,
        addRow: false,
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
          $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idthuoc").focus();
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
        cache: false,
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
        cache: false,
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
function idphuongphapvocamsearch(obj){
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idphuongphapvocamsearch", {
        minChars: 0,
        scroll: true,
        cache: false,
        addRow: true,
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
function chuyenhuong(obj)
{
     $("#gridTable").find("tr").next().eq($(obj).parent().parent().index()).find("#mkv_idthuoc").focus();
}
function idthuocsearch(obj) {

    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idthuocsearch&idbenhnhan=" + $("#idbenhnhan").val() + "&loaithuocid=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#LoaiThuocID").val() + "&idkho=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idkhoxuat").val() + "&cateid=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#cateid").val() + "&IsTuTruc=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IsTuTruc").is(":checked") + "&IdKhoa=" + $("#IdKhoa").val() , {
        minChars: 0,
        width: 900,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                          + "<div algin='left' style=\"width:8%;color:white;font-weight:bold;float:left;\" >Tên thuốc</div>"
                          + "<div style=\"width:33%;color:white;font-weight:bold;float:left; text-algin:center;\" >Công thức</div>"
                          + "<div style=\"width:10%;color:white;font-weight:bold;float:left\" >Đường dùng</div>"
                          + "<div style=\"width:10%;color:white;font-weight:bold;float:left\" >ĐVT</div>"
                          + "<div style=\"width:9%;color:white;font-weight:bold;float:left\" >Giá</div>"
                          + "<div style=\"width:8%;color:white;font-weight:bold;float:left\" >SL tồn</div>"
                          + "<div style=\"width:9%;color:white;font-weight:bold;float:left\" >?BH</div>"
                          + "<div style=\"width:10%;color:white;font-weight:bold;float:left\" >?Thuốc BV</div>"
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
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_Save").attr("checked",true);
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
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#slton").val(data[6]);
         setTimeout(function() {
                $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluongke").focus();
         }, 100);
    });
     
}
function congthucsearch(obj) {

    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=congthucsearch&idbenhnhan=" + $("#idbenhnhan").val() + "&loaithuocid=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#DoiTuongThuocID").val() + "&idkho=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idkhoxuat").val() +"&cateid=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#cateid").val() + "&IsTuTruc=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IsTuTruc").is(":checked") + "&IdKhoa=" + $("#IdKhoa").val() , {
        minChars: 0,
        width: 830,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                          + "<div algin='left' style=\"width:8%;color:white;font-weight:bold;float:left;\" >Tên thuốc</div>"
                          + "<div style=\"width:33%;color:white;font-weight:bold;float:left; text-algin:left;\" >Công thức</div>"
                          + "<div style=\"width:10%;color:white;font-weight:bold;float:left\" >Đường dùng</div>"
                          + "<div style=\"width:10%;color:white;font-weight:bold;float:left\" >ĐVT</div>"
                          + "<div style=\"width:9%;color:white;font-weight:bold;float:left\" >Giá</div>"
                          + "<div style=\"width:8%;color:white;font-weight:bold;float:left\" >SL tồn</div>"
                          + "<div style=\"width:6%;color:white;font-weight:bold;float:left\" >?BH</div>"
                          + "<div style=\"width:8%;color:white;font-weight:bold;float:left\" >?Thuốc BV</div>"
                          + "</div>",
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idthuoc").val(data[4]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val(data[5]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idcachdung").val(data[3]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_iddvt").val(data[2]);               
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_iddvdung").val(data[2]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(data[5]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_congthuc").val(data[7]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#isbh").val(data[8]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#iddvt").val(data[9]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#iddvdung").val(data[9]);
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idcachdung").val(data[10]);     
      
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluongke").val("");
          setTimeout(function() {
                $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluongke").focus();
         }, 100);
    });
    
}
$.mkv.afterThemDong = function(tablename, dongso) {
    if (tablename[0].id == "gridTable") {
        //xac dinh select row below
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#idkhoxuat").val($("#"+tablename[0].id).find("tr").eq(dongso).find("#idkhoxuat").val());
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#mkv_idkhoxuat").val($("#"+tablename[0].id).find("tr").eq(dongso).find("#mkv_idkhoxuat").val());
          $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#LoaiThuocID").val($("#"+tablename[0].id).find("tr").eq(dongso).find("#LoaiThuocID").val());
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#mkv_LoaiThuocID").val($("#"+tablename[0].id).find("tr").eq(dongso).find("#mkv_LoaiThuocID").val());
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#DoiTuongThuocID").val($("#"+tablename[0].id).find("tr").eq(dongso).find("#DoiTuongThuocID").val());
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#mkv_DoiTuongThuocID").val($("#"+tablename[0].id).find("tr").eq(dongso).find("#mkv_DoiTuongThuocID").val());
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#ishaophi").attr("checked",true);
        //end xac dinh 
        $("#" + tablename[0].id).find("tr").eq(dongso + 1).find("#cachdung").attr("disabled", true);
        $("#" + tablename[0].id).find("tr").eq(dongso + 1).find("#isngay").attr("checked", true);
       
    }
     if (tablename[0].id == "gridTable_xk") {
        //xac dinh select row below
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#idkhoxuat").val($("#"+tablename[0].id).find("tr").eq(dongso).find("#idkhoxuat").val());
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#mkv_idkhoxuat").val($("#"+tablename[0].id).find("tr").eq(dongso).find("#mkv_idkhoxuat").val());
          $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#LoaiThuocID").val($("#"+tablename[0].id).find("tr").eq(dongso).find("#LoaiThuocID").val());
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#mkv_LoaiThuocID").val($("#"+tablename[0].id).find("tr").eq(dongso).find("#mkv_LoaiThuocID").val());
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#DoiTuongThuocID").val($("#"+tablename[0].id).find("tr").eq(dongso).find("#DoiTuongThuocID").val());
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#mkv_DoiTuongThuocID").val($("#"+tablename[0].id).find("tr").eq(dongso).find("#mkv_DoiTuongThuocID").val());
        $("#"+tablename[0].id).find("tr").eq(dongso+1).find("#ishaophi").attr("checked",true);
        //end xac dinh 
        $("#" + tablename[0].id).find("tr").eq(dongso + 1).find("#cachdung").attr("disabled", true);
        $("#" + tablename[0].id).find("tr").eq(dongso + 1).find("#isngay").attr("checked", true);
       
    }
}
function IdkhoaChuyenSearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=IdkhoaChuyenSearch", {
        minChars: 0,
        width: 150,
        scroll: true,
        header:false,
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
        width: 150,
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
        width: 150,
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
                $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_save").attr("checked",true);
                $(obj).parent().parent().css("background-color","");
            }else{
                $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_save").attr("disabled",true);
                $(obj).parent().parent().css("background-color","#CAE3FF");
            }
            $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#chietkhau").val("0");
            $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
            thanhtiencls(obj);
            tongtiencls();
        }
        setTimeout(function() {
             $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#soluong").focus();
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
function loadlistbacsi(obj) {
 
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
      
         $("#tableAjax_listbacsi").append("<div style='text-align:left; padding-left:30px;float:left;width:500px;height:30px'>"
                        + "<a style='cursor:pointer' onclick='$(this).parent().remove();'>Xoá--</a>"
                            + "<input type='hidden' mkv='true' id='idbacsidieutri' value='" + data[1] + "' />"
                            + " "+ data[0]
                        + "</div>");
         $(obj).val("");
       
        setTimeout(function() {
            $(obj).focus();
        }, 100);
      
    });
   
}
function loadlistphongmo(obj){
   $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=loadlistphongmo&idkhoa=" + $("#IdKhoa").val(), {
        minChars: 0,
        width: 160,
        scroll: true,
        cache:true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            $("#mkv_giuongid").focus();
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


function tongtiencls()
{
    var tablegrid="gridTablecls";   
    var tongtien=0;
    for(var i=1;i<document.getElementById(tablegrid).rows.length-1;i++)
    {
    try{
        if(typeof eval(document.getElementById(tablegrid).rows[i].cells[7].getElementsByTagName("input")[0].value.replace(/\$|\,/g,''))!='undefined')
             tongtien += eval(document.getElementById(tablegrid).rows[i].cells[7].getElementsByTagName("input")[0].value.replace(/\$|\,/g,''));
        }catch(ex){}
    }
    document.getElementById(tablegrid).rows[document.getElementById(tablegrid).rows.length-1].cells[2].innerText = formatCurrency(tongtien).split(".")[0];
}

function thanhtiencls(obj) {
    var tientruocck = eval($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val()) * eval($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val());
    $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(tientruocck);
}
function thanhtiengiuong(obj) {
    var thanhtien = eval($("#gridTablegiuong").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val()) * eval($("#gridTablegiuong").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val());
    $("#gridTablegiuong").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(thanhtien);
}
//xu ly toa thuoc cu
function getNgayRaToa(control)
{
   $.ajax({
        type:"GET",
        url:"ajax/khambenh_ajax3.aspx?do=getNgayRaToa&idbenhnhan=" + $("#idbenhnhan").val(),
        cache:false,
        success:function(value)
        {
           if(value!="" && value!=null){
			             if ($("#divTimKiem").length == 0) {
		                    $("<div id=\"divTimKiem\" ondblclick='$.mkv.fullscreens(this);' onmove=\"$.mkv.scrollyactive('" + $(control).attr("id") + "')\" onkeyup=\"$.mkv.eventesc(this,'" + $(control).attr("id") + "');\" />").css({ 'background': '#efefef', 'margin': 'auto', 'top': '0%', 'left': '15%', 'position': 'fixed', 'display': 'none', 'border': '1px solid #4297d7', 'width': '950px', 'height': '330px', 'padding': '0px 2px 30px 0px', 'z-index': '5000' }).appendTo(document.body);
		                        $("#divTimKiem").animate({ height: 'show', right: '+100', top: '+100', opacity: 'show' }, 'slow').draggable({ handle: '#divTimKiemTitle' }).resizable();
		                        $("<p id='divTimKiemTitle' />").css({ 'border': '1px solid #fcfdfd', 'background': '#2191c0 url(../images/ui-bg_gloss-wave_75_2191c0_500x100.png) 50% 50% repeat-x', 'color': '#eaf5f7', 'cursor': 'move', 'font-weight': 'bold', 'float': 'left', 'width': '100%', 'padding': '0px 0px 3px 0px','margin':'0' }).html("&nbsp;&nbsp;&nbsp;"  + "Danh sách toa thuốc cũ").appendTo("#divTimKiem");
		                        $("<p onscroll=\"$.mkv.scrollyactive('" + $(control).attr("id") + "')\" id=\"divSetTimKiem\" />").css({ 'background': '#fff', 'width': '99.5%', 'height': '97%', 'float': 'right', 'margin-top': '0px', 'overflow': 'scroll', 'text-align': 'center', 'border': '1px solid #cfcfcf' }).appendTo("#divTimKiem");
		                        $("<img onclick=\"$.mkv.dongtimkiem('" + $(control).attr("id") + "');\" src=\"../images/close.gif\" />").css({ 'float': 'right', 'cursor': 'pointer', 'padding-right': '5px', 'top': '2px', 'right': '0', 'position': 'absolute' }).appendTo("#divTimKiemTitle");
	                        }
				        $("#divSetTimKiem").html(value);
				            if ($("#divSetTimKiem").find("table").find("tr").length < 3) $("#divSetTimKiem").find("table").find("tr").eq(1).click();
				       
				        
            }   
        },
        error:function(data)
        {
            $.mkv.closeDivTimKiem();
              if (data.responseText.length) 
                $.mkv.myerror(data.responseText);
        }
   });
}

//  xu ly danh sach CLS
var listCLS = "";
function ChonCLS(obj, idnhom, idpkb) {
    if (idpkb == null)
        listCLS = "";
    for (var i = 1; i < $("#gridTablecls").find("tr").length; i++) {
        if ($.trim($("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val()).length > 0)
            listCLS += $("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val() + ",";
    }
    if (idpkb == null)
        idpkb = 0;
    $(obj).TimKiem({
        ajax: "ajax/khambenh_ajax3.aspx?do=ChonCLS&listID=" + listCLS + "&idpkb=" + idpkb + "&IdBenhNhan=" + $("#idbenhnhan").val()+"&loaidk="+$("#loaidk").val(), readMKV: false,height:"350",width:"1000"
       
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
$.mkv.runCloseTimKiem = function() {

    var slvack = "";
    for (var i = 0; i < $("#gridTablecls").find("tr").length; i++) {
        var idcls = $("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val();
        var sl = $("#gridTablecls").find("tr").eq(i).find("#soluong").val();
        var ck = $("#gridTablecls").find("tr").eq(i).find("#chietkhau").val();
        var idkhoachinh = $("#gridTablecls").find("tr").eq(i).find("#idkhoachinh").val();
        if ((sl > 1 || ck > 0) || (idkhoachinh != null && idkhoachinh != ""))
            slvack += "@" + idcls + "^" + sl + "^" + ck+"^"+idkhoachinh;

    }
    var idkhambenh = "";
    if ($.mkv.queryString("idkhoachinh") != "")
        idkhambenh = $.mkv.queryString("idkhoachinh");
    else
        idkhambenh = $.mkv.queryString("idkhoachinh");

    $("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
    $.ajax({
        type: "GET",
        dataType: "text",
        url: "ajax/khambenh_ajax3.aspx?do=GetDSCLS&listID=" + listCLS + "&IdBenhNhan=" + $("#idbenhnhan").val() + "&IdKhambenh=" + idkhambenh + "&slvack=" + slvack +"&loaidk="+$("#loaidk").val(),
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
        url:"ajax/khambenh_ajax3.aspx?do=TinhSoNgayRaToa&songay=" + $("#songayratoa").val(),
        success:function(data)
        {
            $("#ngayhentaikham").val(data);
        }
    });
}
//  xu ly danh sach TT
var lstTT = "";
function ChonTT(obj, idkb) {
    if (idkb == null)
        lstTT = "";
    for (var i = 1; i < $("#gridTable").find("tr").length; i++) {
        if ($.trim($("#gridTable").find("tr").eq(i).find("#idchitietbenhnhantoathuoc").val()).length > 0)
            lstTT += $("#gridTable").find("tr").eq(i).find("#idchitietbenhnhantoathuoc").val() + ",";
    }
    if (idkb == null)
        idkb = 0;
        	
		$.ajax({
				type: "GET",
				cache: false,
				dataType: "text",
				url:  "ajax/khambenh_ajax3.aspx?do=ChonTT&listID=" + lstTT + "&idkb=" + idkb + "&IdBenhNhan=" + $("#idbenhnhan").val() + "&idkhambenh=" + $.mkv.queryString("idkhoachinh"),
				success: function(value) {
				    if(value!="" && value !=null && value !="1907"){
				    
					    if ($("#divTimKiem").length == 0) {
			                $("<div id=\"divTimKiem\" ondblclick='$.mkv.fullscreens(this);' onmove=\"$.mkv.scrollyactive('" + $(obj).attr("id") + "')\" onkeyup=\"$.mkv.eventesc(this,'" + $(obj).attr("id") + "');\" />").css({ 'background': '#efefef', 'margin': 'auto', 'top': '20%', 'left': '15%', 'position': 'fixed', 'display': 'none', 'border': '1px solid #4297d7', 'width': "950px", 'height': "350px", 'padding': '0px 2px 30px 0px', 'z-index': '5000' }).appendTo(document.body);
			                $("#divTimKiem").animate({ height: 'show', right: '+100', top: '+200', opacity: 'show' }, 'slow').draggable({ handle: '#divTimKiemTitle' }).resizable();
			                $("<p id='divTimKiemTitle' />").css({ 'border': '1px solid #fcfdfd', 'background': '#2191c0 url(../images/ui-bg_gloss-wave_75_2191c0_500x100.png) 50% 50% repeat-x', 'color': '#eaf5f7', 'cursor': 'move', 'font-weight': 'bold', 'float': 'left', 'width': '100%', 'padding': '2px 0px 3px 0px' }).html("&nbsp;&nbsp;&nbsp;" + "Danh sách toa thuốc cũ").appendTo("#divTimKiem");
			                $("<p onscroll=\"$.mkv.scrollyactive('" + $(obj).attr("id") + "')\" id=\"divSetTimKiem\" />").css({ 'background': '#fff', 'width': '99.5%', 'height': '97%', 'float': 'right', 'margin-top': '-11px', 'overflow': 'scroll', 'text-align': 'center', 'border': '1px solid #cfcfcf' }).appendTo("#divTimKiem");
			                $("<img onclick=\"closeTimKiem('" + $(obj).attr("id") + "');\" src=\"../images/close.gif\" />").css({ 'float': 'right', 'cursor': 'pointer', 'padding-right': '5px', 'top': '2px', 'right': '0', 'position': 'absolute' }).appendTo("#divTimKiemTitle");
		                }
					    $("#divSetTimKiem").html(value);
					    if ($("#divSetTimKiem").find("table").find("tr").length < 3) $("#divSetTimKiem").find("table").find("tr").eq(1).click();
				      }
				      if(value=="1907"){
                       $.mkv.myalert("Không thể lấy toa thuốc cũ khi đã có thuốc rồi",2000,"info");
                    }
				},
				error: function(data) {
					$.mkv.closeDivTimKiem();
					if (data.responseText.length) $.mkv.myerror(data.responseText);
				    $.mkv.myalert("Không có toa thuốc cũ nào",2000,"info");
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
closeTimKiem= function(control) {
    $("#divTimKiem").animate({ top: '1000', left: '0', opacity: 'hide' }, 'slow', function() { $(this).remove(); });
 
    runCloseTimKiem1();
}
runCloseTimKiem1 = function() {
   
    var slvack = "";
    for (var i = 0; i < $("#gridTable").find("tr").length; i++) {
        var idTT = $("#gridTable").find("tr").eq(i).find("#idchitietbenhnhantoathuoc").val();
        var sl = $("#gridTable").find("tr").eq(i).find("#soluongke").val();
        var idkhoachinh = $("#gridTable").find("tr").eq(i).find("#idkhoachinh").val();
        if ((sl > 1) || (idkhoachinh != null && idkhoachinh != ""))
            slvack += "@" + idTT + "^" + sl + "^" + idkhoachinh;
     
    }
    
    var idkhambenh = "";
    if ($.mkv.queryString("idkhoachinh") != "")
        idkhambenh = $.mkv.queryString("idkhoachinh");
    else
        idkhambenh = $.mkv.queryString("idkhoachinh");
   
    $("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
    $.ajax({
        async:false,
        cache:false,
        type: "GET",
        dataType: "text",
        url: "ajax/khambenh_ajax3.aspx?do=GetDSTT&listID=" + lstTT + "&IdBenhNhan=" + $("#idbenhnhan").val()  + "&slvack=" + slvack + "&idkhoa=" + $("#IdKhoa").val() ,
        success: function(data) {
            if(data!=null && data!="" && data!="error")
            {
               $("#tableAjax_chitietbenhnhantoathuoc").html(data);
            }
            $("#loadingAjax").remove();
        }
    });
}
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
function checkslton(obj)
{
   var slton=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#slton").val();
   if(eval($(obj).val())>eval(slton)){
      $.mkv.myerror("Số lượng không được > " + slton);
        $("#luu").attr("disabled",true);
        $("#_luu").attr("disabled",true);
      $(obj).focus();
      return false;  
   }
   else
   {
     $("#luu").attr("disabled",false);
         $("#_luu").attr("disabled",false);
      $("#gridTable").find("tr").next().eq($(obj).parent().parent().index()).find("#mkv_IdThuoc").focus();
   }
}
function ShowTinhTienGiuong(obj)
{
    var idbenhnhan= $("#idbenhnhan").val();
    var IdChiTietDangKyKham= $("#IdChiTietDangKyKham").val();
    var IdKhoa= $("#IdKhoa").val();
    window.open("../noitru/nvk_TinhTienGiuongBenh.aspx?dkmenu=khoaphauthuat&idbenhnhan="+idbenhnhan+"&idctdkk="+IdChiTietDangKyKham+"&IdKhoa="+IdKhoa+"");
}

function idthuocsearch_xk(obj,TypeSearch) {
    var LoaiThuocID=$("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#DoiTuongThuocID").val();
    if(LoaiThuocID==null || LoaiThuocID=="") LoaiThuocID="1";
    var TenLoaiThuoc="thuốc";
    if(LoaiThuocID=="2")  TenLoaiThuoc="hoá chất";
    if(LoaiThuocID=="3")  TenLoaiThuoc="dụng cụ";
    if(LoaiThuocID=="4")  TenLoaiThuoc="VTYT";
    
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idthuocsearch&idbenhnhan=" + $("#idbenhnhan").val() 
     + "&loaithuocid=" + LoaiThuocID
     + "&idkho=" + $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#idkhoxuat").val() 
     + "&cateid=" + $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#cateid").val() 
     + "&IsTuTruc=" + $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#IsTuTruc").is(":checked")
     + "&IdKhoa=" + $("#IdKhoa").val()+"&TypeSearch="+TypeSearch 
     + "&loaidk=" + $("#loaidk").val(), {
        minChars: 0,
        width: 930,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                          + "<div algin='left' style=\"width:8%;color:white;font-weight:bold;float:left;\" >"+TenLoaiThuoc+"</div>"
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
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val(data[5]);
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idcachdung").val(data[3]);
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#mkv_iddvt").val(data[2]);
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#mkv_iddvdung").val(data[2]);
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(data[5]);
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#mkv_congthuc").val(data[7]);
        if(data[8]=="True"){
            $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_save").attr("checked",true);
            $(obj).parent().parent().css("background-color","");
        }else{
            $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_save").attr("disabled",true);
            $(obj).parent().parent().css("background-color","#CAE3FF");
        }
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#iddvt").val(data[9]);
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#iddvdung").val(data[9]);
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#idcachdung").val(data[10]);
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#idkho").val(data[11]);
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#soluongke").val("");
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idthuoc").val(data[4]);
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#idthuoc").val(data[1]);
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#SLTON").val(data[6]);
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#IsCheckSLTon").val(data[12]);
         setTimeout(function() {
                $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#soluongke").focus();
         }, 100);
    });
     
}

function loaithuocidsearch_xk(obj) {
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=loaithuocidsearch", {
        minChars: 0,
        width: 140,
        scroll: true,
        cache: false,
        addRow: false,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idthuoc").focus();
        }, 100);
    });
}
function idkhoxuatsearch_xk(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idkhoxuatsearch_xk&idkhoa=" + $("#IdKhoa").val()  + "&isxuatvien=" + $("#IsXuatVien").is(":checked"), {
        minChars: 0,
        width: 350,
        scroll: true,
        addRow: false,
        header:"<div style =\"width:100%;height:30px\">"
                          + "<div algin='left' style=\"width:15%;color:white;font-weight:bold;float:left; font-size:14px;\" >Mã kho</div>"
                          + "<div style=\"width:65%;color:white;font-weight:bold;float:left; font-size:14px; \" >Tên kho</div>"
               + "</div>",
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
            $(obj).val(data[3]);
              $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
              $("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#mkv_DoiTuongThuocID").focus();
        }, 100);
    });
}
function ChanDoansearch(obj,IsMa)
{
     $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=ChanDoanSearch&IsMaICD="+IsMa+"",{
     minChars:0,
     scroll:true,
     addRow:false,
     width:600,
     header:false,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
        $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#idicd").val(data[1]);
        $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idicd").val(data[2]);
        $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idicdMoTa").val(data[3]);
        themdongCDPK(obj);
         setTimeout(function () {
            $("#gridTableCDPH_xk").find("tr").next().eq($(obj).parent().parent().index()).find("#mkv_idicd").focus();
         },100);
         
     });
}
function themdongCDPK(obj)
{
     if(document.getElementById("gridTableCDPH_xk").rows[obj.parentNode.parentNode.rowIndex + 1] == null)
        {
            var htmlPH="<tr>"
                +"<td>" + (obj.parentNode.parentNode.rowIndex + 1) + "</td>"
                +"<td><a onclick='xoaontableCDPH(this)'>Xóa</a></td>"
                +"<td><input mkv='true' id='idicd' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idicd' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,1)' value='' class='down_select' style='width:90%'/></td>"
                +"<td><input mkv='true' id='mkv_idicdMoTa' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,0)' value='' class='down_select' style='width:95%'/></td>"
                +"<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>"
                +"</tr>";
            $("#gridTableCDPH_xk").append(htmlPH);
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
    var row=$("#gridTableCDPH_xk").find("tr");
    for(var i=stssmoi;i<row.length-1;i++){
        row[i].childNodes[0].innerHTML=i;
    }           
}
function chandoanravien(obj,loai)
{
     $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=chandoanravien" + "&loai=" + loai, {
        minChars: 0,
        scroll: true,
        width:600,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:10%;color:white;float:left; font-size:12px;text-algin:left;\" >Mã ICD</div>"
                      + "<div style=\"width:80%;color:white;float:left;font-size:12px;\" >Mô tả</div>"
                  + "</div>",
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
         $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[3]);  
         $("#idicd_ravien").val(data[1]);
         if (loai == "maicd") {
             $("#mkv_mota_ravien").val(data[3]);
                 $(obj).val(data[2]);
         }else{
             $("#mkv_maicd_ravien").val(data[2]);
                 $(obj).val(data[3]);
         }
        setTimeout(function() {
            $(obj).focus();
        }, 100);
    });
}
 function kiemtraton(obj)
 {
       var  IsCheckSLTon=$("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#IsCheckSLTon").val( );
       var  SLTON=$("#gridTable_xk").find("tr").eq($(obj).parent().parent().index()).find("#SLTON").val();
       var SLKe=$(obj).val();
       if(IsCheckSLTon==""||IsCheckSLTon=="0") return false;
       if(SLKe==""||SLKe=="0") return false;
       if(eval(SLKe)>eval( SLTON))
        {
            $.mkv.myerror("Số lượng kê không vượt quá số lượng tồn");      
            $(obj).val("0");
            $(obj).focus();
        }
 }
function ShowXuatVien(obj)
{
    var idkhambenhgoc=$.mkv.queryString("idkhoachinh");
    if(idkhambenhgoc==null && idkhambenhgoc=="")
    {
        $.mkv.myalert("Vui lòng lưu phiếu khám",2000,"info");
       return false;
    }
    $(obj).TimKiem({
        ajax:"ajax/khambenh_ajax3.aspx?do=ShowXuatVien&idkhambenhgoc=" + idkhambenhgoc
        ,width:1200
        ,title:"Bệnh nhân xuất viện"
        ,height:600
    });
}
 function XuatVien(control)
 {
    $(control).Luu({
        ajax:"ajax/khambenh_ajax3.aspx?do=LuuXuatVien"
            + "&idbenhnhan=" + $("#idbenhnhan").val()
            + "&idchitietdangkykham=" + $("#IdChiTietDangKyKham").val()
            + "&idkhoa=" + $("#IdKhoa").val()
        ,Frame:".xuatvien"
    },function(){
        if($.trim($("#idicd_ravien").val())==""){
            $.mkv.myerror("Vui lòng cho biết chẩn đoán ra viện.");
            $("#mkv_maicd_ravien").focus();
            return false;
        }
        return true;
    },function(value){
            $("#idxuatkhoa").val(value);
                $.LuuTable({
                    ajax:"ajax/khambenh_ajax3.aspx?do=LuuChanDoanPH_XK&idxuatkhoa=" + $("#idxuatkhoa").val()
                    ,tablename:"gridTableCDPH_xk"
                },null,function(){
                   $("#btnInPhieuRaVien").css("display","");
                        $("#btnHuyXuatVien").css("display","");
                    $.LuuTable({
                        ajax:"ajax/khambenh_ajax3.aspx?do=LuuToaThuocXuatVien&idkhambenh=" + $("#idkhambenhxuatkhoa").val()
                         ,tablename:"gridTable_xk"
                    },function(){
                         //kiem tra thuoc trung nhau
                        var tablegrid="gridTable_xk";
                        var thuoctrung="";
                        for(var i=1;i<document.getElementById(tablegrid).rows.length-1;i++)
                        {
                            for(var j=i+1;j<document.getElementById(tablegrid).rows.length-1;j++){
                                if(document.getElementById(tablegrid).rows[i].cells[2].getElementsByTagName("input")[0].value==document.getElementById(tablegrid).rows[j].cells[2].getElementsByTagName("input")[0].value 
                                && document.getElementById(tablegrid).rows[i].cells[4].getElementsByTagName("input")[0].value==document.getElementById(tablegrid).rows[j].cells[4].getElementsByTagName("input")[0].value
                                && document.getElementById(tablegrid).rows[i].cells[19].getElementsByTagName("input")[0].checked==document.getElementById(tablegrid).rows[j].cells[19].getElementsByTagName("input")[0].checked){
                                        thuoctrung+=document.getElementById(tablegrid).rows[j].cells[4].getElementsByTagName("input")[1].value + ",";
                                }
                            }
                        }
                        if(thuoctrung.split(',')[0].length-1>0){
                            // $.mkv.myerror(thuoctrung + " trùng nhau");
                            //    return false;        
                        }
                       return true;
                    },function(){
                        $("#btnInToaRaVien").css("display","");
                    });
            });
    });
 }
function InToaThuocRaVien(idkhambenh,nvk_idkhoa)
{
    window.open("../noitru_BaoCao/nvk_InToaXuatVien.aspx?IsToaRV=1&IdKhamBenh="+idkhambenh,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');  
}
function InPhieuRavien(idkhambenh,idkhoa)
{
   window.open("../noitru_BaoCao/rptRaVien.aspx?idphieutt="+idkhambenh+"&IdKhoa="+idkhoa+"#isPrint=1",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
}
function idbacsisearch_xk(obj) {
    $(obj).unautocomplete().autocomplete("ajax/khambenh_ajax3.aspx?do=idbacsisearch&idkhoa=" + $("#IdKhoa").val(), {
        minChars: 0,
        scroll: true,
        cache:true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
        $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
           $(obj).focus();
        }, 100);
    });
}
function HuyXuatVien()
{
    $.ajax({
        async:true,
        url:"ajax/khambenh_ajax3.aspx",
        data:{
            "do": "HuyXuatVien",
            idkhambenh_xk: $("#idkhambenhxuatkhoa").val(),
            idxuatkhoa:$("#idxuatkhoa").val(),
            idbenhnhan: $("#idbenhnhan").val(),
            idkhambenh: $.mkv.queryString("idkhoachinh")
        },
        success:function(data)
        {
            if(data=="1"){
                $.mkv.myalert("Đã hủy xuất khoa",2000,"success");
                $.mkv.dongtimkiem('default');
            }else{
                $.mkv.myerror("Có lỗi khi thực hiện: " + data);
            }
        },
        error:function(err){
            $.mkv.myerror(err);
        }
    });
    
}
function showListTHChanDoan()
{
    var idkhambenh=$.mkv.queryString("idkhoachinh");
    $.ajax({
        async:false,
        url:"ajax/khambenh_ajax3.aspx",
        data:{
            "do":"showListTHChanDoan",
            idkhambenh:idkhambenh
        },
        success:function(data){
           if(data!=null && data !="" && data !="error")
           {
             $("#tableAjaxChanDoanPHXK").html(data);
           }
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
        if(sl<=0)
        {
            $.mkv.myerror("Số lượng kê " + tenthuoc + " không phù hợp");
            $("#gridTable").find("tr").eq(j).css("background-color","#f09090");
            return false;           
        }
        if(sl>slton)
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
    var lstIdThuoc="";
    for(var i=1;i<$('#gridTable >tbody >tr').length -2;i++)
    {
        var idthuoc=$("#gridTable").find("tr").eq(i).find("#idthuoc").val();
        var idkho=$("#gridTable").find("tr").eq(i).find("#idkhoxuat").val();
        lstIdThuoc += "@" + idthuoc +"|" + idkho
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
                listThuoc:lstIdThuoc
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