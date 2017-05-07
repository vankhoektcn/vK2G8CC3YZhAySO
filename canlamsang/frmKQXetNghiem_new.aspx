<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmKQXetNghiem_new.aspx.cs" Inherits="canlamsang_frmKQXetNghiem_new" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/canlamsang/uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--#include file ="header.htm"-->
 <link type="text/css" rel="stylesheet" href="css/style_truong.css" />
  <link type="text/css" rel="stylesheet" href="css/jtable.css" />
  <script type="text/javascript" src="js/jquery-1.2.3.pack.js"></script>
 <script type="text/javascript" src="js/jquery_Datamin.js"></script>
<script type="text/javascript">
         $(document).ready(function() {
            
             var check=$("[id$='txtIdKQCLS']");
             if(check.val()!="")
             {
                  document.getElementById("btnIn").style.display='block'
                    document.getElementById("btnInTieuDe").style.display='block'
             }
              var lmakq="";	 
	            var count=document.getElementById("txtSodong1").value;
	            for(var i=1;i<=count;i++)
	            {
	                var makq=document.getElementById("txtMaCLSan_"+i);
	                var mamaycls=document.getElementById("txtmamaycls_"+i);
	                var ngaythang=document.getElementById("txtNgayThucHien_"+i);	        
	                lmakq=lmakq+makq.value+"$"+mamaycls.value+"$"+ngaythang.value+"@";	        
   	            }
	            document.getElementById("txtMaKetQuaCLS").value=lmakq;	  
        });
var autoPostBack=true;
function focusNextRowKQ(obj)
{
    if(event.keyCode==40)//xuông
    {
        var posIdNext= eval(obj.id.replace('txtKQ_',''));
        posIdNext ++;
        $("#txtKQ_"+posIdNext+"").focus();
        autoPostBack= false;
        return false;
    }
    if(event.keyCode==38)//lên
    {
        var posIdNext= eval(obj.id.replace('txtKQ_',''));
        posIdNext --;
        $("#txtKQ_"+posIdNext+"").focus();
        autoPostBack= false;
        return false;
    }
}
function CheckIsClickButton()
{
    if(autoPostBack)
        return true;
    else 
        return false;
}
function checkAll(n,k)
{
    if(document.getElementById("checkValue").checked==true)
    {
        for(var i=k;i<=(n+k);i++)
	    {
	        document.getElementById("ckb_"+i+"").checked=true;
	    }
	}
	else if(document.getElementById("checkValue").checked==false)
    {
        for(var i=0;i<=(n+k);i++)
	    {
	        document.getElementById("ckb_"+i+"").checked=false;
	    }
	}
}    
function checkNhom(temp1,temp2,currdong)
{
    //alert(temp1+"/"+temp2+"/"+currdong);
     if(document.getElementById("ckbTenNhom_"+temp1).checked==true)
    {
        for(var i=currdong;i<(currdong+temp2);i++)
	    {
	        document.getElementById("ckb_"+i+"").checked=true;
	    }
	}
	else if(document.getElementById("ckbTenNhom_"+temp1).checked==false)
    {
        for(var i=currdong;i<(currdong+temp2);i++)
	    {
	        document.getElementById("ckb_"+i+"").checked=false;
	    }
	}
}
function inKQ(cotieude)
{

     var sodong = $("[id$='txtSoDong']");
     var inCLS=inclschidinh(sodong);
     var madangkycls = $("[id$='txtMaDKCLS']");
     if(inCLS!="")
       {
         window.open("rptXetNghiem_new.aspx?idDichVu=" + inCLS+"&madangkycls="+madangkycls.val()+"&tieude="+cotieude,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
      }
       else{
              window.open("rptXetNghiem_new.aspx?madangkycls=" + madangkycls.val()+"&idDichVu="+"&tieude="+cotieude,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
       }
}
function Export_Automatic(smadkcls)
{
    if(smadkcls!="")
    {
            var json = "{'madkcls':'" + smadkcls + "'}";
            var ajaxPage = "DataProcessor.aspx?ExportAutomatic=1"; 
            var options = {
                type: "POST",
                url: ajaxPage, 
                data: json,
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                async: false,
                success: function(response) {
                },
                error: function(msg) { }
            };
            var returnText = $.ajax(options).responseText;
    }
}
function luukq()
{
$("#btnLuu").css("display","none");
               var sodong = $("[id$='txtSoDong']");
               var idbs = $("[id$='ddlBacSi']");
               var madkCLS = $("[id$='txtMaDKCLS']");
               var idKQ="";
               var idKQCLS=$("[id$='txtIdKQCLS']");
                if(idKQCLS.val()!="")
                {
                    idKQ=idKQCLS.val();
                }
                else{
                     idKQ=luuKQCLS();
                }
              //var idKQ="1";
                var json="";
                var idDV="";
                var listKQ="";
                var listGiaTriBT="";
                var listIsBatThuong="";
                var listIdChietTietDV=""
                 if(idKQ!="")
                 {
                        for(var i=0;i<eval(sodong.val()-1);i++)
                        {   
                            var idbanggiadichvu=$("[id$='txtIdDichVu_"+i+"']");
                            idDV += idbanggiadichvu.val()+",";
                            var idChiTietDV=$("[id$='txtIdChiTietDichVu_"+i+"']");
                            if(idChiTietDV.val()!="")
                             {
                                listIdChietTietDV+=idChiTietDV.val()+",";
                             }
                             else{
                                listIdChietTietDV+="NULL"+",";
                             }
                            var kq=$("[id$='txtKQ_"+i+"']");
                            if(kq.val()!="")
                             {
                                listKQ+=kq.val()+",";
                             }
                             else{
                                listKQ+="NULL"+",";
                             }
                             var giatribt=$("[id$='txtGiaTriBT_"+i+"']");
                             if(giatribt.val()!="")
                             {
                                listGiaTriBT+=giatribt.val()+",";
                             }
                             else{
                                listGiaTriBT+="NULL"+",";
                             }
                            if(document.getElementById("ckbBatThuong_"+i+"").checked==true)
                             {
                                listIsBatThuong+="1,";
                             }
                             else if(document.getElementById("ckbBatThuong_"+i+"").checked==false)
                             {
                                listIsBatThuong+="0"+",";
                             }
                        }
                           
                            var json = "{'idDV':'" + idDV + "','listKQ':'" + listKQ + "','listGiaTriBT':'" + listGiaTriBT + "','listisBatThuong':'" + listIsBatThuong + "','listIdChiTietDV':'" + listIdChietTietDV + "','idKQCLS':'" + idKQ + "','idBS':'" + idbs.val() + "','maCLS':'" + madkCLS.val() + "'}";
                            var ajaxPage = "DataProcessor.aspx?luuChiTiet=1"; 
                            var options = {
                                type: "POST",
                                url: ajaxPage, 
                                data: json,
                                contentType: "application/json;charset=utf-8",
                                dataType: "json",
                                async: false,
                                success: function(response) {
                                },
                                error: function(msg) { }
                            };
                            var returnText = $.ajax(options).responseText;
                            if (returnText !="") {
                                   alert("Đã lưu thành công");
                                   $("#btnLuu").css("display","");
                                   document.getElementById("txtIdKQCLS").value=returnText;
                                   document.getElementById("btnLuu").value="Cập nhật KQ" ;
                                    document.getElementById("btnIn").style.display='block';  
                                     document.getElementById("btnInTieuDe").style.display='block';
                                      var madangky=document.getElementById("lblMaCLS");
                                      if(madangky.textContent!="")
                                      {
                                        Export_Automatic(madangky.textContent); }         
                            }
                            else {
                                 $("#btnLuu").css("display","");
                                 alert("Lưu dữ liệu thất bại");       
                            }
                 }
                 else{
                    $("#btnLuu").css("display","");
                    alert("Lưu dữ liệu thất bại"); 
                 }
              
}  
function inclschidinh(sodong)
{
     var listIDCLS="";
     for(var i=0;i<eval(sodong.val()-1);i++)
        {
            if(document.getElementById("ckb_"+i+"").checked==true)
             {
                 var idbanggiadichvu=$("[id$='txtIdChiTietDichVu_"+i+"']");
                 listIDCLS+=idbanggiadichvu.val()+",";
             }
        }
     return listIDCLS;
}  
function setValue()
	{
		var count=document.getElementById("txtSodong1").value;
		var maValue=document.getElementById("txtMaCLSan_1").value;
		for(var i=1;i<=count;i++)
	    {
	    value=document.getElementById("txtMaCLSan_"+i).value=maValue;
	    }

	}
function luuKQCLS()
{ 
   var madangkyCLS = $("[id$='txtMaDKCLS']");
   var idbenhnhan = $("[id$='txtidbenhnhan']");
        var json = "{'madangkyCLS':'" + madangkyCLS.val() + "','idBenhNhan':'" + idbenhnhan.val() + "'}";
                var ajaxPage = "DataProcessor.aspx?Save=1"; 
                var options = {
                    type: "POST",
                    url: ajaxPage, 
                    data: json,
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function(response) {
                    },
                    error: function(msg) { alert("failed: " + msg); }
                };
                var returnText = $.ajax(options).responseText;
                if (returnText !="") {
                   return  returnText;               
                }
                else {
                    return returnText;
                    }
}
function LuuMaCLS()
{
 var dv=document.getElementById("txtTenDV_1").value;
    var count=document.getElementById("txtSodong1").value;
    var temp="";
    var maKQ="";
    for(var i=1;i<=count;i++)
    {
         var makq=document.getElementById("txtMaCLSan_"+i);
	     var mamaycls=document.getElementById("txtmamaycls_"+i);
	     var ngaythang=document.getElementById("txtNgayThucHien_"+i);	 
	     var tenDV=document.getElementById("txtTenDV_"+i);       
	     temp=temp+makq.value+"$"+tenDV.value+"$"+mamaycls.value+"$"+ngaythang.value+"@";
         maKQ=maKQ+makq.value+"$"+mamaycls.value+"$"+ngaythang.value+"@";	        
   }
   document.getElementById("txtTemp").value=temp;
   document.getElementById("txtMaKetQuaCLS").value=maKQ;
  // alert(maKQ);
}
function showPopup(obj,id)
{
            $(obj).dblclick(function(e)
              {
                 var idbenhnhan = $("[id$='txtidbenhnhan']");
                 var madangkyCLS = $("[id$='txtMaDKCLS']");
                 var json = "{'iddichvu':'" + id + "','idBenhNhan':'" + idbenhnhan.val() + "','macls':'"+madangkyCLS.val()+"'}";
                var ajaxPage = "DataProcessor.aspx?loadKQTruoc=1"; 
                var options = {
                    type: "POST",
                    url: ajaxPage, 
                    data: json,
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function(response) {
                    },
                    error: function(msg) { }
                };
                var returnText = $.ajax(options).responseText;
                if (returnText !="") {
                 document.getElementById("popuup_div").innerHTML=returnText;     
                  var height = $('#popuup_div').height();
                  var width = $('#popuup_div').width();
                  leftVal=e.pageX-(width/2)+"px";
                  topVal=e.pageY-(height/2)+"px"; 
                 $('#popuup_div').css({left:leftVal,top:topVal}).show();          
                }
                else {
                   return returnText;
                  }

              }); 
}
function hidePop()
{
    document.getElementById("popuup_div").style.display='none';
}
function LuuTraDichVu()
{
               var sodong = $("[id$='txtSoDong']");
                var idDV="";
                for(var i=0;i<eval(sodong.val()-1);i++)
                {   
                      if (document.getElementById("ckbTraDV_"+i).checked)
                      {
                          var idbanggiadichvu=$("[id$='txtIdDichVu_"+i+"']");
                          idDV += idbanggiadichvu.val()+",";
                      }
                            
                }
                if(idDV!="")
                {
                    var madangky=document.getElementById("lblMaCLS");
                     var json = "{'idDV':'" + idDV + "','madangky':'"+madangky.textContent+"'}";
                            var ajaxPage = "DataProcessor.aspx?luuTraDV=1"; 
                            var options = {
                                type: "POST",
                                url: ajaxPage, 
                                data: json,
                                contentType: "application/json;charset=utf-8",
                                dataType: "json",
                                async: false,
                                success: function(response) {
                                },
                                error: function(msg) { }
                            };
                            var returnText = $.ajax(options).responseText;
                            if (returnText !="") {
                                   alert("Đã lưu thành công");
                            }
                            else {
                                 alert("Lưu dữ liệu thất bại");       
                            }
                }
                
}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Kết Quả Xét Nghiệm</title>
</head>
<body>
    <form id="form1" runat="server">
<%--            <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="panel" runat="server">
        <ContentTemplate>--%>
    <div style="width:100%">
        <asp:PlaceHolder ID="placeMenu" runat="server"></asp:PlaceHolder>
    </div>
    <br />
    <div class="khung">
         <div style="width:100%;background-color: #4D67A2;text-align:center" class="title">
             <p class="title" style ="color:#FFFFFF">KẾT QUẢ XÉT NGHIỆM</p>
         </div>
         <div style="width:100%">
         <fieldset><legend style="color:Blue;font-size:16px;">Thông tin bệnh nhân xét nghiệm</legend>
            <table id="mytable" cellspacing="0">
            <%--<caption>Thông tin bệnh nhân xét nghiệm</caption>--%>
                    <tr>
                      <th scope="row" class="spec">Mã BN : <asp:Label CssClass="labBN" ID="lbMaBN" runat="server"></asp:Label></th>
                      <th scope="row" class="spec">Tên Bệnh Nhân:<asp:Label CssClass="labBN" ID="lblTenBN" runat="server"></asp:Label></th>
                      <th scope="row" class="spec">Năm Sinh : <asp:Label CssClass="labBN" ID="lblNamSinh" runat="server"></asp:Label></th>                    

                    </tr>
                    <tr>
                      <th scope="row" class="spec">Giới Tính :<asp:Label CssClass="labBN" ID="lblGioiTinh" runat="server"></asp:Label></th>
                      <th scope="row" class="spec">Mã CLS : <asp:Label CssClass="labBN" ID="lblMaCLS" runat="server"></asp:Label></th>                    
                      <th scope="row" class="spec">Ngày làm CLS: <asp:Label CssClass="labBN" ID="lblNgayCLS" runat="server"></asp:Label></th>              
                 </tr>
                 <tr>
                  <th scope="row" class="spec" colspan="2">Chọn khoa/Phòng : <asp:dropdownlist id="ddlPK" runat="server" autopostback="true" width="200px"></asp:dropdownlist></th>
                    <th scope="row" class="spec">Bác sĩ CLS : <asp:dropdownlist id="ddlBacSi" runat="server" width="200px"></asp:dropdownlist></th>
                   </tr>                
        </table>
        </fieldset>
     </div>
     <div id="showDivCLS" runat="server">
     <div style="float:left" >
           <span id = "showchidinhCLS" runat="server"></span>
           <input type="hidden" runat="server" id="txtMaKetQuaCLS"/>
         </div>
         <div style="float:left;padding-top:10px;padding-left:10px">
         <asp:Button ID="btnLayKQ" runat="server" OnClick="btnLayKQ_Click" CssClass="button" OnClientClick="LuuMaCLS();" Text="Lấy KQ tự động"/>
            <%--<input class="button" type="button" value="Lấy KQ tự động" />--%>
           </div>
           </div>
     <br />
     <fieldset><legend style="color:Blue;font-size:16px;">Thông tin điều trị xét nghiệm</legend>
     <div id="divDieuTri" runat="server"> 
     </div>
     </fieldset>
    </div>
    <div style="padding-top:10px">
      <input type="button" class="button" id="btnLuu" value="Lưu Kết Quả" onclick="luukq();"  style="cursor:pointer;float:left"/>
       <input type="button" class="button" id="btnIn" value="In kết quả" onclick="inKQ('N');" style="cursor:pointer;display:none;float:left"/>
        <input type="button" class="button" id="btnInTieuDe" value="In kết quả có tiêu đề" onclick="inKQ('Y');" style="cursor:pointer;float:left;display:none;width: 162px;"/></div>
        <input type="button" class="button" id="btnLuuTraDV" value="Lưu không làm dịch vụ" onclick="LuuTraDichVu()"  style="cursor:pointer;float:left;width:170px;"/>
    <div id="hidden">
        <input type="hidden" id="txtidbenhnhan" runat="server"/>
        <input type="hidden" id="txtMaDKCLS" runat="server"/>
        <input type="hidden" id="txtIdKQCLS" runat="server"/>
        <input type="hidden" id="txtTemp" runat="server" />
    </div>
        <div id="popuup_div" class="popup_msg">
        </div> 
   <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
<!--#include file ="footer.htm"-->
