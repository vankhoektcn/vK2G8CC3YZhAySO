// JScript File
//dinh dang ngay: dd/mm/yy tu chuoi
function dinhdangngay(obj)
{        
    var kq="";
    var ngaylap=obj.value;     
    
    if(ngaylap!="")
    {    
    if(ngaylap.length==10)
    {
        kq=ngaylap;
    } 
    else
    {  
    if(ngaylap.length !=8 || isNaN(ngaylap))
    {
        alert('Bạn nhập chưa đúng,xin nhập lại:ddmmyy!');
        obj.focus();
    }
    else
    {    
        var ngay=ngaylap.substring(0,2);
        if(eval(ngay)>31 || eval(ngay)<1)
        {
            alert('Bạn nhập ngày chưa đúng!');
            obj.focus();
         }        
        var thang=ngaylap.substr(2,2);
        if(eval(thang)<1 || eval(thang) >12)
        {
            alert('Bạn nhập tháng chưa đúng');
            obj.focus();
        }        
        var nam=ngaylap.substr(4,4);             
        kq=ngay+"/"+thang+"/"+nam;
    }    
    }
    }
    return obj.value=kq;
}

