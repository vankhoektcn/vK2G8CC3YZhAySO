
//Cac ham xu ly cac chuoi
//Ham nay dung kiem tra chuoi nhap vao co phai la so khong (Kieu Float)
//Phai dam bao rang s truyen vao phai duoc cat khoang trang
//Tra ve ngay hien tai tren client
function MyRound(objValue)
{
	objValue = Math.round(objValue * 1000);
	objValue = objValue / 1000;
	return objValue;
}
function ConfirmDelete()
{
	if (confirm("Bạn có muốn xóa mẫu tin này không?")==true)
		return true;
	else
		return false;
}

function ConfirmHoanTat()
{
	if (confirm("Bạn có muốn kết thúc việc thăm khám này không?")==true)
		return true;
	else
		return false;
}

function deleteCurrentRow(obj)
{
	if(confirm("Are you sure you want to delete this item?")){
		var delRow = obj.parentNode.parentNode;
		var tbl = delRow.parentNode;
		var rIndex = delRow.rowIndex;
		tbl.deleteRow(rIndex);
		
	}
	return false;
}			

function GetDate()
		{
			var dDate = new Date();
			var sD = String((parseInt(dDate.getMonth())+ 1)) + "/" + dDate.getDate()+ "/" + dDate.getYear();
			//document.Form1.txtDate.value = sD;
			//alert(document.Form1.txtDate.value);
			return sD;
		}
function CheckNumberFloat(s)
{
	var i = 0;
	for(i = 0; i<s.length; i++)
	{
		var c = s.charAt(i);
		if (s.charAt(0)=="." ||s.charAt(s.length -1)==".")
		return false;
		else if( ( c < "0" || c > "9" ) && c != "." )
			return false;
	}
	var checkNum;
	checkNum = parseFloat(s);
	if ( isNaN(checkNum) )
		return false;
    return true;
}

//Ham nay kiem tra mot chuoi co phai la so khong (Integer)
function CheckNumberInt(s)
{
	var i = 0;
	for(i = 0; i<s.length; i++)
	{
		var c = s.charAt(i);
		if( c < "0" || c > "9" )
			return false;
	}
    return true;
}
function trimLeft(s) {
    var whitespaces = " \t\n\r";
    for(n = 0; n < s.length; n++) { if (whitespaces.indexOf(s.charAt(n)) == -1) return (n > 0) ? s.substring(n, s.length) : s; }
    return("");
}

function trimRight(s){
    var whitespaces = " \t\n\r";
    for(n = s.length - 1; n  > -1; n--) { if (whitespaces.indexOf(s.charAt(n)) == -1) return (n < (s.length - 1)) ? s.substring(0, n+1) : s; }
    return("");
}

function trim(s) {return ((s == null) ? "" : trimRight(trimLeft(s))); }

function isSelected(field, strBodyHeader) {
    for(i=0; i < field.length; i++) { 
        if (field[i].selected && (trim(field[i].value).length > 0)) {
            return true;
        }
    }
    alert("\"" + strBodyHeader + "\" is a required field. Please choose a selection.");
    field.focus();
    return false;
}
// Ham isDate Dung de kiem tra ngay
/**
 * DHTML date validation script. Courtesy of SmartWebby.com (http://www.smartwebby.com/dhtml/)
 */
// Declaring valid date character, minimum year and maximum year
var dtCh= "/";
var minYear=1900;
var maxYear=2100;

function isInteger(s){
	var i;
    for (i = 0; i < s.length; i++){   
        // Check that current character is number.
        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) return false;
    }
    // All characters are numbers.
    return true;
}
function isFloat(s){
	var i;	
    for (i = 0; i < s.length; i++){   
        // Check that current character is number.
        var c = s.charAt(i);
        if (s.charAt(0)=="." || s.charAt(s.length-1)==".")
        {
			return  false
        }
        else if (((c < "0") || (c > "9"))&& (c != ".") ) return false;
    }
    // All characters are numbers.
    return true;
}

function stripCharsInBag(s, bag){
	var i;
    var returnString = "";
    // Search through string's characters one by one.
    // If character is not in bag, append to returnString.
    for (i = 0; i < s.length; i++){   
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}

function daysInFebruary (year){
	// February has 29 days in any year evenly divisible by four,
    // EXCEPT for centurial years which are not also divisible by 400.
    return (((year % 4 == 0) && ( (!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28 );
}
function DaysArray(n) {
	for (var i = 1; i <= n; i++) {
		this[i] = 31
		if (i==4 || i==6 || i==9 || i==11) {this[i] = 30}
		if (i==2) {this[i] = 29}
   } 
   return this
}

function isDate(dtStr){
	var daysInMonth = DaysArray(12)
	var pos1=dtStr.indexOf(dtCh)
	var pos2=dtStr.indexOf(dtCh,pos1+1)
	var strDay=dtStr.substring(0,pos1)
	var strMonth=dtStr.substring(pos1+1,pos2)
	var strYear=dtStr.substring(pos2+1)
	strYr=strYear	
	if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
	if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
	for (var i = 1; i <= 3; i++) {
		if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
	}
	month=parseInt(strMonth)
	day=parseInt(strDay)
	year=parseInt(strYr)
	
	if (pos1==-1 || pos2==-1){
		//alert("The date format should be : mm/dd/yyyy")
		return false
	}
	if (strMonth.length<1 || month<1 || month>12){
		//alert("Please enter a valid month")
		return false
	}
	if (strDay.length<1 || day<1 || day>31 || (month==2 && day>daysInFebruary(year)) || day > daysInMonth[month]){
		//alert("Please enter a valid day")
		return false
	}
	if (strYear.length != 4 || year==0 || year<minYear || year>maxYear){
		//alert("Please enter a valid 4 digit year between "+minYear+" and "+maxYear)
		return false
	}
	if (dtStr.indexOf(dtCh,pos2+1)!=-1 || isInteger(stripCharsInBag(dtStr, dtCh))==false){
		//alert("Please enter a valid date")
		return false
	}
	return true
}

//Ham nay dung de tru ngay hai tham so phai la kieu ngay
function suycDateDiff( startdate, enddate )
{
	var iOut = 0;
	var startMsg = "Check the Start Date and End Date\n";
	startMsg += "must be a valid date format\n\n";
	startMsg += "Please try again";
	var bufferA = Date.parse( startdate );
	var bufferB = Date.parse( enddate );
	if ( isNaN(bufferA) || isNaN(bufferB) )
	{
		alert(startMsg);
		return null;
	}
	iOut = bufferA - bufferB;
return iOut/86400000;
}

//Add them x ngay vao ngay da cho 
function Adddate( sDate, nDate )
{
	/*
	var iOut = 0;
	//sDate='10/5/2004';
	var bufferA = Date.parse(sDate);
	//alert(bufferA);
	var bufferB = nDate*24*60*60*1000;
	//alert(bufferB);
	iOut = bufferA + bufferB;
	//alert(iOut);
	var sOut;*/
	var sOut =new Date(sDate);
	sOut.setDate(sOut.getDate() + nDate);
	var m,d,y;
	d = sOut.getDate();
	m = sOut.getMonth()+1;
	y = sOut.getFullYear();
	return m+"/"+d+"/"+y;
}

//Ham nay lai mot ngay co Kieu la Date tru so ngay
//20/1/2004 - 15 = 5/1/2004
function suycDate( sDate, nDate )
{
	var iOut = 0;
	//sDate='10/5/2004';
	var bufferA = Date.parse(sDate);
	//alert(bufferA);
	var bufferB = nDate*24*60*60*1000;
	//alert(bufferB);
	iOut = bufferA - bufferB;
	//alert(iOut);
	var sOut;
	sOut = new Date(iOut);
	var m,d,y;
	d = sOut.getDate();
	m = sOut.getMonth()+1;
	y = sOut.getFullYear();
	return m+"/"+d+"/"+y;
}

//Ham dung kiem tra xem co check box nao duoc check hay chua
//Dung bien nay co the xem co PO nao duoc check hay chua
function FindPoCheck(nid)
{
	var theBox = document.getElementById(nid);
	if(theBox == null)
		return false;
	var xState = true;
	if ( theBox.checked == true )
		return true;
	elm = theBox.form.elements;
	for(i=0;i<elm.length;i++)
	{
		if(elm[i].type=="checkbox" && elm[i].id != theBox.id )
		{
			if( elm[i].checked == true )
			{
				return true;
			}
		}
	}
	alert("Not selected ! ");
	return false;
}
function FindTwoPoCheck(t,n)
{
		var temp1;
		temp1 = t.substring(0,t.indexOf("_"));
		var temp2;
		temp2 = t.substring(t.lastIndexOf("_")-1,t.lastIndexOf("_"));
		var temp3;
		var tt = t.lastIndexOf("_")+1;
		temp3 = t.substring(tt ,t.length);
		for (j=0;j<n;j++)
		{
			var sCheckboxName = temp1+"__ctl"+temp2+"_"+temp3;
			temp2++;
			var theBox = document.getElementById(sCheckboxName);
			if( theBox.checked == true )
				return true;
		}
		alert("PO is not select ");
		return false;
}


//Dung de chuyen dinh dang cua mot chuoi ngay thanh mot ngay co format
//mm/dd/yyyy
//ss la chuoi tham so dau vao s = 1/1/04
function AddString(ss)
{
	var s = ss;
	if(s.indexOf("\\") != -1 || s.indexOf("-") != -1 || s.length > 10 )
		return ss;
	if ( s.length == 10 )
		return ss;	
	var result1, result2, result3;
	var temp = s.substring(s.lastIndexOf("/") + 1, s.length);
	if(temp.length == 3 || temp.length == 1)	
		return ss;
	if(temp.length == 2)
	result1 = "20" + temp;
	if(temp.length == 4)
		result1 = temp;
				
	s = s.substring(0,s.lastIndexOf("/"));
	temp = s.substring(s.lastIndexOf("/")+1, s.length);
	if(temp.length == 0)
		return ss;
	if(temp.length == 1)
		result2 = "0" + temp;				
	if(temp.length == 2)
		result2 = temp;	
	s = s.substring(0,s.lastIndexOf("/"));
	temp = s.substring(s.lastIndexOf("/")+1, s.length);
	if(temp.length == 0)
		return ss;
	if(temp.length == 1)
		result3 = "0" + temp;
	if(temp.length == 2)
		result3 = temp;
				
	ss = result3 + "/" + result2 + "/" + result1;
	return ss;
}


//Ham nay thuc hien nut check all
//e la doi tuong cua check all
function CheckAll(e)
{
	var xState = e.checked;
	var theBox = e;
	var elm = theBox.form.elements;
	var i = 0;
	for(i = 0;i < elm.length; i++)
		if(elm[i].type=="checkbox" && elm[i].id != theBox.id)
			if(elm[i].checked != xState)
			elm[i].click();
}

//ham kiem tra rong
function CheckEmpty(s)
{
var s1=document.getElementById(s);
	if (s1.value=="")
	{
		alert("Data Empty, please enter ...")
		s1.focus();
		return false
	}	
	return true
}

//ham kiem tra rong hai tham so
function CheckEmpty2(s1,s2)
{
var v1=document.getElementById(s1);
var v2=document.getElementById(s2);

	if (v1.value=="")
	{
		alert("Data Empty, please enter ...")
		v1.focus();
		return false
	}	
	if (v2.value=="")
	{
		alert("Data Empty, please enter ...")
		v2.focus();
		return false
	}
	return true
}
// ham kiem tra email
function isEmail(s)
{   
  if (s!="")
  {
	  if(s.indexOf(" ")>0) 
	  {		
		return false;
	  }
		
	 if(s.indexOf("@")==-1) 
		{		
			return false;
		}
		
	  var i = 1;
	  var sLength = s.length;
	  //if (s.indexO7f(".")==-1) 
	//	return false;
		
	  if (s.indexOf("..")!=-1) 
	  {
		return false;
	  }
		
	  if (s.indexOf("@")!=s.lastIndexOf("@")) 
	  {
		
		return false;
	  }
	  if (s.lastIndexOf(".")==-1) 
		{			
			return false;
		}	
	  if (s.lastIndexOf(".")==s.length-1) 
		{
			
			return false;
		}
	  var str="0123456789ABCDEFGHIKLMNOPQRSTUVXYZabcdefghikjlmnopqrstuvwxyz-@._"; 
	  for(var j=0;j<s.length;j++)
		if(str.indexOf(s.charAt(j))==-1)
		{
		
			return false;
		}	
   return true;
  }
}
function ToUpper(t)
{
	t.value = t.value.toUpperCase()
	return;
}

function autoComplete (field, select, property, forcematch) 
{
	var found = false;
	for (var i = 0; i < select.options.length; i++) 
	{
	if (select.options[i][property].toUpperCase().indexOf(field.value.toUpperCase()) == 0) 
		{
		found=true; break;
		}
	}
	if (found) { select.selectedIndex = i; }
	else { select.selectedIndex = -1; }
	if (field.createTextRange) 
	{	
		//bo di ky tu du sai
		if (forcematch && !found) 
		{
			//field.value=field.value.substring(0,field.value.length-1); 
			return;
		}
		var cursorKeys ="8;46;37;38;39;40;33;34;35;36;45;";
		if (cursorKeys.indexOf(event.keyCode+";") == -1) 
		{
			var r1 = field.createTextRange();
			var oldValue = r1.text;
			var newValue = found ? select.options[i][property] : oldValue;
			
			if (newValue != field.value) 
			{
				field.value = newValue;
				var rNew = field.createTextRange();
				rNew.moveStart('character', oldValue.length) ;
				rNew.select();
			}
		}
	}
}
/* tim va thay doi class name cua headerStyle*/
function ChangeClassHeaderStyle(heighTitle,strIDDataGrid)
{
	var xx=document.body.scrollTop; //vi tri cua scrollbar doc
	
	var navRoot = document.getElementById(strIDDataGrid); //lay goc cua "cay" grid
	var tbody = navRoot.childNodes[0]; //doi tuog header
	node = tbody.childNodes[0];
		if(node.nodeName == "TR"){
		if(xx>heighTitle)
		  	node.className = "ms-formlabel DataGridFixedHeader";
		else
		  	node.className = "ms-formlabel DataGridFixedHeader1";
	}
}

function formatCurrency(num) 
{
    num = num.toString().replace(/\$|\,/g,'');
    if(isNaN(num))
    num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num*100+0.50000000001);
    cents = num%100;
    num = Math.floor(num/100).toString();
    if(cents<10)
    cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
    num = num.substring(0,num.length-(4*i+3))+'.'+
    num.substring(num.length-(4*i+3));
    //return (((sign)?'':'-') + num + '.' + cents);
    return (((sign)?'':'-') + num);
}
	