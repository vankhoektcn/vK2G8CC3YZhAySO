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

public partial class usercontrols_DateTime : System.Web.UI.UserControl
{
    private bool _boolCp = true;

    private string _hamblur = "TestDate(this);";
    private string _hamblur2 = "";

    private string _hamkeyup = "chuyenphim(this);";
    private string _hamkeyup2 = "";

    private bool requiredFields = false;
    private int requiredCharacter = 0;
    private string errormessages = "This field is required";

    private string _hamfocus = "";

    public string Text_TextBox
    {
        get { return txtDefault.Text; }
        set { txtDefault.Text = value; }
    }

    public bool boolChuyenPhim
    {
        set { _boolCp = value; }
        get { return _boolCp; }
    }

    public string onkeyup
    {
        set { _hamkeyup2 = value; }
        get { return _hamkeyup2; }
    }

    public string onblur
    {
        set { _hamblur2 = value; }
        get { return _hamblur2; }
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

    public string IDTextBox
    {
        get { return txtDefault.ID; }
        set { txtDefault.ID = value; }
    }

    public string Title
    {
        get { return clDictionaryDB.sGetValueLanguage(lbdefault.Text); }
        set { lbdefault.Text = clDictionaryDB.sGetValueLanguage(value); }
    }

    public string styleTextBox
    {
        set { txtDefault.Style.Value = value; }
        get { return txtDefault.Style.Value; }
    }

    public string Text_BeforeTextBox
    {
        set { lbBeforeText.Text = value; }
        get { return lbBeforeText.Text; }
    }

    public string Text_AfterTextBox
    {
        set { lbAfterText.Text = value; }
        get { return lbAfterText.Text; }
    }

    public bool Enabled_TextBox
    {
        set { txtDefault.Enabled = value; }
        get { return txtDefault.Enabled; }
    }
    public bool requiredField
    {
        set { requiredFields = value; }
        get { return requiredFields; }
    }

    public int requiredCharacters
    {
        set { requiredCharacter = value; }
        get { return requiredCharacter; }
    }
    public string ErrorMessage
    {
        set { errormessages = value; }
        get { return errormessages; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!_boolCp)
        {
            _hamkeyup = "";
        }
        txtDefault.Attributes.Add("onblur", "" + _hamblur + _hamblur2 + "");
        txtDefault.Attributes.Add("onkeyup", "" + _hamkeyup + _hamkeyup2 + "");
        txtDefault.Attributes.Add("onfocus", "" + _hamfocus + "");
        if (requiredFields == true)
        {
            ValidateRequest.ruleError += " 			" + txtDefault.UniqueID + ": {" + "\r\n"
                    + " 				required: true," + "\r\n"
                    + " 				minlength: " + requiredCharacters + "" + "\r\n"
                    + " 			}," + "\r\n";
        }

        if (requiredFields == true)
        {
            ValidateRequest.messageError += " 			" + txtDefault.UniqueID + ": {" + "\r\n"
                + " 				required: \"" + errormessages + "\"," + "\r\n"
                + " 				minlength: \"> " + requiredCharacter + " characters\"" + "\r\n"
                + " 			}," + "\r\n";
        }
    }
}
