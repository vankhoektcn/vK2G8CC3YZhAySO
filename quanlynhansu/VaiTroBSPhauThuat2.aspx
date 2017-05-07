 <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VaiTroBSPhauThuat2.aspx.cs" Inherits="VaiTroBSPhauThuat" Title="VaiTroBSPhauThuat" %>
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
         .k
         {
            margin:auto;
         }
     </style>
     <script type="text/javascript">
              var flagtemp;
         $(document).ready(function() {
                tablegrid="<%=gridTable.ClientID %>";
       khoachinhcapnhatdulieu = "idkhoachinh";
       for (var i = 0; i < document.forms[0].elements.length; i++) {
         if (document.forms[0].elements[i].type == "text")
         {
             if(document.forms[0].elements[i].visible == true || document.forms[0].elements[i].disabled == false)
                { setTimeout("document.forms[0].elements["+i+"].focus()",100);
             return false;}
         }
      }
         });
         function functionSelected(idkhoachinh)
         {
 
         }
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
                 xmlHttp.open("GET", "../ajax/VaiTroBSPhauThuat_ajax2.aspx?do=xoa&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
                 xmlHttp.send(null);
             }
             }
             else{document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);}
              
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
         function ListControlTimKiemGhiChu(control) {
             return " GhiChu like N'%"+control.value+"%'";
         }
  function btLuuTable(control,functionlistcontroluutable)
          {
              if(document.getElementById(tablegrid) != null){
               if(control.id.indexOf("luuTable") != -1)
              {
                 for(var i=1;i<3;i++){
                  document.getElementById("luuTable_"+i).value = "<%=hsLibrary.clDictionaryDB.sGetValueLanguage("stop") %> ";
                  document.getElementById("luuTable_"+i).id = "huyTable_"+i;
                  }
                  flagtemp = true;
                  LuuTable('','',row1,control,functionlistcontroluutable);
              }
              else{
              for(var i=1;i<3;i++){
                  document.getElementById("huyTable_"+i).value = "<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> ";
                  document.getElementById("huyTable_"+i).id= "luuTable_"+i;
                  }
                  flagtemp = false;
              }
            }
              
          }
         function ListControlLuuTable(i)
         {
             var tenvaitro = document.getElementById(tablegrid).rows[i].cells[2].getElementsByTagName("input")[0].value;
             var GhiChu = document.getElementById(tablegrid).rows[i].cells[3].getElementsByTagName("input")[0].value;
             return "../ajax/VaiTroBSPhauThuat_ajax2.aspx?do=luuTable&tenvaitro=" + encodeURIComponent(tenvaitro) + "&GhiChu=" + encodeURIComponent(GhiChu) + "";
         }
 
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div style="margin-top: 10px; padding: 5px 5px 5px 5px; border: 1px solid #cfcfcf;background: white">
             <div style="padding: 2px 0px 2px 0px; background-color: #4473ca; border: 1px solid #cfcfcf;
                 text-align: center; color: White;font-size: 25px;font-weight:bold">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("VaiTroBSPhauThuat")%></div>
             <div style="display: table-row; padding-bottom: 50px">
 <uc2:TextBox id="tenvaitro" runat="server" IDTextBox="tenvaitro" onkeyup="Find(this,'ListControlTimKiemtenvaitro');" styleTextBox="width:250px" Title="tenvaitro">
             </uc2:TextBox>
 <uc2:TextBox id="GhiChu" runat="server" IDTextBox="GhiChu" onkeyup="Find(this,'ListControlTimKiemGhiChu');" styleTextBox="width:250px" Title="GhiChu">
             </uc2:TextBox>
         </div></div>
 <div style="border: 1px solid #cfcfcf; background: white; text-align: center;
             padding: 5px 5px 5px 5px;border-Top:none;">
             <div style="padding: 10px 0 10px 0;">
             <input id="luuTable_1" type="button" style="margin-right:10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" onclick="btLuuTable(this,'ListControlLuuTable');"/>
                 <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' OnClick="Button2_Click" />
                 <asp:Button UseSubmitBehavior="false" ID="Button1" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("timkiem") %>' OnClick="Button1_Click" />
             </div>
             <div style="overflow:auto">
                 <asp:GridView CssClass="k" Width="700px" ID="gridTable" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="idVaiTroBS" BackColor="White" PageSize="100" OnPageIndexChanging="gridTable_PageIndexChanging" OnRowDataBound="gridTable_RowDataBound" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowSorting="True" ShowFooter="true">
                     <Columns>
 <asp:TemplateField HeaderText="stt">
                         <ItemTemplate>
                             <%#Eval("stt") %>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField>
                         <ItemTemplate>
                             <a onkeydown="chuyendong(this);" href="#" style='text-decoration:none;cursor:pointer;margin-right:10px;color:green;' onclick="xoaontable(this.name,this);" name="<%#Eval("idVaiTroBS") %>"><%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %></a>
                         </ItemTemplate>
                     </asp:TemplateField>
                         <asp:TemplateField HeaderText="tenvaitro">
                             <ItemTemplate>
                             <input onfocusout="chuyenformout(this)" onfocus="chuyenform(this)" onkeydown="chuyendong(this);" style="width:200px;border:none" value='<%#Eval("tenvaitro") %>' type="text"/>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="GhiChu">
                             <ItemTemplate>
                             <input onfocusout="chuyenformout(this)" onfocus="chuyenform(this)" onkeydown="chuyendong(this);" style="width:300px;border:none" value='<%#Eval("GhiChu") %>' type="text"/>
                             </ItemTemplate>
                         </asp:TemplateField>
  <asp:TemplateField HeaderText="dongluu" ItemStyle-Width="30px" Visible="false">
                             <ItemTemplate>
                                 <input onclick="checkluu(this)" type="checkbox" onkeydown="chuyendong(this);" style="border:none" />
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField>
                             <ItemTemplate>
                                 <input type="hidden" value='<%#Eval("idVaiTroBS") %>'/>
                             </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>
                     <RowStyle BackColor="White" ForeColor="#003399" />
                     <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" />
                     <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                     <HeaderStyle BackColor="#4473ca" Font-Bold="True" ForeColor="#CCCCFF" />
                     <FooterStyle BackColor="#4473ca" ForeColor="#003399"/>
                 </asp:GridView>
                 </div>
                 <div style="padding: 10px 0 10px 0;">
                     <asp:HiddenField ID="HiddenField1" runat="server" />
                     <asp:HiddenField ID="HiddenField2" runat="server" />
                     <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>' onclick="btLuuTable(this,'ListControlLuuTable');"/>
                     
                 </div>
         </div>
 </asp:Content>
