//JScript File
//=======================Regular expression
var emailReg = /^(\w+[\.|\_]*?\w+@\w{2,15}(\-\w{1,10})?\.(\w{2,8})(\.\w{2,6})*)$/;
var phoneReg = /^(([\+|\-]\s{0,3})?(\(\s{0,3}?\d{2,3}\s{0,3}\)(\s{0,3})?)|((\+|\-)?\s{0,3}?\d{2,3})(\s{0,3})?)?((\d{1,15})|((\d{2,4})[\s|\.]{0,3}?){1,5})$/;
var websiteReg =/^(https?:\/\/)?(\w{3}\.)?[\w+|\d+]+(\-[\w+|\d+]+)?\.\w{2,6}(\.\w{2,6}){0,2}$/;
var notCharSpe = /^([\w+|(\.|\_|\-)|\d+])+$/;
var digitReg = /^[\d+|\s+]+$/;
var passReg = /^[\w+|\d+]+$/;
var dateVN = /^[0-2][0-9](\s{1,3})?(\:|\g|\h)(\s{1,3})?[0-5][0-9](\s{1,3})?[0-3][0-9](\\|\-|\/|\.)(\s{1,3})?[0-1][0-9](\s{1,3})?(\\|\-|\/|\.)\d{4}$/;
var dateVN1 = /^[0-3][0-9](\\|\-|\/|\.)(\s{1,3})?[0-1][0-9](\s{1,3})?(\\|\-|\/|\.)\d{4}$/;
var dateVN2 = /^([0-3][0-9]\/[0-1][0-9]\/[0-9]{4})$/;
var domain2 = /^[\w+|\d+]+(\-[\w+|\d+]+)?$/;
var NumAndChar = /^[\d+|\w+]+$/;
var floatReg = /^(\d+(\.\d+)?)$/;
//==================
function GetMSXmlHttp()
{
	var xmlHttp2 = null;
	if (!window.XMLHttpRequest) {
		var s="";
		var clsids = ["Msxml2.XMLHTTP.6.0","Msxml2.XMLHTTP.5.0",
								"Msxml2.XMLHTTP.4.0","Msxml2.XMLHTTP.3.0", 
								"Msxml2.XMLHTTP.2.6","Microsoft.XMLHTTP.1.0", 
								"Microsoft.XMLHTTP.1","Microsoft.XMLHTTP"];
		for(var i=0; i<clsids.length && xmlHttp2 == null; i++) {
				xmlHttp2 = CreateXmlHttp(clsids[i]);
		}
	}
	else { //Firefox;nextscape/opera
		xmlHttp2 = new XMLHttpRequest();
	}
	return xmlHttp2;
}
//=================
function CreateXmlHttp(clsid) {
	var xmlHttp1 = null;
	try {
			xmlHttp1 = new ActiveXObject(clsid);
			lastclsid = clsid;
			return xmlHttp1;
	}
	catch(e) {}
}
//=====================
//tao dong ho
var str = "";
function createClock()
{
    var clock = window.setInterval('setClock()',1000);
}
//========================
function setClock()
{
    var curDate = new Date();
    str = FormatStringDate(curDate)+ "&nbsp;" + curDate.toLocaleTimeString();
    var clock = document.getElementById("clock");
    clock.innerHTML = str; 
}
//dinh dang lai ngay thang
function FormatStringDate(date)
{
    var str = date.toDateString();
    var longDay = new Array("Monday","Tuesday","Wednesday","Thusday","Friday","Saturday","Sunday");
    var medDay = new Array("Mon","Tue","Wed","Thu","Fr","Sat","Sun");
    var shortDay = new Array("Mo","Tu","We","Th","Fr","Sa","Su");
    var VNDay = new Array("Thứ Hai","Thứ Ba","Thứ Tư","Thứ Năm","Thứ Sáu","Thứ Bảy","Chủ Nhật");
    var longMonth = new Array("January","February","March","April","May","June","July","August","September","October","November","December");
    var medMonth = new Array("Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec");
    var shortMonth = new Array("Ja","Fe","Ma","Ap","Ma","Ju","Jl","Au","Se","Oc","No","De");
    var fulldate = "";
    for(var i = 0; i < longDay.length; i++)
        if(str.toLowerCase().indexOf(longDay[i].toLowerCase()) >= 0 || str.toLowerCase().indexOf(medDay[i].toLowerCase()) >= 0 ||str.toLowerCase().indexOf(shortDay[i].toLowerCase()) >= 0)
        {
            fulldate += VNDay[i];
            break;
        }
    fulldate += "&nbsp;&nbsp;&nbsp;&nbsp;"+date.getDate();        
    for(var i = 0; i < longMonth.length; i++)
    {
        if(str.toLowerCase().indexOf(longMonth[i].toLowerCase()) >= 0 || str.toLowerCase().indexOf(medMonth[i].toLowerCase()) >= 0 ||str.toLowerCase().indexOf(shortMonth[i].toLowerCase()) >= 0)
        {
            fulldate += "&nbsp;.&nbsp;"+ (i+1);
            break;
        }
    }
    fulldate += "&nbsp;.&nbsp;"+date.getFullYear();
    return fulldate;
}
//=======================
function getItemUrl(obj,url)
{
	var str = "";
	var pos = url.indexOf(obj+"=");
	if(pos == -1 ) return str;
	str = url.substring(pos);
	str = str.split('&')[0];
	str = str.split('=')[1];
	return str;
}
//lay chuoi con trong chuoi me
function getValueInStr(obj,signal,str)
{
    //bo chuoi phia truoc vi tri chuoi con 
    var pos = str.indexOf(obj);
    if(pos == -1) return "";
    str = str.substring(pos);
    //bo chuoi phia sau vi tri chuoi con
    pos = str.indexOf(signal);
    str = str.substring(0,pos);
    return str; 
}
//kiem tra file goi vao co file la file hinh ko 
function checkImage(path)
{
    try
    {
        var image = /(\.([j|J][p|P][g|G]|[j|J][p|P][e|E][g|G]|[b|B][m|M][p|P]|[p|P][n|N][g|G]|[g|G][i|I][f|F]|[t|T][i|I][f|F]|[t|T][i|I][f|F][f|F]))$/;
        return image.test(path)?1:0;
    }catch(exception)
    {
        return 0;
    }
}
//slide
var timerID = new Array();
var obj = new Array();
var endHeight = new Array();
var moving = new Array(); 
var dir = new Array();
var tdparent = "";
var tdtopmenu = "";
//=============================
function startslide(objname)
{
	obj[objname] = document.getElementById(objname);
	endHeight[objname] = parseInt(obj[objname].style.height); 
	if(dir[objname] == "down") obj[objname].style.height = 1;
	obj[objname].style.display = "block";
	timerID[objname] = window.setInterval("slidetick('"+objname+"');",10);
}
//=============================
function slidetick(objname)
{
	if(dir[objname]== "down")
	{
		if(parseInt(obj[objname].style.height) < endHeight[objname])
		{
			var height = parseInt(obj[objname].style.height) + 10 ;
			obj[objname].style.height = height + "px";
		}
		else endSlide(objname);
	}
	else if ( dir[objname] == "up")
	{
		if(parseInt(obj[objname].style.height) > 1)
		{
			var height = parseInt(obj[objname].style.height) - 10 ;
			obj[objname].style.height =  height + "px";
		}
		else 
		{
			obj[objname].style.display = "none";
			endSlide(objname);
		}
	}
	return;
}
//================================
function endSlide(objname)
{
	window.clearInterval(timerID[objname]);
	if(dir[objname] == "up") obj[objname].style.display = "none";
	obj[objname].style.height = endHeight[objname] + "px";
	moving[objname] = "";
	timerID[objname] = "";
	endHeight[objname] = "";
	obj[objname] = "";
	dir[objname] = "";
	return;
}
//====================================
 function slidedown(objname)
 {
    if(moving[objname])	return;
    if(document.getElementById(objname).style.display != "none") return;
    moving[objname] = true;
    dir[objname] = "down";
    startslide(objname);
}
//====================================
function slideup(objname)
{
    if(moving[objname])	return;
    if(document.getElementById(objname).style.display == "none") return;
    moving[objname] = true;
    dir[objname] = "up";
    startslide(objname);
}
//=====================
function verifydate2(da,mo,ye) 
{
	if ((da>29 && mo==2) || (da>28 && mo==2 && ye%4 >0) ||(da > 30 &&(mo==4 || mo==6 || mo==9 || mo==11)) || (da=="" && mo !="")|| (mo=="" && ye !="")|| (ye=="" && da !=0)) {
		return false;
	}
	return true;
}
//goi trang url
function redirectURL(url)
{
	window.location.href = url;
}
//cat chuoi
function trim(str) 
{
	while (str.indexOf(" ")>=0) str = str.replace(" ","");
	return str;
}
//escape cac ki tu gay loi
function myEscape(str)
{
    str = str.replace(/\Đ/g,'DD');
    //alert(str);
    str = str.replace(/\đ/g,'dd');
    
    str = str.replace(/\ấ/g,'z61').replace(/\Ấ/g,'Z61').replace(/\ầ/g,'z62');
    str = str.replace(/\Ầ/g,'Z62').replace(/\ẩ/g,'z63').replace(/\Ẩ/g,'Z63');
    str = str.replace(/\ẫ/g,'z64').replace(/\Ẫ/g,'Z64').replace(/\ậ/g,'z65');
    str = str.replace(/\Ậ/g,'Z65').replace(/\ắ/g,'z81').replace(/\Ắ/g,'Z81');
    str = str.replace(/\ằ/g,'z82').replace(/\Ằ/g,'Z82').replace(/\ẳ/g,'z83');
    str = str.replace(/\Ẳ/g,'Z83').replace(/\ẵ/g,'z84').replace(/\Ẵ/g,'Z84');
    str = str.replace(/\ặ/g,'z85').replace(/\Ặ/g,'Z85');
    str = str.replace(/\ế/g,'e61').replace(/\Ế/g,'E61').replace(/\ề/g,'e62');
    str = str.replace(/\Ề/g,'E62').replace(/\ể/g,'e63').replace(/\Ể/g,'E63');
    str = str.replace(/\ễ/g,'e64').replace(/\Ễ/g,'E64').replace(/\ệ/g,'e65');
    str = str.replace(/\Ệ/g,'E65');
    str = str.replace(/\Ă/g,'Z80');
    str = str.replace(/\ă/g,'z80');
    str = str.replace(/\ố/g,'o61').replace(/\Ố/g,'O61').replace(/\ồ/g,'o62');
    str = str.replace(/\Ồ/g,'O62').replace(/\ổ/g,'o63').replace(/\Ổ/g,'O63');
    str = str.replace(/\ỗ/g,'o64').replace(/\Ỗ/g,'O64').replace(/\ộ/g,'o65');
    str = str.replace(/\Ộ/g,'O65');
    str = str.replace(/\ư/g,'u70');
    str = str.replace(/\Ư/g,'U70');
    str = str.replace(/\ứ/g,'u71').replace(/\Ứ/g,'U71').replace(/\ừ/g,'u72');
    str = str.replace(/\Ừ/g,'U72').replace(/\ử/g,'u73').replace(/\Ử/g,'U73');
    str = str.replace(/\ữ/g,'u74').replace(/\Ữ/g,'U74').replace(/\ự/g,'u75');
    str = str.replace(/\Ự/g,'U75');
    str = str.replace(/\ô/g,'o06').replace(/\ê/g,'e6').replace(/\â/g,'z60');
    str = str.replace(/\Ô/g,'O06').replace(/\Ê/g,'E6').replace(/\Â/g,'Z60'); 
    str = str.replace(/\ò/g,'o02').replace(/\è/g,'e2').replace(/\à/g,'z02');
    str = str.replace(/\Ò/g,'O02').replace(/\È/g,'E2').replace(/\À/g,'Z02'); 
    str = str.replace(/\ó/g,'o01').replace(/\é/g,'e1').replace(/\á/g,'z01');
    str = str.replace(/\Ó/g,'O01').replace(/\É/g,'E1').replace(/\Á/g,'Z01'); 
    str = str.replace(/\ỏ/g,'o03');
    str = str.replace(/\Ỏ/g,'O03'); 
    str = str.replace(/\ọ/g,'o05');
    str = str.replace(/\Ọ/g,'O05');
    
    str = str.replace(/\ạ/g,'z03');
    str = str.replace(/\Ạ/g,'Z03'); 
    str = str.replace(/\ả/g,'z05');
    str = str.replace(/\Ả/g,'Z05');
    str = str.replace(/\ả/g,'z06');
    str = str.replace(/\Ả/g,'Z06');
    str = str.replace(/\õ/g,'o04').replace(/\ã/g,'z04').replace(/\Õ/g,'O04');
    str = str.replace(/\Ã/g,'Z04').replace(/\ĩ/g,'i4').replace(/\Ĩ/g,'I4'); 
    str = str.replace(/\í/g,'i1').replace(/\ì/g,'i2').replace(/\ị/g,'i5'); 
    str = str.replace(/\Í/g,'I1').replace(/\Ì/g,'I2').replace(/\Ị/g,'I5'); 
    str = str.replace(/\ỉ/g,'i3').replace(/\Ỉ/g,'I3').replace(/\--/g,'');
    str = str.replace(/\ú/g,'u1').replace(/\Ú/g,'U1').replace(/\ù/g,'u2');
    str = str.replace(/\Ù/g,'U2').replace(/\ụ/g,'u5').replace(/\Ụ/g,'U5');
    str = str.replace(/\ủ/g,'u3').replace(/\Ủ/g,'U3').replace(/\ũ/g,'u4');
    str = str.replace(/\Ũ/g,'U4').replace(/'/g,'`');
    
    str = str.replace(/\ớ/g,'o715').replace(/\ờ/g,'o725');
    str = str.replace(/\ợ/g, 'o755').replace(/\ỡ/g, 'o745').replace(/\ở/g, 'o735');
    str = str.replace(/\Ợ/g, 'O755').replace(/\Ỡ/g, 'O745').replace(/\Ở/g, 'O735');
    str = str.replace(/\Ớ/g, 'O715').replace(/\Ờ/g, 'O725');
    
    str = str.replace(/\ý/g,'y1').replace(/\ỳ/g,'y2');
    str = str.replace(/\ỵ/g, 'y5').replace(/\ỹ/g, 'y4').replace(/\ỷ/g, 'y3');
    str = str.replace(/\Ỵ/g, 'Y5').replace(/\Ỹ/g, 'Y4').replace(/\Ỷ/g, 'Y3');
    str = str.replace(/\Ý/g, 'Y1').replace(/\Ỳ/g, 'Y2');
    
    str = str.replace(/\é/g,'e1').replace(/\è/g,'e2');
    str = str.replace(/\ẹ/g, 'e5').replace(/\ẽ/g, 'e4').replace(/\ẻ/g, 'e3');
    str = str.replace(/\Ẹ/g, 'E5').replace(/\Ẽ/g, 'E4').replace(/\Ẻ/g, 'E3');
    str = str.replace(/\É/g, 'E1').replace(/\È/g, 'E2');
           
    str = str.replace(/(\s+)?[s|S][e|E][l|L][e|E][c|C][t|T](\s+)?/g,'');
    str = str.replace(/(\s+)?[w|W][h|H][e|E][r|R][e|E](\s+)?/g,'');
    str = str.replace(/(\s+)?[f|F][r|R][o|O][m|M](\s+)?/g,'');
    str = str.replace(/(\s+)?[o|O][r|R](\s+)?/g,'');
    str = str.replace(/(\s+)?[a|A][n|N][d|D](\s+)?/g,'');
    str = str.replace(/\?/g,'');
    return str;
}
//================
function checkallMultiItem(chkname)
{
    var check = document.getElementsByTagName("input");
    var checkall = document.getElementById(chkname);
    for(var i = 0; i < check.length; i++)
         if(check[i].type.toLowerCase()=="checkbox" && check[i] != checkall)
               check[i].checked = checkall.checked;
}

//============================
function _parseInt(obj)
{
    try
    {
        return parseInt(obj);
    }
    catch(exception)
    {
        return 0;
    }
}
//============================
function _parseFloat(obj)
{
    try
    {
        return parseFloat(obj);
    }
    catch(exception)
    {
        return 0;
    }
}
//============================
function CheckFormatNum(obj)
{
    try
    {
        return parseFloat(obj);
    }
    catch(exception)
    {
        return -0.001;
    }
}
//============================
function getValues(obj)
{
	var start = 0 ;
	var s = new Array();
	var j = 0;
	while(start < obj.length )
	{
		var len = _parseInt(obj.substring(start,(_parseInt(start)+4)));
		var begin = _parseInt(start) + 4 ;
		s[j++] = obj.substring(begin,(begin + len));
		start = _parseInt(start)+ len + 8  ; 
	}
	var obj = new Object();
	obj.username = s[0];
	obj.password = s[1];
	return obj;
}
//=============================
function generateNumber(num)
{
	if(num < 10 ) num = "000"+num ;
	else if(num >= 10 && num < 100 ) num = "00" + num ;	
	else if (num >= 100 && num < 1000 ) num = "0" + num ;
	return num;
}
//=============================
function generateFile(obj)
{
	var num = generateNumber(obj.length);
	obj = num + obj + num ;
	return obj;
}
//===============================
function saveToCookie(username,pass,checkName)
{
	var dateCookie = new Date();
	var weeken = dateCookie.getDate() + 7;
	dateCookie.setDate(weeken);
	var check = document.getElementsByName(checkName)[0];
	if(check.checked)
		document.cookie = "username="+username + "&pass=" + pass + "; expires="+dateCookie.toGMTString();	
}
//==============================
function getPass(username,pass)
{
	var getCookie = document.cookie;
	if(trim(getCookie)== "") return ;
	var Username = document.getElementsByName(username)[0];
	var Pass = document.getElementsByName(pass)[0];
	if(Username.value == getItemUrl("username",getCookie.split(';')[0]))
		Pass.value = getItemUrl("pass",getCookie.split(';')[0]);
}
//================================
function discardTimeFromDate(date)
{
    return date.replace(/^[0-2][0-9](\s{1,3})?(\:|\g|\h)(\s{1,3})?[0-5][0-9](\s{1,3})?/,'');
}
//================================
function CheckDate(date)
{
    date = date.replace(/[\/|\-|\.}\\]/,';');
    var dates = date.split(';');
    var day = dates[0];
    var mon = dates[1];
    var yea = dates[2];
    return verifydate2(day,mon,yea);
}
//===============================
function checkallitem(checkname)
{
    try
    {
        var check = document.getElementsByTagName("input");
        var checkall = document.getElementsByName(checkname)[0];
        for(var i = 0; i < check.length; i++)
            if(check[i].type.toLowerCase() == "checkbox" && check[i] != checkall)
                check[i].checked = checkall.checked;
    }
    catch(exception)
    {
        return false;
    }
}
//===============================
function checkItemChecked(checkname)
{
    var iCount = 0;
    try
    {
        var check = document.getElementsByTagName("input");
        var checkall = document.getElementsByName(checkname)[0];
        for(var i = 0; i < check.length; i++)
            if(check[i].type.toLowerCase() == "checkbox" && check[i] != checkall)
                iCount += check[i].checked == true ? 1 : 0;
        return iCount;
    }
    catch(exception)
    {
        return 0;
    }
}
//=====================================
function FormatDate(type)
{
    try
    {
        var str = "";
        var date = new Date();
        switch(type)
        {
            case 1 : str = date.getDate()+"/"+(date.getMonth()+1)+"/"+date.getFullYear(); break;// d/m/yyyy;
            case 2 : str = date.getDate()+"-"+(date.getMonth()+1)+"-"+date.getFullYear(); break;// d-m-yyyy;
            case 3 : str = generateZero(date.getDate(),2)+"/"+generateZero((date.getMonth()+1),2)+"/"+date.getFullYear(); break;// dd/mm/yyyy;
            case 4 : str = generateZero(date.getDate(),2)+"/"+generateZero((date.getMonth()+1),2)+"/"+date.getFullYear().substring(2); break;// dd/mm/yy;
            case 5 : str = generateZero(date.getDate(),2)+"-"+generateZero((date.getMonth()+1),2)+"-"+date.getFullYear().substring(2); break;// dd-mm-yy;
        }
    }
    catch(exception)
    {
        str = date.getDate()+"/"+(date.getMonth()+1)+"/"+date.getFullYear();
    }
    return str;
}
//=======================================
function generateZero(obj,quantity)
{
    var str = "";
    var len = (obj+"").length;
    for(var i = 0; i < quantity - len; i++ )
        str = "0";
    obj = str + "" + obj;
    return obj;
}
