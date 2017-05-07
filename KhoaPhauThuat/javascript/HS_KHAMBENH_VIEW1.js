$(document).ready(function() {
   $(".header-div").append("DANH SÁCH BỆNH NHÂN ĐANG THEO DÕI ");
   SetDefaultData();
   setControlFind($.mkv.queryString("idkhoachinh"));
    $("#moi").click(function () {
         $(this).Moi();  
    });
  
    $("#timKiem").click(function () {
        Find(this);
    });
    $("#TuNgay").bind("focus",function(){
        $(this).datepick();
    });
});
function setControlFind(idkhoatimkiem) {
  if(idkhoatimkiem != "" && idkhoatimkiem != null){
     window.open("HS_KHAMBENH_VIEW3.aspx?idkhoachinh="+idkhoatimkiem );
  }      
}
function XemChiTietCongNo(idbenhnhan,idchitietdangkykham)
{
    var dkMenu=$.mkv.queryString("dkMenu");
    var IdKhoa=$.mkv.queryString("IdKhoa");
    window.open("../noitru_BaoCao/nvk_ChiTietCongNoBenhNhan.aspx?dkmenu="+dkMenu+"&idbenhnhan="+idbenhnhan+"&idctdkk="+idchitietdangkykham+"&IdKhoa="+IdKhoa+"&IsShowTamUng=1",'_blank','location=0,menubar=0,statusbar=0,scrollbars=1');
}
function CHITIETDIEUTRI(IDBENHNHAN,DenNgay) {

$.ajax({
        async:false,
        cache:false,
        url:"ajax/HS_KHAMBENH_VIEW_ajax1.aspx?do=CHITIETDIEUTRI&IDBENHNHAN="+IDBENHNHAN
                                                               +"&DenNgay="+DenNgay
                                                               +"&IdKhoa="+$.mkv.queryString("IdKhoa")
                                                               +"&IsAll ="+$.mkv.queryString("IsAll"),
        success:function(data){
                if(data!=null &&data!="")
                {
                         var IsHaveId=data.split('|')[1];
                         if(IsHaveId=="1")
                                window.open("HS_KHAMBENH_VIEW3.aspx?idkhoachinh="+data.split('|')[0] 
                                    +"&LoaiBN="+data.split('|')[2]
                                    +"&idchitietdangkykham="+ data.split('|')[3] 
                                    +"&IDBENHNHAN="+data.split('|')[4]
                                    +"&idkhambenhchuyenphong="+data.split('|')[5]
                                    +""
                                    );
                         else
                                window.open("KhamBenh.aspx?LoaiBN="+data.split('|')[2]
                                    +"&idchitietdangkykham="+ data.split('|')[3] 
                                    +"&IDBENHNHAN="+data.split('|')[4]
                                    +"&idkhambenhchuyenphong="+data.split('|')[5]
                                    +"&disabledCaKipMo=1"
                                            );
                }
             
        }
    }); 
     
}


function Find(control,page) {
    if(page == null) page = "1";
    var IdKhoa=$.mkv.queryString("IdKhoa");
    if(IdKhoa==null) IdKhoa="22";
  $(control).TimKiem({
         ajax:"ajax/HS_KHAMBENH_VIEW_ajax1.aspx?do=TimKiem"
                                                +"&IdKhoa="+IdKhoa
                                                +"&IsAll ="+$.mkv.queryString("IsAll")
                                                +"&page="+page,showPopup:false
                                               
   },function () {
     $("#tableAjax_HS_KHAMBENH_VIEW").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
     return true;
  },function (data) {
         $("#tableAjax_HS_KHAMBENH_VIEW").html(data);
         $("table.jtable tr:nth-child(odd)").addClass("odd");
             $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
             $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
   });
  
}

function SetDefaultData()
 {
    $.BindFind({
        ajax:"ajax/HS_KHAMBENH_VIEW_ajax1.aspx?do=SetDefaultData"
    });
 }