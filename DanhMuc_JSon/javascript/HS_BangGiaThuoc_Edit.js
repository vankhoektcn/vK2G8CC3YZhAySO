 $(document).ready(function() {
       setControlFind($.mkv.queryString("idkhoachinh"));
       setIdKho();
       $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"../ajax/HS_BangGiaThuoc_Edit_ajax.aspx?do=luuTable",
                tablename:"gridTable",
                isGet:false
            });
        });
        $("#moi").click(function () {
             $(this).Moi();
                setIdKho();
        });
        $("#timKiem").click(function () {
            Find(this);
        });
       
          //───────────────────────────────────────────────────────────────────────────────────────
       $("#btnXuatExel").click(function(){
         var LoaiThuocID = $("#IdLoaiThuoc").val();
         var mkv_LoaiThuocID =  $("#mkv_IdLoaiThuoc").val();
         var tungay = $("#tungay").val();
         var denngay =  $("#denngay").val();
         var IdKho = $("#IDKHO_NHAP").val();
         var TenKho= $("#mkv_IDKHO_NHAP").val();
         if( LoaiThuocID==null ||LoaiThuocID=="" || mkv_LoaiThuocID==null ||mkv_LoaiThuocID==""
             ||  tungay==null ||tungay==""||   denngay==null ||denngay==""
             || IdKho==null ||IdKho=="" 
            )
            {
              $.mkv.myerror(" Vui lòng xác định thông tin : Từ ngày, đến ngày, kho, đối tượng");
              return;
            }
              $.ajax({
                type:"POST",
                url:"../ajax/HS_BangGiaThuoc_Edit_ajax.aspx?do=XuatExcel"
                         +"&LoaiThuocID="+LoaiThuocID
                         +"&tungay="+tungay
                         +"&denngay="+denngay
                         +"&IdKho="+IdKho
                         +"&TenKho="+encodeURIComponent(TenKho)
                         ,
                dataType:"text",
                success:function(data){
                    window.open(data,"_blank");
                }
            });
        });     
       
    //───────────────────────────────────────────────────────────────────────────────────────
 function setIdKho()
 {
    var idkho=$.mkv.queryString("IDKHO_NHAP");
    var IdLoaiThuoc=$.mkv.queryString("IdLoaiThuoc");
    var idkhoa=$.mkv.queryString("idkhoa");
    $.BindFind({
        ajax:"../ajax/HS_BangGiaThuoc_Edit_ajax.aspx?do=setIdKho&idkho="+idkho+"&IdLoaiThuoc="+IdLoaiThuoc
        +"&idkhoa="+idkhoa,useEnabled:false
    },null,function(){
        
    });
 }
 });
  function setControlFind(idkhoatimkiem) {
       
  }
function Find(control,page) {
  $(control).TimKiem({
         ajax:"../ajax/HS_BangGiaThuoc_Edit_ajax.aspx?do=TimKiem",dataType:'json',showPopup:false
   },function () {
         $("#tableAjax_chitietphieunhapkho").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
         return true;
   },function (data) {
        var html = "";
        html+="<table class='jtable' id=\"gridTable\">";
        html+="<tr>";
        html+="<th>STT</th>";
        html+="<th>T.Thuốc/H.C/VT.YT</th>";
        html+="<th>ĐVT</th>";
        html+="<th>Lô.S.Xuất</th>";
        html+="<th>Ngày h.hạn</th>";
        html+="<th>Đ.Giá</th>";
        html+="<th>VAT</th>";
        html+="<th>Đ.Giá ST</th>";
        html+="<th>Ngày nhập</th>";
        html+="<th>Kho nhập</th>";
        html+="<th></th>";
        html+="</tr>";
        html+="</table>";
        html+="<div id='paging' style='width:100%;height:50px'/>";
        $("#tableAjax_chitietphieunhapkho").html(html);
  }).myfilter({
       txtfilter:"#gridTable [name=search]",
       paging:function(json,data){
            $("#tableAjax_chitietphieunhapkho").find("#paging").html(data);
       },
       result:function(json,item){
            var del = json.TABLE[0].DEL;
            var edit = json.TABLE[0].EDIT;
            var add = json.TABLE[0].ADD;
            var html=[],j=0;
            for( var i = -1, y = item.length; ++i != y;){ 
                  html[j++]="<tr>";
                  html[j++]="<td style='width:2%;'>" + (i+1) + "</td>";
                  html[j++]="<td style='text-align:left;width:20%'>" + item[i].TENTHUOC + "</td>";
                  html[j++]="<td style='width:4%'>" + item[i].TENDVT + "</td>";
                  html[j++]="<td style='width:12%'><input mkv='true' id='LOSANXUAT' type='text' value='" + item[i].LOSANXUAT + "' style='width:95%' " + (!edit ? "disabled" : "") + "/></td>";
                  html[j++]="<td style='width:12%'><input mkv='true' id='NGAYHETHAN' type='text' value='" + item[i].NGAYHETHAN + "'onfocus='$(this).datepick();$(this).validDate();' style='width:95%' " + (!edit ? "disabled" : "") + "/></td>";
                  html[j++]="<td style='width:10%'><input mkv='true' id='DONGIA' type='text' value='" + formatCurrency22(item[i].DONGIA) + "' style='width:95%' " + (!edit ? "disabled" : "") + " style='width:95%' onblur='TinhDGST(this);' /></td>";
                  html[j++]="<td style='width:5%'><input mkv='true' id='VAT' type='text' value='" + item[i].VAT + "' style='width:95%' " + (!edit ? "disabled" : "") + "/></td>";
                  html[j++]="<td style='width:10%'><input mkv='true' id='DonGiaView' type='text' value='" + formatCurrency22(item[i].DONGIAVIEW) + "' style='width:95%' " + (!edit ? "disabled" : "") + " onblur='TinhDGTT(this);' /></td>";
                  html[j++]="<td style='width:17%'><input mkv='true' id='NGAYTHANG_NHAP2' type='text' value='" + item[i].NGAYTHANG_NHAP2 + "' style='width:95%' " + (!edit ? "disabled" : "") + "/></td>";
                  html[j++]="<td style='width:15%'><input mkv='true' id='KHONHAP' type='text' value='" + item[i].KHONHAP + "' style='width:95%' " + (!edit ? "disabled" : "") + "/></td>";
                  html[j++]="<td style='width:1%'><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].ID + "'/><input mkv='true' id=\"IDTHUOC\" mkv=\"true\" type=\"hidden\" value='" + item[i].IDTHUOC + "'/><input mkv='true' id=\"IDCHITIETPHIEUNHAPS\" mkv=\"true\" type=\"hidden\" value='" + item[i].IDCHITIETPHIEUNHAPS + "'/></td>";
                  html[j++]="</tr>";
            }
            html[j++]="<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
            $("#gridTable").find("tr:gt(0)").empty().remove();
            $("#gridTable").append($(html.join('')));
       }
  });
  
}
 
function IDTHUOCSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/HS_BangGiaThuoc_Edit_ajax.aspx?do=IDTHUOCSearch&IdLoaiThuoc="+$("#IdLoaiThuoc").val(),{
     minChars:0,
     width:350,
     scroll:true,
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
         $("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 
function IdLoaiThuocSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/HS_BangGiaThuoc_Edit_ajax.aspx?do=IdLoaiThuocSearch",{
     minChars:0,
     width:350,
     scroll:true,
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
         $("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 //───────────────────────────────────────────────────────────────────────────────────────
function idkhoSearch(obj)
 {
      $(obj).unautocomplete().autocomplete("../ajax/HS_BangGiaThuoc_Edit_ajax.aspx?do=idkhoSearch"
        +"&idkhoa="+$.mkv.queryString("idkhoa")
        +"&IdKho="+$.mkv.queryString("IdKho"),{
      minChars:0,
     width:250,
     scroll:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
             $("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 //───────────────────────────────────────────────────────────────────────────────────────
 function TinhDGST(obj)
 {
    var dongia=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#DONGIA").val().replace(/\./g,'').replace(/\,/g,'.'));
    var vat=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#VAT").val().replace(/\./g,'').replace(/\,/g,'.'));
    
    
    var DonGiaView=Math.round((dongia * (vat + 100)/100),0);
    $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#DonGiaView").val(formatCurrency22(DonGiaView));
 }
 //───────────────────────────────────────────────────────────────────────────────────────
 function TinhDGTT(obj)
 {
    var DonGiaView=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#DonGiaView").val().replace(/\./g,'').replace(/\,/g,'.'));
    var vat=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#VAT").val().replace(/\./g,'').replace(/\,/g,'.'));
    var dongia=Math.round((DonGiaView/(vat + 100)*100),0);
    $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#DONGIA").val(formatCurrency22(dongia));
 }
function formatCurrency22(num)
{
    var sodautien= num;
    num = num.toString().replace(/\$|\,/g,'');
    if(isNaN(num))
    num = "0";
    var sign = (num == (num = Math.abs(num)));
    num = Math.floor(num*1000+0.500000000001);
    var nvkSoLe=(num%1000).toString(); 
   if(nvkSoLe.length <2)
        nvkSoLe= "0"+nvkSoLe;    
   if(nvkSoLe.length <3)
        nvkSoLe= "0"+nvkSoLe;
    num = Math.floor(num/1000).toString();
    for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
    {
        num = num.substring(0,num.length-(4*i+3))+'.'+
        num.substring(num.length-(4*i+3));
    }
    return (((sign)?'':'-') + num + "," + nvkSoLe);
}