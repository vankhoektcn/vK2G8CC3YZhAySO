window.onload=function(){

     var w = window.screen.width;
        var h = window.screen.height;

        window.resizeTo(w,h);
        window.moveTo(0,0);
        window.scrollbars=true;
}

function ttxfocus(soid)
{
    var objttx = document.getElementById("txtttx_" + soid);
    objttx.focus();
}
function myalert(message,time){
      if (document.getElementById("divalert") == null) {
      document.getElementById("divParent").innerHTML ="<div id=\"divalert\" style=\"z-index:10000;background-color:white;position:fixed;top:40%;left:40%;display:table;padding:20px 50px 20px 50px;border:5px solid #4D67A2;text-align:center\">"+message+"</div>";
      }
      else{
          document.getElementById("divalert").innerHTML += "<div>"+message+"</div>";
      }
      if(document.getElementById("divParent").innerHTML != ''){
      setTimeout("document.getElementById(\"divParent\").innerHTML='';",time);
      }
}

function GetFocusEndHome(obj)
{
    keycode = window.event.keyCode;
    var obj = document.getElementById("obj" + soid);
    if (keycode == 36 || keycode == 35)
    {
        obj.focus();
    }
}

function ttxfocusend(soid)
{
    var objttx = document.getElementById("txtttxtc_" + soid);
    objttx.focus();
}

function thisfocus(obj)
{
    var obj = document.getElementById(obj);
    obj.focus();
}
function GetFocus(objl, objr, objt, objb)
{
    var objl = document.getElementById(objl);
    var objr = document.getElementById(objr);
    var objt = document.getElementById(objt);
    var objb = document.getElementById(objb);
    keycode = window.event.keyCode;
    if (keycode == 37) // Left
    {
        objl.focus();
    }
    if (keycode == 39) // right
    {
        objr.focus();
    }
    if (keycode == 38) // up
    {
        objt.focus();
    }
    if (keycode == 40) // down
    {
        objb.focus();
    }
    if (keycode == 36) // Home
    {
        var objhome = document.getElementById('txthome');
        objhome.focus();
    }
    if (keycode == 35) // end
    {
        var objend = document.getElementById('txtend');
        objend.focus();
    }
}

function MyRound(objValue)
{
	objValue = Math.round(objValue * 1000);
	objValue = objValue / 1000;
	return objValue;
}
//Chuyen so du
function chuyenSoDu()
{
    try
    {
        //CreateChuyenSoDu();
    }
    catch(exception)
    {
        alert("Lỗi xảy ra ở script . Vui lòng xem lại");
        return false;
    }
}
//==========================================
//function CreateChuyenSoDu()
//{
//    xmlHttp = GetMSXmlHttp();
//    xmlHttp.onreadystatechange = function()
//    {
//        if(xmlHttp.readyState == 4)
//        {
//            var value = xmlHttp.responseText;
//            if(!document.all) value = eval(value+"");
//            if(value == 0)
//            {
//                alert("Lỗi xảy ra khi kết chuyển số dư . Vui lòng xem lại ");
//                return false;
//            }
//            else if(value == 1)
//            {
//                alert("Dữ liệu không hợp lệ ! Thao tác của bạn sẽ bị hủy bỏ");
//                return false;
//            }
//            
//            else 
//            {
//               var arrvalue = value.split("/");
//               alert("Đã kết chuyển số dư thành công sang tháng " + arrvalue[1]);
//            }
//        }
//    }
//    xmlHttp.open("GET","ajax.aspx?do=chuyensodu&times="+Math.random(),true);
//    xmlHttp.send(null);
//}

/*Thong tin chung ve header*/
//==========================================
var statusHeader = new Array();
var objnameHeader = "";
function showThongTinHeader(obj,imgname)
{
    try
    {
        objnameHeader = obj;
        var img = document.getElementById(imgname);
        if(statusHeader[objnameHeader] == "down")
        {
            slideup(objnameHeader);
            statusHeader[objnameHeader] = "up";
            img.src = "images/up.gif";
            
        }
        else if(statusHeader[objnameHeader] == "up")
        {
            slidedown(objnameHeader);
            statusHeader[objnameHeader] = "down";
            img.src = "images/down.gif";
        }
        else 
        {
            slidedown(objnameHeader);
            statusHeader[objnameHeader] = "down";
            img.src = "images/down.gif";
        }
    }
    catch(exception)
    {
    }
}
//==========================================
function changeSrc1(obj)
{
    try
    {
        if(obj.src.indexOf("../images/up.gif") > 0 ) obj.src = "../images/overup.gif";
        else if(obj.src.indexOf("../images/down.gif") > 0 ) obj.src = "../images/overdown.gif";
    }
    catch(exception)
    {
    }
}
//==========================================
function changeSrc(obj)
{
    try
    {
        if(obj.src.indexOf("images/up.gif") > 0 ) obj.src = "images/overup.gif";
        else if(obj.src.indexOf("images/down.gif") > 0 ) obj.src = "images/overdown.gif";
    }
    catch(exception)
    {
    }
}
//==========================================
function resumeSrcvt(obj)
{
    try
    {
        if(obj.src.indexOf("images/overup.gif") > 0) obj.src = "../images/up.gif";
        else if(obj.src.indexOf("images/overdown.gif") > 0 ) obj.src = "../images/down.gif";
    }
    catch(exception)
    {
    }
}
//==========================================
function resumeSrc(obj)
{
    try
    {
        if(obj.src.indexOf("images/overup.gif") > 0) obj.src = "images/up.gif";
        else if(obj.src.indexOf("images/overdown.gif") > 0 ) obj.src = "images/down.gif";
    }
    catch(exception)
    {
    }
}

var xmlHttp ;
//==========================================
function loadMonthRelyOnYear()
{
    try
    {
        var yea = document.getElementsByName("year")[0];
        yea = yea.options[yea.selectedIndex].value;
        if(yea == 0) return;
        var ajax = document.getElementById("ajaxhome");
        ajax.style.display = "";
        loadMonthByAjax(yea);
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    }
}
//===========================================
function loadMonthByAjax(yea)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            var ajax = document.getElementById("ajaxhome");
            ajax.style.display = "none";
            var td = document.getElementById("monthHome");
            td.innerHTML = value;
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=getmonth&year="+yea+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function doExitHome()
{
    document.location.href = "DangNhap.aspx";
}
/* Tai khoan nguoi dung*/
//===========================================
function newuser()
{
    document.location.href = "user.aspx?do=new";
}
//===========================================
function newTaiKhoanUser()
{
    try
    {
        var manv = document.getElementsByName("manv")[0];
        if(!NumAndChar.test(manv.value))
        {
            alert("Mã nhân viên chỉ cho phép nhập chữ hoặc số . Vui lòng nhập lại");
            manv.focus();
            return false;
        }
        var hoten = document.getElementsByName("hoten")[0];
        if(trim(hoten.value) == "")
        {
            alert("Họ tên không được để trống . Vui lòng nhập lại ");
            hoten.focus();
            return false;
        }
        var dienthoai = document.getElementsByName("dienthoai")[0];
        if(!phoneReg.test(dienthoai.value) && trim(dienthoai.value) != "")
        {
            alert("Vui lòng nhập số điện thoại như hướng dẫn");
            dienthoai.focus();
            return false;
        }
        var matkhau = document.getElementsByName("matkhau")[0];
        if(!passReg.test(matkhau.value))
        {
            alert("Mật khẩu chỉ cho phép nhập chữ hoặc số . Vui lòng nhập lại");
            matkhau.focus();
            return false;
        }
        var ajax = document.getElementById("ajaxuser");
        ajax.style.display = "";
        loadCheckManv(manv.value);
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    }
    
}
//===========================================
function loadCheckManv(manv)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            if(!document.all) value = eval(value+"");
            var ajax = document.getElementById("ajaxuser");
            ajax.style.display = "none";
            if(value == 1)
            {
                alert("Mã nhân viên này đã có người sử dụng rồi . Vui lòng chọn mã nhân viên khác");
                return;
            }
            else if(value == 0)
            {
                var f = document.getElementsByName("user")[0];
                var secondtime = document.getElementById("secondtime");
                secondtime.value = "saveNewUser";
                f.submit();
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=checkmanvfromuser&manv="+manv+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function backlistuser()
{
    document.location.href = "user.aspx";
}
//===========================================
function deleteuser(checkname)
{
    var iCount = checkItemChecked(checkname);
    if(iCount == 0)
    {
        alert("Vui lòng chọn ít nhất một tài khoản người dùng trước khi xóa ");
        return false;
    }
    else if(confirm("Bạn có chắc muốn xóa những gì bạn chọn không ?"))
    {
        var f = document.user;
        f.secondtime.value = "deletemultiuser";
        f.submit();
    }
}
//===========================================
var statusPhone = "up";
function showPhone()
{
    if(statusPhone == "down")
    {
        slideup('slidephone');
        statusPhone = "up";
    }
    else if(statusPhone == "up")
    {
        slidedown('slidephone');
        statusPhone = "down";
    }
}
//===========================================
function updateUser()
{
    try
    {
        var manv = document.getElementsByName("manv")[0];
        if(trim(manv.value) == "")
        {
            alert("Mã nhân viên không được để trống . Vui lòng nhập lại ");
            manv.focus();
            return false;
        }
        var hoten = document.getElementsByName("hoten")[0];
        if(trim(hoten.value) == "")
        {
            alert("Họ tên không được để trống . Vui lòng nhập lại ");
            hoten.focus();
            return false;
        }
        var dienthoai = document.getElementsByName("dienthoai")[0];
//        if(!phoneReg.test(dienthoai.value) && trim(dienthoai.value) != "")
//        {
//            alert("Vui lòng nhập số điện thoại như hướng dẫn");
//            dienthoai.focus();
//            return false;
//        }
        var f = document.user;
        f.secondtime.value = "changeaccount";
        f.submit();
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    }   
}
//===========================================
function saveChangePass()
{
    try
    {
        var matkhaucu = document.getElementsByName("matkhaucu")[0];
        if(!passReg.test(matkhaucu.value))
        {
            alert("Mật khẩu cũ chỉ cho phép nhập chữ hoặc số . Vui lòng nhập lại");
            matkhaucu.focus();
            return false;
        }
        var matkhaumoi = document.getElementsByName("matkhaumoi")[0];
        if(!passReg.test(matkhaumoi.value))
        {
            alert("Mật khẩu mới chỉ cho phép nhập chữ hoặc số . Vui lòng nhập lại");
            matkhaumoi.focus();
            return false;
        }
        var xacnhan = document.getElementsByName("retype")[0];
        if(!passReg.test(xacnhan.value))
        {
            alert("xác nhận chỉ cho phép nhập chữ hoặc số . Vui lòng nhập lại");
            xacnhan.focus();
            return false;
        }
        if(matkhaumoi.value != xacnhan.value)
        {
            alert("Xác nhận mật khẩu không trùng khớp . Vui lòng nhập lại");
            xacnhan.focus();
            return false;
        }
        var ajax = document.getElementById("ajaxuser");
        ajax.style.display = "";
        var url = document.location.search;
        var userid = getItemUrl("userid",url);
        loadcheckPass(userid,matkhaucu.value,matkhaumoi.value);
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    }
}
//===========================================
function loadcheckPass(userid,oldpass,newpass)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            if(document.all) value = _parseInt(value);
            var ajax = document.getElementById("ajaxuser");
            ajax.style.display = "none";
            if(value == 0)
            {
                alert("Lỗi trong quá trình truyền dữ liệu");
                return false;
            }            
            else if (value == 1)
            {
                alert("Mật khẩu không trùng khớp ");
                return false;
            }
            else if(value == 2)
            {
                alert("Tài khoản này đã bị khóa");
                return false;
            }
            else if (value == 3)
            {
                alert("Bạn đã vượt quá số lần cho phép sửa ( tối đa 10 lần ) , do đó tài khoản này sẽ bị khóa \n Nếu bạn muốn mở lại tài khoản vui lòng liên hệ với admin");
                return false;
            }
            else if(value == 4)
                alert("Mật khẩu đã được thay đổi");
              
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=changepass&userid="+userid+"&oldpass="+oldpass+"&newpass="+newpass+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function deluser()
{
    try
    {
        if(confirm("Bạn có chắc muốn xóa tài khoản người dùng này không ?"))
        {
            var f = document.user;
            f.secondtime.value = "deleteuser";
            f.submit();
        }
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;        
    }
}
//===========================================

//===========================================
function showDanhSachVatTu(obj) //bien obj = 0 ; //ta khong gan mavt cho textbox , nguoc lai = 1 thi se gan mavt cho textbox
{
   var td = document.getElementById("showtipvattu");
   createTip(td,"tipvattu","danhsachnoidungvattu","Danh sách vật tư hiện có","ajaxvattuexists"," đang load danh sách vật tư...","Lỗi trong quá trình load danh sách vật tư ","ajax.aspx?do=getallvattu&obj="+obj);   
}
//===========================================
function showDanhsachKhachHang()
{
   var td = document.getElementById("showtipkhachhang");
   createTip(td,"tipkhachhang","danhsachnoidungkhachhang","Danh sách khách hàng hiện có","ajaxkhachhangexists"," đang load danh sách khách hàng ...","Lỗi trong quá trình load danh sách khách hàng ","ajax.aspx?do=getallkhachhang");   
}

//function showDanhsachnhacungung()
//{
//   var td = document.getElementById("showtipkhachhang");
//   createTipvt(td,"tipkhachhang","danhsachnoidungkhachhang","Danh sách nhà cung ứng hiện có","ajaxkhachhangexists"," đang load danh sách khách hàng ...","Lỗi trong quá trình load danh sách khách hàng ","ajax.aspx?do=getallnhacungung");   
//}

function showDanhsachnhacungung()
{
   var td = document.getElementById("showtipkhachhang");
   createTipvt(td,"tipkhachhang","danhsachnoidungnhacungung","Danh sách nhà cung ứng hiện có","ajaxkhachhangexists"," đang load danh sách nhà cung ứng ...","Lỗi trong quá trình load danh sách khách hàng ","../quanlyvattu/ajax.aspx?do=getallnhacungung");   
}

//===========================================
function showDanhsachPhuongThucMuaBan()
{
   var td = document.getElementById("showtipphuongthucmuaban");
   createTip(td,"tipphuongthucmuaban","danhsachnoidungphuongthucmuaban","Danh sách phương thức mua bán hiện có","ajaxphuongthucmuabanexists"," đang load danh sách phương thức mua bán ...","Lỗi trong quá trình load danh sách phương thức mua bán ","ajax.aspx?do=getallphuongthucmuaban");   
}
//===========================================
//function createTipThanhToan(td,divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei)
//{
//    try
//   {
//        hideTip(divname);
//        var div = document.createElement("div");
//        div.style.border="1px solid #07b3fb";
//        div.style.backgroundColor = "#E7E4DF";
//        div.style.width = wid + "px";
//        div.style.height = hei + "px";
//        div.style.position = "fixed";
//        div.id = divname;
//        //var e = event ? event : event.window;
//        
//        var posX = 200;//e.clientX;
//        var posY = 100;//e.clientY;
//        div.style.top = _parseInt(posY) + 20;
//        div.style.left = _parseInt(posX) - 100;
//        td.appendChild(div);
//        createTable(divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei);
//    }
//    catch(exception)
//   {
//   }
//}
function createTip(td,divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei)
{
    try
   {
        hideTip(divname);
        var div = document.createElement("div");
        div.style.border="1px solid #07b3fb";
        div.style.backgroundColor = "#E7E4DF";
        div.style.width = wid + "px";
        div.style.height = hei + "px";
        div.style.position = "fixed";
        div.id = divname;
        //var e = event ? event : event.window;
        
        var posX = 200;//e.clientX;
        var posY = 100;//e.clientY;
        div.style.top = _parseInt(posY) + 20;
        div.style.left = _parseInt(posX) - 100;
        td.appendChild(div);
        createTable(divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei);
    }
    catch(exception)
   {
   }
}
function createTipTU(td,divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei)
{
    try
   {
        hideTip(divname);
        var div = document.createElement("div");
        div.style.border="1px solid #07b3fb";
        div.style.backgroundColor = "#E7E4DF";
        div.style.width = wid + "px";
        div.style.height = hei + "px";
        div.style.position = "fixed";
        div.id = divname;
        //var e = event ? event : event.window;
        
        var posX = 200;//e.clientX;
        var posY = 100;//e.clientY;
        div.style.top = _parseInt(posY) + 20;
        div.style.left = _parseInt(posX) - 100;
        td.appendChild(div);
        createTableTU(divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei);
    }
    catch(exception)
   {
   }
}
function createTipHU(td,divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei)
{
    try
   {
        hideTip(divname);
        var div = document.createElement("div");
        div.style.border="1px solid #07b3fb";
        div.style.backgroundColor = "#E7E4DF";
        div.style.width = wid + "px";
        div.style.height = hei + "px";
        div.style.position = "fixed";
        div.id = divname;
        //var e = event ? event : event.window;
        
        var posX = 200;//e.clientX;
        var posY = 100;//e.clientY;
        div.style.top = _parseInt(posY) + 20;
        div.style.left = _parseInt(posX) - 100;
        td.appendChild(div);
        createTableHU(divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei);
    }
    catch(exception)
   {
   }
}
function createTipThanhToan(td,divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei)
{
    try
   {
        hideTip(divname);
        var div = document.createElement("div");
        div.style.border="1px solid #07b3fb";
        div.style.backgroundColor = "#E7E4DF";
        div.style.width = wid + "px";
        div.style.height = hei + "px";
        div.style.position = "fixed";
        div.id = divname;
        //var e = event ? event : event.window;
        
        var posX = 200;//e.clientX;
        var posY = 100;//e.clientY;
        div.style.top = _parseInt(posY) + 20;
        div.style.left = _parseInt(posX) - 100;
        td.appendChild(div);
        createTableThanhToan(divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei);
    }
    catch(exception)
   {
   }
}

function createTipThanhToanRaVien(td,divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei)
{
    try
   {
        hideTip(divname);
        var div = document.createElement("div");
        div.style.border="1px solid #07b3fb";
        div.style.backgroundColor = "#E7E4DF";
        div.style.width = wid + "px";
        div.style.height = hei + "px";
        div.style.position = "fixed";
        div.id = divname;
        //var e = event ? event : event.window;
        
        var posX = 200;//e.clientX;
        var posY = 100;//e.clientY;
        div.style.top = _parseInt(posY) + 20;
        div.style.left = _parseInt(posX) - 100;
        td.appendChild(div);
        createTableThanhToanRaVien(divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei);
    }
    catch(exception)
   {
   }
}
function createTipFocus(td,divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei,idFocus)
{
    try
   {
        hideTip(divname);
        var div = document.createElement("div");
        div.style.border="1px solid #07b3fb";
        div.style.backgroundColor = "#E7E4DF";
        div.style.width = wid + "px";
        div.style.height = hei + "px";
        div.style.position = "fixed";
        div.id = divname;
        //var e = event ? event : event.window;
        
        var posX = 200;//e.clientX;
        var posY = 50;//e.clientY;   Khoe :Old 100
        div.style.top = _parseInt(posY) + 20;
        div.style.left = _parseInt(posX) - 100;
        td.appendChild(div);
        createTableFocus(divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei,idFocus);
    }
    catch(exception)
   {
   }
}
function createTipvt(td,divname,divchildname,title,ajaxname,sloganajax,error,url)
{
   try
   {
        hideTip(divname);
        var div = document.createElement("div");
        div.style.border="1px solid #07b3fb";
        div.style.backgroundColor = "#9ed7ef";
        div.style.width = "350px";
        div.style.height = "250px";
        div.style.position = "absolute";
        div.id = divname;
        var e = event ? event : event.window;
        var posX = e.clientX;
        var posY = e.clientY;
        div.style.top = _parseInt(posY) + 20;
        div.style.left = _parseInt(posX) - 200;
        td.appendChild(div);
        createTablevt(divname,divchildname,title,ajaxname,sloganajax,error,url);
    }
    catch(exception)
   {
   }
}

/*Thong tin chung ve toa do va chuot*/
var flag = 0; //co nam giu chuot default la 0 , chuot chua dc nhan xuong
var mouseX = 0;//toa do X cua con chuot
var mouseY = 0;//toa do Y cua con chuot
var disX = 0;//khoang cach tu toa do X cua chuot cho den mep cua title
var disY = 0;//khoang cach tu toa do Y cua chuot cho den mep cua title
var objover = new Array() ;
var tipobjname = "";
//===========================================
function overScreen()
{
    try
    {
        if(flag == 0) return;
        var e = event ? event : window.event;
        mouseX = e.clientX;
        mouseY = e.clientY;
        var div = document.getElementById(objover[tipobjname]);
        div.style.left = parseInt(mouseX) - parseInt(disX);
        div.style.top = parseInt(mouseY) - parseInt(disY);
    }
    catch(exception)
    {
        mouseRelease(); 
    }
}
//===========================================
function mouseDown(divname)
{
    try
    {
        var e = event ? event : window.event;
        if(e.button == 1)
        {
            flag = 1;
            mouseX = e.clientX;
            mouseY = e.clientY;
            var left , top ;
            var div = document.getElementById(divname);
            tipobjname = divname;
            objover[tipobjname]=divname;
            left = parseInt(div.style.left);
            top =  parseInt(div.style.top);
            disX = parseInt(mouseX) - left;
            disY = parseInt(mouseY) - top;
        }
    }
    catch(exception)
    {
        mouseRelease();
    }
}

//===========================================
function setKhachHang(makh,num)
{
    try
    {
        var mkh ;
        if(num == 0)
            mkh = document.getElementsByName("manv")[0];
        else if(num == 1)
            mkh = document.getElementsByName("mano")[0];
        else if(num == 2)
            mkh = document.getElementsByName("maco")[0];
        mkh.value = makh;
        hideTip('tipkhachhang'+num == 0 ? "":num);
    }
    catch(exception)
    {
    }
}
//===========================================
function mouseRelease()
{
    flag = mouseX = mouseY = disX = disY = 0;    
}
function createTableTU(divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei)
{
    try
    {
        var div = document.getElementById(divname);
        tipobjname = divname;
        var table = document.createElement("table");
        table.style.width = wid + "px";
        table.cellspacing = "0px";
        table.cellpadding = "0px";
        table.border = "0px";
        
        var tr = table.insertRow(0);
        var td = tr.insertCell(0);
        td.style.width="280px";
        td.style.background="url(../images/header.gif) repeat";
        td.style.fontFamily = "tahoma";
        td.style.fontSize = "11px";
        td.style.fontWeight = "bold";
        td.style.color = "white";
        td.style.paddingLeft = "5px";
        td.style.paddingRight = "0px";
        td.style.height = "20px";
        td.innerHTML = "<span style=\"float:left;width:280px;padding-top:0px;cursor:pointer;\" onmousedown=\"mouseDown('"+divname+"')\" onmouseup=\"mouseRelease()\">"+title+"</span><span style=\"float:right\"><img src=\"../images/close.gif\" align=\"right\"/ title=\"click vào để đóng danh sách\" onclick=\"hideTip('"+divname+"')\" style=\"cursor:pointer;\"></span>";
        div.appendChild(table);
        
        tr = table.insertRow(1);
        td = tr.insertCell(0);        
        td.style.width="350px";
        div = document.createElement("div");
        div.id = divchildname;
        div.style.width = "100%";
        div.style.height="100px";
        div.style.overflowX = "scroll";
        div.style.overflowY = "scroll";
        
        div.style.textAlign = "left";
        td.appendChild(div);
        div = document.getElementById(divchildname);
        var span = document.createElement("span");
        span.id=ajaxname;
        span.className= "ajax";
        span.style.textAlign = "center";
        div.appendChild(span);
        span = document.getElementById(ajaxname);
        img = document.createElement("img");
        img.src = "../images/processing.gif";
        span.appendChild(img);
        var text = document.createTextNode(sloganajax);
        span.appendChild(text);
        loadDanhSach(divname,divchildname,error,url);
        
   }
   catch(exception)
   {
   }
}
function createTableHU(divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei)
{
    try
    {
        var div = document.getElementById(divname);
        tipobjname = divname;
        var table = document.createElement("table");
        table.style.width = wid + "px";
        table.cellspacing = "0px";
        table.cellpadding = "0px";
        table.border = "0px";
        
        var tr = table.insertRow(0);
        var td = tr.insertCell(0);
        td.style.width="280px";
        td.style.background="url(../images/header.gif) repeat";
        td.style.fontFamily = "tahoma";
        td.style.fontSize = "11px";
        td.style.fontWeight = "bold";
        td.style.color = "white";
        td.style.paddingLeft = "5px";
        td.style.paddingRight = "0px";
        td.style.height = "20px";
        td.innerHTML = "<span style=\"float:left;width:280px;padding-top:0px;cursor:pointer;\" onmousedown=\"mouseDown('"+divname+"')\" onmouseup=\"mouseRelease()\">"+title+"</span><span style=\"float:right\"><img src=\"../images/close.gif\" align=\"right\"/ title=\"click vào để đóng danh sách\" onclick=\"hideTip('"+divname+"')\" style=\"cursor:pointer;\"></span>";
        div.appendChild(table);
        
        tr = table.insertRow(1);
        td = tr.insertCell(0);        
        td.style.width="350px";
        div = document.createElement("div");
        div.id = divchildname;
        div.style.width = "100%";
        div.style.height="100px";
        div.style.overflowX = "scroll";
        div.style.overflowY = "scroll";
        
        div.style.textAlign = "left";
        td.appendChild(div);
        div = document.getElementById(divchildname);
        var span = document.createElement("span");
        span.id=ajaxname;
        span.className= "ajax";
        span.style.textAlign = "center";
        div.appendChild(span);
        span = document.getElementById(ajaxname);
        img = document.createElement("img");
        img.src = "../images/processing.gif";
        span.appendChild(img);
        var text = document.createTextNode(sloganajax);
        span.appendChild(text);
        loadDanhSach(divname,divchildname,error,url);
        
   }
   catch(exception)
   {
   }
}

function createTableThanhToan(divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei)
{
    try
    {
        var div = document.getElementById(divname);
        tipobjname = divname;
        var table = document.createElement("table");
        table.style.width = wid + "px";
        table.cellspacing = "0px";
        table.cellpadding = "0px";
        table.border = "0px";
        
        var tr = table.insertRow(0);
        var td = tr.insertCell(0);
        td.style.width="280px";
        td.style.background="url(../images/header.gif) repeat";
        td.style.fontFamily = "tahoma";
        td.style.fontSize = "11px";
        td.style.fontWeight = "bold";
        td.style.color = "white";
        td.style.paddingLeft = "5px";
        td.style.paddingRight = "0px";
        td.style.height = "20px";
        td.innerHTML = "<span style=\"font-weight: bold;float:left;width:280px;padding-top:0px;cursor:pointer;\" onmousedown=\"mouseDown('"+divname+"')\" onmouseup=\"mouseRelease()\">"+title+"</span><span style=\"float:right\"><img src=\"../images/close.gif\" align=\"right\"/ title=\"click vào để đóng danh sách\" onclick=\"hideTip('"+divname+"')\" style=\"cursor:pointer;\"></span>";
        div.appendChild(table);
        
        tr = table.insertRow(1);
        td = tr.insertCell(0);        
        td.style.width="350px";
        div = document.createElement("div");
        div.id = divchildname;
        div.style.width = "100%";
        div.style.height="100px";
        div.style.overflowX = "scroll";
        div.style.overflowY = "scroll";
        
        div.style.textAlign = "left";
        td.appendChild(div);
        div = document.getElementById(divchildname);
        var span = document.createElement("span");
        span.id=ajaxname;
        span.className= "ajax";
        span.style.textAlign = "center";
        div.appendChild(span);
        span = document.getElementById(ajaxname);
        img = document.createElement("img");
        img.src = "../images/processing.gif";
        span.appendChild(img);
        var text = document.createTextNode(sloganajax);
        span.appendChild(text);
        loadDanhSach(divname,divchildname,error,url);
        
   }
   catch(exception)
   {
   }
}

function createTableThanhToanRaVien(divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei)
{
    try
    {
        var div = document.getElementById(divname);
        tipobjname = divname;
        var table = document.createElement("table");
        table.style.width = wid + "px";
        table.cellspacing = "0px";
        table.cellpadding = "0px";
        table.border = "0px";
        
        var tr = table.insertRow(0);
        var td = tr.insertCell(0);
        td.style.width="280px";
        td.style.background="url(../images/header.gif) repeat";
        td.style.fontFamily = "tahoma";
        td.style.fontSize = "11px";
        td.style.fontWeight = "bold";
        td.style.color = "white";
        td.style.paddingLeft = "5px";
        td.style.paddingRight = "0px";
        td.style.height = "20px";
        td.innerHTML = "<span style=\"font-weight: bold;float:left;width:280px;padding-top:0px;cursor:pointer;\" onmousedown=\"mouseDown('"+divname+"')\" onmouseup=\"mouseRelease()\">"+title+"</span><span style=\"float:right\"><img src=\"../images/close.gif\" align=\"right\"/ title=\"click vào để đóng danh sách\" onclick=\"hideTip('"+divname+"')\" style=\"cursor:pointer;\"></span>";
        div.appendChild(table);
        
        tr = table.insertRow(1);
        td = tr.insertCell(0);        
        td.style.width="350px";
        div = document.createElement("div");
        div.id = divchildname;
        div.style.width = "100%";
        div.style.height="150px";
        div.style.overflowX = "scroll";
        div.style.overflowY = "scroll";
        
        div.style.textAlign = "left";
        td.appendChild(div);
        div = document.getElementById(divchildname);
        var span = document.createElement("span");
        span.id=ajaxname;
        span.className= "ajax";
        span.style.textAlign = "center";
        div.appendChild(span);
        span = document.getElementById(ajaxname);
        img = document.createElement("img");
        img.src = "../images/processing.gif";
        span.appendChild(img);
        var text = document.createTextNode(sloganajax);
        span.appendChild(text);
        loadDanhSach(divname,divchildname,error,url);
        
   }
   catch(exception)
   {
   }
}

//===========================================
function createTable(divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei)
{
    try
    {
        var div = document.getElementById(divname);
        tipobjname = divname;
        var table = document.createElement("table");
        table.style.width = wid + "px";
        table.cellspacing = "0px";
        table.cellpadding = "0px";
        table.border = "0px";
        
        var tr = table.insertRow(0);
        var td = tr.insertCell(0);
        td.style.width="280px";
        td.style.background="url(../images/header.gif) repeat";
        td.style.fontFamily = "tahoma";
        td.style.fontSize = "11px";
        td.style.fontWeight = "bold";
        td.style.color = "white";
        td.style.paddingLeft = "5px";
        td.style.paddingRight = "0px";
        td.style.height = "20px";
        td.innerHTML = "<span style=\"float:left;width:280px;padding-top:0px;cursor:pointer;\" onmousedown=\"mouseDown('"+divname+"')\" onmouseup=\"mouseRelease()\">"+title+"</span><span style=\"float:right\"><img src=\"../images/close.gif\" align=\"right\"/ title=\"click vào để đóng danh sách\" onclick=\"hideTip('"+divname+"')\" style=\"cursor:pointer;\"></span>";
        div.appendChild(table);
        
        tr = table.insertRow(1);
        td = tr.insertCell(0);        
        td.style.width="350px";
        div = document.createElement("div");
        div.id = divchildname;
        div.style.width = "100%";
        div.style.height="300px";
        div.style.overflowX = "scroll";
        div.style.overflowY = "scroll";
        
        div.style.textAlign = "left";
        td.appendChild(div);
        div = document.getElementById(divchildname);
        var span = document.createElement("span");
        span.id=ajaxname;
        span.className= "ajax";
        span.style.textAlign = "center";
        div.appendChild(span);
        span = document.getElementById(ajaxname);
        img = document.createElement("img");
        img.src = "../images/processing.gif";
        span.appendChild(img);
        var text = document.createTextNode(sloganajax);
        span.appendChild(text);
        loadDanhSach(divname,divchildname,error,url);
        
   }
   catch(exception)
   {
   }
}

function createTableFocus(divname,divchildname,title,ajaxname,sloganajax,error,url, wid, hei,idFocus)
{
    try
    {
        var div = document.getElementById(divname);
        tipobjname = divname;
        var table = document.createElement("table");
        table.style.width = wid + "px";
        table.style.height = hei + "px";
        table.cellspacing = "0px";
        table.cellpadding = "0px";
        table.border = "0px";
        
        var tr = table.insertRow(0);
        var td = tr.insertCell(0);
        td.style.width="280px";
        td.style.background="url(../images/header.gif) repeat";
        td.style.fontFamily = "tahoma";
        td.style.fontSize = "11px";
        td.style.fontWeight = "bold";
        td.style.color = "white";
        td.style.paddingLeft = "5px";
        td.style.paddingRight = "0px";
        td.style.height = "10px";
        td.innerHTML = "<span style=\"float:left;width:280px;padding-top:0px;cursor:pointer;\" onmousedown=\"mouseDown('"+divname+"')\" onmouseup=\"mouseRelease()\">"+title+"</span><span style=\"float:right\"><img src=\"../images/close.gif\" align=\"right\"/ title=\"click vào để đóng danh sách\" onclick=\"hideTipFocus('"+divname+"')\" style=\"cursor:pointer;\"></span>";
        div.appendChild(table);
        
        tr = table.insertRow(1);
        td = tr.insertCell(0);        
        td.style.width="350px";
        div = document.createElement("div");
        div.id = divchildname;
        div.style.width = "100%";
        div.style.height="450px";//Van Khoe Old 350
        div.style.overflowX = "scroll";
        div.style.overflowY = "scroll";
        
        div.style.textAlign = "left";
        td.appendChild(div);
        div = document.getElementById(divchildname);
        var span = document.createElement("span");
        span.id=ajaxname;
        span.className= "ajax";
        span.style.textAlign = "center";
        div.appendChild(span);
        span = document.getElementById(ajaxname);
        img = document.createElement("img");
        img.src = "../images/processing.gif";
        span.appendChild(img);
        var text = document.createTextNode(sloganajax);
        span.appendChild(text);
        loadDanhSachFocus(divname,divchildname,error,url,idFocus);
        
   }
   catch(exception)
   {
   }
}

//===========================================
function createTablevt(divname,divchildname,title,ajaxname,sloganajax,error,url)
{
    try
    {
        var div = document.getElementById(divname);
        tipobjname = divname;
        var table = document.createElement("table");
        table.style.width = "350px";
        table.cellspacing = "1px";
        table.cellpadding = "1px";
        table.border = "0px";
        
        var tr = table.insertRow(0);
        var td = tr.insertCell(0);
        td.style.width="350px";
        td.style.background="url(../images/header.gif) repeat";
        td.style.fontFamily = "tahoma";
        td.style.fontSize = "11px";
        td.style.fontWeight = "bold";
        td.style.color = "white";
        td.style.paddingLeft = "5px";
        td.style.paddingRight = "5px";
        td.style.height = "20px";
        td.innerHTML = "<span style=\"float:left;width:300px;padding-top:2px;cursor:pointer;\" onmousedown=\"mouseDown('"+divname+"')\" onmouseup=\"mouseRelease()\">"+title+"</span><span style=\"float:right\"><img src=\"../images/close.gif\" align=\"right\"/ title=\"click vào để đóng danh sách\" onclick=\"hideTip('"+divname+"')\" style=\"cursor:pointer;\"></span>";
        div.appendChild(table);
        
        tr = table.insertRow(1);
        td = tr.insertCell(0);        
        td.style.width="350px";
        div = document.createElement("div");
        div.id = divchildname;
        div.style.width = "100%";
        div.style.height="250px";
        div.style.overflowX = "hidden";
        div.style.overflowY = "scroll";
        div.style.textAlign = "left";
        td.appendChild(div);
        div = document.getElementById(divchildname);
        var span = document.createElement("span");
        span.id=ajaxname;
        span.className= "ajax";
        span.style.textAlign = "center";
        div.appendChild(span);
        span = document.getElementById(ajaxname);
        img = document.createElement("img");
        img.src = "../images/processing.gif";
        span.appendChild(img);
        var text = document.createTextNode(sloganajax);
        span.appendChild(text);
        loadDanhSach(divname,divchildname,error,url);
   }
   catch(exception)
   {
   }
}
//===========================================
function chonNhom(manhom)
{
    try
    {
        var nhom = document.getElementsByName("nhom")[0];
        nhom.value = manhom;
        hideTip("tooltipnhom");
    }
    catch(exception)
    {
    }
}
//===========================================
function loadDanhSach(divname,divchildname,error,url)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            
            if(value == "error")
            {
                alert(error);
                hideTip(divname);
                return false;
            }
            else 
            {
                var div = document.getElementById(divchildname);
                div.innerHTML = value;
                
            }
        }
    }
    xmlHttp.open("GET",url+"&times="+Math.random(),true);
    xmlHttp.send(null);
}

function loadDanhSachFocus(divname,divchildname,error,url,idFocus)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;            
            if(value == "error")
            {
                alert(error);
                hideTipFocus(divname);
                return false;
            }
            else 
            {                
                var div = document.getElementById(divchildname);
                div.innerHTML = value;                         
                if(idFocus!=null && idFocus!='null' && idFocus!='' && idFocus!='0')
                {
                document.getElementById(idFocus).focus();
                }
//                 document.getElementById('divLuuCLS').style.display='';
//	            document.getElementById('showKQ').focus();
            }
        }
    }
    xmlHttp.open("GET",url+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function hideTipFocus(divname)
{
    try
    {
        var div = document.getElementById(divname);
        div.parentNode.removeChild(div);
        showKQCLS();
    }
    catch(exception)
    {
    }
}
function hideTip(divname)
{
    try
    {
        var div = document.getElementById(divname);
        div.parentNode.removeChild(div);
    }
    catch(exception)
    {
    }
}
//===========================================
function deltaikhoan()
{
    try
    {
        if(confirm("Bạn có chắc muốn xóa loại tài khoản này không ?"))
        {
            var f = document.taikhoan;
            f.secondtime.value = "deletetaikhoan";
            f.submit();
        }
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;        
    }
}
//===========================================
function newsubtaikhoan(nhom)
{
    document.location.href = "taikhoan.aspx?do=newsub&nhom="+nhom;
}
//===========================================
function savenewsubtaikhoan()
{
    try
    {
        var matk = document.getElementsByName("matk")[0];
        if(!NumAndChar.test(matk.value))
        {
            alert("Mã tài khoản chỉ cho phép nhập kí tự hoặc số . Vui lòng nhập lại");
            matk.focus();
            return false;
        }
        var span = document.getElementById("ajaxtaikhoan");
        span.style.display = "";
        loadChecksubTaikhoan(matk.value);
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;      
    }
}
//===========================================
function loadChecksubTaikhoan(matk)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            var ajax = document.getElementById("ajaxtaikhoan");
            ajax.style.display = "none";
            
            if(value == 0) 
            {
                alert("Lỗi trong quá trình truyền dữ liệu");
                return false;
            }
            else if(value == 1) 
            {
                alert("Tài khoản này đã tồn tại rồi . Vui lòng chọn một tài khoản khác ");
                var mtk = document.getElementsByName("matk")[0];
                mtk.focus();
                return false;
            }
            else if(value == 2)
            {
                var f = document.taikhoan;
                f.secondtime.value = "newtaikhoancon";
                f.submit();
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=checktaikhoan&matk="+matk+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
/* Thong tin phuong thuc mua ban*/
//===========================================
function savenewphuongthucmuaban()
{
    try
    {
        var mapt = document.getElementsByName("mapt")[0];
        if(!NumAndChar.test(mapt.value))
        {
            alert("Mã phương thức chỉ cho phép nhập kí tự hoặc số . Vui lòng nhập lại");
            mapt.focus();
            return false;
        }
        var span = document.getElementById("ajaxphuongthucmuaban");
        span.style.display = "";
        loadCheckPhuongThucMuaBan(mapt.value);
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;      
    }
}
//===========================================
function loadCheckPhuongThucMuaBan(mapt)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            var ajax = document.getElementById("ajaxphuongthucmuaban");
            ajax.style.display = "none";
            if(!document.all) value = eval(value+"");
            if(value == 0) 
            {
                alert("Lỗi trong quá trình truyền dữ liệu");
                return false;
            }
            else if(value == 1) 
            {
                alert("Phương thức mua bán này đã tồn tại rồi . Vui lòng chọn một phương thức mua bán khác ");
                var mapt = document.getElementsByName("mapt")[0];
                mapt.focus();
                return false;
            }
            else if(value == 2)
            {
                var f = document.phuongthucmuaban;
                f.secondtime.value = "newphuongthucmuaban";
                f.submit();
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=checkphuongthucmuaban&mapt="+mapt+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function newPhuongThucMuaBan()
{
    try
    {
        var mapt = document.getElementsByName("mapt")[0];
        mapt.value ="";
        mapt.readOnly = "false";
        var tenpt = document.getElementsByName("tenpt")[0];
        tenpt.value ="";
        var html = "";
        html += "<input type=\"button\" name=\"luu\" onclick=\"savenewphuongthucmuaban()\" value=\"Lưu\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"reset\" name=\"cancel\" value=\"Làm lại\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"deletephuongthucmuaban('checkall')\" style=\"width:80px;\" />&nbsp;&nbsp;";
        html += "<span class=\"ajax\" id=\"ajaxdanhmucphuongthucmuaban\" style=\"display:none;\"><img src=\"images/processing.gif\" border=\"0\" />&nbsp;đang load dữ liệu ...</span>";
        var td = document.getElementById("functionphuongthucmuaban");
        td.innerHTML = html;
    }
    catch(exception)
    {
    }
}
//===========================================
function loadDanhMucPhuongThucMuaBan(mapt)
{
    try
    {
        var span = document.getElementById("ajaxdanhmucphuongthucmuaban");
        span.style.display = "";
        loadChiTietPhuongThucMuaBan(mapt);
    }
    catch(exception)
    {
    }
}
//===========================================
function loadChiTietPhuongThucMuaBan(mapt)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            var ajax = document.getElementById("ajaxdanhmucphuongthucmuaban");
            ajax.style.display = "none";
            if(!document.all) value = eval(value+"");
            if(value == 0) 
            {
                alert("Lỗi trong quá trình truyền dữ liệu");
                return false;
            }
            else 
            {
                var td = document.getElementById("chitietphuongthucmuaban");
                td.innerHTML = value;
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=loadchitietphuongthucmuaban&mapt="+mapt+"&times="+Math.random(),true);
    xmlHttp.send(null);   
}
//===========================================
function deletephuongthucmuaban(checkname)
{
    var iCount = checkItemChecked(checkname);
    if(iCount == 0)
    {
        alert("Vui lòng chọn ít nhất một loại ngoại tệ trước khi xóa ");
        return false;
    }
    else if(confirm("Bạn có chắc xóa hết những ngoại tệ mà bạn chọn không ?"))
    {
        var f = document.phuongthucmuaban;
        f.secondtime.value = "deletemultiphuongthucmuaban";
        f.submit();
    }
}
//===========================================
function saveupdatephuongthucmuaban()
{
    try
    {
        var f = document.phuongthucmuaban;
        f.secondtime.value = "updatephuongthucmuaban";
        f.submit();
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    }   
}
//===========================================
function showNewLayOutPhuongThucMuaBan()
{
    try
    {
        var layout = document.getElementsByName("layout")[0];
        layout = _parseInt(layout);
        layout = layout == 0 ? 10 : layout;
        var f = document.phuongthucmuaban;
        f.secondtime.value = "loadlayout";
        f.submit();
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;   
    }
}
//==========================================
function nextpagephuongthucmuaban(curpage)
{
    try
    {
        var page = document.getElementsByName("page")[0];
        page = page.options[page.selectedIndex].value;
        if(page != curpage)
        {
            document.location.href = "phuongthucmuaban.aspx?page="+page;
        }
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false; 
    }
}
//==========================================
function nextpagekhausanxuat(curpage)
{
    try
    {
        var page = document.getElementsByName("page")[0];
        page = page.options[page.selectedIndex].value;
        if(page != curpage)
        {
            document.location.href = "nextpagekhausanxuat.aspx?page="+page;
        }
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false; 
    }
}
//===========================================
/* Thong tin cac khau san xuat*/
//===========================================
function savenewkhaunhan()
{
    try
    {
        var mapt = document.getElementsByName("mapt")[0];
        if(!NumAndChar.test(mapt.value))
        {
            alert("Mã khâu sản xuất chỉ cho phép nhập kí tự hoặc số . Vui lòng nhập lại");
            mapt.focus();
            return false;
        }
        var span = document.getElementById("ajaxphuongthucmuaban");
        span.style.display = "";
        loadCheckKhauNhan(mapt.value);
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;      
    }
}
//===========================================
function loadCheckKhauNhan(mapt)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            var ajax = document.getElementById("ajaxphuongthucmuaban");
            ajax.style.display = "none";
            if(!document.all) value = eval(value+"");
            if(value == 0) 
            {
                alert("Lỗi trong quá trình truyền dữ liệu");
                return false;
            }
            else if(value == 1) 
            {
                alert("Khâu sản xuất này đã tồn tại rồi . Vui lòng chọn một khâu sản xuất khác ");
                var mapt = document.getElementsByName("mapt")[0];
                mapt.focus();
                return false;
            }
            else if(value == 2)
            {
                var f = document.phuongthucmuaban;
                f.secondtime.value = "newphuongthucmuaban";
                f.submit();
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=checkkhaunhan&mapt="+mapt+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function loadDanhMucKhauNhan(mapt)
{
    try
    {
        var span = document.getElementById("ajaxdanhmucphuongthucmuaban");
        span.style.display = "";
        loadChiTietKhauNhan(mapt);
    }
    catch(exception)
    {
    }
}
//===========================================
function loadChiTietKhauNhan(mapt)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            var ajax = document.getElementById("ajaxdanhmucphuongthucmuaban");
            ajax.style.display = "none";
            if(!document.all) value = eval(value+"");
            if(value == 0) 
            {
                alert("Lỗi trong quá trình truyền dữ liệu");
                return false;
            }
            else 
            {
                var td = document.getElementById("chitietphuongthucmuaban");
                td.innerHTML = value;
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=loadchitietkhaunhan&mapt="+mapt+"&times="+Math.random(),true);
    xmlHttp.send(null);   
}
//===========================================
function saveupdatekhaunhan()
{
    try
    {
        var f = document.phuongthucmuaban;
        f.secondtime.value = "updatephuongthucmuaban";
        f.submit();
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    }   
}
//===========================================
function deletekhaunhan(checkname)
{
    var iCount = checkItemChecked(checkname);
    if(iCount == 0)
    {
        alert("Vui lòng chọn ít nhất một khâu sản xuất ");
        return false;
    }
    else if(confirm("Bạn có chắc xóa hết những khâu sản xuất mà bạn chọn không ?"))
    {
        var f = document.phuongthucmuaban;
        f.secondtime.value = "deletemultiphuongthucmuaban";
        f.submit();
    }
}
//===========================================
//===========================================
//* Thông tin nhà cung ứng

//===========================================
function newnhacungung()
{
    document.location.href = "nhacungung.aspx?do=new";
}
//===========================================
function savenewnhacungung()
{
    try
    {
        var makh = document.getElementsByName("makh")[0];
        if(!NumAndChar.test(makh.value))
        {
            alert("Mã nhà cung ứng chỉ cho phép nhập chữ hoặc số . Vui lòng nhập lại");
            makh.focus();
            return false;
        }
        
        var hoten = document.getElementsByName("hoten")[0];
        if(trim(hoten.value) == "")
        {
            alert("Họ tên không được để trống . Vui lòng nhập lại ");
            hoten.focus();
            return false;
        }
        var dienthoai = document.getElementsByName("dienthoai")[0];
       
        var ajax = document.getElementById("ajaxkhachhang");
        ajax.style.display = "";
        loadCheckMancu(makh.value);
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    }
    
}

function loadCheckMancu(makh)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            if(!document.all) value = eval(value+"");
            var ajax = document.getElementById("ajaxkhachhang");
            if(value == 0)
            {
                alert("Lỗi xảy ra trong quá trình truyền dữ liệu");
                ajax.style.display = "none";
                return false;            
            }
            else if(value == 1)
            {
                alert("Mã nhà cung ứng này đã sử dụng rồi . Vui lòng chọn mã nhà cung ứng khác");
                ajax.style.display = "none";
                return;
            }
            else if(value == 2)
            {
                var f = document.khachhang;
                f.secondtime.value = "newkhachhang";
                f.submit();
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=checkmancufromnhacungung&mancu="+makh+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function deletenhacungung(checkname)
{
    var iCount = checkItemChecked(checkname);
    if(iCount == 0)
    {
        alert("Vui lòng chọn ít nhất một nhà cung ứng trước khi xóa ");
        return false;
    }
    else if(confirm("Bạn có chắc muốn xóa những gì bạn chọn không ?"))
    {
        var f = document.khachhang;
        f.secondtime.value = "deletemultikhachhang";
        f.submit();
    }
}
//===========================================
function backlistnhacungung()
{
    document.location.href = "nhacungung.aspx";
}
//===========================================
/* Thông tin khach hang*/
//===========================================
function newkhachhang()
{
    document.location.href = "khachhang.aspx?do=new";
}
//===========================================
function savenewkhachhang()
{
    try
    {
        var makh = document.getElementsByName("makh")[0];
        if(!NumAndChar.test(makh.value))
        {
            alert("Mã khách hàng chỉ cho phép nhập chữ hoặc số . Vui lòng nhập lại");
            makh.focus();
            return false;
        }
        var hoten = document.getElementsByName("hoten")[0];
        if(trim(hoten.value) == "")
        {
            alert("Họ tên không được để trống . Vui lòng nhập lại ");
            hoten.focus();
            return false;
        }
        var dienthoai = document.getElementsByName("dienthoai")[0];
        
        var matk = document.getElementsByName("matk")[0];
        if(!NumAndChar.test(matk.value))
        {
            alert("Mã tài khoản chỉ cho phép nhập chữ hoặc số . Vui lòng nhấn vào dấu chấm hỏi để lấy mã tài khoản chính xác");
            return false;
        }
        var maquan = document.getElementsByName("quanhuyen")[0];
//        if(!NumAndChar.test(maquan.value))
//        {
//            alert("Mã quận huyện chỉ cho phép nhập chữ hoặc số . Vui lòng nhấn vào dấu chấm hỏi để lấy mã quận huyện chính xác");
//            return false;
//        }
        var ajax = document.getElementById("ajaxkhachhang");
        ajax.style.display = "";
        loadCheckMakh(makh.value);
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    }
    
}
//===========================================
function loadCheckMakh(makh)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            if(!document.all) value = eval(value+"");
            var ajax = document.getElementById("ajaxkhachhang");
            if(value == 0)
            {
                alert("Lỗi xảy ra trong quá trình truyền dữ liệu");
                ajax.style.display = "none";
                return false;            
            }
            else if(value == 1)
            {
                alert("Mã khách hàng này đã có người sử dụng rồi . Vui lòng chọn mã khách hàng khác");
                ajax.style.display = "none";
                return;
            }
            else if(value == 2)
            {
                var f = document.khachhang;
                f.secondtime.value = "newkhachhang";
                f.submit();
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=checkmakhfromkhachhang&makh="+makh+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function backlistkhachhang()
{
    document.location.href = "khachhang.aspx";
}
//===========================================
function deletekhachhang(checkname)
{
    var iCount = checkItemChecked(checkname);
    if(iCount == 0)
    {
        alert("Vui lòng chọn ít nhất một khách hàng trước khi xóa ");
        return false;
    }
    else if(confirm("Bạn có chắc muốn xóa những gì bạn chọn không ?"))
    {
        var f = document.khachhang;
        f.secondtime.value = "deletemultikhachhang";
        f.submit();
    }
}
//===========================================
function updatekhachhang()
{
    try
    {
        var makh = document.getElementsByName("makh")[0];
        if(trim(makh.value) == "")
        {
            alert("Mã không được để trống . Vui lòng nhập lại ");
            makh.focus();
            return false;
        }
        var hoten = document.getElementsByName("hoten")[0];
        if(trim(hoten.value) == "")
        {
            alert("Họ tên không được để trống . Vui lòng nhập lại ");
            hoten.focus();
            return false;
        }
        var dienthoai = document.getElementsByName("dienthoai")[0];
//        if(!phoneReg.test(dienthoai.value) && trim(dienthoai.value) != "")
//        {
//            alert("Vui lòng nhập số điện thoại như hướng dẫn");
//            dienthoai.focus();
//            return false;
//        }
        var f = document.khachhang;
        f.secondtime.value = "updatekhachhang";
        f.submit();
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    }   
}
//===========================================
function delkhachhang()
{
    try
    {
        if(confirm("Bạn có chắc muốn xóa khách hàng này không ?"))
        {
            var f = document.khachhang;
            f.secondtime.value = "deletekhachhang";
            f.submit();
        }
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;        
    }
}

function delnhacungung()
{
    try
    {
        if(confirm("Bạn có chắc muốn xóa nhà cung ứng này không ?"))
        {
            var f = document.khachhang;
            f.secondtime.value = "deletekhachhang";
            f.submit();
        }
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;        
    }
}
//===========================================
function showNewLayOutKhachHang()
{
    try
    {
        var layout = document.getElementsByName("layout")[0];
        layout = _parseInt(layout);
        layout = layout == 0 ? 10 : layout;
        var f = document.khachhang;
        f.secondtime.value = "loadlayout";
        f.submit();
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;   
    }
}
//==========================================
function nextpagekhachhang(curpage)
{
    try
    {
        var page = document.getElementsByName("page")[0];
        page = page.options[page.selectedIndex].value;
        if(page != curpage)
        {
            document.location.href = "khachhang.aspx?page="+page;
        }
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false; 
    }
}
//===========================================
/*Thong tin danh muc kho*/
//===========================================
function savenewkho()
{
    try
    {
        var makho = document.getElementsByName("makho")[0];
        if(!NumAndChar.test(makho.value))
        {
            alert("Mã kho chỉ cho phép nhập chữ hoặc số . Vui lòng nhập lại");
            makho.focus();
            return false;
        }
        var tenkho = document.getElementsByName("tenkho")[0];
        if(trim(tenkho.value) == "")
        {
            alert("Tên kho không được để trống . Vui lòng nhập lại ");
            tenkho.focus();
            return false;
        }
        var ajax = document.getElementById("ajaxkho");
        ajax.style.display = "";
        loadCheckMakho(makho.value);
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    } 
}
//===========================================
function loadCheckMakho(makho)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            value = eval(value);
            var ajax = document.getElementById("ajaxkho");
            
            if(value == 0)
            {
                alert("Lỗi xảy ra trong quá trình truyền dữ liệu");
                ajax.style.display = "none";
                return false;            
            }
            else if(value == 1)
            {
                alert("Mã kho này đã sử dụng rồi . Vui lòng chọn mã kho khác");
                ajax.style.display = "none";
                return;
            }
            else if(value == 2)
            {
                var f = document.kho;
                f.secondtime.value = "newkho";
                f.submit();
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=checkmakhofromkho&makho="+makho+"&times="+Math.random(),true);
    xmlHttp.send(null);
}

//===========================================
function loadDanhSachKho(makho)
{
    try
    {
        var span = document.getElementById("ajaxdanhmuckho");
        span.style.display = "";
        loadChiTietKho(makho);
    }
    catch(exception)
    {
    }
}
//===========================================
function loadChiTietKho(makho)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            
            var ajax = document.getElementById("ajaxdanhmuckho");
            ajax.style.display = "";
            if(value == "error")
            {
                alert("Lỗi xảy ra trong quá trình truyền dữ liệu");
                return false;            
            }
            else 
            {
                var td = document.getElementById("chitietkho");
                td.innerHTML = value;
                editor_generate('ghichu');
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=loadchitietkho&makho="+makho+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function newKho()
{
    try
    {
        var makho = document.getElementsByName("makho")[0];
        makho.value = "";
        var html = "";
        html += "<input type=\"text\" name=\"makho\" style=\"width:250px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\"/>";
        html += "<img src=\"images/quest.gif\" style=\"cursor:pointer;\" align=\"middle\" title=\"click vào để xem danh sách mã kho\"  onclick=\"showDanhSachKho(0)\"/>";
        html += "&nbsp;(&nbsp;<font color=\"red\">*</font>&nbsp;)&nbsp;là các thông tin bắt buộc";
        makho.parentNode.innerHTML = html;
        var tenkho = document.getElementsByName("tenkho")[0];
        tenkho.value = "";
        var td = document.getElementById("functionkho");
        html = "<br/>";
        html += "<input type=\"button\" name=\"luu\" onclick=\"savenewkho()\" value=\"Lưu\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"reset\" name=\"cancel\" value=\"Làm lại\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"deletekho('checkall')\" style=\"width:80px;\" />&nbsp;&nbsp;";
        html += "<span class=\"ajax\" id=\"ajaxdanhmuckho\" style=\"display:none;\"><img src=\"images/processing.gif\" border=\"0\" />&nbsp;đang load dữ liệu ...</span>";
        td.innerHTML = html;
    }
    catch(exception)
    {
    }
}


//===========================================
function deletekho(checkname)
{
    var iCount = checkItemChecked(checkname);
    if(iCount == 0)
    {
        alert("Vui lòng chọn ít nhất một kho trước khi xóa ");
        return false;
    }
    else if(confirm("Bạn có chắc muốn xóa những gì bạn chọn không ?"))
    {
        var f = document.kho;
        f.secondtime.value = "deletemultikho";
        f.submit();
    }
}
//===========================================
function saveupdatekho()
{
    try
    {
        var tenkho = document.getElementsByName("tenkho")[0];
        if(trim(tenkho.value) == "")
        {
            alert("Tên kho không được để trống . Vui lòng nhập lại ");
            tenkho.focus();
            return false;
        }
        var f = document.kho;
        f.secondtime.value = "updatekho";
        f.submit();
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    }   
}

//===========================================
/*Thong tin nhom thuoc*/
//===========================================
function savenewnhom()
{
    try
    {
        var group = document.getElementById("ddlcate");
        if (eval(group.value) == 0)
        {
            alert("Bạn chưa chọn nhóm . Vui lòng nhập lại");
            group.focus();
            return false;
        }
        
        var makho = document.getElementsByName("makho")[0];
        if(!NumAndChar.test(makho.value))
        {
            alert("Mã nhóm thuốc chỉ cho phép nhập chữ hoặc số . Vui lòng nhập lại");
            makho.focus();
            return false;
        }
        var tenkho = document.getElementsByName("tenkho")[0];
        if(trim(tenkho.value) == "")
        {
            alert("Tên nhóm thuốc không được để trống . Vui lòng nhập lại ");
            tenkho.focus();
            return false;
        }
        var ajax = document.getElementById("ajaxkho");
        ajax.style.display = "";
        loadCheckMaNhom(makho.value);
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    } 
}
//===========================================
function loadCheckMaNhom(makho)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            value = eval(value);
            var ajax = document.getElementById("ajaxkho");
            
            if(value == 0)
            {
                alert("Lỗi xảy ra trong quá trình truyền dữ liệu");
                ajax.style.display = "none";
                return false;            
            }
            else if(value == 1)
            {
                alert("Mã nhóm thuốc này đã sử dụng rồi . Vui lòng chọn mã nhóm khác");
                ajax.style.display = "none";
                return;
            }
            else if(value == 2)
            {
                var f = document.kho;
                f.secondtime.value = "newnhom";
                f.submit();
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=checkmanhomfromnhomthuoc&makho="+makho+"&times="+Math.random(),true);
    xmlHttp.send(null);
}

//===========================================
function loadDanhSachNhom(makho)
{
    try
    {
        var span = document.getElementById("ajaxdanhmuckho");
        span.style.display = "";
        loadChiTietNhom(makho);
    }
    catch(exception)
    {
    }
}
//===========================================
function loadChiTietNhom(manhom)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
           
            var ajax = document.getElementById("ajaxdanhmuckho");
            ajax.style.display = "";
            if(value == "error")
            {
                alert("Lỗi xảy ra trong quá trình truyền dữ liệu");
                return false;            
            }
            else 
            {
                var td = document.getElementById("chitietkho");
                td.innerHTML = value;                
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=loadchitietnhomthuoc&manhom="+manhom+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function newNhom()
{
    try
    {
        var makho = document.getElementsByName("makho")[0];
        makho.value = "";
        var html = "";
        html += "<input type=\"text\" name=\"makho\" style=\"width:250px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\"/>";
        html += "&nbsp;(&nbsp;<font color=\"red\">*</font>&nbsp;)&nbsp;là các thông tin bắt buộc";
        makho.parentNode.innerHTML = html;
        var tenkho = document.getElementsByName("tenkho")[0];
        tenkho.value = "";
        var td = document.getElementById("functionkho");
        html = "<br/>";
        html += "<input type=\"button\" name=\"luu\" onclick=\"savenewnhom()\" value=\"Lưu\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"reset\" name=\"cancel\" value=\"Làm lại\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"deletenhom('checkall')\" style=\"width:80px;\" />&nbsp;&nbsp;";
        html += "<span class=\"ajax\" id=\"ajaxdanhmuckho\" style=\"display:none;\"><img src=\"images/processing.gif\" border=\"0\" />&nbsp;đang load dữ liệu ...</span>";
        td.innerHTML = html;
    }
    catch(exception)
    {
    }
}


//===========================================
function deletenhom(checkname)
{
    var iCount = checkItemChecked(checkname);
    if(iCount == 0)
    {
        alert("Vui lòng chọn ít nhất một nhóm trước khi xóa ");
        return false;
    }
    else if(confirm("Bạn có chắc muốn xóa những gì bạn chọn không ?"))
    {
        var f = document.kho;
        f.secondtime.value = "deletemultinhom";
        f.submit();
    }
}
//===========================================
function saveupdatenhom()
{
    try
    {
        var tenkho = document.getElementsByName("tenkho")[0];
        if(trim(tenkho.value) == "")
        {
            alert("Tên nhóm không được để trống . Vui lòng nhập lại ");
            tenkho.focus();
            return false;
        }
        var f = document.kho;
        f.secondtime.value = "updatenhom";
        f.submit();
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    }   
}

//===========================================
/*Thong tin hãng sản xuất thuốc*/
//===========================================
function savenewhangsanxuat()
{
    try
    {
        var makho = document.getElementsByName("makho")[0];
        if(!NumAndChar.test(makho.value))
        {
            alert("Mã hãng sản xuất chỉ cho phép nhập chữ hoặc số . Vui lòng nhập lại");
            makho.focus();
            return false;
        }
        var tenkho = document.getElementsByName("tenkho")[0];
        if(trim(tenkho.value) == "")
        {
            alert("Tên hãng sản xuất không được để trống . Vui lòng nhập lại ");
            tenkho.focus();
            return false;
        }
        var tenkho = document.getElementsByName("tenkho")[0];
        if(trim(tenkho.value) == "")
        {
            alert("Tên nhóm thuốc không được để trống . Vui lòng nhập lại ");
            tenkho.focus();
            return false;
        }
        var ajax = document.getElementById("ajaxkho");
        ajax.style.display = "";
        loadCheckMaHangSanXuat(makho.value);
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    } 
}
//===========================================
function loadCheckMaHangSanXuat(mahang)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            value = eval(value);
            var ajax = document.getElementById("ajaxkho");
            
            if(value == 0)
            {
                alert("Lỗi xảy ra trong quá trình truyền dữ liệu");
                ajax.style.display = "none";
                return false;            
            }
            else if(value == 1)
            {
                alert("Mã hãng sản xuất này đã sử dụng rồi . Vui lòng chọn mã khác");
                ajax.style.display = "none";
                return;
            }
            else if(value == 2)
            {
                var f = document.getElementById("kho");
                var sc = document.getElementById("secondtime");
                sc.value = "newhangsanxuat";
                //f.secondtime.value = "newhangsanxuat";
                f.submit();
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=checkmahangfromhansanxuat&mahang="+mahang+"&times="+Math.random(),true);
    xmlHttp.send(null);
}

//===========================================
function loadDanhSachHangSanXuat(mahangsanxuat)
{
    try
    {
        var span = document.getElementById("ajaxdanhmuckho");
        span.style.display = "";
        loadChiTietHangSanXuat(mahangsanxuat);
    }
    catch(exception)
    {
    }
}
//===========================================
function loadChiTietHangSanXuat(mahang)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            var ajax = document.getElementById("ajaxdanhmuckho");
            ajax.style.display = "";
            if(value == "error")
            {
                alert("Lỗi xảy ra trong quá trình truyền dữ liệu");
                return false;            
            }
            else 
            {
                var td = document.getElementById("chitietkho");
                td.innerHTML = value;                
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=loadchitiethangsanxuat&mahang="+mahang+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function newHang()
{
    try
    {
        var makho = document.getElementsByName("makho")[0];
        makho.value = "";
        var html = "";
        html += "<input type=\"text\" name=\"makho\" style=\"width:250px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\"/>";
        html += "&nbsp;(&nbsp;<font color=\"red\">*</font>&nbsp;)&nbsp;là các thông tin bắt buộc";
        makho.parentNode.innerHTML = html;
        var tenkho = document.getElementsByName("tenkho")[0];
        tenkho.value = "";
        var td = document.getElementById("functionkho");
        html = "<br/>";
        html += "<input type=\"button\" name=\"luu\" onclick=\"savenewhangsanxuat()\" value=\"Lưu\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"reset\" name=\"cancel\" value=\"Làm lại\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"deletehangsanxuat('checkall')\" style=\"width:80px;\" />&nbsp;&nbsp;";
        html += "<span class=\"ajax\" id=\"ajaxdanhmuckho\" style=\"display:none;\"><img src=\"images/processing.gif\" border=\"0\" />&nbsp;đang load dữ liệu ...</span>";
        td.innerHTML = html;
    }
    catch(exception)
    {
    }
}


//===========================================
function deletehangsanxuat(checkname)
{
    var iCount = checkItemChecked(checkname);
    if(iCount == 0)
    {
        alert("Vui lòng chọn ít nhất một hãng sản xuất trước khi xóa ");
        return false;
    }
    else if(confirm("Bạn có chắc muốn xóa những gì bạn chọn không ?"))
    {
        var f = document.kho;
        f.secondtime.value = "deletehangsanxuat";
        f.submit();
    }
}
//===========================================
function saveupdatehangsanxuat()
{
    try
    {
        var tenkho = document.getElementsByName("tenkho")[0];
        if(trim(tenkho.value) == "")
        {
            alert("Tên hãng không được để trống . Vui lòng nhập lại ");
            tenkho.focus();
            return false;
        }
        var f = document.kho;
        f.secondtime.value = "updatehangsanxuat";
        f.submit();
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    }   
}


//===========================================

//===========================================
/*Thong tin vat tu*/
//===========================================
function loadDanhmucVatTu(mavt)
{
    var span = document.getElementById("ajaxdanhmucvattu");
    span.style.display = "";
    loadVatTu(mavt);
}
//===========================================
function loadVatTu(mavt)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            
            var ajax = document.getElementById("ajaxdanhmucvattu");
            ajax.style.display = "";
            if(value == 0)
            {
                alert("Lỗi xảy ra trong quá trình truyền dữ liệu");
                return false;            
            }
            else 
            {
                var td = document.getElementById("chitietvattu");
                td.innerHTML = value;
                editor_generate('mota');
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=loaddanhmucvattu&mavt="+mavt+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function saveupdatevattu()
{
    try
    {
        var f = document.vattu;
        f.secondtime.value = "updatevattu";
        f.submit();
    }
    catch(exception)
    {
    }
}
//===========================================
function newVatTu()
{
    try
    {
        var mavt = document.getElementsByName("mavt")[0];
        mavt.value = "";
        mavt.readOnly = false;
        var tenvt = document.getElementsByName("tenvt")[0];
        tenvt.value = "";
        var madvt = document.getElementsByName("madvt")[0];
        madvt.value = "";
        var texta = document.getElementById("motavattu");
        html = "";
        html += "<textarea name=\"mota\" style=\"width:100%;\" rows=\"4\"></textarea>";
        //html += "<script language=\"javascript\">editor_generate('mota')</script>";
        texta.innerHTML = html;
        editor_generate('mota');
        var td = document.getElementById("functionvattu");
        var html = "";
        html += "<br/>";
        html += "<center>";
        html += "<input type=\"button\" name=\"luu\" onclick=\"savenewvattu()\" value=\"Lưu\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"reset\" name=\"cancel\" value=\"Làm lại\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"deletevattu('checkall')\" style=\"width:80px;\" />";
        html += "<span class=\"ajax\" id=\"ajaxdanhmucvattu\" style=\"display:none;\"><img src=\"images/processing.gif\" border=\"0\" />&nbsp;đang load dữ liệu ...</span>";
        html += "</center>";
        td.innerHTML = html;
    }
    catch(exception)
    {
    }
}
//=========Load previewous ma thuc=================================
function LoadPreMaThuoc(manhom)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            var mavt = document.getElementsByName("mathuoc")[0];
            mavt.value = value;
            mavt.focus();            
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=loadmanhomthuoc&manhom="+manhom+"&times="+Math.random(),true);
    xmlHttp.send(null);
}

//===========================================
function savenewvattu()
{
    try
    {
        var nhomthuoc = document.getElementsByName("ddlnhomthuoc")[0];
        if(nhomthuoc.value == "0")
        {
            alert("Vui lòng chọn nhóm thuốc");
            nhomthuoc.focus();
            return false;
        }
        var mavt = document.getElementsByName("mathuoc")[0];
        if(!NumAndChar.test(mavt.value))
        {
            alert("Mã thuốc chỉ cho phép nhập chữ hoặc số . Vui lòng nhập lại");
            mavt.focus();
            return false;
        }
        var tenvt = document.getElementsByName("tenthuoc")[0];
        if(trim(tenvt.value) == "")
        {
            alert("Tên thuốc không được để trống . Vui lòng nhập lại ");
            tenvt.focus();
            return false;
        }
        var congthuc = document.getElementsByName("txtcongthuc")[0];
        if(trim(congthuc.value) == "")
        {
            alert("Bạn chưa nhập công thức thuốc . Vui lòng nhập lại ");
            congthuc.focus();
            return false;
        }
        var hangsx = document.getElementsByName("ddlhangsanxuat")[0];
        if(hangsx.value == "0")
        {
            alert("Bạn chưa chọn hãng sản xuất . Vui lòng nhập lại ");
            hangsx.focus();
            return false;
        }
        var ngayhethan = document.getElementsByName("txtngayhethan")[0];
        if(trim(ngayhethan.value) == "")
        {
            alert("Bạn chưa nhập ngày hết hạn sử dụng thuốc . Vui lòng nhập lại ");
            ngayhethan.focus();
            return false;
        }
        var tenvt = document.getElementsByName("tenthuoc")[0];
        if(trim(tenvt.value) == "")
        {
            alert("Tên thuốc không được để trống . Vui lòng nhập lại ");
            tenvt.focus();
            return false;
        }
        var madvt = document.getElementsByName("madvt")[0];
        if(trim(madvt.value) == "")
        {
            alert("Vui lòng chọn mã đơn vị tính");
            madvt.focus();
            return false;
        }
        
        var ajax = document.getElementById("ajaxvattu");
        ajax.style.display = "";
        loadCheckMavt(mavt.value);
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    }  
}
//===========================================
function loadCheckMavt(mavt)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            
            var ajax = document.getElementById("ajaxvattu");
            ajax.style.display = "none";
            var mavt = document.getElementsByName("mathuoc")[0];
            if(value == 0)
            {
                alert("Lỗi xảy ra trong quá trình truyền dữ liệu");
                ajax.style.display = "none";
                return false;            
            }
            else if(value == 1)
            {
                alert("Mã thuốc này đã sử dụng rồi . Vui lòng chọn mã thuốc khác");
                ajax.style.display = "none";
                mavt.focus();
                return;
            }
            else if(value == 2)
            {
                var f = document.vattu;
                f.secondtime.value = "newvattu";
                f.submit();                
                mavt.focus();
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=checkmathuocfromthuoc&mathuoc="+mavt+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function deletevattu(checkname)
{
    var iCount = checkItemChecked(checkname);
    if(iCount == 0)
    {
        alert("Vui lòng chọn ít nhất một vật tư trước khi xóa ");
        return false;
    }
    else if(confirm("Những thuốc bạn chọn xóa được sử dụng trong nhiều bảng khác.\nBạn có chắc muốn xóa những gì bạn chọn không ?"))
    {
        var f = document.vattu;
        f.secondtime.value = "deletemultivattu";
        f.submit();
    }
}
//===========================================
function showNewLayOutVatTu()
{
    try
    {
        var layout = document.getElementsByName("layout")[0];
        layout = _parseInt(layout);
        layout = layout == 0 ? 10 : layout;
        var f = document.vattu;
        f.secondtime.value = "loadlayout";
        f.submit();
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;   
    }
}
//==========================================
function nextpagevattu(curpage)
{
    try
    {
        var page = document.getElementsByName("page")[0];
        page = page.options[page.selectedIndex].value;
        if(page != curpage)
        {
            document.location.href = "danhmucthuoc.aspx?page="+page;
        }
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false; 
    }
}

//===========================================
function set_active(position)
{
    try
    {
    var e = event ? event : window.event;
    var obj = e.srcElement ? e.srcElement : e.target;
    var parent = obj.parentNode;
    for(var i = 0; i < parent.children.length; i++)
        parent.children[i].className = "tabdeactive";
    obj.className = "tabactive";
    loadSetPosition(position);
    }
    catch(exception)
    {
    }
}

//===========================================
function loadSetPosition(position)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            if(!document.all) value = eval(value+"");
            if(value == -1)
            {
                return false;            
            }
            else if(value >= 0)
            {
                var arr = new Array();
                arr[0] = "danhmucvattu.aspx";
                arr[1] = "danhmucvattukho.aspx";
                arr[2] = "danhmucvattukhuvuc.aspx";
                document.location.href = arr[value];                
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=setposition&position="+position+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function set_active_Phieu(position)
{
    try
    {
    var e = event ? event : window.event;
    var obj = e.srcElement ? e.srcElement : e.target;
    var parent = obj.parentNode;
    for(var i = 0; i < parent.children.length; i++)
        parent.children[i].className = "tabdeactive";
    obj.className = "tabactive";
    loadSetPositionPhieu(position);
    }
    catch(exception)
    {
    }
}
//===========================================
function loadSetPositionPhieu(position)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            if(!document.all) value = eval(value+"");
            if(value == -1)
            {
                return false;            
            }
            else if(value >= 0)
            {
                var arr = new Array();
                arr[0] = "quanlyphieu.aspx";
                arr[1] = "danhmucphieuxuat.aspx";
                document.location.href = arr[value];                
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=setposition&position="+position+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
//Cac ham xu ly phan danh muc thuoc

function LostFocus(obj)
{
    var objold = document.getElementById("tr_" + obj);
    objold.style.background = "White"; 
}

function SetRow(obj)
{
    var objold = document.getElementById("tr_" + obj);
    objold.style.background = "#D4E6FF"; 
    //var objtxt = document.getElementById("txt_" + obj);
    //objtxt.focus();
}

function VaokeyDown(obj,inum)
{
    keycode = window.event.keyCode;
    if (keycode == 40)
    {
        if (obj < inum)
        {
            var idow = obj + 1;
            var objdown = document.getElementById("tr_" + idow);
            objdown.style.background='#D4E6FF';
            var objold = document.getElementById("tr_" + obj);
            objold.style.background = "White"; 
            var objtxt = document.getElementById("txt_" + idow);
            objtxt.focus();
        }
    }
    if (keycode == 38)
    {
        if (obj > 1)
        { 
            var idow = obj - 1;
            var objdown = document.getElementById("tr_" + idow);
            objdown.style.background='#D4E6FF';
            objdown.focus();
            var objold = document.getElementById("tr_" + obj);
            objold.style.background = "White"; 
            var objtxt = document.getElementById("txt_" + idow);
            objtxt.focus();
        }
    }

}


function loadEditInline(idold, idnew, idthuoc)
{
    var objold = document.getElementById("tr_"+idold);
    var objnew = document.getElementById("trr_"+idnew);
    objold.style.display = "none";
    objnew.style.display = '';
    var omatp = document.getElementById("txttenthuoc_"+idthuoc);
    omatp.focus();
}

//idold : ma dong
//idnew: ma thuoc
function SaveEdit(idold, idnew)
{
    try
    {
        var mavt = document.getElementById("txtmathuoc_"+idnew);
        
        if(!NumAndChar.test(mavt.value))
        {
            alert("Mã vật tư chỉ cho phép nhập chữ hoặc số . Vui lòng nhập lại");
            mavt.focus();
            return false; 
        }
        var tenvt = document.getElementById("txttenthuoc_"+idnew);
        
        if(trim(tenvt.value) == "")
        {
            alert("Tên vật tư không được để trống . Vui lòng nhập lại ");
            tenvt.focus();
            return false;
        }
        var madvt = document.getElementById("txtdvt_"+idnew);
        
        if(trim(madvt.value) == "")
        {
            alert("Vui lòng chọn mã đơn vị tính");
            return false;
        }
        var manhom = document.getElementById("ddlnhomthuoc_"+idnew);
        var congthuc = document.getElementById("txtcongthuc_"+idnew);
        var ngayhethan = document.getElementById("txtngayhethan_"+idnew);
        var tondau = document.getElementById("txttondau_"+idnew);
        var giaban = document.getElementById("txtgiaban_"+idnew);
        UpdateThanhPham(idold,idnew, mavt.value, myEscape(tenvt.value), myEscape(madvt.value), tondau.value, giaban.value, manhom.value, congthuc.value, ngayhethan.value);           
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra. Vui lòng xem lại script ");
        return false;
    }  
}


function UpdateThanhPham(iddong, idthuoc, matpnew, tentp, dvt, tondau, giaban, manhomthuoc, congthuc, ngayhethan)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            if(value == 0)
            {
                alert("Lỗi xảy ra trong quá trình truyền dữ liệu");
                return false;            
            }
            else if(value == 1)
            {
                alert("Cập nhật thành công.");
                document.location.href = "danhmucthuoc.aspx";
            }                
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=updatethuoc&idthuoc=" + idthuoc + "&mathuoc=" + matpnew + "&tentthuoc=" + tentp + "&dvt=" + dvt + "&tondau=" + tondau + "&giaban=" + giaban + "&manhom=" + manhomthuoc + "&congthuc=" +  congthuc + "&ngayhethan=" + ngayhethan + "&times="+Math.random(),true);
    xmlHttp.send(null);
}



function SetReSet(idold, idnew)
{
    var objold = document.getElementById("tr_"+idold);
    var objnew = document.getElementById("trr_"+idnew);
    objold.style.display = "";
    objnew.style.display = 'none';
    var objmatp = document.getElementById("txtmathuoc_"+idnew);
    objmatp.value = idnew;
    var obj = document.getElementById("txt_"+idold);
    obj.focus();
}

//matp: ma thuoc cu, idthuoc: id cua thuoc
function CheckTrungMatp(matp, idthuoc)
{
    var objmatp = document.getElementById("txtmathuoc_"+idthuoc);
    if (objmatp.value != matp)
    {
        checkmatp(objmatp.value, idthuoc);            
    }
}


//mavt: ma thuoc moi, idthuoc: ma thuoc


function checkmatp(mavt, idthuoc)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            if(!document.all) value = eval(value+"");
            if(value == 0)
            {
                alert("Lỗi xảy ra trong quá trình truyền dữ liệu");
                var objmatp = document.getElementById("txtmathuoc_"+idthuoc);
                objmatp.focus();
                return 0;            
            }
            else if(value == 1)
            {
                alert("Mã thuốc này đã sử dụng rồi . Vui lòng chọn mã thuốc khác");
                var objmatp = document.getElementById("txtmathuoc_"+idthuoc);
                objmatp.focus();
                return 0;
            }                
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=checkmathuocfromthuoc&mathuoc="+mavt+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
/************* Ket thuc cac ham xu ly danh muc thuoc ******************/  
  
  //**************Xu ly phieu nhap thuoc *******************/
  
  function Anthongtin()
    {
        var obj = document.getElementById('thongtinchungpn');
        obj.style.display = 'none';
        /*var obj1 = document.getElementById('Button5');
        obj1.style.display = '';
        var obj2 = document.getElementById('Button4');
        obj2.style.display = 'none';*/
    }
    
    function Hienthongtin()
    {
        var obj = document.getElementById('thongtinchungpn');
        obj.style.display = '';
        /*var obj1 = document.getElementById('Button4');
        obj1.style.display = '';
        var obj2 = document.getElementById('Button5');
        obj2.style.display = 'none';*/
    }

    function CheckNum(obj)
    {
//        var obj = document.getElementById(obj);
//        if (obj.value != "")
//        {
//            if (! CheckNumberFloat(obj.value))
//            {
//                alert("Bạn nhập dữ liệu không hợp lệ. Vui lòng nhập số.");
//                obj.value = "0";
//                obj.focus();
//            }
//        }
    }
    //Kiem tra Ngay
	function TestDate(t,objct)
	{
		var obj = document.getElementById(t);
		if (obj.value != "")
		{
			obj.value=AddString(obj.value);
			if (isDate(obj.value)==false)
				{
					obj.value="";
					alert("Bạn nhập ngày tháng không hợp lệ ! ");
					obj.focus();
				}
		    var objct = document.getElementById(objct);
		    var svalct = objct.value;
		    CheckTrungChungTuPN(obj.value,svalct,objct,obj); 
		}
		return;
	}  
	
	function CheckTrungChungTuPN(sngaythang,soct,objct,obj)
	{
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if (value == "1")
                {
                    alert("Chứng từ này đã tồn tại rồi. Vui lòng kiểm tra lại.");
                    objct.focus();
                }
                if (value == "2")
                {
                    alert("Ngày tháng chứng từ không hợp lệ. Vui lòng kiểm tra lại.");
                    obj.focus();
                }
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=checktrungphieunhap&soct="+soct+"&ngaythang="+sngaythang+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	function  SetFocus(obj)
	{
	    var obje = document.getElementById(obj);
	    keycode = window.event.keyCode;
        if(keycode == 13)
        {
            obje.focus();
	    }	
	}
	function SetDongia(objvattu,objdongia)
	{
	    var objvt = document.getElementById(objvattu);
	    LoadDonGiaBanThuoc(objvt.value);
	}
	
	function CheckDoiTuong()
	{
	    var objkh = document.getElementById("ddlKhachhang");
	    if (objkh.value == "0" || objkh.value == "")
	    {
	        alert("Bạn chưa chọn đối tượng nhập. Vui lòng kiểm tra lại.");
	        var obj = document.getElementById("txtdoituong");
	        obj.value = "";
	        obj.focus();
	    }
	}
	
	function SetDoiTuong()
	{
	    var objkh = document.getElementById("ddlKhachhang");
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;                 
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=setdoituong&madt="+objkh.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	function SetDongia_()
	{
	    var objvt = document.getElementById("ddlVatTu");
	    //alert(objvt.value);
	    LoadDonGiaBanThuoc(objvt.value);	    
	}
	function LoadDonGia(sVT)
	{
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var dg = document.getElementById("txtDonGia");
                dg.value = value;
                var soluong = document.getElementById('txtSoLuong');
                soluong.value = '0';
                soluong.focus();
//                var ngayhethan = document.getElementById('txtngayhethan');
//                ngayhethan.focus();
//                LoadInfoThuoc(sVT);
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=getdongiaban&mavt="+sVT+"&times="+Math.random(),true);
        xmlHttp.send(null);
        
       // 
	}
	
	function LoadInfoThuoc(mathuoc)
	{
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var arrval = value.split("#");
                var hsx = document.getElementById("txthangsanxuat");
                hsx.value = arrval[0];
                var nhom = document.getElementById("txtnhomthuoc");
                nhom.value = arrval[1];
                var congthuc = document.getElementById('txtcongthuc');
                congthuc.value = arrval[2];
                var dvt = document.getElementById('txtdonvitinh');
                dvt.value = arrval[3];                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loadinfothuoc&mavt="+mathuoc+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	function themmoikhachhang()
    {
        try
        {
            var obj = new Object();
            obj = window.showModalDialog("themkhachhang.aspx?times="+Math.random(),"","DialogWidth:650px;DialogHeight:500px;overflow:hidden;");
        }
        catch(exception)
        {
            alert("Lỗi xảy ra , vui lòng xem lai script");
            return false;
        }
    }
    function Loaddmtp(strS)
    {
        if (strS != "")
        {
            var str = myEscape(strS);
            ChangeListThanhPham(str);
        }
    }
    function ChangeListThanhPham(str)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("listthanhpham"); 
                obj.innerHTML = value;                
                SetDongia_();
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loadchangethuoc&strSear="+str+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    //====================================================================================
    function BindDetailPhieu(ovVat,iLoai)
    {
        var oSoCt = document.getElementById("txtSoCT"); 
        var oNgayCt = document.getElementById("txtNgayCT"); 
        if (oSoCt.value != "" && oNgayCt.value != "")
        {
            xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                    var obj = document.getElementById("chitietphieu"); 
                    obj.innerHTML = value;                                    
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=bindphieubyvat&mact="+oSoCt.value+"&ngayct="+oNgayCt.value+"&vat="+ovVat+"&loai="+iLoai+"&times="+Math.random(),true);
            xmlHttp.send(null);
        }        
    }
    function ResetSession()
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=resetsession&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    function DoActionPhieuNhap()
    {
        var keycode = 9;
        var opxid = document.getElementById("txtpxid");         
        if(keycode == 13)
        {
//            if (opxid.value == "-1")
//            {
//                var oSoCt = document.getElementById("txtSoCT"); 
//                var oNgayCt = document.getElementById("txtNgayCT"); 
//                var oKho = document.getElementById("ddlKho"); 
//                var oncc = document.getElementById("ddlncc");
//                var ongayhoadon = document.getElementById("txtngayhoadon");
//                var otennguoigiao = document.getElementById("txttennguoigiao");
//                var oDienGiai = document.getElementById("txtDienGiai"); 
//                
//                var omavt = document.getElementById("ddlVatTu"); 
//                var osoluong = document.getElementById("txtSoLuong"); 
//                var odongia = document.getElementById("txtDonGia");
//                var olosx = document.getElementById("txtlosx");
//                var ongayhethan = document.getElementById("txtngayhethan");
//            }
//            else
//            {
//                var omavt = document.getElementById("ddlVatTu"); 
//                var osoluong = document.getElementById("txtSoLuong"); 
//                var odongia = document.getElementById("txtDonGia");
//                var olosx = document.getElementById("txtlosx");
//                var ongayhethan = document.getElementById("txtngayhethan");
//            } 
//        
//            if (opxid.value == "-1") // da them moi thanh cong 1 phieu nhap
//            {
//                if (CheckThongTinPhieuNhap(oSoCt, oNgayCt, oKho, oncc, ongayhoadon, otennguoigiao, oDienGiai) && CheckThongTinCTPhieuNhap(omavt,osoluong,odongia, olosx, ongayhethan))
//                {
//                    LuuPhieuNhap(oSoCt.value, oNgayCt.value, oKho.value, oncc.value, ongayhoadon.value, otennguoigiao.value, oDienGiai.value, omavt.value, osoluong.value, odongia.value, olosx.value, ongayhethan.value);
//                }
//            }
//            else
//            {
//               if( CheckThongTinCTPhieuNhap(omavt,osoluong,odongia, olosx, ongayhethan))
//               {
//                     LuuChiTietPhieuNhap(omavt.value, osoluong.value, odongia.value, olosx.value, ongayhethan.value);                    
//               }
//            }       
//            var obj = new Object();
//            obj = window.showModalDialog("popupcomfirenhap.aspx?times="+Math.random(),"","DialogWidth:250px;DialogHeight:150px;dialogTop:120px;dialogLeft:700px;overflow:hidden;");  
//            CheckNew();            
        }
        if(keycode == 9) // Phim Tab
        {
            
            if (opxid.value == "-1")
            {
                var oSoCt = document.getElementById("txtSoCT"); 
                var oNgayCt = document.getElementById("txtNgayCT"); 
                var oKho = document.getElementById("ddlKho"); 
                var oNCC = document.getElementById("ddlncc"); 
                var ongayhoadon = document.getElementById("txtngayhoadon");
                var otennguoigiao = document.getElementById("txttennguoigiao");
                var oDienGiai = document.getElementById("txtDienGiai"); 
                var onhapcho = document.getElementById("ddlKho");
                var omavt = document.getElementById("ddlVatTu"); 
                var osoluong = document.getElementById("txtSoLuong"); 
                var odongia = document.getElementById("txtDonGia");
                var olosx = document.getElementById("txtlosx");
                var ongayhethan = document.getElementById("txtngayhethan");
            }
            else
            {
                //var odongiagoc = document.getElementById("txtdongiagoc"); 
                var omavt = document.getElementById("ddlVatTu"); 
                var osoluong = document.getElementById("txtSoLuong"); 
                var odongia = document.getElementById("txtDonGia");
                var olosx = document.getElementById("txtlosx");
                var ongayhethan = document.getElementById("txtngayhethan");
            }            
            
            if (opxid.value == "-1") // da them moi thanh cong 1 phieu nhap
            {
                if ( CheckThongTinPhieuNhap(oSoCt, oNgayCt, oKho, oNCC, ongayhoadon, otennguoigiao, oDienGiai) && CheckThongTinCTPhieuNhap(omavt,osoluong,odongia, olosx, ongayhethan))
                {
                    LuuPhieuNhap(oSoCt.value, oNgayCt.value, oKho.value, oDienGiai.value, oNCC.value, ongayhoadon.value, otennguoigiao.value, onhapcho.value, omavt.value,osoluong.value,odongia.value, olosx.value, ongayhethan.value);
                }
            }
            else
            {
               if( CheckThongTinCTPhieuNhap(omavt,osoluong,odongia, olosx, ongayhethan))
               {
                     LuuChiTietPhieuNhap(omavt.value,osoluong.value,odongia.value, olosx.value, ongayhethan.value);
                    
               }
            }
	    }  
	    return;
    }
    
        
    function CheckThongTinPhieuNhap(oSoCt, oNgayCt, oKho, oNCC, oNgayHoaDon, oTenNguoiGiao, oDienGiai)
    {
        if (oSoCt.value == "")
        {
            alert("Bạn chưa nhập số chứng từ. Vui lòng kiểm tra lại.");
            oSoCt.focus();
            return false ;
        }
        if (oNgayCt.value == "")
        {
            alert("Bạn chưa nhập ngày chứng từ. Vui lòng kiểm tra lại.");
            oNgayCt.focus();
            return false;
        }
        
        if (oKho.value == "" || oKho.value == "0")
        {
            alert("Bạn chưa chọn kho nhập. Vui lòng kiểm tra lại.");
            oKho.focus();
            return false;
        }       
        
        if (oNCC.value == "" || oNCC.value == "0")
        {
            alert("Bạn chưa chọn nhà cung cấp. Vui lòng kiểm tra lại.");
            oNCC.focus();
            return false;
        } 
        return true;
    }
    
    function CheckThongTinCTPhieuNhap(omavt,osoluong,odongia, olosx, ongayhethan)
    {
        if (omavt.value == "0")
        {
            alert("Bạn chưa nhập tên thuốc. Vui lòng kiểm tra lại.");
            omavt.focus();
            return;
        }
        
        if (osoluong.value == "0")
        {
            alert("Bạn chưa nhập số lượng nhập. Vui lòng kiểm tra lại.");
            osoluong.focus();
            return;
        }
        
        if (odongia.value == "0")
        {
            alert("Bạn chưa nhập đơn giá nhập. Vui lòng kiểm tra lại.");
            odongia.focus();
            return;
        }
        if (olosx.value == "")
        {
            alert("Bạn chưa nhập lô sản xuất thuốc. Vui lòng kiểm tra lại.");
            olosx.focus();
            return;
        }
        if (ongayhethan.value == "")
        {
            alert("Bạn chưa nhập ngày hết hạn sử dụng thuốc. Vui lòng kiểm tra lại.");
            ongayhethan.focus();
            return;
        }
        return true;
    }
    function LuuPhieuNhap(oSoCt, oNgayCt, oKho, oDienGiai, oNCC, oNgayHoaDon, oTenNguoiGiao, oNhapCho, omavt, osoluong, odongia, olosx, ongayhethan)
    {
        //alert(oSoCt+ " " + oNgayCt+ " " + oKho+ " " + oDienGiai+ " " + oNCC+ " " + oNgayHoaDon+ " " + oTenNguoiGiao+ " " + omavt+ " " + osoluong+ " " + odongia+ " " + olosx+ " " + ongayhethan);
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if (value == "0")
                {
                    alert("Số phiếu nhập đã tồn tại. Vui lòng chọn số phiếu nhập khác.")
                    return;
                }
                if (value == "1")
                {
                    alert("Có lỗi trong quá trình lưu dữ liệu . Vui lòng kiểm tra lại thông tin nhập vào.")
                    return;
                }
                if (value == "2")
                {
                    var opxid = document.getElementById("txtpxid"); 
                    opxid.value = "1";
                    var omavt = document.getElementById("txtSearTP"); 
                    var osoluong = document.getElementById("txtSoLuong"); 
                    var odongia = document.getElementById("txtDonGia");
                    osoluong.value = "0";
                    odongia.value = "0";
                    omavt.value = "";
                    omavt.focus();
                    LoadChiTietPhieuNhap();                    
                }
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=luuphieunhap&soct="+oSoCt+"&ngayct="+oNgayCt+"&kho="+oKho+"&diengiai="+encodeURIComponent(oDienGiai)+"&nccid="+oNCC+"&ngayhoadon="+oNgayHoaDon+"&tennguoigiao="+encodeURIComponent(oTenNguoiGiao)+"&nhapcho="+oNhapCho+"&mavt="+omavt+"&soluong="+osoluong+"&dongia="+odongia+"&losx="+olosx+"&ngayhethan="+ongayhethan+"&times="+Math.random(),true);
        //xmlHttp.open("GET","ajax.aspx?do=luuphieunhap&soct="+oSoCt+"&ngayct="+oNgayCt+"&kho="+oKho+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    function LuuChiTietPhieuNhap(omavt,osoluong,odongia, olosx, ongayhethan)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                                
                if (value == "1")
                {
                    alert("Có lỗi trong quá trình lưu dữ liệu . Vui lòng kiểm tra lại thông tin nhập vào.")
                    return;
                }
                if (value == "2")
                {
                    var opxid = document.getElementById("txtpxid");                     
                    opxid.value = "1";
                    var omavt = document.getElementById("txtSearTP"); 
                    var osoluong = document.getElementById("txtSoLuong"); 
                    var odongia = document.getElementById("txtDonGia");
                    osoluong.value = "0";
                    odongia.value = "0";
                    omavt.value = "";
                    omavt.focus();
                    LoadChiTietPhieuNhap();                    
                }
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=luuctphieunhap&mavt="+omavt+"&soluong="+osoluong+"&dongia="+odongia+"&losx="+olosx+"&ngayhethan="+ongayhethan+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    function LoadChiTietPhieuNhap()
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Có lỗi trong quá trình truyền dữ liệu.");
                }
                else
                {
                    obj.innerHTML = value;                
                }
                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loaddanhsachchitietphieunhap&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    function suaitemchitiet(objmactp)
    {
        var omavt = document.getElementById("ddlVatTu_" + objmactp);
        var odongia = document.getElementById("txtdongia_" + objmactp); 
        var osoluong = document.getElementById("txtsoluong_" + objmactp);
        var olosx = document.getElementById("txtlosx_" + objmactp);
        var ongayhethan = document.getElementById("txtngayhethan_" + objmactp);
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Cập nhật không thành công. Vui lòng kiểm tra lại.");
                }
                else
                {
                    obj.innerHTML = value;    
                    alert("Cập nhật thành công.");            
                }
                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loadedititemphieunhap&mactp="+objmactp+"&mavt="+omavt.value+"&soluong="+osoluong.value+"&dongia="+odongia.value+"&losx="+olosx.value+"&ngayhethan="+ongayhethan.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    
    function xoaitemchitiet(objmactp)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Xóa không thành công. Vui lòng kiểm tra lại.");
                }
                else
                {
                    obj.innerHTML = value;    
                    alert("Đã xóa dữ liệu thành công.");            
                }
                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loaddeleteitemphieunhap&mactp="+objmactp+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    
    function CheckNew()
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if (value == "1")
                {
                    ResetSession();
                    document.location.href = "phieunhapthuoc.aspx";
                }                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=checknew&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    //=============== them moi ================
    function QuayVe()
    {
        document.location.href = "index.aspx";
    }
    
    function LoadThanhPhamChange(sSrc,imactp)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("list_" + imactp); 
                obj.innerHTML = value;                
                var objvt = document.getElementById("ddlVatTu_" + imactp); 
                objvt.focus();
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loadchangethanhphamitem&strSear="+myEscape(sSrc)+"&idmactp="+imactp+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
//************************************* Ket thuc phan xu ly nhap thuoc ***********/    

//==================Bat dau xu ly phan phieu xuat kho==================================

	function CheckTrungChungTuPX(sngaythang,soct,objct,obj)
	{
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if (value == "1")
                {
                    alert("Chứng từ này đã tồn tại rồi. Vui lòng kiểm tra lại.");
                    objct.focus();
                }
                if (value == "2")
                {
                    alert("Ngày tháng chứng từ không hợp lệ. Vui lòng kiểm tra lại.");
                    obj.focus();
                }
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=checktrungphieuxuat&soct="+soct+"&ngaythang="+sngaythang+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	
    function DoActionPhieuXuat(e)      //function DoActionPhieuXuat(e)
    {
		var keycode = 9;    
        var opxid = document.getElementById("txtpxid");         
        if(keycode == 13)
        {
            if (opxid.value == "-1")
            {
                var oSoCt = document.getElementById("txtSoCT"); 
                var oNgayCt = document.getElementById("txtNgayCT"); 
                var oDienGiai = document.getElementById("txtDienGiai");
                var oKho = document.getElementById("ddlKho"); 
                var oBophan = document.getElementById("ddlbophan"); 
                var oNguoinhan = document.getElementById("txtnguoinhan"); 
                var oXuatcho = document.getElementById("ddlnhapcho"); 
                var omavt = document.getElementById("ddlVatTu"); 
                var osoluong = document.getElementById("txtSoLuong");                 
            }
            else
            {
                var omavt = document.getElementById("ddlVatTu"); 
                var osoluong = document.getElementById("txtSoLuong");                 
            } 
        
            if (opxid.value == "-1") // da them moi thanh cong 1 phieu Xuat
            {
                if (CheckThongTinPhieuXuat(oSoCt, oNgayCt, oDienGiai, oKho, oBophan, oNguoinhan, oXuatcho) && CheckThongTinCTPhieuXuat(omavt,osoluong))
                {
                    LuuPhieuXuat(oSoCt.value, oNgayCt.value, oDienGiai.value, oKho.value, oBophan.value, oNguoinhan.value, oXuatcho.value, omavt.value, osoluong.value);
                }
            }
            else
            {
               if( CheckThongTinCTPhieuXuat(omavt,osoluong))
               {
                     LuuChiTietPhieuXuat(omavt.value, osoluong.value);
                    
               }
            }       
            var obj = new Object();
            obj = window.showModalDialog("popupcomfireXuat.aspx?times="+Math.random(),"","DialogWidth:250px;DialogHeight:150px;dialogTop:120px;dialogLeft:700px;overflow:hidden;");  
            CheckNewPX();            
        }
        if(keycode == 9) // Phim Tab
        {
            
            if (opxid.value == "-1")
            {
                var oSoCt = document.getElementById("txtSoCT"); 
                var oNgayCt = document.getElementById("txtNgayCT"); 
                var oDienGiai = document.getElementById("txtDienGiai"); 
                var oKho = document.getElementById("ddlKho"); 
                var oBophan = document.getElementById("ddlbophan"); 
                var oNguoinhan = document.getElementById("txtnguoinhan"); 
                var oXuatcho = document.getElementById("ddlKho"); 
                var omavt = document.getElementById("ddlVatTu"); 
                var osoluong = document.getElementById("txtSoLuong"); 
            }
            else
            {
                var omavt = document.getElementById("ddlVatTu"); 
                var osoluong = document.getElementById("txtSoLuong");                 
            }            
            
            if (opxid.value == "-1") // da them moi thanh cong 1 phieu Xuat
            {
                if ( CheckThongTinPhieuXuat(oSoCt, oNgayCt, oDienGiai, oKho, oBophan, oNguoinhan, oXuatcho) && CheckThongTinCTPhieuXuat(omavt,osoluong))
                {
                    LuuPhieuXuat(oSoCt.value, oNgayCt.value, oDienGiai.value, oKho.value, oBophan.value, oNguoinhan.value, oXuatcho.value, omavt.value,osoluong.value);
                }
            }
            else
            {
               if( CheckThongTinCTPhieuXuat(omavt,osoluong))
               {
                     LuuChiTietPhieuXuat(omavt.value,osoluong.value);
                    
               }
            }
	    }  
	    return;
    }
    
        
    function CheckThongTinPhieuXuat(oSoCt, oNgayCt, oDienGiai, oKho, oBophan, oNguoinhan, oXuatcho)
    {
        if (oSoCt.value == "")
        {
            alert("Bạn chưa nhập số chứng từ. Vui lòng kiểm tra lại.");
            oSoCt.focus();
            return false ;
        }
        if (oNgayCt.value == "")
        {
            alert("Bạn chưa nhập ngày chứng từ. Vui lòng kiểm tra lại.");
            oNgayCt.focus();
            return false;
        }
        if (oKho.value == "")
        {
            alert("Bạn chưa chọn xuất từ kho nào. Vui lòng kiểm tra lại.");
            oKho.focus();
            return false;
        }
        if (oBophan.value == "0")
        {
            alert("Bạn chưa chọn nơi xuất đến. Vui lòng kiểm tra lại.");
            oBophan.focus();
            return false;
        }
        if (oNguoinhan.value == "")
        {
            alert("Bạn chưa chọn người nhận thuốc. Vui lòng kiểm tra lại.");
            oNguoinhan.focus();
            return false;
        }
        
        
        return true;
    }
    
    function CheckThongTinCTPhieuXuat(omavt,osoluong)
    {
        if (omavt.value == "0")
        {
            alert("Bạn chưa nhập tên thuốc. Vui lòng kiểm tra lại.");
            omavt.focus();
            return;
        }
        if (osoluong.value == "0")
        {
            alert("Bạn chưa nhập số lượng xuất. Vui lòng kiểm tra lại.");
            osoluong.focus();
            return;
        }        
        return true;
    }
    function LuuPhieuXuat(oSoCt, oNgayCt, oDienGiai, oKho, oBophan, oNguoinhan, oXuatcho, omavt, osoluong)
    {
        //alert(oSoCt + " " + oNgayCt + " " + oDienGiai + " " + oKho + " " + oBophan + " " + oNguoinhan + " " + oXuatcho + " " + omavt + " " + osoluong);
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;                             
                if (value == "0")
                {
                    alert("Số phiếu xuất này đã tồn tại. Vui lòng chọn số phiếu khác.")
                    return;
                }
                if (value == "1")
                {
                    alert("Có lỗi trong quá trình lưu dữ liệu . Vui lòng kiểm tra lại thông tin nhập vào.")
                    return;
                }
                if (value == "2")
                {
                    var opxid = document.getElementById("txtpxid"); 
                    opxid.value = "1";
                    var omavt = document.getElementById("txtSearTP"); 
                    var osoluong = document.getElementById("txtSoLuong"); 
                    var odongia = document.getElementById("txtDonGia");
                    osoluong.value = "0";
                    odongia.value = "0";
                    omavt.value = "";
                    omavt.focus();
                    LoadChiTietPhieuXuat();                    
                }
                if (value == "3")
                {
                    alert("Có lỗi trong quá trình lưu dữ liệu, bởi vì số lượng tồn của thuốc không đủ để xuất.")
                    return;
                }
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=luuphieuxuat&soct="+oSoCt+"&ngayct="+oNgayCt+"&diengiai="+encodeURIComponent(oDienGiai)+"&kho=" + oKho + "&bophan=" + oBophan + "&nguoinhan=" + encodeURIComponent(oNguoinhan) + "&loaixuat=" + oXuatcho +"&mavt="+omavt+"&soluong="+osoluong+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    function LuuChiTietPhieuXuat(omavt,osoluong)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                                
                if (value == "1")
                {
                    alert("Có lỗi trong quá trình lưu dữ liệu . Vui lòng kiểm tra lại thông tin nhập vào.")
                    return;
                }
                if (value == "2")
                {
                    var opxid = document.getElementById("txtpxid");                     
                    opxid.value = "1";
                    var omavt = document.getElementById("txtSearTP"); 
                    var osoluong = document.getElementById("txtSoLuong"); 
                    var odongia = document.getElementById("txtDonGia");
                    osoluong.value = "0";
                    odongia.value = "0";
                    omavt.value = "";
                    omavt.focus();
                    LoadChiTietPhieuXuat();                    
                }
                if (value == "3")
                {
                    alert("Có lỗi trong quá trình lưu dữ liệu, bởi vì số lượng tồn của thuốc không đủ để xuất.")
                    return;
                }
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=luuctphieuxuat&mavt="+omavt+"&soluong="+osoluong+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
	
    function LoadChiTietPhieuXuat()
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Có lỗi trong quá trình truyền dữ liệu.");
                }
                else
                {
                    obj.innerHTML = value;                
                }
                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loaddanhsachchitietphieuxuat&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    function suaitemchitietpx(objmactp)
    {
        var omavt = document.getElementById("ddlVatTu_" + objmactp);
        var odongia = document.getElementById("txtdongia_" + objmactp); 
        var osoluong = document.getElementById("txtsoluong_" + objmactp);
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Cập nhật không thành công. Vui lòng kiểm tra lại.");
                }
                else
                {
                    obj.innerHTML = value;    
                    alert("Cập nhật thành công.");            
                }
                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loadedititemphieuxuat&mactp="+objmactp+"&mavt="+omavt.value+"&soluong="+osoluong.value+"&dongia="+odongia.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    
    function xoaitemchitietpx(objmactp)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Xóa không thành công. Vui lòng kiểm tra lại.");
                }
                else
                {
                    obj.innerHTML = value;    
                    alert("Đã xóa dữ liệu thành công.");            
                }
                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loaddeleteitemphieuxuat&mactp="+objmactp+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
	
	function CheckNewPX()
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if (value == "1")
                {
                    ResetSession();
                    document.location.href = "phieuxuatthuoc.aspx";
                }                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=checknewpx&times="+Math.random(),true);
        xmlHttp.send(null);
    }
//************************************* Ket thuc phan xu ly Xuat thuoc ***********/    

//================================== Bat dau xu ly toa thuoc
    function DoActionToaThuoc()
    {
        
		var keycode = 9;    
        var opxid = document.getElementById("txtpxid");         
        var loai = document.getElementById("txtloaitoathuoc");
        
        if(keycode == 13)
        {
            if (opxid.value == "-1")
            {
                var oSoCt = document.getElementById("txtSoCT"); 
                var oNgayCt = document.getElementById("txtNgayCT"); 
                var oDienGiai = document.getElementById("txtDienGiai"); 
				var oDiaChi = document.getElementById("txtDiaChi"); 
                var omavt = document.getElementById("ddlVatTu"); 
                var osoluong = document.getElementById("txtSoLuong"); 
                var odongia = document.getElementById("txtDonGia");
            }
            else
            {
                var omavt = document.getElementById("ddlVatTu"); 
                var osoluong = document.getElementById("txtSoLuong"); 
                var odongia = document.getElementById("txtDonGia");
            } 
        
            if (opxid.value == "-1") // da them moi thanh cong 1 phieu Xuat
            {
                if (CheckThongTinToaThuoc(oSoCt, oNgayCt, oDienGiai, oDiaChi) && CheckThongTinCTToaThuoc(omavt,osoluong,odongia))
                {
                    LuuToaThuoc(oSoCt.value, oNgayCt.value, oDienGiai.value, oDiaChi.value, omavt.value, osoluong.value, odongia.value, loai.value);
                }
            }
            else
            {
               if( CheckThongTinCTToaThuoc(omavt,osoluong,odongia))
               {
                     LuuChiTietToaThuoc(omavt.value, osoluong.value, odongia.value);
                    
               }
            }       
            var obj = new Object();
            obj = window.showModalDialog("popupcomfireXuat.aspx?times="+Math.random(),"","DialogWidth:250px;DialogHeight:150px;dialogTop:120px;dialogLeft:700px;overflow:hidden;");  
            CheckNewToaThuoc();            
        }
        if(keycode == 9) // Phim Tab
        {
            if (opxid.value == "-1")
            {
                var oSoCt = document.getElementById("txtSoCT"); 
                var oNgayCt = document.getElementById("txtNgayCT"); 
                //=====================
                var ochandoan = document.getElementById("txtchandoan"); 
                var odando = document.getElementById("txtdando"); 
                var ongayhen = document.getElementById("txtngayhen");
                //===============================
                var omavt = document.getElementById("ddlVatTu"); 
                var ongaydung = document.getElementById("txtngaydung"); 
                var omoilan = document.getElementById("txtmoilan"); 
                
                var osoluong = document.getElementById("txtSoLuong"); 
                var odongia = document.getElementById("txtDonGia");
            }
            else
            {
                var omavt = document.getElementById("ddlVatTu"); 
                var ongaydung = document.getElementById("txtngaydung"); 
                var omoilan = document.getElementById("txtmoilan"); 
                var osoluong = document.getElementById("txtSoLuong"); 
                var odongia = document.getElementById("txtDonGia");
            }            
            
            if (opxid.value == "-1") // da them moi thanh cong 1 phieu Xuat
            {
                if ( CheckThongTinToaThuoc(oSoCt, oNgayCt, ochandoan, odando, ongayhen) && CheckThongTinCTToaThuoc(omavt,ongaydung, omoilan,osoluong,odongia))
                {
                    LuuToaThuoc(oSoCt.value, oNgayCt.value, ochandoan.value, odando.value, ongayhen.value, omavt.value,ongaydung.value, omoilan.value, osoluong.value,odongia.value, loai.value);
                }
            }
            else
            {
               if( CheckThongTinCTToaThuoc(omavt, ongaydung, omoilan,osoluong,odongia))
               {
                     LuuChiTietToaThuoc(omavt.value, ongaydung.value, omoilan.value,osoluong.value,odongia.value);
                    
               }
            }
	    }  
	    return;
    }
    
        
    function CheckThongTinToaThuoc(oSoCt, oNgayCt, oChanDoan, oDanDo, oNgayHen)
    {
        if (oSoCt.value == "")
        {
            alert("Bạn chưa nhập số chứng từ. Vui lòng kiểm tra lại.");
            oSoCt.focus();
            return false ;
        }
        if (oNgayCt.value == "")
        {
            alert("Bạn chưa nhập ngày chứng từ. Vui lòng kiểm tra lại.");
            oNgayCt.focus();
            return false;
        }
		
//		if (oChanDoan.value == "")
//        {
//            alert("Bạn chưa nhập phần chẩn đoán bệnh. Vui lòng kiểm tra lại.");
//            oChanDoan.focus();
//            return false;
//        }
////        if (oNgayHen.value == "")
////        {
////            alert("Bạn chưa nhập ngày hẹn tái khám. Vui lòng kiểm tra lại.");
////            oNgayHen.focus();
////            return false;
////        }
        return true;
    }
    
    function CheckThongTinCTToaThuoc(omavt, ongaydung, omoilan ,osoluong,odongia)
    {
        if (omavt.value == "0")
        {
            alert("Bạn chưa nhập tên thuốc. Vui lòng kiểm tra lại.");
            omavt.focus();
            return;
        }
        if (ongaydung.value == "0")
        {
            alert("Bạn chưa nhập thông tin cho phần ngày dùng. Vui lòng kiểm tra lại.");
            ongaydung.focus();
            return;
        }
        if (omoilan.value == "0")
        {
            alert("Bạn chưa nhập thông tin cho phần mỗi lần dùng. Vui lòng kiểm tra lại.");
            omoilan.focus();
            return;
        }
        
        if (osoluong.value == "0")
        {
            alert("Bạn chưa nhập số lượng nhập. Vui lòng kiểm tra lại.");
            osoluong.focus();
            return;
        }
        
        if (odongia.value == "0")
        {
            alert("Bạn chưa đơn giá nhập. Vui lòng kiểm tra lại.");
            odongia.focus();
            return;
        }
        return true;
    }
    function LuuToaThuoc(oSoCt, oNgayCt, oChanDoan, oLoiDan, oNgayHen, omavt, ongaydung, omoilan, osoluong, odongia, loai)
    {
        //alert(oSoCt +oNgayCt+oDienGiai+oNamsinh+oGioitinh+oDiaChi + oSoBhyt + oChanDoan + oLoiDan+omavt+ongaydung+omoilan+osoluong+odongia + loai);
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if (eval(value) == 0)
                {
                    alert("Số toa thuốc này đã tồn tại. Vui lòng chọn số toa thuốc khác.")
                    return;
                }
                if (eval(value) == 1)
                {
                    alert("Có lỗi trong quá trình lưu dữ liệu . Vui lòng kiểm tra lại thông tin nhập vào.")
                    return;
                }
                if (eval(value) == 2)
                {
                    var opxid = document.getElementById("txtpxid");
                    opxid.value = "1";
                    var omavt = document.getElementById("txtSearTP"); 
                    var osoluong = document.getElementById("txtSoLuong"); 
                    var odongia = document.getElementById("txtDonGia");
                    osoluong.value = "0";
                    odongia.value = "0";
                    omavt.value = "";
                    omavt.focus();
                    LoadChiTietToaThuoc();                    
                }
                if (eval(value) == 3)
                {
                    alert("Có lỗi trong quá trình lưu dữ liệu, bởi vì số lượng tồn của thuốc không đủ để xuất.")
                    return;
                }
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=luutoathuoc&soct="+oSoCt+"&ngayct="+oNgayCt+"&chandoan="+encodeURIComponent(oChanDoan)+"&dando="+encodeURIComponent(oLoiDan)+"&ngaytaikham="+oNgayHen+"&mavt="+omavt+"&ngaydung="+ongaydung+"&moilan="+omoilan+"&soluong="+osoluong+"&dongia="+odongia+"&loai="+loai+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    function LuuChiTietToaThuoc(omavt,ongaydung, omoilan,osoluong,odongia)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                                
                if (eval(value) == 1)
                {
                    alert("Có lỗi trong quá trình lưu dữ liệu . Vui lòng kiểm tra lại thông tin nhập vào.")
                    return;
                }
                if (eval(value) == 3)
                {
                    alert("Không đủ số lượng thuốc để xuất bán. Vui lòng kiểm tra lại thông tin nhập vào.")
                    return;
                }
                if (eval(value) == 2)
                {
                    var opxid = document.getElementById("txtpxid");                     
                    opxid.value = "1";
                    var omavt = document.getElementById("txtSearTP"); 
                    var osoluong = document.getElementById("txtSoLuong"); 
                    var odongia = document.getElementById("txtDonGia");
                    osoluong.value = "0";
                    odongia.value = "0";
                    omavt.value = "";
                    omavt.focus();
                    LoadChiTietToaThuoc();                    
                }
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=luucttoathuoc&mavt="+omavt+"&ngaydung="+ongaydung+"&moilan="+omoilan+"&soluong="+osoluong+"&dongia="+odongia+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
	
    function LoadChiTietToaThuoc()
    {
        
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Có lỗi trong quá trình truyền dữ liệu.");
                }
                else
                {
                    obj.innerHTML = value;                
                }
                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loaddanhsachchitiettoathuoc&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    function suaitemchitiettt(objmactp)
    {
        var omavt = document.getElementById("ddlVatTu_" + objmactp);
        var odongia = document.getElementById("txtdongia_" + objmactp); 
        var osoluong = document.getElementById("txtsoluong_" + objmactp);
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Cập nhật không thành công. Vui lòng kiểm tra lại.");
                }
                else
                {
                    obj.innerHTML = value;    
                    alert("Cập nhật thành công.");            
                }
                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loadedititemtoathuoc&mactp="+objmactp+"&mavt="+omavt.value+"&soluong="+osoluong.value+"&dongia="+odongia.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    
    function xoaitemchitiettt(objmactp)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Xóa không thành công. Vui lòng kiểm tra lại.");
                }
                else
                {
                    obj.innerHTML = value;    
                    alert("Đã xóa dữ liệu thành công.");            
                }
                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loaddeleteitemtoathuoc&mactp="+objmactp+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
	
	function CheckTrungCongHieu()
    {
        var objthuoc = document.getElementById("ddlVatTu");
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if (eval(value) == 1)                        
                    alert("Thuốc này có công hiệu trùng với thuốc đã chọn trước đó.");
                LoadDonGiaBanThuoc(objthuoc.value);
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=checktrungconghieuthuoc&idthuoc="+objthuoc.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
	
	function LoadDonGiaBanThuoc(idthuoc)
	{
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("txtDonGia");  
                obj.value = eval(value);
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=getdongiaban&mathuoc=" + idthuoc + "&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	function CheckNewToaThuoc()
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if (value == "1")
                {
                    ResetSession();
                    document.location.href = "toathuocentry.aspx";
                }                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=checknewtt&times="+Math.random(),true);
        xmlHttp.send(null);
    }
//************************************* Ket thuc phan xu ly toa thuoc ***********/  

function DocSo(val)  
{
    var obj = document.getElementById("txtFormatSo");  
    obj.value = formatCurrency(val);
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            var obj = document.getElementById("txtBangChu");  
            obj.value = value;       
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=docso&val=" + val + "&times="+Math.random(),true);
    xmlHttp.send(null);
}

function OpenPhieuThu()
{
    var obj1 = document.getElementById("txtMaBenhNhan");  
    var obj2 = document.getElementById("txtTenBenhNhan");  
    var obj3 = document.getElementById("txtDiaChi");  
    var obj4 = document.getElementById("txtSoTienThu");  
    var obj5 = document.getElementById("txtNoiDungThu");  
    var obj6 = document.getElementById("txtNgayThu"); 
    var obj = new Object();
        obj = window.showModalDialog("rptInPhieuThu.aspx?mabn="+obj1.value+"&tenbn="+myEscape(obj2.value)+"&diachi="+myEscape(obj3.value)+"&sotien="+obj4.value+"&noidung="+myEscape(obj5.value)+"&ngaythu="+obj6.value+"&times="+Math.random(),"","DialogWidth:800px;DialogHeight:500px;overflow:hidden;");
    window.Open("");
}

function InPhieuThuNhapKham(maphieuthu)
{
    var obj = new Object();
        obj = window.showModalDialog("rptInPhieuThuNhapKham.aspx?maphieu="+maphieuthu+"&times="+Math.random(),"","DialogWidth:800px;DialogHeight:500px;overflow:hidden;");
    window.Open("");
}

function InPhieuThuKhamBenh(maphieuthu)
{
    var obj = new Object();
        obj = window.showModalDialog("rptInPhieuThuKhamBenh.aspx?maphieu="+maphieuthu+"&times="+Math.random(),"","DialogWidth:800px;DialogHeight:500px;overflow:hidden;");
    window.Open("");
}

//Lap toa thuoc cho benh nhan
function TaoToaThuoc(mabenhnhanphongkham)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            if (eval(value) == 1)
            {     
                var obj = new Object();
                obj = window.showModalDialog("toathuocbenhnhanentry.aspx?mabenhnhanphongkham="+mabenhnhanphongkham+"&times="+Math.random(),"","DialogWidth:850;DialogHeight:400;overflow:auto;");
                window.Open("");
            }
            else
            {
                alert("Bạn không có quyền sử dụng chức năng này. Vui lòng kiểm tra lại.");
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=checkpermission&idbenhnhanphongkhambenh=" + mabenhnhanphongkham + "&times="+Math.random(),true);
    xmlHttp.send(null);
}

//In phieu thu tien kham benh
function OpenPhieuThuKhamBenh(mabenhnhanphongkham)
{
    var obj = new Object();
        obj = window.showModalDialog("rptInPhieuThuKhamBenh.aspx?mabenhnhanphongkham="+mabenhnhanphongkham+"&times="+Math.random(),"","DialogWidth:800px;DialogHeight:500px;overflow:hidden;");
    window.Open("");
}

function ShowChiDinh(macanlamsan)
{
    var obj1 = document.getElementById("chk_" + macanlamsan);  
    var obj2 = document.getElementById("canlamsan_" + macanlamsan);  
    
    if (obj1.checked)
    {
        obj2.style.display = '';
    }
    else
        obj2.style.display = "none";
}

//Tham benh
function CheckInfoThamBenh()
{
    var check = document.getElementsByTagName("input");
    var sKeyLamSan = "";
    var sNoidungchidinh = "";
    for(var i = 0; i < check.length; i++)
    {
        if(check[i].type.toLowerCase() == "checkbox")
        {
            if (check[i].id.toLowerCase().substr(0,4) == "chk_")
            {
                if (check[i].checked)
                { 
                    sKeyLamSan = sKeyLamSan  + check[i].value + ",";
                    var objV = document.getElementById("txtVungchidinh_" + check[i].value);
                    sNoidungchidinh = sNoidungchidinh + objV.value + "^"; // + "?" + check[i].value + "^";
                }
            }   
        }        
    }    
    var ikq = 1;
    var cls = document.getElementById("KeyCanLamSan");
    cls.value = sKeyLamSan;
    var ndcls = document.getElementById("noidungchidinh");
    ndcls.value = sNoidungchidinh;
    //Check  value 
    var sdo = document.getElementById("action");
    var idbacsi = document.getElementById("ddlBacSi");
    if (idbacsi.value == "0")
    {
        alert("Bạn chưa chọn bác sĩ khám bệnh. Vui lòng kiểm tra lại.");
        sdo.value = "";
        ikq = 0;
        idbacsi.focus();
        return;
    }
    var chidinh = document.getElementById("txtChiDinhBacSi");
    if (chidinh.value == "")
    {
        alert("Bạn chưa nhập phần chỉ định của bác sĩ khám bệnh. Vui lòng kiểm tra lại.");
        sdo.value = "";
        ikq = 0;
        chidinh.focus();
        return;
    }
    
    if (ikq == 1)
    {
        sdo.value = "Y";
        var frm = document.frmThamBenh;
        frm.Submit();    
    }    
}
    
//Thu tien can lam san
function CheckInfoThuTienCanLamSan()
{
    var action = document.getElementById("txtaction");
    var ngaythu = document.getElementById("txtngayphieu");
    if (ngaythu.value == "")
    {
        alert("Bạn chưa nhập ngày thu tiền. Vui lòng kiểm tra lại.")
        ngaythu.focus();
        action.value = "";
        return false;
    }
    var benhnhan = document.getElementById("ddlbenhnhan");
    if (benhnhan.value == "0" || benhnhan.value == "")
    {
        alert("Bạn chưa nhập tên người nộp tiền. Vui lòng kiểm tra lại.")
        benhnhan.focus();
        action.value = "";
        return false;
    }
    var sKeyCLS = document.getElementById("sKeyCLS");
    if (sKeyCLS.value == "")
    {
        alert("Bạn chưa chọn hình thức thu cho cận lâm sàng nào. Vui lòng kiểm tra lại.")
        benhnhan.focus();
        action.value = "";
        return false;
    }
    var sotien = document.getElementById("txtThanhTien");
    if (sotien.value == "0" || sotien.value == "")
    {
        alert("Bạn chưa nhập số tiền cần thu. Vui lòng kiểm tra lại.")
        sotien.focus();
        action.value = "";
        return false;
    }
    var bacsi = document.getElementById("ddlbacsi");
    if (bacsi.value == "0" || bacsi.value == "")
    {
        alert("Bạn chưa nhập tên bác sĩ chỉ định thu. Vui lòng kiểm tra lại.")
        bacsi.focus();
        action.value = "";
        return false;
    }
    var frm = document.frmThuTienCLS;
    action.value = "Y";
    frm.Submit();    
}

//In phieu thu can lam san

function InPhieuThuCanLamSan(mathutien)
{
    var action = document.getElementById("txtaction");
    action.value = "";
    var obj = new Object();
        obj = window.showModalDialog("rptInPhieuThuKhamBenh.aspx?maphieu="+mathutien+"&times="+Math.random(),"","DialogWidth:800px;DialogHeight:500px;overflow:hidden;");
    window.Open("");
    return;
}

function BackXemKetQua()
{
    history.back();
}

function HoanTatKhamBenh(mabenhnhanphongkham)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            if (eval(value) == 1)
            {     
                if (confirm("Bạn có chắc chắn muốn hoàn tất phiên phám bệnh này không?")==true)
                {
                    xmlHttp = GetMSXmlHttp();
                    xmlHttp.onreadystatechange = function()
                    {
                        if(xmlHttp.readyState == 4)
                        {
                            var value = xmlHttp.responseText;
                            alert("Đã cập nhật thành công.");
                        }
                    }
                    xmlHttp.open("GET","ajax.aspx?do=hoantatkhambenh&mahoso=" + mabenhnhanphongkham + "&times="+Math.random(),true);
                    xmlHttp.send(null);
                }
                else
	                return false;
            }
            else
            {
                alert("Bạn không có quyền sử dụng chức năng này. Vui lòng kiểm tra lại.");
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=checkpermission&idbenhnhanphongkhambenh=" + mabenhnhanphongkham + "&times="+Math.random(),true);
    xmlHttp.send(null);
}

//Can lam sang

function CheckInfoThamBenhCLS()
{
    //Check  value 
    var sdo = document.getElementById("action");
    var ikq = 1;
    var idbacsi = document.getElementById("ddlBacSi");    
    if (idbacsi.value == "0")
    {
        alert("Bạn chưa chọn bác sĩ khám bệnh. Vui lòng kiểm tra lại.");
        sdo.value = "";
        ikq = 0;
        idbacsi.focus();
        return false;
    }
    var chidinh = document.getElementById("txtChiDinhBacSi");
    if (chidinh.value == "")
    {
        alert("Bạn chưa nhập phần chỉ định của bác sĩ khám bệnh. Vui lòng kiểm tra lại.");
        sdo.value = "";
        ikq = 0;
        chidinh.focus();
        return false;
    }
    
    var ketluan = document.getElementById("txtKetLuan");
    if (ketluan.value == "")
    {
        alert("Bạn chưa nhập phần kết luận khám bệnh. Vui lòng kiểm tra lại.");
        sdo.value = "";
        ikq = 0;
        ketluan.focus();
        return false;
    }
    if (ikq == 1) 
    {
        sdo.value = "Y";
        var frm = document.frmThamBenh;
        frm.Submit();   
    }   
    
}

function CanCelAction()
{
    var sdo = document.getElementById("action");
    sdo.value = "C";
    var frm = document.frmThamBenh;
    frm.Submit();   
}

function CancelThamBenh()
{
    var sdo = document.getElementById("action");
    sdo.value = "C";
    var frm = document.frmThamBenh;
    frm.Submit();   
}

//Load thong tin toa thuoc

function LoadThongTinToaThuoc(idbenhnhanphongkham)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            var obj = document.getElementById("toathuocinfo"); 
            obj.innerHTML = value;       
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=loadthongtintoathuoc&mabenhnhanphongkhambenh=" + idbenhnhanphongkham + "&times="+Math.random(),true);
    xmlHttp.send(null);
}

//Get cac item can lam sang duoc chon de thu tien phí

function SetCheckCLS(idphongkhamcls)
{
    var okeycls = document.getElementById("chkcls_" + idphongkhamcls); 
    var sKeyCLS = document.getElementById("sKeyCLS"); 
    if (okeycls.checked)
    {
        if(sKeyCLS.value.indexOf(idphongkhamcls) < 0)
        {
            var sval = sKeyCLS.value;
            sval = sval + idphongkhamcls + ",";
            sKeyCLS.value = sval;
        }
    }
    else
    {
        var sval = sKeyCLS.value;
        var arrval = sval.split(',');
        var i = 0;
        var skq = "";
        for (i = 0; i < arrval.length - 1; i++)
        {
            if (arrval[i] !=  idphongkhamcls)
                skq = skq + arrval[i] + ",";
        }
        sKeyCLS.value = skq;        
    }
}

//In toa thuoc benh nhan do bac si ra toa
function InToaThuocBenhNhan(idbenhnhanphongkhambenh)
{
    var obj = new Object();
        obj = window.showModalDialog("rptintoathuocbenhnhan.aspx?mabenhnhanphongkham="+idbenhnhanphongkhambenh+"&times="+Math.random(),"","DialogWidth:800px;DialogHeight:500px;overflow:hidden;");
    window.Open("");
    return;
}

function LoadDanhMucThuoc()
    {
        var obj = document.getElementById("ddlNhomthuoc");
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                //alert(value);
                var obj = document.getElementById("listthanhpham"); 
                obj.innerHTML = value;                
                SetDongia_();
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loadchangethuoc&strSear="+obj.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    
    function Loadthuoctheohoatchat(sSearch)
    {
        
        if (sSearch != "Chọn hoạt chất...")
        {
            var obj = document.getElementById("ddlNhomthuoc");
            xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                    var obj = document.getElementById("listthanhpham"); 
                    obj.innerHTML = value;                
                    SetDongia_();
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=loadthuoctheohoatchat&strSear=" + encodeURIComponent(sSearch) + "&idnhomthuoc=" + obj.value+"&times="+Math.random(),true);
            xmlHttp.send(null);
        }
    }


//===========================================
/*Thong tin nhà cung cap thuốc - 10/09/2009*/
//===========================================
function savenewnhacungcap()
{
    try
    {
        var mancc = document.getElementsByName("mancc")[0];
        if(!NumAndChar.test(mancc.value))
        {
            alert("Mã nhà cung cấp chỉ cho phép nhập chữ hoặc số . Vui lòng nhập lại");
            mancc.focus();
            return false;
        }
        var tenkho = document.getElementsByName("tenncc")[0];
        if(trim(tenkho.value) == "")
        {
            alert("Tên nhà cung cấp không được để trống . Vui lòng nhập lại ");
            tenkho.focus();
            return false;
        }
        
        var ajax = document.getElementById("ajaxkho");
        ajax.style.display = "";
        loadCheckMaNhaCungCap(mancc.value);
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    } 
}
//===========================================
function loadCheckMaNhaCungCap(mancc)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            value = eval(value);
            var ajax = document.getElementById("ajaxkho");
            if(value == 0)
            {
                alert("Lỗi xảy ra trong quá trình truyền dữ liệu");
                ajax.style.display = "none";
                return false;            
            }
            else if(value == 1)
            {
                alert("Mã nhà cung cấp này đã sử dụng rồi . Vui lòng chọn mã khác");
                ajax.style.display = "none";
                return;
            }
            else if(value == 2)
            {
                var f = document.getElementById("kho");
                var sc = document.getElementById("secondtime");
                sc.value = "newnhacungcap";
                f.submit();
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=checkmanccfromnhacc&mancc="+mancc+"&times="+Math.random(),true);
    xmlHttp.send(null);
}

//===========================================
function loadDanhSachNhaSanXuat(nccid)
{
    try
    {
        var span = document.getElementById("ajaxdanhmuckho");
        span.style.display = "";
        loadChiTietNhaCungCap(nccid);
    }
    catch(exception)
    {
    }
}
//===========================================
function loadChiTietNhaCungCap(nccid)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            var ajax = document.getElementById("ajaxdanhmuckho");
            ajax.style.display = "";
            if(value == "error")
            {
                alert("Lỗi xảy ra trong quá trình truyền dữ liệu");
                return false;            
            }
            else 
            {
                var td = document.getElementById("chitietkho");
                td.innerHTML = value;                
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=loadchitietnhacungcap&nccid="+nccid+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function newNhaCungcap()
{
    try
    {
        var makho = document.getElementsByName("mancc")[0];
        makho.value = "";
        var html = "";
        html += "<input type=\"text\" name=\"mancc\" style=\"width:250px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\"/>";
        html += "&nbsp;(&nbsp;<font color=\"red\">*</font>&nbsp;)&nbsp;là các thông tin bắt buộc";
        makho.parentNode.innerHTML = html;
        var tenkho = document.getElementsByName("tenncc")[0];
        tenkho.value = "";
        var nguoilienhe = document.getElementsByName("tennguoilienhe")[0];
        nguoilienhe.value = "";
        var diachi = document.getElementsByName("diachi")[0];
        diachi.value = "";
        var dienthoai = document.getElementsByName("dienthoai")[0];
        dienthoai.value = "";
        var td = document.getElementById("functionkho");
        html = "<br/>";
        html += "<input type=\"button\" name=\"luu\" onclick=\"savenewnhacungcap()\" value=\"Lưu\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"reset\" name=\"cancel\" value=\"Làm lại\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"deletenhacungcap('checkall')\" style=\"width:80px;\" />&nbsp;&nbsp;";
        html += "<span class=\"ajax\" id=\"ajaxdanhmuckho\" style=\"display:none;\"><img src=\"images/processing.gif\" border=\"0\" />&nbsp;đang load dữ liệu ...</span>";
        td.innerHTML = html;
    }
    catch(exception)
    {
    }
}


//===========================================
function deletenhacungcap(checkname)
{
    var iCount = checkItemChecked(checkname);
    if(iCount == 0)
    {
        alert("Vui lòng chọn ít nhất một hãng sản xuất trước khi xóa ");
        return false;
    }
    else if(confirm("Bạn có chắc muốn xóa những gì bạn chọn không ?"))
    {
        var f = document.kho;
        f.secondtime.value = "deletenhacungcap";
        f.submit();
    }
}
//===========================================
function saveupdatenhacungcap()
{
    try
    {
        var tenkho = document.getElementsByName("tenncc")[0];
        if(trim(tenkho.value) == "")
        {
            alert("Tên nhà cung cấp không được để trống . Vui lòng nhập lại ");
            tenkho.focus();
            return false;
        }
        var f = document.kho;
        f.secondtime.value = "updatenhacungcap";
        f.submit();
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    }   
}

//===========================================
/*Thong tin gruop thuoc 11/09/2009*/
//===========================================
function savenewgroup()
{
    //alert("thuoc");
    try
    {
        var makho = document.getElementsByName("tennhom")[0];
        if(makho.value == "")
        {
            alert("Tên nhóm thuốc không thể bỏ trống . Vui lòng nhập lại");
            makho.focus();
            return false;
        }
        var f = document.getElementById("kho");
        f.secondtime.value = "newnhom";
        f.submit();
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    } 
}
//============================================
//======Group San Pham

//=============================================
//===========================================
function loadDanhSachGroup(groupid)
{
    try
    {
        var span = document.getElementById("ajaxdanhmuckho");
        span.style.display = "";
        loadChiTietGroup(groupid);
    }
    catch(exception)
    {
    }
}
//===========================================
function loadChiTietGroup(gid)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            var ajax = document.getElementById("ajaxdanhmuckho");
            ajax.style.display = "";
            if(value == "error")
            {
                alert("Lỗi xảy ra trong quá trình truyền dữ liệu");
                return false;            
            }
            else 
            {
                var td = document.getElementById("chitietkho");
                td.innerHTML = value;                
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=loadchitietgroup&gid="+gid+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function newGroup()
{
    try
    {
        var makho = document.getElementsByName("makho")[0];
        makho.value = "";
        var html = "";
        html += "<input type=\"text\" name=\"tennhom\" id=\"tennhom\" style=\"width:250px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\"/>";
        html += "&nbsp;(&nbsp;<font color=\"red\">*</font>&nbsp;)&nbsp;là các thông tin bắt buộc";
        makho.parentNode.innerHTML = html;
        var tenkho = document.getElementsByName("mota")[0];
        tenkho.value = "";
        var td = document.getElementById("functionkho");
        html = "<br/>";
        html += "<input type=\"button\" name=\"luu\" onclick=\"savenewgroup()\" value=\"Lưu\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"reset\" name=\"cancel\" value=\"Làm lại\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"deletegroup('checkall')\" style=\"width:80px;\" />&nbsp;&nbsp;";
        html += "<span class=\"ajax\" id=\"ajaxdanhmuckho\" style=\"display:none;\"><img src=\"images/processing.gif\" border=\"0\" />&nbsp;đang load dữ liệu ...</span>";
        td.innerHTML = html;
    }
    catch(exception)
    {
    }
}


//===========================================
function deletegroup(checkname)
{
    var iCount = checkItemChecked(checkname);
    if(iCount == 0)
    {
        alert("Vui lòng chọn ít nhất một nhóm trước khi xóa ");
        return false;
    }
    else if(confirm("Bạn có chắc muốn xóa những gì bạn chọn không ?"))
    {
        var f = document.kho;
        f.secondtime.value = "deletemultinhom";
        f.submit();
    }
}
//===========================================
function saveupdategroup()
{
    try
    {
        var tenkho = document.getElementsByName("tennhom")[0];
        if(trim(tenkho.value) == "")
        {
            alert("Tên nhóm không được để trống . Vui lòng nhập lại ");
            tenkho.focus();
            return false;
        }
        var f = document.kho;
        f.secondtime.value = "updatenhom";
        f.submit();
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    }   
}


//17/09/2009
function LoadDanhMucDichVu()
{
    var onhomdv = document.getElementById("ddlnhomdichvu");
    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText; 
                var obj = document.getElementById("listthanhpham"); 
                obj.innerHTML = value;                
                SetChiPhi();
            }
        }
    xmlHttp.open("GET","ajax.aspx?do=loaddanhsachdichvu&gid="+onhomdv.value+"&times="+Math.random(),true);
    xmlHttp.send(null);
}

function SetChiPhi()
{
    
    var odv = document.getElementById("ddldichvu");    
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            var obj = document.getElementById("txtDonGia");  
            obj.value = eval(value);
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=getchiphidichvu&iddichvu=" + odv.value + "&times="+Math.random(),true);
    xmlHttp.send(null);
}

function DoActionPhieuThanhToan()
    {
		var opxid = document.getElementById("txtpxid");         
        if (opxid.value == "-1")
        {
            var oSoCt = document.getElementById("txtSoCT"); 
            var oNgayCt = document.getElementById("txtNgayCT"); 
            
            var odv = document.getElementById("ddldichvu"); 
            var oykienbs = document.getElementById("txtykienbs");
            var odongia = document.getElementById("txtDonGia");
        }
        else
        {
            var odv = document.getElementById("ddldichvu"); 
            var odongia = document.getElementById("txtDonGia");
            var oykienbs = document.getElementById("txtykienbs");
        }            
        
        if (opxid.value == "-1") // da them moi thanh cong 1 phieu Xuat
        {
            if ( CheckThongTinPhieuThanhToan(oSoCt, oNgayCt) && CheckThongTinCTPhieuThanhToan(odv, oykienbs, odongia))
            {
                LuuPhieuThanhToan(oSoCt.value, oNgayCt.value, odv.value, oykienbs.value, odongia.value);
            }
        }
        else
        {
           if( CheckThongTinCTPhieuThanhToan(odv, oykienbs, odongia))
           {
                 LuuChiTietPhieuThanhToan(odv.value, oykienbs.value, odongia.value);
                
           }
        }
	   
	    return;
    }
    
        
    function CheckThongTinPhieuThanhToan(oSoCt, oNgayCt)
    {
        if (oSoCt.value == "")
        {
            alert("Bạn chưa nhập số chứng từ. Vui lòng kiểm tra lại.");
            oSoCt.focus();
            return false ;
        }
        if (oNgayCt.value == "")
        {
            alert("Bạn chưa nhập ngày chứng từ. Vui lòng kiểm tra lại.");
            oNgayCt.focus();
            return false;
        }
		
        return true;
    }
    
    function CheckThongTinCTPhieuThanhToan(odv, oykienbs, odongia)
    {
        if (odv.value == "0")
        {
            alert("Bạn chưa nhập tên dịch vụ sử dụng. Vui lòng kiểm tra lại.");
            odv.focus();
            return;
        }
        if (oykienbs.value == "")
        {
            alert("Bạn chưa nhập ý kiến bác sĩ. Vui lòng kiểm tra lại.");
            oykienbs.focus();
            return;
        }
        
        if (odongia.value == "0")
        {
            alert("Bạn chưa đơn giá nhập. Vui lòng kiểm tra lại.");
            odongia.focus();
            return;
        }
        return true;
    }
    function LuuPhieuThanhToan(oSoCt, oNgayCt, odv, oykienbs, odongia)
    {
        //alert(oSoCt +oNgayCt+oDienGiai+oNamsinh+oGioitinh+oDiaChi + oSoBhyt + oChanDoan + oLoiDan+omavt+ongaydung+omoilan+osoluong+odongia);
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if (value == "0")
                {
                    alert("Số chứng từ này đã tồn tại. Vui lòng chọn số toa thuốc khác.")
                    return;
                }
                if (value == "1")
                {
                    alert("Có lỗi trong quá trình lưu dữ liệu . Vui lòng kiểm tra lại thông tin nhập vào.")
                    return;
                }
                if (value == "2")
                {
                    var opxid = document.getElementById("txtpxid");
                    opxid.value = "1";
                    var odongia = document.getElementById("txtDonGia");
                    odongia.value = "0";
                    var objdv = document.getElementById("ddldichvu"); 
                    objdv.value = "";
                    objdv.focus();
                    LoadChiTietPhieuThanhToan();                    
                }
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=luuphieuthanhtoan&soct="+oSoCt+"&ngayct="+oNgayCt+"&iddichvu="+odv+"&ykienbs="+encodeURIComponent(oykienbs)+"&dongia="+odongia+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    function LuuChiTietPhieuThanhToan(odv, ykienbs, odongia)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                                
                if (value == "1")
                {
                    alert("Có lỗi trong quá trình lưu dữ liệu . Vui lòng kiểm tra lại thông tin nhập vào.")
                    return;
                }
                if (value == "2")
                {
                    var opxid = document.getElementById("txtpxid");                     
                    opxid.value = "1";
                    var omavt = document.getElementById("ddldichvu"); 
                    var odongia = document.getElementById("txtDonGia");
                    odongia.value = "0";
                    omavt.value = "";
                    omavt.focus();
                    LoadChiTietPhieuThanhToan();                    
                }
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=luuctphieuthanhtoan&iddichvu="+odv+"&ykienbs="+encodeURIComponent(ykienbs)+"&dongia="+odongia+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
	
    function LoadChiTietPhieuThanhToan()
    {
        
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Có lỗi trong quá trình truyền dữ liệu.");
                }
                else
                {
                    obj.innerHTML = value;                
                }
                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loaddanhsachchitietphieuthanhtoan&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    function suaitemchitietptt(objmactp)
    {
        var omavt = document.getElementById("ddldichvu_" + objmactp);
        var oykienbs = document.getElementById("txtykienbs_" + objmactp); 
        var odongia = document.getElementById("txtdongia_" + objmactp);
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Cập nhật không thành công. Vui lòng kiểm tra lại.");
                }
                else
                {
                    obj.innerHTML = value;    
                    alert("Cập nhật thành công.");  
                    LoadChiTietPhieuThanhToan();          
                }
                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loadedititemphieuthanhtoan&mactp="+objmactp+"&mavt="+omavt.value+"&ykienbs="+encodeURIComponent(oykienbs.value)+"&dongia="+odongia.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    
    function xoaitemchitietptt(objmactp)
    {
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var obj = document.getElementById("chitietphieu"); 
                if (value == "0")
                {
                    alert("Xóa không thành công. Vui lòng kiểm tra lại.");
                }
                else
                {
                    obj.innerHTML = value;    
                    alert("Đã xóa dữ liệu thành công."); 
                    LoadChiTietPhieuThanhToan();           
                }
                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=loaddeleteitemphieuthanhtoan&mactp="+objmactp+"&times="+Math.random(),true);
        xmlHttp.send(null);
    }
    
    //28092009 nhom vat tu
    
function savenewnhomvt()
{
    try
    {
        var makho = document.getElementsByName("tennhom")[0];
        if(makho.value == "")
        {
            alert("Tên nhóm vật tư không thể bỏ trống . Vui lòng nhập lại");
            makho.focus();
            return false;
        }
        var f = document.kho;
        f.secondtime.value = "newnhom";
        f.submit();
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    } 
}
//===========================================
function loadDanhSachNhomVT(groupid)
{
    try
    {
        var span = document.getElementById("ajaxdanhmuckho");
        span.style.display = "";
        loadChiTietNhomVT(groupid);
    }
    catch(exception)
    {
    }
}
//===========================================
function loadChiTietNhomVT(gid)
{
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            var ajax = document.getElementById("ajaxdanhmuckho");
            ajax.style.display = "";
            if(value == "error")
            {
                alert("Lỗi xảy ra trong quá trình truyền dữ liệu");
                return false;            
            }
            else 
            {
                var td = document.getElementById("chitietkho");
                td.innerHTML = value;                
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=loadchitietnhomvt&gid="+gid+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
//===========================================
function newNhomVT()
{
    try
    {
        var makho = document.getElementsByName("makho")[0];
        makho.value = "";
        var html = "";
        html += "<input type=\"text\" name=\"tennhom\" id=\"tennhom\" style=\"width:250px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\"/>";
        html += "&nbsp;(&nbsp;<font color=\"red\">*</font>&nbsp;)&nbsp;là các thông tin bắt buộc";
        makho.parentNode.innerHTML = html;
        var tenkho = document.getElementsByName("mota")[0];
        tenkho.value = "";
        var td = document.getElementById("functionkho");
        html = "<br/>";
        html += "<input type=\"button\" name=\"luu\" onclick=\"nhomvt()\" value=\"Lưu\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"reset\" name=\"cancel\" value=\"Làm lại\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"deletenhomvt('checkall')\" style=\"width:80px;\" />&nbsp;&nbsp;";
        html += "<span class=\"ajax\" id=\"ajaxdanhmuckho\" style=\"display:none;\"><img src=\"images/processing.gif\" border=\"0\" />&nbsp;đang load dữ liệu ...</span>";
        td.innerHTML = html;
    }
    catch(exception)
    {
    }
}


//===========================================
function deletenhomvt(checkname)
{
    var iCount = checkItemChecked(checkname);
    if(iCount == 0)
    {
        alert("Vui lòng chọn ít nhất một nhóm trước khi xóa ");
        return false;
    }
    else if(confirm("Bạn có chắc muốn xóa những gì bạn chọn không ?"))
    {
        var f = document.kho;
        f.secondtime.value = "deletemultinhom";
        f.submit();
    }
}
//===========================================
function saveupdatenhomvt()
{
    try
    {
        var tenkho = document.getElementsByName("tennhom")[0];
        if(trim(tenkho.value) == "")
        {
            alert("Tên nhóm không được để trống . Vui lòng nhập lại ");
            tenkho.focus();
            return false;
        }
        var f = document.kho;
        f.secondtime.value = "updatenhom";
        f.submit();
    }
    catch(exception)
    {
        alert("Có lỗi xảy ra . Vui lòng xem lại script ");
        return false;
    }   
}

function InPhieuThongTin()
{
    var hoten = document.getElementsById("txttenBN");
    var namsinh = document.getElementsById("txtbirtday");
    var gioitinh = document.getElementsById("DDlsex");
    var sothebhyt = document.getElementsById("txtsothebh");
    var diachi = document.getElementsById("txtaddress");
    var loaibh = document.getElementsById("DDlloaibaohiem");
    document.location.href = "rptinphieuthongtin.aspx?";
}

function CreateChuyenSoDu(iloaikho)
{
    alert(iloaikho);
    var ajax = document.getElementById("ajaxsodu");
    ajax.style.display = "";
    xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function()
    {
        if(xmlHttp.readyState == 4)
        {
            var value = xmlHttp.responseText;
            
            ajax.style.display = "none";
            
            if(eval(value) == 0)
            {
                alert("Lỗi xảy ra khi kết chuyển số dư . Vui lòng xem lại ");
                return;
            }            
            else 
            {
               alert("Đã kết chuyển số dư thành công sang tháng " + value);
            }
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=chuyensodu&loaikho="+iloaikho+"&times="+Math.random(),true);
    xmlHttp.send(null);
}

function TinhTienThatThuBNTra()
	    {
	        var txtTienKham = document.getElementById("txtTienKham");
	        var txtBnTra = document.getElementById("txtBnTra");
	        var txtThatThu = document.getElementById("txtThatThu");
	        txtTienKham.value=txtTienKham.value.replace(".","").replace(".","").replace(",","").replace(",","");
	        txtBnTra.value=txtBnTra.value.replace(".","").replace(".","").replace(",","").replace(",","");
	        txtThatThu.value=txtThatThu.value.replace(".","").replace(".","").replace(",","").replace(",","");
	        if(eval(txtBnTra.value) >eval(txtTienKham.value) || eval(txtBnTra.value) <0)
	        {
	            txtBnTra.value="0";
	            txtThatThu.value=txtTienKham.value;
	        }
	        else
	        {
	            txtThatThu.value=eval(txtTienKham.value)-eval(txtBnTra.value);
	        }
	    }
	    
function TinhTienThatThuThatThu()
	   {
	        var txtTienKham = document.getElementById("txtTienKham");
	        var txtBnTra = document.getElementById("txtBnTra");
	        var txtThatThu = document.getElementById("txtThatThu");
	        txtTienKham.value=txtTienKham.value.replace(".","").replace(".","").replace(",","").replace(",","");
	        txtBnTra.value=txtBnTra.value.replace(".","").replace(".","").replace(",","").replace(",","");
	        txtThatThu.value=txtThatThu.value.replace(".","").replace(".","").replace(",","").replace(",","");
	        if(eval(txtThatThu.value) >eval(txtTienKham.value) || eval(txtThatThu.value) <0)
	        {
	            txtThatThu.value="0";
	            txtBnTra.value=txtTienKham.value;
	        }
	        else
	        {
	            txtBnTra.value=eval(txtTienKham.value)-eval(txtThatThu.value);
	        }
	    }
	    
function isNumberThatThu(field) 
  {
    var re = /^[0-9-'.'-',']*$/;
    if (!re.test(field.value))
     {
    //alert('Value must be all numberic charcters, including "." or "," non numerics will be removed from field!');
    field.value = field.value.replace(/[^0-9-'.'-',']/g,"");
  }
  }