<%@ Control Language="C#" AutoEventWireup="true" CodeFile="capcuu_hanhchinh.ascx.cs"
    Inherits="usercontrols_capcuu_hanhchinh" %>

<script type="text/javascript" src="../javascript/hanhchinh.js">
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
        <div class="div-Out" style="width: 220px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tuoi")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="tuoi" type="text" style="width: 90%" />
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("gioitinh")%>
            </div>
            <div class="div-Right">
                Nam
                <input disabled="true" mkv="true" id="nam" type="checkbox" value="0" style="width: 10%" />
                Nữ
                <input disabled="true" mkv="true" id="nu" type="checkbox" value="1" style="width: 10%" />
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nghenghiep")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="nghenghiep" type="text" style="width: 90%" />
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DanToc")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="DanToc" type="text" style="width: 90%" />
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("QuocTich")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="QuocTich" type="text" style="width: 90%" />
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
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("noicongtac")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="noicongtac" type="text" style="width: 90%" />
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("loai")%>
            </div>
            <div class="div-Right" style="width: 80%">
                1.BHYT
                <input disabled="true" mkv="true" id="bhyt" type="checkbox" onblur="TestSo(this,false,true);"
                    style="width: 10%" />
                2.Thu phí
                <input disabled="true" mkv="true" id="thuphi" type="checkbox" onblur="TestSo(this,false,true);"
                    style="width: 10%" />
                3.Miễn
                <input disabled="true" mkv="true" id="mien" type="checkbox" onblur="TestSo(this,false,true);"
                    style="width: 10%" />
                4.Khác
                <input disabled="true" mkv="true" id="khac" type="checkbox" onblur="TestSo(this,false,true);"
                    style="width: 10%" />
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngayhethan")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="ngayhethan" type="text" style="width: 90%" />
            </div>
        </div>
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("sobhyt")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="BH1" type="text" style="width: 10%" />
                <input disabled="true" mkv="true" id="BH2" type="text" style="width: 10%" />
                <input disabled="true" mkv="true" id="BH3" type="text" style="width: 10%" />
                <input disabled="true" mkv="true" id="BH4" type="text" style="width: 10%" />
                <input disabled="true" mkv="true" id="BH5" type="text" style="width: 20%" />
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
        <div class="div-Out">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaytiepnhan")%>
            </div>
            <div class="div-Right">
                <input disabled="true" mkv="true" id="giotiepnhan" type="text" style="width: 10%" />
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("gio")%>
                <input disabled="true" mkv="true" id="phuttiepnhan" type="text" style="width: 10%" />
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("phut")%>
                <input disabled="true" mkv="true" id="ngaytiepnhan" type="text" onblur="TestDate(this);"
                    style="width: 30%" />
                (dd\MM\yyyy)
            </div>
        </div>
        <div class="div-Out" style="width: 940px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("chandoansobonoigt")%>
            </div>
            <div class="div-Right" style="width: 80%">
                <input disabled="true" mkv="true" id="chandoansobo" type="text" style="width: 60%" />
                1.Y tế
                <input disabled="true" mkv="true" id="YTE" type="checkbox" value="1" style="width: 10%" />
                2.Tự đến
                <input disabled="true" mkv="true" id="TUDEN" type="checkbox" value="2" style="width: 10%" />
            </div>
        </div>
        <div class="div-Out" style="width: 940px">
            <div class="div-Left" style="font-weight:bold;font-size:14px">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("lydovaovien")%>
            </div>
            <div class="div-Right" style="width: 80%">
                <input disabled="true" mkv="true" id="LYDOVAOVIEN" type="text" style="width: 70%" />
            </div>
        </div>
    </div>
</div>
