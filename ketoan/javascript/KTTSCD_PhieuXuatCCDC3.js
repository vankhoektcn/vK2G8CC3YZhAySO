         $(document).ready(function() {
                 $("#so_phieu").disable=true;
                 $("#ngay_xuat").focus();
                 $.mkv.moveUpandDown("#tablefind");
               setControlFind($.mkv.queryString("idkhoachinh"));
                 $("#luu").click(function () {
                   $(this).Luu({
                         ajax:"ajax/KTTSCD_PhieuXuatCCDC_ajax3.aspx?do=Luu&nguoi_nhan="+encodeURIComponent($("#ten_nguoi_nhan").val())
                      },null,function () {
                           $.LuuTable({
                                 ajax:"ajax/KTTSCD_PhieuXuatCCDC_ajax3.aspx?do=luuTablePHIEU_XUAT_VT_CT&ngay_xuat="+$("#ngay_xuat").val()+"&phieu_xuat_id=" + $.mkv.queryString("idkhoachinh"),
                                 tablename:"gridTable"
                           });
                      });
                });
                $("#moi").click(function () {
                     $(this).Moi(); 
                     $("#so_phieu").disable=true;
                     $("#ngay_xuat").focus();                   
                     loadTableAjaxPHIEU_XUAT_VT_CT('');
                });
                $("#xoa").click(function () {
                    $(this).Xoa({
                         ajax:"ajax/KTTSCD_PhieuXuatCCDC_ajax3.aspx?do=xoa"
                    },null,function () {
                         loadTableAjaxPHIEU_XUAT_VT_CT('');
                     });
                });
                $("#timKiem").click(function () {
                    Find($(this)); 
                 });
         });
           function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"ajax/KTTSCD_PhieuXuatCCDC_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
                     loadTableAjaxPHIEU_XUAT_VT_CT($.mkv.queryString("idkhoachinh"));                    
                 });
              }else{loadTableAjaxPHIEU_XUAT_VT_CT();}         
            }
          function Find(control,page) {
              if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"ajax/KTTSCD_PhieuXuatCCDC_ajax3.aspx?do=TimKiem&page="+page
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
                 ajax:"ajax/KTTSCD_PhieuXuatCCDC_ajax3.aspx?do=xoaPHIEU_XUAT_VT_CT"
              });
         }
         function loadTableAjaxPHIEU_XUAT_VT_CT(idkhoa,page)
         {
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_PHIEU_XUAT_VT_CT").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"ajax/KTTSCD_PhieuXuatCCDC_ajax3.aspx?do=loadTablePHIEU_XUAT_VT_CT&phieu_xuat_id="+idkhoa+"&page="+page,
                  success: function (value){
                         document.getElementById("tableAjax_PHIEU_XUAT_VT_CT").innerHTML=value;
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                         
                         tinhtongtien();
                    }
             });
         }
         function phongSearch(obj)
         {
            $(obj).unautocomplete().autocomplete("ajax/KTTSCD_PhieuXuatCCDC_ajax3.aspx?do=phongSearch&Key="+obj.value,{
             minChars:0,
             width:150,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[1];
             }}).result(function(event,data){
                 $("#ma_phong").val(data[1]);
                 $("#ten_phong").val(data[2]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function phongSearch1(obj)
         {
            $(obj).unautocomplete().autocomplete("ajax/KTTSCD_PhieuXuatCCDC_ajax3.aspx?do=phongSearch&Key="+obj.value,{
             minChars:0,
             width:150,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[2];
             }}).result(function(event,data){
                 $("#ma_phong").val(data[1]);
                 $("#ten_phong").val(data[2]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function testsoluong(obj)
         {
            if(obj.value != "")
            {
                var soluonghienco = 0;
                var soluong = 0;
                if($("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#soluong_hienco").val() != "")
                    soluonghienco = $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#soluong_hienco").val();
                if($("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#so_luong").val() != "")
                    soluong = $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#so_luong").val();
                if( eval(soluong) > eval(soluonghienco) )
                {
                    alert("Số lượng không được đáp ứng đủ !");
                    $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#so_luong").val("0");
                }
            }
         }
         function vattuSearch(obj)
         {
            $(obj).unautocomplete().autocomplete("ajax/KTTSCD_PhieuXuatCCDC_ajax3.aspx?do=vattuSearch&Key="+obj.value+"&obj="+obj.id,
                                                        {width:890,scroll:true,header:
                                                        "<div style=\"background-color:#5593DE;height:30px; color:White;font-weight: bold\">"
                         + "<div style=\"width: 90px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Mã CCDC</div>"
                         + "<div style=\"width: 200px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Tên CCDC</div>"
                         + "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Số phiếu</div>"
                         + "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Ngày nhập</div>"
                         + "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">SL hiện có</div>"
                         + "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Nguyên giá</div>"
                         + "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Tên kho</div>"
                         + "</div>",formatItem:function(data)
                                                            {return data[0];}
                                                        }
                                                    ).result(
                        function(event,data)
                        {
                            var count = 0;
                            for(var i=1;i<$(obj).parent().parent().index();i++)
                            {
                                //alert(data[1]+","+data[12]);
                                //alert($("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq(i).find("#so_phieu").val());
                                
                                if($("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq(i).find("#ma_vt").val() == data[1]
                                    && $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq(i).find("#so_phieu").val() == data[12])
                                {
                                    count++;
                                    break;
                                }
                            }
                            //alert(count);
                            if(count == 0)
                            {
                                $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#ma_vt").val(data[1]);
                                $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#ten_vt").val(data[2]);
                                $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#tk_ccdc").val(data[6]);
                                $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#tk_chi_phi").val(data[7]);
                                $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#tk_phan_bo").val(data[8]);
                                $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#idkho").val(data[9]);
                                $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idkho").val(data[10]);
                                $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#phieu_nhap_ct_id").val(data[11]);
                                $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#so_phieu").val(data[12]);
                                $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#soluong_hienco").val(data[13]);
                                //alert(data[5]);
                                $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#don_gia").val( formatCurrency1(eval(data[5])) );
	                            //alert(data[0])
	                            $.mkv.themDongTable("gridTable");
	                         }
	                         else
	                         {
	                            $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#ma_vt").val("");
                                alert("CCDC này đã được chọn !");
	                         }
                        }
                        );           
             
         }
         function tinhtien(obj)
         {
            var soluong = 0;
            var dongia = 0;
            var tongtien = 0;
            if($("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#so_luong").val() != "")
                soluong = $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#so_luong").val().replace(/\$|\,/g,'');
            if($("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#don_gia").val() != "")
                dongia = $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#don_gia").val().replace(/\$|\,/g,'');
            tongtien = eval(soluong) * eval(dongia)
            $("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq($(obj).parent().parent().index()).find("#tong_tien").val( formatCurrency1(tongtien) );
            //alert(tongtien);
            tinhtongtien();
         }
         function tinhtongtien()
         {
            var txttongtien = 0;
            var test="";
            for(var i=1;i<document.getElementById("tableAjax_PHIEU_XUAT_VT_CT").getElementsByTagName('table')[0].rows.length-1;i++)
            {
               //test+="|"+$("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq(i).find("#tong_tien").val();
               if($("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq(i).find("#tong_tien").val() != "")
                    txttongtien +=  eval($("#tableAjax_PHIEU_XUAT_VT_CT").find("tr").eq(i).find("#tong_tien").val().replace(/\$|\,/g,''));
                //alert(test);            
            }
            $("#txttongtien").val(formatCurrency1(txttongtien));
         }
         function formatCurrency1(num){
            Number.prototype.formatMoney = function(c, d, t){
            var n = this, c = isNaN(c = Math.abs(c)) ? 2 : c, d = d == undefined ? "," : d, t = t == undefined ? "." : t, s = n < 0 ? "-" : "", i =  parseInt(n = Math.abs(+n || 0).toFixed(c)) + "", j = (j = i.length) > 3 ? j % 3 : 0;
               return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
             };
            return num.formatMoney(2,'.',',');
         }
         function laphieuchi()
       {
           window.open("KTTM_PhieuChiKhac.aspx");
       }
       
       function inphieuxuat()
       {
            window.open("KTTSCD_rptInPhieuXuat.aspx?so_phieu="+$("#so_phieu").val() +"&ngay_xuat="+$("#ngay_xuat").val());
            //alert("chưa có mẫu in");
       }
