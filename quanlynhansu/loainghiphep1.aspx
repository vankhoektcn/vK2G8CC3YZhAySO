 <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="loainghiphep1.aspx.cs" Inherits="loainghiphep" Title="loainghiphep" %>
 <%@ Register Src="~/quanlynhansu/usercontrols/droplist.ascx" TagName="droplist" TagPrefix="uc1" %>
 <%@ Register Src="~/quanlynhansu/usercontrols/div.ascx" TagName="div" TagPrefix="uc2" %>
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
              var flagtemp,idnghiphep,tennghiphep;
         $(document).ready(function() {
             tennghiphep = document.getElementById("ctl00_body_tennghiphep_tennghiphep");
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
         tennghiphep.value = value[1];
                    setTimeout("setf()",100);
                     //set khoa chinh len querystring va hien nut xoa,sua
                     XoaControlAfterFind(value[0],valueControlSua);
                     if(currentRow != null){currentRow=0}
                 }
             }
             xmlHttp.open("GET", "../ajax/loainghiphep_ajax1.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem + "&times=" + Math.random(), true);
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
         function ListControlTimKiemtennghiphep(control) {
             return " tennghiphep like N'%"+control.value+"%'";
         }
         //ham lay control de insert du lieu
         function ListControlThem() {
             return "../ajax/loainghiphep_ajax1.aspx?do=Them&tennghiphep="+ encodeURIComponent(tennghiphep.value)+""   ;
         }
         //ham lay control de update du lieu
         function ListControlSua() {
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             return "../ajax/loainghiphep_ajax1.aspx?do=Sua&tennghiphep=" + encodeURIComponent(tennghiphep.value) + "&idkhoachinh=" + idkhoachinh;
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
              var hoi = confirm("Xác nhận !");                  if(hoi){             Xoakhoachinh('','',"../ajax/loainghiphep_ajax1.aspx?do=xoa&idkhoachinh=" + idkhoachinh,valueControlLuu);
         }}
         function LamMoi(valueControlLuu) {
             // an nut sua,xoa,hien nut luu
             Moi(valueControlLuu);
         }
 
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div style="margin-top: 10px; padding: 5px 5px 5px 5px; border: 1px solid #cfcfcf;background: white">
             <div style="padding: 2px 0px 2px 0px; background-color: #4473ca; border: 1px solid #cfcfcf;
                 text-align: center; color: White;font-size: 25px;font-weight:bold">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("loainghiphep")%></div>
                 <br />
             <div style="display: table-row; padding-bottom: 50px;width:500px">
 <uc2:div id="tennghiphep" runat="server" IDTextBox="tennghiphep" onkeyup="Find(this,'ListControlTimKiemtennghiphep');" styleTextBox="width:250px" Title="tennghiphep">
             </uc2:div>
         </div></div>
         <div style="border: 1px solid #cfcfcf; background: white; text-align: center;
             padding: 5px 5px 5px 5px;border-Top:none;">
             <!-- voi cac 'xoa','luu','sua' khi onclick la id cua control -->
             <!-- voi cac ListControlThem,ListControlSua,ListControlTimKiemEnter la cac function -->
             <div style=" padding: 10px 0 10px 0;background-color:white;border:1px solid #cfcfcf;">
                 <input style="border:1px solid " id="luu" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " onclick="FunctionLuu(this,'<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> ','<%=hsLibrary.clDictionaryDB.sGetValueLanguage("update") %>','ListControlThem','ListControlSua');"
                      />
                 <input style="border:1px solid " id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" onclick="LamMoi('<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>');"
                      />
                 <input style="border:1px solid;display: none " id="xoa" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" onclick="Xoa(this,'<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>');"
                      />
                 <asp:Button UseSubmitBehavior="false" ID="Button1" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("timkiem") %>' OnClick="Button1_Click" />
             </div>
  <div  style="overflow:auto" style="width:600px">
             <asp:GridView DataKeyNames="idnghiphep" ID="gridTable" AllowPaging="true" PageSize="100" OnPageIndexChanging="gridTable_PageIndexChanging" runat="server" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowDataBound="gridTable_RowDataBound" AutoGenerateColumns="false">
    <Columns>
    <asp:BoundField DataField="STT" HeaderText="STT" />
   <asp:BoundField DataField="tennghiphep" HeaderText="tennghiphep" />
    </Columns>
                 <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                 <RowStyle BackColor="White" ForeColor="Black" />
                 <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                 <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#4473ca" Font-Bold="True" ForeColor="White" />
                 <AlternatingRowStyle BackColor="#CAE3FF" ForeColor="Green"/>
             </asp:GridView>
             <asp:HiddenField ID="HiddenField1" runat="server" />
             <asp:HiddenField ID="HiddenField2" runat="server" />
         </div>
         </div>
 </asp:Content>
