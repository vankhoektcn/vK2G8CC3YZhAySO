 $(document).ready(function() {
     $('#luu').click(function () {
        $(this).TimKiem({ajax:"../ajax/DoiMatKhau_ajax.aspx?do=luu",showPopup:false},function () {
            if($.trim($("#NewPass").val()).length < 1){
                $.mkv.myerror("Mật khẩu mới chưa có.");
                return false;
            }
            if($("#NewPass").val() == $("#ConfirmPass").val()){
                if(confirm("Xác nhận thay đổi mật khẩu mới."))
                    return true;
                else
                    return false;
            }
            else{
                $.mkv.myerror("Xác nhận mật khẩu không đúng.");
                return false;
            }
        },function (data) {
            if(data == "2")
            {
                $.mkv.myalert("Đã thay đổi mật khẩu thành công.",2000,"success");
            }else if(data == "4"){
                $.mkv.myerror("Tên đăng nhập không đúng.");   
            }else if(data == "1"){
                $.mkv.myerror("Mật khẩu hiện tại không đúng.");   
            }
            else{
                $.mkv.myerror("Đổi mật khẩu không thành công.");
            }
        });
     });
     $("#moi").click(function () {
        $(this).Moi();
     });
 });
