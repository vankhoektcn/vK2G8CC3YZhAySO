
 $(document).ready(function() {
       if ($.browser.msie<8) {
        $("input[type=text],input[type=checkbox],select,textarea").live("focus",function(){
            $(this).css("background-color","yellow");
          }).live("blur",function(){
                  $(this).css("background-color","");
          });
          
        }
      $("#loai").bind("change",function(){
           if($(this)[0].selectedIndex==1){
                $("#thongtinbh").css("display","none");
                    $("#dienthoai").bind("blur",function(){
                        $("#idphongkhambenh").focus();
                    });
           }else{
                $("#thongtinbh").css("display","block");
           }
      });
      $.mkv.moveUpandDown("#gridTable");
        
      $(window).focus(function(){
                if($.mkv.queryString("isClose") == "1"){
                        $("#moi").click();
                        $.mkv.removeQueryString("isClose");
                    }
       });
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();
        if (dd < 10) { dd = '0' + dd }
        if (mm < 10) { mm = '0' + mm }
        $("#ngaydangky").val(dd + "/" + mm + "/" + yyyy);
        $("#ngaytiepnhan").val(dd + "/" + mm + "/" + yyyy);
        var h=today.getHours();
        var m=today.getMinutes();
        if(h<10)h="0"+h;
        if(m<10)m="0"+m;
        $("#gio").val(h);
        $("#phut").val(m);
        $("#ngaydangky").bind("focus",function(){
            $(this).datepick();
        });
        $("#tenbenhnhan").focus();
        
        // Bind DropDownList
        $("#idloaiuutien").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=idloaiuutienSearch", defaultVal: "" });
         $("#quoctich").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=idquoctichsearch", defaultVal: "- Quốc tịch -" });
          $("#nghenghiep").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=idnghenghiepsearch", defaultVal: "- Nghề nghiệp -" });
           $("#dantoc").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=iddantocsearch", defaultVal: "- Dân tộc - " });
           
        $("#tinhid").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=tinhidSearch", defaultVal: "- Tỉnh -"},null,function(data){
            $("#quanhuyenid").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=quanhuyenidSearch&tinhid="+$("#tinhid").val(), defaultVal: "- Quận/Huyện -"},null,function(){
                $("#phuongxaid").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=phuongxaidSearch&quanhuyenid="+$("#quanhuyenid").val(), defaultVal: "- Phường xã -"});
            });
             $("#tinhid").val('83');
             tinhidchuyen2();
        });
        $("#idkhoa").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=idkhoasearch",async:false},null,function(){
              if($.mkv.queryString("idkhoa")!=null && $.mkv.queryString("idkhoa")!="" ){
                $("#idkhoa").val($.mkv.queryString("idkhoa"));
                     $("#idkhoa").attr("disabled",true);
              }else{
                 $("#idkhoa")[0].selectedIndex=1;
              }
        });
        $("#loai").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=loaiSearch", defaultVal: "" ,async:false},null,function(){
            $("#idphongkhambenh").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=idphongkhambenhSearch&loaibn=" + $.mkv.queryString("loaibn") + "&idkhoa=" + $("#idkhoa").val(),defaultVal:"- Chọn phòng -" ,async:false},null,function(){
                $("#idchuyenkhoa").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=idChuyenKhoaSearch&ngaydk=" + $("#ngaydangky").val()+"&phongid=" + $("#idphongkhambenh").val(),async:false});
            });
        });
        $("#idphongkhambenh").bind("change",function(){
            idphongkhambenhchuyen($(this).val());
        });
       
        //////////
        macdinhbaohiem();
        setControlFind($.mkv.queryString("idkhoachinh"));
        $("#luu").click(function() {
          
            
            $(this).Luu({
                ajax: "ajax/benhnhan_ajax.aspx?do=Luu"
            }, function() {
                if ($("#ngaytiepnhan").val() == "") {
                    $.mkv.myerror("Ngày tiếp nhận không bỏ trống.");
                    return false;
                }
                else if ($("#tenbenhnhan").val() == "") {
                    $.mkv.myerror("Tên bệnh nhân không bỏ trống.");
                    return false;
                }
                else if ($("#diachi").val() == "") {
                    $.mkv.myerror("Địa chỉ không bỏ trống.");
                    return false;
                }
                else if ($("#ngaysinh").val() == "") {
                    $.mkv.myerror("Ngày sinh không được bỏ trống.");
                    return false;
                }
                else if ($("#idloaiuutien").val() == "") {
                    $.mkv.myerror("Chưa chọn loại ưu tiên.");
                    return false;
                }
                else if ($("#loai").val() == "") {
                    $.mkv.myerror("Chưa chọn loại khám.");
                    return false;
                }
                else if ($("#loai").val() == "1") {
                    if ($("#ngaybatdau").val() != "" && $("#ngayketthuc").val() != "") {
                        var nbd = new Date($("#ngaybatdau").val().substring(6, 10), $("#ngaybatdau").val().substring(3, 5), $("#ngaybatdau").val().substring(0, 2));
                        var nkt = new Date($("#ngayhethan").val().substring(6, 10), $("#ngayhethan").val().substring(3, 5), $("#ngayhethan").val().substring(0, 2));
                        if (nbd > new Date(yyyy, mm, dd)) {
                            $.mkv.myerror("Ngày bắt đầu không lớn hơn ngày hiện tại.");
                            $("#ngaybatdau").focus();
                            return false;
                        } else if (nkt < nbd) {
                            $.mkv.myerror("Ngày kết thúc không nhỏ hơn ngày bắt đầu.");
                            $("#ngayhethan").focus();
                            return false;
                        }
                    } else {
                        $.mkv.myerror("Ngày bắt đầu và ngày kết thúc không bỏ trống.");
                        $("#ngaybatdau").focus();
                        return false;
                    }
                }
                return true;
            }, function(data) {
                if (data.indexOf("@") != -1) {
                    var val = data.split('@');
                    $.mkv.queryString("idkhoachinh", val[0]);
                    $("#mabenhnhan").val(val[1]);
                }
                 $.mkv.ExtendtionLuu(false, { Frame: "#thontindangkykham"});
                setTimeout(function() { $("#dangKy").focus() }, 100);
            });
           
            
           $("#tenbenhnhan").focus();
            if ($("#loai").val() == "2")
                $.mkv.ExtendtionLuu(true, { Frame: "#thongtinbh" });
               
        });
        $("#moi").click(function() {
            var loaibn=$("#loai").val();
            $(this).Moi();
              today = new Date();
            dd = today.getDate();
            mm = today.getMonth() + 1; //January is 0!
            yyyy = today.getFullYear();
            if (dd < 10) { dd = '0' + dd }
            if (mm < 10) { mm = '0' + mm }
            $("#ngaytiepnhan").val(dd + "/" + mm + "/" + yyyy);
            $("#ngaydangky").val(dd + "/" + mm + "/" + yyyy);
            var h=today.getHours();
            var m=today.getMinutes();
            if(h<10)h="0"+h;
            if(m<10)m="0"+m;
            $("#gio").val(h);
            $("#phut").val(m);
            macdinhbaohiem();
            $("#tenbenhnhan").focus();
            $("#dangKy").css("display", "");
            $("#STT").attr("disabled","disabled");
            $("#slbncho").attr("disabled","disabled");
            $("#slbnkham").attr("disabled","disabled");
            $("#idkhoa").val("1");
            $("#loai").val(loaibn);
            $("#loai").attr("disabled","disabled");
            if($.mkv.queryString("idkhoa")=="15")$("#loai").attr("disabled",false);
            loadTableAjaxDangkykham();
            AllowDKKThem="0";
            $("#_luu").attr("id","luu");
            if($.mkv.queryString("idkhoa")!=null && $.mkv.queryString("idkhoa")!=""){
                $("#idkhoa").val($.mkv.queryString("idkhoa"));
                    $("#idkhoa").attr("disabled",true);
            }
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
        
            $.mkv.loading();
            $(this).TimKiem({
                ajax: "ajax/benhnhan_ajax.aspx?do=dangkykhambenh&idbenhnhan=" + $.mkv.queryString("idkhoachinh")+"&tenbenhnhan="+$("#tenbenhnhan").val()+"&AllowDKKThem="+AllowDKKThem
                         //+"&IdKhoa=" + IdKhoa
                         + "&sobh1=" + $("#sobh1").val()
                         + "&sobh2=" + $("#sobh2").val()
                         + "&sobh3=" + $("#sobh3").val()
                         + "&sobh4=" + $("#sobh4").val()
                         + "&sobh5=" + $("#sobh5").val()
                         + "&sobh6=" + $("#sobh6").val()
                         + "&ismuaso=" + $("#ismuaso").is(":checked")
                         + "&isNotThuPhiKham=" + $("#isNotThuPhiKham").is(":checked") 
                         + "&gio="+ $("#gio").val() + "&phut=" + $("#phut").val()
                         , Frame: "#thontindangkykham",showPopup:false
            }, function() {
                if ($.mkv.queryString("idkhoachinh") == "") {
                    $.mkv.myerror("Chưa có bệnh nhân.");
                    return false;
                }else if ($("#ngaydangky").val() == "") {
                    $.mkv.myerror("Chưa chọn ngày đăng ký.");
                    return false;
                }else if ($("#idphongkhambenh").val() == "") {
                     var ismuaso=$("#ismuaso").is(':checked');
                     if(ismuaso!=true)
                     {
                           $.mkv.myerror("Chưa chọn phòng khám.");
                             $("#loadingAjax").remove();
                            return false;
                    }
                }else if ($("#idchuyenkhoa").val() == "") {
                   // $.mkv.myerror("Chưa chọn chuyên khoa.");
                    //return false;
                }
                return true;
            },function(value) {
                if(value=="1")
                {
                    $("#dangKy").css("display", "none");
                    $("#moi").focus();
                     $("#loadingAjax").remove();
                    $.mkv.myalert("Đăng ký khám thành công", 1000, "success");
                    loadTableAjaxDangkykham();
                    AllowDKKThem="0";
                }
                else
                {
                    $.mkv.myerror(value);
                    AllowDKKThem="1";
                }

            });
        });
        $("#dkNhieuKhoa").click(function(){
              $.mkv.queryString("isClose","1");
            window.open("dangkykham3.aspx#idbenhnhan=" + $.mkv.queryString("idkhoachinh") + "&ngaydangky=" +$("#ngaydangky").val() + "&LoaiBN=" + $("#loai").val() + "&idkhoa=" + $("#idkhoa").val(),"_blank");
         
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
                            window.open("hs_DangKyCLS3.aspx?idkhoachinh="+data+"","_blank","location=0,menubar=0,statusbar=0,scrollbar=0");
                        }
                    }
             });                        
        });
    });
    function xacdinhnhapvien(control)
    {
         //nvk sua 
        var IdKhoaNhap=document.getElementById('idkhoachuyen').value;
        if(IdKhoaNhap=="0" || IdKhoaNhap=="" || IdKhoaNhap==" "){
            $.mkv.myerror("Chưa chọn khoa chuyển đến");
            return false;
        }
        $.ajax({
            aysnc:false,
            cache:false,
            type:"post",
            dataType:"text",
            url:"ajax/benhnhan_ajax.aspx?do=LuuNhapVien&idbenhnhan="+$("#gridTableNhapVien").find("#idbenhnhan").val()+"&idbacsi="+$("#gridTableNhapVien").find("#idbacsi").val()+"&idicd="+$("#gridTableNhapVien").find("#idchandoan").val()+"&ngaynhapvien="+$("#gridTableNhapVien").find("#ngaynhapvien").val()+"&idkhoanhap="+$("#gridTableNhapVien").find("#idkhoanhap").val()+"&idkhoachuyen="+$("#gridTableNhapVien").find("#idkhoachuyen").val()+"&idphong="+$("#gridTableNhapVien").find("#idphong").val(),
            success:function(value){
                  if(value=="0"){
                     $.mkv.myalert("Thông tin không thay đổi",2000,"info");  
                  }else if(value=="1"){
                     $.mkv.myalert("Thay đổi thông tin thành công",2000,"success");  
                  }
                   else{
                     $.mkv.myalert(value,2000,"success");  
                  }
            }
        });
       
  
    }
    function nhapvienmoi(control){
        if($.mkv.queryString("idkhoachinh") ==null || $.mkv.queryString("idkhoachinh") =="")
            return;
        $(control).TimKiem({ajax:'ajax/benhnhan_ajax.aspx?do=nhapvienmoi&idbenhnhan='+$.mkv.queryString("idkhoachinh"),title:'Thông tin nhập viện',width:'820px',height:'310px'
        });
      
    }
    function setControlFind(idkhoatimkiem) {
        if (idkhoatimkiem != "" && idkhoatimkiem != null) {
            $.BindFind({ ajax: "ajax/benhnhan_ajax.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem },null,function(){
                $.mkv.ExtendtionLuu(false, { Frame: "#thontindangkykham"});
                loadTableAjaxDangkykham();
               idphongkhambenhchuyen($("#idphongkhambenh").val());
                $("#STT").attr("disabled","disabled");
                 $("#slbncho").attr("disabled","disabled");
                    $("#slbnkham").attr("disabled","disabled");
                
            });
        }
    }
  
    function idkhoa_noitru_search(obj) {
    $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=idkhoa_noitru_search", {
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
          $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
        });
    }  
   
      function idkhoasearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=idkhoasearch", {
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
          $("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
        setTimeout(function() {
            obj.focus();
        }, 100);
        });
    }  
      function idphongkhambenhsearch(obj) {
    $(obj).unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=idphongkhambenhSearch&idkhoa="+$("#idkhoanhap").val(), {
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
    
        window.open("dangkykham3.aspx?dkMenu=tiepnhan#idbenhnhan=" + $.mkv.queryString("idkhoachinh") + "&LoaiBN=" + $("#loai").val() + "&idkhoachinh=" + iddangkykham + "&ngaydangky=" + ngaydangky + "&idkhoa=" + $("#idkhoa").val() ,'_blank','width=500,location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
    }
    function KiemTraBN(control)
    {   
  	    $.ajax({
			    type: "GET",
			    cache: false,
			    dataType: "text",
			    url:"ajax/benhnhan_ajax.aspx?do=checkBN&tenbenhnhan="+ encodeURIComponent($("#tenbenhnhan").val()) + "&ngaysinh=" + $("#ngaysinh").val(),
			    success: function(value) {
			        if(value!="" && value!=null){
			             if ($("#divTimKiem").length == 0) {
		                    $("<div id=\"divTimKiem\" ondblclick='$.mkv.fullscreens(this);' onmove=\"$.mkv.scrollyactive('" + $(control).attr("id") + "')\" onkeyup=\"$.mkv.eventesc(this,'" + $(control).attr("id") + "');\" />").css({ 'background': '#efefef', 'margin': 'auto', 'top': '0%', 'left': '15%', 'position': 'fixed', 'display': 'none', 'border': '1px solid #4297d7', 'width': '950px', 'height': '330px', 'padding': '0px 2px 30px 0px', 'z-index': '5000' }).appendTo(document.body);
		                        $("#divTimKiem").animate({ height: 'show', right: '+100', top: '+100', opacity: 'show' }, 'slow').draggable({ handle: '#divTimKiemTitle' }).resizable();
		                        $("<p id='divTimKiemTitle' />").css({ 'border': '1px solid #fcfdfd', 'background': '#2191c0 url(../images/ui-bg_gloss-wave_75_2191c0_500x100.png) 50% 50% repeat-x', 'color': '#eaf5f7', 'cursor': 'move', 'font-weight': 'bold', 'float': 'left', 'width': '100%', 'padding': '10px 0px 3px 0px','margin':'0' }).html("&nbsp;&nbsp;&nbsp;"  + "Danh sách bệnh nhân trùng tên").appendTo("#divTimKiem");
		                        $("<p onscroll=\"$.mkv.scrollyactive('" + $(control).attr("id") + "')\" id=\"divSetTimKiem\" />").css({ 'background': '#fff', 'width': '99.5%', 'height': '97%', 'float': 'right', 'margin-top': '0px', 'overflow': 'scroll', 'text-align': 'center', 'border': '1px solid #cfcfcf' }).appendTo("#divTimKiem");
		                        $("<img onclick=\"$.mkv.dongtimkiem('" + $(control).attr("id") + "');\" src=\"../images/close.gif\" />").css({ 'float': 'right', 'cursor': 'pointer', 'padding-right': '5px', 'top': '2px', 'right': '0', 'position': 'absolute' }).appendTo("#divTimKiemTitle");
	                        }
				        $("#divSetTimKiem").html(value);
				            if ($("#divSetTimKiem").find("table").find("tr").length < 3) $("#divSetTimKiem").find("table").find("tr").eq(1).click();
				       
				        
				    }
			    },
			    error: function(data) {
				    $.mkv.closeDivTimKiem();
				    if (data.responseText.length) $.mkv.myerror(data.responseText);
				    //else if ($.mkv.queryString("load") != '1') $.mkv.myalert("Không tìm thấy dữ liệu !", 2000, "info");
			    }
		    });
    
    }
    function Tim(e,control,page)
    {
        var t=e.keyCode ? e.keyCode : e.charCode;
        if(t==13)
        {
          if (page == null) page = "1";
                $(control).TimKiem({
                    ajax: "ajax/benhnhan_ajax.aspx?do=TimKiem&page=" + page
            });
        }
    }
    function Find(control, page) {
        if (page == null) page = "1";
        $(control).TimKiem({
            ajax: "ajax/benhnhan_ajax.aspx?do=TimKiem&page=" + page
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
                }
            });
        }else{
            $("#tableDangkykham").html("");
        }
    }
   
    function ktramabh(obj) {
        $.ajax({ cache: false,
            url: "ajax/benhnhan_ajax.aspx?do=ktramabh&mabh=" + obj.value,
            success: function(data) {
                if (data.split('|')[3] == "1"){
                    $("#TraiTuyen").attr("checked", true);
                }
                else{
                    $("#TraiTuyen").attr("checked", false);
                    }
                $("#noidangkykcb").val(data.split('|')[4]);
                if(data=="|||")
                alert("Không có mã đăng ký bảo hiểm này");
            }
        });
    }
     function TimDiaChi_BH()
		{
			$("#txtMaDiaChi").unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=TimDiaChi",
				{formatItem: function(data) {
					return data[0];
				},width: 700,scroll: true,selectFirst: true}
        )

				.result(function(event, data) {
                   $("#txtMaDiaChi").val(data[1]);
                   $("#diachi").val(data[2]);
                   $("#diachi").focus();
				});
	}
	
	   function TimDiaChi_DV()
		{
			$("#txtMaDiaChi").unautocomplete().autocomplete("ajax/benhnhan_ajax.aspx?do=TimDiaChi",
				{formatItem: function(data) {
					return data[0];
				},width: 700,scroll: true,selectFirst: true}
        )

				.result(function(event, data) {
                   $("#txtMaDiaChi").val(data[1]);
                   $("#diachi").val(data[2]);
                   $("#diachi").focus();
				});
	}
    function tinhidchuyen(obj) {
        
        $("#quanhuyenid").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=quanhuyenidSearch&tinhid="+$("#tinhid").val(), defaultVal: "- Quận/Huyện -" });
    }
      function tinhidchuyen2( ) {
        
        $("#quanhuyenid").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=quanhuyenidSearch&tinhid="+$("#tinhid").val(), defaultVal: "- Quận/Huyện -" });
    }
    function quanhuyenidchuyen(obj) {
        $("#phuongxaid").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=phuongxaidSearch&quanhuyenid="+$("#quanhuyenid").val(), defaultVal: "- Phường xã -" });    
    }
    function loaichuyen(obj) {
        if (obj.value == "2" || obj.value == "3") {
            $.mkv.XoaTrangData({ Frame: "#thongtinbh" });
            $.mkv.ExtendtionLuu(true, { Frame: "#thongtinbh" });
        } else {
            $.mkv.ExtendtionLuu(false, { Frame: "#thongtinbh" });
            macdinhbaohiem();
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
     function idkhoa_change(obj) {
        $("#idphongkhambenh").DropList({ ajax: "ajax/benhnhan_ajax.aspx?do=idphongkhambenhSearch&idkhoa=" + obj.value,defaultVal:'-Chọn phòng-'});
    }
    function macdinhbaohiem() {
        if($("#loai").val()=="1")
        {
            $("#noidangkykcb").val("BV ĐK MINH ĐỨC");
            $("#MaDangKy_KCB_bandau").val("83-999");
        }
    }
   function TinhTile()
   {
     
        $.ajax({
            cache:false,
                url:"ajax/benhnhan_ajax.aspx?do=getTileBHYT&bh1=" + $("#sobh1").val() + "&bh2=" + $("#sobh2").val() + "&istraituyen=" + $("#TraiTuyen").is(':checked') + "&iscapcuu=" + $("#IsCapCuu").is(':checked') ,
                success: function(data){
                    $("#tileBHYT").val(data);
                }
        }); 
   }
// xu ly chuoi bao hiem
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
    diachichuyen = function(obj){
        if($("#txtMaDiaChi").val() != "" && $("#diachi").val() != "")
            return;
        var tempdiachi = "";
        if($("#phuongxaid").val() != "")
            tempdiachi += ","+$("#phuongxaid").find("option:selected").text();
        if($("#quanhuyenid").val() != "")
            tempdiachi += ","+$("#quanhuyenid").find("option:selected").text();
        if($("#tinhid").val() != "" && $("#tinhid").find("option:selected").text().split('_').length > 1)
            tempdiachi += ","+$("#tinhid").find("option:selected").text().split('_')[1];
                 
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
             isDates(obj);   
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
                isNgaySinh(obj);   
            }
        }
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
    }
    if(matchArray != null){
        isDate(obj.value);
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
 $(function(){
    if($.mkv.queryString("idkhoa")=="15"){
        $("#thongtinbh").css("display","none");
            $("#loai")[0].selectedIndex=1;
            $("#loai").attr("disabled",false);
            $("#muaso").css("display","none");
             $("#dkNhieuKhoa").css("display","none");
             $("#dangkyCLS").css("display","none");
             $("#dangkyCLS_edit").css("display","none");
             $("#nhapvien").css("display","none");
                $("#dienthoai").blur(function(){
                    $("#nghenghiep").focus();
                });
      }
      else{
        $("#thuphicapcuu").css("display","none");
      }
     if($.mkv.queryString("idkhoa")=="25"){
          $("#muaso").css("display","none");
             $("#dkNhieuKhoa").css("display","none");
             $("#dangkyCLS").css("display","none");
             $("#dangkyCLS_edit").css("display","none");
             $("#nhapvien").css("display","none");
        $("#thuphicapcuu").css("display","none");
             
     }
     if($.mkv.queryString("loaibn")=="1"){
        $("#thongtinbh").css("display","block");
            $("#loai").val("1");
             $("#loai").attr("disabled",true);
              $("#dienthoai").blur(function(){
                    $("#sobh1").focus();
              });
              
             
     }else if($.mkv.queryString("loaibn")=="0"){
        $("#thongtinbh").css("display","none");
            $("#loai").val("2");
            $("#loai").attr("disabled",true);
               $("#dienthoai").blur(function(){
                    $("#idphongkhambenh").focus();
              });    
      }
     
});