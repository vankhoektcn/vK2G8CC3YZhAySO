// JScript File

function getDateNow(ctr)
{
    var now = new Date();
    var date = now.getDay +"/" + now.getMonth +"/"+ now.getFullYear();
    document.getElementById(ctr) = date;
}