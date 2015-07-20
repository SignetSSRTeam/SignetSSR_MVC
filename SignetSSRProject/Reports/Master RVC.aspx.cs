using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
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

                System.Net.ServicePointManager.Expect100Continue = false;

                ReportViewer1.ServerReport.ReportServerCredentials = new ReportServerNetworkCredentials(SSRCommon.ReportServerCredentials.REPORTSERVER_USERNAME, "Isc5672011");
                ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://192.245.222.208/ReportServer");

                string rptname = HttpContext.Current.Request.QueryString["Reportname"];
                string Viewdownload = HttpContext.Current.Request.QueryString["Viewdownload"];
                if (rptname == "Total Project Hours Worked By Job Classification")
                {
                    bool isReportDownload = Convert.ToBoolean(Viewdownload);
                    ReportViewer1.Visible = true;
                    ReportViewer1.ServerReport.ReportPath = string.Format(@"/SignetSSRReports/{0}", rptname);
                    string JobType = HttpContext.Current.Request.QueryString["JobType"];
                    //string[] JobType = QsVal.Split(',');
                    string BeginDate = HttpContext.Current.Request.QueryString["BeginDate"];
                    string EndDate = HttpContext.Current.Request.QueryString["EndDate"];
                    ReportViewer1.ServerReport.Refresh();
                    ReportParameter[] parameters = new ReportParameter[2];
                    string[] lsRateID = JobType.Split(',');
                    ReportParameter paramJobType = new ReportParameter("JobType");
                    paramJobType.Values.AddRange(lsRateID);       
                    ReportParameter paramBeginDate = new ReportParameter("BeginDate", BeginDate);
                    ReportParameter paramEndDate = new ReportParameter("EndDate", EndDate);
                    //this.ReportViewer1.LocalReport.SetParameters(parameters);
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramJobType });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramBeginDate });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramEndDate });

                    if (isReportDownload)
                    {
                        ReportViewer1.Visible = false;
                        string outputPath = String.Format("C:\\SignetReports\\{0} {1}.pdf", rptname, DateTime.Now.ToString("MM.dd.yyyy h.mm tt"));

                        lblMessage.Text = String.Format("Report has been saved to {0}", outputPath);
                        lblMessage.Visible = true;

                        string mimeType;
                        string encoding;
                        string extension;
                        string[] streams;
                        Warning[] warnings;
                        byte[] pdfBytes = ReportViewer1.ServerReport.Render("PDF", string.Empty, out mimeType,
                            out encoding, out extension, out streams, out warnings);

                        // save the file
                        using (FileStream fs = new FileStream(outputPath, FileMode.Create))
                        {
                            fs.Write(pdfBytes, 0, pdfBytes.Length);
                            fs.Close();
                        }

                    }
                }
                if (rptname == "Project hours worked weely")
                {
                    bool isReportDownload = Convert.ToBoolean(Viewdownload);
                    ReportViewer1.Visible = true;
                    ReportViewer1.ServerReport.ReportPath = string.Format(@"/SignetSSRReports/{0}", rptname);
                    ReportViewer1.ServerReport.Refresh();
                    string Date = HttpContext.Current.Request.QueryString["Date"];
                    //ReportParameter[] parameters = new ReportParameter[2];
                    ReportParameter paramDate = new ReportParameter("Date", Date);
                    //this.ReportViewer1.LocalReport.SetParameters(parameters);
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramDate });

                    if (isReportDownload)
                    {
                        ReportViewer1.Visible = false;
                        string outputPath = String.Format("C:\\SignetReports\\{0} {1}.pdf", rptname, DateTime.Now.ToString("MM.dd.yyyy h.mm tt"));

                        lblMessage.Text = String.Format("Report has been saved to {0}", outputPath);
                        lblMessage.Visible = true;

                        string mimeType;
                        string encoding;
                        string extension;
                        string[] streams;
                        Warning[] warnings;
                        byte[] pdfBytes = ReportViewer1.ServerReport.Render("PDF", string.Empty, out mimeType,
                            out encoding, out extension, out streams, out warnings);

                        // save the file
                        using (FileStream fs = new FileStream(outputPath, FileMode.Create))
                        {
                            fs.Write(pdfBytes, 0, pdfBytes.Length);
                            fs.Close();
                        }

                    }
                }
                if (rptname == "Hours Worked by Employee")
                {
                    bool isReportDownload =Convert.ToBoolean(Viewdownload);                    
                    
                    ReportViewer1.Visible = true;
                    ReportViewer1.ServerReport.ReportPath = string.Format(@"/SignetSSRReports/{0}", rptname);
                    ReportViewer1.ServerReport.Refresh();
                    string employeeID = HttpContext.Current.Request.QueryString["EmployeeID"];
                    string beginDate = HttpContext.Current.Request.QueryString["BeginDate"];
                    string endDate = HttpContext.Current.Request.QueryString["EndDate"];
                    ReportParameter[] parameters = new ReportParameter[3];

                    string[] lsEmpID = employeeID.Split(',');                    
                    ReportParameter parameid = new ReportParameter("EmployeeID");
                    parameid.Values.AddRange(lsEmpID);                    
                    
                    ReportParameter paramSTID = new ReportParameter("StartDate", beginDate);
                    ReportParameter paramEDT = new ReportParameter("EndDate", endDate);
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { parameid });
                    //this.ReportViewer1.LocalReport.SetParameters(parameters);

                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramSTID });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramEDT });

                    if (isReportDownload)
                    {
                        ReportViewer1.Visible = false;
                        string outputPath = String.Format("C:\\SignetReports\\{0} {1}.pdf", rptname, DateTime.Now.ToString("MM.dd.yyyy h.mm tt"));

                        lblMessage.Text = String.Format("Report has been saved to {0}", outputPath);
                        lblMessage.Visible = true;

                        string mimeType;
                        string encoding;
                        string extension;
                        string[] streams;
                        Warning[] warnings;
                        byte[] pdfBytes = ReportViewer1.ServerReport.Render("PDF", string.Empty, out mimeType,
                            out encoding, out extension, out streams, out warnings);

                        // save the file
                        using (FileStream fs = new FileStream(outputPath, FileMode.Create))
                        {
                            fs.Write(pdfBytes, 0, pdfBytes.Length);
                            fs.Close();
                        }

                    }

                    
                }
                if (rptname == "Employee Hours Worked Weekly")
                {
                    bool isReportDownload = Convert.ToBoolean(Viewdownload);
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

                    if (isReportDownload)
                    {
                        ReportViewer1.Visible = false;
                        string outputPath = String.Format("C:\\SignetReports\\{0} {1}.pdf", rptname, DateTime.Now.ToString("MM.dd.yyyy h.mm tt"));

                        lblMessage.Text = String.Format("Report has been saved to {0}", outputPath);
                        lblMessage.Visible = true;

                        string mimeType;
                        string encoding;
                        string extension;
                        string[] streams;
                        Warning[] warnings;
                        byte[] pdfBytes = ReportViewer1.ServerReport.Render("PDF", string.Empty, out mimeType,
                            out encoding, out extension, out streams, out warnings);

                        // save the file
                        using (FileStream fs = new FileStream(outputPath, FileMode.Create))
                        {
                            fs.Write(pdfBytes, 0, pdfBytes.Length);
                            fs.Close();
                        }

                    }
                }
                if (rptname == "Materials Expense Details")
                {
                    //string[] JobID = (string[])Session["Cart"];
                    bool isReportDownload = Convert.ToBoolean(Viewdownload);
                    ReportViewer1.Visible = true;
                    ReportViewer1.ServerReport.ReportPath = string.Format(@"/SignetSSRReports/{0}", rptname);
                    string JobID = HttpContext.Current.Request.QueryString["JobID"];
                    string StartDate = HttpContext.Current.Request.QueryString["BeginDate"];
                    string EndDate = HttpContext.Current.Request.QueryString["EndDate"];
                    ReportViewer1.ServerReport.Refresh();
                    ReportParameter[] parameters = new ReportParameter[3];
                    string[] lsJobID = JobID.Split(',');
                    ReportParameter paramJobID = new ReportParameter("JobID");
                    paramJobID.Values.AddRange(lsJobID);
                    ReportParameter paramStartDate = new ReportParameter("StartDate", StartDate);
                    ReportParameter paramEndDate = new ReportParameter("EndDate", EndDate);
                    //this.ReportViewer1.LocalReport.SetParameters(parameters);
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramJobID });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramStartDate });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramEndDate });

                    if (isReportDownload)
                    {
                        ReportViewer1.Visible = false;
                        string outputPath = String.Format("C:\\SignetReports\\{0} {1}.pdf", rptname, DateTime.Now.ToString("MM.dd.yyyy h.mm tt"));

                        lblMessage.Text = String.Format("Report has been saved to {0}", outputPath);
                        lblMessage.Visible = true;

                        string mimeType;
                        string encoding;
                        string extension;
                        string[] streams;
                        Warning[] warnings;
                        byte[] pdfBytes = ReportViewer1.ServerReport.Render("PDF", string.Empty, out mimeType,
                            out encoding, out extension, out streams, out warnings);

                        // save the file
                        using (FileStream fs = new FileStream(outputPath, FileMode.Create))
                        {
                            fs.Write(pdfBytes, 0, pdfBytes.Length);
                            fs.Close();
                        }

                    }
                }
                if (rptname == "ProfitSummary")
                {
                    bool isReportDownload = Convert.ToBoolean(Viewdownload);
                    ReportViewer1.Visible = true;
                    ReportViewer1.ServerReport.ReportPath = string.Format(@"/SignetSSRReports/{0}", rptname);
                    string JobID = HttpContext.Current.Request.QueryString["JobID"];
                    string CostOption = HttpContext.Current.Request.QueryString["CostOption"];
                    string Status = HttpContext.Current.Request.QueryString["Status"];
                    string BeginDate = HttpContext.Current.Request.QueryString["BeginDate"];
                    string EndDate = HttpContext.Current.Request.QueryString["EndDate"];
                    ReportViewer1.ServerReport.Refresh();
                    
                    ReportParameter[] parameters = new ReportParameter[5];
                    string[] lsJobID = JobID.Split(',');
                    ReportParameter paramJobID = new ReportParameter("JobID");
                    paramJobID.Values.AddRange(lsJobID);
                    ReportParameter paramCostOption = new ReportParameter("CostOption", CostOption);
                    string[] lsStatus = Status.Split(',');
                    ReportParameter paramJobStatus = new ReportParameter("Status");
                    paramJobStatus.Values.AddRange(lsStatus);
                    ReportParameter paramBeginDate = new ReportParameter("BeginDate", BeginDate);
                    ReportParameter paramEndDate = new ReportParameter("EndDate", EndDate);
                    
                    //this.ReportViewer1.LocalReport.SetParameters(parameters);
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramJobID });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramCostOption });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramJobStatus });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramBeginDate });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramEndDate });

                    if (isReportDownload)
                    {
                        ReportViewer1.Visible = false;
                        string outputPath = String.Format("C:\\SignetReports\\{0} {1}.pdf", rptname, DateTime.Now.ToString("MM.dd.yyyy h.mm tt"));

                        lblMessage.Text = String.Format("Report has been saved to {0}", outputPath);
                        lblMessage.Visible = true;

                        string mimeType;
                        string encoding;
                        string extension;
                        string[] streams;
                        Warning[] warnings;
                        byte[] pdfBytes = ReportViewer1.ServerReport.Render("PDF", string.Empty, out mimeType,
                            out encoding, out extension, out streams, out warnings);

                        // save the file
                        using (FileStream fs = new FileStream(outputPath, FileMode.Create))
                        {
                            fs.Write(pdfBytes, 0, pdfBytes.Length);
                            fs.Close();
                        }

                    }

                }
                if (rptname == "Specific Employee Absences and Tardiness Report")
                {
                    bool isReportDownload = Convert.ToBoolean(Viewdownload);
                    ReportViewer1.Visible = true;
                    ReportViewer1.ServerReport.ReportPath = string.Format(@"/SignetSSRReports/{0}", rptname);
                    string EmployeeID = HttpContext.Current.Request.QueryString["EmployeeID"];
                    string BeginDate = HttpContext.Current.Request.QueryString["BeginDate"];
                    string EndDate = HttpContext.Current.Request.QueryString["EndDate"];
                    ReportViewer1.ServerReport.Refresh();
                    ReportParameter[] parameters = new ReportParameter[2];
                    string[] lsEmpID = EmployeeID.Split(',');
                    ReportParameter paramEmployeeID = new ReportParameter("employeeID");
                    paramEmployeeID.Values.AddRange(lsEmpID); 
                    ReportParameter paramBeginDate = new ReportParameter("BeginDate", BeginDate);
                    ReportParameter paramEndDate = new ReportParameter("EndDate", EndDate);
                    //this.ReportViewer1.LocalReport.SetParameters(parameters);
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramEmployeeID });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramBeginDate });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramEndDate });

                    if (isReportDownload)
                    {
                        ReportViewer1.Visible = false;
                        string outputPath = String.Format("C:\\SignetReports\\{0} {1}.pdf", rptname, DateTime.Now.ToString("MM.dd.yyyy h.mm tt"));

                        lblMessage.Text = String.Format("Report has been saved to {0}", outputPath);
                        lblMessage.Visible = true;

                        string mimeType;
                        string encoding;
                        string extension;
                        string[] streams;
                        Warning[] warnings;
                        byte[] pdfBytes = ReportViewer1.ServerReport.Render("PDF", string.Empty, out mimeType,
                            out encoding, out extension, out streams, out warnings);

                        // save the file
                        using (FileStream fs = new FileStream(outputPath, FileMode.Create))
                        {
                            fs.Write(pdfBytes, 0, pdfBytes.Length);
                            fs.Close();
                        }

                    }
                }
                if (rptname == "Total Project Hours Worked on a given Month")
                {
                    bool isReportDownload = Convert.ToBoolean(Viewdownload);
                    ReportViewer1.Visible = true;
                    ReportViewer1.ServerReport.ReportPath = string.Format(@"/SignetSSRReports/{0}", rptname);
                    string month = HttpContext.Current.Request.QueryString["month"];
                    string Year = HttpContext.Current.Request.QueryString["Year"];
                    ReportViewer1.ServerReport.Refresh();
                    ReportParameter[] parameters = new ReportParameter[2];
                    ReportParameter parammonth = new ReportParameter("Month", month);
                    ReportParameter paramYear = new ReportParameter("YEAR", Year);
                    //this.ReportViewer1.LocalReport.SetParameters(parameters);
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { parammonth });
                    this.ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { paramYear });

                    if (isReportDownload)
                    {
                        ReportViewer1.Visible = false;
                        string outputPath = String.Format("C:\\SignetReports\\{0} {1}.pdf", rptname, DateTime.Now.ToString("MM.dd.yyyy h.mm tt"));

                        lblMessage.Text = String.Format("Report has been saved to {0}", outputPath);
                        lblMessage.Visible = true;

                        string mimeType;
                        string encoding;
                        string extension;
                        string[] streams;
                        Warning[] warnings;
                        byte[] pdfBytes = ReportViewer1.ServerReport.Render("PDF", string.Empty, out mimeType,
                            out encoding, out extension, out streams, out warnings);

                        // save the file
                        using (FileStream fs = new FileStream(outputPath, FileMode.Create))
                        {
                            fs.Write(pdfBytes, 0, pdfBytes.Length);
                            fs.Close();
                        }

                    }
                }
            }
        }
    }
}