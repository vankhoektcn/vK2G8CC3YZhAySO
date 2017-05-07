
function checkTimes(control)
{
    if(control.value.length > 0){
        if(control.value.split(':').length == 2)
        {
            if(getTimes(control.value) == false)
            {
                control.select();
            }
        }
        else{
            var timenew = control.value.charAt(0) + control.value.charAt(1) + ':' + control.value.charAt(2) + control.value.charAt(3); 
            control.value = timenew;
            if(getTimes(control.value) == false)
            {
                control.select();
            }
        }
    }
}

function getTimes(control)
{
    var time = /^(\d{2,2})(\:|-)(\d{2,2})$/;
    var times = control.match(time);
        if(times == null)
        {
            alert('Khong dung dinh dang HH:mm');
            return false;
        }
        if(control.split(':')[0] == 24 && control.split(':')[1] > 0)
        {
            alert('Phút không lớn hơn 0');
            return false;
        }
        else if(control.split(':')[0] < 24){
            if(control.split(':')[0] < 0)
            {
                alert('Giờ không nhỏ hơn 0');
                return false;
            }
            if(control.split(':')[1] > 59 || control.split(':')[1] < 0)
            {
                alert('Phút phải nhỏ hơn 59 va không nhỏ hơn 0');
                return false;
            }
        }
        else if(control.split(':')[0] > 24){
            alert('Giờ phải không lớn hơn 24');
            return false;
        }
}

function formatCurrency(num) 
 {
    num = num.toString().replace(/\$|\,/g,'');
    if(isNaN(num))
    num = "0";
    var sign = (num == (num = Math.abs(num)));
    num = Math.floor(num*100+0.50000000001);
    var sole = num % 100;
    num = Math.floor(num/100).toString();
    
    for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
    {
        num = num.substring(0,num.length-(4*i+3))+'.'+
        num.substring(num.length-(4*i+3));
    }
    return (((sign)?'':'-') + num+","+sole);
}

function TestDate(t) {
    var ngay = t;
    if (t.value.length > 0) {
        var arrngay = ngay.value.split('/');
        if (arrngay.length == 3) {
            isDate(ngay.value);
            return;
        }
        else {
            var ngaymoi = ngay.value.charAt(0) + ngay.value.charAt(1) + '/' + ngay.value.charAt(2) + ngay.value.charAt(3) + '/' + ngay.value.charAt(4) + ngay.value.charAt(5) + ngay.value.charAt(6) + ngay.value.charAt(7);
            t.value = ngaymoi;
            if (t.value != "") {
                if (isDate(t.value) == false) {
                    t.select();
                }
            }
        }
    }
}
function isDate(dateStr) {
    var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
    var matchArray = dateStr.match(datePat);
    if (matchArray == null) {
        alert("Ngày tháng không hợp lệ: " + dateStr);
        return false;
    }
    day = matchArray[1];
    month = matchArray[3];
    year = matchArray[5];

    if (month < 1 || month > 12) {
        alert("Tháng phải giữa 1 và 12.");
        return false;
    }

    if (day < 1 || day > 31) {
        alert("Ngày phải giữa 1 và 31 ngày.");
        return false;
    }

    if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) {
        alert("Tháng " + month + " không có 31 ngày!");
        return false;
    }

    if (month == 2) {
        var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
        if (day > 29 || (day == 29 && !isleap)) {
            alert("Tháng 2 năm " + year + " không có " + day + " ngày!");
            return false;
        }
    }
    return true;
}
function TestMax(control, sokitu) {
    if (control.value.length > sokitu) {
        alert('Không được vượt quá "' + sokitu + '" kí tự !');
        control.focus();
        control.select();
        return;
    }
    return true;
}
function TestSo(control, soAm, formatSo) {
if(formatSo == false)
{
    if (control.value.length > 0) {
        
        if (soAm == true) {
            try {
                eval(control.value) * 1;
            }
            catch (ex) {
                control.value = 0;
                return;
            }
        }
        else {
            try {
                if (eval(control.value) < 0) {
                    alert('Số phải > "-1" !');
                    control.select();
                    control.focus();
                    return;
                }
            }
            catch (ex) {
                 control.value = 0;
                return;
            }

        }
    }
     else{
            control.value = 0;
        }
        }else{
        control.value = formatCurrency(control.value);
    }
}


function openExcel(strLocation, boolReadOnly) {
	var objExcel;
	var fsobj = new ActiveXObject("Scripting.FileSystemObject");
	objExcel = new ActiveXObject("Excel.Application");
	objExcel.Visible = true;
	objExcel.DisplayAlerts = false;
	objExcel.Workbooks.Open(strLocation, false, boolReadOnly);
}