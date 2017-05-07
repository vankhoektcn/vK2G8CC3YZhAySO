// JScript File

function loadTableAjaxchitietbenhnhantoathuoc(idkhoa,page)
         {
             //document.getElementById('cbDuTruThuoc').checked=true;
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_chitietbenhnhantoathuoc").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load thuốc, VTYT.....<img id='imgLoading' src='../images/processing.gif' /></span>");
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/khambenh_ajax3.aspx?do=loadTablechitietbenhnhantoathuoc&idkhambenh="+idkhoa+"&page="+page,
                  success: function (value){
                        var arr= value.split("@@");
                        $("#tableAjax_chitietbenhnhantoathuoc").html(arr[0]);
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                         if(arr[1]=="0")
                         {
                            $("#cbDuTruThuoc").attr("checked",false);
                         }
                         else
                         {
                            $("#cbDuTruThuoc").attr("checked",true);
                            $("#ngayDuTruThuoc").val(arr[2]);
                         }
                         $("#txtNgayKham").val(arr[3]);
                         //alert($("#txtNgayKham").val());
                         CheckDuTruThuoc($("#cbDuTruThuoc"));
                    }
             });
         }
function DongTraThuoc_Click(idbenhnhan,idkhambenhTra,loaitra,obj)
{
    loadTableAjaxchitietbenhnhanTraThuoc(idkhambenhTra,loaitra)
}
function loadTableAjaxchitietbenhnhanTraThuoc(idKBTraThuoc,loaitra)
         {
             if(idKBTraThuoc == null) idKBTraThuoc = "";
                 $("#tableAjax_chitietbenhnhanTraThuoc").html("<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang load thuốc, VTYT.....<img id='imgLoading' src='../images/processing.gif' /></span>");
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/nvk_khamTongHop_ajax.aspx?do=loadTablechitietbenhnhanTraThuoc&idkhambenh="+idKBTraThuoc+"&loaitra="+loaitra+"",
                  success: function (value){
                        $("#tableAjax_chitietbenhnhanTraThuoc").html(value);
                    }
             });
         }
 function CheckDuTruThuoc(obj,isKiemTra)
 {
    if($("#cbDuTruThuoc").is(":checked")==true)
    {
    var action= true;
        if(isKiemTra != null && isKiemTra== true)
        {
            var soDong= $("#gridTable").find("tr").length;
            //alert(soDong);
            for(var i=1;i<soDong-1;i++)
            {
                var nvk_loaikho_i= $("#gridTable").find("tr").eq(i).find("#nvk_loaikho").val();
                if(nvk_loaikho_i =="2")
                    {
                        action= false; continue;
                    }
            }
        }
        if(action)
        {
            $("#spDuTruThuoc").css("display","");
            $("#ngayDuTruThuoc").focus();
        }
        else
        {
            alert("Không dự trù được từ tủ trực !");
            $("#cbDuTruThuoc").attr("checked",false);
        }
    }
    else
    {
        $("#ngayDuTruThuoc").val("");
        $("#spDuTruThuoc").css("display","none");
    }
 }
 function SetChonToaThuoc(idkhambenh,obj)
 {
    $.mkv.dongtimkiem('default');
    $.mkv.queryString("idkhambenh",idkhambenh);
                 $("#tableAjax_chitietbenhnhantoathuoc").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/khambenh_ajax3.aspx?do=loadTableToaThuocCu&idkhambenh="+idkhambenh,
                  success: function (value){
                        //$.mkv.dongtimkiem('default');
                       $.mkv.queryString("LuuMoiKhamBenh","1");
                        $("#tableAjax_chitietbenhnhantoathuoc").html(value);
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                    }
             });
 }
         function loaithuocidsearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=loaithuocidsearch",{
             minChars:0,
             width:350,
             scroll:true,
             catche:false,
             addRow:false,
             header:"Loại thuốc",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     //obj.focus();
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#doituongthuocid").focus();                     
                 },100);
             });
         }
         function idkhosearch(obj)
         {
            var isDuTruThuoc=0;
            if($("#cbDuTruThuoc").is(":checked")==true)
            {
                isDuTruThuoc=1;
            }
                $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=idkhosearch_ChiDinh&isDuTruThuoc="+isDuTruThuoc+"&IdKhoa="+$.mkv.queryString("IdKhoa")+"&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc"),{
                 minChars:0,
                 width:350,
                 addRow:false,
                 scroll:true,
                 header:"Kho Thuốc",
                 formatItem:function (data) {
                      return data[0];
                 }}).result(function(event,data){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#nvk_loaikho").val(data[2]);
                     setTimeout(function () {
                         //obj.focus();
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idthuoc").focus();
                     },100);
                 });
         }
         function khotoaxuatviensearch(obj,idkhoa)
         {
                $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=khotoaxuatviensearch&IdKhoa="+$.mkv.queryString("IdKhoa")+"",{
                 minChars:0,
                 width:350,
                 addRow:false,
                 scroll:true,
                 header:"Kho Phát Thuốc",
                 formatItem:function (data) {
                      return data[0];
                 }}).result(function(event,data){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                     setTimeout(function () {
                         //obj.focus();
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idthuoc").focus();
                     },100);
                 });
         }
         function doituongthuocidsearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=doituongthuocidsearch",{
             minChars:0,
             width:350,
             scroll:true,
             addRow:false,
             header:"Đối tượng",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     //obj.focus();
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idkho").focus();
                 },100);
             });
         }
         // nvk neww
         function idthuocsearch(obj)
         {
            var idkhoa=$.mkv.queryString("IdKhoa");
            var objkho_Chon= $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idkho");
            if(objkho_Chon.val() == null || objkho_Chon.val()=="" || objkho_Chon.val()=="0")
            {
                objkho_Chon.focus();
                alert("Chưa chọn kho !");
                return;
            }
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=idthuocsearch&idctdkk="+$.mkv.queryString('idctdkk')+"&loaithuocid="+$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#loaithuocid").val()+"&idkho="+$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idkho").val(),{
             minChars:0,
             width:800,
             scroll:true,
             addRow:true,
             header:"<div style =\"color:Blue;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#CAE3FF;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
        //header: "<div style =\"width:100%;height:30px;background-color:#CAE3FF ;color:white\">"
       + "<div style=\"width:5%;height:30px;color:Blue;font-weight:bold;float:left\" >STT</div>"
       + "<div style=\"width:25%;height:30px;color:Blue;font-weight:bold;float:left\" >Biệt dược</div>"
       + "<div style=\"width:25%;height:30px;color:Blue;font-weight:bold;float:left\" >Hoạt chất</div>"
       + "<div style=\"width:10%;height:30px;color:Blue;font-weight:bold;float:left;\" >ĐVT</div>"
       + "<div style=\"width:10%;height:30px;color:Blue;font-weight:bold;float:left\" >C dùng</div>"
       + "<div style=\"width:10%;height:30px;color:Blue;font-weight:bold;float:left\" >SLTon </div>"
       + "<div style=\"width:10%;color:Blue;font-weight:bold;float:left\" >?BH</div>"
       //+( idkhoa == "100" ?  "<div style=\"width:10%;height:30px;color:Blue;font-weight:bold;float:left\" >?Ngoại trú</div>" : "" ) 
       + "</div>",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                if(data[7] <=0)
                    {
                        alert("'"+data[4]+"' Đã hết tồn !");    
                        $(obj).val("");
                        return;
                    }
                $(obj).val(data[4]);
                //$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluongke").val("1");
                $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#DonViCoBan").val(data[3]);
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                     //$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluongke").focus();
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#nvk_soluongton").val(data[7]);
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#slton").val(data[7]);
                 }
                 
                 setTimeout(function () {
                     var objSoLuongKe=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluongke");
                     objSoLuongKe.val("");
                     objSoLuongKe.focus();
                     // nvk set isBHYT
                        if(data[11]=="1")
                        {
                            $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_Save").attr("checked", true);
                            $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_Save").attr("disabled",false);
                        }
                        else
                        {
                            $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_Save").attr("checked", false);
                            $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_Save").attr("disabled",true);
                            $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index() + 1).find("#IsBHYT_Save").attr("disabled",true);
                        }
                     // end nvk set isBHYT
                     // set isTrongDanhMuc
                        if(data[12]=="1")
                        {
                            $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_DM").attr("checked", true);
                        }
                        else
                        {
                            $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_DM").attr("checked", false);
                        }
                        $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index() + 1).find("#IsBHYT_DM").attr("disabled","true");
                     // endset isTrongDanhMuc
                 },100);
                 
             });
             
         }
         
         function idthuocRaViensearch_bk(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=idthuocsearch&loaithuocid="+$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#loaithuocid").val()+"&idkho="+$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idkho").val(),{
             minChars:0,
             width:550,
             scroll:true,
             addRow:true,
             header:"<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
       + "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
       + "<div style=\"width:30%;height:30px;color:#000;font-weight:bold;float:left\" >Biệt dược</div>"
       + "<div style=\"width:30%;height:30px;color:#000;font-weight:bold;float:left\" >Hoạt chất</div>"
       + "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left;\" >ĐVT</div>"
       + "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left\" >Cách dùng</div>"
       + "<div style=\"width:15%;height:30px;color:#000;font-weight:bold;float:left\" >SLTon </div>"
       + "</div>",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                $(obj).val(data[4]);
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                    $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_iddvt").val(data[6]);
                    $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_iddvdung").val(data[6]);
                    $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idcachdung").val(data[8]);
                    $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#iddvt").val(data[9]);
                    $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#iddvdung").val(data[9]);
                    $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idcachdung").val(data[10]);
                 }
                 
                 setTimeout(function () {
                     var objSoLuongKe=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluongke");
                     objSoLuongKe.val("");
                     objSoLuongKe.focus();
                     //obj.focus();
                 },100);
                 
             });
             
         }
         //nvk neww end

function idthuocRaViensearch(obj) {
    var TypeSearch="1";
    var LoaiThuocID=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#loaithuocid").val();
    if(LoaiThuocID==null || LoaiThuocID=="") LoaiThuocID="1";
    var TenLoaiThuoc="thuốc";
    if(LoaiThuocID=="2")  TenLoaiThuoc="hoá chất";
    if(LoaiThuocID=="3")  TenLoaiThuoc="dụng cụ";
    if(LoaiThuocID=="4")  TenLoaiThuoc="VTYT";
    
    
    $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=idthuocXUATVIENsearch&TypeSearch=1&idbenhnhan=" + $.mkv.queryString("idbenhnhan")
     + "&loaithuocid=" + LoaiThuocID
     + "&idkho=" + $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idkhoxuat").val()
     + "&loaidk=" + $.mkv.queryString("LoaiBN"), {
        minChars: 0,
        width: 930,
        scroll: true,
        addRow: true,
        header: "<div style =\"width:100%;height:30px\">"
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
     
}         function xoaontable(control){
             if($(control).parents("table").find("tr").length < 4){
                    $.mkv.themDongTable($(control).parents("table").attr('id'));
                }
              $(control).XoaRow({
                 ajax:"../ajax/khambenh_ajax3.aspx?do=xoachitietbenhnhantoathuoc",
                 valueErXoa:"Không có quyền xóa !"
              });
         }
        function ThongTinBenhNhan()
        {
            var isLuuMoi=$.mkv.queryString("LuuMoiKhamBenh"); 
            if(isLuuMoi=="0")
                {
                    document.getElementById('btnToaThuocCu').style.display='none';
                }
            var idbenhnhan=$.mkv.queryString("idbenhnhan");
            
            $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/khambenh_ajax3.aspx?do=ThongnTinBenhNhanUserControl&idbenhnhan="+idbenhnhan,
                  success: function (value){
                        var arrBN= value.split('@@');
                        $("#spmabenhnhan").html(arrBN[0]);
                        $("#sptenbenhnhan").html(arrBN[1]);
                        $("#spnamsinh").html(arrBN[2]);
                        $("#spgioitinh").html(arrBN[3]);
                    }
             });
        }
         /////////////////////
         

         function ktrasltra(obj) {
            var slke = $(obj).parents("table").find("tr").eq($(obj).parent().parent().index()).find("#soluongke").val();
            if(slke == "")
                slke = 0;
                if(eval($(obj).val()) > eval(slke))
                     $(obj).val(slke);
        }
        function XuatKho(nvk_idkhambenh)
         {
            $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/khambenh_ajax3.aspx?do=xuatkho&idkhoachinh="+nvk_idkhambenh+"&idbenhnhan="+$.mkv.queryString("idbenhnhan")+"&iddieuduong=0",
                  success: function (value){
                        
                    }
             });
         }
        ///
        
//         $.mkv.afterThemDong = function(tablename,sodong)
//         {
//            // Loai Thuoc
//            var chuoitren= $("#"+tablename).find("tr").eq(sodong);
//            var chuoiduoi= $("#"+tablename).find("tr").eq(sodong + 1);
//            var dongduoi = chuoiduoi.find("#loaithuocid");
//            var dongtren = chuoitren.find("#loaithuocid");
//            dongduoi.val(dongtren.val());
//                 dongduoi = chuoiduoi.find("#mkv_loaithuocid");
//                 dongtren = chuoitren.find("#mkv_loaithuocid");
//            dongduoi.val(dongtren.val());
//            // Doi tuong
//                 dongduoi = chuoiduoi.find("#doituongthuocid");
//                 dongtren = chuoitren.find("#doituongthuocid");
//            dongduoi.val(dongtren.val());
//                 dongduoi = chuoiduoi.find("#mkv_doituongthuocid");
//                 dongtren = chuoitren.find("#mkv_doituongthuocid");
//            dongduoi.val(dongtren.val());
//            // Kho
//                 dongduoi = chuoiduoi.find("#idkho");
//                 dongtren = chuoitren.find("#idkho");
//            dongduoi.val(dongtren.val());
//                 dongduoi = chuoiduoi.find("#mkv_idkho");
//                 dongtren = chuoitren.find("#mkv_idkho");
//            dongduoi.val(dongtren.val());
//            
//            var DonViCoBan=chuoiduoi.find("#DonViCoBan");//$("#"+tablename).find("tr").eq(sodong+1).find("#DonViCoBan");
////	        if(DonViCoBan.lenght>0 )
////	        {
//	        DonViCoBan.attr("disabled",true);
//	        //}
//         }
$.mkv.afterThemDong = function(tablename,sodong)
         {
            // Loai Thuoc
          try{
            var chuoitren= tablename.find("tr").eq(sodong);
            var chuoiduoi= tablename.find("tr").eq(sodong + 1);
            var dongduoi = chuoiduoi.find("#loaithuocid");
            var dongtren = chuoitren.find("#loaithuocid");
            dongduoi.val(dongtren.val());
                 dongduoi = chuoiduoi.find("#mkv_loaithuocid");
                 dongtren = chuoitren.find("#mkv_loaithuocid");
            dongduoi.val(dongtren.val());
            // Doi tuong
                 dongduoi = chuoiduoi.find("#doituongthuocid");
                 dongtren = chuoitren.find("#doituongthuocid");
                 if(dongtren.is(":checked")==true)
                    dongduoi.attr("checked", true);
//            dongduoi.val(dongtren.val());
//                 dongduoi = chuoiduoi.find("#mkv_doituongthuocid");
//                 dongtren = chuoitren.find("#mkv_doituongthuocid");
//            dongduoi.val(dongtren.val());
            // Kho
                 dongduoi = chuoiduoi.find("#idkho");
                 dongtren = chuoitren.find("#idkho");
            dongduoi.val(dongtren.val());
                 dongduoi = chuoiduoi.find("#mkv_idkho");
                 dongtren = chuoitren.find("#mkv_idkho");
            dongduoi.val(dongtren.val());
                 dongduoi = chuoiduoi.find("#nvk_loaikho");
                 dongtren = chuoitren.find("#nvk_loaikho");
            dongduoi.val(dongtren.val());
            
            var DonViCoBan=chuoiduoi.find("#DonViCoBan");//$("#"+tablename).find("tr").eq(sodong+1).find("#DonViCoBan");
	        DonViCoBan.attr("disabled",true);
	      } catch(Ex){	        
	        }
	      try{
	            dongduoi = chuoiduoi.find("#idkhoxuat");
                dongtren = chuoitren.find("#idkhoxuat");
                    dongduoi.val(dongtren.val());
                dongduoi = chuoiduoi.find("#mkv_idkhoxuat");
                dongtren = chuoitren.find("#mkv_idkhoxuat");
                    dongduoi.val(dongtren.val());
                $("#" + tablename).find("tr").eq(dongso + 1).find("#dongia").attr("disabled", true);
                $("#" + tablename).find("tr").eq(dongso + 1).find("#thanhtien").attr("disabled", true);
                $("#" + tablename).find("tr").eq(dongso + 1).find("#cachdung").attr("disabled", true);
                $("#" + tablename).find("tr").eq(dongso + 1).find("#isngay").attr("checked", true);
               
	      }catch(Ex){
	      }
         }
function TimKiemToaThuocCu(obj)
{
      var idbenhnhan= $.mkv.queryString('idbenhnhan');
        $(obj).TimKiem({
            ajax:"../ajax/khambenh_ajax3.aspx?do=TimToaThuocTheoIdBenhNhan&idbenhnhan="+idbenhnhan+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+""
        },null,null,function(){
        });
}

function InChiDinhThuoc_Click()
{
    var idKhamBenhInThuoc=document.getElementById('idKhamBenhMoiLuuDV');
    if(idKhamBenhInThuoc != null && idKhamBenhInThuoc.value !="" && idKhamBenhInThuoc.value !="0")
        //window.open("../khambenh/InDonThuoc.aspx?IsChiDinh=1&IdKhamBenh="+idKhamBenhInThuoc.value,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');  
        window.open("../KhamBenh_TH/rpt_Toathuoc.aspx?IdKhamBenh="+idKhamBenhInThuoc.value+"&IsAll=1&IsChiDinh=1",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');  
    else
        alert("Bạn chưa lưu chỉ định thuốc !");
}

// lưu chỉ định thuốc () nvk luuchidinhthuoc****************************************************
function SaveChiDinhThuoc_Click()
{
    if(nvk_kiemtraKe_tablethuoc()==true)
    {
             if($("#idbacsi").val() == "" || $("#idbacsi").val() == "0")
                            {
                                $.mkv.myerror("Chưa chọn bác sỹ.");return ;
                            }
             //alert(document.getElementById('idicdxacdinh').value);// nvk alert
             var ListQuery="&idbacsi="+$("#idbacsi").val()+"&idicdxacdinh="+document.getElementById('idicdxacdinh').value+"&MoTaCD_edit="+encodeURIComponent(document.getElementById('motaicdxacdinh').value);
             var idKhamBenhLuu=document.getElementById('idKhamBenhMoiLuuDV').value;
             var NgayDuTruThuoc=document.getElementById('ngayDuTruThuoc').value;
             ListQuery +="&NgayDuTruThuoc="+NgayDuTruThuoc;
             $.ajax({
                            type:"GET",
                            dataType:"text",
                            cache:false,
                            async:true,
                            url:"../ajax/nvk_khamTongHop_ajax.aspx?do=Luukhambenhmoi&idctdkk="+$.mkv.queryString('idctdkk')+"&idkhoa="+$.mkv.queryString("IdKhoa")+"&idkhambenh=" +idKhamBenhLuu+"&idbenhnhan="+$.mkv.queryString("idbenhnhan")+"&LuuMoiKhamBenh="+$.mkv.queryString("LuuMoiKhamBenh")+ListQuery,
                            success:function (value) {
                                if(value !="0")
                                {
                                    document.getElementById('idKhamBenhMoiLuuDV').value=value;
                                $.LuuTable({
                                 ajax:"../ajax/khambenh_ajax3.aspx?do=luuTablechitietbenhnhantoathuoc&idkhambenh=" + document.getElementById('idKhamBenhMoiLuuDV').value+"&idbenhnhan="+$.mkv.queryString("idbenhnhan"),
                                 tablename:"gridTable"
                                },null,function () 
                                    {
                                        $.mkv.queryString("LuuMoiKhamBenh","0");
                                        nvk_luutableChanDoanPhoiHop(document.getElementById('idKhamBenhMoiLuuDV').value,1);
                                        XuatKho(document.getElementById('idKhamBenhMoiLuuDV').value);
                                        ///
                                        //nvk_TinhLaiTienBy_idctdkk($.mkv.queryString('idctdkk'));
                                    }
                                 );//end LuuTable
                                 
                                 } // end if
                                 else
                                 {
                                    alert("Lưu khám bệnh thất bại !");
                                 }
             }
                           });
    }
}
// end SaveChiDinhthuoc_Click() ****************************************************

//lưu bệnh nhân trả thuốc nvk 
function SaveTraThuoc_Click(idKbTraThuoc)
{
    $.LuuTable({
         ajax:"../ajax/khambenh_ajax3.aspx?do=luuTablechitietbenhnhantoathuoc&idkhambenh=" + idKbTraThuoc+"&idbenhnhan="+$.mkv.queryString("idbenhnhan"),
         tablename:"gridTable"
        },null,function () 
            {
            }
         );//end LuuTable
}
function LoadDsThuocCd()
    {
        $("#divDsThuocCd").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load danh sách chỉ định.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        $.ajax({
                type: "GET",
					cache: false,
					dataType:"text",
					url: "../ajax/nvk_khamTongHop_ajax.aspx?do=LoadDsThuocCd&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"&idctdkk="+$.mkv.queryString('idctdkk')+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa"),
					success: function(value) {
					    $("#divDsThuocCd").html(value);
					}
             });
    }
    

function InToaThuocRaVien(idkhambenh,nvk_idkhoa)
{
    //window.open("../noitru_BaoCao/nvk_InToaXuatVien.aspx?IsToaRV=1&IdKhamBenh="+idkhambenh,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');  
    window.open("../KhamBenh_TH/rpt_Toathuoc.aspx?IsToaRV=1&IdKhamBenh="+idkhambenh+"&IsAll=1",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');  
}
// from khambenh3.js
function iddvtsearch(obj) {
    $(obj).unautocomplete().autocomplete("../KhamBenh_TH/ajax/khambenh_ajax3.aspx?do=iddvtsearch", {
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
    $(obj).unautocomplete().autocomplete("../KhamBenh_TH/ajax/khambenh_ajax3.aspx?do=idcachdungsearch", {
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
//END  from khambenh3.js

function nvk_kiemtratonthuoc(obj)
{
    var soluongke= eval($(obj).val());
    var slKeTruoc= $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#nvk_slKeTruoc").val();
    if(slKeTruoc=="" || slKeTruoc=="undefined")
        slKeTruoc= "10";
    soluongke= soluongke - slKeTruoc;
    //alert(slKeTruoc+"; soluongke="+soluongke);
    var soluogton= eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#nvk_soluongton").val());
    if(soluongke > soluogton)
    {
        alert("Số lượng kê không được lớn hơn số tồn ("+soluogton+")");
        $(obj).val(soluogton);
        $(obj).focus();
        //$("#luuCDThuoc").css("display","none");
        disabled_luu();
        //document.getElementById('luuCDThuoc').style.display='none';
    }
    else
    {
        enable_luu();
    }
}
function disabled_luu()
{
        $("#luuCDThuoc").attr("disabled",true);
        $("#luuCDThuoc").css("background-color","#778899");
        $("#luuCDThuoc").css("background-images","none");
}
function enable_luu()
{
        $("#luuCDThuoc").attr("disabled",false);
        $("#luuCDThuoc").css("background-color","");
        $("#luuCDThuoc").css("background-images","none");
}
function nvk_kiemtraKe_tablethuoc()
{
    var sodong= $('#gridTable tr').length;//$("#gridTable").attr('rows').length;//document.getElementById('gridTable').rows.length;
    var isSave=true;
    for(var i=1;i<sodong;i++)
    {
        var idthuoc= eval($("#gridTable").find("tr").eq(i).find("#idthuoc").val());
        if(idthuoc=="0" || idthuoc=="" || idthuoc=="undefined")
            continue;
        var soluongke= eval($("#gridTable").find("tr").eq(i).find("#soluongke").val());
        var slKeTruoc= $("#gridTable").find("tr").eq(i).find("#nvk_slKeTruoc").val();
        if(slKeTruoc=="" || slKeTruoc=="undefined")
            slKeTruoc= "10";
        soluongke= soluongke - slKeTruoc;
        //alert(slKeTruoc+"; soluongke="+soluongke);
        var soluogton= eval($("#gridTable").find("tr").eq(i).find("#nvk_soluongton").val());
        if(soluongke > soluogton)
        {
            alert($("#gridTable").find("tr").eq(i).find("#mkv_idthuoc").val()+" kê="+soluongke+" > số tồn ("+soluogton+")");
            isSave= false; //break;
        }
    }
    if(isSave== false)
    {
        disabled_luu();
        return false;
    }
    else
    {
        enable_luu();
        return true;        
    }
}

function nvk_CheckValidSLTra(obj,soluongtong)
{
    if(obj.value> soluongtong)
    {
        alert("Trả không được > '"+soluongtong+"'");
        obj.value = soluongtong;
    }
    if(obj.value =="")
    {
        obj.value="0";
    }
}


