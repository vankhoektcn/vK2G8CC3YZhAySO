 $(document).ready(function() {
     $("#timKiem").click(function () {
            Find(this);
     });
     $("#luu1").click(function(){
        $(this).Luu({
            ajax:"ajax/KTHT_CongNo_DauKi_ajax2.aspx?do=luuTable&loai_dt="+$("#loai_dt").val()
        },null,function(){
            $("#timKiem").click();
        });
     });
     $("#luuTable_2").click(function(){
         $(this).LuuTable({ajax:"ajax/KTHT_CongNo_DauKi_ajax2.aspx?do=luuTable",tablename:"tableAjax_CongNo_DauKi"});
     });
 });
 function xoa(control,bool){
    if(bool || bool == null)
      $(control).XoaRow({ajax:'ajax/KTHT_CongNo_DauKi_ajax2.aspx?do=xoa'});
 } 
  function Find(control,page) {
   if(page == null) page = "1";
      $(control).TimKiem({
             ajax:"ajax/KTHT_CongNo_DauKi_ajax2.aspx?do=TimKiem&page="+page,showPopup:false ,keyCode:113  
       },function (){
             $("#tableAjax_CongNo_DauKi").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
             return true;
       },function (data){
                 $("#tableAjax_CongNo_DauKi").html(data);
                 $("table.jtable tr:nth-child(odd)").addClass("odd");
                 $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                 $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
       });              
 }
 function taikhoansearch(obj)
 {              
     $("#"+obj).unautocomplete().autocomplete("ajax/ajax.aspx?do=taikhoanSearch",{
        width:350,
        scroll:true,
        formatItem:function(data)
            {return data[0];}                                                          
        }
    ).result(
    function(event,data)
    {                                                                                                                                
        document.getElementById(obj).value=data[1];
    });
 }
 
 function taikhoansearch1(obj)
 {              
     $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=taikhoanSearch",{
        width:350,
        scroll:true,
        formatItem:function(data)
            {return data[0];}                                                          
        }
    ).result(
    function(event,data)
    {                                                                                                                                
        document.getElementById(obj).value=data[1];
    });
 }
 
  function doituong(obj)
        {               
             $("#"+obj).unautocomplete().autocomplete("ajax/KTHT_CongNo_DauKi_ajax2.aspx?do=doituongsearch&loaidt="+$("#loai_dt").val()+"&Key="+obj.value,{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data){
                  return data[2];
             }}).result(function(event,data){
                 $("#ma_dt").val(data[1]);                 
                 $("#ten_dt").val(data[2]);                                 
             });
        }
         