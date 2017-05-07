 <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VaiTroBSPhauThuat1.aspx.cs" Inherits="VaiTroBSPhauThuat" Title="VaiTroBSPhauThuat" %>
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
              var flagtemp,idVaiTroBS,tenvaitro,idekipmo,GhiChu;
         $(document).ready(function() {
             tenvaitro = document.getElementById("ctl00_body_tenvaitro_tenvaitro");
             idekipmo = document.getElementById("ctl00_body_idekipmo_idekipmo");
             GhiChu = document.getElementById("ctl00_body_GhiChu_GhiChu");
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
         tenvaitro.value = value[1];
  idekipmo.value = value[2];
         GhiChu.value = value[3];
                    setTimeout("setf()",100);
                     //set khoa chinh len querystring va hien nut xoa,sua
                     XoaControlAfterFind(value[0],valueControlSua);
                     if(currentRow != null){currentRow=0}
                 }
             }
             xmlHttp.open("GET", "../ajax/VaiTroBSPhauThuat_ajax1.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem + "&times=" + Math.random(), true);
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
         function ListControlTimKiemtenvaitro(control) {
             return " tenvaitro like N'%"+control.value+"%'";
         }
         function ListControlTimKiemidekipmo(control) {
             return " vt.idekipmo = '"+control.value+"'";
         }
         function ListControlTimKiemGhiChu(control) {
             return " vt.GhiChu like N'%"+control.value+"%'";
         }
         //ham lay control de insert du lieu
         function ListControlThem() {
             return "../ajax/VaiTroBSPhauThuat_ajax1.aspx?do=Them&tenvaitro="+ encodeURIComponent(tenvaitro.value)+"&idekipmo="+ encodeURIComponent(idekipmo.value)+"&GhiChu="+ encodeURIComponent(GhiChu.value)+""   ;
         }
         //ham lay control de update du lieu
         function ListControlSua() {
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             return "../ajax/VaiTroBSPhauThuat_ajax1.aspx?do=Sua&tenvaitro=" + encodeURIComponent(tenvaitro.value) + "&idekipmo=" + encodeURIComponent(idekipmo.value) + "&GhiChu=" + encodeURIComponent(GhiChu.value) + "&idkhoachinh=" + idkhoachinh;
         }
          var controlluuphieunhap = "";
         function FunctionLuu(control,valueControlLuu, valueControlSua, ajaxThem, ajaxSua)
         {
         //alert("control="+control+",valueControlLuu="+valueControlLuu+",valueControlSua="+valueControlSua+",ajaxThem="+ajaxThem+",ajaxSua="+ajaxSua);//alert khoe
             controlluuphieunhap = control;
            Luu('','',control,valueControlLuu, valueControlSua, ajaxThem, ajaxSua);
         }
         // ham xoa du lieu voi querystring khoa chinh
         function Xoa(control,valueControlLuu) {
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             //xoa du lieu voi idkhoachinh va hien nut luu,an nut xoa,sua
              var hoi = confirm("Xác nhận !");                  if(hoi){             Xoakhoachinh('','',"../ajax/VaiTroBSPhauThuat_ajax1.aspx?do=xoa&idkhoachinh=" + idkhoachinh,valueControlLuu);
         }}
         function LamMoi(valueControlLuu) {
             // an nut sua,xoa,hien nut luu
             Moi(valueControlLuu);
          loadDropDownListidekipmo();
         }
         function loadDropDownListidekipmo()
         {
//         alert("1");
//             laydanhsachTodroplist('-- Select one --','','',"../ajax/VaiTroBSPhauThuat_ajax1.aspx?do=DropDownList_idekipmo", 'ctl00_body_idekipmo_idekipmo');
         }
 
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
             <div class="shadow" style="margin-top:30px;padding: 2px 0px 2px 0px; background-color: #4473ca; border: 2px solid #cfcfcf;
                 text-align: center; color: White;font-size: 20px;font-weight:bold">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("VaiTroBSPhauThuat")%></div>
     <div style="margin-top: 10px; padding: 5px 5px 5px 5px; border: 1px solid #cfcfcf;background: white">
             <div style="display: table-row; padding-bottom: 50px">
 <uc2:TextBox id="tenvaitro" runat="server" IDTextBox="tenvaitro" onkeyup="Find(this,'ListControlTimKiemtenvaitro');" styleTextBox="width:250px" Title="tenvaitro">
             </uc2:TextBox>
                 <uc1:DropDownList id="idekipmo" runat="server" ID_DropDownList="idekipmo" onload="loadDropDownListidekipmo()" FindFunction="Find(this,'ListControlTimKiemidekipmo')" Title="idekipmo" styleDivInLeft="20px" styleDivInRight="20px" styleTextBox="width:250px">
                 </uc1:DropDownList>
 <uc2:TextBox id="GhiChu" runat="server" IDTextBox="GhiChu" onkeyup="Find(this,'ListControlTimKiemGhiChu');" styleTextBox="width:250px" Title="GhiChu">
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
             <asp:GridView DataKeyNames="idVaiTroBS" ID="gridTable" AllowPaging="True" PageSize="100" OnPageIndexChanging="gridTable_PageIndexChanging" runat="server" Width="900px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowDataBound="gridTable_RowDataBound" AutoGenerateColumns="False">
    <Columns>
    <asp:TemplateField HeaderText="stt">
                         <ItemTemplate>
                             <%#Eval("stt") %>
                         </ItemTemplate>
        <ItemStyle Width="5%" />
                     </asp:TemplateField>
   <asp:BoundField DataField="tenvaitro" HeaderText="tenvaitro">
       <ItemStyle HorizontalAlign="Left" />
   </asp:BoundField>
   <asp:BoundField DataField="tenekipcamo" HeaderText="idekipmo">
       <ItemStyle HorizontalAlign="Left" />
   </asp:BoundField>
   <asp:BoundField DataField="GhiChu" HeaderText="GhiChu">
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
