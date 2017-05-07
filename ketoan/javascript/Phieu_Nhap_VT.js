         $(document).ready(function() {
                 $.mkv.moveUpandDown("#tablefind");
               setControlFind($.mkv.queryString("idkhoachinh"));
                 $("#luu").click(function () {
                   $(this).Luu({
                         ajax:"../ketoan/ajax/PHIEU_NHAP_VT_ajax.aspx?do=Luu"
                      },null,function () {
                           $.LuuTable({
                                 ajax:"../ketoan/ajax/PHIEU_NHAP_VT_ajax.aspx?do=luuTablePHIEU_NHAP_VT_CT&phieu_nhap_id=" + $.mkv.queryString("idkhoachinh"),
                                 tablename:"gridTable"
                           });
                      });
                });
                $("#moi").click(function () {
                     $(this).Moi();                    
                     loadTableAjaxPHIEU_NHAP_VT_CT('');
                });
                $("#xoa").click(function () {
                   $(this).Xoa({
                         ajax:"../ketoan/ajax/PHIEU_NHAP_VT_ajax.aspx?do=xoa"
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
                 $.BindFind({ajax:"../ketoan/ajax/PHIEU_NHAP_VT_ajax.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
                     loadTableAjaxPHIEU_NHAP_VT_CT($.mkv.queryString("idkhoachinh"));                    
                 });
              }else{loadTableAjaxPHIEU_NHAP_VT_CT();}         
            }
          function Find(control,page) {
              if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"../ketoan/ajax/PHIEU_NHAP_VT_ajax.aspx?do=TimKiem&page="+page
               });
          }
         function xoaontable(control){
              $(control).XoaRow({
                 ajax:"../ketoan/ajax/PHIEU_NHAP_VT_ajax.aspx?do=xoaPHIEU_NHAP_VT_CT"
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
                 url:"../ketoan/ajax/PHIEU_NHAP_VT_ajax.aspx?do=loadTablePHIEU_NHAP_VT_CT&phieu_nhap_id="+idkhoa+"&page="+page,
                  success: function (value){
                         document.getElementById("tableAjax_PHIEU_NHAP_VT_CT").innerHTML=value;
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                    }
             });
         }
        function XuLyMaPhieu(obj)
        {
       
                var objsrc = document.getElementById(obj);
              
                    $("#"+obj).unautocomplete().autocomplete("../ketoan/PHIEU_NHAP_VT_ajax.aspx?do=LoadXuLyMaVT&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                                {width:300,scroll:true,formatItem:function(data)
                                                                    {return data[1];}
                                                                }
                                                            ).result(
                                                                        function(event,data)
                                                                        {;
                                                                            setChonMaVatTu(data[4]);
                                                                        }
                                                                    );     
        }

        function setChonMaVatTu(MaVT)
        { 
              var SophieuCT=document.getElementById('so_phieu');  
              so_phieu.value = MaVT;  
             
              document.getElementById('so_phieu').focus();
              
        }
        function ShowNhaCungCap(obj)
        {
                var objsrc = document.getElementById(obj);
              
                    $("#"+obj).unautocomplete().autocomplete("../ketoan/XuLyPara.aspx?do=LoadDanhSachNhaCungCap&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                                {width:300,scroll:true,formatItem:function(data)
                                                                    {return data[1];}
                                                                }
                                                            ).result(
                                                                        function(event,data)
                                                                        {
                                                                            setChonNCC(data[2],data[3],data[4],data[5],data[6]);
                                                                            //document.getElementById(obj).blur();
                                                                        }
                                                                    );     
        }

        function setChonNCC(idNCC,MaNCC,TenNCC,DC,MST)
        { 
              //var masothue=document.getElementById('masothue');
              // var diachi=document.getElementById('diachi');
              //var nhacungcapid=document.getElementById('nhacungcapid');
              var txtTenNCC=document.getElementById('txtTenNCC');
              var ma_ncc=document.getElementById('ma_ncc'); 
              //var tennhacungcap = document.getElementById('tennhacungcap'); 
                  
              //masothue.value = MST;
              //diachi.value = DC;
              //nhacungcapid.value=idNCC;
              txtTenNCC.value = TenNCC;
              //tennhacungcap.value = TenNCC;
              ma_ncc.value = MaNCC;
              
              
              //alert(hd_IDBN.value);
              document.getElementById('txtTenNCC').focus();
        }
        function ShowTaiKhoan(obj)
        {
             var objsrc = document.getElementById(obj);  
            $("#"+obj).unautocomplete().autocomplete("../ketoan/XuLyPara.aspx?do=DanhSachTaiKhoan_Jquery&Key="+objsrc.value+"&obj="+obj,
                                                        {width:350,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    setChonTaiKhoan(data[2],obj);
                                                                   // document.getElementById(obj).blur();
                                                                }
                                                            );                                                          
        }
        function setChonTaiKhoan(MaTaiKhoan,obj)
        {           
           var tkco = document.getElementById(obj);
           tkco.value=MaTaiKhoan;
        }
        function GetTaiKhoan(obj)
        {
             var objsrc = document.getElementById(obj);  
            $("#"+obj).unautocomplete().autocomplete("../ketoan/ajax/PHIEU_NHAP_VT_ajax.aspx?do=ShowTaiKhoan",
                                                        {             minChars:0,
             width:150,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[2];
             }}).result(function(event,data){
                 if($(obj).parents("#tableAjax_PHIEU_NHAP_VT_CT").attr("TaiKhoan") != null){
                     $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[2]);
                     if ($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);
                     $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#tk_no").val(data[1]);  
                     data1 = null;                  
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });                                                       
        }
         function ShowVatTu(obj)
         {
             var data1;
             $(obj).unautocomplete().autocomplete("../ketoan/ajax/PHIEU_NHAP_VT_ajax.aspx?do=ShowVatTu",{
             minChars:0,
             width:150,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[2];
             }}).result(function(event,data){
                 if($(obj).parents("#tableAjax_PHIEU_NHAP_VT_CT").attr("danhmuc_vattu_id") != null){
                     $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[2]);
                     $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#ma_vt").val(data[1]);
                     if ($("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[2]); 
                     $("#tableAjax_PHIEU_NHAP_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#ma_vt").val(data[1]); 
                     data1 = null;                  
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
