 <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PHIEU_KE_TOAN3.aspx.cs" Inherits="PHIEU_KE_TOAN" Title="PHIEU_KE_TOAN" %>

 <%@ Register Src="Menu_KT/uscmenuKT_TongHop.ascx" TagName="uscmenuKT_TongHop" TagPrefix="uc5" %>
 <%@ Register Src="~/usercontrols/DropDownList.ascx" TagName="DropDownList" TagPrefix="uc1" %>
 <%@ Register Src="~/usercontrols/TextBox.ascx" TagName="TextBox" TagPrefix="uc2" %>
 <%@ Register Src="~/usercontrols/CheckBox.ascx" TagName="CheckBox" TagPrefix="uc3" %>
 <%@ Register Src="~/usercontrols/DateTime.ascx" TagName="DateTime" TagPrefix="uc4" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
 
 <style type="text/css">
         tr#background:hover
         {
             background-color: #f6ebcd;
             z-index: 1000;
             color: green;
         }
     </style>
     <script type="text/javascript">
              var phieuketoanid,so_phieu,ngay_lap;
         $(document).ready(function() {
            //phanquyen();
            so_phieu = document.getElementById("ctl00_body_so_phieu_so_phieu");
            ngay_lap = document.getElementById("ctl00_body_ngay_lap_ngay_lap");
            moveUpandDown("tablefind");
               khoachinhcapnhatdulieu = "idkhoachinh";
               loadTableAjaxPHIEU_KE_TOAN_CT('','');
               tablegrid="gridTables";
         for (var i = 0; i < document.forms[0].elements.length; i++) {
                 if (document.forms[0].elements[i].type == "text")
                 {
                     if(document.forms[0].elements[i].visible == true || document.forms[0].elements[i].disabled == false)
                        { setTimeout("document.forms[0].elements["+i+"].focus()",100);
                     return false;}
                 }
              }
              
         });
         
         // ham set du lieu cho cac control khi lua chon du lieu tim kiem
         function setControlFind(idkhoatimkiem,valueControlSua) {
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                     var value = xmlHttp.responseText.split("@");
         so_phieu.value = value[1];
         ngay_lap.value = value[2];
                    setTimeout("setf()",100);
              loadTableAjaxPHIEU_KE_TOAN_CT("",value[0]);
                     //set khoa chinh len querystring va hien nut xoa,sua
                     XoaControlAfterFind(value[0],valueControlSua);
                     if(currentRow != null){currentRow=0}
                 }
             }
             xmlHttp.open("GET", "../ajax/PHIEU_KE_TOAN_ajax3.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem + "&times=" + Math.random(), true);
             xmlHttp.send(null);
         }
         //ham tim kiem du lieu theo danh sach ham functionlistcontroltimkiem
         function Find(control, functionlistcontroltimkiem) {
             LoadTimKiem('','',control, functionlistcontroltimkiem, 700, 400, "<%=hsLibrary.clDictionaryDB.sGetValueLanguage("namelabelfind") %> !");
         }
         //tim kiem du lieu voi phim F2,Enter cua cac control
         function ListControlTimKiemso_phieu(control) {
             return "../ajax/PHIEU_KE_TOAN_ajax3.aspx?do=TimKiem&so_phieu=" + encodeURIComponent(control.value) + "";
         }
         function ListControlTimKiemngay_lap(control) {
             return "../ajax/PHIEU_KE_TOAN_ajax3.aspx?do=TimKiem&ngay_lap=" + encodeURIComponent(control.value) + "";
         }
         //tim kiem du lieu cac control khi onclick hoac enter button
         function ListControlTimKiemEnter(control) {
             return "../ajax/PHIEU_KE_TOAN_ajax3.aspx?do=TimKiem&so_phieu="+ encodeURIComponent(so_phieu.value)+"&ngay_lap="+ encodeURIComponent(ngay_lap.value)+""       ;
         }
         //ham lay control de insert du lieu
         function ListControlThem() {
             return "../ajax/PHIEU_KE_TOAN_ajax3.aspx?do=Them&so_phieu="+ encodeURIComponent(so_phieu.value)+"&ngay_lap="+ encodeURIComponent(ngay_lap.value)+""   ;
         }
         //ham lay control de update du lieu
         function ListControlSua() {
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             return "../ajax/PHIEU_KE_TOAN_ajax3.aspx?do=Sua&so_phieu=" + encodeURIComponent(so_phieu.value) + "&ngay_lap=" + encodeURIComponent(ngay_lap.value) + "&idkhoachinh=" + idkhoachinh;
         }
          var controlluuphieunhap = "";
         function FunctionLuu(control,valueControlLuu, valueControlSua, ajaxThem, ajaxSua)
         {
             controlluuphieunhap = control;
            Luu('','luugridtable',control,valueControlLuu, valueControlSua, ajaxThem, ajaxSua);
         }
 function luugridtable()
         {
            LuuTable("","",row1,"",'ListControlLuuTablePHIEU_KE_TOAN_CT');
         }
         // ham xoa du lieu voi querystring khoa chinh
         function Xoa(control,valueControlLuu) {
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             //xoa du lieu voi idkhoachinh va hien nut luu,an nut xoa,sua
              var hoi = confirm("Xác nhận !");                  
              if(hoi){ Xoakhoachinh('','loadTableAjaxPHIEU_KE_TOAN_CT',"../ajax/PHIEU_KE_TOAN_ajax3.aspx?do=xoa&idkhoachinh=" + idkhoachinh+"&sophieu="+so_phieu.value,valueControlLuu);
         }}
 function xoaontable(idkhoachinh,control){
             if(idkhoachinh.length > 0){
             var hoi = confirm("Xác nhận !");
             if(hoi){
                 var xmlHttp = GetMSXmlHttp();
                 xmlHttp.onreadystatechange = function() {
                     if (xmlHttp.readyState == 4) {
                         if (xmlHttp.responseText.length > 0) {
                             myalert('Xoá thành công !',2000);
                             document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);
                         }
                         else {
                             alert('Xoá không thành công !');
                         }
                     }
                 }
                 xmlHttp.open("GET", "../ajax/PHIEU_KE_TOAN_ajax3.aspx?do=xoaPHIEU_KE_TOAN_CT&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
                 xmlHttp.send(null);
             }
             }
             else{document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);}              
         }
         function LamMoi(valueControlLuu) {
             // an nut sua,xoa,hien nut luu
             loadTableAjaxPHIEU_KE_TOAN_CT('','');
             Moi(valueControlLuu);
         }
 function loadTableAjaxPHIEU_KE_TOAN_CT(response,idkhoa)
         {
             if(idkhoa == null)
                 idkhoa = "";
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                         document.getElementById("tableAjax_PHIEU_KE_TOAN_CT").innerHTML=xmlHttp.responseText;
                    }
             }
             xmlHttp.open("GET", "../ajax/PHIEU_KE_TOAN_ajax3.aspx?do=loadTablePHIEU_KE_TOAN_CT&idkhoachinh="+idkhoa+"&random=" + Math.random(), true);
             xmlHttp.send(null);
         }
         function ListControlLuuTablePHIEU_KE_TOAN_CT(i)
         {
             var tai_khoan = document.getElementById(tablegrid).rows[i].cells[2].getElementsByTagName("input")[0].value;
             var ma_kh = document.getElementById(tablegrid).rows[i].cells[3].getElementsByTagName("input")[0].value;
             var ten_kh = document.getElementById(tablegrid).rows[i].cells[4].getElementsByTagName("input")[0].value;
             var ps_no = document.getElementById(tablegrid).rows[i].cells[5].getElementsByTagName("input")[0].value;
             var ps_co = document.getElementById(tablegrid).rows[i].cells[6].getElementsByTagName("input")[0].value;
             var dien_giai = document.getElementById(tablegrid).rows[i].cells[7].getElementsByTagName("input")[0].value;
             var thue_xuat = document.getElementById(tablegrid).rows[i].cells[8].getElementsByTagName("input")[0].value;
             return "../ajax/PHIEU_KE_TOAN_ajax3.aspx?do=luuTablePHIEU_KE_TOAN_CT&tai_khoan=" + encodeURIComponent(tai_khoan) + "&ma_kh=" + encodeURIComponent(ma_kh) + "&ten_kh=" + encodeURIComponent(ten_kh) + "&ps_no=" + encodeURIComponent(ps_no) + "&ps_co=" + encodeURIComponent(ps_co) + "&dien_giai=" + encodeURIComponent(dien_giai) + "&thue_xuat=" + encodeURIComponent(thue_xuat) + "&phieuketoanid=" + queryString("idkhoachinh") + "";
         }
var checkchuyenphim=true;         
//show tai khoan ke toan
    function showtaikhoan(obj)
        {            
            $(obj).unautocomplete().autocomplete("../ajax/PHIEU_KE_TOAN_ajax3.aspx?do=gettaikhoan",{
            scroll: true,width:600,formatItem: function(data) {
            checkchuyenphim=false;return data[0]; 
            }                        
            }).result(function(event,data){                    
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[2].getElementsByTagName("input")[0].value=data[1];                                  
            checkchuyenphim = true;                    
            });                             
         }          
//    
    function showkhachhang(obj,kieutimkiem)
        {
            $(obj).unautocomplete().autocomplete("../ajax/PHIEU_KE_TOAN_ajax3.aspx?do=getkhachhang&loai="+kieutimkiem,{
            scroll: true,width:600,formatItem: function(data) {
            checkchuyenphim=false;return data[0]; 
            }                        
            }).result(function(event,data){                    
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[3].getElementsByTagName("input")[0].value=data[1];            
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[4].getElementsByTagName("input")[0].value=data[2];            
            checkchuyenphim = true;  
            themDongTable(tablegrid);                
            });
         }
           // override chuyenphim
           function chuyendong(control){
           if(checkchuyenphim){
    try{
        if(event.keyCode == 40){
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[1].getElementsByTagName("a")[0] == null && document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[control.parentNode.cellIndex].getElementsByTagName("select")[0] == null){
                    themDongTable(); 
                }
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0] != null)
                     document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0].focus();
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0] != null)
                    document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0].focus();
        }
        if(event.keyCode == 38){
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0] != null)
                     document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0].focus();
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0] != null)
                    document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0].focus();  
                
                    var flagrow = false;
                    for(var i = 0;i<document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells.length ;i++)
                    {
                        if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[i].getElementsByTagName('input')[0] != null){
                        if( document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[i].getElementsByTagName('input')[0].type == "text"){
                            if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[i].getElementsByTagName('input')[0].value != '' ){
                            flagrow = true;
                            return;
                          }
                         }
                       }
                    }
                if(flagrow == false && document.getElementById(tablegrid).rows.length > 3 && (document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells.length - 1].getElementsByTagName('input')[0].value.length < 1))
                    document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);
        }        
    }catch(ex){}
    }
    function kiemtra()
    {
        var sophieu=document.getElementById("so_phieu");
        var ngaylap=document.getElementById("ngay_lap");
        if(sophieu.value=="")
        {
            alert("chưa có số phiếu!");
            sophieu.focus();
            return false;
        }
        if(ngaylap.value=="")
        {
            alert("Chưa nhập ngày lập phiếu!");
            ngaylap.focus();
            return false;
        }
        return true;
    }
}    
    function Inphieukt()
    {        
        var SoPhieu = so_phieu.value;
        var NgayLap = ngay_lap.value;        
        if(NgayLap=="")
        {
         alert("Chưa có ngày lập phiếu thu. Vui lòng kiểm tra lại. Cảm ơn!");
        }
        else
        {
         window.open("KTTH_rptInPhieuKT.aspx?so_phieu_thu=" + SoPhieu + "&ngay_thu=" + NgayLap);
        }
    }
// end override       
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div style="margin-top: 10px; padding: 5px 5px 5px 5px; border: 1px solid #cfcfcf;background: white">
         <uc5:uscmenuKT_TongHop ID="UscmenuKT_TongHop1" runat="server" /><div style="padding: 2px 0px 2px 0px; background-color: #0066ff; border: 1px solid #cfcfcf;
                 text-align: center; color: White;font-size: 25px;font-weight:bold">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("PHIEU_KE_TOAN")%></div>
             <div style="display: table-row; padding-bottom: 50px">
 <uc2:TextBox id="so_phieu" runat="server" IDTextBox="so_phieu" onkeyup="Find(this,'ListControlTimKiemso_phieu');" styleTextBox="width:250px" Title="so_phieu">
             </uc2:TextBox>
 <uc4:DateTime id="ngay_lap" runat="server" IDTextBox="ngay_lap" onkeyup="Find(this,'ListControlTimKiemngay_lap');"  Title="ngay_lap" Text_AfterTextBox="(dd\MM\yyyy)">
             </uc4:DateTime>
         </div>
 <div id="tableAjax_PHIEU_KE_TOAN_CT"  style="overflow:auto; height:200px;">             
         </div>
         </div><div style="border: 1px solid #cfcfcf; background: white; text-align: center;
             padding: 5px 5px 5px 5px;border-Top:none;">
             <!-- voi cac 'xoa','luu','sua' khi onclick la id cua control -->
             <!-- voi cac ListControlThem,ListControlSua,ListControlTimKiemEnter la cac function -->
             <div style=" padding: 10px 0 10px 0;background-color:white;border:1px solid #cfcfcf;">
                 <input style="border:1px solid " id="luu" add="<%=StaticData.HavePermision(this, "KeToanTH_PHIEU_KE_TOAN3_Them") %>" edit="<%=StaticData.HavePermision(this, "KeToanTH_PHIEU_KE_TOAN3_Sua") %>"  type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " onclick="FunctionLuu(this,'<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> ','<%=hsLibrary.clDictionaryDB.sGetValueLanguage("update") %>','ListControlThem','ListControlSua');"
                      />
                 <input style="border:1px solid " id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" onclick="LamMoi('<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>');"
                      />
                 <input style="border:1px solid;display: none " delete="<%=StaticData.HavePermision(this, "KeToanTH_PHIEU_KE_TOAN3_Xoa") %>" id="xoa" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" onclick="Xoa(this,'<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>');"
                      />
                 <input style="border:1px solid " id="timKiem"  type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" onclick="Find(this,'ListControlTimKiemEnter');"
                      />
                 <input style="border:1px solid " id="in" type="button" value="In" onclick="Inphieukt();"
                      />
             </div>
         </div>
 </asp:Content>
