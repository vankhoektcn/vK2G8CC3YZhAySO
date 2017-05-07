<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HSBA.aspx.cs" Inherits="HSBA" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>THONG TIN HO SO BENH AN</TITLE>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="" type="text/css" rel="stylesheet">
		<LINK href="../css/default.css" type="text/css" rel="stylesheet">
		<link href="style.css" type="text/css" rel="stylesheet"/>
		<script language="vbscript">
			Sub Exprot
				Dim sHTML
				'sHTML = window.parent.frames("bottom").document.forms(0).outerhtml
				sHTML = document.forms(0).outerhtml
				'sHTML = window.parent.frames("bottom").document.forms(0).children("Label1").outerhtml
				Dim oXL, oBook
				Set oXL = CreateObject("Excel.Application")
				Set oBook = oXL.Workbooks.Add
				oBook.HTMLProject.HTMLProjectItems("Sheet1").Text = sHTML
				oBook.HTMLProject.RefreshDocument
				oXL.Visible = true
				oXL.UserControl = true
			End Sub
			
		</script>
		<style type="text/css">
                    @media print {
                    input.noPrint { display: none; }
                    }
                </style>
	</HEAD>
	<BODY class="DefPageStyle" leftMargin="0" topMargin="0" rightMargin="0">
		<div align="center">
			<form id="Form1" name="Form1" runat="server">
			
			    <table cellpadding = "0" cellspacing = "0" border = "0" width = "80%">
			        
			        <tr>
			            <td style ="width:100%">
			                <p id = "divnoidung" runat = "server"></p>	
			            </td>
			        </tr>
			    <!--
			<tr>
								<td colspan="2" class="tieude" style="padding-bottom:10px" bgcolor="#B5CFF8">IV. QUÁ TRÌNH ĐIỀU TRỊ</td>
						  </tr>
						  	
						  
						  
						  <tr>
							<td colspan="2">
									<table width="100%" border="0" cellspacing="0" cellpadding="0">
									  <tr>
										<td width="25%">&nbsp;</td>
										<td width="75%">&nbsp;</td>
									  </tr>
									  
									  <tr>
										<td>&nbsp;</td>
										<td>&nbsp;</td>
									  </tr>
									  
									  <tr>
										<td width="30%" class="text" align="right">Ngày điều trị &nbsp;</td>
										<td><input type="text" size="70" name="textfield3" style="width:400; height:17" /></td>
									  </tr>
									  <tr>
										<td width="30%" class="text" align="right">Triệu chứng &nbsp;</td>
										<td>							  
											<input type="text" size="70" name="textfield6" style="width:400; height:17" />
										<input type="text" size="70" name="textfield" style="width:400; height:17" />							</td>
									  </tr>
									  <tr>
										<td width="30%" height="22" align="right" class="text">Toa thuốc&nbsp;</td>
										<td style="padding-left:15px"><a href  = "toathuoc.aspx">Ra toa thuốc</a></td>
									  </tr>
									  <tr>
										<td width="30%" class="text" align="right">Kết quả&nbsp;</td>
										<td><input type="text" size="70" name="textfield" style="width:400; height:17" /></td>
									  </tr>
									  
									  <tr>
										<td width="30%" class="text" align="right">Hướng giải quyết tiếp theo&nbsp;</td>
										<td>							  
											<input type="text" size="70" name="textfield" style="width:400; height:17" />							</td>
									  </tr>	
									  <tr>
										<td width="30%" class="text" align="right">Chỉ định cận lâm sàn&nbsp;</td>
										<td>							  
											<input type="text" size="70" name="textfield" style="width:400; height:17" />							</td>
									  </tr>	
									  <tr>
										<td width="30%" class="text" align="right">Bác sĩ điều trị&nbsp;</td>
										<td>							  
											<input type="text" size="70" name="textfield" style="width:400; height:17" />						</td>
									  </tr>
									  <tr>
										<td width="30%" class="text" align="right"></td>
										<td style="padding-left:80px">		<br>					  
											<input type="button" name="lưu" style="width:60" value="Lưu lại" />						</td>
									  </tr>
							</table>							</tr>		  
						  <tr>
							<td colspan="2" class="tieude" style="padding-top:10px">CHI TIẾT THÔNG TIN QUÁ TRÌNH ĐIỀU TRỊ </td>
						  </tr>
						  <tr>
							<td colspan="2"><br>
							  <table border="0" cellspacing="2" cellpadding="2" width="98%" bgcolor="#CCCCCC">
                                
                                <tr bgcolor="#B5CFF8">
                                  <td width="3%" valign="top"><span class="phpmaker" style="color: #000000;"> Stt </span></td>
                                  <td width="8%" valign="top"><span class="phpmaker" style="color: #000000;"> Ngày điều trị </span></td>
                                  <td width="10%" valign="top"><span class="phpmaker" style="color: #000000;"> Triệu chứng </span></td>
                                  <td width="15%"><span class="phpmaker" style="color: #000000;">Toa thuốc</span></td>
                                  <td width="12%"><span class="phpmaker" style="color: #000000;">Kết quả</span></td>
                                  <td width="24%" valign="top"><span class="phpmaker" style="color: #000000;"> Hướng giải quyết </span></td>
                                  <td width="14%" valign="top"><span class="phpmaker" style="color: #000000;">Kết quả CLS</span></td>
                                  <td width="14%" valign="top"><span class="phpmaker" style="color: #000000;"> Bác sĩ </span></td>
                                </tr>
                               
                                <tr bgcolor="#F5F5F5">
                                 
                                  <td height="81"><span class="phpmaker"> 1</span></td>
                                 
                                  <td><span class="phpmaker"></span></td>
                                 
                                  <td><span class="phpmaker"></span></td>
                                  <td><span class="phpmaker">
                                    <a href="Toathuoc.aspx"></a>
                                    </span>
                                  </td>
                                  <td><span class="phpmaker"></span></td>
                                 
                                  <td><span class="phpmaker"></span></td>
                                 
                                  <td><span class="phpmaker">
                                    <a href="../quanlynoivien/hinhchitiet.html"><img src="images/xquang.jpg" height="72" /></a>
                                    <a href="Xquang.htm"></a>
                                    <br />
                                    <br />
                                    <a href="Xetnghiem.htm"></a>
                                    <br />
                                    <br />
                                    <a href="Sieuam.htm"></a>
                                    </span>
                                  </td>
                                  <td><span class="phpmaker"></span></td>
                                </tr>
                               
                                <tr bgcolor="#FFFFFF">
                                 
                                  <td><span class="phpmaker"></span></td>
                                
                                  <td><span class="phpmaker"></span></td>
                                  
                                  <td><span class="phpmaker"></span></td>
                                  <td><span class="phpmaker"></span></td>
                                  <td><span class="phpmaker"></span></td>
                                 
                                  <td><span class="phpmaker"></span></td>
                                  
                                  <td><span class="phpmaker">
                                    <a href="../quanlynoivien/hinhchitiet.html"><img src="images/xquang.jpg" height="72" /></a>
                                    <a href="Xquang.htm"></a>
                                    <br />
                                    <br />
                                    <a href="Xetnghiem.htm"></a>
                                    <br />
                                    <br />
                                    <a href="Sieuam.htm"></a>
                                    </span>
                                  </td>
                                  <td><span class="phpmaker"></span></td>
                                </tr>
                        </table>
                        </td>
                        </tr>
                        -->
                        </table>
                        
            </form>
		</div>
	</BODY>
	<fieldset style ="border:0">				
                <input class="noPrint" type="button" value="IN" onclick="window.print()" ID="Button1"
					NAME="Button1" style ="width:80px"> &nbsp;&nbsp;&nbsp;<%--<input class="noPrint" type="button" value="Quay lại" onclick="javascript:history.go(-1)" ID="Button3"
					NAME="Button1" style ="width:80px">	--%>	
	
		</fieldset>		
</HTML>
