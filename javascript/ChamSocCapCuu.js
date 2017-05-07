         $(document).ready(function() {
                 $.mkv.moveUpandDown("#tablefind");
               setControlFind($.mkv.queryString("idkhoachinh"));
               loadTableAjaxDSkhambenh($.mkv.queryString("idkhambenhgoc"));
                 $("#luu").click(function () {
                   $(this).Luu({
                         ajax:"../ajax/khambenh_ajax3.aspx?do=Luu&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc")
                      },function () {
                            if($("#idbacsi").val() == "" || $("#idbacsi").val() == "0")
                            {
                                $.mkv.myerror("Chưa chọn bác sỹ.");
                                return false;
                            }else
                                return true;
                      },function () {
                           $.LuuTable({
                                 ajax:"../ajax/khambenh_ajax3.aspx?do=luuTablechitietbenhnhantoathuoc&idkhambenh=" + $.mkv.queryString("idkhoachinh")+"&idbenhnhan="+$("#idbenhnhan").val(),
                                 tablename:"gridTable"
                           },null,function () {
                                XuatKho();
                                $.LuuTable({
                                 ajax:"../ajax/khambenh_ajax3.aspx?do=luuTablekhambenhcanlamsan&idkhambenh=" + $.mkv.queryString("idkhoachinh")+"&idbenhnhan="+$("#idbenhnhan").val(),
                                 tablename:"gridTablecls"
                             });
                          
                          loadTableAjaxDSkhambenh($.mkv.queryString("idkhambenhgoc"));
                      });
                      
                      
                });
                $("#inkhong").click(function () { 
                
                //window.open("../khambenh/inchidinhLamsan.aspx?idkhambenh="+$.mkv.queryString("idkhoachinh"));
                
                });
                $("#incls").click(function () { 
                
                window.open("../khambenh/inchidinhLamsan.aspx?idkhambenh="+$.mkv.queryString("idkhoachinh"));
                
                });
                $("#ingiaychuyenvien").click(function () { 
                if ($("#huongdieutri").val()=='4'){
                               window.open("../khambenh/frmGiayChuyenVien.aspx?idbn="+$("#idbenhnhan").val());
                               }
                             });
                             
                
                
                });
                 $("#intoathuoc").click(function () {
	                        window.open("../khambenh/InDonThuoc.aspx?IdKhamBenh="+$.mkv.queryString("idkhoachinh"),'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');  
                });
                $("#moi").click(function () {
                     $(this).Moi();     
                     listCLS = "";               
                     loadTableAjaxchitietbenhnhantoathuoc('');
                     loadTableAjaxkhambenhcanlamsan('');
                });
                $("#xoa").click(function () {
                   $(this).Xoa({
                         ajax:"../ajax/khambenh_ajax3.aspx?do=xoa"
                    },null,function () {
                         listCLS = "";
                         loadTableAjaxDSkhambenh($.mkv.queryString("idkhambenhgoc"));
                         loadTableAjaxchitietbenhnhantoathuoc('');
                         loadTableAjaxkhambenhcanlamsan('');
                     });
                });
                $("#gridTable .down_select").live('hover',function(){
                    if($(this).val().length < 1)
                    {
                        layfirst = true;
                        
                        if($(this).attr("id") == "mkv_loaithuocid")
                            loaithuocidsearch($(this));
                        else if($(this).attr("id") == "mkv_doituongthuocid")
                            doituongthuocidsearch($(this));
                        else if($(this).attr("id") == "mkv_idkho")
                            idkhosearch($(this));
                            
                        layfirst = false;
                    }
                });
                $(".down_select_hover").live('hover',function(){
                    if($(this).val().length < 1)
                    {
                        layfirst = true;
                        if($(this).attr("id") == "mkv_huongdieutri")
                            huongdieutrisearch($(this));
                        layfirst = false;
                    }
                });
         });
         function XuatKho()
         {
            $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/khambenh_ajax3.aspx?do=xuatkho&idkhoachinh="+$.mkv.queryString("idkhoachinh")+"&idbenhnhan="+$("#idbenhnhan").val()+"&iddieuduong="+$("#IdDieuDuong").val()+"&ngaykham="+$("#ngaykham").val(),
                  success: function (value){
                        
                    }
             });
         }
           function setControlFind(idkhoatimkiem) {
                 $.BindFind({ajax:"../ajax/khambenh_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem+"&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc")},null,function () {
                        Setsauhuongdieutri();
                        loadTableAjaxchitietbenhnhantoathuoc($.mkv.queryString("idkhoachinh"));  
                        loadTableAjaxkhambenhcanlamsan($.mkv.queryString("idkhoachinh"));
                 });      
            }
         function xoaontable(control){
              $(control).XoaRow({
                 ajax:"../ajax/khambenh_ajax3.aspx?do=xoachitietbenhnhantoathuoc"
              });
         }
         function xoaontablecls(control){
              var valueCLS = $(control).parents("table").find("tr").eq($(control).parent().parent().index()).find("#idcanlamsan").val();
              $(control).XoaRow({
                 ajax:"../ajax/khambenh_ajax3.aspx?do=xoakhambenhcanlamsan"
              });
           
              (($(control).parent().parent().index() == -1) ? CheckXoaCLS(valueCLS):"");              
         }
         function loadTableAjaxchitietbenhnhantoathuoc(idkhoa,page)
         {
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_chitietbenhnhantoathuoc").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/khambenh_ajax3.aspx?do=loadTablechitietbenhnhantoathuoc&idkhambenh="+idkhoa+"&page="+page,
                  success: function (value){
                        $("#tableAjax_chitietbenhnhantoathuoc").html(value);
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                         
                    }
             });
         }
         function loadTableAjaxkhambenhcanlamsan(idkhoa,page)
         {
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_khambenhcanlamsan").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/khambenh_ajax3.aspx?do=loadTablekhambenhcanlamsan&idkhambenh="+idkhoa+"&page="+page,
                  success: function (value){
                         $("#tableAjax_khambenhcanlamsan").html(value);
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                         
                    }
             });
         }
         function loadTableAjaxDSkhambenh(idkhoa,page)
         {
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_DSkhambenh").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/khambenh_ajax3.aspx?do=loadTableAjaxDSkhambenh&idkhambenhgoc="+idkhoa+"&page="+page,
                  success: function (value){
                         $("#tableAjax_DSkhambenh").html(value);
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                    }
             });
         }
         function chandoanbandausearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=chandoanbandausearch&loaiicd="+$("#loaiicd").val(),{
             minChars:0,
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
         function loaithuocidsearch(obj)
         {
             $(obj).autocomplete("../ajax/khambenh_ajax3.aspx?do=loaithuocidsearch",{
             minChars:0,
             width:350,
             scroll:true,
             catche:false,
             addRow:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function doituongthuocidsearch(obj)
         {
             $(obj).autocomplete("../ajax/khambenh_ajax3.aspx?do=doituongthuocidsearch",{
             minChars:0,
             width:350,
             scroll:true,
             catche:false,
             addRow:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         
         function idkhosearch(obj)
         {
             $(obj).autocomplete("../ajax/khambenh_ajax3.aspx?do=idkhosearch_CapCuu&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc"),{
             minChars:0,
             width:350,
             addRow:true,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function huongdieutrisearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=huongdieutrisearch",{
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
					url: "../ajax/khambenh_ajax3.aspx?do=Loadsauhuongdieutri&huongdieutri="+$("#huongdieutri").val(),
					success: function(value) {
					    $("#loadsauhuongdieutri").html(value);
					}
             });
         }
         function Setsauhuongdieutri() {
             $.ajax({
                type: "GET",
					cache: false,
					dataType:"text",
					url: "../ajax/khambenh_ajax3.aspx?do=Setsauhuongdieutri&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc")+"&idkhoachinh="+$.mkv.queryString("idkhoachinh"),
					success: function(value) {
					    $("#loadsauhuongdieutri").html(value);
					}
             });
         }
         function ghichuhuongdieutriSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=ghichuhuongdieutriSearch",{
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
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=khoakhambenhSearch&huongdieutri="+huongdieutri,{
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
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=banggiadichvuSearch&khoakhambenh="+$("#khoakhambenh").val(),{
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
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=phongkhambenhSearch&banggiadichvu="+$("#idDVPhongChuyenDen").val()+"&idbenhnhan="+$("#idbenhnhan").val(),{
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
         function giuongsearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=giuongsearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                $(obj).val(data[1]);
                 $("#"+$(obj).attr("id").replace("mkv_","")).val(data[2]);
                 $("#giagiuong").val(data[3]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }

         function idthuocsearch(obj)
         {
            
             $(obj).autocomplete("../ajax/khambenh_ajax3.aspx?do=idthuocsearch&loaithuocid="+$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#loaithuocid").val()+"&idkho="+$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idkho").val(),{
             minChars:0,
             width:550,
             scroll:true,
             addRow:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                $(obj).val(data[4]);
                $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluongke").val("1");
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                 }
                 
                 setTimeout(function () {
                     obj.focus();
                 },100);
                 
             });
             
         }
         
         function idcanlamsansearch(obj)
         {
             $(obj).autocomplete("../ajax/khambenh_ajax3.aspx?do=idcanlamsansearch",{
             minChars:0,
             width:550,
             scroll:true,
             addRow:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                
                 if($(obj).parents("#gridTablecls").attr("id") != null){
                 
                     $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val("1");
                     $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val(data[2]);
                     $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").replace("mkv_","")).val(data[1]);
                     thanhtiencls(obj);
                     
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         
        function IdDieuDuongsearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=IdDieuDuongsearch",{
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
         function idbacsisearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax3.aspx?do=idbacsisearch&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc"),{
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
        function thanhtiencls(obj) {
                var tientruocck = eval($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val()) * eval($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val());
                var tienck = (eval(tientruocck)*eval($("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#chietkhau").val()))/100;
                $("#gridTablecls").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(tientruocck - tienck);
        }
        
        //  xu ly danh sach CLS
        var listCLS = "";
        function ChonCLS(obj,idnhom,idpkb)
        {
            listCLS = "";
            for(var i=1;i<$("#gridTablecls").find("tr").length;i++)
            {
                if($.trim($("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val()).length > 0 )
                    listCLS += $("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val()+",";
            }
            if(idpkb == null)
                idpkb = 0;
            $(obj).TimKiem({
                ajax:"../ajax/khambenh_ajax3.aspx?do=ChonCLS&listID="+listCLS+"&idpkb="+idpkb+"&IdBenhNhan="+$("#idbenhnhan").val(),readMKV:false
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
        $.mkv.runCloseTimKiem = function () {
         
            var slvack = "";
            for(var i=0;i<$("#gridTablecls").find("tr").length;i++){
                var idcls = $("#gridTablecls").find("tr").eq(i).find("#idcanlamsan").val();
                var sl = $("#gridTablecls").find("tr").eq(i).find("#soluong").val();
                var ck = $("#gridTablecls").find("tr").eq(i).find("#chietkhau").val();
                if(sl > 1 || ck > 0)
                    slvack += "@"+idcls+"^"+sl+"^"+ck;
                
            }
            var idkhambenh = "";
            if($.mkv.queryString("idkhoachinh") != "")
                idkhambenh = $.mkv.queryString("idkhoachinh");
            else
                idkhambenh = $.mkv.queryString("idkhambenhgoc");
                
            $("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
            $.ajax({
                type:"GET",
                dataType:"text",
                url:"../ajax/khambenh_ajax3.aspx?do=GetDSCLS&listID="+listCLS+"&IdBenhNhan="+$("#idbenhnhan").val()+"&IdKhambenh="+idkhambenh+"&slvack="+slvack,
                success:function (data) {
                     $("#tableAjax_khambenhcanlamsan").html(data);  
                     $("#loadingAjax").remove();
                }
            });
        }
        
        function ktrasltra(obj) {
            var slke = $(obj).parents("table").find("tr").eq($(obj).parent().parent().index()).find("#soluongke").val();
            if(slke == "")
                slke = 0;
                if(eval($(obj).val()) > eval(slke))
                     $(obj).val(slke);
        }