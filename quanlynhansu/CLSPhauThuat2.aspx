 <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CLSPhauThuat2.aspx.cs" Inherits="CLSPhauThuat" Title="CLSPhauThuat" %>
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
     <script type="text/javascript" src="../javascript/CLSPhauThuat2.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <div class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("CLSPhauThuat")%>
                <div class="in-a"></div>
                 <div class="in-b"></div>
           </div>
 <div class="in-a">
 <uc2:TextBox id="idchitietCLSPhauThuat" runat="server" IDTextBox="idchitietCLSPhauThuat" onkeyup="Find(this,'ListControlTimKiemidchitietCLSPhauThuat');" styleTextBox="width:90%" Title="idchitietCLSPhauThuat" styleDivInRight="width:60%">
             </uc2:TextBox>
                 <uc1:DropDownList id="idcaphauthuat" runat="server" ID_DropDownList="idcaphauthuat"  FindFunction="Find(this,'ListControlTimKiemidcaphauthuat')" styleTextBox="width:90%" Title="idcaphauthuat">
                 </uc1:DropDownList>
         </div></div>
 <div class="body-div-button">
 <div class="in-a">
             <input id="luuTable_1" type="button" style="margin-right:10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" onclick="btLuuTable(this,'ListControlLuuTable');"/>
                 <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' OnClick="Button2_Click" />
                 <asp:Button UseSubmitBehavior="false" ID="Button1" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("timkiem") %>' OnClick="Button1_Click" />
             </div>
             <div class="in-b">
                 <asp:GridView Width="100%" ID="gridTable" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="idCLSPhauThuat" BackColor="White" PageSize="100" OnPageIndexChanging="gridTable_PageIndexChanging" OnRowDataBound="gridTable_RowDataBound" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowSorting="True" ShowFooter="true">
                     <Columns>
 <asp:TemplateField HeaderText="stt">
                         <ItemTemplate>
                             <%#Eval("stt") %>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField>
                         <ItemTemplate>
                             <a onkeydown="chuyendong(this);" style='text-decoration:none;cursor:pointer;margin-right:10px;color:green;' onclick="xoaontable(this.name,this);" name="<%#Eval("idCLSPhauThuat") %>"><%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %></a>
                         </ItemTemplate>
                     </asp:TemplateField>
                         <asp:TemplateField HeaderText="idchitietCLSPhauThuat">
                             <ItemTemplate>
                             <input onfocusout="chuyenformout(this);checkchuyenphim=true;" onfocus="chuyenform(this);timkiemCLS(this);" onkeydown="chuyendong(this);" style="width:550px;" value='<%#Eval("tendichvu") %>' type="text"/>
                             <asp:HiddenField ID="idCLS_ID" runat="server" Value='<%#Eval("idchitietCLSPhauThuat") %>' />
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="idcaphauthuat">
                             <ItemTemplate>
                                 <asp:DropDownList ID="DropDownList2" runat="server" onfocusout="chuyenformout(this);" onfocus="chuyenform(this)" onkeydown="chuyendong(this);" style="width:300px;">
                                 </asp:DropDownList>
                             </ItemTemplate>
                         </asp:TemplateField>
  <asp:TemplateField HeaderText="dongluu" ItemStyle-Width="30px" Visible="false">
                             <ItemTemplate>
                                 <input onclick="checkluu(this)" type="checkbox" onkeydown="chuyendong(this);" style="" />
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField>
                             <ItemTemplate>
                                 <input type="hidden" value='<%#Eval("idCLSPhauThuat") %>'/>
                             </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>
                     <RowStyle BorderColor="#E5EFF8" BackColor="White" ForeColor="#003399" />
                     <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" />
                     <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                     <HeaderStyle BackColor="#4473ca" Font-Bold="True" ForeColor="#CCCCFF" />
                     <FooterStyle BackColor="#4473ca" ForeColor="#003399"/>
                 </asp:GridView>
                 </div>
 <div style="padding: 10px 0 10px 0;background-color:#fafafa;border-bottom:1px solid #cfcfcf;">
                     <asp:HiddenField ID="HiddenField1" runat="server" />
                     <asp:HiddenField ID="HiddenField2" runat="server" />
                     <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>' onclick="btLuuTable(this,'ListControlLuuTable');"/>
                     
                 </div>
         </div>
 </asp:Content>
