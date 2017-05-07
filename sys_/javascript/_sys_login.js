 $(function(){
    $("#txt_User").focus();
   /*
    $("#chk_Save").change(function(){
        $.cookie("User",null);
        $.cookie("Password",null);
    });
     if($.cookie("User")){
        $("#txt_User").val($.cookie("User"));
        $("#txt_Password").val($.cookie("Password"));
        $("#chk_Save").attr("checked",true);
    }*/
    $("#txt_User").keyup(function(e){
         var key=(e.keyCode)? e.keyCode : ((e.charCode) ? e.charCode: e.which);
            if(key==13){            
                $("#txt_Password").focus();
            }
    });
    $("#txt_Password").keydown(function(e){
         var key=(e.keyCode)? e.keyCode : ((e.charCode) ? e.charCode: e.which);
            if(key==13){            
                $("#btnDangnhap").click();
            }
    });
     $("#btnDangnhap").click(function(){
        if($.trim($("#txt_User").val())==null || $.trim($("#txt_User").val())=="")
        {
            alert("Vui lòng nhập tên đăng nhập");
            $("#txt_User").focus();
             return false;
        }
        else
        {
            login();
        }
    });

 });
 login=function(){ 
    $.ajax({
        async:false,
        type:"post",
        url:"ajax/sys_login.aspx",
        data:{
            flag:"checkUser",
            username:$("#txt_User").val(),
            password:$("#txt_Password").val()
        },
        dataType:"json",
        success:function(data){
            if(data=="1"){
               /* if($("#chk_Save").attr("checked")){
                    $.cookie("User",$("#txt_User").val());
                    $.cookie("Password",$("#txt_Password").val());
                }else
                {
                    $.cookie("User",null);
                    $.cookie("Password",null);
                }*/
                window.location="../?islogin=1";
            }
            else
            {
                alert(data);
                return false;
            }
        }
    });
 }
