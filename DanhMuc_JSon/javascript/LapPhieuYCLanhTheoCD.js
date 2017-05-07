// JScript File
var today = new Date();
var dd = today.getDate();
var mm = today.getMonth() + 1;
var yyyy = today.getFullYear();


$(document).ready(function () {
    $("#timKiem").click(function () {
        FindList(this);
    });
    $("#Exit").click(function () {
        window.close();
    });
    
      $("#new").click(function () {
         window.location.href="LapPhieuYCLanhTheoCD.aspx?dkmenu="+$.mkv.queryString("dkmenu")+"&IdKhoa="+$.mkv.queryString("IdKhoa")+"";
          $("#PrintPhieuYCXuat").css("display","none");
    });
    
    
   setDefault();
   SetDefault2();
   
    
    
     
        $("#IdKhoYc").DropList({ ajax: "../../DanhMuc_JSon/ajax/Yc_PhieuYCXuat_ajax3.aspx?do=IdKhoYcSearch&IdKhoa=" + $.mkv.queryString("IdKhoa")
                 ,defaultVal:"- Chọn kho -" ,async:false}
                 ,null
                 ,function(){
                         { $("#IdKhoYc")[0].selectedIndex=1;}
                
                  });
               
                //--------------------
                 //----------------------
                 $("#IdKhoDuyet").DropList({ ajax: "../../DanhMuc_JSon/ajax/Yc_PhieuYCXuat_ajax3.aspx?do=IdKhoDuyetSearch"
                 ,defaultVal:"- Chọn kho -" ,async:false}
                 ,null
                 ,function(){
                             { $("#IdKhoDuyet")[0].selectedIndex=1;}
                
                 
            });
               
                //--------------------
                 $("#LoaiThuocID").DropList({ ajax: "../../DanhMuc_JSon/ajax/Yc_PhieuYCXuat_ajax3.aspx?do=LoaiThuocIDSearch"
                 ,defaultVal:"- Chọn đối tượng -" ,async:false}
                 ,null
                 ,function(){
                  });
                 //───────────────────────────────────────────────────────────────────────────────────────
                 
                 
     
     
    setTimeout(function () {
            if($.mkv.queryString("IdPhieuYc")!=null && $.mkv.queryString("IdPhieuYc")!="")
                    $("#timKiem").click();
    }, 100);
    
  
    
    
        
       
});
 //───────────────────────────────────────────────────────────────────────────────────────
function bindKho(idkhoa) {
    $("#ddlKho").DropList({ ajax: "../ajax/LapPhieuYCLanhTheoCD_ajax.aspx?do=IdKhoSearch&idkhoa=" + idkhoa, defaultVal: "- Chọn kho -", async: true }, null, function () {
        $("#ddlKho")[0].selectedIndex = 1;
    });
}
//───────────────────────────────────────────────────────────────────────────────────────
function setPermision()
{
    if($("#perLuu").val()!="1")
        $("#save").css("display","none");
    else      
        $("#save").css("display","");
        
    if($("#perXoa").val()!="1")
        $("#delete").css("display","none");
    else      
        $("#delete").css("display","");
        
    if($("#perPint").val()!="1" || $.isNullOrEmpty($("#IdPhieuYc").val()) )
        $("#PrintPhieuYCXuat").css("display","none");
    else      
        $("#PrintPhieuYCXuat").css("display","");
}   
//───────────────────────────────────────────────────────────────────────────────────────
function Find(control, page) {
    
}
//───────────────────────────────────────────────────────────────────────────────────────
function FindList(control, page) {
    if (page == null) page = "1";
    var IdPhieuYc=$("#IdPhieuYc").val();
    if(IdPhieuYc==null ||IdPhieuYc=="")
      IdPhieuYc= $.mkv.queryString("IdPhieuYc");
    if(IdPhieuYc==null || IdPhieuYc=="")
    {  
                if( $("#IdKhoYc").val()=="" ||$("#LoaiThuocID").val()==""  ||$("#TuNgay").val()=="" ||$("#DenNgay").val()==""||$("#NgayDuyet").val()==""||$("#IdKhoDuyet").val()=="")
                {
                    $.mkv.myerror("Chọn Kho, đối tượng, ngày chỉ định trước khi lấy danh sách !");
                    return false;
                }
    }
      
    $(control).TimKiem({
        ajax: "../ajax/LapPhieuYCLanhTheoCD_ajax.aspx?do=TimKiem"
        +"&IdPhieuYc="+IdPhieuYc
        +"&page=" + page
        , showPopup: false
    }, function () {
        $("#tableAjax_LapPhieuYCLanhTheoCD").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>');
        return true;
    }, function (data) {
        $("#tableAjax_LapPhieuYCLanhTheoCD").html(data);
    });
}
//───────────────────────────────────────────────────────────────────────────────────────
function checkAllTrue(obj, id) {
    var table = $(obj).parents("table#gridTable").find("tr:not(:has([id=CHOICE]:[disabled=disabled]))");
    $.each(table, function () {
                                    $(this).find("td").eq(8).find("input[type=checkbox]").attr("checked", $(obj).is(":checked"));
                                    SetValid($(this).find("td").eq(8).find("input[type=checkbox]"));
     });
        Caculate();
}

//───────────────────────────────────────────────────────────────────────────────────────
function SetValid(obj)
{
 var idthuoc0= $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IDTHUOC").val();
   var table = $(obj).parents("table#gridTable").find("tr:not(:has([id=CHOICE]:[disabled=disabled]))");
   var n=0;

    $.each(table, function () {
                                  var  choice =$(this).find("td").find("#CHOICE").is(":checked");
                                  var idthuoc=$(this).find("td").find("#IDTHUOC").val();
                                  var soluongke=$(this).find("td").find("#SOLUONGKE").val();
                                  var tenthuoc=$(this).find("td").find("#TENTHUOC").val();
                                  if(choice==true && idthuoc==idthuoc0)
                                   {
                                        n=n+ eval(soluongke);
                                   }
     });
     $.each(table, function () {
                                  var  choice =$(this).find("td").find("#CHOICE").is(":checked");
                                  var idthuoc=$(this).find("td").find("#IDTHUOC").val();
                                  var soluongke=$(this).find("td").find("#SOLUONGKE").val();
                                  var tenthuoc=$(this).find("td").find("#TENTHUOC").val();
                                   if(tenthuoc !="-" && idthuoc==idthuoc0)
                                    {
                                      
                                     var SLCHOPHEP=eval( $(this).find("td").find("#SLCHOPHEP").val());
                                     if(SLCHOPHEP<n)
                                     {
                                        alert("Tổng số lượng chỉ định "+tenthuoc+" không được vượt quá :"+SLCHOPHEP);
                                         $("#save").css("display","none");
                                         //$(this).find("td").find("#SOLUONGKE").focus();
                                         $(this).css("background-color","yellow");
                                        return false;
                                     }
                                     else
                                        $(this).find("td").find("#TONGSLKE").val(n);
                                         $("#save").css("display","");
                                         $(this).css("background-color","");
                                    }
     });
}
function Caculate()
{
  var table = $("#gridTable").find("tr:not(:has([id=CHOICE]:[disabled=disabled]))");
  var slthuoc=0;
     var idbenhnhanR="";
     $.each(table, function () {
                                  var TONGSLKE=$(this).find("td").find("#TONGSLKE").val();
                                  var  choice =$(this).find("td").find("#CHOICE").is(":checked");
                                   if(eval(TONGSLKE)>0)
                                    {
                                       slthuoc++;
                                    }
                                    
                                  var idbenhnhan=$(this).find("td").find("#idbenhnhan").val();
                                  if(idbenhnhanR.indexOf(idbenhnhan)==-1 && choice==true)
                                      idbenhnhanR=idbenhnhanR+idbenhnhan+";";
                                   
     });
     var rowCount=$("#gridTable tr").length;
     $("#gridTable").find("tr").eq(rowCount-2).find("#tongthuoc").val(slthuoc);
     $("#gridTable").find("tr").eq(rowCount-2).find("#tongbenhnhan").val(idbenhnhanR.split(';').length-1);
}
function CheckValid(obj)
{
     SetValid(obj);
     Caculate();
     
}
//───────────────────────────────────────────────────────────────────────────────────────
function SetValid_TongSLKe(obj)
{
 var IsChoice= $(obj).is(":checked");
 
 var idthuoc0= $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IDTHUOC").val();
   var table = $(obj).parents("table#gridTable").find("tr:not(:has([id=CHOICE]:[disabled=disabled]))");
   var n=0;

    $.each(table, function () {
                                  
                                  var idthuoc=$(this).find("td").find("#IDTHUOC").val();
                                  var soluongke=$(this).find("td").find("#SOLUONGKE").val();
                                  var tenthuoc=$(this).find("td").find("#TENTHUOC").val();
                                  if(idthuoc==idthuoc0)
                                   {
                                       $(this).find("td").find("#CHOICE").attr("checked",IsChoice);
                                       if( IsChoice==true)
                                       {
                                            n=n+ eval(soluongke);
                                       }
                                       else 
                                       {
                                            n=0;
                                       }
                                   }
     });
     $.each(table, function () {
                                  var  choice =$(this).find("td").find("#CHOICE").is(":checked");
                                  var idthuoc=$(this).find("td").find("#IDTHUOC").val();
                                  var soluongke=$(this).find("td").find("#SOLUONGKE").val();
                                  var tenthuoc=$(this).find("td").find("#TENTHUOC").val();
                                   if(tenthuoc !="-" && idthuoc==idthuoc0)
                                    {
                                     var SLCHOPHEP=eval( $(this).find("td").find("#SLCHOPHEP").val());
                                     if(SLCHOPHEP<n)
                                     {
                                        alert("Tổng số lượng chỉ định "+tenthuoc+" không được vượt quá :"+SLCHOPHEP);
                                         $("#save").css("display","none");
                                         //$(this).find("td").find("#SOLUONGKE").focus();
                                         $(this).css("background-color","yellow");
                                        return false;
                                     }
                                     else
                                        $(this).find("td").find("#TONGSLKE").val(n);
                                         $("#save").css("display","");
                                         $(this).css("background-color","");
                                    }
     });
}
function CheckTongSLKe_click(obj)
{
     SetValid_TongSLKe(obj);
     Caculate();
     
}
//───────────────────────────────────────────────────────────────────────────────────────
function CheckValidSaveYc()
{
    if ($("#gridTable").attr("id") == null)
    {
        $.mkv.myerror("Vui lòng 'Lấy DS' chỉ định trước khi lưu !");
        return;
    }
    var rowNumber= $("#gridTable").find("tr").length;
    var isbreak= false;
    for(var i=1;i< rowNumber-2;i++)
    {
        var IDTHUOC=$("#gridTable").find("tr").eq(i).find("#IDTHUOC").val();
        var TONGSLKE=$("#gridTable").find("tr").eq(i).find("#TONGSLKE").val();
        var list="&IDTHUOC="+IDTHUOC+"&TONGSLKE="+TONGSLKE;
        isbreak= false;
        if(eval(TONGSLKE) >0)
        {
            ///
            $.ajax({
                async:false,
                cache:true,
                dataType:"text",
                url:"../ajax/LapPhieuYCLanhTheoCD_ajax.aspx?do=KiemTraTonYC"
                    +"&IdPhieuYc="+$("#IdPhieuYc").val()
                    +"&IdKhoDuyet="+$("#IdKhoDuyet").val()
                    +"&NgayDuyet="+$("#NgayDuyet").val()
                    +"&GioDuyet="+$("#GioDuyet").val()
                    +"&PhutDuyet="+$("#PhutDuyet").val()
                    + list
                ,success:function(value){
                  if(value!=null &&value=="1")
                  {
                  }
                  else
                  {
                    $("#gridTable").find("tr").eq(i).css("background-color","yellow");
                    $.mkv.myerror("'"+$("#gridTable").find("tr").eq(i).find("#TENTHUOC").val()+"' không đủ tồn tồn !");
                    isbreak= true;
                  }
                }
                ,error:function(data){
                    $("#gridTable").find("tr").eq(i).css("background-color","yellow");
                    $.mkv.myerror(data);
                    isbreak= true;
                }
            });
            ///
        }
        if(isbreak)
            break;
    }
    if(!isbreak)
    {
        SavePhieuYCXuat();
    }
}
//─────────────────────────────────────────────────────────────────────────────────────── 
function SavePhieuYCXuat(){
    
     $.ajax({
        async:false,
        cache:true,
        dataType:"text",
        url:"../ajax/LapPhieuYCLanhTheoCD_ajax.aspx?do=SavePhieuYCXuat"
                                                        +"&NgayYc="+$("#NgayYc").val()
                                                        +"&GioYc="+$("#GioYc").val()
                                                        +"&PhutYC="+$("#PhutYC").val()
                                                        +"&IdKhoYc="+$("#IdKhoYc").val()
                                                        +"&LoaiThuocID="+$("#LoaiThuocID").val()
                                                        +"&IdKhoDuyet="+$("#IdKhoDuyet").val()
                                                        +"&NgayDuyet="+$("#NgayDuyet").val()
                                                        +"&GioDuyet="+$("#GioDuyet").val()
                                                        +"&PhutDuyet="+$("#PhutDuyet").val()
                                                        +"&TuNgay="+$("#TuNgay").val()
                                                        +"&TuGio="+$("#TuGio").val()
                                                        +"&TuPhut="+$("#TuPhut").val()
                                                        +"&DenNgay="+$("#DenNgay").val()
                                                        +"&DenGio="+$("#DenGio").val()
                                                        +"&DenPhut="+$("#DenPhut").val()
                                                        +"&IsDuTru="+ $("#IsDuTru").is(":checked")
                                                        +"&IdPhieuYc="+$("#IdPhieuYc").val()
        ,
        success:function(value){
          if(value!=null &&value!=""){
             //luu talbe 
             $.LuuTable({
                    ajax: "../ajax/LapPhieuYCLanhTheoCD_ajax.aspx?do=UpdateChitietChiDinh&IdPhieuYc="+value.split(';')[0] ,
                    tablename: "gridTable"
                },null,function(){                 
                    $.mkv.myalert("Lập phiếu yêu cầu lãnh thành công !",2000,"success");
                     $("#SoPhieuYc").val(value.split(';')[1]);
                     $("#IdPhieuYc").val(value.split(';')[0]);
                     $.mkv.queryString("IdPhieuYc",$("#IdPhieuYc").val());
                     $("#perXoa").val("1");
                     //$("#save").css("display","none");
                     $("#timKiem").css("display","none");
                     setPermision();
                });
          }
        },
        error:function(data){
            $.mkv.myerror(""+data);
        }
    });
    }
//───────────────────────────────────────────────────────────────────────────────────────     
function DeletePhieuYCXuat()
{
    if( $.isNullOrEmpty($("#IdPhieuYc").val()) )
    {
        $.mkv.myerror("Chưa lưu phiếu yêu cầu !");
        return;
    }
    if(!confirm("Bạn thực sự muốn xóa phiếu ?"))
    {
        return
    }
    $.ajax({
        url: "../ajax/LapPhieuYCLanhTheoCD_ajax.aspx?do=XoaPhieuYCXuat"
                                +"&IdPhieuYc="+$("#IdPhieuYc").val(),
        dataType: "text",
        async: false,
        cache: false,
        success: function (data){
            if(data=="1")
            {
                $.mkv.myalert("Đã xóa thành công !",2000,"success");
                setTimeout(function () {
                        window.location.href="LapPhieuYCLanhTheoCD.aspx?dkmenu="+$.mkv.queryString("dkmenu")+"&IdKhoa="+$.mkv.queryString("IdKhoa")+"";
                        }, 3000);
            }
            else
            {
                $.mkv.myerror(data);
            }
        }
    });
}
//───────────────────────────────────────────────────────────────────────────────────────     
function PrintPhieuYCXuat_function()
{
    var IdPhieuYc= $("#IdPhieuYc").val();
    if(IdPhieuYc==null ||IdPhieuYc=="") return false;
    InPhieuYeuCauLanh(IdPhieuYc ,"yc", "print");
}
 //───────────────────────────────────────────────────────────────────────────────────────
   function InPhieuYeuCauLanh(idphieuYC, loaiPhieu, isPrint) {
            if(idphieuYC == null || idphieuYC=="" || idphieuYC=="0")
                return;
            if (isPrint == "print") {
                nvk_InPhieuLinh_Confirm('Chọn bản muốn in?', 'Chọn bản in', function (r) {
                    if (r == "2") {
                        window.open('../../QLDUOC/WEB/rptPhieuYCXuat_new.aspx?IdPhieuYC=' + idphieuYC + "&IsBanSao=0#isPrint=1", '_blank');
                        setTimeout(function () {
                            window.open('../../QLDUOC/WEB/rptPhieuYCXuat_new.aspx?IdPhieuYC=' + idphieuYC + "&IsBanSao=1#isPrint=1", '_blank');
                        }, 15000);
                    }
                    else if (r) {
                        window.open('../../QLDUOC/WEB/rptPhieuYCXuat_new.aspx?IdPhieuYC=' + idphieuYC + "&IsBanSao=1#isPrint=1", '_blank');
                    }
                    else {
                        window.open('../../QLDUOC/WEB/rptPhieuYCXuat_new.aspx?IdPhieuYC=' + idphieuYC + "&IsBanSao=0#isPrint=1", '_blank');
                    }
                });
            }
            else {
                window.open('../../QLDUOC/WEB/rptPhieuYCXuat_new.aspx?IdPhieuYC=' + idphieuYC + "", '_blank');
            }

        }
  //───────────────────────────────────────────────────────────────────────────────────────
function setDefault()
{
 $.BindFind({
        ajax: "../../DanhMuc_JSon/ajax/Yc_PhieuYCXuat_ajax3.aspx?do=setDefault"
                + "&IdKhoa=" + $.mkv.queryString("IdKhoa")
                + "&idkhoachinh=" + $.mkv.queryString("IdPhieuYc")
                , useEnabled: false
    }, null, function () {
                    ///Add Code Here
                    setPermision();                                                        
        }
    ); 
}
//─────────────────────────────────────────────────────────────────────────────────────── 

 function SetDefault2()
{
    if($.mkv.queryString("IdPhieuYc")!=null && $.mkv.queryString("IdPhieuYc")!="")
    {
                      $("#IdPhieuYc").val($.mkv.queryString("IdPhieuYc"));
                      $.BindFind({
                        ajax: "../ajax/LapPhieuYCLanhTheoCD_ajax.aspx?do=SetDefault"
                                +"&IdPhieuYc="+$.mkv.queryString("IdPhieuYc")
                       , useEnabled: true
                    }, null, function () {
                                        setPermision();                                                        
                        }
                    ); 
    }
}
//─────────────────────────────────────────────────────────────────────────────────────── 

function ChangeNgayYc(obj)
{
   $("#TuNgay").val($("#NgayYc").val());
   $("#DenNgay").val($("#NgayYc").val());
}