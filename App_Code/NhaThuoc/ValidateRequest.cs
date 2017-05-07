using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for ValidateRequest
/// </summary>
public class ValidateRequest
{
    public ValidateRequest()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string ruleError = "";
    public static string messageError = "";
    public static string TotalError
    {
        get
        {
            string html = "<script language=\"javascript\" type=\"text/javascript\">" + "\r\n"
                + " $().ready(function() {" + "\r\n"
                + " 	$(\"#aspnetForm\").validate({" + "\r\n"
                + " 		rules: {" + "\r\n";
            html += ValidateRequest.ruleError;
            html += " 			tamthoi: {" + "\r\n"
                        + " 				required: true" + "\r\n"
                        + " 			}" + "\r\n";
            html += " 		}," + "\r\n"
                + " 		messages: {" + "\r\n";
            html += ValidateRequest.messageError;
            html += " 			tamthoi: {" + "\r\n"
                    + " 				required: \"Error\"" + "\r\n"
                    + " 			}" + "\r\n";
            html += " 		}" + "\r\n"
                + " 	});" + "\r\n"
                + " });" + "\r\n"
                + " </script>" + "\r\n";
            return html;
        }
    }
}
