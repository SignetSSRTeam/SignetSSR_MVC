using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignetSSRProject.Reports
{
    public partial class ReportList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
           // {
             //   PopulateReportLinks();

          //  }
        }
    //    public void PopulateReportLinks()
      //  {
            
       // }
        protected void linkbtn1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportCustomize.aspx");
            
        }

        protected void btn_reportlink_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost/ReportServer");
        }

       
    }
}