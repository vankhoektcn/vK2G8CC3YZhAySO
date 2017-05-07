
         $(document).ready(function() {
            phanquyen();
             $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"ajax/KTDM_DanhMucNghiepVU_ajax.aspx?do=luuTable",tablename:"gridTable"});
             });
             $("#timKiem").click(function () {
                    Find(this);
             });
         });
         function phanquyen()
         {
            if($("#quyenthem").val() == 'False' && $("#quyensua").val() == 'False')
                document.getElementById('luuTable_2').disabled=true;
            else
                document.getElementById('luuTable_2').disabled=false;
            
         }
         window.onload = function()
         {
            pageload();
         }
         function pageload()
         {
            //$(obj).unautocomplete().autocomplete("ajax/KTDM_DanhMucNghiepVu_ajax.aspx?do=testsoct&so_phieu="+obj.value,
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
                      $("#tableAjax_DMNghiepVu").html(value);
                         $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                }
            }
            xmlhttp.open("GET","ajax/KTDM_DanhMucNghiepVu_ajax.aspx?do=TimKiem&times="+Math.random(),true);
            xmlhttp.send(null);
         }
         function xoa(control){
              $(control).XoaRow({ajax:'ajax/KTDM_DanhMucNghiepVu_ajax.aspx?do=xoa'});
         }
          function Find(control,page) {
           if(page == null) page = "1";
              $(control).TimKiem({
                     ajax:"ajax/KTDM_DanhMucNghiepVu_ajax.aspx?do=TimKiem&page="+page
               },function (data) {
                         $("#tableAjax_DMNghiepVu").html(data);
                         $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
               },function () {
                     $("#tableAjax_DMNghiepVu").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
               });
              
         }
         function ShowTaiKhoan(obj)
        {
            $("#"+obj).unautocomplete().autocomplete("ajax/KTTSCD_PhieuNhapVT_ajax3.aspx?do=DanhSachTaiKhoan_Jquery",
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
            $(obj).unautocomplete().autocomplete("ajax/KTTSCD_PhieuNhapVT_ajax3.aspx?do=DanhSachTaiKhoan_Jquery&Key="+obj.value+"&obj="+obj.id,
                                                        {width:350,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                        function(event,data)
                        {
                            $("#tableAjax_DMNghiepVu").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[2]);
                        }
                        );           
             
        }
        function testsoct(obj)
        {
        
            //$(obj).unautocomplete().autocomplete("ajax/KTDM_DanhMucNghiepVu_ajax.aspx?do=testsoct&so_phieu="+obj.value,
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
                      if(value == '1')
                      {
                         $("#tableAjax_DMNghiepVu").find("tr").eq($(obj).parent().parent().index()).find("#SoCT_hientai").val("");
                         alert('Số chứng từ không hợp lệ');
                      }
                      if(value == '2')
                      {
                         $("#tableAjax_DMNghiepVu").find("tr").eq($(obj).parent().parent().index()).find("#SoCT_hientai").val("");
                         alert('Số chứng từ đã tồn tại');
                      }
                }
            }
            var manghiepvu=$("#tableAjax_DMNghiepVu").find("tr").eq($(obj).parent().parent().index()).find("#MaNghiepVu").val();
            var tiepdaungu=$("#tableAjax_DMNghiepVu").find("tr").eq($(obj).parent().parent().index()).find("#TiepDauNgu").val();
            xmlhttp.open("GET","ajax/KTDM_DanhMucNghiepVu_ajax.aspx?do=testsoct&so_phieu="+obj.value+"&manghiepvu="+manghiepvu+"&tiepdaungu="+tiepdaungu+"&times="+Math.random(),true);
            xmlhttp.send(null);
        }
        function testsoct1(obj)
        {
        
            //$(obj).unautocomplete().autocomplete("ajax/KTDM_DanhMucNghiepVu_ajax.aspx?do=testsoct&so_phieu="+obj.value,
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
                      if(value == '1')
                      {
                         $("#SoCT_hientai").val("");
                         alert('Số chứng từ không hợp lệ');
                      }                      
                }
            }
            xmlhttp.open("GET","ajax/KTDM_DanhMucNghiepVu_ajax.aspx?do=testsoct1&so_phieu="+obj.value+"&manghiepvu="+$("#SoCT_hientai").val()+"&times="+Math.random(),true);
            xmlhttp.send(null);
        }
        function SaveDMNV()
        {
            //$(obj).unautocomplete().autocomplete("ajax/KTDM_DanhMucNghiepVu_ajax.aspx?do=testsoct&so_phieu="+obj.value,
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
                      if(value == '0')
                      {
                         alert('Lưu thành công !')
                      }
                      if(value == '1')
                      {
                         alert('Lưu thất bại, bạn vui lòng kiểm tra lại thông tin !')
                      }
                      if(value == '2')
                      {
                         alert('Mã nghiệp vụ đã tồn tại !');
                      }
                }
            }
            var manghiepvu=$("#MaNghiepVu").val();
            var tennghiepvu=$("#TenNghiepVu").val();
            var diengiai=$("#DienGiai").val();
            var tiepdaungu=$("#TiepDauNgu").val();
            var soct_hientai=$("#SoCT_hientai").val();
            var tkno=$("#TKNo").val();
            var tkco=$("#TKCo").val();
            var tkthue=$("#TKThue").val();
            var tkck=$("#tkck").val();
            var vat=$("#VAT").val();
            
            xmlhttp.open("GET","ajax/KTDM_DanhMucNghiepVu_ajax.aspx?do=Save&manghiepvu="+manghiepvu+"&tennghiepvu="+tennghiepvu+"&diengiai="+diengiai+"&tiepdaungu="+tiepdaungu+"&soct_hientai="+soct_hientai+"&tkno="+tkno+"&tkco="+tkco+"&tkthue="+tkthue+"&tkck="+tkck+"&vat="+vat+"&times="+Math.random(),true);
            xmlhttp.send(null);
        }
        
