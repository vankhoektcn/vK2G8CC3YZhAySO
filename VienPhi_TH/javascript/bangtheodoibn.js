// JScript File
$(document).ready(function(){
   setControlFind($.mkv.queryString("idkhoachinh")); 
   $("#Tim").click(function(){
        Find(this);
   });
   $("#Moi").click(function(){
        $(this).Moi();
        $("a").attr("disabled",false);
        loaddsphieuchidinhcls();
        loaddsphieuchidinhdvkt();
        loaddsphieuchidinhthuoc();
        loadTableAjaxDSPhieuThuHoanTra();
        loadTableAjaxChitietCongNo();        
   });
   $("#bangke02").click(function(){
        window.open("../noitru/frm_Rpt_BieuMau02.aspx?idchitietdangkykham=" + $("#idchitietdangkykham").val(),"_blank");
   });
   $("#toathuoc").click(function(){
    if($("#idkhambenh").val()!=""){
        window.open("../KhamBenh_TH/rpt_Toathuoc.aspx?IdKhamBenh=" + $("#idkhambenh").val() +"&IsBHYT=0&IsAll=0", '_blank', 'location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
    }else{
        $.mkv.myerror("Không có toa thuốc nào !");
    }
   });
   $("#bangke01").click(function(){
        window.open("../vienphi_bh/frm_rpt_chiphikhambenh.aspx?idphieutt=" + $.mkv.queryString("idkhoachinh"));
   });
   $("#bangkedongchitra").click(function(){
        window.open("../VienPhi_BH/frm_rpt_DongChiTra.aspx?ID=" + $.mkv.queryString("idkhoachinh"));
   });
   
   
   $("#chitietdangkykham").click(function(){
        window.open("../danhmuc_json/web/chitietdangkykham2.aspx?IDBENHBHDONGTIEN=" + $.mkv.queryString("idkhoachinh"));
   });
    $("#chitietphieuxuatkho").click(function(){
        window.open("../danhmuc_json/web/chitietphieuxuatkho2.aspx?IDBENHBHDONGTIEN=" + $.mkv.queryString("idkhoachinh"));
   });
   $("#chitietcanlamsang").click(function(){
        window.open("../danhmuc_json/web/khambenhcanlamsan2.aspx?IDBENHBHDONGTIEN=" + $.mkv.queryString("idkhoachinh"));
   });
   $("#chitiettiengiuong").click(function(){
        window.open("../danhmuc_json/web/KB_ChiTietGiuongBN2.aspx?IDBENHBHDONGTIEN=" + $.mkv.queryString("idkhoachinh"));
   });  
   
   $("#tinhlaitien").click(function(){
              if($.mkv.queryString("idkhoachinh") ==null || $.mkv.queryString("idkhoachinh") =="")    return;
              $.ajax({ 
                async:true,
                cache: false,
                url: "ajax/BangTDCNBenhNhan.ashx?do=tinhlaitien&IDBENHBHDONGTIEN=" +$.mkv.queryString("idkhoachinh")  ,
                success: function(data) {
                                                $.mkv.myalert(data,1000,"success");
                                                
                                         }
            });
        
        
   });  
   
});
function setPrintToaThuoc(idkhambenh)
 {
    window.open("../KhamBenh_TH/rpt_Toathuoc.aspx?idkhambenh=" + idkhambenh + "&isall=1" ,"_blank");
 }
 function setPrintCLS(idkhambenh)
 {
    window.open("../KhamBenh_TH/rptPhieuChiDinh.aspx?idkhambenh=" + idkhambenh + "&isdvkt=0&isall=1" ,"_blank");
 }
 function setPrintDVKT(idkhambenh)
 {
    window.open("../KhamBenh_TH/rptPhieuChiDinh.aspx?idkhambenh=" + idkhambenh + "&isdvkt=1&isall=1","_blank");
 }
 function setPrint(maphieu,loaithu)
 {
    window.open("frm_rpt_InPhieuThuTH.aspx?MaPhieu=" + maphieu + "&LoaiThu=" + loaithu + "&InTrucTiep=0","_blank");
 }
 function setHoanTra(maphieu)
 {
    window.open("frm_rpt_InPhieuThuTH.aspx?MaPhieu=" + maphieu + "&InTrucTiep=0&IsDaHuy=1","_blank");
 }
 function setControlFind(idkhoatimkiem) {
        if (idkhoatimkiem != "" && idkhoatimkiem != null) {
            $.BindFind({ajax:"ajax/BangTDCNBenhNhan.ashx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem
                },null,function(){
                    if($("#isnoitru").val()=="True"){
                        $("#bangke02").attr("disabled",false);
                        $("#bangke01").attr("disabled",true);
                    }else
                    {
                        if($("#isbhyt").val()=="True")
                        {
                            $("#bangke01").attr("disabled",false);
                        }else{
                            $("#bangke01").attr("disabled",true);
                        }
                        $("#bangke02").attr("disabled",true);
                    }
                    if($("#isbhyt").val()=="True"){
                        $("#bangkedongchitra").attr("disabled",false);
                    }else{
                        $("#bangkedongchitra").attr("disabled",true);
                    }
                    loadTableAjaxDSPhieuThuHoanTra();
                    loadTableAjaxChitietCongNo();
                    loaddsphieuchidinhcls();
                    loaddsphieuchidinhdvkt();
                    loaddsphieuchidinhthuoc();
            });
        }
}
function Find(control, page) {
    if (page == null) page = "1";
    $(control).TimKiem({
        ajax: "ajax/BangTDCNBenhNhan.ashx?do=TimKiem&page=" + page
    },null,function(data){
        if(data==null || data==""){
            $.mkv.myalert("Không tìm thấy dữ liệu !",1000,"info");
            $.mkv.closeDivTimKiem();
        }
    });
}
function loaddsphieuchidinhcls(idkhoachinh,page)
{
    if($.mkv.queryString("idkhoachinh") != ""){
        if(page == null)page = "1";
        $.ajax({
            async:true,
            cache:false,
            dataType:"text",
            type:"GET",
            url:"ajax/BangTDCNBenhNhan.ashx?do=loaddsphieuchidinhcls&id="+$.mkv.queryString("idkhoachinh") + "&page=" + page,
            success:function(data){
                $("#tableAjaxPhieuChiDinhCLS").html(data);
            }
        });
    }else{
        $("#tableAjaxPhieuChiDinhCLS").html("");
    }
}
function loaddsphieuchidinhdvkt(idkhoachinh,page)
{
    if($.mkv.queryString("idkhoachinh") != ""){
        if(page == null)page = "1";
        $.ajax({
            async:true,
            cache:false,
            dataType:"text",
            type:"GET",
            url:"ajax/BangTDCNBenhNhan.ashx?do=loaddsphieuchidinhdvkt&id="+$.mkv.queryString("idkhoachinh") + "&page=" + page,
            success:function(data){
                $("#tableAjaxPhieuChiDinhDVKT").html(data);
            }
        });
    }else{
        $("#tableAjaxPhieuChiDinhDVKT").html("");
    }
}
function loaddsphieuchidinhthuoc(idkhoachinh,page)
{
    if($.mkv.queryString("idkhoachinh") != ""){
        if(page == null)page = "1";
        $.ajax({
            async:true,
            cache:false,
            dataType:"text",
            type:"GET",
            url:"ajax/BangTDCNBenhNhan.ashx?do=loaddstoathuoc&id="+$.mkv.queryString("idkhoachinh") + "&page=" + page,
            success:function(data){
                $("#tableAjaxToaThuoc").html(data);
            }
        });
    }else{
        $("#tableAjaxToaThuoc").html("");
    }
}
function loadTableAjaxDSPhieuThuHoanTra(idkhoachinh,page)
{
    if($.mkv.queryString("idkhoachinh") != ""){
        if(page == null)page = "1";
        $.ajax({
            cache:false,
            dataType:"text",
            type:"GET",
            url:"ajax/BangTDCNBenhNhan.ashx?do=loadchitietdsphieuthuhoantra&id="+$.mkv.queryString("idkhoachinh") + "&page=" + page,
            success:function(data){
                $("#tableAjaxDsPhieuThuHoanTra").html(data);
            }
        });
    }else{
        $("#tableAjaxDsPhieuThuHoanTra").html("");
    }
}
function loadTableAjaxChitietCongNo(idkhoachinh,page)
{
    if($.mkv.queryString("idkhoachinh") != ""){
        if(page == null)page = "1";
            $.mkv.loading();
        $.ajax({
            cache:false,
            dataType:"text",
            type:"GET",
            url:"ajax/BangTDCNBenhNhan.ashx?do=loadchitietcongno&id="+$.mkv.queryString("idkhoachinh") + "&page=" + page,
            success:function(data){
                $("#loadingAjax").remove();
                $("#tableAjaxChitietCongNo").html(data);
            }
        });
    }else{
        $("#tableAjaxChitietCongNo").html("");
    }
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
})(jQuery);

