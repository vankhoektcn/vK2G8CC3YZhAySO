using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using hsLibrary;

namespace usercontrols
{
    public partial class DropDownList : UserControl
    {
        #region Delegates

        public delegate void SelectChange(object sender, EventArgs e);

        #endregion

        private string _find = "";
        private string _hamlist = "";
        private string _hamkeyup = "chuyenphim(this);";
        private string errormessages = "This field is required";
        private bool requiredFields = false;
        private bool _boolCP = true;
        private string _hamonchange = "";

        public string ID_DropDownList
        {
            get { return dlDefault.ID; }
            set { dlDefault.ID = value; }
        }

        public bool boolChuyenPhim
        {
            set { _boolCP = value; }
            get { return _boolCP; }
        }

        public string onchange
        {
            set { _hamonchange = value; }
        }

        public string onload
        {
            set { _hamlist = value; }
            get { return _hamlist; }
        }

        public string FindFunction
        {
            set { _find = value; }
            get { return _find; }
        }

        public string Title
        {
            set { lbdefault.Text = clDictionaryDB.sGetValueLanguage(value); }
            get { return clDictionaryDB.sGetValueLanguage(lbdefault.Text); }
        }

        public bool Enabled_DropList
        {
            set { dlDefault.Enabled = value; }
            get { return dlDefault.Enabled; }
        }

        public bool AutoPostBack
        {
            set { dlDefault.AutoPostBack = value; }
            get { return dlDefault.AutoPostBack; }
        }

        public bool AppendNewItems
        {
            set { dlDefault.AppendDataBoundItems = value; }
            get { return dlDefault.AppendDataBoundItems; }
        }

        public string DefaultText_DropList
        {
            set { dlDefault.Items.Add(new ListItem(value, "")); }
        }

        public System.Web.UI.WebControls.DropDownList  ControlDropList
        {
            get { return dlDefault; }
        }

        public DataTable DataTable_DropList
        {
            set
            {
                dlDefault.DataSource = value;
                dlDefault.DataBind();
            }
        }

        public string ValueTable_DropList
        {
            set { dlDefault.DataValueField = value; }
            get { return dlDefault.DataValueField; }
        }

        public string TextTable_DropList
        {
            set { dlDefault.DataTextField = value; }
            get { return dlDefault.DataTextField; }
        }

        public string SelectedValue
        {
            set { dlDefault.SelectedValue = value; }
            get { return dlDefault.SelectedValue; }
        }

        public int SelectedIndex
        {
            set { dlDefault.SelectedIndex = value; }
            get { return dlDefault.SelectedIndex; }
        }
        public string SelectedText
        {
            set { dlDefault.SelectedItem.Text = value; }
            get { return dlDefault.SelectedItem.Text; }
        }

        public string value
        {
            get { return dlDefault.SelectedItem.Value; }
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

        public string styleTextBox
        {
            set { dlDefault.Style.Value = value; }
            get { return dlDefault.Style.Value; }
        }

        public string Text_BeforeTextBox
        {
            set { lbBeforeDroplist.Text = value; }
            get { return lbBeforeDroplist.Text; }
        }

        public string Text_AfterTextBox
        {
            set { lbAfterDroplist.Text = value; }
            get { return lbAfterDroplist.Text; }
        }

        public event SelectChange SelectIndexChanged;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            if (!_boolCP)
                _hamkeyup = "";
            dlDefault.Attributes.Add("onkeyup", _hamkeyup + _find + "");
            dlDefault.Attributes.Add("onchange",  _hamonchange);
            string html = "<script language=\"javascript\" type=\"text/javascript\">" + "\r\n"
            + " $().ready(function() {" + "\r\n"
            + "" + "\r\n"
            + "" + _hamlist + ";" + "\r\n"
            + "";
            html += " });" + "\r\n"
            + " </script>" + "\r\n";
            divList.InnerHtml = html;
            if (requiredFields)
            {
                dlDefault.CssClass = "required";
            }
        }

        protected void dlDefault_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SelectIndexChanged != null)
                SelectIndexChanged(sender, e);
        }

        public void SetDataDropList(DataTable table, string value, string text,string defaulValue,string defaultText)
        {
            dlDefault.Items.Add(new ListItem(defaultText, defaulValue));
            dlDefault.DataValueField = value;
            dlDefault.DataTextField = text;
            dlDefault.DataSource = table;
            dlDefault.DataBind();
        }
        public void Clear()
        {
            dlDefault.Items.Clear();
        }
        public bool requiredField
        {
            set { requiredFields = value; }
            get { return requiredFields; }
        }
        public string ErrorMessage
        {
            set { errormessages = value; }
            get { return errormessages; }
        }
    }
}