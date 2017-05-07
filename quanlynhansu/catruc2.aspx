 <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="catruc2.aspx.cs" Inherits="catruc" Title="catruc" %>
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
                 xmlHttp.open("GET", "../ajax/catruc_ajax2.aspx?do=xoa&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
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
         function ListControlTimKiemtencatruc(control) {
             return " tencatruc like N'%"+control.value+"%'";
         }
         function ListControlTimKiemtientruc(control) {
             return " tientruc like N'%"+control.value+"%'";
         }
         function ListControlTimKiemghichu(control) {
             return " ghichu like N'%"+control.value+"%'";
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
             var tencatruc = document.getElementById(tablegrid).rows[i].cells[2].getElementsByTagName("input")[0].value;
             var tientruc = document.getElementById(tablegrid).rows[i].cells[3].getElementsByTagName("input")[0].value;
             var ghichu = document.getElementById(tablegrid).rows[i].cells[4].getElementsByTagName("input")[0].value;
             return "../ajax/catruc_ajax2.aspx?do=luuTable&tencatruc=" + encodeURIComponent(tencatruc) + "&tientruc=" + encodeURIComponent(tientruc) + "&ghichu=" + encodeURIComponent(ghichu) + "";
         }
 
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div style="margin-top: 10px; padding: 5px 5px 5px 5px; border: 1px solid #cfcfcf;background: white">
             <div style="padding: 2px 0px 2px 0px; background-color: #4473ca; border: 1px solid #cfcfcf;
                 text-align: center; color: White;font-size: 25px;font-weight:bold">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("catruc")%></div>
             <div style="display: table-row; padding-bottom: 50px">
                 <div style="float: left; padding: 0px 20px 0px 20px; width: 443px;height:40px; border-right: 1px solid #cfcfcf;
                     border-bottom: 1px solid #cfcfcf;">
                     <div style="float: left; padding: 10px 0px 10px 0px">
                         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tencatruc") %> :</div>
                     <div style="width: 70%; float: right; border-left: 1px solid #cfcfcf; padding: 10px 0px 10px 20px">
                         <input runat="server" style="width: 250px" id="tencatruc" type="text"
                             onkeyup="Find(this,'ListControlTimKiemtencatruc');chuyenphim(this)" /></div>
                 </div>
                 <div style="float: left; padding: 0px 20px 0px 20px; width: 443px;height:40px; border-right: 1px solid #cfcfcf;
                     border-bottom: 1px solid #cfcfcf;">
                     <div style="float: left; padding: 10px 0px 10px 0px">
                         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tientruc") %> :</div>
                     <div style="width: 70%; float: right; border-left: 1px solid #cfcfcf; padding: 10px 0px 10px 20px">
                         <input runat="server" style="width: 250px" id="tientruc" type="text"
                             onkeyup="Find(this,'ListControlTimKiemtientruc');chuyenphim(this)" /></div>
                 </div>
                 <div style="float: left; padding: 0px 20px 0px 20px; width: 443px;height:40px; border-right: 1px solid #cfcfcf;
                     border-bottom: 1px solid #cfcfcf;">
                     <div style="float: left; padding: 10px 0px 10px 0px">
                         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") %> :</div>
                     <div style="width: 70%; float: right; border-left: 1px solid #cfcfcf; padding: 10px 0px 10px 20px">
                         <input runat="server" style="width: 250px" id="ghichu" type="text"
                             onkeyup="Find(this,'ListControlTimKiemghichu');chuyenphim(this)" /></div>
                 </div>
         </div></div>
 <div style="border: 1px solid #cfcfcf; background: white; text-align: center;
             padding: 5px 5px 5px 5px;border-Top:none;">
             <div style="padding: 10px 0 10px 0;">
             <input id="luuTable_1" type="button" style="margin-right:10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" onclick="btLuuTable(this,'ListControlLuuTable');"/>
                 <asp:Button UseSubmitBehavior="false" ID="Button1" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("timkiem") %>' OnClick="Button1_Click" />
             </div>
             <div style="overflow:auto">
                 <asp:GridView Width="100%" ID="gridTable" runat="server" AutoGenerateColumns="False" DataKeyNames="idcatruc" BackColor="White" PageSize="2" OnPageIndexChanging="gridTable_PageIndexChanging" OnRowDataBound="gridTable_RowDataBound" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowSorting="True" ShowFooter="true">
                     <Columns>
 <asp:TemplateField HeaderText="stt">
                         <ItemTemplate>
                             <%#Eval("stt") %>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField>
                         <ItemTemplate>
                             <a onkeydown="chuyendong(this);" href="#" style='text-decoration:none;cursor:pointer;margin-right:10px;color:green;' onclick="xoaontable(this.name,this);" name="<%#Eval("idcatruc") %>"><%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %></a>
                         </ItemTemplate>
                     </asp:TemplateField>
                         <asp:TemplateField HeaderText="tencatruc">
                             <ItemTemplate>
                             <input onfocusout="chuyenformout(this)" onfocus="chuyenform(this)" onkeydown="chuyendong(this);" style="width:250px;border:none" value='<%#Eval("tencatruc") %>' type="text"/>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="tientruc">
                             <ItemTemplate>
                             <input onfocusout="chuyenformout(this)" onfocus="chuyenform(this)" onkeydown="chuyendong(this);" style="width:70px;border:none" value='<%#Eval("tientruc") %>' type="text"/>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="ghichu">
                             <ItemTemplate>
                             <input onfocusout="chuyenformout(this)" onfocus="chuyenform(this)" onkeydown="chuyendong(this);" style="width:350px;border:none" value='<%#Eval("ghichu") %>' type="text"/>
                             </ItemTemplate>
                         </asp:TemplateField>
  <asp:TemplateField HeaderText="dongluu" Visible="False">
                             <ItemTemplate>
                                 <input onclick="checkluu(this)" type="checkbox" onkeydown="chuyendong(this);" style="border:none" />
                             </ItemTemplate>
      <ItemStyle Width="30px" />
                         </asp:TemplateField>
                         <asp:TemplateField>
                             <ItemTemplate>
                                 <input type="hidden" value='<%#Eval("idcatruc") %>'/>
                             </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>
                     <RowStyle BackColor="White" ForeColor="#003399" />
                     <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" />
                     <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                     <HeaderStyle BackColor="#4473CA" Font-Bold="True" ForeColor="#CCCCFF" />
                     <FooterStyle BackColor="#4473CA" ForeColor="#003399"/>
                 </asp:GridView>
                 </div>
                 <div style="padding: 10px 0 10px 0;">
                     <asp:HiddenField ID="HiddenField1" runat="server" />
                     <asp:HiddenField ID="HiddenField2" runat="server" />
                     <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>' onclick="btLuuTable(this,'ListControlLuuTable');"/>
                     
                 </div>
         </div>
 </asp:Content>
