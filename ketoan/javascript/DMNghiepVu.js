
         $(document).ready(function() {
            phanquyen();
             $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"../ketoan/ajax/DMNghiepVu_ajax.aspx?do=luuTable",tablename:"gridTable"});
             });
             $("#timKiem").click(function () {
                    Find(this);
             });
             Find($("#timKiem"));
         });
         function phanquyen()
         {
            if($("#quyenthem").val() == 'False')
                document.getElementById('luuTable_2').disabled=true;
            else
                document.getElementById('luuTable_2').disabled=false;
            
         }
         function xoa(control){
              $(control).XoaRow({ajax:'../ketoan/ajax/DMNghiepVu_ajax.aspx?do=xoa'});
         }
          function Find(control,page) {
           if(page == null) page = "1";
              $(control).TimKiem({
                     ajax:"../ketoan/ajax/DMNghiepVu_ajax.aspx?do=TimKiem&page="+page
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
        function ShowTaiKhoan1(obj)
        {
            //var objsrc = document.getElementById(obj.id);  
            $(obj).unautocomplete().autocomplete("XuLyPara.aspx?do=DanhSachTaiKhoan_Jquery&Key="+obj.value+"&obj="+obj.id,
                                                        {width:350,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                        function(event,data)
                        {
	                        $("#tableAjax_DMNghiepVu").find("tr").eq($(obj).parent().parent().index()).find("#TKNo").val(data[2]);
                        }
                        );           
             
        }
        function ShowTaiKhoan2(obj)
        {
            //var objsrc = document.getElementById(obj.id);  
            $(obj).unautocomplete().autocomplete("XuLyPara.aspx?do=DanhSachTaiKhoan_Jquery&Key="+obj.value+"&obj="+obj.id,
                                                        {width:350,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                        function(event,data)
                        {
	                        $("#tableAjax_DMNghiepVu").find("tr").eq($(obj).parent().parent().index()).find("#TKCo").val(data[2]);
                        }
                        );           
             
        }
        function ShowTaiKhoan3(obj)
        {
            //var objsrc = document.getElementById(obj.id);  
            $(obj).unautocomplete().autocomplete("XuLyPara.aspx?do=DanhSachTaiKhoan_Jquery&Key="+obj.value+"&obj="+obj.id,
                                                        {width:350,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                        function(event,data)
                        {
	                        $("#tableAjax_DMNghiepVu").find("tr").eq($(obj).parent().parent().index()).find("#TKThue").val(data[2]);
                        }
                        );           
             
        }
         
