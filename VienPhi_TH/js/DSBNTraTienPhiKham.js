$(document).ready(function(){
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    if (dd < 10) { dd = '0' + dd }
    if (mm < 10) { mm = '0' + mm }
    $("#ngaybd").val(dd + "/" + mm + "/" + yyyy);
    $("#LayDS").click(function(){
        $.ajax({
            aysnc:true,
            cache:false,
            dataType:"text",
            type:"GET",
            url:"ajax/DSBNTraTien.ashx?do=loadDSBNPhiKham&ngaybd=" + $("#ngaybd").val() + "&mabenhnhan=" +$("#mabenhnhan").val() + "&tenbenhnhan=" + $("#tenbenhnhan").val(),
            success:function(data){
                $("#tableDSBNPhiKham").html(data);           
            }
        });
    }); 
   $("#LayDS").click();    
     $("#ngaybd").bind("focus",function(){$(this).datepick();});   
});
function HienThiChiTietCLS(control)
{
    var MaPhieu=$("#gridTable").find("tr").eq($(control).parent().parent().index()).find("td").eq(1).html();
    $(control).TimKiem({
        ajax:"ajax/DSBNTraTien.ashx?do=HienThiChiTietPhiKham&MaPhieu=" + MaPhieu,title:"Danh sách phiếu thu - " + MaPhieu, height:"230"
    });
}
function setHoanTraPhiKham(control){
    var lst="";
    $('#gridTablePhiKham tbody tr td:first-child input:checkbox').each(function() {
        if (this.checked) {
            lst+=$(this).attr("id").replace("chk_","") + "@";
        }
    });
    $.ajax({
        async:false,
        cache:false,
        type:"POST",
        url:"ajax/DSBNTraTien.ashx?do=setHoanTraPhiKham&MaPhieu=" + $("#maphieucls").val() + "&lstId="+lst,
        success:function(value){
            $.mkv.myalert(value,2000,"success");
            window.open("frm_rpt_InPhieuThuTH.aspx?MaPhieu=" + $("#maphieucls").val() + "&intructiep=0&IsHoanTra=1","_blank");
            $.mkv.closeDivTimKiem();
            $("#LayDS").click();
        },
        error:function(msg){
            $.mkv.myerror(msg);
        }
    });
}
function checkAllPhiKham(obj) {
    var tablePhiKham = $(obj).parents("table").find("tr");
    for (var i = 0; i < tablePhiKham.length; i++) {
        if ($(obj).is(":checked")) {
            tablePhiKham.eq(i).find("input[type=checkbox]").attr("checked", true);
        } else {
            tablePhiKham.eq(i).find("input[type=checkbox]").attr("checked", false);
        }
    }
}