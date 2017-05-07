// JScript File
function nvk_CurentDate()
{
    var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();
        if (dd < 10) { dd = '0' + dd }
        if (mm < 10) { mm = '0' + mm }
        var aa= dd + "/" + mm + "/" + yyyy;
        return aa;
}
function nvk_testDate(id_txtNgay)
	{
		if (document.getElementById(id_txtNgay).value.length < 1)
		{
		    //alert("Bạn phải nhập ngày hợp lệ !");
			document.getElementById(id_txtNgay).focus();
			return;
		}
		var ngaybd = document.getElementById(id_txtNgay);
		var arrngaybd = ngaybd.value.split('/');
		var ngaymoi;
		var ngay;
		var thang;
		var nam;
		var getDay;
		var offset;
		var now = new Date();
		if (arrngaybd.length == 3)
		{
		    var bd = nvk_isDate(ngaybd.value);
			if (bd == false)
			{
    			document.getElementById(id_txtNgay).value = "";
				document.getElementById(id_txtNgay).focus();
			}
//			ngay = arrngaybd[0];
//			thang = arrngaybd[1];
//			nam = arrngaybd[2];
//			getDay = new Date(nam, thang-1, ngay);
//			offset = now.getTime() - getDay.getTime();
//			if (offset < 0) {
//				alert("Ngày không hợp lệ");
//				document.getElementById(id_txtNgay).value = "";
//				document.getElementById(id_txtNgay).focus();
//			}
		}
		if (arrngaybd.length != 3)
		{
			ngay = ngaybd.value.charAt(0) + ngaybd.value.charAt(1);
			thang = ngaybd.value.charAt(2) + ngaybd.value.charAt(3);
			nam = ngaybd.value.charAt(4) + ngaybd.value.charAt(5) + ngaybd.value.charAt(6) + ngaybd.value.charAt(7);
			ngaymoi = ngay + '/' + thang + '/' + nam;
			document.getElementById(id_txtNgay).value = ngaymoi;
			var bd = nvk_isDate(ngaymoi);
			if (bd == false)
			{
    			document.getElementById(id_txtNgay).value = "";
				document.getElementById(id_txtNgay).focus();
			}
			if (bd == true)
			 {
//				getDay = new Date(nam, thang-1, ngay);
//				offset = now.getTime() - getDay.getTime();
//				if (offset < 0) {
//					alert("Ngày bắt đầu không hợp lệ");
//					document.getElementById(id_txtNgay).value = "";
//					document.getElementById(id_txtNgay).focus();
//				}

			 }

		}
	}
function nvk_testDate_this(obj)
	{
		if (obj.value.length < 1)
		{
			obj.focus();
			return;
		}
		var ngaybd = obj;
		var arrngaybd = ngaybd.value.split('/');
		var ngaymoi;
		var ngay;
		var thang;
		var nam;
		var getDay;
		var offset;
		var now = new Date();
		if (arrngaybd.length == 3)
		{
		    var bd = nvk_isDate(ngaybd.value);
			if (bd == false)
			{
    			obj.value = "";
				obj.focus();
			}
//			ngay = arrngaybd[0];
//			thang = arrngaybd[1];
//			nam = arrngaybd[2];
//			getDay = new Date(nam, thang-1, ngay);
//			offset = now.getTime() - getDay.getTime();
//			if (offset < 0) {
//				alert("Ngày không hợp lệ");
//				obj.value = "";
//				obj.focus();
//			}
		}
		if (arrngaybd.length != 3)
		{
			ngay = ngaybd.value.charAt(0) + ngaybd.value.charAt(1);
			thang = ngaybd.value.charAt(2) + ngaybd.value.charAt(3);
			nam = ngaybd.value.charAt(4) + ngaybd.value.charAt(5) + ngaybd.value.charAt(6) + ngaybd.value.charAt(7);
			ngaymoi = ngay + '/' + thang + '/' + nam;
			obj.value = ngaymoi;
			var bd = nvk_isDate(ngaymoi);
			if (bd == false)
			{
    			obj.value = "";
				obj.focus();
			}
			if (bd == true)
			 {
			 }

		}
	}
function nvk_testDate_this_notfocus(obj)
	{
		if (obj.value.length < 1)
		{
			return;
		}
		var ngaybd = obj;
		var arrngaybd = ngaybd.value.split('/');
		var ngaymoi;
		var ngay;
		var thang;
		var nam;
		var getDay;
		var offset;
		var now = new Date();
		if (arrngaybd.length == 3)
		{
		    var bd = nvk_isDate(ngaybd.value);
			if (bd == false)
			{
    			obj.value = "";
			}
		}
		if (arrngaybd.length != 3)
		{
			ngay = ngaybd.value.charAt(0) + ngaybd.value.charAt(1);
			thang = ngaybd.value.charAt(2) + ngaybd.value.charAt(3);
			nam = ngaybd.value.charAt(4) + ngaybd.value.charAt(5) + ngaybd.value.charAt(6) + ngaybd.value.charAt(7);
			ngaymoi = ngay + '/' + thang + '/' + nam;
			obj.value = ngaymoi;
			var bd = nvk_isDate(ngaymoi);
			if (bd == false)
			{
    			obj.value = "";
			}
			if (bd == true)
			 {
			 }

		}
	}
function nvk_isDate(dateStr) {
        var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
        var matchArray = dateStr.match(datePat); // is the format ok?
        if (matchArray == null) {
        alert("Ngày tháng không hợp lệ: " + dateStr);
        return false;
        }       
        day = matchArray[1]; // p@rse date into variables
        month = matchArray[3];
        year = matchArray[5];

        if (month < 1 || month > 12) { // check month range
        alert("Tháng phải giữa 1 và 12.");
        return false;
        }

        if (day < 1 || day > 31) {
        alert("Ngày phải giữa 1 và 31 ngày.");
        return false;
        }

        if ((month==4 || month==6 || month==9 || month==11) && day==31) {
        alert("Tháng "+month+" không có 31 ngày!");
        return false;
        }

        if (month == 2) { // check for february 29th
        var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
        if (day > 29 || (day==29 && !isleap)) {
        alert("Tháng 2 năm " + year + " không có " + day + " ngày!");
        return false;}
        }
        return true; // date is valid
    }
 
function formatCurrency(num) {
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
        num = num.substring(0,num.length-(4*i+3))+','+
        num.substring(num.length-(4*i+3));
        return (((sign)?'':'-')  + num + '.' + cents);
}
function nck_formatCurrency(num,isThapPhan) {
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
        num = num.substring(0,num.length-(4*i+3))+','+
        num.substring(num.length-(4*i+3));
        if(isThapPhan)
            return (((sign)?'':'-')  + num + '.' + cents);
        else
            return (((sign)?'':'-')  + num );            
}
function nvk_formatNumBer(obj)
{
    var format = obj.value;
    if(format==null)
        return;
    if(format==undefined)
        return;    
    //alert(format);
    var kq = nck_formatCurrency(format,false);
    obj.value=kq;
    
}