$(document).ready(function(){
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    if (dd < 10) { dd = '0' + dd }
    if (mm < 10) { mm = '0' + mm }
    $("#tungay").val(dd + "/" + mm + "/" + yyyy);
    $("#denngay").val(dd + "/" + mm + "/" + yyyy);
    $("#tungay").bind("focus",function(){
        $(this).datepick();
    });
    $("#nguoidung").DropList({ ajax: "ajax/ThongKeDoanhThu.ashx?do=idnguoidungsearch",async:false},null,null);
    $("#btnLayDS").click(function(){
        $.ajax({
            async:true,
            cache:false,
            type:"GET",
            dataType:"text",
            url:"ajax/ThongKeDoanhThu.ashx?do=getDoanhThu&tungay="+$("#tungay").val()+"&denngay="+ $("#denngay").val() + "&idnguoidung=" + $("#nguoidung").val()+ "&tennguoidung="+encodeURIComponent($("#nguoidung option:selected").text()),
            success:function(data){
                $("#tableAjax_ThongKeDoanhThu").html(data);
            }
        });
    });
    $("#btnExport").click(function(){
        $.ajax({
            async:true,
            cache:false,
            type:"GET",
            dataType:"text",
            url:"ajax/ThongKeDoanhThu.ashx?do=ExportExcel&tungay="+$("#tungay").val()+"&denngay="+ $("#denngay").val() + "&idnguoidung=" + $("#nguoidung").val()+ "&tennguoidung="+encodeURIComponent($("#nguoidung option:selected").text()),
            success:function(data){
                window.open(data,"_blank");
            }
        });
    });
});