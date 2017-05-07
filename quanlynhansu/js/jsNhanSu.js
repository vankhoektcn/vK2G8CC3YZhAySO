function kiemtrangay(obj){
		if(obj.value.length<1)
		{   
		        //alert("Bạn phải nhập ngày hết hạn");
		        return;
		}	    
	    var arrngaybd=obj.value.split('/');
	    var ngaymoi="";	    
	    if(arrngaybd.length==3)
	    {
	        isDate(obj.value);
	        return;
	    }
	    else
	    {
	        ngaymoi=obj.value.charAt(0)+obj.value.charAt(1)+'/'+obj.value.charAt(2)+obj.value.charAt(3)+'/'+obj.value.charAt(4)+obj.value.charAt(5)+obj.value.charAt(6)+ obj.value.charAt(7);
	        obj.value=ngaymoi;
	    }
	    var kt=isDate(ngaymoi);
	    if(kt==false)
	    {
	        obj.focus();
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
            num = num.substring(0,num.length-(4*i+3))+','+
            num.substring(num.length-(4*i+3));
            //return (((sign)?'':'-') + num + '.' + cents);
            return (((sign)?'':'-') + num);
        }
	function isDate(dateStr) {
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
 function isNumber(field) 
  {
    var re = /^[0-9-'.'-',']*$/;
    if (!re.test(field.value)) {
    //alert('Value must be all numberic charcters, including "." or "," non numerics will be removed from field!');
    field.value = field.value.replace(/[^0-9-'.'-',']/g,"");
  }
}
    