<%@ Control Language="C#" AutoEventWireup="true" CodeFile="txtMaVach.ascx.cs" Inherits="Controls_txtMaVach" %>
<script language="javascript" type="text/javascript">
    function clickButton(e, buttonid){   
  
          var evt = e ? e : window.event;  
  
          var bt = document.getElementById(buttonid);  
  
          if (bt){   
  
              if (evt.keyCode == 13){   
  
                    bt.click();   
  
                    return false;   
  
              }   
  
          }   
  
        }  
</script>
<asp:TextBox ID="txtMavach"  runat="server" onTextChanged="txtMavach_TextChanged"></asp:TextBox>
<asp:Button ID="btnTim" runat="server" Width="80px" Text="Tìm" OnClick="btnTim_Click" />&nbsp;
