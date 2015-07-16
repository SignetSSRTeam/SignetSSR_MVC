using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Collections.Specialized.NameValueCollection;
//using System.Web.UI.Page;
//using System.Web.UI.ScriptManager;

using Microsoft.Reporting.WebForms;

namespace SignetSSRProject.Reports
{
    public partial class Reportweb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Net.ServicePointManager.Expect100Continue = false;

                myReportViewer.ServerReport.ReportServerCredentials = new ReportServerNetworkCredentials(SSRCommon.ReportServerCredentials.REPORTSERVER_USERNAME, "Isc5672011");
                myReportViewer.ServerReport.ReportServerUrl = new Uri("http://192.245.222.208/ReportServer");
                

                string JobType = HttpContext.Current.Request.QueryString["JobType"];
                string BeginDate = HttpContext.Current.Request.QueryString["BeginDate"];
                string EndDate = HttpContext.Current.Request.QueryString["EndDate"];

                //ReportParameter[] parameters = new ReportParameter[3];
                ReportParameter paramJobType = new ReportParameter("JobType", JobType);
                ReportParameter paramBeginDate = new ReportParameter("BeginDate", BeginDate);
                ReportParameter paramEndDate = new ReportParameter("EndDate", EndDate);

                myReportViewer.ServerReport.SetParameters(new ReportParameter[] { paramJobType });
                myReportViewer.ServerReport.SetParameters(new ReportParameter[] { paramBeginDate });
                myReportViewer.ServerReport.SetParameters(new ReportParameter[] { paramEndDate });

            }
            
        }


        
   


        /*protected void get_reports_Click(object sender, EventArgs e)
        {
            try
            {

                myReportViewer.ProcessingMode = ProcessingMode.Remote;

                myReportViewer.ServerReport.ReportServerUrl = new Uri("http://dileepthani9369:80/ReportServer");

                myReportViewer.ServerReport.ReportPath = "/SSRS Project/Report1";

                myReportViewer.ServerReport.Refresh();

            }

            catch (Exception ex)
            {

                Response.Write(ex.ToString());

            }
        }*/
        
    }
}