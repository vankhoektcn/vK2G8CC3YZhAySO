<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NVK_sinhhieu.ascx.cs"
    Inherits="NVK_sinhhieu" %>

<%--<script type="text/javascript" src="../javascript/sinhhieu1.js">
</script>--%>
<script type="text/javascript">
             $(document).ready(function() {
               setControlFind($.mkv.queryString("idsinhhieu"));
               $("#luu").click(function () {
                   $(this).Luu({
                      ajax:"../ajax/sinhhieu_ajax1.aspx?do=Luu&idkhoasinhhieu="+$.mkv.queryString("IdKhoa")+"&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc")+"&idkhoachinh="+$.mkv.queryString("idkhoachinh"),idkhoachinh:"idsinhhieu"
                      },null,function () {
                         $("#timKiem").click();
                   });
                });
                $("#moi").click(function () {
                     $(this).Moi({idkhoachinh:"idsinhhieu"});
                });
                $("#xoa").click(function () {
                    $(this).Xoa({
                        ajax:'../ajax/sinhhieu_ajax1.aspx?do=xoa',idkhoachinh:"idsinhhieu"
                    },null,function () {
                         $("#timKiem").click();
                    });
                });
                $("#timKiem").click(function () {
                    Find(this);
                });
                $("#timKiem").click();
         });
          function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != null && idkhoatimkiem != ""){
                 $.BindFind({ajax:"../ajax/sinhhieu_ajax1.aspx?do=setTimKiem&idsinhhieu="+idkhoatimkiem,idkhoachinh:"idsinhhieu"});
              }      
          }
           function Find(control,page) {
           if(page == null) page = "1";
              $(control).TimKiem({
                    readMKV:false,
                     ajax:"../ajax/sinhhieu_ajax1.aspx?do=TimKiem&page="+page+"&idkhambenhgoc="+$.mkv.queryString("idkhambenhgoc")+"&ngaydo="+$.mkv.queryString("ngaydo")
               },function (data) {
                     $("#tableAjax_sinhhieu").html(data);
                     $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
               },function () {
                 $("#tableAjax_sinhhieu").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                 return true;
               });
              
          }
          
          function tinhBMI()
          {
             $("#BMI").val((eval($("#chieucao").val())*eval($("#chieucao").val()))/eval($("#cannang").val()));
          }

</script>
<div class="body-div" style="border-top:none">
    <%--<div class="header-div">
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("capcuu_sinhhieu")%>
    </div>--%>
    <div style="">
    <%--<div class="div-Out" style="width: 940px; padding-bottom: 0; background-color: #fff">
            <div class="div-Left" style="font-weight: bold; font-size: 17px;text-transform:uppercase">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("lichsusinhhieu")%>
            </div>
        </div>--%>
        <a class="reload" onclick="Find(this)"></a>
        <div id="tableAjax_sinhhieu">
        </div>
    </div>
    <div class="in-a" style=";padding-bottom:0px;padding-top:0px">
        <div class="div-Out" style="width: 940px; ;padding-bottom:0px;padding-top:0px">
            <div class="div-Left" style="font-weight: bold; font-size: 17px;padding-bottom:0px;padding-top:0px">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("chitietsinhhieu")%>
            </div>
        </div>
        <div class="div-Out" style="width:400px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaydo")%>
            </div>
            <div class="div-Right">
                <input mkv="true" id="ngaydo" type="text" onfocus="chuyenphim(this);$(this).datepick();"
                    onblur="TestDate(this);" style="width: 50%" />
                (dd\MM\yyyy)
            </div>
        </div>
        <div class="div-Out" style="width:250px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("mach")%>
                (L/ph)
            </div>
            <div class="div-Right" style="width:50%">
                <input mkv="true" id="mach" type="text" onfocus="chuyenphim(this);" onblur="TestSo(this,false,true);"
                    style="width: 80%" />
            </div>
        </div>
        <div class="div-Out" style="width:250px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nhietdo")%>
                (độ C)
            </div>
            <div class="div-Right" style="width:50%">
                <input mkv="true" id="nhietdo" type="text" onfocus="chuyenphim(this);" onblur="TestSo(this,false,true);"
                    style="width: 80%" />
            </div>
        </div>
        <div class="div-Out" style="width:520px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("huyetap")%>
                (mmHg)
            </div>
            <div class="div-Right" style="width:73.5%">
                <input mkv="true" id="huyetap1" type="text" onfocus="chuyenphim(this);" onblur="TestSo(this,false,true);"
                    style="width: 30%" />
                <input mkv="true" id="huyetap2" type="text" onfocus="chuyenphim(this);" onblur="TestSo(this,false,true);"
                    style="width: 30%" />
            </div>
        </div>
        <div class="div-Out"  style="width:400px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nhiptho")%>
                (lần/phút)
            </div>
            <div class="div-Right" style="width:50%">
                <input mkv="true" id="nhiptho" type="text" onfocus="chuyenphim(this);" onblur="TestSo(this,false,true);"
                    style="width: 40%" />
            </div>
        </div>
        <div class="div-Out" style="width:250px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("chieucao")%>
                (cm)
            </div>
            <div class="div-Right" style="width:45%">
                <input mkv="true" id="chieucao" type="text" onfocus="chuyenphim(this);" onblur="TestSo(this,false,true);tinhBMI();"
                    style="width: 80%" />
            </div>
        </div>
        <div class="div-Out" style="width:250px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cannang")%>
                (kg)
            </div>
            <div class="div-Right" style="width:50%">
                <input mkv="true" id="cannang" type="text" onfocus="chuyenphim(this);" onblur="TestSo(this,false,true);tinhBMI();"
                    style="width: 80%" />
            </div>
        </div>
        <div class="div-Out" style="width:400px">
            <div class="div-Left">
                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("BMI")%>
            </div>
            <div class="div-Right">
                <input mkv="true" id="BMI" type="text" onfocus="chuyenphim(this);" onblur="TestSo(this,false,true);"
                    style="width: 60%" />
            </div>
        </div>
    </div>
</div>
<div class="body-div-button">
    <div class="in-a">
        <input id="luu" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
        <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
        <input id="xoa" type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
        <input id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
    </div>
</div>
