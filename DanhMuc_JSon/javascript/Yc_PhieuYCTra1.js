         $(document).ready(function() {
               setControlFind($.mkv.queryString("idkhoachinh"));
               $("#luu").click(function () {
                   $(this).Luu({
                      ajax:"../ajax/Yc_PhieuYCTra_ajax1.aspx?do=Luu"
                      },null,function () {
                         $("#timKiem").click();
                   });
                });
                $("#moi").click(function () {
                     $(this).Moi();
                     setDefault();  
                });
                $("#xoa").click(function () {
                    $(this).Xoa({
                        ajax:'../ajax/Yc_PhieuYCTra_ajax1.aspx?do=xoa'
                    },null,function () {
                         $("#timKiem").click();
                    });
                });
                $("#timKiem").click(function () {
                    Find(this);
                });
                
                $("#new").click(function () {
                        window.open('Yc_PhieuYCTra3.aspx?dkmenu='+  $.mkv.queryString("dkmenu")+"&IdKhoa=" + $.mkv.queryString("IdKhoa")+"&IsHongVo="+$.mkv.queryString("IsHongVo"), '_blank');
                });
                //----------------------
                   setDefault();
                //--------------------
                 
                          
                 $("#IdKhoYc").DropList({ ajax: "../ajax/Yc_PhieuYCTra_ajax3.aspx?do=IdKhoYcSearch&IdKhoa=" + $.mkv.queryString("IdKhoa")
                 ,defaultVal:"- Chọn kho -" ,async:true}
                 ,null
                 ,function(){
                      
                  
                 
            });
            
                 //----------------------
                 $("#IdKhoDuyet").DropList({ ajax: "../ajax/Yc_PhieuYCTra_ajax3.aspx?do=IdKhoDuyetSearch&IsHongVo="+$.mkv.queryString("IsHongVo")+"&IdKho="+ $.mkv.queryString("IdKho")
                 ,defaultVal:"" ,async:true}
                 ,null
                 ,function(){
                  
                 
            });
                   //--------------------
              
                 $("#LoaiThuocID").DropList({ ajax: "../ajax/Yc_PhieuYCXuat_ajax3.aspx?do=LoaiThuocIDSearch"
                 ,defaultVal:"- Chọn đối tượng -" ,async:false}
                 ,null
                 ,function(){
                    if($.mkv.queryString("LoaiThuocID")!=null && $.mkv.queryString("LoaiThuocID")!="")
                      $("#LoaiThuocID").val($.mkv.queryString("LoaiThuocID"));
                     
                 
                  });
                     //--------------------
                //--------------------
                
         });
          function setControlFind(IdKhoatimkiem) {
              if(IdKhoatimkiem != "" && IdKhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/Yc_PhieuYCTra_ajax1.aspx?do=setTimKiem&idkhoachinh="+IdKhoatimkiem ,dataType:'json'});
              }      
          }
           function Find(control) {
               $(control).TimKiem({
                     ajax:"../ajax/Yc_PhieuYCTra_ajax1.aspx?do=TimKiem"
//                            &tenthuoc="+$("#mkv_IdThuoc").val()
//                            +"&TuNgay="+$("#TuNgay").val()+"&TuGio="+$("#TuGio").val()+"&TuPhut="+$("#TuPhut").val()
//                            +"&DenNgay="+$("#DenNgay").val()+"&DenGio="+$("#DenGio").val()+"&DenPhut="+$("#DenPhut").val()
                ,dataType:'json',showPopup:false
               },function () {
                    $("#tableAjax_Yc_PhieuYCTra").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                    return true;
               },function (data) {
                      var html="";
                      html+="<table class='jtable' id=\"gridTable\">";
                      html+="<tr>";
                      html+="<th>STT</th>";
                      html+="<th></th>";
                      html+="<th>"+ data.TABLE[0].SOPHIEUYC +"</th>";
                      html+="<th>"+ data.TABLE[0].NGAYYC_VIEW +"</th>";
                      html+="<th>"+ data.TABLE[0].IDKHOYC +"</th>";
                      html+="<th>"+ data.TABLE[0].IDKHODUYET +"</th>";
                      html+="<th>"+ data.TABLE[0].IDNGUOIYC +"</th>";
                      html+="<th>"+ data.TABLE[0].IDNGUOIDUYET +"</th>";
                      html+="<th>"+ data.TABLE[0].NGAYDUYET_VIEW +"</th>";
                      //html+="<th>"+ data.TABLE[0].ISDUYETIN +"</th>";
                      html+="<th>"+ data.TABLE[0].ISDUYETTRA +"</th>";
                      html+="<th>ĐỐI TƯỢNG</th>";
                      html+="<th>PHẾU XUẤT</th>";

                      html+="</tr>";
                      html+="</table>";
                      html+="<div id='paging' style='width:100%;height:50px'/>";
                      $("#tableAjax_Yc_PhieuYCTra").html(html);
               }).myfilter({
                     txtfilter:"#gridTable [name=search]",
                     paging:function(json,data){
                           $("#tableAjax_Yc_PhieuYCTra").find("#paging").html(data);
                     },
                     result:function(json,item){
                         var html=[],j=0;
                         for( var i = -1, y = item.length; ++i != y;){ 
                                 html[j++]="<tr>";
                                 html[j++]="<td>" + item[i].STT + "</td>";
                                 html[j++]="<td>"+($.isNullOrEmpty(item[i].IDPHIEUYC)? "":"<a style='cursor:pointer;font-weight:bold;'  onclick=\"ViewDetail('"+item[i].IDPHIEUYC+"')\" >Chi tiết</a>")+"</td>";
                                 html[j++]="<td>" + item[i].SOPHIEUYC + "</td>";
                                 html[j++]="<td>" +  item[i].NGAYYC_VIEW + "</td>";
                                 html[j++]="<td>" + item[i].KHOYEUCAU + "</td>";
                                 html[j++]="<td>" + item[i].KHODUYET + "</td>";
                                 html[j++]="<td>" + item[i].NGUOIYEUCAU + "</td>";
                                 html[j++]="<td>" + item[i].NGUOIDUYET + "</td>";
                                 html[j++]="<td>" + item[i].NGAYDUYET_VIEW + "</td>";
                                 
                                 html[j++]="<td>";
                                 html[j++]="<div ";
                                 if (item[i].ISDUYETTRA == "True"){ html[j++]=" style='width: 50%;' align='center'>";}
                                 else{html[j++]=" style='width: 50%;background-color:#0066FF;' align='center'>";}
                                 html[j++]="<input type='checkbox' disabled='true' " + (item[i].ISDUYETTRA == "True" ? "checked" : "") + "/></div>";
                                 html[j++]="</td>";
                                 
                                 html[j++]="<td>" + item[i].TENLOAI + "</td>";
                                 html[j++]="<td onclick='ViewPhieuXuatKho("+item[i].IDPHIEUXUAT+")' >" + item[i].MAPHIEUXUAT + "</td>";
                                 html[j++]="</tr>";
                         }
                         $("#gridTable").find("tr:gt(0)").empty().remove();
                         $("#gridTable").append($(html.join('')));
                     }
               });
         }
         
          function TenThuocSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/Yc_PhieuYCTra_ajax1.aspx?do=TenThuocSearch&IdKhoa=" + $.mkv.queryString("IdKhoa"), {
                minChars: 0,
                width: 350,
                scroll: true,
                addRow: false,
                header: "<div style =\"width:100%;height:30px\">"
                          + "<div algin='left' style=\"width:15%;color:white;font-weight:bold;float:left; font-size:14px;\" >Mã thuốc/vt</div>"
                          + "<div style=\"width:65%;color:white;font-weight:bold;float:left; font-size:14px; \" >Tên thuốc/vt</div>"
               + "</div>",
                formatItem: function (data) {
                    return data[0];
                }
            }).result(function (event, data) {
                $(obj).val(data[0]);
                $("#" + obj.id.replace("mkv_", "")).val(data[1]);
                setTimeout(function () {
                     obj.focus();
                }, 100);
            });
         }
         
     
        function IdNguoiYcSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/Yc_PhieuYCTra_ajax1.aspx?do=IdNguoiYcSearch",{
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
        function IdNguoiDuyetSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/Yc_PhieuYCTra_ajax1.aspx?do=IdNguoiDuyetSearch",{
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
 function ViewDetail(idkhoachinh)
  {        
        window.open('Yc_PhieuYCTra3.aspx?dkmenu='+  $.mkv.queryString("dkmenu")+"#idkhoachinh="+idkhoachinh+"&IdKhoa=" + $.mkv.queryString("IdKhoa")+"&IsHongVo="+$.mkv.queryString("IsHongVo"), '_blank');
   }
 function ViewPhieuXuatKho(idphieuxuat )
{
    if(idphieuxuat!=null &&idphieuxuat!="")
        window.open('../../QLDuoc/Web/PHIEUXUATKHO3.aspx?dkmenu='+  $.mkv.queryString("dkmenu")+'#idkhoachinh=' + idphieuxuat , '_blank');
}    
function setDefault()
{
    $.BindFind({
        ajax: "../ajax/Yc_PhieuYCTra_ajax1.aspx?do=setDefault"
                + "&IdKhoa=" + $.mkv.queryString("IdKhoa")
                , useEnabled: false
        }, null, function () {
            $("#TuGio").val("00");
            $("#TuPhut").val("00");
            $("#DenGio").val("23");
            $("#DenPhut").val("59");
        }
    ); 
}