 <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChiTietPhuCapBacSiPhauThuat1.aspx.cs" Inherits="ChiTietPhuCapBacSiPhauThuat" Title="ChiTietPhuCapBacSiPhauThuat" %>
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
              var flagtemp,idchitietPCBSPT,idloaiphauthuat,idvaitroBSPT,phantramphucap,tienphucap,ghichu;
         $(document).ready(function() {
             idloaiphauthuat = document.getElementById("ctl00_body_idloaiphauthuat_idloaiphauthuat");
             idvaitroBSPT = document.getElementById("ctl00_body_idvaitroBSPT_idvaitroBSPT");
             phantramphucap = document.getElementById("ctl00_body_phantramphucap_phantramphucap");
             tienphucap = document.getElementById("ctl00_body_tienphucap_tienphucap");
             ghichu = document.getElementById("ctl00_body_ghichu_ghichu");
 for (var i = 0; i < document.forms[0].elements.length; i++) {
         if (document.forms[0].elements[i].type == "text")
         {
             if(document.forms[0].elements[i].visible == true || document.forms[0].elements[i].disabled == false)
                { setTimeout("document.forms[0].elements["+i+"].focus()",100);
             return false;}
         }
      }
         });
         //ham nay bat buoc phai co de Xoa,Sua,Timkiem du lieu
         // ham set du lieu cho cac control khi lua chon du lieu tim kiem
         function setControlFind(idkhoatimkiem,valueControlSua) {
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                     var value = xmlHttp.responseText.split("@");
  idloaiphauthuat.value = value[1];
  idvaitroBSPT.value = value[2];
         phantramphucap.value = value[3];
         tienphucap.value = value[4];
         ghichu.value = value[5];
                    setTimeout("setf()",100);
                     //set khoa chinh len querystring va hien nut xoa,sua
                     XoaControlAfterFind(value[0],valueControlSua);
                     if(currentRow != null){currentRow=0}
                 }
             }
             xmlHttp.open("GET", "../ajax/ChiTietPhuCapBacSiPhauThuat_ajax1.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem + "&times=" + Math.random(), true);
             xmlHttp.send(null);
         }
         //ham tim kiem du lieu theo danh sach ham functionlistcontroltimkiem
         function Find(control, functionlistcontroltimkiem) {
 if(event.keyCode == 113){
             document.getElementById("<%=HiddenField1.ClientID %>").value = eval(functionlistcontroltimkiem)(control);
             $("#<%=Button1.ClientID %>").click();
             }
         }
         //tim kiem du lieu voi phim F2,Enter cua cac control
         function ListControlTimKiemidloaiphauthuat(control) {
             return " ct.idloaiphauthuat = '"+control.value+"'";
         }
         function ListControlTimKiemidvaitroBSPT(control) {
             return " ct.idvaitroBSPT = '"+control.value+"'";
         }
         function ListControlTimKiemphantramphucap(control) {
             return " phantramphucap = '"+control.value+"'";
         }
         function ListControlTimKiemtienphucap(control) {
             return " tienphucap = '"+control.value+"'";
         }
         function ListControlTimKiemghichu(control) {
             return " ghichu like N'%"+control.value+"%'";
         }
         //ham lay control de insert du lieu
         function ListControlThem() {
             return "../ajax/ChiTietPhuCapBacSiPhauThuat_ajax1.aspx?do=Them&idloaiphauthuat="+ encodeURIComponent(idloaiphauthuat.value)+"&idvaitroBSPT="+ encodeURIComponent(idvaitroBSPT.value)+"&phantramphucap="+ encodeURIComponent(phantramphucap.value)+"&tienphucap="+ encodeURIComponent(tienphucap.value)+"&ghichu="+ encodeURIComponent(ghichu.value)+""   ;
         }
         //ham lay control de update du lieu
         function ListControlSua() {
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             return "../ajax/ChiTietPhuCapBacSiPhauThuat_ajax1.aspx?do=Sua&idloaiphauthuat=" + encodeURIComponent(idloaiphauthuat.value) + "&idvaitroBSPT=" + encodeURIComponent(idvaitroBSPT.value) + "&phantramphucap=" + encodeURIComponent(phantramphucap.value) + "&tienphucap=" + encodeURIComponent(tienphucap.value) + "&ghichu=" + encodeURIComponent(ghichu.value) + "&idkhoachinh=" + idkhoachinh;
         }
          var controlluuphieunhap = "";
         function FunctionLuu(control,valueControlLuu, valueControlSua, ajaxThem, ajaxSua)
         {
             controlluuphieunhap = control;
            Luu('','',control,valueControlLuu, valueControlSua, ajaxThem, ajaxSua);
         }
         // ham xoa du lieu voi querystring khoa chinh
         function Xoa(control,valueControlLuu) {
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             //xoa du lieu voi idkhoachinh va hien nut luu,an nut xoa,sua
              var hoi = confirm("Xác nhận !");                  if(hoi){             Xoakhoachinh('','',"../ajax/ChiTietPhuCapBacSiPhauThuat_ajax1.aspx?do=xoa&idkhoachinh=" + idkhoachinh,valueControlLuu);
         }}
         function LamMoi(valueControlLuu) {
             // an nut sua,xoa,hien nut luu
             Moi(valueControlLuu);
          loadDropDownListidloaiphauthuat();
          loadDropDownListidvaitroBSPT();
         }
         function loadDropDownListidloaiphauthuat()
         {
            //laydanhsachTodroplist('-- Select one --','','',"../ajax/ChiTietPhuCapBacSiPhauThuat_ajax1.aspx?do=DropDownList_idloaiphauthuat", 'ctl00_body_idloaiphauthuat_idloaiphauthuat');
         }
         function loadDropDownListidvaitroBSPT()
         {
            // laydanhsachTodroplist('-- Select one --','','',"../ajax/ChiTietPhuCapBacSiPhauThuat_ajax1.aspx?do=DropDownList_idvaitroBSPT", 'ctl00_body_idvaitroBSPT_idvaitroBSPT');
         }
 
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
             <div class="shadow" style="margin-top:30px;padding: 2px 0px 2px 0px; background-color: #4473ca; border: 2px solid #cfcfcf;
                 text-align: center; color: White;font-size: 25px;font-weight:bold">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ChiTietPhuCapBacSiPhauThuat")%></div>
     <div style="margin-top: 10px; padding: 5px 5px 5px 5px; border: 1px solid #cfcfcf;background: white">
             <div style="display: table-row; padding-bottom: 50px">
                 <uc1:DropDownList id="idloaiphauthuat" runat="server" ID_DropDownList="idloaiphauthuat" onload="loadDropDownListidloaiphauthuat()" FindFunction="Find(this,'ListControlTimKiemidloaiphauthuat')" Title="idloaiphauthuat" styleTextBox="width:250px">
                 </uc1:DropDownList>
                 <uc1:DropDownList id="idvaitroBSPT" runat="server" ID_DropDownList="idvaitroBSPT" onload="loadDropDownListidvaitroBSPT()" FindFunction="Find(this,'ListControlTimKiemidvaitroBSPT')" Title="idvaitroBSPT" styleTextBox="width:250px">
                 </uc1:DropDownList>
 <uc2:TextBox id="phantramphucap" runat="server" IDTextBox="phantramphucap" onkeyup="Find(this,'ListControlTimKiemphantramphucap');" boolTestSo="true" styleTextBox="width:250px" Title="phantramphucap">
             </uc2:TextBox>
 <uc2:TextBox id="tienphucap" runat="server" IDTextBox="tienphucap" onkeyup="Find(this,'ListControlTimKiemtienphucap');" boolTestSo="true" styleTextBox="width:250px" Title="tienphucap">
             </uc2:TextBox>
 <uc2:TextBox id="ghichu" runat="server" IDTextBox="ghichu" onkeyup="Find(this,'ListControlTimKiemghichu');" styleTextBox="width:250px" Title="ghichu">
             </uc2:TextBox>
         </div></div>
         <div style="border: 1px solid #cfcfcf; background: white; text-align: center;
             padding: 5px 5px 5px 5px;border-Top:none;">
             <!-- voi cac 'xoa','luu','sua' khi onclick la id cua control -->
             <!-- voi cac ListControlThem,ListControlSua,ListControlTimKiemEnter la cac function -->
             <div style=" padding: 10px 0 10px 0;background-color:#fafafa;border-top:1px solid #cfcfcf;">
                 <input  id="luu" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " onclick="FunctionLuu(this,'<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> ','<%=hsLibrary.clDictionaryDB.sGetValueLanguage("update") %>','ListControlThem','ListControlSua');"
                      />
                 <input  id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" onclick="LamMoi('<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>');"
                      />
                 <input  id="xoa" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" onclick="Xoa(this,'<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>');"
                      />
                 <asp:Button UseSubmitBehavior="false" ID="Button1" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("timkiem") %>' OnClick="Button1_Click" />
             </div>
  <div  style="overflow:auto">
             <asp:GridView DataKeyNames="idchitietPCBSPT" ID="gridTable" AllowPaging="True" PageSize="100" OnPageIndexChanging="gridTable_PageIndexChanging" runat="server" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowDataBound="gridTable_RowDataBound" AutoGenerateColumns="False">
    <Columns>
     <asp:TemplateField HeaderText="stt">
                         <ItemTemplate>
                             <%#Eval("stt") %>
                         </ItemTemplate>
        <ItemStyle Width="5%" />
                     </asp:TemplateField>
   <asp:BoundField DataField="TenLoaiPhauThuat" HeaderText="idloaiphauthuat">
       <ItemStyle HorizontalAlign="Left" />
   </asp:BoundField>
   <asp:BoundField DataField="tenvaitro" HeaderText="idvaitroBSPT">
       <ItemStyle HorizontalAlign="Left" />
   </asp:BoundField>
   <asp:BoundField DataField="phantramphucap" HeaderText="phantramphucap" DataFormatString=" {0:N0}">
       <ItemStyle HorizontalAlign="Center" />
   </asp:BoundField>
   <asp:BoundField DataField="tienphucap" HeaderText="tienphucap" DataFormatString=" {0:N0}">
       <ItemStyle HorizontalAlign="Right" />
   </asp:BoundField>
   <asp:BoundField DataField="ghichu" HeaderText="ghichu">
       <ItemStyle HorizontalAlign="Left" />
   </asp:BoundField>
    </Columns>
                 <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                 <RowStyle BackColor="White" ForeColor="Black" />
                 <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                 <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#4473CA" Font-Bold="True" ForeColor="White" />
                 <AlternatingRowStyle BackColor="#CAE3FF" ForeColor="Green"/>
             </asp:GridView>
             <asp:HiddenField ID="HiddenField1" runat="server" />
             <asp:HiddenField ID="HiddenField2" runat="server" />
         </div>
         </div>
 </asp:Content>
