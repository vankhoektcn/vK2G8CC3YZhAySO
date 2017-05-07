﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ketoan_HDDV_DanhSachHoaDon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            string sql = "";
            sql = "select idloaixuat,tenloaixuat from thuoc_loaixuat where idloaixuat=1 or idloaixuat=2 or idloaixuat=8";
            DataTable dt = new DataTable();
            dt = DataAcess.Connect.GetTable(sql);
            StaticData.FillCombo(ddlloaixuat, dt, "idloaixuat", "tenloaixuat", "---Chọn loại xuất---");
        }
    }
}