var today = new Date();
var dd = today.getDate();
var mm = today.getMonth() + 1;
var yyyy = today.getFullYear();
$(document).ready(function () {
    $("#timKiem").click(function () {
        Find(this);
    });
    $("#ddlKhoa").DropList({ ajax: "../ajax/frmDSBNKTCD_ajax.aspx?do=loaddskhoa&IdKhoa="+$.mkv.queryString("IdKhoa"), async: false }, null, function () {
        $("#ddlKhoa")[0].selectedIndex = 1;
        bindPhong($("#ddlKhoa").val());
    });
    if (dd < 10) { dd = '0' + dd }
    if (mm < 10) { mm = '0' + mm }
    $("#TuNgay").val(dd + "/" + mm + "/" + yyyy);
    $("#DenNgay").val(dd + "/" + mm + "/" + yyyy);
    $("#ddlKhoa").bind("change", function () {
        bindPhong($(this).val());
    });
    setTimeout(function () {
        $("#timKiem").click();
    }, 100);
    if ($.mkv.queryString("IsDaDuyet") != null && $.mkv.queryString("IsDaDuyet") == "1") {
        $(".header-div").html("Danh sách toa thuốc đã duyệt");
    }
   
});
function bindPhong(idkhoa) {
    $("#ddlPhong").DropList({ ajax: "../ajax/frmDSBNKTCD_ajax.aspx?do=loaddsphong&idkhoa=" + idkhoa, defaultVal: "- Chọn phòng -", async: true }, null, function () {
        $("#ddlPhong")[0].selectedIndex = 1;
        setTimeout(function () {
            $("#timKiem").click();
        }, 100);
    });
}

function Find(control, page) {
    if (page == null) page = "1";
    $(control).TimKiem({
        ajax: "../ajax/frmDSBNKTCD_ajax.aspx?do=TimKiem" + "&page=" + page, showPopup: false
    }, function () {
        $("#tableAjax_DSChoDuyet").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>');
        return true;
    }, function (data) {
        $("#tableAjax_DSTTNoiTru").html(data);
    });
}
function ViewDetailCD(idkhambenh)
{
            window.open("frmDSBNKTCDChitiet.aspx?idkhoachinh="+idkhambenh );
}