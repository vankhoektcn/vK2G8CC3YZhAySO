<%@ Page Language="C#" MasterPageFile="~/Master_thuoc.master" AutoEventWireup="true" CodeFile="frm_PhieuYCXuat.aspx.cs" Inherits="frm_PhieuYCXuat" Title="Untitled Page" %>
<%@ Register Src="~/usercontrols/droplist.ascx" TagName="droplist" TagPrefix="uc1" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
 <style type="text/css">
         tr#background:hover
         {
             background-color: #f6ebcd;
             z-index: 1000;
             color: green;
         }
     </style>
     <link type="text/css" rel="stylesheet" href="../js/epoch_styles.css" />
    <script type="text/javascript" src="../js/epoch_classes.js"></script>
     <script type="text/javascript">
              var IdPhieuYC,NgayYC,SoPhieu,idphongkhambenh,ghichu,idloaithuoc;
              var dp_cal1; 
         $(document).ready(function() {
             NgayYC = document.getElementById("<%= NgayYC.ClientID%>");
             dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById("<%= NgayYC.ClientID%>"));	 
             SoPhieu = document.getElementById("SoPhieu");
             idphongkhambenh = document.getElementById(("ctl00_body_droplistidphongkhambenh_idphongkhambenh"));
             idloaithuoc = document.getElementById(("ctl00_body_droplistidloaithuoc_idloaithuoc"));             
             ghichu = document.getElementById("ghichu");
            moveUpandDown("tablefind");
               khoachinhcapnhatdulieu = "idkhoachinh";
               tablegrid="gridTables";
               if(queryString('idkhoachinh') != null && queryString('idkhoachinh') != '')
               {
                    loadTableAjaxThuoc_ChiTietPhieuDaYCXuat("",queryString('idkhoachinh'));
                    XoaControlAfterFind(queryString('idkhoachinh'),'update');
               }
 for (var i = 0; i < document.forms[0].elements.length; i++) {
         if (document.forms[0].elements[i].type == "text")
         {
             if(document.forms[0].elements[i].visible == true || document.forms[0].elements[i].disabled == false)
                { setTimeout("document.forms[0].elements["+i+"].focus()",100);
             return false;}
         }         
      }
         });
         // khởi tạo mã phiếu yêu cầu lĩnh
         function newMaPhieuYCLinh()
         {
            var xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function() 
            {
               if (xmlHttp.readyState == 4)
                 { 
                    var value = xmlHttp.responseText;
                    SoPhieu.value = value;
                 }
            }
             xmlHttp.open("GET", "../ajax/frm_PhieuYCXuat_ajax.aspx?do=NewMaPhieuYCLinhThuoc&times=" + Math.random(), true);
             xmlHttp.send(null);
         }
         // ham set du lieu cho cac control khi lua chon du lieu tim kiem
         function setControlFind(idkhoatimkiem,valueControlSua) {
         //if(idkhoatimkiem != ""){
            var dkMenu=queryString('dkmenu');
            var idkho1=idphongkhambenh.value;
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {                 
                     var value = xmlHttp.responseText.split("@");
                     if(xmlHttp.responseText=='')
                     {
                        newMaPhieuYCLinh();
                        loadTableAjaxThuoc_ChiTietPhieuYCXuat("","");
                        return;
                     }
         NgayYC.value = value[1];
         SoPhieu.value = value[2];
        idphongkhambenh.value = value[3];
         ghichu.value = value[4];
                    setTimeout("setf()",100);
             if(queryString('Update') == null || queryString('Update') == '')
               {
                loadTableAjaxThuoc_ChiTietPhieuYCXuat("",value[0]);
               }
                     //set khoa chinh len querystring va hien nut xoa,sua
                     //alert("XoaControlAfterFind nè="+valueControlSua);
                     //XoaControlAfterFind(value[0],valueControlSua);
                     if(currentRow != null){currentRow=0}
                 }
             }
             xmlHttp.open("GET", "../ajax/frm_PhieuYCXuat_ajax.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem+"&dkMenu="+dkMenu+"&idkho="+idkho1+"&times=" + Math.random(), true);
             xmlHttp.send(null);
//             }
//             else{
//                            loadTableAjaxThuoc_ChiTietPhieuYCXuat('','');
//             }
         }
         //ham tim kiem du lieu theo danh sach ham functionlistcontroltimkiem
         function Find(control, functionlistcontroltimkiem) {
             LoadTimKiem('','',control, functionlistcontroltimkiem, 700, 400, "<%=hsLibrary.clDictionaryDB.sGetValueLanguage("namelabelfind") %> !");
         }
         //tim kiem du lieu voi phim F2,Enter cua cac control
         function ListControlTimKiemNgayYC(control) {
             return "../ajax/frm_PhieuYCXuat_ajax.aspx?do=TimKiem&NgayYC=" + encodeURIComponent(control.value) + "";
         }
         function ListControlTimKiemSoPhieu(control) {
             return "../ajax/frm_PhieuYCXuat_ajax.aspx?do=TimKiem&SoPhieu=" + encodeURIComponent(control.value) + "";
         }
        
         function ListControlTimKiemidphongkhambenh(control) {
             return "../ajax/frm_PhieuYCXuat_ajax.aspx?do=TimKiem&idphongkhambenh=" + encodeURIComponent(control.value) + "";
         }
         function ListControlTimKiemghichu(control) {
             return "../ajax/frm_PhieuYCXuat_ajax.aspx?do=TimKiem&ghichu=" + encodeURIComponent(control.value) + "";
         }
         //tim kiem du lieu cac control khi onclick hoac enter button
         function ListControlTimKiemEnter(control) {
             return "../ajax/frm_PhieuYCXuat_ajax.aspx?do=TimKiem&NgayYC="+ encodeURIComponent(NgayYC.value)+"&SoPhieu="+ encodeURIComponent(SoPhieu.value)+"&ghichu="+ encodeURIComponent(ghichu.value)+""       ;
         }
         //ham lay control de insert du lieu
         function ListControlThem() {
             
             return "../ajax/frm_PhieuYCXuat_ajax.aspx?do=Them&IdKhoYC="+idphongkhambenh.value+"&NgayYC="+ encodeURIComponent(NgayYC.value)+"&SoPhieu="+ encodeURIComponent(SoPhieu.value)+"&idphongkhambenh="+ encodeURIComponent(idphongkhambenh.value)+"&idloaithuoc=" + encodeURIComponent(idloaithuoc.value)+"&ghichu="+ encodeURIComponent(ghichu.value)+""   ;
         }
         //ham lay control de update du lieu
         function ListControlSua() {
             
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             return "../ajax/frm_PhieuYCXuat_ajax.aspx?do=Sua&NgayYC=" + encodeURIComponent(NgayYC.value) + "&SoPhieu=" + encodeURIComponent(SoPhieu.value) + "&idphongkhambenh=" + encodeURIComponent(idphongkhambenh.value)+"&idloaithuoc=" + encodeURIComponent(idloaithuoc.value) + "&ghichu=" + encodeURIComponent(ghichu.value) + "&idkhoachinh=" + idkhoachinh;
         }
         function FunctionLuu(control,valueControlLuu, valueControlSua, ajaxThem, ajaxSua)
         {
            Luu('','luugridtable',control,valueControlLuu, valueControlSua, ajaxThem, ajaxSua);
            control.disabled = false;
         }
 function luugridtable()
         {
            LuuTable("","",row1,"",'ListControlLuuTableThuoc_ChiTietPhieuYCXuat');
         }
         // ham xoa du lieu voi querystring khoa chinh
         function Xoa(control,valueControlLuu) {
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             //xoa du lieu voi idkhoachinh va hien nut luu,an nut xoa,sua
              var hoi = confirm("Xác nhận !");                  if(hoi){             Xoakhoachinh('','loadTableAjaxThuoc_ChiTietPhieuYCXuat',"../ajax/frm_PhieuYCXuat_ajax.aspx?do=xoa&idkhoachinh=" + idkhoachinh,valueControlLuu);
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
                 xmlHttp.open("GET", "../ajax/frm_PhieuYCXuat_ajax.aspx?do=xoaThuoc_ChiTietPhieuYCXuat&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
                 xmlHttp.send(null);
             }
             }
             else{document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);}
              
         }
         function LamMoi(valueControlLuu) {
             // an nut sua,xoa,hien nut luu
             loadTableAjaxThuoc_ChiTietPhieuYCXuat('','');
             Moi(valueControlLuu);
          loaddroplist4();
         }
 function loadTableAjaxThuoc_ChiTietPhieuYCXuat(response,idkhoa)
         {
             if(idkhoa == null)
                 idkhoa = "";
             var idkho1=idphongkhambenh.value;
             var idLoaiThuoc=idloaithuoc.value
             //alert('idLoaiThuoc='+idLoaiThuoc);
             var dkMenu=queryString('dkmenu');
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                         document.getElementById("tableAjax_Thuoc_ChiTietPhieuYCXuat").innerHTML=xmlHttp.responseText;
                    }
             }
             xmlHttp.open("GET", "../ajax/frm_PhieuYCXuat_ajax.aspx?do=loadTableThuoc_ChiTietPhieuYCXuat&dkMenu="+dkMenu+"&idkhoachinh="+idkhoa+"&idkho="+idkho1+"&idloaithuoc="+idLoaiThuoc+"&random=" + Math.random(), true);
             xmlHttp.send(null);
         }
// Load Update Phieu
function loadTableAjaxThuoc_ChiTietPhieuDaYCXuat(response,idkhoa)
         {
             if(idkhoa == null)
                 idkhoa = "";
             var idkho1=idphongkhambenh.value;
             var dkMenu=queryString('dkmenu');
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                         document.getElementById("tableAjax_Thuoc_ChiTietPhieuYCXuat").innerHTML=xmlHttp.responseText;
                    }
             }
             xmlHttp.open("GET", "../ajax/frm_PhieuYCXuat_ajax.aspx?do=loadTableThuoc_ChiTietPhieuYCXuat&Update=1&dkMenu="+dkMenu+"&idkhoachinh="+idkhoa+"&idkho="+idkho1+"&random=" + Math.random(), true);
             xmlHttp.send(null);
         }         

         function loaddroplist4()
         {
             var dkMenu=queryString('dkmenu');
             laydanhsachTodroplist('-- Select one --','','chaysauno',"../ajax/frm_PhieuYCXuat_ajax.aspx?do=droplist_idphongkhambenh&dkMenu="+dkMenu, 'ctl00_body_droplistidphongkhambenh_idphongkhambenh');
         }
         function chaysauno(response){
            setControlFind(queryString("idkhoachinh"),"<%=hsLibrary.clDictionaryDB.sGetValueLanguage("update") %>");
            idphongkhambenh.value = <%=StaticData.MacDinhKhoNhapMuaID %>;
            
         }
         function loaddroplist5()
         {
             laydanhsachTodroplist('-- Select one --','','laythuoc',"../ajax/frm_PhieuYCXuat_ajax.aspx?do=droplist_idloaithuoc", 'ctl00_body_droplistidloaithuoc_idloaithuoc');
         }
          function laythuoc(response){
            
            //idloaithuoc.value = 1;
            
         }
         function ListControlLuuTableThuoc_ChiTietPhieuYCXuat(i)
         {
             var IDthuoc = document.getElementById(tablegrid).rows[i].cells[2].getElementsByTagName("input")[0].value;
             var SoLuong = document.getElementById(tablegrid).rows[i].cells[6].getElementsByTagName("input")[0].value;
             var slxuat = document.getElementById(tablegrid).rows[i].cells[7].getElementsByTagName("input")[0].value;             
             var GhiChu = document.getElementById(tablegrid).rows[i].cells[8].getElementsByTagName("input")[0].value;
             var ListIdChiTietToaThuoc = document.getElementById(tablegrid).rows[document.getElementById(tablegrid).rows.length-1].cells[0].getElementsByTagName("input")[0].value;
             return "../ajax/frm_PhieuYCXuat_ajax.aspx?do=luuTableThuoc_ChiTietPhieuYCXuat&IDthuoc=" + encodeURIComponent(IDthuoc) + "&SoLuong=" + encodeURIComponent(SoLuong) +"&Slxuat=" + encodeURIComponent(slxuat) + "&GhiChu=" + encodeURIComponent(GhiChu)+"&ListIdChiTietToaThuoc="+ListIdChiTietToaThuoc+ "&IdPhieuYC=" + queryString("idkhoachinh") + "";
         }
         var checkchuyenphim = true;
         function timkiemthuoc(obj){
 $(obj).unautocomplete().autocomplete("../ajax/frm_PhieuYCXuat_ajax.aspx?do=getthuoc&loaithuoc="+idloaithuoc.value+"&NgayCT="+NgayYC.value,
        {formatItem: function(data) {
               checkchuyenphim = false; return data[0];
            },width:900,scroll:true}
        )
        
        .result(function(event, data){
        if(document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex + 1].cells[1].getElementsByTagName("a")[0] == null && document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[obj.parentNode.cellIndex].getElementsByTagName("select")[0] == null){
                    themDongTable(tablegrid); 
                }
                document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[4].getElementsByTagName("input")[0].value = data[4];
               document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[2].getElementsByTagName("input")[0].value = data[1];
               document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[3].getElementsByTagName("input")[0].value = data[5];
               document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[5].getElementsByTagName("select")[0].value = data[3];               
	           checkchuyenphim = false; 
	           obj.blur();
	           obj.focus(); 
        });
        }
        
function chuyendong(control){
if(checkchuyenphim == true){
    try{
        if(event.keyCode == 40){
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[1].getElementsByTagName("a")[0] == null && document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[control.parentNode.cellIndex].getElementsByTagName("select")[0] == null){
                    themDongTable(tablegrid); 
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
        if(event.keyCode == 27){
            if(control.type == 'text' || document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[control.parentNode.cellIndex].getElementsByTagName("select")[0] != null)
                chuyenformout(control);
        }
        if(event.keyCode == 13){
            if(control.type == 'text' || document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[control.parentNode.cellIndex].getElementsByTagName("select")[0] != null)
            {
                if(control.style.position=='')
                    chuyenform(control);
                else
                    chuyenformout(control);
            }
       }
    }catch(ex){}
    }
}
function Inphieu()
{
    var idphieu =  queryString("idkhoachinh");
    window.open('frm_PhieuYCXuat_Crpt.aspx?IdPhieuYC='+idphieu,'_blank');
}
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div style="margin-top: 10px; padding: 5px 5px 5px 5px; border: 1px solid #cfcfcf;background: #e9e9e9">
             <div style="padding: 2px 0px 2px 0px; background-color: #4D67A2; border: 1px solid #cfcfcf;
                 text-align: center; color: White; font-size: 20px">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Thuoc_PhieuYCXuat") %>  </div>
             <div style="display: table-row; padding-bottom: 50px">
                 <div style="float: left; padding: 0px 20px 0px 20px; width: 443px;height:40px; border-right: 1px solid #cfcfcf;
                     border-bottom: 1px solid #cfcfcf;">
                     <div style="float: left; padding: 10px 0px 10px 0px">
                         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NgayYC") %>  :</div>
                     <div style="width: 70%; float: right; border-left: 1px solid #cfcfcf; padding: 10px 0px 10px 20px">
                         <input id="NgayYC" runat="server" type="text" onblur="TestDate(this)" onkeyup="Find(this,'ListControlTimKiemNgayYC');chuyenphim(this)" />dd/MM/yyyy</div>
                 </div>
                 <div style="float: left; padding: 0px 20px 0px 20px; width: 443px;height:40px; border-right: 1px solid #cfcfcf;
                     border-bottom: 1px solid #cfcfcf;">
                     <div style="float: left; padding: 10px 0px 10px 0px">
                         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SoPhieu") %>  :</div>
                     <div style="width: 70%; float: right; border-left: 1px solid #cfcfcf; padding: 10px 0px 10px 20px">
                         <input style="width: 250px" id="SoPhieu" type="text"
                             onkeyup="Find(this,'ListControlTimKiemSoPhieu');chuyenphim(this)" /></div>
                 </div>
                
 <div style="float: left; padding: 0px 20px 0px 20px; width: 443px; border-right: 1px solid #cfcfcf;
                     border-bottom: 1px solid #cfcfcf;">
                 <uc1:droplist id="droplistidphongkhambenh" runat="server" id_="idphongkhambenh" onload="loaddroplist4()" onchange="setControlFind('','update');" FindFunction="Find(this,'ListControlTimKiemidphongkhambenh')" title="Kho">
                 </uc1:droplist>
                 </div>
                 
 <div style="float: left; padding: 0px 20px 0px 20px; width: 443px; border-right: 1px solid #cfcfcf;
                     border-bottom: 1px solid #cfcfcf;">
                 <uc1:droplist id="droplistidloaithuoc" runat="server" id_="idloaithuoc" onload="loaddroplist5()"  onchange="setControlFind('','update');" title="Loaithuoc">
                 </uc1:droplist>
                 </div>
                 <div style="float: left; padding: 0px 20px 0px 20px; width: 443px;height:40px; border-right: 1px solid #cfcfcf;
                     border-bottom: 1px solid #cfcfcf;">
                     <div style="float: left; padding: 10px 0px 10px 0px">
                         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") %>  :</div>
                     <div style="width: 70%; float: right; border-left: 1px solid #cfcfcf; padding: 10px 0px 10px 20px">
                         <input style="width: 250px" id="ghichu" type="text"
                             onkeyup="Find(this,'ListControlTimKiemghichu');chuyenphim(this)" /></div>
                 </div>
         </div>
 <div id="tableAjax_Thuoc_ChiTietPhieuYCXuat">
             
         </div>
         </div><div style="border: 1px solid #cfcfcf; background: #e9e9e9; text-align: center;
             padding: 5px 5px 5px 5px;border-Top:none;">
             <!-- voi cac 'xoa','luu','sua' khi onclick la id cua control -->
             <!-- voi cac ListControlThem,ListControlSua,ListControlTimKiemEnter la cac function -->
             <div style=" padding: 10px 0 10px 0;background-color:#cfcfcf;border:1px solid #cfcfcf;">
                 <input style="border:1px solid " id="luu" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " onclick="FunctionLuu(this,'<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> ','<%=hsLibrary.clDictionaryDB.sGetValueLanguage("update") %>','ListControlThem','ListControlSua');"
                      />
                 <input style="border:1px solid " id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" onclick="LamMoi('<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>');"
                      />
                 <input style="border:1px solid;display: none " id="xoa" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" onclick="Xoa(this,'<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>');"
                      />
                 <input style="border:1px solid " id="inphieu" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("inphieu") %>" onclick="Inphieu();"
                      />
                <%-- <input style="border:1px solid " id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" onclick="Find(this,'ListControlTimKiemEnter');"
                      />--%>
             </div>
         </div>
 </asp:Content>

