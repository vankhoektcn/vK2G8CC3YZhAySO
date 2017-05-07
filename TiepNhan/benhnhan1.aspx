<%@ Page Language="C#" MasterPageFile="Page.master" AutoEventWireup="true"
    CodeFile="benhnhan1.aspx.cs" Inherits="benhnhan" Title="benhnhan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="javascript/benhnhan1.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("benhnhan")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("mabenhnhan")%>
                </h4>
                <p>
                    <input mkv="true" id="mabenhnhan" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tenbenhnhan")%>
                </h4>
                <p>
                    <input mkv="true" id="tenbenhnhan" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("diachi")%>
                </h4>
                <p>
                    <input mkv="true" id="diachi" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("dienthoai")%>
                </h4>
                <p>
                    <input mkv="true" id="dienthoai" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("gioitinh")%>
                </h4>
                <p>
                    <input mkv="true" id="gioitinh" type="text" onfocus="Find(this);chuyenphim(this);"
                        onblur="TestSo(this,false,true);" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaysinh")%>
                </h4>
                <p>
                    <input mkv="true" id="ngaysinh" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
           
            <input id="timKiem" search="<%=StaticData.HavePermision(this, "benhnhan_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_benhnhan">
        </div>
    </div>
</asp:Content>
