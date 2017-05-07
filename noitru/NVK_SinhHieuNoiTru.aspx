<%@ Page Language="C#" MasterPageFile="~/MasterPage_New.master" AutoEventWireup="true" CodeFile="NVK_SinhHieuNoiTru.aspx.cs" Inherits="NVK_SinhHieuNoiTru" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="headerChiDinhK-div" >Sinh hiệu</div>
    <div id="CLSChonClick-div" style="display:none;background:#D4D0C8;position:fixed;width:100%;top:100;left:0;right:0;bottom:0;z-index:99999;height:100%;overflow:auto;padding-top:200px">
        
    </div>
    <div  style="float:left;padding-top:40px;width:100%">
    <span style="font-size:medium;">Mã Bệnh Nhân :</span>
    <input id="txtMaBenhNhan" type="text" mkv="true" onfocus="TimBenhNhanTheoMa(event,1,this);"  runat="server" style="font-size:medium;height:20px;width:130px"/>
    <span style="font-size:medium;">Tên Bệnh Nhân :</span>
    <input id="txtTenBenhNhan" type="text" mkv="true" onfocus="TimBenhNhanTheoMa(event,1,this)"   runat="server"  style="font-size:medium;height:20px;width:275px"/>
    <span style="font-size:medium;">Ngày :</span>
    <input mkv="true" id="ngayLoc" runat="server" type="text" onfocus="chuyenphim(this);$(this).datepick();"
                    onblur="TestDate(this);" style="width:85px;height:20px;font-size:medium;" />
    <input id="Button2" type="button" runat="server" value="Tìm"  onclick="TimKiemBenhNhanClick(this)" style="width:50px"  />
    <input id="Button3" type="button" runat="server" value="Mới"  onclick="ResetValueControl()" style="width:50px"  />
    <%--<input id="Button1" type="button" runat="server" value="Chỉ định CLS"  onclick="BeforeChonCLSClick();CLSChonClick();" style="width:100px"  />--%> <%--style="margin-top:100px"--%>
    <br /><br />
    <span style="font-size:medium;">Địa chỉ BN :</span>
    <input id="txtDiaChiBN" type="text" runat="server"  style="font-size:medium;height:20px;width:500px"/>
    <span style="font-size:medium;">Năm sinh :</span>
    <input id="txtNamSinh" type="text" runat="server"  style="font-size:medium;height:20px;width:90px"/>
    <span style="font-size:medium;">Giới tính :</span>
    <input id="txtGioiTinh" type="text" runat="server"  style="font-size:medium;height:20px;width:40px"/>
    </div>
    <div>
    <input type="hidden" id="hdIdBenhNhan" value="0" name="hdIdBenhNhan" runat="server" />
    <input type="hidden" id="hdIdKhamBenhGoc" value="0" name="hdIdKhamBenhGoc" runat="server" />
    <input type="hidden" id="HiddenIdKhoaChinh" value="0" name="hdIdBenhNhan" runat="server" />
    </div>
    
    <div style="display:none;top:15%;left:10%;width:80%;background-color:White;z-index:1000;padding:10px 10px 10px 10px;border:10px solid #4D67A2" id="divDanhSachBN" runat="server">
        <div id="tableAjax_DSBenhNhanNoiTru">            
        </div>
    </div>
    <div id="DSCanLamSan" style="width:100%;padding-top:20px">
    </div>
    <div id="tabs-1"></div>
    <script type="text/javascript">
    
    window.onload=function ()
    {
        //AddUserControl();
        if($.mkv.queryString("load") == '1')
        {
            $.mkv.queryString("LuuMoiKhamBenh",'0');
            CLSChonClick();
        }
    };
        $.mkv.moveUpandDown("#gridTabledskb");

function AddUserControl(){
        var fileascx = "~/usercontrols/NVK_sinhhieu.ascx";
	    $("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
	    $.ajax({
              type: "POST",
              contentType: "application/json; charset=utf-8",
              url: "Benhanngoaikhoa.aspx/Result",
              data: "{controlName:'"+fileascx+"'}",
               success: function (response) {
                    $("#tabs-1").html(response);
                    $("#loadingAjax").remove();
               }
         });
	}
        function CLSChonClick(){
            var fileascx = "~/usercontrols/DichvuCLSChon.ascx";
                if($.mkv.queryString("IsTheoDoiCC")=="1" || $.mkv.queryString("load") == '1')
                fileascx = "~/usercontrols/DichvuCLSChonTheoDoiCC.ascx";                
	        $("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');
	        $.ajax({
                  type: "POST",
                  contentType: "application/json; charset=utf-8",
                  url: "ChonCLSBenhVien.aspx/Result",
                  data: "{controlName:'"+fileascx+"'}",
                   success: function (response) {
                        $("#CLSChonClick-div").css({'display':''}).html(response);
                        $("#loadingAjax").remove();
                   }
             });
	    }
	    function TimKiemBenhNhanClick(obj)
	    {
	          var mabenhnhan= document.getElementById('<%=txtMaBenhNhan.ClientID %>').value;
	          var tenbenhnhan= document.getElementById('<%=txtTenBenhNhan.ClientID %>').value;
	            $(obj).TimKiem({
                    ajax:"../ajax/khambenh_ajax3.aspx?do=TimKiemBenhNhanTheoMaBenhNhan&mabn="+mabenhnhan+"&tenbn="+encodeURIComponent(tenbenhnhan)+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+""
                },null,null,function(){
                });  
	        //$.mkv.Find('txtTenBenhNhan',"../ajax/khambenh_ajax3.aspx?do=TimKiemBenhNhanTheoMaBenhNhan&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"","aaa");
	    }
	    function TimBenhNhanTheoMa(event,timTheoMa,obj,enter)
	    {
	    //alert(event.keyCode);
	        if(!$("#divTimKiem").length)
	        {
	            if(timTheoMa== 0)   
	               {
	                  var tenbenhnhan= document.getElementById('<%=txtTenBenhNhan.ClientID %>').value;
	                  PathUrl="../ajax/khambenh_ajax3.aspx?do=TimKiemBenhNhanTheoTenBenhNhan&TenBenhNhan="+encodeURIComponent(tenbenhnhan)+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"";
	               }
	             $(obj).TimKiem({
                    ajax:"../ajax/khambenh_ajax3.aspx?do=TimKiemBenhNhanTheoMaBenhNhan&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+""
                },null,null,function(){
                   
                   // $(obj).focus();
                });                 
            }
            else if(event.keyCode == 13)
            {
            }
	    }
	    function EnableChonCLS(HienChon)
	    {
	        if(HienChon==1)
	        {
                document.getElementById('<%=Button2.ClientID %>').style.display='none';//Ẩn nút Tìm BN
                //document.getElementById('<%=Button3.ClientID %>').style.display='none';//Ẩn nút Tìm BN
	        }
	        else
	        {
                document.getElementById('<%=Button2.ClientID %>').style.display='';//Ẩn nút Tìm BN
                //document.getElementById('<%=Button3.ClientID %>').style.display='';//Ẩn nút Tìm BN
	        }
	    }
	    function ResetValueControl()
	    {
	        document.getElementById('<%=hdIdBenhNhan.ClientID %>').value="";
                                document.getElementById('<%=hdIdKhamBenhGoc.ClientID %>').value="";
                                document.getElementById('<%=txtMaBenhNhan.ClientID %>').value="";
                                document.getElementById('<%=txtTenBenhNhan.ClientID %>').value="";
                                document.getElementById('<%=txtDiaChiBN.ClientID %>').value="";
                                document.getElementById('<%=txtGioiTinh.ClientID %>').value="";
                                document.getElementById('<%=txtNamSinh.ClientID %>').value="";
            EnableChonCLS(0);
            $("#tabs-1").html("");
            $("#DSCanLamSan").html("");document.getElementById('<%=txtMaBenhNhan.ClientID %>').focus();
	    }
	    function SetIdKhamBenhSuaChiDinh(idbenhnhan,idkhambenh)
	    {
	        $.mkv.queryString("idkhoachinh",idkhambenh);
            $.mkv.queryString("idbenhnhan",idbenhnhan);
            $.mkv.queryString("LuuMoiKhamBenh",'0');
            //document.getElementById('<%=HiddenIdKhoaChinh.ClientID %>').value=idkhambenh;
            CLSChonClick();
            
	    }
	    function BeforeChonCLSClick()
	    {
	        document.getElementById('<%=HiddenIdKhoaChinh.ClientID %>').value="0";
	        //alert(document.getElementById('<%=HiddenIdKhoaChinh.ClientID %>').value);
	        //$.mkv.removeQueryString("idkhoachinh");
	        $.mkv.queryString("LuuMoiKhamBenh",'1');
	    }
	    
	    function SetBenhNhanClick(MaBenhNhan,IdKhoa)
	    {
	        var ngayLoc= document.getElementById('<%=ngayLoc.ClientID %>').value;
	            var PathUrl="../ajax/khambenh_ajax3.aspx?do=SetBenhNhanClick&MaBenhNhan="+MaBenhNhan+"&IdKhoaNoiTru="+$.mkv.queryString("IdKhoa")+"&ngayLoc="+ngayLoc+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {//alert(value);
                        var arrValue=value.split('~');
                             if(arrValue[0] =="1" && arrValue[1] !="0")
                             {
                                var arrBN= arrValue[1].split('^');
                                document.getElementById('<%=hdIdBenhNhan.ClientID %>').value=arrBN[0];
                                document.getElementById('<%=hdIdKhamBenhGoc.ClientID %>').value=arrBN[1];
                                document.getElementById('<%=txtMaBenhNhan.ClientID %>').value=arrBN[2];
                                document.getElementById('<%=txtTenBenhNhan.ClientID %>').value=arrBN[3];
                                document.getElementById('<%=txtDiaChiBN.ClientID %>').value=arrBN[4];
                                document.getElementById('<%=txtGioiTinh.ClientID %>').value=arrBN[5];
                                document.getElementById('<%=txtNamSinh.ClientID %>').value=arrBN[6];
                                $.mkv.queryString("idkhoachinh",arrBN[1]);
                                $.mkv.queryString("idbenhnhan",arrBN[0]);
                                //$("#DSCanLamSan").html(arrValue[2]);
                                if(arrValue[3]=="1")
                                    $.mkv.queryString("IsTheoDoiCC",'1');
                                else
                                    $.mkv.queryString("IsTheoDoiCC",'0');
                                $.mkv.queryString("idkhambenhgoc",arrBN[7]);
                                $.mkv.queryString("ngaydo",ngayLoc);
                                EnableChonCLS(1);
                                document.getElementById('<%=divDanhSachBN.ClientID %>').style.display='none';//Ẩn Danh Sach BN
                                AddUserControl();
                             }
                             else if(arrValue[0] =="n" && arrValue[1] !="0")
                             {
                                $("#tableAjax_DSBenhNhanNoiTru").html(arrValue[1]);
                                document.getElementById('<%=divDanhSachBN.ClientID %>').style.display='';
                             }
                             else
                             {
                                alert("Không tìm thấy bệnh nhân !");
                                EnableChonCLS(0);
                                document.getElementById('<%=txtMaBenhNhan.ClientID %>').value="";
                                document.getElementById('<%=txtTenBenhNhan.ClientID %>').value="";
                                document.getElementById('<%=txtDiaChiBN.ClientID %>').value="";
                                document.getElementById('<%=txtGioiTinh.ClientID %>').value="";
                                document.getElementById('<%=txtNamSinh.ClientID %>').value="";
                                $("#DSCanLamSan").html("");document.getElementById('<%=txtMaBenhNhan.ClientID %>').focus();
                             }
                             $("#divTimKiem").remove();
                        }
                });
	    }
    </script>
</asp:Content>

