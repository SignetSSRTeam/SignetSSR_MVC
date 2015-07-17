using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignetSSRProject.Reports
{
    public partial class Master_RVC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string rptname = HttpContext.Current.Request.QueryString["Reportname"];
                if (rptname == "Total Project Hours Worked By Job Classification")
                {
                    
                    ReportViewer1.Visible = true;
                    ReportViewer1.ServerReport.ReportPath = string.Format(@"/SignetSSRReports/{0}", rptname);
                    string JobType = HttpContext.Current.Request.QueryString["JobType"];
                    //string[] JobType = QsVal.Split(',');
                    string BeginDate = HttpContext.Current.Request.QueryString["BeginDate"];
                    string EndDate = HttpContext.Current.Request.QueryString["EndDate"];
                    ReportViewer1.ServerReport.Refresh();
                    ReportParameter[] parameters = new ReportParameter[2];
                    ReportParameter paramJobType = new ReportParameter("JobType", JobType);
                    ReportParameter paramBeginDate = new ReportParameter("BeginDate", BeginDate);
                    ReportParameter paramEndDate = new ReportParameter("EndDate", EndDate);
                    //this.ReportViewer1.LocalReport.SetParameters(parameters);
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramJobType });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramBeginDate });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramEndDate });
                }
                if (rptname == "Project hours worked weely")
                {
                    ReportViewer1.Visible = true;
                    ReportViewer1.ServerReport.ReportPath = string.Format(@"/SignetSSRReports/{0}", rptname);
                    ReportViewer1.ServerReport.Refresh();
                    string Date = HttpContext.Current.Request.QueryString["Date"];
                    //ReportParameter[] parameters = new ReportParameter[2];
                    ReportParameter paramDate = new ReportParameter("Date", Date);
                    //this.ReportViewer1.LocalReport.SetParameters(parameters);
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramDate });
                }
                if (rptname == "Hours Worked by Employee")
                {
                    ReportViewer1.Visible = true;
                    ReportViewer1.ServerReport.ReportPath = string.Format(@"/SignetSSRReports/{0}", rptname);
                    ReportViewer1.ServerReport.Refresh();
                    string eid = HttpContext.Current.Request.QueryString["eid"];
                    string STID = HttpContext.Current.Request.QueryString["STID"];
                    string EDT = HttpContext.Current.Request.QueryString["EDT"];
                    ReportParameter[] parameters = new ReportParameter[3];
                    ReportParameter parameid = new ReportParameter("eid", eid);
                    ReportParameter paramSTID = new ReportParameter("STID", STID);
                    ReportParameter paramEDT = new ReportParameter("EDT", EDT);
                    //this.ReportViewer1.LocalReport.SetParameters(parameters);

                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { parameid });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramSTID });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramEDT });
                }
                if (rptname == "Employee Hours Worked Weekly")
                {
                    ReportViewer1.Visible = true;
                    ReportViewer1.ServerReport.ReportPath = string.Format(@"/SignetSSRReports/{0}", rptname);
                    ReportViewer1.LocalReport.Refresh();

                    string ContractLaborer = HttpContext.Current.Request.QueryString["ContractLaborer"];
                    string Date = HttpContext.Current.Request.QueryString["Date"];
                    ReportParameter[] parameters = new ReportParameter[2];
                    ReportParameter paramContractLaborer = new ReportParameter("ContractLaborer", ContractLaborer);
                    ReportParameter paramDate = new ReportParameter("Date", Date);
                    //this.ReportViewer1.LocalReport.SetParameters(parameters);

                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramContractLaborer });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramDate });
                }
                if (rptname == "Materials Expense Details")
                {
                    //string[] JobID = (string[])Session["Cart"];
                    ReportViewer1.Visible = true;
                    ReportViewer1.ServerReport.ReportPath = string.Format(@"/SignetSSRReports/{0}", rptname);
                    string JobID = HttpContext.Current.Request.QueryString["JobID"];
                    string StartDate = HttpContext.Current.Request.QueryString["StartDate"];
                    string EndDate = HttpContext.Current.Request.QueryString["EndDate"];
                    ReportViewer1.ServerReport.Refresh();
                    ReportParameter[] parameters = new ReportParameter[3];
                    ReportParameter paramJobID = new ReportParameter("JobID", JobID);
                    ReportParameter paramStartDate = new ReportParameter("StartDate", StartDate);
                    ReportParameter paramEndDate = new ReportParameter("EndDate", EndDate);
                    //this.ReportViewer1.LocalReport.SetParameters(parameters);
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramJobID });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramStartDate });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramEndDate });
                }
                if (rptname == "ProfitSummary")
                {
                    ReportViewer1.Visible = true;
                    ReportViewer1.ServerReport.ReportPath = string.Format(@"/SignetSSRReports/{0}", rptname);
                    string JobID = HttpContext.Current.Request.QueryString["JobID"];
                    string CostOption = HttpContext.Current.Request.QueryString["CostOption"];
                    string Status = HttpContext.Current.Request.QueryString["Status"];
                    string BeginDate = HttpContext.Current.Request.QueryString["BeginDate"];
                    string EndDate = HttpContext.Current.Request.QueryString["EndDate"];
                    ReportViewer1.ServerReport.Refresh();
                    ReportParameter[] parameters = new ReportParameter[5];
                    ReportParameter paramJobID = new ReportParameter("JobID", JobID);
                    ReportParameter paramCostOption = new ReportParameter("CostOption", CostOption);
                    ReportParameter paramJobStatus = new ReportParameter("Status", Status);
                    ReportParameter paramBeginDate = new ReportParameter("BeginDate", BeginDate);
                    ReportParameter paramEndDate = new ReportParameter("EndDate", EndDate);
                    //this.ReportViewer1.LocalReport.SetParameters(parameters);
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramJobID });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramCostOption });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramJobStatus });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramBeginDate });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramEndDate });

                }
                if (rptname == "Specific Employee Absences and Tardiness Report")
                {
                    ReportViewer1.Visible = true;
                    ReportViewer1.ServerReport.ReportPath = string.Format(@"/SignetSSRReports/{0}", rptname);
                    string ReportParameter1 = HttpContext.Current.Request.QueryString["ReportParameter1"];
                    string BeginDate = HttpContext.Current.Request.QueryString["BeginDate"];
                    string EndDate = HttpContext.Current.Request.QueryString["EndDate"];
                    ReportViewer1.ServerReport.Refresh();
                    ReportParameter[] parameters = new ReportParameter[2];
                    ReportParameter paramReportParameter1 = new ReportParameter("ReportParameter1", ReportParameter1);
                    ReportParameter paramBeginDate = new ReportParameter("BeginDate", BeginDate);
                    ReportParameter paramEndDate = new ReportParameter("EndDate", EndDate);
                    //this.ReportViewer1.LocalReport.SetParameters(parameters);
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramReportParameter1 });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramBeginDate });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramEndDate });
                }
                if (rptname == "Total Project Hours Worked on a given Month")
                {
                    ReportViewer1.Visible = true;

                    ReportViewer1.ServerReport.ReportPath = string.Format(@"/SignetSSRReports/{0}", rptname);
                    string month = HttpContext.Current.Request.QueryString["month"];
                    string Year = HttpContext.Current.Request.QueryString["Year"];
                    ReportViewer1.ServerReport.Refresh();
                    ReportParameter[] parameters = new ReportParameter[2];
                    ReportParameter parammonth = new ReportParameter("month", month);
                    ReportParameter paramYear = new ReportParameter("Year", Year);
                    //this.ReportViewer1.LocalReport.SetParameters(parameters);
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { parammonth });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramYear });   
                }
            }
        }
    }
}