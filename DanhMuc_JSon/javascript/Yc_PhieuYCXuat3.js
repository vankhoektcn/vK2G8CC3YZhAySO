         $(document).ready(function() {
         //-------------------------------------------------------
         //vi da co giao dien chuyen xu ly cho viec lay danh sach chi dinh thuoc,nen khoa chuc nang lay danh sach o day lai
           $("#div_LayDS").css("display","none");
         ///------------------------------------------------------
         
         
         
         
                 $.mkv.moveUpandDown("#tablefind");
               setControlFind($.mkv.queryString("idkhoachinh"));
                 $("#luu").click(function () {
                    if(this.id=="_luu")
                    {
                       $(this).Luu({
                             ajax:"../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=Luu"
                          },function(){
						    return CheckValidSaveYeuCau();
					      },function () {
                               $.LuuTable({
                                     ajax:"../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=luuTableYc_PhieuYcXuatChiTiet&IdPhieuYc=" + $.mkv.queryString("idkhoachinh"),
                                     tablename:"#gridTable"
                               });
					           if($("#IsDuyetIn").is(":checked"))
					                $("#isviewIn").val("1");
					           else
					                $("#isviewIn").val("0");
					           setViewIn();
					           GetSoPhieuYC($.mkv.queryString("idkhoachinh"));
                          });
                    }
                    else
                       CheckValidSaveYc(this,false);
                });
                 //───────────────────────────────────────────────────────────────────────────────────────
                $("#moi").click(function () {
                     var IdKhoYC=$("#IdKhoYc").val();
                     var IdKhoDuyet=$("#IdKhoDuyet").val();
                     $(this).Moi();  
                     setDefault();
                      $("#IdKhoYc").val( IdKhoYC);
                      $("#IdKhoDuyet").val(IdKhoDuyet);
                });
                
                $("#Thoat").click(function () {
                        window.close();                
                });
                //----------------------
                 $("#IdKhoYc").DropList({ ajax: "../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=IdKhoYcSearch&IdKhoa=" + $.mkv.queryString("IdKhoa")
                 ,defaultVal:"- Chọn kho -" ,async:false}
                 ,null
                 ,function(){
                         if($.mkv.queryString("idkhoachinh")==null || $.mkv.queryString("idkhoachinh") =="")
                         { $("#IdKhoYc")[0].selectedIndex=1;}
                
                  });
               
                //--------------------
                 //----------------------
                 $("#IdKhoDuyet").DropList({ ajax: "../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=IdKhoDuyetSearch"
                 ,defaultVal:"- Chọn kho -" ,async:false}
                 ,null
                 ,function(){
                           if($.mkv.queryString("idkhoachinh")==null || $.mkv.queryString("idkhoachinh") =="")
                             { $("#IdKhoDuyet")[0].selectedIndex=1;}
                
                 
            });
               
                //--------------------
                 $("#LoaiThuocID").DropList({ ajax: "../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=LoaiThuocIDSearch"
                 ,defaultVal:"- Chọn đối tượng -" ,async:false}
                 ,null
                 ,function(){
                  });
                 //───────────────────────────────────────────────────────────────────────────────────────
                $("#xoa").click(function () {
                    if($.isNullOrEmpty($.mkv.queryString("idkhoachinh")) || $.mkv.queryString("idkhoachinh")=="0")
                    {
                        $.mkv.myerror("Chưa lưu phiếu Yêu Cầu !");
                        return;
                    }
                    var IdKhoYC=$("#IdKhoYc").val();
                    var IdKhoDuyet=$("#IdKhoDuyet").val();
                          
                    if($("#isviewIn").val()!="1")
                       {
                          $(this).Xoa({
                          
                          ajax:"../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=xoa"
                            },null,function () {
                                 loadTableAjaxYc_PhieuYcXuatChiTiet('');
                                 setDefault();
                                 $("#IdKhoYc").val( IdKhoYC);
                                 $("#IdKhoDuyet").val(IdKhoDuyet);
                             });
                       }
                       else
                       {
                            $.mkv.myerror("Phiếu đã duyệt không được xóa !");    
                       }
                });
                 //───────────────────────────────────────────────────────────────────────────────────────
                $("#timKiem").click(function () {
                    Find($(this)); 
                 });
                  //───────────────────────────────────────────────────────────────────────────────────────
                $("#btnprint").click(function () {
               
                    if($.mkv.queryString("idkhoachinh")!= null && $.mkv.queryString("idkhoachinh")!="")
                    {
                      
                        InPhieuYeuCauLanh($.mkv.queryString("idkhoachinh"),"yc", "print");
                    }
                 });
                  //───────────────────────────────────────────────────────────────────────────────────────
                $("#btngetList").click(function () {
                    LoadDanhSachYCTuChiDinh();
                 });
                $("#bntduyetIn").click(function () {
                    //LuuDuyetIn();
                    CheckValidSaveYc(this,true);
                 });
                  //───────────────────────────────────────────────────────────────────────────────────────
                $("#btnDuyetPhat").click(function () {
                    LuuDuyetPhat();
                 });
                  //───────────────────────────────────────────────────────────────────────────────────────
                $("#btnHuyDuyetPhat").click(function () {
                    HuyDuyetPhat();
                     $("#maphieuxuat").val("");
                 });
                 setDefault();
         });
 //───────────────────────────────────────────────────────────────────────────────────────         
           function setControlFind(IdKhoatimkiem) {
              if(IdKhoatimkiem != "" && IdKhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=setTimKiem&idkhoachinh="+IdKhoatimkiem,dataType:"json"},null,function () {
                     loadTableAjaxYc_PhieuYcXuatChiTiet($.mkv.queryString("idkhoachinh"));
                     setViewGetList();
                     setViewIn();
                 });
              }else{loadTableAjaxYc_PhieuYcXuatChiTiet();}         
            }
 //───────────────────────────────────────────────────────────────────────────────────────            
          function Find(control,page) {
              if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=TimKiem&page="+page
               });
          }
 //───────────────────────────────────────────────────────────────────────────────────────          
         function xoaontable(control,bool){
           if($("#isviewIn").val()!="1")
           {
              if(bool || bool == null)
                  $(control).XoaRow({
                     ajax:"../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=xoaYc_PhieuYcXuatChiTiet"
                  });
           }
           else
           {
                $.mkv.myerror("Phiếu đã duyệt không được xóa !");    
           }
         }
 //───────────────────────────────────────────────────────────────────────────────────────         
         function loadTableAjaxYc_PhieuYcXuatChiTiet(IdKhoa,page)
         {
             if(IdKhoa == null) IdKhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_Yc_PhieuYcXuatChiTiet").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=loadTableYc_PhieuYcXuatChiTiet&IdPhieuYc="+IdKhoa+"&page="+page,
                  success: function (value){
                         $("#tableAjax_Yc_PhieuYcXuatChiTiet").html(value);
                    }
             });
         }
 //───────────────────────────────────────────────────────────────────────────────────────        
function IdThuocSearch(obj,type) {
    var idkho2 = $("#IdKhoYc").val();
    if($("#NgayYC").val()=="")
    {
        alert("Chưa chọn Ngày YC!");
        $("#NgayYC").focus();
        return false;
    }
    if($.isNullOrEmpty($("#IdKhoYc").val()))
    {
        alert("Chưa chọn kho YC!");
        $("#mkv_IdKhoYc").focus();
        return false;
    }
    if($.isNullOrEmpty($("#IdKhoDuyet").val()) )
    {
        alert("Chưa chọn kho Duyệt!");
        $("#mkv_IdKhoDuyet").focus();
        return;
    }
    if($.isNullOrEmpty($("#LoaiThuocID").val()) )
    {
        alert("Chưa chọn đối tượng!"); 
        $("#LoaiThuocID").focus();
        return;
    }
    var IdChiTietYc=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idkhoachinh").val();
    $(obj).unautocomplete().autocomplete("../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=IdThuocSearch&loaithuoc=" + $("#LoaiThuocID").val() + "&idkho=" + $("#IdKhoDuyet").val()
            + "&NgayCT=" + $("#NgayDuyet").val()  
            + "&Gio=" + $("#GioDuyet").val()
            + "&Phut=" + $("#PhutDuyet").val()
            + "&idkho2=" + idkho2
            + "&type=" + type
            + "&IsCoSoTuTruc=1"
            + "&IsYCXuat=1"
            + "&IdChiTietYc="+IdChiTietYc
            , {
         minChars: 0,
         width: 850,
         scroll: true,
         addRow: true,
         header: "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
                + "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
                 + "<div style=\"width:15%;height:30px;color:#000;font-weight:bold;float:left\" >TT HC</div>"
                + "<div style=\"width:25%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;padding-left:5px;\" >Biệt dược</div>"
                + "<div style=\"width:29%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;\" >Hoạt chất</div>"
                + "<div style=\"width:7%;height:30px;color:#000;font-weight:bold;float:left;\" >ĐVT</div>"
                + "<div style=\"width:8%;height:30px;color:#000;font-weight:bold;float:left\" >SLTon </div>"
                + "<div style=\"width:7%;height:30px;color:#000;font-weight:bold;float:left;\" >Dự trù</div>"
                + "</div>",
         formatItem: function (data) {
             $(".ac_results").css("padding-top", "30px");
             return data[0];
         }
     }).result(function (event, data) {
         var ton= eval(data[13])- eval(data[12]);
         if(ton <=0)
         {
            $(obj).val("");
            alert(data[4]+" đã hết tồn !");
            return false;
         }
         else
         {
             if ($(obj).parents("#gridTable").attr("id") != null) {
               if (type == "2") {
                 $(obj).val(data[11]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IdThuoc").val(data[1]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_IdThuoc").val(data[4]);
             } else if (type == "1") {
                 $(obj).val(data[4]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + $(obj).attr("id").replace("mkv_", "")).val(data[1]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#tthoatchat").val(data[11]);
             }
             
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#UnitID").val(data[3]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_UnitID").val(data[7]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SlTon").val(data[13]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SlTon").attr("disabled",true)
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SlDutru").val(data[12]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SlDutru").attr("disabled",true)
                 if($("#perDuyetIn").val()!="1")
                 {
                    $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IsDuyetIn").attr("disabled",true)
                    $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SoLuongDuyet").attr("disabled",true)
                 }
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#TonPhat").attr("disabled",true)
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#DutruPhat").attr("disabled",true)
//                 if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
//                     $.mkv.themDongTable("gridTable");
             }
             setTimeout(function () {
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SoLuongYc").focus();
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SoLuongYc").val("");
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()+1).find("#SlTon").attr("disabled",true)
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()+1).find("#SlDutru").attr("disabled",true)
                 if($("#perDuyetIn").val()!="1")
                 {
                    $("#gridTable").find("tr").eq($(obj).parent().parent().index()+1).find("#IsDuyetIn").attr("disabled",true)
                    $("#gridTable").find("tr").eq($(obj).parent().parent().index()+1).find("#SoLuongDuyet").attr("disabled",true)
                 }
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()+1).find("#TonPhat").attr("disabled",true)
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()+1).find("#DutruPhat").attr("disabled",true)
             }, 100);
         }
     });
}
 //───────────────────────────────────────────────────────────────────────────────────────
         function IdNguoiYcSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=IdNguoiYcSearch",{
             minChars:0,
             scroll:true,
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
 //───────────────────────────────────────────────────────────────────────────────────────         
         function IdNguoiDuyetSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=IdNguoiDuyetSearch",{
             minChars:0,
             scroll:true,
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
 //───────────────────────────────────────────────────────────────────────────────────────         
      
function setDefault()
{
  setViewGetList();
 $.BindFind({
        ajax: "../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=setDefault"
                + "&IdKhoa=" + $.mkv.queryString("IdKhoa")
                + "&idkhoachinh=" + $.mkv.queryString("idkhoachinh")
                , useEnabled: false
    }, null, function () {
        setViewIn();
        }
    ); 
}
 //───────────────────────────────────────────────────────────────────────────────────────
function setViewGetList()
{
    if($.mkv.queryString("idkhoachinh")!= null && $.mkv.queryString("idkhoachinh") !="")//khobenhnhan
	{
	    $("#btngetList").css("display","none");
	}
	else
	{
	    $("#btngetList").css("display","");
	}
}
 //───────────────────────────────────────────────────────────────────────────────────────
function setViewIn()
{
    if($("#isviewIn").val()=="1")
    {
       $("#btnprint").css("display","");
       if($("#perDuyetPhat").val()=="1" && $("#isDaPhat").val()=="0")
            $("#btnDuyetPhat").css("display","");
       else
            $("#btnDuyetPhat").css("display","none");
       if($("#perDuyetPhat").val()=="1" && $("#isDaPhat").val()=="1")
       {
            $("#btnHuyDuyetPhat").css("display","");
            $("#bntduyetIn").css("display","none");
       }
       else
            $("#btnHuyDuyetPhat").css("display","none");
       $("#luu").css("display","none");
       $("#_luu").css("display","none");
       $("#xoa").css("display","none");
    }
    else
    {
       $("#btnprint").css("display","none");
       $("#btnDuyetPhat").css("display","none");
       $("#btnHuyDuyetPhat").css("display","none");
       $("#_luu").css("display","");
       $("#luu").css("display","");
       $("#xoa").css("display","");
    }
    
    
    if($("#IsTheoCD").val()=="1")
    {
          $("#luu").css("display","none");
          $("#_luu").css("display","none");
          $("#xoa").css("display","none");
    }
}
 //───────────────────────────────────────────────────────────────────────────────────────
function KiemTraTonYC(obj) 
{
    var soluongke = eval($(obj).val());
    var soluogton = eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SlTon").val());
    var slDuTru = eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SlDutru").val());
    if (soluongke > (soluogton-slDuTru)) {
        alert("'" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_IdThuoc").val() + "' yêu cầu không được lớn hơn '" + (soluogton-slDuTru) + "'");
        //disabled_luu();
        $(obj).val("");
        $(obj).focus();
    }
    else {
        //enable_luu();
    }
}
function KiemTraTonDuyet(obj) 
{
    var soluongDuyet = eval($(obj).val());
    var soluogYC = eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SoLuongYc").val());
    if (soluongDuyet > soluogYC) {
        alert("'" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_IdThuoc").val() + "' duyệt không được lớn hơn '" + (soluogYC) + "'");
        $(obj).val($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SoLuongYc").val());
        $(obj).focus();
    }
    else {
    }
}
 //───────────────────────────────────────────────────────────────────────────────────────
function CheckValidSaveYeuCau()
{
	var valid= true;
	var countValid=0;
	var rowCount = $('#gridTable tr').length;
	for(var i=1;i<rowCount-1;i++)
	{
		if( eval($("#gridTable").find("tr").eq(i).find("#IdThuoc").val()))
		{
			var soluongYC= $("#gridTable").find("tr").eq(i).find("#SoLuongYc").val();
			if( soluongYC=="" || soluongYC=="0")
			{
				alert($("#gridTable").find("tr").eq(i).find("#mkv_IdThuoc").val() +" chưa có số lượng !");
			}
			else
			{
				countValid ++;
			}
		}
	}
	if(valid)
		if(countValid ==0)
		{
			alert("Chưa nhập nội dung Yêu Cầu hợp lệ !");
			return false;
		}
	return valid;
}
 //───────────────────────────────────────────────────────────────────────────────────────
function LoadDanhSachYCTuChiDinh()
{
    if($.isNullOrEmpty($("#IdKhoYc").val()))
    {
        alert("Chưa chọn kho Yêu cầu!");
        $("#mkv_IdKhoYc").focus();
        return false;
    }
    if($.isNullOrEmpty($("#IdKhoDuyet").val()) )
    {
        alert("Chưa chọn kho Duyệt!");
        $("#mkv_IdKhoDuyet").focus();
        return;
    }
    if($.isNullOrEmpty($("#LoaiThuocID").val()) )
    {
        alert("Chưa chọn đối tượng!"); 
        $("#mkv_LoaiThuocID").focus();
        return;
    }
    if($.isNullOrEmpty($("#TuNgay").val()) || $.isNullOrEmpty($("#DenNgay").val()) )
    {
        alert("Chưa chọn thời gian chỉ đinh!"); 
        $("#TuNgay").focus();
        return;
    }
    var listQr="&IdKhoYc="+$("#IdKhoYc").val()+"&IdKhoDuyet="+$("#IdKhoDuyet").val()+"&LoaiThuocID="+$("#LoaiThuocID").val()
                +"&TuNgay="+$("#TuNgay").val()+"&TuGio="+$("#TuGio").val()+"&TuPhut="+$("#TuPhut").val()
                +"&DenNgay="+$("#DenNgay").val()+"&DenGio="+$("#DenGio").val()+"&DenPhut="+$("#DenPhut").val()
                +"&NgayYC="+$("#NgayYc").val()+"&GioYC="+$("#GioYc").val()+"&PhutYC="+$("#PhutYC").val()
                +"&IsDuTru="+$("#IsDuTru").is(":checked")
                ;
    $.ajax({
        url: "../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=LoadDanhSachYCTuChiDinh"+listQr,
        cache: false,
        async: false,
        type: "GET",
        success: function (data) {
            if (data != "") 
            {
                $("#tableAjax_Yc_PhieuYcXuatChiTiet").html(data);
            } else
            {
                $.mkv.myerror("Lỗi load danh sách Yêu cầu !");
            }
        }
    });
}
 //───────────────────────────────────────────────────────────────────────────────────────
function LuuDuyetIn()
{
    if($.isNullOrEmpty($.mkv.queryString("idkhoachinh"))|| $.mkv.queryString("idkhoachinh")=="0")
    {
        $.mkv.myerror("Chưa lưu phiếu Yêu Cầu !");
        return;
    }
    var isDuyet ="0";
    if($("#IsDuyetIn").is(":checked"))
        isDuyet ="1";
    $.ajax({
        url: "../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=LuuDuyetIn&idPhieuYc="+$.mkv.queryString("idkhoachinh")+"&isDuyet="+isDuyet

        ,
        cache: false,
        async: false,
        type: "GET",
        success: function (data) {
            if (data != "") 
            {
                $.LuuTable({
                                 ajax:"../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=luuDuyetInTableYc_PhieuYcXuatChiTiet&IdPhieuYc=" + $.mkv.queryString("idkhoachinh"),
                                 tablename:"#gridTable"
                           });
               if($("#IsDuyetIn").is(":checked"))
                    $("#isviewIn").val("1");
               else
                    $("#isviewIn").val("0");
               setViewIn();
            } else
            {
                $.mkv.myerror("Lỗi Duyệt In !");
            }
        }
    });
}
 //───────────────────────────────────────────────────────────────────────────────────────
function LuuDuyetPhat()
{
    if($.isNullOrEmpty($.mkv.queryString("idkhoachinh"))|| $.mkv.queryString("idkhoachinh")=="0")
    {
        $.mkv.myerror("Chưa lưu phiếu Yêu Cầu !");
        return;
    }
    $.ajax(
        {
            url:"../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=LuuDuyetPhat&idPhieuYc="+$.mkv.queryString("idkhoachinh"),
            cache: false,
            async: false,
            type:"GET",
            success: function(data){
                if(data !="")
                {
                    $.mkv.myalert("Duyệt phát thành công.", 2000, "success");
                    $("#btnDuyetPhat").css("display","none");
                    $("#btnHuyDuyetPhat").css("display","");
                    $("#bntduyetIn").css("display","none");
                    $("#isDaPhat").val("1");
                    setViewIn();
                    $("#maphieuxuat").val(data);
                }
                else
                {
                    $.mkv.myerror("Duyệt phát thất bại!");                    
                }
            }
        }
    );
}
 //───────────────────────────────────────────────────────────────────────────────────────
function HuyDuyetPhat()
{
    $.ajax(
        {
            url:"../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=HuyDuyetPhat&idPhieuYc="+$.mkv.queryString("idkhoachinh"),
            cache: false,
            async: false,
            type:"GET",
            success: function(data){
                if(data !="")
                {
                    $.mkv.myalert("Hủy phát thành công.", 2000, "success");
                    $("#btnDuyetPhat").css("display","");
                    $("#bntduyetIn").css("display","");
                    $("#btnHuyDuyetPhat").css("display","none");
                    $("#isDaPhat").val("0");
                    setViewIn();
                }
                else
                {
                    $.mkv.myerror("Hủy phát thất bại!");                    
                }
            }
        }
    );
}
 //───────────────────────────────────────────────────────────────────────────────────────
function refreshPage() {
  window.location.href = window.location.href;
  if (window.progressWindow)
  {
    window.progressWindow.close()
  }
}
 //───────────────────────────────────────────────────────────────────────────────────────
function refreshParent() {
  window.opener.location.href = window.opener.location.href;
//  if (window.opener.progressWindow)
//  {
//    window.opener.progressWindow.close()
//  }
//  window.close();
}
 //───────────────────────────────────────────────────────────────────────────────────────
  function InPhieuYeuCauLanh(idphieuYC, loaiPhieu, isPrint) {
            if(idphieuYC == null || idphieuYC=="" || idphieuYC=="0")
                return;
            if (isPrint == "print") {
                nvk_InPhieuLinh_Confirm('Chọn bản muốn in?', 'Chọn bản in', function (r) {
                    if (r == "2") {
                        window.open('../../QLDUOC/WEB/rptPhieuYCXuat_new.aspx?IdPhieuYC=' + idphieuYC + "&IsBanSao=0#isPrint=1", '_blank');
                        setTimeout(function () {
                            window.open('../../QLDUOC/WEB/rptPhieuYCXuat_new.aspx?IdPhieuYC=' + idphieuYC + "&IsBanSao=1#isPrint=1", '_blank');
                        }, 15000);
                    }
                    else if (r) {
                        window.open('../../QLDUOC/WEB/rptPhieuYCXuat_new.aspx?IdPhieuYC=' + idphieuYC + "&IsBanSao=1#isPrint=1", '_blank');
                    }
                    else {
                        window.open('../../QLDUOC/WEB/rptPhieuYCXuat_new.aspx?IdPhieuYC=' + idphieuYC + "&IsBanSao=0#isPrint=1", '_blank');
                    }
                });
            }
            else {
                window.open('../../QLDUOC/WEB/rptPhieuYCXuat_new.aspx?IdPhieuYC=' + idphieuYC + "", '_blank');
            }

        }
  //───────────────────────────────────────────────────────────────────────────────────────
    function GetSoPhieuYC(IdPhieuYC)
         {
            if($.isNullOrEmpty(IdPhieuYC) || IdPhieuYC=="0")
            {
                return false
            }
            $.ajax({
                url: "../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=GetSoPhieuYC&IdPhieuYC="+IdPhieuYC,
                cache: false,
                async: false,
                type: "GET",
                success: function (data) {
                    if (data != "") 
                    {
                        $("#SoPhieuYc").val(data.split('|')[0]);
					     
                    } else
                    {
                    }
                }
            });
         }
//───────────────────────────────────────────────────────────────────────────────────────
function CheckValidSaveYc(obj,isDuyetIn)
{
    if($.isNullOrEmpty(isDuyetIn))
        isDuyetIn= false;
    if ($("#gridTable").attr("id") == null)
    {
        $.mkv.myerror("Chưa có nội dung yêu cầu !");
        return;
    }
    if(!CheckValidSaveYeuCau())
        return;    
    var rowNumber= $("#gridTable").find("tr").length;
    var isbreak= false;
    
    var arr_Chenhlech="";
    
    for(var i=2;i< rowNumber-1;i++)
    {
        var IDTHUOC=$("#gridTable").find("tr").eq(i).find("#IdThuoc").val();
        var TONGSLKE=eval( $("#gridTable").find("tr").eq(i).find("#SoLuongYc").val());
        var list="&IDTHUOC="+IDTHUOC+"&TONGSLKE="+TONGSLKE;
        isbreak= false;
        
        if(  $("#gridTable").find("tr").eq(i).find("#IsDuyetIn").is(":checked")==true  && isDuyetIn)
        { 
                var SoLuongDuyet=eval( $("#gridTable").find("tr").eq(i).find("#SoLuongDuyet").val());
                var SlTon=eval( $("#gridTable").find("tr").eq(i).find("#SlTon").val());
                var SlDutru=eval( $("#gridTable").find("tr").eq(i).find("#SlDutru").val());
                 if(SoLuongDuyet>TONGSLKE)
                 {
                    $.mkv.myerror("Số lượng duyệt không vượt quá số lượng yêu cầu");
                    isbreak=true;
                 }
                 else
                 if(SoLuongDuyet<0)
                 {
                    $.mkv.myerror("Số lượng duyệt không âm");
                    isbreak=true;
                 }
                 else
                 if(SoLuongDuyet>(SlTon-SlDutru))
                 {
                    $.mkv.myerror("Số lượng duyệt không vượt quá "+ (SlTon-SlDutru)  );
                    isbreak=true;
                 }
                 else if(SoLuongDuyet<TONGSLKE) 
                        arr_Chenhlech=arr_Chenhlech+$("#gridTable").find("tr").eq(i).find("#mkv_IdThuoc").val() +" yêu cầu : "+ TONGSLKE+" , duyệt: "+SoLuongDuyet +"\r\n";
        }
        if(isbreak)
            break;
    }
    
    if(arr_Chenhlech!="")
    {
        if($("#IsKhoBN").val()!="1")
            {
                   arr_Chenhlech="Có sự chênh lệch giữa số lượng yêu cầu và duyệt như sau:\r\n"+ arr_Chenhlech +"(Nhấn OK để tiếp tục)";
                    if(!confirm(arr_Chenhlech))
                        return false;
            }
        else
            {
                        arr_Chenhlech="Có sự chênh lệch giữa số lượng yêu cầu và duyệt như sau:\r\n"+ arr_Chenhlech +"(Bạn không thể duyệt cho kho bệnh nhân)";
                         alert(arr_Chenhlech);
                        return false;
            }
    }
    
    if(!isbreak)
    {
        if(isDuyetIn)
            LuuDuyetIn();
        else
            SavePhieuYCXuat();
    }
}
//───────────────────────────────────────────────────────────────────────────────────────
function SavePhieuYCXuat()
{
  $("#luu").Luu({
                         ajax:"../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=Luu"
                      },function(){
						return true;
					  },function () {
                           $.LuuTable({
                                 ajax:"../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=luuTableYc_PhieuYcXuatChiTiet&IdPhieuYc=" + $.mkv.queryString("idkhoachinh"),
                                 tablename:"#gridTable"
                           });
					       if($("#IsDuyetIn").is(":checked"))
					            $("#isviewIn").val("1");
					       else
					            $("#isviewIn").val("0");
					       setViewIn();
					       GetSoPhieuYC($.mkv.queryString("idkhoachinh"));
                      });  
}
