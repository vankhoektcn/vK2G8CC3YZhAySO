using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Text;

public partial class noitru_ChonThuocBenhVien : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Button1.Style.Add("display", "none");
    }
    [WebMethod]
    public static string Result(string controlName)
    {
        return RenderControl(controlName);
    }

    public static string RenderControl(string controlName)
    {
        Page page = new Page();
        UserControl userControl = (UserControl)page.LoadControl(controlName);
        userControl.EnableViewState = false;
        HtmlForm form = new HtmlForm();
        form.Controls.Add(userControl);
        page.Controls.Add(form);

        StringWriter textWriter = new StringWriter();
        HttpContext.Current.Server.Execute(page, textWriter, false);
        return textWriter.ToString();

        //                         ajax:"../ajax/khambenh_ajax3.aspx?do=luuTablekhambenhcanlamsan&idkhambenh=" + $.mkv.queryString("idkhoachinh")+"&idbenhnhan="+$.mkv.queryString("idbenhnhan"),
        //                         tablename:"gridTablecls"
    }
}
