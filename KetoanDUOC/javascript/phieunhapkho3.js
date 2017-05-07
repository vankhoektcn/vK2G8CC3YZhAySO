$(document).ready(function() {
    
     $.mkv.moveUpandDown("#tablefind");
     setIdKho();
     setControlFind($.mkv.queryString("idkhoachinh"));
     $("#luu").click(function () {
      var idloainhap=$.mkv.queryString("idloainhap");
      if(idloainhap==null ||idloainhap=="")
        idloainhap="1";
      if(idloainhap=="1"){
       $(this).Luu({
             ajax:"../ajax/phieunhapkho_ajax3.aspx?do=Luu&idloainhap="+idloainhap+"&TenNhaCungCap="+$("mkv_nhacungcapid").val()+"&tienhang=" + $("#tienhang").val().replace(',','') + "&tienvat=" + $("#tienvat").val().replace(',','') + "&tongtien=" + $("#tongtien").val().replace(',','')
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
                        luuvaosocai();
                    }
                }); 
          });
         }
         else{
              $(this).Luu({
             ajax:"../ajax/phieunhapkho_ajax3.aspx?do=Luu&idloainhap="+idloainhap+"&TenNhaCungCap="+$("mkv_nhacungcapid").val()
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
         }
    });
    function luuvaosocai()
    {        
                $.ajax({
                    async:false,
                    cache:false,
                    url:"../ajax/phieunhapkho_ajax3.aspx?do=LuuSoCai&idphieunhap=" + $.mkv.queryString("idkhoachinh")+"&maphieunhap="+$("#maphieunhap").val()+"&ngaythang="+$("#ngaythang").val()+"&nhacungcapid="+$("#nhacungcapid").val()+"&sohoadon="+$("#sohoadon").val()+"&ngayhoadon="+$("#ngayhoadon").val()+"&tkco="+$("#tkco").val()+"&tkvat="+$("#tkvat").val()+"&tkck="+$("#tkck").val()+"&thuesuat="+$("#vat").val()+"&ghichu="+encodeURIComponent($("#ghichu").val()),
                    success:function(data){                        
                    }
                }); 
    }
//───────────────────────────────────────────────────────────────────────────────────────
$("#TimMoi").click(function () {
    var mkv_idkho=$("#mkv_idkho").val();
    var idkho=$("#idkho").val();
    $(this).Moi();                    
    loadTableAjaxchitietphieunhapkho('');
    $("#idkho").val(idkho);
    $("#mkv_idkho").val(mkv_idkho);
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
                +"&idkhoa="+$.mkv.queryString("idkhoa")
                +"&IdKho="+$.mkv.queryString("IdKho")
                +"&LoaiThuocID="+$.mkv.queryString("LoaiThuocID")
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
  var idloainhap=$.mkv.queryString("idloainhap");
      if(idloainhap==null ||idloainhap=="")
        idloainhap="1";
        
      var idkho= $.mkv.queryString("IdKho");
      if(idkho!=null &&idkho!="")
      idkho="&idkho="+$.mkv.queryString("IdKho");
        
  if(page == null)page = "1";
  $(control).TimKiem({
         ajax:"../ajax/phieunhapkho_ajax3.aspx?do=TimKiem&idloainhap="+idloainhap+"&page="+page + idkho,"width":"1180px","heigth":"400px","title":"Danh sách phiếu nhập"
   },null,function(data){
        if(data==null || data==""){
            $.mkv.closeDivTimKiem();
        }
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
      var idloainhap=$.mkv.queryString("idloainhap");
      if(idloainhap==null ||idloainhap=="")
        idloainhap="1";
        
 if(idkhoa == null) idkhoa = "";
     if(page == null) page = "1";
     $("#tableAjax_chitietphieunhapkho").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
      $.ajax({
     type:"GET",
     cache:false,
     url:"../ajax/phieunhapkho_ajax3.aspx?do=loadTablechitietphieunhapkho&idloainhap="+idloainhap+"&idphieunhap="+idkhoa
                    +"&LoaiThuocID="+$.mkv.queryString("LoaiThuocID")
                    +"&page="+page,
      success: function (value){
             document.getElementById("tableAjax_chitietphieunhapkho").innerHTML=value;
            $("table.jtable tr:nth-child(odd)").addClass("odd");
             $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
             $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
             {tinhtongtien();}
             //if($.mkv.queryString("idloainhap")=="1"){tinhtongtien();}
        }
 });
}
//───────────────────────────────────────────────────────────────────────────────────────
function idthuocSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/phieunhapkho_ajax3.aspx?do=idthuocSearch&loaithuoc="+$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IdLoaiThuoc").val()+"&idkho="+$("#idkho").val()+"&NgayCT="+$("#ngaythang").val()
                                        +"&LoaiThuocID="+$.mkv.queryString("LoaiThuocID"),{
 minChars:0,
 width:750,
 scroll:true,
 header:  "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
            + "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
            + "<div style=\"width:29%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;padding-left:5px;\" >Tên thuốc/VTYT/HC</div>"
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
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IdDVT_N").val(data[9]);
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_IdDVT_N").val(data[10]);
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#vat").val($("#vat").val());
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SLQuyDoi").val(data[8]);
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#iddvt").val(data[3]);
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_iddvt").val(data[7]);
             
             if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
             $.mkv.themDongTable("gridTable");
     }
     setTimeout(function () {
         $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_IdDVT_N").focus();
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
 $(obj).unautocomplete().autocomplete("../ajax/phieunhapkho_ajax3.aspx?do=IdLoaiThuocSearch"
 +"&LoaiThuocID="+$.mkv.queryString("LoaiThuocID"),{
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
    
 $(obj).unautocomplete().autocomplete("../ajax/phieunhapkho_ajax3.aspx?do=idkhoSearch"
                +"&idkhoa="+$.mkv.queryString("idkhoa")
                +"&IdKho="+$.mkv.queryString("IdKho")
                +"&LoaiThuocID="+$.mkv.queryString("LoaiThuocID"),{
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
 

function QuyDoiDVTChan(obj)
{
   
   var SLQuyDoi=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SLQuyDoi").val().replace(/\$|\,/g,''));
   var Soluong_N=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#Soluong_N").val().replace(/\$|\,/g,''));
   var Dongia_N=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#Dongia_N").val().replace(/\$|\,/g,''));
   if(Dongia_N=="") Dongia_N=0;
   var Soluong =SLQuyDoi* Soluong_N;
   var Dongia= Dongia_N/SLQuyDoi;
   $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#Soluong").val(formatCurrency(Soluong));
   $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#Dongia").val(formatCurrency(Dongia));
    
}

function QuyDoiDVTLe(obj)
{
   
   var SLQuyDoi=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SLQuyDoi").val().replace(/\$|\,/g,''));
   var Soluong=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#Soluong").val().replace(/\$|\,/g,''));
   var Dongia=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#Dongia").val().replace(/\$|\,/g,''));
   if(Dongia=="")Dongia=0;
   var Soluong_N =Soluong/SLQuyDoi;
   var Dongia_N= Dongia*SLQuyDoi;
   $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#Soluong_N").val(formatCurrency(Soluong_N));
   $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#Dongia_N").val(formatCurrency(Dongia_N));
    
}


//function tinhtongtien()
//{
//    var tablegrid="gridTable";
//    var tientruocthue = 0;
//    var tiensauthue = 0;
//    var tienthue = 0;
//    for(var i=1;i<document.getElementById(tablegrid).rows.length-1;i++)
//    {
//    try{
//      if(typeof eval(document.getElementById(tablegrid).rows[i].cells[9].getElementsByTagName("input")[0].value.replace(/\$|\,/g,''))!='undefined')
//      {
//       var i_tientruocthue=eval(document.getElementById(tablegrid).rows[i].cells[9].getElementsByTagName("input")[0].value.replace(/\$|\,/g,''))*eval(document.getElementById(tablegrid).rows[i].cells[10].getElementsByTagName("input")[0].value.replace(/\$|\,/g,''));
//        tientruocthue +=i_tientruocthue; 
//       
//      if(typeof eval(document.getElementById(tablegrid).rows[i].cells[16].getElementsByTagName("input")[0].value.replace(/\$|\,/g,''))!='undefined')
//      {
//        var  i_tienthue=i_tientruocthue*eval(document.getElementById(tablegrid).rows[i].cells[16].getElementsByTagName("input")[0].value.replace(/\$|\,/g,''))
//        i_tienthue=i_tienthue/100;
//        tiensauthue +=i_tientruocthue+ i_tienthue;
//      }
//      }
//  
//    }catch(ex){}
//    }
//    tienthue=tiensauthue-tientruocthue;
//    document.getElementById(tablegrid).rows[document.getElementById(tablegrid).rows.length-1].cells[2].getElementsByTagName("input")[0].value= formatCurrency(tientruocthue);
//    document.getElementById(tablegrid).rows[document.getElementById(tablegrid).rows.length-1].cells[3].getElementsByTagName("input")[0].value= formatCurrency(tienthue);
//    document.getElementById(tablegrid).rows[document.getElementById(tablegrid).rows.length-1].cells[4].getElementsByTagName("input")[0].value = formatCurrency(Math.round(tiensauthue,2));
// 
//}
function tinhtongtien()
{
    var tablegrid="gridTable";
    var tiensauthuetp;
    var tientruocthuetp;
    var tientruocthue = 0;
    var tiensauthue = 0;
    var phannguyen=0;
    var tienthue = 0;
    var value;
    var value2;
    for(var i=1;i<document.getElementById(tablegrid).rows.length-1;i++)
    {
    try{
    if(typeof eval(document.getElementById(tablegrid).rows[i].cells[12].getElementsByTagName("input")[0].value.replace(/\$|\./g,''))!='undefined')
    {
        tientruocthuetp = document.getElementById(tablegrid).rows[i].cells[12].getElementsByTagName("input")[0].value.replace(/\$|\./g,'');
        value2=tientruocthuetp.replace(/\$|\,/g,'.');
        tientruocthue += eval(value2);        
    }
    if(typeof eval(document.getElementById(tablegrid).rows[i].cells[14].getElementsByTagName("input")[0].value.replace(/\$|\./g,''))!='undefined')
    {
        tiensauthuetp= document.getElementById(tablegrid).rows[i].cells[14].getElementsByTagName("input")[0].value.replace(/\$|\./g,'');  
        value=tiensauthuetp.replace(/\$|\,/g,'.');
        tiensauthue += eval(value);
    }
    }catch(ex){}
    }
    tienthue=Math.round(tiensauthue-tientruocthue,2);
    document.getElementById(tablegrid).rows[document.getElementById(tablegrid).rows.length-1].cells[2].getElementsByTagName("input")[0].value= formatCurrency2(Math.round(tientruocthue,2));
    document.getElementById(tablegrid).rows[document.getElementById(tablegrid).rows.length-1].cells[3].getElementsByTagName("input")[0].value= formatCurrency2(tienthue);
    document.getElementById(tablegrid).rows[document.getElementById(tablegrid).rows.length-1].cells[4].getElementsByTagName("input")[0].value = formatCurrency2(Math.round(tiensauthue,2)); 
}
function checkHSD(obj){
    var value=$(obj).val().split('/');
    var d=value[0];
    var m=value[1];
    var y=value[2];
    var date=new Date(y,m,d);
    var today=new Date();
    var sonam=date.getFullYear()-today.getFullYear();
    var thangsd=date.getMonth();
    var thanght=today.getMonth()+1;
    var sothangconlai=sonam*12 + (thangsd-thanght);
    if(sothangconlai<9){
        $.mkv.myalert("Sắp hết hạn sử dụng.",2000,"info");
    }
}
function CheckExistThuoc(obj){
    if($(obj).val()=="") return false;
    var idthuoc= $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val();
    if(idthuoc==null || idthuoc==""){
        $.mkv.myalert("Thuốc không tồn tại, phần mềm sẽ tự lưu thuốc này vào danh mục thuốc!",2000,"info");
    }
    else
    {    
        $.ajax({
                async:false,
                cache:false,
                url:"../ajax/phieunhapkho_ajax3.aspx?do=SetNuocSX&idthuoc=" + idthuoc,
                success:function(data){
                    if(data!="")
                    {
                        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IdNuocSX_N").val(data.split('|')[0]);
                        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_IdNuocSX_N").val(data.split('|')[1]);
                        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IdHangSX_N").val(data.split('|')[2]);
                        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_IdHangSX_N").val(data.split('|')[3]);
                    }
                }
            });
    
    }
    
}
function tknoSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=tkkhoSearch",{
     minChars:0,
     width:390,
     scroll:true,
     header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:20%;color:white;float:left; font-size:12px;text-algin:left;\" >Tài khoản</div>"
                      + "<div style=\"width:80%;color:white;float:left;font-size:12px;\" >Tên tài khoản</div>"
                  + "</div>",
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
             $("#"+obj.id.replace("mkv_","")).val(data[1]);
                $(this).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 
 function tkcoSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=tkkhoSearch",{
     minChars:0,
     width:390,
     scroll:true,
     header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:20%;color:white;float:left; font-size:12px;text-algin:left;\" >Tài khoản</div>"
                      + "<div style=\"width:80%;color:white;float:left;font-size:12px;\" >Tên tài khoản</div>"
                  + "</div>",
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
             $("#"+obj.id.replace("mkv_","")).val(data[1]);
                $(this).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 
 function tkvatSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=tkkhoSearch",{
     minChars:0,
     width:390,
     scroll:true,
     header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:20%;color:white;float:left; font-size:12px;text-algin:left;\" >Tài khoản</div>"
                      + "<div style=\"width:80%;color:white;float:left;font-size:12px;\" >Tên tài khoản</div>"
                  + "</div>",
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
             $("#"+obj.id.replace("mkv_","")).val(data[1]);
                $(this).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 
 function tknoSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=tkkhoSearch",{
     minChars:0,
     width:390,
     scroll:true,
     header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:20%;color:white;float:left; font-size:12px;text-algin:left;\" >Tài khoản</div>"
                      + "<div style=\"width:80%;color:white;float:left;font-size:12px;\" >Tên tài khoản</div>"
                  + "</div>",
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
             $("#"+obj.id.replace("mkv_","")).val(data[1]);
                $(this).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 
 function tkckSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=tkkhoSearch",{
     minChars:0,
     width:390,
     scroll:true,
     header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:20%;color:white;float:left; font-size:12px;text-algin:left;\" >Tài khoản</div>"
                      + "<div style=\"width:80%;color:white;float:left;font-size:12px;\" >Tên tài khoản</div>"
                  + "</div>",
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
             $("#"+obj.id.replace("mkv_","")).val(data[1]);
                $(this).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 
 function InPhieuNhap()
        {   
             if(queryString("idkhoachinh") != "")
            {
            window.open("rptPhieuNhapKho_In.aspx?idphieunhap="+$.mkv.queryString("idkhoachinh")+"&LoaiNhap=1");
            }
                 
        }