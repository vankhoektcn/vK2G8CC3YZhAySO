/*kho*/
function saveKHO()
{
    try
    {     
        var txtmancc= document.getElementById(ctrlServer+"txtmakho");
        if(Trim(txtmancc.value) == "")
        {
            alert("Mã kho không được để trống . Vui lòng nhập lại ");
            txtmancc.focus();
            return false;
        }   
        var txttenkho = document.getElementById(ctrlServer+"txttenkho");
        if(Trim(txttenkho.value) == "")
        {
            alert("Tên kho không được để trống . Vui lòng nhập lại ");
            txttenkho.focus();
            return false;
        } 
        return true;       
    }
    catch(exception)
    {
        alert("Vui lòng cung cấp thông tin trước khi lưu ");
        return false;
    } 
}
function searchKHO()
{
    var flag=false;    
    var tenkho = document.getElementById(ctrlServer+"txttenkho");
    if(Trim(tenkho.value) != "" && !flag)
    {
         flag=true;
    }    
    var txtmakho = document.getElementById(ctrlServer+"txtmakho");
    if(Trim(txtmakho.value) && !flag)
    {
         flag=true;
    }    
    if(flag)
        return true;
    else
        alert("Vui lòng cung cấp thông tin để tìm.")
    return false;
}
/*NCC*/
function saveNCC()
{
    try
    {     
        var txtmancc= document.getElementById(ctrlServer+"txtmancc");
        if(Trim(txtmancc.value) == "")
        {
            alert("Mã nhà cung cấp không được để trống . Vui lòng nhập lại ");
            txtmancc.focus();
            return false;
        }   
        var tenncc = document.getElementById(ctrlServer+"txttenncc");
        if(Trim(tenncc.value) == "")
        {
            alert("Tên nhà cung cấp không được để trống . Vui lòng nhập lại ");
            tenncc.focus();
            return false;
        }
        var txtlienhe = document.getElementById(ctrlServer+"txtlienhe");
        if(Trim(txtlienhe.value) == "")
        {
            alert("Tên người liên hệ không được để trống . Vui lòng nhập lại ");
            txtlienhe.focus();
            return false;
        }
        if(document.getElementById(ctrlServer+"radioNCC").checked==true)
        {
            var ddimei=document.getElementById(ctrlServer+"txtdinhdanh");
            if(ddimei.value=="")
            {
                alert("Định danh IMEI không được bỏ trống. Vui lòng nhập lại");
                ddimei.focus();
                return false;
            }
            if(ddimei.value.length!=4)
            {
                alert("Vui lòng nhập 4 ký tự");
                ddimei.focus();
                return false;
            }
           
        }             
        
    }
    catch(exception)
    {
        alert("Vui lòng cung cấp thông tin trước khi lưu ");
        return false;
    } 
}

function searchNCC()
{
    var flag=false;    
    var tenncc = document.getElementById(ctrlServer+"txttenncc");
    if(Trim(tenncc.value) != "" && !flag)
    {
         flag=true;
    }    
    var txttindung = document.getElementById(ctrlServer+"txttindung");
    if(Trim(txttindung.value) && !flag)
    {
         flag=true;
    }
    var txtlienhe=document.getElementById(ctrlServer+"txtlienhe");
    if(Trim(txtlienhe.value)!="" && !flag)
    {
         flag=true;
    }
    if(flag)
        return true;
    else
        alert("Vui lòng cung cấp thông tin để tìm.")
    return false;
}
/*nhomSP*/
function saveNSP()
{
    try
    {     
        var cboNCC= document.getElementById(ctrlServer+"cboNCC");
        if(Trim(cboNCC.value) == "")
        {
            alert("Mã nhà cung cấp không được để trống . Vui lòng nhập lại ");
            cboNCC.focus();
            return false;
        }   
        var txtmanhom = document.getElementById(ctrlServer+"txtmanhom");
        if(Trim(txtmanhom.value) == "")
        {
            alert("Mã nhóm không được để trống . Vui lòng nhập lại ");
            txtmanhom.focus();
            return false;
        }
        var txttennhom = document.getElementById(ctrlServer+"txttennhom");
        if(Trim(txttennhom.value) == "")
        {
            alert("Tên nhóm không được để trống . Vui lòng nhập lại ");
            txttennhom.focus();
            return false;
        }                  
        var txtimei= document.getElementById(ctrlServer+"txtimei");
        if(Trim(txtimei.value) == "")
        {
            alert("Định danh không được để trống . Vui lòng nhập lại ");
            txtimei.focus();
            return false;
        }                  
    }
    catch(exception)
    {
        alert("Vui lòng cung cấp thông tin trước khi lưu ");
        return false;
    } 
}

function searchNSP()
{
    var flag=false;    
    var cboNCC= document.getElementById(ctrlServer+"cboNCC");
    if(Trim(cboNCC.value)!= "" && !flag)
    {
         flag=true;
    }    
    var txtmanhom = document.getElementById(ctrlServer+"txtmanhom");
    if(Trim(txtmanhom.value) != "" && !flag)
    {
         flag=true;
    }
    var txttennhom = document.getElementById(ctrlServer+"txttennhom");
    if(Trim(txttennhom.value) != "" && !flag)
    {
         flag=true;
    }
    var txtimei= document.getElementById(ctrlServer+"txtimei");
    if(Trim(txtimei.value) != "" && !flag)
    {
        flag=true;
    }  
    if(flag)
        return true;
    else
        alert("Vui lòng cung cấp thông tin để tìm.")
    return false;
}
/*nhomSP*/
function saveSP()
{
    try
    {     
        var ddlNhomsp= document.getElementById(ctrlServer+"ddlNhomsp");
        if(Trim(ddlNhomsp.value) == "")
        {
            alert("Nhóm hàng không được để trống . Vui lòng nhập lại ");
            ddlNhomsp.focus();
            return false;
        }   
        var txtmasp = document.getElementById(ctrlServer+"txtmasp");
        if(Trim(txtmasp.value) == "")
        {
            alert("Mã nhóm không được để trống . Vui lòng nhập lại ");
            txtmasp.focus();
            return false;
        }
        var txtTensp = document.getElementById(ctrlServer+"txtTensp");
        if(Trim(txtTensp.value) == "")
        {
            alert("Tên nhóm không được để trống . Vui lòng nhập lại ");
            txtTensp.focus();
            return false;
        }                 
                   
    }
    catch(exception)
    {
        alert("Vui lòng cung cấp thông tin trước khi lưu ");
        return false;
    } 
}

function searchSP()
{
    var flag=false;    
    var ddlNhomsp= document.getElementById(ctrlServer+"ddlNhomsp");
    if(Trim(ddlNhomsp.value) != "" && !flag)
    {
         flag=true;
    }    
    var txtmasp = document.getElementById(ctrlServer+"txtmasp");
    if(Trim(txtmasp.value) != "" && !flag)
    {
         flag=true;
    }
    var txttennhom = document.getElementById(ctrlServer+"txttennhom");
    if(Trim(txttennhom.value) != "" && !flag)
    {
         flag=true;
    }
    var txtTensp = document.getElementById(ctrlServer+"txtTensp");
    if(Trim(txtTensp.value) != "" && !flag)
    {
        flag=true;
    }  
    if(flag)
        return true;
    else
        alert("Vui lòng cung cấp thông tin để tìm.")
    return false;
}
/*ngan*/
function showSP(v){  
    //var v=document.getElementById(this);    
    var s=document.getElementById('listsp_'+v);    
    if(s!=null)
    {
        if(s.style.display=='none')
            s.style.display='';
        else
            s.style.display='none';
    }
}
function back(){
    location.href="quanlykengan.aspx";
    return false;
}
function showADD(v){        
    var s=document.getElementById('div_'+v);    
    if(s!=null)
    {
        if(s.style.display=='none')
            s.style.display='';
        else
            s.style.display='none';
    }
}
function goBack()
{
    location.href='quanlyngan.aspx';
    return false;
}
/*phieu nhap*/
    var idSoPN,txtmaphieu,txtngaylap,cboKHO,txtNCC,cboNCC,
    txtKHHD,txtsoHD,txtngayHD,
    cboNSP,cboTenSP,txtgianhap,txtsoluong;  
    
    var dp_cals,dp_cal;
    window.onload = function () {       
        dp_cals=new Epoch('epoch_popup','popup',document.getElementById(ctrlServer+'txtngay'));
        dp_cal=new Epoch('epoch_popup','popup',document.getElementById(ctrlServer+'txtngayhoadon'),false);
    }      
    function setNCC(idncc,tenncc)
	{
	    document.getElementById(ctrlServer+"idNCC").value=idncc;
	    document.getElementById(ctrlServer+"txtNCC").value=tenncc;
	    hideTip("tipbenhnhan");
	}    
    function showDanhSachNCC()
    {        
        var td = document.getElementById("tipncc");
        createTip(td,"tipbenhnhan","danhsachnoidungbenhnhan","Danh sách nhà cung cấp","ajaxbenhnhanexists"," đang load danh sách nhà cung cấp...","Lỗi trong quá trình load danh sách nhà cung cấp","ajax.aspx?do=getallncc", "950", "350");   
    }
    function showDanhSachPO()
    {
        var td = document.getElementById("tipncc");
        var idNCC= document.getElementById(ctrlServer+"idNCC");
        if(idNCC.value>0 && !isNaN(idNCC.value))
            createTip(td,"tipbenhnhan","danhsachnoidungbenhnhan","Danh sách đơn đặt hàng","ajaxbenhnhanexists"," đang load danh sách đơn đặt hàng...","Lỗi trong quá trình load danh sách đơn đặt hàng","ajax.aspx?do=getDSPO&MaKH="+idNCC.value, "950", "350");                
        else
            alert("Chưa có đơn đặt hàng cho phiếu này.");
    }  
    function DoActionPhieuNhap()
    { 
        idSoPN= document.getElementById(ctrlServer+"idSoPN");        
        txtmaphieu= document.getElementById(ctrlServer+"txtmaphieu");
        txtngaylap= document.getElementById(ctrlServer+"txtngaylap");
        cboKHO= document.getElementById(ctrlServer+"cboKHO");
        cboNCC= document.getElementById(ctrlServer+"cboNCC");        
        txtKHHD= document.getElementById(ctrlServer+"txtKHHD");
        txtsoHD= document.getElementById(ctrlServer+"txtsoHD");
        
        cboTenSP= document.getElementById(ctrlServer+"cboTenSP");
        txtgianhap= document.getElementById(ctrlServer+"txtgianhap");
        txtsoluong= document.getElementById(ctrlServer+"txtsoluong");               
        if(idSoPN.value=="0") //  them moi 1 phieu nhap
        {   
            if (CheckThongTinPhieuNhap() && CheckThongTinCTPhieuNhap())                            
                return true;
            return false;
        }
        else
        {
           if( CheckThongTinCTPhieuNhap())
           {
                return true;
           }
        }
	      
	    return false;
    }
    function CheckThongTinPhieuNhap()
    {
        if (txtmaphieu.value == "")
        {
            alert("Bạn chưa nhập số chứng từ. Vui lòng kiểm tra lại.");
            txtmaphieu.focus();
            return false ;
        }
        if (txtngaylap.value == "")
        {
            alert("Bạn chưa nhập ngày chứng từ. Vui lòng kiểm tra lại.");
            txtngay.focus();
            return false;
        }        
        if (cboKHO.value == "" || cboKHO.value == "0")
        {
            alert("Bạn chưa chọn kho nhập. Vui lòng kiểm tra lại.");
            cboKHO.focus();
            return false;
        }       
        
        if (cboNCC.value == "" || cboNCC.value == "0")
        {
            alert("Bạn chưa chọn nhà cung cấp. Vui lòng kiểm tra lại.");
            cboNCC.focus();
            return false;
        }                     
        if (txtKHHD.value == "" )
        {
            alert("Bạn chưa nhập ký hiệu hợp đồng. Vui lòng kiểm tra lại.");
            txtKHHD.focus();
            return false;
        }
        if (txtsoHD.value == "" )
        {
            alert("Bạn chưa nhập số hợp đồng. Vui lòng kiểm tra lại.");
            txtsoHD.focus();
            return false;
        }
        return true;
    }
    
    function CheckThongTinCTPhieuNhap()
    {
        if (cboTenSP.value == "0" ||cboTenSP.value == "")
        {
            alert("Bạn chưa chọn tên hàng. Vui lòng kiểm tra lại.");
            cboTenSP.focus();
            return false;
        }
        if (txtgianhap.value == "" || txtgianhap.value == "0")
        {
            alert("Bạn chưa nhập đơn giá nhập. Vui lòng kiểm tra lại.");
            txtgianhap.focus();
            return false;
        } 
        if (txtsoluong.value == "" ||txtsoluong.value == "0")
        {
            alert("Bạn chưa nhập số lượng nhập. Vui lòng kiểm tra lại.");
            txtsoluong.focus();
            return false;
        }               
        return true;
    }
    function getDate()
    {
        var t= document.getElementById(ctrlServer+"txtngaylap");
        t.value=insertDate("DD/MM/YYYY");
    }    