        //---------------------------code phát sinh----------------------------
         $(document).ready(function() {
                 $.mkv.moveUpandDown("#tablefind");
               setControlFind($.mkv.queryString("idkhoachinh"));
               if($.mkv.queryString("idkhoachinh") == "")
                    PageLoadNgoaiTe();
                 $("#luu").click(function () {
                   $(this).Luu({
                         ajax:"../ketoan/XuLyPara.aspx?do=Luu"
                      },null,function () {
                           $.LuuTable({
                                 ajax:"../ketoan/XuLyPara.aspx?do=luuTablechitietphieunhapkho&idphieunhap=" + $.mkv.queryString("idkhoachinh")+"&maphieunhap="+$("#maphieunhap").val()+"&ma_kt="+$("#ma_kt").val()+"&ngaythang="+$("#ngaythang").val()+"&mancc="+$("#txtMaNCC").val()+"&sohoadon="+$("#sohoadon").val()+"&ngayhoadon="+$("#ngayhoadon").val()+"&tkco="+$("#tkco").val()+"&tkcokhac="+$("#TkCoKhac").val()+"&tkvat="+$("#tkvat").val()+"&thuesuat="+$("#vat").val()+"&ghichu="+$("#ghichu").val(),
                                 tablename:"gridTable"
                           });
                      });
                });
                $("#moi").click(function () {
                     //$(this).Moi();                    
                     //loadTableAjaxchitietphieunhapkho('');
                     	window.location = "../ketoan/KT_PhieuNhapKho.aspx";
                });
                $("#xoa").click(function () {
                   $(this).Xoa({
                         ajax:"../ketoan/XuLyPara.aspx?do=xoa"
                    },null,function () {
                         loadTableAjaxchitietphieunhapkho('');
                     });
                });
                $("#timKiem").click(function () {
                    Find($(this)); 
                 });
                 $("#tinhphitt").click(function () {
                     $(this).Moi();                    
                     tinhtien();
                });
         });
         
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
                         $("#txtMaNT").val(data[1]);
                         $("#txtty_gia").val(data[2]);
                      }
                }
            }
            xmlhttp.open("GET","ajax/phieuxuatkho_ajax3.aspx?do=PageLoadNgoaiTe&times="+Math.random(),true);
            xmlhttp.send(null);
        }
        
        function load(obj)
        {
            //var ma_kt=document.getElementById('ma_kt');  
            //ma_kt.value = "abc";
            //document.getElementById('ma_kt').focus();    
        }
        window.onload = load;      
        function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"../ketoan/XuLyPara.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
                     loadTableAjaxchitietphieunhapkho($.mkv.queryString("idkhoachinh"));                    
                 });
              }else{loadTableAjaxchitietphieunhapkho();}         
            }
          function Find(control,page) {
              if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"../ketoan/XuLyPara.aspx?do=TimKiem&page="+page
               });
          }
         function xoaontable(control){
              $(control).XoaRow({
                 ajax:"../ketoan/XuLyPara.aspx?do=xoachitietphieunhapkho"
              });
         }
         function loadTableAjaxchitietphieunhapkho(idkhoa,page)
         {
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_chitietphieunhapkho").html('<img src="../images/loading-bar.gif" style="margin:0 81%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ketoan/XuLyPara.aspx?do=loadTablechitietphieunhapkho&idphieunhap="+idkhoa+"&page="+page,
                  success: function (value){
                         document.getElementById("tableAjax_chitietphieunhapkho").innerHTML=value;
                         $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                         //Load tổng tiền
                         tinhtongtien();
                    }
             });
         }
         function formatCurrency1(num){
            Number.prototype.formatMoney = function(c, d, t){
            var n = this, c = isNaN(c = Math.abs(c)) ? 2 : c, d = d == undefined ? "," : d, t = t == undefined ? "." : t, s = n < 0 ? "-" : "", i =  parseInt(n = Math.abs(+n || 0).toFixed(c)) + "", j = (j = i.length) > 3 ? j % 3 : 0;
               return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
             };
            return num.formatMoney(2,'.',',');
         }
         //---------------------------code nam dang----------------------------
         function ShowLoaiThuoc(obj)
        {
             var objsrc = document.getElementById(obj);
             $("#"+obj).unautocomplete().autocomplete("../ketoan/XuLyPara.aspx?do=LoadDLoaiThuoc&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
             {width:300,scroll:true,formatItem:function(data)
                        {return data[1];}
             }
             ).result(
                         function(event,data)
                         {
                            setChonLoaiThuoc(data[2],data[3],data[4]);
                         }   
                     );
        }

        function setChonLoaiThuoc(idLoaiThuoc,MaLoaiThuoc,TenLoaiThuoc)
        { 
              var txtMaLoaiThuoc=document.getElementById('txtMaLoaiThuoc');
              var txtTenLoaiThuoc=document.getElementById('txtTenLoaiThuoc');
             
              txtMaLoaiThuoc.value=MaLoaiThuoc;
              txtTenLoaiThuoc.value = TenLoaiThuoc;
              
              //alert(hd_IDBN.value);
              document.getElementById('TenLoaiThuoc').focus();
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
              var txtMST=document.getElementById('txtMST');
              var txtDC=document.getElementById('txtDC');
              var nhacungcapid=document.getElementById('nhacungcapid');
              var txtTenNCC=document.getElementById('txtTenNCC');
              var txtMaNCC=document.getElementById('txtMaNCC'); 
              var tennhacungcap = document.getElementById('tennhacungcap'); 
                  
              txtMST.value = MST;
              txtDC.value = DC;
              nhacungcapid.value=idNCC;
              txtTenNCC.value = TenNCC;
              tennhacungcap.value = TenNCC;
              txtMaNCC.value = MaNCC;
              
              
              //alert(hd_IDBN.value);
              document.getElementById('txtTenNCC').focus();
        }
        function ShowThongTinNCC(obj)
        {
                var objsrc = document.getElementById(obj);
              
                    $("#"+obj).unautocomplete().autocomplete("../ketoan/XuLyPara.aspx?do=LayThongTinNCC&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                                {width:300,scroll:true,formatItem:function(data)
                                                                    {return data[1];}
                                                                }
                                                            ).result(
                                                                        function(event,data)
                                                                        {
                                                                            alert("abc");
                                                                            //setChonTTNCC(data[2],data[3],data[4],data[5],data[6]);
                                                                            //document.getElementById(obj).blur();
                                                                        }
                                                                    );     
        }
        function setChonTTNCC(idNCC,MaNCC,TenNCC,DC,MST)
        { 
              var txtMST=document.getElementById('masothue');
              var txtDCNCC=document.getElementById('diachi');
              
              txtMST.value = MST;
              txtDCNCC.value = DC;             
              
              
              //alert(hd_IDBN.value);
              //document.getElementById('txtTenNCC').focus();
        }
        function ShowNghiepVu(obj)
        {
                var objsrc = document.getElementById(obj);
              
                    $("#"+obj).unautocomplete().autocomplete("../ketoan/XuLyPara.aspx?do=LoadDanhSachNghiepVu&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                                {width:300,scroll:true,formatItem:function(data)
                                                                    {return data[1];}
                                                                }
                                                            ).result(
                                                                        function(event,data)
                                                                        {
                                                                            setChonNghiepVu(data[2],data[3],data[4],data[5],data[6],data[7],data[8],data[9]);
                                                                            //document.getElementById(obj).blur();
                                                                        }
                                                                    );     
        }
        function setChonNghiepVu(id,MaNV,TenNV,LoaiCT,TKN,TKC,TKT,VAT)
        { 
              var txtTenNghiepVu=document.getElementById('txtTenNghiepVu');
              var tkco=document.getElementById('tkco');
              // var tkno=document.getElementById('tkno');
              var Id=document.getElementById('Id');
              var tkvat=document.getElementById('tkvat'); 
              var vat = document.getElementById('vat'); 
              var Id_nv = document.getElementById('Id_nv');
                  
              txtTenNghiepVu.value = TenNV;
              tkco.value = TKC;
              //tkno.value=TKN;              
              tkvat.value = TKT;
              vat.value = VAT;
              Id_nv.value = id;
              
              
              //alert(hd_IDBN.value);
              document.getElementById('txtTenNghiepVu').focus();
        }
        
        function loadthuesuat()
        {
            var thuesuat = $("#vat").val();
            for(var i=1;i<document.getElementById("tableAjax_chitietphieunhapkho").getElementsByTagName('table')[0].rows.length-1;i++)
            {
                $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#vat").val(thuesuat);
                var thanhtientruocthue = 0;
                var tienchietkhau = 0;
                var tienthue = 0;
                if($("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#thanhtientruocthue").val().replace(/\$|\,/g,'') != "")
                    thanhtientruocthue = $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#thanhtientruocthue").val().replace(/\$|\,/g,'');
                if($("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tienchietkhau").val() != "")
                    tienchietkhau = $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tienchietkhau").val().replace(/\$|\,/g,'');
                //if($("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tienthue").val() != "")
                //    tienthue = $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tienthue").val().replace(/\$|\,/g,'');
                //Tính lại tiền thuế, thành tiền = tientruocthue+chietkhau+tienthue, tổng tiền
                $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tienthue").val(formatCurrency1( eval(thuesuat) * eval(thanhtientruocthue)));
                tienthue = $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tienthue").val().replace(/\$|\,/g,'');
                $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tongtien").val(formatCurrency1( eval(thanhtientruocthue) + eval(tienchietkhau) + eval(tienthue)));
            }
            //Tính tổng tiền
            tinhtongtien();
        }
        function tinhtongtien()
        {
            var txttongtientruocthue = 0;
            var txttienthue = 0;
            var txttienchietkhau = 0;
            var txtthanhtien = 0;
            var txtthanhtienquydoi = 0;
            for(var i=1;i<document.getElementById("tableAjax_chitietphieunhapkho").getElementsByTagName('table')[0].rows.length-1;i++)
            {
                    //tongtientruocthue = 1 * tongtientruocthue + 1 * $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#soluong").val() * $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#dongia").val();
                    var tongtientruocthue = 0;
                    var tienchietkhau = 0;
                    var tienthue = 0;
                    var thanhtien = 0;
                    var thanhtienquydoi = 0;
                    if($("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#thanhtientruocthue").val() != "")
                        tongtientruocthue = $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#thanhtientruocthue").val().replace(/\$|\,/g,'');
                    if($("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tienchietkhau").val() != "")
                        tienchietkhau = $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tienchietkhau").val().replace(/\$|\,/g,'');
                    if($("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tienthue").val() != "")
                        tienthue = $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tienthue").val().replace(/\$|\,/g,'');
                    if($("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tongtien").val() != "")
                        thanhtien = $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tongtien").val().replace(/\$|\,/g,'');
                    //alert($("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tongtienquydoi").val());
                    if($("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tongtienquydoi").val() != "")
                        thanhtienquydoi = $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tongtienquydoi").val().replace(/\$|\,/g,'');
                    // alert(tienchietkhau);
                    txttongtientruocthue = eval(txttongtientruocthue) + eval(tongtientruocthue);
                    txttienthue = eval(txttienthue) + eval(tienthue);
                    txttienchietkhau = eval(txttienchietkhau) + eval(tienchietkhau);
                    txtthanhtien = eval(txtthanhtien) + eval(thanhtien);
                    txtthanhtienquydoi = eval(txtthanhtienquydoi) + eval(thanhtienquydoi);
            }
            $("#txttongtientruocthue").val(formatCurrency1(txttongtientruocthue));
            $("#txtchietkhau").val(formatCurrency1(txttienchietkhau));
            $("#txttienthue").val(formatCurrency1(txttienthue));
            $("#txtthanhtien").val(formatCurrency1(txtthanhtien));
            $("#txtthanhtienquydoi").val(formatCurrency1(txtthanhtienquydoi));
        }
        function XuLyMaPhieuNhap(obj)
        {
                var objsrc = document.getElementById(obj);
                    $("#"+obj).unautocomplete().autocomplete("../ketoan/XuLyPara.aspx?do=LoadXuLyMaPhieuNhap&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                                {width:300,scroll:true,formatItem:function(data)
                                                                    {return data[1];}
                                                                }
                                                            ).result(
                                                                        function(event,data)
                                                                        {;
                                                                            setChonPhieuNhap(data[4]);
                                                                        }
                                                                    );     
        }

        function setChonPhieuNhap(MaPN)
        { 
              var maphieunhap=document.getElementById('maphieunhap');  
              var txtMaPhieuNhap = document.getElementById('txtMaPhieuNhap');  
              maphieunhap.value = MaPN;  
              txtMaPhieuNhap.value = MaPN;
             
              document.getElementById('maphieunhap').focus();
              
        }
        function XuLyMaChungTu(obj)
        {
       
                var objsrc = document.getElementById(obj);
              
                    $("#"+obj).unautocomplete().autocomplete("../ketoan/XuLyPara.aspx?do=LoadXuLyMaChungTu&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                                {width:300,scroll:true,formatItem:function(data)
                                                                    {return data[1];}
                                                                }
                                                            ).result(
                                                                        function(event,data)
                                                                        {;
                                                                            setChonChungTu(data[4]);
                                                                        }
                                                                    );     
        }

        function setChonChungTu(MaCT)
        { 
              var SophieuCT=document.getElementById('SophieuCT');  
              SophieuCT.value = MaCT;  
             
              document.getElementById('SophieuCT').focus();
              
        }
        function TestMaNCC(obj)
        {
            if(obj.value=="")
            {
                document.getElementById('txtMaNCC').value = "";
            }
        }
        function ShowNgoaiTe(obj)
        {
                var objsrc = document.getElementById(obj);
              
                    $("#"+obj).unautocomplete().autocomplete("../ketoan/XuLyPara.aspx?do=LoadDanhSachNgoaiTe&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                                {width:300,scroll:true,formatItem:function(data)
                                                                    {return data[1];}
                                                                }
                                                            ).result(
                                                                        function(event,data)
                                                                        {
                                                                            setChonNT(data[2],data[3],data[4],data[5]);
                                                                            //document.getElementById(obj).blur();
                                                                        }
                                                                    );     
        }
        function setChonNT(idNT,MaNT,TenNT,TyGia)
        { 
              var ngoai_te_id=document.getElementById('ngoai_te_id');
              var txtTenNT=document.getElementById('txtTenNT');
              var ty_gia=document.getElementById('txtty_gia');
             
              ngoai_te_id.value=idNT;
              txtTenNT.value = TenNT;
              ty_gia.value = TyGia;
              
              //alert(hd_IDBN.value);
              document.getElementById('txtTenNT').focus();
        }
        function TestMaNT(obj)
        {
            if(obj.value=="")
            {
                document.getElementById('txtMaNT').value = "";
            }
        }
        function ShowChungTu(obj)
        {
                var objsrc = document.getElementById(obj);
              
                    $("#"+obj).unautocomplete().autocomplete("../ketoan/XuLyPara.aspx?do=LoadDanhSachChungTu&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                                {width:300,scroll:true,formatItem:function(data)
                                                                    {return data[1];}
                                                                }
                                                            ).result(
                                                                        function(event,data)
                                                                        {
                                                                            setChonCT(data[2],data[3],data[4]);
                                                                            //document.getElementById(obj).blur();
                                                                        }
                                                                    );     
        }
        function setChonCT(idCT,MaCT,TenCT)
        { 
              var txtMaCT=document.getElementById('txtMaCT');
              var txtTenCT=document.getElementById('txtTenCT');
             
              txtMaCT.value=MaCT;
              txtTenCT.value = TenCT;
              
              //alert(hd_IDBN.value);
              document.getElementById('txtTenCT').focus();
        }
        function TestMaCT(obj)
        {
            if(obj.value=="")
            {
                document.getElementById('txtMaCT').value = "";
            }
        }
  

        function TestMaPN(obj)
        {
            if(obj.value=="")
            {
                document.getElementById('txtMaPhieuNhap').value = "";
            }
        }
        //-----------------------------Test Ngày Tháng-----------------------
         function ListControlTimKiemngaythang(control) 
         {
             return "../../ketoan/XuLyPara.aspx?do=TimKiem&ngaythang=" + encodeURIComponent(control.value) + "";
         }
         //--------
              function ListControlTimKiemtkvat(control) {
             return " tkvat = '"+control.value+"'";
         }
         //-------------
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
	                        $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#tkno").val(data[2]);
                        }
                        );           
             
        }
        function TestMaTK(obj)
        {
            if(obj.value=="")
            {
                document.getElementById('txtMaTKCo').value = "";
            }
        }   
         function loaivattuSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("XuLyPara.aspx?do=loaivattuSearch",{
             minChars:0,
             width:150,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#tableAjax_chitietphieunhapkho").attr("id") != null){
                     $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }   
         function VatTuSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("XuLyPara.aspx?do=VatTuSearch&idloaivattu="+$("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#loaithuoc").val(),{
             minChars:0,
             width:150,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#tableAjax_chitietphieunhapkho").attr("id") != null){
                     $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function dvtSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("XuLyPara.aspx?do=dvtSearch",{
             minChars:0,
             width:150,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#tableAjax_chitietphieunhapkho").attr("id") != null){
                     $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
        function ShowDMPhi(obj)
        {
                var objsrc = document.getElementById(obj);
              
                    $("#"+obj).unautocomplete().autocomplete("../ketoan/XuLyPara.aspx?do=LoadDanhSachPhi&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                                {width:300,scroll:true,formatItem:function(data)
                                                                    {return data[1];}
                                                                }
                                                            ).result(
                                                                        function(event,data)
                                                                        {
                                                                            setChonPhi(data[2],data[3],data[4],data[5]);
                                                                            //document.getElementById(obj).blur();
                                                                        }
                                                                    );     
        }
        function setChonPhi(idNT,MaNT,TenNT,TyGia)
        { 
              var txtPhi=document.getElementById('txtPhi');
             
              txtPhi.value=TenNT;
              
              //alert(hd_IDBN.value);
              document.getElementById('txtPhi').focus();
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
                     $("#"+obj.id.replace("mkv_","")).val(data[0]);                    
                     //$("#tigia").val(formatCurrency1(data[2].substring(0,data[2].length-3)));
                     $("#txtty_gia").val(data[2].substring(0,data[2].length-3));
                     //Load lại VNĐ
                     /*var tienthue=0;
                     var tongtien = 0;
                     var tigia = $("#ty_gia").val();
                     for(var i=1;i<document.getElementById("tableAjax_chitietphieunhapkho").getElementsByTagName('table')[0].rows.length-1;i++)
                     {
                         var nguyente = $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#nguyente").val().replace(/\$|\,/g,'');
                         $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#thanhtien").val(formatCurrency1( nguyente * tigia ));
                         tongtien = 1 * tongtien + 1 * $("#tableAjax_chitietphieuxuatkho").find("tr").eq(i).find("#thanhtien").val().replace(/\$|\,/g,'');
                     }*/
                     //alert(tongtien);
                     //$("#txtthanhtienquydoi").val(formatCurrency1(tongtien));
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function tinhphi()
         {
         
            var phi = $("#txtPhi").val().replace(/\$|\,/g,'');
            if($("#txtLoaiPhi").val() == 'Lượng')
            {
                //alert('luong');
                var tongsoluong = 0;   
                for(var i=1;i<document.getElementById("tableAjax_chitietphieunhapkho").getElementsByTagName('table')[0].rows.length-1;i++)
                {
                    tongsoluong = eval(tongsoluong) + eval($("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#soluong").val());     
                }
                for(var i=1;i<document.getElementById("tableAjax_chitietphieunhapkho").getElementsByTagName('table')[0].rows.length-1;i++)
                {
                    var soluong = $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#soluong").val();     
                    var thanhtienphi = soluong * phi / tongsoluong;
                    $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#thanhtienphi").val(formatCurrency1(thanhtienphi));
                }
            }
            if($("#txtLoaiPhi").val() == 'Trị')
            {
                //alert('tri');
                for(var i=1;i<document.getElementById("tableAjax_chitietphieunhapkho").getElementsByTagName('table')[0].rows.length-1;i++)
                {
                    var thanhtien = 0;
                    var tongtien = 0;
                    var thanhtienphi = 0;
                    
                    //alert($("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tongtien").val());
                    if($("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tongtien").val() != "")
                        thanhtien = $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#tongtien").val().replace(/\$|\,/g,'');     
                    if($("#txtthanhtien").val() != "")
                        tongtien = $("#txtthanhtien").val().replace(/\$|\,/g,'');
                    thanhtienphi = eval(thanhtien) * eval(phi) / eval(tongtien);
                    //alert(eval(phi));
                    $("#tableAjax_chitietphieunhapkho").find("tr").eq(i).find("#thanhtienphi").val(formatCurrency1(thanhtienphi));
                    //$("#txtPhi").val(formatCurrency1(phi));
                }   
            }
            $("#txtPhi").val(formatCurrency1(eval(phi)));
         }
         function tinhtien(obj)
         {      
                var thuesuat = $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#vat").val();
                //alert(thuesuat);
                var chietkhau = $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#chietkhau").val();
                var tongtientruocthue = $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#thanhtientruocthue").val(); 
                var tienchietkhau = $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#tienchietkhau").val();
                var tienthue = $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#tienthue").val();
                var thanhtien = $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#tongtien").val();
                var thanhtienquydoi = $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#tongtienquydoi").val();
                var ty_gia = $("#txtty_gia").val();
                if(ty_gia == "")
                    ty_gia = 0;
                    
                if(tongtientruocthue == "")
                    tongtientruocthue = 0;
                if(thuesuat == "")
                {
                    thuesuat = 0;
                }
                else
                {
                    //alert(tongtientruocthue+" ' "+thuesuat);
                    $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#tienthue").val( formatCurrency1(eval(tongtientruocthue.replace(/\$|\,/g,'')) * eval(thuesuat.replace(/\$|\,/g,''))/100) );
                    tienthue = $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#tienthue").val();
                }
                if(chietkhau == "")
                {
                    chietkhau = 0;
                }
                else
                {
                    $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#tienchietkhau").val( formatCurrency1(eval(tongtientruocthue.replace(/\$|\,/g,'')) * eval(chietkhau.replace(/\$|\,/g,''))/100) );
                    tienchietkhau = $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#tienchietkhau").val();
                }  
                if(tienchietkhau == "")
                    tienchietkhau = 0;
                if(tienthue == "")
                    tienthue = 0;
                if(thanhtien == "")
                    thanhtien = 0;
                if(thanhtienquydoi == "")
                    thanhtienquydoi = 0;
                    
                $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#tongtien").val( formatCurrency1(eval(tongtientruocthue.replace(/\$|\,/g,'')) - eval(tienchietkhau.replace(/\$|\,/g,'')) + eval(tienthue.replace(/\$|\,/g,''))) );                    
                $("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#tongtienquydoi").val( eval($("#tableAjax_chitietphieunhapkho").find("tr").eq($(obj).parent().parent().index()).find("#tongtien").val().replace(/\$|\,/g,'')) * eval(ty_gia));                    
                //Tính tổng tiền
                tinhtongtien();
         }
         function ShowKho(obj)
        {
                var objsrc = document.getElementById(obj);
              
                    $("#"+obj).unautocomplete().autocomplete("../ketoan/XuLyPara.aspx?do=LoadDanhSachKho&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                                {width:300,scroll:true,formatItem:function(data)
                                                                    {return data[1];}
                                                                }
                                                            ).result(
                                                                        function(event,data)
                                                                        {
                                                                            setChonKho(data[2],data[3],data[4]);
                                                                            //document.getElementById(obj).blur();
                                                                        }
                                                                    );     
        }
        function setChonKho(idk,MaKho,TenKho)
        { 
              var idkho=document.getElementById('idkho');
              var txtKho=document.getElementById('txtKho');
             
              idkho.value=idk;
              txtKho.value = TenKho;
              
              //alert(hd_IDBN.value);
              document.getElementById('txtKho').focus();
        }
        function ShowLoaiPhi(obj)
        {
                var objsrc = document.getElementById(obj);
              
                    $("#"+obj).unautocomplete().autocomplete("../ketoan/XuLyPara.aspx?do=LoadLoaiPhi&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                                {width:300,scroll:true,formatItem:function(data)
                                                                    {return data[1];}
                                                                }
                                                            ).result(
                                                                        function(event,data)
                                                                        {
                                                                            setChonLoaiPhi(data[2],data[3]);
                                                                            //document.getElementById(obj).blur();
                                                                        }
                                                                    );     
        }
        function setChonLoaiPhi(id,TenLoaiPhi)
        { 
              var Id_lp=document.getElementById('Id_lp');
              var txtLoaiPhi=document.getElementById('txtLoaiPhi');
             
              Id_lp.value=id;
              txtLoaiPhi.value = TenLoaiPhi;
              
              //alert(hd_IDBN.value);
              document.getElementById('txtLoaiPhi').focus();
        }