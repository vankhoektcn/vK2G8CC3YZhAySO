<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPhieuSo1.aspx.cs" Inherits="nhanbenh_frmPhieuSo1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR"%>

<!--#include file ="header.htm"-->
<script type="text/javascript" language = "javascript">
    
 
	function timbn(obj)
	{	
	    var mabn=document.getElementById("txtBN").value;
	    $(obj).unautocomplete().autocomplete("ajax.aspx?do=GetBNInfoMa&Mabenhnhan="+mabn+"",{
	    scroll: true
	    }).result(function(event,data){
	            var a=data[0].split("/");
	            var b= document.getElementById("lbma").value;
                document.getElementById("txtBN").value=a[2];
                document.getElementById("lbma").innerText=a[1];
	            $(obj).focus();
                
	    });
	}
	function InReport()
	{
		var a=document.getElementById("lbma").innerText;
		if(a!="")
		{
		    window.open("rptPhieuKhamSucKhoe.aspx?MaBN="+a+"&isMau=1");
		}
	}
	function InReport3()
	{
		var a=document.getElementById("lbma").innerText;
		if(a!="")
		{
		  //  window.open("rptPhieuSo1.aspx?MaBN="+a+"&isMau=3");
		}
	}
	function InReport2()
	{
		var a=document.getElementById("lbma").innerText;
		if(a!="")
		{
		   // window.open("rptPhieuSo1.aspx?MaBN="+a+"&isMau=2");
		}
	}
	
	
function TABLE1_onclick() {



}

</script>
<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <%--<td width = "100%" align = "left" style="background-color:#D4D0C8; height: 10px;">
              <asp:placeholder ID="PlaceHolder1" runat="server"></asp:placeholder>
            &nbsp;
        </td>--%>
        <td width="100%" align="left" style="background-color: #D4D0C8; height: 10px;">
                        <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
                    </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style="background-color:#D4D0C8; height: 19px;">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
		    <td width="100%"   style="PADDING-LEFT:0px; PADDING-TOP:0px">
			    <table id="user" cellSpacing="1" cellPadding="1" width="100%" border="0" class = "khung">
				    <tr>
				        <td class="title" align = "center" style="background-color: #4D67A2; height: 25px;">
                            <strong>
			                <span class="title" style ="color:#FFFFFF">PHIẾU KHÁM BỆNH THEO MẪU</span></strong></td>
				    </tr>
				    <TR>
					    <TD width="100%">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD   width="100%" align="left" style="height: 60px;padding-left:50px">

                                        &nbsp;Bệnh nhân: 
                                        <%--<asp:textbox id="txtBN" runat="server" onfocus='timbn(this)'></asp:textbox>--%>
                                        
                                        <asp:textbox id="txtBN" runat="server" tabindex="1" width="389px" onfocus='timbn(this)'></asp:textbox>
                                        
                                        <%--<input type="text" name="txtTest" onfocus='timbn(this);'" style="width:150px">--%>
                                        <asp:label id="lbma" runat="server" width="150px"></asp:label>
                                        &nbsp; &nbsp;
                                        <%--<asp:button id="btIn" runat="server" onclick='InReport()' text="In phiếu" width="118px" /> --%>
                                        <input type="button" value="In Phiếu Khám"name="button2" onclick="InReport();InReport2();" style="width:150px">
                                        <%--<input type="button" value="Phiếu khám số 2"name="button3" onclick="InReport2()" style="width:150px">
                                        <input type="button" value="Phiếu khám răng hàm mặt"name="button4" onclick="InReport3()" style="width:180px">--%>
                                        
                                    </TD>
							    </TR>
						    </TABLE>
						    
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD   align="left" width="100%" height="20"  class="title"  style ="color:#FFFFFF;background-color: #4D67A2"></TD>
							    </TR>
						    </TABLE>						   
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD   align="center" width="100%" colSpan="2" height="20">
                                        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
									    &nbsp;
<br />
 <asp:Panel ID="pnlDV" runat="server" Width="100%"><BR /></asp:Panel>				

<br />


<asp:Panel ID="pnlKB" runat="server" Width="100%"></asp:Panel>	
 
 <asp:Panel ID="pnlCLS" runat="server" Width="100%"></asp:Panel>


								    </TD>
							    </TR>
						    </TABLE>
					    </TD>
				    </TR>
			    </table>
		    </td>
	    </tr>				
    </table>
    </td>
   </tr>
  </table>  
 </form>
<!--#include file ="footer.htm"-->