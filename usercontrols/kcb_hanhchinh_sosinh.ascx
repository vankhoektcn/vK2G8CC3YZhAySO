<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kcb_hanhchinh_sosinh.ascx.cs"
    Inherits="usercontrols_capcuu_hanhchinh" %>

<script type="text/javascript" src="../javascript/hanhchinhsosinh.js">
</script>

<div class="body-div">
    <div class="header-div">
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hanhchinh")%>
    </div>
    <div class="in-a">
        <div class="div-Out" style="width:940px;padding-bottom:0px;padding-top:10px;height:30px">
             <div style="font-weight:bold;font-size:15px">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("sovaovien")%> :
                 <span mkv="true" id="sovaovien" style="width:90%;font-weight:bold;font-size:15px"></span>
             </div>
         </div>
        <div class="div-Out" style="width: 400px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tenbenhnhan")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="tenbenhnhan" type="text" style="width: 90%" />
            </div>
        </div>
        <div class="div-Out" style="width: 280px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaysinh")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="ngaysinh" type="text" style="width: 90%" />
            </div>
        </div>
        <div class="div-Out" style="width: 900px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("gioitinh")%>
            </div>
            <div class="div-Right" style="width:80%">
                Nam
                <input disabled="true" mkv="true" id="nam" type="checkbox" value="0" style="width: 10%" />
                Nữ
                <input disabled="true" mkv="true" id="nu" type="checkbox" value="1" style="width: 10%" />
            </div>
        </div>
        <div class="div-Out" style="width: 400px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tenme")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="tenme" type="text" style="width: 90%" />
            </div>
        </div>
        <div class="div-Out" style="width: 280px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaysinh")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="ngaysinhme" type="text" style="width: 90%" />
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nghenghiep")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="nghenghiepme" type="text" style="width: 90%" />
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("delanmay")%>
            </div>
            <div class="div-Right" style="width:80%">
                <input disabled="true" mkv="true" id="delanmay" type="checkbox" />
            </div>
        </div>
        <div class="div-Out" style="width: 400px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tenbo")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="tenbo" type="text" style="width: 90%" />
            </div>
        </div>
        <div class="div-Out" style="width: 280px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaysinh")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="ngaysinhbo" type="text" style="width: 90%" />
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nghenghiep")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="nghenghiepbo" type="text" style="width: 90%" />
            </div>
        </div>
        <div class="div-Out" style="width: 200px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DanToc")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="DanToc" type="text" style="width: 70%" />
            </div>
        </div>
        <div class="div-Out"  style="width: 200px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("QuocTich")%>
            </div>
            <div class="div-Right" style="width:60%">
                <input disabled="true" mkv="true" id="QuocTich" type="text" style="width: 70%" />
            </div>
        </div>
        <div class="div-Out" style="width: 940px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("diachi")%>
            </div>
            <div class="div-Right" style="width: 85.35%">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("sonha")%>
                <input disabled="true" mkv="true" id="sonha" type="text" style="width: 10%" />
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("phuongxaid")%>
                <input disabled="true" mkv="true" id="phuongxaid" type="text" onblur="TestSo(this,false,true);"
                    style="width: 20%" />
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("quanhuyenid")%>
                <input disabled="true" mkv="true" id="quanhuyenid" type="text" onblur="TestSo(this,false,true);"
                    style="width: 20%" />
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tinhid")%>
                <input disabled="true" mkv="true" id="tinhid" type="text" onblur="TestSo(this,false,true);"
                    style="width: 15%" />
            </div>
        </div>
        <div class="div-Out" style="width: 300px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nhommaume")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="noicongtac" type="text" style="width: 70%" />
            </div>
        </div>
        
        <div class="div-Out" style="width: 600px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tienthai")%>
            </div>
            <div class="div-Right" style="width:85%">
                <input disabled="true" mkv="true" id="ngayhethan" type="text" style="width: 30%" />
                (Sinh(đủ tháng),sớm(thiếu tháng),sẩy(nạo,hút,sống))
            </div>
        </div>
        <div class="div-Out" style="width: 940px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NguoiLH,DiaChiLH")%>
            </div>
            <div class="div-Right" style="width: 80%">
                <input disabled="true" mkv="true" id="NguoiLH" type="text" style="width: 40%" />
                <input disabled="true" mkv="true" id="DiaChiLH" type="text" style="width: 40%" />
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DienThoaiLH")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="DienThoaiLH" type="text" style="width: 90%" />
            </div>
        </div>
    </div>
</div>
