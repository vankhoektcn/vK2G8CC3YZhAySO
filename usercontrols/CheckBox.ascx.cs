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
using hsLibrary;
public partial class usercontrols_CheckBox : System.Web.UI.UserControl
{
    private bool _boolCp = true;

    private string _hamclick = "";

    private string _hamkeyup = "chuyenphim(this);";

    private string _hamfocus = "";

    public string Value_CheckBox
    {
        get { return cbDefault.Value; }
        set { cbDefault.Value = value; }
    }

    public bool boolChuyenPhim
    {
        set { _boolCp = value; }
        get { return _boolCp; }
    }

    public bool Checked
    {
        get { return cbDefault.Checked; }
        set { cbDefault.Checked = value; }
    }

    public string onclick
    {
        set { _hamclick = value; }
        get { return _hamclick; }
    }

    public string onfocus
    {
        set { _hamfocus = value; }
        get { return _hamfocus; }
    }

    public string styleDivOut
    {
        set { divDefaultOut.Attributes.Add("style", value); }
    }

    public string classDivOut
    {
        set { divDefaultOut.Attributes.Add("class", value); }
    }

    public string styleDivInRight
    {
        set { divInDefaultRight.Attributes.Add("style", value); }
    }

    public string classDivInRight
    {
        set { divInDefaultRight.Attributes.Add("class", value); }
    }

    public string styleDivInLeft
    {
        set { divInDefaultLeft.Attributes.Add("style", value); }
    }

    public string classDivInLeft
    {
        set { divInDefaultLeft.Attributes.Add("class", value); }
    }

    public string IDCheckBox
    {
        get { return cbDefault.ID; }
        set { cbDefault.ID = value; }
    }

    public string Title
    {
        get { return clDictionaryDB.sGetValueLanguage(lbdefault.Text); }
        set { lbdefault.Text = clDictionaryDB.sGetValueLanguage(value); }
    }

    public string styleCheckBox
    {
        set { cbDefault.Style.Value = value; }
        get { return cbDefault.Style.Value; }
    }

    public string Text_BeforeCheckBox
    {
        set { lbBeforeCheckBox.Text = value; }
        get { return lbBeforeCheckBox.Text; }
    }

    public string Text_AfterCheckBox
    {
        set { lbAfterCheckBox.Text = value; }
        get { return lbAfterCheckBox.Text; }
    }

    public bool Disabled_CheckBox
    {
        set { cbDefault.Disabled = value; }
        get { return cbDefault.Disabled; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!_boolCp)
        {
            _hamkeyup = "";
        }
        cbDefault.Attributes.Add("onclick", "" + _hamclick + "");
        cbDefault.Attributes.Add("onkeyup", "" + _hamkeyup + "");
        cbDefault.Attributes.Add("onfocus", "" + _hamfocus + "");
    }
}