var dataAdapter;
var abc="";
$(document).ready(function(){
   var url = "../ajax/phanquyen_ajax.aspx?do=listnguoidung";
   var source =
    {
        datatype: "json",
        url: url,
        async:true
    };
    var eee = new $.jqx.dataAdapter(source,{
        formatData:function(data){
            data.name_search=$("#ddlNguoiDung").jqxComboBox("searchString");
            return data;
        }
    });
    $("#ddlNguoiDung").jqxComboBox({ 
        selectedIndex:0,
        source: eee, 
        displayMember: "NGUOIDUNG", 
        valueMember: "IDNGUOIDUNG", 
        width: 350, 
        height: 25,
        theme:'classic',
        search:function(searchString){
            eee.dataBind();
        }
    });
   var url = "../ajax/phanquyen_ajax.aspx?do=getListQuyen";
   var source =
    {
        datatype: "json",
        url: url,
        type:'get',
        async:true
    };
    dataAdapter = new $.jqx.dataAdapter(source,{
        formatData:function(data){
            data.permdesc=$("#searchListQuyen").val();
            return data;
        }
    });
    $("#ddlListQuyen").jqxListBox({ 
        source: dataAdapter, 
        displayMember: "permdesc", 
        valueMember: "permid", 
        width: $("#ddlListQuyen").width(), 
        height: 350,
        theme:'classic',
        checkboxes:true
    });
  var me=this;
  $("#searchListQuyen").keyup(function(evt){
      if($(this).val().length>=2){
        if(me.timer)clearInterval(me.timer);
        me.timmer=setTimeout(function(){
            dataAdapter.dataBind();
        },100);
      }
  });
               
    
   $("#ddlNguoiDung").select(function (event) {
        if (event.args) {
            var item = event.args.item;
            if (item) {
               abc=item.value;
                bind_listbox(item.value);
            }
        }
        
  });
  var nextItems,prevItems;
  $("#ddlListQuyen").bind('checkChange', function (event) {
        var items=$("#ddlListQuyen").jqxListBox('getCheckedItems');
        nextItems=new Array();
        nextItems.push(items);
   });
   $("#btnNext").click(function(){
       if(nextItems !="" && nextItems !=null){
            for(var i=0;i<nextItems[0].length;i++){
                var index=nextItems[0][i].index;
                    $("#ddlListQuyen").jqxListBox('removeAt',index);    
                    $("#ddlQuyen").jqxListBox('addItem',nextItems[0][i]);
            }
       }
   });
   $("#ddlQuyen").bind('checkChange', function (event) {
        var items=$("#ddlQuyen").jqxListBox('getCheckedItems');
        prevItems=new Array();
        prevItems.push(items);
   });
   $("#btnPrev").click(function(){
       if(prevItems !="" && prevItems !=null){
            for(var i=0;i<prevItems[0].length;i++){
                var index_prev=prevItems[0][i].index;
                    $("#ddlQuyen").jqxListBox('removeAt',index_prev);    
                    $("#ddlListQuyen").jqxListBox('addItem',prevItems[0][i]);
            }
       }
   });
   $("#chkNextAll, #chkPrevAll").jqxCheckBox();
   $("#chkNextAll").bind("change",function(evt){
        if(evt.args.checked){
            $("#ddlListQuyen").jqxListBox('checkAll');
        }else{
            $("#ddlListQuyen").jqxListBox('uncheckAll');
        }
   });
   $("#chkPrevAll").bind("change",function(evt){
        if(evt.args.checked){
            $("#ddlQuyen").jqxListBox('checkAll');
        }else{
            $("#ddlQuyen").jqxListBox('uncheckAll');
        }
   });
   $("#divButton input[type='button'], #btnSaveQuyen").jqxButton({
        theme:'classic'                        
   });
   $("#btnSaveQuyen").click(function(){
        var items=$("#ddlQuyen").jqxListBox('getItems');
        var item="";
        for(var i=0;i<items.length;i++){
            item+=items[i].value + "@";
        }
        $.ajax({
            async:false,
            url:"../ajax/phanquyen_ajax.aspx",
            data:{
                "do":"saveQuyen",
                userid: abc,
                listquyen:  item
            },
            success:function(value){
                if(value==0){
                    $.mkv.myalert("Đã lưu thành công",2000,"success");
                }else{
                    $.mkv.myerror("Có lỗi trong khi lưu");
                }
            }
        });
   });
  
});
function bind_listbox(value)
{
   
    var aa = "../ajax/phanquyen_ajax.aspx?do=getQuyen&idnguoidung=" + value;
   var source =
    {
        datatype: "json",
        url: aa,
        type:'get',
        async:true
    };
    var ddd = new $.jqx.dataAdapter(source);
    $("#ddlQuyen").jqxListBox({ 
        source: ddd, 
        displayMember: "permdesc", 
        valueMember: "permid", 
        width: $("#ddlQuyen").width(), 
        height: 350,
        theme:'classic',
        checkboxes:true
    });
}