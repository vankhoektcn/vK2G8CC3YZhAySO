// JScript File
var today = new Date();
var dd = today.getDate();
var mm = today.getMonth() + 1;
var yyyy = today.getFullYear();


$(document).ready(function () {
    $("#timKiem").click(function () {
        Find(this);
    });
    $("#Exit").click(function () {
        window.close();
    });
    
     
    setTimeout(function () {
        $("#timKiem").click();
    }, 100);
       SetDefault();
});
 

function Find(control, page) {
    if (page == null) page = "1";
    $(control).TimKiem({
        ajax: "../ajax/frmDSBNKTCDChitiet_ajax.aspx?do=TimKiem&idkhambenh="+$.mkv.queryString("idkhoachinh") + "&page=" + page, showPopup: false
    }, function () {
        $("#tableAjax_DSChoDuyet").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>');
        return true;
    }, function (data) {
        $("#tableAjax_DSTTNoiTru").html(data);
    });
}
function checkAllTrue(obj, id) {
    var table = $(obj).parents("table#gridTable").find("tr:not(:has([id=IsTrue]:[disabled=disabled]))");
    $.each(table, function () {
                                    $(this).find("td").eq(8).find("input[type=checkbox]").attr("checked", $(obj).is(":checked"));
     });
     $("#IsCheckAllCD").attr("checked", $(obj).is(":checked"));
}

 
//───────────────────────────────────────────────────────────────────────────────────────

 
function IsThieuCD_Click(obj,id)
{
   var IsThieuCD= $(obj).is(":checked");
   var idkhambenh= id;
      $.ajax({
            async: false,
            cache: false,
            url: "../ajax/frmDSBNKTCDChitiet_ajax.aspx?do=func_ThieuCD&idkhambenh=" + idkhambenh+"&IsThieuCD="+IsThieuCD,
            success: function (value) {
                if (value.split("|")[0] != null && value.split("|")[0] != "" && value.split("|")[0] == "-1") {
                    $.mkv.myerror(value.split("|")[1]);
                    return;
                } else {
                    $.mkv.myalert(value.split("|")[1], 100, "success");
                    setTimeout(function () {
                    }, 10);
                    return;
                }
            }
        });
}
 

//--------------------------------------------------------------------------------------------------------------------------------------------            
 function SetDefault()
{
      $.BindFind({
        ajax: "../ajax/frmDSBNKTCDChitiet_ajax.aspx?do=SetDefault"
                +"&idkhambenh="+$.mkv.queryString("idkhoachinh")
       , useEnabled: false
    }, null, function () {
                                        if($("#perLuu").val()!="1")
                                            $("#save").css("display","none");
                                        else      
                                            $("#save").css("display","");
        }
    ); 
}


function CheckValid(obj)
{
    var idobj=obj.id;
    var idOther="IsTrue";
    if(obj.id=="IsTrue")
        idOther="IsFalse";
    if($(obj).is(":checked"))
    {
       // $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+idOther).attr("checked", false);
        setCheckIfAllIsCheck(obj);
    }
    else
    {
       // $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+idOther).attr("checked", true);        
        
     $("#IsCheckAllCD").attr("checked",false);     
     $("#chkAllTrue").attr("checked",false);  
    }
}
function setCheckIfAllIsCheck(obj)
{
    var ischeck =true;
    var rowcount= $("#gridTable tr").length;
    for(var i=1; i<rowcount-1;i++)
    {
        if(!$("#gridTable").find("tr").eq(i).find("#IsTrue").is(":checked"))
        {
                ischeck= false;
        }
    }
     $("#IsCheckAllCD").attr("checked",ischeck);     
     $("#chkAllTrue").attr("checked",ischeck);     
}
function SaveKTCD(){
    
     $.ajax({
        async:false,
        cache:true,
        dataType:"text",
        url:"../ajax/frmDSBNKTCDChitiet_ajax.aspx?do=SaveKTCD&idkhoachinh="+$.mkv.queryString("idkhoachinh")
        +"&GhiChuCD="+ $("#GHICHUCD").val()
        +"&IsCheckAllCD="+ $("#IsCheckAllCD").is(":checked")
        ,
        success:function(value){
          if(value=="1"){
             //luu talbe 
             $.LuuTable({
                    ajax: "../ajax/frmDSBNKTCDChitiet_ajax.aspx?do=DuyetLan1" ,
                    tablename: "gridTable"
                },null,function(){                
                    $.mkv.myalert("Lưu ghi chú và tình trạng kiểm tra thành công !",2000,"success");
                });
          }
        },
        error:function(data){
            $.mkv.myerror(""+data);
        }
    });
    }