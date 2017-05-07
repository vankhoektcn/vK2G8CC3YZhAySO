
 $(document).ready(function() {
    phanquyen();
     $("#luu1").click(function(){
        $(this).Luu({
            ajax:"ajax/KTTSCD_DanhMucTSCD_ajax.aspx?do=luuTable"},null,function(){
                $("#timKiem").click();
            });
     });
     $("#timKiem").click(function () {
            Find(this);
     });
     
 });
 function phanquyen()
 {
    if($("#quyenthem").val() == 'False')
        document.getElementById('luuTable_2').disabled=true;
    else
        document.getElementById('luuTable_2').disabled=false;            
 }
 function xoa(control){
      $(control).XoaRow({ajax:'ajax/KTTSCD_DanhMucTSCD_ajax.aspx?do=xoa'});
 }
  function Find(control,page) {
   if(page == null) page = "1";
      $(control).TimKiem({             
             ajax:"ajax/KTTSCD_DanhMucTSCD_ajax.aspx?do=TimKiem&page="+page,showPopup:false
       },function(){
              $("#tableAjax_DanhMucTaiSan").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                return true;
       },function (data) {
                 $("#tableAjax_DanhMucTaiSan").html(data);
                 $("table.jtable tr:nth-child(odd)").addClass("odd");
                 $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                 $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
       });              
 }
 function ShowTaiKhoan1(obj)
{
    //var objsrc = document.getElementById(obj.id);  
    $(obj).unautocomplete().autocomplete("ajax/KTTSCD_DanhMucTSCD_ajax.aspx?do=DanhSachTaiKhoan_Jquery&Key="+obj.value+"&obj="+obj.id,
                                                {width:350,scroll:true,formatItem:function(data)
                                                    {return data[1];}
                                                }
                                            ).result(
                function(event,data)
                {
                    $("#tableAjax_DanhMucTaiSan").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[2]);	                        
                }
                );           
     
}
function khoSearch(obj)
{
    $(obj).unautocomplete().autocomplete("ajax/KTTSCD_DanhMucTSCD_ajax.aspx?do=khoSearch&Key="+obj.value+"&obj="+obj.id,
                                                {width:350,scroll:true,formatItem:function(data)
                                                    {return data[1];}
                                                }
                                            ).result(
                function(event,data)
                {
                    $("#tableAjax_DanhMucTaiSan").find("tr").eq($(obj).parent().parent().index()).find("#idkho").val(data[0]);
                    $("#tableAjax_DanhMucTaiSan").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idkho").val(data[1]);
                }
                );           
     
}
function khoSearch1(obj)
{
    $(obj).unautocomplete().autocomplete("ajax/KTTSCD_DanhMucTSCD_ajax.aspx?do=khoSearch&Key="+obj.value+"&obj="+obj.id,
                                                {width:350,scroll:true,formatItem:function(data)
                                                    {return data[1];}
                                                }
                                            ).result(
                function(event,data)
                {
                    $("#idkho").val(data[0]);
                    $("#mkv_idkho").val(data[1]);
                }
                );           
     
}
function setControlFind(idkhoatimkiem) {
      if(idkhoatimkiem != "" && idkhoatimkiem != null){
         $.BindFind({ajax:"ajax/KTTSCD_DanhMucTSCD_ajax.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem});
      }      
  }