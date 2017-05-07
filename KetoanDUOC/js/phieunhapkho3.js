$(document).ready(function() {
    
     $.mkv.moveUpandDown("#tablefind");
     setIdKho();
     setControlFind($.mkv.queryString("idkhoachinh"));
     $("#luu").click(function () {
       $(this).Luu({
             ajax:"../ajax/phieunhapkho_ajax3.aspx?do=Luu&TenNhaCungCap="+$("mkv_nhacungcapid").val()+"&tienhang=" + $("#tienhang").val().replace(',','') + "&tienvat=" + $("#tienvat").val().replace(',','') + "&tongtien=" + $("#tongtien").val().replace(',','')
          },null,function () {
               $.LuuTable({
                     ajax:"../ajax/phieunhapkho_ajax3.aspx?do=luuTablechitietphieunhapkho&idphieunhap=" + $.mkv.queryString("idkhoachinh"),
                     tablename:"gridTable"
               });
              $.ajax({
                    async:false,
                    cache:false,
                    url:"../ajax/phieunhapkho_ajax3.aspx?do=GetMaPhieuNhap&IdPhieuNhap=" + $.mkv.queryString("idkhoachinh"),
                    success:function(data){
                        $("#maphieunhap").val(data);
                    }
                }); 
          });
    });
//───────────────────────────────────────────────────────────────────────────────────────
$("#TimMoi").click(function () {
$(this).Moi();                    
loadTableAjaxchitietphieunhapkho('');
});
//───────────────────────────────────────────────────────────────────────────────────────
    $("#moi").click(function () {
         $(this).Moi();                    
         loadTableAjaxchitietphieunhapkho('');
         setIdKho();
    });
//───────────────────────────────────────────────────────────────────────────────────────
    $("#xoa").click(function () {
       $(this).Xoa({
             ajax:"../ajax/phieunhapkho_ajax3.aspx?do=xoa"
        },null,function () {
             loadTableAjaxchitietphieunhapkho('');
         });
    });
//───────────────────────────────────────────────────────────────────────────────────────
    $("#timKiem").click(function () {
        Find($(this)); 
     });
}); //end Document Ready
//───────────────────────────────────────────────────────────────────────────────────────
function setIdKho()
{
$.BindFind({
    ajax:"../ajax/phieunhapkho_ajax3.aspx?do=setIdKho"
});
}
//───────────────────────────────────────────────────────────────────────────────────────
function setControlFind(idkhoatimkiem) {
  if(idkhoatimkiem != "" && idkhoatimkiem != null){
     $.BindFind({ajax:"../ajax/phieunhapkho_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
         loadTableAjaxchitietphieunhapkho($.mkv.queryString("idkhoachinh"));                    
     });
  }else{loadTableAjaxchitietphieunhapkho();}         
}
//───────────────────────────────────────────────────────────────────────────────────────
function Find(control,page) {
  if(page == null)page = "1";
  $(control).TimKiem({
         ajax:"../ajax/phieunhapkho_ajax3.aspx?do=TimKiem&page="+page,"width":"1180px","heigth":"400px","title":"Danh sách phiếu nhập"
   });
}
//───────────────────────────────────────────────────────────────────────────────────────
function xoaontable(control,bool){
if(bool || bool == null)
  $(control).XoaRow({
     ajax:"../ajax/phieunhapkho_ajax3.aspx?do=xoachitietphieunhapkho"
  });
}
//───────────────────────────────────────────────────────────────────────────────────────
function loadTableAjaxchitietphieunhapkho(idkhoa,page)
{
 if(idkhoa == null) idkhoa = "";
     if(page == null) page = "1";
     $("#tableAjax_chitietphieunhapkho").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
      $.ajax({
     type:"GET",
     cache:false,
     url:"../ajax/phieunhapkho_ajax3.aspx?do=loadTablechitietphieunhapkho&idphieunhap="+idkhoa+"&page="+page,
      success: function (value){
             document.getElementById("tableAjax_chitietphieunhapkho").innerHTML=value;
            $("table.jtable tr:nth-child(odd)").addClass("odd");
             $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
             $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
              tinhtongtien();
        }
 });
}
//───────────────────────────────────────────────────────────────────────────────────────
function idthuocSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/phieunhapkho_ajax3.aspx?do=idthuocSearch&loaithuoc="+$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IdLoaiThuoc").val()+"&idkho="+$("#idkho").val()+"&NgayCT="+$("#ngaythang").val(),{
 minChars:0,
 width:750,
 scroll:true,
 header:  "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
            + "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
            + "<div style=\"width:29%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;padding-left:5px;\" >Biệt dược</div>"
            + "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left\" >TT HC</div>"
            + "<div style=\"width:30%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;\" >Hoạt chất</div>"
            + "<div style=\"width:11%;height:30px;color:#000;font-weight:bold;float:left;\" >ĐVT</div>"
            + "<div style=\"width:13%;height:30px;color:#000;font-weight:bold;float:left\" >SLTon </div>"
            + "</div>",
 formatItem:function (data) {
      return data[0];
 }}).result(function(event,data){
     if($(obj).parents("#gridTable").attr("id") != null){
            $(obj).val(data[4]);
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IdDVT_N").val(data[3]);
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_IdDVT_N").val(data[7]);
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#vat").val($("#vat").val());
         if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
             $.mkv.themDongTable("gridTable");
     }
     setTimeout(function () {
         $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#losanxuat").focus();
     },100);
 });
}
//───────────────────────────────────────────────────────────────────────────────────────
function dvtSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/phieunhapkho_ajax3.aspx?do=dvtSearch",{
 minChars:0,
 width:150,
 scroll:true,
 header:false,
 formatItem:function (data) {
      return data[0];
 }}).result(function(event,data){
     if($(obj).parents("#gridTable").attr("id") != null){
         $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
         if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
             $.mkv.themDongTable("gridTable");
     }
     setTimeout(function () {
         obj.focus();
     },100);
 });
}
//───────────────────────────────────────────────────────────────────────────────────────
function IdNuocSX_NSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/phieunhapkho_ajax3.aspx?do=IdNuocSX_NSearch",{
 minChars:0,
 width:150,
 scroll:true,
 header:false,
 formatItem:function (data) {
      return data[0];
 }}).result(function(event,data){
     if($(obj).parents("#gridTable").attr("id") != null){
         $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
         if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
             $.mkv.themDongTable("gridTable");
     }
     setTimeout(function () {
         obj.focus();
     },100);
 });
}
//───────────────────────────────────────────────────────────────────────────────────────
function IdHangSX_NSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/phieunhapkho_ajax3.aspx?do=IdHangSX_NSearch",{
 minChars:0,
 width:150,
 scroll:true,
 header:false,
 formatItem:function (data) {
      return data[0];
 }}).result(function(event,data){
     if($(obj).parents("#gridTable").attr("id") != null){
         $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
         if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
             $.mkv.themDongTable("gridTable");
     }
     setTimeout(function () {
         obj.focus();
     },100);
 });
}
//───────────────────────────────────────────────────────────────────────────────────────
function IdLoaiThuocSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/phieunhapkho_ajax3.aspx?do=IdLoaiThuocSearch",{
 minChars:0,
 width:250,
 scroll:true,
 header:false,
 formatItem:function (data) {
      return data[0];
 }}).result(function(event,data){
     if($(obj).parents("#gridTable").attr("id") != null){
         $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
         if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
             $.mkv.themDongTable("gridTable");
     }
     setTimeout(function () {
         $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idthuoc").focus();
     },100);
 });
}
//───────────────────────────────────────────────────────────────────────────────────────
function idkhoSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/phieunhapkho_ajax3.aspx?do=idkhoSearch",{
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
function nhacungcapidSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/phieunhapkho_ajax3.aspx?do=nhacungcapidSearch",{
 minChars:0,
 width:550,
 scroll:true,
 header:false,
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
function idnguoinhapSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/phieunhapkho_ajax3.aspx?do=idnguoinhapSearch",{
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
function tinhthanhtien(obj)
{
   
   var dongia=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#thanhtientruocthue").val().replace(/\$|\,/g,'')) / eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#Soluong_N").val().replace(/\$|\,/g,''));
   $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#Dongia_N").val(formatCurrency(dongia));
   var tientruocthue = eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#thanhtientruocthue").val().replace(/\$|\,/g,''))
   var thanhtien=tientruocthue*(1-(eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#chietkhau").val().replace(/\$|\,/g,'')))/100);
   var tienthue=thanhtien*eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#vat").val().replace(/\$|\,/g,''))/100;
   var tiensauthue=thanhtien+tienthue;
   $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#ThanhTien").val(formatCurrency(tiensauthue));
   $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#thanhtientruocthue").val(formatCurrency($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#thanhtientruocthue").val()));
   tinhtongtien();
}
function tinhtongtien()
{
    var tablegrid="gridTable";
    var tientruocthue = 0;
    var tiensauthue = 0;
    var tienthue = 0;
    for(var i=1;i<document.getElementById(tablegrid).rows.length-1;i++)
    {
    try{
    if(typeof eval(document.getElementById(tablegrid).rows[i].cells[10].getElementsByTagName("input")[0].value.replace(/\$|\,/g,''))!='undefined')
        tientruocthue += eval(document.getElementById(tablegrid).rows[i].cells[10].getElementsByTagName("input")[0].value.replace(/\$|\,/g,''));
    if(typeof eval(document.getElementById(tablegrid).rows[i].cells[12].getElementsByTagName("input")[0].value.replace(/\$|\,/g,''))!='undefined')
        tiensauthue += eval(document.getElementById(tablegrid).rows[i].cells[12].getElementsByTagName("input")[0].value.replace(/\$|\,/g,''));
  
    }catch(ex){}
    }
    tienthue=tiensauthue-tientruocthue;
    document.getElementById(tablegrid).rows[document.getElementById(tablegrid).rows.length-1].cells[2].getElementsByTagName("input")[0].value= formatCurrency(tientruocthue);
     document.getElementById(tablegrid).rows[document.getElementById(tablegrid).rows.length-1].cells[3].getElementsByTagName("input")[0].value= formatCurrency(tienthue);
    document.getElementById(tablegrid).rows[document.getElementById(tablegrid).rows.length-1].cells[4].getElementsByTagName("input")[0].value = formatCurrency(Math.round(tiensauthue,2));
 
}