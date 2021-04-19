using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace CIS3342_TermProject
{
    public partial class ImageGrab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();
            DataSet ds;
            string strSql;

            if(Request.QueryString["ID"] != null)
            {
                strSql = "SELECT ImageData FROM TP_Photos Where UserID = " + Request.QueryString["ID"];
                ds = objDB.GetDataSet(strSql);

                byte[] imageData;
                imageData = (byte[])objDB.GetField("ImageData", 0);


                Response.Clear();
                Response.OutputStream.Write(imageData, 0, imageData.Length);
                Response.End();
                
            }
        }
    }
}