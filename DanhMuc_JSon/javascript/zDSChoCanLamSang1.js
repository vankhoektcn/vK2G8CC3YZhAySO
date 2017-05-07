var now = new Date();
         $(document).ready(function() {
               //setControlFind($.mkv.queryString("idkhoachinh"));
               if($.mkv.queryString("isDaCLS")=="1")
                    $("#header").html("DANH SÁCH KẾT QUẢ XÉT NGHIỆM");
               $("#luu").click(function () {
                   $(this).Luu({
                      ajax:"../ajax/zDSChoCanLamSang_ajax1.aspx?do=Luu"
                      },null,function () {
                         $("#timKiem").click();
                   });
                });
                $("#moi").click(function () {
                     $(this).Moi();  
                });
                $("#xoa").click(function () {
                    $(this).Xoa({
                        ajax:'../ajax/zDSChoCanLamSang_ajax1.aspx?do=xoa'
                    },null,function () {
                         $("#timKiem").click();
                    });
                });
                $("#timKiem").click(function () {
                    Find(this);
                });
                $("#IdKhoa").DropList({
                    ajax: "../ajax/zDSChoCanLamSang_ajax1.aspx?do=IdKhoaSearch"
                    ,defaultVal: ""
                },null,function(){
                    if( !$.isNullOrEmpty($.mkv.queryString("IdKhoa")) )
                        $("#IdKhoa")[0].value=$.mkv.queryString("IdKhoa");                        
                });
                SetDefault();
         });
         function SetDefault()
         {
            $("#TuNgay").val(now.format("d/m/Y"));
            $("#DenNgay").val(now.format("d/m/Y"));
         }
          function setControlFind(obj,madangky,idbs,MaPhong,IdKhoa) {
              $("#gridTable").find("tr").eq($(obj).parent().parent().index()).remove();
              var link = "../../canlamsang/frmKQXetNghiem_new.aspx?new=1&macls='" + madangky + "'&idbs=" + idbs + "&MaPhong=" + MaPhong + "&idphongkhambenh=" + IdKhoa + "&dkmenu=nomenu";    
              window.open(link,"_blank");
          }
          function XemKetQuaXetNghiem(obj,idKetQua,madangky,idbs,MaPhong,IdKhoa) {
              //$("#gridTable").find("tr").eq($(obj).parent().parent().index()).remove();
              var link = "../../canlamsang/frmKQXetNghiem_new.aspx?new=0&macls='" + madangky + "'&idbs=0&MaPhong=" + MaPhong + "&idphongkhambenh=" + IdKhoa + "&dkmenu=nomenu";    
              window.open(link,"_blank");
          }
          function setNEWCLS(obj,idkhambenh,idkhoa)
          {
              var link = "../../KhamBenh_TH/ChiDinhCanLamSang.aspx?dkmenu=nomenu#idkhoachinh="+idkhambenh+"";    
              window.open(link,"_blank");
          }
           function Find(control) {
               var isDaCLS= !$.isNullOrEmpty($.mkv.queryString("isDaCLS"))&& $.mkv.queryString("isDaCLS")=="1" ?"&isDaCLS=1":"";
               $(control).TimKiem({
                     ajax:"../ajax/zDSChoCanLamSang_ajax1.aspx?do=TimKiem"+isDaCLS+"",dataType:'json',showPopup:false
               },function () {
                    $("#tableAjax_zDSChoCanLamSang").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                    return true;
               },function (data) {
                      var html="";
                      html+="<table class='jtable' id=\"gridTable\">";
                      html+="<tr>";
                      html+="<th></th>";
                      html+="<th>STT</th>";
                      html+="<th>"+ data.TABLE[0].IDKHOA +"</th>";
                      html+="<th>Ngày Thu</th>";
                      html+="<th>"+ data.TABLE[0].MACLS +"</th>";
                      html+="<th>"+ data.TABLE[0].MABENHNHAN +"</th>";
                      html+="<th>"+ data.TABLE[0].TENBENHNHAN +"</th>";
                      html+="<th>"+ data.TABLE[0].GIOITINH +"</th>";
                      html+="<th>"+ data.TABLE[0].NGAYSINH +"</th>";
                      html+="<th>"+ data.TABLE[0].BSCHIDINH +"</th>";
                      html+="<th></th>";
                      html+="</tr>";
                      html+="</table>";
                      html+="<div id='paging' style='width:100%;height:50px'/>";
                      $("#tableAjax_zDSChoCanLamSang").html(html);
               }).myfilter({
                     txtfilter:"#gridTable [name=search]",
                     paging:function(json,data){
                           $("#tableAjax_zDSChoCanLamSang").find("#paging").html(data);
                     },
                     result:function(json,item){
                         var html=[],j=0;
                         for( var i = -1, y = item.length; ++i != y;){ 
                            if(!$.isNullOrEmpty(item[i].IDKHAMBENH))
                            {
                                 html[j++]="<tr>";
                                 var XetNghiem= "";
                                 if(isDaCLS=="&isDaCLS=1")
                                 {
                                        XetNghiem= "<a href='javascript:;' onclick=\"XemKetQuaXetNghiem(this,"+item[i].IDKETQUA_CANLAMSANG+",'"+item[i].MACLS+"','"+item[i].IDBACSI+"','"+item[i].MAPHONGKHAMBENH+"','"+item[i].IDKHOA+"');\" style='font-weight:bold;'>Chi tiết</a>";
                                 }
                                 else
                                 {
                                     if(!$.isNullOrEmpty(item[i].MACLS))
                                        XetNghiem= "<a href='javascript:;' onclick=\"setControlFind(this,'"+item[i].MACLS+"','"+item[i].IDBACSI+"','"+item[i].MAPHONGKHAMBENH+"','"+item[i].IDKHOA+"');\" style='font-weight:bold;'>Xét nghiệm</a>";
                                 }
                                 html[j++]="<td>"+XetNghiem+"</td>";
                                 html[j++]="<td>" + item[i].STT + "</td>";
                                 html[j++]="<td style='text-align: left;'>" + item[i].TENPHONGKHAMBENH + "</td>";
                                 html[j++]="<td>" + item[i].TUNGAY + "</td>";
                                 html[j++]="<td>" + item[i].MACLS + "</td>";
                                 html[j++]="<td style='text-align: left;'>" + item[i].MABENHNHAN + "</td>";
                                 html[j++]="<td style='text-align: left;'>" + item[i].TENBENHNHAN + "</td>";
                                 html[j++]="<td>" + item[i].GIOITINH + "</td>";
                                 html[j++]="<td>" + item[i].NGAYSINH + "</td>";
                                 html[j++]="<td style='text-align: left;'>" + item[i].BSCHIDINH + "</td>";
                                 var NewCls= "";
                                 if(item[i].ISNEWCLS=="1")
                                    NewCls= "<a href='javascript:;' onclick=\"setNEWCLS(this,'"+item[i].IDKHAMBENH+"','"+item[i].IDKHOA+"');\" style='font-weight:bold;'>Chỉ định</a>";
                                 html[j++]="<td>"+NewCls+"</td>";
                                 html[j++]="</tr>";
                            }
                         }
                         $("#gridTable").find("tr:gt(0)").empty().remove();
                         $("#gridTable").append($(html.join('')));
                     }
               });
         }
        function IdKhoaSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/zDSChoCanLamSang_ajax1.aspx?do=IdKhoaSearch",{
             minChars:0,
             scroll:true,
             formatItem:function (data) {
                 return data[0];
             }}).result(function(event,data){
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
