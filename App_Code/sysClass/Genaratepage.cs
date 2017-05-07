using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.Collections;

public class Genaratepage : System.Web.UI.Page
{

    #region QLBV
    public bool IsBHYT = false;
    public string LoaiKham = "dv";
    public Genaratepage()
    {
        this.Load += new EventHandler(Genaratepage_Load);

    }

    void Genaratepage_Load(object sender, EventArgs e)
    {
        Response.Expires = -1000;
        Response.BufferOutput = true;

        this.LoaiKham = Request.QueryString["LoaiKham"];
        if (LoaiKham != null && LoaiKham != "")
        {
            if (LoaiKham.ToLower() == "bh")
                IsBHYT = true;
        }
    }
    #endregion
   

}

