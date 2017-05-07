$(document).ready(function() {
     $.mkv.moveUpandDown("#tablefind");
     setControlFind($.mkv.queryString("idkhoachinh"),$.mkv.queryString("idbenhnhan"),$.mkv.queryString("ngaydangky"));
     loaddsPhong($.mkv.queryString("idbenhnhan"),$.mkv.queryString("ngaydangky"));
    $("#luu1").click(function(){
        var arrphong="";
        var tablegrid="gridTable";
        for(var i=1;i<document.getElementById(tablegrid).rows.length-1;i++)
        {
           arrphong+=document.getElementById(tablegrid).rows[i].cells[2].getElementsByTagName("input")[0].value + "^" + document.getElementById(tablegrid).rows[i].cells[6].getElementsByTagName("input")[0].value + "@";
        }  
       var LoaiKhamID= null;
        if($("#LoaiKhamID").length){
                LoaiKhamID=$("#LoaiKhamID").val();
         }
         else LoaiKhamID=$.mkv.queryString("LoaiKhamID");
         
        $(this).Luu({
            ajax:"ajax/dangkykham_ajax3.aspx?do=Luu&arrphong=" +arrphong 
            +"&ngaydangky1="+$("#ngaydangky").val()
            +"&giodk1="+$("#giodk").val()
            +"&phutdk1="+$("#phutdk").val()
            +"&giaydk1="+$("#giaydk").val()
            +"&LoaiKhamID="+LoaiKhamID
        },function(){
            return true;
        },function(){
            $.LuuTable({
                  ajax:"ajax/dangkykham_ajax3.aspx?do=luuTablechitietdangkykham&iddangkykham=" 
                        + $.mkv.queryString("idkhoachinh") + "&ngaydangky=" + $("#ngaydangky").val() 
                        +"&idbenhnhan=" + $("#idbenhnhan").val() 
                        +"&idkhoa="+$.mkv.queryString("idkhoa"), 
                 tablename:tablegrid
            },null,function(){
                tinhlaitien_function();
            });
        });
     });
    
    $("#moi").click(function () {
        window.close();
    });
     $("#btnInPhieu").click(function () {
        window.open("../KhamBenh_TH/rptPhieuChiDinh.aspx?iddangkykham=" + $.mkv.queryString("idkhoachinh"),"_blank");
    });
    $("#xoa").click(function () {
       $(this).Xoa({
             ajax:"ajax/dangkykham_ajax3.aspx?do=xoa"
        },null,function () {
             loadTableAjaxchitietdangkykham('');
         });
    });
      $("#dangkyCLS").click(function(){
       
        if($.mkv.queryString("idbenhnhan") ==null || $.mkv.queryString("idbenhnhan") =="")
            return;
        window.open("frmDangKyCLS.aspx?idbenhnhan=" + $.mkv.queryString("idbenhnhan") + "&ngaydangky=" +$("#ngaydangky").val() + "&LoaiBN=" + $("#loai").val()+"&dkMenu=TiepNhan" + "#idbenhnhan=" + $.mkv.queryString("idbenhnhan"),"_blank","location=1,menubar=0,statusbar=1,scrollbars=1");
 });

    $("#timKiem").click(function () {
        Find($(this)); 
     });
});
function setControlFind(idkhoatimkiem,idbenhnhan,ngaydangky) {
  
     $.BindFind({ajax:"ajax/dangkykham_ajax3.aspx?do=setTimKiem&idkhoachinh="
				+idkhoatimkiem+"&idbenhnhan="+idbenhnhan +"&ngaydangky="+ngaydangky  
				+"&LoaiKhamID="+ $.mkv.queryString("LoaiKhamID") + "&IDBENHNHAN_BH=" 
				+ $.mkv.queryString("IDBENHNHAN_BH") + "&SoBH=" + $.mkv.queryString("SoBH"),useEnabled:false  }
        ,null,function () {
             loadTableAjaxchitietdangkykham($.mkv.queryString("idkhoachinh"));                    
               $.mkv.ExtendtionLuu(false, { Frame: "#abc"});  
                    
     });
         
}
function Find(control,page) {
  if(page == null)page = "1";
  $(control).TimKiem({
         ajax:"ajax/dangkykham_ajax3.aspx?do=TimKiem&page="+page
   });
}
function xoaontable(control,bool){
var sttmoi=$(control).parent().parent().index();
if(bool || bool == null)
  $(control).XoaRow({
     ajax:"ajax/dangkykham_ajax3.aspx?do=xoachitietdangkykham"
  });
var row=$("#gridTable").find("tr");
for(var i=sttmoi;i<row.length-1;i++){
    row[i].childNodes[0].innerHTML=i;
}
}
function loaddsPhong(idbenhnhan,ngaydangky)
{
$.ajax({
    async:false,
    cache:false,
    type:"GET",
    dataType:"text",
    url:"ajax/dangkykham_ajax3.aspx?do=loaddsPhong&idbenhnhan="+$.mkv.queryString("idbenhnhan") +"&ngaydangky=" +$.mkv.queryString("ngaydangky") + "&iddangkykham=" + $.mkv.queryString("idkhoachinh"),
    success:function(value){
        $("#dsPhong").append("<span style='color:#18538c; font-weight:bold;'>" +  value + "</span>");
    },
    error:function(value){
        $.mkv.myerror(value);
    }
});
}
function loadTableAjaxchitietdangkykham(idkhoa,page)
{
 if(idkhoa == null) idkhoa = "";
     if(page == null) page = "1";
     $("#tableAjax_chitietdangkykham").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
      $.ajax({
     type:"GET",
     cache:false,
     url:"ajax/dangkykham_ajax3.aspx?do=loadTablechitietdangkykham&iddangkykham="+idkhoa+"&page="+page,
      success: function (value){
             document.getElementById("tableAjax_chitietdangkykham").innerHTML=value;
            $("table.jtable tr:nth-child(odd)").addClass("odd");
             $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
             $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
        }
 });
}
function idbanggiadichvuSearch(obj)
{
 $(obj).unautocomplete().autocomplete("ajax/dangkykham_ajax3.aspx?do=idbanggiadichvuSearch",{
     minChars:0,
     width:350,
     scroll:true,
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
function PhongIDSearch(obj)
{
 $(obj).unautocomplete().autocomplete("ajax/dangkykham_ajax3.aspx?do=PhongIDSearch&IdKhoa=" + $.mkv.queryString("idkhoa"),{
     minChars:0,
     width:350,
     scroll:true,
     addRow:true,
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         if($(obj).parents("#gridTable").attr("id") != null){
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
             $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idbanggiadichvu").val(data[2]);
             
             if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                 $.mkv.themDongTable("gridTable");
         }
         $.get("ajax/dangkykham_ajax3.aspx?do=LaySoTT&PhongID="+data[1]+"&NgayDangKy="+$("#ngaydangky").val()+"&IdBenhNhan="+$("#idbenhnhan").val(),function(data){
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SoTT").val(data);
         });   
             $.get("ajax/dangkykham_ajax3.aspx?do=LaySLBNCho&PhongID="+data[1]+"&NgayDangKy="+$("#ngaydangky").val(),function(data){
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SLBNCho").val(data);
         });
         
         setTimeout(function () {
            $("#gridTable").find("tr").next().eq($(obj).parent().parent().index()).find("#mkv_PhongID").focus();
         },100);
         
     });
}

function idbenhnhanSearch(obj)
{
 $(obj).unautocomplete().autocomplete("ajax/dangkykham_ajax3.aspx?do=idbenhnhanSearch",{
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

function idnguoidungSearch(obj)
{
 $(obj).unautocomplete().autocomplete("ajax/dangkykham_ajax3.aspx?do=idnguoidungSearch",{
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
function huyontablephikham(control,IsDaHuyPhieuThu)
{
if($("#gridTable").find("tr").eq($(control).parent().parent().index()).find("#idbanggiadichvu").val()==""){ 
    $(control).parent().parent().remove();
        return;
}
jConfirm("Bạn đồng ý hủy đăng ký ? ","Xác nhận hủy",function(r){
if(r){
     var stssmoi =$(control).parent().parent().index();
        $.ajax({
            async:false,
            cache:false,
            type:'post',
            url:"ajax/dangkykham_ajax3.aspx?do=HuyDKK&IsDaHuyPhieuThu="+IsDaHuyPhieuThu+"&idchitietdangkykham="+$("#gridTable").find("tr").eq($(control).parent().parent().index()).find("#idkhoachinh").val()  + "&idbanggiadichvu=" + $("#gridTable").find("tr").eq($(control).parent().parent().index()).find("#idbanggiadichvu").val(),
            success:function(data){
                $.mkv.myalert(data,2000,"info");
                    $(control).parent().parent().remove();
            }
        });
        var row=$("#gridTable").find("tr");
        for(var i=stssmoi;i<row.length-1;i++){
            row[i].childNodes[0].innerHTML=i;
        }
    }
});
}

function tinhlaitien_function(){
    if($.mkv.queryString("idkhoachinh") ==null || $.mkv.queryString("idkhoachinh") =="")    return;
     var dadangky=1;
     if($.mkv.queryString("dadangky")!=null && $.mkv.queryString("dadangky")!="")
        dadangky=$.mkv.queryString("dadangky");
      $.ajax({ 
        async:true,
        cache: false,
        url: "ajax/dangkykham_ajax3.aspx?do=tinhlaitien&iddangkykham=" +$.mkv.queryString("idkhoachinh") + "&dadangky=" + dadangky,
        success: function(data) {
                                        $.mkv.myalert(data,1000,"success");
                                        
                                 }
    });

}
function IDBENHNHAN_BHSearch(obj)
{
 $(obj).unautocomplete().autocomplete("ajax/dangkykham_ajax3.aspx?do=IDBENHNHAN_BHSearch" + "&idbenhnhan=" + $.mkv.queryString("idbenhnhan"),{
     minChars:0,
     width:700,
     scroll:true,
     header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:15%;color:white;float:left; font-size:12px;text-align:left; padding-left:5px;\" >Số BHYT </div>"
                    + "<div style=\"width:35%;color:white;float:left;font-size:12px;text-align:left; padding-left:35px;\" >Nơi ĐK KCB</div>"
                    + "<div style=\"width:15%;color:white;float:left;font-size:12px;text-align:left;\" >Ngày bắt đầu</div>"
                    + "<div style=\"width:15%;color:white;float:left;font-size:12px;text-align:left;\" >Ngày hết hạn </div>"
                    + "<div style=\"width:14%;color:white;float:left;font-size:12px;text-align:left;\" >? Đúng tuyến </div>"
             + "</div>",
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
             $(obj).val(data[2]);
             $("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
}
function LoaiKhamIDsearch(obj)
{
     $(obj).unautocomplete().autocomplete("ajax/dangkykham_ajax3.aspx?do=LoaiKhamIDsearch",{
     minChars:0,
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