
         $(document).ready(function() {
            var currentTime = new Date()
            var month = currentTime.getMonth() + 1
            var day = currentTime.getDate()
            var year = currentTime.getFullYear()
            $("[id$='tungay']").val(day + "/" + month+ "/" + year)
            $("[id$='denngay']").val(day + "/" + month+ "/" + year)
             $("#timKiem").click(function () {
                    Find(this);
             });
             $("#timKiem").click();
         });
          function Find(control,page) {
           if(page == null) page = "1";
           var LoaiBN=getUrlVars()["LoaiBN"];
              $(control).TimKiem({
                     ajax:"../ajax/benhnhan_ajax2.aspx?do=TimKiem&LoaiBN="+LoaiBN+"&page="+page
               },function (data) {
                         $("#tableAjax_benhnhan").html(data);
                         $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
               },function () {
                     $("#tableAjax_benhnhan").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
               });
              
       }
       function InPhieuDangKyBaoHiem(idphieudangky,iddv,other,loaiBN)
	   {
	        if(loaiBN=="1"){
	         window.open("rptPhieuThuKB.aspx?iddangky="+idphieudangky+"&iddv="+iddv+"&loaiBN=1&other="+other,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	        }
	        else{
	         window.open("rptPhieuThuKB.aspx?iddangky="+idphieudangky+"&iddv="+iddv+"&loaiBN=0&other="+other,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	        }
	   }
	   function SuaPhieu(iddangky)
	   {
	     window.open("dangkynhieukhoa.aspx?idDkk="+iddangky+"&dkmenu=thuphi");

	   } 
	   function ThuPhiDV(iddkkham,ngaydangky,loaiBN,maphieu)
       { 
             if (confirm("Bạn có chắn thực thu phiếu thu "+maphieu+" không!")){
                           var options = {
                                type: "POST",
                                url:"../ajax/benhnhan_ajax2.aspx?do=ThuPhiDV&iddkkham="+iddkkham+"&ngaydangky="+ngaydangky,
                                contentType: "application/json;charset=utf-8",
                                dataType: "json",
                                async: false,
                                success: function(response) {
                                 $("#timKiem").click();
                                },
                                error: function(msg) {   
                                 }
                            };
                            var returnText = $.ajax(options).responseText;
                            if(returnText=="1")  {
                              if (confirm("Đã lưu thành công!Bạn có muốn in phiếu thu dịch vụ không !"))
	                             {
	                             var LoaiBN=getUrlVars()["LoaiBN"];
	                                if(loaiBN=="1")
	                                {
	                                    window.open("rptPhieuThuKB.aspx?iddangky="+iddkkham+"&iddv=0&loaiBN=1&other=0",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
                                                
	                                }
	                                else{
	                                    window.open("rptPhieuThuKB.aspx?iddangky="+iddkkham+"&iddv=0&loaiBN=0&other=0",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
	                                }
	                             }  
                            }
                            else
                            {
                                alert(returnText);
                            }
                            }
                            else{
                                return;
                            }
                }
              function huy(control,kieuthaotac,iddangkykham) {
              $(control).TimKiem({
                     ajax:"../ajax/benhnhan_ajax2.aspx?do=huyDangKy&kieuthaotac="+encodeURIComponent(kieuthaotac)+"&iddangkykham="+iddangkykham
               }); 
                
            }
            //huy dang ky dich vu kham benh
            function  LuuHuyDangKy()
            {
                var idnguoithu=$("[id$='idnguoithu']");
                var iddangkykham=$("[id$='hdiddangkykham']");
                var kieuthaotac=$("[id$='kieuthaotac']");
                var lydo=$("[id$='lydo']");
                                var options = {
                                type: "POST",
                                url:"../ajax/benhnhan_ajax2.aspx?do=huyDVKham&iddkkham="+iddangkykham.val()+"&kieuthaotac="+encodeURIComponent(kieuthaotac.val())+"&lydo="+encodeURIComponent(lydo.val()),
                                contentType: "application/json;charset=utf-8",
                                dataType: "json",
                                async: false,
                                success: function(response) {
                                },
                                error: function(msg) {   
                                 }
                            };
                            var returnText = $.ajax(options).responseText;
                            if (returnText !="") {
                                 alert(returnText);  
                                 Dong();
                                 $("#timKiem").click(); 
                            }
                            else {
                              alert(returnText);   
                              Dong();
                                }                   
                
            }
            function Dong()
            {
                 $("#divTimKiem").remove();
             
            }
            //Lay paramater tu url
            function getUrlVars()
            {
                var vars = [], hash;
                var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                for(var i = 0; i < hashes.length; i++)
                {
                    hash = hashes[i].split('=');
                    vars.push(hash[0]);
                    vars[hash[0]] = hash[1];
                }
                return vars;
            }