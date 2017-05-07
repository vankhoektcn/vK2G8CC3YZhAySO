<%@ Page Language="C#" MasterPageFile="MasterPage_KT.master" AutoEventWireup="true"
    CodeFile="KTHT_CongNo_DauKi2.aspx.cs" Inherits="CongNo_DauKi" Title="CongNo_DauKi" %>

<%@ Register Src="Menu_KT/uscmenuKT_HeThong.ascx" TagName="uscmenuKT_HeThong" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="javascript/KTHT_CongNo_DauKi2.js">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
<uc1:uscmenuKT_HeThong ID="uscmenuKT_HeThong1" runat="server" />
    <div class="body-div">
        <p class="header-div">
                CÔNG NỢ ĐẦU KÌ
<%--            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("CongNo_DauKi")%>
--%>        </p>
        <div class="in-a">
            <div class="div-Out">                
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Năm")%>
                </h4>
                <p>
                    <input mkv="true" id="nam" type="text" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tài khoản ")%>
                </h4>
                <p>
                    <input mkv="true" id="tk" type="text" onfocus="Find(this);chuyenphim(this);taikhoansearch(this.id);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Loại đối tượng")%>
                </h4>
                <p>
                    <%--<input mkv="true" id="loai_dt" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />--%>
                        <select id="loai_dt" style="width:50%">
                            <option value="kh">Khách hàng</option>
                            <option value="ncc">Nhà cung cấp</option>                                            
                        </select>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên đối tượng")%>
                </h4>
                <p>
                    <input id="ten_dt" type="text" onfocus="doituong(this.id);Find(this);chuyenphim(this)" style="width: 90%" />
                    <input mkv="true" id="ma_dt" type="hidden"  />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("số hóa đơn")%>
                </h4>
                <p>
                    <input mkv="true" id="so_hd" type="text" onfocus="Find(this);chuyenphim(this);" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngày lập HĐ")%>
                </h4>
                <p>
                    <input mkv="true" id="ngay_lap_hd" type="text" onfocus="Find(this);chuyenphim(this);$(this).validDate();"
                        style="width: 50%" />
                    (dd\MM\yyyy)
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("dư nợ đầu kì")%>
                </h4>
                <p>
                    <input mkv="true" id="du_no0" type="text" onfocus="Find(this);chuyenphim(this);"
                         style="width: 90%" />
                   <%-- onblur="TestSo(this,false,true);"--%>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("dư có đầu kì")%>
                </h4>
                <p>
                    <input mkv="true" id="du_co0" type="text" onfocus="Find(this);chuyenphim(this);"
                         style="width: 90%" />
                   <%-- onblur="TestSo(this,false,true);"      --%>                   
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("dien_giai")%>
                </h4>
                <p>
                    <input mkv="true" id="dien_giai" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu1" type="button" style="margin-right: 10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
            <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
            <input id="timKiem" search="<%=StaticData.HavePermision(this, "CongNo_DauKi_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_CongNo_DauKi">
        </div>
        <p class="in-c">
            <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>' />
        </p>
    </div>
</asp:Content>
