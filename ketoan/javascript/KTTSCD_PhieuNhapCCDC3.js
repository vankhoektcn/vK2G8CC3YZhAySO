         $(document).ready(function() {
                 $.mkv.moveUpandDown("#tablefind");
               setControlFind($.mkv.queryString("idkhoachinh"));
               if($.mkv.queryString("idkhoachinh") == "")
               {
                    PageLoadNgoaiTe();
                    $("#so_phieu").disable=true;
                    $("#ngay_nhap").focus();
               }
                 $("#luu").click(function () {
                   $(this).Luu({
                         ajax:"ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=Luu"
                      },null,function () {
                           $.LuuTable({
                                 ajax:"ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=luuTablePHIEU_NHAP_VT_CT&phieu_nhap_id=" + $.mkv.queryString("idkhoachinh") +"&so_phieu="+$("#so_phieu").val() + "&ngay_nhap="+$("#ngay_nhap").val() +"&ma_ncc="+$("#ma_ncc").val() + "&so_hd="+$("#so_hd").val() + "&ngay_lap_hd="+$("#ngay_lap_hd").val() + "&so_seri="+$("#so_seri").val() + "&tk_co="+$("#tk_co").val() + "&tkchietkhau="+$("#tkchietkhau").val() + "&tkvat="+$("#tkvat").val() + "&vat="+$("#vat").val() + "&dien_giai="+encodeURIComponent($("#dien_giai").val()),
                                 tablename:"gridTable"
                           });
                      });
                });
                $("#moi").click(function () {
                     $(this).Moi(); 
                      $("#so_phieu").disable=true;
                      $("#ngay_nhap").focus();                   
                     loadTableAjaxPHIEU_NHAP_VT_CT('');
                     PageLoadNgoaiTe();
                });
                $("#xoa").click(function () {
                   $(this).Xoa({
                         ajax:"ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=xoa"
                    },null,function () {
                         loadTableAjaxPHIEU_NHAP_VT_CT('');
                     });
                });
                $("#timKiem").click(function () {
                    Find($(this)); 
                 });
         });
           function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
                     loadTableAjaxPHIEU_NHAP_VT_CT($.mkv.queryString("idkhoachinh"));                    
                 });
              }else{loadTableAjaxPHIEU_NHAP_VT_CT();}         
            }
          function Find(control,page) {
              if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=TimKiem&page="+page
               ,keyCode:113                                
               },null,function(data){
                    if(data==null||data=="")
                    {
                        $.mkv.closeDivTimKiem();
                    }
               });
          }
         function xoaontable(control){
              $(control).XoaRow({
                 ajax:"ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=xoaPHIEU_NHAP_VT_CT"
              });
         }
         function loadTableAjaxPHIEU_NHAP_VT_CT(idkhoa,page)
         {
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_PHIEU_NHAP_VT_CT").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=loadTablePHIEU_NHAP_VT_CT&phieu_nhap_id="+idkhoa+"&page="+page,
                  success: function (value){
                         document.getElementById("tableAjax_PHIEU_NHAP_VT_CT").innerHTML=value;
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                         
                         tinhtongtien();
                    }
             });
         }
        function nhacungcapSearch(obj)
        {
             $(obj).unautocomplete().autocomplete("ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=nhacungcapSearch&mancc="+$("#mkv_ma_ncc").val(),{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[1];
             }}).result(function(event,data){
                 $("#ma_ncc").val(data[1]);
                 $("#mkv_ma_ncc").val(data[1]);
                 $("#ten_ncc").val(data[2]);
                 $("#diachi_ncc").val(data[3]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
        }
        function nhacungcapSearch1(obj)
        {
             $(obj).unautocomplete().autocomplete("ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=nhacungcapSearch&tenncc="+$("#ten_ncc").val(),{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[2];
             }}).result(function(event,data){
                 $("#ma_ncc").val(data[1]);
                 $("#mkv_ma_ncc").val(data[1]);
                 $("#ten_ncc").val(data[2]);
                 $("#diachi_ncc").val(data[3]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
        }
        function khoSearch(obj)
        {
            $("#"+obj).unautocomplete().autocomplete("ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=khoSearch",
                                                        {width:350,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    $("#idkho").val(data[0]);
                                                                    $("#mkv_idkho").val(data[1]);
                                                                }
                                                            );
        }
        function khoSearch1(obj)
        {
            $(obj).unautocomplete().autocomplete("ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=khoSearch&Key="+obj.value+"&obj="+obj.id,
                                                        {width:350,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                        function(event,data)
                        {
                            $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#idkho").val(data[0]);
                            $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idkho").val(data[1]);
	                        
                        }
                        );           
             
        }
        function ShowTaiKhoan(obj)
        {
            $("#"+obj).unautocomplete().autocomplete("ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=DanhSachTaiKhoan_Jquery",
                                                        {width:350,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    document.getElementById(obj).value=data[2];
                                                                }
                                                            );
        }
        function ShowTaiKhoan1(obj)
        {
            $(obj).unautocomplete().autocomplete("ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=DanhSachTaiKhoan_Jquery&Key="+obj.value+"&obj="+obj.id,
                                                        {width:350,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                        function(event,data)
                        {
                            $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[2]);
                        }
                        );           
             
        }
        function vattuSearch(obj)
        {
            $(obj).unautocomplete().autocomplete("ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=vattuSearch&Key="+obj.value+"&obj="+obj.id,
                                                        {width:350,scroll:true,formatItem:function(data)
                                                            {return data[0];}
                                                        }
                                                    ).result(
                        function(event,data)
                        {
                            var count = 0;
                            for(var i=1;i<$(obj).parent().parent().index();i++)
                            {
                                if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#ma_vt").val() == data[0])
                                {
                                    count++;                                
                                    break;
                                }
                            }
                            //alert(count);
                            if(count == 0)
                            {
                                $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#ma_vt").val(data[0]);
                                $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#ten_vt").val(data[1]);
                                if($("#idkho").val() != "")
                                    {
                                        $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#idkho").val($("#idkho").val());
                                        $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idkho").val($("#mkv_idkho").val());
                                    }
                                $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#tk_no").val(data[2]);
                                $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#dvt").val(data[3]);
                                if($("#vat").val() != "")
                                    {
                                        $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#thue_suat").val($("#vat").val());
                                    }
                                $.mkv.themDongTable("gridTable");
                            }
                            else
                            {
                                $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#ma_vt").val("");
                                alert("Tài sản này đã được chọn !");
                            }
                        }
                        );           
                        
             
        }
        
        function vattuSearch1(obj)
        {
            $(obj).unautocomplete().autocomplete("ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=vattuSearch&Key="+obj.value+"&obj="+obj.id,
                                                        {width:350,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                        function(event,data)
                        {
                            var count = 0;
                            for(var i=1;i<$(obj).parent().parent().index();i++)
                            {
                                if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#ma_vt").val() == data[0])
                                {
                                    count++;                                
                                    break;
                                }
                            }
                            //alert(count);
                            if(count == 0)
                            {
                                $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#ma_vt").val(data[0]);
                                $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#ten_vt").val(data[1]);
                                if($("#idkho").val() != "")
                                    {
                                        $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#idkho").val($("#idkho").val());
                                        $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idkho").val($("#mkv_idkho").val());
                                    }
                                $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#tk_no").val(data[2]);
                                $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#dvt").val(data[3]);
                                if($("#vat").val() != "")
                                    {
                                        $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#thue_suat").val($("#vat").val());
                                    }
                                $.mkv.themDongTable("gridTable");
                            }
                            else
                            {
                                $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#ten_vt").val("");
                                alert("Tài sản này đã được chọn !");
                            }
                        }
                        );           
                        
             
        }
        function PageLoadNgoaiTe()
         {
            var xmlhttp;
            if (window.XMLHttpRequest)
            {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp=new XMLHttpRequest();
            }
            else
            {// code for IE6, IE5
                xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function()
            {
                if(xmlhttp.readyState == 4)
                {
                    var value = xmlhttp.responseText;
                    //alert(value);
                      if(value != 'true')
                      {
                        var data = value.split('|');
                         $("#loai_nt").val(data[0]);
                         $("#mkv_loai_nt").val(data[1]);
                         $("#ty_gia").val(data[2]);
                      }
                }
            }
            xmlhttp.open("GET","ajax/phieuxuatkho_ajax3.aspx?do=PageLoadNgoaiTe&times="+Math.random(),true);
            xmlhttp.send(null);
            
        }
        function ngoaiteSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=ngoaiteSearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[1];
             }}).result(function(event,data){
                 var ty_gia_cu = $("#ty_gia").val();
                 $("#loai_nt").val(data[0]);
                 $("#mkv_loai_nt").val(data[1]);
                 $("#ty_gia").val(data[2]);
                 //Tính lại tiền
                 var ty_gia = 1;
                 if($("#ty_gia").val() != "")
                    ty_gia = $("#ty_gia").val();
                    
                 for(var i=1;i<document.getElementById("tableAjax_PHIEU_NHAP_VT_CT").getElementsByTagName('table')[0].rows.length;i++)
                 {
                    var thanhtien = 0;
                    var tienphi = 0;
                    var tienthue = 0;
                    var tienchietkhau = 0;
                    var tongtien = 0;
                    if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#thanh_tien").val() != "")
                        thanhtien = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#thanh_tien").val().replace(/\$|\,/g,'');
                    if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tien_thue").val() != "")
                        tienthue = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tien_thue").val().replace(/\$|\,/g,'');
                    if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tien_phi").val() != "")
                        tienphi = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tien_phi").val().replace(/\$|\,/g,'');
                    if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tienchietkhau").val() != "")
                        tienchietkhau = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tienchietkhau").val().replace(/\$|\,/g,'');
                    if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tong_tien").val() != "")
                        tongtien = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tong_tien").val().replace(/\$|\,/g,'');
                        
                    $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#thanh_tien").val( formatCurrency1( (eval(thanhtien) / eval(ty_gia_cu)) * eval(ty_gia) ));
                    $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tien_thue").val( formatCurrency1( (eval(tienthue) / eval(ty_gia_cu)) * eval(ty_gia) ));
                    $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tien_phi").val( formatCurrency1( (eval(tienphi) / eval(ty_gia_cu)) * eval(ty_gia) ));
                    $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tienchietkhau").val( formatCurrency1( (eval(tienchietkhau) / eval(ty_gia_cu)) * eval(ty_gia) ));
                    $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tong_tien").val( formatCurrency1( (eval(tongtien) / eval(ty_gia_cu)) * eval(ty_gia) ));                    
                    
                    
                    tinhtongtien();
                 }
                 ////////////////
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function loaiphiSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=loaiphiSearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[1];
             }}).result(function(event,data){
                 $("#id_loaiphi").val(data[0]);
                 $("#mkv_id_loaiphi").val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function loainghiepvuSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("ajax/KTTSCD_PhieuNhapCCDC_ajax3.aspx?do=loainghiepvuSearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[1];
             }}).result(function(event,data){
                 $("#manghiepvu").val(data[0]);
                 $("#mkv_manghiepvu").val(data[1]);
                 $("#tk_co").val(data[2]);
                 $("#tkchietkhau").val(data[3]);
                 $("#tkvat").val(data[4]);
                 $("#vat").val(data[5]);
                 //alert(data[5]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function tinhphi()
         {
            var ty_gia = "0";
            if($("#ty_gia").val() != "")
                ty_gia = $("#ty_gia").val();
            var phi = 0
            if($("#tongphi").val() != "")
                phi = $("#tongphi").val().replace(/\$|\,/g,'');
            if($("#mkv_id_loaiphi").val() == 'Lượng')
            {
                //alert('luong');
                var tongsoluong = 0;   
                for(var i=1;i<document.getElementById("tableAjax_PHIEU_NHAP_VT_CT").getElementsByTagName('table')[0].rows.length-1;i++)
                {
                    var soluong = 0;
                    if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#so_luong").val() != "")
                        tongsoluong = eval(tongsoluong) + eval($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#so_luong").val());     
                        
                }
                for(var i=1;i<document.getElementById("tableAjax_PHIEU_NHAP_VT_CT").getElementsByTagName('table')[0].rows.length-1;i++)
                {
                    var soluong = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#so_luong").val();     
                    var thanhtienphi = (soluong * phi / tongsoluong) * ty_gia;
                    //alert(soluong+","+phi+","+tongsoluong+","+ty_gia);
                    $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tien_phi").val(formatCurrency1(thanhtienphi));
                    //alert(soluong+","+phi+","+tongsoluong);
                }
            }
            if($("#mkv_id_loaiphi").val() == 'Trị')
            {
                //alert('tri');
                for(var i=1;i<document.getElementById("tableAjax_PHIEU_NHAP_VT_CT").getElementsByTagName('table')[0].rows.length-1;i++)
                {
                    var thanhtien = 0;
                    var tongtien = 0;
                    var thanhtienphi = 0;
                    
                    //alert($("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tongtien").val());
                    if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tong_tien").val() != "")
                        thanhtien = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tong_tien").val().replace(/\$|\,/g,'');     
                    if($("#txtthanhtien").val() != "")
                        tongtien = $("#txtthanhtien").val().replace(/\$|\,/g,'');
                    thanhtienphi = ( (thanhtien *phi / tongtien) * ty_gia);
                    //alert(thanhtien +","+phi+","+tongtien+","+ty_gia);
                    $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tien_phi").val(formatCurrency1(eval(thanhtienphi)));
                    //$("#txtPhi").val(formatCurrency1(phi));
                }   
            }
            $("#txtPhi").val(formatCurrency1(eval(phi)));
         }
         function formatCurrency1(num){
            Number.prototype.formatMoney = function(c, d, t){
            var n = this, c = isNaN(c = Math.abs(c)) ? 2 : c, d = d == undefined ? "," : d, t = t == undefined ? "." : t, s = n < 0 ? "-" : "", i =  parseInt(n = Math.abs(+n || 0).toFixed(c)) + "", j = (j = i.length) > 3 ? j % 3 : 0;
               return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
             };
            return num.formatMoney(2,'.',',');
         }
        
        function tinhtongtien()
        {
            var txttongtientruocthue = 0;
            var txttienthue = 0;
            var txttienchietkhau = 0;
            var txtthanhtien = 0;
            for(var i=1;i<document.getElementById("tableAjax_PHIEU_NHAP_VT_CT").getElementsByTagName('table')[0].rows.length-1;i++)
            {
                    //tongtientruocthue = 1 * tongtientruocthue + 1 * $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#soluong").val() * $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#dongia").val();
                    var soluong = 0;
                    var dongia = 0;
                    var tienchietkhau = 0;
                    var tienthue = 0;
                    var thanhtien = 0;
                    var thanhtienquydoi = 0;
                    var ty_gia = 1;
                    if($("#ty_gia") != "")
                        ty_gia = $("#ty_gia").val();
                    if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#so_luong").val() != "")
                        soluong = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#so_luong").val().replace(/\$|\,/g,'');
                    if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#don_gia").val() != "")
                        dongia = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#don_gia").val().replace(/\$|\,/g,'');
                    if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tienchietkhau").val() != "")
                        tienchietkhau = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tienchietkhau").val().replace(/\$|\,/g,'');
                    if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tien_thue").val() != "")
                        tienthue = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tien_thue").val().replace(/\$|\,/g,'');
                    if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tong_tien").val() != "")
                        thanhtien = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq(i).find("#tong_tien").val().replace(/\$|\,/g,'');
                    txttongtientruocthue = eval(txttongtientruocthue) + (eval(soluong) * eval(dongia) * eval(ty_gia) - eval(tienchietkhau));
                    txttienthue = eval(txttienthue) + eval(tienthue);
                    txttienchietkhau = eval(txttienchietkhau) + eval(tienchietkhau);
                    txtthanhtien = eval(txtthanhtien) + eval(thanhtien);
                    
            }
            $("#txttongtientruocthue").val(formatCurrency1(txttongtientruocthue));
            $("#txttienthue").val(formatCurrency1(txttienthue));
            $("#txtchietkhau").val(formatCurrency1(txttienchietkhau));
            $("#txtthanhtien").val(formatCurrency1(txtthanhtien));
        }
        function tinhtien(obj)
        {
            //alert('1,000.00'.replace(/\$|\,/g,''));
            var soluong = 0;
            var dongia = 0;
            var thuesuat = 0;
            var chietkhau = 0;
            var tienthue = 0;
            var tienchietkhau = 0;
            var tongtien = 0;
            var ty_gia = 1;
            if($("#ty_gia").val() != "")
                ty_gia = $("#ty_gia").val();
            //alert($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#don_gia").val());
            if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#so_luong").val() != "")      
                soluong = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#so_luong").val();
            //alert($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#don_gia").val());
            if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#don_gia").val() != "")      
                dongia = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#don_gia").val().replace(/\$|\,/g,'');
            if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#thue_suat").val() != "")      
                thuesuat = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#thue_suat").val();
            if($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#chietkhau").val() != "")      
                chietkhau = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#chietkhau").val();
            
            //Tính thuế, chiết khấu
            $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#tienchietkhau").val( formatCurrency1( (eval(soluong) * eval(dongia) * eval(ty_gia) * eval(chietkhau)/100) ) );
            tienchietkhau = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#tienchietkhau").val().replace(/\$|\,/g,'');
            $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#thanh_tien").val( formatCurrency1( eval(soluong) * eval(dongia) * eval(ty_gia) - eval(tienchietkhau) ) );
            $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#tien_thue").val(formatCurrency1( ((eval(soluong) * eval(dongia) * eval(ty_gia) - eval(tienchietkhau)) * eval(thuesuat)/100) ));
            tienthue = $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#tien_thue").val().replace(/\$|\,/g,'');
            tongtien = eval(soluong) * eval(dongia) - eval(tienchietkhau) + eval(tienthue);
            //Tính tiền cho tiền phí, tiền thuế, tiền chiết khấu
            //viết hàm riêng cho nó
            $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#don_gia").val( formatCurrency1(eval(dongia)) );
            $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#tong_tien").val( formatCurrency1(tongtien) );
            ////////////////
            tinhphi();
            tinhtongtien();
        }
        function laphieuchi()
       {
           window.open("KTTM_PhieuChiKhac.aspx");
       }
       function inphieunhap()
       {
            window.open("KTTSCD_rptInPhieuNhap.aspx?so_phieu_nhap="+$("#so_phieu").val() +"&ngay_nhap="+$("#ngay_nhap").val());
            //alert("chưa có mẫu in");
       }