var today = new Date();
var dd = today.getDate();
var mm = today.getMonth() + 1; //January is 0!
var yyyy = today.getFullYear();
var da_dangky=0;
$(document).ready(function() {
   if ($.browser.msie<8) {
    $("input[type=text],input[type=checkbox],textarea").live("focus",function(){
        $(this).css("background-color","yellow");
      }).live("blur",function(){
              $(this).css("background-color","");
      });
      
    }
    $("select#loai").live("focus",function(){
        $(this).css("background-color","#00ffff");
    }).live("blur",function(){
        $(this).css("background-color","#00ffff");
    }).live("hover",function(){
        $(this).css("background-color","#00ffff");
    });
    if (dd < 10) { dd = '0' + dd }
    if (mm < 10) { mm = '0' + mm }
    
  $.mkv.moveUpandDown("#gridTable");
  $(window).focus(function(){
            if($.mkv.queryString("isClose") == "1"){
                    $("#moi").click();
                    $.mkv.removeQueryString("isClose");
                }
   });
    $("#ngaydangky").bind("focus",function(){
        $(this).datepick();
    });
    $("#tenbenhnhan").focus();
    $("#idloaiuutien").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=idloaiuutienSearch", defaultVal: "" });

    $("#idkhoa").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=idkhoasearch",async:false},null,function(){
          if($.mkv.queryString("idkhoa")!=null && $.mkv.queryString("idkhoa")!="" ){
            $("#idkhoa").val($.mkv.queryString("idkhoa"));
                 $("#idkhoa").attr("disabled",true);
          }else{
             $("#idkhoa")[0].selectedIndex=1;
          }
    });
    $("#loai").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=loaiSearch", defaultVal: "" ,async:false},null,function(){
        var idkhoa=$.mkv.queryString("idkhoa");
        if(idkhoa==null || idkhoa =="")idkhoa=$("#idkhoa").val();
        $("#idphongkhambenh").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=idphongkhambenhSearch&idkhoa=" + idkhoa,defaultVal:"- Chọn phòng -" ,async:true},null,function(){
           if($.mkv.queryString("idkhoa")!=null && $.mkv.queryString("idkhoa")!="") 
                $("#idphongkhambenh")[0].selectedIndex=1;
        });
    });
    if($.mkv.queryString("idkhoa")=="15"){
        $("#smTaiNan").css("display", "");
        $("#idloaitainan").css("display", "");
    };
    setControlFind($.mkv.queryString("idkhoachinh"));
    $("#luu").click(function() {
        $(this).Luu({
            ajax: "ajax/benhnhan_ajax.aspx?do=Luu",isGet:true,timeMes:1000
        }, function() {
            if ($("#ngaytiepnhan").val() == "") {
                alert("Ngày tiếp nhận không bỏ trống.");
                $("#ngaytiepnhan").focus();
                return false;
            }
            else if ($("#tenbenhnhan").val() == "") {
                alert("Tên bệnh nhân không bỏ trống.");
                $("#tenbenhnhan").focus();
                return false;
            }
            else if ($("#ngaysinh").val() == "") {
                alert("Ngày sinh không được bỏ trống.");
                $("#ngaysinh").focus();
                return false;
            }
            else if ($("#diachi").val() == "") {
                alert("Địa chỉ không bỏ trống.");
                $("#txtMaDiaChi").focus();
                return false;
            }
            else if ($("#idloaiuutien").val() == "") {
                alert("Chưa chọn loại ưu tiên.");
                return false;
            }
            else if ($("#loai").val() == "") {
                alert("Chưa chọn loại khám.");
                return false;
            }
            else if ($("#loai").val() == "1") {
                if($("#sobh1").val().toUpperCase()=="TE" && $("#sobh2").val()=="1"){return true;}
                if(check_dodai($("#sobh1"),2)==false)return false;
                if(check_dodai($("#sobh2"),1)==false)return false;
                if(check_dodai($("#sobh3"),2)==false)return false;
                if(check_dodai($("#sobh4"),2)==false)return false;
                if(check_dodai($("#sobh5"),3)==false)return false;
                if(check_dodai($("#sobh6"),5)==false)return false;
                if($("#mkv_TENNOIDANGKY").val()=="" && $("#sobh1").val().toUpperCase()!="TE"){
                    alert("Nơi ĐK KCB không bỏ trống");
                        $("#mvk_MADANGKY").focus();
                    return false
                }
                if(!check_ngaybaohiem())return false; 
                if(!$("#dungtuyen").is(":checked")&& !$("#TraiTuyen").is(":checked"))
                {
                    alert("Phải chọn đúng tuyến hoặc trái tuyến !");
                    return false;
                }
            }
            return true;
        }, function(data) {
            if (data.indexOf("@") != -1) {
                var value = data.split('@');
                $.mkv.queryString("idkhoachinh", value[0]);
                $("#mabenhnhan").val(value[1]);
                $("#IDBENHNHAN_BH").val(value[2]);
                if(value[3]!=null && value[3]!="")
                    da_dangky=value[3];
            }
            if($("#loai").selectedIndex==0){
                $.mkv.ExtendtionLuu(false, { Frame: "#thongtindangkykham"});
            }else{
                $.mkv.ExtendtionLuu(false, { Frame: "#thongtinkhoaphong"});
                    
            }
            setTimeout(function() { $("#dangKy").focus() }, 100);
        });
        
    });
    $("#moi").click(function() {
        $(this).Moi();
        $("#dangKy").attr("disabled",false);
        $("#tenbenhnhan").focus();
        $("#dangKy").css("display", "");
        $("#STT").attr("disabled","disabled");
        $("#slbncho").attr("disabled","disabled");
        $("#slbnkham").attr("disabled","disabled");
        AllowDKKThem="0";
        $("#_luu").attr("id","luu");
          $("#thongtinbh :input").attr("disabled",true);
         setDefault();
        loadTableAjaxDangkykham();
          if($.mkv.queryString("idkhoa")!=null && $.mkv.queryString("idkhoa")!="") 
                $("#idphongkhambenh")[0].selectedIndex=1;
      }); 
    $("#xoa").click(function() {
        $(this).Xoa({ ajax: "ajax/benhnhan_ajax.aspx?do=xoa" });
    });
    $("#timKiem").click(function() {
        Find(this);
    });
    var AllowDKKThem="0";
    $("#dangKy").click(function() {
       var IdKhoa=$.mkv.queryString("idkhoa");
       if(IdKhoa==null ||IdKhoa=="")
       IdKhoa=$("#idkhoa").val();
       $("#dangKy").attr("disabled",true);
        $(this).TimKiem({
            ajax: "ajax/benhnhan_ajax.aspx?do=dangkykhambenh&idbenhnhan=" + $.mkv.queryString("idkhoachinh")+"&tenbenhnhan="+$("#tenbenhnhan").val()+"&AllowDKKThem="+AllowDKKThem  +  "&da_dangky=" + da_dangky
                      + "&ngaydangky=" + $("#ngaydangky").val()
                      + "&giodk=" + $("#giodk").val()
                      + "&phutdk=" + $("#phutdk").val()
                      + "&idkhoa=" + IdKhoa
                      //+ "&idloaitainan=" +  $("#idloaitainan").val()  
                      + "&IDBENHNHAN_BH=" + $("#IDBENHNHAN_BH").val()                      
                     , Frame: "#thongtindangkykham",showPopup:false,timeMes:1000
        }, function() {
            if ($.mkv.queryString("idkhoachinh") == "") {
                $("#dangKy").attr("disabled",false);
                alert("Chưa có bệnh nhân.");
                return false;
            }else if ($("#ngaydangky").val() == "") {
                $("#dangKy").attr("disabled",false);
                alert("Chưa chọn ngày đăng ký.");
                return false;
            }else if ($("#idphongkhambenh").val() == "" || $("#idphongkhambenh").selectedIndex=="0") {
                 var ismuaso=$("#ismuaso").is(':checked');
                 if(ismuaso!=true)
                 {
                       $("#dangKy").attr("disabled",false);
                       alert("Chưa chọn phòng khám.");
                       $("#idphongkhambenh").focus();
                       return false;
                 }
            }
                return true;
        },function(value) {
          if($.isNumeric(value))
          {
                $("#dangKy").css("display", "none");
                $("#moi").focus();
                $.mkv.myalert("Đăng ký khám thành công", 1000, "success");
                loadTableAjaxDangkykham();
                AllowDKKThem="0";
                da_dangky=1;
                if (IdKhoa=="15")
					window.open("../KhamBenh_TH/rptPhieuChiDinh.aspx?iddangkykham=" +value,"_blank");
				else if($("#isInBaoThuPK").val()=="1" && $("#loai").val()=="2")
					window.open("../KhamBenh_TH/rptPhieuChiDinh.aspx?iddangkykham=" +value,"_blank");
            }
            else
            {
                $.mkv.myalert("" + value,5000,"info");
                AllowDKKThem="1";
                $("#dangKy").attr("disabled",false);
            }
        });
        
    });
    $("#dkNhieuKhoa").click(function(){
          $.mkv.queryString("isClose","1");
        window.open("dangkykham3.aspx#idbenhnhan=" + $.mkv.queryString("idkhoachinh") 
            + "&ngaydangky=" +$("#ngaydangky").val() 
            + "&idkhoa=" + $("#idkhoa").val()
            + "&LoaiKhamID=" + $("#loai").val()
            + "&dadangky=" + da_dangky 
            + "&IDBENHNHAN_BH=" + $("#IDBENHNHAN_BH").val()
            + "&SoBH=" + $("#sobh1").val()+ $("#sobh2").val()+ $("#sobh3").val()+ $("#sobh4").val()+ $("#sobh5").val()+ $("#sobh6").val() 
            ,"_blank");
     
    });
     $("#dangkyCLS").click(function(){
                $.mkv.queryString("isClose","1");
                if($.mkv.queryString("idkhoachinh") ==null || $.mkv.queryString("idkhoachinh") =="")
                    return;
        window.open("frmDangkyCLS.aspx?idbenhnhan=" + $.mkv.queryString("idkhoachinh") + "&ngaydangky=" +$("#ngaydangky").val() + "&LoaiBN=" + $("#loai").val()+"&dkMenu=TiepNhan" + "#idbenhnhan=" + $.mkv.queryString("idkhoachinh") + "#IdKhoa=" + $("#idkhoa").val(),"_blank","location=0,menubar=0,statusbar=1,scrollbars=1");
    });
     $("#dangkyCLS_edit").click(function(){
      $.mkv.queryString("isClose","1");
                if($.mkv.queryString("idkhoachinh") ==null || $.mkv.queryString("idkhoachinh") =="")
                    return;
        $.ajax({ cache: false,
        url: "ajax/benhnhan_ajax.aspx?do=GetLastIDDangKyCLS&IdBenhNhan=" + $.mkv.queryString("idkhoachinh"),
        success: function(data) {
                    if(data!=""&&data=="not"){
                        $.mkv.myalert("Không có cận lâm sàn nào, hoặc đã thu tiền rồi ",2000,"info");
                    }else{
                        window.open("hs_DangKyCLS3.aspx?idkhoachinh="+data+"","_blank","menubar=0,statusbar=1,scrollbars=1");
                    }
                }
         });                        
    });
    $("#idphongkhambenh").bind("change",function(){
        idphongkhambenhchuyen($(this).val());
    });

     $("#bhmoi").click(function(){
        $("#thongtinbh :input[type='text']").val("");
        $("#thongtinbh :input[type='checkbox']").attr("checked",false);
        $("#thongtinbh :input[type='text']").attr("disabled",false);
        $("#thongtinbh :input[type='checkbox']").attr("disabled",false);
        $("#IDBENHNHAN_BH").val("");
    });
    $('#timKiem').poshytip({
        className: 'tip-darkgray',
        bgImageFrameSize: 11,
        offsetX: -25,
        content:'Tìm theo Mã, Tên,Số BH,Số ĐT.'
    });
    setDefault();
    $("#loai").bind("change",function(){
        if($(this)[0].selectedIndex!=0){
            $("#thongtinbh :input[type='text']").val("");
            $("#thongtinbh :input[type='checkbox']").attr("checked",false);
            $("#thongtinbh :input[type='text']").attr("disabled",false);
            $("#thongtinbh :input[type='checkbox']").attr("disabled",false);
            $("#tilebhyt").val("");
            $("#IDBENHNHAN_BH").val("");
        }else{
            if($.mkv.queryString("idkhoachinh")!=""){
             $.BindFind({
                ajax:"ajax/benhnhan_ajax.aspx?do=get_last_thongtin_bh&idbenhnhan=" + $.mkv.queryString("idkhoachinh"),useEnabled:false
            },null,function(){
                     $.mkv.ExtendtionLuu(false, { Frame: "#thongtinbh"});
            });
           }
        }
    });    
    $("#ngaysinh").bind("blur",function(e){
        if(TestNgaySinh(this)){
             TinhTuoiBenhNhan();
                if($.trim($("#tenbenhnhan").val())!="" && $.trim($(this).val())!=""){
                      $("#checkBN").click();
                }  
        }
    });
    $("#ngaybatdau,#ngayhethan").bind("focus",function(e){
         $(this).validDate();
          $(this).datepick();
    });
    
});
//───────────────────────────────────────────────────────────────────────────────────
function tinhidsearch(obj)
{
    $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=tinhidSearch" + "&tinhid=" + $("#tinhid").val(), {
        minChars: 0,
        width:150,
        scroll: true,
        addRow: true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
            $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            $("#mkv_quanhuyenid").focus();
        }, 100);
     });
}
//───────────────────────────────────────────────────────────────────────────────────
function quanhuyenidsearch(obj)
{
    $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=quanhuyenidSearch"+ "&tinhid="+$("#tinhid").val(), {
        minChars: 0,
        width:150,
        scroll: true,
        addRow: true,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
            $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            $("#mkv_phuongxaid").focus();
        }, 100);
     });
}
//───────────────────────────────────────────────────────────────────────────────────
function phuongxaidsearch(obj)
{
    $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=phuongxaidSearch"+ "&quanhuyenid="+$("#quanhuyenid").val(), {
        minChars: 0,
        scroll: true,
        addRow: true,
        width:150,
        header:false,
        formatItem: function(data) {
            return data[0];
        } 
    }).result(function(event, data) {
            $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            $("#sonha").focus();
        }, 100);
     });
}
//───────────────────────────────────────────────────────────────────────────────────
function setDefault()
{
    
    $.BindFind({
        ajax:"ajax/benhnhan_ajax.aspx?do=setdefault&loai="+$("#loai").val(),useEnabled:false
    },null,function(){
        $("#loai")[0].selectedIndex=1; // mac dinh loai kham = dich vu
         //───────────────────truong hop da truyen vao idkhoa──────────────────────────────────────
        if($.mkv.queryString("idkhoa")!=null && $.mkv.queryString("idkhoa")!="" )
          {
                 $("#idkhoa").val($.mkv.queryString("idkhoa"));
                 $("#idkhoa").attr("disabled",true);
                
          }
          //─────────────────truong hop khong truyen vao idkho, gan mac dinh la khoa dau tien─────────────────────
          else{
                $("#idkhoa")[0].selectedIndex=1;
               }
          //─────────────────truong hop khoa san, gioi tinh mac dinh la nu va khong cho xac dih gioi tinh khac───────────────
        if($.mkv.queryString("idkhoa")=="3")
            {
                $("#gioitinh")[0].selectedIndex=1;    
                $("#gioitinh").attr("disabled",true);
            }
        //─────────────────truong hop khac khoa san, gioi tinh mac dinh la nam─────────────────────
         else{
              $("#gioitinh")[0].selectedIndex=0;
             }
             //─────────────────mac dinh khong xuat hien thu phi cap cuu, thong tin bao hiem────────────
       // $("#thuphicapcuu").css("display","none");
        $("#thongtinbh :input").attr("disabled",true);
        $("#tilebhyt").attr("disabled",true);
        //─────────────────tab dien thoai, nhay qua loai kham────────────
      
             $("#loai").bind("blur",function()
                {
                    $("#ismuaso").focus();
                });
        //──────────────────mac dinh tham so khi thay doi loai kham---------------------
           $("#loai").bind("change",function(){
                          //──────────────────truong hop loai kham khac bao hiem, tab tu phong kham, chuyen qua nut Luu
                   if($(this)[0].selectedIndex!=0)
                    {
                       $("#thongtinbh :input").attr("disabled",true);
                            $("#tilebhyt").attr("disabled",true);
                       $("#idphongkhambenh").bind("blur",function()
                            {
                                $("#luu").focus();
                            });
                      
                     } 
                     //──────────────────truong hop loai kham la bao hiem y te
                  else
                    {
                        
                        $("#idphongkhambenh").bind("blur",function()
                        {
                            $("#sobh1").focus();
                        });
                         $("#thongtinbh :input").attr("disabled",false);
                         $("#thongtinbh :input[type='text']").val("");
                         $("#tilebhyt").val("");
                         $("#thongtinbh :input[type='checkbox']").attr("checked",false);
                         var timev = null;
                        
                     //----------------tab sobh2 ----------------------------------------------------                            
               $("#sobh1").bind("keyup",function(){
                    if($(this).val().toUpperCase()=="TE")
                    {
                        $("#dungtuyen").attr("checked",true);
                        $("#sobh2").val("1");
                    }
               });
               $("#sobh2").bind("focus",function(e)
               {
                    $(this).chuyenBH('2','num');
                    clearTimeout(timev);
                    //------------ timev=setTimeout----------------------
                    timev=setTimeout(function()
                        {
                         //--------- $(e.target).bind----------------------------------
                          $(e.target).bind("blur",function()
                          {
                             
                            //--------- $.ajax({----------------------------------
                            $.ajax({
                                   
                                        async:false,
                                        cache:false,
                                        type:'post',
                                        url:"ajax/benhnhan_ajax.aspx?do=check_thuphi&idbenhhnhan=" + $.mkv.queryString("idkhoachinh") + "&idbenhnhan_bh=" + $("#IDBENHNHAN_BH").val(),
                                        success:function(data)
                                            {
                                                if(data!="")
                                                {
                                                             alert(data);
                                                             return false;
                                                } else
                                                     {
                                                        $("#diverror").click();
                                                     }
                                            }
                                    });
                             //------------ end $.ajax({----------------------
                            });
                        //------------ end  $(e.target).bind----------------------
                    });
                  //------------ end  timev=setTimeout----------------------
               }); 
               //----------------end tab sobh2 ----------------------------------------------------                            
            }
            //----------------end truong hop loai kham =bao hiem-----------------------------------                          
        });
       ///----------------end loaikham change-----------------------------------------------------------------------
       //─────────────────────truong hop khac khoa kham benh───────────────────────────────
       if($.mkv.queryString("idkhoa")!="" && $.mkv.queryString("idkhoa")!="1"){
            $("#dienthoai").blur(function()
               {
                    $("#mkv_maquoctich").focus();
                });
             $("#muaso").css("display","none");
             $("#thuphicapcuu").css("display","");
             $("#dkNhieuKhoa").css("display","none");
        //     $("#dangkyCLS").css("display","none");
          //   $("#dangkyCLS_edit").css("display","none");
             $("#nhapvien").css("display","none");
        }
       else
       {
          $("#dienthoai").bind("blur",function()
            {
                $("#mkv_manghenghiep").focus();
            });
          $("#mkv_manghenghiep").bind("blur",function()
            {
                $("#loai").focus();
            });
       }
       if($.mkv.queryString("idkhoa")=="3")
       {
            $("#muaso").css("display","");
         //   $("#thuphicapcuu").css("display","none");
       }
       //idphongkhambenhchuyen($("#idphongkhambenh").val());
         //───────────────────────────────────────────────────────
		 setViewOption();
    });/// end bind find
    
}//end function
//───────────────────────────────────────────────────────────────────────────────────
function setViewOption()
{
	if($("#isInMaVachBN").val()=="1")
	{
		$("#inMaVach").css("display","");
	}
	else
		$("#inMaVach").css("display","none");
		
	if($("#isInTheBN").val()=="1")
		$("#inTheBN").css("display","");
	else
		$("#inTheBN").css("display","none");
	if($("#isKhamBH").val()=="0")
	{
	    $("#loai")[0].selectedIndex=0; //
        $("#thongtinbh").css("display","none");
        $("#divTiLeBHYT").css("display","none");
        $("#divButton").css("width","98%");
	    $("#loai").attr("disabled",true);
	}
	else
	{
	    $("#loai")[0].selectedIndex=1; // mac dinh loai kham = dich vu	    
	}
}
//───────────────────────────────────────────────────────────────────────────────────
function chonbh(obj)
{
    if($.mkv.queryString("idkhoachinh") ==null || $.mkv.queryString("idkhoachinh") =="")
        return;
          $(obj).TimKiem({ajax:'ajax/benhnhan_ajax.aspx?do=chonbhkhac&idbenhnhan='+$.mkv.queryString("idkhoachinh"),title:'Thông tin bảo hiểm',width:"1000px",autoClick:false
    },null,function(data){
        if(data==""||data==null){
            $.mkv.closeDivTimKiem();
         }
    });
  
}
function chonthongtinbh(idbenhnhan_bh,ngayhethan){
    var nhh = new Date(ngayhethan.substring(6, 10),ngayhethan.substring(3, 5),ngayhethan.substring(0, 2));
    if (nhh < new Date(yyyy, mm, dd)) {
        alert("Ngày hết hạn không nhỏ hơn ngày hiện tại.");
        return false;
    }
    $.BindFind({
        ajax:"ajax/benhnhan_ajax.aspx?do=chonthongtinbh&idbenhnhan_bh=" + idbenhnhan_bh
    },null,function(){
             $.mkv.ExtendtionLuu(false, { Frame: "#thongtinbh"});
    });
}
function loadmaquoctich(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=loadmaquoctich", {
        minChars: 0,
        width: 220,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:10%;color:white;float:left; font-size:12px;text-algin:left;\" >Mã </div>"
                      + "<div style=\"width:60%;color:white;float:left;font-size:12px;\" >Tên quốc tịch</div>"
                  + "</div>",
        formatItem: function(data) {
            return "<div style='float:left; width:15%; height:30px'>" + data[1] + "</div><div style='float:left;width:85%; height:30px;'>" + data[2] + "</div>";
        } 
    }).result(function(event, data) {
            $(obj).val(data[1]);
            $("#quoctich").val(data[3]);
            $("#mkv_tenquoctich").val(data[2]);
        setTimeout(function() {
            obj.focus();
        }, 100);
     });
}
function loadmadantoc(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=loadmadantoc", {
        minChars: 0,
        width: 220,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:10%;color:white;float:left; font-size:12px;text-algin:left;\" >Mã </div>"
                      + "<div style=\"width:60%;color:white;float:left;font-size:12px;\" >Tên dân tộc</div>"
                  + "</div>",
        formatItem: function(data) {
            return "<div style='float:left; width:15%; height:30px'>" + data[1] + "</div><div style='float:left;width:85%; height:30px;'>" + data[2] + "</div>";
        } 
    }).result(function(event, data) {
            $(obj).val(data[1]);
            $("#dantoc").val(data[3]);
            $("#mkv_tendantoc").val(data[2]);
        setTimeout(function() {
            obj.focus();
        }, 100);
     });
}
function loadmanghenghiep(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=loadmanghenghiep", {
        minChars: 0,
        width: 220,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:10%;color:white;float:left; font-size:12px;text-algin:left;\" >Mã </div>"
                      + "<div style=\"width:60%;color:white;float:left;font-size:12px;\" >Tên nghề nghiệp</div>"
                  + "</div>",
        formatItem: function(data) {
            return "<div style='float:left; width:15%; height:30px'>" + data[1] + "</div><div style='float:left;width:85%; height:30px;'>" + data[2] + "</div>";
        } 
    }).result(function(event, data) {
            $(obj).val(data[1]);
            $("#nghenghiep").val(data[3]);
            $("#mkv_tennghenghiep").val(data[2]);
        setTimeout(function() {
            $("#loai").focus();
        }, 100);
     });
}
function loadmadangky(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=loadmadangky", {
        minChars: 0,
        width: 420,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:20%;color:white;float:left; font-size:12px; text-align:left;padding-left:10px;\" >Mã ĐK KCB </div>"
                    + "<div style=\"width:47%;color:white;float:left;font-size:12px; text-align:left;\" >Tên nơi đăng ký</div>"
                    + "<div style=\"width:20%;color:white;float:left;font-size:12px;\" >? Đúng tuyến</div>"
                  + "</div>",
        formatItem: function(data) {
            return "<div style='float:left; width:15%; height:30px; padding-left:10px;'>" + data[1] + "</div><div style='float:left;width:55%; height:30px; padding-left:10px;'>" + data[2] + "</div><div style='float:left;width:15%; height:30px; padding-left:10px;'>" + data[4] + "</div>";
        } 
    }).result(function(event, data) {
            $(obj).val(data[1]);
            $("#IdNoiDangKyBH").val(data[3]);
            $("#mkv_TENNOIDANGKY").val(data[2]);
        setTimeout(function() {
            $("#mkv_ma_noigioithieu").focus();
        }, 100);
     });
}
function loadnoidangky(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=loadnoidangky", {
        minChars: 0,
        width: 420,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:20%;color:white;float:left; font-size:12px; text-align:left;padding-left:10px;\" >Mã ĐK KCB </div>"
                    + "<div style=\"width:47%;color:white;float:left;font-size:12px; text-align:left;\" >Tên nơi đăng ký</div>"
                    + "<div style=\"width:20%;color:white;float:left;font-size:12px;\" >? Đúng tuyến</div>"
                  + "</div>",
        formatItem: function(data) {
            return "<div style='float:left; width:15%; height:30px; padding-left:10px;'>" + data[1] + "</div><div style='float:left;width:55%; height:30px; padding-left:10px;'>" + data[2] + "</div><div style='float:left;width:15%; height:30px; padding-left:10px;'>" + data[4] + "</div>";
        } 
    }).result(function(event, data) {
            $(obj).val(data[2]);
            $("#IdNoiDangKyBH").val(data[3]);
            $("#mvk_MADANGKY").val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
     });
}
 function loadmagioithieu(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=loadmadangky", {
        minChars: 0,
        width: 420,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:20%;color:white;float:left; font-size:12px; text-align:left;padding-left:10px;\" >Mã ĐK KCB </div>"
                    + "<div style=\"width:47%;color:white;float:left;font-size:12px; text-align:left;\" >Tên nơi đăng ký</div>"
                    + "<div style=\"width:20%;color:white;float:left;font-size:12px;\" >? Đúng tuyến</div>"
                  + "</div>",
        formatItem: function(data) {
            return "<div style='float:left; width:15%; height:30px; padding-left:10px;'>" + data[1] + "</div><div style='float:left;width:55%; height:30px; padding-left:10px;'>" + data[2] + "</div><div style='float:left;width:15%; height:30px; padding-left:10px;'>" + data[4] + "</div>";
        } 
    }).result(function(event, data) {
            $(obj).val(data[1]);
            $("#idNoiGioiThieu").val(data[3]);
            $("#mkv_ten_noigioithieu").val(data[2]);
        setTimeout(function() {
            obj.focus();
        }, 100);
     });
}
function loadtengioithieu(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=loadnoidangky", {
        minChars: 0,
        width: 420,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:20%;color:white;float:left; font-size:12px; text-align:left;padding-left:10px;\" >Mã ĐK KCB </div>"
                    + "<div style=\"width:47%;color:white;float:left;font-size:12px; text-align:left;\" >Tên nơi đăng ký</div>"
                    + "<div style=\"width:20%;color:white;float:left;font-size:12px;\" >? Đúng tuyến</div>"
                  + "</div>",
        formatItem: function(data) {
            return "<div style='float:left; width:15%; height:30px; padding-left:10px;'>" + data[1] + "</div><div style='float:left;width:55%; height:30px; padding-left:10px;'>" + data[2] + "</div><div style='float:left;width:15%; height:30px; padding-left:10px;'>" + data[4] + "</div>";
        } 
    }).result(function(event, data) {
            $(obj).val(data[2]);
            $("#IdNoiGioiThieu").val(data[3]);
            $("#mkv_ma_noigioithieu").val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
     });
}
function loadtennghenghiep(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=loadtennghenghiep", {
        minChars: 0,
        width: 180,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:10%;color:white;float:left; font-size:12px;text-algin:left;\" >Mã </div>"
                      + "<div style=\"width:60%;color:white;float:left;font-size:12px;\" >Tên nghề nghiệp</div>"
                  + "</div>",
        formatItem: function(data) {
            return "<div style='float:left; width:15%; height:30px'>" + data[1] + "</div><div style='float:left;width:85%; height:30px;'>" + data[2] + "</div>";
        } 
    }).result(function(event, data) {
            $(obj).val(data[2]);
            $("#nghenghiep").val(data[3]);
            $("#mkv_manghenghiep").val(data[1]);
        setTimeout(function() {
            $("#loai").focus();
            //obj.focus();
        }, 100);
     });
}
function loadtendantoc(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=loadtendantoc", {
        minChars: 0,
        width: 180,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:10%;color:white;float:left; font-size:12px;text-algin:left;\" >Mã </div>"
                      + "<div style=\"width:60%;color:white;float:left;font-size:12px;\" >Tên dân tộc</div>"
                  + "</div>",
        formatItem: function(data) {
            return "<div style='float:left; width:15%; height:30px'>" + data[1] + "</div><div style='float:left;width:85%; height:30px;'>" + data[2] + "</div>";
        } 
    }).result(function(event, data) {
            $(obj).val(data[2]);
            $("#dantoc").val(data[3]);
            $("#mkv_madantoc").val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
     });
}
function loadtenquoctich(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=loadtenquoctich", {
        minChars: 0,
        width: 180,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:10%;color:white;float:left; font-size:12px;text-algin:left;\" >Mã </div>"
                      + "<div style=\"width:60%;color:white;float:left;font-size:12px;\" >Tên quốc tịch</div>"
                  + "</div>",
        formatItem: function(data) {
            return "<div style='float:left; width:15%; height:30px'>" + data[1] + "</div><div style='float:left;width:85%; height:30px;'>" + data[2] + "</div>";
        } 
    }).result(function(event, data) {
            $(obj).val(data[2]);
            $("#quoctich").val(data[3]);
            $("#mkv_maquoctich").val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
     });
}
function xacdinhnhapvien(control)
{
    /*   
    $(control).Luu({
        ajax:"ajax/benhnhan_ajax.aspx?do=LuuNhapVien&LoaiKhamID=" + $("#loai").val() + "&IDBENHNHAN_BH=" + $("#IDBENHNHAN_BH").val()
         , Frame: "#thongtinnhapvien"
    },function(){
       
        var idkhoanhap=$.trim($("#idkhoachuyen").val());
        if(idkhoanhap=="0" || idkhoanhap=="" || idkhoanhap==null)
        {
             alert("Chưa chọn khoa chuyển đến");
            return false;
        }
       
      return true;
    },function(value){
         if(value=="0"){
                 $.mkv.myalert("Thông tin không thay đổi",2000,"info");  
          }else if(value=="1"){
             $.mkv.myalert("Thay đổi thông tin thành công",2000,"success");  
          }
           else{
                $("#thongtinnhapvien #sovaovien").append(value.split('|')[1]);
             $.mkv.myalert(value.split('|')[0],2000,"success");  
          }
    });
    */
    var idkhoanhap=$.trim($("#idkhoachuyen").val());
        if(idkhoanhap=="0" || idkhoanhap=="" || idkhoanhap==null)
        {
             alert("Chưa chọn khoa chuyển đến");
            return false;
        }
     var isNhapNewqr="0";
     var checkval= $("#thongtinnhapvien #isNhapNew");
     if(!$.isNullOrEmpty(checkval) && checkval.is(":checked"))
     {
        isNhapNewqr="1";
     }
     $.ajax({
        async:false,
       // type:"POST",
        url:"ajax/benhnhan_ajax.aspx",
        data:{
            "do": "LuuNhapVien",
            idbenhnhan: $("#idbenhnhan").val(),
            LoaiKhamID: $("#loai").val(),
            IDBENHNHAN_BH: $("#IDBENHNHAN_BH").val(),
            ngaynhapvien: $("#thongtinnhapvien #ngaynhapvien").val(),
            idkhoanhap: $("#thongtinnhapvien #idkhoanhap").val(),
            idbacsi: $("#thongtinnhapvien #idbacsi").val(),
            idchandoan: $("#thongtinnhapvien #idchandoan").val(),
            idphong: $("#thongtinnhapvien #idphong").val(),
            idkhoachuyen: $("#thongtinnhapvien #idkhoachuyen").val(),
            sovaovien: $("#thongtinnhapvien #sovaovien").val(),
            isNhapNew: isNhapNewqr
        },
        success:function(value){
          if(value.split(';')[0]=="0"){
                 $.mkv.myalert("Thông tin không thay đổi",2000,"info");  
          }else 
          if(value.split(';')[0]=="1"){
             $.mkv.myalert("Thay đổi thông tin thành công",2000,"success");  
          }
           else{
                  $("#thongtinnhapvien #sovaovien").html(value.split(';')[1]);
             $.mkv.myalert(value.split(';')[0],2000,"success");  
          }
        }
     });
    
    
}
function nhapvienmoi(control){
    if($.mkv.queryString("idkhoachinh") ==null || $.mkv.queryString("idkhoachinh") =="")
        return;
    $(control).TimKiem({ajax:'ajax/benhnhan_ajax.aspx?do=nhapvienmoi&idbenhnhan='
        +$.mkv.queryString("idkhoachinh"),
        title:'Thông tin nhập viện',
        width: 780,
        height: 220,
        onlyPopup:false
    });
  
}
function setControlFind(idkhoatimkiem) {
    if (idkhoatimkiem != "" && idkhoatimkiem != null) {
        $.BindFind({ ajax: "ajax/benhnhan_ajax.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem },null,function(){
        if($("#divTimKiem").length > 0)
            $("#divTimKiem").remove();
        loadTableAjaxDangkykham();
            if($("#loai")[0].selectedIndex==0){
                $("#chonbhkhac").attr("disabled",false);
                $("#bhmoi").attr("disabled",false);
                  $.BindFind({
                        ajax:"ajax/benhnhan_ajax.aspx?do=get_last_thongtin_bh&idbenhnhan=" + $.mkv.queryString("idkhoachinh")
                    },null,function(){
                        $.mkv.ExtendtionLuu(false, { Frame: "#thongtinkhoaphong"});
                         $("#STT").attr("disabled",true);
                         $("#slbncho").attr("disabled",true);
                         $("#slbnkham").attr("disabled",true);
                             if($.mkv.queryString("idkhoa")!=null && $.mkv.queryString("idkhoa")!="" ){
                                $("#idkhoa").val($.mkv.queryString("idkhoa"));
                                     $("#idkhoa").attr("disabled",true);
                              }else{
                                 $("#idkhoa")[0].selectedIndex=1;
                              }
                    });
            }else{
                $("#chonbhkhac").attr("disabled",true);
                $("#bhmoi").attr("disabled",true);
                $("#thongtinbh :input[type='text']").val("");
                $("#thongtinbh :input[type='checkbox']").attr("checked",false);
            }
        });
    }
}
function idkhoa_noitru_search(obj) {
$(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=idkhoa_noitru_search", {
    minChars: 0,
    scroll: true,
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

  function idkhoasearch(obj) {
$(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=idkhoasearch", {
    minChars: 0,
    scroll: true,
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
  function idphongkhambenhsearch(obj) {
$(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=idphongkhambenhSearch&idkhoa="+$("#idkhoanhap").val(), {
    minChars: 0,
    scroll: true,
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
function idbacsisearch(obj) {
$(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=idbacsisearch&idkhoa=" + $("#idkhoanhap").val(), {
    minChars: 0,
    width: 460,
    scroll: true,
    header:false,
    formatItem: function(data) {
        return data[0];
    } 
}).result(function(event, data) {
    $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
    $(obj).val(data[0]);
    setTimeout(function() {
        }, 100);
    });
}
function LoadChanDoanMoTaICD(obj,loaichuandoan)
{
     $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=LoadChanDoanMoTaICD", {
        minChars: 0,
        width: 380,
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
        $("#idchandoan").val(data[3]);
        $("#mkv_mota").val(data[2]);
        $("#mkv_idchandoan").val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
     });
}
function LoadChanDoanMaICD(obj,loaichuandoan)
{
     $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=LoadChanDoanMaICD", {
        minChars: 0,
        width: 460,
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
        $("#idchandoan").val(data[3]);
        $("#mkv_mota").val(data[2]);
        $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[3]);
        setTimeout(function() {
            obj.focus();
        }, 100);
    });
}
function setDangkykham(iddangkykham,ngaydangky){

    window.open("dangkykham3.aspx?dkMenu=tiepnhan#idbenhnhan=" + $.mkv.queryString("idkhoachinh") + "&LoaiKhamID=" + $("#loai").val() + "&idkhoachinh=" + iddangkykham + "&ngaydangky=" + ngaydangky + "&idkhoa=" + $("#idkhoa").val() ,'_blank','width=500,location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
}
function KiemTraBN(obj){
   $(obj).TimKiem({
        ajax:"ajax/benhnhan_ajax.aspx?do=checkBN" 
            +"&idbenhnhan=" + $.mkv.queryString("idkhoachinh") 
            + "&tenbenhnhan=" + encodeURIComponent($("#tenbenhnhan").val())
            + "&ngaysinh=" + $("#ngaysinh").val()
        ,title:"Danh sách bệnh nhân trùng tên"
        ,autoClick:false
        ,width: "1100px"
        ,onlyPopup:false
        ,readMKV:false
   },function(){
      $.mkv.loading(".");
   },function(data){
        if(data.length <1 )
            return false;
      
   });
}

function Find(control, page) {
    if (page == null) page = "1";
     $(control).TimKiem({
        ajax: "ajax/benhnhan_ajax.aspx?do=TimKiem&page=" + page,
        title:"Danh sách bệnh nhân",
        width: 1200,
        keyCode:13,
        onlyPopup:false
        ,Frame:"#timkiemthongtin"
    });
}
function loadTableAjaxDangkykham(idkhoachinh,page)
{
    if($.mkv.queryString("idkhoachinh") != ""){
        if(page == null)page = "1";
        $.ajax({
            cache:false,
            dataType:"text",
            type:"GET",
            url:"ajax/benhnhan_ajax.aspx?do=loadDSDangkykham&idbenhnhan="+$.mkv.queryString("idkhoachinh")+"&mabenhnhan="+$("#mabenhnhan").val()+"&page=" + page,
            success:function(data){
                $("#tableDangkykham").html(data);
                da_dangky=$("#da_dangky").val();
            }
        });
    }else{
        $("#tableDangkykham").html("");
    }
}
function ktramabh(obj) {
   if($("#IdNoiDangKyBH").val()=="") return false;
    $.ajax({ 
        async:false,
        cache: false,
        url: "ajax/benhnhan_ajax.aspx?do=ktramabh&IDNOIDANGKY=" + $("#IdNoiDangKyBH").val(),
        dataType:"text",
        success: function(data) {
            if(data=="True"){
                $("#TraiTuyen").attr("checked",false);
                $("#dungtuyen").attr("checked",true);
            }else{
                $("#TraiTuyen").attr("checked",true);
                $("#dungtuyen").attr("checked",false);
            }
        }
    });
}

function TimDiaChi(obj)
{
    $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=TimDiaChi",
        {
            width:700,
            scroll:true,
            selectFirst:true,
            header: "<div style =\"width:100%;height:15px\">"
                        + "<div style=\"width:10%;color:white;float:left; font-size:12px;text-algin:left;\" >Ký hiệu</div>"
                        + "<div style=\"width:80%;color:white;float:left;font-size:12px;text-align:left; padding-left:50px;\" >Địa chỉ</div>"
                  + "</div>",
            formatItem:function(data){
                return data[0];
            }
        }
    ).result(function(event,data){
        $(obj).val(data[1]);
        $("#diachi").val(","+data[2]);
        $("#tinhid").val(data[5]);
        $("#mkv_tinhid").val(data[8]);
        $("#quanhuyenid").val(data[4]);
        $("#mkv_quanhuyenid").val(data[7]);
        $("#phuongxaid").val(data[3]);
        $("#mkv_phuongxaid").val(data[6]);
        $.setFocusCharacter(document.getElementById("diachi"), 0);
    });
}

function loaichuyen(obj) {
    if (obj.value == "2" || obj.value == "3") {
        $.mkv.XoaTrangData({ Frame: "#thongtinbh" });
        $.mkv.ExtendtionLuu(true, { Frame: "#thongtinbh" });
    } else {
        $.mkv.ExtendtionLuu(false, { Frame: "#thongtinbh" });
    }
    $("#idphongkhambenh").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=idphongkhambenhSearch&loaibn=" + $("#loai").val() + "&idkhoa=" + $("#idkhoa").val(),defaultVal:"- Chọn phòng -" });
    obj.focus();
}
function idphongkhambenhchuyen(obj) {
    $.ajax({
        async:false,
        cache: false,
        url: "ajax/benhnhan_ajax.aspx?do=loadSTT&idphongkhambenh=" + obj +"&idbenhnhan="+$.mkv.queryString("idkhoachinh")
        +"&ngaydk="+$("#ngaydangky").val()+"&idloaiuutien="+$("#idloaiuutien").val(),
        success: function(data) {
            $("#STT").val(data.split('@')[0]);
            $("#slbncho").val(data.split('@')[1]);
            $("#slbnkham").val(data.split('@')[2]);
        }
    });
}
function idloaitainan(obj) {
    $.ajax({
        async:false,
        cache: false,
        url: "ajax/benhnhan_ajax.aspx?do=idloaitainan",
        success: function(data) {
            $("#idloaitainan").val(data.split('@')[0]);
            $("#tenloaitainan").val(data.split('@')[1]);
        }
    });
}
 function idkhoa_change(obj) {
    $("#idphongkhambenh").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=idphongkhambenhSearch&idkhoa=" + obj.value,defaultVal:'-Chọn phòng-'});
}
function TinhTile()
{
    $.ajax({
        cache:false,
            url:"ajax/benhnhan_ajax.aspx?do=getTileBHYT&bh1=" + $("#sobh1").val() + "&bh2=" + $("#sobh2").val() + "&istraituyen=" + $("#TraiTuyen").is(':checked') + "&iscapcuu=" + $("#IsCapCuu").is(':checked') ,
            success: function(data){
                $("#tilebhyt").val(data);
            }
    }); 
}
(function($) {
$.fn.extend({
    chuyenBH: function(sokitu, kieudulieu) {
        $(this).keyup(function(event) {
            if (event.keyCode == 37 || event.keyCode == 39) return;
            if (event.keyCode != 46 && event.keyCode != 8) {
                if ($(this).attr("id") != "sobh6") {
                    if ($(this).val().length == sokitu) {
                        var nextIdx = $('input[type=text]');
                        nextIdx = nextIdx.eq(nextIdx.index(this) + 1);
                        if(nextIdx.val().length == 0)
                            nextIdx.focus();
                    }
                }
            }
        }).keydown(function(event) {
            if (event.keyCode == 37 || event.keyCode == 39) return;
            if (event.keyCode != 46 && event.keyCode != 8 && event.keyCode != 9) {
                if ((kieudulieu != null && kieudulieu == "char") && ((event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode >= 48 && event.keyCode <= 57))) {
                    return false;
                } else if ((kieudulieu != null && kieudulieu == "num") && ((event.keyCode < 96 || event.keyCode > 105) && (event.keyCode < 48 || event.keyCode > 57))) {
                    return false;
                }
                if ($(this).val().length >= sokitu) {
                    return false;
                }
            } else if (event.keyCode == 8) {
                if ($(this).attr("id") != "sobh1") {
                    if ($(this).val().length <= 0) {
                       
                        var nextIdx = $('input[type=text]');
                        nextIdx = nextIdx.eq(nextIdx.index(this) - 1).focus();
                    }
                }
            }
        }).focus(function(){
			$.setFocusCharacter(this,this.value.length);
		}).blur(function() {
            $(this).unbind("keydown");
            $(this).unbind("blur");
        });
    },
    validMaDK: function() {
        $(this).keydown(function(event) {
            if (event.keyCode == 9 || (event.keyCode == 37 || event.keyCode == 39)) return;
            if (((event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode >= 48 && event.keyCode <= 57)) || (event.keyCode == 8 || event.keyCode == 46)) {
                if (event.keyCode != 8 && event.keyCode != 46) {
                    if ($(this).val().substring(0, $.getCharacter(this)).length == 2) {
                        if ($(this).val().indexOf("-") != -1) {
                            $.setFocusCharacter(this, $(this).val().indexOf("-") + 2);
                        } else {
                            $(this).val($(this).val() + "-");
                        }
                    } else {
                        if ($(this).val().indexOf("-") != -1) {
                            if ($(this).val().substring(2, $(this).val().length).length > 3) {
                                return false;
                            }
                        }
                    }
                } else {
                    var nobackspace1 = ['-'];
                    var pos = $.getCharacter(this);
                    if (event.keyCode == 8)
                        if (pos > 0) pos--;
                    if (!$.inArray($(this).val().charAt(pos), nobackspace1)) {
                        $.setFocusCharacter(this, $(this).val().indexOf("-"));
                        return false;
                    }
                }
            } else {
                return false;
            }
        }).keyup(function(event) {
            if (event.keyCode == 9 || (event.keyCode == 37 || event.keyCode == 39)) return;
            if ($(this).val().substring(0, $.getCharacter(this)).length == 2) {
                if ($(this).val().indexOf("-") != -1) {
                    $.setFocusCharacter(this, $(this).val().indexOf("-") + 2);
                } else {
                    $(this).val($(this).val() + "-");
                }
            }
        }).blur(function() {
            $(this).unbind("keydown");
            $(this).unbind("blur");
        });
    }
});
bindiachi=function(obj){
      $(obj).keyup(function(){
            $("#sonha").val($(obj).val().split(',')[0]);
        }).blur(function(){
              $("#sonha").val($(obj).val().split(',')[0]);
        });
};
diachichuyen = function(obj){

    var tempdiachi = "";
    if($("#phuongxaid").val() != "")
        tempdiachi += ","+$("#mkv_phuongxaid").val();
    if($("#quanhuyenid").val() != "")
        tempdiachi += ","+$("#mkv_quanhuyenid").val();
    if($("#tinhid").val() != "" && $("#mkv_tinhid").val().split("_").length > 1)
        tempdiachi += ","+$("#mkv_tinhid").val().split("_")[1];
             
    $(obj).keyup(function(){
        $("#diachi").val(obj.value+tempdiachi);
    }).blur(function(){
        $("#diachi").val(obj.value+tempdiachi);
    });
}
})(jQuery);
function TestNgaySinh(obj) {
var ngay = obj;
if (obj.value.length > 0) {
    var arrngay = ngay.value.split('/');
    if (arrngay.length > 1) {
        return isDate(obj.value);   
    }
    else {
        var ngaymoi ;
        if(obj.value.length >= 7){
            ngaymoi = ngay.value.charAt(0) + ngay.value.charAt(1) + '/' + ngay.value.charAt(2) + ngay.value.charAt(3) + '/' + ngay.value.charAt(4) + ngay.value.charAt(5) + ngay.value.charAt(6) + ngay.value.charAt(7);    
        }else if(obj.value.length >= 5){
            ngaymoi = ngay.value.charAt(0) + ngay.value.charAt(1) + '/' + ngay.value.charAt(2) + ngay.value.charAt(3) + ngay.value.charAt(4) + ngay.value.charAt(5);    
        }else{
            ngaymoi = obj.value;
        }
        obj.value = ngaymoi;
        if (obj.value != "") {
           return isNgaySinh(obj);   
        }
    }4
} 
}
function isNgaySinh(obj) {
var matchArray = obj.value.match(/^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/);
var matchArray1 = obj.value.match(/^(\d{1,2})(\/|-)(\d{4})$/);
var matchArray2 = obj.value.match(/^(\d{4})$/);
var matchArray3 = obj.value.match(/^(\d{1,2})(\/|-)(\d{1,2})$/);
if (matchArray == null && matchArray1 == null && matchArray2 == null && matchArray3 == null) {
     alert("Ngày tháng không hợp lệ.");
    obj.focus();
    return false;
}
if(matchArray != null){
   return isDate(obj.value);
}else if(matchArray1 != null){
    month = matchArray1[1];
    year = matchArray1[3];

    if (month < 1 || month > 12) {
        alert("Tháng phải giữa 1 và 12.");
        return false;
    }
    if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) {
         alert("Tháng " + month + " không có 31 ngày!");
        return false;
    }
}else if(matchArray3 != null){
    day = matchArray3[1];
    month = matchArray3[3];

if (month < 1 || month > 12) {
     alert("Tháng phải giữa 1 và 12.");
    return false;
}

if (day < 1 || day > 31) {
     alert("Ngày phải giữa 1 và 31 ngày.");
    return false;
}

if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) {
     alert("Tháng " + month + " không có 31 ngày!");
    return false;
}

if (month == 2) {
        if (day > 29) {
             alert("Tháng 2 không có " + day + " ngày!");
            return false;
        }
    }
}
return true;
}
function TinhTuoiBenhNhan()
{
$.ajax({
        cache:false,
            url:"ajax/benhnhan_ajax.aspx?do=TinhTuoiBenhNhan&NgaySinh=" + $("#ngaysinh").val(),
            success: function(data){
                 if(data!="")
                 {
                  
                   $("#SoTuoi").val(data.split(';')[0]);
                   $("#SoThang").val(data.split(';')[1]);
                 }
            }
    });
}
function TinhNamSinh_TheoTuoi()
{
if( $("#ngaysinh").val()!="") return;
if( $("#SoTuoi").val()=="" ) return;
$.ajax({
        cache:false,
            url:"ajax/benhnhan_ajax.aspx?do=TinhNamSinh_TheoTuoi&Tuoi=" + $("#SoTuoi").val(),
            success: function(data){
                 if(data!="")
                 {
                   $("#ngaysinh").val(data);
                 }
            }
    });
}
function TinhNamSinh_TheoThang()
{
if( $("#ngaysinh").val()!="" && $("#SoTuoi").val()!="0" )
        return false;
if( $("#SoThang").val()=="" ) return;
$.ajax({
        cache:false,
            url:"ajax/benhnhan_ajax.aspx?do=TinhNamSinh_TheoThang&Thang=" + $("#SoThang").val(),
            success: function(data){
                 if(data!="")
                 {
                   $("#ngaysinh").val(data);
                   $("#SoTuoi").val('0');
                 }
            }
    });
}
function check_chungminhthu(obj)
{
if($(obj).val()=="") return;
 $.ajax({
        cache:false,
        async:false,
            url:"ajax/benhnhan_ajax.aspx?do=check_chungminhthu&chungminhthu=" + $(obj).val(),
            success: function(data){
                 if(data!="")
                 {
                        $(obj).focus();
                    alert(data);
                 }
                 else
                 {
                    $("#diverror").click();
                 }
            }
    });
}
function check_dodai(obj,sokytu)
{
    if($(obj).val().length!=sokytu)
    {
        alert("Số ký tự không được khác " + sokytu );
        $(obj).focus();
        return false;
    }
    return true;
    
}
function check_ngaybaohiem()
{
     if($("#ngaybatdau").val()=="" && $("#sobh1").val().toUpperCase()!="TE"){
          alert("Ngày bắt đầu không bỏ trống");
            $("#ngaybatdau").focus();
            return false;
      }
       
       //--------------------------------------------------------
         if($("#ngayhethan").val()=="" && $("#sobh1").val().toUpperCase()!="TE")
         {
              alert("Ngày hết hạn không bỏ trống");
                $("#ngayhethan").focus();
                return false;
         }
       if(new Date($("#ngaybatdau").val().split('/')[2],$("#ngaybatdau").val().split('/')[1],$("#ngaybatdau").val().split('/')[0])>new Date(yyyy,mm,dd))
       {
            alert("Ngày bắt đầu không lớn hơn ngày hiện tại");
            $("#ngaybatdau").focus();
            return false;
        }
        var nkt=new Date($("#ngayhethan").val().split('/')[2],$("#ngayhethan").val().split('/')[1],$("#ngayhethan").val().split('/')[0]);
        var nbd=new Date($("#ngaybatdau").val().split('/')[2],$("#ngaybatdau").val().split('/')[1],$("#ngaybatdau").val().split('/')[0]);
        if(nkt<nbd)
        {
            alert("Ngày bắt đầu không lớn hơn ngày hết hạn");
            $("#ngayhethan").focus();
            return false;
        } 
        if(nkt<new Date(yyyy,mm,dd))
        { 
            alert("Ngày hết hạn không nhỏ hơn ngày hiện tại ");
            $("#ngayhethan").focus();
            return false;
        }
        
     return true;
}
function displayChildTable(obj,childTableName)
{
    if(obj.innerText=="+")
    {
        $("#"+childTableName).css("display","");
        obj.innerText="-";
    }
    else if(obj.innerText=="-")
    {
        $("#"+childTableName).css("display","none");
        obj.innerText="+";
    }
}

function TinhLaiTien( )
{
      $.ajax({ 
        async:true,
        cache: false,
        url: "ajax/benhnhan_ajax.aspx?do=TinhLaiTien&idbenhnhan="+$.mkv.queryString("idkhoachinh"),
        success: function(data) {
                                        $.mkv.myalert(data,1000,"success");
                                        
                                 }
    });
    
}
function InTheBN(obj)
{
    alert("đf");
}