using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Data.SqlClient;
using System.Threading;

//Barcode
using System.Collections.Generic;
using System.Text;
using OnBarcode.Barcode;
using System.Drawing.Imaging;


//ThuanNH 21/05/2010
public partial class ketoan_KTTSCD_Khauhaotaisan : System.Web.UI.Page
{
    public ArrayList arr = new ArrayList();
    public int i = 1;
    public int maxRecordOnPage = 10;
    public int curPage = 1;

    public void Page_Load(object sender, System.EventArgs e)
    {
        //Page_Init();        
    }
    
    public void LoadPage()
    {

    }

    private void kho_unload(object sender, System.EventArgs e)
    {
        i = 0;
        arr = null;
    }

    #region khoi tao va giai phong bo nho
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        InitialComponent();
    }
    private void InitialComponent()
    {
        this.Unload += new EventHandler(kho_unload);
    }
    #endregion
}
