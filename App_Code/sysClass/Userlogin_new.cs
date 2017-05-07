using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
public class Userlogin_new : DataAcess.Connect
    {
        public static bool HavePermision(System.Web.UI.Page ClientCode, string PermName)
        {
           
            if (SysParameter.UserLogin.IsAdmin(ClientCode)) return true;
            string ID = SysParameter.UserLogin.UserID(ClientCode);
            if (ID == null || ID == "" || ID == "0") return false;
            string sqlSelect = ""
                            + " select count(*) from UserProfile A" + "\r\n"
                            + " left join Permision B on A.PermID=B.PermID" + "\r\n"
                            + " where B.PermName='" + PermName + "' and A.Status=1 and B.Status=1 and A.UserID=" + ID + "" + "\r\n";
            DataTable dt = GetTable(sqlSelect);
            if (dt == null) return false;
            if (dt.Rows[0][0].ToString() == "0") return false;
            return true;
        }//end void
    }//end class
