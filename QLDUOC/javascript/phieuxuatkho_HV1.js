var today=new Date();
var dd=today.getDate();
var MM=today.getMonth() + 1;
var yyyy=today.getFullYear();
if(dd<10) dd='0' + dd;
if(MM<10) MM='0' + MM;
     $(document).ready(function() {
           $("#tungay").val(dd + "/" + MM + "/" + yyyy);
           $("#denngay").val(dd + "/" + MM + "/" + yyyy);
           setControlFind($.mkv.queryString("idkhoachinh"));
           $("#luu").click(function () {
               $(this).Luu({
                  ajax:"../ajax/phieuxuatkho_HV_ajax1.aspx?do=Luu"
                  },null,function () {
                     $("#timKiem").click();
               });
            });
            $("#moi").click(function () {
                 $(this).Moi();  
                     setIdKho();
                  $("#tungay").val(dd + "/" + MM + "/" + yyyy);
                 $("#denngay").val(dd + "/" + MM + "/" + yyyy);
                 
            });
            $("#xoa").click(function () {
                $(this).Xoa({
                    ajax:'../ajax/phieuxuatkho_HV_ajax1.aspx?do=xoa'
                },null,function () {
                     $("#timKiem").click();
                });
            });
            $("#timKiem").click(function () {
                Find(this);
            });
       setIdKho();
            
     });
      function setControlFind(idkhoatimkiem) {
          if(idkhoatimkiem != "" && idkhoatimkiem != null){
             $.BindFind({ajax:"../ajax/phieuxuatkho_HV_ajax1.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem});
                window.open("phieuxuatkho_HV3.aspx#idkhoachinh=" + idkhoatimkiem ,"_blank");
          }      
      }
       function Find(control,page) {
       if(page == null) page = "1";
          $(control).TimKiem({
                 ajax:"../ajax/phieuxuatkho_HV_ajax1.aspx?do=TimKiem&page="+page,showPopup:false
           },function () {
             $("#tableAjax_phieuxuatkho").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
             return true;
          },function (data) {
                 $("#tableAjax_phieuxuatkho").html(data);
           });
          
      }
  function setIdKho()
 {
    $.BindFind({
        ajax:"../ajax/phieuxuatkho_HV_ajax1.aspx?do=setIdKho",useEnabled:false
    },null,function(){
        $("#mkv_idkho").attr("disabled",true);
        $("#ngaythang").val(dd + "/" + MM + "/"  + yyyy);
     });
 }

function idkhoSearch(obj)
{
    $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_HV_ajax1.aspx?do=idkhoSearch"
        +"&idkhoa="+$.mkv.queryString("idkhoa")
        +"&IdKho="+$.mkv.queryString("IdKho")
        ,{
    minChars:0,
    width:250,
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