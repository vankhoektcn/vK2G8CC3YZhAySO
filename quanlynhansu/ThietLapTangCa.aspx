<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThietLapTangCa.aspx.cs" Inherits="ThietLapTangCa" %>

<%@ Register Src="~/quanlynhansu/uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file = "header.htm" -->



<script type="text/javascript">
var dp_cal, dp_cal1,SoGioTangCa;      
	window.onload = function () 
	{
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtNgay'));
	};
function showDanhSachNhanVien()
{	
    
	var idpb = document.getElementById("ddlPhongBan").value;
    if(idpb =="0")
      {
        alert("Vui lòng chọn phòng ban trước khi chọn Nhân Viên !");
        return;
      }
	var listID = document.getElementById('listIdNV').value;
	hideTip("tipnhanvien");
 var td = document.getElementById("showtipNhanVien");
 var txtListIdPhongCheckAll= document.getElementById("txtListIdPhongCheckAll").value;
 createTipFocus(td,"tipnhanvien","danhsachNhanVien","Danh sách Nhân Viên","ajaxbenhnhanexists"," đang load danh sách Nhân Viên...","Lỗi trong quá trình load danh sách nhân viên","../quanlynhansu/ajax.aspx?do=showDSNV&listID="+listID+"&txtListIdPhongCheckAll="+txtListIdPhongCheckAll+"&idpb="+idpb+"", "750", "500",null);   
}
	
function setChonNhanVien(idNhanVien,idCheck)
{
	
	if(idCheck.checked == true || idCheck == true)
	{
	var strIDDV = document.getElementById('listIdNV').value;
	document.getElementById('listIdNV').value = strIDDV + idNhanVien + ",";
	
	}
	else
	{
	
	  if(document.getElementById('listIdNV').value.indexOf(",")!=-1)
	    {
	    	
	    var arrIDDVDelete = document.getElementById('listIdNV').value.split(',');
	   document.getElementById('listIdNV').value="";
	        for(var i=0;i<arrIDDVDelete.length;i++)
	        {
	         
    	        if(arrIDDVDelete[i]==idNhanVien)
    	        {
    	        }
    	        else
    	        {
    	         if(arrIDDVDelete[i]!="")
    	          {
    	            document.getElementById('listIdNV').value =document.getElementById('listIdNV').value+ arrIDDVDelete[i]+",";
    	          }
    	        }
    	        
	        }
	     
	    }
	    
	}
	
}	
function setChonCaPhong(listIdNVbyPB,idphong,idCheck)
{
 document.getElementById("txtListIdPhongCheckAll").value="";
 var strIDDV = document.getElementById('listIdNV').value; 
 var arrIDNVbyPB = listIdNVbyPB.split(',');
    if(idCheck.checked == true)
	{
	    document.getElementById("txtListIdPhongCheckAll").value+=document.getElementById("txtListIdPhongCheckAll").value+idphong+",";
	    //Cập nhật lại(Thêm mới) danh sách Nhân Viên
	    for(var i =0 ;i<arrIDNVbyPB.length;i++)
	    {
	        if(document.getElementById('listIdNV').value.indexOf(",")!=-1)
	        {
	            var dk = 0;
	            var arrTextIDDV = document.getElementById('listIdNV').value.split(',');
	            for(var j = 0 ; j<arrTextIDDV.length;j++)
	            {
	                if(arrIDNVbyPB[i]==arrTextIDDV[j])
	                {
        	        dk=1;
        	        break;
	                }
	                else
                    {
                        dk = 0;
                    }
	            }
	            if (dk == 1)
                {

                }
                else
                {
                   document.getElementById('listIdNV').value=document.getElementById('listIdNV').value+arrIDNVbyPB[i]+",";
    	            
                }
	        }
	        else
	        {
	        document.getElementById('listIdNV').value=document.getElementById('listIdNV').value+arrIDNVbyPB[i]+",";
	        }
	    }
	}
	else
	{
	    document.getElementById('txtListIdPhongCheckAll').value.replace(idphong +",","");
	    //Cập nhật lại(Lược bớt) danh sách Nhân Viên
	    var arrTextIDNVOld = document.getElementById('listIdNV').value.split(',');	    
	    document.getElementById('listIdNV').value="";
	    for(var i =0 ;i<arrTextIDNVOld.length;i++)
	    {
//	        if(document.getElementById('listIdNV').value.indexOf(",")!=-1)
//	        {
	            var dk = 0;
	            var arrTextIDDV =listIdNVbyPB.split(',');  //document.getElementById('listIdNV').value.split(',');
	            for(var j = 0 ; j<arrTextIDDV.length;j++)
	            {
	                if(arrTextIDNVOld[i]==arrTextIDDV[j])
	                {
        	        dk=1;
        	        break;
	                }
	                else
                    {
                        dk = 0;
                    }
	            }
	            if (dk == 1)
                {

                }
                else
                {
                   document.getElementById('listIdNV').value=document.getElementById('listIdNV').value+arrTextIDNVOld[i]+",";
    	            
                }
//	        }
//	        else
//	        {
//	        document.getElementById('listIdNV').value=document.getElementById('listIdNV').value+arrTextIDNVOld[i]+",";
//	        }
	    }
	}
	showDanhSachNhanVien();
}
function showKQCLS()
{
	  var oidbn = document.getElementById("txtidbenhnhan");
	var listIDNV = document.getElementById('listIdNV').value;
	//alert("showKQCLS,listIdNV="+listIDNV);
	 if(listIDNV != "")
	 {
	  xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                //var value = value1.split('@');
                var oCLS = document.getElementById("showDanhSachNVchon");
	            oCLS.innerHTML = value;
	            hideTip("tipcls");
	             document.getElementById("showDanhSachNVchon").style.display = '';
	                 
            }
        }
        var LoaiBN= document.getElementById("cbLoaiBN");
        xmlHttp.open("GET","ajax.aspx?do=showKQCLS&listIDNV="+listIDNV+"&times="+Math.random(),true);
        xmlHttp.send(null);
      }
      else
      {
        hideTip("tipnhanvien");	
          document.getElementById("showDanhSachNVchon").style.display = 'none';
      }
}
function KiemTraGio()
{
     var ddlTuGioText = document.getElementById("txtTuGio").value.split(':');
     if(ddlTuGioText.length <2)
        {
       return false;
        }
     var ddlDenGioText = document.getElementById("txtDenGio").value.split(':');
     if(ddlDenGioText.length <2)
        {
       return false;
        }
     if (CheckNumberFloat(ddlTuGioText[0])==false || CheckNumberFloat(ddlTuGioText[1])==false || CheckNumberFloat(ddlDenGioText[0])==false || CheckNumberFloat(ddlDenGioText[1])==false)
			{
				return false;				
			}
	if(eval(ddlTuGioText[0]) <0 || eval(ddlTuGioText[0]) >23 || eval(ddlTuGioText[0])<0 || eval(ddlTuGioText[0]) >23 )
	    return false;
	if(eval(ddlTuGioText[1]) <0 || eval(ddlTuGioText[1]) >59 || eval(ddlTuGioText[1])<0 || eval(ddlTuGioText[1]) >59 )
	    return false;    
	var TuGio=eval(ddlTuGioText[0])+ eval(ddlTuGioText[1])/60;
	//alert("TuGio="+TuGio);
	var DenGio=eval(ddlDenGioText[0])+ eval(ddlDenGioText[1])/60;
	//alert("DenGio="+DenGio);
	if(eval(DenGio) <= eval(TuGio))
	{
	        return false;
	}
	else
	{
	    this.SoGioTangCa =DenGio - TuGio;// eval(DenGio) - eval(TuGio) ;
	    //alert(this.SoGioTangCa);
	    return true;
	}
}
function LuuThietLapCa(update)
{
    var idTangCaKiemTra = document.getElementById("txtidTangCa").value;
     if(update==1)
     {
        if(idTangCaKiemTra=="")
        {
            alert("Bạn chưa chọn Tăng ca muốn cập nhật");
            return false;
        }
     }
     //Kiem tra Gio
     var ddlTuGioText=document.getElementById("txtTuGio").value;
     var ddlDenGioText=document.getElementById("txtDenGio").value;
     if(ddlTuGioText=="" || ddlDenGioText =="")
     {
        alert("Bạn chưa nhập giờ.Vui lòng nhập giờ hợp lệ !");
        return false;
     }
     
     if(KiemTraGio()==false)
     {
        alert("Giờ tăng ca không hợp lệ !");
        return false;
     }

     //End Kiem tra Gio
//Kiểm tra dữ liệu 
    var idLoaiTangCa = document.getElementById("ddlLoaiTangCa").value;
    if(idLoaiTangCa=="0" || idLoaiTangCa=="")
    {
        alert("Bạn chưa chọn loại tăng ca !");
        document.getElementById("ddlLoaiTangCa").focus();
        return false;
    }
    //alert("abcde");
    var listIDNV = document.getElementById('<%=listIdNV.ClientID %>').value;

    if(listIDNV=="0" || listIDNV=="")
    {
        alert("Bạn chưa chọn nhân viên tăng ca!");
        document.getElementById('listIdNV').focus();
        return false;
    }
    var txtNgay = document.getElementById("txtNgay").value;
    if(txtNgay=="0" || txtNgay=="")
    {
        alert("Bạn chưa chọn ngày tăng ca!");
        document.getElementById('txtNgay').focus();
        return false;
    }
    //Luu Thiết lập ca
    
     var idTangCa = document.getElementById("txtidTangCa").value;
     if(update==1)
     {
        if(idTangCa=="")
        {
            alert("Bạn chưa chọn Tăng ca muốn cập nhật");
            return false;
        }
        UpdateThietLapCa(idTangCa,idLoaiTangCa,listIDNV,txtNgay,ddlTuGioText,ddlDenGioText,this.SoGioTangCa);
     }
     else
        saveasThietLapCa(idLoaiTangCa,listIDNV,txtNgay,ddlTuGioText,ddlDenGioText,this.SoGioTangCa);
        
     
}
function saveasThietLapCa(idLoaiTangCa, listIDNV, txtNgay, ddlTuGioText, ddlDenGioText,sogio)
	{
	    xmlHttp = GetMSXmlHttp();
	    
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if(eval(value) == 0)
                {
                   alert("Có lỗi xảy ra trong quá trình lưu thông tin thiết lập ca. Vui lòng thử lại lần sau.");
                   return false;
                }               
                else
                {   
                    alert("Đã lưu thiết lập tăng ca thành công !");    
                    //document.getElementById('listIdNV').value="";
                    //document.getElementById("showDanhSachNVchon").style.display = 'none';
                    document.getElementById('txtidTangCa').value=value;
                    //alert("txtidTangCa="+document.getElementById('txtidTangCa').value);
                } 
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=LuuThietLapCa&idLoaiTangCa="+idLoaiTangCa+"&listIDNV="+listIDNV+"&txtNgay="+txtNgay+"&ddlTuGioText="+ddlTuGioText+"&ddlDenGioText="+ddlDenGioText+"&sogio="+sogio+"&times="+Math.random() ,true);
        xmlHttp.send(null);
	}
function UpdateThietLapCa(idTangCa,idLoaiTangCa,listIDNV,txtNgay,ddlTuGioText,ddlDenGioText,sogio)
{
    xmlHttp = GetMSXmlHttp();
	    
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if(eval(value) == 0)
                {
                   alert("Có lỗi xảy ra trong quá trình cập nhật thông tin thiết lập ca. Vui lòng thử lại lần sau.");
                   return false;
                }               
                else
                {   
                    alert("Đã cập nhật thiết lập tăng ca thành công !");    
                    //document.getElementById('listIdNV').value="";
                    //document.getElementById("showDanhSachNVchon").style.display = 'none';
                } 
            }
        }
        //alert("idTangCa="+idTangCa);
        xmlHttp.open("GET","ajax.aspx?do=UpdateThietLapCa&idTangCa="+idTangCa+"&idLoaiTangCa="+idLoaiTangCa+"&listIDNV="+listIDNV+"&txtNgay="+txtNgay+"&ddlTuGioText="+ddlTuGioText+"&ddlDenGioText="+ddlDenGioText+"&sogio="+sogio+"&times="+Math.random() ,true);
        xmlHttp.send(null);
}
function SetValueEmpty()
{
    window.location.href="ThietLapTangCa.aspx";
    return;
    document.getElementById('listIdNV').value="";
    document.getElementById("showDanhSachNVchon").style.display = 'none';
    document.getElementById('txtidTangCa').value="";
    showKQCLS();
}
</script>

<form id="frmBSPK" method="post" runat="server">
    <div  style="background-color: #FBF8F1;text-align:left;padding-left:20px">
        <uc1:uscmenu ID="Uscmenu1" runat="server" />
    </div>
    <br />
    <div style="background-color: White;" align="left">
        <div style="width: 100%; padding-left: 10px; background-color: #FBF8F1; height: 19px;
            background-image: url(../images/menu.jpg); color: Red; font-weight: bold">
            <span style="color: Red; font-weight: bold; font-size: 12pt;">
                <div style="margin-top: 0px; padding-left: 5px">
                    THIẾT LẬP TĂNG CA</div>
            </span>
        </div>
        <br />
        <div style="text-align: left; width: 700px; padding-left: 50px; background-color: White;">
            <table width="700px" rules="none" cellpadding="0px" cellspacing="0px" style="border-color: Blue;
                border-style: double; border: 4px; padding-left: 0px;" bgcolor="#dad3f5">
                <%--<tr>
                                                                                    <td valign="top" nowrap align="right" style="height: 23px; padding-left: 10px; width: 110px;">
                                                                                        <p class="ptext">
                                                                                            Mã loại tăng ca :&nbsp;
                                                                                        </p>
                                                                                    </td>
                                                                                    <td valign="top" align="left" width="430" style="width: 430px; height: 23px;" colspan="3">
                                                                                        <p class="ptext">
                                                                                            <asp:textbox id="txtmachucvu" runat="server" width="248px" tabindex="2" height="19px"></asp:textbox>
                                                                                        </p>
                                                                                    </td>
                                                                                </tr>--%>
                <tr>
                    <td colspan="4" style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="left" style="height: 40px; padding-left: 10px; width: 13%;">
                        <p class="ptext">
                            Loại Tăng Ca:&nbsp;
                        </p>
                    </td>
                    <td valign="top" align="left" style="width: 25%; height: 40px; padding-right: 0px">
                        <p class="ptext">
                            <%--<asp:textbox id="txtMaLoaiNgayNghi" runat="server" width="248px" tabindex="4"></asp:textbox>--%>
                            <asp:dropdownlist id="ddlLoaiTangCa" runat="server" width="100%" tabindex="1"></asp:dropdownlist>
                            &nbsp;</p>
                    </td>
                    <td valign="top" align="right" style="padding-right: 2px; width: 6%;">
                        <p class="ptext">
                            Phòng:
                        </p>
                    </td>
                    <td valign="top" align="left" style="width: 40%; height: 40px; padding-right: 0px">
                        <p class="ptext">
                            <asp:dropdownlist id="ddlPhongBan" runat="server" width="63%" tabindex="1"></asp:dropdownlist>
                            &nbsp;
                            <input id="btnChonNhanVien" type="button" style="width: 100px" onclick="showDanhSachNhanVien();"
                                value="Chọn Nhân Viên" />
                        </p>
                    </td>
                </tr>
                <tr height="auto">
                    <td colspan="4" style="height: 2px" id="showtipNhanVien">
                </tr>
                <tr>
                    <td colspan="4" style="height: 60px">
                        <table width="100%" cellpadding="0px" cellspacing="0px" style="padding-left: 0px;
                            padding-right: 0px">
                            <tr>
                                <td valign="top" align="left" style="height: 40px; padding-left: 10px; width: 10%;">
                                    Ngày:
                                </td>
                                <td valign="top" align="right" style="width: 25%; height: 40px; padding-left: 10px">
                                    <asp:textbox id="txtNgay" runat="server" width="70%" tabindex="5"></asp:textbox>
                                    <input id="Button2" type="button" value="..." onclick="dp_cal.toggle()" />&nbsp;</td>
                                <td valign="top" align="right" style="height: 40px; padding-left: 10px; width: 7%;">
                                    Từ:
                                </td>
                                <td valign="top" align="right" style="width: 25%; height: 40px; padding-right: 0px">
                                    <%--<asp:textbox id="txtTuGio" runat="server" Width="95px"></asp:textbox>--%>
                                    <input id="txtTuGio" runat="server" type="text" style="width: 95px" />
                                    (hh:mm)
                                    <%--<asp:textbox id="txtSoLuong" runat="server" width="100%" tabindex="4"></asp:textbox>--%>
                                    <%--<asp:dropdownlist id="ddlTuGio" runat="server" width="100%" tabindex="7">
                                           <asp:ListItem Value="-1">--Chọn--</asp:ListItem>
                                           <asp:ListItem Selected="True" Value="5.0">5:00 h</asp:ListItem>
                                           <asp:ListItem Value="5.5" >5 h 30</asp:ListItem>
                                           <asp:ListItem Value="6.0">6:00 h</asp:ListItem>
                                           <asp:ListItem Value="6.5">6 h 30</asp:ListItem>
                                           <asp:ListItem Value="7.0">7:00 h</asp:ListItem>
                                           <asp:ListItem Value="7.6">7 h 30</asp:ListItem>
                                           <asp:ListItem Value="8.0">8:00 h</asp:ListItem>
                                           <asp:ListItem Value="8.5">8 h 30</asp:ListItem>
                                           <asp:ListItem Value="9.0">9:00 h</asp:ListItem>
                                           <asp:ListItem Value="9.5">9 h 30</asp:ListItem>
                                           <asp:ListItem Value="10.0">10:00 h</asp:ListItem>
                                           <asp:ListItem Value="10.5">10 h 30</asp:ListItem>
                                           <asp:ListItem Value="11.0">11:00 h</asp:ListItem>
                                           <asp:ListItem Value="11.5">11 h 30</asp:ListItem>
                                           <asp:ListItem Value="12.0">12:00 h</asp:ListItem>
                                           <asp:ListItem Value="12.5">12 h 30</asp:ListItem>
                                           <asp:ListItem Value="13.0">13:00 h</asp:ListItem>
                                           <asp:ListItem Value="13.0">13 h 30</asp:ListItem>
                                           <asp:ListItem Value="14.0">14:00 h</asp:ListItem>
                                           <asp:ListItem Value="14.5">14 h 30</asp:ListItem>
                                           <asp:ListItem Value="15.0">15:00 h</asp:ListItem>
                                           <asp:ListItem Value="15.5">15 h 30</asp:ListItem>
                                           <asp:ListItem Value="16.0">16:00 h</asp:ListItem>
                                           <asp:ListItem Value="16.5">16 h 30</asp:ListItem>
                                           <asp:ListItem Value="17.0">17:00 h</asp:ListItem>
                                           <asp:ListItem Value="17.5">17 h 30</asp:ListItem>
                                           <asp:ListItem Value="18.0">18:00 h</asp:ListItem>
                                           <asp:ListItem Value="18.5">18 h 30</asp:ListItem>
                                           <asp:ListItem Value="19.0">19:00 h</asp:ListItem>
                                           <asp:ListItem Value="19.5">19h 30</asp:ListItem>
                                           <asp:ListItem Value="20.0">20:00 h</asp:ListItem>
                                           <asp:ListItem Value="20.5">20 h 30</asp:ListItem>
                                           <asp:ListItem Value="21.0">21:00 h</asp:ListItem>
                                           <asp:ListItem Value="21.5">21 h 30</asp:ListItem>
                                           <asp:ListItem Value="22.0">22:00 h</asp:ListItem>
                                           <asp:ListItem Value="22.5">22 h 30</asp:ListItem>
                                           <asp:ListItem Value="23.0">23:00 h</asp:ListItem>
                                           <asp:ListItem Value="23.5">23 h 30</asp:ListItem>
                                    </asp:dropdownlist>--%>
                                </td>
                                <td valign="top" align="right" style="padding-right: 2px; width: 7%; height: 40px;">
                                    Đến :
                                </td>
                                <td valign="top" align="right" style="width: 25%; height: 40px; padding-right: 10px">
                                    <%--<asp:textbox id="txtDenGio" runat="server" Width="95px" ></asp:textbox>--%>
                                    <input id="txtDenGio" runat="server" type="text" style="width: 94px" />
                                    (hh:mm)<%--<asp:textbox id="txtSoTien" runat="server" width="80%" tabindex="3"></asp:textbox>--%><%--<asp:dropdownlist id="ddlDenGio" runat="server" width="100%" tabindex="7">
                                           <asp:ListItem Value="-1">--Chọn--</asp:ListItem>
                                           <asp:ListItem Selected="True" Value="5.0">5:00 h</asp:ListItem>
                                           <asp:ListItem Value="5.5">5 h 30</asp:ListItem>
                                           <asp:ListItem Value="6.0">6:00 h</asp:ListItem>
                                           <asp:ListItem Value="6.5">6 h 30</asp:ListItem>
                                           <asp:ListItem Value="7.0">7:00 h</asp:ListItem>
                                           <asp:ListItem Value="7.6">7 h 30</asp:ListItem>
                                           <asp:ListItem Value="8.0">8:00 h</asp:ListItem>
                                           <asp:ListItem Value="8.5">8 h 30</asp:ListItem>
                                           <asp:ListItem Value="9.0">9:00 h</asp:ListItem>
                                           <asp:ListItem Value="9.5">9 h 30</asp:ListItem>
                                           <asp:ListItem Value="10.0">10:00 h</asp:ListItem>
                                           <asp:ListItem Value="10.5">10 h 30</asp:ListItem>
                                           <asp:ListItem Value="11.0">11:00 h</asp:ListItem>
                                           <asp:ListItem Value="11.5">11 h 30</asp:ListItem>
                                           <asp:ListItem Value="12.0">12:00 h</asp:ListItem>
                                           <asp:ListItem Value="12.5">12 h 30</asp:ListItem>
                                           <asp:ListItem Value="13.0">13:00 h</asp:ListItem>
                                           <asp:ListItem Value="13.0">13 h 30</asp:ListItem>
                                           <asp:ListItem Value="14.0">14:00 h</asp:ListItem>
                                           <asp:ListItem Value="14.5">14 h 30</asp:ListItem>
                                           <asp:ListItem Value="15.0">15:00 h</asp:ListItem>
                                           <asp:ListItem Value="15.5">15 h 30</asp:ListItem>
                                           <asp:ListItem Value="16.0">16:00 h</asp:ListItem>
                                           <asp:ListItem Value="16.5">16 h 30</asp:ListItem>
                                           <asp:ListItem Value="17.0">17:00 h</asp:ListItem>
                                           <asp:ListItem Value="17.5">17 h 30</asp:ListItem>
                                           <asp:ListItem Value="18.0">18:00 h</asp:ListItem>
                                           <asp:ListItem Value="18.5">18 h 30</asp:ListItem>
                                           <asp:ListItem Value="19.0">19:00 h</asp:ListItem>
                                           <asp:ListItem Value="19.5">19h 30</asp:ListItem>
                                           <asp:ListItem Value="20.0">20:00 h</asp:ListItem>
                                           <asp:ListItem Value="20.5">20 h 30</asp:ListItem>
                                           <asp:ListItem Value="21.0">21:00 h</asp:ListItem>
                                           <asp:ListItem Value="21.5">21 h 30</asp:ListItem>
                                           <asp:ListItem Value="22.0">22:00 h</asp:ListItem>
                                           <asp:ListItem Value="22.5">22 h 30</asp:ListItem>
                                           <asp:ListItem Value="23.0">23:00 h</asp:ListItem>
                                           <asp:ListItem Value="23.5">23 h 30</asp:ListItem>
                                           <asp:ListItem Value="24.0">24:00 h</asp:ListItem>
                                    </asp:dropdownlist>--%>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div style="text-align: left; width: 1200px; padding-left: 20px">
            <table width="1100px">
                <tr width="100%">
                    <td colspan="10" align="left" style="width: 100%">
                        <span style="overflow: scroll; width: 100%" id="showDanhSachNVchon"></span>
                    </td>
                </tr>
            </table>
        </div>
        <%--<br />--%>
        <div style="text-align: center; width: 900px">
            <asp:panel id="pnl1" runat="server" visible="false" width="100%"> 
            </asp:panel>
            <input type="hidden" value="" runat="server" name="listIdNV" id="listIdNV" />
            <input type="hidden" value="" runat="server" name="txtidlistIdNVTangCa" id="txtidTangCa" />
            <input type="hidden" value="" runat="server" name="txtListIdPhongCheckAll" id="txtListIdPhongCheckAll" />
        </div>
        <div style="width: 100%; text-align: left; padding-left: 300px">
            <%--<input id="Button5" style="width: 50px;cursor:pointer" type="button" value="Lưu" onclick = "LuuThietLapCa()"/>--%>
            <asp:button id="btnLuu" runat="server" onclientclick="return LuuThietLapCa(0)" text="Lưu"
                width="92px"></asp:button>
            <asp:button id="btnUpDate" runat="server" visible="false" onclientclick="return LuuThietLapCa(1)"
                text="Cập nhật" width="92px"></asp:button>
            <%-- <asp:button id="btnMoi" runat="server" onclick="btnMoi_Click" text="Mới" width="82px"></asp:button>--%>
            <input id="Button5" style="width: 50px; cursor: pointer" type="button" value="Mới"
                onclick="SetValueEmpty()" />
        </div>
        <div style="width: 80%; padding-left: 00px" align="left">
            <table cellpadding="0" width="100%" border="0">
                <tr>
                    <td align="left" style="width: 100%; padding-left: 20px; background-color: #FBF8F1;
                        height: 19px; background-image: url(../images/menu.jpg); color: White; font-weight: bold">
                        DANH SÁCH CA ĐÃ THIẾT LẬP
                    </td>
                </tr>
            </table>
            <table cellpadding="0" width="100%" border="0">
                <tr>
                    <td valign="top" align="center" colspan="2" height="20" style="width: 100%">
                        <asp:datagrid id="dgr" tabindex="12" runat="server" width="100%" allowsorting="True"
                            autogeneratecolumns="False" datakeyfield="idtangca" borderwidth="1px" bordercolor="Silver"
                            onitemdatabound="dgr_ItemDataBound" cellpadding="2" ondeletecommand="DelTangCa"
                            oneditcommand="Edit" allowpaging="True" onpageindexchanged="PageIndexStyleChanged"
                            pagesize="30" headerstyle-cssclass="HeaderStyle" cssclass="GridViewStyle" pagerstyle-cssclass="PagerStyle"
                            rowstyle-cssclass="RowStyle">              
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
														    <asp:LinkButton id="lbtnDel" CommandName="Delete" runat="server" Text='<%#Bind("Xoa") %>' CssClass="alink3"></asp:LinkButton>
													    
</ItemTemplate>

<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
														    <asp:LinkButton id="lbtnEdit" CommandName="Edit" runat="server" CssClass="alink3">Chi tiết</asp:LinkButton>
													    
</ItemTemplate>

<HeaderStyle Width="7%"></HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn DataField="tenloaitangca" HeaderText="Loại tăng ca">
<HeaderStyle Wrap="False" Width="45%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngay" HeaderText="Ngày tăng ca">
<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="sonhanvien" HeaderText="Số nhân viên">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle Wrap="True" HorizontalAlign="center"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tugio" HeaderText="Từ giờ">
<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="dengio" HeaderText="Đến giờ">
<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="sogiotangca" HeaderText="Số giờ tăng ca">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="center" ></ItemStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" BackColor="#C0FFFF" Font-Bold="True" ForeColor="Blue"></HeaderStyle>
</asp:datagrid>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
</form>
<!--#include file = "footer.htm" -->