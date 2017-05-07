 <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChiTietCLSGoiPhauThuat1.aspx.cs" Inherits="ChiTietCLSGoiPhauThuat" Title="ChiTietCLSGoiPhauThuat" %>
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
              var flagtemp,idchitietCLSPhauThuat,idgoiphauthuat,idcanlamsang,idloaiphauthuat,giatrongoi,giabinhthuong,ghichu;
         $(document).ready(function() {
             idgoiphauthuat = document.getElementById("ctl00_body_idgoiphauthuat_idgoiphauthuat");
             idcanlamsang = document.getElementById("ctl00_body_idcanlamsang_idcanlamsang");
             idloaiphauthuat = document.getElementById("ctl00_body_idloaiphauthuat_idloaiphauthuat");
             giatrongoi = document.getElementById("ctl00_body_giatrongoi_giatrongoi");
             giabinhthuong = document.getElementById("ctl00_body_giabinhthuong_giabinhthuong");
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
  idgoiphauthuat.value = value[1];
         idcanlamsang.value = value[2];
  idloaiphauthuat.value = value[3];
         giatrongoi.value = value[4];
         giabinhthuong.value = value[5];
         ghichu.value = value[6];
                    setTimeout("setf()",100);
                     //set khoa chinh len querystring va hien nut xoa,sua
                     XoaControlAfterFind(value[0],valueControlSua);
                     if(currentRow != null){currentRow=0}
                 }
             }
             xmlHttp.open("GET", "../ajax/ChiTietCLSGoiPhauThuat_ajax1.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem + "&times=" + Math.random(), true);
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
         function ListControlTimKiemidgoiphauthuat(control) {
             return " idgoiphauthuat = '"+control.value+"'";
         }
         function ListControlTimKiemidcanlamsang(control) {
             return " idcanlamsang = '"+control.value+"'";
         }
         function ListControlTimKiemidloaiphauthuat(control) {
             return " idloaiphauthuat = '"+control.value+"'";
         }
         function ListControlTimKiemgiatrongoi(control) {
             return " giatrongoi = '"+control.value+"'";
         }
         function ListControlTimKiemgiabinhthuong(control) {
             return " giabinhthuong = '"+control.value+"'";
         }
         function ListControlTimKiemghichu(control) {
             return " ghichu like N'%"+control.value+"%'";
         }
         //ham lay control de insert du lieu
         function ListControlThem() {
             return "../ajax/ChiTietCLSGoiPhauThuat_ajax1.aspx?do=Them&idgoiphauthuat="+ encodeURIComponent(idgoiphauthuat.value)+"&idcanlamsang="+ encodeURIComponent(idcanlamsang.value)+"&idloaiphauthuat="+ encodeURIComponent(idloaiphauthuat.value)+"&giatrongoi="+ encodeURIComponent(giatrongoi.value)+"&giabinhthuong="+ encodeURIComponent(giabinhthuong.value)+"&ghichu="+ encodeURIComponent(ghichu.value)+""   ;
         }
         //ham lay control de update du lieu
         function ListControlSua() {
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             return "../ajax/ChiTietCLSGoiPhauThuat_ajax1.aspx?do=Sua&idgoiphauthuat=" + encodeURIComponent(idgoiphauthuat.value) + "&idcanlamsang=" + encodeURIComponent(idcanlamsang.value) + "&idloaiphauthuat=" + encodeURIComponent(idloaiphauthuat.value) + "&giatrongoi=" + encodeURIComponent(giatrongoi.value) + "&giabinhthuong=" + encodeURIComponent(giabinhthuong.value) + "&ghichu=" + encodeURIComponent(ghichu.value) + "&idkhoachinh=" + idkhoachinh;
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
              var hoi = confirm("Xác nhận !");                  if(hoi){             Xoakhoachinh('','',"../ajax/ChiTietCLSGoiPhauThuat_ajax1.aspx?do=xoa&idkhoachinh=" + idkhoachinh,valueControlLuu);
         }}
         function LamMoi(valueControlLuu) {
             // an nut sua,xoa,hien nut luu
             Moi(valueControlLuu);
          loadDropDownListidgoiphauthuat();
          loadDropDownListidloaiphauthuat();
         }
         function loadDropDownListidgoiphauthuat()
         {
             //laydanhsachTodroplist('-- Select one --','','',"../ajax/ChiTietCLSGoiPhauThuat_ajax1.aspx?do=DropDownList_idgoiphauthuat", 'ctl00_body_idgoiphauthuat_idgoiphauthuat');
         }
         
         function loadDropDownListidloaiphauthuat()
         {
             //laydanhsachTodroplist('-- Select one --','','',"../ajax/ChiTietCLSGoiPhauThuat_ajax1.aspx?do=DropDownList_idloaiphauthuat", 'ctl00_body_idloaiphauthuat_idloaiphauthuat');
         }
 
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
             <div class="shadow" style="margin-top:30px;padding: 2px 0px 2px 0px; background-color: #4473ca; border: 2px solid #cfcfcf;
                 text-align: center; color: White;font-size: 25px;font-weight:bold">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ChiTietCLSGoiPhauThuat")%></div>
     <div style="margin-top: 10px; padding: 5px 5px 5px 5px; border: 1px solid #cfcfcf;background: white">
             <div style="display: table-row; padding-bottom: 50px">
                 <uc1:DropDownList id="idgoiphauthuat" runat="server" ID_DropDownList="idgoiphauthuat" onload="loadDropDownListidgoiphauthuat()" FindFunction="Find(this,'ListControlTimKiemidgoiphauthuat')" Title="idgoiphauthuat" styleTextBox="width:250px">
                 </uc1:DropDownList>
                 <uc1:DropDownList id="idcanlamsang" runat="server" ID_DropDownList="idcanlamsang" onload="loadDropDownListidgoiphauthuat()" FindFunction="Find(this,'ListControlTimKiemidcanlamsang')" Title="idcanlamsang" styleTextBox="width:250px">
                 </uc1:DropDownList>

                 <uc1:DropDownList id="idloaiphauthuat" runat="server" ID_DropDownList="idloaiphauthuat" onload="loadDropDownListidloaiphauthuat()" FindFunction="Find(this,'ListControlTimKiemidloaiphauthuat')" Title="idloaiphauthuat" styleTextBox="width:250px">
                 </uc1:DropDownList>
 <uc2:TextBox id="giatrongoi" runat="server" IDTextBox="giatrongoi" onkeyup="Find(this,'ListControlTimKiemgiatrongoi');" boolTestSo="true" styleTextBox="width:250px" Title="giatrongoi">
             </uc2:TextBox>
 <uc2:TextBox id="giabinhthuong" runat="server" IDTextBox="giabinhthuong" onkeyup="Find(this,'ListControlTimKiemgiabinhthuong');" boolTestSo="true" styleTextBox="width:250px" Title="giabinhthuong">
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
             <asp:GridView DataKeyNames="idchitietCLSPhauThuat" ID="gridTable" AllowPaging="True" PageSize="100" OnPageIndexChanging="gridTable_PageIndexChanging" runat="server" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowDataBound="gridTable_RowDataBound" AutoGenerateColumns="False">
    <Columns>
    <asp:TemplateField HeaderText="stt">
                         <ItemTemplate>
                             <%#Eval("stt") %>
                         </ItemTemplate>
        <ItemStyle Width="5%" />
                     </asp:TemplateField>
   <asp:BoundField DataField="TenGoiPhauThuat" HeaderText="idgoiphauthuat">
       <ItemStyle HorizontalAlign="Left" />
   </asp:BoundField>
   <asp:BoundField DataField="TenDichVu" HeaderText="idcanlamsang">
       <ItemStyle HorizontalAlign="Left" />
   </asp:BoundField>
   <asp:BoundField DataField="TenLoaiPhauThuat" HeaderText="idloaiphauthuat">
       <ItemStyle HorizontalAlign="Left" />
   </asp:BoundField>
   <asp:BoundField DataField="giatrongoi" HeaderText="giatrongoi" DataFormatString=" {0:N0}">
       <ItemStyle HorizontalAlign="Right" />
   </asp:BoundField>
   <asp:BoundField DataField="giabinhthuong" HeaderText="giabinhthuong" DataFormatString=" {0:N0}">
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
