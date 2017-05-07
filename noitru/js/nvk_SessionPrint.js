
function StartPrint() 
	{
	    var IsPrint=$.mkv.queryString('isPrint');
	    if (IsPrint=="1")
	    {
	    $.ajax({
            type: "GET",
		        cache: false,
		        dataType:"text",
		        url: "../ajax/nvk_frmTaoPhieuYCTheoToa_ajax.aspx?do=nvk_GetValuePrint",
		        success: function(value) {
		            var arr= value.split('~~');
		            if(arr[1] =="1")
		            { 
		                nvk_DisablePrint(arr[0]);
		            }
		            else
		            { 
		                nvk_EnablePrint(arr[0]);
		            }
		        }
            }); 
         }
         else
         {
		    nvk_EnablePrint("nvk_SessionPrint");
            //alert("Xem Thôi");
         }
	};
function nvk_EnablePrint(isSession)
{
    $.ajax({
            type: "GET",
		        cache: false,
		        dataType:"text",
		        url: "../ajax/nvk_frmTaoPhieuYCTheoToa_ajax.aspx?do=nvk_GetValuePrint&idsesiion="+isSession+"&EnablePrint=1",
		        success: function(value) {
		            var arr= value.split('~~');
		            if(arr[1] =="1")
		            {
		                $.mkv.queryString('isPrint',"0"); 
		            }
		            else
		            { alert("nvk_EnablePrint thất bại !");}
		        }
            });   
}
function nvk_DisablePrint(isSession)
{
    $.ajax({
            type: "GET",
		        cache: false,
		        dataType:"text",
		        url: "../ajax/nvk_frmTaoPhieuYCTheoToa_ajax.aspx?do=nvk_GetValuePrint&idsesiion="+isSession+"&EnablePrint=0",
		        success: function(value) {
		            var arr= value.split('~~');
		            //alert(arr[1]);
		            if(arr[1] =="0")
		            {
		                       document.getElementById("nvk_print").click();
		            }
		            else
		            { alert("nvk_DisablePrint thất bại !");}
		        }
            });   
}
