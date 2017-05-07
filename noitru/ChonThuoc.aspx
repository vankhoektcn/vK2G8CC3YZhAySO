<%@ Page Language="C#" MasterPageFile="~/MasterPage_New.master" AutoEventWireup="true" CodeFile="ChonThuoc.aspx.cs" Inherits="noitru_ChonCLSBenhVien" Title="Khoa sản" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="headerChiDinhK-div" >Chỉ định Thuốc,vtyt</div>
    <div id="ThuocChonClick-div" style="display:none;background:black;position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:99999;height:100%;overflow:auto;padding-top:20px">
        
    </div>
    <div  style="float:left;padding-top:40px;width:100%">
    <span style="font-size:medium;">Mã Bệnh Nhân :</span>
    <input id="txtMaBenhNhan" type="text" onkeyup="TimBenhNhanTheoMa(event)"  runat="server" style="font-size:medium;height:20px;width:130px"/>
    <span style="font-size:medium;">Tên Bệnh Nhân :</span>
    <input id="txtTenBenhNhan" type="text" runat="server"  style="font-size:medium;height:20px;width:490px"/>
    <input id="Button1" type="button" runat="server" value="Chỉ định thuốc" style="width:100px" onclick="ThuocChonClick();"  /><br /><br />
    <span style="font-size:medium;">Địa chỉ BN :</span>
    <input id="txtDiaChiBN" type="text" runat="server"  style="font-size:medium;height:20px;width:500px"/>
    <span style="font-size:medium;">Năm sinh :</span>
    <input id="txtNamSinh" type="text" runat="server"  style="font-size:medium;height:20px;width:90px"/>
    <span style="font-size:medium;">Giới tính :</span>
    <input id="txtGioiTinh" type="text" runat="server"  style="font-size:medium;height:20px;width:40px"/>
    </div>
    
    <script type="text/javascript">
        function ThuocChonClick(){
            var fileascx = "~/usercontrols/ThuocChon.ascx";
                
	        $("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
	        $.ajax({
                  type: "POST",
                  contentType: "application/json; charset=utf-8",
                  url: "ChonThuoc.aspx/Result",
                  data: "{controlName:'"+fileascx+"'}",
                   success: function (response) {
                        $("#ThuocChonClick-div").css({'display':''}).html(response);
                        $("#loadingAjax").remove();
                   }
             });
	    }
	    function TimBenhNhanTheoMa(event)
	    {
	        if( event.keyCode == 13 )
	        {
	            var maBenhNhan= document.getElementById('<%=txtMaBenhNhan.ClientID %>').value;
	            alert("maBenhNhan="+maBenhNhan);     
	            $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:"../ajax/khambenh_ajax3.aspx?do=TimKiemBenhNhanTheoMaBenhNhan&MaBenhNhan="+maBenhNhan+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"",
                      success: function (value)
                        {
                             if(value !="0")
                             {
                             alert("1");
                                var arrBN= value.split('^');
                                document.getElementById('<%=txtMaBenhNhan.ClientID %>').value=arrBN[2];
                                document.getElementById('<%=txtTenBenhNhan.ClientID %>').value=arrBN[3];
                                document.getElementById('<%=txtDiaChiBN.ClientID %>').value=arrBN[4];
                                document.getElementById('<%=txtGioiTinh.ClientID %>').value=arrBN[5];
                                document.getElementById('<%=txtNamSinh.ClientID %>').value=arrBN[6];
                                $.mkv.queryString("idkhoachinh",arrBN[1]);
                                $.mkv.queryString("idbenhnhan",arrBN[0]);
                                document.getElementById('<%=Button1.ClientID %>').style.display='';
                             }
                             else
                             {
                                alert("Mã bệnh nhân nội trú không đúng !");
                                document.getElementById('<%=Button1.ClientID %>').style.display='none';
                                document.getElementById('<%=txtMaBenhNhan.ClientID %>').value="";
                                document.getElementById('<%=txtTenBenhNhan.ClientID %>').value="";
                                document.getElementById('<%=txtDiaChiBN.ClientID %>').value="";
                                document.getElementById('<%=txtGioiTinh.ClientID %>').value="";
                                document.getElementById('<%=txtNamSinh.ClientID %>').value="";
                             }                          
                        }
                });
	        }
	    }
    </script>
</asp:Content>

