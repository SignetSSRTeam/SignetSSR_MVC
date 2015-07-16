using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignetSSRProject.Reports
{
    public partial class ReportCustomize : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!IsPostBack)
            {
                Populateddl();
            }*/
        }

        
        protected void viewonly_Click1(object sender, EventArgs e)
        {
            if (ddljobtype.SelectedIndex > 0)
            {
                Response.Redirect("Reportweb.aspx?Jobtype=" + ddljobtype.SelectedValue + "&Begindate=" + begindate.SelectedDate + "&Enddate=" + enddate.SelectedDate);

            }
        }

        
        
        /*public void Populateddl()
        {
            ddljobtype.Items.Add(new ListItem("DNU_In-house", "0"));
            ddljobtype.Items.Add(new ListItem("DNU_In-house", "1"));
            ddljobtype.Items.Add(new ListItem("DNU_In-house", "2"));
            ddljobtype.Items.Add(new ListItem("DNU_In-house", "3"));
            ddljobtype.Items.Add(new ListItem("DNU_In-house", "4"));

        }*/

        

        
    }
}