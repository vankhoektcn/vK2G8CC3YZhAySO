using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using hsLibrary;

namespace usercontrols
{
    public partial class Droplist : UserControl
    {
        #region Delegates

        public delegate void SelectChange(object sender, EventArgs e);

        #endregion

        private string _find = "";
        private string _hamlist = "";
        private string _hamkeyup = "chuyenphim(this);";
        private bool _boolCP = true;

        public string ID_DropList
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
            set { dlDefault.Attributes.Add("onchange", value); }
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
            set { divInDefaultRight.Attributes.Add("style", value); }
        }

        public string classDivInLeft
        {
            set { divInDefaultRight.Attributes.Add("class", value); }
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
            divList.InnerHtml = "<script>$(document).ready(function() {" + _hamlist + "});</script>";
            if (!_boolCP)
                _hamkeyup = "";
            dlDefault.Attributes.Add("onkeyup", _hamkeyup + _find + "");
        }

        protected void dlDefault_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SelectIndexChanged != null)
                SelectIndexChanged(sender, e);
        }
    }
}