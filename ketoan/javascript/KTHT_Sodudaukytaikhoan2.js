
         $(document).ready(function() {              
              $('input[id^=luu]').click(function(){
                $(this).Luu({ajax:"ajax/KTHT_Sodudaukytaikhoan_ajax2.aspx?do=luuTable"},null,function(){
                $("#timkiem").click();
                });
             });
                                
             $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"ajax/KTHT_Sodudaukytaikhoan_ajax2.aspx?do=luuTable",tablename:"tableAjax_So_Du_Tk_Dau_Ky"});
             });
             $("#timKiem").click(function () {
                    Find(this);
             });
                                       
         });
         function xoa(control,bool){
            if(bool || bool == null)
              $(control).XoaRow({ajax:'ajax/KTHT_Sodudaukytaikhoan_ajax2.aspx?do=xoa'});
         }
         function Find(control) {                
              $(control).TimKiem({             
                     ajax:"ajax/KTHT_Sodudaukytaikhoan_ajax2.aspx?do=TimKiem",dataType:'json',showPopup:false                    
               },function () {
                     $("#tableAjax_So_Du_Tk_Dau_Ky").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
               },function (data) {
                    var html = "";
                    html+="<div id='paging' style='width:100%;height:50px'/>";
                    html+="<table class='jtable' id=\"gridTable\">";
                    html+="<tr>";
                    html+="<th>STT</th>";
                    html+="<th></th>";
                    html+="<th>Năm</th>";
                    html+="<th>Tài khoản</th>";
                    html+="<th>Dư nợ đầu kì</th>";
                    html+="<th>Dư có đầu kì</th>";
                    html+="<th>Dư nợ đầu kì NT</th>";
                    html+="<th>Dư có đầu kì NT</th>";
                    html+="<th></th>";
                    html+="</tr>";
                    html+="<tr>";
                    html+="<th></th>";
                    html+="<th></th>";
                    
                    html+="<th></th>";
                    html+="</tr>";
                    html+="</table>";
                    html+="<div id='paging' style='width:100%;height:50px'/>";
                    $("#tableAjax_So_Du_Tk_Dau_Ky").html(html);
              }).myfilter({
                   txtfilter:"#gridTable [name=search]",
                   paging:function(json,data){
                        $("#tableAjax_So_Du_Tk_Dau_Ky").find("#paging").html(data);
                   },
                   result:function(json,item){
                        var del = json.TABLE[0].DEL;
                        var edit = json.TABLE[0].EDIT;
                        var add = json.TABLE[0].ADD;
                        var html=[],j=0;
                        for( var i = -1, y = item.length; ++i != y;){ 
                              html[j++]="<tr>";
                              html[j++]="<td>" + item[i].STT + "</td>";
                              html[j++]="<td> <a id=\"xoaRow\" style='color:" + (!del ? "#cfcfcf" : "") + "' onclick=\"xoa(this," + del + ");\">Xoá</a></td>";
                              html[j++]="<td><input mkv='true' id='nam' type='text' value='" + item[i].NAM + "' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id='tai_khoan' type='text' value='" + item[i].TAI_KHOAN + "' onblur='taikhoansearch(this.id)' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id='du_no0' type='text' value='" + item[i].DU_NO0 + "' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id='du_co0' type='text' value='" + item[i].DU_CO0 + "' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id='du_no_nt0' type='text' value='" + item[i].DU_NO_NT0 + "' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id='du_co_nt0' type='text' value='" + item[i].DU_CO_NT0 + "' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                              html[j++]="<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + item[i].SO_DU_TK_ID + "'/></td>";
                              html[j++]="</tr>";
                        }
                        html[j++]="<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
                        $("#gridTable").find("tr:gt(0)").empty().remove();
                        $("#gridTable").append($(html.join('')));
                   }
              });
         }
function taikhoansearch(obj)
 {              
     $("#"+obj).unautocomplete().autocomplete("ajax/ajax.aspx?do=taikhoanSearch",{
        width:400,
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
