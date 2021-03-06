
         $(document).ready(function() {
                 $.mkv.moveUpandDown("#tablefind");
               setControlFind($.mkv.queryString("idkhoachinh"));
                 $("#luu").click(function () {
                   $(this).Luu({
                         ajax:"../ajax/Yc_PhieuYCTra_ajax3.aspx?do=Luu"
                      },function(){
						return CheckValidSaveYeuCau();
					  },function () {
                           $.LuuTable({
                                 ajax:"../ajax/Yc_PhieuYCTra_ajax3.aspx?do=luuTableYc_PhieuYCTraChiTiet&IdPhieuYc=" + $.mkv.queryString("idkhoachinh"),
                                 tablename:"#gridTable"
                           },null,function(){
                                XuatThuoc_Treo_TheoPhieuTra($.mkv.queryString("idkhoachinh"));
                                SetStateControl();
                           });
                      });
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
                 $("#IdKhoYc").DropList({ ajax: "../ajax/Yc_PhieuYCTra_ajax3.aspx?do=IdKhoYcSearch&IdKhoa=" + $.mkv.queryString("IdKhoa")
                 ,defaultVal:"- Chọn kho -" ,async:false}
                 ,null
                 ,function(){
                              if($.mkv.queryString("idkhoachinh")==null || $.mkv.queryString("idkhoachinh") =="")
                                     { $("#IdKhoYc")[0].selectedIndex=1;}
                
            });
               
                //--------------------
                 //----------------------
                 $("#IdKhoDuyet").DropList({ ajax: "../ajax/Yc_PhieuYCTra_ajax3.aspx?do=IdKhoDuyetSearch&IsHongVo="+$.mkv.queryString("IsHongVo")
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
                     //--------------------
                //--------------------
                 //───────────────────────────────────────────────────────────────────────────────────────
                $("#xoa").click(function () {
                    if($.isNullOrEmpty($.mkv.queryString("idkhoachinh")) || $.mkv.queryString("idkhoachinh")=="0")
                    {
                        $.mkv.myerror("Chưa lưu phiếu Yêu Cầu !");
                        return;
                    }
                    var IdKhoYC=$("#IdKhoYc").val();
                     var IdKhoDuyet=$("#IdKhoDuyet").val();
                          
                    if($("#IsDuyetTra").is(':checked')!=true)
                       {
                          $(this).Xoa({
                          
                          ajax:"../ajax/Yc_PhieuYCTra_ajax3.aspx?do=xoa"
                            },null,function () {
                                 loadTableAjaxYc_PhieuYcTraChiTiet('');
                                 setDefault();
                                 SetStateControl();
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
                        InPhieuYeuCauTra($.mkv.queryString("idkhoachinh"),"yc", "print");
                    }
                 });
                  //───────────────────────────────────────────────────────────────────────────────────────
                $("#btngetList").click(function () {
                    LoadDanhSachYCTuChiDinh();
                 });
                  //───────────────────────────────────────────────────────────────────────────────────────
                $("#btnDuyetTra").click(function () {
                    LuuDuyetTra();
                 });
                  //───────────────────────────────────────────────────────────────────────────────────────
                $("#btnHuyDuyetTra").click(function () {
                    HuyDuyetTra();
                 });
                 
         });
 //───────────────────────────────────────────────────────────────────────────────────────         
         function XuatThuoc_Treo_TheoPhieuTra(idPhieuYcTra)
         {
            if($.isNullOrEmpty(idPhieuYcTra) || idPhieuYcTra=="0")
            {
                return false
            }
            $.mkv.loading();
            $.ajax({
                url: "../ajax/Yc_PhieuYCTra_ajax3.aspx?do=XuatThuoc_Treo_TheoPhieuTra&idPhieuYcTra="+idPhieuYcTra,
                cache: false,
                async: false,
                type: "GET",
                success: function (data) {
                    $(".loadingAjax").remove();
                    if (data != "") 
                    {
                        var arr = data.split('@@');
                        $("#SoPhieuYc").val(arr[0]);
                        $("#maphieuxuat").val(arr[1]);
                        $.mkv.myalert("Hoàn thành.", 2000, "success");
					     
                    } else
                    {
                        $.mkv.myerror("Lỗi xuất treo !");
                    }
                }
            });
         }
 //───────────────────────────────────────────────────────────────────────────────────────         
           function setControlFind(IdKhoatimkiem) {
              if(IdKhoatimkiem != "" && IdKhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/Yc_PhieuYCTra_ajax3.aspx?do=setTimKiem&idkhoachinh="+IdKhoatimkiem,dataType:"json"},null,function () {
                     loadTableAjaxYc_PhieuYcTraChiTiet($.mkv.queryString("idkhoachinh"));
                     setViewGetList();                    
                     setDefault();
                 });
              }else
              {
                loadTableAjaxYc_PhieuYcTraChiTiet();
                setDefault();
              }
            }
 //───────────────────────────────────────────────────────────────────────────────────────            
          function Find(control,page) {
              if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/Yc_PhieuYCTra_ajax3.aspx?do=TimKiem&page="+page
               });
          }
 //───────────────────────────────────────────────────────────────────────────────────────          
         function xoaontable(control,bool){
           if($("#IsDuyetTra").is(':checked')!=true)
           {
              if(bool || bool == null)
                  $(control).XoaRow({
                     ajax:"../ajax/Yc_PhieuYCTra_ajax3.aspx?do=xoaYc_PhieuYcTraChiTiet"
                  });
           }
           else
           {
                $.mkv.myerror("Phiếu đã duyệt không được xóa !");    
           }
         }
 //───────────────────────────────────────────────────────────────────────────────────────         
         function loadTableAjaxYc_PhieuYcTraChiTiet(IdKhoa,page)
         {
             if(IdKhoa == null) IdKhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_Yc_PhieuYCTraChiTiet").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/Yc_PhieuYCTra_ajax3.aspx?do=loadTableYc_PhieuYcTraChiTiet&IdPhieuYc="+IdKhoa+"&page="+page,
                  success: function (value){
                         $("#tableAjax_Yc_PhieuYCTraChiTiet").html(value);
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
     var IsCheckSLTon= IsCheckSLChiDinh();
    $(obj).unautocomplete().autocomplete("../ajax/Yc_PhieuYCTra_ajax3.aspx?do=IdThuocSearch&loaithuoc=" + $("#LoaiThuocID").val() + "&idkho=" + $("#IdKhoYc").val()
            + "&NgayCT=" + $("#NgayDuyet").val()  
            + "&Gio=" + $("#GioDuyet").val()
            + "&Phut=" + $("#PhutDuyet").val()
            + "&type=" + type
            + "&idkho2=" + $("#IdKhoDuyet").val()
            + "&IsCoSoTuTruc=1"
            + "&IsYCTRA=1"
            + "&IsCheckSLTon="+IsCheckSLTon
            
            
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
            var IsCheckSLTon1= IsCheckSLChiDinh();
         if(ton <=0 && IsCheckSLTon1=="1")
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
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#TonPhat").attr("disabled",true)
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#DutruPhat").attr("disabled",true)
             }
             setTimeout(function () {
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SoLuongYc").focus();
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SoLuongYc").val("");
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()+1).find("#SlTon").attr("disabled",true)
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()+1).find("#SlDutru").attr("disabled",true)
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()+1).find("#TonPhat").attr("disabled",true)
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()+1).find("#DutruPhat").attr("disabled",true)
             }, 100);
         }
     });
}
 //───────────────────────────────────────────────────────────────────────────────────────
       
         function IdNguoiYcSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/Yc_PhieuYCTra_ajax3.aspx?do=IdNguoiYcSearch",{
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
             $(obj).unautocomplete().autocomplete("../ajax/Yc_PhieuYCTra_ajax3.aspx?do=IdNguoiDuyetSearch",{
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
        ajax: "../ajax/Yc_PhieuYCTra_ajax3.aspx?do=setDefault"
                + "&IdKhoa=" + $.mkv.queryString("IdKhoa")
                 + "&idkhoachinh=" + $.mkv.queryString("idkhoachinh")
                , useEnabled: false
    }, null, function () {
        SetStateControl();
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
function SetStateControl()
{
   
	
     
    if($("#IsDuyetTra").is(':checked')== true)
    {
       $("#btnDuyetTra").css("display","none");
       $("#luu").css("display","none");
       $("#_luu").css("display","none");
       $("#xoa").css("display","none");     
       if($("#perDuyetTra").val()=="1" )
       {
            $("#btnHuyDuyetTra").css("display","");
       }
       else
            $("#btnHuyDuyetTra").css("display","none");
       
    }
    else
    {
      if($("#perDuyetTra").val()=="1" )
         $("#btnDuyetTra").css("display","");
       
       $("#btnHuyDuyetTra").css("display","none");
       $("#_luu").css("display","");
       $("#luu").css("display","");
       $("#xoa").css("display","");
           if($.mkv.queryString("idkhoachinh")!= null && $.mkv.queryString("idkhoachinh") !="") 
	        {
	            $("#btnDuyetTra").css("display","");
	             
	        }
	        else
	        {
	            $("#btnDuyetTra").css("display","none");
	              
	        }
	
	
    }
}
 //───────────────────────────────────────────────────────────────────────────────────────
 function IsCheckSLChiDinh()
 {
    var IsCheckSLTon="1";
     if( (        $("#IdKhoYc").val()=="14" 
               || $("#IdKhoYc").val()=="22"  
               || $("#IdKhoYc").val()=="23" 
               || $("#IdKhoYc").val()=="24" 
               || $("#IdKhoYc").val()=="30"  
               || $("#IdKhoYc").val()=="57"  
               || $("#IdKhoYc").val()=="58"  
               || $("#IdKhoYc").val()=="59"  
               || $("#IdKhoYc").val()=="60"  
               || $("#IdKhoYc").val()=="61"  
               || $("#IdKhoYC").val()=="62"
          )
          &&  $("#TuNgay").val()!=""
          &&  $("#DenNgay").val()!=""
      )   IsCheckSLTon="0";
      
      return IsCheckSLTon;
 }
function KiemTraTonYC(obj) 
{
   var IsCheckSLTon= IsCheckSLChiDinh();
 
    
    var soluongke = eval($(obj).val());
    var soluogton = eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SlTon").val());
    if (soluongke >soluogton) {
        if(IsCheckSLTon=="1")
        {
        alert("'" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_IdThuoc").val() + "' yêu cầu không được lớn hơn '" + (soluogton) + "'");
        $(obj).val("");
        $(obj).focus();
        }
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
                 ;
    $.ajax({
        url: "../ajax/Yc_PhieuYCTra_ajax3.aspx?do=LoadDanhSachYCTuChiDinh"+listQr,
        cache: false,
        async: false,
        type: "GET",
        success: function (data) {
            if (data != "") 
            {
                $("#tableAjax_Yc_PhieuYCTraChiTiet").html(data);
            } else
            {
                $.mkv.myerror("Lỗi load danh sách Yêu cầu !");
            }
        }
    });
}
  
 //───────────────────────────────────────────────────────────────────────────────────────
function LuuDuyetTra()
{
    if($.isNullOrEmpty($.mkv.queryString("idkhoachinh"))|| $.mkv.queryString("idkhoachinh")=="0")
    {
        $.mkv.myerror("Chưa lưu phiếu Yêu Cầu !");
        return;
    }
    $.ajax(
        {
            url:"../ajax/Yc_PhieuYCTra_ajax3.aspx?do=LuuDuyetTra&IdPhieuYc="+$.mkv.queryString("idkhoachinh")
            +"&NgayDuyet="+$("#NgayDuyet").val()
            +"&PhutDuyet="+$("#PhutDuyet").val()
            +"&GioDuyet="+$("#GioDuyet").val()
            ,
            cache: false,
            async: false,
            type:"GET",
            success: function(data){
                if(data !="")
                {
                    $.mkv.myalert("Duyệt trả thành công.", 2000, "success");
                    $("#IsDuyetTra").attr("checked",true);
                    SetStateControl();
                    $("#maphieuxuat").val(data);
                }
                else
                {
                    $.mkv.myerror("Duyệt trả thất bại!");                    
                }
            }
        }
    );
}
 //───────────────────────────────────────────────────────────────────────────────────────
function HuyDuyetTra()
{
    $.ajax(
        {
            url:"../ajax/Yc_PhieuYCTra_ajax3.aspx?do=HuyDuyetTra&IdPhieuYc="+$.mkv.queryString("idkhoachinh"),
            cache: false,
            async: false,
            type:"GET",
            success: function(data){
                if(data !="")
                {
                    $.mkv.myalert("Hủy trả thành công.", 2000, "success");
                    $("#IsDuyetTra").attr("checked",false);;
                    SetStateControl();
                }
                else
                {
                    $.mkv.myerror("Hủy trả thất bại!");                    
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
}
 //───────────────────────────────────────────────────────────────────────────────────────
       function InPhieuYeuCauTra(idphieuYC) {
        if(idphieuYC == null || idphieuYC=="" || idphieuYC=="0")           return;
                    nvk_InPhieuLinh_Confirm('Chọn bản muốn in?', 'Chọn bản in', function (r) {
                                    var IsBanSao="0";
                                    if (r == "1")  IsBanSao="1";
                                    if(r!="2")
                                        window.open('../../QLDUOC/WEB/rptPhieuYCTra_new.aspx?IdPhieuYC=' + idphieuYC + "&IsBanSao="+IsBanSao, '_blank');
                                    else if (r == "2") 
                                          {
                                          window.open('../../QLDUOC/WEB/rptPhieuYCTra_new.aspx?IdPhieuYC=' + idphieuYC + "&IsBanSao="+"1", '_blank');
                                          window.open('../../QLDUOC/WEB/rptPhieuYCTra_new.aspx?IdPhieuYC=' + idphieuYC + "&IsBanSao="+"0", '_blank');
                                          }
                                });
        }