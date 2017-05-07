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

public partial class droplist : System.Web.UI.UserControl
{
    private string hamlist = "";
    private string find = "";
    protected void Page_Load(object sender, EventArgs e)
    {
            divList.InnerHtml = "<script>$(document).ready(function() {" + hamlist + "});</script>";
            @default.Attributes.Add("onkeyup", "chuyenphim(this);" + find + "");
    }

    public string id_
    {
        get { return this.@default.ID; }
        set{this.@default.ID = value;}
    }

    public string onchange
    {
        set
        {
            this.@default.Attributes.Add("onchange",value);
        }
    }

    public string onload
    {
        set { hamlist = value; }
    }

    public string FindFunction
    {
        set { find = value; }
    }

    public string title
    {
        set { this.lbdefault.Text = hsLibrary.clDictionaryDB.sGetValueLanguage(value); }
        get { return hsLibrary.clDictionaryDB.sGetValueLanguage(this.lbdefault.Text); }
    }
    public string value
    {
        set { this.@default.Value = value; }
        get { return this.@default.Value; }
    }
    public bool disabled
    {
        set { this.@default.Disabled = value; }
        get { return this.@default.Disabled; }
    }
    public string styleTextBox
    {
        set { @default.Style.Value = value; }
        get { return @default.Style.Value; }
    }
}
