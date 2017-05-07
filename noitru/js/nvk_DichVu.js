// JScript File
$(document).ready(function(){
    
    $("#moi").live("click",function(){
        $(this).Moi({Frame:$(this).closest("#thongtindichvu"),idkhoachinh:""});
        $(this).closest("#thongtindichvu").find("#ngaykham").focus();
    });

});
function loadTableAjaxkhambenhcanlamsan(idkhamBenhLoad,page)
         {
             if(idkhamBenhLoad == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_khambenhcanlamsan").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load thông tin dịch vụ.....<img id='imgLoading' src='../images/processing.gif' /></span>");
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/khambenh_ajax3.aspx?do=loadTablekhambenhcanlamsan&idkhambenh="+idkhamBenhLoad+"&page="+page,
                  success: function (value){
                         $("#tableAjax_khambenhcanlamsan").html(value);
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                         //document.getElementById('txt_cls').focus();
                    }
             });
         }
                 //  xu ly danh sach CLS
        function thanhtiencls(obj) {
            if($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#chietkhau").val()=="" || $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#chietkhau").val()== null)  
                $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#chietkhau").val(0);
            if($(obj).parents("#gridTablecls").attr("id") != null){
                var tientruocck = eval($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val()) * eval($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val());
                var tienck = (eval(tientruocck)*eval($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#chietkhau").val()))/100;
                $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(tientruocck - tienck);
            }else{
                var so_dong = $("#gridTablecls").find("tr").length - 2;
                var tientruocck = eval($("#gridTablecls").find("tr").eq(so_dong).find("#dongia").val()) * eval($("#gridTablecls").find("tr").eq(so_dong).find("#soluong").val());
                var tienck = (eval(tientruocck)*eval($("#gridTablecls").find("tr").eq(so_dong).find("#chietkhau").val()))/100;
                $("#gridTablecls").find("tr").eq(so_dong).find("#thanhtien").val(tientruocck - tienck);
            }
        }
         function idcanlamsansearch(obj,loai)
         {
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=idcanlamsansearch&idctdkk="+$.mkv.queryString('idctdkk')+"&loai="+loai,{
             minChars:0,
             width:550,
             scroll:true,
             addRow:true,
             header:"<div style =\"color:Blue;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#CAE3FF;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
       + "<div style=\"width:80%;height:30px;color:Blue;font-weight:bold;float:left\" >Tên dịch vụ</div>"
       + "<div style=\"width:20%;color:Blue;font-weight:bold;float:left\" >DmBH?</div>"
       + "</div>",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                $(obj).val(data[1]);
                 if($(obj).parents("table:first").attr("id") != null){                 
                     //$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[2]);
                     $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#idcanlamsan").val(data[2]);
                     $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val("1");
                     
                     thanhtiencls(obj);   
                     setTimeout(function () {
                        $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()+ 1 ).find("#mkv_idcanlamsan").focus();
                        // nvk set isBHYT
                        if(data[4]=="1")
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
                     // is CLS trong danh mục BH
                        if(data[5]=="1")
                        {
                            $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_DM").attr("checked", true);
                        }
                        else
                        {
                            $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#IsBHYT_DM").attr("checked", false);
                        }
                        $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index() + 1).find("#IsBHYT_DM").attr("disabled",true);
                     // end is CLS trong danh mục BH
                     },100); 
                 }
             });
         }
        var listCLS = "";
        function ChonCLS(obj,idnhom,idpkb,loai,LoaiBN)
        {
            var form = "";
            if(loai != null){
                if(loai == "cls")
                    form = $(obj).closest("#thongtindichvu").find("#gridTablecls");
                else if(loai == "dichvu")
                    form = $(obj).closest("#thongtindichvu").find("#gridTabledichvu");
            }else{
                form = $("#gridTablecls");
            }
            if(idpkb == null)
                listCLS = "";
            for(var i=1;i<form.find("tr").length;i++)
            {
                if($.trim(form.find("tr").eq(i).find("#idcanlamsan").val()).length > 0 )
                    listCLS += form.find("tr").eq(i).find("#idcanlamsan").val()+",";
            }
            if(idpkb == null)
                idpkb = 0;
            $(obj).TimKiem({
                ajax:"../ajax/khambenh_ajax3.aspx?do=ChonCLS&listID="+listCLS+"&idpkb="+idpkb+"&IdBenhNhan="+$.mkv.queryString("idbenhnhan")+"&loai="+loai+"&LoaiBN="+$.mkv.queryString("LoaiBN"),readMKV:false
            });
            
        }
        function checkAllCLS(obj) {
            var tableCLS = $(obj).parents("table").find("tr");
            for(var i=0;i<tableCLS.length;i++)
            {
                CheckXoaCLS(tableCLS.eq(i).find("input[type=checkbox]").val());
                if($(obj).is(":checked")){
                    tableCLS.eq(i).find("input[type=checkbox]").attr("checked",true);
	                listCLS += tableCLS.eq(i).find("input[type=checkbox]").val()+",";
                }else{
                    tableCLS.eq(i).find("input[type=checkbox]").attr("checked",false);
                }
            }
        }
        function setChonDichVuCLS(obj) {
            CheckXoaCLS($(obj).val());
            if($(obj).is(":checked")){
	             listCLS += $(obj).val()+",";
            }
        }
        
        function CheckXoaCLS(vals) {
            if(listCLS.indexOf(",")!=-1)
            {
                var arrIDDV  = listCLS.split(',');
                for(var j = 0 ; j<arrIDDV.length;j++)
                {
	                if(arrIDDV[j] == vals)
	                {
	                    var stemp = new RegExp(arrIDDV[j]+",", 'g');
	                    listCLS = listCLS.replace(stemp,'');
	                    break;
	                }
                   
                }
            }
        }
        $.mkv.runCloseTimKiem = function (obj) {
           var form = $(obj).closest("#thongtindichvu");
           var loai = "";
           if($(obj).attr("onclick").indexOf("cls") != -1){
                form = form.find("#gridTablecls");
                loai = "cls";
           }
           else if($(obj).attr("onclick").indexOf("dichvu") != -1){
                form = form.find("#gridTabledichvu");
                loai = "dichvu";
           }
            var slvack = "";
            for(var i=0;i<form.find("tr").length;i++){
                var idcls = form.find("tr").eq(i).find("#idcanlamsan").val();
                var sl = form.find("tr").eq(i).find("#soluong").val();
                if(sl > 1)
                    slvack += "@"+idcls+"^"+sl;
                
            }
            var idkhambenh = $(obj).closest("#thongtindichvu").find("#idKhamBenhMoiLuuDV").val();
            $("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
            $.ajax({
                type:"GET",
                dataType:"text",
                url:"../ajax/nvk_khamTongHop_ajax.aspx?do=GetDSCLS&listID="+listCLS+"&IdBenhNhan="+$.mkv.queryString("idbenhnhan")+"&IdKhambenh="+idkhambenh+"&slvack="+slvack+"&loai="+loai+"&LoaiBN="+$.mkv.queryString("LoaiBN"),
                success:function (data) {
                     if(loai == "cls")
                        $(obj).closest("#thongtindichvu").find("#tableAjax_khambenhcanlamsan").html(data);
                     else if(loai == "dichvu")
                        $(obj).closest("#thongtindichvu").find("#tableAjax_khambenhdichvu").html(data);
                     $("#loadingAjax").remove();
                }
            });
        }
         function xoaontablecls(control){
            if($(control).parents("table").find("tr").length < 4){
                $.mkv.themDongTable($(control).parents("table").attr('id'));
            }
                  var valueCLS = $(control).parents("table").find("tr").eq($(control).parent().parent().index()).find("#idcanlamsan").val();
                  $(control).XoaRow({
                     ajax:"../ajax/khambenh_ajax3.aspx?do=xoakhambenhcanlamsan",
                 valueErXoa:"Không có quyền xóa !"
                  });
               
                  (($(control).parent().parent().index() == -1) ? CheckXoaCLS(valueCLS):"");  
                        
         }
function nvk_HuyOnTablecls(obj,idkhambenhcanlamsan,tendichvu)
{
    if($(obj).html()=="Đã hủy")
    {
        return;
    }
var msg="Bạn muốn hủy dịch vụ : "+tendichvu+" ?";
    if(confirm(msg))
    {
        nvk_Huykbcls(obj,idkhambenhcanlamsan,1);
    }
    else
    {
        //nvk_Huykbcls(obj,idkhambenhcanlamsan,0);       
    }
}
function nvk_Huykbcls(obj,idkhambenhcanlamsan,dahuy)
{
    var PathUrl="../ajax/nvk_commonFuntion_ajax.aspx?do=nvk_setHuyKhamBenhCanLamSang&idkbcls="+idkhambenhcanlamsan+"&nvkDahuy="+dahuy+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                           if(value=="1")
					        {
					            if(dahuy== 1)
					            {
                                    $(obj).html("Đã hủy");
                                    alert("Đã hủy !");
                                }
                                else
                                {
                                    $(obj).html("Hủy");
                                    //alert("Đã cập nhật !");
                                }
                            }
                            else
                                alert(value);
                        }
                });
}
         //////////Làm mới///////////
function ThongTinBenhNhan()
        {
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
function SaveChiDinhCls_Click(obj,Stt_table)
{
 var form = $(obj).closest("#thongtindichvu");
 if(form.find("#idbacsi").val() == "" || form.find("#idbacsi").val() == "0")
            {
                $.mkv.myerror("Chưa chọn bác sỹ.");return ;
            }
 var ListQuery="&idbacsi="+form.find("#idbacsi").val()+"&idicdxacdinh="+form.find("#idicdxacdinh").val()+"&MoTaCD_edit="+encodeURIComponent(form.find("#motaicdxacdinh").val());
 var idKhamBenhLuu=form.find("#idKhamBenhMoiLuuDV").val();
    $.ajax({
            type:"GET",
            dataType:"text",
            cache:false,
            async:true,
            url:"../ajax/nvk_khamTongHop_ajax.aspx?do=Luukhambenhmoi&idctdkk="+$.mkv.queryString('idctdkk')+"&idkhoa="+$.mkv.queryString("IdKhoa")+"&idkhambenh=" +idKhamBenhLuu+"&idbenhnhan="+$.mkv.queryString("idbenhnhan")+"&ngaykham="+form.find("#ngaykham").val()+ListQuery,
            success:function (value) {
                if(value !="0")
                {
                    form.find("#idKhamBenhMoiLuuDV").val(value);
                    
                // can lam sang    
                $.LuuTable({
                     ajax:"../ajax/khambenh_ajax3.aspx?do=luuTablekhambenhcanlamsan&idkhambenh=" + form.find("#idKhamBenhMoiLuuDV").val()+"&idbenhnhan="+$.mkv.queryString("idbenhnhan"),
                     tablename:form.find("#gridTablecls"),valueMesComplete:"Đã Lưu CLS .."
                },null,function (){
                        // chan doan phoi hop
                        $.LuuTable({
                             ajax:"../ajax/nvk_khamTongHop_ajax.aspx?do=nvk_luutableChanDoanPhoiHop&idkhoa="+$.mkv.queryString("IdKhoa")+"&idkhambenh="+form.find("#idKhamBenhMoiLuuDV").val()+"",
                             tablename:form.find("#gridTableCDPH"+Stt_table),valueMesComplete:"Đã Lưu chẩn đoán phối hợp .."
                        },null,function(){
                            // dich vu
                           $.LuuTable({
                                 ajax:"../ajax/khambenh_ajax3.aspx?do=luuTablekhambenhcanlamsan&idkhambenh=" + form.find("#idKhamBenhMoiLuuDV").val()+"&idbenhnhan="+$.mkv.queryString("idbenhnhan"),
                                 tablename:form.find("#gridTabledichvu"),valueMesComplete:"Đã Lưu dịch vụ .."
                            },null,function(){
                                 nvk_TinhLaiTienBy_idctdkk($.mkv.queryString('idctdkk'));                                
                            });   
                        });
                });//end LuuTable
                }//end if
                else
                                 {
                                    alert("Lưu chỉ định thất bại !");
                                 }
            }
      });
}
// end SaveChiDinhCls_Click() ****************************************************
function InChiDinhCls_Click(obj,nvkLoaiDC)
{
//    var idKhamBenhInCLS=$(obj).closest("#thongtindichvu").find('#idKhamBenhMoiLuuDV');
//    if(idKhamBenhInCLS != null && idKhamBenhInCLS.value !="" && idKhamBenhInCLS.value !="0")
//        window.open("../noitru_baocao/NVK_inchidinhLamsan_NoiTru.aspx?idkhambenh="+idKhamBenhInCLS.val()+"&idkhoa="+$.mkv.queryString("IdKhoa")+"#isPrint=1");
//    else
//        alert("Bạn chưa lưu thông tin dịch vụ !");
        
    var idKhamBenhInCLS=$(obj).closest("#thongtindichvu").find('#idKhamBenhMoiLuuDV');//=document.getElementById('idKhamBenhMoiLuuDV');
    if(idKhamBenhInCLS != null && idKhamBenhInCLS.val() !="" && idKhamBenhInCLS.val() !="0")
    {
        var LoaiCD="";
//        if(nvkLoaiDC==1)
//            LoaiCD="&nvk_loaiDC=cls";
//        if(nvkLoaiDC==2)
//            LoaiCD="&nvk_loaiDC=dv";
//        window.open("../noitru_baocao/NVK_inchidinhLamsan_NoiTru.aspx?idkhambenh="+idKhamBenhInCLS.val()+"&idkhoa="+$.mkv.queryString("IdKhoa")+LoaiCD+"#isPrint=1");
        if(nvkLoaiDC==1)
            LoaiCD="&isdvkt=0";
        if(nvkLoaiDC==2)
            LoaiCD="&isdvkt=1";
        window.open("../KhamBenh_TH/rptPhieuChiDinh.aspx?idkhambenh="+idKhamBenhInCLS.val()+"&IsAll=1"+LoaiCD+"");
    }
    else
        alert("Bạn chưa lưu thông tin dịch vụ !");
}
function nvk_In1ChiDinh(idkhambenh,idkbcls)
{
    window.open("../noitru_baocao/NVK_inchidinhLamsan_NoiTru.aspx?idkhambenh="+idkhambenh+"&nvk_IdKbCls="+idkbcls+"&idkhoa="+$.mkv.queryString("IdKhoa")+"#isPrint=1");
}
  function huongdieutrisearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/khamcapcuu_ajax.aspx?do=huongdieutrisearch_KhamcapCuu",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             triggerDelete:"xoaloadsauhuongdieutri()",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 $("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 Loadsauhuongdieutri();
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
    function xoaloadsauhuongdieutri() {
            $("#loadsauhuongdieutri").html("");
         }
    function Loadsauhuongdieutri() {
             $.ajax({
                type: "GET",
					cache: false,
					dataType:"text",
					url: "../ajax/khamcapcuu_ajax.aspx?do=Loadsauhuongdieutri&huongdieutri="+$("#huongdieutri").val()+"&idkhoa="+$.mkv.queryString('IdKhoa'),
					success: function(value) {
					    $("#loadsauhuongdieutri").html(value);
					}
             });
         }
     function ghichuhuongdieutriSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/khamcapcuu_ajax.aspx?do=ghichuhuongdieutriSearch&mkv_ghichuhuongdieutri="+encodeURIComponent($("#mkv_ghichuhuongdieutri").val()),{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 $("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
     function khoakhambenhSearch(obj,huongdieutri)
     {
         $(obj).unautocomplete().autocomplete("../ajax/khamcapcuu_ajax.aspx?do=khoakhambenhSearch&huongdieutri="+huongdieutri,{
         minChars:0,
         width:350,
         scroll:true,
         header:"DANH SÁCH",
         formatItem:function (data) {
              return data[0];
         }}).result(function(event,data){
             if($("#"+$(obj).attr("id").replace("mkv_","")).val() != data[1]){
                  $("#mkv_idDVPhongChuyenDen").val("");
                 $("#idDVPhongChuyenDen").val("");
                 $("#mkv_idPhongChuyenDen").val("");
                 $("#idPhongChuyenDen").val("");
             }
             $("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
             setTimeout(function () {
                 obj.focus();
             },100);
         });
     }
     function banggiadichvuSearch(obj)
     {
         $(obj).unautocomplete().autocomplete("../ajax/khamcapcuu_ajax.aspx?do=banggiadichvuSearch&khoakhambenh="+$("#khoakhambenh").val()+"&huongdieutri="+$("#huongdieutri").val(),{
         minChars:0,
         width:350,
         scroll:true,
         header:"DANH SÁCH",
         formatItem:function (data) {
              return data[0];
         }}).result(function(event,data){
             if($("#"+$(obj).attr("id").replace("mkv_","")).val() != data[1]){
                $("#mkv_idPhongChuyenDen").val("");
                 $("#idPhongChuyenDen").val("");
             }
             $("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
             setTimeout(function () {
                 obj.focus();
             },100);
         });
     }
     function phongkhambenhSearch(obj)
     {
         $(obj).unautocomplete().autocomplete("../ajax/khamcapcuu_ajax.aspx?do=phongkhambenhSearch&banggiadichvu="+$("#idDVPhongChuyenDen").val()+"&idbenhnhan="+$.mkv.queryString("idbenhnhan"),{
         minChars:0,
         width:350,
         scroll:true,
         header:"DANH SÁCH",
         formatItem:function (data) {
              return data[0];
         }}).result(function(event,data){
             $("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
             setTimeout(function () {
                 obj.focus();
             },100);
         });
     }
     function idbacsisearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/nvk_commonFuntion_ajax.aspx?do=idbacsisearch&idkhambenhgoc="+$.mkv.queryString("idkhoachinh"),{
             minChars:0,
             width:550,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 $("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
    function idICDCapCuusearchMaICD(obj)
    {
        $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=idICDCapCuusearchMaICD&idkhambenhgoc="+$.mkv.queryString("idkhoachinh"),{
             minChars:0,
             width:550,
             scroll:true,
             header:"Chẩn đoán ICD10",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                    document.getElementById('idicd').val(data[1]);
                    alert(document.getElementById('idicd').val());
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
    }
    function idICDCapCuusearchMoTa(obj)
    {
        $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=idICDCapCuusearchMoTa&idkhambenhgoc="+$.mkv.queryString("idkhoachinh"),{
             minChars:0,
             width:550,
             scroll:true,
             header:"Chẩn đoán ICD10",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                    $("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
    }
    function loadicd(obj,loai,kieu)
	 {
             $(obj).unautocomplete().autocomplete("../ajax/nvk_commonFuntion_ajax.aspx?do=loadicd&loai="+loai,{
             minChars:0,
             width:600,
             scroll:true,
             formatItem:function (data) {
                 return data[0];
            },header: "<div style =\"height:24px\">"
                    + "<div style=\"width:80px;color:white;font-weight:bold;float:left\" >MÃ ICD10</div>"
                    + "<div style=\"width:400px;color:white;font-weight:bold;float:left\" >MÔ TẢ</div>"
                    + "</div>"}
        ).result(function(event,data){
//                if(kieu=="td"){
//                    $("#idicdtuyenduoi").val(data[1]);
//                    $("#maicdtuyenduoi").val(data[2]);
//                    $("#motaicdtuyenduoi").val(data[3]);}
                if(kieu=="xd"){
                    $(obj).closest("div").find('#idicdxacdinh').val(data[1]);
                    $(obj).closest("div").find('#mkv_idicdxacdinh').val(data[2]);
                    $(obj).closest("div").find('#motaicdxacdinh').val(data[3])} 
                if(kieu=="ph"){
                    setChonChanDoanPhoiHop(data[1],data[2],data[3]);
                       $(obj).val("");
                }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
    function Setsauhuongdieutri() {
             $.ajax({
                type: "GET",
					cache: false,
					dataType:"text",
					url: "../ajax/khamcapcuu_ajax.aspx?do=Setsauhuongdieutri&idkhambenhgoc="+$.mkv.queryString("idkhoachinh")+"&idkhoachinh="+$.mkv.queryString("idkhoachinh"),
					success: function(value) {
					    $("#loadsauhuongdieutri").html(value);
					}
             });
         }
    function SetBacSiChiDinh() {
             var idKhamBenh= document.getElementById('idKhamBenhMoiLuuDV');
             var IdKhoaChinh="";
//             if(idKhamBenh ==null || idKhamBenh.value =="0" || idKhamBenh.value=="")
//                IdKhoaChinh=$.mkv.queryString("idkhoachinh");
//             else
                IdKhoaChinh=idKhamBenh.value;                
             $.ajax({
                type: "GET",
					cache: false,
					dataType:"text",
					url: "../ajax/khambenh_ajax3.aspx?do=SetBacSiChiDinh&idctdkk="+$.mkv.queryString("idctdkk")+"&idkhoachinh="+IdKhoaChinh+"&idkhoa="+$.mkv.queryString("IdKhoa"),
					success: function(value) {
					    $("#divBacSi").html(value);
					}
             });
         }
    function SetChanDoanXacDinh() {
             var idKhamBenh= document.getElementById('idKhamBenhMoiLuuDV');
             var IdKhoaChinh="";
//             if(idKhamBenh ==null || idKhamBenh.value =="0" || idKhamBenh.value=="")
//                IdKhoaChinh=$.mkv.queryString("idkhoachinh");
//             else
                IdKhoaChinh=idKhamBenh.value; 
             $.ajax({
                type: "GET",
					cache: false,
					dataType:"text",
					url: "../ajax/khambenh_ajax3.aspx?do=SetChanDoanXacDinh&idctdkk="+$.mkv.queryString("idctdkk")+"&idkhoachinh="+IdKhoaChinh+"&idkhoa="+$.mkv.queryString("IdKhoa"),
					success: function(value) {
					    $("#divChanDoan").html(value);
					}
             });
         }
    function SetChanDoanPhoiHop() {
             var idKhamBenh= document.getElementById('idKhamBenhMoiLuuDV');
             var IdKhoaChinh="";
             if(idKhamBenh ==null || idKhamBenh.value =="0" || idKhamBenh.value=="")
                IdKhoaChinh=$.mkv.queryString("idkhoachinh");
             else
                IdKhoaChinh=idKhamBenh.value; 
             $("#divChanDoanPhoiHop").html("<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang load chẩn đoán phối hợp.....<img id='imgLoading' src='../images/processing.gif' /></span>");
             $.ajax({
                type: "GET",
					cache: false,
					dataType:"text",
					url: "../ajax/nvk_khamTongHop_ajax.aspx?do=SetChanDoanPhoiHop&idctdkk="+$.mkv.queryString('idctdkk')+"&idkhambenhgoc="+$.mkv.queryString("idkhoachinh")+"&idkhoachinh="+IdKhoaChinh+"&idkhoa="+$.mkv.queryString("IdKhoa"),
					success: function(value) {
					    $("#divChanDoanPhoiHop").html(value);
					}
             });
         }
    function SethuongdieutriTheoDoiCapCuu() {
             $.ajax({
                type: "GET",
					cache: false,
					dataType:"text",
					url: "../ajax/khamcapcuu_ajax.aspx?do=SethuongdieutriTheoDoiCapCuu&idkhambenhgoc="+$.mkv.queryString("idkhoachinh")+"&idkhoachinh="+$.mkv.queryString("idkhoachinh"),
					success: function(value) {
					    $("#divHuongDieuTri").html(value);
					}
             });
         }
    // Chẩn đoán phối hợp
    function setChonChanDoanPhoiHop(idchandoan, machandoan, tenchandoan)
	{
	    var Curdong = document.getElementById('chandoanicd10_1').rows.length;
	    document.getElementById("chandoanicd10_1").style.display ='';
	    	    for(var i=0;i<Curdong;i++)
	    	    {
	    	    try{
	    	        if(idchandoan == document.getElementById('chandoanicd10_1').rows[i].cells[1].getElementsByTagName("input")[0].value)
	    	        {
	    	            return;
	    	        }
	    	        }catch(ex){}
	    	    }
	    $("#chandoanicd10_1").append("<tr><td style=\"cursor:pointer\" onclick=\"javascript:document.getElementById('chandoanicd10_1').deleteRow(this.parentNode.rowIndex);\">X</td><td><input type='hidden' id='idchandoanicd10_"+Curdong+"' value='"+idchandoan+"' />"+machandoan+"</td><td>"+tenchandoan+"</td></tr>");
	}
	function Luuchandoanphoihop(idkhambenh,isLoadThuoc){
		var listidchandoanicd10;
	 for (var i = 1; i < document.getElementById("chandoanicd10_1").rows.length; i++)
                { 
                   if(document.getElementById("idchandoanicd10_"+i) != null)
                   {
                        listidchandoanicd10 = listidchandoanicd10 +"@"+ document.getElementById("idchandoanicd10_"+i).value;
                   }
                }
                
	     xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                if(isLoadThuoc==0)
                    LoadDsClsCd();
                else
                    LoadDsThuocCd();
            }
        }
            xmlHttp.open("GET","../khambenh/ajax.aspx?do=luuchandoanphoihop&idchandoan="+listidchandoanicd10+"&idkhambenh="+idkhambenh,true);
        xmlHttp.send(null);
	}
function nvk_luutableChanDoanPhoiHop(idkhambenh,isLoadThuoc)
{
   $.LuuTable({
         ajax:"../ajax/nvk_khamTongHop_ajax.aspx?do=nvk_luutableChanDoanPhoiHop&idkhoa="+$.mkv.queryString("IdKhoa")+"&idkhambenh="+idkhambenh+"",
         tablename:"gridTableCDPH0"
        },null,function () 
            {
                alert("Đã lưu THÀNH CÔNG !");
                if(isLoadThuoc==0)
                {
                    LoadDsClsCd();
                }
                else
                {
                    LoadDsThuocCd();
                }
            }
         );//end LuuTable
}
function nvk_luutableChanDoanPhoiHop_XK(idxuatkhoa,isAlertSuccess,IdKbXK,idbenhnhan)
{
   $.LuuTable({
         ajax:"../ajax/nvk_khamTongHop_ajax.aspx?do=nvk_luutableChanDoanPhoiHop_XK&idkhoa="+$.mkv.queryString("IdKhoa")+"&idxuatkhoa="+idxuatkhoa+"",
         tablename:"gridTableCDPH0"
        },null,function () 
            {
                if(isAlertSuccess != null && isAlertSuccess=="1")
                    alertXuatKhoaThanhCong();
                if(IdKbXK != null && idbenhnhan != null)
                {
                    nvk_LuuToaXuatVien(IdKbXK,idbenhnhan); // lưu table toa thuốc xuất viện
                }
            }
         );//end LuuTable
}

    // end chẩn đoán phối hợp
    function LoadDsClsCd()
    {
        $("#divDsClsCd").html("<span style='height: auto; width: 100%;text-align:center; color: White; font-weight: bold;font-style:italic' class='Tieude'> Đang load danh sách chỉ định.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        $.ajax({
                type: "GET",
					cache: false,
					dataType:"text",
					url: "../ajax/nvk_khamTongHop_ajax.aspx?do=LoadDsClsCd&idbenhnhan="+$.mkv.queryString('idbenhnhan')+"&idctdkk="+$.mkv.queryString('idctdkk')+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa"),
					success: function(value) {
					    $("#divDsClsCd").html(value);
					}
             });
    }
    
    function ChanDoansearch(obj,IsMa,Stt_table)
         {
             $(obj).unautocomplete().autocomplete("../ajax/nvk_khamTongHop_ajax.aspx?do=ChanDoansearch&IsMaICD="+IsMa+"",{
             minChars:0,
             width:550,
             scroll:true,
             addRow:false,
             header:"Chẩn đoán ICD10...",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#idicd").val(data[1]);
                $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idicd").val(data[2]);
                $(obj).parents("table:first").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idicdMoTa").val(data[3]);
                 nvk_themdongtableCDPH(obj,Stt_table);
                 setTimeout(function () {
                     obj.focus();
                 },100);
                 
             });
             
         }
         function xoaontableCDPH(control){
            if($(control).parents("table").find("tr").length < 4){
                nvk_themdongtableCDPH(control);
            }
                  var valueCLS = $(control).parents("table").find("tr").eq($(control).parent().parent().index()).find("#idicd").val();
                  $(control).XoaRow({
                     ajax:"../ajax/nvk_khamTongHop_ajax.aspx?do=xoanvk_chanDoanPhoiHop",
                     valueErXoa:"Không có quyền xóa !"
                  });               
         }
function xoaontableCDPH_XK(control){
            if($(control).parents("table").find("tr").length < 4){
                nvk_themdongtableCDPH(control);
            }
                  var valueCLS = $(control).parents("table").find("tr").eq($(control).parent().parent().index()).find("#idicd").val();
                  $(control).XoaRow({
                     ajax:"../ajax/nvk_khamTongHop_ajax.aspx?do=xoanvk_chanDoanXuatKhoa",
                     valueErXoa:"Không có quyền xóa !"
                  });               
         }
function nvk_themdongtableCDPH(obj,Stt_table)
    {
        if(document.getElementById("gridTableCDPH"+Stt_table).rows[obj.parentNode.parentNode.rowIndex + 1] == null)
        {
            var htmlPH="<tr>"
                +"<td>" + (obj.parentNode.parentNode.rowIndex + 1) + "</td>"
                +"<td><a onclick='xoaontableCDPH(this)'>Xóa</a></td>"
                +"<td><input mkv='true' id='idicd' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idicd' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,1,"+Stt_table+")' value='' class='down_select' style='width:80px'/></td>"
                +"<td><input mkv='true' id='mkv_idicdMoTa' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,0,"+Stt_table+")' value='' class='down_select' style='width:90%'/></td>"
                //+"<td><input id='mkvDown' type='text'  value='' style='width:10px'  onkeydown=\"chuyendongPH(this);\" /></td>"
                +"<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>"
                +"</tr>";
            $("#gridTableCDPH"+Stt_table).append(htmlPH);
            
        }


                    ////alert($(obj).parents("table:first")+"; obj.parentNode.parentNode="+ obj.parentNode.parentNode);
                    //var nvk_TenTable= "#"+obj.parentNode.parentNode.parentNode.parentNode.id;
                    //var obj_table= $(nvk_TenTable);
                    //    obj_table= $(obj).parents("table");
                    ////alert(obj_table.find("tr").eq(obj.parentNode.parentNode.rowIndex + 1).find("#idicd").val());
                    ////        if(obj_table.rows[obj.parentNode.parentNode.rowIndex + 1] == null)
                    ////        {
                    ////        }
                    ////        {
                    //            var htmlPH="<tr>"
                    //                +"<td>" + (obj.parentNode.parentNode.rowIndex + 1) + "</td>"
                    //                +"<td><a onclick='xoaontableCDPH(this)'>Xóa</a></td>"
                    //                +"<td><input mkv='true' id='idicd' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idicd' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,1)' value='' class='down_select' style='width:80px'/></td>"
                    //                +"<td><input mkv='true' id='mkv_idicdMoTa' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,0)' value='' class='down_select' style='width:90%'/></td>"
                    //                //+"<td><input id='mkvDown' type='text'  value='' style='width:10px'  onkeydown=\"chuyendongPH(this);\" /></td>"
                    //                +"<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>"
                    //                +"</tr>";
                    //            obj_table.append(htmlPH);
                    //            
                    ////        }
    }
function nvkHienTuyChonIn(control,nvkIdKhamBenh) {
              if(nvkIdKhamBenh== -1)
                {
                    var idKhamBenhInCLS=$(control).closest("#thongtindichvu").find('#idKhamBenhMoiLuuDV');
                    if(idKhamBenhInCLS != null && idKhamBenhInCLS.val() !="" && idKhamBenhInCLS.val() !="0")
                     {
                        nvkIdKhamBenh= eval(idKhamBenhInCLS.val());                                            
                     }
                    else
                     {
                        alert("Chưa lưu thông tin chỉ định !");return;
                     }
                }
              $(control).TimKiem({
                     ajax:"../ajax/nvk_commonFuntion_ajax.aspx?do=nvk_TuyChonInChiDinh&idkhambenh="+nvkIdKhamBenh,readMKV:false
                     ,title: "In CLS & DV theo yêu cầu"
               });
               }
 ///              
//  In CLS & DV tùy chọn 
function CheckChonCLS(objCB,TienCLS)
     {
        var idcls=objCB.id;
        var lisIDClsIn=document.getElementById("lisIDClsIn").value;
        //alert(lisIDClsIn);
        var ListNew="";
        var arr = lisIDClsIn.split(',');
        //danh sách check Hoàn
        for(var i=0;i<arr.length;i++)
        {
            if(arr[i] !="")
            {
                if(eval(idcls)!=eval(arr[i]))
                {
                    ListNew +=arr[i]+",";
                }
            }
        }
        if(objCB.checked==true )
        {
            ListNew +=idcls;
        }
        document.getElementById("lisIDClsIn").value=ListNew;
     }
function CheckAllCLS(objCAll,idkhambenh, isDV)
{
    var TinhTrangChon="";
    if(objCAll.checked==true)
        TinhTrangChon="true";
    else
        TinhTrangChon="false";    
    var objSP = $("#spDSCLS");
    if(isDV==1)    
        objSP = $("#spDSDichVu");
    objSP.html("<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang load .....<img id='imgLoading' src='../images/processing.gif' /></span>");
    var listID_CLSIN = document.getElementById("lisIDClsIn").value;
        var PathUrl="../ajax/nvk_commonFuntion_ajax.aspx?do=nvk_CheckAllCLS_In&idkhambenh="+idkhambenh+"&CheckAll="+TinhTrangChon+"&ListIDCLS="+listID_CLSIN+"&nvk_isDV="+isDV+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            var arr = value.split('~~');
                            if(isDV==0)
                                document.getElementById('spDSCLS').innerHTML=arr[0];
                            else
                                document.getElementById('spDSDichVu').innerHTML=arr[0];
                            document.getElementById("lisIDClsIn").value=arr[1];
                            
                        }
                });
}

function nvk_InTuyChonCLS_DV(idkhambenh)
{
var listID_in = document.getElementById("lisIDClsIn").value;
    if(listID_in == "" || listID_in == "0")
    {
        alert("Chưa chọn mục cần in !"); return;
    }
    //window.open("../noitru_baocao/NVK_inchidinhLamsan_NoiTru.aspx?idkhambenh="+idkhambenh+"&nvk_IdKbCls="+listID_in+"&idkhoa="+$.mkv.queryString("IdKhoa")+"#isPrint=1");
    window.open("../KhamBenh_TH/rptPhieuChiDinh.aspx?idkhambenh="+idkhambenh+"&nvk_IdKbCls="+listID_in+"&IsAll=1");
}
 // end In CLS & DV tùy chọn 
///              

/// CẬN LÂM SÀNG THƯỜNG QUY

 function ChoncanlamsangThuongquy(obj)
 {
   
    $(obj).TimKiem({
        ajax:"../ajax/nvk_khamTongHop_ajax.aspx?do=ChonclsThuongquy"
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
 
function setCSLThuongQuy(obj,idnhomTq,page)
 {
 $("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
 var form = $("#fielClSChiDinhMoi").find("#gridTablecls");
         var listIdCLS="";
         var slvack = "";
         for(var i=0;i<form.find("tr").length;i++)
            {
                var idcls = form.find("tr").eq(i).find("#idcanlamsan").val();
                var sl = form.find("tr").eq(i).find("#soluong").val();
                if(idcls > 0)
                {
                    slvack += "@"+idcls+"^"+sl;
                    listIdCLS += ""+idcls+",";
                }
            }
            
         if(idnhomTq == null) idnhomTq = "";
         if(page == null) page = "1";
            $.mkv.dongtimkiem('default');
         $.ajax({
            async:false,
             type:"GET",
             cache:false,
             url:"../ajax/nvk_khamTongHop_ajax.aspx?do=getListCSLThuongQuy&NhomId="+idnhomTq+"&page="+page + "&slvack=" + slvack,
              success: function (value){
                     listIdCLS += ""+value;
                     var idkhambenh = $(obj).closest("#thongtindichvu").find("#idKhamBenhMoiLuuDV").val();
                     AppendTableClsThuongQuy(obj,listIdCLS,idkhambenh,slvack);
                }
         });
 }
 function AppendTableClsThuongQuy(obj,listIdCLS,idkhambenh,slvack)
 {
    $.ajax({
                type:"GET",
                dataType:"text",
                url:"../ajax/nvk_khamTongHop_ajax.aspx?do=GetDSCLS&listID="+listIdCLS+"&IdBenhNhan="+$.mkv.queryString("idbenhnhan")+"&IdKhambenh="+idkhambenh+"&slvack="+slvack+"&loai=cls&LoaiBN="+$.mkv.queryString("LoaiBN"),
                success:function (data) {
                     $("#fielClSChiDinhMoi").find("#tableAjax_khambenhcanlamsan").html(data);
                     $("#loadingAjax").remove();
                }
           });
 }
 // END CẬN LÂM SÀNG THƯỜNG QUY