         $(document).ready(function() {
                 $.mkv.moveUpandDown("#tablefind");
                 setControlFind($.mkv.queryString("idkhoachinh"));
                 //alert($.mkv.queryString("idkhoachinh"));
                 if($.mkv.queryString("idkhoachinh") == "")
                    PageLoadNgoaiTe();
                 $("#luu").click(function () {
                    if($("#luu").val() == "Lưu")
                    {
                        $(this).Luu({
                         ajax:"ajax/phieuxuatkho_ajax3.aspx?do=Luu&txtthanhtien="+eval($("#txtthanhtien").val().replace(/\$|\,/g,''))
                          },null,function () {
                               document.getElementById("maphieuxuat").disabled=true;
                               $.LuuTable({
                                    ajax:"ajax/phieuxuatkho_ajax3.aspx?do=luuTablechitietphieuxuatkho&ma_ct="+ $("#maphieuxuat").val() +"&txttienthue="+ $("#txttienthue").val() +"&tigia="+ $("#tigia").val() +"&tkvat="+ $("#TKVAT").val() +"&tkno="+ $("#TKNo").val() +"&tknokhac="+ $("#TKNoKhac").val() +"&diengiai=" + $("#ghichu").val() + "&idphieuxuat=" + $.mkv.queryString("idkhoachinh"),
                                    tablename:"gridTable"
                                    },null,function(){                                    
                               $.ajax({                                       
                                    cache:false,
                                    url:"ajax/phieuxuatkho_ajax3.aspx?do=luuvasocai&ma_ct="+ $("#maphieuxuat").val()+"&ngaynhap="+$("#ngaythang").val() + "&tkvat="+ $("#TKVAT").val() +"&tkno="+ $("#TKNo").val() +"&tknokhac="+ $("#TKNoKhac").val() +"&diengiai=" + $("#ghichu").val() +"&makhachhang="+$("#makhachhang").val()+"&thuesuat="+$("#txtvat").val()+ "&idphieuxuat=" + $.mkv.queryString("idkhoachinh"),                                   
                                    success:function(data){                                                                       
                                    }
                                });
                               });
                          });
                          Find($(this));                                            
                    }
                    else
                    {
                        $(this).Luu({
                         ajax:"ajax/phieuxuatkho_ajax3.aspx?do=Luu&txtthanhtien="+eval($("#txtthanhtien").val().replace(/\$|\,/g,''))
                          },null,function () {
                               document.getElementById("maphieuxuat").disabled=true;
                               $.LuuTable({
                                    ajax:"ajax/phieuxuatkho_ajax3.aspx?do=luuTablechitietphieuxuatkho&ma_ct="+ $("#maphieuxuat").val() +"&txttienthue="+ $("#txttienthue").val() +"&tigia="+ $("#tigia").val() +"&tkvat="+ $("#TKVAT").val() +"&tkno="+ $("#TKNo").val() +"&tknokhac="+ $("#TKNoKhac").val() +"&diengiai=" + $("#ghichu").val() + "&idphieuxuat=" + $.mkv.queryString("idkhoachinh"),
                                    tablename:"gridTable"
                                    },null,function(){                                     
                               $.ajax({                                   
                                    cache:false,
                                    url:"ajax/phieuxuatkho_ajax3.aspx?do=luuvasocai&ma_ct="+ $("#maphieuxuat").val()+"&ngaynhap="+$("#ngaythang").val() + "&tkvat="+ $("#TKVAT").val() +"&tkno="+ $("#TKNo").val() +"&tknokhac="+ $("#TKNoKhac").val() +"&diengiai=" + $("#ghichu").val() +"&makhachhang="+$("#makhachhang").val()+"&thuesuat="+$("#txtvat").val()+ "&idphieuxuat=" + $.mkv.queryString("idkhoachinh"),
                                    success:function(data){                                        
                                    }
                                });
                               });
                          });
                    } 
                });
                $("#moi").click(function () {
                     $(this).Moi();                    
                     loadTableAjaxchitietphieuxuatkho('');
                     
                     if($("#mkv_ngoai_te_id").val() == "" || $("#tigia").val() == "")
                        PageLoadNgoaiTe();
                });
                $("#xoa").click(function () {
                   $(this).Xoa({
                         ajax:"ajax/phieuxuatkho_ajax3.aspx?do=xoa"
                    },null,function () {
                         loadTableAjaxchitietphieuxuatkho('');
                     });
                });
                $("#timKiem").click(function () {
                    Find($(this)); 
                 });
                 $("#chontoa").click(function () {
                    chontoathuoc($(this)); 
                 });
                 /////////
                 
         });
         window.onload = function()
         {
            //alert($("#tigia").val());
                 
         }
         function lammoi()
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
                    var data = value.split('|');
                    $("#ngoai_te_id").val(data[0]);
                    $("#mkv_ngoai_te_id").val(data[1]);
                    $("#tigia").val(data[2]);
                    var d = new Date();
                    //alert(d.getDate()+"/"+d.getMonth()+"/"+d.getFullYear());
                    $("#ngaythang").val(d.getDate()+"/"+d.getMonth()+"/"+d.getFullYear());
                }
            }
            xmlhttp.open("GET","ajax/phieuxuatkho_ajax3.aspx?do=lammoi&"+Math.random(),true);
            xmlhttp.send(null);
         }
         
         
         function chontoathuoc(control, page)
         {
            if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"ajax/phieuxuatkho_ajax3.aspx?do=chontoathuoc&page="+page
               });
         }
         //function setPhieu
         function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"ajax/phieuxuatkho_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
                     loadTableAjaxchitietphieuxuatkho($.mkv.queryString("idkhoachinh"));                    
                 });
              }
              else{
                loadTableAjaxchitietphieuxuatkho();
              }         
          }
          function Find(control,page) {
              if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"ajax/phieuxuatkho_ajax3.aspx?do=TimKiem&page="+page
               });
          }
         function xoaontable(control){
              $(control).XoaRow({
                 ajax:"ajax/phieuxuatkho_ajax3.aspx?do=xoachitietphieuxuatkho"
              });
         }
         function loadTableAjaxchitietphieuxuatkho(idkhoa,page)
         {  
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_chitietphieuxuatkho").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"ajax/phieuxuatkho_ajax3.aspx?do=loadTablechitietphieuxuatkho&idphieuxuat="+idkhoa+"&page="+page,
                  success: function (value){
                        document.getElementById("tableAjax_chitietphieuxuatkho").innerHTML=value;
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                        $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                        $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                        ////////////////////////
                        //alert($("#tableAjax_chitietphieuxuatkho").find("tr").eq(1).find("#txtma_kt").val())
//                        $("#maphieuxuat").val($("#tableAjax_chitietphieuxuatkho").find("tr").eq(1).find("#txtmaphieuxuat").val());
//                        $("#Ma_kt").val($("#tableAjax_chitietphieuxuatkho").find("tr").eq(1).find("#txtma_kt").val());
                        ////////////////////////
                        $("#txttongtientruocthue").val("0");
                        $("#txttienthue").val("0");
                        $("#txtthanhtien").val("0");
                        $("#txtchietkhau").val("0");
                        //////////////
                        var txttongtientruocthue = 0;
                        var txttienthue = 0;
                        var txttienchietkhau = 0;
                        var txtnguyente = 0;
                        var txtthanhtien = 0;
                        for(var i=1;i<document.getElementById("tableAjax_chitietphieuxuatkho").getElementsByTagName('table')[0].rows.length-1;i++)
                        {
                            txttongtientruocthue = eval(txttongtientruocthue) + eval($("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#soluong").val()) * eval($("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#dongia").val().replace(/\$|\,/g,''));
                            txttienthue = eval(txttienthue) + eval($("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#tienthue").val().replace(/\$|\,/g,''));
                            txttienchietkhau = eval(txttienchietkhau) + eval($("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#tienchietkhau").val().replace(/\$|\,/g,''));
                            txtnguyente = eval(txtnguyente) + eval($("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#nguyente").val().replace(/\$|\,/g,''));
                            txtthanhtien = eval(txtthanhtien) + eval($("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#thanhtien").val().replace(/\$|\,/g,''));
                        }
                        
                        $("#txttongtientruocthue").val(formatCurrency1(txttongtientruocthue));
                        $("#txttienthue").val(formatCurrency1(txttienthue));
                        $("#txtchietkhau").val(formatCurrency1(eval(txttienchietkhau)));
                        $("#txtthanhtien").val(formatCurrency1(txtnguyente));
                        $("#txtthanhtienquydoi").val(formatCurrency1(txtthanhtien));
                        $("#thanhtien").val(txtnguyente);              
                    }
             });
         }
         
         function timkiem_click()
         {
            //$("#timKiem").click(function () {
            //                Find($(this)); 
            //             });
         }
         
         function formatCurrency1(num){
            Number.prototype.formatMoney = function(c, d, t){
            var n = this, c = isNaN(c = Math.abs(c)) ? 2 : c, d = d == undefined ? "," : d, t = t == undefined ? "." : t, s = n < 0 ? "-" : "", i =  parseInt(n = Math.abs(+n || 0).toFixed(c)) + "", j = (j = i.length) > 3 ? j % 3 : 0;
               return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
             };
            return num.formatMoney(2,'.',',');
         }
         function loaivattuSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("ajax/phieuxuatkho_ajax3.aspx?do=loaivattuSearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#tableAjax_chitietphieuxuatkho").attr("id") != null){
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function loainghiepvuSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("ajax/phieuxuatkho_ajax3.aspx?do=loainghiepvuSearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#tableAjax_chitietphieuxuatkho").attr("id") != null){
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                     if(data[1] == "0")
                        $("#chontoa").hide();
                     else
                        $("#chontoa").show();
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         
         function vattuSearch(obj)
         {   
             //alert($("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#loaithuoc").val());
             $(obj).unautocomplete().autocomplete("ajax/phieuxuatkho_ajax3.aspx?do=vattuSearch&idloaivattu="+$("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#loaithuoc").val(),{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#tableAjax_chitietphieuxuatkho").attr("id") != null){
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                     //Load thông tin liên quan
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#ngayhethan").val(data[2]);
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#dvt").val(data[3]);
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#mkv_dvt").val(data[4]);
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#tkco").val(data[5]);
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#tkdoanhthu").val(data[6]);
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#tkgiavon").val(data[7]);
                     //alert(data);
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                     //Load thông tin liên quan
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#ngayhethan").val(data[2]);
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#dvt").val(data[3]);
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#mkv_dvt").val(data[4]);
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#tkco").val(data[5]);
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#tkdoanhthu").val(data[6]);
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#tkgiavon").val(data[7]);
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         
         function khoSearch(obj)
         {
             
             //alert($("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#loaithuoc").val());
             $(obj).unautocomplete().autocomplete("ajax/phieuxuatkho_ajax3.aspx?do=khoSearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#tableAjax_chitietphieuxuatkho").attr("id") != null){
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         
         
         function loadthuesuat()
         {
            var txttienthue=0;
            var txttongtien = 0;
            var txttongtientruocthue = 0;
            
            var thuesuat = $("#txtvat").val();
            
            for(var i=1;i<document.getElementById("tableAjax_chitietphieuxuatkho").getElementsByTagName('table')[0].rows.length-1;i++)
                {
                    $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#vat").val(thuesuat);
                    //Tính lại tiền trên lưới
                    var dongia=$("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#dongia").val().replace(/\$|\,/g,'');
                    var tigia = eval($("#tigia").val().replace(/\$|\,/g,''));
                    var soluong=$("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#soluong").val();
                    var vat = $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#vat").val();
                    var thanhtien = 0;
                    if(dongia != "" && tigia != "" && vat != "" && vat != "0")
                    {
                        $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#tienthue").val( formatCurrency1((soluong * dongia * vat)/100));
                        var tienthue = $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#tienthue").val().replace(/\$|\,/g,'');
                        $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#nguyente").val(formatCurrency1(dongia * soluong + 1 * tienthue));
                        //alert(dongia * soluong + 1 * tienthue);// * soluong + 1 * tienthue));
                        $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#thanhtien").val( formatCurrency1((dongia * soluong + 1 * tienthue) * tigia));
                    }
                    else
                    {
                        $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#nguyente").val( formatCurrency1(dongia * soluong));
                        $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#thanhtien").val( formatCurrency1(dongia * soluong * tigia));
                    }
                    //Tính tổng tiền
                    txttongtientruocthue = 1 * txttongtientruocthue + 1 * $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#soluong").val() * 1 * $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#dongia").val().replace(/\$|\,/g,'');
                    txttienthue = 1 * txttienthue + 1 * $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#tienthue").val().replace(/\$|\,/g,'');
                    txttongtien = 1 * txttongtien + 1 * $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#thanhtien").val().replace(/\$|\,/g,'');
                }
                $("#txttongtientruocthue").val(formatCurrency1(txttongtientruocthue));
                $("#txttienthue").val(formatCurrency1(txttienthue));
                txttongtien = 1 * txttongtientruocthue + 1 * txttienthue + 1 * $("#txtchietkhau").val().replace(/\$|\,/g,'');
                
                $("#txtthanhtien").val(formatCurrency1(txttongtien));
                $("#txtthanhtienquydoi").val(formatCurrency1(txttongtien * tigia));
                $("#thanhtien").val(1 * txttongtien);              
         }
         
         function tinhtien(obj)
         {
                var dongia = $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val().replace(/\$|\,/g,'');
                //var dongia1 = 1000000;
                //alert(dongia1.replace(/\$|\,/g,''););
                var tigia = eval($("#tigia").val().replace(/\$|\,/g,''));
                var soluong=$("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val();
                var vat = $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#vat").val();
                var chietkhau = $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#chietkhau").val();
                var tienchietkhau = $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#tienchietkhau").val();
                var thanhtien = 0;
                if(chietkhau != "")
                {
                    if(tienchietkhau == "")
                        tienchietkhau = 0;
                    tienchietkhau = eval(dongia) * eval(chietkhau) / 100;
                    $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#tienchietkhau").val(formatCurrency1(tienchietkhau));
                    //alert(tienchietkhau);
                }
                if(dongia != "" && tigia != "" && vat != "")
                {
                    $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#tienthue").val( formatCurrency1((soluong * dongia * vat)/100));
                    var tienthue = $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#tienthue").val().replace(/\$|\,/g,'');
                    $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#nguyente").val(formatCurrency1(eval(dongia) * eval(soluong) + eval(tienthue) - eval(tienchietkhau)));
                    $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val( formatCurrency1((eval(dongia) * eval(soluong) + eval(tienthue) - eval(tienchietkhau)) * eval(tigia)));
                    ////////////
                    
                }
                else
                {
                    $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#nguyente").val( formatCurrency1(dongia * soluong));
                    $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val( formatCurrency1(dongia * soluong * tigia));
                }
                ////////////////////////
                $("#txttongtientruocthue").val("0");
                $("#txttienthue").val("0");
                $("#txtthanhtien").val("0");
                $("#txtchietkhau").val("0");
                //////////////
                var txttongtientruocthue = 0;
                var txttienthue = 0;
                var txttienchietkhau = 0;
                var txtnguyente = 0;
                var txtthanhtien = 0;
                for(var i=1;i<document.getElementById("tableAjax_chitietphieuxuatkho").getElementsByTagName('table')[0].rows.length-1;i++)
                {
                    txttongtientruocthue = eval(txttongtientruocthue) + eval($("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#soluong").val()) * eval($("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#dongia").val().replace(/\$|\,/g,''));
                    txttienthue = eval(txttienthue) + eval($("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#tienthue").val().replace(/\$|\,/g,''));
                    txttienchietkhau = eval(txttienchietkhau) + eval($("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#tienchietkhau").val().replace(/\$|\,/g,''));
                    txtnguyente = eval(txtnguyente) + eval($("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#nguyente").val().replace(/\$|\,/g,''));
                    txtthanhtien = eval(txtthanhtien) + eval($("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#thanhtien").val().replace(/\$|\,/g,''));
                }
                     
                $("#txttongtientruocthue").val(formatCurrency1(txttongtientruocthue));
                $("#txttienthue").val(formatCurrency1(txttienthue));
                $("#txtchietkhau").val(formatCurrency1(eval(txttienchietkhau)));
                $("#txtthanhtien").val(formatCurrency1(txtnguyente));
                $("#txtthanhtienquydoi").val(formatCurrency1(txtthanhtien));
                $("#thanhtien").val(txtnguyente);              
                //////////////////
                $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val(formatCurrency1(1 * dongia));
         }
         
         function tinhchietkhau()
         {
            var tongtientruocthue = $("#txttongtientruocthue").val().replace(/\$|\,/g,'');
            var tienthue = $("#txttienthue").val().replace(/\$|\,/g,'');
            //
            var thanhtien = eval(tongtientruocthue) + eval(tienthue);
            var chietkhau = 0;
            if($("txtchietkhau").val() != "")
                chietkhau = $("#txtchietkhau").val().replace(/\$|\,/g,'');
            $("#txtthanhtien").val( formatCurrency1(eval(thanhtien) + eval(chietkhau)));
            //ngoại tệ
            var ty_gia = 1;
            if($("txtchietkhau").val() != "" && $("txtchietkhau").val() != "0")
                ty_gia = $("#tigia").val().replace(/\$|\,/g,'');
            $("#txtthanhtienquydoi").val( formatCurrency1((eval(thanhtien) + eval(chietkhau)) * ty_gia) );
            
            //alert(eval(thanhtien) +"'"+ eval(chietkhau) +","+ ty_gia)
         }
         
         function khachhangSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("ajax/phieuxuatkho_ajax3.aspx?do=khachhangSearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#tableAjax_chitietphieuxuatkho").attr("id") != null){
                     //$("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[3]);
                     if ($("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                     $("#IDKhachHang").val(data[3]);
                     //$("#mkv_idkhachhang").val(data[0]);
                     $("#makhachhang").val(data[1]);
                     $("#diachi").val(data[2]);                    
                 }else{
                     $("#IDKhachHang").val(data[3]);
                     //$("#mkv_idkhachhang").val(data[0]);
                     $("#makhachhang").val(data[1]);
                     $("#diachi").val(data[2]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function makhachhangSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("ajax/phieuxuatkho_ajax3.aspx?do=makhachhangSearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#tableAjax_chitietphieuxuatkho").attr("id") != null){
                     //$("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[3]);
                     if ($("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                     $("#IDKhachHang").val(data[3]);
                     //$("#mkv_idkhachhang").val(data[0]);
                     $("#mkv_IDKhachHang").val(data[1]);
                     $("#diachi").val(data[2]);                    
                 }else{
                     $("#IDKhachHang").val(data[3]);
                     //$("#mkv_idkhachhang").val(data[0]);
                     $("#mkv_IDKhachHang").val(data[1]);
                     $("#diachi").val(data[2]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function ngoaiteSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("ajax/phieuxuatkho_ajax3.aspx?do=ngoaiteSearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#tableAjax_chitietphieuxuatkho").attr("id") != null){
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                     //$("#tigia").val(formatCurrency1(data[2].substring(0,data[2].length-3)));
                     $("#tigia").val(data[2].substring(0,data[2].length-3));
                     //Load lại VNĐ
                     var tienthue=0;
                     var tongtien = 0;
                     var tigia = $("#tigia").val();
                     for(var i=1;i<document.getElementById("tableAjax_chitietphieuxuatkho").getElementsByTagName('table')[0].rows.length-1;i++)
                     {
                         var nguyente = $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#nguyente").val().replace(/\$|\,/g,'');
                         $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#thanhtien").val(formatCurrency1( nguyente * tigia ));
                         tongtien = 1 * tongtien + 1 * $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#thanhtien").val().replace(/\$|\,/g,'');
                     }
                     //alert(tongtien);
                     $("#txtthanhtienquydoi").val(formatCurrency1(tongtien));
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function nguoixuatSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("ajax/phieuxuatkho_ajax3.aspx?do=nguoixuatSearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#tableAjax_chitietphieuxuatkho").attr("id") != null){
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function donvitinhSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("ajax/phieuxuatkho_ajax3.aspx?do=donvitinhSearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#tableAjax_chitietphieuxuatkho").attr("id") != null){
                     $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function TestSoChungTu()
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
                          alert('Số chứng từ đã tồn tại')
                         $("#maphieuxuat").val('');
                      }
                }
            }
            xmlhttp.open("GET","ajax/phieuxuatkho_ajax3.aspx?do=TestSoChungTu&ma_ct="+$("#maphieuxuat").val()+"&times="+Math.random(),true);
            xmlhttp.send(null);
            
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
                         $("#ngoai_te_id").val(data[0]);
                         $("#mkv_ngoai_te_id").val(data[1]);
                         $("#tigia").val(data[2]);
                      }
                }
            }
            xmlhttp.open("GET","ajax/phieuxuatkho_ajax3.aspx?do=PageLoadNgoaiTe&times="+Math.random(),true);
            xmlhttp.send(null);
            
        }
         function ShowTaiKhoan(obj)
        {
            $("#"+obj).unautocomplete().autocomplete("ajax/phieuxuatkho_ajax3.aspx?do=DanhSachTaiKhoan_Jquery",
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
            //var objsrc = document.getElementById(obj.id);  
            $(obj).unautocomplete().autocomplete("ajax/phieuxuatkho_ajax3.aspx?do=DanhSachTaiKhoan_Jquery&Key="+obj.value+"&obj="+obj.id,
                                                        {width:350,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                        function(event,data)
                        {
                            $("#tableAjax_chitietphieuxuatkho").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[2]);
	                        
                        }
                        );           
             
        }
                 
